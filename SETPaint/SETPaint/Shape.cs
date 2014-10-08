/* ================================================ *
 *											 		*
 * 		FILE 			: Shape.cs 				    *
 * 		PROJECT 		: WMP A3					*
 * 		PROGRAMMER 		: Ben Lorantfy              *
 * 		                  and Chaung Liu 		    *
 * 		FIRST VERSION 	: 2014-10-07 				*
 * 		DESCRIPTION		: Shape class               * 
 *													*
 * ================================================ */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SETPaint
{

    /* =========================================================================================================== *
    *											 																   *
    * 		NAME 			: Shape																			       *
    * 		PURPOSE 		: The shape class is used to instantiate shape objects that contain information        *
    * 		                  about the shape such as startPoint, endPoint, fill, stroke, strokeWidth, and type    * 
    *																											   *
    * ============================================================================================================ */
    class Shape
    {
        public Point startPoint;    // Start of shape (not neccesarily top left))
        public Point endPoint;      // End of shape (not neccesarily bottom right)
        public Pen stroke;          // Stroke color and width
        public SolidBrush fill;     // Fill color
        public string type;         // Type of shape (line,rectangle,ellipse)

        public Shape(string type, Point startPoint, Point endPoint, Pen stroke, SolidBrush fill)
        {
            //
            // Sets the shape's properties
            // Since objects are references in C#, this creates duplicates of objects so 
            // that changing the original objects elsewhere doesn't effect them here
            //
            this.startPoint = new Point(startPoint.X, startPoint.Y);
            this.endPoint = new Point(endPoint.X, endPoint.Y);
            this.stroke = new Pen(stroke.Color, stroke.Width);
            this.fill = new SolidBrush(fill.Color);
            this.type = type;
        }

        /* 
         *	FUNCTION 	: GetRectangle
         *	DESCRIPTION : Gets a Rectangle object that represents the size of the shape
         *	PARAMETERS 	: Color color   : the color to use
         *  RETURNS		: Rectangle
         */
        public Rectangle GetRectangle()
        {
            //
            // Since it is not a valid rectangle to have a negative width/height,
            // the top left and bottom right points are found and the width/height
            // are calucalted from those
            // 
            int minX = Math.Min(startPoint.X, endPoint.X);
            int maxX = Math.Max(startPoint.X, endPoint.X);
            int minY = Math.Min(startPoint.Y, endPoint.Y);
            int maxY = Math.Max(startPoint.Y, endPoint.Y);

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }

        /* 
         *	FUNCTION 	: ToString
         *	DESCRIPTION : Returns a single line string representation of the shape and its properties
         *	PARAMETERS 	: none
         *  RETURNS		: string
         */
        public override string ToString()
        {
            return
                type + "|" +
                startPoint.X + "|" +
                startPoint.Y + "|" +
                endPoint.X + "|" +
                endPoint.Y + "|" +
                stroke.Color.ToArgb() + "|" +
                stroke.Width + "|" +
                fill.Color.ToArgb();
                
        }
    }

}
