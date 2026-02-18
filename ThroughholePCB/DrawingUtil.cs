using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
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

        public static void DrawRotatedText(Graphics g, string text, Font font, Brush brush, Point startPos, Point endPos)
        {
            // Convert to Vector2 for clean math
            Vector2 s = new Vector2(startPos.X, startPos.Y);
            Vector2 e = new Vector2(endPos.X, endPos.Y);

            // Direction vector
            Vector2 se = e - s;
            float length = se.Length();

            // Angle in degrees
            float angleDeg = MathF.Atan2(se.Y, se.X) * 180f / MathF.PI;

            // Centered text formatting
            using var sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };

            // Save graphics state
            GraphicsState state = g.Save();

            // Move origin to midpoint
            g.TranslateTransform(s.X, s.Y);

            // Rotate so text aligns with the segment
            g.RotateTransform(angleDeg);

            using (var clipPath = new GraphicsPath())
            {
                clipPath.AddRectangle(new RectangleF(0, -5000, length, 10000));
                g.SetClip(clipPath);
            }

            // Draw text centered at (0,0)
            g.DrawString(text, font, brush, 0, 0, sf);

            // Restore original transform
            g.Restore(state);
        }
    }
}
