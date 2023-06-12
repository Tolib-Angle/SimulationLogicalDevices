using GalaSoft.MvvmLight.Command;
using SimulatorLogicDevices.View.SettingWindow.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimulatorLogicDevices.ViewModel.ControlPages
{
    internal class SettingWindowPagesViewModel : PagesViewModelBase
    {
        private static Page _openPage = new OpenPage();
        private static Page _createPage = new CreatePage();
        private static Page _themePage = new ThemePage();
        private static Page _languagePage = new LanguagePage();
        private static Page _documentationPage = new DocumentationPage();
        private static Page _hotKeyPage = new HotKeyPage();
        private static Page _examplesPage = new ExamplesPage();

        private static Page _curPage = new OpenPage();

        // getter fon save value pages
        public static ThemePage getThemePage()
        {
            return (ThemePage) _themePage;
        }
        public static LanguagePage getLanguagePage()
        {
            return (LanguagePage) _languagePage;
        }
        public static string getNameCurPage()
        {
            if (_curPage.Equals(typeof(OpenPage)))
                return "Open";
            else
                return "NN";
        }
        public Page CurrentPage
        {
            get => _curPage;
            set => Set(ref _curPage, value);
        }
        public ICommand OpenOpenPage
        {
            get { return new RelayCommand(() => CurrentPage = _openPage); }
        }
        public ICommand OpenCreatePage
        {
            get { return new RelayCommand(() => CurrentPage = _createPage); }
        }
        public ICommand OpenThemePage
        {
            get { return new RelayCommand(() => CurrentPage = _themePage); }
        }
        public ICommand OpenLanguagePage
        {
            get { return new RelayCommand(() => CurrentPage = _languagePage); }
        }
        public ICommand OpenDocumentationPage
        {
            get { return new RelayCommand(() => CurrentPage = _documentationPage); }
        }
        public ICommand OpenHotkeyPage
        {
            get { return new RelayCommand(() => CurrentPage = _hotKeyPage); }
        }
        public ICommand OpenExamplesPage
        {
            get { return new RelayCommand(() => CurrentPage = _examplesPage); }
        }

    }
}
