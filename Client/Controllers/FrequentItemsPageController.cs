using System.Collections;
using System.Windows.Controls;
using Client.Framework;
using Client.ItemProxy;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    public class FrequentItemsPageController : PageControllerBase, MainWindowNavigator.NavigationSubscriber
    {
        private readonly ItemServiceClient _client = new ItemServiceClient();
        private readonly FrequentItemsPageViewModel _viewModel = new FrequentItemsPageViewModel();

        public void Initialize()
        {
            LoadItems();
            Page = new FrequentItemsPage(){DataContext = _viewModel};
            MainWindowNavigator.NavigationSubscribers.Add(this);
        }

        private async void LoadItems()
        {
            var items = await _client.GetRatedItemsByCategoryAsync(ApplicationData.Category);
            items.Sort((item1, item2) => item2.Ratings - item1.Ratings);
            _viewModel.Items = items;
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

        public void Notify(string navigationTarget)
        {
            if (navigationTarget == Page.Title)
            {
                LoadItems();
            }
        }
    }
}