namespace Toy_Robot.Core.Interfaces
{
    interface IRobot
    {
        void Move(int numberOfMoves);
        void RotateLeft();
        void RotateRight();
        string Report();
    }
}
