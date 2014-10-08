/* ================================================ *
 *											 		*
 * 		FILE 			: frmPaint.cs 				*
 * 		PROJECT 		: WMP A3					*
 * 		PROGRAMMER 		: Ben Lorantfy              *
 * 		                  and Chaung Liu 		    *
 * 		FIRST VERSION 	: 2014-10-07 				*
 * 		DESCRIPTION		: A simple drawing program  *
 * 		                  that allows you to draw   *
 * 		                  lines, rectangles, and    *
 * 		                  ellipses                  *
 *													*
 * ================================================ */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO;

namespace SETPaint
{
    public partial class frmPaint : Form
    {
        int mouseX;                     // Keeps track of the cursor's X position
        int mouseY;                     // Keeps track of the cursor's Y position
        string tool;                    // Keeps track of the current operation
        Draw draw;                      // Encapsulates drawing methods
        FileIO fileIO;                  // Encapsulates file io methods
        bool undo;                      // Flag for if user undid something
        bool checkPainting = false;     // Flag for if coordinates should show
        bool savedAtleastOnce = false;  // Flag for if drawing is a new drawing
        string fileName;                // Stores the file name for the drawing
        string filePath;                // Stores the file path for the drawing

        public frmPaint()
        {           
            InitializeComponent();
            draw = new Draw();
            fileIO = new FileIO();
            mouseX = 0;
            mouseY = 0;
            tool = "none";
            undo = false;
            fileName = "untitled.stp";
            filePath = "untitled.stp";
        }

        private void pnlCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;

            if (tool == "drawingLine" || tool == "drawingRectangle" || tool == "drawingEllipse")
            {
                pnlCanvas.Invalidate();
            }

            if (checkPainting)
            {
                mousePosition.Text = "X: " + (mouseX - 24) + "    Y: " + (mouseY - 24);
            }
            else
            {
                mousePosition.Text = "";
            }
        }

        private void pnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            checkPainting = true;
            txtStrokeWidth_Leave(sender, e);
            draw.Start(mouseX, mouseY);

            switch (tool)
            {
                case "line":
                    tool = "drawingLine";
                    break;

                case "rectangle":
                    tool = "drawingRectangle";
                    break;

                case "ellipse":
                    tool = "drawingEllipse";
                    break;
            }
            
        }

        private void pnlCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            checkPainting = false;

            switch (tool)
            {
                case "drawingLine":
                    tool = "stopDrawingLine";
                    pnlCanvas.Invalidate();
                    break;

                case "drawingRectangle":
                    tool = "stopDrawingRectangle";
                    pnlCanvas.Invalidate();
                    break;

                case "drawingEllipse":
                    tool = "stopDrawingEllipse";
                    pnlCanvas.Invalidate();
                    break;
            }

            
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (undo)
            {
                draw.Undo(e.Graphics);
                undo = false;
            }

            //
            // Do all drawing here
            //     
            switch (tool){
                case "drawingLine":
                    draw.Line(e.Graphics, mouseX, mouseY);
                    break;
                
                case "drawingRectangle":
                    draw.Rectangle(e.Graphics, mouseX, mouseY);
                    break;

                case "drawingEllipse":
                    draw.Ellipse(e.Graphics, mouseX, mouseY);
                    break;

                case "stopDrawingLine":
                    draw.End(e.Graphics);
                    tool = "line";
                    break;
                
                case "stopDrawingRectangle":
                    draw.End(e.Graphics);
                    tool = "rectangle";
                    break;
                
                case "stopDrawingEllipse":
                    draw.End(e.Graphics);
                    tool = "ellipse";
                    break;

                case "clearing":
                    draw.ClearAndReset(e.Graphics);
                    tool = "none";
                    break;

                default:
                    draw.Redraw(e.Graphics);
                    break;

            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            tool = "line";
            txtStrokeWidth_Leave(sender, e);
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            tool = "rectangle";
            txtStrokeWidth_Leave(sender, e);
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            tool = "ellipse";
            txtStrokeWidth_Leave(sender, e);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo = true;
            pnlCanvas.Invalidate();
        }
        
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            Color fill = pnlFillColor.BackColor;
            Color stroke = pnlStrokeColor.BackColor;

            pnlFillColor.BackColor = stroke;
            pnlStrokeColor.BackColor = fill;

            draw.SetStrokeColor(fill);
            draw.SetFillColor(stroke);
        }

        private void pnlFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.ShowDialog();
            Color color = colorPicker.Color;
            pnlFillColor.BackColor = color;
            draw.SetFillColor(color);
        }

        private void pnlStrokeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.ShowDialog();
            Color color = colorPicker.Color;
            pnlStrokeColor.BackColor = color;
            draw.SetStrokeColor(color);
        }

        private void trkStrokeWidth_Scroll(object sender, EventArgs e)
        {
            int width = trkStrokeWidth.Value;
            draw.SetStrokeWidth(width);
            txtStrokeWidth.Text = Convert.ToString(width);
        }

        private void txtStrokeWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;          //Stops ding when enter is pressed
                txtStrokeWidth_Leave(sender, e);
            }
        }

        private void txtStrokeWidth_Leave(object sender, EventArgs e)
        {
            //
            // Tries to convert textbox value to integer
            // If string is not a valid integer, it sets the width to 1
            //
            string textBoxValue = txtStrokeWidth.Text;
            int width = 1;
            if (!int.TryParse(textBoxValue, out width) || width < 1)
            {
                width = 1;
                txtStrokeWidth.Text = "1";
            }
            else if (width > 100)
            {
                width = 100;
                txtStrokeWidth.Text = "100";
            }

            if (width <= 20)
            {
                trkStrokeWidth.Value = width;
            }
            else
            {
                trkStrokeWidth.Value = 20;
            }
            
            draw.SetStrokeWidth(width);           
        }

        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete entire image?", "Clear Image", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                tool = "clearing";
                pnlCanvas.Invalidate();
            } 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savedAtleastOnce)
            {
                fileIO.Save(filePath, draw.Shapes());
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openDialog.FileName.ToString();
                fileIO.Open(filePath, draw.Shapes());
                tool = "none";
                pnlCanvas.Invalidate();
                fileName = Path.GetFileName(openDialog.FileName);
                this.Text = "SETPaint - " + fileName;
                savedAtleastOnce = true;
            }       
        }

        private void aboutSETPaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout box = new frmAbout();
            box.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = fileName;
            saveDialog.Filter = @"SETPaint Project|*.stp";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveDialog.FileName.ToString();
                fileIO.Save(filePath, draw.Shapes());
                fileName = Path.GetFileName(saveDialog.FileName);
                this.Text = "SETPaint - " + fileName;
                savedAtleastOnce = true;
            }
        }
  
    }
}
