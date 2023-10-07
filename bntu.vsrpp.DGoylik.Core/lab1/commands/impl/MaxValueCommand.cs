﻿using bntu.vsrpp.DGoylik.Core.lab1.commands;
using bntu.vsrpp.DGoylik.Core.lab1.xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace bntu.vsrpp.DGoylik.Core.lab1.commands.impl
{
    internal class MaxValueCommand : AbstractCommand
    {
        public override void AddParameters(ComboBox comboBox, IEnumerable<Dictionary<string, string>> parameters)
        {
            AddParameters(comboBox, parameters, (value) => Regex.IsMatch(value, @"^\d+(\.\d+)?$"));
        }

        public override string Execute(string parameter)
        {
            double max = double.MinValue;
            var elements = XmlContentHandler.getElements();
            foreach (var item in elements)
            {
                if (double.Parse(item[parameter]) > max)
                    max = double.Parse(item[parameter]);
            }

            return max.ToString();
        }
    }
}
