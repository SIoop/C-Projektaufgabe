using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class LoginWindowController
    {
        private LoginWindowViewModel mViewModel;
        private readonly UserServiceClient client = new UserServiceClient();
        private LoginWindow view;

        public void Initialize()
        {
            mViewModel = new LoginWindowViewModel();
            mViewModel.LoginCommand = new RelayCommand(ExecuteLoginCommand);
            view = new LoginWindow {DataContext = mViewModel};
            view.ShowDialog();
        }

        private void ExecuteLoginCommand(object obj)
        {
            var result = client.LoginUser(mViewModel.Username, view.LoginPasswordBox.Password);

            if (result == null)
            {
                
            }
            else
            {
                view.Close();
                new MainWindowController().Initialize();
            }
        }
    }
}