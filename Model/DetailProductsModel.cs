using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
   public class DetailProductsModel
    {
      
            public string barcode { get; set; }
            public string name { get; set; }
            public string size { get; set; }
            public int qtyPerCase { get; set; }
            public int qtyPerPack { get; set; }
            public double buyInCasePrice { get; set; }
            public double sellingCasePrice { get; set; }
            public string category { get; set; }
            public DateTime expiryDate { get; set; }
            public string batchCode { get; set; }
            public string meterialCode { get; set; }
            public double orderCtn { get; set; }
            public int orderPcs { get; set; }
            public int freePcs { get; set; }
       
    }
}
