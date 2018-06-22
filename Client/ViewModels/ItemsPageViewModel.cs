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