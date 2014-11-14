namespace SimulatePost
{
    partial class MainForm
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
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.btnOneVote = new System.Windows.Forms.Button();
            this.pbBusy = new System.Windows.Forms.ProgressBar();
            this.btnIPVote = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSuccCount = new System.Windows.Forms.Label();
            this.lbFailCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRandomMode = new System.Windows.Forms.CheckBox();
            this.lbIpVoteCountState = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbGateWay1 = new System.Windows.Forms.TextBox();
            this.tbIpEnd1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbIpStart1 = new System.Windows.Forms.TextBox();
            this.tbDNS1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMsg
            // 
            this.rtbMsg.BackColor = System.Drawing.Color.White;
            this.rtbMsg.Location = new System.Drawing.Point(16, 130);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ReadOnly = true;
            this.rtbMsg.Size = new System.Drawing.Size(271, 256);
            this.rtbMsg.TabIndex = 0;
            this.rtbMsg.Text = "";
            // 
            // btnOneVote
            // 
            this.btnOneVote.Location = new System.Drawing.Point(293, 130);
            this.btnOneVote.Name = "btnOneVote";
            this.btnOneVote.Size = new System.Drawing.Size(91, 57);
            this.btnOneVote.TabIndex = 0;
            this.btnOneVote.Text = "单次投票";
            this.btnOneVote.UseVisualStyleBackColor = true;
            this.btnOneVote.Click += new System.EventHandler(this.btnOneVote_Click);
            // 
            // pbBusy
            // 
            this.pbBusy.Location = new System.Drawing.Point(16, 392);
            this.pbBusy.Name = "pbBusy";
            this.pbBusy.Size = new System.Drawing.Size(272, 10);
            this.pbBusy.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbBusy.TabIndex = 5;
            this.pbBusy.Visible = false;
            // 
            // btnIPVote
            // 
            this.btnIPVote.Location = new System.Drawing.Point(294, 193);
            this.btnIPVote.Name = "btnIPVote";
            this.btnIPVote.Size = new System.Drawing.Size(90, 174);
            this.btnIPVote.TabIndex = 0;
            this.btnIPVote.Text = "IP刷票";
            this.btnIPVote.UseVisualStyleBackColor = true;
            this.btnIPVote.Click += new System.EventHandler(this.btnIPVote_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "成功：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "失败：";
            // 
            // lbSuccCount
            // 
            this.lbSuccCount.AutoSize = true;
            this.lbSuccCount.Location = new System.Drawing.Point(40, 4);
            this.lbSuccCount.Name = "lbSuccCount";
            this.lbSuccCount.Size = new System.Drawing.Size(11, 12);
            this.lbSuccCount.TabIndex = 2;
            this.lbSuccCount.Text = "0";
            // 
            // lbFailCount
            // 
            this.lbFailCount.AutoSize = true;
            this.lbFailCount.Location = new System.Drawing.Point(112, 4);
            this.lbFailCount.Name = "lbFailCount";
            this.lbFailCount.Size = new System.Drawing.Size(11, 12);
            this.lbFailCount.TabIndex = 2;
            this.lbFailCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "概况：";
            // 
            // cbRandomMode
            // 
            this.cbRandomMode.AutoSize = true;
            this.cbRandomMode.Checked = true;
            this.cbRandomMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRandomMode.Location = new System.Drawing.Point(303, 373);
            this.cbRandomMode.Name = "cbRandomMode";
            this.cbRandomMode.Size = new System.Drawing.Size(72, 16);
            this.cbRandomMode.TabIndex = 6;
            this.cbRandomMode.Text = "随机模式";
            this.cbRandomMode.UseVisualStyleBackColor = true;
            this.cbRandomMode.CheckedChanged += new System.EventHandler(this.cbRandomMode_CheckedChanged);
            // 
            // lbIpVoteCountState
            // 
            this.lbIpVoteCountState.AutoSize = true;
            this.lbIpVoteCountState.Location = new System.Drawing.Point(187, 4);
            this.lbIpVoteCountState.Name = "lbIpVoteCountState";
            this.lbIpVoteCountState.Size = new System.Drawing.Size(23, 12);
            this.lbIpVoteCountState.TabIndex = 2;
            this.lbIpVoteCountState.Text = "0/0";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbSuccCount);
            this.panel3.Controls.Add(this.lbIpVoteCountState);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lbFailCount);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(16, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 21);
            this.panel3.TabIndex = 7;
            // 
            // tbGateWay1
            // 
            this.tbGateWay1.Location = new System.Drawing.Point(61, 51);
            this.tbGateWay1.Name = "tbGateWay1";
            this.tbGateWay1.Size = new System.Drawing.Size(126, 21);
            this.tbGateWay1.TabIndex = 3;
            this.tbGateWay1.Text = "211.69.198.254";
            // 
            // tbIpEnd1
            // 
            this.tbIpEnd1.Location = new System.Drawing.Point(246, 25);
            this.tbIpEnd1.Name = "tbIpEnd1";
            this.tbIpEnd1.Size = new System.Drawing.Size(126, 21);
            this.tbIpEnd1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束IP：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "DNS：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "网关IP：";
            // 
            // tbIpStart1
            // 
            this.tbIpStart1.Location = new System.Drawing.Point(61, 24);
            this.tbIpStart1.Name = "tbIpStart1";
            this.tbIpStart1.Size = new System.Drawing.Size(126, 21);
            this.tbIpStart1.TabIndex = 1;
            this.tbIpStart1.TextChanged += new System.EventHandler(this.tbIpStart_TextChanged);
            // 
            // tbDNS1
            // 
            this.tbDNS1.Location = new System.Drawing.Point(246, 51);
            this.tbDNS1.Name = "tbDNS1";
            this.tbDNS1.Size = new System.Drawing.Size(126, 21);
            this.tbDNS1.TabIndex = 4;
            this.tbDNS1.Text = "202.114.0.242";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "起始IP：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbDNS1);
            this.groupBox1.Controls.Add(this.tbIpStart1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbIpEnd1);
            this.groupBox1.Controls.Add(this.tbGateWay1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 88);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刷票设置";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cbRandomMode);
            this.Controls.Add(this.pbBusy);
            this.Controls.Add(this.btnIPVote);
            this.Controls.Add(this.btnOneVote);
            this.Controls.Add(this.rtbMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CGCL刷票器0.3.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.Button btnOneVote;
        private System.Windows.Forms.ProgressBar pbBusy;
        private System.Windows.Forms.Button btnIPVote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbSuccCount;
        private System.Windows.Forms.Label lbFailCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbRandomMode;
        private System.Windows.Forms.Label lbIpVoteCountState;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbGateWay1;
        private System.Windows.Forms.TextBox tbIpEnd1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbIpStart1;
        private System.Windows.Forms.TextBox tbDNS1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

