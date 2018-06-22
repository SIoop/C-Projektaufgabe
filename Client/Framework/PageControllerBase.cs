using System.Windows.Controls;

namespace Client.Framework
{
    public interface PageControllerBase : ControllerBase
    {
        Page Page { get; set; }
        (bool, bool, bool, bool) ActiveButtons { get; set; }

        void NewButtonPressed();
        void EditButtonPressed();
        void SaveButtonPressed();
        void DeleteButtonPressed();
    }
}