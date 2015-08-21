using CommandLineParser.commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                args = new string[] { "-help" };

            do
            {
                if (args == null)
                {
                    args = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }

                string[] commands = ParseArgs(args);
                ExecuteCommands(commands);

                args = null;

            } while (true);
        }

        private static string[] ParseArgs(string[] args)
        {
            ArrayList commands = new ArrayList();

            string command = null;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("/") || args[i].StartsWith("-"))
                {
                    if (command != null)
                    {
                        commands.Add(command);
                    }   

                    command = args[i];
                }
                else
                {
                    command += (" " + args[i]);
                }
            }

            if (command != null)
            {
                commands.Add(command);
            }   

            return (string[]) commands.ToArray(typeof(string));
        }

        private static void ExecuteCommands(string[] commands)
        {
            bool helpWasCalled = false;
            for (int i = 0; i < commands.Length; i++)
            {
                ICommand command = CommandBuilder.CreateCommand((string)commands[i]);

                if (command is HelpCommand)
                {
                    if (helpWasCalled)
                    {
                        break;
                    }
                    else
                    {
                        helpWasCalled = true;
                    }
                }

                command.Execute();
            }
        }

    }
}
