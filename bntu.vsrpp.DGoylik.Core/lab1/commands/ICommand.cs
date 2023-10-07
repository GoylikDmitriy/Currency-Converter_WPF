using bntu.vsrpp.DGoylik.Core.lab1.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bntu.vsrpp.DGoylik.Core.lab1.commands
{
    public interface ICommand
    {
        string Execute(string parameter);
        void AddParameters(System.Windows.Controls.ComboBox comboBox, IEnumerable<Dictionary<string, string>> parameters);
    }
}
