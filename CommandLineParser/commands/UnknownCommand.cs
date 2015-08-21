using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class UnknownCommand: ICommand
    {

        private string[] _arguments;

        public UnknownCommand(string[] arguments)
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            Console.WriteLine("Command <{0}> is not supported, use CommandParser.exe /? to see set of allowed commands", _arguments[0]);
        }

    }
}
