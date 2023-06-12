using System.Windows.Shapes;

namespace SimulatorLogicDevices.ViewModel.HelperClass
{
    internal class Pair
    {
        public int key { get; set; }
        public Ellipse value { get; set; }

        public Pair()
        {
            key = 0;
            value = new Ellipse();
        }

        public Pair(int _key, Ellipse _value)
        {
            key = _key;
            value = _value;
        }
    }
}
