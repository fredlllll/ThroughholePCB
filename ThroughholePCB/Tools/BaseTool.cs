using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public abstract class BaseTool : ITool
    {
        protected MainForm mainForm;
        protected ToolStripButton button;

        protected PrinterData CurrentPrinter
        {
            get { return mainForm.CurrentPrinter; }
        }

        protected float PixelsPerMm
        {
            get
            {
                return (CurrentPrinter.PixelsPerMmX + CurrentPrinter.PixelsPerMmY) / 2;
            }
        }

        protected float MmPerPixel
        {
            get
            {
                return (CurrentPrinter.MmPerPixelX + CurrentPrinter.MmPerPixelY) / 2;
            }
        }

        public BaseTool(MainForm mainForm, ToolStripButton button)
        {
            this.mainForm = mainForm;
            this.button = button;
            button.Click += Button_Click;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            mainForm.SetTool(this);
        }

        protected float MilToPixels(float mil)
        {
            return mil / 1000 * mainForm.CurrentPrinter.PixelsPerMmX * 25.4f;
        }

        protected float PixelsToMil(float pixels)
        {
            return (pixels / 25.4f / mainForm.CurrentPrinter.PixelsPerMmX) * 1000;
        }

        public virtual void Enable()
        {
            mainForm.layeredCanvas.MouseDown += WorkareaPictureBox_MouseDown;
            mainForm.layeredCanvas.MouseUp += WorkareaPictureBox_MouseUp;
            mainForm.layeredCanvas.MouseMove += WorkareaPictureBox_MouseMove;
            mainForm.layeredCanvas.Paint += WorkareaPictureBox_Paint;
            button.Checked = true;
        }

        public virtual void Disable()
        {
            mainForm.layeredCanvas.MouseDown -= WorkareaPictureBox_MouseDown;
            mainForm.layeredCanvas.MouseUp -= WorkareaPictureBox_MouseUp;
            mainForm.layeredCanvas.MouseMove -= WorkareaPictureBox_MouseMove;
            mainForm.layeredCanvas.Paint -= WorkareaPictureBox_Paint;
            button.Checked = false;
        }
        protected virtual void WorkareaPictureBox_MouseDown(object? sender, MouseEventArgs e)
        {

        }

        protected virtual void WorkareaPictureBox_MouseMove(object? sender, MouseEventArgs e)
        {

        }

        protected virtual void WorkareaPictureBox_MouseUp(object? sender, MouseEventArgs e)
        {

        }

        protected virtual void WorkareaPictureBox_Paint(object? sender, PaintEventArgs e)
        {

        }
    }
}
