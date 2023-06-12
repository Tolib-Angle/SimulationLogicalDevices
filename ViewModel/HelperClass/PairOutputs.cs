using SimulatorLogicDevices.Model;

namespace SimulatorLogicDevices.ViewModel.HelperClass
{
    internal class PairOutputs
    {
        public IElements elements { set; get; }
        public int index { set; get; }

        public PairOutputs()
        {
            elements = null;
            index = -1;
        }

        public PairOutputs(IElements _elements, int _index)
        {
            elements = _elements;
            index = _index;
        }
    }
}
