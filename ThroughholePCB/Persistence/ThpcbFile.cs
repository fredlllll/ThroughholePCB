using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThroughholePCB.Persistence
{
    public class ThpcbFile
    {
        public const int currentVersion = 1;

        public Dictionary<string, Image> Layers { get; set; } = new Dictionary<string, Image>();
        public PrinterData PrinterData { get; set; } = null!;

        class ExtraInfo
        {
            public int Version { get; set; } = 1;

            public string PrinterName { get; set; } = string.Empty;

            public int PrinterDisplayWidthPx { get; set; }
            public int PrinterDisplayHeightPx { get; set; }

            public float PrinterDisplayWidthMm { get; set; }
            public float PrinterDisplayHeightMm { get; set; }

            public string[] LayerNames { get; set; } = Array.Empty<string>();
        }

        public void WriteTo(string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            WriteTo(fs);
        }

        public void WriteTo(Stream stream)
        {
            using var zip = new ZipArchive(stream, ZipArchiveMode.Create, true);

            foreach (var kv in Layers)
            {
                var layerEntry = zip.CreateEntry(kv.Key + ".png", CompressionLevel.NoCompression);
                using (var layerStream = layerEntry.Open())
                {
                    kv.Value.Save(layerStream, System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            var extraInfo = new ExtraInfo()
            {
                Version = currentVersion,
                PrinterName = PrinterData.Name,
                PrinterDisplayWidthPx = PrinterData.DisplayWidthPx,
                PrinterDisplayHeightPx = PrinterData.DisplayHeightPx,
                PrinterDisplayWidthMm = PrinterData.DisplayWidthMm,
                PrinterDisplayHeightMm = PrinterData.DisplayHeightMm,
                LayerNames = Layers.Keys.ToArray(),
            };
            var opt = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            var extraInfoEntry = zip.CreateEntry("data.json", CompressionLevel.Optimal);
            using (var dataStream = extraInfoEntry.Open())
            {
                JsonSerializer.Serialize(dataStream, extraInfo, opt);
            }
        }

        public void ReadFrom(string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            ReadFrom(fs);
        }

        public void ReadFrom(Stream stream)
        {
            using var zip = new ZipArchive(stream, ZipArchiveMode.Read, true);

            var extraInfoEntry = zip.GetEntry("data.json") ?? throw new InvalidDataException();
            ExtraInfo extraInfo;
            using (var dataStream = extraInfoEntry.Open())
            {
                extraInfo = JsonSerializer.Deserialize<ExtraInfo>(dataStream) ?? throw new InvalidDataException();
            }

            if (extraInfo.Version < currentVersion)
            {
                //TODO: upgrade version
            }
            else if (extraInfo.Version > currentVersion)
            {
                throw new InvalidDataException("This file was saved with a newer version of this program");
            }

            PrinterData = new PrinterData()
            {
                Name = extraInfo.PrinterName,
                DisplayWidthPx = extraInfo.PrinterDisplayWidthPx,
                DisplayHeightPx = extraInfo.PrinterDisplayHeightPx,
                DisplayWidthMm = extraInfo.PrinterDisplayWidthMm,
                DisplayHeightMm = extraInfo.PrinterDisplayHeightMm,
            };

            Layers = new Dictionary<string, Image>();
            foreach (var layerName in extraInfo.LayerNames)
            {
                var layerEntry = zip.GetEntry(layerName + ".png") ?? throw new InvalidDataException();
                using (var layerStream = layerEntry.Open())
                {
                    Layers[layerName] = new Bitmap(layerStream);
                }
            }
        }
    }
}
