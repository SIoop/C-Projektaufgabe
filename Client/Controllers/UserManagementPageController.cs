﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Client.Framework;
using Client.RatingProxy;
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
        public bool EditButtonActive { get; set; } = true;
        public bool NewButtonActive { get; set; } = true;
        public bool SaveButtonActive { get; set; }
        public bool DeleteButtonActive { get; set; } = true;

        public void NewButtonPressed()
        {
            var item = new User {Password = "geheim"};
            _viewModel.Users.Add(item);
            _viewModel.SelectedUser = item;
            EditButtonPressed();
        }

        public void EditButtonPressed()
        {
            _viewModel.EditMode = !_viewModel.EditMode;
            if (!_viewModel.EditMode)
            {
                NewButtonActive = false;
                DeleteButtonActive = false;
                SaveButtonActive = true;
            }
            else
            {
                NewButtonActive = true;
                DeleteButtonActive = true;
                SaveButtonActive = false;
            }
            OnButtonHandler();
        }

        public void SaveButtonPressed()
        {
            if (_viewModel.SelectedUser != null)  _client.AddOrUpdateUser((User) _viewModel.SelectedUser);
            LoadItems();
            EditButtonPressed();
        }

        public async void DeleteButtonPressed()
        {
            if (_viewModel.SelectedUser != null)
            {
                if (HasUserRatings(_viewModel.SelectedUser))
                {
                    MessageBox.Show("Der Benutzer besitzt noch Bewertungen, er kann deswegen nicht gelöscht werden.");
                    return;
                }
                await _client.DeleteUserAsync(_viewModel.SelectedUser);
            }

            LoadItems();
        }

        private bool HasUserRatings(User user)
        {
            RatingServiceClient client = new RatingServiceClient();
            var ratings = client.GetAll().FindAll(r => r.User.Id == user.Id);
            return ratings.Count != 0;
        }

        public void OnNavigation(string navigationTarget)
        {
            if(navigationTarget==Page.Title) LoadItems();
        }

        protected virtual void OnButtonHandler()
        {
            ButtonHandler?.Invoke(NewButtonActive, EditButtonActive, SaveButtonActive, DeleteButtonActive, !_viewModel.EditMode);
        }
    }
}