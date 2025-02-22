using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
    public class cls_detail_takeorder
    {
        public decimal id { get; set; }
        public decimal takeordernumber { get; set; }
        public string pickingnumber { get; set; }
        public string ponumber { get; set; }
        public string barcode { get; set; }
        public string proname { get; set; }
        public string size { get; set; }
        public int qtypercase { get; set; }
        public decimal pcsfree { get; set; }
        public decimal pcsorder { get; set; }
        public decimal packorder { get; set; }
        public float ctnorder { get; set; }
        public decimal totalpcsorder { get; set; }


    }
}
