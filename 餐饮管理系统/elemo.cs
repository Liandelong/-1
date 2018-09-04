using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 餐饮管理系统
{
    class elemo
    {
        private string name;
        private string iphone;
        private string address;
        private string id;
        private string Menuname;
        private string Unitprice;
        private string Menudatatime;

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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Menuname1
        {
            get
            {
                return Menuname;
            }

            set
            {
                Menuname = value;
            }
        }

        public string Unitprice1
        {
            get
            {
                return Unitprice;
            }

            set
            {
                Unitprice = value;
            }
        }

        public string Menudatatime1
        {
            get
            {
                return Menudatatime;
            }

            set
            {
                Menudatatime = value;
            }
        }

        public elemo(string name,string iphone,string address)
        {
            this.Name = name;
            this.Iphone = iphone;
            this.Address = address;
        }

        public elemo(string id,string menuname,string unitprice,string menudatatime)
        {
            this.Id = id;
            this.Menudatatime1 = menudatatime;
            this.Menuname1 = menuname;
            this.Unitprice1 = unitprice;
        }
    }
}
