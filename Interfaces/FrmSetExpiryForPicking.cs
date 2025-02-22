using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.XtraEditors;
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
    public partial class FrmSetExpiryForPicking : DevExpress.XtraEditors.XtraForm
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private string DatabaseName;
        private DateTime icurrentdate_;
        private string iquery_;
        private DataTable ilists_;
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
     

        public FrmSetExpiryForPicking()
        {
            InitializeComponent();
        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
        DatabaseName = String.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }
        private void btnexporttoexcel_Click(object sender, EventArgs e)
        {

        }

        private void FrmSetExpiryForPicking_Load(object sender, EventArgs e)
        {
            this.LoadingInitialized();
            this.loading.Enabled = true;
        }
        private void DataSources(System.Windows.Forms.ComboBox ComboboxName , DataTable DTale, string DispayMember, string ValueNumber )
        {
            ComboboxName.DataSource = DTale;
            ComboboxName.DisplayMember = DispayMember;
            ComboboxName.ValueMember = ValueNumber;
            ComboboxName.SelectedIndex = -1;

        }

        private void loading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.loading.Enabled = false;
            this.icurrentdate_ = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.customerloading.Enabled = true;
            this.periodloading.Enabled = true;
            this.displayloading.Enabled = true;
            this.Cursor = Cursors.Default;

        }

        private void customerloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.customerloading.Enabled = false;
            this.iquery_ = @"
SELECT o.[CusNum],
       RTRIM(LTRIM(o.[CusName])) [CusName],
       o.[CusNum] + SPACE(3) + RTRIM(LTRIM(o.[CusName])) [fullname]
FROM [Stock].[dbo].[TPRCustomer] o
WHERE o.[Status] = N'Activate'
ORDER BY RTRIM(LTRIM(o.[CusName]));
";
            this.iquery_ = string.Format(this.iquery_, DatabaseName);
            this.ilists_ = Data.Selects(this.iquery_, Initialized.GetConnectionType(Data, App));
            this.DataSources(this.cmbcustomer, this.ilists_, "fullname", "CusNum");
            this.Cursor = Cursors.Default;

        }

        private void periodloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.periodloading.Enabled = false;
            this.ilists_ = new DataTable();
            this.ilists_.Columns.Add("display", typeof(string));
            this.ilists_.Columns.Add("value", typeof(int));
            DataRow irow_;
            for (int i = 3; i <= 12; i++)
            {
                irow_ = this.ilists_.NewRow();
                irow_["display"] = string.Format("{0} Months Before Expiry", i);
                irow_["value"] = i;
                this.ilists_.Rows.Add(irow_);
            }
            this.DataSources(this.cmbperiodbeforeexpiry, this.ilists_, "display", "value");
            this.Cursor = Cursors.Default;

        }

        private void FrmSetExpiryForPicking_Paint(object sender, PaintEventArgs e)
        {
            this.PicLogo.Image = Initialized.R_Logo;
            this.LblCompanyName.Text = Initialized.R_CompanyKhmerName.ToUpper();
        }

        private void displayloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.displayloading.Enabled = false;
            this.iquery_ = @"
SELECT i.[id],
       i.[cusnum],
       x.[CusName] [cusname],
       CONVERT(NVARCHAR,i.[periodbeforeexpiry]) + N' Months Before Expiry' [periodbeforeexpiry],
       i.[createddate]
FROM [DBPickers].[dbo].[tblsetperiodexpiryforpicking] i
    INNER JOIN [Stock].[dbo].[TPRCustomer] x
        ON (x.CusNum = i.cusnum)
ORDER BY x.[CusName];
";
            this.iquery_ = string.Format(this.iquery_, DatabaseName);
            this.ilists_ = Data.Selects(this.iquery_, Initialized.GetConnectionType(Data, App));
            this.dgvshow.DataSource = this.ilists_;
            this.dgvshow.Refresh();
            this.lblcountrow.Text = string.Format("Count Row = {0}", this.dgvshow.Rows.Count);
            this.Cursor = Cursors.Default;

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.cmbcustomer.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any customer!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbcustomer.Focus();
                return;
            }
            else if (this.cmbperiodbeforeexpiry.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any period before expiry!", "Select Period Before Expiry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbperiodbeforeexpiry.Focus();
                return;
            }
            else
            {
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    this.iquery_ = @"
DECLARE @ocusnum_ AS NVARCHAR(8) = N'{1}';
DECLARE @operiodbeforeexpiry AS INT = {2};

IF NOT EXISTS
(
    SELECT *
    FROM [DBPickers].[dbo].[tblsetperiodexpiryforpicking]
    WHERE ([cusnum] = @ocusnum_)
)
BEGIN
    INSERT INTO [DBPickers].[dbo].[tblsetperiodexpiryforpicking]
    (
        [cusnum],
        [periodbeforeexpiry],
        [createddate]
    )
    VALUES
    (@ocusnum_, @operiodbeforeexpiry, GETDATE());
END;
ELSE
BEGIN
    UPDATE v
    SET v.[periodbeforeexpiry] = @operiodbeforeexpiry
    FROM [DBPickers].[dbo].[tblsetperiodexpiryforpicking] v
    WHERE (v.[cusnum] = @ocusnum_);
END;
";
                    this.iquery_ = string.Format(this.iquery_, DatabaseName, cmbcustomer.SelectedValue, cmbperiodbeforeexpiry.SelectedValue);
                    RCom.CommandText = this.iquery_;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    MessageBox.Show("The Transaction has been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.loading.Enabled = true;
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

        private void dgvshow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                using (DataGridViewRow row = this.dgvshow.Rows[this.dgvshow.CurrentRow.Index])
                {
                    decimal oId = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["id"].Value) ? 0 : row.Cells["id"].Value);
                    string oCusName = DBNull.Value.Equals(row.Cells["cusname"].Value) ? "" : row.Cells["cusname"].Value.ToString().Trim();
                    string oPeriod = DBNull.Value.Equals(row.Cells["periodbeforeexpiry"].Value) ? "" : row.Cells["periodbeforeexpiry"].Value.ToString().Trim();

                    if (MessageBox.Show(string.Format("Are you sure, you want to delete <{0} ~ {1}>?(Yes/No)", oCusName, oPeriod), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return;

                    RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                    RCon.Open();
                    RTran = RCon.BeginTransaction();
                    try
                    {
                        RCom.Transaction = RTran;
                        RCom.Connection = RCon;
                        RCom.CommandType = CommandType.Text;
                        this.iquery_ = @"
DECLARE @oid AS DECIMAL(18, 0) = {1};
INSERT INTO [DBPickers].[dbo].[tblsetperiodexpiryforpicking.deleted]
(
    [cusnum],
    [periodbeforeexpiry],
    [createddate],
    [deleteddate]
)
SELECT [cusnum],
       [periodbeforeexpiry],
       [createddate],
       GETDATE()
FROM [DBPickers].[dbo].[tblsetperiodexpiryforpicking]
WHERE ([id] = @oid);

DELETE FROM [DBPickers].[dbo].[tblsetperiodexpiryforpicking]
WHERE ([id] = @oid);
";
                        this.iquery_ = string.Format(this.iquery_, DatabaseName, oId);
                        RCom.CommandText = this.iquery_;
                        RCom.ExecuteNonQuery();
                        RTran.Commit();
                        RCon.Close();
                        MessageBox.Show("Deleting has been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.loading.Enabled = true;
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
    }
}