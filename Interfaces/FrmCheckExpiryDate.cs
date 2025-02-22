using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DeliveryTakeOrder.Dev;
using DeliveryTakeOrder.Interfaces.distributor_under;
using DeliveryTakeOrder.Interfaces.preview;
using DeliveryTakeOrder.Interfaces.Teamleader;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmCheckExpiryDate : Form
    {
        public FrmCheckExpiryDate()
        {
            InitializeComponent();
            db = new RMDB(AppSetting.ConnectionString);

            this.bsWH = new BindingSource();
            this.bsWarehouse = new BindingSource();
            this.bsWarehouse.PositionChanged += new EventHandler(Position_Changed);

            this.LoadingInitialized();
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.warehouseNameLoading.Enabled = true;
            this.Loading.Enabled = true;


        }
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
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
        public string vBarcode { get; set; }
        public string vCusNum { get; set; }
        public string vCusname { get; set; }
        RMDB db;
        private BindingSource bsWarehouse;
        private BindingSource bsWH;

        private void FrmCheckExpiryDate_Load(object sender, EventArgs e)
        {

        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }
        private void Datasources(ComboBox ComboboxName , DataTable DTable, string DisplayMember , string ValueMember)
        {
            ComboboxName.DataSource = DTable;
            ComboboxName.DisplayMember = DisplayMember;
            ComboboxName.ValueMember = ValueMember;
            ComboboxName.SelectedIndex = -1;

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

        }

        private void BtnOK_Click_1(object sender, EventArgs e)
        {

        }

        private void DgvShow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DgvShow_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DateTime DateExpiry;
            DateTime CurDate;

            foreach (DataGridViewRow row in DgvShow.Rows)
            {
                DateExpiry = DBNull.Value.Equals(row.Cells["expiryDate"].Value) ? Todate : Convert.ToDateTime(row.Cells["expiryDate"].Value);
                CurDate = DBNull.Value.Equals(row.Cells["curDate"].Value) ? Todate : Convert.ToDateTime(row.Cells["curDate"].Value);

                if ((DateExpiry - CurDate).Days <= 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

        }

        private void Loading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Loading.Enabled = false;
            string warehouseId = "";
            if (this.cmbWarehouseName.InternalListBox != null)
            {
                if (this.cmbWarehouseName.InternalListBox.Items[0].CheckState == CheckState.Checked)
                {
                    warehouseId = "";
                }
                else
                {
                    warehouseId = "";
                    foreach (Guid l in this.cmbWarehouseName.Properties.GetItems().GetCheckedValues())
                    {
                        warehouseId += string.Format("{0},", l);
                    }
                    if (!warehouseId.Trim().Equals(""))
                    {
                        warehouseId = warehouseId.Substring(0, warehouseId.Length - 1).Trim();
                    }
                }

            }
            string sql = $@"DECLARE @barcode AS NVARCHAR(15) = N'{vBarcode}';
DECLARE @warehouseId NVARCHAR(MAX) = N'{warehouseId}';
IF ((@warehouseId IS NULL) OR (@warehouseId = N''))
        SET @warehouseId = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);

SET @warehouseId = CASE
                      WHEN RIGHT(@warehouseId, 1) = N',' THEN
                          @warehouseId
                      ELSE
                          CONCAT(@warehouseId, N',')
                  END;
    DECLARE @warehouseIdList AS TABLE
    (
        [warehouseId] UNIQUEIDENTIFIER NULL
    );
    WITH warehouseIdList ([warehouseId], [item])
    AS (SELECT LEFT(@warehouseId, CHARINDEX(N',', @warehouseId) - 1) [warehouseId],
               STUFF(@warehouseId, 1, CHARINDEX(N',', @warehouseId), N'') [item]
        UNION ALL
        SELECT LEFT([item], CHARINDEX(N',', [item]) - 1) [warehouseId],
               STUFF([item], 1, CHARINDEX(N',', [item]), N'') [item]
        FROM warehouseIdList
        WHERE [item] <> N'')
    INSERT INTO @warehouseIdList
    (
        [warehouseId]
    )
    SELECT [warehouseId]
    FROM warehouseIdList
    GROUP BY [warehouseId]
    OPTION (MAXRECURSION 32767);

WITH locationNotForSellList AS
  (SELECT [id] ,
          [locationid] ,
          [locationname] ,
          [location] ,
          [level] ,
          [createddate],
          N'Not For Sell' [status]
   FROM [DBWarehouses].[dbo].[.tbllocation.not.for.sell])
SELECT [lh].[warehouseName],
       [lw].[ProNumy] [unitNumber],
       [lw].[ProName] [proName],
       [lw].[ProPackSize] [size],
       [lw].[ProQtyPCase] [qtyPerCase],
       [lw].[Expiry] [expiryDate],
       [lw].[BatchCode] [batchcode],
       SUM([lw].[QtyOnHand]) [stock],
       [ll].[status],
       GETDATE() [curDate]
FROM [Stock].[dbo].[TPRWarehouseStockIn] lw
INNER JOIN [Stock].[dbo].[TPRWarehouseLocationName] ln on([lw].[locationid] = [ln].[mainid])
INNER JOIN [DBWarehouses].[dbo].[tblWarehouseName] lh on([ln].[warehouseId] = [lh].[id])
LEFT OUTER JOIN locationNotForSellList ll ON ([ll].[locationid] = [lw].[locationid])
WHERE ((
    [ln].[warehouseId] IN
    (
        SELECT [lx].[warehouseId] FROM @warehouseIdList lx GROUP BY [lx].[warehouseId]
    )
    OR CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER) IN
        (
            SELECT [lx].[warehouseId] FROM @warehouseIdList lx GROUP BY [lx].[warehouseId]
        )
) AND ([lw].[ProNumy] = @barcode))
GROUP BY [lh].[warehouseName],
         [lw].[ProNumy],
         [lw].[ProName],
         [lw].[ProPackSize],
         [lw].[ProQtyPCase],
         [lw].[Expiry],
         [lw].[BatchCode],
         [ll].[status]
