using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{

    public class TopRuler : BaseRuler
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
                float pixelsPerMm = mainForm.CurrentPrinter.PixelsPerMmX;
                float pixelsPerSpacingMm = 2 * pixelsPerMm;
                for (float x = 0; x < Width; x += pixelsPerSpacingMm)
                {
                    g.DrawLine(Pens.Black, x, 3, x, Height);

                    int mmValue = (int)(x / pixelsPerMm);
                    g.DrawString(mmValue.ToString(), Font, Brushes.Black, x + 2, 2);
                }
            }
            else
            {
                float pixelsPerMil = mainForm.CurrentPrinter.PixelsPerMmX * 25.4f / 1000;
                float pixelsPerSpacingMil = 100 * pixelsPerMil;
                for (float x = 0; x < Width; x += pixelsPerSpacingMil)
                {
                    g.DrawLine(Pens.Black, x, 3, x, Height);

                    int milValue = (int)(x / pixelsPerMil);
                    g.DrawString(milValue.ToString(), Font, Brushes.Black, x + 2, 2);
                }
            }

            base.OnPaint(e);
        }
    }
}
