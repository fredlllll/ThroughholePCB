using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public enum RulerMode
    {
        Mil,
        Mm
    }

    public abstract class BaseRuler :Control
    {
        public MainForm? mainForm;
        public RulerMode Mode { get; set; } = RulerMode.Mm;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (Mode == RulerMode.Mm)
            {
                Mode = RulerMode.Mil;
            }
            else
            {
                Mode = RulerMode.Mm;
            }
            Invalidate();
            base.OnMouseClick(e);
        }
    }
}
