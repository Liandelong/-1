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
    public partial class AddEmployees : Form
    {
        public AddEmployees()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loading();
            this.Close();
        }

        //添加员工
        public void loading()
        {
            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load("5.xml");
                XElement User = new XElement("user");
                User.SetAttributeValue("id", textBox1.Text);
                User.SetElementValue("name", textBox2.Text);
                if (radioButton1.Checked)
                {
                    User.SetElementValue("datetime", radioButton1.Text);
                    User.SetElementValue("condition", "早班");
                }
                else
                {
                    User.SetElementValue("datetime", radioButton2.Text);
                    User.SetElementValue("condition", "晚班");
                }
                User.SetElementValue("position", textBox3.Text);
                User.SetElementValue("iphone", textBox4.Text);
                xdoc.Root.Add(User);
                xdoc.Save("5.xml");
                MessageBox.Show("添加成功");
                // vip.Refresh();
            }
            catch { MessageBox.Show("请添加完整！！！"); }
        }


    }
}
