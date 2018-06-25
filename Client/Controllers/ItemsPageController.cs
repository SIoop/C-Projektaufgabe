using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Client.CategoryProxy;
using Client.Framework;
using Client.ItemProxy;
using Client.RatingProxy;
using Client.ViewModels;
using Client.Views;
using Models;
using Rating = Models.Rating;

namespace Client.Controllers
{
    public class ItemsPageController : PageControllerBase, MainWindowNavigator.NavigationSubscriber
    {
        public Page Page { get; set; }
        private readonly ItemsPageViewModel _viewModel = new ItemsPageViewModel();
        private readonly ItemServiceClient _itemClient = new ItemServiceClient();
        private readonly CategoryServiceClient _catClient = new CategoryServiceClient();

        public void Initialize()
        {
            _viewModel.SelectionChange = new RelayCommand(SelectionChanged);
            _viewModel.RateCommand = new RelayCommand(ExecuteRateCommand);
            _viewModel.DeleteRatingCommand = new RelayCommand(ExecuteDeleteRatingCommand);
            Page = new ItemsPage {DataContext = _viewModel};
            LoadItems();
            MainWindowNavigator.NavigationSubscribers.Add(this);
        }

        private void LoadItems()
        {
            if (ApplicationData.Category != null)
            {
                ApplicationData.Category = _catClient.Get(ApplicationData.Category.Id);
                _viewModel.Items = ApplicationData.Category.Items.ToList();
                _viewModel.SelectedItem = null;
            }
        }

        private void ExecuteRateCommand(object obj)
        {
            RateWindowController con = new RateWindowController();
            var item = con.Initialize();
            if (item != null)
            {
                var list = new List<Rating>(_viewModel.SelectedItem.Ratings) {item};
                _viewModel.SelectedItem.Ratings = list;
            }
        }

        private void ExecuteDeleteRatingCommand(object obj)
        {
           
        }

        public void Notify(string navigationTarget)
        {
            if (navigationTarget == Page.Title)
            {
                LoadItems();
            }
        }

        private void SelectionChanged(object obj)
        {
        }

        public (bool, bool, bool, bool) ActiveButtons { get; set; } = (true, true, true, true);

        public void NewButtonPressed()
        {
            var newItem = new Item()
            {
                Name = "",
                Ratings = new List<Rating>()
            };
            _viewModel.Items.Add(newItem);
            _viewModel.SelectedItem = newItem;
        }

        public void EditButtonPressed()
        {
            _viewModel.EditMode = !_viewModel.EditMode;
        }

        public async void SaveButtonPressed()
        {
            await _catClient.SaveOrUpdateAsync(ApplicationData.Category);
            LoadItems();
        }

        public void DeleteButtonPressed()
        {
            _itemClient.Delete(_viewModel.SelectedItem);
            LoadItems();
        }
    }
}