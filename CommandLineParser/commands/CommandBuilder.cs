using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.commands
{
    class CommandBuilder
    {

        public static ICommand CreateCommand(string argument)
        {
            string[] args = argument.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ICommand command = null;
            switch (args[0])
            {
                case "/?":
                case "/help":
                case "-help":
                    {
                        command = new HelpCommand(args);
                        break;
                    }
                case "-key":
                    {
                        command = new KeyCommand(args);
                        break;
                    }
                case "-ping":
                    {
                        command = new PingCommand(args);
                        break;
                    }
                case "-print":
                    {
                        command = new PrintCommand(args);
                        break;
                    }
                case "-exit":
                    {
                        command = new ExitCommand(args);
                        break;
                    }
                default:
                    {
                        command = new UnknownCommand(args);
                        break;
                    }
            }

            return command;
        }

    }
}