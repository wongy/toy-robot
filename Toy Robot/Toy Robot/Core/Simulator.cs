using Toy_Robot.Core.Interfaces;

namespace Toy_Robot.Core
{
    class Simulator
    {
        // Messages for invalid cases
        public const string InvalidCommandMessage = "Command is invalid and is ignored.";
        public const string NotPlacedMessage = "Command is invalid as robot is not placed yet.";
        public const string OutOfBoundsMessage = "Move command is ignored as robot will be going out of bounds.";

        private enum Commands
        {
            Place,
            Left,
            Right,
            Move,
            Report
        }

        public Board _board;
        public IRobot _robot;

        private bool isRobotPlaced = false;

        public Simulator(Board board)
        {
            _board = board;
        }

        // Used to read user input and decide which command to run
        public string ProcessCommand(string command)
        {
            return "";
        }

        public string Place(string command)
        {
            return "";
        }

        public string Move()
        {
            return "";
        }

        private bool IsValidPlaceCommand()
        {
            return true;
        }
    }
}
