using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using ThroughholePCB.Persistence;
using ThroughholePCB.Tools;

namespace ThroughholePCB
{
    public partial class MainForm : Form
    {
        const string fileFilter = "ThroughholePCB file (*.thpcb)|*.thpcb|All Files (*.*)|*.*";

        private string? currentFileName = null;
        private bool reallyCloseForm = false;

        private ITool currentTool;
        private WireTool wireTool;
        private HoleTool holeTool;
        private FreeLineTool freeLineTool;
        private ResistorTool resistorTool;

        private GridToggler gridToggler;

        public PrinterData CurrentPrinter { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            topRuler1.mainForm = this;
            leftRuler1.mainForm = this;

            gridToggler = new GridToggler(toolGridBtn, layeredCanvas.Grid);

            //initialize tools
            wireTool = new WireTool(this, toolWireBtn);
            holeTool = new HoleTool(this, toolHoleBtn);
            freeLineTool = new FreeLineTool(this, toolFreeLine);
            resistorTool = new ResistorTool(this, toolResistor);

            //populate layer dropdown;
            foreach (var n in LayerInfos.AllLayerInfos)
            {
                toolActiveLayer.Items.Add(n);
            }

            //initialize application
            New(50, 50, PrinterDatas.DefaultPrinter);

            //set wire tool as default
            SetTool(wireTool);

            FormClosing += MainForm_FormClosing;

            Shown += MainForm_Shown;
        }

        private void MainForm_Shown(object? sender, EventArgs e)
        {
            //for some reason the panel refuses to scroll to anything but the top ruler,
            //which makes it hide the left ruler till you manually scroll back
            //only solution i found was to force a dummy panel into view here. doesnt work in form.load event
            panel1.ScrollControlIntoView(panel2);
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!reallyCloseForm)
            {
                if (!Exit(sender!, e))
                {
                    e.Cancel = true;
                }
            }
        }

        [MemberNotNull(nameof(currentTool))]
        public void SetTool(ITool tool)
        {
            currentTool?.Disable(); //is null on startup
            currentTool = tool;
            propertyGrid.SelectedObject = tool;
            currentTool.Enable();
        }

        private bool Exit(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to save before exiting?", "Exit", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            else if (result == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Exit(sender, e))
            {
                reallyCloseForm = true;
                Close();
            }
        }

        [MemberNotNull(nameof(CurrentPrinter))]
        private void New(float widthMm, float heightMm, PrinterData printerData)
        {
            var widthPx = printerData.GetWidthPx(widthMm);
            var heightPx = printerData.GetHeightPx(heightMm);

            List<CanvasLayer> layers = new();
            foreach (var info in LayerInfos.AllLayerInfos)
            {
                layers.Add(new CanvasLayer(widthPx, heightPx, info.Name, info.Color));
            }

            LoadData(layers, printerData);

            wireTool.WireWidthMil = 50;
            holeTool.OuterDiameterMil = 80;
            holeTool.InnerDiameterMil = 40;
            freeLineTool.LineWidthMil = 3;

            currentFileName = null;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var newDialog = new NewDialog();
            if (newDialog.ShowDialog() == DialogResult.OK)
            {
                var printer = newDialog.SelectedPrinter;
                if (printer == null)
                {
                    throw new UnreachableException(); //shouldnt be possible
                }
                New(newDialog.BoardWidthMm, newDialog.BoardHeightMm, printer);
            }
        }

        [MemberNotNull(nameof(CurrentPrinter))]
        private void LoadData(IEnumerable<CanvasLayer> layers, PrinterData printerData)
        {
            layeredCanvas.ClearLayers();

            //load new Layers
            int width = 0, height = 0;
            foreach (var l in layers)
            {
                layeredCanvas.AddLayer(l);
                width = l.Bitmap.Width;
                height = l.Bitmap.Height;
            }
            layeredCanvas.MakeLayerActive(LayerInfos.CopperTopLayer.Name);
            toolActiveLayer.SelectedItem = LayerInfos.CopperTopLayer;

            layeredCanvas.Size = new Size(width, height);

            CurrentPrinter = printerData;

            layeredCanvas.Grid.SpacingX = printerData.PixelsPerMmX * 2.54f;
            layeredCanvas.Grid.SpacingY = printerData.PixelsPerMmY * 2.54f;

            leftRuler1.Height = layeredCanvas.Height;
            topRuler1.Width = layeredCanvas.Width;

            toolStripStatusLabel.Text = $"{printerData.Name} {width}x{height}";
        }

        private void Save()
        {
            if (currentFileName == null)
            {
                throw new InvalidOperationException();
            }

            var file = new ThpcbFile();
            file.PrinterData = CurrentPrinter;
            file.Layers = layeredCanvas.Layers;
            try
            {
                file.WriteTo(currentFileName);
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Error Saving file: " + e.Message);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFileName == null)
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                Save();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog();
            sfd.Filter = fileFilter;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                currentFileName = sfd.FileName;
                Save();
            }
        }

