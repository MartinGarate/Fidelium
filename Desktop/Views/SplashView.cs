using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        public SplashView()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ProgressBar.Value+=5;
            if (ProgressBar.Value == 100)
            {
                timer.Stop();
                this.Hide();
                var menuView = new LoginView();
                menuView.ShowDialog();
                this.Close();

            }
        }
    }
}
