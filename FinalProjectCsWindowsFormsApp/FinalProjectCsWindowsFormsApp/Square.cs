using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCsWindowsFormsApp
{
    internal class Square:Figure
    {
        public Square()
        {
            setXValue(0);
            setYValue(0);
        }
        public Square(int x, int y)
        {
            setXValue(x);
            setYValue(y);
        }
    }
}
