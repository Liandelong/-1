using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 餐饮管理系统
{
    public delegate void Det(string str,string str1,string str2,int num);
    public partial class Billing : Form
    {
        public Det _det;

        public Billing()
        {
            InitializeComponent();
        }

        public Billing(Det det)
        {
            this._det = det;
            InitializeComponent();
        }

        //加载comBox
        private void Billing_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "001", "002", "003", "004", "005", "006", "007", "008", "009" });
            LoadElement();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        int num=0;
        private void button1_Click(object sender, EventArgs e)
        {
            bool result = Regex.IsMatch(textBox1.Text, "\\d");
            if (result)
            {
                num++;
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("请选择餐桌号");
                }
                else
                {
                    _det("pic.PNG", comboBox1.Text, textBox1.Text, num);
                    MessageBox.Show("开单成功");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("顾客人数请输入整数");
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        //加载点餐列表
        XDocument xdoc;
        List<Menulist> list;
        public void LoadElement()
        {

            xdoc = XDocument.Load("2.xml");
            XElement root = xdoc.Root;
            list = new List<Menulist>();
            foreach (XElement item in root.Elements())
            {
                list.Add(new Menulist(item.Attribute("id").Value, item.Element("name").Value , item.Element("Unitprice").Value+"元"));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
            try
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            catch { }
        }

        private void Billing_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        //双击显示
        List<Menulist> list1;
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            if (comboBox1.Text =="")
            {
                MessageBox.Show("请选择餐桌号");
            }
            else
            {
                Loading();
                Addxml();
                Loading1();
                char[] t = { '元' };
                double monney = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    string[] str = dataGridView2.Rows[i].Cells[2].Value.ToString().Split(t, StringSplitOptions.RemoveEmptyEntries);
                    monney += Convert.ToDouble(str[0]);

                }
                label4.Text = monney.ToString() + "元";
                label6.Text = dataGridView2.Rows.Count.ToString();
            }
        }


        System.DateTime time = new System.DateTime();
       
        public void Loading()
        {
            //System.DateTime time = new System.DateTime();
            time = System.DateTime.Now;
            xdoc = XDocument.Load("2.xml");
            XElement root = xdoc.Root;
            list1 = new List<Menulist>();
            foreach (XElement item in root.Elements())
            {
               
                if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == item.Attribute("id").Value)
                {
                    int i = 0;
                    list1.Add(new Menulist(i,item.Element("name").Value, item.Element("Unitprice").Value + "元",
                        "1", item.Element("unit").Value, time.Hour.ToString()+":"+time.Minute.ToString()+
                        ":"+time.Second.ToString()));
                }

            }
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = list1;
            try
            {
                dataGridView2.SelectedRows[0].Selected = false;
            }
            catch { }
        }

        XDocument xdoc1;
        //增加3.xml
        public void Addxml()
        {
                //time = System.DateTime.Now;
                xdoc1 = XDocument.Load("3.xml");
                XElement User = new XElement("user");
                User.SetAttributeValue("id",t+1);
                User.SetAttributeValue("idd",comboBox1.Text);
                User.SetElementValue("name", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                User.SetElementValue("Unitprice", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                User.SetElementValue("num", "1");
                User.SetElementValue("unit", list1[0].Unit);
                User.SetElementValue("datatime", time.Hour.ToString() + ":" + time.Minute.ToString() +
                        ":" + time.Second.ToString());
                xdoc1.Root.Add(User);
                xdoc1.Save("3.xml");
        }
        List<Menulist> list2;
        int t;
        
        public void Loading1()
        {
            //System.DateTime time = new System.DateTime();
            //time = System.DateTime.Now;
            xdoc1 = XDocument.Load("3.xml");
            XElement root = xdoc1.Root;
            list2 = new List<Menulist>();
            int i = 0;
            foreach (XElement item in root.Elements())
            {
                if (item.Attribute("idd").Value == comboBox1.Text)
                {
                    i++;
                    list2.Add(new Menulist(i, item.Element("name").Value, item.Element("Unitprice").Value,
                       item.Element("num").Value, item.Element("unit").Value, item.Element("datatime").Value));
                }
            }
            t = i;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = list2;
            try
            {
                dataGridView2.SelectedRows[0].Selected = false;
            }
            catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        //退菜
        private void button2_Click_2(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                XDocument xdoc3= XDocument.Load("3.xml");
                XElement root = xdoc3.Root;
                foreach (XElement item in root.Elements())
                {
                    
                    if (item.Element("datatime").Value == dataGridView2.SelectedRows[0].Cells[5].Value.ToString()&&
                        item.Attribute("idd").Value==comboBox1.Text)
                    {
                       
                        item.Remove();
                        xdoc3.Save("3.xml");
                        Loading1();
                        //MessageBox.Show("退菜成功");
                    }
                }
                char[] t = { '元' };
                double monney = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    string[] str = dataGridView2.Rows[i].Cells[2].Value.ToString().Split(t, StringSplitOptions.RemoveEmptyEntries);
                    monney += Convert.ToDouble(str[0]);

                }
                label4.Text = monney.ToString() + "元";
                label6.Text = dataGridView2.Rows.Count.ToString();
            }
            else
            {
                MessageBox.Show("请选择要退的菜");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Loading1();
            char[] t = { '元' };
            double monney = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                string[] str = dataGridView2.Rows[i].Cells[2].Value.ToString().Split(t, StringSplitOptions.RemoveEmptyEntries);
                monney += Convert.ToDouble(str[0]);
            }
            label4.Text = monney.ToString() + "元";
            label6.Text = dataGridView2.Rows.Count.ToString();
        }
    }
}
