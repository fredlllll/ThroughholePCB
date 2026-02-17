using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public static class LayerInfos
    {
        public static readonly LayerInfo CopperTopLayer = new LayerInfo()
        {
            Name = "copperTop",
            Color = Color.Salmon
        };
        public static readonly LayerInfo CopperBottomLayer = new LayerInfo()
        {
            Name = "copperBottom",
            Color = Color.Red
        };
        public static readonly LayerInfo SilkScreenTop = new LayerInfo()
        {
            Name = "silkscreenTop",
            Color = Color.White
        };
        public static readonly LayerInfo SilkScreenBottom = new LayerInfo()
        {
            Name = "silkscreenBottom",
            Color = Color.Gray
        };

        //in drawing order
        public static readonly LayerInfo[] AllLayerInfos = [
            SilkScreenBottom,
            CopperBottomLayer,
            CopperTopLayer,
            SilkScreenTop,
        ];
    }
}
