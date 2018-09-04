using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 餐饮管理系统
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "马冬梅" && textBox2.Text == "666")
            {
                Vip vip = new Vip();
                vip.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("请输入正确的信息");
            }
        }
    }
}
