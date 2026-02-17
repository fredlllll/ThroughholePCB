using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThroughholePCB.Tools
{
    public class FreeLineTool : ToolBase
    {
        private bool hasMouseBeenPressed = false;
        private bool erase = false;
        private Point lastPos;
        private Pen pen;
        //private SolidBrush lineBrush = new SolidBrush(Color.White);

        public float LineWidthMil
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

        public Color LineShade
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

        public FreeLineTool(MainForm mainForm, ToolStripButton button) : base(mainForm, button)
        {
            pen = new Pen(new SolidBrush(Color.White), 1);
        }

        protected override void WorkareaPictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                if (mainForm.layeredCanvas.ActiveLayer != null)
                {
                    var currentPos = mainForm.layeredCanvas.Grid.GetAligned(e.Location);
                    using var g = mainForm.layeredCanvas.ActiveLayer.CreateGraphics();
                    if (erase)
                    {
                        g.CompositingMode = CompositingMode.SourceCopy;
                        var col = pen.Color;
                        pen.Color = Color.Transparent;
                        DrawingUtil.PaintLine(g, pen, lastPos, currentPos);
                        pen.Color = col;
                    }
                    else
                    {
                        DrawingUtil.PaintLine(g, pen, lastPos, currentPos);
                    }
                    lastPos = currentPos;
                    mainForm.layeredCanvas.Invalidate();
                }
            }
        }

        protected override void WorkareaPictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (hasMouseBeenPressed)
            {
                hasMouseBeenPressed = false;
            }
        }

        protected override void WorkareaPictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!hasMouseBeenPressed && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                hasMouseBeenPressed = true;
                if (mainForm.layeredCanvas.ActiveLayer != null)
                {
                    erase = e.Button == MouseButtons.Right;

                    lastPos = mainForm.layeredCanvas.Grid.GetAligned(e.Location);
                    using var g = mainForm.layeredCanvas.ActiveLayer.CreateGraphics();
                    var widthPx = MilToPixels(LineWidthMil);
                    var brush = pen.Brush;
                    if (erase)
                    {
                        g.CompositingMode = CompositingMode.SourceCopy;
                        brush = Brushes.Transparent;
                    }
                    g.FillEllipse(brush, lastPos.X - widthPx / 2, lastPos.Y - widthPx / 2, widthPx, widthPx);
                    mainForm.layeredCanvas.Invalidate();
                }
            }
        }
    }
}
