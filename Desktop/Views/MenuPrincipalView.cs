using Desktop.Views;

namespace Desktop
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void usuarios_Click(object sender, EventArgs e)
        {
            var usuariosView = new UsuariosView();
            usuariosView.MdiParent = this;
            usuariosView.Show();
        }

        private void subMenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void subMenu_Capacitaciones_Click(object sender, EventArgs e)
        {
            var capacitacionesView = new CapacitacionesView();
            capacitacionesView.MdiParent = this;
            capacitacionesView.Show();

        }
    }
}
