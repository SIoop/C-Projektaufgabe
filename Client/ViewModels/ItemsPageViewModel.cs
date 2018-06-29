using System.Collections.ObjectModel;
using System.Windows.Input;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class ItemsPageViewModel : ViewModelBase
    {
        private ICommand _deleteRatingCommand;

        private bool _editMode = true;
        private ObservableCollection<Item> _items;

        private ICommand _rateCommand;

        private Item _selectedItem;

        private Rating _selectedRating;

        public ObservableCollection<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Rating SelectedRating
        {
            get => _selectedRating;
            set
            {
                _selectedRating = value;
                OnPropertyChanged();
            }
        }

        public bool EditMode
        {
            get => _editMode;
            set
            {
                _editMode = value;
                OnPropertyChanged();
            }
        }

        public ICommand RateCommand
        {
            get => _rateCommand;
            set
            {
                _rateCommand = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteRatingCommand
        {
            get => _deleteRatingCommand;
            set
            {
                _deleteRatingCommand = value;
                OnPropertyChanged();
            }
        }
    }
}