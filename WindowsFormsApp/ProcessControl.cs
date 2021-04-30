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
    public partial class ProcessControl : Form
    {
        public ProcessControl()
        {
            InitializeComponent();
        }

        private void ProcessControl_Load(object sender, EventArgs e)
        {
            // 设置要启动的应用程序
            process1.StartInfo.FileName = "notepad.exe";

        }

        private void btnStartProcess_Click(object sender, EventArgs e)
        {
            // 启动记事本进程
            process1.Start();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 声明一个进程数组
            System.Diagnostics.Process[] myProcess;
            // 获取当前的所有记事本进程
            myProcess = System.Diagnostics.Process.GetProcessesByName("Notepad");
            // 循环遍历数组中的每个元素
            foreach (System.Diagnostics.Process instance in myProcess)
            {
                // 关闭拥有用户界面的进程
                instance.CloseMainWindow();
                // 在指定的时间内等待关联进程的退出
                instance.WaitForExit(3000);
                // 释放与此组件相关联的所有资源
                instance.Close();
            }
        }
    }
}
