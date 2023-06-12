using Newtonsoft.Json;
using SimulatorLogicDevices.Model;

namespace SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement
{
    internal class ElementsSaveValue
    {
        public int id { get; set; }
        public int inputs { get; set; }
        public int outputs { get; set; }
        public ElementType elementType { get; set; }
        public double positionX {
            set
            {
                x = value;
            }
            get 
            {
                if (elements == null)
                    return x;
                else
                    return elements.translateTransform.X;
            } 
        }
        public double positionY
        {
            set
            {
                y = value;
            }
            get 
            { 
                if(elements == null)
                    return y;
                else
                    return elements.translateTransform.Y;
            } 
        }
        [JsonIgnore] public IElements elements { get; set; }
        [JsonIgnore] private double x;
        [JsonIgnore] private double y;
    }
}