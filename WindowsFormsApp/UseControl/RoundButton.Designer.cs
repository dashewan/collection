using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp.UseControl
{
    public partial class RoundButton : Label
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //public RoundButton()
        //{
           

        //    radius = 80;
        //    this.Size = new Size(Radius, Radius);
        //    this.FlatStyle = FlatStyle.Flat;
        //    this.BorderStyle = BorderStyle.None;
        //    //this.FlatAppearance.BorderSize = 0;
        //    this.BackgroundImage = imageEnter;
        //    this.BackgroundImageLayout = ImageLayout.Stretch;
        //    this.TextAlign = ContentAlignment.MiddleCenter;
        //}
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private Image imageEnter;
        [CategoryAttribute("外观"), BrowsableAttribute(true), ReadOnlyAttribute(false)]
        public Image ImageEnter
        {
            set
            {
                imageEnter = value;
            }
            get
            {
                return imageEnter;
            }
        }
        private int radius;//半径 
                           //圆形按钮的半径属性
        [CategoryAttribute("布局"), BrowsableAttribute(true), ReadOnlyAttribute(false)]
        public int Radius
        {
            set
            {
                radius = value;
                this.Size = new Size(radius, radius);
            }
            get
            {
                return radius;
            }
        }
        //重写OnSizeChanged
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (Height != Radius)
            {
                Radius = Width = Height;
            }
            else if (Width != Radius)
            {
                Radius = Height = Width;
            }

        }
        //重写OnPaint
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //Brush b=Brushes.go
            Pen pen = new Pen(Brushes.Gold, 5);
            e.Graphics.DrawEllipse(pen, 2, 2, Radius - 4, Radius - 4);
            pen.Dispose();
            path.AddEllipse(2, 2, Radius - 4, Radius - 4);
            this.Region = new Region(path);
            path.Dispose();
            //this.FlatStyle = FlatStyle.Popup;
            //this.BorderStyle = BorderStyle.FixedSingle;

        }
        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoundButton
            // 
            this.radius = 80;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Size = new System.Drawing.Size(radius, radius);
            this.ResumeLayout(false);
        }
        #endregion
    }
}
