using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace DeliveryTakeOrder.Interfaces.WS_Products_List
{
    public partial class rpt_ws_products_list : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_ws_products_list()
        {
            InitializeComponent();
        }

        private void rpt_ws_products_list_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void XrTableCell59_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            cls_ws_products_list lst_ = (cls_ws_products_list)this.GetCurrentRow();
            if (DBNull.Value.Equals(lst_.LastPurchase))
            {
                ((XRTableCell)sender).Text = "";
            }
            else
            {
                if (lst_.LastPurchase.ToString() != "0001-01-01")
                {
                    ((XRTableCell)sender).Text = string.Format("{0:yyyy-MM-dd}", lst_.LastPurchase);
                }
            }

        }

        private void XrTableCell62_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            cls_ws_products_list lst_ = (cls_ws_products_list)this.GetCurrentRow();
            if (DBNull.Value.Equals(lst_.StartDate))
            {
                ((XRTableCell)sender).Text = "";
            }
            else
            {
                if (lst_.StartDate.ToString() != "0001-01-01")
                {
                    ((XRTableCell)sender).Text = string.Format("{0:yyyy-MM-dd}", lst_.StartDate);
                }
            }

        }
    }
}
