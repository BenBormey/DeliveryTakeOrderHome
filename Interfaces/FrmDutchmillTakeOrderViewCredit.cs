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

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmDutchmillTakeOrderViewCredit : DevExpress.XtraEditors.XtraForm
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
        public string vCusNum { get; set; }


        private void LoadinInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }

        private void DataSources(System.Windows.Forms.ComboBox ComboboxName , DataTable DTtable, string DisplayMember , string ValueMember)
        {
            ComboboxName.DataSource = DTtable;
            ComboboxName.DisplayMember = DisplayMember;
            ComboboxName.ValueMember = ValueMember;
            ComboboxName.SelectedIndex = -1;
        }
        public FrmDutchmillTakeOrderViewCredit()
        {
            InitializeComponent();
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
                RSheet.Range["B4"].Value = "Invoice #";
                RSheet.Range["C4"].Value = "P.O Number";
                RSheet.Range["D4"].Value = "Customer #";
                RSheet.Range["E4"].Value = "Customer Name";
                RSheet.Range["F4"].Value = "Ship Date";
                RSheet.Range["G4"].Value = "DelTo";
                RSheet.Range["H4"].Value = "Amount";
                RSheet.Range["C:C"].NumberFormat = "@";
                RSheet.Range["F:F"].NumberFormat = "dd-MMM-yyyy";
                RSheet.Range["H:H"].NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* \"-\"??_);_(@_)";
                RSheet.Range["A4:O4"].WrapText = true;
                RSheet.Range["A4:O4"].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                RSheet.Range["A4:O4"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                long QsRow = 5;
                foreach (DataGridViewRow QsDataRow in DgvShow.Rows)
                {
                    RSheet.Range["A" + QsRow].Value = (QsRow - 4);
                    RSheet.Range["B" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["InvNumber"].Value) ? "" : QsDataRow.Cells["InvNumber"].Value;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["PONumber"].Value) ? "" : QsDataRow.Cells["PONumber"].Value;
                    RSheet.Range["D" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CusNum"].Value) ? "" : QsDataRow.Cells["CusNum"].Value;
                    RSheet.Range["E" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CusName"].Value) ? "" : QsDataRow.Cells["CusName"].Value;
                    RSheet.Range["F" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ShipDate"].Value) ? "" : QsDataRow.Cells["ShipDate"].Value;
                    RSheet.Range["G" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["DelTo"].Value) ? "" : QsDataRow.Cells["DelTo"].Value;
                    RSheet.Range["H" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["GrandTotal"].Value) ? "" : QsDataRow.Cells["GrandTotal"].Value;
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

        private void FrmDutchmillTakeOrderViewCredit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void FrmDutchmillTakeOrderViewCredit_Load(object sender, EventArgs e)
        {
            LoadinInitialized();
            DisplayLoading.Enabled = true;
        }

        private void DisplayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DisplayLoading.Enabled = true;
            query = @"DECLARE @NewLineChar AS CHAR(2) = CHAR(13) + CHAR(10);
                DECLARE @query AS NVARCHAR(MAX) = '';
                DECLARE @CreditLists AS TABLE
                (
	                [InvNumber] [NVARCHAR](25) NULL,
	                [PONumber] [NVARCHAR](25) NULL,
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
                    SET @query = @query + 'DECLARE @vCusNum AS NVARCHAR(8) = N''{3}'' ' + @NewLineChar;
	                SET @query = @query + 'SELECT [InvNumber],[PONumber],[CusNum],[CusCom],[ShipDate],[DelTo],[GrandTotal] ' + @NewLineChar;
	                SET @query = @query + 'FROM [Stock].[dbo].[' + @TableName + '] ' + @NewLineChar;
	                SET @query = @query + 'WHERE ISNULL([PAID],''0'') = ''0'' AND [CusNum] = @vCusNum AND [InvNumber] NOT IN (' + @NewLineChar;
	                SET @Condition = '';
	                DECLARE CUR_STA CURSOR
	                FOR SELECT [TableName] FROM [Stock].[dbo].[AAllDivisionStatement] WHERE [Division] = @Division ORDER BY [TableName];
	                OPEN CUR_STA
	                FETCH NEXT FROM CUR_STA INTO @StatementName;
	                WHILE @@FETCH_STATUS = 0
	                BEGIN
		                SET @Condition = @Condition + 'SELECT [InvNumber] ' + @NewLineChar;
		                SET @Condition = @Condition + 'FROM [Stock].[dbo].[' + @StatementName + '] ' + @NewLineChar;
		                SET @Condition = @Condition + 'WHERE [CusNum] = @vCusNum ' + @NewLineChar;
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
                        SET @Condition = @Condition + 'WHERE [CusNum] = @vCusNum ' + @NewLineChar;
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

                SELECT o.CusNum,o.CusName,SUM(o.GrandTotal) AS GrandTotal,v.CreditLimit,v.CreditLimitAllow
                INTO #vCredit
                FROM @CreditLists AS o INNER JOIN v ON v.CusNum = o.CusNum
                GROUP BY o.CusNum,o.CusName,v.CreditLimit,v.CreditLimitAllow
                HAVING SUM(o.GrandTotal) >= v.CreditLimit OR SUM(o.GrandTotal) >= v.CreditLimitAllow;

                SELECT o.InvNumber,o.PONumber,o.CusNum,o.CusName,o.ShipDate,o.DelTo,o.GrandTotal
                FROM @CreditLists AS o
                WHERE o.CusNum IN (SELECT v.CusNum FROM #vCredit AS v)
                ORDER BY o.CusName,o.ShipDate ASC;

                DROP TABLE #vCredit;";

            query = string.Format(query, DatabaseName, vDepartment, vPlanning, vCusNum);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row  : {0}", DgvShow.RowCount);
            this.Cursor = Cursors.Default;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}