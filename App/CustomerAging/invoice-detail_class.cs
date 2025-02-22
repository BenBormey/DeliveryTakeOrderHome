using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.App.CustomerAging
{
   public class invoicedetail
    {
        public decimal InvNumber { get; set; }
        public DateTime ShipDate { get; set; }
        public string CusNum { get; set; }
        public string CusName { get; set; }
        public string CusCom { get; set; }
        public decimal DeltoId { get; set; }
        public string DelTo { get; set; }
        public string ProNumY { get; set; }
        public string ProName { get; set; }
        public string ProPacksize { get; set; }
        public string SupNum { get; set; }
        public string SupName { get; set; }
        public string OrderAmount { get; set; }
        public string PcsOrder { get; set; }
        public double GrandAmount { get; set; }
        public string TableName { get; set; }
        public string Division { get; set; }
    }
}
