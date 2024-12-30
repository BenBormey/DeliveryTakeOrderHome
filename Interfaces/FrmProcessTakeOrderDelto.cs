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

    public partial class FrmProcessTakeOrderDelto : Form
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
        public string vDeltoId { get; set; }
        public string vDeltoName { get; set; }

        public FrmProcessTakeOrderDelto()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmProcessTakeOrderDelto_Load(object sender, EventArgs e)
        {
            TxtDeltoId.Text = vDeltoId;
            TxtDeltoName.Text = vDeltoName;
            TimerCustomerLoading.Enabled = true;

            
        }

        private void TimerCustomerLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerCustomerLoading.Enabled = false;

            query = $@"
    DECLARE @vTakeOrderNumber AS NVARCHAR(25) = N'{vTakeOrder}';
    SELECT [DefId] AS [Id], [DelTo]
    FROM [Stock].[dbo].[TPRDelto]
    --WHERE [DefId] NOT IN (SELECT [DelToId] FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] WHERE [TakeOrderNumber] = @vTakeOrderNumber)
    ORDER BY [DelTo];
";
            query = string.Format(query, DatabaseName, vTakeOrder);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbDelto, lists, "DelTo", "Id");
            this.Cursor = Cursors.Default;


        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            if (CmbDelto.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any customer!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbDelto.Focus();
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
            DECLARE @vTakeOrder AS NVARCHAR(25) = N'{vTakeOrder}';
            DECLARE @vDeltoId AS DECIMAL(18,0) = {CmbDelto.SelectedValue};
            DECLARE @vDeltoName AS NVARCHAR(100) = N'{CmbDelto.Text.Trim()}';
            DECLARE @vCusNum_ AS NVARCHAR(8) = N'{vCusNum}';
            DECLARE @vDeltoId_ AS DECIMAL(18,0) = {vDeltoId};
            DECLARE @vAll AS BIT = {(ChkChangeAll.Checked ? 1 : 0)};
            IF (@vAll == 0)
            BEGIN
                UPDATE v
                SET v.DelToId = @vDeltoId, v.DelTo = @vDeltoName
                FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS v
                WHERE (v.TakeOrderNumber = @vTakeOrder) AND (v.CusNum = @vCusNum_) AND (v.DelToId = @vDeltoId_);
            END
            ELSE
            BEGIN
                UPDATE v
                SET v.DelToId = @vDeltoId, v.DelTo = @vDeltoName
                FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS v
                WHERE (v.TakeOrderNumber = @vTakeOrder) AND (v.CusNum = @vCusNum_);
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
    }
}
