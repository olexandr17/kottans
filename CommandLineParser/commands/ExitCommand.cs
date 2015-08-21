using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class ExitCommand: ICommand
    {

        private string[] _arguments;

        public ExitCommand(string[] arguments)
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            Environment.Exit(0);
        }

    }
}
