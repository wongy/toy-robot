using System;
using Toy_Robot.Core.Interfaces;
using static Toy_Robot.Core.Models.SharedModels;

namespace Toy_Robot.Core
{
    public class Robot: IRobot
    {
        public int CurrentXPosition { get; set; }
        public int CurrentYPosition { get; set; }
        public string CurrentDirection { get; set; }

        public Robot(int xPosition, int yPosition, string direction)
        {
            CurrentXPosition = xPosition;
            CurrentYPosition = yPosition;
            CurrentDirection = direction;
        }

        public void Move(int numberOfMoves = 1)
        {
            if (CurrentDirection.Equals(Direction.North.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentYPosition += numberOfMoves;
            }
            else if (CurrentDirection.Equals(Direction.South.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentYPosition -= numberOfMoves;
            }
            else if(CurrentDirection.Equals(Direction.East.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentXPosition += numberOfMoves;
            }
            else if (CurrentDirection.Equals(Direction.West.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentXPosition -= numberOfMoves;
            }
        }

        public void RotateLeft()
        {
            if (CurrentDirection.Equals(Direction.North.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentDirection = Direction.West.ToString();
            }
            else if (CurrentDirection.Equals(Direction.South.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentDirection = Direction.East.ToString();
            }
            else if (CurrentDirection.Equals(Direction.East.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentDirection = Direction.North.ToString();
            }
            else if (CurrentDirection.Equals(Direction.West.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentDirection = Direction.South.ToString();
            }
        }

        public void RotateRight()
        {
            if (CurrentDirection.Equals(Direction.North.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentDirection = Direction.East.ToString();
            }
            else if (CurrentDirection.Equals(Direction.South.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentDirection = Direction.West.ToString();
            }
            else if (CurrentDirection.Equals(Direction.East.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentDirection = Direction.South.ToString();
            }
            else if (CurrentDirection.Equals(Direction.West.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                CurrentDirection = Direction.North.ToString();
            }
        }

        public string Report()
        {
            return $"{CurrentXPosition},{CurrentYPosition},{CurrentDirection.ToUpper()}";
        }
    }
}
