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

        protected float MilToPixels(float mil)
        {
            return mil / 1000 * mainForm.CurrentPrinter.PixelsPerMmX * 25.4f;
        }

        protected float PixelsToMil(float pixels)
        {
            return (pixels / 25.4f / mainForm.CurrentPrinter.PixelsPerMmX) * 1000;
        }

        public virtual void Enable()
        {
            mainForm.layeredCanvas.MouseDown += WorkareaPictureBox_MouseDown;
            mainForm.layeredCanvas.MouseUp += WorkareaPictureBox_MouseUp;
            mainForm.layeredCanvas.MouseMove += WorkareaPictureBox_MouseMove;
            mainForm.layeredCanvas.Paint += WorkareaPictureBox_Paint;
        }

        public virtual void Disable()
        {
            mainForm.layeredCanvas.MouseDown -= WorkareaPictureBox_MouseDown;
            mainForm.layeredCanvas.MouseUp -= WorkareaPictureBox_MouseUp;
            mainForm.layeredCanvas.MouseMove -= WorkareaPictureBox_MouseMove;
            mainForm.layeredCanvas.Paint -= WorkareaPictureBox_Paint;
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
