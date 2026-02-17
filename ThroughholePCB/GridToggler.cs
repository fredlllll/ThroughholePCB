using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public class GridToggler
    {
        private ToolStripButton toolStripButton;
        private Grid grid;
        private bool keyDown = false;

        public GridToggler(ToolStripButton toolStripButton, Grid grid)
        {
            this.toolStripButton = toolStripButton;
            this.grid = grid;
        }

        public void ToggleGrid()
        {
            grid.Enabled = !grid.Enabled;
            toolStripButton.Checked = grid.Enabled;
        }

        public void KeyUp()
        {
            if (keyDown)
            {
                keyDown = false;
                ToggleGrid();
            }
        }

        public void KeyDown()
        {
            if (!keyDown)
            {
                keyDown = true;
                ToggleGrid();
            }
        }
    }
}
