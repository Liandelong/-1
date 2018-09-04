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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            LoadElement();
        }

        XDocument xdoc;
        List<Menulist> list;
        public void LoadElement()
        {

           xdoc = XDocument.Load("2.xml");
            XElement root = xdoc.Root;
            list = new List<Menulist>();
            foreach (XElement item in root.Elements())
            {
                list.Add(new Menulist(item.Attribute("id").Value, item.Element("name").Value, item.Element("unit").Value
                    , item.Element("Unitprice").Value+"元", item.Element("Currentinventory").Value
                    , item.Element("Originalprice").Value , item.Element("remarks").Value));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
            try
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMenu addmenu = new AddMenu();
            addmenu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadElement();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
               ModifyMenu modify = new ModifyMenu();
                Storage();
                modify.PassValue(list1);
                modify.Show();
            }
            else
            {
                MessageBox.Show("请选中用户");
            }
        }


        List<string> list1;
        public void Storage()
        {
            //存储数据
            list1 = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list1.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                XDocument  xdoc = XDocument.Load("2.xml");
                XElement root = xdoc.Root;
                foreach (XElement item in root.Elements())
                {

                    if (item.Attribute("id").Value == dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        item.Remove();
                        xdoc.Save("2.xml");
                        LoadElement();
                        MessageBox.Show("删除成功");
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Loading();
            for (int i = 0; i < list.Count; i++)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = lian;

            }
            try
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            catch { }

        }

        List<Menulist> lian;
        public void Loading()
        {
            xdoc = XDocument.Load("2.xml");
            XElement root = xdoc.Root;
            lian = new List<Menulist>();
            foreach (XElement item in root.Elements())
            {
                if (textBox1.Text == item.Attribute("id").Value | textBox1.Text == item.Element("name").Value)
                {
                    lian.Add(new Menulist(item.Attribute("id").Value, item.Element("name").Value, item.Element("unit").Value
                    , item.Element("Unitprice").Value, item.Element("Currentinventory").Value
                    , item.Element("Originalprice").Value, item.Element("remarks").Value));
                }
            }
        }
    }
}
