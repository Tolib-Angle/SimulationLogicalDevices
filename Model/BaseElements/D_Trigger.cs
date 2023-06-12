using SimulatorLogicDevices.View.MainWindow.Pages;
using SimulatorLogicDevices.ViewModel.AllElementViewModel;
using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulatorLogicDevices.Model.BaseElements
{
    internal class D_Trigger : IElements
    {
        private Rectangle _activeBorder;
        private List<string> inputsOutputsName = new List<string>();

        public D_Trigger()
        {
            InitRSTrigger();

            Draw();

            RecalculateOutputValue();
        }

        private void InitRSTrigger()
        {
            inputs = new List<bool>();
            outputs = new List<bool>();

            _inputs = new List<Pair>();
            _outputs = new List<Pair>();

            inputs.Add(false);
            inputs.Add(false);
            outputs.Add(false);
            outputs.Add(true);

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

            inputsOutputsName.Add("D");
            inputsOutputsName.Add("C");
            inputsOutputsName.Add("Q");
            inputsOutputsName.Add("¬Q");
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
                ManagementInfoSpace.SetInfo(0, 0, ElementType.DTRIGGER);
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
                grid.Children.Add(DrawElements.DrawTwoOrMoreInputsOutputs(ref _activeBorder, ref _inputs, ref _outputs, "T", inputsOutputsName));

                _outputs[0].value.AddHandler(ButtonBase.MouseDownEvent, new MouseButtonEventHandler((sender, e) =>
                {
                    DrawLine.StartDraw(sender, e, this, 0, false);
                }));
                _outputs[1].value.AddHandler(ButtonBase.MouseDownEvent, new MouseButtonEventHandler((sender, e) =>
                {
                    DrawLine.StartDraw(sender, e, this, 1, false);
                }));
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
            return "D - Trigger";
        }

        public override void Resize(int inputsCount)
        {
            // NO RESIZE
        }

        public override void SetInputValue(int index, bool value)
        {
            inputs[index] = value;

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
                bool ou1 = outputs[0], ou2 = outputs[1];

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

                if (!inputs[1])
                {
                    outputs[0] = outputs[0];
                    outputs[1] = outputs[1];
                }
                else if (inputs[1])
                {
                    outputs[0] = inputs[0];
                    outputs[1] = !inputs[0];
                }

                bool is_changed = false;

                if (outputs[0] != ou1 || ou2 != outputs[1])
                    is_changed = true;

                for (int i = 0; i < outputs.Count; i++)
                {
                    if (outputs[i])
                    {
                        _outputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                    }
                    else
                    {
                        _outputs[i].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                    }

                    if (OutputsLines[i] != null && is_changed)
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
    }
}
