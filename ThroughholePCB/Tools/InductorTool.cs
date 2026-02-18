using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public class InductorTool : ABToolBase
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

        public InductorTool(MainForm mainForm, ToolStripButton button) : base(mainForm, button)
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

            float leadLengthPx = MathF.Min(PixelsPerMm * 4, se.Length() / 4);
            float bodyLengthPx = se.Length() - leadLengthPx;
            float bodyWidthPx = PixelsPerMm * 3;

            var forward = Vector2.Normalize(se);
            var left = new Vector2(-forward.Y, forward.X);
            var right = new Vector2(forward.Y, -forward.X);

            //draw leads
            var leadLeftEnd = s + forward * leadLengthPx;
            var leadRightEnd = e - forward * leadLengthPx;
            g.DrawLine(pen, startPos, leadLeftEnd.ToPoint());
            g.DrawLine(pen, endPos, leadRightEnd.ToPoint());




            //generate points


            var coilVec = leadRightEnd - leadLeftEnd;
            int loops = (int)(coilVec.Length() / 20);
            float amplitude = 3 * PixelsPerMm;
            float segment = coilVec.Length() / loops;
            List<Vector2> pts = new List<Vector2>();

            // Add the very first anchor
            pts.Add(new Vector2(0, 0));

            for (int i = 0; i < loops; i++)
            {
                float x0 = i * segment;
                float x3 = (i + 1) * segment;

                float x1 = x0 + segment * 0.25f;
                float x2 = x0 + segment * 0.75f;

                // Control points + next anchor
                pts.Add(new Vector2(x1, amplitude)); // C1
                pts.Add(new Vector2(x2, amplitude)); // C2
                pts.Add(new Vector2(x3, 0));         // Pn
            }


            PointF[] world = pts.Select(p => (leadLeftEnd + forward * p.X + left * p.Y).ToPointF()).ToArray();

            //draw coil
            g.DrawBeziers(pen, world);

        }
    }
}
