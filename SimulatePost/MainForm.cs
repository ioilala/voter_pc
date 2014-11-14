using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.IO;

/*
 * Name:CGCL刷票器
 * Author:王胜 
 * E-mail:hust_wsh@qq.com
 * Date:2014-11-13
 * Version:0.3.1
 * Add:刷人气，自动换IP
 */
namespace SimulatePost
{
    public partial class MainForm : Form
    {
        #region 初始定义
        FileStream logFileStream = null;
        StreamWriter sw = null;
        BackgroundWorker bw = new BackgroundWorker();
        System.Windows.Forms.Timer tmTimeOut = new System.Windows.Forms.Timer();
        List<int> ipList = null;
        string ipCurrent = null;//当前IP
        int succCount = 0;//本次成功投票次数
        int failCount = 0;
        int ipTestedCount = 0;//本次已测试IP数
        int ipTotalCount = 0;//本次总ip数
        bool flagIpVoteStart = false;//是否正在ip刷票
        bool flagWaitForHttpResponse = true;
        bool flagRandomMode = true;
        string ipOrigin = null;
        string gatewayOrigin = null;
        string dnsOrigin = null;
        public MainForm()
        {
            InitializeComponent();
            logFileStream = new FileStream("ipresult.log", FileMode.Append, FileAccess.Write);
            try
            {
                sw = new StreamWriter(logFileStream);
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.WorkerSupportsCancellation = true;
                dnsOrigin = NetworkSetting.GetDNS()[0].ToString();
                ipOrigin = NetworkSetting.GetIP();
                gatewayOrigin = NetworkSetting.GetIPDefaultGateWay();
                tmTimeOut.Tick += new EventHandler(tm_TimeOutCallBack);
                tmTimeOut.Interval = 5000;//单个ip3s超时
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请检查网卡配置，是否有可用网卡?","启动异常");
                //Application.Exit();
            }
        }
        #endregion 
        #region 控件事件
        private void MainForm_Load(object sender, EventArgs e)
        {
            string ipsegment = ipOrigin.Substring(0, ipOrigin.LastIndexOf('.'));
            tbIpStart1.Text = ipsegment + ".1";
            tbIpStart_TextChanged(null,null);
        }
        private void btnOneVote_Click(object sender, EventArgs e)
        {
            rtbMsg.Clear();
            VoteForOnce();
            VoteAddHot(1);
            //pbBusy.Show();
        }
        private void btnIPVote_Click(object sender, EventArgs e)
        {
            flagIpVoteStart = !flagIpVoteStart;
            if (flagIpVoteStart)//进入刷票模式
            {
                if (NetworkSetting.isDHCPEnabled())
                {
                    MessageBox.Show("当前为DHCP模式，可能不支持!");
                    //return;
                }
                succCount = 0;
                failCount = 0;
                ipTestedCount = 0;
                ipTotalCount = 0;
                if (ipList != null)
                {
                    ipList.Clear();
                }
                lbFailCount.Text = "0";
                lbSuccCount.Text = "0";
                lbIpVoteCountState.Text = "0";
                rtbMsg.Clear();
                btnIPVote.Text = "刷票中...";
                btnOneVote.Enabled = false;
                cbRandomMode.Enabled = false;
                bw.RunWorkerAsync();
                rtbMsg.AppendText("开始刷票...\n");
            }
            else
            {
                btnIPVote.Text = "IP刷票";
                bw.CancelAsync();
                btnOneVote.Enabled = true;
                cbRandomMode.Enabled = true;
                rtbMsg.AppendText("正在停止...\n");
            }
        }
        private void tbIpStart_TextChanged(object sender, EventArgs e)
        {
            if (tbIpStart1.Text != "" && NetworkSetting.IsIPAddress(tbIpStart1.Text))
            {
                string ipsegment = tbIpStart1.Text.Substring(0, tbIpStart1.Text.LastIndexOf('.'));
                tbIpEnd1.Text = ipsegment + ".253";
                tbGateWay1.Text = ipsegment + ".254";
            }
        }
        private void cbRandomMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRandomMode.Checked)
            {
                flagRandomMode = true;
            }
            else
            {
                flagRandomMode = false;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (sw != null)
            //    sw.Close();
            //if (logFileStream != null)
            //    logFileStream.Close();
            ////恢复原始
            //RestoreOriginIP();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sw != null)
                sw.Close();
            if (logFileStream != null)
                logFileStream.Close();
            //恢复原始
            RestoreOriginIP();
        }
        #endregion
        #region 后台事件
        //网站返回
        private void wc_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            try
            {
                this.Invoke(new EventHandler(delegate
                {
                    pbBusy.Hide();
                }));
                if (tmTimeOut.Enabled)
                {
                    StopTimer();
                }
                string htmlstr = Encoding.GetEncoding("gb2312").GetString(e.Result);
                if (htmlstr.Contains("成功"))
                {
                    succCount++;
                    this.Invoke(new EventHandler(delegate
                    {
                        rtbMsg.AppendText("IP:" + ipCurrent + "投票成功一次!\n");
                    }));
                }
                else if (htmlstr.Contains("24小时"))
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        rtbMsg.AppendText("IP:" + ipCurrent + "已经投过了\n");
                    }));
                    failCount++;
                }

                //sw.WriteLine(htmlstr);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message,"投票失败");
                //Application.Exit();
                this.Invoke(new EventHandler(delegate
                {
                    rtbMsg.AppendText("IP:" + ipCurrent + "出现异常！\n");
                }));
                sw.WriteLine("===接收返回信息异常===" + ex.Message);
                failCount++;
            }
            finally
            {
                this.Invoke(new EventHandler(delegate
                {
                    lbSuccCount.Text = succCount.ToString();
                    lbFailCount.Text = failCount.ToString();
                    rtbMsg.ScrollToCaret();
                }));
                flagWaitForHttpResponse = false;
            }
        }
        //后台投票
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string startIP = null;
            string endIP = null;
            string gateway = null;
            string dns = null;
            this.Invoke(new EventHandler(delegate
            {
                //开始轮询IP
                startIP = tbIpStart1.Text;
                endIP = tbIpEnd1.Text;
                gateway = tbGateWay1.Text;
                dns = tbDNS1.Text;
                if (!NetworkSetting.IsIPAddress(startIP) || !NetworkSetting.IsIPAddress(endIP)
                    || !NetworkSetting.IsIPAddress(gateway) || !NetworkSetting.IsIPAddress(dns))
                {
                    MessageBox.Show("IP地址格式有误!");
                    btnIPVote_Click(null, null);
                    return;
                }
            }));
            int start = Convert.ToInt32(startIP.Split('.')[3]);
            int end = Convert.ToInt32(endIP.Split('.')[3]);
            ipTotalCount = end - start + 1;
            if (flagRandomMode)
            {
                ipList = new List<int>(end - start + 1);
                for (int i = start; i <= end; i++)
                {
                    ipList.Add(i);
                }
            }
            string ipsegment = startIP.Substring(0, startIP.LastIndexOf('.'));
            while (start <= end)
            {
                this.Invoke(new EventHandler(delegate
                {
                    pbBusy.Show();
                }));
                try
                {
                    if (flagRandomMode)
                    {
                        Random rand = new Random(DateTime.Now.Millisecond);
                        int index = rand.Next(end - start + 1);
                        ipCurrent = ipsegment + "." + ipList[index];
                        ipList.RemoveAt(index);
                    }
                    else
                    {
                        ipCurrent = ipsegment + "." + start;
                    }
                    if (ipCurrent == "211.69.198.23")//认证服务器的ip不要抢
                        continue;
                    NetworkSetting.SetIPAddress(ipCurrent, "255.255.255.0", gateway);
                    //...DNS默认不变
                    //NetworkSetting.SetDNS(new string[] { dns, "8.8.8.8" });
                    //Thread.Sleep(1000);
                    flagWaitForHttpResponse = true;
                    //刷人气
                    VoteAddHot(3);
                    //tmTimeOut.Start();//
                    //刷票
                    VoteForOnce();

                    Thread.Sleep(3000);
                    //while (flagWaitForHttpResponse);
                    if (!flagIpVoteStart)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    sw.WriteLine("===" + ex.Message + "===");
                    this.Invoke(new EventHandler(delegate
                    {
                        rtbMsg.AppendText("IP地址" + ipCurrent + "被占用\n");
                    }));
                }
                finally
                {
                    start++;
                    ipTestedCount++;
                    this.Invoke(new EventHandler(delegate
                    {
                        lbIpVoteCountState.Text = ipTestedCount.ToString() + "/" + ipTotalCount.ToString();
                    }));
                }
            }
            this.Invoke(new EventHandler(delegate
            {
                rtbMsg.AppendText("本次投票成功:" + succCount + "次,投票失败:" + failCount + "次\n");
                rtbMsg.ScrollToCaret();
            }));
            btnIPVote_Click(null, null);
            //恢复原始IP 
            RestoreOriginIP();
        }
        //超时跳过
        private void tm_TimeOutCallBack(object sender, EventArgs e)
        {
            flagWaitForHttpResponse = false;
            StopTimer();
        }
        //停止计时器
        private void StopTimer()
        {
            tmTimeOut.Stop();
            tmTimeOut.Interval = 5000;
        }
        #endregion
        #region 功能函数
        //投票
        private void VoteForOnce()
        {
            this.Invoke(new EventHandler(delegate
            {
                pbBusy.Show();
            }));
            //rtbMsg.Clear();
            WebClient wc = new WebClient();
            NameValueCollection reqparm = new NameValueCollection();
            wc.Headers.Add("Accept: */*");
            wc.Headers.Add("User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET4.0E; .NET4.0C; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; SE 2.X MetaSr 1.0)");
            wc.Headers.Add("Accept-Language: zh-cn");
            wc.Headers.Add("Content-Type: application/x-www-form-urlencoded");
            wc.Headers.Add("Accept-Encoding: gzip, deflate");
            wc.Headers.Add("Cache-Control: no-cache");
            wc.Headers.Add("Referer", "http://gqt-xl.org/index.asp");
            reqparm.Add("VoTeid", "320");
            reqparm.Add("Submit", "提交投票");
            wc.UploadValuesCompleted += new UploadValuesCompletedEventHandler(wc_UploadValuesCompleted);
            wc.UploadValuesAsync(new Uri("http://gqt-xl.org/More&vote.asp"), "POST", reqparm);
            wc.Dispose();
        }
        //增加人气
        private void VoteAddHot(int cnt)
        {
            try
            {
                WebClient wc = new WebClient();
                //wc.Headers.Add("Accept: */*");
                //wc.Headers.Add("User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET4.0E; .NET4.0C; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; SE 2.X MetaSr 1.0)");
                //wc.Headers.Add("Accept-Language: zh-cn");
                //wc.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                //wc.Headers.Add("Accept-Encoding: gzip, deflate");
                //wc.Headers.Add("Cache-Control: no-cache");
                wc.Headers.Add("Referer", "http://gqt-xl.org/Vote_List5.asp?ClassId=44&Topid=0");
                Random rm = new Random(DateTime.Now.Millisecond);
                int count=rm.Next(0, cnt + 1);
                for (int i = 0; i < count; i++)
                {
                    wc.DownloadDataAsync(new Uri("http://gqt-xl.org/Vote_Show.asp?InfoId=48a50a51&ClassId=44&Topid=0"));
                    this.Invoke(new EventHandler(delegate
                    {
                        rtbMsg.AppendText("IP" + ipCurrent + "刷人气成功一次\n");
                        rtbMsg.ScrollToCaret();
                    }));
                    //Thread.Sleep(100);
                }
                wc.Dispose();                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                sw.WriteLine("===刷人气失败:"+ex.Message);
            }
        }
        //恢复本机默认IP
        private void RestoreOriginIP()
        {
            //return;
            if (NetworkSetting.isDHCPEnabled())
            {
                NetworkSetting.EnableDHCP();
            }
            else
            {
                NetworkSetting.SetIPAddress(ipOrigin, "255.255.255.0", gatewayOrigin);
                NetworkSetting.SetDNS(new string[] { dnsOrigin, "8.8.8.8" });
            }
        }
        #endregion
    }
}
