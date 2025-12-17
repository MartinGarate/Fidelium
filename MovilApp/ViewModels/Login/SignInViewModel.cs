using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using MovilApp.Views;
using Service.Enums;
using Service.Models;
using Service.Services;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

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
        private string name = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string dni = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string email = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string password = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string verifyPassword = string.Empty;

        [ObservableProperty]
        private bool estaDescargando;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private bool hasError;

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
            return !string.IsNullOrWhiteSpace(Name) && 
                   !string.IsNullOrWhiteSpace(Email) && 
                   !string.IsNullOrWhiteSpace(Password) && 
                   !string.IsNullOrWhiteSpace(VerifyPassword) && 
                   !string.IsNullOrWhiteSpace(Dni) && 
                   !EstaDescargando;
        }

        private async Task Volver()
        {
            try
            {
                ClearError();
                if (Application.Current?.MainPage is AgoraShell shell)
                {
                    await shell.GoToAsync("//Login");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al navegar: {ex.Message}");
            }
        }

        private async Task Registrarse()
        {
            ClearError();

            try
            {
                // Validaciones mejoradas
                var validationResult = ValidateRegistrationData();
                if (!validationResult.IsValid)
                {
                    ShowError(validationResult.ErrorMessage);
                    return;
                }

                EstaDescargando = true;

                var fullname = Name.Trim();
                var emailTrimmed = Email.Trim().ToLowerInvariant();
                var dniTrimmed = Dni.Trim().ToUpperInvariant();

                // Crear en Firebase (validará email duplicado)
                try
                {
                    var user = await _clientAuth.CreateUserWithEmailAndPasswordAsync(emailTrimmed, Password, fullname);
                    
                    // Si Firebase fue exitoso, crear en la base de datos SQL
                    var usuario = new Usuario
                    {
                        Nombre = fullname,
                        DNI = dniTrimmed,
                        Email = emailTrimmed,
                        TipoUsuario = TipoUsuarioEnum.Empleado
                    };

                    var usuarioResponse = await _usuarioService.AddAsync(usuario);
                    
                    if (usuarioResponse != null && usuarioResponse.ID > 0)
                    {
                        // Enviar email de verificación
                        var idToken = await user.User.GetIdTokenAsync();
                        await SendVerificationEmailAsync(idToken);
                        
                        await Application.Current.MainPage.DisplayAlert("Registro Exitoso", 
                            "¡Cuenta de empleado creada correctamente!\nPor favor verifica tu correo electrónico antes de iniciar sesión.", "Entendido");
                        
                        // Limpiar campos
                        ClearFields();
                        
                        // Volver al login
                        if (Application.Current?.MainPage is AgoraShell shell)
                        {
                            await shell.GoToAsync("//Login");
                        }
                    }
                    else
                    {
                        ShowError("Error al registrar en la base de datos. Intente nuevamente.");
                    }
                }
                catch (FirebaseAuthException firebaseError)
                {
                    ShowError(GetFirebaseErrorMessage(firebaseError.Reason));
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error inesperado: {ex.Message}");
                Console.WriteLine($"Error en Registrarse: {ex}");
            }
            finally
            {
                EstaDescargando = false;
            }
        }

        private (bool IsValid, string ErrorMessage) ValidateRegistrationData()
        {
            // Validar campos requeridos
            if (string.IsNullOrWhiteSpace(Name))
                return (false, "El nombre es requerido");
            
            if (string.IsNullOrWhiteSpace(Dni))
                return (false, "El DNI es requerido");
            
            if (string.IsNullOrWhiteSpace(Email))
                return (false, "El email es requerido");
            
            if (string.IsNullOrWhiteSpace(Password))
                return (false, "La contraseña es requerida");
            
            if (string.IsNullOrWhiteSpace(VerifyPassword))
                return (false, "Debe confirmar la contraseña");

            // Validar nombre
            if (Name.Trim().Length < 2)
                return (false, "El nombre debe tener al menos 2 caracteres");

         

            // Validar formato del email
            if (!IsValidEmail(Email))
                return (false, "El formato del email no es válido");

            // Validar formato del DNI
            if (!IsValidDNI(Dni))
                return (false, "El formato del DNI no es válido");

            // Validar contraseña
            var passwordValidation = ValidatePassword(Password);
            if (!passwordValidation.IsValid)
                return (false, passwordValidation.ErrorMessage);

            // Verificar que las contraseñas coincidan
            if (Password != VerifyPassword)
                return (false, "Las contraseñas no coinciden");

            return (true, string.Empty);
        }

        private (bool IsValid, string ErrorMessage) ValidatePassword(string password)
        {
            if (password.Length < 8)
                return (false, "La contraseña debe tener al menos 8 caracteres");

            if (!password.Any(char.IsUpper))
                return (false, "La contraseña debe contener al menos una mayúscula");

            if (!password.Any(char.IsLower))
                return (false, "La contraseña debe contener al menos una minúscula");

            if (!password.Any(char.IsDigit))
                return (false, "La contraseña debe contener al menos un número");

            return (true, string.Empty);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email?.Trim() ?? string.Empty);
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidDNI(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return false;

            var cleanDni = dni.Trim().Replace(" ", "").Replace(".", "").Replace("-", "");

            if (cleanDni.Length < 6 || cleanDni.Length > 20)
                return false;

            return cleanDni.All(c => char.IsLetterOrDigit(c));
        }

        private async Task<bool> CheckDNIExists(string dni)
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync("") ?? new List<Usuario>();
                return usuarios.Any(u => string.Equals(u.DNI?.Trim(), dni.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar DNI: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> CheckEmailExists(string email)
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync("") ?? new List<Usuario>();
                return usuarios.Any(u => string.Equals(u.Email?.Trim(), email.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar email: {ex.Message}");
                return false;
            }
        }

        public async Task SendVerificationEmailAsync(string idToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(30);

            var content = new StringContent($"{{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"{idToken}\"}}");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(RequestUri, content);
            response.EnsureSuccessStatusCode();
        }

        private string GetFirebaseErrorMessage(AuthErrorReason reason)
        {
            return reason switch
            {
                AuthErrorReason.EmailExists => "Este email ya está registrado",
                AuthErrorReason.InvalidEmailAddress => "El email no es válido",
                AuthErrorReason.WeakPassword => "La contraseña es muy débil",
                AuthErrorReason.TooManyAttemptsTryLater => "Demasiados intentos. Espere unos minutos",
                _ => $"Error de autenticación: {reason}"
            };
        }

        private void ShowError(string message)
        {
            ErrorMessage = message;
            HasError = true;
        }

        private void ClearError()
        {
            ErrorMessage = string.Empty;
            HasError = false;
        }

        private void ClearFields()
        {
            Name = string.Empty;
            Dni = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            VerifyPassword = string.Empty;
        }
    }
}
