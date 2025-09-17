namespace webBlazor.Services
{
    public class AuthenticationStateService
    {
        public bool IsAuthenticated { get; private set; }

        public event Action? OnAuthenticationStateChanged;

        public void SetAuthenticationState(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
            OnAuthenticationStateChanged?.Invoke();
        }
    }
}

