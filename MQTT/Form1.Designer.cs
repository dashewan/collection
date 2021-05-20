namespace MQTT
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSendOperate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOperateTopic = new System.Windows.Forms.TextBox();
            this.txtOperateJson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExcetpionJson = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExcetionSend = new System.Windows.Forms.Button();
            this.txtHoleJson = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHoleSend = new System.Windows.Forms.Button();
            this.txtExcetpionTopic = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHoleTopic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.btnTimeSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(753, 118);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(726, 613);
            this.listBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(970, 118);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 63);
            this.button2.TabIndex = 2;
            this.button2.Text = "断开";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSendOperate
            // 
            this.btnSendOperate.Location = new System.Drawing.Point(753, 526);
            this.btnSendOperate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSendOperate.Name = "btnSendOperate";
            this.btnSendOperate.Size = new System.Drawing.Size(154, 41);
            this.btnSendOperate.TabIndex = 3;
            this.btnSendOperate.Text = "发送";
            this.btnSendOperate.UseVisualStyleBackColor = true;
            this.btnSendOperate.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(750, 245);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "主题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(750, 345);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "常规数据项";
            // 
            // txtOperateTopic
            // 
            this.txtOperateTopic.Location = new System.Drawing.Point(753, 285);
            this.txtOperateTopic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOperateTopic.Name = "txtOperateTopic";
            this.txtOperateTopic.Size = new System.Drawing.Size(131, 27);
            this.txtOperateTopic.TabIndex = 6;
            this.txtOperateTopic.Text = "001/Operate";
            // 
            // txtOperateJson
            // 
            this.txtOperateJson.Location = new System.Drawing.Point(753, 387);
            this.txtOperateJson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOperateJson.Multiline = true;
            this.txtOperateJson.Name = "txtOperateJson";
            this.txtOperateJson.Size = new System.Drawing.Size(154, 102);
            this.txtOperateJson.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(902, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "断开连接";
            // 
            // txtExcetpionJson
            // 
            this.txtExcetpionJson.Location = new System.Drawing.Point(953, 387);
            this.txtExcetpionJson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExcetpionJson.Multiline = true;
            this.txtExcetpionJson.Name = "txtExcetpionJson";
            this.txtExcetpionJson.Size = new System.Drawing.Size(154, 102);
            this.txtExcetpionJson.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(950, 345);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "异常数据项";
            // 
            // btnExcetionSend
            // 
            this.btnExcetionSend.Location = new System.Drawing.Point(953, 526);
            this.btnExcetionSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcetionSend.Name = "btnExcetionSend";
            this.btnExcetionSend.Size = new System.Drawing.Size(154, 41);
            this.btnExcetionSend.TabIndex = 9;
            this.btnExcetionSend.Text = "发送";
            this.btnExcetionSend.UseVisualStyleBackColor = true;
            this.btnExcetionSend.Click += new System.EventHandler(this.btnExcetionSend_Click);
            // 
            // txtHoleJson
            // 
            this.txtHoleJson.Location = new System.Drawing.Point(1159, 387);
            this.txtHoleJson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHoleJson.Multiline = true;
            this.txtHoleJson.Name = "txtHoleJson";
            this.txtHoleJson.Size = new System.Drawing.Size(154, 102);
            this.txtHoleJson.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1156, 345);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "格口数据项";
            // 
            // btnHoleSend
            // 
            this.btnHoleSend.Location = new System.Drawing.Point(1159, 526);
            this.btnHoleSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHoleSend.Name = "btnHoleSend";
            this.btnHoleSend.Size = new System.Drawing.Size(154, 41);
            this.btnHoleSend.TabIndex = 12;
            this.btnHoleSend.Text = "发送";
            this.btnHoleSend.UseVisualStyleBackColor = true;
            this.btnHoleSend.Click += new System.EventHandler(this.btnHoleSend_Click);
            // 
            // txtExcetpionTopic
            // 
            this.txtExcetpionTopic.Location = new System.Drawing.Point(953, 285);
            this.txtExcetpionTopic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExcetpionTopic.Name = "txtExcetpionTopic";
            this.txtExcetpionTopic.Size = new System.Drawing.Size(131, 27);
            this.txtExcetpionTopic.TabIndex = 16;
            this.txtExcetpionTopic.Text = "001/Excetpion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(950, 245);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "主题";
            // 
            // txtHoleTopic
            // 
            this.txtHoleTopic.Location = new System.Drawing.Point(1182, 285);
            this.txtHoleTopic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHoleTopic.Name = "txtHoleTopic";
            this.txtHoleTopic.Size = new System.Drawing.Size(131, 27);
            this.txtHoleTopic.TabIndex = 18;
            this.txtHoleTopic.Text = "001/Chute";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1179, 245);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "主题";
            // 
            // timerSend
            // 
            this.timerSend.Interval = 2000;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // btnTimeSend
            // 
            this.btnTimeSend.Location = new System.Drawing.Point(1199, 118);
            this.btnTimeSend.Name = "btnTimeSend";
            this.btnTimeSend.Size = new System.Drawing.Size(138, 63);
            this.btnTimeSend.TabIndex = 19;
            this.btnTimeSend.Text = "定时发送";
            this.btnTimeSend.UseVisualStyleBackColor = true;
            this.btnTimeSend.Click += new System.EventHandler(this.btnTimeSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 613);
            this.Controls.Add(this.btnTimeSend);
            this.Controls.Add(this.txtHoleTopic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtExcetpionTopic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHoleJson);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHoleSend);
            this.Controls.Add(this.txtExcetpionJson);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExcetionSend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOperateJson);
            this.Controls.Add(this.txtOperateTopic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendOperate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "MQTT测试";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSendOperate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOperateTopic;
        private System.Windows.Forms.TextBox txtOperateJson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExcetpionJson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExcetionSend;
        private System.Windows.Forms.TextBox txtHoleJson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHoleSend;
        private System.Windows.Forms.TextBox txtExcetpionTopic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHoleTopic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.Button btnTimeSend;
    }
}

