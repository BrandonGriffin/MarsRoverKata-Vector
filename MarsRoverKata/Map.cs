using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class Map
    {
        private Int32 numberOfRows { get; set; }
        private Int32 numberOfColumns { get; set; }
        private List<Vector2> obstaclePositions = new List<Vector2>();

        public Map(Int32 rows, Int32 columns)
        {
            numberOfRows = rows;
            numberOfColumns = columns;
        }

        public void CreateObstacle(Vector2 location)
        {
            obstaclePositions.Add(location);
        }

        public Boolean IsAnObstacleAtNextPosition(Vector2 nextPosition)
        {
            return obstaclePositions.Contains(nextPosition);
        }

        public Vector2 CheckBoundaries(Vector2 nextPosition)
        {
            if (nextPosition.X > numberOfRows - 1)
                nextPosition.X = 0;
            else if (nextPosition.X < 0)
                nextPosition.X = numberOfRows - 1;

            if (nextPosition.Y > numberOfColumns - 1)
                nextPosition.Y = 0;
            else if (nextPosition.Y < 0)
                nextPosition.Y = numberOfColumns - 1;

            return nextPosition;
        }
    }
}