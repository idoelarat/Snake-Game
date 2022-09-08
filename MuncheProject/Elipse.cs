using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MuncheProject
{
    internal class Elipse:Circle
    {
        public Elipse()
        {
            SetX(0);
            SetY(0);
        }
        public Elipse(int x, int y)
        {
            SetX(x);
            SetY(y);
            
        }

        public override void updateSize(Graphics g,Settings set, Circle part, Brush brushColor) 
        {
            g.FillEllipse(brushColor, new Rectangle
                       (
                       part.GetX() * Settings.Width,
                       part.GetY() * Settings.Height ,
                       Settings.Width +3 , Settings.Height +3
                       ));

        }
    }
}
