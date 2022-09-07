using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MuncheProject
{
    internal class Rectangel:Figure
    {
        public Rectangel()
        {
            SetX(0);
            SetY(0);
        }
        public Rectangel(int x, int y)
        {
            SetX(x);
            SetY(y);
        }
        public virtual void BackgourdEvent() { }
        public virtual void ColorEvent() { }


    }
}
