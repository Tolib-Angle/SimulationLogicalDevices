using System;
using System.Windows;
using System.Windows.Media;

namespace SimulatorLogicDevices.Model.BaseElements
{
    internal class NOT : ILogic
    {
        public override void RecalculateOutputValue()
        {
            try
            {
                bool tmp_output = true;

                if (inputs[0] == true)
                    tmp_output = false;

                bool is_changed = false;
                if (tmp_output != outputs[0] || outputs[0])
                    is_changed = true;

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

                if (tmp_output)
                {
                    outputs[0] = true;
                    _outputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPushPortBackgroundColor");
                }
                else
                {
                    outputs[0] = false;
                    _outputs[0].value.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                }

                if (OutputsLines[0] != null && is_changed)
                {
                    ConnectionElements[0].elements.SetInputValue(ConnectionElements[0].index, outputs[0]);
                }
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }

        public override void setElementType()
        {
            type = ElementType.NOT;
        }

        public override void setNameElements()
        {
            _name = "Logic \'NOT\'";
        }

        public override void setSymbolForDraw()
        {
            _symbol = "~";
        }
    }
}
