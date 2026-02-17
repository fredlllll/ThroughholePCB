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

        public IEnumerable<CanvasLayer> Layers { get; set; } = new List<CanvasLayer>();
        public PrinterData PrinterData { get; set; } = null!;

        class ExtraInfo
        {
            public int Version { get; set; } = 1;

            public string PrinterName { get; set; } = string.Empty;

            public int PrinterDisplayWidthPx { get; set; }
            public int PrinterDisplayHeightPx { get; set; }

            public float PrinterDisplayWidthMm { get; set; }
            public float PrinterDisplayHeightMm { get; set; }

            public int CanvasWidth { get; set; }
            public int CanvasHeight { get; set; }

            public List<ExtraLayerInfo> LayerInfos { get; set; } = new();
            //public string[] LayerNames { get; set; } = Array.Empty<string>();
            //public Dictionary<string, Color> LayerColors { get; set; } = new Dictionary<string, Color>();
        }

        class ExtraLayerInfo
        {
            public string Name { get; set; } = string.Empty;
            public string Color { get; set; } = string.Empty;
        }

        public void WriteTo(string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            WriteTo(fs);
        }

        public void WriteTo(Stream stream)
        {
            using var zip = new ZipArchive(stream, ZipArchiveMode.Create, true);

            List<ExtraLayerInfo> layerInfos = new List<ExtraLayerInfo>();
            foreach (var l in Layers)
            {
                var layerEntry = zip.CreateEntry(l.Name + ".png", CompressionLevel.NoCompression);
                using (var layerStream = layerEntry.Open())
                {
                    l.Bitmap.Save(layerStream, System.Drawing.Imaging.ImageFormat.Png);
                }
                var li = new ExtraLayerInfo()
                {
                    Name = l.Name,
                    Color = l.LayerColor.ToArgb().ToString("X4")
                };
                layerInfos.Add(li);
            }

            var extraInfo = new ExtraInfo()
            {
                Version = currentVersion,
                PrinterName = PrinterData.Name,
                PrinterDisplayWidthPx = PrinterData.DisplayWidthPx,
                PrinterDisplayHeightPx = PrinterData.DisplayHeightPx,
                PrinterDisplayWidthMm = PrinterData.DisplayWidthMm,
                PrinterDisplayHeightMm = PrinterData.DisplayHeightMm,
                CanvasWidth = Layers.First().Bitmap.Width,
                CanvasHeight = Layers.First().Bitmap.Height,
                LayerInfos = layerInfos,
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

            var layers = new List<CanvasLayer>();
            foreach (var layerInfo in extraInfo.LayerInfos)
            {
                var layerEntry = zip.GetEntry(layerInfo.Name + ".png") ?? throw new InvalidDataException();
                Bitmap bmp;
                using (var layerStream = layerEntry.Open())
                {
                    bmp = new Bitmap(layerStream);
                }
                var color = Color.FromArgb(int.Parse(layerInfo.Color, System.Globalization.NumberStyles.HexNumber));
                var cl = new CanvasLayer(bmp, layerInfo.Name, color);
                layers.Add(cl);
            }
            Layers = layers;
        }
    }
}
