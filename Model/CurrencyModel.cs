using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
  public  class CurrencyModel
    {
        public string id { get; set; }
        public string description { get; set; }
        public string abbreviation { get; set; }
        public float exchangeRate { get; set; }

        public string fullcurrency
        {
            get
            {
                return string.Format("{0}   {1:N2}", this.abbreviation, this.exchangeRate);
            }
        }

    }
}
