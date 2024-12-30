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
    public partial class FrmDutchmillTakeOrderPlanningOrder : Form
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
        public string vCusName { get; set; }
        public decimal vDeltoId { get; set; }
        public string vDelto { get; set; }
        public decimal vId { get; set; }

        public FrmDutchmillTakeOrderPlanningOrder()
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
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }
        private void FrmDutchmillTakeOrderPlanningOrder_Load(object sender, EventArgs e)
        {
            this.LoadingInitialized();
            this.TxtCusNum.Text = vCusNum;
            this.TxtCusName.Text = vCusName;
            this.TxtDeltoId.Text = vDeltoId.ToString();
            this.TxtDelto.Text = vDelto;
            this.PlanningOrderLoading.Enabled = true;
        }

        private void PlanningOrderLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.PlanningOrderLoading.Enabled = false;
            this.query = @"
    WITH v AS (
        SELECT [PlanningOrder]
        FROM [{0}].[dbo].[TblDeliveryTakeOrders_PlanningOrder]
        GROUP BY [PlanningOrder]
    )
    SELECT v.[PlanningOrder]
    FROM v
    GROUP BY v.[PlanningOrder]
    ORDER BY v.[PlanningOrder];
";
            this.query = string.Format(query, DatabaseName);
            DataTable oLists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            this.DataSources(CmbPlanningOrder, oLists, "PlanningOrder", "PlanningOrder");
            this.Cursor = Cursors.Default;

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            if (CmbPlanningOrder.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any planning order!", "Select Planning Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbPlanningOrder.Focus();
                return;
            }
            else
            {
                string oPlanningOrder = "";
                if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
                {
                    oPlanningOrder = "";
                }
                else
                {
                    oPlanningOrder = CmbPlanningOrder.Text.Trim().Equals("") ? "" : CmbPlanningOrder.SelectedValue.ToString();
                }

                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    query = $@"
            DECLARE @vCusNum AS NVARCHAR(8) = N'{vCusNum}';
            DECLARE @vPlanningOrder_ AS NVARCHAR(50) = N'{vPlanning}';
            DECLARE @vDepartment AS NVARCHAR(50) = N'{vDepartment}';
            DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{oPlanningOrder}';
            DECLARE @vDeltoId AS DECIMAL(18,0) = {vDeltoId};
            DECLARE @vId AS DECIMAL(18,0) = {vId};

            UPDATE v
            SET v.[PlanningOrder] = @vPlanningOrder
            FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] AS v
            WHERE v.[Id] = @vId;
        ";
                    query = string.Format(query, DatabaseName, vCusNum, vPlanning, vDepartment, oPlanningOrder, vDeltoId, vId);
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    this.DialogResult = DialogResult.OK;
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
