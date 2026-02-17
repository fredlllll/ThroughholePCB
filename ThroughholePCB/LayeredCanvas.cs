using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public class LayeredCanvas : Control
    {
        private readonly List<CanvasLayer> layers = new();
        public readonly Grid Grid;

        public IEnumerable<CanvasLayer> Layers { get { return layers; } }

        public int CanvasWidth { get { return layers.FirstOrDefault()?.Bitmap?.Width ?? 0; } }
        public int CanvasHeight { get { return layers.FirstOrDefault()?.Bitmap?.Height ?? 0; } }

        public CanvasLayer? ActiveLayer { get { return layers.Where(x => x.Active).FirstOrDefault(); } }

        public void AddLayer(CanvasLayer layer)
        {
            if (layers.Count == 0)
            {
                layer.Active = true;
            }
            layers.Add(layer);
        }

        public CanvasLayer? GetLayer(string name)
        {
            foreach (var layer in layers)
            {
                if (layer.Name == name)
                {
                    return layer;
                }
            }
            return null;
        }

        public void ClearLayers()
        {
            foreach (var layer in layers)
            {
                layer.Dispose();
            }
            layers.Clear();
        }

        public void MakeLayerActive(string name)
        {
            CanvasLayer? toMakeActive = null;
            List<CanvasLayer> toMakeInactive = new();
            foreach (var layer in layers)
            {
                if (layer.Name == name)
                {
                    toMakeActive = layer;
                }
                else if (layer.Active)
                {
                    toMakeInactive.Add(layer);
                }
            }
            if (toMakeActive != null)
            {
                foreach (var layer in toMakeInactive)
                {
                    layer.Active = false;
                }
                toMakeActive.Active = true;
            }
        }

        public LayeredCanvas()
        {
            Grid = new Grid(this);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            foreach (var layer in Layers)
            {
                layer.DrawLayer(e.Graphics);
            }
            Grid.Draw(e.Graphics, CanvasWidth, CanvasHeight);
            base.OnPaint(e); //just calls the paint event handler
        }

        public void ResizeCanvas(int widthPx, int heightPx)
        {
            foreach (var layer in Layers)
            {
                layer.Resize(widthPx, heightPx);
            }
            Width = widthPx;
            Height = heightPx;
            Invalidate();
        }
    }
}
