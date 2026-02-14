using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public class PrinterData
    {
        public string Name { get; set; } = string.Empty;

        public int DisplayWidthPx { get; set; } = 1;
        public int DisplayHeightPx { get; set; } = 1;

        public float DisplayWidthMm { get; set; } = 1;
        public float DisplayHeightMm { get; set; } = 1;

        public float PixelsPerMmX
        {
            get
            {
                return DisplayWidthPx / DisplayWidthMm;
            }
        }

        public float PixelsPerMmY
        {
            get
            {
                return DisplayHeightPx / DisplayHeightMm;
            }
        }

        public float MmPerPixelX
        {
            get
            {
                return DisplayWidthMm / DisplayWidthPx;
            }
        }

        public float MmPerPixelY
        {
            get
            {
                return DisplayHeightMm / DisplayHeightPx;
            }
        }
    }
}
