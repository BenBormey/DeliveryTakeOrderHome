using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
    public  class ClassstoreModel
    {
        public string id { get; set; }
        public string abbr { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public bool isActive { get; set; }
    }
}
