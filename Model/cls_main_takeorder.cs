using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
    internal class cls_main_takeorder
    {
        public decimal id { get; set; }
        public decimal takeordernumber { get; set; }
        public string pickingnumber { get; set; }
        public DateTime pickingdate { get; set; }
        public string cusnum { get; set; }
        public string cusname { get; set; }
        public decimal deltoid { get; set; }
        public string delto { get; set; }
        public DateTime dateorder { get; set; }
        public DateTime daterequired { get; set; }
        public DateTime deliverydate { get; set; }
        public string reason { get; set; }
        public DateTime createddate { get; set; }


    }
}
