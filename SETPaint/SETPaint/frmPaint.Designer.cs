namespace SETPaint
{
    partial class frmPaint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaint));
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.pnlColors = new System.Windows.Forms.Panel();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.pnlStrokeColor = new System.Windows.Forms.Panel();
            this.txtStrokeWidth = new System.Windows.Forms.TextBox();
            this.trkStrokeWidth = new System.Windows.Forms.TrackBar();
            this.lblStrokeWidth = new System.Windows.Forms.Label();
            this.lblFillAndStroke = new System.Windows.Forms.Label();
            this.pnlFillColor = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDebug = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLine = new System.Windows.Forms.ToolStripButton();
            this.btnRectangle = new System.Windows.Forms.ToolStripButton();
            this.btnEllipse = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCanvas.SuspendLayout();
            this.pnlColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkStrokeWidth)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.White;
            this.pnlCanvas.Controls.Add(this.pnlColors);
            this.pnlCanvas.Controls.Add(this.statusStrip1);
            this.pnlCanvas.Controls.Add(this.toolStrip1);
            this.pnlCanvas.Controls.Add(this.menuStrip1);
            this.pnlCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCanvas.Location = new System.Drawing.Point(0, 0);
            this.pnlCanvas.MaximumSize = new System.Drawing.Size(99999, 99999);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(565, 415);
            this.pnlCanvas.TabIndex = 0;
            this.pnlCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCanvas_Paint);
            this.pnlCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseDown);
            this.pnlCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseMove);
            this.pnlCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseUp);
            // 
            // pnlColors
            // 
            this.pnlColors.BackColor = System.Drawing.SystemColors.Control;
            this.pnlColors.Controls.Add(this.btnSwitch);
            this.pnlColors.Controls.Add(this.pnlStrokeColor);
            this.pnlColors.Controls.Add(this.txtStrokeWidth);
            this.pnlColors.Controls.Add(this.trkStrokeWidth);
            this.pnlColors.Controls.Add(this.lblStrokeWidth);
            this.pnlColors.Controls.Add(this.lblFillAndStroke);
            this.pnlColors.Controls.Add(this.pnlFillColor);
            this.pnlColors.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlColors.Location = new System.Drawing.Point(452, 24);
            this.pnlColors.Name = "pnlColors";
            this.pnlColors.Size = new System.Drawing.Size(113, 369);
            this.pnlColors.TabIndex = 3;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(13, 77);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(87, 23);
            this.btnSwitch.TabIndex = 10;
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // pnlStrokeColor
            // 
            this.pnlStrokeColor.BackColor = System.Drawing.Color.Black;
            this.pnlStrokeColor.Location = new System.Drawing.Point(57, 28);
            this.pnlStrokeColor.Name = "pnlStrokeColor";
            this.pnlStrokeColor.Size = new System.Drawing.Size(43, 43);
            this.pnlStrokeColor.TabIndex = 9;
            this.pnlStrokeColor.Click += new System.EventHandler(this.pnlStrokeColor_Click);
            // 
            // txtStrokeWidth
            // 
            this.txtStrokeWidth.Location = new System.Drawing.Point(14, 133);
            this.txtStrokeWidth.Name = "txtStrokeWidth";
            this.txtStrokeWidth.Size = new System.Drawing.Size(40, 20);
            this.txtStrokeWidth.TabIndex = 5;
            this.txtStrokeWidth.Text = "4";
            this.txtStrokeWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStrokeWidth_KeyDown);
            this.txtStrokeWidth.Leave += new System.EventHandler(this.txtStrokeWidth_Leave);
            // 
            // trkStrokeWidth
            // 
            this.trkStrokeWidth.Location = new System.Drawing.Point(4, 159);
            this.trkStrokeWidth.Maximum = 20;
            this.trkStrokeWidth.Minimum = 1;
            this.trkStrokeWidth.Name = "trkStrokeWidth";
            this.trkStrokeWidth.Size = new System.Drawing.Size(107, 45);
            this.trkStrokeWidth.TabIndex = 4;
            this.trkStrokeWidth.TickFrequency = 2;
            this.trkStrokeWidth.Value = 4;
            this.trkStrokeWidth.Scroll += new System.EventHandler(this.trkStrokeWidth_Scroll);
            // 
            // lblStrokeWidth
            // 
            this.lblStrokeWidth.AutoSize = true;
            this.lblStrokeWidth.Location = new System.Drawing.Point(10, 114);
            this.lblStrokeWidth.Name = "lblStrokeWidth";
            this.lblStrokeWidth.Size = new System.Drawing.Size(69, 13);
            this.lblStrokeWidth.TabIndex = 8;
            this.lblStrokeWidth.Text = "Stroke Width";
            // 
            // lblFillAndStroke
            // 
            this.lblFillAndStroke.AutoSize = true;
            this.lblFillAndStroke.Location = new System.Drawing.Point(10, 12);
            this.lblFillAndStroke.Name = "lblFillAndStroke";
            this.lblFillAndStroke.Size = new System.Drawing.Size(74, 13);
            this.lblFillAndStroke.TabIndex = 7;
            this.lblFillAndStroke.Text = "Fill and Stroke";
            // 
            // pnlFillColor
            // 
            this.pnlFillColor.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlFillColor.Location = new System.Drawing.Point(14, 28);
            this.pnlFillColor.Name = "pnlFillColor";
            this.pnlFillColor.Size = new System.Drawing.Size(43, 43);
            this.pnlFillColor.TabIndex = 6;
            this.pnlFillColor.Click += new System.EventHandler(this.pnlFillColor_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDebug});
            this.statusStrip1.Location = new System.Drawing.Point(24, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(541, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDebug
            // 
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(118, 17);
            this.lblDebug.Text = "toolStripStatusLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLine,
            this.btnRectangle,
            this.btnEllipse});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 391);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLine
            // 
            this.btnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageTransparentColor = System.Drawing.Color.White;
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(21, 20);
            this.btnLine.Text = "toolStripButton1";
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.ImageTransparentColor = System.Drawing.Color.White;
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(21, 20);
            this.btnRectangle.Text = "toolStripButton1";
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.ImageTransparentColor = System.Drawing.Color.White;
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(21, 20);
            this.btnEllipse.Text = "toolStripButton2";
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(565, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.eraseToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // eraseToolStripMenuItem
            // 
            this.eraseToolStripMenuItem.Name = "eraseToolStripMenuItem";
            this.eraseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eraseToolStripMenuItem.Text = "Erase";
            this.eraseToolStripMenuItem.Click += new System.EventHandler(this.eraseToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // frmPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 415);
            this.Controls.Add(this.pnlCanvas);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPaint";
            this.Text = "Form1";
            this.pnlCanvas.ResumeLayout(false);
            this.pnlCanvas.PerformLayout();
            this.pnlColors.ResumeLayout(false);
            this.pnlColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkStrokeWidth)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLine;
        private System.Windows.Forms.ToolStripButton btnRectangle;
        private System.Windows.Forms.ToolStripButton btnEllipse;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDebug;
        private System.Windows.Forms.Panel pnlColors;
        private System.Windows.Forms.TextBox txtStrokeWidth;
        private System.Windows.Forms.Panel pnlFillColor;
        private System.Windows.Forms.Label lblStrokeWidth;
        private System.Windows.Forms.Label lblFillAndStroke;
        private System.Windows.Forms.TrackBar trkStrokeWidth;
        private System.Windows.Forms.Panel pnlStrokeColor;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eraseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

