using Client.Framework;
using Client.ViewModels;
using Client.Views;
using Models;

namespace Client.Controllers
{
    public class RateWindowController
    {
        private RateWindow _view;
        private RateWindowViewModel _viewModel;

        public Rating Initialize()
        {
            _viewModel = new RateWindowViewModel
            {
                RateCommand = new RelayCommand(ExecuteRateCommand),
                CancelCommand = new RelayCommand(ExecuteCancelCommand)
            };
            _view = new RateWindow() {DataContext = _viewModel};
            _view.ShowDialog();
            return _viewModel.Rating;
        }

        private void ExecuteRateCommand(object obj)
        {
            _view.Close();
        }

        private void ExecuteCancelCommand(object obj)
        {
            _viewModel.Rating = null;
            _view.Close();
        }
    }
}