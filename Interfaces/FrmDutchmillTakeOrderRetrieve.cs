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
    public partial class FrmDutchmillTakeOrderRetrieve : Form
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
        public DateTime vDateRequired { get; set; }
        public DataTable vList { get; set; }
        public string vPlanning { get; set; }
        public string vCusNum { get; set; }
        public decimal vDeltoId { get; set; }
        public string vDepartment { get; set; }

        public FrmDutchmillTakeOrderRetrieve()
        {
            InitializeComponent();
            
        }

        private void FrmDutchmillTakeOrderRetrieve_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            DataSources(CmbPONumber, lists, "PONumber", "DateRequired");
        }
        private void LoadingInitialized()
        {
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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            if (CmbPONumber.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Please select the P.O Numer!", "Select P.O Number ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbPONumber.Focus();
                return;
            }
            else
            {

                Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
                DateTime vDateRequired = Todate;
                if (CmbPONumber.SelectedValue is DataRowView || CmbPONumber.SelectedValue == null)
                {
                    vDateRequired = Todate;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(CmbPONumber.Text.Trim()))
                    {
                        vDateRequired = Todate;
                    }
                    else
                    {
                        vDateRequired = Convert.ToDateTime(CmbPONumber.SelectedValue);
                    }
                }

                query = @" DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                    DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                    DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';                    
                    DECLARE @vRequiredDate AS DATE = N'{5:yyyy-MM-dd}';

                    SELECT [Id],[DateRequired],[Department],[PlanningOrder],[CreatedDate]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder_Locked]
                    WHERE ([Department] = @vDepartment)
                    --AND ([CusNum] = @vCusNum) 
                    --AND ([DeltoId] = @vDeltoId)
                    AND ([PlanningOrder] = @vPlanningOrder)
                    AND (DATEDIFF(DAY,[DateRequired],@vRequiredDate) = 0)
                    ORDER BY [DateRequired];";

                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment, vDateRequired);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

                if (lists != null)
                {
                    if (lists.Rows.Count > 0)
                    {

                        MessageBox.Show($"Sorry, The TakeOrder < {vDateRequired} > cannot retrieve.\r\n Because of the takeorder was processed. \r\n Please check it again...", "Invalid Retrieve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CmbPONumber.Focus();
                        return;

                    }
                }
                this.vDateRequired = vDateRequired;
                this.DialogResult = DialogResult.OK;
               this.Close();
            }
        }
    }
}
