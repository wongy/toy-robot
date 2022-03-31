using Toy_Robot.Core;
using Toy_Robot.Core.Interfaces;
using Xunit;

namespace Toy_Robot.Test
{
    public class RobotTest
    {
        private IRobot _robot;
        public RobotTest()
        {
            _robot = new Robot(0, 0, "North");
        }
        [Fact]
        public void MoveShouldWork()
        {
            _robot.Move();
            Assert.Equal(0, _robot.CurrentXPosition);
            Assert.Equal(1, _robot.CurrentYPosition);
            Assert.Equal("North", _robot.CurrentDirection);
        }
    }
}