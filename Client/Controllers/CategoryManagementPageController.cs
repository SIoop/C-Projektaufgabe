using System.Collections.ObjectModel;
using System.Windows.Controls;
using Client.CategoryProxy;
using Client.Framework;
using Client.ViewModels;
using Client.Views;
using Models;

namespace Client.Controllers
{
    public class CategoryManagementPageController : PageControllerBase
    {
        private readonly CategoryManagementPageViewModel _viewModel = new CategoryManagementPageViewModel();
        private readonly CategoryServiceClient _client = new CategoryServiceClient();

        public void Initialize()
        {
            LoadItems();

            Page = new CategoriesManagementPage {DataContext = _viewModel};
        }

        private void LoadItems()
        {
            _viewModel.Categories = new ObservableCollection<Category>( _client.GetAll());
        }

        public Page Page { get; set; }
        public (bool, bool, bool, bool) ActiveButtons { get; set; }
        public void NewButtonPressed()
        {
            var cat = new Category();
            _viewModel.Categories.Add(cat);
            _viewModel.SelectedCategory = cat;
        }

        public void EditButtonPressed()
        {
            _viewModel.EditMode = !_viewModel.EditMode;
        }

        public void SaveButtonPressed()
        {
            _client.SaveOrUpdate(_viewModel.SelectedCategory);
        }

        public void DeleteButtonPressed()
        {
            _client.Delete(_viewModel.SelectedCategory);
        }
    }
}