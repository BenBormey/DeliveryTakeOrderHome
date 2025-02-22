using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.App.CustomerAging
{
  public  class ARAgingRemark
    {
        public bool Checked { get; set; } = true;
        public string InvNumber { get; set; }
        public string Division { get; set; }
        public DateTime DateCheck { get; set; }
        public string Remark { get; set; }
        public DateTime FollowUpDate { get; set; }
        public int DataArea { get; set; } = 0;
        public int ColumnArea { get; set; } = 0;
        public string CusNum { get; set; }
    }
}
