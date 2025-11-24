using Desktop.Views;
using Service.Models;
using Service.Models.Login;
using Service.Services;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Desktop
{
    public partial class MenuPrincipalView : Form
    {
        private Button? currentSelectedButton;

        public MenuPrincipalView()
        {
            InitializeComponent();
            ConfigureMenuButtons();
        }
        private void ConfigureMenuButtons()
        {
            // Establecer el Dashboard como botón seleccionado por defecto
            currentSelectedButton = BtnDashboard;
            BtnDashboard.BackColor = ColorTranslator.FromHtml("#5801b4");
            BtnDashboard.ForeColor = Color.White;
        }

        private void ButtonSeleccionado(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Si hay un botón previamente seleccionado, cambiar su color
            if (currentSelectedButton != null && currentSelectedButton != clickedButton)
            {
                currentSelectedButton.BackColor = Color.Transparent;
                currentSelectedButton.ForeColor = Color.FromArgb(4, 5, 4);

                // Cambiar el color del icono del botón deseleccionado
                if (currentSelectedButton is FontAwesome.Sharp.IconButton previousIconButton)
                {
                    previousIconButton.IconColor = Color.FromArgb(4, 5, 4);
                }
            }

            // Cambiar el color del botón clickeado a púrpura (seleccionado)
            clickedButton.BackColor = ColorTranslator.FromHtml("#5801b4");
            clickedButton.ForeColor = Color.White;

            // Cambiar el color del icono del botón seleccionado
            if (clickedButton is FontAwesome.Sharp.IconButton iconButton)
            {
                iconButton.IconColor = Color.White;
            }

            // Actualizar el botón seleccionado actualmente
            currentSelectedButton = clickedButton;
        }


        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            ButtonSeleccionado(sender, e);
            // Tu lógica específica del Dashboard aquí
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            ButtonSeleccionado(sender, e);
            var usuariosView = new UsuariosView();
            usuariosView.MdiParent = this;
            usuariosView.Show();
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            ButtonSeleccionado(sender, e);
            // Tu lógica específica de Compras aquí
        }

        private void BtnNotificaciones_Click(object sender, EventArgs e)
        {
            ButtonSeleccionado(sender, e);
            // Tu lógica específica de Notificaciones aquí
        }

        private void subMenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void subMenu_Capacitaciones_Click(object sender, EventArgs e)
        {
            var clientesView = new ClientesView();
            clientesView.MdiParent = this;
            clientesView.Show();
        }

    }
}
