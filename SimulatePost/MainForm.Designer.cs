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
            this.tbGateWay = new System.Windows.Forms.TextBox();
            this.tbIpEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbIpStart = new System.Windows.Forms.TextBox();
            this.tbDNS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbVoteShow = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbRemoteRank = new System.Windows.Forms.Label();
            this.lbRemoteHotCount = new System.Windows.Forms.Label();
            this.lbRemoteVoteCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbRankStart = new System.Windows.Forms.ComboBox();
            this.cbTime3 = new System.Windows.Forms.CheckBox();
            this.cbTime2 = new System.Windows.Forms.CheckBox();
            this.cbTime1 = new System.Windows.Forms.CheckBox();
            this.tbTime3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbTime2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbTime1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tbBeiStartIP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbBeiEndIP = new System.Windows.Forms.TextBox();
            this.tbBeiGateWay = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbVoteHot = new System.Windows.Forms.CheckBox();
            this.cbVote = new System.Windows.Forms.CheckBox();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMsg
            // 
            this.rtbMsg.BackColor = System.Drawing.Color.White;
            this.rtbMsg.Location = new System.Drawing.Point(16, 249);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ReadOnly = true;
            this.rtbMsg.Size = new System.Drawing.Size(271, 156);
            this.rtbMsg.TabIndex = 0;
            this.rtbMsg.Text = "";
            // 
            // btnOneVote
            // 
            this.btnOneVote.Location = new System.Drawing.Point(302, 210);
            this.btnOneVote.Name = "btnOneVote";
            this.btnOneVote.Size = new System.Drawing.Size(91, 44);
            this.btnOneVote.TabIndex = 0;
            this.btnOneVote.Text = "单次投票";
            this.btnOneVote.UseVisualStyleBackColor = true;
            this.btnOneVote.Click += new System.EventHandler(this.btnOneVote_Click);
            // 
            // pbBusy
            // 
            this.pbBusy.Location = new System.Drawing.Point(16, 237);
            this.pbBusy.Name = "pbBusy";
            this.pbBusy.Size = new System.Drawing.Size(272, 10);
            this.pbBusy.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbBusy.TabIndex = 5;
            this.pbBusy.Visible = false;
            // 
            // btnIPVote
            // 
            this.btnIPVote.Location = new System.Drawing.Point(303, 260);
            this.btnIPVote.Name = "btnIPVote";
            this.btnIPVote.Size = new System.Drawing.Size(90, 46);
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
            this.cbRandomMode.Location = new System.Drawing.Point(312, 317);
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
            this.panel3.Location = new System.Drawing.Point(16, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 21);
            this.panel3.TabIndex = 7;
            // 
            // tbGateWay
            // 
            this.tbGateWay.Location = new System.Drawing.Point(61, 51);
            this.tbGateWay.Name = "tbGateWay";
            this.tbGateWay.Size = new System.Drawing.Size(126, 21);
            this.tbGateWay.TabIndex = 3;
            this.tbGateWay.Text = "211.69.198.254";
            // 
            // tbIpEnd
            // 
            this.tbIpEnd.Location = new System.Drawing.Point(246, 25);
            this.tbIpEnd.Name = "tbIpEnd";
            this.tbIpEnd.Size = new System.Drawing.Size(126, 21);
            this.tbIpEnd.TabIndex = 2;
            this.tbIpEnd.Text = "211.69.198.253";
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
            // tbIpStart
            // 
            this.tbIpStart.Location = new System.Drawing.Point(61, 24);
            this.tbIpStart.Name = "tbIpStart";
            this.tbIpStart.Size = new System.Drawing.Size(126, 21);
            this.tbIpStart.TabIndex = 1;
            this.tbIpStart.Text = "211.69.198.1";
            this.tbIpStart.TextChanged += new System.EventHandler(this.tbIpStart_TextChanged);
            // 
            // tbDNS
            // 
            this.tbDNS.Location = new System.Drawing.Point(246, 51);
            this.tbDNS.Name = "tbDNS";
            this.tbDNS.Size = new System.Drawing.Size(126, 21);
            this.tbDNS.TabIndex = 4;
            this.tbDNS.Text = "202.114.0.242";
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
            this.groupBox1.Controls.Add(this.tbDNS);
            this.groupBox1.Controls.Add(this.tbIpStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbIpEnd);
            this.groupBox1.Controls.Add(this.tbGateWay);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 88);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主IP段";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbVoteShow);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbRemoteRank);
            this.groupBox2.Controls.Add(this.lbRemoteHotCount);
            this.groupBox2.Controls.Add(this.lbRemoteVoteCount);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(400, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 235);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时信息";
            // 
            // tbVoteShow
            // 
            this.tbVoteShow.Location = new System.Drawing.Point(17, 90);
            this.tbVoteShow.Multiline = true;
            this.tbVoteShow.Name = "tbVoteShow";
            this.tbVoteShow.Size = new System.Drawing.Size(310, 122);
            this.tbVoteShow.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(243, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "实时排名";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "实时人气";
            // 
            // lbRemoteRank
            // 
            this.lbRemoteRank.AutoSize = true;
            this.lbRemoteRank.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemoteRank.ForeColor = System.Drawing.Color.Lime;
            this.lbRemoteRank.Location = new System.Drawing.Point(249, 49);
            this.lbRemoteRank.Name = "lbRemoteRank";
            this.lbRemoteRank.Size = new System.Drawing.Size(27, 30);
            this.lbRemoteRank.TabIndex = 2;
            this.lbRemoteRank.Text = "0";
            this.lbRemoteRank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRemoteHotCount
            // 
            this.lbRemoteHotCount.AutoSize = true;
            this.lbRemoteHotCount.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemoteHotCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbRemoteHotCount.Location = new System.Drawing.Point(142, 49);
            this.lbRemoteHotCount.Name = "lbRemoteHotCount";
            this.lbRemoteHotCount.Size = new System.Drawing.Size(27, 30);
            this.lbRemoteHotCount.TabIndex = 2;
            this.lbRemoteHotCount.Text = "0";
            this.lbRemoteHotCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRemoteVoteCount
            // 
            this.lbRemoteVoteCount.AutoSize = true;
            this.lbRemoteVoteCount.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemoteVoteCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbRemoteVoteCount.Location = new System.Drawing.Point(20, 49);
            this.lbRemoteVoteCount.Name = "lbRemoteVoteCount";
            this.lbRemoteVoteCount.Size = new System.Drawing.Size(27, 30);
            this.lbRemoteVoteCount.TabIndex = 2;
            this.lbRemoteVoteCount.Text = "0";
            this.lbRemoteVoteCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "实时票数";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbRankStart);
            this.groupBox3.Controls.Add(this.cbTime3);
            this.groupBox3.Controls.Add(this.cbTime2);
            this.groupBox3.Controls.Add(this.cbTime1);
            this.groupBox3.Controls.Add(this.tbTime3);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.tbTime2);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.tbTime1);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Location = new System.Drawing.Point(400, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 149);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "定时刷票";
            // 
            // cmbRankStart
            // 
            this.cmbRankStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRankStart.FormattingEnabled = true;
            this.cmbRankStart.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbRankStart.Location = new System.Drawing.Point(299, 33);
            this.cmbRankStart.Name = "cmbRankStart";
            this.cmbRankStart.Size = new System.Drawing.Size(39, 20);
            this.cmbRankStart.TabIndex = 4;
            // 
            // cbTime3
            // 
            this.cbTime3.AutoSize = true;
            this.cbTime3.Checked = true;
            this.cbTime3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTime3.Location = new System.Drawing.Point(193, 86);
            this.cbTime3.Name = "cbTime3";
            this.cbTime3.Size = new System.Drawing.Size(15, 14);
            this.cbTime3.TabIndex = 3;
            this.cbTime3.UseVisualStyleBackColor = true;
            // 
            // cbTime2
            // 
            this.cbTime2.AutoSize = true;
            this.cbTime2.Checked = true;
            this.cbTime2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTime2.Location = new System.Drawing.Point(193, 61);
            this.cbTime2.Name = "cbTime2";
            this.cbTime2.Size = new System.Drawing.Size(15, 14);
            this.cbTime2.TabIndex = 3;
            this.cbTime2.UseVisualStyleBackColor = true;
            // 
            // cbTime1
            // 
            this.cbTime1.AutoSize = true;
            this.cbTime1.Checked = true;
            this.cbTime1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTime1.Location = new System.Drawing.Point(193, 34);
            this.cbTime1.Name = "cbTime1";
            this.cbTime1.Size = new System.Drawing.Size(15, 14);
            this.cbTime1.TabIndex = 3;
            this.cbTime1.UseVisualStyleBackColor = true;
            // 
            // tbTime3
            // 
            this.tbTime3.Location = new System.Drawing.Point(50, 84);
            this.tbTime3.Name = "tbTime3";
            this.tbTime3.Size = new System.Drawing.Size(126, 21);
            this.tbTime3.TabIndex = 2;
            this.tbTime3.Text = "22:30";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "时间:";
            // 
            // tbTime2
            // 
            this.tbTime2.Location = new System.Drawing.Point(50, 57);
            this.tbTime2.Name = "tbTime2";
            this.tbTime2.Size = new System.Drawing.Size(126, 21);
            this.tbTime2.TabIndex = 2;
            this.tbTime2.Text = "12:30";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "时间:";
            // 
            // tbTime1
            // 
            this.tbTime1.Location = new System.Drawing.Point(50, 30);
            this.tbTime1.Name = "tbTime1";
            this.tbTime1.Size = new System.Drawing.Size(126, 21);
            this.tbTime1.TabIndex = 2;
            this.tbTime1.Text = "7:30";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "时间:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(243, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "排名限额:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(302, 383);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 34);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.tbBeiStartIP);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.tbBeiEndIP);
            this.groupBox4.Controls.Add(this.tbBeiGateWay);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(12, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(382, 88);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "备用IP段";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "起始IP：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(246, 51);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(126, 21);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "202.114.0.242";
            // 
            // tbBeiStartIP
            // 
            this.tbBeiStartIP.Location = new System.Drawing.Point(61, 24);
            this.tbBeiStartIP.Name = "tbBeiStartIP";
            this.tbBeiStartIP.Size = new System.Drawing.Size(126, 21);
            this.tbBeiStartIP.TabIndex = 1;
            this.tbBeiStartIP.Text = "115.156.232.1";
            this.tbBeiStartIP.TextChanged += new System.EventHandler(this.tbIpStart_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "网关IP：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(194, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "DNS：";
            // 
            // tbBeiEndIP
            // 
            this.tbBeiEndIP.Location = new System.Drawing.Point(246, 25);
            this.tbBeiEndIP.Name = "tbBeiEndIP";
            this.tbBeiEndIP.Size = new System.Drawing.Size(126, 21);
            this.tbBeiEndIP.TabIndex = 2;
            this.tbBeiEndIP.Text = "115.156.232.253";
            // 
            // tbBeiGateWay
            // 
            this.tbBeiGateWay.Location = new System.Drawing.Point(61, 51);
            this.tbBeiGateWay.Name = "tbBeiGateWay";
            this.tbBeiGateWay.Size = new System.Drawing.Size(126, 21);
            this.tbBeiGateWay.TabIndex = 3;
            this.tbBeiGateWay.Text = "115.156.232.254";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(193, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 2;
            this.label17.Text = "结束IP：";
            // 
            // cbVoteHot
            // 
            this.cbVoteHot.AutoSize = true;
            this.cbVoteHot.Checked = true;
            this.cbVoteHot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVoteHot.Location = new System.Drawing.Point(312, 361);
            this.cbVoteHot.Name = "cbVoteHot";
            this.cbVoteHot.Size = new System.Drawing.Size(60, 16);
            this.cbVoteHot.TabIndex = 6;
            this.cbVoteHot.Text = "刷人气";
            this.cbVoteHot.UseVisualStyleBackColor = true;
            this.cbVoteHot.CheckedChanged += new System.EventHandler(this.cbVoteHot_CheckedChanged);
            // 
            // cbVote
            // 
            this.cbVote.AutoSize = true;
            this.cbVote.Checked = true;
            this.cbVote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVote.Location = new System.Drawing.Point(312, 339);
            this.cbVote.Name = "cbVote";
            this.cbVote.Size = new System.Drawing.Size(48, 16);
            this.cbVote.TabIndex = 6;
            this.cbVote.Text = "刷票";
            this.cbVote.UseVisualStyleBackColor = true;
            this.cbVote.CheckedChanged += new System.EventHandler(this.cbVote_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 416);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbBusy);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cbVote);
            this.Controls.Add(this.cbVoteHot);
            this.Controls.Add(this.cbRandomMode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnIPVote);
            this.Controls.Add(this.btnOneVote);
            this.Controls.Add(this.rtbMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CGCL刷票器0.3.6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.TextBox tbGateWay;
        private System.Windows.Forms.TextBox tbIpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbIpStart;
        private System.Windows.Forms.TextBox tbDNS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbRemoteVoteCount;
        private System.Windows.Forms.Label lbRemoteRank;
        private System.Windows.Forms.Label lbRemoteHotCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tbVoteShow;
        private System.Windows.Forms.TextBox tbTime1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbTime3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbTime2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbTime3;
        private System.Windows.Forms.CheckBox cbTime2;
        private System.Windows.Forms.CheckBox cbTime1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox tbBeiStartIP;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbBeiEndIP;
        private System.Windows.Forms.TextBox tbBeiGateWay;
        private System.Windows.Forms.CheckBox cbVoteHot;
        private System.Windows.Forms.CheckBox cbVote;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbRankStart;
    }
}

