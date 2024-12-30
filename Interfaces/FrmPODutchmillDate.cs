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
    public partial class FrmPODutchmillDate : Form
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
        public DateTime iRequiredDate { get; set; }
        public FrmPODutchmillDate()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }

        private void FrmPODutchmillDate_Load(object sender, EventArgs e)
        {
           this.requireddateloading.Enabled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void requireddateloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.requireddateloading.Enabled = false;
            query = $@"
    SELECT [DateRequired]
    FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
    GROUP BY [DateRequired]
    ORDER BY [DateRequired];
";
            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbRequiredDate, lists, "DateRequired", "DateRequired");
            this.Cursor = Cursors.Default;

        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            if (CmbRequiredDate.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any required date.", "Select Required Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbRequiredDate.Focus();
                return;
            }
            else
            {
                if (ChkLock.Checked)
                {
                    query = $@"
        DECLARE @vDateRequired AS DATE = '{CmbRequiredDate.SelectedValue:yyyy-MM-dd}';
        INSERT INTO [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder_Locked]([DateRequired],[Department],[PlanningOrder],[CreatedDate])
        SELECT [DateRequired],[Remark],[PromotionMachanic],GETDATE()
        FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
        WHERE (DATEDIFF(DAY,[DateRequired],@vDateRequired) = 0)
        GROUP BY [DateRequired],[Remark],[PromotionMachanic];
    ";
                    query = string.Format(query, DatabaseName, CmbRequiredDate.SelectedValue);
                    RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                    RCon.Open();
                    RTran = RCon.BeginTransaction();
                    try
                    {
                        RCom = new SqlCommand
                        {
                            Transaction = RTran,
                            Connection = RCon,
                            CommandType = CommandType.Text,
                            CommandText = query
                        };
                        RCom.ExecuteNonQuery();
                        RTran.Commit();
                        RCon.Close();
                    }
                    catch (SqlException ex)
                    {
                        RTran.Rollback();
                        RCon.Close();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    catch (Exception ex)
                    {
                        RTran.Rollback();
                        RCon.Close();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                this.iRequiredDate = (DateTime)CmbRequiredDate.SelectedValue;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }

        }

        private void FrmPODutchmillDate_FormClosed(object sender, FormClosedEventArgs e)
        {
           this.Dispose();
        }
    }
}