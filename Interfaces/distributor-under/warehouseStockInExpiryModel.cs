using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Interfaces.distributor_under
{
   public class warehouseStockInExpiryModel
    {

        public string warehouseName { get; set; }
        public string unitNumber { get; set; }
        public string proName { get; set; }
        public string size { get; set; }
        public int qtyPerCase { get; set; }
        public DateTime expiryDate { get; set; }
        public string batchcode { get; set; }
        public int stock { get; set; }
        public string status { get; set; }
        public DateTime curDate { get; set; }
    }
}
