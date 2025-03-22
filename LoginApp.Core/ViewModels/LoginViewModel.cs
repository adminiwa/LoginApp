using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginApp.Core.Interfaces;
using LoginApp.Core.Models;
using LoginApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Core.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [ObservableProperty]
        private string user = string.Empty;

        partial void OnUserChanged(string value)
        {
            LoginCommand.NotifyCanExecuteChanged();
        }

        [ObservableProperty]
        private string password = string.Empty;

        partial void OnPasswordChanged(string value)
        {
            LoginCommand.NotifyCanExecuteChanged();
        }

        [ObservableProperty]
        private string loginMessage = string.Empty;

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task LoginAsync()
        {
            var user = new UserModel { User = User, Password = Password };
            var result = await _authService.LoginAsync(user);

            LoginMessage = result.Success ? $"✅ {result.Message}" : $"❌ {result.Message}";
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(User) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
