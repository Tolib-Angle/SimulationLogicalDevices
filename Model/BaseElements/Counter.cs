using SimulatorLogicDevices.View.MainWindow.Pages;
using SimulatorLogicDevices.ViewModel.AllElementViewModel;
using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulatorLogicDevices.Model.BaseElements
{
    internal class Counter : IElements
    {
        private Rectangle _activeBorder;
        private int countSignal;

        public Counter()
        {
            countSignal = 0;

            InitElementCounter();

            Draw();

            RecalculateOutputValue();
        }

        private void InitElementCounter()
        {
            inputs = new List<bool>();
            outputs = new List<bool>();

            _inputs = new List<Pair>();
            _outputs = new List<Pair>();

            inputs.Add(false);
            inputs.Add(false);
            outputs.Add(false);
            outputs.Add(false);

            _inputs.Add(new Pair(1, new Ellipse()));
            _inputs.Add(new Pair(2, new Ellipse()));
            _outputs.Add(new Pair(1, new Ellipse()));
            _outputs.Add(new Pair(2, new Ellipse()));

            InputsLines.Add(null);
            InputsLines.Add(null);
            OutputsLines.Add(null);
            OutputsLines.Add(null);

            ConnectionElements.Add(null);
            ConnectionElements.Add(null);
        }

        public override void Active()
        {
            _activeBorder.StrokeThickness = 1;
        }

        public override void AddInfo()
        {
            try
            {
                InfoPage.resize = false;
                ManagementInfoSpace.ResetInfoPage();
                ManagementInfoSpace.SetInfo(0, outputs.Count, ElementType.COUNTER);
                InfoPage.resize = true;
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }

        public override void Draw()
        {
            try
            {
                grid.Children.Clear();
                grid.Children.Add(DrawElements.DrawCounter(ref _activeBorder, ref _inputs, ref _outputs, "Cn"));

                for (int i = 0; i < _outputs.Count; i++)
                {
                    int j = i;
                    _outputs[i].value.AddHandler(ButtonBase.MouseDownEvent, new MouseButtonEventHandler((sender, e) =>
                    {
                        DrawLine.StartDraw(sender, e, this, j, false);
                    }));
                }

                _inputs[0].value.AddHandler(ButtonBase.MouseDownEvent, new MouseButtonEventHandler((sender, e) =>
                {
                    DrawLine.StartDraw(sender, e, this, 0, true);
                }));
                _inputs[1].value.AddHandler(ButtonBase.MouseDownEvent, new MouseButtonEventHandler((sender, e) =>
                {
                    DrawLine.StartDraw(sender, e, this, 1, true);
                }));
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }

        public override void Inactive()
        {
            _activeBorder.StrokeThickness = 0;
        }

        public override string NameElement()
        {
            return "Counter";
        }

        public override void Resize(int inputsCount)
        {
            try
            {
                int tmp = Math.Abs(inputsCount - outputs.Count);
                if (inputsCount > outputs.Count)
                {
                    for (int i = 0; i < tmp; i++)
                    {
                        outputs.Add(false);
                        _outputs.Add(new Pair(outputs.Count + i + 1, new Ellipse()));
                        OutputsLines.Add(null);
                        ConnectionElements.Add(null);
                    }
                }
                else if (inputsCount < outputs.Count)
                {
                    for (int i = 0; i < tmp; i++)
                    {
                        outputs.Remove(outputs.Last());
                        _outputs.Remove(_outputs.Last());
                        OutputsLines.Remove(OutputsLines.Last());
                        ConnectionElements.Remove(ConnectionElements.Last());
                    }
                }
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }

            Draw();

            RecalculateOutputValue();

            Active();
        }

        public override void SetInputValue(int index, bool value)
        {
            try
            {
                if (value && index == 0)
                    countSignal++;
                if (index == 1 && value)
                    countSignal = 0;

                if (countSignal >= Math.Pow(2, outputs.Count))
                {
                    countSignal--;
                    return;
                }

                inputs[index] = value;
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }

            RecalculateOutputValue();
        }

        public override void TriggerSetInputValue()
        {
            RecalculateOutputValue();
        }

        private void RecalculateOutputValue()
        {
            try
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if (inputs[i])
                    {
                        _inputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                        if (InputsLines[i] != null)
                            InputsLines[i].Stroke = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                    }
                    else
                    {
                        _inputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                        if (InputsLines[i] != null)
                            InputsLines[i].Stroke = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                    }
                }

                List<int> buffer = new List<int>();
                int n = countSignal;
                bool tmp = false;
                do
                {
                    buffer.Add((n % 2));
                    n = n / 2;
                } while (n > 0);

                int j = 0;

                for (int i = outputs.Count - 1; i >= 0; i--)
                {
                    if (j >= buffer.Count)
                    {
                        outputs[i] = false;

                        if (OutputsLines[i] != null)
                            ConnectionElements[i].elements.SetInputValue(ConnectionElements[i].index, false);

                        _outputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                    }
                    else
                    {
                        tmp = buffer[j] == 1 ? true : false;
                        outputs[i] = tmp;

                        if (OutputsLines[i] != null)
                            ConnectionElements[i].elements.SetInputValue(ConnectionElements[i].index, tmp);

                        if (tmp)
                            _outputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                        else
                            _outputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");

                        j++;
                    }
                }
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }
    }
}
