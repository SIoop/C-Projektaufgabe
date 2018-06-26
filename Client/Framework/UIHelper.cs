using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Client.Framework
{
    public static class UIHelper
    {

        private static bool _isBusy;
        
        public static void SetBusyState()
        {
            SetBusyState(true);
        }

        private static void SetBusyState(bool busy)
        {
            if (busy == _isBusy) return;
            _isBusy = busy;
            Mouse.OverrideCursor = busy ? Cursors.Cross : null;

            if (_isBusy)
            {
                var dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(0), DispatcherPriority.ApplicationIdle, dispatcherTimer_Tick, Application.Current.Dispatcher);
            }
        }

        private static void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!(sender is DispatcherTimer dispatcherTimer)) return;
            SetBusyState(false);
            dispatcherTimer.Stop();
        }
    }
}