using Microsoft.JSInterop;
using Service.Models.Login;

namespace webBlazor.Services
{
    public class FirebaseAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserIdKey = "fideliumUser";
        public event Action OnChangeLogin;

        public FirebaseAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<FirebaseUser> SignInWithEmailPassword(string email, string password)
        {
            var user = await _jsRuntime.InvokeAsync<FirebaseUser?>("firebaseAuth.signInWithEmailPassword", email, password);
            if (user != null)
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, user.Uid);
                OnChangeLogin?.Invoke();
            }
            return user;
        }

        public async Task<string> createUserWithEmailAndPassword(string email, string password, string displayName)
        {
            var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.createUserWithEmailAndPassword", email, password, displayName);
            //if (userId != null)
            //{
            //    await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, userId);
            //    OnChangeLogin?.Invoke();
            //}
            return userId;
        }

        public async Task SignOut()
        {
            //Console.WriteLine("Ejecutando SignOut...");
            await _jsRuntime.InvokeVoidAsync("firebaseAuth.signOut");
            //Console.WriteLine("Sesión cerrada en Firebase.");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", UserIdKey);
            //Console.WriteLine("Clave eliminada de localStorage.");
            OnChangeLogin?.Invoke();
            //Console.WriteLine("Evento OnChangeLogin invocado.");
        }

        public async Task<string> GetUserId()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", UserIdKey);
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var userId = await GetUserId();
            Console.WriteLine($"Valor recuperado de localStorage: {userId}");
            return !string.IsNullOrEmpty(userId);
        }

        
    }
}
