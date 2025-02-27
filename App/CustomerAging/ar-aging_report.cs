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
            cellCurrent.BeforePrint += cellInvoice_BeforePrint;
            cellAA.BeforePrint += cellInvoice_BeforePrint;
            cellAB.BeforePrint += cellInvoice_BeforePrint;
            cellA.BeforePrint += cellInvoice_BeforePrint;
            cellB.BeforePrint += cellInvoice_BeforePrint;
            cellC.BeforePrint += cellInvoice_BeforePrint;
            cellD.BeforePrint += cellInvoice_BeforePrint;
            cellE.BeforePrint += cellInvoice_BeforePrint;
            cellCustomer.BeforePrint += cellInvoice_BeforePrint;
            cellTotal.BeforePrint += cellInvoice_BeforePrint;
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
            cellCurrent.PreviewMouseMove += cellInvoice_PreviewMouseMove;
            cellAA.PreviewMouseMove += cellInvoice_PreviewMouseMove;
            cellAB.PreviewMouseMove += cellInvoice_PreviewMouseMove;
            cellA.PreviewMouseMove += cellInvoice_PreviewMouseMove;
            cellB.PreviewMouseMove += cellInvoice_PreviewMouseMove;
            cellC.PreviewMouseMove += cellInvoice_PreviewMouseMove;
            cellD.PreviewMouseMove += cellInvoice_PreviewMouseMove;
            cellE.PreviewMouseMove += cellInvoice_PreviewMouseMove;

            cellTotal.PreviewMouseMove += cellInvoice_PreviewMouseMove;
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

        private void cellCustomer_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
           
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void xtblData_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {

        }

        private void cellAA_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {

            e.PreviewControl.Cursor = Cursors.Hand;

        }

        private void cellAB_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void cellA_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void cellD_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void cellE_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void cellC_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }

        private void cellB_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            e.PreviewControl.Cursor = Cursors.Hand;
        }
    }
}
