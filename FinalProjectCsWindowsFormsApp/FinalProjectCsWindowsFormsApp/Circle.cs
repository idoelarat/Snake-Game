using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCsWindowsFormsApp
{
    internal class Circle : Figure
    {

        public Circle()
        {
           setXValue(0);
           setYValue(0);
        }
        public Circle(int x, int y)
        {
            setXValue(x);
            setYValue(y);
        }
    }
}
