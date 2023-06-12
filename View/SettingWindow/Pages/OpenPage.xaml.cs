using SimulatorLogicDevices.ViewModel.AllElementViewModel.BaseElement;
using SimulatorLogicDevices.ViewModel.DialogService;
using System.Windows;
using System.Windows.Controls;

namespace SimulatorLogicDevices.View.SettingWindow.Pages
{
    public partial class OpenPage : Page
    {
        DefaultDialogService _dialogService;
        public static string path = "";
        public OpenPage()
        {
            InitializeComponent();
            _dialogService = new DefaultDialogService();
        }

        private void OpenPathForFile(object sender, RoutedEventArgs e)
        {
            _dialogService.OpenFileDialog();
            PathOpenFile.Text = _dialogService.FilePath;
            path = _dialogService.FilePath;
        }
    }
}
