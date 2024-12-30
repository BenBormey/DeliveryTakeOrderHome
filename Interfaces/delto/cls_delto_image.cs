using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Interfaces.delto
{
    internal class cls_delto_image
    {
        public decimal ID { get; set; }
        public decimal DeltoID { get; set; }
        public byte[] ImgDelto { get; set; }
        public Image Picture
        {
            get
            {
                using (MemoryStream ms = new MemoryStream(ImgDelto))
                {
                    return Image.FromStream(ms);
                }
            }
        }

    }
}
