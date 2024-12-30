using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.Declares;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces.delto
{
    public partial class FrmSearch : Form
    {
        private bool IsFormBeingDragged = false;
        private int MouseDownX;
        private int MouseDownY;

        public FrmSearch()
        {
            InitializeComponent();
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {

        }

        private void FrmSearch_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsFormBeingDragged = true;
                MouseDownX = e.X;
                MouseDownY = e.Y;
            }

        }

        private void FrmSearch_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsFormBeingDragged = false;
            }

        }
        public  enum typeofsearching
        {
            Id = 0,
            Name = 1,
            PhoneNumber = 2
        }
        public typeofsearching typeofsearching_ { get; set; }
      


        private void FrmSearch_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsFormBeingDragged)
            {
                Point temp = new Point();
                temp.X = this.Location.X + (e.X - MouseDownX);
                temp.Y = this.Location.Y + (e.Y - MouseDownY);
                this.Location = temp;
            //    temp = null;
            }

        }
        private ApplicationFramework App = new ApplicationFramework();
    
     

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Initialized.R_IsCancel = true;
            this.Close();

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                MessageBox.Show(LblMsg.Text, "Enter Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSearch.Focus();
                return;
            }

            if (this.RdbCustomerId.Checked)
            {
                this.typeofsearching_ = typeofsearching.Id;
            }
            else if (this.RdbCustomerName.Checked)
            {
                this.typeofsearching_ = typeofsearching.Name;
            }
            else
            {
                this.typeofsearching_ = typeofsearching.PhoneNumber;
            }

            // Initialized.R_SearchCustomerId = RdbCustomerId.Checked;
            Initialized.R_SearchValue = TxtSearch.Text;
            Initialized.R_IsCancel = false;
            this.Close();

        }

        private void RdbCustomerId_CheckedChanged(object sender, EventArgs e)
        {
            this.SetFocus_(sender, e);
        }
        private void SetFocus_(object sender, EventArgs e)
        {
            this.LblMsg.Text = Strings.StrConv(string.Format("Please enter the {0}", ((Control)sender).Text), VbStrConv.ProperCase);
            this.TxtSearch.Text = "";
            this.TxtSearch.Focus();
         }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.RdbCustomerId.Checked)
            {
                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, $"{5}");
            }
            else if (this.rdbphonenumber.Checked)
            {
                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, $"{25}");
            }

            if (e.KeyChar == (char)Keys.Return)
            {
                BtnOK_Click(BtnOK, new EventArgs());
            }

        }

        private void FrmSearch_Activated(object sender, EventArgs e)
        {
            TxtSearch.SelectionStart = 0;
            TxtSearch.SelectionLength = TxtSearch.TextLength;
            TxtSearch.Focus();

        }
    }
}
