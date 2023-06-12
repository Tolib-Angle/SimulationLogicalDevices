using SimulatorLogicDevices.ViewModel.AllElementViewModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace SimulatorLogicDevices.View.MainWindow.Pages
{
    public partial class MainPage : Page
    {
        private static Canvas workspace;
        public MainPage()
        {
            InitializeComponent();

            workspace = new Canvas();
            workspace.Background = (Brush) FindResource("BackgroundColor");

            MainPageGrid.Children.Add(workspace);
            workspace.AddHandler(ButtonBase.MouseMoveEvent, new MouseEventHandler(DrawLine.DragMoveMouse));
            workspace.AddHandler(ButtonBase.MouseRightButtonDownEvent, new MouseButtonEventHandler(DrawLine.DropDrawLine));
        }

        public static Canvas getCanvas()
        {
            return workspace;
        }
    }
}
