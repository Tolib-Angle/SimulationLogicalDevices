using SimulatorLogicDevices.View.MainWindow.Pages;
using SimulatorLogicDevices.ViewModel.AllElementViewModel;
using SimulatorLogicDevices.ViewModel.DialogService;
using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Shapes;

namespace SimulatorLogicDevices.Model
{
    internal abstract class ILogic : IElements
    {
        public Rectangle _activeBorder;
        public string _symbol;
        public string _name;
        protected DefaultDialogService defaultDialogService = new DefaultDialogService();
        protected bool firsTime = false;

        public abstract void RecalculateOutputValue();
        public abstract void setSymbolForDraw();

        public abstract void setNameElements();

        public abstract void setElementType();

        public ILogic()
        {
            setSymbolForDraw();
            setNameElements();
            setElementType();

            InitLogicElements();

            Draw();

            RecalculateOutputValue();
        }

        public void InitLogicElements()
        {
            inputs = new List<bool>();
            outputs = new List<bool>();

            _inputs = new List<Pair>();
            _outputs = new List<Pair>();
                
            inputs.Add(false);
            outputs.Add(false);
            
            _inputs.Add(new Pair(1, new Ellipse()));
            _outputs.Add(new Pair(1, new Ellipse()));
            
            InputsLines.Add(null);
            OutputsLines.Add(null);

            if (type != ElementType.NOT)
            {
                inputs.Add(false);
                _inputs.Add(new Pair(2, new Ellipse()));
                InputsLines.Add(null);
            }

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
                ManagementInfoSpace.SetInfo(inputs.Count, 0, type);
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
                grid.Children.Add(DrawElements.DrawLogicElement(ref _activeBorder, ref _inputs, ref _outputs, _symbol));

                for (int i = 0; i < _inputs.Count; i++)
                {
                    int j = i;
                    _inputs[i].value.AddHandler(ButtonBase.MouseDownEvent, new MouseButtonEventHandler((sender, e) =>
                    {
                        DrawLine.StartDraw(sender, e, this, j, true);
                    }));
                }

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
            return _name;
        }

        public override void Resize(int inputsCount)
        {
            try
            {
                int tmp = Math.Abs(inputsCount - inputs.Count);

                if (inputsCount > inputs.Count)
                {
                    for (int i = 0; i < tmp; i++)
                    {
                        inputs.Add(false);
                        _inputs.Add(new Pair(inputs.Count + i + 1, new Ellipse()));
                        InputsLines.Add(null);
                    }
                }
                else if (inputsCount < inputs.Count)
                {
                    for (int i = 0; i < tmp; i++)
                    {
                        inputs.Remove(inputs.Last());
                        _inputs.Remove(_inputs.Last());
                        InputsLines.Remove(InputsLines.Last());
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
            inputs[index] = value;

            RecalculateOutputValue();
        }

        public override void TriggerSetInputValue()
        {
            firsTime = true;
            RecalculateOutputValue();
        }
    }
}
