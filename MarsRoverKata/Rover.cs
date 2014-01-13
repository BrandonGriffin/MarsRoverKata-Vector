using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Rover
    {
        public Coordinate CurrentPosition { get; set; }
        public Direction Direction { get; set; }

        public Rover(Coordinate space, Direction direction)
        {
            CurrentPosition = space;
            Direction = direction;
        }

        public void Move(IEnumerable<Char> commands)
        {
            foreach (var command in commands)
            {
                if (command == 'f')
                    if (Direction == Direction.North)
                        CurrentPosition = new Coordinate(CurrentPosition.x, CurrentPosition.y + 1);
                    else if (Direction == Direction.East)
                        CurrentPosition = new Coordinate(CurrentPosition.x + 1, CurrentPosition.y);
                    else if (Direction == Direction.South)
                        CurrentPosition = new Coordinate(CurrentPosition.x, CurrentPosition.y - 1);
                    else
                        CurrentPosition = new Coordinate(CurrentPosition.x - 1, CurrentPosition.y);

                if (command == 'b')
                    if (Direction == Direction.North)
                        CurrentPosition = new Coordinate(CurrentPosition.x, CurrentPosition.y - 1);
                    else if (Direction == Direction.East)
                        CurrentPosition = new Coordinate(CurrentPosition.x - 1, CurrentPosition.y);
                    else if (Direction == Direction.South)
                        CurrentPosition = new Coordinate(CurrentPosition.x, CurrentPosition.y + 1);
                    else
                        CurrentPosition = new Coordinate(CurrentPosition.x + 1, CurrentPosition.y);

                if (command == 'r')
                    Direction = Direction + 1;

                if (command == 'l')
                    Direction = Direction + 3;
            }
        }
    }
}
