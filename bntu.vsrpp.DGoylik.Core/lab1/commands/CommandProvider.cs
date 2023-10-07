using bntu.vsrpp.DGoylik.Core.lab1.commands.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace bntu.vsrpp.DGoylik.Core.lab1.commands
{
    public static class CommandProvider
    {
        private static Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        static CommandProvider()
        {
            commands.Add("MaxValue", new MaxValueCommand());
            commands.Add("MinValue", new MinValueCommand());
            commands.Add("Average", new AverageCommand());
            commands.Add("AverageStringLength", new AverageStringLengthCommand());
            commands.Add("MaxStringLength", new MaxStringLengthCommand());
            commands.Add("MinStringLength", new MinStringLengthCommand());
        }

        public static ICommand getCommand(string commandName)
        {
            return commands[getCommandName(commandName)];
        }

        private static string getCommandName(string commandName)
        {
            return commandName.Remove(0, 3);
        }
    }
}
