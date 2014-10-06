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
        public Point startPoint;
        public Point endPoint;
        public Pen stroke;
        public SolidBrush fill;
        public string type;

        public Shape(string type, Point startPoint, Point endPoint, Pen stroke, SolidBrush fill)
        {
            this.startPoint = new Point(startPoint.X, startPoint.Y);
            this.endPoint = new Point(endPoint.X, endPoint.Y);
            this.stroke = new Pen(stroke.Color, stroke.Width);
            this.fill = new SolidBrush(fill.Color);
            this.type = type;
            this.stroke = stroke;
            this.fill = fill;
        }

        public Rectangle GetRectangle()
        {
            int minX = Math.Min(startPoint.X, endPoint.X);
            int maxX = Math.Max(startPoint.X, endPoint.X);
            int minY = Math.Min(startPoint.Y, endPoint.Y);
            int maxY = Math.Max(startPoint.Y, endPoint.Y);

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
    }

}
