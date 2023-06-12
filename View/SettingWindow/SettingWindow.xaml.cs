using SimulatorLogicDevices.View.SettingWindow.Pages;
using SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement;
using SimulatorLogicDevices.ViewModel.ControlPages;
using SimulatorLogicDevices.ViewModel.DialogService;
using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public enum TOP_MENU_BUTTON { FILE, SETTING, HELP, CREATE, EXAMPLE, HOTKEY, LANGUAGE };

namespace SimulatorLogicDevices.View.SettingWindow
{
    public partial class SettingWindow : Window
    {
        DefaultDialogService dialogService;
        SaveLoad save;
        public SettingWindow(TOP_MENU_BUTTON currentButton)
        {
            InitializeComponent();

            InitButtons(currentButton);
            dialogService = new DefaultDialogService();
            save = new SaveLoad();
        }

        private void DragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseSettingWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveSettings(object sender, RoutedEventArgs e)
        {
            SettingWindowPagesViewModel.getThemePage().saveTheme();
            SettingWindowPagesViewModel.getLanguagePage().saveLanguage();

            if(OpenPage.path != "")
                save.Load(OpenPage.path);
        }

        private void FileButtonClick(object sender, RoutedEventArgs e)
        {
            if (FileTabs.Visibility == Visibility.Collapsed)
                FileTabs.Visibility = Visibility.Visible;
            else
                FileTabs.Visibility = Visibility.Collapsed;
        }

        private void SaveCurrentProject(object sender, RoutedEventArgs e)
        {
            dialogService.SaveFileDialog();
            Console.WriteLine(dialogService.FilePath);
            save.Save(dialogService.FilePath);
        }

        private void SettingButtonClick(object sender, RoutedEventArgs e)
        {
            if (SettingTabs.Visibility == Visibility.Collapsed)
                SettingTabs.Visibility = Visibility.Visible;
            else
                SettingTabs.Visibility = Visibility.Collapsed;
        }

        private void HelpButtonClick(object sender, RoutedEventArgs e)
        {
            if (HelpTabs.Visibility == Visibility.Collapsed)
                HelpTabs.Visibility = Visibility.Visible;
            else
                HelpTabs.Visibility = Visibility.Collapsed;
        }

        private void InitButtons(TOP_MENU_BUTTON currentButton)
        {
            if (currentButton == TOP_MENU_BUTTON.FILE)
            {
                FileButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                FileButton.IsChecked = true;
                WindowName.Text = (string)FileButton.Content;
                OpenButton.Command.Execute(this);
                FocusExtension.SetIsFocused(OpenButton, true);
            }
            else if (currentButton == TOP_MENU_BUTTON.SETTING)
            {
                SettingButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                SettingButton.IsChecked = true;
                WindowName.Text = (string)SettingButton.Content;
                ThemeButton.Command.Execute(this);
                FocusExtension.SetIsFocused(ThemeButton, true);
            }
            else if (currentButton == TOP_MENU_BUTTON.HELP)
            {
                HelpButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                HelpButton.IsChecked = true;
                WindowName.Text = (string)HelpButton.Content;
                DocumentationButton.Command.Execute(this);
                FocusExtension.SetIsFocused(DocumentationButton, true);
            }
            else if (currentButton == TOP_MENU_BUTTON.EXAMPLE)
            {
                SettingButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                SettingButton.IsChecked = true;
                WindowName.Text = (string)HelpButton.Content;
                ExamplesButton.Command.Execute(this);
                FocusExtension.SetIsFocused(ExamplesButton, true);
            }
            else if (currentButton == TOP_MENU_BUTTON.LANGUAGE)
            {
                SettingButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                SettingButton.IsChecked = true;
                WindowName.Text = (string)SettingButton.Content;
                LanguageButton.Command.Execute(this);
                FocusExtension.SetIsFocused(LanguageButton, true);
            }
            else if (currentButton == TOP_MENU_BUTTON.HOTKEY)
            {
                HelpButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                HelpButton.IsChecked = true;
                WindowName.Text = (string)HelpButton.Content;
                HotKeyButton.Command.Execute(this);
                FocusExtension.SetIsFocused(HotKeyButton, true);
            }

            ProgrammVersion.Text = Properties.Settings.Default.version;
        }
    }
}
