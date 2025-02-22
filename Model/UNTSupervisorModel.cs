using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
   public class UNTSupervisorModel
    {
        public string id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string[] phones { get; set; }

        public string lstphone
        {
            get
            {
                if (DBNull.Value.Equals(this.phones) || this.phones == null)
                {
                    return string.Empty;
                }
                else
                {
                    return string.Join(" | ", this.phones);
                }
            }
        }

        public string sdId { get; set; }
        public string sdFullname { get; set; }

    }
}
