using LoginApp.Core.ViewModels;

namespace LoginApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = App.Current.Handler.MauiContext.Services.GetService<LoginViewModel>();
    }
}