using Microsoft.JSInterop;
using Service.Models.Login;

namespace webBlazor.Services
{
    public class FirebaseAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        public event Action OnChangeLogin;
        public FirebaseUser CurrentUser { get; set; }

        public FirebaseAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<FirebaseUser?> SignInWithEmailPassword(string email, string password, bool rememberPassword)
        {
            var user = await _jsRuntime.InvokeAsync<FirebaseUser?>("firebaseAuth.signInWithEmailPassword", email, password, rememberPassword);
            if (user != null)
            {
                CurrentUser = user;
                if (user.EmailVerified)
                    OnChangeLogin?.Invoke();
            }
            return user;
        }

        public async Task<string> createUserWithEmailAndPassword(string email, string password, string displayName)
        {
            var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.createUserWithEmailAndPassword", email, password, displayName);
            if (userId != null)
            {
                OnChangeLogin?.Invoke();
            }
            return userId;
        }

        public async Task SignOut()
        {
            await _jsRuntime.InvokeVoidAsync("firebaseAuth.signOut");
            CurrentUser = null;
            OnChangeLogin?.Invoke();
        }

        public async Task<FirebaseUser?> GetUserFirebase()
        {
            var userFirebase = await _jsRuntime.InvokeAsync<FirebaseUser>("firebaseAuth.getUserFirebase");
            CurrentUser = userFirebase;
            return userFirebase;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var user = await GetUserFirebase();
            return user != null && user.EmailVerified;

        }

        public async Task<FirebaseUser?> LoginWithGoogle()
        {
            var userFirebase = await _jsRuntime.InvokeAsync<FirebaseUser>("firebaseAuth.loginWithGoogle");
            CurrentUser = userFirebase;
            OnChangeLogin?.Invoke();
            return userFirebase;
        }

        /// <summary>
        /// Obtiene el nombre de usuario actual. Si no está cacheado, lo obtiene de Firebase.
        /// </summary>
        public async Task<string> GetUserDisplayName()
        {
            // Si ya tenemos el usuario en caché, usamos su DisplayName
            if (CurrentUser != null)
                return CurrentUser.DisplayName ?? "Usuario";

            // Si no está cacheado, lo obtenemos de Firebase
            var user = await GetUserFirebase();
            return user?.DisplayName ?? "Usuario";
        }
    }
}