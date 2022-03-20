namespace Toy_Robot.Core.Interfaces
{
    interface IRobot
    {
        int CurrentXPosition { get; set; }
        int CurrentYPosition { get; set; }
        string CurrentDirection { get; set; }

        void Move(int numberOfMoves = 1);
        void RotateLeft();
        void RotateRight();
        string Report();
    }
}
