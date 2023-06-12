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
    internal class LED : IElements
    {
        private Rectangle _activeBorder;
        private Rectangle _led;
        public LED()
        {
            InitElementLED();

            Draw();
        }

        private void InitElementLED()
        {
            inputs = new List<bool>();

            _inputs = new List<Pair>();

            inputs.Add(false);

            _inputs.Add(new Pair(1, new Ellipse()));

            InputsLines.Add(null);
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
                ManagementInfoSpace.SetInfo(0, 0, ElementType.LED);
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
                grid.Children.Add(DrawElements.DrawLED(ref _led, ref _activeBorder, ref _inputs));

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
            return "LED";
        }

        public override void Resize(int inputsCount)
        {
            // NO RESIZE
        }

        public override void SetInputValue(int index, bool value)
        {
            try
            {
                inputs[index] = value;
                if (value)
                {
                    _led.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                    if (InputsLines[0] != null)
                        InputsLines[0].Stroke = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                    _inputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                }
                else
                {
                    _led.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                    if (InputsLines[0] != null)
                        InputsLines[0].Stroke = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                    _inputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                }
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }

        public override void TriggerSetInputValue()
        {
            try
            {
                if (inputs[0])
                {
                    _led.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                    if (InputsLines[0] != null)
                        InputsLines[0].Stroke = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                    _inputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                }
                else
                {
                    _led.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                    if (InputsLines[0] != null)
                        InputsLines[0].Stroke = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                    _inputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                }
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }
    }
}
