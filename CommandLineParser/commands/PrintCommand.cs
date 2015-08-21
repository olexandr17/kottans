using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class PrintCommand: ICommand
    {

        private string[] _arguments;

        public PrintCommand(string[] arguments)
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            string message = "<null>";

            if (_arguments.Length > 1)
            {
                message = _arguments[1];
            }

            Console.WriteLine(message);
        }

    }
}
