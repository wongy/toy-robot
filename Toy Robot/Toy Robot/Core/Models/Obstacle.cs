using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Core.Interfaces;

namespace ToyRobot.Core.Models
{
    public class Obstacle : IObstacle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Obstacle(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
