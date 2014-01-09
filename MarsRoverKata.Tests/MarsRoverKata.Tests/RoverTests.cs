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
        [Test]
        public void RoverReturnsTheGridItIsLocatedOn()
        {
            var rover = new Rover();

            var actual = Rover.Grid();
            var expected = new Int32[0,0];
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
