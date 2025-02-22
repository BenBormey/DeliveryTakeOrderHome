using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
   public class ProductsModel :ItemModel
    {
        private string id_;
        public string id
        {
            get
            {
                string v = (id_ == null ? "" : id_).Trim();
                return v.Trim().Equals("") ? "" : v;
            }
            set
            {
                id_ = value;
            }
        }

        public string currencyAbbreviation { get; set; }
        public ImageModel profilePicture { get; set; }
        public DateTime createdAt { get; set; }

    }
}
