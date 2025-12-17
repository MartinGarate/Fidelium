using MovilApp.ViewModels.Admin;

namespace MovilApp.Views.Admin
{
    public partial class SeguimientoVentasView : ContentPage
    {
        public SeguimientoVentasView()
        {
            InitializeComponent();
            
            // Conectar el ViewModel al BindingContext
            BindingContext = new SeguimientoVentasViewViewModel();
        }
    }
}
