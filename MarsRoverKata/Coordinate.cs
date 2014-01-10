using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Coordinate
    {
        public Int32 x { get; private set; }
        public Int32 y { get; private set; }

        public Coordinate()
        {
            this.x = 0;
            this.y = 0;
        }

        public Coordinate(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", this.x, this.y);
        }
    }
}
