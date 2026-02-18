using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThroughholePCB
{
    public partial class TextToolDialog : Form
    {
        public float FontSize
        {
            get
            {
                return (float)fontSizeNum.Value;
            }
            set
            {
                fontSizeNum.Value = (decimal)value;
            }
        }

        public string UserText
        {
            get
            {
                return text.Text;
            }
            set { text.Text = value; }
        }

        public TextToolDialog()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
