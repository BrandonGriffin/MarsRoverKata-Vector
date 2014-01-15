using System;

namespace MarsRoverKata
{
    public class Coordinate
    {
        public Int32 x { get; private set; }
        public Int32 y { get; private set; }

        public Coordinate()
        {
            x = 0;
            y = 0;
        }

        public Coordinate(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }

        public override Int32 GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

        public override Boolean Equals(Object obj)
        {
            if (obj is Coordinate == false)
                return false;

            var otherCoordinate = obj as Coordinate;

            if (GetHashCode() != otherCoordinate.GetHashCode())
                return false;

            if (x != otherCoordinate.x || y != otherCoordinate.y)
                return false;

            return true;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", x, y);
        }
    }
}
