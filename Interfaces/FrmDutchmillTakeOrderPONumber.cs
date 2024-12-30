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
    public partial class FrmDutchmillTakeOrderPONumber : Form
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
        public DateTime vDateOrder { get; set; }
        public DateTime vRequiredDate { get; set; }
        public string vPONumber { get; set; }

        public FrmDutchmillTakeOrderPONumber()
        {
            InitializeComponent();
        }

        private void FrmDutchmillTakeOrderPONumber_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            TxtPONo.Text = vPONumber;
            TxtOrderDate.Text = string.Format("{0:dd-MMM-yyyy}", vDateOrder);
            DTPRequiredDate.Value = vRequiredDate;
            PicRefreshPO_Click(PicRefreshPO, e);

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

        private void PicRefreshPO_Click(object sender, EventArgs e)
        {
            lists = (DataTable)Data.ExecuteStoredProc("Stock.dbo.AutoPONumber", Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {
                    TxtPONo.Text = (lists.Rows[0]["Auto"] == DBNull.Value) ? "" : lists.Rows[0]["Auto"].ToString().Trim();
                }
            }

        }
    }
}
