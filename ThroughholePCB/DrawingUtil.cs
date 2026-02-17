using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public static class DrawingUtil
    {
        public static void PaintLine(Graphics g, Pen pen, Point startPos, Point endPos)
        {
            float width = pen.Width;
            float halfRadius = pen.Width / 2;
            int startCapX = (int)(startPos.X - halfRadius);
            int startCapY = (int)(startPos.Y - halfRadius);
            int endCapX = (int)(endPos.X - halfRadius);
            int endCapY = (int)(endPos.Y - halfRadius);

            g.DrawLine(pen, startPos, endPos);
            g.FillEllipse(pen.Brush, startCapX, startCapY, width, width);
            g.FillEllipse(pen.Brush, endCapX, endCapY, width, width);
        }
    }
}