ORDER BY [lh].[warehouseName],
         [lw].[Expiry]";
            DataTable tbl = Data.Selects(sql, Initialized.GetConnectionType(Data, App));
            List<warehouseStockInExpiryModel> result = this.GetDataTableToObject<warehouseStockInExpiryModel>(tbl);
            this.bsWH = new BindingSource(result, null);
            this.DgvShow.DataSource = this.bsWH;
            this.DgvShow.Refresh();
            this.Cursor = Cursors.Default;


        }
        public List<T> GetDataTableToObject<T>(DataTable pDataTable)
        {
            List<T> ls = new List<T>();
            T o;

            foreach (DataRow dr in pDataTable.Rows)
            {
                o = Activator.CreateInstance<T>();
                object value;
                foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    try
                    {
                        if (pDataTable.Columns.Contains(p.Name))
                        {
                            Type propType = p.PropertyType;
                            value = DBNull.Value.Equals(dr[p.Name]) ? null : Convert.ChangeType(dr[p.Name], propType);
                            p.SetValue(o, value, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception if needed
                    }
                }
                ls.Add(o);
            }
            return ls;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if(this.bsWarehouse != null || this.cmbWarehouseName.Text.Trim().Equals("")== true)
            {
                this.Cursor = Cursors.Default;
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select which warehouse you are standing!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string warehouseId = "";
            if(this.cmbWarehouseName.InternalListBox != null)
            {
                if(this.cmbWarehouseName.InternalListBox.Items[0].CheckState == CheckState.Checked)
                {
                    warehouseId = "";

                }
                else
                {
                    warehouseId = "";
                    foreach (Guid l in this.cmbWarehouseName.Properties.GetItems().GetCheckedValues())
                    {
                        warehouseId += string.Format($"{l}");

                    }
                    if(warehouseId.Trim().Equals("") == false)
                    {
                        warehouseId = warehouseId.Substring(0, warehouseId.Length - 1).Trim();
                    }
                }
            }

            sExpiryDate vreport = new sExpiryDate();
            OleDbDataAdapter vadapter;
            DataSet vsd;
            ReportPrintTool vtool;
            query = @"  DECLARE @oBarcode AS NVARCHAR(15) = N'{1}';
DECLARE @warehouseId NVARCHAR(MAX) = N'{2}';
IF ((@warehouseId IS NULL) OR (@warehouseId = N''))
        SET @warehouseId = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);

SET @warehouseId = CASE
                      WHEN RIGHT(@warehouseId, 1) = N',' THEN
                          @warehouseId
                      ELSE
                          CONCAT(@warehouseId, N',')
                  END;
    DECLARE @warehouseIdList AS TABLE
    (
        [warehouseId] UNIQUEIDENTIFIER NULL
    );
    WITH warehouseIdList ([warehouseId], [item])
    AS (SELECT LEFT(@warehouseId, CHARINDEX(N',', @warehouseId) - 1) [warehouseId],
               STUFF(@warehouseId, 1, CHARINDEX(N',', @warehouseId), N'') [item]
        UNION ALL
        SELECT LEFT([item], CHARINDEX(N',', [item]) - 1) [warehouseId],
               STUFF([item], 1, CHARINDEX(N',', [item]), N'') [item]
        FROM warehouseIdList
        WHERE [item] <> N'')
    INSERT INTO @warehouseIdList
    (
        [warehouseId]
    )
    SELECT [warehouseId]
    FROM warehouseIdList
    GROUP BY [warehouseId]
    OPTION (MAXRECURSION 32767);

                        WITH s AS (
	                        SELECT i.[ProID],i.[ProNumY],i.[ProNumYP],i.[ProNumYC],i.[Sup1],i.[ProName],i.[KhmerNameUnicode],i.[ProPacksize],i.[ProQtyPCase],i.[ProQtyPPack],i.[ProTotQty],N'' [Status]
	                        FROM [Stock].[dbo].[TPRProducts] i
	                        WHERE (ISNULL(i.[ProNumY],N'') = @oBarcode) OR (ISNULL(i.[ProNumYP],N'') = @oBarcode) OR (ISNULL(i.[ProNumYC],N'') = @oBarcode)
	                        UNION ALL
	                        SELECT i.[ProID],i.[ProNumY],i.[ProNumYP],i.[ProNumYC],i.[Sup1],i.[ProName],i.[KhmerNameUnicode],i.[ProPacksize],i.[ProQtyPCase],i.[ProQtyPPack],i.[ProTotQty],N'DC' [Status]
	                        FROM [Stock].[dbo].[TPRProductsDeactivated] i
	                        WHERE (ISNULL(i.[ProNumY],N'') = @oBarcode) OR (ISNULL(i.[ProNumYP],N'') = @oBarcode) OR (ISNULL(i.[ProNumYC],N'') = @oBarcode)
	                        UNION ALL
	                        SELECT i.[ProID],v.[OldProNumy] [ProNumY],i.[ProNumYP],i.[ProNumYC],i.[Sup1],i.[ProName],i.[KhmerNameUnicode],i.[ProPacksize],i.[ProQtyPCase],i.[ProQtyPPack],v.[Stock] [ProTotQty],N'Old Code' [Status]
	                        FROM [Stock].[dbo].[TPRProducts] i 
	                        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v ON v.ProId = i.ProID
	                        WHERE (ISNULL(i.[ProNumY],N'') = @oBarcode) OR (ISNULL(i.[ProNumYP],N'') = @oBarcode) OR (ISNULL(i.[ProNumYC],N'') = @oBarcode)
	                        UNION ALL
	                        SELECT i.[ProID],v.[OldProNumy] [ProNumY],i.[ProNumYP],i.[ProNumYC],i.[Sup1],i.[ProName],i.[KhmerNameUnicode],i.[ProPacksize],i.[ProQtyPCase],i.[ProQtyPPack],v.[Stock] [ProTotQty],N'Old Code' [Status]
	                        FROM [Stock].[dbo].[TPRProductsDeactivated] i 
	                        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v ON v.ProId = i.ProID
	                        WHERE (ISNULL(i.[ProNumY],N'') = @oBarcode) OR (ISNULL(i.[ProNumYP],N'') = @oBarcode) OR (ISNULL(i.[ProNumYC],N'') = @oBarcode)
                        )
                        SELECT s.ProNumY [UnitNumber],
                        s.ProNumYP [PackNumber],
                        s.ProNumYC [CaseNumber],
                        s.ProName [ProName],
                        s.KhmerNameUnicode [KhmerName],
                        s.ProPacksize [Size],
                        s.ProQtyPCase [QtyPerCase],
                        s.ProQtyPPack [QtyPerPack],
                        s.ProTotQty [StockIn],
                        LEFT(s.Sup1,8) [SupNum],
                        RTRIM(LTRIM(SUBSTRING(s.Sup1,9,LEN(s.Sup1)))) [SupName],
						o.[locationname],
						o.[location],
						o.[level],
                        w.QtyOnHand [QtyOnHand],
                        w.Expiry [ExpiryDate],
                        o.Status [Status]
						INTO #oExpiryList
                        FROM s
                        LEFT OUTER JOIN [Stock].[dbo].[TPRWarehouseStockIn] w ON (w.ProNumy = s.ProNumY)
                        INNER JOIN [Stock].[dbo].[TPRWarehouseLocationName] ln on([w].[locationid] = [ln].[mainid])
                        INNER JOIN [DBWarehouses].[dbo].[tblWarehouseName] lh on([ln].[warehouseId] = [lh].[id])
                        LEFT OUTER JOIN (
					    SELECT [id],[locationname],[location],[level],N'Not For Sell' [Status]
					    FROM [DBWarehouses].[dbo].[.tbllocation.not.for.sell]
					    ) o ON (o.locationname = w.LocName) AND (o.location = w.Location) AND (o.level = w.LocationLevel) 
WHERE (
    [ln].[warehouseId] IN
    (
        SELECT [lx].[warehouseId] FROM @warehouseIdList lx GROUP BY [lx].[warehouseId]
    )
    OR CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER) IN
        (
            SELECT [lx].[warehouseId] FROM @warehouseIdList lx GROUP BY [lx].[warehouseId]
        )
)
                        ORDER BY s.ProNumY,w.Expiry,CONVERT(DECIMAL,w.LocationLevel) DESC,w.Location,w.LocName;

						SELECT s.[UnitNumber],
                        s.[PackNumber],
                        s.[CaseNumber],
                        s.[ProName],
                        s.[KhmerName],
                        s.[Size],
                        s.[QtyPerCase],
                        s.[QtyPerPack],
                        s.[StockIn],
                        s.[SupNum],
                        s.[SupName],
						s.[locationname],
						s.[location],
						s.[level],
                        SUM(s.[QtyOnHand]) [QtyOnHand],
                        CONVERT(DATE,s.[ExpiryDate]) [ExpiryDate],
                        s.[Status]
						FROM #oExpiryList s
						GROUP BY s.[UnitNumber],
                        s.[PackNumber],
                        s.[CaseNumber],
                        s.[ProName],
                        s.[KhmerName],
                        s.[Size],
                        s.[QtyPerCase],
                        s.[QtyPerPack],
                        s.[StockIn],
                        s.[SupNum],
                        s.[SupName],
						s.[locationname],
						s.[location],
						s.[level],
                        CONVERT(DATE,s.[ExpiryDate]),
                        s.[Status]
						ORDER BY s.[UnitNumber],CONVERT(DATE,s.[ExpiryDate]);

						DROP TABLE #oExpiryList;";
            query = string.Format(query, DatabaseName, vBarcode, warehouseId);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));

           vreport = new sExpiryDate();
             vadapter = new OleDbDataAdapter();
            DataSet vds = new DataSet();
             vtool = new ReportPrintTool(vreport);
            vreport.Parameters["companyname"].Value = string.Format("{0}{1}{2}", Initialized.R_CompanyKhmerName, Environment.NewLine, Initialized.R_CompanyName);
            vreport.Parameters["companyaddress"].Value = string.Format("{0}{1}{2}{1}Tel:{3}", Initialized.R_CompanyKhmAddress.Replace(Environment.NewLine, "").Trim(), Environment.NewLine, Initialized.R_CompanyAddress.Replace(Environment.NewLine, "").Trim(), Initialized.R_CompanyTelephone);
            vreport.Parameters["currentdate"].Value = Todate;
            vreport.Parameters["cusnum"].Value = vCusNum.Trim();
            vreport.Parameters["cusname"].Value = vCusname.Trim();
            vreport.DataSource = lists;
            vreport.DataAdapter = vadapter;
            vreport.DataMember = "dtExpiryDate";
            vreport.RequestParameters = false;
            // vtool.AutoShowParametersPanel = false;
            // vtool.PrinterSettings.Copies = 1;
            // vtool.ShowRibbonPreviewDialog();
            gui_preview gui_ = new gui_preview { WindowState = FormWindowState.Maximized };
            gui_.docviewer.DocumentSource = vreport;
            gui_.docviewer.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Customize, DevExpress.XtraPrinting.CommandVisibility.None);
            gui_.docviewer.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, DevExpress.XtraPrinting.CommandVisibility.None);
            vreport.CreateDocument(true);
            gui_.ShowDialog(this);


        }

        private void warehouseNameLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.warehouseNameLoading.Enabled = false;
            string sql = @"DECLARE @RC INT;
