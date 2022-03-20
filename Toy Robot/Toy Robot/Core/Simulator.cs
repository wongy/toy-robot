using System;
using System.Collections.Generic;
using System.Linq;
using Toy_Robot.Core.Interfaces;

using static Toy_Robot.Core.Models.SharedModels;

namespace Toy_Robot.Core
{
    class Simulator
    {
        // Messages for invalid cases
        public const string InvalidCommandMessage = "Command is invalid and is ignored.";
        public const string NotPlacedMessage = "Command is invalid as robot is not placed yet.";
        public const string OutOfBoundsMessage = "Move/Place command is ignored as robot will be going out of bounds.";

        // the number of values we expect in place command
        public const int FirstTimePlacementArguments = 4;
        public const int ExistingRobotPlacementArguments = 3;

        private enum Commands
        {
            Place,
            Left,
            Right,
            Move,
            Report
        }

        public IBoard _board;
        public IRobot _robot;

        private bool IsRobotPlaced = false;

        public Simulator(IBoard board)
        {
            _board = board;
        }

        // Used to read user input and decide which command to run
        public string ProcessCommand(string command)
        {
            if (command.Contains(Commands.Place.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                // Check that place command is valid and place robot
                return Place(command);
            }
            else if (!IsRobotPlaced)
            {
                return NotPlacedMessage;
            }
            else if (command.Equals(Commands.Move.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return Move();
            }
            else if (command.Equals(Commands.Left.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                _robot.RotateLeft();
                return string.Empty;
            }
            else if (command.Equals(Commands.Right.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                _robot.RotateRight();
                return string.Empty;
            }
            else if (command.Equals(Commands.Report.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return _robot.Report();
            }
            else
            {
                // if no known commands are detected
                return InvalidCommandMessage;
            }
        }

        public string Place(string command)
        {
            var splitPlaceCommand = SplitPlaceCommand(command);
            //Console.WriteLine(string.Join(",", splitPlaceCommand));

            if (splitPlaceCommand.Length == FirstTimePlacementArguments)
            {
                // validate if the values are good to genereate a robot
                var tempRobot = CreateRobotValues(splitPlaceCommand);
                if (tempRobot == null)
                {
                    Console.WriteLine(tempRobot);
                    return InvalidCommandMessage;
                }

                // if there is a valid robot, check that the position is valid on the board
                if (!_board.IsValidPlacement(tempRobot.CurrentXPosition, tempRobot.CurrentYPosition))
                {
                    return OutOfBoundsMessage;
                }

                _robot = tempRobot;
            }
            else if (splitPlaceCommand.Length == ExistingRobotPlacementArguments)
            {
                var tempRobot = CreateRobotValues(splitPlaceCommand);
                if (_robot == null || tempRobot == null)
                {
                    return InvalidCommandMessage;
                }

                // if there is a valid robot, check that the position is valid on the board
                if (!_board.IsValidPlacement(tempRobot.CurrentXPosition, tempRobot.CurrentYPosition))
                {
                    return OutOfBoundsMessage;
                }

                _robot.CurrentXPosition = tempRobot.CurrentXPosition;
                _robot.CurrentYPosition = tempRobot.CurrentYPosition;
            }
            IsRobotPlaced = true;
            return string.Empty;
        }

        private IRobot CreateRobotValues(string[] splitPlaceCommand)
        {
            if (splitPlaceCommand[0].Equals(Commands.Place.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                // try parse values of place command into corresponding variables
                bool validX = int.TryParse(splitPlaceCommand[1], out int xPosition);
                bool validY = int.TryParse(splitPlaceCommand[2], out int yPosition);
                
                if (validX && validY)
                {
                    if (splitPlaceCommand.Length == FirstTimePlacementArguments)
                    {
                        var direction = splitPlaceCommand[3];
                        List<string> directionList = new List<string>(Enum.GetNames(typeof(Direction)));
                        bool validDirection = directionList.Contains(direction, StringComparer.OrdinalIgnoreCase);
                        return validDirection ? new Robot(xPosition, yPosition, direction) : null;
                    }
                    else if (splitPlaceCommand.Length == ExistingRobotPlacementArguments)
                    {
                        return new Robot(xPosition, yPosition, null);
                    }
                }
            }

            return null;
        }

        // split the place command into separate fields
        private string[] SplitPlaceCommand(string command)
        {
            char[] delimiterChars = new char[] { ',', ' ' };
            var splitCommand = command.Split(delimiterChars)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .ToArray();

            return splitCommand;
        }

        public string Move()
        {
            int oldXPosition = _robot.CurrentXPosition;
            int oldYPosition = _robot.CurrentXPosition;

            _robot.Move();
            if (!_board.IsValidPlacement(_robot.CurrentXPosition, _robot.CurrentYPosition))
            {
                // not a valid position, revert to previous position
                RevertRobotPosition(oldXPosition, oldYPosition);
                return OutOfBoundsMessage;
            }
            return string.Empty;
        }

        private void RevertRobotPosition(int xPosition, int yPosition)
        {
            _robot.CurrentXPosition = xPosition;
            _robot.CurrentYPosition = yPosition;
        }
    }
}
