 using MovilApp.ViewModels.Login;

namespace MovilApp.Views.Login
{

    public partial class SignInView : ContentPage
    {
        public SignInView()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            if (BindingContext is SignInViewModel vm && vm.VolverCommand.CanExecute(null))
            {
                vm.VolverCommand.Execute(null);
                return true; // Indica que ya manejaste el evento
            }
            return base.OnBackButtonPressed();
        }
    }
}