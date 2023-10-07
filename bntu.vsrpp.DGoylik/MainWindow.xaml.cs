using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using bntu.vsrpp.DGoylik.lab1;
using bntu.vsrpp.DGoylik.Core.lab1.xml;
using bntu.vsrpp.DGoylik.Core.lab1.xml.exceptions;

namespace bntu.vsrpp.DGoylik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CommandWindow commandWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLoadXml_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlContentHandler.setElementNameAndLoad(this.InputElementNameTextBox.Text);
                this.XmlContentTextBox.Text = XmlContentHandler.getContent();
                this.ObjectCountTextBlock.Text = XmlContentHandler.getObjectCount().ToString();

                if (XmlContentHandler.isXmlFileSet())
                {
                    this.BtnAverage.IsEnabled = true;
                    this.BtnAverageStringLength.IsEnabled = true;
                    this.BtnMaxStringLength.IsEnabled = true;
                    this.BtnMaxValue.IsEnabled = true;
                    this.BtnMinStringLength.IsEnabled = true;
                    this.BtnMinValue.IsEnabled = true;

                    this.BtnNormilize.IsEnabled = true;
                }
            }
            catch (XmlContentException ex)
            {
                MessageBox.Show(ex.Message, "Warning.");
            }
        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (this.commandWindow != null)
            {
                commandWindow.Close();
            }

            var btn = (Button)sender;
            this.commandWindow = new CommandWindow(btn.Name, btn.Content?.ToString());
            this.commandWindow.Show();
        }

        private void BtnNormilize_Click(object sender, RoutedEventArgs e)
        {
            XmlContentHandler.normalize();
            MessageBox.Show("The normilized xml has been successfully saved.", "Success");
        }
    }
}
