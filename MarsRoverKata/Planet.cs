using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Planet
    {
        public Int32 NumberOfRows;
        public Int32 NumberOfColumns;

        public Planet(Int32 rows, Int32 columns)
        {
            NumberOfRows = rows;
            NumberOfColumns = columns;
        }
    }
}
