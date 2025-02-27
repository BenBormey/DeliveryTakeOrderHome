using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DeliveryTakeOrder.App.CustomerAging
{
    public partial class ar_aging_report_detail : DevExpress.XtraReports.UI.XtraReport
    {
        public ar_aging_report_detail()
        {
            InitializeComponent();
        }

        private void cellGrandTotal_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;

        }
        int rowNum = 0;

        private void XrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
                  //   sender.Text = rowNum;
        }

        private void cellInvoiceNumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Tag = GetCurrentRow();

        }

        private void ar_aging_report_detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;

        }
    }
}
