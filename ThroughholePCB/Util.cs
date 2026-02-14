using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public static class Util
    {
        public static Bitmap CreateImageCleared(int width,int height, PixelFormat pixelFormat, Color backgroundColor)
        {
            Bitmap bmp = new Bitmap(width, height, pixelFormat);
            using var g = Graphics.FromImage(bmp);
            g.Clear(backgroundColor);
            g.Flush(FlushIntention.Sync);
            return bmp;
        }
    }
}
