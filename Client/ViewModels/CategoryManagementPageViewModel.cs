using System.Collections.ObjectModel;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class CategoryManagementPageViewModel : ViewModelBase
    {
        public ObservableCollection<Category> Categories { get; set; }

        private Category _selectedCategory;

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        private bool _editMode;

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