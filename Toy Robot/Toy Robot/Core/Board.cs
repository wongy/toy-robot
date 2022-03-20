namespace Toy_Robot.Core
{
    class Board
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public Board(int length = 6, int width = 6)
        {
            Length = length;
            Width = width;
        }

        public bool IsValidPlacement()
        {
            return true;
        }
    }
}
