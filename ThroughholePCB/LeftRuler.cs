using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public class LeftRuler : BaseRuler
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            if (mainForm == null || mainForm.CurrentPrinter == null)
            {
                return;
            }

            var g = e.Graphics;
            g.Clear(Color.WhiteSmoke);

            if (Mode == RulerMode.Mm)
            {
                float pixelsPerMm = mainForm.CurrentPrinter.PixelsPerMmY;
                float pixelsPerSpacingMm = 2 * pixelsPerMm;
                for (float y = 0; y < Height; y += pixelsPerSpacingMm)
                {
                    g.DrawLine(Pens.Black, 0, y, Width - 3, y);

                    int mmValue = (int)(y / pixelsPerMm);
                    g.DrawString(mmValue.ToString(), Font, Brushes.Black, 2, y + 2);
                }
            }
            else
            {
                float pixelsPerMil = mainForm.CurrentPrinter.PixelsPerMmY * 25.4f / 1000;
                float pixelsPerSpacingMil = 100 * pixelsPerMil;
                for (float y = 0; y < Height; y += pixelsPerSpacingMil)
                {
                    g.DrawLine(Pens.Black, 0, y, Width - 3, y);

                    int milValue = (int)(y / pixelsPerMil);
                    g.DrawString(milValue.ToString(), Font, Brushes.Black, 2, y + 2);
                }
            }

            base.OnPaint(e);
        }
    }
}
