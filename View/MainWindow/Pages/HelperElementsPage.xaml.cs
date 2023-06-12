using SimulatorLogicDevices.Model.HelperDevices;
using SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement;
using System.Windows;
using System.Windows.Controls;

namespace SimulatorLogicDevices.View.MainWindow.Pages
{
    public partial class HelperElementsPage : Page
    {
        public HelperElementsPage()
        {
            InitializeComponent();
        }

        private void AddElementDelimiter(object sender, RoutedEventArgs e)
        {
            Delimiter and = new Delimiter();
            AddElementsInCanvas.AddElements(and);
        }
    }
}
