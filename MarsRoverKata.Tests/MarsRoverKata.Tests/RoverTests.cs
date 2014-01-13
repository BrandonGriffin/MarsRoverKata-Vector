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
        private Planet planet;
        private Rover rover;
        private List<Char> commands;

        [SetUp]
        public void Setup()
        {
            planet = new Planet(3, 3);
            rover = new Rover(new Coordinate(1, 1), Direction.North, planet);
            commands = new List<Char>();
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
            commands.Add('r');
            commands.Add('f');

            rover.Move(commands);
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(2, 1)));
        }

        [Test]
        public void RoverCanTurnRightThenMoveBackward()
        {
            commands.Add('r');
            commands.Add('b');

            rover.Move(commands);
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(0, 1)));
        }

        [Test]
        public void RoverShouldWrapAroundTheWorld()
        {
            commands.Add('r');
            commands.Add('f');
            commands.Add('f');

            rover.Move(commands);
            Assert.That(rover.CurrentPosition, Is.EqualTo(new Coordinate(0, 1)));
        }
    }
}
