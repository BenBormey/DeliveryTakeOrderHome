using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Interfaces.promotion_Id
{
   public class deliveryTakeOrderPromotionIdModel
    {
        public int id { get; set; }
        public string methodOfPayment { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }

        public string promotionId => $"{description} - {methodOfPayment}";
    }
}
