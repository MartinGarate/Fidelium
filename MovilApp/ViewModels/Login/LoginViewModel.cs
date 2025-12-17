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
using System.Text.RegularExpressions;

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
        private int _failedAttempts = 0;
        private DateTime _lastFailedAttempt = DateTime.MinValue;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string email = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password = string.Empty;

        [ObservableProperty]
        private bool recordarContraseña;

        [ObservableProperty]
        private bool estaDescargando;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private bool hasError;

        [ObservableProperty]
        private bool isBlocked;

        [ObservableProperty]
        private int remainingTime;

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
            
            IniciarSesionCommand = new AsyncRelayCommand(IniciarSesion, PermitirIniciarSesion);
            RegistrarseCommand = new AsyncRelayCommand(Registrarse);
        }

        private async Task Registrarse()
        {
            try
            {
                ClearError();
                if (Application.Current?.MainPage is AgoraShell shell)
                {
                    await shell.GoToAsync("//Registrarse");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al navegar: {ex.Message}");
            }
        }

        private async void ChequearSiHayUsuarioAlmacenado()
        {
            try
            {
                if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    if (_userRepository.UserExists())
                    {
                        (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                        // Verificar que el token no haya expirado
                        if (_firebaseCredential != null && IsTokenValid(_firebaseCredential))
                        {
                            if (Application.Current?.MainPage is AgoraShell shell)
                            {
                                shell.SetLoginState(true);
                            }
                        }
                        else
                        {
                            // Token expirado, eliminar usuario guardado
                            _userRepository.DeleteUser();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al verificar sesión guardada: {ex.Message}");
                // Limpiar datos corruptos
                try
                {
                    _userRepository.DeleteUser();
                }
                catch { }
            }
        }

        private bool IsTokenValid(FirebaseCredential credential)
        {
            try
            {
                // Verificar si el credential tiene información válida
                return credential != null && !string.IsNullOrEmpty(credential.IdToken);
            }
            catch
            {
                return false;
            }
        }

        private bool PermitirIniciarSesion()
        {
            return !string.IsNullOrWhiteSpace(Email) && 
                   !string.IsNullOrWhiteSpace(Password) && 
                   !EstaDescargando && 
                   !IsBlocked;
        }

        private async Task IniciarSesion()
        {
            ClearError();

            try
            {
                // Verificar bloqueo por intentos fallidos
                if (CheckIfBlocked())
                {
                    ShowError($"Demasiados intentos fallidos. Espere {RemainingTime} segundos.");
                    return;
                }

                // Validar entrada
                var validationResult = ValidateLoginData();
                if (!validationResult.IsValid)
                {
                    ShowError(validationResult.ErrorMessage);
                    return;
                }

                EstaDescargando = true;
                
                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(Email.Trim().ToLowerInvariant(), Password);
                
                if (userCredential?.User?.Info == null)
                {
                    ShowError("Error en la autenticación. Intente nuevamente.");
                    return;
                }

                if (!userCredential.User.Info.IsEmailVerified)
                {
                    ShowError("Debe verificar su correo electrónico antes de iniciar sesión.");
                    return;
                }

                // Verificar si el usuario existe en la base de datos
                await EnsureUserExistsInDatabase(userCredential.User.Info.Email, userCredential.User.Info.DisplayName);

                // Guardar credenciales si el usuario lo desea
                if (RecordarContraseña)
                {
                    try
                    {
                        _userRepository.SaveUser(userCredential.User);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al guardar credenciales: {ex.Message}");
                        // No interrumpir el login por este error
                    }
                }
                else
                {
                    try
                    {
                        _userRepository.DeleteUser();
                    }
                    catch { }
                }

                // Resetear intentos fallidos en login exitoso
                _failedAttempts = 0;

                if (Application.Current?.MainPage is AgoraShell shell)
                {
                    shell.SetLoginState(true);
                }
            }
            catch (FirebaseAuthException error)
            {
                HandleFailedLogin();
                ShowError(GetFirebaseErrorMessage(error.Reason));
            }
            catch (Exception ex)
            {
                HandleFailedLogin();
                ShowError($"Error inesperado: {ex.Message}");
            }
            finally
            {
                EstaDescargando = false;
            }
        }

        private (bool IsValid, string ErrorMessage) ValidateLoginData()
        {
            if (string.IsNullOrWhiteSpace(Email))
                return (false, "El email es requerido");

            if (string.IsNullOrWhiteSpace(Password))
                return (false, "La contraseña es requerida");

            if (!IsValidEmail(Email))
                return (false, "El formato del email no es válido");

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

        private bool CheckIfBlocked()
        {
            if (_failedAttempts >= 3)
            {
                var timeSinceLastAttempt = DateTime.Now - _lastFailedAttempt;
                var blockDuration = TimeSpan.FromMinutes(5); // 5 minutos de bloqueo

                if (timeSinceLastAttempt < blockDuration)
                {
                    IsBlocked = true;
                    RemainingTime = (int)(blockDuration - timeSinceLastAttempt).TotalSeconds;
                    
                    // Iniciar countdown
                    StartCountdown();
                    
                    return true;
                }
                else
                {
                    // Reset después del tiempo de bloqueo
                    _failedAttempts = 0;
                    IsBlocked = false;
                    RemainingTime = 0;
                }
            }

            return false;
        }

        private void HandleFailedLogin()
        {
            _failedAttempts++;
            _lastFailedAttempt = DateTime.Now;

            if (_failedAttempts >= 3)
            {
                IsBlocked = true;
                RemainingTime = 300; // 5 minutos en segundos
                StartCountdown();
            }
        }

        private async void StartCountdown()
        {
            while (RemainingTime > 0 && IsBlocked)
            {
                await Task.Delay(1000);
                RemainingTime--;
            }

            if (RemainingTime <= 0)
            {
                IsBlocked = false;
                _failedAttempts = 0;
            }
        }

        private async Task EnsureUserExistsInDatabase(string email, string displayName)
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync("");
                var usuarioExistente = usuarios?.FirstOrDefault(u => 
                    string.Equals(u.Email?.Trim(), email?.Trim(), StringComparison.OrdinalIgnoreCase));

                if (usuarioExistente == null)
                {
                    var dniTemporal = $"TEMP_{DateTime.Now:yyyyMMddHHmmss}";
                    
                    var nuevoUsuario = new Usuario
                    {
                        Nombre = string.IsNullOrWhiteSpace(displayName) ? "Usuario" : displayName.Trim(),
                        DNI = dniTemporal,
                        Email = email?.Trim().ToLowerInvariant(),
                        TipoUsuario = TipoUsuarioEnum.Empleado
                    };

                    await _usuarioService.AddAsync(nuevoUsuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar/crear usuario en BD: {ex.Message}");
                // No lanzamos la excepción para no interrumpir el flujo de login
            }
        }

        private string GetFirebaseErrorMessage(AuthErrorReason reason)
        {
            return reason switch
            {
                AuthErrorReason.InvalidEmailAddress => "Email o contrasena no válido",
                AuthErrorReason.UserNotFound => "Usuario no encontrado",
                AuthErrorReason.WrongPassword => "Contraseña incorrecta",
                AuthErrorReason.UserDisabled => "Cuenta deshabilitada",
                AuthErrorReason.TooManyAttemptsTryLater => "Demasiados intentos. Espere unos minutos",
                _ => "Error de autenticación. Intente nuevamente"
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
    }
}

