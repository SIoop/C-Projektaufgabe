using Client.Framework;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class MainWindowController
    {
        private MainWindowViewModel _viewModel;
        private MainWindowNavigator _navigator;

        public void Initialize()
        {
            _viewModel = new MainWindowViewModel();
            var view = new MainWindow {DataContext = _viewModel};
            _navigator = new MainWindowNavigator(view.NavigationFrame);
            _viewModel.NavChange = new RelayCommand(ExecuteNavChangeCommand);

            RegisterPages();
            _navigator.navigateTo("Start");
            view.ShowDialog();
        }

        private void RegisterPages()
        {
            _navigator.Pages.Add("Start", new StartPageController().Initialize());
        }

        private void ExecuteNavChangeCommand(object obj)
        {

        }
    }
}