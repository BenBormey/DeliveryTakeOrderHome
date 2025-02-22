using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
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

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmDutchmillTakeOrderViewSummaryCredit : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private DatabaseFramework_MySQL MyData = new DatabaseFramework_MySQL();
        private DateTime Todate;
        private PrintToPrinter Printer = new PrintToPrinter();
        private ConvertReport Export = new ConvertReport();
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
        private LocalReport Report;
        private ReportParameter RParameter;
        private string DatabaseName;
        private string query;
        private DataTable lists;
        public string vDepartment { get; set; }
        public string vPlanning { get; set; }

        public FrmDutchmillTakeOrderViewSummaryCredit()
        {
            InitializeComponent();
          
        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
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
                RSheet.Range["A:Z"].Font.Size = 8;
                RSheet.Range["A1"].Value = "Over Credit ~ Customer List";
                RSheet.Range["A2"].Value = "Export Date : " + DateTime.Now.ToString("dd-MMM-yy");
                RSheet.Range["A4"].Value = "Nº";
                RSheet.Range["B4"].Value = "Customer #";
                RSheet.Range["C4"].Value = "Customer Name";
                RSheet.Range["D4"].Value = "DelTo";
                RSheet.Range["E4"].Value = "Grand Total";
                RSheet.Range["F4"].Value = "Credit Limit";
                RSheet.Range["G4"].Value = "Credit Allow";
                RSheet.Range["H4"].Value = "Latest Invoice";
                RSheet.Range["I4"].Value = "Over Credit";
                RSheet.Range["C:C"].NumberFormat = "@";
                RSheet.Range["E:E, F:F, G:G, I:I"].NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* \"-\"??_);_(@_)";
                RSheet.Range["A4:O4"].WrapText = true;
                RSheet.Range["A4:O4"].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                RSheet.Range["A4:O4"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                long QsRow = 5;
                foreach (DataGridViewRow QsDataRow in DgvShow.Rows)
                {
                    RSheet.Range["A" + QsRow].Value = (QsRow - 4);
                    RSheet.Range["B" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CusNum"].Value) ? "" : QsDataRow.Cells["CusNum"].Value;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CusName"].Value) ? "" : QsDataRow.Cells["CusName"].Value;
                    RSheet.Range["D" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["DelTo"].Value) ? "" : QsDataRow.Cells["DelTo"].Value;
                    RSheet.Range["E" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["GrandTotal"].Value) ? "" : QsDataRow.Cells["GrandTotal"].Value;
                    RSheet.Range["F" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CreditLimit"].Value) ? "" : QsDataRow.Cells["CreditLimit"].Value;
                    RSheet.Range["G" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CreditLimitAllow"].Value) ? "" : QsDataRow.Cells["CreditLimitAllow"].Value;
                    RSheet.Range["H" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["LatestInvoice"].Value) ? "" : QsDataRow.Cells["LatestInvoice"].Value;
                    RSheet.Range["I" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["OverCredit"].Value) ? "" : QsDataRow.Cells["OverCredit"].Value;
                    QsRow++;
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

        private void DgvShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvShow.RowCount <= 0) return;
            using (DataGridViewRow row = DgvShow.Rows[DgvShow.CurrentRow.Index])
            {
                string vCusNum = DBNull.Value.Equals(row.Cells["CusNum"].Value) ? "" : row.Cells["CusNum"].Value.ToString().Trim();
                FrmDutchmillTakeOrderViewCredit vFrm = new FrmDutchmillTakeOrderViewCredit
                {
                    vPlanning = vPlanning,
                    vDepartment = vDepartment,
                    vCusNum = vCusNum
                };
                if (vFrm.ShowDialog(this) == DialogResult.Cancel) return;
            }

        }

        private void DisplayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DisplayLoading.Enabled = false;

            query = @"DECLARE @NewLineChar AS CHAR(2) = CHAR(13) + CHAR(10);
                DECLARE @query AS NVARCHAR(MAX) = '';
                DECLARE @CreditLists AS TABLE
                (
	                [InvNumber] [NVARCHAR](25) NULL,
	                [PONumber] [NVARCHAR](50) NULL,
	                [CusNum] [NVARCHAR](8) NULL,
	                [CusName] [NVARCHAR](100) NULL,
	                [ShipDate] [DATE] NULL,
	                [DelTo] [NVARCHAR](100) NULL,
	                [GrandTotal] [MONEY] NULL
                );
                DECLARE @StatementName AS NVARCHAR(100) = N'';
                DECLARE @TableName AS NVARCHAR(100) = N'';
                DECLARE @Division AS NVARCHAR(25) = N'';
                DECLARE @Condition AS NVARCHAR(MAX) = N'';
                DECLARE CUR_DIV CURSOR
                FOR SELECT [TableName],[Division] FROM [Stock].[dbo].[AAllDivisionPayment] WHERE [Division] NOT IN ('Division8', 'Division8 VAT', 'Division9','Division9 VAT', 'Division11', 'Division11 VAT') ORDER BY [Division];
                OPEN CUR_DIV
                FETCH NEXT FROM CUR_DIV INTO @TableName,@Division;
                WHILE @@FETCH_STATUS = 0
                BEGIN
	                SET @query = 'DECLARE @vDepartment AS NVARCHAR(50) = N''{1}'' ' + @NewLineChar;
	                SET @query = @query + 'DECLARE @vPlanningOrder AS NVARCHAR(50) = N''{2}'' ' + @NewLineChar;
	                SET @query = @query + 'SELECT [InvNumber],[PONumber],[CusNum],[CusCom],[ShipDate],[DelTo],[GrandTotal] ' + @NewLineChar;
	                SET @query = @query + 'FROM [Stock].[dbo].[' + @TableName + '] ' + @NewLineChar;
	                SET @query = @query + 'WHERE ISNULL([PAID],''0'') = ''0'' AND [CusNum] IN (SELECT [CusNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE [Department] = @vDepartment AND [PlanningOrder] = @vPlanningOrder GROUP BY [CusNum]) AND [InvNumber] NOT IN (' + @NewLineChar;
	                SET @Condition = '';
	                DECLARE CUR_STA CURSOR
	                FOR SELECT [TableName] FROM [Stock].[dbo].[AAllDivisionStatement] WHERE [Division] = @Division ORDER BY [TableName];
	                OPEN CUR_STA
	                FETCH NEXT FROM CUR_STA INTO @StatementName;
	                WHILE @@FETCH_STATUS = 0
	                BEGIN
		                SET @Condition = @Condition + 'SELECT [InvNumber] ' + @NewLineChar;
		                SET @Condition = @Condition + 'FROM [Stock].[dbo].[' + @StatementName + '] ' + @NewLineChar;
		                SET @Condition = @Condition + 'WHERE [CusNum] IN (SELECT [CusNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE [Department] = @vDepartment AND [PlanningOrder] = @vPlanningOrder GROUP BY [CusNum]) ' + @NewLineChar;
		                SET @Condition = @Condition + 'UNION ALL ' + @NewLineChar;
		                FETCH NEXT FROM CUR_STA INTO @StatementName;
	                END
	                CLOSE CUR_STA;
	                DEALLOCATE CUR_STA;
	                IF (RTRIM(LTRIM(@Condition)) = '')
	                BEGIN
		                SET @Condition = '0';
	                END
	                ELSE
	                BEGIN
		                SET @Condition = @Condition + 'SELECT [InvNumber] ' + @NewLineChar;
                        SET @Condition = @Condition + 'FROM [Stock].[dbo].[TPRDeliveryPaymentViewCreditException] ' + @NewLineChar;
                        SET @Condition = @Condition + 'WHERE [CusNum] IN (SELECT [CusNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE [Department] = @vDepartment AND [PlanningOrder] = @vPlanningOrder GROUP BY [CusNum]) ' + @NewLineChar;
	                END
	                SET @query = @query + @Condition + ' ' + @NewLineChar;
	                SET @query = @query + '); ' + @NewLineChar;
	                INSERT INTO @CreditLists ([InvNumber],[PONumber],[CusNum],[CusName],[ShipDate],[DelTo],[GrandTotal])
	                EXEC(@query);
	                FETCH NEXT FROM CUR_DIV INTO @TableName,@Division;
                END
                CLOSE CUR_DIV;
                DEALLOCATE CUR_DIV;

                WITH v AS (
                SELECT x.CusNum,x.CusName,x.Terms,x.MaxMonthAllow,x.CreditLimit,ISNULL(v.MaxCredit,x.CreditLimitAllow) AS CreditLimitAllow
                FROM Stock.dbo.TPRCustomer AS x
                LEFT OUTER JOIN [{0}].[dbo].[TblCustomerAllowCredits] AS v ON v.CusNum = x.CusNum AND DATEDIFF(DAY,GETDATE(),ISNULL(v.[Expiry],GETDATE())) > 0 )

                SELECT o.CusNum,o.CusName,o.DelTo,SUM(o.GrandTotal) AS GrandTotal,v.CreditLimit,v.CreditLimitAllow
				,v.Terms,v.MaxMonthAllow,DATEDIFF(DAY,MIN(o.ShipDate),GETDATE()) AS LatestInvoice
				,CASE WHEN (SUM(o.GrandTotal) >= v.CreditLimitAllow) THEN (SUM(o.GrandTotal) - v.CreditLimitAllow) ELSE (SUM(o.GrandTotal) - v.CreditLimit) END AS OverCredit
                INTO #vCredit
                FROM @CreditLists AS o INNER JOIN v ON v.CusNum = o.CusNum
                GROUP BY o.CusNum,o.CusName,o.DelTo,v.CreditLimit,v.CreditLimitAllow,v.Terms,v.MaxMonthAllow
                HAVING SUM(o.GrandTotal) >= v.CreditLimit OR SUM(o.GrandTotal) >= v.CreditLimitAllow;

                SELECT o.CusNum,o.CusName,o.DelTo,o.GrandTotal,o.CreditLimit,o.CreditLimitAllow,cast (o.LatestInvoice as nvarchar) + N' day(s)' as LatestInvoice,o.OverCredit
                FROM #vCredit AS o
                ORDER BY o.CusName,o.OverCredit DESC,o.LatestInvoice DESC;

                DROP TABLE #vCredit;";

            query = string.Format(query, DatabaseName, vDepartment, vPlanning);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row  : {0}", DgvShow.RowCount);
            this.Cursor = Cursors.Default;

        }

        private void FrmDutchmillTakeOrderViewSummaryCredit_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DisplayLoading.Enabled = true; }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDutchmillTakeOrderViewSummaryCredit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
