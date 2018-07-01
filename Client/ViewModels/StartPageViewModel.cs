using System;
using System.Collections.Generic;
using System.Windows.Input;
using Client.CategoryProxy;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {

        public List<Category> Categories { get; set; }

        private ICommand _passwordResetCommand;

        public ICommand PasswordResetCommand
        {
            get { return _passwordResetCommand; }
            set
            {
                _passwordResetCommand = value;
                OnPropertyChanged();
            }
        }


        public ICommand CategorySelectedCommand { get; set; }

        public Category SelectedCategory { get; set; }
    }
}