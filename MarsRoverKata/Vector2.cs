using System;

namespace MarsRoverKata
{
    public class Vector2
    {
        public Double X { get; set; }
        public Double Y { get; set; }
        
        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(Double x, Double y)
        {
            X = x;
            Y = y;
        }

        public override Int32 GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override Boolean Equals(Object obj)
        {
            if (obj is Vector2 == false)
                return false;

            var otherCoordinate = obj as Vector2;

            if (GetHashCode() != otherCoordinate.GetHashCode())
                return false;

            if (X != otherCoordinate.X || Y != otherCoordinate.Y)
                return false;

            return true;
        }

        public override String ToString()
        {
            return String.Format("({0}, {1})", X, Y);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, Double scalar)
        {
            return new Vector2(v1.X * scalar, v1.Y * scalar);
        }
    }
}