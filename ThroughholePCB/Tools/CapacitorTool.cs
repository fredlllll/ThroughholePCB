using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public class CapacitorTool : ABToolBase
    {
        private Pen pen;

        public Color Color
        {
            get { return pen.Color; }
            set { pen.Color = value; }
        }

        public int Width
        {
            get { return (int)pen.Width; }
            set { pen.Width = value; }
        }

        public CapacitorTool(MainForm mainForm, ToolStripButton button) : base(mainForm, button)
        {
            pen = new Pen(Brushes.White, 1);
        }

        protected override void DrawPreview(Graphics g)
        {
            DrawFinal(g);
        }

        protected override void DrawFinal(Graphics g)
        {
            Pen pen = Pens.White;

            Vector2 s = new Vector2(startPos.X, startPos.Y);
            Vector2 e = new Vector2(endPos.X, endPos.Y);
            Vector2 se = e - s;
            if (se.Length() <= 0)
            {
                return;//dont draw if length is 0 to prevent the math from exploding
            }

            float bodyLengthPx = PixelsPerMm * 0.3f;
            float leadLengthPx = (se.Length() - bodyLengthPx)/2;
            float bodyWidthPx = PixelsPerMm * 3;

            var forward = Vector2.Normalize(se);
            var left = new Vector2(-forward.Y, forward.X);
            var right = new Vector2(forward.Y, -forward.X);

            //draw leads
            var leadLeftEnd = s + forward * leadLengthPx;
            var leadRightEnd = e - forward * leadLengthPx;
            g.DrawLine(pen, startPos, leadLeftEnd.ToPoint());
            g.DrawLine(pen, endPos, leadRightEnd.ToPoint());

            var bodyLeftTop = leadLeftEnd + left * bodyWidthPx / 2;
            var bodyLeftBottom = leadLeftEnd + right * bodyWidthPx / 2;
            var bodyRightTop = leadRightEnd + left * bodyWidthPx / 2;
            var bodyRightBottom = leadRightEnd + right * bodyWidthPx / 2;
            g.DrawLine(pen, bodyLeftBottom.ToPoint(), bodyLeftTop.ToPoint());
            g.DrawLine(pen, bodyRightBottom.ToPoint(), bodyRightTop.ToPoint());
        }
    }
}
