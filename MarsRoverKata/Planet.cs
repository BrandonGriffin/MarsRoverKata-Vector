using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class Planet
    {
        public Int32 NumberOfRows { get; private set; }
        public Int32 NumberOfColumns { get; private set; }
        private List<Vector2> obstaclePositions = new List<Vector2>();

        public Planet(Int32 rows, Int32 columns)
        {
            NumberOfRows = rows;
            NumberOfColumns = columns;
        }

        public void CreateObstacle(Vector2 location)
        {
            obstaclePositions.Add(location);
        }

        public List<Vector2> GetObstacleLocations()
        {
            return obstaclePositions;
        }
    }
}