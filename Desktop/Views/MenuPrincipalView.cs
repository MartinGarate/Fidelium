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
        private Form? currentOpenView;

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

        private void CloseCurrentView()
        {
            // Cerrar y disponer la vista actual si existe
            if (currentOpenView != null && !currentOpenView.IsDisposed)
            {
                currentOpenView.Close();
                currentOpenView.Dispose(); // liberar recursos no administrados que un objeto está utilizando
                currentOpenView = null;
            }
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
            CloseCurrentView();
            // Tu lógica específica del Dashboard aquí
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            ButtonSeleccionado(sender, e);
            CloseCurrentView();
            var usuariosView = new UsuariosView();
            usuariosView.MdiParent = this;
            usuariosView.Show();
            currentOpenView = usuariosView;
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            ButtonSeleccionado(sender, e);
            CloseCurrentView();
            var seguimientoVentasView = new SeguimientoVentasView();
            seguimientoVentasView.MdiParent = this;
            seguimientoVentasView.Show();
            currentOpenView = seguimientoVentasView;
        }

    }
}
