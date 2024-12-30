using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmPlanningOrder : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private DatabaseFramework_MySQL MyData = new DatabaseFramework_MySQL();
        private DateTime Todate;
        private PrintToPrinter Printer = new PrintToPrinter();
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
        private LocalReport Report;
        private ReportParameter RParameter;
        private string DatabaseName;
        private string query;
        private DataTable lists;
        private string vHostName = System.Net.Dns.GetHostName();
        private string vIPAddress;

        public string IPAddress
        {
            get
            {
                if (string.IsNullOrEmpty(vIPAddress))
                {
                    vIPAddress = System.Net.Dns.GetHostEntry(vHostName).AddressList[0].ToString();
                }
                return vIPAddress;
            }
        }

        private CheckBox vCheckBox;
        public string vDepartment { get; set; }

        public FrmPlanningOrder()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }
        private void DataSources(ComboBox comboBoxName, DataTable dTable, string displayMember, string valueMember)
        {
            comboBoxName.DataSource = dTable;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.ValueMember = valueMember;
            comboBoxName.SelectedIndex = -1;
        }

        private void DisplayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.DisplayLoading.Enabled = false;
            this.query = @"
    SELECT [Id],[PlanningOrder],[DayOfWeek],[CreatedDate]
    FROM [{0}].[dbo].[TblDeliveryTakeOrders_PlanningOrder]
    ORDER BY [PlanningOrder];
";
            this.query = string.Format(this.query, DatabaseName);
            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            this.DgvShow.DataSource = this.lists;
            this.DgvShow.Refresh();
            this.LblCountRow.Text = string.Format("Count Row : {0}", this.DgvShow.Rows.Count);
            this.Cursor = Cursors.Default;

        }
        private DataTable oDayOfWeekList;
        private void dayofweekloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.dayofweekloading.Enabled = false;
            if (this.oDayOfWeekList != null) this.oDayOfWeekList = null;
            this.oDayOfWeekList = new DataTable();
            this.oDayOfWeekList.Columns.Add("value", typeof(string));
            this.oDayOfWeekList.Columns.Add("display", typeof(string));

            DataRow oRow = null;
            for (decimal o = 1; o <= 7; o++)
            {
                string oDayName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)((int)o % 7)).ToUpper();
                oRow = this.oDayOfWeekList.NewRow();
                oRow["value"] = oDayName;
                oRow["display"] = oDayName;
                this.oDayOfWeekList.Rows.Add(oRow);
            }

            this.DataSources(CmbDayOfWeek, this.oDayOfWeekList, "display", "value");
            this.Cursor = Cursors.Default;

        }

        private void FrmPlanningOrder_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_DatabaseName.ToUpper();
        }

        private void BtnAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FrmPlanningOrder_PreviewKeyDown(this, e);
            }

        }

        private void FrmPlanningOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                BtnAdd.Text = "&Add";
                BtnAdd.Image = DeliveryTakeOrder.Properties.Resources.add16;
                TxtPlanningOrder.Text = "";
                TxtPlanningOrder.Focus();
            }

        }

        private void TxtPlanningOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FrmPlanningOrder_PreviewKeyDown(this, e);
            }
        }

        private void DgvShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (DgvShow.Rows.Count <= 0)
            {
                MessageBox.Show("No record to delete!", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                FrmPlanningOrder_PreviewKeyDown(this, e);
            }
            if (e.KeyCode != Keys.Delete) return;

            var currentRow = DgvShow.Rows[DgvShow.CurrentRow.Index];
            decimal oId = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["Id"].Value) ? 0 : currentRow.Cells["Id"].Value);
            string oPlanning = DBNull.Value.Equals(currentRow.Cells["PlanningOrder"].Value) ? "" : currentRow.Cells["PlanningOrder"].Value.ToString().Trim();

            query = $@"
    DECLARE @oPlanningOrder AS NVARCHAR(50) = N'{oPlanning}';
    SELECT [CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate],GETDATE()
    FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
    WHERE [PlanningOrder] = @oPlanningOrder;
";
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                MessageBox.Show("Cannot delete this planning!\nBecause the planning is process order...", "Invalid Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Are you sure, you want to delete this ({oPlanning})?(Yes/No)", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            query = $@"
    DECLARE @oId AS DECIMAL(18,0) = {oId};
    DECLARE @oPlanningOrder_Old AS NVARCHAR(50) = N'';
    SELECT @oPlanningOrder_Old = ISNULL(o.[PlanningOrder],N'')
    FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder] o
    WHERE [Id] = @oId;

    INSERT INTO [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder_Deleting]([CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate],[DeletedDate])
    SELECT [CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate],GETDATE()
    FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
    WHERE [PlanningOrder] = @oPlanningOrder_Old;

    DELETE FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
    WHERE [PlanningOrder] = @oPlanningOrder_Old;

    INSERT INTO [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder.Deleted]
    ([PlanningOrder], [DayOfWeek], [CreatedDate], [DeletedDate])
    SELECT [PlanningOrder], [DayOfWeek], [CreatedDate], GETDATE()
    FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder]
    WHERE [Id] = @oId;

    DELETE FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder]
    WHERE [Id] = @oId;
