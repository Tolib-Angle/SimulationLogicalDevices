using SimulatorLogicDevices.Model;
using SimulatorLogicDevices.View.MainWindow.Pages;
using System.Collections.Generic;

namespace SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement
{
    internal static class AddElementsInCanvas
    {
        public static List<ElementsSaveValue> elements = new List<ElementsSaveValue>();
        public static List<LinkElements> linkElements = new List<LinkElements>();

        public static void AddElements (IElements element)
        {
            MainPage.getCanvas().Children.Add(element.grid);
            int _input, _outputs;

            if(element.inputs == null)
                _input = 0;
            else
                _input = element.inputs.Count;

            if(element.outputs == null)
                _outputs = 0;
            else
                _outputs = element.outputs.Count;

            elements.Add(new ElementsSaveValue
            {
                id = element.id,
                elementType = element.type,
                elements = element,
                inputs = _input,
                outputs = _outputs
            });
        }
        public static void AddElements(IElements element, double x, double y)
        {
            element.SetGridPosition(x, y);
            MainPage.getCanvas().Children.Add(element.grid);
            int _input, _outputs;

            if (element.inputs == null)
                _input = 0;
            else
                _input = element.inputs.Count;

            if (element.outputs == null)
                _outputs = 0;
            else
                _outputs = element.outputs.Count;

            elements.Add(new ElementsSaveValue
            {
                id = element.id,
                elementType = element.type,
                elements = element,
                inputs = _input,
                outputs = _outputs
            });
        }
        public static void Link(IElements first, IElements second, int firsPort, int SecondPort)
        {
            linkElements.Add(new LinkElements(first.id, second.id, firsPort, SecondPort));
        }
    }
}
