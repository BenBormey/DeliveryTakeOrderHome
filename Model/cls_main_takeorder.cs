using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
    internal class cls_main_takeorder
    {
        public decimal Id { get; set; }
        public decimal TakeOrderNumber { get; set; }
        public string PickingNumber { get; set; }
        public DateTime PickingDate { get; set; }
        public string CusNum { get; set; }
        public string CusName { get; set; }
        public decimal DeltoId { get; set; }
        public string Delto { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateRequired { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
