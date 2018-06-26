using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Client.Framework;
using Client.RatingProxy;
using Models;

namespace Client.ViewModels
{
    public class ItemsPageViewModel : ViewModelBase
    {
        private List<Item> _items;

        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private ICommand _selectionChange;

        public ICommand SelectionChange
        {
            get => _selectionChange;
            set
            {
                _selectionChange = value;
                OnPropertyChanged();
            }
        }

        private Item _selectedItem;

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private Rating _selectedRating;

        public Rating SelectedRating
        {
            get => _selectedRating;
            set
            {
                _selectedRating = value;
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

        private ICommand _deleteRatingCommand;

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