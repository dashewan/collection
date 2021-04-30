using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.UseControl
{
    public partial class Circle : UserControl
    {
        public Circle()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
          
                roundButton1.ForeColor = Color.Blue;
            lblData.ForeColor = Color.Black;
            lblData.BackColor = roundButton1.BackColor;
            lblData.Width = this.Width - 50;
            lblData.Left = (this.Width - lblData.Width) / 2 - 2;
            lblData.Top = this.Width / 2 - 35;







        }

        private void circle_Load(object sender, EventArgs e)
        {
            this.Width = this.Height;
            roundButton1.Radius = this.Width;
            roundButton1.Top = 0;
            roundButton1.Left = 0;
            lblData.BackColor = roundButton1.BackColor;
            lblData.Width = this.Width - 50;
            lblData.Left = (this.Width - lblData.Width) / 2 - 2;
            lblData.Top = this.Width / 2 - 35;
        }
      
    }
}
