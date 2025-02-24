using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DeliveryTakeOrder.Interfaces.Teamleader;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DeliveryTakeOrder.DatabaseFrameworks.DatabaseFramework;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmPasswordLogin : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private warehouseNameModel warehouseName;

        public FrmPasswordLogin(warehouseNameModel warehouseName)
        {
            this.warehouseName = warehouseName;
            InitializeComponent();
            this.lblWarehouseName.Text = this.warehouseName.warehouseName.ToUpper().Trim();
        }


        private void FrmPasswordLogin_Load(object sender, EventArgs e)
        {
            Initialized.LoadingInitialized(Data, App);
            TxtPassword.Focus();
        }
        private void PasswordContinues_Load(object sender, EventArgs e)
        {
            Initialized.LoadingInitialized(Data, App);
            if (Initialized.CheckCompaniesExistOrNot(Data, App)) { App.ClearController(TxtPassword); }
            else
            {
                MessageBox.Show("Cannot find company name!\nPlease contact to IT Assistant to create company name!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {


            if (TxtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the password login!", "Enter Password Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtPassword.Focus();
                return;
            }
            else
            {
                Dictionary<string, object> Dic;

                // Check Password MD
                Dic = new Dictionary<string, object>();
                Dic.Add("ProgramName", "Managing Director");

                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, false, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count <= 0)
                {
                    Dic = new Dictionary<string, object>();
                    Dic.Add("ProgramName", "Managing Director");
                    Dic.Add("UserName", "Managing Director");
                    Dic.Add("Password", App.ConvertTextToPassword("Admin",Initialized.R_KeyPassword));
                    Dic.Add("CreatedDate", "GETDATE()");
                    bool R_Result = Data.Inserts("PasswordLogin", Dic, Initialized.GetConnectionType(Data, App));
                }

                // Check Password IT Manager
                Dic = new Dictionary<string, object>();
                Dic.Add("ProgramName", "IT Manager");

                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, false, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count <= 0)
                {
                    Dic = new Dictionary<string, object>();
                    Dic.Add("ProgramName", "IT Manager");
                    Dic.Add("UserName", "IT Manager");
                    Dic.Add("Password", App.ConvertTextToPassword("MSRITH$260689", Initialized.R_KeyPassword));
                    Dic.Add("CreatedDate", "GETDATE()");
                    bool R_Result = Data.Inserts("PasswordLogin", Dic, Initialized.GetConnectionType(Data, App));
                }

                // Check TakeOrder
                Dic = new Dictionary<string, object>();
                Dic.Add("ProgramName", "TakeOrder");

                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, false, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count <= 0)
                {
                    Dic = new Dictionary<string, object>();
                    Dic.Add("ProgramName", "TakeOrder");
                    Dic.Add("UserName", "TakeOrder");
                    Dic.Add("Password", App.ConvertTextToPassword("to", Initialized.R_KeyPassword));
                    Dic.Add("CreatedDate", "GETDATE()");
                    bool R_Result = Data.Inserts("PasswordLogin", Dic, Initialized.GetConnectionType(Data, App));
                }

                // Check Password Login
                Dic = new Dictionary<string, object>();
                Dic.Add("ProgramName", "N'Managing Director',N'MD Assistant',N'IT Manager',N'TakeOrder', N'Software Developer', N'UNT-ADMIN'");
                Dic.Add("Password", string.Format("'{0}'", App.ConvertTextToPassword(TxtPassword.Text, Initialized.R_KeyPassword)));

                DataTable lists = (DataTable)Data.Selects("PasswordLogin", null, Dic, true, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App));

                if (lists.Rows.Count > 0)
                {
                    string ProgramName = "TakeOrder";
                    this.Hide();
                    MDI Frm = new MDI(this.warehouseName);
                    Frm.Show();
                    Frm.ProgramName = ProgramName;
                }
                else
                {
                    MessageBox.Show("The Password are wrong!\nPlease check password again...", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPassword.SelectionStart = 0;
                    TxtPassword.SelectionLength = TxtPassword.Text.Length;
                    TxtPassword.Focus();
                    return;
                }
            }
        }
  

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                BtnLogIn_Click(BtnLogIn, new EventArgs());
            }

        }


    }
}
