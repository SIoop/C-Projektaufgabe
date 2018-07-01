using System.Windows.Input;
using Client.Framework;

namespace Client.ViewModels
{
    public class ChangePasswordWindowViewModel : ViewModelBase
    {
        private ICommand _changePasswordCommand;

        public ICommand ChangePasswordCommand
        {
            get => _changePasswordCommand;
            set
            {
                _changePasswordCommand = value;
                OnPropertyChanged();
            }
        }

    }
}