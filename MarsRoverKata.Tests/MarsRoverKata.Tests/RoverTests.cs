using NUnit.Framework;

namespace MarsRoverKata.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Planet planet;
        private Rover rover;
        private Controller controller;

        [SetUp]
        public void Setup()
        {
            planet = new Planet(3, 3);
            rover = new Rover(new Vector2(1, 1), 90, planet);
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
            Assert.That(rover.Rotation, Is.EqualTo(90));
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
            Assert.That(rover.Rotation, Is.EqualTo(0));
        }

        [Test]
        public void RoverCanTurnLeft()
        {
            controller.ProcessCommands("l");
            Assert.That(rover.Rotation, Is.EqualTo(180));
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
        public void RoverShouldWrapAroundTheWorld()
        {
            controller.ProcessCommands("rff");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(0, 1)));
        }

        [Test]
        public void RoverShouldSeeObstructions()
        {
            planet.CreateObstacle(new Vector2(2, 2));
            controller.ProcessCommands("frf");

            Assert.That(rover.IsObstructed, Is.EqualTo(true));
        }

        [Test]
        public void RoverShouldStopWhenItEncountersAnObstacle()
        {
            planet.CreateObstacle(new Vector2(2, 0));
            controller.ProcessCommands("ffrf");

            Assert.That(rover.CurrentPosition, Is.EqualTo(new Vector2(1, 0)));
        }

        [Test]
        public void RoverShouldStopWhenItEncountersTheFirstObstacle()
        {
            planet.CreateObstacle(new Vector2(2, 2));
            planet.CreateObstacle(new Vector2(1, 1));
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