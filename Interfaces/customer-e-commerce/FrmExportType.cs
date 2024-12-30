using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
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

namespace DeliveryTakeOrder.Interfaces.customer_e_commerce
{
    public partial class FrmExportType : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private string DatabaseName;
        private DateTime Todate;
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
        public Dictionary<string, object> RProgramList;
        public TypeOfExport vExport = new TypeOfExport();

        public enum TypeOfExport
        {
            All_Export = 0,
            All_Deactivate_Customers = 1,
            All_Activate_Customers = 2
        }

        public FrmExportType()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadinInitialized()
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

        private void FrmExportType_Load(object sender, EventArgs e)
        {
            LoadinInitialized();
            TimerLoading.Enabled = true;
            
        }

        private void FrmExportType_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();

        }

        private void TimerLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerLoading.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            if(RdbAllExport.Checked == true)
            {
                vExport = TypeOfExport.All_Export;
            }else if(RdbAllDeactivateCustomers.Checked == true){
                vExport = TypeOfExport.All_Deactivate_Customers;
            }
            else
            {
                vExport = TypeOfExport.All_Activate_Customers;
            }
            this.Close();
        }
    }
}
