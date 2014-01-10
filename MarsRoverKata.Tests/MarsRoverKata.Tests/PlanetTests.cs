using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MarsRoverKata.Tests
{
    [TestFixture]
    public class PlanetTests
    {
        [Test]
        public void GridIsCreated()
        {
            var planet = new Planet(3, 3);

            Assert.That(planet.NumberOfRows, Is.EqualTo(3));

            Assert.That(planet.NumberOfColumns, Is.EqualTo(3));
        }
    }
}
