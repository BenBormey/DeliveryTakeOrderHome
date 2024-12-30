using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
    public  class SDModel
    {
        public string id { get; set; }
        public string cusNum { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string[] phones { get; set; }
        public string lstphone { get { if (phones == null || phones.Length == 0) { return string.Empty; } else { return string.Join(" | ", phones); } } }
        public string status { get; set; }
    }
}
