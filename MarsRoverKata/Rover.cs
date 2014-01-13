using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Rover
    {
        public Coordinate CurrentPosition { get; private set; }
        public Direction Direction { get; private set; }
        public Boolean IsObstructed { get; private set; }
        private Planet map;

        public Rover(Coordinate point, Direction direction, Planet planet)
        {
            CurrentPosition = point;
            Direction = direction;
            map = planet;
        }

        public void Move(IEnumerable<Char> commands)
        {
            foreach (var command in commands)
            {
                if (CommandIsForward(command))
                    MoveForward();

                if (CommandIsBackward(command))
                    MoveBackward();

                if (CommandIsRight(command))
                    TurnRight();

                if (CommandIsLeft(command))
                    TurnLeft();
            }
        }

        private void TurnLeft()
        {
            Direction = Direction + 3;
        }

        private void TurnRight()
        {
            Direction = Direction + 1;
        }

        private void MoveBackward()
        {
            if (Direction == Direction.North)
                MoveSouth();
            else if (Direction == Direction.East)
                MoveWest();
            else if (Direction == Direction.South)
                MoveNorth();
            else
                MoveEast();
        }

        private void MoveForward()
        {
            if (Direction == Direction.North)
                MoveNorth();
            else if (Direction == Direction.East)
                MoveEast();
            else if (Direction == Direction.South)
                MoveSouth();
            else
                MoveWest();
        }

        private void MoveWest()
        {
            if (IsFarWest())
                if (IsAnObstacleAtNextPosition(new Coordinate(MaxColumn(), CurrentPosition.y)))
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(MaxColumn(), CurrentPosition.y);
            else
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x - 1, CurrentPosition.y)))
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(CurrentPosition.x - 1, CurrentPosition.y);
        }

        private Boolean IsFarWest()
        {
            return CurrentPosition.x == 0;
        }

        private void MoveSouth()
        {
            if (IsFarSouth())
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x, MaxRow())))
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(CurrentPosition.x, MaxRow());
            else
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x, CurrentPosition.y - 1)))
                    IsObstructed = true;
                else    
                    CurrentPosition = new Coordinate(CurrentPosition.x, CurrentPosition.y - 1);
        }

        private Boolean IsFarSouth()
        {
            return CurrentPosition.y == 0;
        }

        private void MoveEast()
        {
            if (IsFarEast())
                if (IsAnObstacleAtNextPosition(new Coordinate(0, CurrentPosition.y)))
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(0, CurrentPosition.y);
            else
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x + 1, CurrentPosition.y)))
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(CurrentPosition.x + 1, CurrentPosition.y);
        }

        private Boolean IsAnObstacleAtNextPosition(Coordinate coordinate)
        {
            return coordinate.Equals(map.ObstaclePosition);
        }

        private Boolean IsFarEast()
        {
            return CurrentPosition.x == MaxColumn();
        }

        private void MoveNorth()
        {
            if (IsFarNorth())
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x, 0)))
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(CurrentPosition.x, 0);
            else
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x, CurrentPosition.y + 1)))
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(CurrentPosition.x, CurrentPosition.y + 1);
        }

        private Boolean IsFarNorth()
        {
            return CurrentPosition.y == MaxRow();
        }
        
        private Int32 MaxColumn()
        {
            return map.NumberOfColumns - 1;
        }

        private Int32 MaxRow()
        {
            return map.NumberOfRows - 1;
        }
        private static Boolean CommandIsLeft(Char command)
        {
            return command == 'l';
        }

        private static Boolean CommandIsRight(Char command)
        {
            return command == 'r';
        }

        private static Boolean CommandIsBackward(Char command)
        {
            return command == 'b';
        }

        private static Boolean CommandIsForward(Char command)
        {
            return command == 'f';
        }
    }
}
