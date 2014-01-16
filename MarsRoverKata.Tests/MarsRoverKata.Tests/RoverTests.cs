using NUnit.Framework;

namespace MarsRoverKata.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Map map;
        private Rover rover;
        private Controller controller;

        [SetUp]
        public void Setup()
        {
            map = new Map(3, 3);
            rover = new Rover(new Vector2(1, 1), new Vector2(0, 1), map);
            controller = new Controller(rover);
        }

        [Test]
        public void RoversCurrentPositionIsSetToStartingPosition()
        {
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(1, 1)));
        }

        [Test]
        public void RoversDirectionIsSet()
        {
            Assert.That(rover.Direction, Is.EqualTo(new Vector2(0, 1)));
        }

        [Test]
        public void RoverCanMoveForward()
        {
            controller.ProcessCommands("f");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(1, 2)));
        }

        [Test]
        public void RoverCanMoveBackward()
        {
            controller.ProcessCommands("b");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(1, 0)));
        }

        [Test]
        public void RoverCanTurnRight()
        {
            controller.ProcessCommands("r");
            Assert.That(rover.Direction, Is.EqualTo(new Vector2(1, 0)));
        }

        [Test]
        public void RoverCanTurnLeft()
        {
            controller.ProcessCommands("l");
            Assert.That(rover.Direction, Is.EqualTo(new Vector2(-1, 0)));
        }

        [Test]
        public void RoverCanTurnRightThenMoveForward()
        {
            controller.ProcessCommands("rf");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(2, 1)));
        }

        [Test]
        public void RoverCanTurnRightThenMoveBackward()
        {
            controller.ProcessCommands("rb");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(0, 1)));
        }

        [Test]
        public void RoverShouldStopWhenItEncountersAnObstacle()
        {
            map.CreateObstacle(new Vector2(2, 0));
            controller.ProcessCommands("ffrf");

            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(1, 0)));
        }

        [Test]
        public void RoverShouldStopWhenItEncountersTheFirstObstacle()
        {
            map.CreateObstacle(new Vector2(2, 2));
            map.CreateObstacle(new Vector2(1, 1));
            controller.ProcessCommands("frflfff");

            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(1, 2)));
        }

        [Test]
        public void RandomRoverShouldEndUpAtOneZero()
        {
            controller.ProcessCommands("ffrffflbrrff");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(1, 0)));
        }
    }
}