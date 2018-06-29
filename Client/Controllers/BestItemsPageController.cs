using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Client.Framework;
using Client.ItemProxy;
using Client.ViewModels;
using Client.Views;
using Models;

namespace Client.Controllers
{
    public class BestItemsPageController : IPageControllerBase
    {
        private readonly BestItemsPageViewModel _viewModel = new BestItemsPageViewModel();
        private readonly ItemServiceClient _client = new ItemServiceClient();

        public event MainWindowNavigator.SetButtonStatus ButtonHandler;

        public void Initialize()
        {
            LoadItems();
            Page = new BestItemsPage() {DataContext = _viewModel};
        }

        private async void LoadItems()
        {
            var items = await _client.GetRatedItemsByCategoryAsync(ApplicationData.Category);
            items.Sort((item1, item2) =>
            {
                var diff = item2.AvgRating - item1.AvgRating;
                if (diff > 0) return 1;
                if (Math.Abs(diff) < 0) return 0;
                else return -1;
            });
            _viewModel.Items = new ObservableCollection<RatedItem>(items);
        }

        public Page Page { get; set; }
        public bool EditButtonActive { get; set; }
        public bool NewButtonActive { get; set; }
        public bool SaveButtonActive { get; set; }
        public bool DeleteButtonActive { get; set; }

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

        public void OnNavigation(string navigationTarget)
        {
            if (navigationTarget == Page.Title)
            {
                LoadItems();
            }
        }

        protected virtual void OnButtonHandler(bool a, bool b, bool c, bool d, bool e)
        {
            ButtonHandler?.Invoke(a, b, c, d, e);
        }
    }
}