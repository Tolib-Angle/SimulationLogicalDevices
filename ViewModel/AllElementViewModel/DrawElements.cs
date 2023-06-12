using SimulatorLogicDevices.ViewModel.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulatorLogicDevices.ViewModel.AllElementViewModel
{
    internal static class DrawElements
    {
        public static Canvas DrawButton(ref Ellipse _button, ref Rectangle _activeBorder, ref List<Pair> _outputs)
        {
            Canvas canvas = new Canvas();

            Rectangle _allElement = new Rectangle();
            _allElement.Width = 45;
            _allElement.Height = 40;
            Canvas.SetTop(_allElement, 10);
            Canvas.SetLeft(_allElement, 10);

            _activeBorder = new Rectangle();
            _activeBorder.Width = 40;
            _activeBorder.Height = 40;
            _activeBorder.Fill = (Brush)Application.Current.FindResource("ElementBackgroundColor");
            _activeBorder.Stroke = (Brush)Application.Current.FindResource("ElementActiveBorderColor");
            _activeBorder.StrokeThickness = 0;
            Canvas.SetTop(_activeBorder, 10);
            Canvas.SetLeft(_activeBorder, 10);

            Ellipse _btnShadow = new Ellipse();
            _btnShadow.Width = 25;
            _btnShadow.Height = 25;
            _btnShadow.Fill = (Brush)Application.Current.FindResource("ElementButtonShadowColor");
            Canvas.SetTop(_btnShadow, 18);
            Canvas.SetLeft(_btnShadow, 18);

            _button = new Ellipse();
            _button.Width = 25;
            _button.Height = 25;
            _button.Fill = (Brush)Application.Current.FindResource("ElementButtonColor");
            Canvas.SetTop(_button, 17);
            Canvas.SetLeft(_button, 17);


            Ellipse _tmpOutput = new Ellipse();
            _tmpOutput.Width = 10;
            _tmpOutput.Height = 10;
            _tmpOutput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
            _tmpOutput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
            _tmpOutput.StrokeThickness = 1;
            Canvas.SetTop(_tmpOutput, 40);
            Canvas.SetLeft(_tmpOutput, 44);

            _outputs[0].key = 1;
            _outputs[0].value = _tmpOutput;

            canvas.Children.Add(_allElement);
            canvas.Children.Add(_activeBorder);
            canvas.Children.Add(_btnShadow);
            canvas.Children.Add(_button);
            canvas.Children.Add(_outputs[0].value);

            return canvas;
        }

        public static Canvas DrawGenerator(ref Ellipse _button, ref Rectangle _activeBorder, ref List<Pair> _outputs)
        {
            Canvas canvas = new Canvas();

            Rectangle _allElement = new Rectangle();
            _allElement.Width = 45;
            _allElement.Height = 60;
            Canvas.SetTop(_allElement, 10);
            Canvas.SetLeft(_allElement, 10);

            _activeBorder = new Rectangle();
            _activeBorder.Width = 40;
            _activeBorder.Height = 60;
            _activeBorder.Fill = (Brush)Application.Current.FindResource("ElementBackgroundColor");
            _activeBorder.Stroke = (Brush)Application.Current.FindResource("ElementActiveBorderColor");
            _activeBorder.StrokeThickness = 0;
            Canvas.SetTop(_activeBorder, 10);
            Canvas.SetLeft(_activeBorder, 10);

            Ellipse _btnShadow = new Ellipse();
            _btnShadow.Width = 20;
            _btnShadow.Height = 20;
            _btnShadow.Fill = (Brush)Application.Current.FindResource("ElementButtonShadowColor");
            Canvas.SetTop(_btnShadow, 18);
            Canvas.SetLeft(_btnShadow, 21);

            _button = new Ellipse();
            _button.Width = 20;
            _button.Height = 20;
            _button.Fill = (Brush)Application.Current.FindResource("ElementButtonColor");
            Canvas.SetTop(_button, 17);
            Canvas.SetLeft(_button, 20);

            TextBlock _elementName = new TextBlock();
            _elementName.Text = "G";
            _elementName.HorizontalAlignment = HorizontalAlignment.Center;
            _elementName.VerticalAlignment = VerticalAlignment.Center;
            _elementName.Foreground = Brushes.White;
            Canvas.SetTop(_elementName, 55);
            Canvas.SetLeft(_elementName, 30);

            Ellipse _tmpOutput = new Ellipse();
            _tmpOutput.Width = 10;
            _tmpOutput.Height = 10;
            _tmpOutput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
            _tmpOutput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
            _tmpOutput.StrokeThickness = 1;
            Canvas.SetTop(_tmpOutput, 60);
            Canvas.SetLeft(_tmpOutput, 44);

            _outputs[0].key = 1;
            _outputs[0].value = _tmpOutput;

            canvas.Children.Add(_allElement);
            canvas.Children.Add(_activeBorder);
            canvas.Children.Add(_btnShadow);
            canvas.Children.Add(_button);
            canvas.Children.Add(_elementName);
            canvas.Children.Add(_outputs[0].value);

            return canvas;
        }

        public static Canvas DrawLED(ref Rectangle _led, ref Rectangle _activeBorder, ref List<Pair> _inputs)
        {
            Canvas canvas = new Canvas();

            Rectangle _allElments = new Rectangle();
            _allElments.Width = 45;
            _allElments.Height = 40;
            _allElments.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.SetTop(_allElments, 10);
            Canvas.SetLeft(_allElments, 10);

            _activeBorder = new Rectangle();
            _activeBorder.Width = 40;
            _activeBorder.Height = 40;
            _activeBorder.Fill = (Brush)Application.Current.FindResource("ElementBackgroundColor");
            _activeBorder.Stroke = (Brush)Application.Current.FindResource("ElementActiveBorderColor");
            _activeBorder.StrokeThickness = 0;
            Canvas.SetTop(_activeBorder, 10);
            Canvas.SetLeft(_activeBorder, 10);

            _led = new Rectangle();
            _led.Width = 26;
            _led.Height = 26; 
            _led.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor"); ;
            Canvas.SetTop(_led, 17);
            Canvas.SetLeft(_led, 17);

            Ellipse _tmpInput = new Ellipse();
            _tmpInput.Width = 10;
            _tmpInput.Height = 10;
            _tmpInput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
            _tmpInput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
            _tmpInput.StrokeThickness = 1;

            Canvas.SetTop(_tmpInput, 40);
            Canvas.SetLeft(_tmpInput, 5);

            _inputs[0].key = 1;
            _inputs[0].value = _tmpInput;

            canvas.Children.Add(_allElments);
            canvas.Children.Add(_activeBorder);
            canvas.Children.Add(_led);
            canvas.Children.Add(_inputs[0].value);

            return canvas;
        }

        public static Canvas DrawElementInOneInput(ref Rectangle _activeBorder, ref List<Pair> _inputs, ref List<Pair> _outputs, string symbol, double _width)
        {
            Canvas canvas = new Canvas();

            Rectangle _allElments = new Rectangle();
            double _height = 10 + 20 * _outputs.Count;
            _allElments.Width = _width;
            _allElments.Height = _height;
            _allElments.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.SetTop(_allElments, 10);
            Canvas.SetLeft(_allElments, 10);

            _activeBorder = new Rectangle();
            _activeBorder.Width = _width;
            _activeBorder.Height = _height;
            _activeBorder.Fill = (Brush)Application.Current.FindResource("ElementBackgroundColor");
            _activeBorder.Stroke = (Brush)Application.Current.FindResource("ElementActiveBorderColor");
            _activeBorder.StrokeThickness = 0;
            Canvas.SetTop(_activeBorder, 10);
            Canvas.SetLeft(_activeBorder, 10);

            TextBlock _elementName = new TextBlock();
            _elementName.Text = symbol;
            _elementName.HorizontalAlignment = HorizontalAlignment.Center;
            _elementName.VerticalAlignment = VerticalAlignment.Center;
            _elementName.Foreground = Brushes.White;
            Canvas.SetTop(_elementName, 20);
            Canvas.SetLeft(_elementName, 25);

            Ellipse _tmpInput = new Ellipse();
            _tmpInput.Width = 10;
            _tmpInput.Height = 10;
            _tmpInput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
            _tmpInput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
            _tmpInput.StrokeThickness = 1;

            Canvas.SetTop(_tmpInput, 20);
            Canvas.SetLeft(_tmpInput, 5);

            _inputs[0].key = 1;
            _inputs[0].value = _tmpInput;

            for (int i = 0; i < _outputs.Count; i++)
            {
                Ellipse _tmpOutput = new Ellipse();
                _tmpOutput.Width = 10;
                _tmpOutput.Height = 10;
                _tmpOutput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
                _tmpOutput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                _tmpOutput.StrokeThickness = 1;

                Canvas.SetTop(_tmpOutput, (i + 1) * 20);
                Canvas.SetLeft(_tmpOutput, _width + 5);

                _outputs[i].key = i;
                _outputs[i].value = _tmpOutput;
            }

            canvas.Children.Add(_allElments);
            canvas.Children.Add(_activeBorder);
            canvas.Children.Add(_inputs[0].value);
            for (int i = 0; i < _outputs.Count; i++)
                canvas.Children.Add(_outputs[i].value);
            canvas.Children.Add(_elementName);

            return canvas;
        }

        public static Canvas DrawCounter(ref Rectangle _activeBorder, ref List<Pair> _inputs, ref List<Pair> _outputs, string symbol)
        {
            Canvas canvas = new Canvas();

            Rectangle _allElments = new Rectangle();
            double _height = 10 + 20 * _outputs.Count;
            _allElments.Width = 80;
            _allElments.Height = _height;
            _allElments.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.SetTop(_allElments, 10);
            Canvas.SetLeft(_allElments, 10);

            _activeBorder = new Rectangle();
            _activeBorder.Width = 80;
            _activeBorder.Height = _height;
            _activeBorder.Fill = (Brush)Application.Current.FindResource("ElementBackgroundColor");
            _activeBorder.Stroke = (Brush)Application.Current.FindResource("ElementActiveBorderColor");
            _activeBorder.StrokeThickness = 0;
            Canvas.SetTop(_activeBorder, 10);
            Canvas.SetLeft(_activeBorder, 10);

            TextBlock _elementName = new TextBlock();
            _elementName.Text = symbol;
            _elementName.HorizontalAlignment = HorizontalAlignment.Center;
            _elementName.VerticalAlignment = VerticalAlignment.Center;
            _elementName.Foreground = Brushes.White;
            Canvas.SetTop(_elementName, 15);
            Canvas.SetLeft(_elementName, 40);

            TextBlock _resetOutput = new TextBlock();
            _resetOutput.Text = "R";
            _resetOutput.HorizontalAlignment = HorizontalAlignment.Center;
            _resetOutput.VerticalAlignment = VerticalAlignment.Center;
            _resetOutput.Foreground = Brushes.White;
            Canvas.SetTop(_resetOutput, 40);
            Canvas.SetLeft(_resetOutput, 20);

            canvas.Children.Add(_allElments);
            canvas.Children.Add(_activeBorder);
            canvas.Children.Add(_elementName);
            canvas.Children.Add(_resetOutput);

            for (int i = 0; i < _inputs.Count; i++)
            {
                Ellipse _tmpInput = new Ellipse();
                _tmpInput.Width = 10;
                _tmpInput.Height = 10;
                _tmpInput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
                _tmpInput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                _tmpInput.StrokeThickness = 1;

                Canvas.SetTop(_tmpInput, (i + 1) * 20);
                Canvas.SetLeft(_tmpInput, 5);

                _inputs[i].key = i;
                _inputs[i].value = _tmpInput;
            }

            double n = Math.Pow(2, _outputs.Count - 1);

            for (int i = 0; i < _outputs.Count; i++)
            {
                
                Ellipse _tmpOutput = new Ellipse();
                _tmpOutput.Width = 10;
                _tmpOutput.Height = 10;
                _tmpOutput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
                _tmpOutput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                _tmpOutput.StrokeThickness = 1;

                Canvas.SetTop(_tmpOutput, (i + 1) * 20);
                Canvas.SetLeft(_tmpOutput, 85);

                TextBlock _numOutput = new TextBlock();
                _numOutput.Text = (n).ToString();
                _numOutput.HorizontalAlignment = HorizontalAlignment.Center;
                _numOutput.VerticalAlignment = VerticalAlignment.Center;
                _numOutput.Foreground = Brushes.White;
                Canvas.SetTop(_numOutput, (i + 1) * 19);
                Canvas.SetLeft(_numOutput, 78 - ((n.ToString()).Length) * 5);

                canvas.Children.Add(_numOutput);

                _outputs[i].key = i;
                _outputs[i].value = _tmpOutput;

                n -= n / 2;
            }

            canvas.Children.Add(_inputs[0].value);
            canvas.Children.Add(_inputs[1].value);
            for (int i = 0; i < _outputs.Count; i++)
                canvas.Children.Add(_outputs[i].value);
            

            return canvas;
        }

        public static Canvas DrawLogicElement(ref Rectangle _activeBorder, ref List<Pair> _inputs, ref List<Pair> _outputs, string symbol)
        {
            Canvas canvas = new Canvas();

            Rectangle _allElments = new Rectangle();
            double _height = 10 + 20 * _inputs.Count;
            _allElments.Width = 80;
            _allElments.Height = _height;
            _allElments.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.SetTop(_allElments, 10);
            Canvas.SetLeft(_allElments, 10);

            _activeBorder = new Rectangle();
            _activeBorder.Width = 80;
            _activeBorder.Height = _height;
            _activeBorder.Fill = (Brush) Application.Current.FindResource("ElementBackgroundColor");
            _activeBorder.Stroke = (Brush)Application.Current.FindResource("ElementActiveBorderColor");
            _activeBorder.StrokeThickness = 0;
            Canvas.SetTop(_activeBorder, 10);
            Canvas.SetLeft(_activeBorder, 10);

            TextBlock _elementName = new TextBlock();
            _elementName.Text = symbol;
            _elementName.HorizontalAlignment = HorizontalAlignment.Center;
            _elementName.VerticalAlignment = VerticalAlignment.Center;
            _elementName.Foreground = Brushes.White;
            Canvas.SetTop(_elementName, 20);
            Canvas.SetLeft(_elementName, 40);


            for (int i = 0; i < _inputs.Count; i++)
            {
                Ellipse _tmpInput = new Ellipse();
                _tmpInput.Width = 10;
                _tmpInput.Height = 10;
                _tmpInput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
                _tmpInput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                Canvas.SetTop(_tmpInput, (i + 1) * 20);
                Canvas.SetLeft(_tmpInput, 5);

                _inputs[i].key = i;
                _inputs[i].value = _tmpInput;
            }


            Ellipse _tmpOutput = new Ellipse();
            _tmpOutput.Width = 10;
            _tmpOutput.Height = 10;
            _tmpOutput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
            _tmpOutput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
            _tmpOutput.StrokeThickness = 1;

            Canvas.SetTop(_tmpOutput, 20);
            Canvas.SetLeft(_tmpOutput, 85);

            _outputs[0].key = 1;
            _outputs[0].value = _tmpOutput;

            canvas.Children.Add(_allElments);
            canvas.Children.Add(_activeBorder);
            for (int i = 0; i < _inputs.Count; i++)
                canvas.Children.Add(_inputs[i].value);
            canvas.Children.Add(_outputs[0].value);
            canvas.Children.Add(_elementName);

            return canvas;
        }

        public static Canvas DrawTwoOrMoreInputsOutputs(ref Rectangle _activeBorder, ref List<Pair> _inputs, ref List<Pair> _outputs, string symbol, List<string> names)
        {
            Canvas canvas = new Canvas();

            Rectangle _allElments = new Rectangle();
            double _height = 10 + 20 * (_inputs.Count > _outputs.Count ? _inputs.Count : _outputs.Count);
            _allElments.Width = 80;
            _allElments.Height = _height;
            _allElments.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.SetTop(_allElments, 10);
            Canvas.SetLeft(_allElments, 10);

            _activeBorder = new Rectangle();
            _activeBorder.Width = 80;
            _activeBorder.Height = _height;
            _activeBorder.Fill = (Brush)Application.Current.FindResource("ElementBackgroundColor");
            _activeBorder.Stroke = (Brush)Application.Current.FindResource("ElementActiveBorderColor");
            _activeBorder.StrokeThickness = 0;
            Canvas.SetTop(_activeBorder, 10);
            Canvas.SetLeft(_activeBorder, 10);

            TextBlock _elementName = new TextBlock();
            _elementName.Text = symbol;
            _elementName.HorizontalAlignment = HorizontalAlignment.Center;
            _elementName.VerticalAlignment = VerticalAlignment.Center;
            _elementName.Foreground = Brushes.White;
            Canvas.SetTop(_elementName, 30);
            Canvas.SetLeft(_elementName, 40);

            canvas.Children.Add(_allElments);
            canvas.Children.Add(_activeBorder);
            canvas.Children.Add(_elementName);

            for (int i = 0; i < _inputs.Count; i++)
            {
                Ellipse _tmpInput = new Ellipse();
                _tmpInput.Width = 10;
                _tmpInput.Height = 10;
                _tmpInput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
                _tmpInput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                _tmpInput.StrokeThickness = 1;

                Canvas.SetTop(_tmpInput, (i + 1) * 20);
                Canvas.SetLeft(_tmpInput, 5);

                TextBlock _elementName1 = new TextBlock();
                _elementName1.HorizontalAlignment = HorizontalAlignment.Center;
                _elementName1.VerticalAlignment = VerticalAlignment.Center;
                _elementName1.Foreground = Brushes.White;

                _elementName1.Text = names[i];

                Canvas.SetTop(_elementName1, (i + 1) * 19);
                Canvas.SetLeft(_elementName1, 18);

                canvas.Children.Add(_elementName1);

                _inputs[i].key = i;
                _inputs[i].value = _tmpInput;
            }


            for (int i = 0; i < _outputs.Count; i++)
            {
                Ellipse _tmpOutput = new Ellipse();
                _tmpOutput.Width = 10;
                _tmpOutput.Height = 10;
                _tmpOutput.Stroke = (Brush)Application.Current.FindResource("ElementPortBorderColor");
                _tmpOutput.Fill = (Brush)Application.Current.FindResource("ElementPortBackgroundColor");
                _tmpOutput.StrokeThickness = 1;

                Canvas.SetTop(_tmpOutput, (i + 1) * 20);
                Canvas.SetLeft(_tmpOutput, 85);

                TextBlock _elementName1 = new TextBlock();
                _elementName1.HorizontalAlignment = HorizontalAlignment.Center;
                _elementName1.VerticalAlignment = VerticalAlignment.Center;
                _elementName1.Foreground = Brushes.White;

                _elementName1.Text = names[i + _inputs.Count];

                Canvas.SetTop(_elementName1, (i + 1) * 19);
                Canvas.SetLeft(_elementName1, 65);

                canvas.Children.Add(_elementName1);

                _outputs[i].key = i;
                _outputs[i].value = _tmpOutput;
            }
            
            for (int i = 0; i < _inputs.Count; i++)
                canvas.Children.Add(_inputs[i].value);
            for (int i = 0; i < _outputs.Count; i++)
                canvas.Children.Add(_outputs[i].value);

            return canvas;
        }
    }
}
