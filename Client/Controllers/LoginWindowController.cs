using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class LoginWindowController
    {
        private LoginWindowViewModel _viewModel;
        private readonly UserServiceClient _client = new UserServiceClient();
        private LoginWindow _view;

        public void Initialize()
        {
            _viewModel = new LoginWindowViewModel();
            _viewModel.LoginCommand = new RelayCommand(ExecuteLoginCommand);
            _view = new LoginWindow {DataContext = _viewModel};
            _view.ShowDialog();
        }

        private void ExecuteLoginCommand(object obj)
        {
            var result = _client.LoginUser(_viewModel.Username, _view.LoginPasswordBox.Password);

            if (result == null)
            {
                
            }
            else
            {
                ApplicationData.User = result;
                new MainWindowController().Initialize();
                _view.Close();
            }
        }
    }
}