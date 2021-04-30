using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FlowLayoutForm : Form
    {
        public FlowLayoutForm()
        {
            InitializeComponent();
        }

        private void rdbFlowDirection_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.FlowDirection= FlowDirection.TopDown;
        }

        private void rdbUP_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
        }
    }
}
