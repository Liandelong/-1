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
    public delegate void Det1(string str);
    public partial class Paying : Form
    {
        public Det1 _det;
        public Paying()
        {
            InitializeComponent();
        }

        //委托
        public Paying(Det1 det)
        {
            this._det = det;
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                bool result = Regex.IsMatch(textBox1.Text, "\\d");
                if (textBox1.Text != ""&&result)
                {
                    if (Convert.ToDouble(label13.Text) >= 0)
                    {
                        MessageBox.Show("结账成功");
                        payed();//删除结账桌号的菜单
                        _det(comboBox1.Text);
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("霸王餐！！！");
                    }
                }
                else
                {
                    MessageBox.Show("请输入金额");
                }
            }
            else
            {
                MessageBox.Show("请选择餐桌号");
            }
        }

        private void Paying_Load(object sender, EventArgs e)
        {
            //加载餐桌号
            comboBox1.Items.AddRange(new string[] { "001", "002", "003", "004", "005", "006", "007", "008", "009" });
            //加载会员名
            XDocument xdoc;
            xdoc = XDocument.Load("1.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {
                comboBox2.Items.Add(item.Element("name").Value);
            }
        }

        XDocument xdoc1;
        List<Menulist> list2;
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Loading();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Loading1();
        }

        //餐桌号选择完后，加载余额和数据
       public void Loading()
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
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list2;
            try
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            catch { }

            //余额
            char[] t = { '元' };
            double monney = 0;
            for (int p = 0; p < dataGridView1.Rows.Count; p++)
            {
                string[] str = dataGridView1.Rows[p].Cells[2].Value.ToString().Split(t, StringSplitOptions.RemoveEmptyEntries);
                monney += Convert.ToDouble(str[0]);

            }
            label3.Text = monney.ToString() ;
            label10.Text = label3.Text;
            // label6.Text = dataGridView1.Rows.Count.ToString();

        }

        //会员选择完显示数据

        XDocument xdoc2;
        List<Menulist> list3;
        public void Loading1()
        {
            //System.DateTime time = new System.DateTime();
            //time = System.DateTime.Now;
            xdoc2 = XDocument.Load("1.xml");
            XElement root = xdoc2.Root;
            list3 = new List<Menulist>();
            int z = 0;//打折
            foreach (XElement item in root.Elements())
            {
                if (item.Element("name").Value == comboBox2.Text)
                {
                    label8.Text = item.Element("discount").Value+"折";
                    z = Convert.ToInt32(item.Element("discount").Value);
                    label6.Text = item.Element("garde").Value+"级";
                }
            }
            //余额
            char[] t = { '元' };
            double monney1 = 0;
            for (int p = 0; p < dataGridView1.Rows.Count; p++)
            {
                string[] str = dataGridView1.Rows[p].Cells[2].Value.ToString().Split(t, StringSplitOptions.RemoveEmptyEntries);
                monney1 += Convert.ToDouble(str[0]);

            }
            monney1 = monney1 * 0.1 * z;
            label10.Text = monney1.ToString();
            // label6.Text = dataGridView1.Rows.Count.ToString();

        }

        //textbox1改变，算余额
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool result = Regex.IsMatch(textBox1.Text, "\\d");
            double money2;
            if (textBox1.Text != ""&&result)
            {
                money2 = Convert.ToDouble(textBox1.Text) - Convert.ToDouble(label10.Text);
                label13.Text = money2.ToString();
            }
            else
            {
                label13.Text = (0 - Convert.ToDouble(label10.Text)).ToString();
            }
        }

        //删除结账列表
        XDocument xdoc3;
        List<XElement> list4=new List<XElement>();
        public void payed()
        {
            xdoc3 = XDocument.Load("3.xml");
            XElement root = xdoc3.Root;
            foreach (XElement item in root.Elements())
            {
                if (item.Attribute("idd").Value == comboBox1.Text)
                {
                    list4.Add(item);
                   
                }
            }
            for(int i = 0; i < list4.Count; i++)
            {
                list4[i].Remove();
            }
            xdoc3.Save("3.xml");
        }
    }
}
