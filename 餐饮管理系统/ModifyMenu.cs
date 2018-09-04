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
    public partial class ModifyMenu : Form
    {
        public ModifyMenu()
        {
            InitializeComponent();
        }


        XDocument xdoc;
        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            xdoc = XDocument.Load("2.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {
                if (item.Attribute("id").Value == label8.Text)
                {
                    //item.Attribute("id").Value = textBox1.Text;
                    item.Element("name").Value = textBox2.Text;
                    item.Element("unit").Value = textBox3.Text;
                    item.Element("Unitprice").Value = textBox4.Text;
                    item.Element("Currentinventory").Value = textBox5.Text;
                    item.Element("Originalprice").Value = textBox6.Text;
                    item.Element("remarks").Value = textBox7.Text;
                    //item.Element("garde").Value.r
                    xdoc.Save("2.xml");
                    menu.LoadElement();
                    MessageBox.Show("修改成功");
                }
            }
        }

        private void ModifyMenu_Load(object sender, EventArgs e)
        {

        }

        //窗体传值
        public void PassValue(List<string> str)
        {
            label8.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            textBox6.Text = str[5];
            textBox7.Text = str[6];
        }
    }
}
