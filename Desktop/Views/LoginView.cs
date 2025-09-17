using Firebase.Auth;
using Firebase.Auth.Providers;
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
    public partial class LoginView : Form
    {
        FirebaseAuthClient _firebaseAuthClient;
        int loginFailCount = 0;
        public LoginView()
        {
            InitializeComponent();
            SettingFirebase();
            labelErrorPassword.Visible = false;
        }

        private void SettingFirebase()
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = Service.Properties.Resources.ApiKeyFirebase,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };
            _firebaseAuthClient = new FirebaseAuthClient(config);
        }

        private async void ButtonLogIn_Click(object sender, EventArgs e)
        {
            try
            {

                UserCredential userCredential = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);
                if (userCredential != null && !string.IsNullOrEmpty(userCredential.User.Uid))
                {
                    labelErrorPassword.Visible = false;
                    MenuPrincipalView menuPrincipalView = new MenuPrincipalView();
                    menuPrincipalView.ShowDialog();
                    this.Hide();
                }
  
            }
            catch (Exception ex)
            {
                labelErrorPassword.Visible = true;
                loginFailCount++;
                if (loginFailCount >= 3)
                {
                    MessageBox.Show("Ha excedido el número máximo de intentos. La aplicación se cerrará.");
                    Application.Exit();
                }
            }
        }

        private void LoginView_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBoxVerContraseña.Checked ? '\0' : '*';



        }
    }
}

