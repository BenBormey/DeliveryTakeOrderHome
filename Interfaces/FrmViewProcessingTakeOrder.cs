using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.CodeParser;
using DevExpress.XtraGauges.Core.Base;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmViewProcessingTakeOrder : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private string DatabaseName;
        private DateTime Todate;
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
        private string vquery;
        private DataTable vlist;

        public FrmViewProcessingTakeOrder()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }
        private void DataSources(ComboBox comboBoxName, DataTable dTable, string displayMember, string valueMember)
        {
            comboBoxName.DataSource = dTable;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.ValueMember = valueMember;
            comboBoxName.SelectedIndex = -1;
        }
        private string oBarcode_Search;
        private void FrmViewProcessingTakeOrder_Activated(object sender, EventArgs e)
        {
            
        }
        private void CmbInvoiceNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDate.SelectedValue is DataRowView || CmbDate.SelectedValue == null) return;
            this.displayloading.Enabled = true;
        }


        private void FrmViewProcessingTakeOrder_Load(object sender, EventArgs e)
        {
            oBarcode_Search = "";

            this.CustomerLoading.Enabled = true;
            //if(txtbarcode.Text.Trim().Equals("") == true)
            //{
            //    MessageBox.Show("Please enter the barcode whcih you want to search...", "Enter Barcode ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtbarcode.Focus();
            //    return;

            //}
            //oBarcode_Search = txtbarcode.Text.Trim();
            //CmbCustomer_SelectedIndexChanged(CmbCustomer, e);

        }

        private void CmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null) return;
            if (CmbCustomer.Text.Trim().Equals("")) return;

            string vCusNum = CmbCustomer.SelectedValue.ToString();
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            Initialized.R_AllUnpaid = true;
            Initialized.R_DateFrom = Todate;
            Initialized.R_DateTo = Todate;
            oDateFrom = Todate;
            oDateTo = Todate;
            oAllUnpaid = true;
        

            vquery = $@"
    DECLARE @vCusNum AS NVARCHAR(8) = N'{vCusNum}';
    WITH v AS (
        SELECT MIN([DateRequired]) [InvDate]
        FROM [Stock].[dbo].[TPRDeliveryTakeOrder]
        WHERE ([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)
        UNION ALL
        SELECT MIN([DateRequired]) [InvDate]
        FROM [Stock].[dbo].[TPRDeliveryTakeOrderAfterPrintWaitingPicking]
        WHERE ([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)
        UNION ALL
        SELECT MIN([DateRequired]) [InvDate]
        FROM [Stock].[dbo].[TPRDeliveryTakeOrderAfterPrintWaiting]
        WHERE ([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)
        UNION ALL
        SELECT MIN([DateRequired]) [InvDate]
        FROM [Stock].[dbo].[TPRDeliveryTakeOrderAfterPrint]
        WHERE ([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)
        UNION ALL
        SELECT MIN([DateRequired]) [InvDate]
        FROM [Stock].[dbo].[TPRDeliveryTakeOrderAfterPrintFinish]
        WHERE ([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)
    )
    SELECT MIN([InvDate]) [InvDate]
    FROM v;
";
            vquery = string.Format(vquery, DatabaseName, vCusNum);
            vlist = Data.Selects(vquery, Initialized.GetConnectionType(Data, App));

            Initialized.R_AllUnpaid = true;
            Initialized.R_IsCancel = true;

            FrmSelectedPayment oFr = new FrmSelectedPayment
            {
                DTable = vlist
            };
            oFr.ShowDialog();

            if (Initialized.R_IsCancel) return;

            oDateFrom = Initialized.R_DateFrom;
            oDateTo = Initialized.R_DateTo;
            oAllUnpaid = Initialized.R_AllUnpaid;

            this.DeltoLoading.Enabled = true;
            this.displayloading.Enabled = true;

        }

        private void txtbarcode_TextChanged(object sender, EventArgs e)
        {
            oBarcode_Search = "";
        }

        private void CustomerLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.CustomerLoading.Enabled = false;

            string vquery = @"
    WITH v AS (
        SELECT 0 [Index], N'CUS00000' [CusNum], N'All Customers' [CusName]
        UNION ALL 
        SELECT 1 [Index], [CusNum], [CusName]
        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry]
        GROUP BY [CusNum], [CusName]
        UNION ALL 
        SELECT 1 [Index], [CusNum], [CusName]
        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.picking]
        GROUP BY [CusNum], [CusName]
        UNION ALL 
        SELECT 1 [Index], [CusNum], [CusName]
        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.invoicing]
        GROUP BY [CusNum], [CusName]
    )
    SELECT v.[Index], v.CusNum, v.CusName
    FROM v
    GROUP BY v.[Index], v.CusNum, v.CusName
    ORDER BY v.[Index], v.CusName;
";
            vquery = string.Format(vquery, DatabaseName);
            DataTable vlist = Data.Selects(vquery, Initialized.GetConnectionType(Data, App));
            DataSources(CmbCustomer, vlist, "CusName", "CusNum");

            if (CmbCustomer.Items.Count > 0) CmbCustomer.SelectedIndex = 0;

            this.Cursor = Cursors.Default;

        }

        private void DateLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.DateLoading.Enabled = false;

            string vCusNum = "";
            if (CmbCustomer.Text.Trim().Equals("") || CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null)
            {
                vCusNum = "";
            }
            else
            {
                vCusNum = CmbCustomer.SelectedValue.ToString();
            }

            decimal vdeltoid = 0;
            if (CmbDelto.Text.Trim().Equals("") || CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
            {
                vdeltoid = 0;
            }
            else
            {
                vdeltoid = Convert.ToDecimal(CmbDelto.SelectedValue);
            }

            string vquery = $@"
    DECLARE @vCusNum AS NVARCHAR(8) = N'{vCusNum}';
    DECLARE @vdeltoid AS DECIMAL(18,0) = {vdeltoid};
    WITH v AS (
        SELECT CONVERT(DATE, [daterequired]) [Date]
        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry]
        WHERE (([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)) AND ([deltoid] = @vdeltoid)
        GROUP BY CONVERT(DATE, [daterequired])
        UNION ALL 
        SELECT CONVERT(DATE, [daterequired]) [Date]
        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.picking]
        WHERE (([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)) AND ([deltoid] = @vdeltoid)
        GROUP BY CONVERT(DATE, [daterequired])
        UNION ALL 
        SELECT CONVERT(DATE, [daterequired]) [Date]
        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.invoicing]
        WHERE (([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)) AND ([deltoid] = @vdeltoid)
        GROUP BY CONVERT(DATE, [daterequired])
    )
    SELECT v.[Date]
    FROM v
    GROUP BY v.[Date]
    ORDER BY v.[Date];
";
            vquery = string.Format(vquery, DatabaseName, vCusNum, vdeltoid);
            DataTable vlist = Data.Selects(vquery, Initialized.GetConnectionType(Data, App));
            DataSources(CmbDate, vlist, "Date", "Date");

            this.Cursor = Cursors.Default;

        }

        private void displayloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.displayloading.Enabled = false;

            string vCusNum = "";
            if (CmbCustomer.Text.Trim().Equals("") || CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null)
            {
                vCusNum = "";
            }
            else
            {
                vCusNum = CmbCustomer.SelectedValue.ToString();
            }

            decimal vdeltoid = 0;
            if (CmbDelto.Text.Trim().Equals("") || CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
            {
                vdeltoid = 0;
            }
            else
            {
                vdeltoid = Convert.ToDecimal(CmbDelto.SelectedValue);
            }

            string vDate = "";
            if (CmbDate.Text.Trim().Equals("") || CmbDate.SelectedValue is DataRowView || CmbDate.SelectedValue == null)
            {
                vDate = "";
            }
            else
            {
                vDate = CmbDate.SelectedValue.ToString();
            }
            vquery = @" DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                        DECLARE @vdeltoid AS DECIMAL(18,0) = {2};
                        DECLARE @vRequiredDate AS NVARCHAR(MAX) = N'{3}';
                        DECLARE @vDateFrom AS DATE = N'{4:yyyy-MM-dd}';
                        DECLARE @vDateTo AS DATE = N'{5:yyyy-MM-dd}';
                        DECLARE @vbarcode AS NVARCHAR(15) = N'{8}';
                        IF (@vRequiredDate = N'') SET @vRequiredDate = CONVERT(NVARCHAR,CONVERT(DATE,GETDATE()));
                        WITH v AS (
	                        SELECT [ID],[CusName],[CusNum],[DelTo],[dateorder] [DateOrd],CONVERT(DATE,[DateRequired]) [DateRequired],[DeliveryDate],[barcode] [ProNumy],[ProName],[size] [ProPackSize],[qtypercase] [ProQtyPCase],[PcsFree],[PcsOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[takeordernumber] [TakeOrderInvoiceNumber],null [PrintInvoiceNumber],[PromotionMachanic],[category] [ProCat],[ItemDiscount],[remark] [RemarkExpiry],NULL [RelatedKey],[Saleman],N'' [Status]
	                        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry]
	                        WHERE (([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)) AND (([deltoid] = @vdeltoid) OR (0 = @vdeltoid))
	                        {7} AND ((CONVERT(DATE,[DateRequired]) = CONVERT(DATE,@vRequiredDate)) OR (CONVERT(DATE,GETDATE()) = CONVERT(DATE,@vRequiredDate)))
	                        {6} AND (CONVERT(DATE,[DateRequired]) BETWEEN @vDateFrom AND @vDateTo)
                            {9} AND (([barcode] = @vbarcode) OR (N'' = @vbarcode))
	                        UNION ALL
                            SELECT [ID],[CusName],[CusNum],[DelTo],[dateorder] [DateOrd],CONVERT(DATE,[DateRequired]) [DateRequired],[DeliveryDate],[barcode] [ProNumy],[ProName],[size] [ProPackSize],[qtypercase] [ProQtyPCase],[PcsFree],[PcsOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[takeordernumber] [TakeOrderInvoiceNumber],[pickingnumber] [PrintInvoiceNumber],[PromotionMachanic],[category] [ProCat],[ItemDiscount],[remark] [RemarkExpiry],NULL [RelatedKey],[Saleman],N'Picking T.0 @ ' + CONVERT(NVARCHAR,CONVERT(DATE,[pickingdate])) [Status]
	                        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.picking]
	                        WHERE (([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)) AND (([deltoid] = @vdeltoid) OR (0 = @vdeltoid))
	                        {7} AND ((CONVERT(DATE,[DateRequired]) = CONVERT(DATE,@vRequiredDate)) OR (CONVERT(DATE,GETDATE()) = CONVERT(DATE,@vRequiredDate)))
	                        {6} AND (CONVERT(DATE,[DateRequired]) BETWEEN @vDateFrom AND @vDateTo)
                            {9} AND (([barcode] = @vbarcode) OR (N'' = @vbarcode))
	                        UNION ALL
                            SELECT [ID],[CusName],[CusNum],[DelTo],[dateorder] [DateOrd],CONVERT(DATE,[DateRequired]) [DateRequired],[DeliveryDate],[barcode] [ProNumy],[ProName],[size] [ProPackSize],[qtypercase] [ProQtyPCase],[PcsFree],[PcsOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[takeordernumber] [TakeOrderInvoiceNumber],[pickingnumber] [PrintInvoiceNumber],[PromotionMachanic],[category] [ProCat],[ItemDiscount],[remark] [RemarkExpiry],NULL [RelatedKey],[Saleman],N'Invoicing @ ' + CONVERT(NVARCHAR,CONVERT(DATE,[invoicingdate])) [Status]
	                        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.invoicing]
	                        WHERE (([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)) AND (([deltoid] = @vdeltoid) OR (0 = @vdeltoid))
	                        {7} AND ((CONVERT(DATE,[DateRequired]) = CONVERT(DATE,@vRequiredDate)) OR (CONVERT(DATE,GETDATE()) = CONVERT(DATE,@vRequiredDate)))
	                        {6} AND (CONVERT(DATE,[DateRequired]) BETWEEN @vDateFrom AND @vDateTo)
                            {9} AND (([barcode] = @vbarcode) OR (N'' = @vbarcode))
	                        {6}UNION ALL
                            {6}SELECT [ID],[CusName],[CusNum],[DelTo],[dateorder] [DateOrd],CONVERT(DATE,[DateRequired]) [DateRequired],[DeliveryDate],[barcode] [ProNumy],[ProName],[size] [ProPackSize],[qtypercase] [ProQtyPCase],[PcsFree],[PcsOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[takeordernumber] [TakeOrderInvoiceNumber],[pickingnumber] [PrintInvoiceNumber],[PromotionMachanic],[category] [ProCat],[ItemDiscount],[remark] [RemarkExpiry],NULL [RelatedKey],[Saleman],N'Finish @ ' + CONVERT(NVARCHAR,CONVERT(DATE,[finishdate])) [Status]
	                        {6}FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish]
	                        {6}WHERE (([CusNum] = @vCusNum) OR (N'CUS00000' = @vCusNum)) AND (([deltoid] = @vdeltoid) OR (0 = @vdeltoid))
	                        {7}{6} AND ((CONVERT(DATE,[DateRequired]) = CONVERT(DATE,@vRequiredDate)) OR (CONVERT(DATE,GETDATE()) = CONVERT(DATE,@vRequiredDate)))
	                        {6} AND (CONVERT(DATE,[DateRequired]) BETWEEN @vDateFrom AND @vDateTo)
                            {9} AND (([barcode] = @vbarcode) OR (N'' = @vbarcode))
                        )
                        SELECT v.[ID],v.[CusName],v.[CusNum],v.[DelTo],v.[DateOrd],v.[DateRequired],v.[DeliveryDate],v.[ProNumy],v.[ProName],v.[ProPackSize],v.[ProQtyPCase],v.[PcsFree],v.[PcsOrder],v.[CTNOrder],v.[TotalPcsOrder],v.[PONumber],v.[LogInName],v.[TakeOrderInvoiceNumber],v.[PrintInvoiceNumber],v.[PromotionMachanic],v.[ProCat],v.[ItemDiscount],v.[RemarkExpiry],v.[RelatedKey],v.[Saleman],v.[Status]
                        FROM v
                        ORDER BY v.[DateRequired],v.[CusName],v.[ProName];";

            vquery = string.Format(vquery, DatabaseName, vCusNum, vdeltoid, vDate, oDateFrom, oDateTo, oAllUnpaid ? "--" : "", oAllUnpaid ? "" : "--", oBarcode_Search, oBarcode_Search.Trim().Equals("") ? "--" : "");
            DataTable vlist = Data.Selects(vquery, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = vlist;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row : {0:N0}", DgvShow.RowCount);
            this.Cursor = Cursors.Default;



        }

        private void DeltoLoading_Tick(object sender, EventArgs e)
        {

        }

        private void FrmViewProcessingTakeOrder_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName;
        }
        private DateTime oDateFrom;
        private DateTime oDateTo;
        private bool oAllUnpaid;

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            if (DgvShow.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel.Application RExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook RBook = RExcel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet RSheet = (Microsoft.Office.Interop.Excel.Worksheet)RBook.Worksheets[1];
                RSheet.Range["A:Z"].Font.Name = "Arial";
                RSheet.Range["A:Z"].Font.Size = 8;
                RSheet.Range["A1"].Value = "Processing Take Order Report";
                RSheet.Range["A2"].Value = "Export Date : " + DateTime.Now.ToString("dd-MMM-yy");
                RSheet.Range["A4"].Value = "Nº";
                RSheet.Range["B4"].Value = "Customer No.";
                RSheet.Range["C4"].Value = "Customer Name";
                RSheet.Range["D4"].Value = "Delto";
                RSheet.Range["E4"].Value = "Order Date";
                RSheet.Range["F4"].Value = "Required Date";
                RSheet.Range["G4"].Value = "Delivery Date";
                RSheet.Range["H4"].Value = "Barcode";
                RSheet.Range["I4"].Value = "Description";
                RSheet.Range["J4"].Value = "Size";
                RSheet.Range["K4"].Value = "Q/C";
                RSheet.Range["L4"].Value = "PCS Free";
                RSheet.Range["M4"].Value = "PCS Ord.";
                RSheet.Range["N4"].Value = "CTN Ord.";
                RSheet.Range["O4"].Value = "Total PCs Ord.";
                RSheet.Range["P4"].Value = "P.O Number";
                RSheet.Range["Q4"].Value = "T.O Number";
                RSheet.Range["R4"].Value = "Picking Number";
                RSheet.Range["S4"].Value = "Status";
                RSheet.Range["G:G"].NumberFormat = "@";
                RSheet.Range["C:C"].NumberFormat = "dd-MMM-yy";
                // RSheet.Range["O:O, P:P"].NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* \"-\"??_);_(@_)";
                RSheet.Range["A4:T4"].WrapText = true;
                RSheet.Range["A4:T4"].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                RSheet.Range["A4:T4"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                long QsRow = 5;
                foreach (DataGridViewRow QsDataRow in DgvShow.Rows)
                {
                    RSheet.Range["A" + QsRow].Value = (QsRow - 4);
                    RSheet.Range["B" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CusNum"].Value) ? "" : QsDataRow.Cells["CusNum"].Value;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CusName"].Value) ? "" : QsDataRow.Cells["CusName"].Value;
                    RSheet.Range["D" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["DelTo"].Value) ? "" : QsDataRow.Cells["DelTo"].Value;
                    RSheet.Range["E" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["DateOrd"].Value) ? "" : QsDataRow.Cells["DateOrd"].Value;
                    RSheet.Range["F" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["DateRequired"].Value) ? "" : QsDataRow.Cells["DateRequired"].Value;
                    RSheet.Range["G" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["DeliveryDate"].Value) ? "" : QsDataRow.Cells["DeliveryDate"].Value;
                    RSheet.Range["H" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ProNumy"].Value) ? "" : QsDataRow.Cells["ProNumy"].Value;
                    RSheet.Range["I" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ProName"].Value) ? "" : QsDataRow.Cells["ProName"].Value;
                    RSheet.Range["J" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ProPackSize"].Value) ? "" : QsDataRow.Cells["ProPackSize"].Value;
                    RSheet.Range["K" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ProQtyPCase"].Value) ? "" : QsDataRow.Cells["ProQtyPCase"].Value;
                    RSheet.Range["L" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["PcsFree"].Value) ? "" : QsDataRow.Cells["PcsFree"].Value;
                    RSheet.Range["M" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["PcsOrder"].Value) ? "" : QsDataRow.Cells["PcsOrder"].Value;
                    RSheet.Range["N" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CTNOrder"].Value) ? "" : QsDataRow.Cells["CTNOrder"].Value;
                    RSheet.Range["O" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["TotalPcsOrder"].Value) ? "" : QsDataRow.Cells["TotalPcsOrder"].Value;
                    RSheet.Range["P" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["PONumber"].Value) ? "" : QsDataRow.Cells["PONumber"].Value;
                    RSheet.Range["Q" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["TakeOrderInvoiceNumber"].Value) ? "" : QsDataRow.Cells["TakeOrderInvoiceNumber"].Value;
                    RSheet.Range["R" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["PrintInvoiceNumber"].Value) ? "" : QsDataRow.Cells["PrintInvoiceNumber"].Value;
                    RSheet.Range["S" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["Status"].Value) ? "" : QsDataRow.Cells["Status"].Value;
                    QsRow++;
                }

                RSheet.Columns.AutoFit();
                RSheet.Range["A:A"].ColumnWidth = 4;
                RExcel.Visible = true;

                App.ReleaseObject(RSheet);
                App.ReleaseObject(RBook);
                App.ReleaseObject(RExcel);
            }

        }

        private void CmbDelto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DateLoading.Enabled = true;
        }

        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;

            if ((e.KeyChar >= (char)Keys.A && e.KeyChar <= (char)Keys.Z) || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
            {
                if (txtbarcode.Text.Trim() != "" && !Information.IsNumeric(txtbarcode.Text.Trim())) e.Handled = true;
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else
            {
                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 15);
            }

        }

        private void txtbarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                BtnSearch_Click(BtnSearch, new System.EventArgs());  
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            oBarcode_Search = "";
            if (txtbarcode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the barcode which you want to search...", "Enter Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbarcode.Focus();
                return;
            }
            oBarcode_Search = txtbarcode.Text.Trim();
            CmbCustomer_SelectedIndexChanged(CmbCustomer, e);

        }
    }
}
