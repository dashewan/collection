using MaterialSkin;
using MaterialSkin.Controls;
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
            //var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
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
        public delegate string dd(string a1, string a2);
        private void button2_Click(object sender, EventArgs e)
        {
            //LayoutMdi(MdiLayout.TileVertical);
            FlowLayoutForm flowLayout = new FlowLayoutForm();
            flowLayout.Show();
            //Action<string,string> action = MessageShow;
            dd d1 = new dd(MessageShow);
           IAsyncResult result= flowLayout.BeginInvoke(d1, "aa", "bbb");
           object obj= flowLayout.EndInvoke(result);
        }
        public string  MessageShow(string a1,string a2)
        {
            MessageBox.Show(a1 + a2);
            return "dddd";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //LayoutMdi(MdiLayout.Cascade);
            ProcessControl process = new ProcessControl();
            process.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //skinEngine1.SkinFile = System.Environment.CurrentDirectory + "\\Skins\\Eighteen\\Eighteen.ssk";  //选择皮肤文件
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //if (e. == MouseButtons.Right)
            //{
            //    toolStripContainer1.Show();
            //}

            //if (e.Button == MouseButtons.Left)
            //{
            //    this.Visible = true;
            //    this.WindowState = FormWindowState.Normal;
            //}
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
            }
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                // Form1 form1=(Form1)this.ParentForm;
                //隐藏任务栏区图标
                //form1.ShowInTaskbar = false;
          
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            WebBrower web = new WebBrower();
            web.Show();
        }

        private void btnDelegate_Click(object sender, EventArgs e)
        {
            DelegateForm delegateForm = new DelegateForm();
            delegateForm.Show();
        }
    }
}
