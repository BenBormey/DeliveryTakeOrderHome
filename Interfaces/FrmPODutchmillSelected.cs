using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmPODutchmillSelected : DevExpress.XtraEditors.XtraForm
    {


        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private string DatabaseName;
        private DateTime Todate;
        public DataTable DTable;
        public FrmPODutchmillSelected()
        {
            InitializeComponent();

        }
        public void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = $"{Data.PrefixDatabase},{Data.DatabaseName}";

        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if(RdbAllUnpaid.Checked == true) {
                Initialized.R_AllUnpaid = true;
            }else
            {
                Initialized.R_AllUnpaid = false;
            }
            Initialized.R_DateFrom = DTPFrom.Value;
            Initialized.R_DateTo = DTPTo.Value;
            Initialized.R_IsCancel = false;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RdbAllTransaction_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RdbAllUnpaid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmPODutchmillSelected_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data,App));
            DTPTo.Value = Todate;
            DTPFrom.Value = DTPFrom.MinDate;
        }

        private void FrmPODutchmillSelected_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}