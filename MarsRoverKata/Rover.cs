using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Rover
    {

        public String Position()
        {
            var position = new Coordinate(0, 0);

            return position.ToString();
        }

        public String Direction()
        {
            return "N";
        }
    }
}
