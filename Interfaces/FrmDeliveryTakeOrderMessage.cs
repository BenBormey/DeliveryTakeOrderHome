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
using System.Timers;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmDeliveryTakeOrderMessage : Form
    {
        public string vPONumber { get; set; }
        public DateTime? vDeliveryDate { get; set; }
        public DateTime vTodate { get; set; }

        public FrmDeliveryTakeOrderMessage()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            if (!vPONumber.Trim().Equals("") && TxtPONumber.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the P.O Number!", "Enter P.O Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPONumber.Focus();
                return;
            }
            Initialized.R_MessageAlert = TxtRemark.Text.Trim();
            vPONumber = TxtPONumber.Text.Trim();
            if (CheckBox1.Checked)
            {
                vDeliveryDate = DTPDeliveryDate.Value;
            }
            else
            {
                vDeliveryDate = vTodate.Date;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void FrmDeliveryTakeOrderMessage_Load(object sender, EventArgs e)
        {
            if (vPONumber != null)
            {
                if (vPONumber.Trim().Equals(""))
                {
                    PanelPONumber.Visible = false;
                }
                else
                {
                    PanelPONumber.Visible = true;
                }
            }
            else
            {
                vPONumber = "";
                PanelPONumber.Visible = false;
            }

            TxtPONumber.Text = vPONumber;

            if (CheckBox1.Checked)
            {
                vDeliveryDate = DTPDeliveryDate.Value;
            }
            else
            {
                vDeliveryDate = null;
            }

        }

        private void DTPDeliveryDate_ValueChanged(object sender, EventArgs e)
        {
            if (DTPDeliveryDate.Value.Date < vTodate.Date)
            {
                DTPDeliveryDate.Value = vTodate.Date;
            }

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            DTPDeliveryDate.Enabled = CheckBox1.Checked;
        }
    }
}
