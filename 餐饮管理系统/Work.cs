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
    public partial class Work : Form
    {
        public Work()
        {
            InitializeComponent();
        }

        private void Work_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "全体员工";
            tabPage2.Text = "上班人员";

            //加载数据
            LoadElement();
            LoadElement1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployees Addemployees = new AddEmployees();
            Addemployees.Show();
        }

        //加载全员数据
        public void LoadElement()
        {
            List<Employees> list;
            XDocument xdoc;
            xdoc = XDocument.Load("5.xml");
            XElement root = xdoc.Root;
            list = new List<Employees>();
            foreach (XElement item in root.Elements())
            {
                list.Add(new Employees(item.Attribute("id").Value, item.Element("name").Value,
                    item.Element("position").Value , item.Element("datetime").Value, 
                    item.Element("condition").Value, item.Element("iphone").Value));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
            try
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            catch { }
        }

        //加载上班人员数据
        public void LoadElement1()
        {
            char[] c = {':','-' };//分割时间

            string str1, str2, str3;

            DateTime data = DateTime.Now;
            List<Employees> list;
            XDocument xdoc;
            xdoc = XDocument.Load("5.xml");
            XElement root = xdoc.Root;
            list = new List<Employees>();
            foreach (XElement item in root.Elements())
            {
                string[] str = item.Element("datetime").Value.Split(c, StringSplitOptions.RemoveEmptyEntries);
                if(data.Hour<10)
                {
                  str1 = "0" + data.Hour.ToString();
                }
                else
                {
                   str1 = data.Hour.ToString();
                }
                if (data.Minute < 10)
                {
                    str2 = "0" + data.Minute.ToString();
                }
                else
                {
                    str2 = data.Minute.ToString();
                }
                if (data.Second < 10)
                {
                    str3 = "0" + data.Second.ToString();
                }
                else
                {
                   str3 = data.Second.ToString();
                }
                if (Convert.ToInt32(str[0]+str[1]+str[2])<=Convert.ToInt32(str1+str2  + str3 )&&
                    Convert.ToInt32(str[3] + str[4] + str[5]) >= Convert.ToInt32(str1 + str2 + str3))
                {
                    list.Add(new Employees(item.Attribute("id").Value, item.Element("name").Value,
                        item.Element("position").Value, item.Element("datetime").Value,
                        item.Element("condition").Value, item.Element("iphone").Value));
                }
            }
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = list;
            try
            {
                dataGridView2.SelectedRows[0].Selected = false;
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadElement();
            LoadElement1();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
