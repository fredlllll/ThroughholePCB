using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ThroughholePCB
{
    public partial class NewDialog : Form
    {
        const float defaultWidth = 50f;
        const float defaultHeight = 50f;

        public NewDialog()
        {
            InitializeComponent();
            

            for(int i =0;i< PrinterDatas.AllPrinters.Length; ++i)
            {
                var p = PrinterDatas.AllPrinters[i];
                printerDropdown.Items.Add(p.Name);
            }
            printerDropdown.SelectedIndex = 0;
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            WidthParameter = defaultWidth;
            HeightParameter = defaultHeight;
            SelectedPrinter = null;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //check for parsing errors
                float w = WidthParameter;
                float h = HeightParameter;
                SelectedPrinter = PrinterDatas.AllPrinters[printerDropdown.SelectedIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Check formatting and stuff");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            LoadDefaults();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public float WidthParameter
        {
            get
            {
                return float.Parse(widthTxt.Text, CultureInfo.InvariantCulture);
            }
            set
            {
                widthTxt.Text = value.ToString(CultureInfo.InvariantCulture);
            }
        }

        public float HeightParameter
        {
            get
            {
                return float.Parse(heightTxt.Text, CultureInfo.InvariantCulture);
            }
            set
            {
                heightTxt.Text = value.ToString(CultureInfo.InvariantCulture);
            }
        }

        public PrinterData? SelectedPrinter { get; set; } = null;
    }
}
