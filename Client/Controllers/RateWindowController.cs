using Client.Framework;
using Client.ViewModels;
using Client.Views;
using Models;

namespace Client.Controllers
{
    public class RateWindowController
    {
        public RateWindow View;
        private RateWindowViewModel _viewModel;

        public Rating Initialize()
        {
            _viewModel = new RateWindowViewModel
            {
                RateCommand = new RelayCommand(ExecuteRateCommand),
                CancelCommand = new RelayCommand(ExecuteCancelCommand)
            };
            View = new RateWindow() {DataContext = _viewModel};
            View.ShowDialog();
            return _viewModel.Rating;
        }

        private void ExecuteRateCommand(object obj)
        {
            View.Close();
        }

        private void ExecuteCancelCommand(object obj)
        {
            _viewModel.Rating = null;
            View.Close();
        }
    }
}