using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public static class ImageUtil
    {
        public static Bitmap CreateImageCleared(int width, int height, PixelFormat pixelFormat, Color backgroundColor)
        {
            Bitmap bmp = new Bitmap(width, height, pixelFormat);
            using var g = Graphics.FromImage(bmp);
            g.Clear(backgroundColor);
            g.Flush(FlushIntention.Sync);
            return bmp;
        }

        /// <summary>
        /// takes a colored image and turns every non black pixel to white. returns a new image
        /// </summary>
        /// <param name="source"></param>
        public static Bitmap CreateMask(Bitmap source)
        {
            if (source.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new ArgumentException("only 32bit ARGB supported");
            }

            int w = source.Width;
            int h = source.Height;
            int numPixels = w * h;

            Bitmap dest = new Bitmap(w, h, PixelFormat.Format32bppArgb);

            var rect = new Rectangle(0, 0, w, h);

            var srcData = source.LockBits(rect, ImageLockMode.ReadOnly, source.PixelFormat);
            var dstData = dest.LockBits(rect, ImageLockMode.WriteOnly, dest.PixelFormat);
            uint blackPixel = 0xFF000000; //ABGR
            uint whitePixel = 0xFFFFFFFF;
            if (!BitConverter.IsLittleEndian)
            {
                //i am assured by AI that its always in little endian, but who knows if you can trust this
                blackPixel = 0x000000FF; //RGBA
            }
            bool noPadding = (srcData.Stride == w * 4) && (dstData.Stride == w * 4);

            unsafe
            {
                if (noPadding)
                {
                    //no padding, all pixels essentially in one array
                    uint* src = (uint*)srcData.Scan0;
                    uint* dst = (uint*)dstData.Scan0;
                    uint* srcEnd = src + numPixels;
                    while (src < srcEnd)
                    {
                        if (*src == blackPixel)
                        {
                            *dst = blackPixel;
                        }
                        else
                        {
                            *dst = whitePixel;
                        }
                        src++;
                        dst++;
                    }
                }
                else
                {
                    //rows are padded, have to use row based approach
                    for (int y = 0; y < h; y++)
                    {
                        uint* src = (uint*)(srcData.Scan0 + (y * srcData.Stride));
                        uint* dst = (uint*)(dstData.Scan0 + (y * dstData.Stride));
                        uint* srcEnd = src + w;

                        while (src < srcEnd)
                        {
                            if (*src == blackPixel)
                            {
                                *dst = blackPixel;
                            }
                            else
                            {
                                *dst = whitePixel;
                            }
                            src++;
                            dst++;
                        }
                    }
                }
            }

            source.UnlockBits(srcData);
            dest.UnlockBits(dstData);

            return dest;
        }
    }
}
