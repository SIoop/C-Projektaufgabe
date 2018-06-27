using System.Collections.ObjectModel;
using System.Windows.Controls;
using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;
using Models;

namespace Client.Controllers
{
    public class UserManagementPageController : PageControllerBase
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
        public (bool, bool, bool, bool) ActiveButtons { get; set; } = (true, true, true, true);
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
    }
}