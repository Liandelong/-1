using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 餐饮管理系统
{
   public class VipUers
    {
        private string id;
        private string name;
        private string gender;
        private string garde;
        private string  discount;
        private string iphone;
        private string datatime;

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

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string  Garde
        {
            get
            {
                return garde;
            }

            set
            {
                garde = value;
            }
        }

        public string Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
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
        public VipUers(string id, string name, string gender, string garde, string discount, string iphone, string datatime)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.Garde = garde;
            this.Discount = discount;
            this.Iphone = iphone;
            this.Datatime = datatime;
        }
    }
}
