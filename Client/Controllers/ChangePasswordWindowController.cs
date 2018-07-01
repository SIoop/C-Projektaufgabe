using System.Windows;
using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class ChangePasswordWindowController : ControllerBase
    {
        private ChangePasswordWindow _view;
        private ChangePasswordWindowViewModel _viewModel;

        private UserServiceClient _client = new UserServiceClient();

        public void Initialize()
        {
            _viewModel = new ChangePasswordWindowViewModel
            {
                ChangePasswordCommand = new RelayCommand(ExecuteChangePasswordCommand)
            };

            _view = new ChangePasswordWindow
            {
                DataContext = _viewModel
            };

            _view.ShowDialog();
        }

        private void ExecuteChangePasswordCommand(object obj)
        {
            var oldPw = _view.PasswordBox1.Password;
            var newPw1 = _view.PasswordBox2.Password;
            var newPw2 = _view.PasswordBox3.Password;

            if (newPw1 != newPw2)
            {
                MessageBox.Show("Neue Passwörter stimmen nicht überein!");
                return;
            }

            var success = _client.ChangePassword(ApplicationData.User, oldPw, newPw2);
            if (!success)
            {
                MessageBox.Show("Altes Passwort war falsch!");
                return;
            }
            MessageBox.Show("Passwort erfolgreich geändert!");
            _view.Close();
        }
    }
}