using System.Windows;
using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace Client.Controllers
{
    public class LoginWindowController : ControllerBase
    {
        private LoginWindowViewModel _viewModel;
        private readonly UserServiceClient _client = new UserServiceClient();
        private LoginWindow _view;
        private bool _mainWindowOpen = false;

        public void Initialize()
        {
            _viewModel = new LoginWindowViewModel {LoginCommand = new RelayCommand(ExecuteLoginCommand)};
            _view = new LoginWindow {DataContext = _viewModel};
            _view.ShowDialog();
        }

        private async void ExecuteLoginCommand(object obj)
        {
            if (!_mainWindowOpen)
            {
                _mainWindowOpen = true;
                _viewModel.Busy = true;
                UIHelper.SetBusyState();
                var result = await _client.LoginUserAsync(_viewModel.Username, _view.LoginPasswordBox.Password);

                if (result == null)
                {
                    UIHelper.SetBusyState();
                    _viewModel.Busy = false;
                    MessageBox.Show("Falsche Anmeldedaten!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    _mainWindowOpen = false;
                }
                else
                {
                    ApplicationData.User = result;
                    _view.Hide();
                    _viewModel.Busy = false;
                    new MainWindowController().Initialize();
                    _view.Show();
                    UIHelper.SetBusyState();
                }
            }
        }
    }
}