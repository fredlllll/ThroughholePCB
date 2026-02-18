using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public abstract class ABToolBase : BaseTool
    {
        protected bool hasMouseBeenPressed = false;
        protected bool erase = false;
        protected Point startPos, endPos;

        public ABToolBase(MainForm mainForm, ToolStripButton button) : base(mainForm, button) { }

        protected abstract void DrawPreview(Graphics g);
        protected abstract void DrawFinal(Graphics g);

        protected override void WorkareaPictureBox_Paint(object? sender, PaintEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                DrawPreview(e.Graphics);
            }
        }

        protected override void WorkareaPictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                endPos = mainForm.layeredCanvas.Grid.GetAligned(e.Location);
                mainForm.layeredCanvas.Invalidate();
            }
        }

        protected override void WorkareaPictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                hasMouseBeenPressed = false;
                if (mainForm.layeredCanvas.ActiveLayer != null)
                {
                    endPos = mainForm.layeredCanvas.Grid.GetAligned(e.Location);
                    using var g = mainForm.layeredCanvas.ActiveLayer.CreateGraphics();
                    DrawFinal(g);
                    mainForm.layeredCanvas.Invalidate();
                }
            }
        }

        protected override void WorkareaPictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!hasMouseBeenPressed && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                hasMouseBeenPressed = true;
                erase = e.Button == MouseButtons.Right;

                endPos = startPos = mainForm.layeredCanvas.Grid.GetAligned(e.Location);
                mainForm.layeredCanvas.Invalidate();
            }
        }
    }
}
