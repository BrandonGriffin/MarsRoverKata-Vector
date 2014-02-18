using System;

namespace MarsRoverKata
{
    public class Rover
    {
        public Vector2 CurrentPosition { get; private set; }
        public Vector2 Direction { get; private set; }

        private Boolean isObstructed;
        private Map map;

        public Rover(Vector2 point, Vector2 direction, Map map)
        {
            CurrentPosition = point;
            Direction = direction;
            this.map = map;
        }
        
        public void MoveForward()
        {
            Move(Direction);
        }

        public void MoveBackward()
        {
            Move(Direction * (-1));
        }

        public void TurnLeft()
        {
            Direction = new Vector2(-Direction.Y, Direction.X);
        }

        public void TurnRight()
        {
            Direction = new Vector2(Direction.Y, -Direction.X);
        }
        
        private void Move(Vector2 direction)
        {
            if (isObstructed)
                return;

            var nextPosition = map.CheckBoundaries(CurrentPosition + direction);

            if (map.IsAnObstacleAtNextPosition(nextPosition))
                isObstructed = true;
            else
                CurrentPosition = nextPosition;
        }
    }
}