namespace webBlazor.Services
{
    // Permite saber si el usuario está autenticado y notifica a los componentes cuando este estado cambia.
    public class AuthStateService
    {
        // Indica si el usuario está autenticado (true) o no (false).
        public bool IsAuthenticated { get; private set; }

        // Evento que se dispara cuando el estado de autenticación cambia.
        public event Action? OnAuthenticationStateChanged;


        // Cambia el estado de autenticación del usuario.

        public void SetAuthenticationState(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
            // Notifica a los componentes suscritos que el estado ha cambiado
            OnAuthenticationStateChanged?.Invoke();
        }
    }
}