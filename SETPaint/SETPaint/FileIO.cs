/* ================================================ *
 *											 		*
 * 		FILE 			: FileIO.cs 				*
 * 		PROJECT 		: WMP A3					*
 * 		PROGRAMMER 		: Ben Lorantfy              *
 * 		                  and Chaung Liu 		    *
 * 		FIRST VERSION 	: 2014-10-07 				*
 * 		DESCRIPTION		: Contains methods for      *
 * 		                  file io                   * 
 *													*
 * ================================================ */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace SETPaint
{
    /* =========================================================================================================== *
    *											 																   *
    * 		NAME 			: FileIO																			   *
    * 		PURPOSE 		: The fileIO class encapsultes methods used for interacting with files                 * 
    *																											   *
    * ============================================================================================================ */
    class FileIO
    {
        public void Save(string fileName, List<Shape> shapes)
        {
            StreamWriter writer = new StreamWriter(fileName);

            //
            // Write each shape's string as a seperate line in the file
            //
            foreach (var shape in shapes)
            {
                writer.WriteLine(shape.ToString());
            }

            writer.Close();
        }

        public void Open(string fileName, List<Shape> shapes)
        {
            string line;

            //
            // Opens file
            //       
            StreamReader reader = new StreamReader(fileName);

            //
            // Empties the current shape list
            //
            shapes.Clear();

            //
            // Get each line and load each shape
            //
            while ((line = reader.ReadLine()) != null)
            {
                //
                // Converts the properties from a delimited string to an array
                //
                string[] shapeProperties = line.Split('|');

                //
                // Creates new shape with properties and adds to the shapes list
                //
                shapes.Add(new Shape(
                      shapeProperties[0]
                    , new Point(Convert.ToInt32(shapeProperties[1]), Convert.ToInt32(shapeProperties[2]))
                    , new Point(Convert.ToInt32(shapeProperties[3]), Convert.ToInt32(shapeProperties[4]))
                    , new Pen(Color.FromArgb(Convert.ToInt32(shapeProperties[5])), Convert.ToInt32(shapeProperties[6]))
                    , new SolidBrush(Color.FromArgb(Convert.ToInt32(shapeProperties[7])))
                ));
                
            }
        }

     
    }
}
