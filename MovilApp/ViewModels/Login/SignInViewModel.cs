using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using MovilApp.Views;
using Service.Enums;
using Service.Models;
using Service.Services;
using System.Net.Http.Headers;

namespace MovilApp.ViewModels.Login
{
    public partial class SignInViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _clientAuth;
        private readonly GenericService<Usuario> _usuarioService;
        private readonly string FirebaseApiKey;
        private readonly string RequestUri;

        public IRelayCommand RegistrarseCommand { get; }
        public IRelayCommand VolverCommand { get; }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string name;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string lastname;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string dni;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string password;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string verifyPassword;

        [ObservableProperty]
        private bool estaDescargando;

        public SignInViewModel()
        {
            FirebaseApiKey = Service.Properties.Resources.ApiKeyFirebase;
            RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;
            _usuarioService = new GenericService<Usuario>();
            
            RegistrarseCommand = new AsyncRelayCommand(Registrarse, PermitirRegistrarse);
            VolverCommand = new AsyncRelayCommand(Volver);
            
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = FirebaseApiKey,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
        }

        private bool PermitirRegistrarse()
        {
            return !string.IsNullOrEmpty(Name) && 
                   !string.IsNullOrEmpty(Email) && 
                   !string.IsNullOrEmpty(Password) && 
                   !string.IsNullOrEmpty(VerifyPassword) && 
                   !string.IsNullOrEmpty(Dni) && 
                   !string.IsNullOrEmpty(Lastname);
        }

        private async Task Volver()
        {
            if (Application.Current?.MainPage is AgoraShell shell)
            {
                await shell.GoToAsync("//Login");
            }
        }

        private async Task Registrarse()
        {
            // Validaciones básicas
            if (string.IsNullOrEmpty(name) || 
                string.IsNullOrEmpty(lastname) || 
                string.IsNullOrEmpty(dni) || 
                string.IsNullOrEmpty(email) || 
                string.IsNullOrEmpty(password) || 
                string.IsNullOrEmpty(verifyPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Por favor complete todos los campos obligatorios", "Ok");
                return;
            }

            // Validar formato del DNI
            if (!IsValidDNI(dni))
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "El formato del DNI no es válido", "Ok");
                return;
            }

            // Verificar que el DNI no esté duplicado
            var dniExists = await CheckDNIExists(dni);
            if (dniExists)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "El DNI ingresado ya está registrado en el sistema", "Ok");
                return;
            }

            // Validar que las contraseñas coincidan
            if (password != verifyPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Las contraseñas ingresadas no coinciden", "Ok");
                return;
            }

            // Validar longitud mínima de contraseña
            if (password.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "La contraseña debe tener mínimo 6 caracteres", "Ok");
                return;
            }

            EstaDescargando = true;

            try
            {
                var fullname = name + " " + lastname;
                
                // 1. Crear usuario en Firebase
                var user = await _clientAuth.CreateUserWithEmailAndPasswordAsync(email, password, fullname);
                
                // 2. Crear usuario en la base de datos SQL como EMPLEADO
                var usuarioResponse = await CreateEmpleadoInDatabase(fullname, dni, email);
                
                if (usuarioResponse != null && usuarioResponse.ID > 0)
                {
                    // 3. Enviar email de verificación
                    await SendVerificationEmailAsync(user.User.GetIdTokenAsync().Result);
                    
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "¡Cuenta de empleado creada correctamente! Por favor verifica tu correo electrónico.", "Ok");
                    
                    // Volver al login
                    if (Application.Current?.MainPage is AgoraShell shell)
                    {
                        await shell.GoToAsync("//Login");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "Error al registrar en la base de datos", "Ok");
                }
            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un problema: " + error.Reason, "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Error al registrarse: " + ex.Message, "Ok");
            }
            finally
            {
                EstaDescargando = false;
            }
        }

        private async Task<Usuario?> CreateEmpleadoInDatabase(string nombre, string dni, string email)
        {
            try
            {
                // Crear usuario con rol de EMPLEADO (orientado a la app móvil)
                var usuario = new Usuario
                {
                    Nombre = nombre,
                    DNI = dni,
                    Email = email,
                    TipoUsuario = TipoUsuarioEnum.Empleado  // Rol de Empleado para usuarios de la app móvil
                };

                return await _usuarioService.AddAsync(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear empleado: {ex.Message}");
                throw;
            }
        }

        private bool IsValidDNI(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return false;

            // Eliminar espacios y puntos
            var cleanDni = dni.Trim().Replace(" ", "").Replace(".", "");

            // Verificar longitud mínima y máxima
            if (cleanDni.Length < 5 || cleanDni.Length > 20)
                return false;

            // Permitir números, letras y guiones (para diferentes formatos de DNI/NIE/Pasaporte)
            return cleanDni.All(c => char.IsLetterOrDigit(c) || c == '-');
        }

        private async Task<bool> CheckDNIExists(string dni)
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync("") ?? new List<Usuario>();
                return usuarios.Any(u => string.Equals(u.DNI, dni, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar DNI: {ex.Message}");
                return false; // En caso de error, permitir continuar
            }
        }

        public async Task SendVerificationEmailAsync(string idToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent("{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + idToken + "\"}");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(RequestUri, content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
