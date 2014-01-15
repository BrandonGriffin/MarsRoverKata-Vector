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
            rover = new Rover(new Coordinate(1, 1), Direction.North, planet);
        }

        [Test]
        public void RoversCurrentPositionIsSetToStartingPosition()
        {
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 1)));
        }

        [Test]
        public void RoversDirectionIsSet()
        {
            Assert.That(rover.Direction, Is.EqualTo(Direction.North));
        }

        [Test]
        public void RoverCanMoveForward()
        {
            rover.Move("f");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 2)));
        }

        [Test]
        public void RoverCanMoveBackward()
        {
            rover.Move("b");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 0)));
        }

        [Test]
        public void RoverCanTurnRight()
        {
            rover.Move("r");
            Assert.That(rover.Direction, Is.EqualTo(Direction.East));
        }

        [Test]
        public void RoverCanTurnLeft()
        {
            rover.Move("l");
            Assert.That(rover.Direction, Is.EqualTo(Direction.West));
        }

        [Test]
        public void RoverCanTurnRightThenMoveForward()
        {
            rover.Move("rf");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(2, 1)));
        }

        [Test]
        public void RoverCanTurnRightThenMoveBackward()
        {
            rover.Move("rb");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(0, 1)));
        }

        [Test]
        public void RoverShouldWrapAroundTheWorld()
        {
            rover.Move("rff");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(0, 1)));
        }

        [Test]
        public void RoverShouldThrowAnExceptionWhenItEncountersAnObstacle()
        {
            planet.CreateObstacle(new Coordinate(2, 0));
            rover.Move("ffrf");

            Assert.That(rover.IsObstructed, Is.EqualTo(true));
        }

        [Test]
        public void RoverShouldStopWhenItEncountersAnObstacle()
        {
            planet.CreateObstacle(new Coordinate(2, 0));
            rover.Move("ffrf");

            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 0)));
        }

        [Test]
        public void RoverShouldStopWhenItEncountersTheFirstObstacle()
        {
            planet.CreateObstacle(new Coordinate(2, 0));
            planet.CreateObstacle(new Coordinate(1, 1));
            rover.Move("ffrflfff");

            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 0)));
        }

        [Test]
        public void RandomRoverShouldEndUpAtOneZero()
        {
            rover.Move("ffrffflbrrff");
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(1, 0)));
        }
    }
}
