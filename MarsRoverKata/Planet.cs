using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class Planet
    {
        public Int32 NumberOfRows { get; private set; }
        public Int32 NumberOfColumns { get; private set; }
        private List<Coordinate> obstaclePositions = new List<Coordinate>();

        public Planet(Int32 rows, Int32 columns)
        {
            NumberOfRows = rows;
            NumberOfColumns = columns;
        }

        public void CreateObstacle(Coordinate location)
        {
            obstaclePositions.Add(location);
        }

        public List<Coordinate> GetObstacleLocations()
        {
            return obstaclePositions;
        }
    }
}
