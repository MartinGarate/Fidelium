using MovilApp.ViewModels;
using MovilApp.Views.Login;

namespace MovilApp.Views;

public partial class AgoraShell : Shell
{
    public FideliumShellViewModel ViewModel => (FideliumShellViewModel)BindingContext;

    public AgoraShell()
    {
        InitializeComponent();
    }

    public void SetLoginState(bool isLoggedIn)
    {
        ViewModel.SetLoginState(isLoggedIn);
    }

}