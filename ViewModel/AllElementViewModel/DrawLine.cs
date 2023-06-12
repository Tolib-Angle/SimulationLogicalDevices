using SimulatorLogicDevices.Model;
using SimulatorLogicDevices.View.MainWindow.Pages;
using SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement;
using SimulatorLogicDevices.ViewModel.DialogService;
using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulatorLogicDevices.ViewModel.AllElementViewModel
{
    internal static class DrawLine
    {
        private static Point StartPosition, EndPosition;
        public static bool startDraw { set; get; }
        private static Line _curLine = null;
        private static Ellipse firstEllepse = null;
        private static IElements firstElement = null;
        private static int firstIndex = 0;
        private static DefaultDialogService defaultDialogService = new DefaultDialogService();

        public static void StartDraw(object sender, MouseButtonEventArgs e, IElements elements, int i, bool inputDraw)
        {
            try
            {
                if (inputDraw)
                {
                    if (elements.InputsLines[i] != null)
                        return;
                }
                else
                {
                    if (elements.OutputsLines[i] != null)
                        return;
                }

                if (!startDraw)
                {
                    firstIndex = i;
                    firstElement = elements;

                    FrameworkElement fe = MainPage.getCanvas();
                    StartPosition = e.MouseDevice.GetPosition(fe);
                    _curLine = new Line();

                    _curLine.StrokeThickness = 3;
                    _curLine.Stroke = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");

                    _curLine.X1 = StartPosition.X;
                    _curLine.Y1 = StartPosition.Y;
                    _curLine.X2 = StartPosition.X;
                    _curLine.Y2 = StartPosition.Y;

                    MainPage.getCanvas().Children.Add(_curLine);

                    startDraw = true;

                    firstEllepse = sender as Ellipse;
                }
                else
                {
                    startDraw = false;

                    firstElement.ConnectionElements[firstIndex] = new PairOutputs(elements, i);

                    if (inputDraw)
                    {
                        firstElement.OutputsLines[firstIndex] = _curLine;
                        elements.InputsLines[i] = _curLine;

                        firstElement.TriggerSetInputValue();
                        AddElementsInCanvas.Link(firstElement, elements, firstIndex, i);
                    }
                    else
                    {
                        firstElement.InputsLines[firstIndex] = _curLine;
                        elements.OutputsLines[i] = _curLine;

                        elements.TriggerSetInputValue();
                        AddElementsInCanvas.Link(elements, firstElement, i, firstIndex);
                    }
                }
            }
            catch
            {
                defaultDialogService.ShowMessage("Undefined error! Try again!");
            }
        }

        public static void DropDrawLine(object sender, MouseButtonEventArgs e)
        {
            startDraw = false;
            MainPage.getCanvas().Children.Remove(_curLine);
        }

        public static void DragMoveMouse(object sender, MouseEventArgs e)
        {
            try
            {
                if (startDraw)
                {
                    FrameworkElement fe = sender as FrameworkElement;

                    EndPosition = e.MouseDevice.GetPosition(fe);

                    if (_curLine != null)
                    {
                        _curLine.X2 = EndPosition.X - 1;
                        _curLine.Y2 = EndPosition.Y - 1;
                    }
                }
            }
            catch
            {
                defaultDialogService.ShowMessage("Undefined error! Try again!");
            }
        }
    }
}
