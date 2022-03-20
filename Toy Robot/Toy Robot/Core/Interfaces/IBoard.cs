using System;
using System.Collections.Generic;
using System.Text;

namespace Toy_Robot.Core.Interfaces
{
    interface IBoard
    {
        bool IsValidPlacement(int XCoordinate, int YCoordinate);
    }
}
