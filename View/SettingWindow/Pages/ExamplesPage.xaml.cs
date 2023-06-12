using System;
using System.Windows;
using System.Windows.Controls;

namespace SimulatorLogicDevices.View.SettingWindow.Pages
{
    public partial class ExamplesPage : Page
    {
        public ExamplesPage()
        {
            InitializeComponent();
            LoadPdfFile();
        }

        private void LoadPdfFile()
        {
            try
            {
                string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = @"..\..\View\Resources\Examples\SchemeExample\Exampels.pdf";
                string absolutePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDirectory, relativePath));

                Uri uri = new Uri(absolutePath, UriKind.Absolute);

                Documantion.Navigate(uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
