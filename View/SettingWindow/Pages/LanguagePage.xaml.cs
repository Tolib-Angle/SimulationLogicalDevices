using SimulatorLogicDevices.ViewModel.HelperClass;
using System.Windows.Controls;

namespace SimulatorLogicDevices.View.SettingWindow.Pages
{
    public partial class LanguagePage : Page
    {
        public LanguagePage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.languageRU)
            {
                LanguageRU.IsChecked = true;
            }
            else
            {
                LanguageENG.IsChecked = true;
            }
        }

        internal void saveLanguage()
        {
            if (LanguageRU.IsChecked == true)
                LoadResources.ChangeLanguage(true);
            else
                LoadResources.ChangeLanguage(false);
        }
    }
}
