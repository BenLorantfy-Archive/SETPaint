/* ================================================ *
 *											 		*
 * 		FILE 			: Draw.cs 				    *
 * 		PROJECT 		: WMP A3					*
 * 		PROGRAMMER 		: Ben Lorantfy              *
 * 		                  and Chaung Liu 		    *
 * 		FIRST VERSION 	: 2014-10-07 				*
 * 		DESCRIPTION		: Contains drawing methods  *
 *													*
 * ================================================ */

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
    /* =========================================================================================================== *
    *											 																   *
    * 		NAME 			: Draw																			       *
    * 		PURPOSE 		: The draw class contains methods for drawing shapes and keeping track of shapes       *
    * 		                  This includes functionality such as drawing lines, rectangles, and ellipses as well  *
    * 		                  as erasing, undoing, and redrawing                                                   *
    *																											   *
    * ============================================================================================================ */
    class Draw
    {
        private SolidBrush fill;        // Used to specify fill color when drawing shapes
        private Pen stroke;             // Used to specify stroke color and width when drawing shapes
        private Pen dottedLine;         // Used to draw the dotted line effect when "rubber-banding"
        private Pen previewEraser;      // Used to erase dotted line (white stroke and thicker stroke width)

        private Point startPoint;       // Start of shape (not necessarily top left point)
        private Point endPoint;         // End of shape (not neccessarily bottom right point)
        private Point topLeft;          // Top left point of shape
        private Size dimensions;        // Width and height of shape

        private List<Shape> shapes;     // Used to store shape information
                                        // This has to be kept so that shapes can be redrawn when something ontop is erased
        private string shapeType;       // Stores the type (line/rectangle/ellipse) of the shape currently being drawn

        public Draw()
        {       
            //
            // Set default drawing properties
            //
            
            this.startPoint = new Point(0, 0);
            this.endPoint = new Point(0, 0);
            
            this.stroke = new Pen(Color.Black, 4);
            this.fill = new SolidBrush(Color.DodgerBlue);

            this.previewEraser = new Pen(Color.White, 20);

            this.dottedLine = new Pen(Color.Gray,4);
            this.dottedLine.DashPattern = new float[]{ 3, 3 };
            
            this.shapes = new List<Shape>();
            this.shapeType = "none";

        }

        /* 
         *	FUNCTION 	: SetStrokeColor
         *	DESCRIPTION : Set's the stroke color to be used for future shapes
         *	PARAMETERS 	: Color color   : the color to use
         *  RETURNS		: void
         */
        public void SetStrokeColor(Color color)
        {
            stroke.Color = color;
        }

        /* 
         *	FUNCTION 	: SetFillColor
         *	DESCRIPTION : Set's the fill color to be used for future shapes
         *	PARAMETERS 	: Color color   : the color to use
         *  RETURNS		: void
         */
        public void SetFillColor(Color color)
        {
            fill.Color = color;
        }

        /* 
         *	FUNCTION 	: SetStrokeWidth
         *	DESCRIPTION : Set's the stroke width to be used for future shapes
         *	PARAMETERS 	: int width   : the width to use
         *  RETURNS		: void
         */
        public void SetStrokeWidth(int width)
        {
            stroke.Width = width;
        }

        /* 
         *	FUNCTION 	: Start
         *	DESCRIPTION : Update's the start and end point to a given point
         *	PARAMETERS 	: int x : x coordinate of start of shape
         *	            : int y : y coordinate of start of shape
         *  RETURNS		: void
         */
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

        /* 
         *	FUNCTION 	: Line
         *	DESCRIPTION : Draws a temporary dotted line from the start point to the given point
         *	PARAMETERS 	: Graphics canvas   : the graphics object to draw on
         *	            : int x             : the x coordinate of the end of the line
         *	            : int y             : the y coordinate of the end of the line
         *  RETURNS		: void
         */
        public void Line(Graphics canvas, int x, int y)
        {
            //
            // Erase last line drawn and redraw what was underneath
            //
            canvas.DrawLine(previewEraser, startPoint, endPoint);
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

        /* 
         *	FUNCTION 	: Rectangle
         *	DESCRIPTION : Draws a temporary dotted rectangle from the start point to the given point
         *	PARAMETERS 	: Graphics canvas   : the graphics object to draw on
         *	            : int x             : the x coordinate of the end rectangle point
         *	            : int y             : the y coordinate of the end rectangle point
         *  RETURNS		: void
         */
        public void Rectangle(Graphics canvas, int x, int y)
        {
            //
            // Erases last rectangle and redraws what was underneath
            //
            canvas.DrawRectangle(previewEraser, new Rectangle(topLeft, dimensions));
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

        /* 
         *	FUNCTION 	: Ellipse
         *	DESCRIPTION : Draws a temporary dotted ellipse from the start point to the given point
         *	PARAMETERS 	: Graphics canvas   : the graphics object to draw on
         *	            : int x             : the x coordinate of the end ellipse point
         *	            : int y             : the y coordinate of the end ellipse point
         *  RETURNS		: void
         */
        public void Ellipse(Graphics canvas, int x, int y)
        {
            //
            // Erases last rectangle and redraws what was underneath
            //
            canvas.DrawEllipse(previewEraser, new Rectangle(topLeft, dimensions));
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

        /* 
         *	FUNCTION 	: End
         *	DESCRIPTION : Makes the currently-being-drawn temporary shape permanent and 
         *	              draws it with the correct fill,stroke,and stroke width
         *	PARAMETERS 	: Graphics canvas   : the graphics object to draw on
         *  RETURNS		: void
         */
        public void End(Graphics canvas)
        {
            if (startPoint.X != endPoint.X || startPoint.Y != endPoint.Y)
            {
                if (shapeType == "line")
                {
                    //
                    // Erases dotted line and draws what was underneath it
                    //
                    canvas.DrawLine(previewEraser, startPoint, endPoint);
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
                    canvas.DrawRectangle(previewEraser, new Rectangle(topLeft, dimensions));
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
                    canvas.DrawEllipse(previewEraser, new Rectangle(topLeft, dimensions));
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

        /* 
         *	FUNCTION 	: UpdateEndPoint
         *	DESCRIPTION : Sets the end point and related variables
         *	PARAMETERS 	: int x : the x coordinate of the new end point
         *	            : int y : the y coordinate of the new end point
         *  RETURNS		: void
         */
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

        /* 
         *	FUNCTION 	: Redraw
         *	DESCRIPTION : Redraws all the shapes in the shape list
         *	PARAMETERS 	: Graphics canvas   : the graphics object to draw on
         *  RETURNS		: void
         */
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

        /* 
         *	FUNCTION 	: ClearAndReset
         *	DESCRIPTION : Clears the screen and empties the shape list
         *	PARAMETERS 	: Graphics canvas   : the graphics object to draw on
         *  RETURNS		: void
         */
        public void ClearAndReset(Graphics canvas)
        {
            shapes.Clear();
            Clear(canvas);
        }

        /* 
         *	FUNCTION 	: Clear
         *	DESCRIPTION : Clears the canvas
         *	PARAMETERS 	: Graphics canvas   : the graphics object to draw on
         *  RETURNS		: void
         */
        private void Clear(Graphics canvas)
        {
            canvas.Clear(Color.White);
        }

        /* 
         *	FUNCTION 	: Undo
         *	DESCRIPTION : Removes the last shape that was added to the shape list, clears, and redraws
         *	PARAMETERS 	: Graphics canvas   : the graphics object to draw on
         *  RETURNS		: void
         */
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

        /* 
         *	FUNCTION 	: Shapes
         *	DESCRIPTION : Returns the list of shapes
         *	PARAMETERS 	: none
         *  RETURNS		: List<Shape>
         */
        public List<Shape> Shapes()
        {
            return shapes;
        }
    }
}
