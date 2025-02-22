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
    public partial class FrmDelayPrintInvoicingForDutchmillSelected : DevExpress.XtraEditors.XtraForm
    {
        public FrmDelayPrintInvoicingForDutchmillSelected()
        {
            InitializeComponent();
        }

        private void BtnDelayItems_Click(object sender, EventArgs e)
        {
            this.oDelayDate = this.dtpActiveDate.Value;

        }
        private DateTime oDelayDate;
        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpActiveDate_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.oDelayDate) > Convert.ToDateTime(this.dtpActiveDate.Value))
            {
                this.dtpActiveDate.Value = this.oDelayDate;
            }

        }
    }
}