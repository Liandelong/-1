using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 餐饮管理系统
{
    class OrderUser
    {
        string name;
        string iphone;
        string num;
        string cash;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Iphone
        {
            get
            {
                return iphone;
            }

            set
            {
                iphone = value;
            }
        }

        public string Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }

        public string Cash
        {
            get
            {
                return cash;
            }

            set
            {
                cash = value;
            }
        }
        public OrderUser(string name,string iphone,string num,string cash)
        {
            this.Name = name;
            this.Iphone = iphone;
            this.Num = num;
            this.Cash = cash;
        }
    }
}
