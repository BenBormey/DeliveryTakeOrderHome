using DeliveryTakeOrder.Declares;
using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.ApplicationFrameworks;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmChangePassword : Form
    {
        DatabaseFramework Data = new DatabaseFramework();
        ApplicationFramework App = new ApplicationFramework();
        public string ProgramName { get; set; }

        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (TxtNewPassword.Text == "")
            {
                MessageBox.Show("Please enter the New Password!", "Enter New Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtNewPassword.Focus();
                return;
            } else if (TxtNewPassword.Text == string.Empty) {
                MessageBox.Show("Please enter the Confirm Password!", "Enter Confirm Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtConfirmPassword.Focus();
                return;

            }
            else
            {
                if (string.Compare(TxtNewPassword.Text, TxtConfirmPassword.Text, StringComparison.Ordinal) != 0)
                {
                    MessageBox.Show("The password does not match!\nPlease check the Confirm Password again.", "Invalid Confirm Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtConfirmPassword.SelectionStart = 0;
                    TxtConfirmPassword.SelectionLength = TxtConfirmPassword.TextLength;
                    TxtConfirmPassword.Focus();
                    return;
                }

                Dictionary<string, object> Dic = new Dictionary<string, object>
                    {
                        { "Password", string.Format("{0}", App.ConvertTextToPassword(TxtNewPassword.Text,Initialized.R_KeyPassword)) }
                    };

                if (Data.Updates("PasswordLogin", Dic, $"[ProgramName] = '{ProgramName}'", Initialized.GetConnectionType(Data, App)))
                {
                    MessageBox.Show("Changing password has been completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The Password is wrong!\nPlease check the password again...", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtConfirmPassword.SelectionStart = 0;
                    TxtConfirmPassword.SelectionLength = TxtConfirmPassword.TextLength;
                    TxtConfirmPassword.Focus();
                    return;
                }

            }
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            Initialized.LoadingInitialized(Data,App);
            App.ClearController(TxtConfirmPassword);
        }

        private void FrmChangePassword_Activated(object sender, EventArgs e)
        {
            TxtNewPassword.Focus();
        }
        private void TxtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                TxtConfirmPassword.Focus();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                BtnOK_Click(BtnOK, new EventArgs());
            }
        }

        private void FrmChangePassword_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();

        }
    }
}
