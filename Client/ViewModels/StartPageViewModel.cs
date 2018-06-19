using System;
using System.Collections.Generic;
using System.Windows.Input;
using Client.CategoryProxy;
using Client.Framework;

namespace Client.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {

        public List<Category> Categories { get; set; }
    }
}