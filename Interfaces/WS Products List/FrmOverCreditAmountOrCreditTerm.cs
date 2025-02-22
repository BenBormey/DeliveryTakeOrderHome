using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;
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

namespace DeliveryTakeOrder.Interfaces.WS_Products_List
{
    public partial class FrmOverCreditAmountOrCreditTerm : DevExpress.XtraEditors.XtraForm
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private DateTime Todate;
        private PrintToPrinter Printer = new PrintToPrinter();
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
        private LocalReport Report;
        private ReportParameter RParameter;
        private string DatabaseName;
        private string query;
        private DataTable lists;
        public DateTime RequiredDate { get; set; }

        public FrmOverCreditAmountOrCreditTerm()
        {
            InitializeComponent();

        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            if (DgvShow.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel.Application RExcel;
                Microsoft.Office.Interop.Excel.Workbook RBook;
                Microsoft.Office.Interop.Excel.Worksheet RSheet;
                RExcel = new Microsoft.Office.Interop.Excel.Application();
                RBook = RExcel.Workbooks.Add(Type.Missing);
                RSheet = RBook.Worksheets[1];
                RSheet.Range["A:Z"].Font.Name = "Arial";
                // RSheet.Range["D:J"].Font.Name = "Webdings";
                RSheet.Range["A4:Z4"].Font.Name = "Arial";
                RSheet.Range["A:Z"].Font.Size = 8;
                RSheet.Range["D:J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                RSheet.Range["D:J"].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                RSheet.Range["A1"].Value = "Over Credit Amount | Over Credit Term";
                RSheet.Range["A2"].Value = "Export Date : " + DateTime.Now.ToString("dd-MMM-yy");
                RSheet.Range["A4:K4"].Font.Bold = true;
                RSheet.Range["A4"].Value = "Nº";
                RSheet.Range["B4"].Value = "Cus.#";
                RSheet.Range["C4"].Value = "Cus. Name";
                RSheet.Range["D4"].Value = "Grand Total";
                RSheet.Range["E4"].Value = "Over Day";
                RSheet.Range["F4"].Value = "Credit (Allow)";
                RSheet.Range["G4"].Value = "Term (Allow)";
                RSheet.Range["H4"].Value = "Average (Last 3 Months)";
                RSheet.Range["I4"].Value = "New Proposing Credit Limit";

                RSheet.Range["B:B"].NumberFormat = "@";
                RSheet.Range["D:D, F:F, H:H"].NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                long QsRow = 5;
                double vGrandTotal = 0;
                double vCreditAllow = 0;
                decimal vIndex = 1;
                string vCusNum = "";
                foreach (DataGridViewRow QsDataRow in DgvShow.Rows)
                {
                    vGrandTotal = Convert.ToDouble(DBNull.Value.Equals(QsDataRow.Cells["GrandTotal"].Value) ? "" : QsDataRow.Cells["GrandTotal"].Value);
                    vCreditAllow = Convert.ToDouble(DBNull.Value.Equals(QsDataRow.Cells["CreditLimitAllow"].Value) ? "" : QsDataRow.Cells["CreditLimitAllow"].Value);
                    vCusNum = DBNull.Value.Equals(QsDataRow.Cells["CusNum"].Value) ? "" : QsDataRow.Cells["CusNum"].Value.ToString().Trim();
                    RSheet.Range["A" + QsRow].Value = vIndex;
                    RSheet.Range["B" + QsRow].Value = vCusNum;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CusCom"].Value) ? "" : QsDataRow.Cells["CusCom"].Value;
                    RSheet.Range["D" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["GrandTotal"].Value) ? "" : QsDataRow.Cells["GrandTotal"].Value;
                    RSheet.Range["E" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["Overday"].Value) ? "" : QsDataRow.Cells["Overday"].Value;
                    RSheet.Range["F" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CreditLimitAllow"].Value) ? "" : QsDataRow.Cells["CreditLimitAllow"].Value;
                    RSheet.Range["G" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["MaxMonthAllow"].Value) ? "" : QsDataRow.Cells["MaxMonthAllow"].Value;
                    RSheet.Range["H" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["Average"].Value) ? "" : QsDataRow.Cells["Average"].Value;
                    if (vGrandTotal > vCreditAllow)
                    {
                        // RSheet.Range["A" + QsRow + ":G" + QsRow].EntireRow.Interior.ColorIndex = Color.Red;
                        RSheet.Range["A" + QsRow + ":I" + QsRow].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    }
                    else
                    {
                        RSheet.Range["A" + QsRow + ":I" + QsRow].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    }
                    vIndex++;
                }
                RSheet.Columns.AutoFit();
                RSheet.Range["A:A"].ColumnWidth = 4;
                RExcel.Visible = true;
                App.ReleaseObject(RSheet);
                App.ReleaseObject(RBook);
                App.ReleaseObject(RExcel);
            }
            else
            {
                MessageBox.Show("No record to export to excel!", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void FrmOverCreditAmountOrCreditTerm_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
        }
    }
}