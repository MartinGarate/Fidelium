using Microsoft.Extensions.Logging;

namespace webBlazor.Services
{
    public class AuthenticationStateService
    {
        private readonly ILogger<AuthenticationStateService> _logger;
        
        public bool IsAuthenticated { get; private set; }

        public event Action? OnAuthenticationStateChanged;

        public AuthenticationStateService(ILogger<AuthenticationStateService> logger)
        {
            _logger = logger;
        }

        public void SetAuthenticationState(bool isAuthenticated)
        {
            try
            {
                _logger.LogInformation("🔐 Cambiando estado de autenticación a: {IsAuthenticated}", isAuthenticated);
                
                IsAuthenticated = isAuthenticated;
                OnAuthenticationStateChanged?.Invoke();
                
                _logger.LogInformation("✅ Estado de autenticación actualizado correctamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error al cambiar estado de autenticación");
                
                // En caso de error, asegurar que el estado sea consistente
                IsAuthenticated = false;
            }
        }

        public void Initialize(bool initialState = false)
        {
            try
            {
                _logger.LogInformation("🚀 Inicializando AuthenticationStateService");
                IsAuthenticated = initialState;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error inicializando AuthenticationStateService");
                IsAuthenticated = false;
            }
        }
    }
}

