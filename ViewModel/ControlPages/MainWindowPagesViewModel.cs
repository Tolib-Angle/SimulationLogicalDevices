using GalaSoft.MvvmLight.Command;
using SimulatorLogicDevices.View.MainWindow.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimulatorLogicDevices.ViewModel.ControlPages
{
    internal class MainWindowPagesViewModel : PagesViewModelBase
    {
        private static Page _inputOutputPage = new InputOutputPage();
        private static Page _baseElementsPage = new ElementsPage();
        private static Page _helperElementPage = new HelperElementsPage();

        private static Page _infoPage = new InfoPage();

        private static Page _curElementsPage = new InputOutputPage();

        public static InfoPage getInfoPage() { return (InfoPage) _infoPage; }

        public Page CurrentElementsPage
        {
            get => _curElementsPage;
            set => Set(ref _curElementsPage, value);
        }
        public Page InfoPage
        {
            get => _infoPage;
            set => Set(ref _infoPage, value);
        }
        public ICommand OpenInputOutputPage
        {
            get { return new RelayCommand(() => CurrentElementsPage = _inputOutputPage); }
        }
        public ICommand OpenBaseElementsPage
        {
            get { return new RelayCommand(() => CurrentElementsPage = _baseElementsPage); }
        }
        public ICommand OpenHelperElementsPage
        {
            get { return new RelayCommand(() => CurrentElementsPage = _helperElementPage); }
        }
        public ICommand SetInfoPage
        {
            get { return new RelayCommand(() => InfoPage = _infoPage); }
        }
    }
}
