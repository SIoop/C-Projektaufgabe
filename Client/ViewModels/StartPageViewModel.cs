using System;
using System.Collections.Generic;
using System.Windows.Input;
using Client.CategoryProxy;
using Client.Framework;
using Models;

namespace Client.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {

        public List<Category> Categories { get; set; }

        public ICommand CategorySelectedCommand { get; set; }

        public Category SelectedCategory { get; set; }
    }
}