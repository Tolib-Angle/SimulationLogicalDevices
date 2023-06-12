using SimulatorLogicDevices.Model.BaseElements;
using SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement;
using System.Windows;
using System.Windows.Controls;

namespace SimulatorLogicDevices.View.MainWindow.Pages
{
    public partial class ElementsPage : Page
    {
        public ElementsPage()
        {
            InitializeComponent();
        }

        private void AddElementAND(object sender, RoutedEventArgs e)
        {
            AND and = new AND();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddElementOR(object sender, RoutedEventArgs e)
        {
            OR and = new OR();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddElementNOT(object sender, RoutedEventArgs e)
        {
            NOT and = new NOT();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddElementXOR(object sender, RoutedEventArgs e)
        {
            XOR and = new XOR();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddElementANDNOT(object sender, RoutedEventArgs e)
        {
            AND_NOT and = new AND_NOT();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddElementORNOT(object sender, RoutedEventArgs e)
        {
            OR_NOT and = new OR_NOT();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddElementTriggerD(object sender, RoutedEventArgs e)
        {
            D_Trigger and = new D_Trigger();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddElementTriggerRS(object sender, RoutedEventArgs e)
        {
            RS_Trigger and = new RS_Trigger();
            AddElementsInCanvas.AddElements(and);
        }

        private void AddElementCounter(object sender, RoutedEventArgs e)
        {
            Counter and = new Counter();
            AddElementsInCanvas.AddElements(and);
        }
    }
}