        private void ToolGridBtn_Click(object sender, EventArgs e)
        {
            toolGridBtn.Checked = layeredCanvas.Grid.Enabled = !layeredCanvas.Grid.Enabled;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = fileFilter;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFileName = ofd.FileName;
                var file = new ThpcbFile();
                try
                {
                    file.ReadFrom(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading file:\n" + ex);
                    return;
                }
                LoadData(file.Layers, file.PrinterData);
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var folderName = Path.Combine(Path.GetDirectoryName(currentFileName), Path.GetFileNameWithoutExtension(currentFileName));
            Directory.CreateDirectory(folderName);
            Console.WriteLine(folderName);

            string[] mirroredLayers = [LayerInfos.CopperTopLayer.Name, LayerInfos.SilkScreenTop.Name];

            int w = CurrentPrinter.DisplayWidthPx;
            int h = CurrentPrinter.DisplayHeightPx;
            List<string> imagesToConvert = new();
            using var printerScreen = new Bitmap(w, h, PixelFormat.Format32bppArgb);
            using var g = Graphics.FromImage(printerScreen);
            foreach (var layer in layeredCanvas.Layers)
            {
                g.Clear(Color.Black);
                using var mask = ImageUtil.CreateMask(layer.Bitmap);
                if (mirroredLayers.Contains(layer.Name))
                {
                    g.DrawImage(mask, mask.Width, 0, -mask.Width, mask.Height); //flip image for exposure
                }
                else
                {
                    g.DrawImage(mask, 0, 0, mask.Width, mask.Height);
                }
                g.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);

                var imageName = Path.Combine(folderName, layer.Name + ".png");
                printerScreen.Save(imageName);
                imagesToConvert.Add(imageName);
            }

            //alignment masks
            {
                using var alignmentMask = new Bitmap(layeredCanvas.CanvasWidth, layeredCanvas.CanvasHeight, PixelFormat.Format32bppArgb);
                using var ag = Graphics.FromImage(alignmentMask);
                ag.FillEllipse(Brushes.White, 8, 8, 4, 4);
                ag.FillEllipse(Brushes.White, alignmentMask.Width - 8, 8, 4, 4);
                ag.FillEllipse(Brushes.White, alignmentMask.Width - 8, alignmentMask.Height - 8, 4, 4);
                ag.FillEllipse(Brushes.White, 8, alignmentMask.Height - 8, 4, 4);

                g.Clear(Color.Black);
                g.DrawImage(alignmentMask, 0, 0, alignmentMask.Width, alignmentMask.Height);
                g.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
                var imageName = Path.Combine(folderName, "alignment.png");
                printerScreen.Save(imageName);
                imagesToConvert.Add(imageName);
                //dont have to flip cause its symmetrical. might need something more advanced if this proves error prone
            }

            //TODO: this is just a crutch for converting to my printers format. actually determine format by printer type in the future
            List<Process> processes = new();
            foreach (var img in imagesToConvert)
            {
                var psi = new ProcessStartInfo();
                psi.FileName = Path.GetFullPath("ImageToPrinter\\ImageToPrinter.exe");
                psi.ArgumentList.Add(img);
                var p = Process.Start(psi) ?? throw new Exception("no process");
                processes.Add(p);
            }
            foreach (var p in processes)
            {
                p.WaitForExit();
                p.Dispose();
            }
        }

        private void ToolActiveLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var info = (LayerInfo?)toolActiveLayer.SelectedItem;
            if (info != null)
            {
                layeredCanvas.MakeLayerActive(info.Name);
                layeredCanvas.Invalidate();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.ControlKey || (keyData & Keys.Control) == Keys.Control)
            {
                gridToggler.KeyDown();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            const int WM_KEYUP = 0x0101;

            if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.ControlKey)
            {
                gridToggler.KeyUp();
                return true;
            }

            return base.ProcessKeyPreview(ref m);
        }

        private void resizeBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var resizeDialog = new ResizeDialog();
            resizeDialog.BoardWidthMm = layeredCanvas.CanvasWidth * CurrentPrinter.MmPerPixelX;
            resizeDialog.BoardHeightMm = layeredCanvas.CanvasHeight * CurrentPrinter.MmPerPixelY;
            if (resizeDialog.ShowDialog() == DialogResult.OK)
            {
                layeredCanvas.ResizeCanvas((int)(resizeDialog.BoardWidthMm * CurrentPrinter.PixelsPerMmX), (int)(resizeDialog.BoardHeightMm * CurrentPrinter.PixelsPerMmY));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.ScrollControlIntoView(panel2);
        }
    }
}
