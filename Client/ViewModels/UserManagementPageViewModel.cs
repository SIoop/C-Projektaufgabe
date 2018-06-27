using System.Collections.ObjectModel;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class UserManagementPageViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (Equals(_selectedUser, value)) return;
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        private bool _editMode = true;
        private ObservableCollection<User> _users;

        public bool EditMode
        {
            get => _editMode;
            set
            {
                _editMode = value;
                OnPropertyChanged();
            }
        }
    }
}