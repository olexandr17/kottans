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
                "========\n" +
                "-help                            - show help page\n" +
                "-exit                            - exit the program\n" +
                "-key <key1> <val1> <key2> <val2> - show table with keys and values\n" +
                "-ping <val>                      - sound one or some beeps\n" +
                "-print <val>                     - print message\n" +
                "========";

            Console.WriteLine(help);
        }

    }
}
