using System.Collections.ObjectModel;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class CategoryManagementPageViewModel : ViewModelBase
    {
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                if (Equals(value, _categories))
                {
                    return;
                }
                _categories = value;
                OnPropertyChanged();
            }
        }

        private Category _selectedCategory;

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (Equals(value, SelectedCategory)) return;
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        private bool _editMode = true;
        private ObservableCollection<Category> _categories;

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