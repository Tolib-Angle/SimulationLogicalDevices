﻿using System;
using System.Windows;
using System.Windows.Media;

namespace SimulatorLogicDevices.Model.BaseElements
{
    internal class OR : ILogic
    {
        public override void RecalculateOutputValue()
        {
            try
            {
                bool tmp_output = false;
                bool is_changed = false;

                for (int i = 0; i < inputs.Count; i++)
                    if (inputs[i] == true)
                        tmp_output = true;

                if (tmp_output != outputs[0] || outputs[0])
                    is_changed = true;

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
            type = ElementType.OR;
        }

        public override void setNameElements()
        {
            _name = "Logic \'OR\'";
        }

        public override void setSymbolForDraw()
        {
            _symbol = "1";
        }
    }
}
