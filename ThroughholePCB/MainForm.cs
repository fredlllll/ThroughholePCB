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

        private GridToggler gridToggler;
        public Grid Grid { get; }

        public Graphics CurrentGraphics { get; private set; }
        public PrinterData CurrentPrinter { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            Grid = new Grid(workareaPictureBox);
            gridToggler = new GridToggler(this, toolGridBtn, Grid, Keys.ControlKey);

            //initialize tools
            wireTool = new WireTool(this, toolWireBtn);
            holeTool = new HoleTool(this, toolHoleBtn);

            //set wire tool as default
            currentTool = wireTool;
            wireTool.Enable();

            //initialize application
            New(50, 50, PrinterDatas.DefaultPrinter);

            FormClosing += MainForm_FormClosing;
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

        public void SetTool(ITool tool)
        {
            currentTool.Disable();
            currentTool = tool;
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

        [MemberNotNull(nameof(CurrentGraphics), nameof(CurrentPrinter))]
        private void New(float widthMm, float heightMm, PrinterData printerData)
        {
            var widthPx = (int)(printerData.PixelsPerMmX * widthMm);
            var heightPx = (int)(printerData.PixelsPerMmY * heightMm);

            var layers = new Dictionary<string, Image>()
            {
                {LayerNames.CopperTopLayer,Util.CreateImageCleared(widthPx,heightPx,PixelFormat.Format32bppArgb,Color.Black) }
            };

            LoadData(layers, printerData);

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
                New(newDialog.WidthParameter, newDialog.HeightParameter, printer);
            }
        }

        [MemberNotNull(nameof(CurrentGraphics), nameof(CurrentPrinter))]
        private void LoadData(Dictionary<string, Image> layers, PrinterData printerData)
        {
            CurrentGraphics?.Dispose(); //will be null on initial load
            var img = layers[LayerNames.CopperTopLayer];
            CurrentGraphics = Graphics.FromImage(img);
            CurrentPrinter = printerData;
            workareaPictureBox.Image = img;
            workareaPictureBox.Width = img.Width;
            workareaPictureBox.Height = img.Height;

            toolStripStatusLabel.Text = $"{printerData.Name} {img.Width}x{img.Height}";
        }

        private void Save()
        {
            if (currentFileName == null)
            {
                throw new InvalidOperationException();
            }

            var file = new ThpcbFile();
            file.PrinterData = CurrentPrinter;
            file.Layers[LayerNames.CopperTopLayer] = workareaPictureBox.Image;
            file.WriteTo(currentFileName);
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
            toolGridBtn.Checked = Grid.Enabled = !Grid.Enabled;
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
            //TODO: this is just a crutch for exporting to my printers format. actually determine format by printer type in the future
            var src = workareaPictureBox.Image;
            using var tmpImage = Util.CreateImageCleared(CurrentPrinter.DisplayWidthPx, CurrentPrinter.DisplayHeightPx,PixelFormat.Format32bppArgb,Color.Black);
            using var g = Graphics.FromImage(tmpImage);
            g.DrawImage(src, src.Width, 0, -src.Width, src.Height);
            g.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);

            tmpImage.Save("tmpout.png");

            var psi = new ProcessStartInfo();
            psi.FileName = Path.GetFullPath("ImageToPrinter\\ImageToPrinter.exe");
            psi.ArgumentList.Add("tmpout.png");
            Process.Start(psi);
        }
    }
}
