using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB
{
    public class GridToggler
    {
        private bool keyDown = false;

        private Form form;
        private ToolStripButton toolStripButton;
        private Grid grid;
        private Keys keyCode;

        public GridToggler(Form mainForm, ToolStripButton toolStripButton, Grid grid, Keys keyCode)
        {
            this.form = mainForm;
            this.toolStripButton = toolStripButton;
            this.grid = grid;
            this.keyCode = keyCode;

            mainForm.PreviewKeyDown += MainForm_PreviewKeyDown;
            mainForm.KeyUp += MainForm_KeyUp;
            mainForm.LostFocus += MainForm_LostFocus;
        }

        private void Up()
        {
            if (keyDown)
            {
                keyDown = false;
                grid.Enabled = !grid.Enabled;
                toolStripButton.Checked = grid.Enabled;
            }
        }

        private void Down()
        {
            if (!keyDown)
            {
                keyDown = true;
                grid.Enabled = !grid.Enabled;
                toolStripButton.Checked = grid.Enabled;
            }
        }

        private void MainForm_LostFocus(object? sender, EventArgs e)
        {
            Up();
        }

        private void MainForm_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == keyCode)
            {
                Up();
            }
        }

        private void MainForm_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == keyCode)
            {
                Down();
            }
        }
    }
}
