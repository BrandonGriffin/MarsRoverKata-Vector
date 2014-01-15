using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class Rover
    {
        public Coordinate CurrentPosition { get; private set; }
        public Int32 Rotation { get; private set; }
        public Boolean IsObstructed { get; private set; }
        private Planet map;

        public Rover(Coordinate point, Int32 rotation, Planet planet)
        {
            CurrentPosition = point;
            Rotation = rotation;
            map = planet;
        }

        public void ProcessCommands(IEnumerable<Char> commands)
        {
            foreach (var command in commands)
                Move(command);
        }

        public void Move(Char command)
        {
            if (CommandIsForward(command))
                MoveForward();
            else if (CommandIsBackward(command))
                MoveBackward();
            else if (CommandIsRight(command))
                TurnRight();
            else if (CommandIsLeft(command))
                TurnLeft();
        }

        private void TurnLeft()
        {
            if (Rotation == 360)
                Rotation = 90;
            else
                Rotation += 90;
        }

        private void TurnRight()
        {
            if (Rotation == 0)
                Rotation = 270;
            else
                Rotation -= 90;
        }

        private void MoveBackward()
        {
            if (Rotation == 90)
                MoveSouth();
            else if (Rotation == 0)
                MoveWest();
            else if (Rotation == 270)
                MoveNorth();
            else
                MoveEast();
        }

        private void MoveForward()
        {
            if (Rotation == 90)
                MoveNorth();
            else if (Rotation == 0)
                MoveEast();
            else if (Rotation == 270)
                MoveSouth();
            else
                MoveWest();
        }

        private void MoveWest()
        {
            if (IsFarWest())
                if (IsAnObstacleAtNextPosition(new Coordinate(MaxColumn(), CurrentPosition.y)) || IsObstructed == true)
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(MaxColumn(), CurrentPosition.y);
            else
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x - 1, CurrentPosition.y)) || IsObstructed == true)
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
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x, MaxRow())) || IsObstructed == true)
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(CurrentPosition.x, MaxRow());
            else
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x, CurrentPosition.y - 1)) || IsObstructed == true)
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
                if (IsAnObstacleAtNextPosition(new Coordinate(0, CurrentPosition.y)) || IsObstructed == true)
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(0, CurrentPosition.y);
            else
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x + 1, CurrentPosition.y)) || IsObstructed == true)
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(CurrentPosition.x + 1, CurrentPosition.y);
        }

        private Boolean IsAnObstacleAtNextPosition(Coordinate coordinate)
        {
            var obstacles = map.GetObstacleLocations();       
            return obstacles.Contains(coordinate);
        }

        private Boolean IsFarEast()
        {
            return CurrentPosition.x == MaxColumn();
        }

        private void MoveNorth()
        {
            if (IsFarNorth())
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x, 0)) || IsObstructed == true)
                    IsObstructed = true;
                else
                    CurrentPosition = new Coordinate(CurrentPosition.x, 0);
            else
                if (IsAnObstacleAtNextPosition(new Coordinate(CurrentPosition.x, CurrentPosition.y + 1)) || IsObstructed == true)
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
