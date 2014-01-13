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

        public void Move(String commands)
        {
            if(commands == "f")
               CurrentPosition = new Coordinate(CurrentPosition.x, CurrentPosition.y + 1);

            if (commands == "b")
                CurrentPosition = new Coordinate(CurrentPosition.x, CurrentPosition.y - 1);

            if (commands == "r")
                Direction = Direction + 1;

            if (commands == "l")
                Direction = Direction + 3;
        }
    }
}
