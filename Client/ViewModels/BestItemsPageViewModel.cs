using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Client.Framework;
using Client.ItemProxy;
using Models;

namespace Client.ViewModels
{
    public class BestItemsPageViewModel : ViewModelBase
    {
        private ObservableCollection<RatedItem> _items;

        public ObservableCollection<RatedItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }


    }
}