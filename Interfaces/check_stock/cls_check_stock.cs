using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Interfaces.check_stock
{
   
    public class cls_check_stock
    {
        public string ponumber { get; set; }
        public string cusnum { get; set; }
        public string cusname { get; set; }
        public decimal deltoid { get; set; }
        public string delto { get; set; }
        public DateTime dateorder { get; set; }
        public DateTime daterequired { get; set; }
        public DateTime deliverydate { get; set; }
        public string barcode { get; set; }
        public string proname { get; set; }
        public string size { get; set; }
        public int qtypercase { get; set; }
        public decimal pcsfree { get; set; }
        public decimal pcsorder { get; set; }
        public decimal packorder { get; set; }
        public float ctnorder { get; set; }
        public decimal totalpcsorder { get; set; }
        public decimal takeordernumber { get; set; }
        public string Status { get; set; }
    }

}
