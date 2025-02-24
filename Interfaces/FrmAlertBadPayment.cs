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
    public partial class FrmAlertBadPayment : Form
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

        public FrmAlertBadPayment()
        {
            InitializeComponent();
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


        private void FrmAlertBadPayment_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));

        }

        private void BtnYes_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
         
        }
    }
}
