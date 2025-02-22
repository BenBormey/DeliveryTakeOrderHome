using DeliveryTakeOrder.App.CustomerAging;
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
    public partial class FrmAlertCreditAmount : Form
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
        public string oCusNum { get; set; }

        public FrmAlertCreditAmount()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));

        }



        private void FrmAlertCreditAmount_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.loading.Enabled = false;
            double BankGarantee = 0;
            
        }

        private void loading_Tick(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;   
            this.loading.Enabled = false ;
            double BankGarantee = 0;
            query = @"DECLARE @CusId AS NVARCHAR(8) = N'{1}';
                        SELECT SUM([CreditLimit]) AS [BankGarantee]
                        FROM [Stock].[dbo].[TPRCustomerBankGarantee]
                        WHERE [CusId] = @CusId;";
            query = string.Format(query, DatabaseName, oCusNum);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null) {
            
                if(lists.Rows.Count > 0)
                {
                     BankGarantee = Convert.ToDouble(DBNull.Value.Equals(lists.Rows[0]["BankGarantee"]) ? 0 : lists.Rows[0]["BankGarantee"]);

                }
                //gui_preview 
            }
            lblbankgarantee.Text = string.Format("Bank Garatee = {0:C2}", BankGarantee);
            this.Cursor = Cursors.Default;
        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void btnPreviewAging_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ar_aging_form frm = new ar_aging_form();
            frm.CusNum = oCusNum;
            frm.Show();


        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
