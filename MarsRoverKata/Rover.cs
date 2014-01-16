using System;

namespace MarsRoverKata
{
    public class Rover
    {
        public Boolean IsObstructed { get; private set; }
        public Vector2 CurrentPosition { get; private set; }
        public Vector2 Direction { get; private set; }
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
            if (IsObstructed)
                return;

            var nextPosition = CurrentPosition + direction;
            nextPosition = map.CheckBoundaries(nextPosition);

            if (map.IsAnObstacleAtNextPosition(nextPosition))
                IsObstructed = true;
            else
                CurrentPosition = nextPosition;
        }
    }
}