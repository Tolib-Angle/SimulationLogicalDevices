using SimulatorLogicDevices.ViewModel.ControlPages;
using System.Windows;
using System.Windows.Controls;

namespace SimulatorLogicDevices.ViewModel.AllElementViewModel
{
    internal static class ManagementInfoSpace
    {
        public static void SetInfo(int inputsNumber, int outputsNumber, ElementType type)
        {
            SetInputs(inputsNumber);
            SetOutputs(outputsNumber);

            if (type == ElementType.AND)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameAND");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextAND");
            }
            else if (type == ElementType.OR)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameOR");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextOR");
            }
            else if (type == ElementType.NOT)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameNOT");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextNOT");
            }
            else if (type == ElementType.ANDNOT)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameAND_NOT");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextANDNOT");
            }
            else if (type == ElementType.ORNOT)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameOR_NOT");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextORNOT");
            }
            else if (type == ElementType.XOR)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameXOR");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextXOR");
            }
            else if (type == ElementType.BUTTON)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameButton");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextBUTTON");
            }
            else if (type == ElementType.LED)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameLED");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextLED");
            }
            else if (type == ElementType.COUNTER)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameCounter");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextCOUNTER");
            }
            else if (type == ElementType.GENERATOR)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameGenerator");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextGENERATOR");
            }
            else if (type == ElementType.RSTRIGGER)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameRS_Trigger");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextRSTRIGGER");
            }
            else if (type == ElementType.DTRIGGER)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameD_Trigger");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextDTRIGGER");
            }
            else if (type == ElementType.DELIMITER)
            {
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = (string)Application.Current.FindResource("TextDEVNameDelimiter");
                ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string)Application.Current.FindResource("TextDELIMITER");
            }
            else
                ResetInfoPage();
        }

        public static void SetInputs(int count)
        {
            if(count <= 0 || count == 1 || count == 7 || count >= 9)
            {
                ((ColumnDefinition)MainWindowPagesViewModel.getInfoPage().FindName("OnOffInputsNumber")).Width = new GridLength(0);
            }
            else
            {
                ((ColumnDefinition)MainWindowPagesViewModel.getInfoPage().FindName("OnOffInputsNumber")).Width = new GridLength(150);
                

                string str = "IRB" + count.ToString();
                ((RadioButton)MainWindowPagesViewModel.getInfoPage().FindName(str)).IsChecked = true;
            }
        }

        public static void SetOutputs(int count)
        {
            if (count <= 0 || count == 1 || count == 7 || count >= 9)
            {
                ((ColumnDefinition)MainWindowPagesViewModel.getInfoPage().FindName("OnOffOutputsNumber")).Width = new GridLength(0);
            }
            else
            {
                ((ColumnDefinition)MainWindowPagesViewModel.getInfoPage().FindName("OnOffOutputsNumber")).Width = new GridLength(150);

                string str = "IRB" + count.ToString();
                ((RadioButton)MainWindowPagesViewModel.getInfoPage().FindName(str)).IsChecked = true;
            }
        }

        public static void ResetInfoPage()
        {
            ((ColumnDefinition)MainWindowPagesViewModel.getInfoPage().FindName("OnOffInputsNumber")).Width = new GridLength(0);
            ((ColumnDefinition)MainWindowPagesViewModel.getInfoPage().FindName("OnOffOutputsNumber")).Width = new GridLength(0);

            ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpaceHeader")).Text = "Simulation of logical device (SLD)";
            ((TextBlock)MainWindowPagesViewModel.getInfoPage().FindName("infoSpace")).Text = (string) Application.Current.FindResource("TextSLD");
        }
    }
}
