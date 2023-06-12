using System.Windows.Controls;
using System.Windows;
using System;
using SimulatorLogicDevices.ViewModel.AllElementViewModel;

namespace SimulatorLogicDevices.View.MainWindow.Pages
{
    public partial class InfoPage : Page
    {
        public static bool resize = false; 
        public InfoPage()
        {
            InitializeComponent();
        }

        private void InputsRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item && ActiveElement._activeElement != null && resize)
            {
                ActiveElement._activeElement.Resize(Convert.ToInt32(item.Content.ToString()));
            }
        }

        private void OutputsRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item && ActiveElement._activeElement != null && resize)
            {
                ActiveElement._activeElement.Resize(Convert.ToInt32(item.Content.ToString()));
            }
        }
    }
}
