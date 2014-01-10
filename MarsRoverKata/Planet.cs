using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Planet
    {
        public Int32[,] Map(Int32 rowsAndColums)
        {
            return new Int32[rowsAndColums, rowsAndColums];
        }
    }
}
