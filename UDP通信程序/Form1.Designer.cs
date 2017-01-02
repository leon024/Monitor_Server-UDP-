namespace UDP通信程序
{
    partial class UDPserverForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxSend = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRe = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxPortNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdatePortNumber = new System.Windows.Forms.Button();
            this.textBoxRemotePort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHostIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRemoteIp = new System.Windows.Forms.TextBox();
            this.checkBoxAppointIp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // richTextBoxSend
            // 
            this.richTextBoxSend.Location = new System.Drawing.Point(12, 201);
            this.richTextBoxSend.Name = "richTextBoxSend";
            this.richTextBoxSend.Size = new System.Drawing.Size(327, 96);
            this.richTextBoxSend.TabIndex = 0;
            this.richTextBoxSend.Text = "";
            this.richTextBoxSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxSend_KeyDown);
            this.richTextBoxSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBoxSend_KeyDown);
            // 
            // richTextBoxRe
            // 
            this.richTextBoxRe.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxRe.Location = new System.Drawing.Point(13, 13);
            this.richTextBoxRe.Name = "richTextBoxRe";
            this.richTextBoxRe.ReadOnly = true;
            this.richTextBoxRe.Size = new System.Drawing.Size(326, 169);
            this.richTextBoxRe.TabIndex = 1;
            this.richTextBoxRe.Text = "";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(264, 303);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "发送(回车)";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(171, 303);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxPortNumber
            // 
            this.textBoxPortNumber.Location = new System.Drawing.Point(528, 27);
            this.textBoxPortNumber.Name = "textBoxPortNumber";
            this.textBoxPortNumber.Size = new System.Drawing.Size(61, 21);
            this.textBoxPortNumber.TabIndex = 4;
            this.textBoxPortNumber.Text = "10101";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "本地端口：";
            // 
            // buttonUpdatePortNumber
            // 
            this.buttonUpdatePortNumber.Location = new System.Drawing.Point(528, 54);
            this.buttonUpdatePortNumber.Name = "buttonUpdatePortNumber";
            this.buttonUpdatePortNumber.Size = new System.Drawing.Size(61, 23);
            this.buttonUpdatePortNumber.TabIndex = 6;
            this.buttonUpdatePortNumber.Text = "修改";
            this.buttonUpdatePortNumber.UseVisualStyleBackColor = true;
            this.buttonUpdatePortNumber.Click += new System.EventHandler(this.buttonUpdatePortNumber_Click);
            // 
            // textBoxRemotePort
            // 
            this.textBoxRemotePort.Location = new System.Drawing.Point(528, 140);
            this.textBoxRemotePort.Name = "textBoxRemotePort";
            this.textBoxRemotePort.ReadOnly = true;
            this.textBoxRemotePort.Size = new System.Drawing.Size(63, 21);
            this.textBoxRemotePort.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(526, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "对方端口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "本地IP：";
            // 
            // textBoxHostIp
            // 
            this.textBoxHostIp.Location = new System.Drawing.Point(360, 26);
            this.textBoxHostIp.Name = "textBoxHostIp";
            this.textBoxHostIp.ReadOnly = true;
            this.textBoxHostIp.Size = new System.Drawing.Size(146, 21);
            this.textBoxHostIp.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "对方IP：";
            // 
            // textBoxRemoteIp
            // 
            this.textBoxRemoteIp.Location = new System.Drawing.Point(360, 140);
            this.textBoxRemoteIp.Name = "textBoxRemoteIp";
            this.textBoxRemoteIp.ReadOnly = true;
            this.textBoxRemoteIp.Size = new System.Drawing.Size(146, 21);
            this.textBoxRemoteIp.TabIndex = 12;
            // 
            // checkBoxAppointIp
            // 
            this.checkBoxAppointIp.AutoSize = true;
            this.checkBoxAppointIp.Location = new System.Drawing.Point(405, 123);
            this.checkBoxAppointIp.Name = "checkBoxAppointIp";
            this.checkBoxAppointIp.Size = new System.Drawing.Size(48, 16);
            this.checkBoxAppointIp.TabIndex = 13;
            this.checkBoxAppointIp.Text = "指定";
            this.checkBoxAppointIp.UseVisualStyleBackColor = true;
            this.checkBoxAppointIp.CheckedChanged += new System.EventHandler(this.checkBoxAppointIp_CheckedChanged);
            // 
            // UDPserverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 334);
            this.Controls.Add(this.checkBoxAppointIp);
            this.Controls.Add(this.textBoxRemoteIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHostIp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRemotePort);
            this.Controls.Add(this.buttonUpdatePortNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPortNumber);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.richTextBoxRe);
            this.Controls.Add(this.richTextBoxSend);
            this.Name = "UDPserverForm";
            this.Text = "UDP 服务端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxSend;
        private System.Windows.Forms.RichTextBox richTextBoxRe;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxPortNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdatePortNumber;
        private System.Windows.Forms.TextBox textBoxRemotePort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHostIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRemoteIp;
        private System.Windows.Forms.CheckBox checkBoxAppointIp;
    }
}

