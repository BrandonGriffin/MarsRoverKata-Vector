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
        private Planet mars;

        [SetUp]
        public void Setup()
        {
            rover = new Rover();
            mars = new Planet();
        }

        [Test]
        public void RoverReturnsTheGridItIsLocatedOn()
        {
            var actual = mars.Map(0);
            var expected = new Int32[0,0];
            
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TheGridCanBeOfASpecifiedSize()
        {
            var actual = mars.Map(3);
            var expected = new Int32[3,3];

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RoverReturnsItsStartingPositionOnTheGrid()
        {
            mars.Map(3);
            var actual = rover.Position();

            Assert.That(actual, Is.EqualTo("(0, 0)"));
        }

        [Test]
        public void RoverReturnsItsDirection()
        {
            var actual = rover.Direction();
            var expected = "N";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RoverTakesASeriesfCommandsToMove()
        {
            rover.Move("ff");
            var actual = rover.Position();
            var expected = "(2, 0)";

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
