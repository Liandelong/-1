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
    public partial class AddMenu : Form
    {
        public AddMenu()
        {
            InitializeComponent();
        }


        XDocument xdoc;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Menu menu = new Menu();
                xdoc = XDocument.Load("2.xml");
                XElement User = new XElement("user");
                User.SetAttributeValue("id", textBox1.Text);
                User.SetElementValue("name", textBox2.Text);
                User.SetElementValue("unit", textBox3.Text);
                User.SetElementValue("Unitprice", textBox4.Text);
                User.SetElementValue("Currentinventory", textBox5.Text);
                User.SetElementValue("Originalprice", textBox6.Text);
                User.SetElementValue("remarks", textBox7.Text);
                xdoc.Root.Add(User);
                xdoc.Save("2.xml");
                menu.LoadElement();
                MessageBox.Show("添加成功");
                // vip.Refresh();
            }
            catch { MessageBox.Show("请添加完整！！！"); }
        }
    }
}
