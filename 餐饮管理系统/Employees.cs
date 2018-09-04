using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 餐饮管理系统
{
    class Employees
    {
        string id;
        string name;
        string position;
        string datetime;
        string condition;
        string iphone;

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

        public string Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public string Datetime
        {
            get
            {
                return datetime;
            }

            set
            {
                datetime = value;
            }
        }

        public string Condition
        {
            get
            {
                return condition;
            }

            set
            {
                condition = value;
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
        public Employees(string id,string name,string position,string datetime,
            string condition,string iphone)
        {
            this.Id = id;
            this.Name = name;
            this.Position = position;
            this.Datetime = datetime;
            this.Condition = condition;
            this.Iphone = iphone;
        }
    }
}
