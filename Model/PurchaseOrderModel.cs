using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
  public  class PurchaseOrderModel
    {
        public string invoiceNo { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime shipDate { get; set; }
        public string sdId { get; set; }
        public string currencyId { get; set; }
        public List<DetailProductsModel> orderProducts { get; set; }

    }
}
