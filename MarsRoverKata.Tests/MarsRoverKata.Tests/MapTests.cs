using NUnit.Framework;

namespace MarsRoverKata.Tests
{
    [TestFixture]
    public class MapTests
    {
        private Map map;

        [SetUp]
        public void SetUp()
        {
            map = new Map(3, 3);
        }

        [Test]
        public void WhatTestsDoINeed()
        {
            Assert.Fail();
        }

        [Test]
        public void MapShouldWrapAtTheBottom()
        {
            var actual = map.CheckBoundaries(new Vector2(3, 1));
            Assert.That(actual, Is.EqualTo(new Vector2(0, 1)));
        }

        [Test]
        public void MapShouldWrapAtTheTop()
        {
            var actual = map.CheckBoundaries(new Vector2(-1, 1));
            Assert.That(actual, Is.EqualTo(new Vector2(2, 1)));
        }

        [Test]
        public void MapShouldWrapAtTheRight()
        {
            var actual = map.CheckBoundaries(new Vector2(2, 3));
            Assert.That(actual, Is.EqualTo(new Vector2(2, 0)));
        }

        [Test]
        public void MapShouldWrapAtTheLeft()
        {
            var actual = map.CheckBoundaries(new Vector2(2, -1));
            Assert.That(actual, Is.EqualTo(new Vector2(2, 2)));
        }

        [Test]
        public void RoverShouldSeeObstructions()
        {
            map.CreateObstacle(new Vector2(2, 2));
            Assert.That(map.IsAnObstacleAtNextPosition(new Vector2(2, 2)));
        }
    }
}
