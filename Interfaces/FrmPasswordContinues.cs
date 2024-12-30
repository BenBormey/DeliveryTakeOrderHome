using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
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
using static DeliveryTakeOrder.DatabaseFrameworks.DatabaseFramework;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmPasswordContinues : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        public string R_PasswordPermission;

        public FrmPasswordContinues()
        {
            InitializeComponent();
        }
           
   


        private void FrmPasswordContinues_Load(object sender, EventArgs e)
        {
            App.ClearController(TxtPassword);
        }
        private void TxtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                TxtPassword.Focus();
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Initialized.R_CorrectPassword = false;

            this.Close();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                BtnOK_Click(BtnOK, new EventArgs());
            }

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                MessageBox.Show("Please enter the password login!", "Enter Password Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtPassword.Focus();
                return;
            }
            else
            {
                Dictionary<string, object> Dic;

                // Check Password MD
                Dic = new Dictionary<string, object>
{
    { "ProgramName", "Managing Director" }
};
                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, false, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count <= 0)
                {
                    Dic = new Dictionary<string, object>
    {
        { "ProgramName", "Managing Director" },
        { "UserName", "Managing Director" },
        { "Password", App.ConvertTextToPassword("Admin",Initialized.R_KeyPassword) },
        { "CreatedDate", "GETDATE()" }
    };
                    bool R_Result = Data.Inserts("PasswordLogin", Dic, Initialized.GetConnectionType(Data, App));
                }

                // Check Password IT Manager
                Dic = new Dictionary<string, object>
{
    { "ProgramName", "IT Manager" }
};
                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, false, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count <= 0)
                {
                    Dic = new Dictionary<string, object>
    {
        { "ProgramName", "IT Manager" },
        { "UserName", "IT Manager" },
        { "Password", App.ConvertTextToPassword("MSRITH$260689",Initialized.R_KeyPassword) },
        { "CreatedDate", "GETDATE()" }
    };
                    bool R_Result = Data.Inserts("PasswordLogin", Dic, Initialized.GetConnectionType(Data, App));
                }

                // Check GM
                Dic = new Dictionary<string, object>
{
    { "ProgramName", "Products" }
};
                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, false, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count <= 0)
                {
                    Dic = new Dictionary<string, object>
    {
        { "ProgramName", "Products" },
        { "UserName", "Products" },
        { "Password", App.ConvertTextToPassword("a",Initialized.R_KeyPassword) },
        { "CreatedDate", "GETDATE()" }
    };
                    bool R_Result = Data.Inserts("PasswordLogin", Dic, Initialized.GetConnectionType(Data, App));
                }

                // Check Password Login
                Dic = new Dictionary<string, object>
{
    { "ProgramName", R_PasswordPermission },
    { "Password", string.Format("'{0}'", App.ConvertTextToPassword(TxtPassword.Text,Initialized.R_KeyPassword)) }
};
                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, true, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count > 0)
                {
                    Initialized.R_CorrectPassword = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The Password are wrong!\nPlease check password again...", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPassword.SelectionStart = 0;
                    TxtPassword.SelectionLength = TxtPassword.TextLength;
                    TxtPassword.Focus();
                    return;
                }

            }

        }

        private void FrmPasswordContinues_Activated(object sender, EventArgs e)
        {
            Initialized.LoadingInitialized(Data, App);

        }

        private void FrmPasswordContinues_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();
        }
    }
}
