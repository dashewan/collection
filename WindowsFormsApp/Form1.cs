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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChildForm2 child = new ChildForm2();
            child.MdiParent = this;
          
            //child.WindowState = FormWindowState.Normal;
            child.WindowState = FormWindowState.Maximized;
            child.Show();
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = System.Environment.CurrentDirectory + "\\Skins\\Eighteen\\Eighteen.ssk";  //选择皮肤文件
        }
    }
}
