using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class Parameters : Form
    {
        public double val;
        public static string label;

        public Parameters()
        {
            InitializeComponent();
            this.label1.Text = label;
        }

        public void SetLabel(string text)
        {
            this.label1.Text = text;
        }

        private void OK(object sender, EventArgs e)
        {
            this.val = double.Parse(this.inputValue.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
