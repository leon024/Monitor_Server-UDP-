using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UDP通信程序
{
    public partial class UDPserverForm : Form
    {
        private UdpClient udpserver;//UDP服务器
        private Thread udpListenThread;//UDP监听线程
        private IPEndPoint remoteIpAndPort;//远程IP地址和端口
        private delegate void displayMessageDelegate();//委托
        public int kk = 0;
        
        public UDPserverForm()
        {
            InitializeComponent();            
            udpListenThread = new Thread(new ThreadStart(udpListen));//创建监听线程
            udpListenThread.IsBackground = true;//设为后台线程
            udpListenThread.Start();//启动监听线程
            //↓ 显示本机内网IPv4地址 win7系统
            //this.textBoxHostIp.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[3].ToString();

            for(int i = 0; i < Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length; i++)
            {
                //MessageBox.Show(Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString());
                //↓ 获取本机的IPv4地址，不知道怎么获取，只找到了这个办法
                if (Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].AddressFamily.ToString().Equals("InterNetwork"))
                {
                    this.textBoxHostIp.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString();
                    break;
                }
            }
            textBoxHostIp.Text="121.42.185.160";
        }

        private void udpListen()//监听，线程的实际代码
        {
            int i = 1;
            while (true)//循环，端口不可用自动加1
            {
                try
                {
                    udpserver = new UdpClient(int.Parse(this.textBoxPortNumber.Text));//创建UDP服务器，绑定要监听的端口
                    break;                
                }
                catch
                {
                    //就是将预设的端口号加1
                    this.textBoxPortNumber.Text = (int.Parse(this.textBoxPortNumber.Text)+i++).ToString();
                }
            }

            remoteIpAndPort = new IPEndPoint(IPAddress.Any, 0);//定义IPENDPOINT，装载远程IP地址和端口                    
            string receivedStr;//保存接收的数据字符的临时变量
           
 
            while (true)
            {
                try
                {
                    
                    //将udpserver接受到指定的远程主机的数据包转换成字符串保存在临时变量
                    byte[] by = udpserver.Receive(ref remoteIpAndPort);
                    StringBuilder sb=new StringBuilder();
                    for (int k = 0; k < by.Length; k++)
                    {

                        sb.Append(by[k].ToString("X2"));

                    }                
                    receivedStr =sb.ToString();
                    string SID = receivedStr;
                    SID = SID.Remove(2, 12);
                    string str = receivedStr.Substring(6);
                    string str1 = str.Remove(str.Length - 4, 4);

                    double a = Convert.ToInt32(str1, 16);
                    if (a > Convert.ToInt32("7FFF", 16))
                        a = a - Convert.ToInt32("10000", 16);




                    receivedStr = (a / 10).ToString();

                    DateTime Daytemp = DateTime.Now;
                    string year = Daytemp.Year.ToString();
                    string month = null;
                    string day = null;
                    month = Daytemp.Month.ToString();
                    day = Daytemp.Day.ToString();
                    if (Daytemp.Month.ToString().Length == 1)
                        month = "0" + Daytemp.Month.ToString();

                    if (Daytemp.Day.ToString().Length == 1)
                        day = "0" + Daytemp.Day.ToString();


                    string filename= year + "_" + month + "_" + day+".txt";


                    
                     StreamWriter sw;
                    if (Directory.Exists("D:/Monitor/"+SID+"/")== false)//如果不存在就创建file文件夹{
                        Directory.CreateDirectory("D:/Monitor/" + SID + "/");


                    if (File.Exists("D:/Monitor/" + SID + "/" + filename) == false)
                    {
                        File.Create("D:/Monitor/" + SID + "/" + filename).Close();//创建该文件
                        sw = File.AppendText("D:/Monitor/" + SID + "/" + filename);

                          sw.Write("{\"T\":[{\"time\":\"" + DateTime.Now.ToLongTimeString() + "\",\"temprature\":\"" + receivedStr + "\"}");
                    sw.Close();
                        
                    }
                    sw = File.AppendText("D:/Monitor/" + SID + "/" + filename);

                    //sw.Write(Get_DateTime() + "<t>" + receivedStr + "</t>" + "\r\n");
                        sw.Write(",{\"time\":\""+DateTime.Now.ToLongTimeString()+"\",\"temprature\":\""+receivedStr+"\"}");
                    sw.Close();

                    //定义委托
                    displayMessageDelegate dis = delegate()
                    {
                        //string s = "\n[I received some data]";
                        //byte[] b = System.Text.Encoding.UTF8.GetBytes(s);
                        //this.udpserver.Send(b, b.Length, remoteIpAndPort);//接收到数据后返回 “[I received some data]”
                        this.textBoxRemoteIp.Text = remoteIpAndPort.Address.ToString();//远程主机的IP显示到窗体
                        this.textBoxRemotePort.Text = remoteIpAndPort.Port.ToString();//远程主机的端口号显示到窗体
                        this.richTextBoxRe.AppendText(string.Format("\n{0}", remoteIpAndPort));//显示远程回话(当昵称用)
                        this.richTextBoxRe.AppendText("\n"+receivedStr);//数据报显示到接收区域                        
                        this.richTextBoxRe.ScrollToCaret();//滚动到最下面，显示最新消息
                        //↓ 更新显示本地端口号(无实际意义)
                        this.textBoxPortNumber.Text = ((IPEndPoint)(this.udpserver.Client.LocalEndPoint)).Port.ToString();
                    };

                    this.Invoke(dis);//执行委托
                }
                catch
                {
                    break;
                }
            }
        }
      

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            this.richTextBoxSend.Focus();
            if (this.richTextBoxSend.Text.Length == 1)
            {
                this.richTextBoxSend.Clear();
                return;
            }
            try
            {
                //将发送框中的文本转化成byte数组
                //byte[] b = System.Text.Encoding.UTF8.GetBytes(this.richTextBoxSend.Text);
                byte[] b = System.Text.Encoding.Default.GetBytes(this.richTextBoxSend.Text);
                if (this.checkBoxAppointIp.Checked)
                {
                    remoteIpAndPort.Address = IPAddress.Parse(this.textBoxRemoteIp.Text);
                    remoteIpAndPort.Port = int.Parse(this.textBoxRemotePort.Text);
                }
                this.udpserver.Send(b, b.Length, remoteIpAndPort);
                this.richTextBoxRe.AppendText("\n" + this.textBoxHostIp.Text + ":" + this.textBoxPortNumber.Text);
                this.richTextBoxRe.AppendText("\n"+this.richTextBoxSend.Text);
                this.richTextBoxSend.Clear();
                this.richTextBoxRe.ScrollToCaret();
            }
            catch
            {
                ;
            }
        }

        //修改本地监听端口号则重启线程
        private void buttonUpdatePortNumber_Click(object sender, EventArgs e)
        {
            udpserver.Close();//释放UDP连接
            udpListenThread.Abort();//kill线程
            //重建线程
            udpListenThread = new Thread(new ThreadStart(udpListen));
            udpListenThread.IsBackground = true;
            udpListenThread.Start();
        }

        private void richTextBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buttonSend.PerformClick();
            }
        }

        private void checkBoxAppointIp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAppointIp.Checked)
            {
                this.textBoxRemoteIp.ReadOnly = false;
                this.textBoxRemotePort.ReadOnly = false;
            }
            else
            {
                this.textBoxRemoteIp.ReadOnly = true;
                this.textBoxRemotePort.ReadOnly = true;
            }
        }
    }
}
