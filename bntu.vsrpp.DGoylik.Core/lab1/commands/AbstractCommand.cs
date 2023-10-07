using bntu.vsrpp.DGoylik.Core.lab1.xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace bntu.vsrpp.DGoylik.Core.lab1.commands
{
    internal abstract class AbstractCommand : ICommand
    {
        public abstract void AddParameters(ComboBox comboBox, IEnumerable<Dictionary<string, string>> parameters);
        public abstract string Execute(string parameter);

        protected void AddParameters(ComboBox comboBox, IEnumerable<Dictionary<string, string>> parameters, Func<string, bool> condition)
        {
            comboBox.Items.Clear();
            foreach (var item in parameters)
            {
                foreach (var entry in item)
                {
                    if (condition.Invoke(entry.Value))
                    {
                        if (!comboBox.Items.Contains(entry.Key) && allElementsContain(entry.Key))
                        {
                            comboBox.Items.Add(entry.Key);
                        }
                    }
                }
            }
        }

        private bool allElementsContain(string value)
        {
            var elements = XmlContentHandler.getElements();
            return elements.All(item => item.Keys.Contains(value));
        }
    }
}
