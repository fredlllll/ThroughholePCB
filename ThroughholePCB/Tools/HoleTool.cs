using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public class HoleTool : ToolBase
    {
        public float OuterRadius { get; set; } = 50;
        public float InnerRadius { get; set; } = 20;
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
            var pos = GetImagePos(e.Location);
            var g = mainForm.CurrentGraphics;
            var halfOuter = OuterRadius / 2;
            var halfInner = InnerRadius / 2;
            if (e.Button == MouseButtons.Left)
            {
                g.FillEllipse(holeBrush, pos.X - halfOuter, pos.Y - halfOuter, OuterRadius, OuterRadius);
                g.FillEllipse(Brushes.Black, pos.X - halfInner, pos.Y - halfInner, InnerRadius, InnerRadius);
            }
            else if (e.Button == MouseButtons.Right)
            {
                g.FillEllipse(Brushes.Black, pos.X - halfOuter, pos.Y - halfOuter, OuterRadius, OuterRadius);
            }
            mainForm.workareaPictureBox.Invalidate();
        }
    }
}
