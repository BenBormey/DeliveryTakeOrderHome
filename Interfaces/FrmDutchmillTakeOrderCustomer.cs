using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmDutchmillTakeOrderCustomer : Form
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

        public FrmDutchmillTakeOrderCustomer()
        {
            InitializeComponent();
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void FrmDutchmillTakeOrderCustomer_Load(object sender, EventArgs e)
        {
           TxtCusName.Text = vCusName;
            TxtCusNum.Text = vCusNum;
            BillToLoading.Enabled = true;
            
        }

        private void BillToLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            BillToLoading.Enabled = false;
            query = @"SELECT [CusNum],[CusName]
                FROM [Stock].[dbo].[TPRCustomer]
                WHERE [Status] = N'Activate'
                GROUP BY [CusNum],[CusName]
                ORDER BY [CusName];";

            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbBillTo, lists, "CusName", "CusNum");
            this.Cursor = Cursors.Default;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            if(CmbBillTo.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Please select any customer!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string xCusNum = "";
                if(CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
                {
                    xCusNum = "";
                    if (CmbBillTo.Text.Trim().Equals(""))
                    {
                        xCusNum = "";
                    }
                    else
                    {
                        xCusNum = CmbBillTo.SelectedValue.ToString();
                    }
                }
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    query = @"DECLARE @OldCusNum AS NVARCHAR(8) = N'{1}';
                        DECLARE @vCusNum AS NVARCHAR(8) = N'{2}';
                        DECLARE @vCusName AS NVARCHAR(100) = N'';
                        DECLARE @vDepartment AS NVARCHAR(50) = N'{3}';
                        DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{4}';
                        DECLARE @vDeltoId AS DECIMAL(18,0) = {5};

                        SELECT @vCusName=v.CusName
                        FROM [Stock].[dbo].[TPRCustomer] AS v
                        WHERE v.CusNum = @vCusNum;

                        UPDATE v
                        SET v.[CusNum] = @vCusNum,v.[CusName] = @vCusName
                        FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] AS v
                        WHERE v.[CusNum] = @OldCusNum AND v.[Department] = @vDepartment AND v.[PlanningOrder] = @vPlanningOrder AND v.[DeltoId] = @vDeltoId;";

                    query = string.Format(query, DatabaseName, vCusNum, xCusNum, vDepartment, vDeltoId);
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    DialogResult = DialogResult.OK;
                    this.Close();



                }
                catch (SqlException ex)
                {
                    RTran.Rollback();
                    RCon.Close();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex) {

                    RTran.Rollback();
                    RCon.Close();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information );
                
                }
               
            }


        }
    }
}
