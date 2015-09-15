using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class SetUserCommand: ICommand
    {

        private static string userKey = "user";

        private string[] _arguments;

        public SetUserCommand(string[] arguments)
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            if (_arguments.Length > 1)
            {
                DataStorage.setValue(userKey, _arguments[1]);
                Console.WriteLine("User was defined");
            }
            else
            {
                Console.WriteLine("User was not defined because name is empty");
            }
        }

    }
}
