using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SETPaint
{
    class Canvas
    {
        private Graphics canvas;
        private Panel canvasControl;
        private Pen pen;
        private Pen dottedLine;
        private Pen eraser;

        Point point1;
        Point point2;

        List<Shape> shapes;
        string shapeType;

        public Canvas(Panel canvasControl)
        {       
            this.canvasControl = canvasControl;
            this.canvas = this.canvasControl.CreateGraphics();
            this.point1 = new Point(0, 0);
            this.point2 = new Point(0, 0);
            this.pen = new Pen(Color.Black, 4);
            this.eraser = new Pen(Color.White, 8);
            this.dottedLine = new Pen(Color.Gray,4);
            this.dottedLine.DashPattern = new float[]{ 3, 3 };
            this.shapes = new List<Shape>();
            this.shapeType = "none";
        }

        public void StartDraw(int x, int y)
        {
            point1.X = x;
            point1.Y = y;
            point2.X = x;
            point2.Y = y;
        }

        public void DrawLine(int x, int y)
        {
            canvas.DrawLine(eraser, point1, point2);
            Redraw();
            point2.X = x;
            point2.Y = y;
            canvas.DrawLine(dottedLine, point1, point2);
            shapeType = "line";
        }

        public void DrawRectangle(int x, int y)
        {
            int minX = Math.Min(point1.X, point2.X);
            int maxX = Math.Max(point1.X, point2.X);
            int minY = Math.Min(point1.Y, point2.Y);
            int maxY = Math.Max(point1.Y, point2.Y);

            canvas.DrawRectangle(eraser, new Rectangle(minX, minY, maxX - minX, maxY - minY));
            Redraw();

            point2.X = x;
            point2.Y = y;

            minX = Math.Min(point1.X, point2.X);
            maxX = Math.Max(point1.X, point2.X);
            minY = Math.Min(point1.Y, point2.Y);
            maxY = Math.Max(point1.Y, point2.Y);

            canvas.DrawRectangle(dottedLine, new Rectangle(minX, minY, maxX - minX, maxY - minY));
            shapeType = "rectangle";
        }

        public void Redraw()
        {
            foreach (Shape shape in shapes)
            {
                if (shape.type == "line")
                {
                    canvas.DrawLine(shape.pen, new Point(shape.x, shape.y), new Point(shape.maxX, shape.maxY));
                }
                else if(shape.type == "rectangle")
                {
                    canvas.DrawRectangle(shape.pen, new Rectangle(shape.x, shape.y, shape.maxX - shape.x, shape.maxY - shape.y));
                }
            }
        }

        public void Clear()
        {
            canvas.Clear(Color.White);
        }

        public void EndDraw()
        {
            int minX = Math.Min(point1.X, point2.X);
            int maxX = Math.Max(point1.X, point2.X);
            int minY = Math.Min(point1.Y, point2.Y);
            int maxY = Math.Max(point1.Y, point2.Y);

            

            if (shapeType == "line")
            {
                shapes.Add(new Shape(shapeType, point1.X, point1.Y, point2.X, point2.Y, pen));
                canvas.DrawLine(eraser, point1, point2);
                Redraw();
                canvas.DrawLine(pen, point1, point2);
            }
            else if (shapeType == "rectangle")
            {
                shapes.Add(new Shape(shapeType, minX, minY, maxX, maxY, pen));
                canvas.DrawRectangle(eraser, new Rectangle(minX, minY, maxX - minX, maxY - minY));
                Redraw();
                canvas.DrawRectangle(pen, new Rectangle(minX, minY, maxX - minX, maxY - minY));
            }

            shapeType = "none";
        }

        public void CancelDraw()
        {
            canvas.DrawLine(eraser, point1, point2);
            Redraw();
        }

        public void Undo()
        {
            if (shapes.Count > 0)
            {
                shapes.RemoveAt(shapes.Count - 1);
                Clear();
                Redraw();
            }
        }
    }
}
