using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Client.Framework
{
    public class MainWindowNavigator
    {
        private Frame _navFrame;
        public Dictionary<string, Page> Pages { get; set; } = new Dictionary<string, Page>();

        public MainWindowNavigator(Frame frame)
        {
            _navFrame = frame;
        }

        public void navigateTo(string page)
        {
            _navFrame.Navigate(Pages[page]);
        }
    }
}