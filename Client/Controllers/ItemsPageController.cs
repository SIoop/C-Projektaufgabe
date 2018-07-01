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

namespace Client.Controllers
{
    public class ItemsPageController : IPageControllerBase
    {
        private readonly CategoryServiceClient _catClient = new CategoryServiceClient();
        private readonly ItemServiceClient _itemClient = new ItemServiceClient();
        private readonly RatingServiceClient _ratClient = new RatingServiceClient();
        private readonly ItemsPageViewModel _viewModel = new ItemsPageViewModel();
        private ItemsPage _view;
        public Page Page { get; set; }
        public event MainWindowNavigator.SetButtonStatus ButtonHandler;
        public bool EditButtonActive { get; set; } = true;
        public bool NewButtonActive { get; set; } = true;
        public bool SaveButtonActive { get; set; }
        public bool DeleteButtonActive { get; set; } = true;

        public void Initialize()
        {
            _viewModel.RateCommand = new RelayCommand(ExecuteRateCommand);
            _viewModel.DeleteRatingCommand = new RelayCommand(ExecuteDeleteRatingCommand);
            Page = new ItemsPage {DataContext = _viewModel};
            _view = (ItemsPage) Page;
            LoadItems();
        }

        public void NewButtonPressed()
        {
            var newItem = new Item
            {
                Name = "",
                Ratings = new List<Rating>(),
                CategoryId = ApplicationData.Category.Id
            };
            _viewModel.Items.Add(newItem);
            _viewModel.SelectedItem = newItem;
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

            UpdateButtons();
        }

        public void SaveButtonPressed()
        {
            _itemClient.SaveOrUpdate(_viewModel.SelectedItem);
            EditButtonPressed();
            LoadItems();
        }

        public void DeleteButtonPressed()
        {
            _itemClient.Delete(_viewModel.SelectedItem);
            LoadItems();
        }

        public void OnNavigation(string navigationTarget)
        {
            if (navigationTarget == Page.Title) LoadItems();
        }

        private void LoadItems()
        {
            if (ApplicationData.Category == null) return;
            ApplicationData.Category = _catClient.Get(ApplicationData.Category.Id);
            _viewModel.Items = new ObservableCollection<Item>(ApplicationData.Category.Items.ToList());
        }

        private void ExecuteRateCommand(object obj)
        {
            var con = new RateWindowController();
            var item = con.Initialize();
            if (item != null)
            {
                item.ItemId = _viewModel.SelectedItem.Id;
                _ratClient.AddRating(item);
                LoadItems();
            }
        }

        private void ExecuteDeleteRatingCommand(object obj)
        {
            if (_viewModel.SelectedRating != null) _ratClient.DeleteRating(_viewModel.SelectedRating);
            _viewModel.SelectedRating = null;
            LoadItems();
        }

        private void UpdateButtons()
        {
            ButtonHandler?.Invoke(NewButtonActive, EditButtonActive, SaveButtonActive, DeleteButtonActive,
                !_viewModel.EditMode);
        }
    }
}