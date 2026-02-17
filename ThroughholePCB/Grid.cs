using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThroughholePCB.Tools;

namespace ThroughholePCB
{
    public class Grid
    {
        /// <summary>
        /// Spacing in PIXELS, not mils
        /// </summary>
        public float SpacingX { get; set; } = 100f;
        public float SpacingY { get; set; } = 100f;
        public bool Enabled { get; set; } = true;

        private readonly Control canvas;
        private Point mousePosRaw;

        public Grid(Control canvas)
        {
            this.canvas = canvas;
            canvas.MouseMove += Canvas_MouseMove;
        }

        private void Canvas_MouseMove(object? sender, MouseEventArgs e)
        {
            mousePosRaw = e.Location;
            canvas.Invalidate();
        }

        public void Draw(Graphics g, float width, float height)
        {
            //grid lines
            using var pen = new Pen(Color.FromArgb(40, Color.White));
            for (float x = 0; x < width; x += SpacingX)
                g.DrawLine(pen, x, 0, x, height);
            for (float y = 0; y < height; y += SpacingY)
                g.DrawLine(pen, 0, y, width, y);

            //red cross
            var pos = GetAligned(mousePosRaw);
            g.DrawLine(Pens.Red, pos.X - 5, pos.Y, pos.X + 5, pos.Y);
            g.DrawLine(Pens.Red, pos.X, pos.Y - 5, pos.X, pos.Y + 5);
        }

        public Point GetAligned(Point pos)
        {
            if (!Enabled)
            {
                return pos;
            }

            //get the nearest grid point to pos
            float nearestX = MathF.Round(pos.X / SpacingX) * SpacingX;
            float nearestY = MathF.Round(pos.Y / SpacingY) * SpacingY;

            return new Point((int)nearestX, (int)nearestY);
        }
    }
}
