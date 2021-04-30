namespace WindowsFormsApp.UseControl
{
    partial class Circle
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Circle));
            this.roundButton1 = new WindowsFormsApp.UseControl.RoundButton(this.components);
            this.lblData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.Tomato;
            resources.ApplyResources(this.roundButton1, "roundButton1");
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.ImageEnter = null;
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Radius = 152;
            // 
            // lblData
            // 
            resources.ApplyResources(this.lblData, "lblData");
            this.lblData.BackColor = System.Drawing.Color.Tomato;
            this.lblData.Name = "lblData";
            // 
            // circle
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.roundButton1);
            this.Name = "circle";
            this.Load += new System.EventHandler(this.circle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundButton roundButton1;
        private System.Windows.Forms.Label lblData;
    }
}
