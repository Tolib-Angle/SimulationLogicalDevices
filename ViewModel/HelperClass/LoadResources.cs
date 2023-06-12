using System;
using System.Windows;

namespace SimulatorLogicDevices.ViewModel.HelperClass
{
    internal static class LoadResources
    {
        // language resources path
        private static Uri uriRU = new Uri(@"\View\Resources\Language\RU\language.xaml", UriKind.Relative); // language RU
        private static Uri uriENG = new Uri(@"\View\Resources\Language\ENG\language.xaml", UriKind.Relative); // language ENG
        // theme resources path
        // dark theme
        private static Uri uriDarkColor = new Uri(@"\View\Resources\Theme\Dark\color.xaml", UriKind.Relative);
        private static Uri uriDarkIcons = new Uri(@"\View\Resources\Theme\Dark\icons.xaml", UriKind.Relative);
        // light theme
        private static Uri uriLightColor = new Uri(@"\View\Resources\Theme\Light\color.xaml", UriKind.Relative);
        private static Uri uriLightIcons = new Uri(@"\View\Resources\Theme\Light\icons.xaml", UriKind.Relative);

        public static void SetCurrentValue()
        {
            if (Properties.Settings.Default.languageRU)
            {
                ResourceDictionary resourceDictionary = Application.LoadComponent(uriRU) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
            else
            {
                ResourceDictionary resourceDictionary = Application.LoadComponent(uriENG) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }

            if (Properties.Settings.Default.darkTheme)
            {
                ResourceDictionary resourceDictionary = Application.LoadComponent(uriDarkColor) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                ResourceDictionary _resourceDictionary = Application.LoadComponent(uriDarkIcons) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(_resourceDictionary);
            }
            else
            {
                ResourceDictionary resourceDictionary = Application.LoadComponent(uriLightColor) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                ResourceDictionary _resourceDictionary = Application.LoadComponent(uriLightIcons) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(_resourceDictionary);
            }
        }

        public static void ChangeLanguage(bool languageRU)
        {
            if (languageRU)
            {
                ResourceDictionary resourceDictionary = Application.LoadComponent(uriRU) as ResourceDictionary;
                Application.Current.Resources.Remove(uriENG);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
            else
            {
                ResourceDictionary resourceDictionary = Application.LoadComponent(uriENG) as ResourceDictionary;
                Application.Current.Resources.Remove(uriRU);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }

            SaveLanguage(languageRU);
        }

        public static void ChangeTheme(bool dark)
        {
            if (!dark)
            {
                ResourceDictionary resourceDictionary = Application.LoadComponent(uriLightColor) as ResourceDictionary;
                Application.Current.Resources.Remove(uriDarkColor);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                ResourceDictionary _resourceDictionary = Application.LoadComponent(uriLightIcons) as ResourceDictionary;
                Application.Current.Resources.Remove(uriDarkIcons);
                Application.Current.Resources.MergedDictionaries.Add(_resourceDictionary);
            }
            else
            {
                ResourceDictionary resourceDictionary = Application.LoadComponent(uriDarkColor) as ResourceDictionary;
                Application.Current.Resources.Remove(uriLightColor);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                ResourceDictionary _resourceDictionary = Application.LoadComponent(uriDarkIcons) as ResourceDictionary;
                Application.Current.Resources.Remove(uriLightIcons);
                Application.Current.Resources.MergedDictionaries.Add(_resourceDictionary);
            }

            SaveTheme(dark);
        }

        private static void SaveLanguage(bool languageRU)
        {
            Properties.Settings.Default.languageRU = languageRU;
            Properties.Settings.Default.Save();
        }

        private static void SaveTheme(bool dark)
        {
            Properties.Settings.Default.darkTheme = dark;
            Properties.Settings.Default.Save();
        }
    }
}
