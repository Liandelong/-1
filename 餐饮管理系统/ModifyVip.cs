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
    public partial class ModifyVip : Form
    {

        public ModifyVip()
        {
            InitializeComponent();
        }

        private void ModifyVip_Load(object sender, EventArgs e)
        {
          
        }

       //Vip vip = new Vip(PassValue);
        //窗体传值
        public void PassValue(List<string> str)
        {
            label8.Text = str[0];
            textBox2.Text = str[1];
            if (str[2] == "男")
            {
                radioButton1.Checked=true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            textBox6.Text = str[5];
            dateTimePicker1.Text = str[6];

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void ModifyVip_Shown(object sender, EventArgs e)
        {
        }

        XDocument xdoc;
        //根据编号修改用户
        private void button1_Click(object sender, EventArgs e)
        {
            Vip vip = new Vip();
            xdoc = XDocument.Load("1.xml");
            XElement root = xdoc.Root;
            foreach (XElement item in root.Elements())
            {
                if (item.Attribute("id").Value == label8.Text)
                {
                    //item.Attribute("id").Value = textBox1.Text;
                    item.Element("name").Value = textBox2.Text;
                    if (radioButton1.Checked)
                    {
                        item.Element("gender").Value ="男" ;
                    }
                    else
                    {
                        item.Element("gender").Value = "女";
                    }
                    item.Element("garde").Value = textBox4.Text;
                    item.Element("discount").Value = textBox5.Text;
                    item.Element("iphone").Value = textBox6.Text;
                    item.Element("datatime").Value = dateTimePicker1.Text;
                    //item.Element("garde").Value.r
                    xdoc.Save("1.xml");
                    vip.LoadElement();
                    MessageBox.Show("修改成功");
                }
            }
        }
               
        private void ModifyVip_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
