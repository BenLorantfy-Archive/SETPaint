using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SETPaint
{
    class Shape
    {
        public Pen pen;
        public int x;
        public int y;
        public int maxX;
        public int maxY;
        public string type;

        public Shape(string type, int x, int y, int maxX, int maxY, Pen pen)
        {
            this.x = x;
            this.y = y;
            this.maxX = maxX;
            this.maxY = maxY;
            this.pen = new Pen(pen.Color, pen.Width);
            this.type = type;
        }
    }

}
