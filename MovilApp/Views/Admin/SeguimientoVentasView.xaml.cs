using MovilApp.ViewModels.Admin;
using Service.Models.Service.Models;

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

        private async void OnVerDetallesClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is CompraServicio compra)
            {
                // DECISIÓN INTELIGENTE: Feedback recibido o contacto pendiente
                if (compra.FeedbackRecibido)
                {
                    // ? TIENE FEEDBACK - Mostrar opinión del cliente
                    if (!string.IsNullOrWhiteSpace(compra.ComentarioFeedback))
                    {
                        await DisplayAlert(
                            $"?? Feedback - {compra.Nombre}",
                            $"?? Fecha: {compra.FechaCompra:dd/MM/yyyy}\n\n" +
                            $"?? Cliente: {compra.Cliente?.Usuario?.Nombre ?? "N/A"}\n\n" +
                            $"?? Comentario:\n\n{compra.ComentarioFeedback}",
                            "Cerrar"
                        );
                    }
                    else
                    {
                        await DisplayAlert(
                            "? Feedback Recibido",
                            "El cliente marcó el feedback como recibido pero no dejó comentarios escritos.",
                            "OK"
                        );
                    }
                }
                else
                {
                    // ? FEEDBACK PENDIENTE - Mostrar medios de contacto
                    var cliente = compra.Cliente;
                    if (cliente != null)
                    {
                        var contactInfo = $"?? Cliente: {cliente.Usuario?.Nombre ?? "N/A"}\n\n";
                        
                        // Teléfono
                        if (!string.IsNullOrWhiteSpace(cliente.Telefono))
                            contactInfo += $"?? Teléfono:\n{cliente.Telefono}\n\n";
                        
                        // Email
                        if (!string.IsNullOrWhiteSpace(cliente.Usuario?.Email))
                            contactInfo += $"?? Email:\n{cliente.Usuario.Email}\n\n";
                        
                        // Instagram
                        if (!string.IsNullOrWhiteSpace(cliente.Instagram))
                            contactInfo += $"?? Instagram:\n{cliente.Instagram}\n\n";
                        
                        // DNI
                        if (!string.IsNullOrWhiteSpace(cliente.Usuario?.DNI))
                            contactInfo += $"?? DNI:\n{cliente.Usuario.DNI}";

                        await DisplayAlert(
                            $"?? Contactar - {compra.Nombre}",
                            contactInfo.TrimEnd(),
                            "Cerrar"
                        );
                    }
                    else
                    {
                        await DisplayAlert(
                            "Sin información",
                            "No se encontraron datos de contacto para este cliente.",
                            "OK"
                        );
                    }
                }
            }
        }
    }
}
