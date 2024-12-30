using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using ProtoBuf;
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

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmUnlockPrinterTakeOrder : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private string DatabaseName;
        private DateTime Todate;
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;

        public FrmUnlockPrinterTakeOrder()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixProcedure, Data.DatabaseName);

        }

        private void FrmUnlockPrinterTakeOrder_Load(object sender, EventArgs e)
        {
            TimerLoading.Enabled = true;

        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void FrmUnlockPrinterTakeOrder_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();
        }

        private string RSQL;
        private void TimerLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerLoading.Enabled = false;
            RSQL = @" SELECT [PrintInvNo],[IsBusy]
                FROM [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo]
                WHERE ISNULL([IsBusy],0) = 1;";
            //RSQL = string.Format(RSQL, DatabaseName);
            //RCom.CommandText = RSQL;
            //RCom.ExecuteNonQuery();
            //RTran.Commit();
            //RCon.Close();
            //MessageBox.Show("Unlock Printer have been completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //PicStatus.Image = DeliveryTakeOrder.Properties.Resources.Unlock_Printer;
            RSQL = string.Format(RSQL, DatabaseName);
            DataTable DTable = Data.Selects(RSQL, Initialized.GetConnectionType(Data, App));
            if (DTable != null)
            {
                if (DTable.Rows.Count > 0)
                {
                    PicStatus.Image = DeliveryTakeOrder.Properties.Resources.Lock_Printer;
                }
                else
                {
                    PicStatus.Image = DeliveryTakeOrder.Properties.Resources.Unlock_Printer;
                }
            }
            else
            {
                PicStatus.Image = DeliveryTakeOrder.Properties.Resources.Unlock_Printer;
            }
            this.Cursor = Cursors.Default;


        }

        private void BtnUnlockPrinter_Click(object sender, EventArgs e)
        {
            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();
            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                RSQL = @"
        UPDATE v
        SET v.[PrintInvNo] = (ISNULL(v.[PrintInvNo], 0) + 1), v.[IsBusy] = 0
        FROM [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] v
        WHERE ISNULL(v.[IsBusy], 0) = 1;
    ";
                RSQL = string.Format(RSQL, DatabaseName);
                RCom.CommandText = RSQL;
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();
                MessageBox.Show("Unlock Printer have been completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PicStatus.Image = DeliveryTakeOrder.Properties.Resources.Unlock_Printer;
            }
            catch (SqlException ex)
            {
                RTran.Rollback();
                RCon.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RTran.Rollback();
                RCon.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
