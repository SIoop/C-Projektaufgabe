using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using Client.Framework;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class MainWindowController : ControllerBase
    {
        private MainWindowViewModel _viewModel;
        private MainWindow _view;

        public void Initialize()
        {
            _viewModel = new MainWindowViewModel();
            _view = new MainWindow {DataContext = _viewModel};
            MainWindowNavigator.NavFrame = _view.NavigationFrame;
            MainWindowNavigator.ButtonMethod = SetButtons;

            _viewModel.NavChange = new RelayCommand(ExecuteNavChangeCommand);
            _viewModel.NewCommand = new RelayCommand(MainWindowNavigator.OnNew);
            _viewModel.EditCommand = new RelayCommand(MainWindowNavigator.OnEdit);
            _viewModel.SaveCommand = new RelayCommand(MainWindowNavigator.OnSave);
            _viewModel.DeleteCommand = new RelayCommand(MainWindowNavigator.OnDelete);
            _viewModel.IsAdmin = ApplicationData.User.IsAdmin;

            RegisterControllers();

            MainWindowNavigator.InitializePages();
            _viewModel.UserPages = MainWindowNavigator.UserPages;
            _viewModel.AdminPages = MainWindowNavigator.AdminPages;

            MainWindowNavigator.NavigateToFirstPage();
            _view.ShowDialog();
        }

        private void SetButtons(bool newButton, bool editButton, bool saveButton, bool deleteButton, bool editMode)
        {
            _viewModel.NewButton = newButton;
            _viewModel.EditButton = editButton;
            _viewModel.SaveButton = saveButton;
            _viewModel.DeleteButton = deleteButton;
            _view.EditButton.IsChecked = editMode;
        }

        private static void RegisterControllers()
        {
            MainWindowNavigator.UserPageControllers.Add(new StartPageController());
            MainWindowNavigator.UserPageControllers.Add(new ItemsPageController());
            MainWindowNavigator.UserPageControllers.Add(new BestItemsPageController());
            MainWindowNavigator.UserPageControllers.Add(new FrequentItemsPageController());

            MainWindowNavigator.AdminPageControllers.Add(new UserManagementPageController());
            MainWindowNavigator.AdminPageControllers.Add(new CategoryManagementPageController());
        }

        private void ExecuteNavChangeCommand(object obj)
        {
            MainWindowNavigator.NavigateTo(_viewModel.SelectedPage.Title);
        }
    }
}