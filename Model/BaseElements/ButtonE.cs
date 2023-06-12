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
    internal class ButtonE : IElements
    {
        private Ellipse _button;
        private Rectangle _activeBorder;

        public ButtonE()
        {
            InitElementButton();

            Draw();

            _button.AddHandler(ButtonBase.MouseDownEvent, new MouseButtonEventHandler(PushButton));
        }

        private void InitElementButton()
        {
            outputs = new List<bool>();

            _outputs = new List<Pair>();

            outputs.Add(false);

            _outputs.Add(new Pair(1, new Ellipse()));

            OutputsLines.Add(null);

            ConnectionElements.Add(null);
        }

        private void PushButton(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (_button.Margin == new Thickness(0))
                {
                    _button.Margin = new Thickness(1, 1, 0, 0);
                    outputs[0] = true;
                    _outputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");

                    if (OutputsLines[0] != null)
                    {
                        OutputsLines[0].Stroke = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                        ConnectionElements[0].elements.SetInputValue(ConnectionElements[0].index, outputs[0]);
                    }
                }
                else
                {
                    _button.Margin = new Thickness(0);
                    outputs[0] = false;
                    _outputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");

                    if (OutputsLines[0] != null)
                    {
                        OutputsLines[0].Stroke = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                        ConnectionElements[0].elements.SetInputValue(ConnectionElements[0].index, outputs[0]);
                    }
                }
            }
            catch
            {
                defaultDialogService.ShowMessage("Undefined error! Try again!");
            }
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
                ManagementInfoSpace.SetInfo(0, 0, ElementType.BUTTON);
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
                grid.Children.Add(DrawElements.DrawButton(ref _button, ref _activeBorder, ref _outputs));

                _outputs[0].value.AddHandler(ButtonBase.MouseDownEvent, new MouseButtonEventHandler((sender, e) =>
                {
                    DrawLine.StartDraw(sender, e, this, 0, false);
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
            return "Button";
        }

        public override void Resize(int inputsCount)
        {
            //NO RESIZE
        }

        public override void SetInputValue(int index, bool value)
        {
            // NOT INPUTS
        }

        public override void TriggerSetInputValue()
        {
            try
            {
                if (OutputsLines[0] != null)
                {
                    ConnectionElements[0].elements.SetInputValue(ConnectionElements[0].index, outputs[0]);
                }
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }
    }
}
