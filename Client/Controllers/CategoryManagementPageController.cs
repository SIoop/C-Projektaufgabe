using System.Collections.ObjectModel;
using System.Windows.Controls;
using Client.CategoryProxy;
using Client.Framework;
using Client.ViewModels;
using Client.Views;
using Models;

namespace Client.Controllers
{
    public class CategoryManagementPageController : IPageControllerBase
    {
        private readonly CategoryServiceClient _client = new CategoryServiceClient();
        private readonly CategoryManagementPageViewModel _viewModel = new CategoryManagementPageViewModel();

        public void Initialize()
        {
            LoadItems();

            Page = new CategoriesManagementPage {DataContext = _viewModel};
        }

        public Page Page { get; set; }
        public event MainWindowNavigator.SetButtonStatus ButtonHandler;
        public bool EditButtonActive { get; set; } = true;
        public bool NewButtonActive { get; set; } = true;
        public bool SaveButtonActive { get; set; }
        public bool DeleteButtonActive { get; set; } = true;

        public void NewButtonPressed()
        {
            var cat = new Category();
            _viewModel.Categories.Add(cat);
            _viewModel.SelectedCategory = cat;
            EditButtonPressed();
        }

        public void EditButtonPressed()
        {
            _viewModel.EditMode = !_viewModel.EditMode;
            if (!_viewModel.EditMode)
            {
                NewButtonActive = false;
                DeleteButtonActive = false;
                SaveButtonActive = true;
            }
            else
            {
                NewButtonActive = true;
                DeleteButtonActive = true;
                SaveButtonActive = false;
            }
            OnButtonHandler();
        }

        public void SaveButtonPressed()
        {
            _client.SaveOrUpdate(_viewModel.SelectedCategory);
            LoadItems();
            EditButtonPressed();
        }

        public void DeleteButtonPressed()
        {
            _client.Delete(_viewModel.SelectedCategory);
            LoadItems();
        }

        public void OnNavigation(string navigationTarget)
        {
            if (navigationTarget == Page.Title) LoadItems();
        }

        private void LoadItems()
        {
            _viewModel.Categories = new ObservableCollection<Category>(_client.GetAll());
        }

        protected virtual void OnButtonHandler()
        {
            ButtonHandler?.Invoke(NewButtonActive, EditButtonActive, SaveButtonActive, DeleteButtonActive, !_viewModel.EditMode);
        }
    }
}