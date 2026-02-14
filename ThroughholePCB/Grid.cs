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
        public float Spacing { get; set; } = 100f;
        public bool Enabled { get; set; } = true;

        private readonly PictureBox pictureBox;
        private Point mousePosRaw;

        public Grid(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            pictureBox.Paint += PictureBox_Paint;
            pictureBox.MouseMove += PictureBox_MouseMove;
        }

        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            mousePosRaw = e.Location;
            pictureBox.Invalidate();
        }

        private void PictureBox_Paint(object? sender, PaintEventArgs e)
        {
            if (Enabled)
            {
                // get aligned position and then convert it to picture box coordinates for drawing
                var pos = ToolUtils.GetImagePos(pictureBox, mousePosRaw, this);
                pos = ToolUtils.GetPictureBoxPos(pictureBox, pos);
                e.Graphics.DrawLine(Pens.Red, pos.X - 5, pos.Y, pos.X + 5, pos.Y);
                e.Graphics.DrawLine(Pens.Red, pos.X, pos.Y - 5, pos.X, pos.Y + 5);
            }
        }

        public Point GetAligned(Point pos)
        {
            if (!Enabled)
            {
                return pos;
            }

            //get the nearest grid point to pos
            float nearestX = MathF.Round(pos.X / Spacing) * Spacing;
            float nearestY = MathF.Round(pos.Y / Spacing) * Spacing;

            return new Point((int)nearestX, (int)nearestY);
        }
    }
}
