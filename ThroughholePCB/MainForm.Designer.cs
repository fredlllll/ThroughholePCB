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
            toolStrip1 = new ToolStrip();
            toolWireBtn = new ToolStripButton();
            toolHoleBtn = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolGridBtn = new ToolStripButton();
            workareaPictureBox = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)workareaPictureBox).BeginInit();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1071, 24);
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
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(180, 22);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += ExportToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolWireBtn, toolHoleBtn, toolStripSeparator2, toolGridBtn });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1071, 31);
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
            // workareaPictureBox
            // 
            workareaPictureBox.BackColor = SystemColors.ControlDarkDark;
            workareaPictureBox.Location = new Point(0, 0);
            workareaPictureBox.Name = "workareaPictureBox";
            workareaPictureBox.Size = new Size(256, 256);
            workareaPictureBox.TabIndex = 2;
            workareaPictureBox.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 476);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1071, 22);
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
            panel1.Controls.Add(workareaPictureBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(1071, 421);
            panel1.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 498);
            Controls.Add(panel1);
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
            ((System.ComponentModel.ISupportInitialize)workareaPictureBox).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
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
        public PictureBox workareaPictureBox;
        private ToolStripSeparator toolStripSeparator2;
        private Panel panel1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
    }
}
