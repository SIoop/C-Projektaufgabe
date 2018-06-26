using Client.Framework;

namespace Client.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }


        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private bool _busy;

        public bool Busy
        {
            get => _busy;
            set
            {
                _busy = value;
                OnPropertyChanged();
            }
        }



        public RelayCommand LoginCommand { get; set; }

    }
}