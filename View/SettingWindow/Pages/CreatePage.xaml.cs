using SimulatorLogicDevices.ViewModel.DialogService;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimulatorLogicDevices.View.SettingWindow.Pages
{
    public partial class CreatePage : Page
    {
        DefaultDialogService dialogService;
        public CreatePage()
        {
            InitializeComponent();
            dialogService = new DefaultDialogService();
        }

        private void ClearFocus(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void OpenPathForCreateDevice(object sender, RoutedEventArgs e)
        {
            dialogService.OpenFileDialog();
            PathProject.Text = dialogService.FilePath;
        }
    }
}
