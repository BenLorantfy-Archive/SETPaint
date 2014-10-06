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
        private SolidBrush fill;
        private Pen stroke;
        private Pen dottedLine;
        private Pen strokeEraser;
        private SolidBrush fillEraser;

        Point startPoint;
        Point endPoint;
        Point topLeft;
        Size dimensions;

        List<Shape> shapes;
        string shapeType;

        public Canvas(Panel canvasControl)
        {       
            //
            // Set default drawing properties
            //
            this.canvasControl = canvasControl;
            this.canvas = this.canvasControl.CreateGraphics();
            
            this.startPoint = new Point(0, 0);
            this.endPoint = new Point(0, 0);
            
            this.stroke = new Pen(Color.Black, 4);
            this.fill = new SolidBrush(Color.Gray);
            
            this.strokeEraser = new Pen(Color.White, 16);
            this.fillEraser = new SolidBrush(Color.White);

            this.dottedLine = new Pen(Color.Gray,4);
            this.dottedLine.DashPattern = new float[]{ 3, 3 };
            
            this.shapes = new List<Shape>();
            this.shapeType = "none";
        }

        public void StartDraw(int x, int y)
        {
            //
            // Set start point and end point to (x,y)
            //
            startPoint.X = x;
            startPoint.Y = y;
            endPoint.X = x;
            endPoint.Y = y;
        }

        public void DrawLine(int x, int y)
        {
            //
            // Erase last line drawn and redraw what was underneath
            // Erases circles at start and end points
            // Otherwise there is a little spec of line left after erasing line
            //
            int diameter = Convert.ToInt32(stroke.Width) * 10;
            canvas.DrawLine(strokeEraser, startPoint, endPoint);
            canvas.FillEllipse(fillEraser, startPoint.X, startPoint.Y, diameter, diameter);
            canvas.FillEllipse(fillEraser, endPoint.X, endPoint.Y, diameter, diameter);

            Redraw();
            
            //
            // Update end point to (x,y)
            //
            endPoint.X = x;
            endPoint.Y = y;
            
            //
            // Draw new line
            //
            canvas.DrawLine(dottedLine, startPoint, endPoint);
            shapeType = "line";
        }

        private void UpdateEndPoint(int x, int y)
        {
            //
            // Rectangle/Ellipse have to be drawn with top left and positive width and height
            // Start and end points might not neccessarily correspond to top left and bottom right
            // This finds the top left and bottom right point
            // Width and height is calculated from these
            //
            int minX = Math.Min(startPoint.X, endPoint.X);
            int maxX = Math.Max(startPoint.X, endPoint.X);
            int minY = Math.Min(startPoint.Y, endPoint.Y);
            int maxY = Math.Max(startPoint.Y, endPoint.Y);
            topLeft.X = minX;
            topLeft.Y = minY;
            dimensions.Width = maxX - minX;
            dimensions.Height = maxY - minY;

            //
            // Updates endPoint
            //
            endPoint.X = x;
            endPoint.Y = y;
        }

        public void DrawRectangle(int x, int y)
        {
            //
            // Erases last rectangle and redraws what was underneath
            //
            canvas.DrawRectangle(strokeEraser, new Rectangle(topLeft, dimensions));
            Redraw();

            //
            // Updates end point with (x,y)
            //
            UpdateEndPoint(x, y);
            
            //
            // Draws new rectangle
            //
            canvas.DrawRectangle(dottedLine, new Rectangle(topLeft, dimensions));
            shapeType = "rectangle";
        }

        public void Redraw()
        {
            foreach (Shape shape in shapes)
            {
                if (shape.type == "line")
                {
                    canvas.DrawLine(shape.stroke, shape.startPoint, shape.endPoint);
                }
                else if(shape.type == "rectangle")
                {
                    canvas.DrawRectangle(shape.stroke, shape.GetRectangle());
                }
            }
        }

        public void Clear()
        {
            canvas.Clear(Color.White);
        }

        public void EndDraw()
        {
            if (shapeType == "line")
            {
                //
                // Adds line to list of drawn shapes
                //
                shapes.Add(new Shape(shapeType, startPoint, endPoint, stroke, fill));

                //
                // Erases dotted line and draws what was underneath it
                //
                canvas.DrawLine(strokeEraser, startPoint, endPoint);
                Redraw();

                //
                // Draws new permanent line with correct stroke width and color
                //
                canvas.DrawLine(stroke, startPoint, endPoint);
            }
            else if (shapeType == "rectangle")
            {
                //
                // Adds rectangle to list of shape
                //
                shapes.Add(new Shape(shapeType, startPoint, endPoint, stroke, fill));

                //
                // Erases dotted rectangle and redraws what was underneath it
                //
                canvas.DrawRectangle(strokeEraser, new Rectangle(topLeft, dimensions));
                Redraw();

                //
                // Draws new permanent line with correct stroke width and color
                //
                canvas.DrawRectangle(stroke, new Rectangle(topLeft, dimensions));
            }
            
            //
            // Sets shape type to none
            //
            shapeType = "none";
        }

        public void CancelDraw()
        {
            
        }

        public void Undo()
        {
            //
            // Removes last shape and redraws
            //
            if (shapes.Count > 0)
            {
                shapes.RemoveAt(shapes.Count - 1);
                Clear();
                Redraw();
            }
        }
    }
}
