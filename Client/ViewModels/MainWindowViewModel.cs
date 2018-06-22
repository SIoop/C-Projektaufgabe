﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Client.Framework;

namespace Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICommand _navChange;
        private bool _isAdmin;

        public ICommand NavChange
        {
            get => _navChange;
            set
            {
                _navChange = value;
                OnPropertyChanged();
            }
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        private Page _selectedPage;

        public Page SelectedPage
        {
            get => _selectedPage;
            set
            {
                _selectedPage = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Page> _userPages;

        public ObservableCollection<Page> UserPages
        {
            get => _userPages;
            set
            {
                _userPages = value;
                OnPropertyChanged();
            }
        }

        private ICommand _newCommand;

        public ICommand NewCommand
        {
            get => _newCommand;
            set
            {
                _newCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _editCommand;

        public ICommand EditCommand
        {
            get => _editCommand;
            set
            {
                _editCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get => _saveCommand;
            set
            {
                _saveCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get => _deleteCommand;
            set
            {
                _deleteCommand = value;
                OnPropertyChanged();
            }
        }


    }
}