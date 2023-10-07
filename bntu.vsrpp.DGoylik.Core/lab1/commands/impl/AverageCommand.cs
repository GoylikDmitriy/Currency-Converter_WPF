using bntu.vsrpp.DGoylik.Core.lab1.commands;
using bntu.vsrpp.DGoylik.Core.lab1.xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace bntu.vsrpp.DGoylik.Core.lab1.commands.impl
{
    internal class AverageCommand : AbstractCommand
    {
        public override void AddParameters(ComboBox comboBox, IEnumerable<Dictionary<string, string>> parameters)
        {
            AddParameters(comboBox, parameters, (value) => Regex.IsMatch(value, @"^\d+(\.\d+)?$"));
        }

        public override string Execute(string parameter)
        {
            var elements = XmlContentHandler.getElements();
            double sum = 0;
            int count = 0;
            foreach (var item in elements)
            {
                sum += double.Parse(item[parameter]);
                count++;
            }

            return (sum / count).ToString();
        }
    }
}
