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
            rover = new Rover();
        }

        [Test]
        public void RoverReturnsTheGridItIsLocatedOn()
        {
            var actual = Rover.Grid(0);
            var expected = new Int32[0,0];
            
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TheGridCanBeOfASpecifiedSize()
        {
            var actual = Rover.Grid(3);
            var expected = new Int32[3, 3];

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
