using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 餐饮管理系统
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
           
        }



        private void but2_Click(object sender, EventArgs e)
        {
            Manager man = new Manager();
            man.Show();
            //Vip vip = new Vip();
            //vip.Show();
        }

        private void but4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void but1_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();

        }

        private void but1_Click_1(object sender, EventArgs e)
        {
            Billing billing = new Billing(ShowMsg);
            billing.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }


        //public void Picshow()
        // {
        //     pictureBox1.Image = Image.FromFile("pic.PNG");
        // }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        Socket Accept;//通信socket
        Socket Socketlisten;//监听socket
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadElement4();
            loading();
            Chat();
        }

       

        //委托传值Billing
        public void ShowMsg(string str, string str1, string str2, int num)
        {

            switch (str1)
            {
                case "001": pictureBox1.BackgroundImage = Image.FromFile(str); break;
                case "002": pictureBox8.BackgroundImage = Image.FromFile(str); break;
                case "003": pictureBox9.BackgroundImage = Image.FromFile(str); break;
                case "004": pictureBox2.BackgroundImage = Image.FromFile(str); break;
                case "005": pictureBox3.BackgroundImage = Image.FromFile(str); break;
                case "006": pictureBox4.BackgroundImage = Image.FromFile(str); break;
                case "007": pictureBox5.BackgroundImage = Image.FromFile(str); break;
                case "008": pictureBox6.BackgroundImage = Image.FromFile(str); break;
                case "009": pictureBox7.BackgroundImage = Image.FromFile(str); break;
            }
            int n = Convert.ToInt32(label23.Text) + Convert.ToInt32(str2);
            label23.Text = n.ToString();
            int l = Convert.ToInt32(str1);
            if (Convert.ToInt32(str2) != 0)
            {
                int m = Convert.ToInt32(label19.Text) + num;
                if (m >= 9)
                { m = 9; }
                label19.Text = m.ToString();

                int p = Convert.ToInt32(label20.Text) - num;
                if (p <= 0)
                { p = 0; }
                label20.Text = p.ToString();
            }
        }


        //委托传值Paying
        public void ShowMsg1(string str1)
        {
            string str = "pic1.PNG";
            switch (str1)
            {
                case "001": pictureBox1.BackgroundImage = Image.FromFile(str); break;
                case "002": pictureBox8.BackgroundImage = Image.FromFile(str); break;
                case "003": pictureBox9.BackgroundImage = Image.FromFile(str); break;
                case "004": pictureBox2.BackgroundImage = Image.FromFile(str); break;
                case "005": pictureBox3.BackgroundImage = Image.FromFile(str); break;
                case "006": pictureBox4.BackgroundImage = Image.FromFile(str); break;
                case "007": pictureBox5.BackgroundImage = Image.FromFile(str); break;
                case "008": pictureBox6.BackgroundImage = Image.FromFile(str); break;
                case "009": pictureBox7.BackgroundImage = Image.FromFile(str); break;
            }

            int m = Convert.ToInt32(label19.Text) - 1;
            if (m <= 0)
            { m = 0; }
            label19.Text = m.ToString();

            int p = Convert.ToInt32(label20.Text) + 1;
            if (p >= 9)
            { p = 9; }
            label20.Text = p.ToString();

        }

        //启动显示数据
        public void loading()
        {
            int[] t = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int sum = 0;
            string str = "pic.PNG";
            XDocument xdoc;
            xdoc = XDocument.Load("3.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {

                switch (item.Attribute("idd").Value)
                {
                    case "001": t[0] = 1; pictureBox1.BackgroundImage = Image.FromFile(str); break;
                    case "002": t[1] = 1; pictureBox8.BackgroundImage = Image.FromFile(str); break;
                    case "003": t[2] = 1; pictureBox9.BackgroundImage = Image.FromFile(str); break;
                    case "004": t[3] = 1; pictureBox2.BackgroundImage = Image.FromFile(str); break;
                    case "005": t[4] = 1; pictureBox3.BackgroundImage = Image.FromFile(str); break;
                    case "006": t[5] = 1; pictureBox4.BackgroundImage = Image.FromFile(str); break;
                    case "007": t[6] = 1; pictureBox5.BackgroundImage = Image.FromFile(str); break;
                    case "008": t[7] = 1; pictureBox6.BackgroundImage = Image.FromFile(str); break;
                    case "009": t[8] = 1; pictureBox7.BackgroundImage = Image.FromFile(str); break;
                }
            }
            foreach (int item in t)
            {
                sum += item;//计算已经开了几张桌子
            }

            int m = Convert.ToInt32(label19.Text) + sum; ;
            if (m <= 0)
            { m = 0; }
            label19.Text = m.ToString();

            int p = Convert.ToInt32(label20.Text) - sum;
            if (p >= 9)
            { p = 9; }
            label20.Text = p.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            label17.Text = time.ToString();
        }

        private void but5_Click(object sender, EventArgs e)
        {
            Paying paying = new Paying(ShowMsg1);
            paying.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadElement3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Work work = new Work();
            work.Show();
        }


        //保存今天人数

        public void LoadElement3()
        {
         
            XDocument xdoc;
            xdoc = XDocument.Load("6.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {
                item.Element("num").Value= label23.Text;
                item.Element("time").Value = DateTime.Now.ToLongDateString().ToString();
            }
            xdoc.Save("6.xml");
        }

        //开机显示今天人数
        public void LoadElement4()
        {

            XDocument xdoc;
            xdoc = XDocument.Load("6.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {
                if (item.Element("time").Value == DateTime.Now.ToLongDateString().ToString())
                {
                    label23.Text = item.Element("num").Value;
                }
            }
        }
        //stoket通信
        private void Chat()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Socketlisten = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //设置监听ip和端口号
            IPAddress ip = IPAddress.Parse("172.19.224.190");//IPAddress.Parse(textBox1.Text);
            IPEndPoint point = new IPEndPoint(ip, 10069);
            //绑定ip和port
            Socketlisten.Bind(point);
            Socketlisten.Listen(10);
            Thread th = new Thread(accept);
            th.IsBackground = true;
            th.Start();
        }
        //接收数据
        void accept()
        {

            try
            {
                while (true)
                {
                    //等待Client连接 
                    Accept = Socketlisten.Accept();
                   //MessageBox.Show(Accept.RemoteEndPoint.ToString() + ":" + "连接成功");
                    Thread th = new Thread(Rcive);
                    th.IsBackground = true;
                    th.Start();
                }
            }
            catch { }
        }

        //接收数据
        private void Rcive()
        {
            char[] t = { '+' };
            XDocument xdoc1;
            xdoc1 = XDocument.Load("Recive.xml");
            XElement User = new XElement("user");
            try
            {
                while (true)
                {
                    Byte[] buff = new Byte[1024 * 1204 * 2];
                    int r = Accept.Receive(buff);
                    if (r == 0)
                    {
                        break;
                    }
                    // MessageBox.Show(Encoding.UTF8.GetString(buff, 0, r ));
                    else
                    {
                        string[] str = Encoding.UTF8.GetString(buff, 0, r).Split(t, StringSplitOptions.RemoveEmptyEntries);
                        User.SetAttributeValue("name", str[0]);
                        User.SetAttributeValue("iphone", str[1]);
                        User.SetAttributeValue("address", str[2]);
                        //User.SetAttributeValue("datatime", str[3]);
                        for (int m = 3; m < str.Length; m = m + 4)
                        {
                            XElement User1 = new XElement("user1");
                            User1.SetElementValue("id", str[m]);
                            User1.SetElementValue("Menuname", str[m + 1]);
                            User1.SetElementValue("Unitprice", str[m + 2]);
                            User1.SetElementValue("Menudatatime", str[m + 3]);
                            User.Add(User1);

                        }
                        xdoc1.Root.Add(User);
                        xdoc1.Save("Recive.xml");
                    }
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            WaiMai waimai = new WaiMai();
            waimai.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
