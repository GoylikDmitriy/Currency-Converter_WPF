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
using System.Windows.Shapes;
using bntu.vsrpp.DGoylik.Core.lab1.commands;
using bntu.vsrpp.DGoylik.Core.lab1.xml;

namespace bntu.vsrpp.DGoylik.lab1
{
    /// <summary>
    /// Interaction logic for CommandWindow.xaml
    /// </summary>
    public partial class CommandWindow : Window
    {
        private string commandName;
        private string content;
        private Core.lab1.commands.ICommand command;

        public CommandWindow(string commandName, string content)
        {
            InitializeComponent();
            this.commandName = commandName;
            this.command = CommandProvider.getCommand(this.commandName);
            this.command.AddParameters(this.ParameterComboBox, XmlContentHandler.getElements());
            this.content = content;
        }

        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            string? parameter = this.ParameterComboBox.SelectedItem?.ToString();
            if (parameter != null)
            {
                MessageBox.Show(this.content + ": " + this.command.Execute(parameter), this.content);
            }
        }
    }
}
