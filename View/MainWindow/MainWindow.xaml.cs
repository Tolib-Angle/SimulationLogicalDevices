using SimulatorLogicDevices.View.MainWindow.Pages;
using SimulatorLogicDevices.View.SettingWindow;
using SimulatorLogicDevices.ViewModel.AllElementViewModel;
using SimulatorLogicDevices.ViewModel.HelperClass;
using System.Windows;
using System.Windows.Input;

namespace SimulatorLogicDevices
{
    public partial class MainWindow : Window
    {
        // current window size
        double _curWidth, _curHeight;
        public MainWindow()
        {
            InitializeComponent();

            InitializeMainWindow();
            LoadResources.SetCurrentValue();
            ManagementInfoSpace.ResetInfoPage();
        }
        private void InitializeMainWindow()
        {
            FocusExtension.SetIsFocused(InputsOutputsButton, true);
            _curWidth = 1280;
            _curWidth = 720;
        }
        private void FileButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (Window windows in App.Current.Windows)
            {
                if (windows.Name == "MainSettingWindow")
                    windows.Close();
            }

            (new SettingWindow(TOP_MENU_BUTTON.FILE)).Show();
        }

        private void SettingButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (Window windows in App.Current.Windows)
            {
                if (windows.Name == "MainSettingWindow")
                    windows.Close();
            }

            (new SettingWindow(TOP_MENU_BUTTON.SETTING)).Show();
        }

        private void HelpButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (Window windows in App.Current.Windows)
            {
                if (windows.Name == "MainSettingWindow")
                    windows.Close();
            }

            (new SettingWindow(TOP_MENU_BUTTON.HELP)).Show();
        }

        private void DragMoveMainWindow(object sender, MouseButtonEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
                DragMove();
        }

        private void RollUpWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void UnwrapWindow(object sender, RoutedEventArgs e)
        {
            if (_MainWindow.Width != SystemParameters.WorkArea.Width || _MainWindow.Height != SystemParameters.WorkArea.Height)
            {
                _curWidth = _MainWindow.Width;
                _curHeight = _MainWindow.Height;

                _MainWindow.Width = SystemParameters.WorkArea.Width;
                _MainWindow.Height = SystemParameters.WorkArea.Height;
                _MainWindow.Left = 0;
                _MainWindow.Top = 0;
            }
            else
            {
                _MainWindow.Width = _curWidth;
                _MainWindow.Height = _curHeight;

                _MainWindow.Left = SystemParameters.WorkArea.Width / 2 - _curWidth / 2;
                _MainWindow.Top = SystemParameters.WorkArea.Height / 2 - _curHeight / 2;
            }
        }

        private void CloseProgramm(object sender, RoutedEventArgs e)
        {
            foreach (Window windows in App.Current.Windows)
                windows.Close();
            Close();
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (Window windows in App.Current.Windows)
            {
                if (windows.Name == "MainSettingWindow")
                    windows.Close();
            }

            (new SettingWindow(TOP_MENU_BUTTON.CREATE)).Show();
        }

        private void HotkeyHotKeyClick(object sender, RoutedEventArgs e)
        {
            foreach (Window windows in App.Current.Windows)
            {
                if (windows.Name == "MainSettingWindow")
                    windows.Close();
            }

            (new SettingWindow(TOP_MENU_BUTTON.HOTKEY)).Show();
        }

        private void LanguageHotKeyClick(object sender, RoutedEventArgs e)
        {
            foreach (Window windows in App.Current.Windows)
            {
                if (windows.Name == "MainSettingWindow")
                    windows.Close();
            }

            (new SettingWindow(TOP_MENU_BUTTON.LANGUAGE)).Show();
        }

        private void ExampleButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (Window windows in App.Current.Windows)
            {
                if (windows.Name == "MainSettingWindow")
                    windows.Close();
            }

            (new SettingWindow(TOP_MENU_BUTTON.EXAMPLE)).Show();
        }

        private void HideRevealInfospace(object sender, RoutedEventArgs e)
        {
            if (Infospace.Height == new GridLength(150))
                Infospace.Height = new GridLength(0);
            else
                Infospace.Height = new GridLength(150);
        }

        private void DeleteActiveDevice(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < ActiveElement._activeElement.InputsLines.Count; i++)
            {
                if(ActiveElement._activeElement.InputsLines[i] != null)
                    MainPage.getCanvas().Children.Remove(ActiveElement._activeElement.InputsLines[i]);
                ActiveElement._activeElement.InputsLines[i] = null;
            }

            for (int i = 0; i < ActiveElement._activeElement.OutputsLines.Count; i++)
            {
                if (ActiveElement._activeElement.OutputsLines[i] != null)
                    MainPage.getCanvas().Children.Remove(ActiveElement._activeElement.OutputsLines[i]);
                ActiveElement._activeElement.OutputsLines[i] = null;
            }

            MainPage.getCanvas().Children.Remove(ActiveElement._activeElement.grid);
        }
    }
}
