using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRoverKata.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Planet planet;
        private Rover rover;

        [SetUp]
        public void Setup()
        {
            planet = new Planet(3, 3);
            rover = new Rover(new Coordinate(1, 1), 90, planet);
        }

        [Test]
        public void RoversCurrentPositionIsSetToStartingPosition()
        {
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 1)));
        }

        [Test]
        public void RoversDirectionIsSet()
        {
            Assert.That(rover.Rotation, Is.EqualTo(90));
        }

        [Test]
        public void RoverCanMoveForward()
        {
            rover.ProcessCommands("f");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 2)));
        }

        [Test]
        public void RoverCanMoveBackward()
        {
            rover.ProcessCommands("b");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 0)));
        }

        [Test]
        public void RoverCanTurnRight()
        {
            rover.ProcessCommands("r");
            Assert.That(rover.Rotation, Is.EqualTo(0));
        }

        [Test]
        public void RoverCanTurnLeft()
        {
            rover.ProcessCommands("l");
            Assert.That(rover.Rotation, Is.EqualTo(180));
        }

        [Test]
        public void RoverCanTurnRightThenMoveForward()
        {
            rover.ProcessCommands("rf");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(2, 1)));
        }

        [Test]
        public void RoverCanTurnRightThenMoveBackward()
        {
            rover.ProcessCommands("rb");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(0, 1)));
        }

        [Test]
        public void RoverShouldWrapAroundTheWorld()
        {
            rover.ProcessCommands("rff");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(0, 1)));
        }

        [Test]
        public void RoverShouldThrowAnExceptionWhenItEncountersAnObstacle()
        {
            planet.CreateObstacle(new Coordinate(2, 0));
            rover.ProcessCommands("ffrf");

            Assert.That(rover.IsObstructed, Is.EqualTo(true));
        }

        [Test]
        public void RoverShouldStopWhenItEncountersAnObstacle()
        {
            planet.CreateObstacle(new Coordinate(2, 0));
            rover.ProcessCommands("ffrf");

            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 0)));
        }

        [Test]
        public void RoverShouldStopWhenItEncountersTheFirstObstacle()
        {
            planet.CreateObstacle(new Coordinate(2, 0));
            planet.CreateObstacle(new Coordinate(1, 1));
            rover.ProcessCommands("ffrflfff");

            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 0)));
        }

        [Test]
        public void RandomRoverShouldEndUpAtOneZero()
        {
            rover.ProcessCommands("ffrffflbrrff");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 0)));
        }
    }
}
