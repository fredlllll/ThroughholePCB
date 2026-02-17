using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThroughholePCB.Tools
{
    public class WireTool : BaseTool
    {
        private bool hasMouseBeenPressed = false;
        private bool erase = false;
        private Point startPos, endPos;
        private Pen pen;

        public float WireWidthMil
        {
            get
            {
                return PixelsToMil(pen.Width);
            }
            set
            {
                pen.Width = MilToPixels(value);
            }
        }

        public Color WireShade
        {
            get
            {
                return pen.Color;
            }
            set
            {
                pen.Color = value;
            }
        }

        public WireTool(MainForm mainForm, ToolStripButton button) : base(mainForm, button)
        {
            pen = new Pen(new SolidBrush(Color.White), 1);
        }

        protected override void WorkareaPictureBox_Paint(object? sender, PaintEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                DrawingUtil.PaintLine(e.Graphics, pen, mainForm.layeredCanvas.Grid.GetAligned(startPos), mainForm.layeredCanvas.Grid.GetAligned(endPos));
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
                    if (erase)
                    {
                        g.CompositingMode = CompositingMode.SourceCopy;
                        var col = pen.Color;
                        pen.Color = Color.Transparent;
                        DrawingUtil.PaintLine(g, pen, startPos, endPos);
                        pen.Color = col;
                    }
                    else
                    {
                        DrawingUtil.PaintLine(g, pen, startPos, endPos);
                    }

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
