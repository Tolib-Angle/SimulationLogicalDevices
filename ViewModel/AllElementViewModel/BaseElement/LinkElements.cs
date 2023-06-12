namespace SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement
{
    internal class LinkElements
    {
        public int firstElement { set; get; }
        public int secondElement { set; get; }
        public int firstPort { set; get; }
        public int secondPort { set; get; }
        public LinkElements(int firs, int second, int _firsPort, int _secondPort)
        {
            firstElement = firs;
            secondElement = second;
            firstPort = _firsPort;
            secondPort = _secondPort;
        }
    }
}
