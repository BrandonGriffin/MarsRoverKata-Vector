using System;

namespace MarsRoverKata
{
    public class Rover
    {
        public Int32 Rotation { get; private set; }
        public Boolean IsObstructed { get; private set; }
        public Vector2 CurrentPosition { get; private set; }
        private Vector2 direction;
        private Vector2 nextPosition;
        private Planet map;

        public Rover(Vector2 point, Int32 rotation, Planet planet)
        {
            CurrentPosition = point;
            Rotation = rotation;
            map = planet;
        }
        
        public void MoveForward()
        {
            UpdateDirection();
            nextPosition = CurrentPosition + direction;
            CheckBoundaries();

            if (IsAnObstacleAtNextPosition())
                IsObstructed = true;
            else           
                CurrentPosition = nextPosition;
        }

        public void MoveBackward()
        {
            UpdateDirection();
            nextPosition = CurrentPosition - direction;
            CheckBoundaries();

            if (IsAnObstacleAtNextPosition())
                IsObstructed = true;
            else
                CurrentPosition = nextPosition;
        }

        public void TurnLeft()
        {
            if (Rotation == 360)
                Rotation = 90;
            else
                Rotation += 90;
        }

        public void TurnRight()
        {
            if (Rotation == 0)
                Rotation = 270;
            else
                Rotation -= 90;
        }

        private void UpdateDirection()
        {
            direction = new Vector2(GetXValue(), GetYValue());
        }

        private int GetYValue()
        {
            return Convert.ToInt32(Math.Sin(Rotation * Math.PI / 180));
        }

        private int GetXValue()
        {
            return Convert.ToInt32(Math.Cos(Rotation * Math.PI / 180));
        }

        private Boolean IsAnObstacleAtNextPosition()
        {
            var obstacles = map.GetObstacleLocations();
            return obstacles.Contains(nextPosition) || IsObstructed == true;
        }

        private void CheckBoundaries()
        {
            if (nextPosition.X > map.NumberOfRows - 1)
                nextPosition.X = 0;
            else if (nextPosition.X < 0)
                nextPosition.X = map.NumberOfRows - 1;

            if (nextPosition.Y > map.NumberOfColumns - 1)
                nextPosition.Y = 0;
            else if (nextPosition.Y < 0)
                nextPosition.Y = map.NumberOfColumns - 1;
        }
    }
}