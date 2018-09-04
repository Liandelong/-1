using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 餐饮管理系统
{
    class Menulist
    {
        private string id;
        private string name;
        private string unit;
        private string unitprice;
        private string currentinventory;
        private string  originalprice;
        private string remarks;
        private string num;
        private string datatime;
      
        int i;

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

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }
        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
            }
        }
        public string Unitprice
        {
            get
            {
                return unitprice;
            }

            set
            {
                unitprice = value;
            }
        }

        public string Currentinventory
        {
            get
            {
                return currentinventory;
            }

            set
            {
                currentinventory = value;
            }
        }

        public string Originalprice
        {
            get
            {
                return originalprice;
            }

            set
            {
                originalprice = value;
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

        public string Datatime
        {
            get
            {
                return datatime;
            }

            set
            {
                datatime = value;
            }
        }

        public int I
        {
            get
            {
                return i;
            }

            set
            {
                i = value;
            }
        }
        public Menulist(string id, string name, string unit, string unitprice, string currentinventory, string originalprice, string remarks)
        {
            this.Id = id;
            this.Name = name;
            this.Unit = unit;
            this.Unitprice = unitprice;
            this.Currentinventory= currentinventory;
            this.Originalprice = originalprice;
            this.Remarks=remarks;
        }

        //点餐列
        public Menulist(string id,string name,string unitprice)
        {
            this.Id = id;
            this.Name = name;
            this.Unitprice = unitprice;
        }

        //已选列
        public Menulist(int i,string name, string unitprice,string num,string unit,string datatime)
        {
            this.Name = name;
            this.Unitprice = unitprice;
            this.Unit = unit;
            this.Num = num;
            this.Datatime = datatime;
            this.I = i;
        }
    }
}
