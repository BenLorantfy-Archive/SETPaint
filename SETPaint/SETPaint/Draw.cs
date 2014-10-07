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
    class Draw
    {
        private SolidBrush fill;
        private Pen stroke;
        private Pen dottedLine;
        private Pen strokeEraser;
        private SolidBrush fillEraser;

        private Point startPoint;
        private Point endPoint;
        private Point topLeft;
        private Size dimensions;

        private List<Shape> shapes;
        private string shapeType;

        public Draw()
        {       
            //
            // Set default drawing properties
            //
            
            this.startPoint = new Point(0, 0);
            this.endPoint = new Point(0, 0);
            
            this.stroke = new Pen(Color.Black, 4);
            this.fill = new SolidBrush(Color.DodgerBlue);
            
            this.strokeEraser = new Pen(Color.White, 20);
            this.fillEraser = new SolidBrush(Color.White);

            this.dottedLine = new Pen(Color.Gray,4);
            this.dottedLine.DashPattern = new float[]{ 3, 3 };
            
            this.shapes = new List<Shape>();
            this.shapeType = "none";

        }

        public void SetStrokeColor(Color color)
        {
            stroke.Color = color;
        }

        public void SetFillColor(Color color)
        {
            fill.Color = color;
        }

        public void SetStrokeWidth(int width)
        {
            stroke.Width = width;
        }

        public void Start(int x, int y)
        {
            //
            // Set start point and end point to (x,y)
            //
            startPoint.X = x;
            startPoint.Y = y;
            endPoint.X = x;
            endPoint.Y = y;
        }

        public void Line(Graphics canvas, int x, int y)
        {
            //
            // Erase last line drawn and redraw what was underneath
            //
            canvas.DrawLine(strokeEraser, startPoint, endPoint);
            Redraw(canvas);

            //
            // Updates end point with (x,y)
            //
            UpdateEndPoint(x, y);
            
            //
            // Draw new line
            //
            canvas.DrawLine(dottedLine, startPoint, endPoint);
            shapeType = "line";
        }

        public void Rectangle(Graphics canvas, int x, int y)
        {
            //
            // Erases last rectangle and redraws what was underneath
            //
            canvas.DrawRectangle(strokeEraser, new Rectangle(topLeft, dimensions));
            Redraw(canvas);

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

        public void Ellipse(Graphics canvas, int x, int y)
        {
            //
            // Erases last rectangle and redraws what was underneath
            //
            canvas.DrawEllipse(strokeEraser, new Rectangle(topLeft, dimensions));
            Redraw(canvas);

            //
            // Updates end point with (x,y)
            //
            UpdateEndPoint(x, y);

            //
            // Draws new rectangle
            //
            canvas.DrawEllipse(dottedLine, new Rectangle(topLeft, dimensions));

            shapeType = "ellipse";
        }

        public void End(Graphics canvas)
        {
            if (startPoint.X != endPoint.X || startPoint.Y != endPoint.Y)
            {
                if (shapeType == "line")
                {
                    //
                    // Erases dotted line and draws what was underneath it
                    //
                    canvas.DrawLine(strokeEraser, startPoint, endPoint);
                    Redraw(canvas);

                    //
                    // Adds line to list of drawn shapes
                    //
                    shapes.Add(new Shape(shapeType, startPoint, endPoint, stroke, fill));

                    //
                    // Draws new permanent line with correct stroke width and color
                    //
                    canvas.DrawLine(stroke, startPoint, endPoint);
                }
                else if (shapeType == "rectangle")
                {
                    //
                    // Erases dotted rectangle and redraws what was underneath it
                    //
                    canvas.DrawRectangle(strokeEraser, new Rectangle(topLeft, dimensions));
                    Redraw(canvas);

                    //
                    // Adds rectangle to list of shape
                    //
                    shapes.Add(new Shape(shapeType, startPoint, endPoint, stroke, fill));

                    //
                    // Draws new permanent line with correct stroke width and color
                    //
                    canvas.FillRectangle(fill, new Rectangle(topLeft, dimensions));
                    canvas.DrawRectangle(stroke, new Rectangle(topLeft, dimensions));
                }
                else if (shapeType == "ellipse")
                {
                    //
                    // Erases dotted rectangle and redraws what was underneath it
                    //
                    canvas.DrawEllipse(strokeEraser, new Rectangle(topLeft, dimensions));
                    Redraw(canvas);

                    //
                    // Adds rectangle to list of shape
                    //
                    shapes.Add(new Shape(shapeType, startPoint, endPoint, stroke, fill));

                    //
                    // Draws new permanent line with correct stroke width and color
                    //
                    canvas.FillEllipse(fill, new Rectangle(topLeft, dimensions));
                    canvas.DrawEllipse(stroke, new Rectangle(topLeft, dimensions));
                }

                //
                // Sets shape type to none
                //
                shapeType = "none";
            }
            else
            {
                Clear(canvas);
                Redraw(canvas);
            }

        }

        private void UpdateEndPoint(int x, int y)
        {
            //
            // Updates endPoint
            //
            endPoint.X = x;
            endPoint.Y = y; 
            
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
        }

        public void Redraw(Graphics canvas)
        {
            foreach (Shape shape in shapes)
            {
                if (shape.type == "line")
                {
                    canvas.DrawLine(shape.stroke, shape.startPoint, shape.endPoint);
                }
                else if(shape.type == "rectangle")
                {
                    canvas.FillRectangle(shape.fill, shape.GetRectangle());
                    canvas.DrawRectangle(shape.stroke, shape.GetRectangle());
                }
                else if (shape.type == "ellipse")
                {
                    canvas.FillEllipse(shape.fill, shape.GetRectangle());
                    canvas.DrawEllipse(shape.stroke, shape.GetRectangle());
                }
            }
        }

        public void ClearAndReset(Graphics canvas)
        {
            shapes.Clear();
            Clear(canvas);
        }

        private void Clear(Graphics canvas)
        {
            canvas.Clear(Color.White);
        }

        public void Undo(Graphics canvas)
        {
            //
            // Removes last shape and redraws
            //
            if (shapes.Count > 0)
            {
                shapes.RemoveAt(shapes.Count - 1);
                Clear(canvas);
                Redraw(canvas);
            }
        }

        public List<Shape> Shapes()
        {
            return shapes;
        }
    }
}
