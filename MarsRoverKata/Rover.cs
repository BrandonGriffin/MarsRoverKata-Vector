using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Rover
    {
        enum Directions { N, E, S, W };

        public String Position()
        {
            var position = new Coordinate(0, 0);
            return position.ToString();
        }

        public String Direction()
        {
            var direction = Directions.N;
            return direction.ToString();
        }

        public void Move(string p)
        {
            throw new NotImplementedException();
        }
    }
}
