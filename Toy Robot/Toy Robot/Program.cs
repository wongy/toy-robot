using System;
using Toy_Robot.Core;
using Toy_Robot.Core.Interfaces;

namespace Toy_Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = string.Empty;
            IBoard board = new Board(8, 8);
            Simulator simulator = new Simulator(board);
            Console.WriteLine("Start application - enter commands (type ':q' to quit)");

            while(true)
            {
                inputCommand = Console.ReadLine();

                if (inputCommand.Equals(":q"))
                {
                    break;
                }

                string commandResponse = simulator.ProcessCommand(inputCommand);
                if (!string.IsNullOrEmpty(commandResponse))
                {
                    Console.WriteLine(commandResponse);
                }
            }

            Console.WriteLine("application exited - press any key to close");
            Console.ReadLine();
        }
    }
}
