using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmDownloadSaleTeam : DevExpress.XtraEditors.XtraForm
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private DatabaseFramework_MySQL MyData = new DatabaseFramework_MySQL();
        private DateTime Todate;
        private PrintToPrinter Printer = new PrintToPrinter();
        private ConvertReport Export = new ConvertReport();
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
        private LocalReport Report;
        private ReportParameter RParameter;
        private string DatabaseName;
        private string query;
        private DataTable lists;
        private const string InvoiceName = "";

        public FrmDownloadSaleTeam()
        {
            InitializeComponent();
        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }

        private void DataSources(System.Windows.Forms.ComboBox ComboboxName, DataTable DTable, string DisplayMenber, string ValueMember)
        {
            ComboboxName.DataSource = DTable;
            ComboboxName.DisplayMember = DisplayMenber;
            ComboboxName.ValueMember = ValueMember;
            ComboboxName.SelectedIndex = -1;

        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            FrmPODutchmillDate Frm = new FrmPODutchmillDate();
            if(Frm.ShowDialog() == DialogResult.Cancel)
            {
                DateTime RequiredDate = Frm.iRequiredDate;
                query = @"  DECLARE @DateRequired AS DATE = N'{1:yyyy-MM-dd}';
                WITH v as (
                    SELECT [Barcode],[ProName],[Category] AS [Remark],[Size],[QtyPCase],CASE WHEN LTRIM(RTRIM(ISNULL([CusName],''))) LIKE 'YN %' THEN 'Total Sale' ELSE ISNULL([DelTo],'') END AS [CusName],SUM(ISNULL([TotalPcsOrder],0)) AS [TotalPcsOrder],[DateRequired],[DelToId]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam]
                    WHERE DATEDIFF(DAY,[DateRequired],@DateRequired) = 0
                    GROUP BY [Barcode],[ProName],[Category],[Size],[QtyPCase],CASE WHEN LTRIM(RTRIM(ISNULL([CusName],''))) LIKE 'YN %' THEN 'Total Sale' ELSE ISNULL([DelTo],'') END,[DateRequired],[DelToId]
                    UNION ALL
                    SELECT x.[Barcode],x.[ProName],x.[Category] AS [Remark],x.[Size],x.[QtyPCase],ISNULL(v.[DelTo],'') AS [CusName],NULL AS [TotalPcsOrder],NULL AS [DateRequired],v.[DelToId]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam] as x,[{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting] as v
                    WHERE DATEDIFF(DAY,x.[DateRequired],@DateRequired) = 0
                ),

				w AS (
                SELECT v.[Barcode],v.[ProName],v.[Remark],v.[Size],v.[QtyPCase],v.[CusName],ISNULL(SUM(v.[TotalPcsOrder]),0) AS [TotalPcsOrder]
                ,CASE WHEN ((DATENAME(WEEKDAY,v.[DateRequired]) = N'Monday' AND x.[Monday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Tuesday' AND x.[Tuesday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Wednesday' AND x.[Wednesday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Thursday' AND x.[Thursday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Friday' AND x.[Friday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Saturday' AND x.[Saturday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Sunday' AND x.[Sunday] = 1 AND v.[DelToId] = x.[DelToId]))
                THEN 1 ELSE 0 END AS [Missing],x.[DelToId]
                FROM v
                LEFT OUTER JOIN [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting] AS x ON v.[DelToId] = x.[DelToId]
                GROUP BY v.[Barcode],v.[ProName],v.[Remark],v.[Size],v.[QtyPCase],v.[CusName]
                ,CASE WHEN ((DATENAME(WEEKDAY,v.[DateRequired]) = N'Monday' AND x.[Monday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Tuesday' AND x.[Tuesday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Wednesday' AND x.[Wednesday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Thursday' AND x.[Thursday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Friday' AND x.[Friday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Saturday' AND x.[Saturday] = 1 AND v.[DelToId] = x.[DelToId])
                OR (DATENAME(WEEKDAY,v.[DateRequired]) = N'Sunday' AND x.[Sunday] = 1 AND v.[DelToId] = x.[DelToId]))
                THEN 1 ELSE 0 END,x.[DelToId])

				SELECT w.[Barcode],w.[ProName],w.[Remark],w.[Size],w.[QtyPCase],w.[CusName],case when isnull(w.[TotalPcsOrder],0) = 0 then null else w.[TotalPcsOrder] end as [TotalPcsOrder],
                CASE WHEN (w.[Missing] = 1 AND ISNULL(w.[TotalPcsOrder],0) <> 0) OR ISNULL(w.[DelToId],0) = 0 THEN 1 ELSE 0 END AS [Missing],
                ISNULL(v.[PiecesPerTray],1) AS [PiecesPerTray]
				FROM w
                LEFT OUTER JOIN [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] AS v ON v.Barcode = w.Barcode
                ORDER BY w.[Remark],w.[ProName];";

                query = string.Format(query, DatabaseName, RequiredDate);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                ReportViewer Report = new ReportViewer();
                string Path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "PODutchmill" + string.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + ".xls");
                string[] picList = Directory.GetFiles(System.IO.Path.GetTempPath(), "*.xls");
                foreach (string f in picList)
                {
                    File.Delete(f);
                }

                Report.LocalReport.ReportEmbeddedResource = "DeliveryTakeOrder.PODutchmill.rdlc";
                Report.LocalReport.DataSources.Add(new ReportDataSource("PODutchmill", lists));
                Export.Save(Report, Path, ConvertReport.Type_Converter.Excel, true);

            }
        }

        private void FrmDownloadSaleTeam_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void FrmDownloadSaleTeam_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            TimerCustomerLoading.Enabled = true;

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerCustomerLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerCustomerLoading.Enabled = false;
            query = @"
    SELECT [CusNum],[CusName],[Customer]
    FROM (
        --SELECT 0 AS [Index], N'CUS00000' AS [CusNum],N'All Customers' AS [CusName],N'All Customers' AS [Customer]
        --UNION ALL
        SELECT 1 AS [Index], [CusNum],[CusName],ISNULL([CusNum],'') + SPACE(3) + ISNULL([CusName],'') AS [Customer]
        FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam]
        GROUP BY [CusNum],[CusName],ISNULL([CusNum],'') + SPACE(3) + ISNULL([CusName],'')
    ) LISTS
    ORDER BY [Index],[CusName];
";
            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbCustomer, lists, "Customer", "CusNum");
            this.Cursor = Cursors.Default;

        }

        private void TimerTakeOrderLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerTakeOrderLoading.Enabled = false;
            CmbTakeOrderNo.DataSource = null;
            string CusNum = "";
            if (this.CmbCustomer.SelectedValue is DataRowView || this.CmbCustomer.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (!this.CmbCustomer.Text.Trim().Equals(""))
                {
                    CusNum = this.CmbCustomer.SelectedValue.ToString();
                }
            }
            if (!CusNum.Equals(""))
            {
                query = @"
        DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
        SELECT [TakeOrderNumber]
        FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam]
        WHERE ([CusNum] = @CusNum OR N'CUS00000' = @CusNum)
        GROUP BY [TakeOrderNumber]
        ORDER BY [TakeOrderNumber];
    ";
                query = string.Format(query, DatabaseName, CusNum);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                DataSources(CmbTakeOrderNo, lists, "TakeOrderNumber", "TakeOrderNumber");
            }
            this.Cursor = Cursors.Default;

        }

        private void CmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbCustomer.SelectedValue is DataRowView || this.CmbCustomer.SelectedValue == null) return;
            if (this.CmbCustomer.Text.Trim().Equals("")) return;
            Initialized.R_AllUnpaid = true;
            if (this.CmbCustomer.SelectedValue.Equals("CUS00000"))
            {
                FrmPODutchmillSelected Frm = new FrmPODutchmillSelected();
                if (Frm.ShowDialog() == DialogResult.Cancel) return;
            }
            TimerTakeOrderLoading.Enabled = true;
            TimerDisplayLoading.Enabled = true;

        }

        private void CmbTakeOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbTakeOrderNo.SelectedValue is DataRowView || this.CmbTakeOrderNo.SelectedValue == null) return;
            if (this.CmbTakeOrderNo.Text.Trim().Equals("")) return;
            TimerDisplayLoading.Enabled = true;

        }

        private void TimerDisplayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerDisplayLoading.Enabled = false;
            decimal TakeOrderNo = 0;
            if (this.CmbTakeOrderNo.SelectedValue is DataRowView || this.CmbTakeOrderNo.SelectedValue == null)
            {
                TakeOrderNo = 0;
            }
            else
            {
                if (!this.CmbTakeOrderNo.Text.Trim().Equals(""))
                {
                    TakeOrderNo = Convert.ToDecimal(this.CmbTakeOrderNo.SelectedValue);
                }
            }
            query = @"
    DECLARE @TakeOrderNo AS DECIMAL(18,0) = {1};
    DECLARE @IsAllProcess AS BIT = {2};
    DECLARE @DateTo AS DATE = N'{3:yyyy-MM-dd}';
    DECLARE @DateFrom AS DATE = N'{4:yyyy-MM-dd}';
    
    IF (@IsAllProcess = 0)
    BEGIN
        SELECT v.[Id],v.[TakeOrderNumber],v.[PONumber],v.[CusNum],v.[CusName],v.[DelToId],v.[DelTo],v.[DateOrd],v.[DateRequired],v.[UnitNumber],v.[Barcode],v.[ProName],v.[Size],v.[QtyPCase],v.[QtyPPack],v.[Category],v.[PcsFree],v.[PcsOrder],v.[PackOrder],v.[CTNOrder],v.[TotalPcsOrder],v.[LogInName],v.[PromotionMachanic],v.[ItemDiscount],v.[Remark],v.[Saleman],v.[CreatedDate]
        FROM (
            SELECT [Id],[CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate]
            FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam]
            WHERE ([TakeOrderNumber] = @TakeOrderNo OR 0 = @TakeOrderNo)
        ) v
        ORDER BY [CusName],[TakeOrderNumber];
    END
    ELSE
    BEGIN
        SELECT v.[Id],v.[TakeOrderNumber],v.[PONumber],v.[CusNum],v.[CusName],v.[DelToId],v.[DelTo],v.[DateOrd],v.[DateRequired],v.[UnitNumber],v.[Barcode],v.[ProName],v.[Size],v.[QtyPCase],v.[QtyPPack],v.[Category],v.[PcsFree],v.[PcsOrder],v.[PackOrder],v.[CTNOrder],v.[TotalPcsOrder],v.[LogInName],v.[PromotionMachanic],v.[ItemDiscount],v.[Remark],v.[Saleman],v.[CreatedDate]
        FROM (
            SELECT [Id],[CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate]
            FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam]
            WHERE ([TakeOrderNumber] = @TakeOrderNo OR 0 = @TakeOrderNo)
            UNION ALL
            SELECT [Id],[CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate]
            FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam_Processed]
            WHERE ([TakeOrderNumber] = @TakeOrderNo OR 0 = @TakeOrderNo) AND (CONVERT(DATE,[DateOrd]) BETWEEN @DateTo AND @DateFrom)
        ) v
        ORDER BY [CusName],[TakeOrderNumber];
    END
