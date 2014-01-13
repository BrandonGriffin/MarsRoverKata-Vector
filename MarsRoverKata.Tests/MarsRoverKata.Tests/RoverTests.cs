using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MarsRoverKata.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Rover rover;

        [SetUp]
        public void Setup()
        {
            rover = new Rover(new Coordinate(1, 1), Direction.North);
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
    }
}
