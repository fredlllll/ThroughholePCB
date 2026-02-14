using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThroughholePCB.Tools
{
    public class WireTool : ToolBase
    {
        private bool hasMouseBeenPressed = false;
        private Point startPos, endPos;
        private Pen pen;

        public float Radius
        {
            get
            {
                return pen.Width;
            }
            set
            {
                pen.Width = value;
            }
        }

        public WireTool(MainForm mainForm, ToolStripButton button) : base(mainForm, button)
        {
            pen = new Pen(Brushes.White, 10);
        }

        protected override void WorkareaPictureBox_Paint(object? sender, PaintEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                PaintLine(e.Graphics, GetPictureBoxPos(startPos), GetPictureBoxPos(endPos));
            }
        }

        private void PaintLine(Graphics g, Point startPos, Point endPos)
        {
            float halfRadius = pen.Width / 2;
            int startCapX = (int)(startPos.X - halfRadius);
            int startCapY = (int)(startPos.Y - halfRadius);
            int endCapX = (int)(endPos.X - halfRadius);
            int endCapY = (int)(endPos.Y - halfRadius);

            g.DrawLine(pen, startPos, endPos);
            g.FillEllipse(pen.Brush, startCapX, startCapY, Radius, Radius);
            g.FillEllipse(pen.Brush, endCapX, endCapY, Radius, Radius);
        }

        protected override void WorkareaPictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                endPos = GetImagePos(e.Location);
                mainForm.workareaPictureBox.Invalidate();
            }
        }

        protected override void WorkareaPictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                hasMouseBeenPressed = false;
                endPos = GetImagePos(e.Location);
                PaintLine(mainForm.CurrentGraphics, startPos, endPos);
                mainForm.workareaPictureBox.Invalidate();
            }
        }

        protected override void WorkareaPictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!hasMouseBeenPressed && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                hasMouseBeenPressed = true;
                if (e.Button == MouseButtons.Left)
                {
                    pen.Brush = Brushes.White;
                }
                else
                {
                    pen.Brush = Brushes.Black;
                }

                endPos = startPos = GetImagePos(e.Location);
                mainForm.workareaPictureBox.Invalidate();
            }
        }
    }
}
