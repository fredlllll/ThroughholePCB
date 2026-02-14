using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public static class PrinterDatas
    {
        //TODO: move to data file?

        public static PrinterData DefaultPrinter { get { return AllPrinters[0]; } }

        public static PrinterData[] AllPrinters = {
            new()
            {
                Name = "Anycubic Mono X2",
                DisplayWidthPx = 4096,
                DisplayHeightPx = 2560,
                DisplayWidthMm = 196.61f,
                DisplayHeightMm = 122.88f,
            },
        };
    }
}
