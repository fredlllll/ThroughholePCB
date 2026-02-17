using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public class CanvasLayer : IDisposable
    {
        public bool Active { get; set; } = false;
        public Bitmap Bitmap { get; }
        public bool Visible { get; set; } = true;
        public string Name { get; set; }
        public Color LayerColor { get; set; }

        public CanvasLayer(Bitmap bitmap, string name, Color layerColor)
        {
            Bitmap = bitmap;
            Name = name;
            LayerColor = layerColor;
        }

        public CanvasLayer(int width, int height, string name, Color layerColor)
        {
            Bitmap = ImageUtil.CreateImageCleared(width, height, PixelFormat.Format32bppArgb, Color.Transparent);
            Name = name;
            LayerColor = layerColor;
        }

        public Graphics CreateGraphics()
        {
            return Graphics.FromImage(Bitmap);
        }

        public void DrawLayer(Graphics g)
        {
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cm = new ColorMatrix();
            cm.Matrix00 = LayerColor.R / 255f;
            cm.Matrix11 = LayerColor.G / 255f;
            cm.Matrix22 = LayerColor.B / 255f;
            if (!Active)
            {
                cm.Matrix33 = 0.2f;
            }
            ia.SetColorMatrix(cm);
            g.DrawImage(Bitmap, new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), 0, 0, Bitmap.Width, Bitmap.Height, GraphicsUnit.Pixel, ia);
            ia?.Dispose();
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Bitmap.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
