using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DeliveryTakeOrder.App.CustomerAging
{
    public partial class AgingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public AgingReport()
        {
            InitializeComponent();
        }
        private void cellInvoice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ARAging o = (ARAging)GetCurrentRow();
            ((XRTableCell)sender).Tag = o;

            if (sender == cellAA)
            {
                ((XRTableCell)sender).ForeColor = o.AA_Color;
            }
            else if (sender == cellAB)
            {
                ((XRTableCell)sender).ForeColor = o.AB_Color;
            }
            else if (sender == cellA)
            {
                ((XRTableCell)sender).ForeColor = o.A_Color;
            }
            else if (sender == cellB)
            {
                ((XRTableCell)sender).ForeColor = o.B_Color;
            }
            else if (sender == cellC)
            {
                ((XRTableCell)sender).ForeColor = o.C_Color;
            }
            else if (sender == cellD)
            {
                ((XRTableCell)sender).ForeColor = o.D_Color;
            }
            else if (sender == cellE)
            {
                ((XRTableCell)sender).ForeColor = o.E_Color;
            }
            else if (sender == cellTotal)
            {
                ((XRTableCell)sender).ForeColor = o.Total_Color;
            }
        }
        private void cellInvoice_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }


        private void AgingReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            // Set the AutoFitToPagesWidth to 1
            this.PrintingSystem.Document.AutoFitToPagesWidth = 1;

            // Set the PaperKind to A4
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;

            // Adjust the zoom to 95%
            this.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Zoom, new object[] { 0.95f });

            // Optionally, you could use ZoomToTextWidth like in the commented-out line:
            // this.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToTextWidth);


        }

        private void cellTerm_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (int.Parse(((XRTableCell)sender).Text) == 0)
            {
                ((XRTableCell)sender).ForeColor = Color.Red;
            }
            else
            {
                ((XRTableCell)sender).ForeColor = Color.Black;
            }
        }
        int rowNum = 0;

        private void cellRowNumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowNum += 1;
            cellRowNumber.Text = rowNum.ToString("No");
        }

        private void cellAA_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
