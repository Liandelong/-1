using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 餐饮管理系统
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument xdoc1;
            xdoc1 = XDocument.Load("4.xml");
            XElement User = new XElement("user");
            User.SetElementValue("name",textBox8.Text);
            User.SetElementValue("iphone", textBox7.Text);
            User.SetElementValue("num", textBox6.Text);
            User.SetElementValue("cash", textBox5.Text);
            xdoc1.Root.Add(User);
            xdoc1.Save("4.xml");
            MessageBox.Show("添加成功");
            comboBox1.Items.Add(textBox8.Text);
        }

        private void Order_Load(object sender, EventArgs e)
        {

            Loading1();
        }

        //加载数据
        public void Loading()
        {
            XDocument xdoc;
           // List<OrderUser> list;
            xdoc = XDocument.Load("4.xml");
            XElement root = xdoc.Root;
           // list = new List<OrderUser>();
            foreach (XElement item in root.Elements())
            {
                if (item.Element("name").Value == comboBox1.Text)
                {
                    label10.Text = item.Element("name").Value;
                    label11.Text = item.Element("iphone").Value;
                    label12.Text = item.Element("num").Value;
                    label13.Text = item.Element("cash").Value;
                }
                //list.Add(new OrderUser(item.Element("name").Value, item.Element("iphone").Value, item.Element("num").Value, item.Element("cash").Value));
            }
        }

        //加载combox数据
        public void Loading1()
        {
            XDocument xdoc;
            xdoc = XDocument.Load("4.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {
                //list.Add(new OrderUser(item.Element("name").Value, item.Element("iphone").Value, item.Element("num").Value, item.Element("cash").Value));
                comboBox1.Items.Add(item.Element("name").Value);
            }
        }

        //加载信息
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Loading();
        }


        //退订
        private void button1_Click(object sender, EventArgs e)
        {
            Remove1();
        }

        public void Remove1()
        {
            XDocument xdoc;
            xdoc = XDocument.Load("4.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {
                if (comboBox1.Text == item.Element("name").Value)
                {
                    item.Remove();
                    xdoc.Save("4.xml");
                    MessageBox.Show("退订成功");
                }
            }
            newform();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        //刷新窗体
        public void newform()
        {
            comboBox1.Items.Clear();
            //comboBox1.Text = "请选择订餐人";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            Loading1();
        }
    }
}
