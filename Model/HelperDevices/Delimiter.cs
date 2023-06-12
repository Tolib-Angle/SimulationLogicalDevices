using SimulatorLogicDevices.View.MainWindow.Pages;
using SimulatorLogicDevices.ViewModel.AllElementViewModel;
using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulatorLogicDevices.Model.HelperDevices
{
    internal class Delimiter : IElements
    {
        private Rectangle _activeBorder;

        public Delimiter()
        {
            InitElementAND();

            Draw();

            RecalculateOutputValue();
        }

        private void InitElementAND()
        {
            inputs = new List<bool>();
            outputs = new List<bool>();

            _inputs = new List<Pair>();
            _outputs = new List<Pair>();

            inputs.Add(false);
            outputs.Add(false);
            outputs.Add(false);

            _inputs.Add(new Pair(1, new Ellipse()));
            _outputs.Add(new Pair(1, new Ellipse()));
            _outputs.Add(new Pair(2, new Ellipse()));

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
                ManagementInfoSpace.SetInfo(0, outputs.Count, ElementType.DELIMITER);
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
                grid.Children.Add(DrawElements.DrawElementInOneInput(ref _activeBorder, ref _inputs, ref _outputs, "-=", 40));

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
            return "Logical \"DELIMITER\"";
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
            inputs[0] = value;

            RecalculateOutputValue();
        }

        private void RecalculateOutputValue()
        {
            if (inputs[0])
            {
                _inputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                if (InputsLines[0] != null)
                    InputsLines[0].Stroke = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
            }
            else
            {
                _inputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                if (InputsLines[0] != null)
                    InputsLines[0].Stroke = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
            }

            for (int i = 0; i < outputs.Count; i++)
            {
                outputs[i] = inputs[0];
                if (outputs[i])
                {
                    outputs[i] = true;
                    _outputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                }
                else
                {
                    outputs[i] = false;
                    _outputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                }
            }
            try
            {
                for (int i = 0; i < outputs.Count; i++)
                {
                    if (OutputsLines[i] != null)
                    {
                        ConnectionElements[i].elements.SetInputValue(ConnectionElements[i].index, outputs[i]);
                    }
                }
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }

        public override void TriggerSetInputValue()
        {
            RecalculateOutputValue();
        }
    }
}
