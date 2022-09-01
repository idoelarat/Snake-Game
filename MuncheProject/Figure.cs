using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuncheProject
{
    class Figure
    {
        private int X;
        private int Y;
        public Figure()
        {
            X = 0;
            Y = 0;
        }
        public int GetX() { return X; }
        public void SetX(int x) { X = x; }
        public int GetY() { return Y; }
        public void SetY(int y) { Y = y; }

        
    }
}
