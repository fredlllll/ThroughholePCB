using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public class HoleTool : ToolBase
    {
        public float OuterDiameterMil { get; set; } = 40;
        public float InnerDiameterMil { get; set; } = 20;
        private SolidBrush holeBrush = new SolidBrush(Color.White);

        public Color HoleColor
        {
            get { return holeBrush.Color; }
            set { holeBrush.Color = value; }
        }

        public HoleTool(MainForm mainForm, ToolStripButton button) : base(mainForm, button)
        {
        }
        protected override void WorkareaPictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (mainForm.layeredCanvas.ActiveLayer != null)
            {
                var pos = mainForm.layeredCanvas.Grid.GetAligned(e.Location);
                using var g = mainForm.layeredCanvas.ActiveLayer.CreateGraphics();

                var outerDiameterPx = MilToPixels(OuterDiameterMil);
                var innerDiameterPx = MilToPixels(InnerDiameterMil);

                var halfOuter = outerDiameterPx / 2;
                var halfInner = innerDiameterPx / 2;
                if (e.Button == MouseButtons.Left)
                {
                    g.FillEllipse(holeBrush, pos.X - halfOuter, pos.Y - halfOuter, outerDiameterPx, outerDiameterPx);
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    g.FillEllipse(Brushes.Transparent, pos.X - halfInner, pos.Y - halfInner, innerDiameterPx, innerDiameterPx);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    g.FillEllipse(Brushes.Transparent, pos.X - halfOuter, pos.Y - halfOuter, outerDiameterPx, outerDiameterPx);
                }
                mainForm.layeredCanvas.Invalidate();
            }
        }
    }
}
