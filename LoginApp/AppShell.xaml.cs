using LoginApp.MVVM.Views;

namespace LoginApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));


        GoToAsync($"//{nameof(LoginPage)}");
    }
}
