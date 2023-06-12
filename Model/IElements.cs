using SimulatorLogicDevices.View.MainWindow.Pages;
using SimulatorLogicDevices.ViewModel.AllElementViewModel;
using SimulatorLogicDevices.ViewModel.DialogService;
using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

internal enum ElementType { AND, OR, NOT, XOR, ANDNOT, ORNOT, 
    BUTTON, LED, GENERATOR, COUNTER, DTRIGGER, RSTRIGGER, DELIMITER }

namespace SimulatorLogicDevices.Model
{
    internal abstract class IElements
    {
        public int id;
        public ElementType type;
        // grid - draw in canvas element
        public Grid grid = new Grid();
        // connect line
        public List<Line> InputsLines = new List<Line>();
        public List<Line> OutputsLines = new List<Line>();
        // logical value
        public List<bool> inputs;
        public List<bool> outputs;
        // inputs/outputs ellepse object
        public List<Pair> _inputs;
        public List<Pair> _outputs;
        // link to output elements
        public List<PairOutputs> ConnectionElements = new List<PairOutputs>();
        // for show massege
        protected DefaultDialogService defaultDialogService = new DefaultDialogService();
        static private int counter = 1;
        // for DragMove elements
        private Point m_start;
        private Vector m_startOffset;
        public TranslateTransform translateTransform = new TranslateTransform();
        public abstract void Draw();
        public abstract void Active();
        public abstract void Inactive();
        public abstract string NameElement();
        public abstract void AddInfo();
        public abstract void Resize(int inputsCount);
        public abstract void SetInputValue(int index, bool value);
        public abstract void TriggerSetInputValue();
        public IElements()
        {
            id = counter;
            counter++;

            grid.RenderTransform = translateTransform;

            try
            {
                grid.AddHandler(Button.MouseDownEvent, new MouseButtonEventHandler(Grid_MouseDown));
                grid.AddHandler(Button.MouseMoveEvent, new MouseEventHandler(Grid_MouseMove));
                grid.AddHandler(Button.MouseUpEvent, new MouseButtonEventHandler(Grid_MouseUp));
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ActiveElement.SetActiveElement(this);

                m_start = e.GetPosition(MainPage.getCanvas());
                m_startOffset = new Vector(translateTransform.X, translateTransform.Y);
                grid.CaptureMouse();
            }
            catch
            {
                defaultDialogService.ShowMessage("Undefined error! Try again!");
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (grid.IsMouseCaptured)
                {
                    Vector offset = Point.Subtract(e.GetPosition(MainPage.getCanvas()), m_start);

                    translateTransform.X = m_startOffset.X + offset.X;
                    translateTransform.Y = m_startOffset.Y + offset.Y;

                    for (int i = 0; i < OutputsLines.Count; i++)
                    {
                        if (NameElement() != "LED")
                        {
                            if (OutputsLines[i] != null)
                            {
                                OutputsLines[i].X1 = Canvas.GetLeft(_outputs[i].value) + translateTransform.X + 5;
                                OutputsLines[i].Y1 = Canvas.GetTop(_outputs[i].value) + translateTransform.Y + 5;
                            }
                        }
                    }

                    for (int i = 0; i < InputsLines.Count; i++)
                    {
                        if (NameElement() != "Button" && NameElement() != "Generator")
                        {
                            if (InputsLines[i] != null)
                            {
                                InputsLines[i].X2 = Canvas.GetLeft(_inputs[i].value) + translateTransform.X + 5;
                                InputsLines[i].Y2 = Canvas.GetTop(_inputs[i].value) + translateTransform.Y + 5;
                            }
                        }
                    }
                }
            }
            catch
            {
                defaultDialogService.ShowMessage("Undefined error! Try again!");
            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grid.ReleaseMouseCapture();
        }

        public void SetGridPosition(double x, double y)
        {
            translateTransform.Y = y;
            translateTransform.X = x;
        }

        public void setId(int _id)
        {
            id = _id;
        }

        public void ConnectInput(int port, IElements element, Line line)
        {
            try
            {
                InputsLines[port] = line;

                line.X2 = Canvas.GetLeft(_inputs[port].value) + translateTransform.X + 5;
                line.Y2 = Canvas.GetTop(_inputs[port].value) + translateTransform.Y + 5;
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }

        public void ConnectOutput(int port, IElements element, Line line)
        {
            try
            {
                OutputsLines[port] = line;
                ConnectionElements[port] = new PairOutputs(element, port);

                line.X1 = Canvas.GetLeft(_outputs[port].value) + translateTransform.X + 5;
                line.Y1 = Canvas.GetTop(_outputs[port].value) + translateTransform.Y + 5;
            }
            catch (ArgumentException e)
            {
                defaultDialogService.ShowMessage(e.Message);
            }
        }
    }
}
