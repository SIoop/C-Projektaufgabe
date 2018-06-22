using System.Collections.Generic;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class FrequentItemsPageViewModel : ViewModelBase
    {
        private List<RatedItem> _items;

        public List<RatedItem> Items
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