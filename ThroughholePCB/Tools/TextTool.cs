using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public class TextTool : ABToolBase
    {
        string lastText = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        Font font;
        Brush brush = Brushes.White;
        TextToolDialog dialog = new TextToolDialog();

        public TextTool(MainForm mainForm, ToolStripButton button) : base(mainForm, button)
        {

        }

        protected override void DrawPreview(Graphics g)
        {
            if (font == null)
            {
                font = new Font(FontFamily.GenericMonospace, PixelsPerMm * 4);
            }
            DrawingUtil.DrawRotatedText(g, lastText, font, brush, startPos, endPos);
        }

        protected override void DrawFinal(Graphics g)
        {
            var result = dialog.ShowDialog();
            font?.Dispose();
            font = new Font(FontFamily.GenericMonospace, dialog.FontSize * PixelsPerMm * 2);
            lastText = dialog.UserText;
            if (result == DialogResult.OK)
            {
                DrawingUtil.DrawRotatedText(g, lastText, font, brush, startPos, endPos);
            }
        }
    }
}
