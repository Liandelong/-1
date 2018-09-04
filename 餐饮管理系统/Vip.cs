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
    //通过委托传值
   
    public partial class Vip : Form
    {
        List<string> list1; 

       
      
        public Vip()
        {
            InitializeComponent();
        }
        //XDocument xdoc ;
        private void Vip_Load(object sender, EventArgs e)
        {
            LoadElement();
        }

        //加载数据
        List<VipUers> list;
        XDocument xdoc;
        public void LoadElement()
        {
           
            xdoc = XDocument.Load("1.xml");
            XElement root = xdoc.Root;
            list = new List<VipUers>();
            foreach (XElement item in root.Elements())
            {
                list.Add(new VipUers(item.Attribute("id").Value, item.Element("name").Value, item.Element("gender").Value
                    , item.Element("garde").Value, item.Element("discount").Value, item.Element("iphone").Value
                    , item.Element("datatime").Value));
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
            AddVip Addvip = new AddVip();
            Addvip.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ModifyVip modify = new ModifyVip();
                Storage();
                modify.PassValue(list1);
                modify.Show();
            }
            else
            {
                MessageBox.Show("请选中用户");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                XDocument xdoc; xdoc = XDocument.Load("1.xml");
                XElement root = xdoc.Root;
                foreach (XElement item in root.Elements())
                {

                    if (item.Attribute("id").Value == dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        item.Remove();
                        xdoc.Save("1.xml");
                        LoadElement();
                        MessageBox.Show("删除成功");
                    }
                }
            }
        }

        public void Storage()
        {
            //存储数据
            list1 = new List<string>();
            for(int i = 0; i < 7; i++)
            {
                list1.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadElement();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Loading();
            for (int i=0; i < list.Count; i++)
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


        //查询
        List<VipUers> lian;
        public void Loading()
        {
            xdoc = XDocument.Load("1.xml");
            XElement root = xdoc.Root;
            lian= new List<VipUers>();
            foreach (XElement item in root.Elements())
            {
                if (textBox1.Text == item.Attribute("id").Value | textBox1.Text == item.Element("name").Value)
                {
                    lian.Add(new VipUers(item.Attribute("id").Value, item.Element("name").Value, item.Element("gender").Value
                        , item.Element("garde").Value, item.Element("discount").Value, item.Element("iphone").Value
                        , item.Element("datatime").Value));
                }
            }
        }
    }
}
