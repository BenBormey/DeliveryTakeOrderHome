using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.XtraRichEdit.Import.Doc;
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
    public partial class FrmDutchmillTakeOrderQty : Form
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
        public decimal vId { get; set; }
        public string vBarcode { get; set; }
        public string vProName { get; set; }
        public string vSize { get; set; }
        public int vQtyPerCase { get; set; }
        public decimal vPcsOrder { get; set; }
        public decimal vCTNOrder { get; set; }

        public FrmDutchmillTakeOrderQty()
        {
            InitializeComponent();
        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }
        private void FrmDutchmillTakeOrderQty_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            TxtBarcode.Text = vBarcode;
            TxtProName.Text = vProName;
            TxtSize.Text = vSize;
            TxtQtyPerCase.Text = vQtyPerCase.ToString();
            TxtOldPcsOrder.Text = String.Format("{0:N0}", vPcsOrder);
        TxtOldCTNOrder.Text = String.Format("{0:N2}", vCTNOrder);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            if (string.IsNullOrWhiteSpace(TxtNewPcsOrder.Text.Trim()) && string.IsNullOrWhiteSpace(TxtNewCTNOrder.Text.Trim()))
            {
                MessageBox.Show("Please enter the quantity order!", "Enter Quantity Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNewPcsOrder.Focus();
                return;
            }
            else
            {
                decimal vNewPcsOrder = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtNewPcsOrder.Text.Trim()) ? "0" : TxtNewPcsOrder.Text.Trim());
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
            DECLARE @vId AS DECIMAL(18,0) = {vId};
            DECLARE @vBarcode AS NVARCHAR(MAX) = N'{vBarcode}';
            DECLARE @vNewPcsOrder AS DECIMAL(18,0) = {vNewPcsOrder};
            DECLARE @vNewCTNOrder AS DECIMAL(18,0) = {vNewCTNOrder};
            IF (@vNewPcsOrder IS NULL) SET @vNewPcsOrder = 0;
            IF (@vNewCTNOrder IS NULL) SET @vNewCTNOrder = 0;
            UPDATE v
            SET v.PcsOrder = @vNewPcsOrder, v.CTNOrder = @vNewCTNOrder, v.TotalPcsOrder = (@vNewPcsOrder + (@vNewCTNOrder * ISNULL(v.QtyPerCase,1))), [VerifyDate] = GETDATE()
            FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] AS v
            WHERE v.Id = @vId AND v.Barcode = @vBarcode;
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

        private void TxtNewPcsOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);

        }

        private void TxtNewCTNOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number,null , 10);
        }
    }
}
