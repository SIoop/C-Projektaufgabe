using System.Linq;
using System.Windows.Controls;
using Client.CategoryProxy;
using Client.Framework;
using Client.UserProxy;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class StartPageController
    {
        private StartPageViewModel _viewModel;
        private readonly CategoryServiceClient _client = new CategoryServiceClient();

        public Page Initialize()
        {
            _viewModel = new StartPageViewModel();
            _viewModel.Categories = _client.GetAll().ToList();
            
            var page = new StartPage();
            page.DataContext = _viewModel;
            return page;
        }
    }
}