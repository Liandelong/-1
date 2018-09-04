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

namespace 点餐系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //加载点餐列表
        public void LoadElement()
        {
            XDocument xdoc;
            List<MenuList> list;
            xdoc = XDocument.Load("menu.xml");
            XElement root = xdoc.Root;
            list = new List<MenuList>();
            foreach (XElement item in root.Elements())
            {
                list.Add(new MenuList(item.Attribute("id").Value, item.Element("name").Value, item.Element("Unitprice").Value + "元"));
            }
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = list;
            try
            {
                dataGridView3.SelectedRows[0].Selected = false;
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadElement();
            Order();
        }

        //点餐选中
        private void Chooes()
        {
            Addxml();
            Loading1();
            char[] t = { '元' };
            double monney = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string[] str = dataGridView1.Rows[i].Cells[2].Value.ToString().Split(t, StringSplitOptions.RemoveEmptyEntries);
                monney += Convert.ToDouble(str[0]);

            }
            label20.Text = monney.ToString() + "元";
            label21.Text = dataGridView1.Rows.Count.ToString();
        }

        System.DateTime time = new System.DateTime();
        //增加choose.xml
        public void Addxml()
        {
            XDocument xdoc1;
            time = System.DateTime.Now;
            //time = System.DateTime.Now;
            xdoc1 = XDocument.Load("choose.xml");
            XElement User = new XElement("user");
            User.SetAttributeValue("id", t + 1);
            User.SetElementValue("name", dataGridView3.SelectedRows[0].Cells[1].Value.ToString());
            User.SetElementValue("Unitprice", dataGridView3.SelectedRows[0].Cells[2].Value.ToString());
            User.SetElementValue("datatime",time.ToString());
            xdoc1.Root.Add(User);
            xdoc1.Save("choose.xml");
        }

        //重载函数用于图片点餐
        public void Addxml(string name,string Unitprice)
        {
            XDocument xdoc1;
            time = System.DateTime.Now;
            //time = System.DateTime.Now;
            xdoc1 = XDocument.Load("choose.xml");
            XElement User = new XElement("user");
            User.SetAttributeValue("id", t + 1);
            User.SetElementValue("name", name);
            User.SetElementValue("Unitprice", Unitprice);
            User.SetElementValue("datatime", time.ToString());
            xdoc1.Root.Add(User);
            xdoc1.Save("choose.xml");
        }



        int t;
        //加载已选列表
        public void Loading1()
        {
            List<MenuList> list2;
            XDocument xdoc1;
            xdoc1 = XDocument.Load("choose.xml");
            XElement root = xdoc1.Root;
            list2 = new List<MenuList>();
            int i = 0;
            foreach (XElement item in root.Elements())
            {
                
                    i++;
                    list2.Add(new MenuList(i, item.Element("name").Value,
                        item.Element("Unitprice").Value, item.Element("datatime").Value));
                
            }
            t = i;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list2;
            try
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            catch { }

            char[] y = { '元' };
            double monney = 0;
            for (int n = 0; n< dataGridView1.Rows.Count; n++)
            {
                string[] str = dataGridView1.Rows[n].Cells[2].Value.ToString().Split(y, StringSplitOptions.RemoveEmptyEntries);
                monney += Convert.ToDouble(str[0]);

            }
            label20.Text = monney.ToString() + "元";
            label21.Text = dataGridView1.Rows.Count.ToString();

        }
        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Chooes();
        }

        //退菜
        private void retu()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                XDocument xdoc3 = XDocument.Load("choose.xml");
                XElement root = xdoc3.Root;
                foreach (XElement item in root.Elements())
                {

                    if (item.Element("datatime").Value == dataGridView1.SelectedRows[0].Cells[3].Value.ToString())
                    {
                        item.Remove();
                        xdoc3.Save("choose.xml");
                        Loading1();
                        //MessageBox.Show("退菜成功");
                    }
                }
                char[] t = { '元' };
                double monney = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string[] str = dataGridView1.Rows[i].Cells[2].Value.ToString().Split(t, StringSplitOptions.RemoveEmptyEntries);
                    monney += Convert.ToDouble(str[0]);

                }
                label20.Text = monney.ToString() + "元";
                label21.Text = dataGridView1.Rows.Count.ToString();
            }
            else
            {
                MessageBox.Show("请选择要退的菜");
            }
        }

        //退菜
        private void button7_Click(object sender, EventArgs e)
        {
            retu();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           payed();
        }

        //窗体关闭,清除choose数据
          public void payed()
        {
            XDocument xdoc3;
            List<XElement> list4 = new List<XElement>();
            xdoc3 = XDocument.Load("choose.xml");
            XElement root = xdoc3.Root;
            foreach (XElement item in root.Elements())
            {
                
                    list4.Add(item);

                
            }
            for (int i = 0; i < list4.Count; i++)
            {
                list4[i].Remove();
            }
            xdoc3.Save("choose.xml");
        }

        Socket Socketconnet;
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string str = "192.168.232.1";
                //Soket通信
                try
                {
                    //创建一个连接的socket
                    Socketconnet = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ip = IPAddress.Parse(str);
                    IPEndPoint point = new IPEndPoint(ip, 10066);
                    //连接对方的ip和port
                    Socketconnet.Connect(point);
                    //创建线程接收数据
                     //MessageBox.Show(Socketconnet.RemoteEndPoint.ToString() + ":" + "连接成功");
                    //创建线程接收数据
                    //Thread th = new Thread(Rcive);
                    //th.IsBackground = true;
                    //th.Start();
                    //发数据
                    Send();
                    Order();
                }
                catch{
                    MessageBox.Show("请先打开Sever监听");
                }
              

                //发数据
                //Send();

               // Order();
            }
            else
            {
                MessageBox.Show("姓名|电话|地址不能为空！");
            }
        }

         //发送数据
         private void Send()
        {
            int n = 0;
            string str = null;
            XDocument xdoc;         
            xdoc = XDocument.Load("choose.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {
                n++;
                if (n == 1)
                {
                    str = str + item.Attribute("id").Value + "+" + item.Element("name").Value +
                    "+" + item.Element("Unitprice").Value+"+"+ item.Element("datatime").Value;
                }
                else
                {
                    str = str +"+"+ item.Attribute("id").Value + "+" + item.Element("name").Value +
                    "+" + item.Element("Unitprice").Value+"+" + item.Element("datatime").Value;
                }
            }

            Byte[] buff = Encoding.UTF8.GetBytes(textBox1.Text.Trim()+"+"+textBox3.Text.Trim() +
                "+" + textBox2.Text.Trim()+"+"+str);//new Byte[1024 * 1024 * 2];
            Socketconnet.Send(buff);
        }

        //接收数据
        private void Rcive()
        {
            try
            {
                while (true)
                {
                    Byte[] buff = new Byte[1024 * 1204 * 2];
                    int r = Socketconnet.Receive(buff);
                    if (r == 0)
                    {
                        break;
                    }
                    MessageBox.Show(Encoding.UTF8.GetString(buff, 0, r ));
                }
            }
            catch { }
        }

        //历史订单
        private void Order()
        {
            List<XElement> list4 = new List<XElement>();

            List<MenuList> list2;
            XDocument xdoc1;
            xdoc1 = XDocument.Load("choose.xml");

            XDocument xdoc2;
            xdoc2 = XDocument.Load("history.xml");
            XElement root1 = xdoc2.Root;

            XElement root = xdoc1.Root;
            list2 = new List<MenuList>();
            int i = 0;
            foreach (XElement item in root.Elements())
            {
                xdoc2.Root.Add(item);
            }
            xdoc2.Save("history.xml");

            foreach (XElement item in root1.Elements())
            {

                list4.Add(item);


            }
            for (int n = list4.Count-1; n>=0; n--)
            {
                i++;
                list2.Add(new MenuList(i, list4[n].Element("name").Value,
                  list4[n].Element("Unitprice").Value, list4[n].Element("datatime").Value));
            }
            t = i;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = list2;
            try
            {
                dataGridView2.SelectedRows[0].Selected = false;
            }
            catch { }
            payed();
            Loading1();
        }

        //一键清空历史
        private void button9_Click(object sender, EventArgs e)
        {
            XDocument xdoc3;
            List<XElement> list4 = new List<XElement>();
            xdoc3 = XDocument.Load("history.xml");
            XElement root = xdoc3.Root;
            foreach (XElement item in root.Elements())
            {

                list4.Add(item);


            }
            for (int i = 0; i < list4.Count; i++)
            {
                list4[i].Remove();
            }
            xdoc3.Save("history.xml");
            loading1();

        }

        //加载gridview2
        private void loading1()
        {
            XDocument xdoc;
            List<MenuList> list;
            xdoc = XDocument.Load("history.xml");
            XElement root5 = xdoc.Root;
            list = new List<MenuList>();
            foreach (XElement item in root5.Elements())
            {
                list.Add(new MenuList(Convert.ToInt32(item.Element("id").Value), item.Element("name").Value,
                  item.Element("Unitprice").Value, item.Element("datatime").Value));
            }
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = list;
            try
            {
                dataGridView2.SelectedRows[0].Selected = false;
            }
            catch { }

        }

        /**

        */
        private void button1_Click(object sender, EventArgs e)
        {
            Addxml("宫保鸡丁", "32元");
            Loading1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Addxml("酱骨架", "22元");
            Loading1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Addxml("糖醋鱼", "28元");
            Loading1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Addxml("馍馍", "15元");
            Loading1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Addxml("爱心披萨", "28元");
            Loading1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Addxml("菠萝龙虾", "88元");
            Loading1();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Addxml("三鲜汤", "8元");
            Loading1();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Addxml("家常汤", "8元");
            Loading1();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Addxml("排骨汤", "8元");
            Loading1();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Addxml("落汤鸡", "8元");
            Loading1();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Addxml("布朗尼克号", "18元");
            Loading1();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Addxml("是但", "18元");
            Loading1();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Addxml("双皮奶", "18元");
            Loading1();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Addxml("求其", "18元");
            Loading1();
        }
    }
}
