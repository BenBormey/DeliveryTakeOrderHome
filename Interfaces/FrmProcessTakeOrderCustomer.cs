using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class FrmProcessTakeOrderCustomer : Form
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
        public decimal vTakeOrder { get; set; }
        public string vCusNum { get; set; }
        public string vCusName { get; set; }
        public decimal vDeltoId { get; set; }

        public FrmProcessTakeOrderCustomer()
        {
            InitializeComponent();
        }

        private void TimerCustomerLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerCustomerLoading.Enabled = false;
            query = @"DECLARE @vTakeOrderNumber AS DECIMAL(18,0) = {1};
                SELECT [CusNum],[CusName],ISNULL([CusNum],N'') + SPACE(3) + ISNULL([CusName],N'') AS [Customer]
                FROM [Stock].[dbo].[TPRCustomer]
                WHERE [Status] = N'Activate'
                --AND [CusNum] NOT IN (SELECT [CusNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill] WHERE [TakeOrderNumber] = @vTakeOrderNumber)
                GROUP BY [CusNum],[CusName],ISNULL([CusNum],N'') + SPACE(3) + ISNULL([CusName],N'')
                ORDER BY [CusName];";
            query = string.Format(query, DatabaseName, vTakeOrder);
            DataSources(CmbCustomer, lists, "CusName", "CusNum");
            this.Cursor = Cursors.Default;
        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            if(CmbCustomer.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Please select any customer!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CmbCustomer.Focus();
                return;
            }
            else
            {
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    query = $@"
        DECLARE @vTakeOrder AS DECIMAL(18,0) = {vTakeOrder};                        
        DECLARE @vDeltoId AS DECIMAL(18,0) = {vDeltoId};
        DECLARE @vCusNumOld AS NVARCHAR(8) = N'{vCusNum}';
        DECLARE @vCusNum AS NVARCHAR(8) = N'{CmbCustomer.SelectedValue}';
        DECLARE @vCusName AS NVARCHAR(100) = N'';
        DECLARE @vAll AS BIT = {(ChkChangeAll.Checked ? 1 : 0)};
        SELECT @vCusName = [CusName] FROM [Stock].[dbo].[TPRCustomer] WHERE [CusNum] = @vCusNum;
        IF (@vAll = 0)
        BEGIN
            UPDATE v
            SET v.CusNum = @vCusNum, v.CusName = @vCusName
            FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS v
            WHERE (v.TakeOrderNumber = @vTakeOrder) AND (v.DeltoId = @vDeltoId) AND (v.CusNum = @vCusNumOld);
        END
        ELSE
        BEGIN
            UPDATE v
            SET v.CusNum = @vCusNum, v.CusName = @vCusName
            FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS v
            WHERE (v.TakeOrderNumber = @vTakeOrder) AND (v.CusNum = @vCusNumOld);
        END
    ";
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex)
                {
                    RTran.Rollback();
                    RCon.Close();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    RTran.Rollback();
                    RCon.Close();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkChangeAll_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
