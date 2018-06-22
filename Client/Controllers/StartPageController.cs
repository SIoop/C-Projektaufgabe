using System.Linq;
using System.Windows.Controls;
using Client.CategoryProxy;
using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class StartPageController : PageControllerBase
    {
        private StartPageViewModel _viewModel;
        private readonly CategoryServiceClient _client = new CategoryServiceClient();

        public void Initialize()
        {
            _viewModel = new StartPageViewModel
            {
                Categories = _client.GetAll().ToList(),
                CategorySelectedCommand = new RelayCommand(ExecuteCategorySelectedCommand)
            };

            Page = new StartPage { DataContext = _viewModel };
        }

        private void ExecuteCategorySelectedCommand(object obj)
        {
            ApplicationData.Category = _viewModel.SelectedCategory;
            if (MainWindowNavigator.UserPages.Count==1)
            {
                MainWindowNavigator.EnableAllUserPages();
            }
            MainWindowNavigator.NavigateTo(MainWindowNavigator.UserPageControllers[1].Page.Title);
        }

        public Page Page { get; set; }
        public (bool, bool, bool, bool) ActiveButtons { get; set; }
        public void NewButtonPressed()
        {
            
        }

        public void EditButtonPressed()
        {
            
        }

        public void SaveButtonPressed()
        {
            
        }

        public void DeleteButtonPressed()
        {
            
        }
    }
}