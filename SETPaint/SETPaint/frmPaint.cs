using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SETPaint
{
    public partial class frmPaint : Form
    {
        Canvas canvas;
        string tool;
        public frmPaint()
        {           
            InitializeComponent();
            tool = "none";
            canvas = new Canvas(pnlCanvas);
        }

        private void pnlCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (tool == "drawingLine")
            {
                canvas.DrawLine(e.X, e.Y);
            }
            else if (tool == "drawingRectangle")
            {
                canvas.DrawRectangle(e.X, e.Y);
            }
           
        }

        private void pnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool == "line")
            {
                tool = "drawingLine";
                
            }
            else if (tool == "rectangle")
            {
                tool = "drawingRectangle";
            }
            canvas.StartDraw(e.X, e.Y);
        }

        private void pnlCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (tool == "drawingLine")
            {
                tool = "line";
            }
            else if (tool == "drawingRectangle")
            {
                tool = "rectangle";  
            }
            canvas.EndDraw();
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            canvas.Redraw();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvas.Undo();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            tool = "line";
        }

        private void frmPaint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                if (tool == "drawingLine")
                {
                    tool = "line";
                }
                canvas.CancelDraw();
            }
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            tool = "rectangle";
        }

        private void pnlFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.ShowDialog();
            Color color = colorPicker.Color;
            pnlFillColor.BackColor = color;
            canvas.SetFill(color);
        }

        private void pnlStrokeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.ShowDialog();
            Color color = colorPicker.Color;
            pnlStrokeColor.BackColor = color;
            canvas.SetStroke(color);
        }



    }
}
