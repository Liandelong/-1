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
    public partial class WaiMai : Form
    {
        public WaiMai()
        {
            InitializeComponent();
        }

        private void WaiMai_Load(object sender, EventArgs e)
        {
            Message();
        }

        //加载客户信息
        private void Message()
        {
            XDocument xdoc;
            List<elemo> list;
            xdoc = XDocument.Load("Recive.xml");
            XElement root = xdoc.Root;
            list = new List<elemo>();
            foreach (XElement item in root.Elements())
            {
                list.Add(new elemo(item.Attribute("name").Value, item.Attribute("iphone").Value, item.Attribute("address").Value));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
            try
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
            catch { }
        }


        //加载客户订单
        private void Message1()
        {
            int p = 0;
            List<XElement> list1 = new List<XElement>();
            XDocument xdoc;
            List<elemo> list;
            xdoc = XDocument.Load("Recive.xml");
            XElement root = xdoc.Root;
            list = new List<elemo>();
            foreach (XElement item in root.Elements())
            {

                if (item.Attribute("name").Value == dataGridView1.SelectedRows[0].Cells[0].Value.ToString() &&
                    item.Attribute("iphone").Value == dataGridView1.SelectedRows[0].Cells[1].Value.ToString())
                {
                    list1.Add(item);
                }
            }
            foreach (XElement item1 in list1.Elements())
            {
                p++;
                list.Add(new elemo(p.ToString(), item1.Element("Menuname").Value, item1.Element("Unitprice").Value, item1.Element("Menudatatime").Value));
            }
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = list;
            try
            {
                dataGridView2.SelectedRows[0].Selected = false;
            }
            catch { }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
                  Message1();
        }
    }
}
