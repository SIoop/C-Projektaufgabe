using System.Windows.Controls;

namespace Client.Framework
{
    public interface IPageControllerBase : ControllerBase
    {
        Page Page { get; set; }

        event MainWindowNavigator.SetButtonStatus ButtonHandler;

        bool EditButtonActive { get; }
        bool NewButtonActive { get; }
        bool SaveButtonActive { get;}
        bool DeleteButtonActive { get; }

        void NewButtonPressed();
        void EditButtonPressed();
        void SaveButtonPressed();
        void DeleteButtonPressed();

        void OnNavigation(string navigationTarget);
    }
}