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
    public partial class FrmAlertCustomerHistory : DevExpress.XtraEditors.XtraForm
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
        public decimal vDeltoId { get; set; }

        public FrmAlertCustomerHistory()
        {
            InitializeComponent();
        }
        
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
        }
        private void DataSources(System.Windows.Forms.ComboBox ComboBoxName ,DataTable DTable , string DisplayNumber ,string ValueMember  )
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayNumber;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;


        }
        private void FrmAlertCustomerHistory_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
        }

        private void Loading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Loading.Enabled = false;

            query = @" DECLARE @vQuery AS NVARCHAR(MAX) = N'';
                WITH v AS (
                SELECT [TableName],[Division]
                FROM [Stock].[dbo].[AAllMainDivision]
                WHERE ISNULL([Division],N'') <> N''
                UNION ALL
                SELECT [TableName],[Division]
                FROM [Stock].[dbo].[AAllMainDivisionInvoiceing]
                WHERE ISNULL([Division],N'') <> N'')

                SELECT @vQuery += N'SELECT MAX([InvNumber]) AS [InvNumber],MAX([ShipDate]) AS [ShipDate],[CusNum],[CusCom],N''' + v.Division +  N''' AS [Division]
                FROM [Stock].[dbo].[' + v.TableName + N']
                WHERE [DeltoId] = @vDeltoId
                GROUP BY [CusNum],[CusCom]
                UNION ALL '
                FROM v 
                ORDER BY v.Division;
                SET @vQuery += N'SELECT NULL AS [InvNumber],NULL AS [ShipDate],NULL AS [CusNum],NULL AS [CusCom],NULL AS [Division]';
                SELECT @vQuery = N'
                DECLARE @vDeltoId AS DECIMAL(18,0) = {1};
                WITH o as (
                ' + @vQuery + N'
                )
                SELECT *
                INTO #vCustomer
                FROM o
                WHERE o.InvNumber is not null;
                with v as (
                SELECT MAX(o.InvNumber) as InvNumber,MAX(o.ShipDate) as ShipDate,o.CusNum,o.CusCom
                FROM #vCustomer as o
                WHERE o.InvNumber is not null
                GROUP BY o.CusNum,o.CusCom)
                SELECT MAX(o.InvNumber) as InvNumber,MAX(o.ShipDate) as ShipDate,o.CusNum,o.CusCom,v.Division
                FROM v as o
                INNER JOIN #vCustomer as v on o.InvNumber = v.InvNumber and o.CusNum = v.CusNum
                WHERE o.InvNumber is not null
                GROUP BY o.CusNum,o.CusCom,v.Division
                ORDER BY o.ShipDate DESC,o.CusCom;
                DROP TABLE #vCustomer;
                ';
                EXEC(@vQuery);";
            query = string.Format(query, DatabaseName, vDeltoId);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            this.Cursor = Cursors.Default;
        }
    }
}