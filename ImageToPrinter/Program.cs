using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Reflection;
using UVtools.Core.FileFormats;
using UVtools.Core.Layers;
namespace ImageToPrinter
{
    public class Program
    {
        const int displayWidthPx = 4096;
        const int displayHeightPx = 2560;

        static void Main(string[] args)
        {
            string fullInputPath = Path.GetFullPath(args[0]); /*"I:\\Projects\\PCB3D\\Unbenannt.png"*/
            Console.WriteLine(fullInputPath);
            string outputPath = Path.Combine(Path.GetDirectoryName(fullInputPath)!, Path.GetFileNameWithoutExtension(fullInputPath) + ".pmx2");
            float exposureTime = 20;

            byte[] inputImage = File.ReadAllBytes(fullInputPath);
            Image<Rgba32> image = Image.Load<Rgba32>(inputImage);
            if (image.Width != displayWidthPx || image.Height != displayHeightPx)
            {
                throw new Exception("Image has wrong dimensions, needs 4096x2560");
            }

            AnycubicFile af = new AnycubicFile();
            af.FileFullPath = outputPath;
            af.LayerHeight = 0.2f;
            af.BottomLayerCount = 1;
            af.BottomExposureTime = exposureTime;
            af.ExposureTime = exposureTime;
            af.BottomLiftHeight = 0;
            af.BottomLiftHeight2 = 0;
            af.LiftHeight = 0;
            af.LiftHeight2 = 0;
            af.RetractHeight2 = -5;
            af.RetractSpeed = 60 * 10;
            af.RetractSpeed2 = 60 * 10;

            var layer = new Layer(0, inputImage, af);
            af.Add(layer);

            af.Save();

            Console.WriteLine("pixels per mm X/Y: " + (1000 / af.PixelWidthMicrons) + " / " + (1000 / af.PixelHeightMicrons));

            Console.WriteLine("File saved");
        }
    }
}
