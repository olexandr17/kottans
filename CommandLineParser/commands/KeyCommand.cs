using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class KeyCommand: ICommand
    {

        private string[] _arguments;

        public KeyCommand(string[] arguments)
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            if (_arguments.Length > 1) 
            {
                string table = "";

                int len = (int) Math.Ceiling(Convert.ToDouble(_arguments.Length - 1) / 2);

                for (int i = 0; i < len; i++)
                {
                    int indexKey = 1 + i * 2;
                    int indexValue = indexKey + 1;

                    string value = "<null>";
                    if (indexValue < _arguments.Length)
                        value = _arguments[indexValue];

                    if (i > 0)
                        table += "\n";
                    
                    table += (_arguments[indexKey] + " - " + value);
                }

                Console.WriteLine(table);
            }
        }

    }
}
