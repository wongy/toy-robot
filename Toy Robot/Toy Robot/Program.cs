using System;

namespace Toy_Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = String.Empty;
            Console.WriteLine("Start application - enter commands (type ':q' to quit)");

            while(true)
            {
                inputCommand = Console.ReadLine();

                if (inputCommand.Equals(":q"))
                {
                    break;
                }
            }

            Console.WriteLine("application exited - press any key to close");
            Console.ReadLine();
        }
    }
}
