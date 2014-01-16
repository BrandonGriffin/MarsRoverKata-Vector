using System;

namespace MarsRoverKata
{
    public class Rover
    {
        public Int32 Rotation { get; private set; }
        public Boolean IsObstructed { get; private set; }
        public Vector2 CurrentPosition { get; private set; }
        private Vector2 direction;
        private Map map;

        public Rover(Vector2 point, Int32 rotation, Map map)
        {
            CurrentPosition = point;
            Rotation = rotation;
            this.map = map;
        }
        
        public void MoveForward()
        {
            UpdateDirection();
            Move(direction);
        }

        public void MoveBackward()
        {
            UpdateDirection();
            Move(direction * (-1));
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

        private void UpdateDirection()
        {
            direction = new Vector2(GetXValue(), GetYValue());
        }

        private Int32 GetYValue()
        {
            return Convert.ToInt32(Math.Sin(Rotation * Math.PI / 180));
        }

        private Int32 GetXValue()
        {
            return Convert.ToInt32(Math.Cos(Rotation * Math.PI / 180));
        }
    }
}