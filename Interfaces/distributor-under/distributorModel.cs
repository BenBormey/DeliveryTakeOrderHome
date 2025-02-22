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
        public string warehouseId { get; set; }
        public string khmerName { get; set; }
        public string warehouseName { get; set; }
        public string khmerAddress { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string contactName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string note { get; set; }
        public string status { get; set; }
        public bool allowManuallyPromotion { get; set; }
        public DateTime createddate { get; set; }
        public string url { get; set; }

        public string urlGallery
        {
            get
            {
                return url ?? "https://res.cloudinary.com/dqjqk3ryn/image/upload/v1732509917/unt-wholesale/default.png";
            }
        }

        public Image photo
        {
            get
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] bytes = wc.DownloadData(urlGallery);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
        }


    }
}
