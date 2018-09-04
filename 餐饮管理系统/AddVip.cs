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
    public partial class AddVip : Form
    {
        public AddVip()
        {
            InitializeComponent();
        }
        XDocument xdoc;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Vip vip = new Vip();
                xdoc = XDocument.Load("1.xml");
                XElement User = new XElement("user");
                User.SetAttributeValue("id", textBox1.Text);
                User.SetElementValue("name", textBox2.Text);
                if (radioButton1.Checked )
                {
                    User.SetElementValue("gender", radioButton1.Text);
                }
                else
                {
                    User.SetElementValue("gender", radioButton2.Text);
                }
                User.SetElementValue("garde", textBox4.Text);
                User.SetElementValue("discount", textBox5.Text);
                User.SetElementValue("iphone", textBox6.Text);
                User.SetElementValue("datatime", dateTimePicker1.Text);
                xdoc.Root.Add(User);
                xdoc.Save("1.xml");
                vip.LoadElement();
                MessageBox.Show("添加成功");
               // vip.Refresh();
            }
            catch { MessageBox.Show("请添加完整！！！"); }
        }

        private void AddVip_Load(object sender, EventArgs e)
        {

        }
        //public void lian(List<string> p)
        //{

        //}
    }
}
