using System.Collections.ObjectModel;
using System.Windows.Controls;
using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;
using Models;

namespace Client.Controllers
{
    public class UserManagementPageController : IPageControllerBase
    {
        private readonly UserManagementPageViewModel _viewModel = new UserManagementPageViewModel();
        private readonly UserServiceClient _client = new UserServiceClient();

        public void Initialize()
        {
            LoadItems();

            Page = new UserManagementPagexaml {DataContext = _viewModel};
        }

        private void LoadItems()
        {
            _viewModel.Users = new ObservableCollection<User>(( _client.GetAllUsers()));
        }

        public Page Page { get; set; }
        public event MainWindowNavigator.SetButtonStatus ButtonHandler;
        public bool EditButtonActive { get; set; }
        public bool NewButtonActive { get; set; }
        public bool SaveButtonActive { get; set; }
        public bool DeleteButtonActive { get; set; }

        public void NewButtonPressed()
        {
            var item = new User {Password = "geheim"};
            _viewModel.Users.Add(item);
            _viewModel.SelectedUser = item;
        }

        public void EditButtonPressed() => _viewModel.EditMode = !_viewModel.EditMode;

        public void SaveButtonPressed()
        {
            if (_viewModel.SelectedUser != null)  _client.AddOrUpdateUser((User) _viewModel.SelectedUser);
            LoadItems();
        }

        public async void DeleteButtonPressed()
        {
            if (_viewModel.SelectedUser != null) await _client.DeleteUserAsync(_viewModel.SelectedUser);
            LoadItems();
        }

        public void OnNavigation(string navigationTarget)
        {
            if(navigationTarget==Page.Title) LoadItems();
        }

        protected virtual void OnButtonHandler(bool a, bool b, bool c, bool d, bool e)
        {
            ButtonHandler?.Invoke(a, b, c, d, e);
        }
    }
}