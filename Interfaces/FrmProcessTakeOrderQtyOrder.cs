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
    public partial class FrmProcessTakeOrderQtyOrder : Form
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
        public string vBarcode { get; set; }
        public string vProName { get; set; }
        public string vSize { get; set; }
        public int vQtyPerCase { get; set; }
        public decimal vPcsOrder { get; set; }
        public decimal vPackOrder { get; set; }
        public decimal vCTNOrder { get; set; }
        public decimal vId { get; set; }

        public FrmProcessTakeOrderQtyOrder()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }

        private void FrmProcessTakeOrderQtyOrder_Load(object sender, EventArgs e)
        {
            TxtBarcode.Text = vBarcode;
            TxtProName.Text = vProName;
            TxtSize.Text = vSize;
            TxtQtyPerCase.Text = vQtyPerCase.ToString();
            TxtOldPcsOrder.Text = string.Format("{0:N0}", vPcsOrder);
            TxtOldPackOrder.Text = string.Format("{0:N0}", vPackOrder);
            TxtOldCTNOrder.Text = string.Format("{0:N2}", vCTNOrder);

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

        private void TxtNewCTNOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Float, null, 10);
        }

        private void TxtNewPackOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);

        }

        private void TxtNewPcsOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            if (TxtNewPcsOrder.Text.Trim().Equals("") && TxtNewPackOrder.Text.Trim().Equals("") && TxtNewCTNOrder.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the quantity order!", "Enter Quantity Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNewPcsOrder.Focus();
                return;
            }
            else
            {
                decimal vNewPcsOrder = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtNewPcsOrder.Text.Trim()) ? "0" : TxtNewPcsOrder.Text.Trim());
                decimal vNewPackOrder = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtNewPackOrder.Text.Trim()) ? "0" : TxtNewPackOrder.Text.Trim());
                decimal vNewCTNOrder = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtNewCTNOrder.Text.Trim()) ? "0" : TxtNewCTNOrder.Text.Trim());
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
            DECLARE @vBarcode AS NVARCHAR(MAX) = N'{vBarcode}';
            DECLARE @vNewPcsOrder AS DECIMAL(18,0) = {vNewPcsOrder};
            DECLARE @vNewPackOrder AS DECIMAL(18,0) = {vNewPackOrder};
            DECLARE @vNewCTNOrder AS DECIMAL(18,0) = {vNewCTNOrder};
            DECLARE @vId AS DECIMAL(18,0) = {vId};
            IF (@vNewPcsOrder IS NULL) SET @vNewPcsOrder = 0;
            IF (@vNewPackOrder IS NULL) SET @vNewPackOrder = 0;
            IF (@vNewCTNOrder IS NULL) SET @vNewCTNOrder = 0;
            UPDATE v
            SET v.PcsOrder = @vNewPcsOrder, v.PackOrder = @vNewPackOrder, v.CTNOrder = @vNewCTNOrder, v.TotalPcsOrder = (@vNewPcsOrder + (@vNewPackOrder * ISNULL(v.QtyPPack,1)) + (@vNewCTNOrder * ISNULL(v.QtyPCase,1))) 
            FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS v
            WHERE v.Id = @vId;
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
