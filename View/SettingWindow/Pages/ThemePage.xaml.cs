using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimulatorLogicDevices.View.SettingWindow.Pages
{
    public partial class ThemePage : Page
    {
        public ThemePage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.darkTheme)
            {
                DarkThemeButton.IsChecked = true;
            }
            else
            {
                LightThemeButton.IsChecked = true;
            }
        }

        internal void saveTheme()
        {
            if (DarkThemeButton.IsChecked == true)
                LoadResources.ChangeTheme(true);
            else
                LoadResources.ChangeTheme(false);
        }
    }
}
