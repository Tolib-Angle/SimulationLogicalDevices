using SimulatorLogicDevices.Model;

namespace SimulatorLogicDevices.ViewModel.AllElementViewModel
{
    internal class ActiveElement
    {
        public static IElements _activeElement;

        public static void SetActiveElement(IElements _element)
        {
            if(_activeElement != null && _activeElement != _element)
            {
                _activeElement.Inactive();
            }
            // UI and infospace
            _element.Active();
            _element.AddInfo();
            _activeElement = _element;
        }
    }
}
