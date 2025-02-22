using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Model
{
   public class ItemModel
    {
        public string name { get; set; }
        public string nameKhmer { get; set; }
        public double sellingCasePrice { get; set; }
        public double buyinCasePrice { get; set; }
        public int qtyPerCase { get; set; }
        public int qtyPerPack { get; set; }
        public string size { get; set; }
        private string unitnumber;
        public string barcode
        {
            get
            {
                string v = (unitnumber == null ? "" : unitnumber).Trim();
                return v.Trim().Equals("") ? "" : v;
            }
            set
            {
                unitnumber = value;
            }
        }
        private string packnumber;
        public string barcodePack
        {
            get
            {
                string v = (packnumber == null ? "" : packnumber).Trim();
                return v.Trim().Equals("") ? "" : v;
            }
            set
            {
                packnumber = value;
            }
        }
        private string casenumber;
        public string barcodeCase
        {
            get
            {
                string v = (casenumber == null ? "" : casenumber).Trim();
                return v.Trim().Equals("") ? "" : v;
            }
            set
            {
                casenumber = value;
            }
        }
        public string category { get; set; }
        public string currencyId { get; set; }
        public string mediaId { get; set; }
        public int sellingToCode { get; set; }
        public string brandId { get; set; }
        public string brandName { get; set; }
        public string[] sdIds { get; set; }
    }
}
