using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class PingCommand: ICommand
    {

        private string[] _arguments;

        public PingCommand(string[] arguments)
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            Console.WriteLine("Pinging...");

            int count = 1;
            if (_arguments.Length > 1)
            {
                count = Convert.ToInt16(_arguments[1]);
            }

            for (int i = 0; i < count; i++)
            {
                Console.Beep();
            }   
        }

    }
}
