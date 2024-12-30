using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using Org.BouncyCastle.Asn1.X509.Qualified;
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
    public partial class FrmSelectedPayment : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private string DatabaseName;
        private DateTime Todate;
        public DataTable DTable;

        public FrmSelectedPayment()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }

        private void FrmSelectedPayment_Load(object sender, EventArgs e)
        {
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            DTPTo.Value = Todate;
            DTPFrom.Value = Todate;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (RdbAllUnpaid.Checked)
            {
                Initialized.R_AllUnpaid = true;
            }
            else
            {
                Initialized.R_AllUnpaid = false;
            }

            Initialized.R_DateFrom = DTPFrom.Value;
            Initialized.R_DateTo = DTPTo.Value;
            Initialized.R_IsCancel = false;
            this.Close();

        }

        private void RdbAllTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (DTable != null)
            {
                if (DTable.Rows.Count > 0)
                {
                    DTPFrom.Value = Convert.ToDateTime(DBNull.Value.Equals(DTable.Rows[0][0]) ? Todate : DTable.Rows[0][0]);
                }
            }

        }
    }
}
