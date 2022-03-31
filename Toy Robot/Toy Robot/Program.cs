using System;
using System.Collections.Generic;
using Toy_Robot.Core;
using Toy_Robot.Core.Interfaces;
using ToyRobot.Core.Interfaces;
using ToyRobot.Core.Models;

namespace Toy_Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = string.Empty;
            IBoard board = new Board(8, 8);
            List<Obstacle> obstacles = new List<Obstacle>();
            Simulator simulator = new Simulator(board, obstacles);
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
