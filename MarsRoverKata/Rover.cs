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

        public void Move(string p)
        {
            throw new NotImplementedException();
        }
    }
}
