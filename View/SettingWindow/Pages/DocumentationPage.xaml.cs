using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SimulatorLogicDevices.View.SettingWindow.Pages
{
    public partial class DocumentationPage : Page
    {
        public DocumentationPage()
        {
            InitializeComponent();
            LoadPdfFile();
        }

        private void LoadPdfFile()
        {
            try
            {
                string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = @"..\..\View\Resources\Examples\ForDocumantation\Documentation.pdf";
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
