using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Storage;
using MovilApp.Views;
using Service.Enums;
using Service.Models;
using Service.Services;

namespace MovilApp.ViewModels.Login
{
    public partial class LoginViewModel : ObservableObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;
        private readonly GenericService<Usuario> _usuarioService;
        private readonly GenericService<Cliente> _clienteService;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password;

        [ObservableProperty]
        private bool recordarContraseña;

        [ObservableProperty]
        private bool estaDescargando;


        public IRelayCommand IniciarSesionCommand { get; }
        public IRelayCommand RegistrarseCommand { get; }

        public LoginViewModel()
        {
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = Service.Properties.Resources.ApiKeyFirebase,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("AgoraMovilApp");
            _usuarioService = new GenericService<Usuario>();
            _clienteService = new GenericService<Cliente>();
            
            ChequearSiHayUsuarioAlmacenado();
            
            IniciarSesionCommand = new RelayCommand(IniciarSesion, PermitirIniciarSesion);
            RegistrarseCommand = new RelayCommand(Registrarse);
        }

        private async void Registrarse()
        {
            if (Application.Current?.MainPage is AgoraShell shell)
            {
                await shell.GoToAsync("//Registrarse");
            }
        }

        private async void ChequearSiHayUsuarioAlmacenado()
        {
            //_userRepository.DeleteUser(); // Por temas de testing
            //if la aplicación se ejecuta en android o ios chequea si hay un usuario almacenado
            if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
            {
                try
                {
                    if (_userRepository.UserExists())
                    {
                        (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                        if (Application.Current?.MainPage is AgoraShell shell)
                        {
                            shell.SetLoginState(true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Ocurrió un problema al leer el usuario almacenado: " + ex.Message, "Ok");
                }
            }
        }

        private bool PermitirIniciarSesion()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private async void IniciarSesion()
        {
            try
            {
                EstaDescargando = true;
                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(email, password);
                
                if (userCredential.User.Info.IsEmailVerified == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico", "Ok");
                    EstaDescargando = false;
                    return;
                }

                // Verificar si el usuario existe en la base de datos, si no crearlo como Empleado
                await EnsureUserExistsInDatabase(userCredential.User.Info.Email, userCredential.User.Info.DisplayName);

                if (recordarContraseña)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                if (Application.Current?.MainPage is AgoraShell shell)
                {
                    shell.SetLoginState(true);
                }
                EstaDescargando = false;
            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema:" + error.Reason, "Ok");
                EstaDescargando = false;
            }
        }

        private async Task EnsureUserExistsInDatabase(string email, string displayName)
        {
            try
            {
                // Buscar si el usuario ya existe usando el servicio genérico
                var usuarios = await _usuarioService.GetAllAsync("");
                var usuarioExistente = usuarios?.FirstOrDefault(u => u.Email == email);

                if (usuarioExistente == null)
                {
                    // Generar un DNI temporal que puede ser actualizado después
                    var dniTemporal = $"TEMP_{DateTime.Now:yyyyMMddHHmmss}";
                    
                    // Crear nuevo usuario con rol de EMPLEADO (orientado a la app móvil)
                    var nuevoUsuario = new Usuario
                    {
                        Nombre = displayName ?? "Usuario",
                        DNI = dniTemporal,
                        Email = email,
                        TipoUsuario = TipoUsuarioEnum.Empleado  // Rol de Empleado para usuarios de la app móvil
                    };

                    var usuarioCreado = await _usuarioService.AddAsync(nuevoUsuario);

                    // Nota: Los empleados NO necesitan registro en la tabla Cliente
                    // Solo los clientes que se registran desde el WebBlazor tienen entrada en Cliente
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asegurar usuario en BD: {ex.Message}");
                // No lanzamos la excepción para no interrumpir el flujo de login
            }
        }
    }
}

