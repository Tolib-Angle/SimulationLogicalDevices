using SimulatorLogicDevices.Model.BaseElements;
using SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement;
using System.Windows;
using System.Windows.Controls;

namespace SimulatorLogicDevices.View.MainWindow.Pages
{
    public partial class InputOutputPage : Page
    {
        public InputOutputPage()
        {
            InitializeComponent();
        }

        private void AddButtonInCanvas(object sender, RoutedEventArgs e)
        {
            ButtonE and = new ButtonE();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddLEDInCanvas(object sender, RoutedEventArgs e)
        {
            LED and = new LED();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddGenerator(object sender, RoutedEventArgs e)
        {
            Generator and = new Generator();
            AddElementsInCanvas.AddElements(and);
        }
    }
}
