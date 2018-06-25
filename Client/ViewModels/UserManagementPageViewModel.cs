using System.Collections.ObjectModel;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class UserManagementPageViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; }

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