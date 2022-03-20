namespace Toy_Robot.Core
{
    class Board
    {
        // constants for board dimensions boundaries
        private const int MinX = 0;
        private const int MinY = 0;

        public int MaxX { get; set; }
        public int MaxY { get; set; }

        // 
        public Board(int length = 6, int width = 6)
        {
            MaxX = length - 1; // the maximum X coordinate is the length of the board minus 1
            MaxY = width - 1; // the maximum Y coordinate is the width of the board minus 1
        }

        // does a check to see if the provided placement position is within the maximum length and width of the board
        public bool IsValidPlacement(int XCoordinate, int YCoordinate)
        {
            var ValidXPosition = XCoordinate >= MinX && XCoordinate <= MaxX;
            var ValidYPosition = YCoordinate >= MinY && YCoordinate <= MaxY;
            return ValidXPosition && ValidYPosition;
        }
    }
}
