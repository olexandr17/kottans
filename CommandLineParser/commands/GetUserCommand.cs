using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class GetUserCommand: ICommand
    {

        private static string userKey = "user";

        private string[] _arguments;

        public GetUserCommand(string[] arguments)
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            if (DataStorage.hasValue(userKey))
            {
                Console.WriteLine("User is {0}", DataStorage.getValue(userKey));
            }
            else
            {
                Console.WriteLine("User is not defined");
            }
        }

    }
}
