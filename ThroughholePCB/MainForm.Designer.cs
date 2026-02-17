namespace ThroughholePCB
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            resizeBoardToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolWireBtn = new ToolStripButton();
            toolHoleBtn = new ToolStripButton();
            toolFreeLine = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolGridBtn = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolActiveLayer = new ToolStripComboBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            panel1 = new Panel();
            panel2 = new Panel();
            leftRuler1 = new LeftRuler();
            topRuler1 = new TopRuler();
            layeredCanvas = new LayeredCanvas();
            propertyGrid = new PropertyGrid();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(837, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, exportToolStripMenuItem, toolStripSeparator3, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(114, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(114, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(114, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(111, 6);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(114, 22);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += ExportToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(111, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(114, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resizeBoardToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // resizeBoardToolStripMenuItem
            // 
            resizeBoardToolStripMenuItem.Name = "resizeBoardToolStripMenuItem";
            resizeBoardToolStripMenuItem.Size = new Size(140, 22);
            resizeBoardToolStripMenuItem.Text = "Resize Board";
            resizeBoardToolStripMenuItem.Click += resizeBoardToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolWireBtn, toolHoleBtn, toolFreeLine, toolStripSeparator2, toolGridBtn, toolStripSeparator4, toolActiveLayer });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(837, 31);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolWireBtn
            // 
            toolWireBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolWireBtn.Image = (Image)resources.GetObject("toolWireBtn.Image");
            toolWireBtn.ImageTransparentColor = Color.Magenta;
            toolWireBtn.Name = "toolWireBtn";
            toolWireBtn.Size = new Size(28, 28);
            toolWireBtn.Text = "Wire Tool";
            // 
            // toolHoleBtn
            // 
            toolHoleBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolHoleBtn.Image = (Image)resources.GetObject("toolHoleBtn.Image");
            toolHoleBtn.ImageTransparentColor = Color.Magenta;
            toolHoleBtn.Name = "toolHoleBtn";
            toolHoleBtn.Size = new Size(28, 28);
            toolHoleBtn.Text = "Hole Tool";
            // 
            // toolFreeLine
            // 
            toolFreeLine.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolFreeLine.Image = (Image)resources.GetObject("toolFreeLine.Image");
            toolFreeLine.ImageTransparentColor = Color.Magenta;
            toolFreeLine.Name = "toolFreeLine";
            toolFreeLine.Size = new Size(28, 28);
            toolFreeLine.Text = "toolStripButton1";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // toolGridBtn
            // 
            toolGridBtn.Checked = true;
            toolGridBtn.CheckState = CheckState.Checked;
            toolGridBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolGridBtn.Image = (Image)resources.GetObject("toolGridBtn.Image");
            toolGridBtn.ImageTransparentColor = Color.Magenta;
            toolGridBtn.Name = "toolGridBtn";
            toolGridBtn.Size = new Size(28, 28);
            toolGridBtn.Text = "Grid On/Off";
            toolGridBtn.Click += ToolGridBtn_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 31);
            // 
            // toolActiveLayer
            // 
            toolActiveLayer.DropDownWidth = 250;
            toolActiveLayer.Name = "toolActiveLayer";
            toolActiveLayer.Size = new Size(121, 31);
            toolActiveLayer.SelectedIndexChanged += ToolActiveLayer_SelectedIndexChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 579);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(837, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(leftRuler1);
            panel1.Controls.Add(topRuler1);
            panel1.Controls.Add(layeredCanvas);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(649, 524);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(20, 20);
            panel2.TabIndex = 3;
            // 
            // leftRuler1
            // 
            leftRuler1.BackColor = Color.IndianRed;
            leftRuler1.Location = new Point(0, 20);
            leftRuler1.Mode = RulerMode.Mm;
            leftRuler1.Name = "leftRuler1";
            leftRuler1.Size = new Size(20, 200);
            leftRuler1.TabIndex = 2;
            leftRuler1.Text = "leftRuler1";
            // 
            // topRuler1
            // 
            topRuler1.BackColor = Color.IndianRed;
            topRuler1.Location = new Point(20, 0);
            topRuler1.Mode = RulerMode.Mm;
            topRuler1.Name = "topRuler1";
            topRuler1.Size = new Size(200, 20);
            topRuler1.TabIndex = 1;
            topRuler1.Text = "topRuler1";
            // 
            // layeredCanvas
            // 
            layeredCanvas.Location = new Point(20, 20);
            layeredCanvas.Name = "layeredCanvas";
            layeredCanvas.Size = new Size(200, 200);
            layeredCanvas.TabIndex = 0;
            layeredCanvas.TabStop = false;
            layeredCanvas.Text = "layeredCanvas";
            // 
            // propertyGrid
            // 
            propertyGrid.Dock = DockStyle.Fill;
            propertyGrid.HelpVisible = false;
            propertyGrid.Location = new Point(0, 0);
            propertyGrid.Name = "propertyGrid";
            propertyGrid.Size = new Size(184, 150);
            propertyGrid.TabIndex = 5;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 55);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(837, 524);
            splitContainer1.SplitterDistance = 649;
            splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(propertyGrid);
            splitContainer2.Size = new Size(184, 524);
            splitContainer2.SplitterDistance = 150;
            splitContainer2.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 601);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "ThroughholePCB";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolWireBtn;
        private ToolStripButton toolHoleBtn;
        private ToolStripButton toolGridBtn;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripSeparator toolStripSeparator2;
        private Panel panel1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private PropertyGrid propertyGrid;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        public LayeredCanvas layeredCanvas;
        private ToolStripComboBox toolActiveLayer;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolFreeLine;
        private TopRuler topRuler1;
        private LeftRuler leftRuler1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem resizeBoardToolStripMenuItem;
        private Panel panel2;
    }
}
