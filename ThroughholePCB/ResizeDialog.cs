using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThroughholePCB
{
    public partial class ResizeDialog : Form
    {
        public float BoardWidthMm
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

        public float BoardHeightMm
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

        public ResizeDialog()
        {
            InitializeComponent();
        }

        private void resizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //check for parsing errors
                float w = BoardWidthMm;
                float h = BoardHeightMm;
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
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
