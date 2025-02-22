using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Interfaces.WS_Products_List
{
    public class cls_ws_products_list
    {
        public string CusNum { get; set; }
        public string CusName { get; set; }
        public string SupNum { get; set; }
        public string SupName { get; set; }
        public string UnitNumber { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal QtyPerCase { get; set; }
        public double WS { get; set; }
        public DateTime Dates { get; set; }
        public string ChangeOrNot { get; set; }
        public string Condition { get; set; }
        public string OrderCycle { get; set; }
        public string PriceChange { get; set; }
        public float Discount { get; set; }
        public float ServiceRebate { get; set; }
        public DateTime LastPurchase { get; set; }
        public string LastInvNo { get; set; }
        public string LastInvType { get; set; }
        public float TotalPurchaseQty { get; set; }
        public DateTime StartDate
        {
            get; set;
        }
    }
}
