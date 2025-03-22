using LoginApp.Core.Interfaces;
using LoginApp.Core.Models;
using LoginApp.Core.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Tests.ViewModels
{
    [TestFixture]
    public class LoginViewModelTests
    {
        private Mock<IAuthService> _authServiceMock = null!;
        private LoginViewModel _viewModel = null!;

        [SetUp]
        public void Setup()
        {
            _authServiceMock = new Mock<IAuthService>();
            _viewModel = new LoginViewModel(_authServiceMock.Object);
        }

        [Test]
        public async Task LoginCommand_SuccessfulLogin_SetsSuccessMessage()
        {
            // Arrange
            _viewModel.User = "test";
            _viewModel.Password = "123456";

            var expectedMessage = "Inicio de sesión exitoso";

            _authServiceMock
                .Setup(x => x.LoginAsync(It.IsAny<UserModel>()))
                .ReturnsAsync(new LoginResponse
                {
                    Success = true,
                    Message = expectedMessage
                });

            // Act
            await _viewModel.LoginCommand.ExecuteAsync(null);

            // Assert
            Assert.That(_viewModel.LoginMessage, Is.EqualTo($"✅ {expectedMessage}"));
        }

        [Test]
        public async Task LoginCommand_FailedLogin_SetsErrorMessage()
        {
            // Arrange
            _viewModel.User = "wrong";
            _viewModel.Password = "wrongpass";

            var expectedMessage = "Credenciales incorrectas";

            _authServiceMock
                .Setup(x => x.LoginAsync(It.IsAny<UserModel>()))
                .ReturnsAsync(new LoginResponse
                {
                    Success = false,
                    Message = expectedMessage
                });

            // Act
            await _viewModel.LoginCommand.ExecuteAsync(null);

            // Assert
            Assert.That(_viewModel.LoginMessage, Is.EqualTo($"❌ {expectedMessage}"));
        }

        [Test]
        public void LoginCommand_CannotExecute_WhenFieldsAreEmpty()
        {
            _viewModel.User = "";
            _viewModel.Password = "";

            var canExecute = _viewModel.LoginCommand.CanExecute(null);

            Assert.That(canExecute, Is.False);
        }

        [Test]
        public void LoginCommand_CanExecute_WhenFieldsAreFilled()
        {
            _viewModel.User = "usuario";
            _viewModel.Password = "password";

            var canExecute = _viewModel.LoginCommand.CanExecute(null);

            Assert.That(canExecute, Is.True);
        }
    }
}
