using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public class LayerInfo
    {
        public string Name { get; set; } = string.Empty;
        public Color Color { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Color})";
        }
    }
}