";
            query = string.Format(query, DatabaseName, TakeOrderNo, Initialized.R_AllUnpaid ? 0 : 1, Initialized.R_DateFrom, Initialized.R_DateTo);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row : {0}", DgvShow.RowCount);
            this.Cursor = Cursors.Default;

        }

        private void BtnDownloadTakeOrder_Click(object sender, EventArgs e)
        {

        }

        private void DgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmDownloadSaleTeam_Paint(object sender, PaintEventArgs e)
        {
            this.PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();
        }

        private void DgvShow_MouseDown(object sender, MouseEventArgs e)
        {
            this.Popmenu.Close();
            if(DgvShow.RowCount <= 0)
            {
                return;
            }
            if(e.Button == MouseButtons.Right)
            {
                this.Popmenu.Show(DgvShow, new System.Drawing.Point(e.X, e.Y));
            }
        }

        private void MnuChangeCustomer_Click(object sender, EventArgs e)
        {
            this.Popmenu.Close();
            if (DgvShow.RowCount <= 0) return;
            using (DataGridViewRow row = DgvShow.Rows[DgvShow.CurrentRow.Index])
            {
                decimal vTakeOrder = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["TakeOrderNumber"].Value) ? 0 : row.Cells["TakeOrderNumber"].Value);
                string vCusNum = DBNull.Value.Equals(row.Cells["CusNum"].Value) ? "" : row.Cells["CusNum"].Value.ToString().Trim();
                string vCusName = DBNull.Value.Equals(row.Cells["CusName"].Value) ? "" : row.Cells["CusName"].Value.ToString().Trim();
                FrmProcessTakeOrderCustomer Frm = new FrmProcessTakeOrderCustomer { vTakeOrder = vTakeOrder, vCusNum = vCusNum, vCusName = vCusName };
                if (Frm.ShowDialog(this) == DialogResult.Cancel) return;
                TimerDisplayLoading.Enabled = true;
            }

        }

        private void MnuChangeQtyOrder_Click(object sender, EventArgs e)
        {
            this.Popmenu.Close();
            if (DgvShow.RowCount <= 0) return;
            using (DataGridViewRow row = DgvShow.Rows[DgvShow.CurrentRow.Index])
            {
                decimal vTakeOrder = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["TakeOrderNumber"].Value) ? 0 : row.Cells["TakeOrderNumber"].Value);
                string vBarcode = DBNull.Value.Equals(row.Cells["Barcode"].Value) ? "" : row.Cells["Barcode"].Value.ToString().Trim();
                string vProName = DBNull.Value.Equals(row.Cells["ProName"].Value) ? "" : row.Cells["ProName"].Value.ToString().Trim();
                string vSize = DBNull.Value.Equals(row.Cells["Size"].Value) ? "" : row.Cells["Size"].Value.ToString().Trim();
                int vQtyPerCase = DBNull.Value.Equals(row.Cells["QtyPCase"].Value) ? 1 : Convert.ToInt32(row.Cells["QtyPCase"].Value);
                decimal vPcsOrder = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["PcsOrder"].Value) ? 0 : row.Cells["PcsOrder"].Value);
                decimal vPackOrder = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["PackOrder"].Value) ? 0 : row.Cells["PackOrder"].Value);
                decimal vCTNOrder = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["CTNOrder"].Value) ? 0 : row.Cells["CTNOrder"].Value);
                FrmProcessTakeOrderQtyOrder Frm = new FrmProcessTakeOrderQtyOrder
                {
                    vTakeOrder = vTakeOrder,
                    vBarcode = vBarcode,
                    vProName = vProName,
                    vSize = vSize,
                    vQtyPerCase = vQtyPerCase,
                    vPcsOrder = vPcsOrder,
                    vPackOrder = vPackOrder,
                    vCTNOrder = vCTNOrder
                };
                if (Frm.ShowDialog(this) == DialogResult.Cancel) return;
                TimerDisplayLoading.Enabled = true;
            }

        }

        private void MnuChangeDelto_Click(object sender, EventArgs e)
        {
            this.Popmenu.Close();
            if (DgvShow.RowCount <= 0) return;
            using (DataGridViewRow row = DgvShow.Rows[DgvShow.CurrentRow.Index])
            {
                decimal vTakeOrder = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["TakeOrderNumber"].Value) ? 0 : row.Cells["TakeOrderNumber"].Value);
                string vDeltoId = DBNull.Value.Equals(row.Cells["DelToId"].Value) ? "" : row.Cells["DelToId"].Value.ToString().Trim();
                string vDeltoName = DBNull.Value.Equals(row.Cells["DelTo"].Value) ? "" : row.Cells["DelTo"].Value.ToString().Trim();
                FrmProcessTakeOrderDelto Frm = new FrmProcessTakeOrderDelto { vTakeOrder = vTakeOrder, vDeltoId = vDeltoId, vDeltoName = vDeltoName };
                if (Frm.ShowDialog(this) == DialogResult.Cancel) return;
                TimerDisplayLoading.Enabled = true;
            }

        }

        private void MnuDeleteTakeOrder_Click(object sender, EventArgs e)
        {
            this.Popmenu.Close();
            if (DgvShow.RowCount <= 0) return;
            using (DataGridViewRow row = DgvShow.Rows[DgvShow.CurrentRow.Index])
            {
                decimal vTakeOrder = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["TakeOrderNumber"].Value) ? 0 : row.Cells["TakeOrderNumber"].Value);
                if (MessageBox.Show($"Are you sure, you want to delete the take order <{vTakeOrder}>?(Yes/No)", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    query = @"
            DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{1}';
            INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam_Deleted]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[DeletedDate])
            SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],GETDATE()
            FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam]
            WHERE [TakeOrderNumber] = @TakeOrderNumber;

            DELETE FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_SaleTeam]
            WHERE [TakeOrderNumber] = @TakeOrderNumber;
        ";
                    query = string.Format(query, DatabaseName, vTakeOrder);
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    MessageBox.Show("Deleting has been completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimerTakeOrderLoading.Enabled = true;
                    TimerDisplayLoading.Enabled = true;
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