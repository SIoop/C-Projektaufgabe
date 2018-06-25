using System.Windows.Input;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class RateWindowViewModel : ViewModelBase
    {
        private Rating _rating = new Rating() {Score = 3, User = ApplicationData.User};

        public Rating Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }

        private ICommand _rateCommand;

        public ICommand RateCommand
        {
            get => _rateCommand;
            set
            {
                _rateCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _cancelCommand;

        public ICommand CancelCommand
        {
            get => _cancelCommand;
            set
            {
                _cancelCommand = value;
                OnPropertyChanged();
            }
        }


    }
}