";
            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();
            try
            {
                RCom = new SqlCommand
                {
                    Transaction = RTran,
                    Connection = RCon,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();
                this.DisplayLoading.Enabled = true;
                BtnAdd.Text = "&Add";
                BtnAdd.Image = DeliveryTakeOrder.Properties.Resources.add16;
                TxtPlanningOrder.Text = "";
                TxtPlanningOrder.Focus();
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

        private void DgvShow_DoubleClick(object sender, EventArgs e)
        {
            if (DgvShow.Rows.Count <= 0)
            {
                MessageBox.Show("No record to update!", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var currentRow = DgvShow.Rows[DgvShow.CurrentRow.Index];
            string oPlanning = DBNull.Value.Equals(currentRow.Cells["PlanningOrder"].Value) ? "" : currentRow.Cells["PlanningOrder"].Value.ToString().Trim();
            string oDayofWeek = DBNull.Value.Equals(currentRow.Cells["DayOfWeek"].Value) ? "" : currentRow.Cells["DayOfWeek"].Value.ToString().Trim();

            this.TxtPlanningOrder.Text = oPlanning.Trim();
            this.CmbDayOfWeek.SelectedValue = oDayofWeek;
            BtnAdd.Text = "&Update";
            BtnAdd.Image = DeliveryTakeOrder.Properties.Resources.update_blue;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TxtPlanningOrder.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the planning order...", "Enter Planning Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPlanningOrder.Focus();
                return;
            }
            else if (CmbDayOfWeek.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any day of week...", "Select Day of Week", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbDayOfWeek.Focus();
                return;
            }
            else
            {
                string oPlanningOrder = TxtPlanningOrder.Text.Replace("'", "").Trim();
                string oDayOfWeek = CmbDayOfWeek.Text.Replace("'", "").Trim();
                decimal oId = 0;
                if (BtnAdd.Text.Trim().Equals("&Add"))
                {
                    oId = 0;
                }
                else
                {
                    oId = Convert.ToDecimal(DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value) ? 0 : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value);
                }

                query = $@"
        DECLARE @oPlanningOrder AS NVARCHAR(50) = N'{oPlanningOrder}';
        DECLARE @oId AS DECIMAL(18,0) = {oId};
        SELECT [Id],[PlanningOrder],[CreatedDate]
        FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder]
        WHERE ([PlanningOrder] = @oPlanningOrder) AND ([Id] <> @oId);
    ";
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null && lists.Rows.Count > 0)
                {
                    MessageBox.Show("Please check the Planning Order again!\nThe Planning Order already exists.", "Duplicated Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtPlanningOrder.Focus();
                    return;
                }

                query = $@"
        DECLARE @oPlanningOrder AS NVARCHAR(50) = N'{oPlanningOrder}';                            
        DECLARE @oId AS DECIMAL(18,0) = {oId};
        DECLARE @oDayOfWeek AS NVARCHAR(25) = N'{oDayOfWeek}';
        IF NOT EXISTS (SELECT * FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder] WHERE ([PlanningOrder] = @oPlanningOrder)) AND (@oId = 0)
        BEGIN
            INSERT INTO [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder]([PlanningOrder],[DayOfWeek],[CreatedDate])
            VALUES(@oPlanningOrder,@oDayOfWeek,GETDATE());
        END
        ELSE
        BEGIN
            IF (@oId <> 0)
            BEGIN
                DECLARE @oPlanningOrder_Old AS NVARCHAR(50) = N'';
                SELECT @oPlanningOrder_Old = ISNULL(o.[PlanningOrder],N'')
                FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder] o
                WHERE [Id] = @oId;

                UPDATE o
                SET o.[PlanningOrder] = @oPlanningOrder,
                    o.[DayOfWeek] = @oDayOfWeek
                FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_PlanningOrder] o
                WHERE [Id] = @oId;

                UPDATE o
                SET o.[PlanningOrder] = @oPlanningOrder
                FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] o
                WHERE o.[PlanningOrder] = @oPlanningOrder_Old;

                UPDATE o
                SET o.[PromotionMachanic] = @oPlanningOrder
                FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] o
                WHERE o.[PromotionMachanic] = @oPlanningOrder_Old;
            END
        END
    ";
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom = new SqlCommand
                    {
                        Transaction = RTran,
                        Connection = RCon,
                        CommandType = CommandType.Text,
                        CommandText = query
                    };
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    this.DisplayLoading.Enabled = true;
                    BtnAdd.Text = "&Add";
                    BtnAdd.Image = DeliveryTakeOrder.Properties.Resources.add16;
                    TxtPlanningOrder.Text = "";
                    TxtPlanningOrder.Focus();
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPlanningOrder_Load(object sender, EventArgs e)
        {
            this.dayofweekloading.Enabled = true;
            this.DisplayLoading.Enabled  =true; 
        }
    }
}
