using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.App.CustomerAging
{
    public class AgingCallcardDetail : ICloneable
    {

        public bool IsChecked { get; set; } = true;
        public decimal InvNumber { get; set; }
        public string PONumber { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CusNum { get; set; }
        public string CusName { get; set; }
        public decimal DeltoId { get; set; }
        public string DelTo { get; set; }
        public string Zone { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string City { get; set; }
        public string SalesmanNumber { get; set; }
        public string SalesmanName { get; set; }
        public string MobileNumber { get; set; }
        public int DaysOver { get; set; }
        public decimal GrandTotal { get; set; }
        public string Division { get; set; }

        // Read-only property
        public string Tel
        {
            get
            {
                string result = Tel1;
                if (!string.IsNullOrEmpty(Tel2))
                {
                    result += $" / {Tel2}";
                }
                return result;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
