using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class LoginWindowController : ControllerBase
    {
        private LoginWindowViewModel _viewModel;
        private readonly UserServiceClient _client = new UserServiceClient();
        private LoginWindow _view;

        public void Initialize()
        {
            _viewModel = new LoginWindowViewModel {LoginCommand = new RelayCommand(ExecuteLoginCommand)};
            _view = new LoginWindow {DataContext = _viewModel};
            _view.ShowDialog();
        }

        private async void ExecuteLoginCommand(object obj)
        {
            var result = await _client.LoginUserAsync(_viewModel.Username, _view.LoginPasswordBox.Password);

            if (result == null)
            {
                
            }
            else
            {
                ApplicationData.User = result;
                _view.Hide();
                new MainWindowController().Initialize();
                _view.Show();
            }
        }
    }
}