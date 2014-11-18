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
using HtmlAgilityPack;
using System.Timers;

/*
 * Name:CGCL刷票器
 * Author:王胜 
 * E-mail:hust_wsh@qq.com
 * Date:2014-11-14
 * Version:0.3.6
 * History:
 * 1.刷人气;
 * 2.自动换IP;
 * 3.本机启动自动获取IP段;
 * 4.主IP段投完后自动切换备用IP段投票
 * 5.定时功能
 * 6.刷人气开关
 * Add:
 * 1.增加两次刷票之间的时间，防止DDOS攻击检测
 * 2.修改
 * Todo:
 */
namespace SimulatePost
{
    public partial class MainForm : Form
    {
        #region 初始定义
        FileStream logFileStream = null;
        StreamWriter sw = null;
        //BackgroundWorker bw = new BackgroundWorker();
        Thread thIpVote = null;//后台投票的线程
        Thread thGetVoteShow = null;//获取投票信息的线程
        System.Timers.Timer tmCheckSystemTime = new System.Timers.Timer();
        List<int> ipListMain = null;
        string urlVote = "http://gqt-xl.org/More&vote.asp";
        string urlShowPage = "http://gqt-xl.org/Vote_List5.asp?ClassId=44&Topid=0";
        string urlShowPageRefer = "http://gqt-xl.org/index.asp";
        string urlAimPage = "http://gqt-xl.org/Vote_Show.asp?InfoId=48a50a51&ClassId=44&Topid=0";
        string urlAimPageRefer = "http://gqt-xl.org/Vote_List5.asp?ClassId=44&Topid=0";
        string urlVoteRefer = "http://gqt-xl.org/index.asp";
        string ipCurrent = null;//当前IP
        int succCount = 0;//本次成功投票次数
        int failCount = 0;
        int ipTestedCount = 0;//本次已测试IP数
        int ipTotalCount = 0;//本次总ip数
        bool flagIpVoteStart = false;//是否正在ip刷票
        bool flagWaitForHttpResponse = true;
        bool flagGetVoteShow = true;
        bool flagOnceMore = true;
        bool flagRandomMode = true;
        bool flagVote = true;//是否刷票
        bool flagVoteHot = true;//是否刷人气值
        string ipOrigin = null;
        string gatewayOrigin = null;
        string dnsOrigin = null;
        #endregion
        #region 系统初始
        public MainForm()
        {
            InitializeComponent();
            logFileStream = new FileStream("ipresult.log", FileMode.Append, FileAccess.Write);
            try
            {
                sw = new StreamWriter(logFileStream);
                dnsOrigin = NetworkSetting.GetDNS()[0].ToString();
                ipOrigin = NetworkSetting.GetIP();
                gatewayOrigin = NetworkSetting.GetIPDefaultGateWay();
                cmbRankStart.SelectedIndex = 0;
                thGetVoteShow = new Thread(new ThreadStart(thGetVoteShow_DoWork));
                thGetVoteShow.IsBackground = true;
                tmCheckSystemTime.Elapsed+=new System.Timers.ElapsedEventHandler(tmCheckSystemTime_Elapsed);
                tmCheckSystemTime.AutoReset = true;
                tmCheckSystemTime.Interval = 60000;
                tmCheckSystemTime.Start();
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
            tbIpStart.Text = ipsegment + ".1";
            tbIpStart_TextChanged(null,null);
        }
        private void btnOneVote_Click(object sender, EventArgs e)
        {
            rtbMsg.Clear();
            VoteForOnce();
            VoteAddHot(3);
            //pbBusy.Show();
        }
        private void btnIPVote_Click(object sender, EventArgs e)
        {
            if (!flagIpVoteStart)//进入刷票模式
            {
                if (NetworkSetting.isDHCPEnabled())
                {
                    //MessageBox.Show();
                    OutMsg("当前为DHCP模式，可能不支持!");
                    //return;
                }
                succCount = 0;
                failCount = 0;
                ipTestedCount = 0;
                ipTotalCount = 0;
                if (ipListMain != null)
                {
                    ipListMain.Clear();
                }
                SetIpVoteBtnState(true);
                thIpVote = new Thread(new ThreadStart(thIpVote_DoWork));
                thIpVote.IsBackground = true;
                thIpVote.Start();
                OutMsg("开始刷票...");
            }
            else
            {
                if (sender!=null)//手点的按钮，不再运行第二次
                {
                    flagOnceMore = false;
                }
                //bw.CancelAsync();
                SetIpVoteBtnState(false);
                OutMsg("正在停止...");
                btnIPVote.Enabled = false;
            }
        }
        private void tbIpStart_TextChanged(object sender, EventArgs e)
        {
            if (tbIpStart.Text != "" && NetworkSetting.IsIPAddress(tbIpStart.Text))
            {
                string ipsegment = tbIpStart.Text.Substring(0, tbIpStart.Text.LastIndexOf('.'));
                tbIpEnd.Text = ipsegment + ".253";
                tbGateWay.Text = ipsegment + ".254";
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
            flagGetVoteShow = false;
            if (sw != null)
                sw.Close();
            if (logFileStream != null)
                logFileStream.Close();
            //恢复原始
            RestoreOriginIP();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void cbVoteHot_CheckedChanged(object sender, EventArgs e)
        {
            flagVoteHot = cbVoteHot.Checked;
        }
        private void cbVote_CheckedChanged(object sender, EventArgs e)
        {
            flagVote = cbVote.Checked;
        }
        #endregion
        #region 后台事件
        //网站返回 obselete
        private void wc_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            try
            {
                this.Invoke(new EventHandler(delegate
                {
                    pbBusy.Hide();
                }));
                string htmlstr = Encoding.GetEncoding("gb2312").GetString(e.Result);
                if (htmlstr.Contains("成功"))
                {
                    succCount++;
                    this.Invoke(new EventHandler(delegate
                    {
                        OutMsg("IP:" + ipCurrent + "投票成功一次!");
                    }));
                }
                else if (htmlstr.Contains("24小时"))
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        OutMsg("IP:" + ipCurrent + "已经投过了!");
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
                    OutMsg("IP:" + ipCurrent + "出现异常！"+ex.Message);
                }));
                //sw.WriteLine("===接收返回信息异常===" + ex.Message);
                failCount++;
            }
            finally
            {
                this.Invoke(new EventHandler(delegate
                {
                    lbSuccCount.Text = succCount.ToString();
                    lbFailCount.Text = failCount.ToString();
                }));
                flagWaitForHttpResponse = false;
            }
        }
        //后台投票
        private void thIpVote_DoWork()
        {
            string startIP = null;
            string endIP = null;
            string gateway = null;
            string dns = null;
            this.Invoke(new EventHandler(delegate
            {
                //开始轮询IP
                startIP = tbIpStart.Text;
                endIP = tbIpEnd.Text;
                gateway = tbGateWay.Text;
                dns = tbDNS.Text;
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
                ipListMain = new List<int>(end - start + 1);
                for (int i = start; i <= end; i++)
                {
                    ipListMain.Add(i);
                }
            }
            string ipsegment = startIP.Substring(0, startIP.LastIndexOf('.'));
            ShowBusyUI(true);
            while (start <= end)
            {
                try
                {
                    if (flagRandomMode)
                    {
                        Random rand = new Random(DateTime.Now.Millisecond);
                        int index = rand.Next(end - start + 1);
                        ipCurrent = ipsegment + "." + ipListMain[index];
                        ipListMain.RemoveAt(index);
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
                    if (flagVoteHot)
                    {
                        //刷人气
                        VoteAddHot(3);
                    }
                    //tmTimeOut.Start();//
                    if (flagVote)
                    {
                        //刷票
                        VoteForOnce();
                    }
                    //刷新网站投票
                    thGetVoteShow_DoWork();
                    //Thread.Sleep(3000);
                    //while (flagWaitForHttpResponse)
                    //{
                    //    Thread.Sleep(200);
                    //}
                    if (!flagIpVoteStart)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                        OutMsg(ipCurrent+"投票异常:"+ex.Message);
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
                //两次投票之间休眠一段时间
                Random randTime = new Random(DateTime.Now.Millisecond);
                int sleeptime=randTime.Next(1000, 5000);
                OutMsg("休眠" + sleeptime + "ms");
                Thread.Sleep(sleeptime);
            }
            this.Invoke(new EventHandler(delegate
            {
                OutMsg("本次投票成功:" + succCount + "次,投票失败:" + failCount + "次");
                btnIPVote.Enabled = true;
            }));
            ShowBusyUI(false);
            SetIpVoteBtnState(false);
            //恢复原始IP 
            RestoreOriginIP();
            if (flagOnceMore)
            {
                tbIpStart.Text = tbBeiStartIP.Text;
                tbIpStart_TextChanged(null, null);
                btnIPVote_Click(null, null);
                flagOnceMore = false;
            }
            else
            {
                tbIpStart.Text = "211.69.198.1";
                tbIpStart_TextChanged(null, null);
            }
        }
        //后台获取投票信息
        private void thGetVoteShow_DoWork()
        {
            //while (flagGetVoteShow)
            //{
                string htmlstr = DownLoadHtml(urlShowPage, urlShowPageRefer);
                if (htmlstr == null)
                {
                    //OutMsg("获取网站票数信息失败!");
                    return;
                }
                try
                {
                    HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                    htmldoc.LoadHtml(htmlstr);
                    HtmlNode hn = htmldoc.DocumentNode.SelectSingleNode(@"//form[@id='form1']");
                    string text = hn.NextSibling.InnerText;//前几名的排名
                    this.Invoke(new EventHandler(delegate
                    {
                        tbVoteShow.Text = text;
                        if (!text.Contains("北大方正"))
                        {
                            MessageBox.Show("北大方正已经跌出前4!!!");
                            //...启动自动刷票
                        }
                        //获取排名、票数、人气值
                        string[] names = text.Split('【');
                        for (int i = 1; i < names.Length; i++)
                        {
                            if (names[i].Contains("北大方正"))
                            {
                                lbRemoteRank.Text = i.ToString();
                                string[] tem = names[i].Split('：');
                                tem[1] = tem[1].Replace("人气", "").TrimEnd(' ');
                                tem[2] = tem[2].TrimEnd(' ');
                                //OutMsg(tem[0]+"\r\n"+tem[1]+"\r\n"+tem[2]);
                                lbRemoteVoteCount.Text = tem[1];
                                lbRemoteHotCount.Text = tem[2];
                                break;
                            }
                        }
                    }));
                }
                catch (Exception ex)
                {
                    OutMsg("获取投票信息异常:" + ex.Message);
                }            
            //}
        }
        //定时投票
        private void tmCheckSystemTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!flagIpVoteStart)//如果已经在刷票直接返回
            {
                string timestr = DateTime.Now.ToShortTimeString();
                if (((timestr == tbTime1.Text) && cbTime1.Checked) || ((timestr == tbTime2.Text) && cbTime2.Checked) || ((timestr == tbTime3.Text) && cbTime3.Checked))
                {
                    //获取网站排名
                    thGetVoteShow_DoWork();
                    this.Invoke(new EventHandler(delegate
                    {
                        if (Convert.ToInt32(lbRemoteRank.Text) > (cmbRankStart.SelectedIndex + 1))//排名跌落到2开外，才刷票
                        {
                            flagOnceMore = true;
                            flagIpVoteStart = false;
                            btnIPVote_Click(null, null);
                        }
                    }));
                }
            }
        }
        #endregion
        #region 功能函数
        private void SetIpVoteBtnState(bool on)
        {
            this.Invoke(new EventHandler(delegate
            {
                flagIpVoteStart = on;
                if (on)
                {
                    lbFailCount.Text = "0";
                    lbSuccCount.Text = "0";
                    lbIpVoteCountState.Text = "0";
                    rtbMsg.Clear();
                    btnIPVote.Text = "刷票中...";
                    btnOneVote.Enabled = false;
                    cbRandomMode.Enabled = false;
                }
                else
                {
                    btnIPVote.Text = "IP刷票";
                    btnOneVote.Enabled = true;
                    cbRandomMode.Enabled = true;
                }
            }));
        }
        //是否显示进度条
        private void ShowBusyUI(bool flag)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (flag)
                {
                    pbBusy.Show();
                }
                else
                {
                    pbBusy.Hide();
                }
            }));
        }
        //下载某个url的html
        private string DownLoadHtml(string url, string refer)
        {
            WebClient wc = null;
            try
            {
                wc = new WebClient();
                wc.Headers.Add("Referer", refer);
                byte[] html=wc.DownloadData(new Uri(url));
                return Encoding.GetEncoding("gb2312").GetString(html);
            }
            catch (WebException ex)
            {
                OutMsg("获取网站投票数据失败!" + ex.Message + "错误码:" + ex.Status);
            }
            finally
            {
                if (wc != null)
                    wc.Dispose();
            }
            return null;
        }
        //打印消息
        private void OutMsg(string msg)
        {
            this.Invoke(new EventHandler(delegate
            {
                rtbMsg.AppendText("\r\n"+msg);
                rtbMsg.ScrollToCaret();
            }));
        }
        //投票
        private void VoteForOnce()
        {
            WebClient wc = null;
            //ShowBusyUI(true);
            try
            {
                wc = new WebClient();
                NameValueCollection reqparm = new NameValueCollection();
                wc.Headers.Add("Accept: */*");
                wc.Headers.Add("User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET4.0E; .NET4.0C; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; SE 2.X MetaSr 1.0)");
                wc.Headers.Add("Accept-Language: zh-cn");
                wc.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                wc.Headers.Add("Accept-Encoding: gzip, deflate");
                wc.Headers.Add("Cache-Control: no-cache");
                //wc.Headers.Add("Connection: Keep-Alive");//实验证明不能加入keepalive字段，否则会一直报错 
                //wc.Headers.Add(HttpRequestHeader.KeepAlive, "TRUE");
                wc.Headers.Add("Referer", urlVoteRefer);
                reqparm.Add("VoTeid", "320");
                reqparm.Add("Submit", "提交投票");
                //wc.UploadValuesCompleted += new UploadValuesCompletedEventHandler(wc_UploadValuesCompleted);
                //wc.UploadValuesAsync(new Uri(urlVote), "POST", reqparm);
                byte[] result = wc.UploadValues(new Uri(urlVote), "POST", reqparm);
                string htmlstr = Encoding.GetEncoding("gb2312").GetString(result);
                if (htmlstr.Contains("成功"))
                {
                    succCount++;
                    this.Invoke(new EventHandler(delegate
                    {
                        OutMsg("IP:" + ipCurrent + "投票成功一次!");
                        sw.WriteLine("["+DateTime.Now+"]"+"IP:"+ipCurrent+"投票成功一次!当前票数:"+lbRemoteVoteCount.Text+"人气:"+lbRemoteHotCount.Text+"排名:"+lbRemoteRank.Text);
                    }));
                }
                else if (htmlstr.Contains("24小时"))
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        OutMsg("IP:" + ipCurrent + "已经投过了");
                    }));
                    failCount++;
                }
            }
            catch (WebException ex)
            {
                OutMsg("IP:" + ipCurrent + "投票异常,消息:" + ex.Message + "错误码:" + ex.Status);
                failCount++;
            }
            finally
            {
                this.Invoke(new EventHandler(delegate
                {
                    lbSuccCount.Text = succCount.ToString();
                    lbFailCount.Text = failCount.ToString();
                }));
                //ShowBusyUI(false);
                //flagWaitForHttpResponse = false;
                wc.Dispose();
            }
        }
        //增加人气
        private void VoteAddHot(int cnt)
        {
            Random rm = new Random(DateTime.Now.Millisecond);
            int count = rm.Next(0, cnt + 1);
            for (int i = 0; i < count; i++)
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.Headers.Add("Referer", urlAimPageRefer);
                    wc.DownloadDataAsync(new Uri(urlAimPage));
                    this.Invoke(new EventHandler(delegate
                    {
                        OutMsg("IP" + ipCurrent + "刷人气成功一次!");
                    }));
                    wc.Dispose();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    //sw.WriteLine("===刷人气失败:"+ex.Message);
                    OutMsg("刷人气失败:" + ex.Message);
                }
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
