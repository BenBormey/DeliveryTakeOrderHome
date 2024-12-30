using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
    internal class cls_detail_takeorder
    {
        public decimal Id { get; set; }
        public decimal TakeOrderNumber { get; set; }
        public string PickingNumber { get; set; }
        public string PoNumber { get; set; }
        public string Barcode { get; set; }
        public string ProName { get; set; }
        public string Size { get; set; }
        public int QtyPerCase { get; set; }
        public decimal PcsFree { get; set; }
        public decimal PcsOrder { get; set; }
        public decimal PackOrder { get; set; }
        public float CtnOrder { get; set; }
        public decimal TotalPcsOrder { get; set; }

    }
}
