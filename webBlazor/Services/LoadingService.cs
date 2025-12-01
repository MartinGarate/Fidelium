namespace webBlazor.Services
{
    public class LoadingService
    {
        private bool _isLoading = false;
        private string _loadingText = "Cargando...";

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                NotifyStateChanged();
            }
        }

        public string LoadingText
        {
            get => _loadingText;
            set
            {
                _loadingText = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnLoadingChanged;

        private void NotifyStateChanged() => OnLoadingChanged?.Invoke();

        public void Show(string text = "Cargando...")
        {
            LoadingText = text;
            IsLoading = true;
        }

        public void Hide()
        {
            IsLoading = false;
            LoadingText = "Cargando...";
        }

        /// <summary>
        /// Muestra el spinner durante la ejecución de una tarea asincrónica
        /// </summary>
        public async Task ShowDuring(Func<Task> action, string loadingText = "Cargando...")
        {
            Show(loadingText);
            try
            {
                await action();
            }
            finally
            {
                Hide();
            }
        }

        /// <summary>
        /// Muestra el spinner durante la ejecución de una tarea asincrónica con resultado
        /// </summary>
        public async Task<T> ShowDuring<T>(Func<Task<T>> action, string loadingText = "Cargando...")
        {
            Show(loadingText);
            try
            {
                return await action();
            }
            finally
            {
                Hide();
            }
        }
    }
}