EXECUTE @RC = [DBWarehouses].[dbo].[getWarehouseNameList];";

            DataTable dt = db.GetDataTable(sql);
            List<warehouseNameModel> result = this.GetDataTableToObject<warehouseNameModel>(dt);
            this.bsWarehouse = new BindingSource(result, null);
            this.cmbWarehouseName.Properties.DataSource = this.bsWarehouse;
            this.cmbWarehouseName.Properties.DisplayMember = "warehouseName";
            this.cmbWarehouseName.Properties.ValueMember = "id";
            foreach(CheckedListBoxItem l in cmbWarehouseName.Properties.GetItems())
            {
                l.CheckState = CheckState.Checked;
            }
            this.Position_Changed(this.cmbWarehouseName, e);
            this.Cursor = Cursors.Default;


        }
        private void Position_Changed(object sender, EventArgs e)
        {
            if (this.bsWarehouse == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            warehouseNameModel currentWarehouseName = (warehouseNameModel)this.bsWarehouse.Current;
            if (currentWarehouseName == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            this.Loading.Enabled = true;
        }

        private void cmbWarehouseName_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.cmbWarehouseName.Properties.DataSource == null) return;
            if (this.cmbWarehouseName.InternalListBox == null) return;
            if (this.cmbWarehouseName.InternalListBox.Items.GetCheckedValues().Count <= 0) return;
            if (this.cmbWarehouseName.InternalListBox.Items[0].CheckState == CheckState.Checked) e.DisplayText = "( select all )";

        }

        private void cmbWarehouseName_Closed(object sender, ClosedEventArgs e)
        {
            if (e.CloseMode == DevExpress.XtraEditors.PopupCloseMode.Cancel) return;
            if (this.cmbWarehouseName.Properties.DataSource == null) return;
            if (this.cmbWarehouseName.InternalListBox == null) return;
            if (this.cmbWarehouseName.InternalListBox.Items.GetCheckedValues().Count <= 0) return;

            this.Position_Changed(this.cmbWarehouseName, e);

        }
    }

}
