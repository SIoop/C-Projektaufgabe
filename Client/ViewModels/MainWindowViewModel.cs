using System.Windows.Input;
using Client.Framework;

namespace Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand NavChange { get; set; }
    }
}