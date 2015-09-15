using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class HelpCommand: ICommand
    {

        private string[] _arguments;

        public HelpCommand(string[] arguments)
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            string help =
@"========
-help                            - show help page
-exit                            - exit the program
-key <key1> <val1> <key2> <val2> - show table with keys and values
-ping <val>                      - sound one or some beeps
-print <val>                     - print message
-setuser <val>                   - set user name
-getuser                         - get user name
========";

            Console.WriteLine(help);
        }

    }
}
