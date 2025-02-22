using DeliveryTakeOrder.Declares;
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
    public partial class FrmDeliveryTakeOrderInfoAeon : Form
    {
        public FrmDeliveryTakeOrderInfoAeon()
        {
            InitializeComponent();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            Initialized.R_DocumentNumber = TxtDocumentNumber.Text.Trim();
            Initialized.R_LineCode = TxtLineCode.Text.Trim();
            Initialized.R_DeptCode = TxtDeptCode.Text.Trim();

        }

        private void FrmDeliveryTakeOrderInfoAeon_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
