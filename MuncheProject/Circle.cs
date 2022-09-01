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
            EventScore++;
        }
        public virtual void BackgourdEvent()
        { 
            if (EventScore == 0)
            {
               PictureBox picBox1 = MyPictureBox();
            }
        }
        public virtual void ColorEvent() 
        {
            Brush SnakeColour = Brushes.DarkRed;
        }
    }
}
