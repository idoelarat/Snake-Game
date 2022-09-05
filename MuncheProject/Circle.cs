using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MuncheProject
{
    internal class Circle : Figure
    {
        static int EventScore = 0;
        public Circle()
        {
            SetX(0);
            SetY(0);
        }
        public Circle(int x,int y)
        {
            SetX(x);
            SetY(y);
            
        }
        
        public void scoreCounter() { EventScore++; }

        public override void updateSize(Graphics g, Settings set, Circle part, Brush brushColor) {
            
            g.FillEllipse(brushColor, new Rectangle
                    (
                    part.GetX() * Settings.Width,
                    part.GetY() * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
        }
    }
}
