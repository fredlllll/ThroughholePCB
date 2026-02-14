using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public abstract class ToolBase : ITool
    {
        protected MainForm mainForm;
        protected ToolStripButton button;

        public ToolBase(MainForm mainForm, ToolStripButton button)
        {
            this.mainForm = mainForm;
            this.button = button;
            button.Click += Button_Click;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            mainForm.SetTool(this);
        }

        protected Point GetImagePos(Point pictureBoxPos, bool useGrid = true)
        {
            return ToolUtils.GetImagePos(mainForm.workareaPictureBox, pictureBoxPos, useGrid ? mainForm.Grid : null);
        }

        protected Point GetPictureBoxPos(Point imagePos, bool useGrid = false)
        {
            return ToolUtils.GetPictureBoxPos(mainForm.workareaPictureBox, imagePos, useGrid ? mainForm.Grid : null);
        }

        public virtual void Enable()
        {
            mainForm.workareaPictureBox.MouseDown += WorkareaPictureBox_MouseDown;
            mainForm.workareaPictureBox.MouseUp += WorkareaPictureBox_MouseUp;
            mainForm.workareaPictureBox.MouseMove += WorkareaPictureBox_MouseMove;
            mainForm.workareaPictureBox.Paint += WorkareaPictureBox_Paint;
        }

        public virtual void Disable()
        {
            mainForm.workareaPictureBox.MouseDown -= WorkareaPictureBox_MouseDown;
            mainForm.workareaPictureBox.MouseUp -= WorkareaPictureBox_MouseUp;
            mainForm.workareaPictureBox.MouseMove -= WorkareaPictureBox_MouseMove;
            mainForm.workareaPictureBox.Paint -= WorkareaPictureBox_Paint;
        }
        protected virtual void WorkareaPictureBox_MouseDown(object? sender, MouseEventArgs e)
        {

        }

        protected virtual void WorkareaPictureBox_MouseMove(object? sender, MouseEventArgs e)
        {

        }

        protected virtual void WorkareaPictureBox_MouseUp(object? sender, MouseEventArgs e)
        {

        }

        protected virtual void WorkareaPictureBox_Paint(object? sender, PaintEventArgs e)
        {

        }
    }
}
