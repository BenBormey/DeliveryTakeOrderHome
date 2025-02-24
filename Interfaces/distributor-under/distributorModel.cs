using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Interfaces.distributor_under
{
  public  class distributorModel
    {
        public Guid id { get; set; } 
        public string companyName { get; set; }
        public string remark { get; set; }
        public Boolean allowManuallyPromotion { get; set; }
        public DateTime createdDate { get; set; }


    }
}
