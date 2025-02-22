using com.sun.org.apache.bcel.@internal.generic;
using DeliveryTakeOrder.App.SendMailDCSKU;
using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.Controller;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DeliveryTakeOrder.Interfaces.check_stock;
using DeliveryTakeOrder.Interfaces.customer_e_commerce;
using DeliveryTakeOrder.Interfaces.promotion_Id;
using DeliveryTakeOrder.Interfaces.Teamleader;
using DeliveryTakeOrder.Interfaces.WS_Products_List;
using DeliveryTakeOrder.message;
using DeliveryTakeOrder.Model;
using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Google.Protobuf.WellKnownTypes;
using K4os.Compression.LZ4.Internal;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmDeliveryTakeOrder : Form
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
        private const string InvoiceName = "";
        public string ProgramName { get; set; }
        public bool IsDutchmill { get; set; }
        private RMDB db;

        private APIsController app_;
        private const string allsd_ = "/User/sd/list";
        private List<SDModel> lstsd_;
        private BindingSource bssd_;
        private AllowanceModel lstcheckallowance_;


        private const string checkallowance_ = "/Purchase/check-allowance/{0}";
        //private AllowanceModel lstcheckallowance_;

        private MDI mdi_;
        private warehouseNameModel warehouseName;
        private BindingSource bsDistributor;
        public FrmDeliveryTakeOrder(MDI mdi_, warehouseNameModel warehouseName)
        {
            InitializeComponent();
            this.mdi_ = mdi_;
            this.warehouseName = warehouseName;
            this.Text = string.Format("Delivery Take Order - {0}", this.warehouseName.warehouseName).ToLower().Trim();
            this.lblWarehouseName.Text = string.Format("{0}", this.warehouseName.warehouseName).ToUpper().Trim();
            this.chkallitems.Checked = false;
            this.lblDescriptionWarehouse.Text = $"Total {this.warehouseName.warehouseName.ToUpper().Trim()}'s Stockuin :";
            if (Initialized.vIsNestleOnly)
            {
                this.chkallitems.Visible = true;
            }
            this.PicLogo.Image = Initialized.R_Logo;
            this.LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();


            this.LoadingInitialized();

            if (this.warehouseName.allowManuallyPromotion == false)
            {
                this.loginToken();
                this.lstsd_ = app_.GetAllSD(String.Format("{0}{1}", Initialized.url_, allsd_));
                this.bssd_ = new BindingSource(this.lstsd_, null);

            }

            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.CreateDeliveryTakeOrderList();
            this.TimerLoading.Enabled = true;
            this.TimerSalemanLoading.Enabled = true;
            this.refreshonlinepo.Enabled = true;
            this.warehouseNameColor.Enabled = true;



        }
        private string _reason_continue = "";
        private void loginToken()
        {
            if (app_ != null)
            {
                app_ = null;
            }
            app_ = new APIsController("UNT SD");
            app_.Login(string.Format("{0}{1}", Initialized.url_, Initialized.login_), Initialized.username_, Initialized.password_);
        }
        private void LoadingInitialized()
        {
            db = AppSetting.DBMain;

            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

            if (this.IsDutchmill)
            {
                this.RdbManually.Visible = false;
                this.rdbcostlowecommerence.Visible = false;
                this.piccreatecustomerecommerce.Visible = false;
                this.RdbOnlinePO.Visible = false;
                this.LblDisplay.Text = "DUTCHMILL";
            }
            else
            {
                this.RdbManually.Visible = true;
                this.rdbcostlowecommerence.Visible = false;
                this.piccreatecustomerecommerce.Visible = false;
                this.RdbOnlinePO.Visible = true;
                this.LblDisplay.Text = "";
            }

            this.vponumber_ = "";
        }
        private void DataSources(System.Windows.Forms.ComboBox comboBoxName, DataTable dTable, string displayMember, string valueMember)
        {
            comboBoxName.DataSource = dTable;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.ValueMember = valueMember;
            comboBoxName.SelectedIndex = -1;
        }

        private void CreateDeliveryTakeOrderList()
        {
            if (vPromotionList != null) vPromotionList = null;
            vPromotionList = new DataTable();
            vPromotionList.Columns.Add("PromotionIdLink", typeof(decimal));
            vPromotionList.Columns.Add("QtyInvoicing", typeof(int));
            vPromotionList.Columns.Add("Division", typeof(string));

            if (vFixedPriceList != null) vFixedPriceList = null;
            vFixedPriceList = new DataTable();
            vFixedPriceList.Columns.Add("FixedIdLink", typeof(decimal));
            vFixedPriceList.Columns.Add("Barcode", typeof(string));
            vFixedPriceList.Columns.Add("QtyInvoicing", typeof(int));

            if (DeliveryTakeOrderList != null) DeliveryTakeOrderList = null;
            DeliveryTakeOrderList = new DataTable();
            DeliveryTakeOrderList.Columns.Add("Barcode", typeof(string));
            DeliveryTakeOrderList.Columns.Add("ProNumy", typeof(string));
            DeliveryTakeOrderList.Columns.Add("ProNumyP", typeof(string));
            DeliveryTakeOrderList.Columns.Add("ProNumyC", typeof(string));
            DeliveryTakeOrderList.Columns.Add("ProName", typeof(string));
            DeliveryTakeOrderList.Columns.Add("ProPackSize", typeof(string));
            DeliveryTakeOrderList.Columns.Add("ProQtyPCase", typeof(int));
            DeliveryTakeOrderList.Columns.Add("ProCat", typeof(string));
            DeliveryTakeOrderList.Columns.Add("SupNum", typeof(string));
            DeliveryTakeOrderList.Columns.Add("SupName", typeof(string));
            DeliveryTakeOrderList.Columns.Add("PcsFree", typeof(decimal));
            DeliveryTakeOrderList.Columns.Add("PcsOrder", typeof(decimal));
            DeliveryTakeOrderList.Columns.Add("PackOrder", typeof(decimal));
            DeliveryTakeOrderList.Columns.Add("CTNOrder", typeof(float));
            DeliveryTakeOrderList.Columns.Add("TotalPcsOrder", typeof(decimal));
            DeliveryTakeOrderList.Columns.Add("ItemDiscount", typeof(float));
            DeliveryTakeOrderList.Columns.Add("PromotionMachanic", typeof(string));
            DeliveryTakeOrderList.Columns.Add("Remark", typeof(string));
            DeliveryTakeOrderList.Columns.Add("Reason_Continue", typeof(string));
            DeliveryTakeOrderList.Columns.Add("TotalAmount", typeof(double));
            DeliveryTakeOrderList.Columns.Add("Division", typeof(string));

            DgvShow.DataSource = DeliveryTakeOrderList;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row : {0}", DgvShow.RowCount);

            this.chkgenerate.Checked = false;
            this.chknone.Checked = false;
        }
        private void DTPRequiredDate_MouseDown(object sender, MouseEventArgs e)
        {
            TxtRequiredDate.Text = DTPRequiredDate.Value.ToString("dd-MMM-yyyy");

        }
        private void DTPRequiredDate_ValueChanged(object sender, EventArgs e)
        {
            if (DTPRequiredDate.Value.Date < Todate.Date)
            {
                MessageBox.Show("Please check Required Date again!", "Invalid Required Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DTPRequiredDate.Value = Todate;
                return;
            }
            TxtRequiredDate.Text = string.Format("{0:dd-MMM-yyyy}", DTPRequiredDate.Value);
        }

        private string vponumber_;

        public string VpoNumber
        {
            get { return vponumber_; }
            set { vponumber_ = value; }
        }
        private void TimerLoading_Tick(object sender, EventArgs e)
        {
            TimerLoading.Enabled = false;
            App.ClearController(TxtEmpName, TxtOrderDate, TxtInvoiceNo, TxtPONo);
            TxtEmpName.Text = Environment.MachineName;
            TxtOrderDate.Text = string.Format("{0:dd-MMM-yyyy}", Todate);
            DTPDeliverDate.Value = Todate;

            long InvNo = 0;
            string query = @"
            DECLARE @RC INT;
            EXECUTE @RC = [DBPickers].[dbo].[auto_check_item_separately];
            EXECUTE @RC = [DBPickers].[dbo].[SeperateTakeOrderNumberByDivision];
            EXECUTE @RC = [DBPickers].[dbo].[SeperateTakeOrderNumberByStateCharge];

            SELECT [PrintInvNo], [IsBusy]
            FROM [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo];
            ";
            query = string.Format(query, DatabaseName, 0);
            var lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                InvNo = lists.Rows[0].IsNull("PrintInvNo") ? 0 : Convert.ToInt64(lists.Rows[0]["PrintInvNo"]);
            }
            InvNo += 1;
            this.TxtInvoiceNo.Text = InvNo.ToString();
            this.RdbManually.Checked = true;


            this.switchFree.IsOn = false;
            this.switchFree.Enabled = false;
            this.TxtPcsFree.ReadOnly = true;
            this.TxtItemDiscount.ReadOnly = true;
            this.txtpromotionid.Visible = true;
            this.cmbPromotionId.Visible = false;
            this.btnAddPromotionID.Visible = false;

            if (this.warehouseName != null)
            {
                if (this.warehouseName.allowManuallyPromotion)
                {
                    this.switchFree.Enabled = true;
                    this.TxtPcsFree.ReadOnly = false;
                    this.TxtItemDiscount.ReadOnly = false;
                    this.txtpromotionid.Visible = false;
                    this.cmbPromotionId.Visible = true;
                    this.btnAddPromotionID.Visible = true;
                    this.promotionIdLoading.Enabled = true;
                }
            }

        }


        private void TimerCustomerLoading_Tick_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.TimerCustomerLoading.Enabled = false;
            this.IsKeyPress = true;
            string distributorSelected = $"{this.warehouseName.id}";
            //  this.IsKeyPress = true;

            if (this.RdbManually.Checked)
            {
                if (this.ProgramName.Equals("Sale_Team"))
                {
                    this.query = @"
                   DECLARE @distributorId NVARCHAR(MAX) = N'{3}';

IF (
       (@distributorId IS NULL)
       OR (@distributorId = N'')
       OR (@distributorId = N'( select all )')
   )
    SET @distributorId = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);

SET @distributorId = CASE
                         WHEN RIGHT(@distributorId, 1) = N',' THEN
                             @distributorId
                         ELSE
                             CONCAT(@distributorId, N',')
                     END;
DECLARE @distributorIdList AS TABLE
(
    [distributorId] UNIQUEIDENTIFIER NULL
);
WITH distributorIdList ([distributorId], [items])
AS (SELECT LEFT(@distributorId, CHARINDEX(N',', @distributorId) - 1) [distributorId],
           STUFF(@distributorId, 1, CHARINDEX(N',', @distributorId), N'') [items]
    UNION ALL
    SELECT LEFT([items], CHARINDEX(N',', [items]) - 1) [distributorId],
           STUFF([items], 1, CHARINDEX(N',', [items]), N'') [items]
    FROM distributorIdList
    WHERE [items] <> N'')
INSERT INTO @distributorIdList
(
    [distributorId]
)
SELECT [distributorId]
FROM distributorIdList
GROUP BY [distributorId]
OPTION (MAXRECURSION 32767);

WITH customerList
AS (SELECT [lc].[CusNum],
           [lc].[CusName]
    FROM [Stock].[dbo].[TPRCustomer] lc
    WHERE ([lc].[Status] = 'Activate')
          AND ([lc].[CusName] LIKE 'YN %')
          AND
          (
              ([lc].[distributorUnderId] IN
               (
                   SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
               )
              )
              OR (CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)IN
                  (
                      SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
                  )
                 )
          ))
SELECT [lc].[CusNum],
       [lc].[CusName]
FROM customerList lc
GROUP BY [lc].[CusNum],
         [lc].[CusName]
ORDER BY [lc].[CusName];
                ";
                }
                else
                {
                    this.query = @"DECLARE @distributorId NVARCHAR(MAX) = N'{3}';

IF (
       (@distributorId IS NULL)
       OR (@distributorId = N'')
       OR (@distributorId = N'( select all )')
   )
    SET @distributorId = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);

SET @distributorId = CASE
                         WHEN RIGHT(@distributorId, 1) = N',' THEN
                             @distributorId
                         ELSE
                             CONCAT(@distributorId, N',')
                     END;
DECLARE @distributorIdList AS TABLE
(
    [distributorId] UNIQUEIDENTIFIER NULL
);
WITH distributorIdList ([distributorId], [items])
AS (SELECT LEFT(@distributorId, CHARINDEX(N',', @distributorId) - 1) [distributorId],
           STUFF(@distributorId, 1, CHARINDEX(N',', @distributorId), N'') [items]
    UNION ALL
    SELECT LEFT([items], CHARINDEX(N',', [items]) - 1) [distributorId],
           STUFF([items], 1, CHARINDEX(N',', [items]), N'') [items]
    FROM distributorIdList
    WHERE [items] <> N'')
INSERT INTO @distributorIdList
(
    [distributorId]
)
SELECT [distributorId]
FROM distributorIdList
GROUP BY [distributorId]
OPTION (MAXRECURSION 32767);

WITH customerList
AS (SELECT [lc].[CusNum],
           [lc].[CusName]
    FROM [Stock].[dbo].[TPRCustomer] lc
    WHERE ([lc].[Status] = 'Activate')
          AND
          (
              ([lc].[distributorUnderId] IN
               (
                   SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
               )
              )
              OR (CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)IN
                  (
                      SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
                  )
                 )
          ))
SELECT [lc].[CusNum],
       [lc].[CusName]
FROM customerList lc
GROUP BY [lc].[CusNum],
         [lc].[CusName]
ORDER BY [lc].[CusName];
                ";
                }
            }
            else if (this.rdbcostlowecommerence.Checked)
            {
                this.query = @"
            SELECT DISTINCT [CusNum],[CusName]
            FROM [DBCostLowECommerce].[dbo].[TblCustomer]
            WHERE [Status] = 'Activate'
            ORDER BY [CusName];
        ";
            }
            else
            {
                this.query = @"
DECLARE @vteam_ AS INT = {2};

SELECT *
INTO #team_
FROM DBUNTWHOLESALECOLTD.dbo.TblSetSaleManagerToSupplier s;

UPDATE x
SET [x].[TeamName] = N'Alpha',
    [x].[TeamID] = 1,
    [x].[SaleManagerID] = 1
FROM #team_ x
WHERE ([x].[TeamName] NOT IN ( N'Charlie', N'Delta' ));

UPDATE x
SET [x].[TeamName] = N'Charlie + Delta',
    [x].[TeamID] = 2,
    [x].[SaleManagerID] = 2
FROM #team_ x
WHERE ([x].[TeamName] IN ( N'Charlie', N'Delta' ));

WITH vItem
AS (SELECT [x].[ProNumY] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8) IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8) IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYP], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8) IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYC], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumY] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8) IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8) IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYP], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8) IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYC], N'') <> N'')
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8) IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8) IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          ))
SELECT [x].*
INTO #lst_items
FROM vItem x;

SELECT [CusNum],
       [CusName]
FROM [Stock].[dbo].[TPRCustomer]
WHERE [Status] = 'Activate'
      AND [CusNum] IN
          (
              SELECT [v].[CusNum]
              FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                  INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] o
                      ON ([v].[Id] = [o].[POId])
              WHERE ([v].[OrderDate] IS NOT NULL)
                    AND ([v].[DeliveryDate] IS NOT NULL)
                    AND ([o].[Barcode] IN
                         (
                             SELECT [Barcode] FROM #lst_items GROUP BY [Barcode]
                         )
                        )
              GROUP BY [v].[CusNum]
          )
ORDER BY [CusName];

DROP TABLE #team_;
DROP TABLE #lst_items;
        ";
            }

            this.query = string.Format(this.query, DatabaseName,
        (Initialized.vIsNestleOnly == true && !this.chkallitems.Checked ? "" : "--"),
        AppSetting.SaleManagerID, distributorSelected);
            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            DataSources(this.CmbBillTo, this.lists, "CusName", "CusNum");
            this.CmbBillTo.SelectedIndex = -1;
            this.Cursor = Cursors.Default;
        }
        private void TimerDeltoLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.TimerDeltoLoading.Enabled = false;
            string CusNum = "";
            if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.CmbBillTo.Text))
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = this.CmbBillTo.SelectedValue.ToString();
                }
            }

            if (this.RdbManually.Checked)
            {
                this.query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
SELECT [DefId] [Id],[DelTo]
FROM [Stock].[dbo].[TPRDelto]
WHERE ([CusNum] = @CusNum)
GROUP BY [DefId],[DelTo]
ORDER BY [DelTo];
";
                this.query = string.Format(this.query, DatabaseName, CusNum);
            }
            else if (this.rdbcostlowecommerence.Checked)
            {
                this.query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
SELECT [DefId] [Id],[DelTo]
FROM [DBCostLowECommerce].[dbo].[TblCustomer]
WHERE ([CusNum] = @CusNum)
GROUP BY [DefId],[DelTo]
ORDER BY [DelTo];
";
                this.query = string.Format(this.query, DatabaseName, CusNum);
            }
            else
            {
                this.query = @"
DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
DECLARE @vteam_ AS INT = {2};

SELECT *
INTO #team_
FROM DBUNTWHOLESALECOLTD.dbo.TblSetSaleManagerToSupplier s;

UPDATE x
SET [x].[TeamName] = N'Alpha',
    [x].[TeamID] = 1,
    [x].[SaleManagerID] = 1
FROM #team_ x
WHERE ([x].[TeamName] NOT IN ( N'Charlie', N'Delta' ));

UPDATE x
SET [x].[TeamName] = N'Charlie + Delta',
    [x].[TeamID] = 2,
    [x].[SaleManagerID] = 2
FROM #team_ x
WHERE ([x].[TeamName] IN ( N'Charlie', N'Delta' ));

WITH vItem
AS (SELECT [x].[ProNumY] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYP], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYC], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumY] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYP], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYC], N'') <> N'')
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          ))
SELECT [x].*
INTO #lst_items
FROM vItem x;

SELECT [DefId] [Id],
       [DelTo]
FROM [Stock].[dbo].[TPRDelto]
WHERE ([CusNum] = @CusNum)
      AND ([DefId] IN
           (
               SELECT [v].[DeltoId]
               FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                   INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] o
                       ON ([v].[Id] = [o].[POId])
               WHERE ([v].[OrderDate] IS NOT NULL)
                     AND ([v].[DeliveryDate] IS NOT NULL)
                     AND ([v].[CusNum] = @CusNum)
                     AND ([o].[Barcode] IN
                          (
                              SELECT [Barcode] FROM #lst_items GROUP BY [Barcode]
                          )
                         )
               GROUP BY [v].[DeltoId]
           )
          )
GROUP BY [DefId],
         [DelTo]
ORDER BY [DelTo];

DROP TABLE #team_;
DROP TABLE #lst_items;
";
                this.query = string.Format(this.query, DatabaseName, CusNum, AppSetting.SaleManagerID);
            }

            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            DataSources(this.CmbDelto, this.lists, "DelTo", "Id");

            decimal vid_ = Convert.ToDecimal(string.IsNullOrWhiteSpace(this.TxtIdDelto.Text) ? "0" : this.TxtIdDelto.Text.Trim());
            if (vid_ == 0)
            {
                if (this.CmbDelto.Items.Count == 1) this.CmbDelto.SelectedIndex = 0;
            }
            else
            {
                this.CmbDelto.SelectedValue = vid_;
            }
            this.Cursor = Cursors.Default;
        }

        private void TimerSalemanLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerSalemanLoading.Enabled = false;

            string query = @"
WITH v AS (
    SELECT 0 AS [Index], N'EMP0000000' AS [Value], N'Admin' AS [Display], N'Admin' AS [SalesmanName]
    UNION ALL
    SELECT 1 AS [Index], COALESCE([EmployeeNumber], N'') AS [Value], 
           COALESCE([SalesmanName], N'') + ' (' + ISNULL([SalesmanNumber], '') + ')' AS [Display], 
           [SalesmanName]
    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblSetSalesmanToSalesManager]
    WHERE COALESCE([EmployeeNumber], N'') IN (
        SELECT [empid]
        FROM [DBEmployeeUNTWHOLESALECOLTD].[dbo].[tblinfoemployees]
        WHERE [status] = N'Active'
    )
    GROUP BY COALESCE([EmployeeNumber], N''), 
             COALESCE([SalesmanName], N'') + ' (' + ISNULL([SalesmanNumber], '') + ')', 
             [SalesmanName]
)
SELECT [v].[Index], [v].[Value], [v].[Display], [v].[SalesmanName]
FROM v
GROUP BY [v].[Index], [v].[Value], [v].[Display], [v].[SalesmanName]
ORDER BY [v].[Index], [v].[SalesmanName];
";

            query = string.Format(query, DatabaseName);
            var lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(this.CmbSaleman, lists, "Display", "Value");
            this.Cursor = Cursors.Default;
        }
        private Random rnd = new Random();
        private decimal qty_online_po;

        private void TimerCategoryLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.TimerCategoryLoading.Enabled = false;
            this.App.ClearController(TxtIdDelto, TxtZone, TxtKhmerName, TxtNote, txtpromotionid);
            string CusNum = "";
            if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.CmbBillTo.Text))
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = this.CmbBillTo.SelectedValue.ToString();
                }
            }

            this.query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
IF EXISTS (SELECT * FROM [Stock].[dbo].[TPRWSCusProductList] WHERE [CusNum] = @CusNum)
BEGIN
    SELECT [Index],[ProCat]
    FROM (
        SELECT 0 AS [Index],'All Categories' AS [ProCat]
        UNION ALL 
        SELECT 1 AS [Index],[ProCat]
        FROM [Stock].[dbo].[TPRProducts]
        WHERE [ProNumY] IN (SELECT [ProNumY] FROM [Stock].[dbo].[TPRWSCusProductList] WHERE ([CusNum] = @CusNum))
        {3}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
        {2} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
    ) lists
    GROUP BY [Index],[ProCat]
    ORDER BY [Index],[ProCat];
END
ELSE
BEGIN
    SELECT [Index],[ProCat]
    FROM (
        SELECT 0 AS [Index],'All Categories' AS [ProCat]
        UNION ALL 
        SELECT 1 AS [Index],[ProCat]
        FROM [Stock].[dbo].[TPRProducts]
        {3}WHERE LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
        {2} WHERE LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
    ) lists
    GROUP BY [Index],[ProCat]
    ORDER BY [Index],[ProCat];
END
";
            this.query = string.Format(this.query, DatabaseName, CusNum, IsDutchmill ? "" : "--", Initialized.vIsNestleOnly && !this.chkallitems.Checked ? "" : "--");
            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbCategory, lists, "ProCat", "ProCat");
            if (CmbCategory.Items.Count > 0) CmbCategory.SelectedIndex = 0;
            this.Cursor = Cursors.Default;
        }

        private void TimerProductLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.TimerProductLoading.Enabled = false;
            string CusNum = "";
            if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.CmbBillTo.Text))
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = this.CmbBillTo.SelectedValue.ToString();
                }
            }

            decimal deltoid_ = 0;
            if (this.CmbDelto.SelectedValue is DataRowView || this.CmbDelto.SelectedValue == null)
            {
                deltoid_ = 0;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.CmbDelto.Text))
                {
                    deltoid_ = 0;
                }
                else
                {
                    deltoid_ = Convert.ToDecimal(this.CmbDelto.SelectedValue);
                }
            }

            string Category = "";
            if (this.CmbCategory.SelectedValue is DataRowView || this.CmbCategory.SelectedValue == null)
            {
                Category = "";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.CmbCategory.Text))
                {
                    Category = "";
                }
                else
                {
                    Category = this.CmbCategory.SelectedValue.ToString();
                }
            }

            if (this.RdbManually.Checked || this.rdbcostlowecommerence.Checked)
            {
                this.query = @" DECLARE @CusNum AS NVARCHAR(8) = '{1}';
                    DECLARE @Category AS NVARCHAR(100) = N'{2}';
                    WITH sItems AS (
	                    SELECT ISNULL([ProNumY],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display],[Sup1]
	                    FROM [Stock].[dbo].[TPRProducts]
                        WHERE ([ProCat] = @Category OR N'' = @Category OR N'All Categories' = @Category)
                        {4}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
                        {3} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
                        GROUP BY ISNULL([ProNumY],''),ISNULL([ProName],''),ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],''),[Sup1]
	                    UNION ALL 
	                    SELECT ISNULL([ProNumYP],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display],[Sup1]
	                    FROM [Stock].[dbo].[TPRProducts]
	                    WHERE ISNULL([ProNumYP],'') <> '' AND ([ProCat] = @Category OR N'' = @Category OR N'All Categories' = @Category)
                        {4}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
                        {3} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
                        GROUP BY ISNULL([ProNumYP],''),ISNULL([ProName],''),ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],''),[Sup1]
	                    UNION ALL 
	                    SELECT ISNULL([ProNumYC],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display],[Sup1]
	                    FROM [Stock].[dbo].[TPRProducts]
	                    WHERE ISNULL([ProNumYC],'') <> '' AND ([ProCat] = @Category OR N'' = @Category OR N'All Categories' = @Category)
                        {4}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
                        {3} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
                        GROUP BY ISNULL([ProNumYC],''),ISNULL([ProName],''),ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],''),[Sup1]
	                    UNION ALL
                        SELECT ISNULL([ProNumY],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display],[Sup1]
	                    FROM [Stock].[dbo].[TPRProductsDeactivated]
                        WHERE (ISNULL([ProTotQty],0) <> 0) AND ([ProCat] = @Category OR N'' = @Category OR N'All Categories' = @Category)
                        {4}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
                        {3} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
                        GROUP BY ISNULL([ProNumY],''),ISNULL([ProName],''),ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],''),[Sup1]
	                    UNION ALL 
	                    SELECT ISNULL([ProNumYP],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display],[Sup1]
	                    FROM [Stock].[dbo].[TPRProductsDeactivated]
	                    WHERE (ISNULL([ProTotQty],0) <> 0) AND ISNULL([ProNumYP],'') <> '' AND ([ProCat] = @Category OR N'' = @Category OR N'All Categories' = @Category)
                        {4}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
                        {3} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
                        GROUP BY ISNULL([ProNumYP],''),ISNULL([ProName],''),ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],''),[Sup1]
	                    UNION ALL 
	                    SELECT ISNULL([ProNumYC],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display],[Sup1]
	                    FROM [Stock].[dbo].[TPRProductsDeactivated]
	                    WHERE (ISNULL([ProTotQty],0) <> 0) AND ISNULL([ProNumYC],'') <> '' AND ([ProCat] = @Category OR N'' = @Category OR N'All Categories' = @Category)
                        {4}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
                        {3} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
                        GROUP BY ISNULL([ProNumYC],''),ISNULL([ProName],''),ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],''),[Sup1]
	                    UNION ALL 
	                    SELECT ISNULL([B].[OldProNumy],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display],[Sup1]
	                    FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
                        WHERE (A.[ProCat] = @Category OR N'' = @Category OR N'All Categories' = @Category)  
                        {4}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
                        {3} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
                        GROUP BY ISNULL([B].[OldProNumy],''),ISNULL([ProName],''),ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],''),[Sup1]
                        UNION ALL 
	                    SELECT ISNULL([B].[OldProNumy],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display],[Sup1]
	                    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
                        WHERE (ISNULL(B.[Stock],0) <> 0) AND (A.[ProCat] = @Category OR N'' = @Category OR N'All Categories' = @Category)  
                        {4}AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryTakeOrder_SetSupplier] GROUP BY [SupNum])
                        {3} AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [Stock].[dbo].[TPRDeliveryDutchmill])
                        GROUP BY ISNULL([B].[OldProNumy],''),ISNULL([ProName],''),ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],''),[Sup1]
                    )
                    SELECT [Barcode],[ProName],[Display]
                    FROM sItems
                    WHERE ((LEFT([Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
                    GROUP BY [Barcode],[ProName],[Display]
                    ORDER BY [ProName];
";
                this.query = string.Format(this.query, DatabaseName, CusNum, Category, IsDutchmill ? "" : "--", Initialized.vIsNestleOnly && !this.chkallitems.Checked ? "" : "--");
            }
            else
            {
                string SelectedBarcode = "";
                if (this.DeliveryTakeOrderList != null)
                {
                    var barcodeSelected = (from DataRow row in this.DeliveryTakeOrderList.Rows
                                           where Convert.ToDecimal(DBNull.Value.Equals(row["PcsFree"]) ? 0 : row["PcsFree"]) == 0
                                           select row["Barcode"].ToString()).Distinct().ToArray();
                    SelectedBarcode = $"N'{string.Join("',N'", barcodeSelected)}'";
                }

                if (string.IsNullOrWhiteSpace(SelectedBarcode))
                {
                    SelectedBarcode = "''";
                }

                bool vismixed_ = false;
                this.query = @"
DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
DECLARE @DeltoId_ AS DECIMAL(18,0) = {5};
DECLARE @vteam_ AS INT = {4};

SELECT *
INTO #team_
FROM DBUNTWHOLESALECOLTD.dbo.TblSetSaleManagerToSupplier s;

UPDATE x
SET [x].[TeamName] = N'Alpha',
    [x].[TeamID] = 1,
    [x].[SaleManagerID] = 1
FROM #team_ x
WHERE ([x].[TeamName] NOT IN ( N'Charlie', N'Delta' ));

UPDATE x
SET [x].[TeamName] = N'Charlie + Delta',
    [x].[TeamID] = 2,
    [x].[SaleManagerID] = 2
FROM #team_ x
WHERE ([x].[TeamName] IN ( N'Charlie', N'Delta' ));

WITH vItem
AS (SELECT [x].[ProNumY] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYP], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYC], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumY] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYP], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYC], N'') <> N'')
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          ))
SELECT [x].*
INTO #lst_items
FROM vItem x;

SELECT [x].[Barcode]
FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
    INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
        ON ([v].[Id] = [x].[POId])
WHERE ([v].[OrderDate] IS NOT NULL)
      AND ([v].[DeliveryDate] IS NOT NULL)
      AND ([v].[CusNum] = @CusNum)
      AND ([v].[DeltoId] = @DeltoId_)
      AND ([x].[Barcode] NOT IN
           (
               SELECT [Barcode] FROM #lst_items GROUP BY [Barcode]
           )
          )
GROUP BY [x].[Barcode];

DROP TABLE #team_;
DROP TABLE #lst_items;
";
                this.query = string.Format(this.query, DatabaseName, CusNum, Category, SelectedBarcode, AppSetting.SaleManagerID, deltoid_);
                var lst_ = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
                if (lst_ != null && lst_.Rows.Count > 0)
                {
                    vismixed_ = true;
                }

                this.query = @"
DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
DECLARE @DeltoId_ AS DECIMAL(18,0) = {5};
DECLARE @Category AS NVARCHAR(100) = N'{2}';
DECLARE @vteam_ AS INT = {4};

SELECT *
INTO #team_
FROM DBUNTWHOLESALECOLTD.dbo.TblSetSaleManagerToSupplier s;

UPDATE x
SET [x].[TeamName] = N'Alpha',
    [x].[TeamID] = 1,
    [x].[SaleManagerID] = 1
FROM #team_ x
WHERE ([x].[TeamName] NOT IN ( N'Charlie', N'Delta' ));

UPDATE x
SET [x].[TeamName] = N'Charlie + Delta',
    [x].[TeamID] = 2,
    [x].[SaleManagerID] = 2
FROM #team_ x
WHERE ([x].[TeamName] IN ( N'Charlie', N'Delta' ));

WITH vItem
AS (SELECT [x].[ProNumY] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          ) AND ((LEFT([x].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYP], N'') <> N'')
          AND ((LEFT([x].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYC], N'') <> N'')
          AND ((LEFT([x].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    UNION ALL
    SELECT [x].[ProNumY] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          ) AND ((LEFT([x].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYP], N'') <> N'')
          AND ((LEFT([x].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          )
          AND (COALESCE([x].[ProNumYC], N'') <> N'')
          AND ((LEFT([x].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode]
    FROM [Stock].[dbo].[TPRProducts] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          ) AND ((LEFT([x].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8)IN
          (
              SELECT [SupNum]
              FROM #team_
              WHERE ([SaleManagerID] = @vteam_)
              GROUP BY [SupNum]
          ) AND ((LEFT([x].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
)
SELECT [x].*
INTO #lst_items
FROM vItem x;

WITH vItem
AS (SELECT ISNULL([ProNumY], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumY], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE (
              [ProCat] = @Category
              OR N'' = @Category
              OR N'All Categories' = @Category
          )
          AND [ProNumY] IN
              (
                  SELECT [x].[Barcode]
                  FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                      INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                          ON ([v].[Id] = [x].[POId])
                  WHERE ([v].[OrderDate] IS NOT NULL)
                        AND ([v].[DeliveryDate] IS NOT NULL)
                        AND ([v].[CusNum] = @CusNum)
                        AND ([v].[DeltoId] = @DeltoId_)
                  GROUP BY [x].[Barcode]
              )
        AND ((LEFT([Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    GROUP BY ISNULL([ProNumY], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumY], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([ProNumYP], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumYP], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE ISNULL([ProNumYP], '') <> ''
          AND
          (
              [ProCat] = @Category
              OR N'' = @Category
              OR N'All Categories' = @Category
          )
          AND [ProNumYP] IN
              (
                  SELECT [x].[Barcode]
                  FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                      INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                          ON ([v].[Id] = [x].[POId])
                  WHERE ([v].[OrderDate] IS NOT NULL)
                        AND ([v].[DeliveryDate] IS NOT NULL)
                        AND ([v].[CusNum] = @CusNum)
                        AND ([v].[DeltoId] = @DeltoId_)
                  GROUP BY [x].[Barcode]
              )
        AND ((LEFT([Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    GROUP BY ISNULL([ProNumYP], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumYP], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([ProNumYC], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumYC], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE ISNULL([ProNumYC], '') <> ''
          AND
          (
              [ProCat] = @Category
              OR N'' = @Category
              OR N'All Categories' = @Category
          )
          AND [ProNumYC] IN
              (
                  SELECT [x].[Barcode]
                  FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                      INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                          ON ([v].[Id] = [x].[POId])
                  WHERE ([v].[OrderDate] IS NOT NULL)
                        AND ([v].[DeliveryDate] IS NOT NULL)
                        AND ([v].[CusNum] = @CusNum)
                        AND ([v].[DeltoId] = @DeltoId_)
                  GROUP BY [x].[Barcode]
              )
        AND ((LEFT([Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    GROUP BY ISNULL([ProNumYC], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumYC], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([ProNumY], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumY], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE (ISNULL([ProTotQty], 0) <> 0)
          AND
          (
              [ProCat] = @Category
              OR N'' = @Category
              OR N'All Categories' = @Category
          )
          AND [ProNumY] IN
              (
                  SELECT [x].[Barcode]
                  FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                      INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                          ON ([v].[Id] = [x].[POId])
                  WHERE ([v].[OrderDate] IS NOT NULL)
                        AND ([v].[DeliveryDate] IS NOT NULL)
                        AND ([v].[CusNum] = @CusNum)
                        AND ([v].[DeltoId] = @DeltoId_)
                  GROUP BY [x].[Barcode]
              )
        AND ((LEFT([Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    GROUP BY ISNULL([ProNumY], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumY], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([ProNumYP], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumYP], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE (ISNULL([ProTotQty], 0) <> 0)
          AND ISNULL([ProNumYP], '') <> ''
          AND
          (
              [ProCat] = @Category
              OR N'' = @Category
              OR N'All Categories' = @Category
          )
          AND [ProNumYP] IN
              (
                  SELECT [x].[Barcode]
                  FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                      INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                          ON ([v].[Id] = [x].[POId])
                  WHERE ([v].[OrderDate] IS NOT NULL)
                        AND ([v].[DeliveryDate] IS NOT NULL)
                        AND ([v].[CusNum] = @CusNum)
                        AND ([v].[DeltoId] = @DeltoId_)
                  GROUP BY [x].[Barcode]
              )
        AND ((LEFT([Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    GROUP BY ISNULL([ProNumYP], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumYP], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([ProNumYC], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumYC], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE (ISNULL([ProTotQty], 0) <> 0)
          AND ISNULL([ProNumYC], '') <> ''
          AND
          (
              [ProCat] = @Category
              OR N'' = @Category
              OR N'All Categories' = @Category
          )
          AND [ProNumYC] IN
              (
                  SELECT [x].[Barcode]
                  FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                      INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                          ON ([v].[Id] = [x].[POId])
                  WHERE ([v].[OrderDate] IS NOT NULL)
                        AND ([v].[DeliveryDate] IS NOT NULL)
                        AND ([v].[CusNum] = @CusNum)
                        AND ([v].[DeltoId] = @DeltoId_)
                  GROUP BY [x].[Barcode]
              )
        AND ((LEFT([Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    GROUP BY ISNULL([ProNumYC], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumYC], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([B].[OldProNumy], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([B].[OldProNumy], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProducts] AS A
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B
            ON A.[ProID] = B.[ProId]
    WHERE (
              A.[ProCat] = @Category
              OR N'' = @Category
              OR N'All Categories' = @Category
          )
          AND [B].[OldProNumy] IN
              (
                  SELECT [x].[Barcode]
                  FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                      INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                          ON ([v].[Id] = [x].[POId])
                  WHERE ([v].[OrderDate] IS NOT NULL)
                        AND ([v].[DeliveryDate] IS NOT NULL)
                        AND ([v].[CusNum] = @CusNum)
                        AND ([v].[DeltoId] = @DeltoId_)
                  GROUP BY [x].[Barcode]
              )
        AND ((LEFT([A].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    GROUP BY ISNULL([B].[OldProNumy], ''),
             ISNULL([ProName], ''),
             ISNULL([B].[OldProNumy], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([B].[OldProNumy], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([B].[OldProNumy], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B
            ON A.[ProID] = B.[ProId]
    WHERE (ISNULL(B.[Stock], 0) <> 0)
          AND
          (
              A.[ProCat] = @Category
              OR N'' = @Category
              OR N'All Categories' = @Category
          )
          AND [B].[OldProNumy] IN
              (
                  SELECT [x].[Barcode]
                  FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                      INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                          ON ([v].[Id] = [x].[POId])
                  WHERE ([v].[OrderDate] IS NOT NULL)
                        AND ([v].[DeliveryDate] IS NOT NULL)
                        AND ([v].[CusNum] = @CusNum)
                        AND ([v].[DeltoId] = @DeltoId_)
                  GROUP BY [x].[Barcode]
              )
        AND ((LEFT([A].[Sup1],8) IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])) OR (N'SUP00000' IN (SELECT [supnum] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer-Exclusive-Brand] WHERE ([cusnum] = @CusNum) GROUP BY [supnum])))
    GROUP BY ISNULL([B].[OldProNumy], ''),
             ISNULL([ProName], ''),
             ISNULL([B].[OldProNumy], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], ''))
SELECT [x].[Barcode],
       [x].[ProName],
       [x].[Display]
FROM vItem x
WHERE [x].[Barcode] NOT IN ( {3} )
{6}AND ([x].[Barcode] IN
{6}                          (
{6}                              SELECT [Barcode] FROM #lst_items GROUP BY [Barcode]
{6}                          )
{6}                         )
GROUP BY [x].[Barcode],
         [x].[ProName],
         [x].[Display]
ORDER BY [x].[ProName];

DROP TABLE #team_;
DROP TABLE #lst_items;
";
                this.query = string.Format(this.query, DatabaseName, CusNum, Category, SelectedBarcode, AppSetting.SaleManagerID, deltoid_, vismixed_ ? "" : "");
            }

            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            DataSources(this.CmbProducts, this.lists, "Display", "Barcode");
            this.Cursor = Cursors.Default;
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CmbBillTo.Text)) return;
            TimerProductLoading.Enabled = true;
        }

        private void CmbProducts_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                CmbProducts.SelectedText = "";
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                CmbProducts.Text = Clipboard.GetText();
                CmbProducts.SelectionStart = CmbProducts.Text.Length;
                CmbProducts.Focus();
            }
            if (e.KeyCode == Keys.Return)
            {
                if (!string.IsNullOrWhiteSpace(CmbProducts.Text))
                {
                    ProductSearch(CmbProducts);
                }
            }
        }
        private void ProductSearch(System.Windows.Forms.ComboBox ComboName)
        {
            if (CmbProducts.Items.Count <= 0) return;
            string RBarcode = ComboName.Text.Trim();
            if (RBarcode.Length > 13) RBarcode = RBarcode.Substring(0, 15).Trim();
            if (IsNumeric(RBarcode.Trim())) RBarcode = string.Format("{0:0000000000000}", Convert.ToDecimal(RBarcode));
            DataTable TableProducts = (DataTable)ComboName.DataSource;
            for (int i = 0; i < TableProducts.Rows.Count; i++)
            {
                string displayItem = TableProducts.Rows[i][ComboName.DisplayMember].ToString();
                string valueItem = TableProducts.Rows[i][ComboName.ValueMember].ToString();
                valueItem = valueItem.Substring(0, RBarcode.Length).Trim();
                if (valueItem.Equals(RBarcode))
                {
                    ComboName.SelectedIndex = i;
                    break;
                }
            }
            TxtCTNOrder.Focus();
        }

        private void CmbProducts_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)Keys.Back) return;

            if ((e.KeyChar >= (char)Keys.A && e.KeyChar <= (char)Keys.Z) ||
                (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                e.KeyChar == (char)Keys.Return ||
                e.KeyChar == (char)Keys.Back)
            {
                if (!string.IsNullOrWhiteSpace(CmbProducts.Text) && !IsNumeric(CmbProducts.Text.Trim()))
                {
                    e.Handled = true;
                }
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else
            {
                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 15);
            }
        }
        private void ClearProductItems()
        {
            this.currency = "";
            this.rSupNum = "";
            this.rSupName = "";
            this.rate = 0;
            this.buyin = 0;
            this.buyDis = 0;
            this.buyVAT = 0;
            this.totalBuyin = 0;
            this.average = 0;
            this.wsAfter = 0;
            this.lExciseTaxPercent = 0;
            this.lPublicLightingTaxPercent = 0;
            this.BtnAdd.Enabled = true;
            this.PicProducts.Image = null;
            this.App.ClearController(TxtQtyPerCase, TxtStock, TxtWSPrice, TxtBarcodeFree, TxtPcsFree, TxtItemDiscount, TxtPcsOrder, TxtPackOrder, TxtCTNOrder, TxtTotalPcsOrder, TxtUnitPrice, TxtPackPrice, TxtTotalAmount, TxtRemark, txtStockWarehouse, txtCustomerCode);
            this.App.SetReadOnlyController(false, TxtPackOrder);
            this.App.SetReadOnlyController(false, TxtPackOrder);

        }


        private void CmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ClearProductItems();
            if (string.IsNullOrWhiteSpace(this.CmbProducts.Text)) return;
            if (this.CmbProducts.SelectedValue is DataRowView || this.CmbProducts.SelectedValue == null) return;
            if (this.rdbcostlowecommerence.Checked)
            {
                // Do nothing
            }
            else
            {
                this.TimerCheckPromotion.Enabled = true;
            }
            this.TimerChecking.Enabled = true;
        }
        private bool CheckNewCodeForCustomer()
        {
            bool IsNewCode = false;
            string query = @"
DECLARE @Barcode AS NVARCHAR(MAX) = '{1}';
DECLARE @CusNum AS NVARCHAR(8) = '{2}';
SELECT [Id], [OldProNumy], [ProName], [ProPackSize], [NewProNumy], [Delto], [Telephone], [CusNum]
FROM [Stock].[dbo].[TPRProductNewCodeAlert]
WHERE ([OldProNumy] = @Barcode OR [NewProNumy] = @Barcode) AND [CusNum] = @CusNum;
";
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue, CmbBillTo.SelectedValue);
            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                IsNewCode = true;
            }
            return IsNewCode;
        }
        private DataTable QueryCCEmail()
        {
            bool IsDeactivated = false;
            string query = @"
SELECT Email
FROM dbo.TblEmailCCProductDC;
";

            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            return lists;
        }
        private DataTable CheckDeactivatedItem()
        {
            bool IsDeactivated = false;
            string query = @"
DECLARE @Barcode AS NVARCHAR(MAX) = '{1}';
SELECT * 
FROM [Stock].[dbo].[TPRProductsDeactivated] 
WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode);
";
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            return lists;
        }
        private DataTable CheckCustomerEmail()
        {
            bool IsDeactivated = false;
            string query = @"
SELECT ISNULL(CusEmail, '') AS Email
FROM Stock.dbo.TPRCustomer
WHERE CusNum = '{0}';
";
            query = string.Format(query, CmbBillTo.SelectedValue);
            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            return lists;
        }
        private bool CheckOldItem()
        {
            bool IsOldItem = false;
            string NewBarcode = "";
            decimal ProId = 0;
            decimal _Stock = 0;
            string query = @"
DECLARE @Barcode AS NVARCHAR(MAX) = '{1}';
SELECT [Id], [ProId], [OldProNumy], [Stock]
FROM [Stock].[dbo].[TPRProductsOldCode]
WHERE [OldProNumy] = @Barcode;
";
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                ProId = lists.Rows[0]["ProId"] == DBNull.Value ? 0 : Convert.ToDecimal(lists.Rows[0]["ProId"]);
                _Stock = lists.Rows[0]["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(lists.Rows[0]["Stock"]);
                query = @"
DECLARE @ProId AS DECIMAL(18,0) = {1};
SELECT [ProNumY]
FROM (
    SELECT [ProNumY]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE [ProID] = @ProId
    UNION ALL
    SELECT [ProNumY]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE [ProID] = @ProId
) lists;
";
                query = string.Format(query, DatabaseName, ProId);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null && lists.Rows.Count > 0)
                {
                    NewBarcode = lists.Rows[0]["ProNumY"] == DBNull.Value ? "" : lists.Rows[0]["ProNumY"].ToString().Trim();
                    if (MessageBox.Show(string.Format("This item is old code <{0}>, Stock have {2:#,###,##0;(#,###,##0)} pcs.\nDo you want to change the old code <{0}> to new code <{1}>?(Yes/No)", CmbProducts.SelectedValue, NewBarcode, _Stock), "Confirm Change Old Code", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        IsOldItem = false;
                    }
                    else
                    {
                        CmbProducts.SelectedValue = NewBarcode;
                        IsOldItem = true;
                    }
                }
            }
            return IsOldItem;
        }
        private void TotalPcsOrder()
        {
            int PcsOrder = Convert.ToInt32(string.IsNullOrWhiteSpace(TxtPcsOrder.Text.Trim()) ? "0" : TxtPcsOrder.Text.Trim());
            int PackOrder = Convert.ToInt32(string.IsNullOrWhiteSpace(TxtPackOrder.Text.Trim()) ? "0" : TxtPackOrder.Text.Trim());
            float CTNOrder = Convert.ToSingle(string.IsNullOrWhiteSpace(TxtCTNOrder.Text.Trim()) ? "0" : TxtCTNOrder.Text.Trim());
            int QtyPerCase = Convert.ToInt32(string.IsNullOrWhiteSpace(TxtQtyPerCase.Text.Trim()) ? "1" : TxtQtyPerCase.Text.Trim());
            float TotalPcsOrder = ((CTNOrder * QtyPerCase) + (PackOrder * QtyPerPack) + PcsOrder);
            this.TxtTotalPcsOrder.Text = string.Format("{0:N0}", TotalPcsOrder);
        }
        private void TotalAmount()
        {
            decimal lDigited = this.GetDigitsValue(vDigit);
            double lUnitPrice2 = string.IsNullOrWhiteSpace(this.TxtUnitPrice.Text) ? 0 : Convert.ToDouble(this.TxtUnitPrice.Text.Trim());
            double lPackPrice2 = string.IsNullOrWhiteSpace(this.TxtPackPrice.Text) ? 0 : Convert.ToDouble(this.TxtPackPrice.Text.Trim());
            double lCasePrice2 = string.IsNullOrWhiteSpace(this.TxtWSPrice.Text) ? 0 : Convert.ToDouble(this.TxtWSPrice.Text.Trim());
            float lItemDis = string.IsNullOrWhiteSpace(this.TxtItemDiscount.Text) ? 0 : Convert.ToSingle(this.TxtItemDiscount.Text.Trim());
            lItemDis = Math.Abs((100 - lItemDis) / 100);
            decimal lPcsOrder = string.IsNullOrWhiteSpace(this.TxtPcsOrder.Text) ? 0 : Convert.ToInt32(this.TxtPcsOrder.Text.Trim());
            decimal lPackOrder = string.IsNullOrWhiteSpace(this.TxtPackOrder.Text) ? 0 : Convert.ToInt32(this.TxtPackOrder.Text.Trim());
            float lCTNOrder = string.IsNullOrWhiteSpace(this.TxtCTNOrder.Text) ? 0 : Convert.ToSingle(this.TxtCTNOrder.Text.Trim());
            decimal lQtyPerCase = string.IsNullOrWhiteSpace(this.TxtQtyPerCase.Text) ? 1 : Convert.ToInt32(this.TxtQtyPerCase.Text.Trim());
            if (this.QtyPerPack == 0) this.QtyPerPack = 1;
            int lTotalPcsOrder = (int)(((int)lCTNOrder * lQtyPerCase) + (lPackOrder * this.QtyPerPack) + (int)lPcsOrder);
            double lTotalAmount = 0;

            if (this.lIsServiceRebateAllItems && !oIsFixedPrice)
            {
                lTotalAmount = ((int)(lTotalPcsOrder / lQtyPerCase) * lCasePrice2 * lItemDis);
            }
            else if (this.rdbcostlowecommerence.Checked)
            {
                lTotalAmount = ((((int)lPcsOrder) * this.lUnitPrice) + ((int)(lPackOrder) * this.lPackPrice) + (lCTNOrder * this.lCasePrice) * lItemDis);
            }
            else
            {
                if (lQtyPerCase == 1)
                {
                    lTotalAmount = ((lTotalPcsOrder * lCasePrice2) * lItemDis);
                }
                else
                {
                    if (oIsFixedPrice)
                    {
                        if (vIssueUnitPrice && vIsFormatUnitPrice)
                        {
                            lTotalAmount = ((lTotalPcsOrder * lUnitPrice2) * lItemDis);
                        }
                        else
                        {
                            if (vIssuePackPrice)
                            {
                                lTotalAmount = ((((int)(lPcsOrder) * lUnitPrice2)) + ((int)(lPackOrder) * lPackPrice2)) + ((lCTNOrder * lCasePrice2) * lItemDis);
                            }
                            else
                            {
                                lTotalAmount = (((int)(lTotalPcsOrder / lQtyPerCase) * lCasePrice2) * lItemDis);
                            }
                        }
                    }
                    else
                    {
                        if (vIssueUnitPrice || vIsFormatUnitPrice)
                        {
                            if (vIssuePackPrice)
                            {
                                lTotalAmount = ((((int)lPcsOrder * lUnitPrice2) + ((int)lPackOrder * lPackPrice2) + (lCTNOrder * lCasePrice2)) * lItemDis);
                            }
                            else
                            {
                                lTotalAmount = ((lTotalPcsOrder * lUnitPrice2) * lItemDis);
                            }
                        }
                        else
                        {
                            lTotalAmount = (((int)(lTotalPcsOrder / lQtyPerCase) * lCasePrice2) * lItemDis);
                        }
                    }
                }
            }
            this.TxtTotalAmount.Text = string.Format("{0:N2}", lTotalAmount);
            this.IsCheckPromotion = false;
            if (this.rdbcostlowecommerence.Checked)
            {
                // Do nothing
            }
            else
            {
                this.TimerCheckPromotion.Enabled = true;
            }
        }
        private void refreshonlinepo_Tick(object sender, EventArgs e)
        {

            // 300000 (5 minutes)
            this.refreshonlinepo.Interval = 300000;
            this.qty_online_po = 0;
            DataTable vlst_ = null;
            string vsql_ = @"
SELECT COUNT(*) [num_]
FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
WHERE ([v].[OrderDate] IS NOT NULL)
      AND ([v].[DeliveryDate] IS NOT NULL);
";

            vsql_ = @"
DECLARE @vteam_ AS INT = {1};

SELECT *
INTO #team_
FROM DBUNTWHOLESALECOLTD.dbo.TblSetSaleManagerToSupplier s;

UPDATE x
SET [x].[TeamName] = N'Alpha',
    [x].[TeamID] = 1,
    [x].[SaleManagerID] = 1
FROM #team_ x
WHERE ([x].[TeamName] NOT IN ( N'Charlie', N'Delta' ));

UPDATE x
SET [x].[TeamName] = N'Charlie + Delta',
    [x].[TeamID] = 2,
    [x].[SaleManagerID] = 2
FROM #team_ x
WHERE ([x].[TeamName] IN ( N'Charlie', N'Delta' ));

WITH vItem AS (
    SELECT [x].[ProNumY] [Barcode] 
    FROM [Stock].[dbo].[TPRProducts] x 
    WHERE LEFT([x].[Sup1], 8) IN (
        SELECT [SupNum] 
        FROM #team_ 
        WHERE ([SaleManagerID] = @vteam_) 
        GROUP BY [SupNum]
    )
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode] 
    FROM [Stock].[dbo].[TPRProducts] x 
    WHERE LEFT([x].[Sup1], 8) IN (
        SELECT [SupNum] 
        FROM #team_ 
        WHERE ([SaleManagerID] = @vteam_) 
        GROUP BY [SupNum]
    ) AND (COALESCE([x].[ProNumYP], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode] 
    FROM [Stock].[dbo].[TPRProducts] x 
    WHERE LEFT([x].[Sup1], 8) IN (
        SELECT [SupNum] 
        FROM #team_ 
        WHERE ([SaleManagerID] = @vteam_) 
        GROUP BY [SupNum]
    ) AND (COALESCE([x].[ProNumYC], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumY] [Barcode] 
    FROM [Stock].[dbo].[TPRProductsDeactivated] x 
    WHERE LEFT([x].[Sup1], 8) IN (
        SELECT [SupNum] 
        FROM #team_ 
        WHERE ([SaleManagerID] = @vteam_) 
        GROUP BY [SupNum]
    )
    UNION ALL
    SELECT [x].[ProNumYP] [Barcode] 
    FROM [Stock].[dbo].[TPRProductsDeactivated] x 
    WHERE LEFT([x].[Sup1], 8) IN (
        SELECT [SupNum] 
        FROM #team_ 
        WHERE ([SaleManagerID] = @vteam_) 
        GROUP BY [SupNum]
    ) AND (COALESCE([x].[ProNumYP], N'') <> N'')
    UNION ALL
    SELECT [x].[ProNumYC] [Barcode] 
    FROM [Stock].[dbo].[TPRProductsDeactivated] x 
    WHERE LEFT([x].[Sup1], 8) IN (
        SELECT [SupNum] 
        FROM #team_ 
        WHERE ([SaleManagerID] = @vteam_) 
        GROUP BY [SupNum]
    ) AND (COALESCE([x].[ProNumYC], N'') <> N'')
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode] 
    FROM [Stock].[dbo].[TPRProducts] x 
    INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v 
    ON ([v].[ProId] = [x].[ProID]) 
    WHERE LEFT([x].[Sup1], 8) IN (
        SELECT [SupNum] 
        FROM #team_ 
        WHERE ([SaleManagerID] = @vteam_) 
        GROUP BY [SupNum]
    )
    UNION ALL
    SELECT [v].[OldProNumy] [Barcode] 
    FROM [Stock].[dbo].[TPRProductsDeactivated] x 
    INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v 
    ON ([v].[ProId] = [x].[ProID])
    WHERE LEFT([x].[Sup1], 8) IN (
        SELECT [SupNum] 
        FROM #team_ 
        WHERE ([SaleManagerID] = @vteam_) 
        GROUP BY [SupNum]
    )
)
SELECT [x].*
INTO #lst_items
FROM vItem x;

SELECT COUNT(DISTINCT [v].[Id]) [num_]
FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v 
INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] o 
ON ([v].[Id] = [o].[POId])
WHERE ([v].[OrderDate] IS NOT NULL) 
AND ([v].[DeliveryDate] IS NOT NULL) 
AND ([o].[Barcode] IN (
    SELECT [Barcode] 
    FROM #lst_items 
    GROUP BY [Barcode]
));

DROP TABLE #team_;
DROP TABLE #lst_items;
";
            vsql_ = string.Format(vsql_, DatabaseName, AppSetting.SaleManagerID);
            vlst_ = Data.Selects(vsql_, Initialized.GetConnectionType(Data, App));
            if (vlst_ != null && vlst_.Rows.Count > 0)
            {
                qty_online_po = Convert.ToDecimal(DBNull.Value.Equals(vlst_.Rows[0]["num_"]) ? 0 : vlst_.Rows[0]["num_"]);
                if (qty_online_po == 0)
                {
                    goto err_blank;
                }
                else
                {
                    this.lblalarm.Text = qty_online_po.ToString();
                    this.lblalarm.Visible = true;
                    this.randomcolor.Enabled = true;
                }
            }
            else
            {
                goto err_blank;
            }
            return;

        err_blank:
            this.lblalarm.Text = "";
            this.lblalarm.Visible = false;
            this.randomcolor.Enabled = false;
        }

        private void randomcolor_Tick(object sender, EventArgs e)
        {
            this.lblalarm.ForeColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));

        }

        private void lblWarehouseName_Click(object sender, EventArgs e)
        {

        }

        //private void warehouseNameColor_Tick(object sender, EventArgs e)
        //{
        //    this.lblWarehouseName.ForeColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));

        //}

        private void RdbManually_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbManually.Checked)
            {
                this.sFirstLoading = true;
                this.lblMsg.Text = this.RdbManually.Text.Trim().ToUpper();
                this.TimerCustomerLoading.Enabled = true;
            }
        }

        private double vServiceCost { get; set; }
        private float CusItemDis { get; set; }
        private float CusInvoiceDis { get; set; }
        private string CusVAT { get; set; }
        private float CusServiceRebate { get; set; }
        private int Terms { get; set; }
        private double CreditLimit { get; set; }
        private int MaxMonthAllow { get; set; }
        private double CreditLimitAllow { get; set; }
        private int vDigit { get; set; }
        private bool sFirstLoading { get; set; }
        private bool vIsCustomerNoVATTinIntoDivisionVAT { get; set; }
        private bool lIsServiceRebateAllItems { get; set; }
        private double lUnitPrice { get; set; }
        private double lPackPrice { get; set; }
        private double lCasePrice { get; set; }

        private string currency;
        private float rate;
        private double buyin;
        private float buyDis;
        private float buyVAT;
        private double totalBuyin;
        private double average;
        private string rSupNum;
        private string rSupName;
        private int QtyPerPack;
        private double wsAfter;
        private string vCity;
        private bool vIssueUnitPrice;
        private bool vIssuePackPrice;
        private bool vIssueCasePrice;
        private bool vIsFormatUnitPrice;

        private bool vAdditionalCost;
        private int oFixedPriceQtyInvoicing;
        private bool oIsFixedPrice;

        public float lExciseTaxPercent { get; set; }
        public float lPublicLightingTaxPercent { get; set; }
        FrmAlertCreditAmount frmAlertCreditAmount = new FrmAlertCreditAmount();
        FrmAlertBankGarantee frmAlertBankGarantee = new FrmAlertBankGarantee();
        private void CmbBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.PCustomerRemark.Visible = false;
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.DTPRequiredDate.Value = DateTime.ParseExact(Todate.ToString("dd-MMM-yyyy"), "dd-MMM-yyyy", null);
            this.DTPDeliverDate.Value = Todate;
            this.vServiceCost = 0;
            this.CusItemDis = 0;
            this.CusInvoiceDis = 0;
            this.CusServiceRebate = 0;
            this.Terms = 0;
            this.CreditLimit = 0;
            this.MaxMonthAllow = 0;
            this.CreditLimitAllow = 0;
            this.lIsServiceRebateAllItems = false;
            this.CusVAT = "";
            this.vCity = "";
            this.vIssueUnitPrice = false;
            this.vIssuePackPrice = false;
            this.vIssueCasePrice = false;
            this.vIsFormatUnitPrice = false;
            this.vAdditionalCost = false;
            this.vIsCustomerNoVATTinIntoDivisionVAT = false;
            this.vDigit = 2;
            this.PicProducts.Image = null;
            this.lUnitPrice = 0;
            this.lPackPrice = 0;
            this.lCasePrice = 0;
            App.SetEnableController(true, BtnAdd, CmbProducts, CmbDelto, CmbCategory);
            App.ClearController(txtCustomerCode, txtStockWarehouse, TxtIdDelto, CmbDelto, TxtZone, TxtKhmerName, TxtNote, txtpromotionid, CmbProducts, TxtQtyPerCase, TxtStock, TxtBarcodeFree, TxtPcsOrder, TxtPackOrder, TxtCTNOrder, TxtTotalPcsOrder, TxtUnitPrice, TxtPcsFree, TxtItemDiscount, TxtWSPrice, TxtTotalAmount, TxtRequiredDate);
            this.chknone.Checked = false;

            if (this.CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
                return;
            if (string.IsNullOrWhiteSpace(this.CmbBillTo.Text))
                return;
            if (this.sFirstLoading)
            {
                this.sFirstLoading = false;
                return;
            }
            frmAlertCreditAmount = new FrmAlertCreditAmount();
            frmAlertCreditAmount.Close();
            frmAlertBankGarantee = new FrmAlertBankGarantee();
            frmAlertBankGarantee.Close();
            string CusNum = "";
            if (this.CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.CmbBillTo.Text))
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = this.CmbBillTo.SelectedValue.ToString();
                }
            }
            if (string.IsNullOrWhiteSpace(CusNum))
                return;
            this.TxtCusNumSearch.Text = decimal.Parse(CusNum.Replace("CUS", "").Replace("CEC", "").Trim()).ToString();
            string sql = $@"DECLARE @cusNum AS NVARCHAR(10) = N'{CusNum}';
SELECT lh.*,
       [lm].[description] [agreementMethod]
FROM [Stock].[dbo].[TPRCustomer] lh
    INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[tblCustomerMethodAgreement] lm
        ON ([lh].[agreementMethodId] = [lm].[id])
WHERE ([lh].[CusNum] = @cusNum);";
            DataTable tbl = Data.Selects(sql, Initialized.GetConnectionType(Data, App));
            if (tbl != null)
            {
                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];
                    string agreementMethod = DBNull.Value.Equals(row["agreementMethod"]) ? "" : row["agreementMethod"].ToString().Trim();
                    if (agreementMethod.ToLower().Trim().Equals("need to set"))
                    {
                        this.Cursor = Cursors.Default;
                        XtraMessageBox.Show("This customer missing set agreement, please ask Admin manager to update agreement!", "Not Allow To Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }




            // LOCK INVOICING FOR DOCUMENT AR IN
            string lSql = @"
DECLARE @lCusNum AS NVARCHAR(8) = N'{1}';
WITH lDocumentARIn
AS (SELECT [ll].[allowedday],
           DATEDIFF(DAY, [lx].[ReceiptDate], GETDATE()) [overday],
           [lx].[Id],
           [lx].[CusNum],
           [lx].[CusName],
           [lx].[DeltoId],
           [lx].[Delto],
           [lx].[InvNumber],
           [lx].[DateShip],
           [lx].[DeliveryDate],
           [lx].[SubTotal],
           [lx].[Dis],
           [lx].[Ser],
           [lx].[Total],
           [lx].[Vat],
           [lx].[GrandTotal],
           [lx].[ReceiptNo],
           [lx].[ReceiptDate],
           [lx].[Department]
    FROM [Stock].[dbo].[TPRTruckLoadingHistory] lx
        INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblUnlockInvoicingForDeliveryARIN] ll
            ON ([ll].[CusNum] = [lx].[CusNum])
               AND ([ll].[allowedday] <= DATEDIFF(DAY, [lx].[ReceiptDate], GETDATE()))
    WHERE (([lx].[CusNum] = @lCusNum)))
SELECT [lx].[allowedday],
       [lx].[overday],
       [lx].[Id],
       [lx].[CusNum],
       [lx].[CusName],
       [lx].[DeltoId],
       [lx].[Delto],
       [lx].[InvNumber],
       [lx].[DateShip],
       [lx].[DeliveryDate],
       [lx].[SubTotal],
       [lx].[Dis],
       [lx].[Ser],
       [lx].[Total],
       [lx].[Vat],
       [lx].[GrandTotal],
       [lx].[ReceiptNo],
       [lx].[ReceiptDate],
       [lx].[Department]
FROM lDocumentARIn lx
ORDER BY [lx].[overday];
";
            lSql = string.Format(lSql, DatabaseName, CusNum);
            var lTbl = Data.Selects(lSql, Initialized.GetConnectionType(Data, App));
            if (lTbl != null && lTbl.Rows.Count > 0)
            {
                var lDocument = new FrmLockInvoicingDocumentARIN { WindowState = FormWindowState.Normal };
                lDocument.DgvShow.DataSource = lTbl;
                lDocument.DgvShow.Refresh();
                lDocument.ShowDialog(mdi_);
                return;
            }

            // Check pending stock SD
            if (!this.warehouseName.allowManuallyPromotion)
            {
                if (this.lstsd_ != null)
                {
                    this.lstsd_ = this.lstsd_.Where(lls => lls.cusNum != null).ToList();
                    if (this.lstsd_.Count > 0)
                    {
                        string sdId_ = (from x in this.lstsd_
                                        where x.cusNum.Trim().Equals(CusNum)
                                        select x.id).FirstOrDefault();
                        this.loginToken();
                        string slink_ = string.Format("{0}{1}", Initialized.url_, string.Format(checkallowance_, sdId_));
                        this.lstcheckallowance_ = app_.GetFirstOrDefault<AllowanceModel>(slink_);
                        if (this.lstcheckallowance_ != null)
                        {
                            if (this.lstcheckallowance_.invoices > 0)
                            {
                                App.SetEnableController(false, BtnAdd, CmbProducts, CmbDelto, CmbCategory);
                                XtraMessageBox.Show("Please ask Sub Distributor to update arrival, thank you!", "Not Allow To Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
            }


            DataTable oList;
            // Customer No VATTIn Into Division VAT
            this.query = @"
DECLARE @oCusNum AS NVARCHAR(8) = N'{1}';
SELECT [Id],
       [CusNum],
       [CusName],
       [IsExcludeVAT],
       [RoundUp],
       [CreatedDate]
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblSetCustomerIntoDivisionVAT]
WHERE ([CusNum] = @oCusNum);
";
            this.query = string.Format(this.query, DatabaseName, CusNum);
            oList = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            if (oList != null && oList.Rows.Count > 0)
            {
                this.vIsCustomerNoVATTinIntoDivisionVAT = true;
            }

            // Check Service Rebate
            this.query = @"
DECLARE @lCusNum AS NVARCHAR(8) = N'{1}';
SELECT [l].[allitems],
       [l].[onwsprice],
       [l].[onbuyinprice]
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomer.ServiceRateOnPrice] l
WHERE ([l].[cusnum] = @lCusNum);
";
            this.query = string.Format(this.query, DatabaseName, CusNum);
            oList = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            if (oList != null && oList.Rows.Count > 0)
            {
                DataRow l = oList.Rows[0];
                this.lIsServiceRebateAllItems = Convert.ToBoolean(DBNull.Value.Equals(l["allitems"]) ? 0 : l["allitems"]);
            }



            Panel18.Enabled = true;
            // Block Days REM Alert Customer Bad Payment
            string query = @"
  DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate]
                FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomerRemarkSetting]
                WHERE ([CusNum] = @vCusNum) 
                AND (([Status] = N'Both') OR ([Status] = N'Dry Items'))
                AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE()));
";
            query = string.Format(query, DatabaseName, CusNum);
            DataTable oRemarkList = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (oRemarkList != null && oRemarkList.Rows.Count > 0)
            {
                DateTime vBlockDate = Convert.ToDateTime(DBNull.Value.Equals(oRemarkList.Rows[0]["BlockDate"]) ? Todate : oRemarkList.Rows[0]["BlockDate"]);
                string vCustomerRemark = Convert.ToString(DBNull.Value.Equals(oRemarkList.Rows[0]["Remark"]) ? "" : oRemarkList.Rows[0]["Remark"]).Trim();
                vCustomerRemark += DBNull.Value.Equals(oRemarkList.Rows[0]["BlockDate"]) ? "" : string.Format("{1}អតិថិជននេះនឹងប្លុកនៅថ្ងៃទី : {0:dd-MMM-yyyy}", Convert.ToDateTime(oRemarkList.Rows[0]["BlockDate"]), Environment.NewLine);
                this.TxtCustomerRemark.Text = string.Format("*សូមចំណាំ៖{1}{0}", vCustomerRemark, Environment.NewLine);
                this.PCustomerRemark.Visible = true;
                decimal vExpiry = (decimal)(vBlockDate.Date - Todate.Date).TotalDays;
                if (vExpiry <= 0)
                {
                    this.Panel18.Enabled = false;
                }
                else
                {
                    System.Threading.Thread.Sleep(5000);
                    this.PCustomerRemark.Visible = false;
                    this.TxtCustomerRemark.Text = "";
                }
            }

            // Check Info Customer
            if (!CheckInfoCustomer(CusNum))
            {
                BtnAdd.Enabled = false;
                MessageBox.Show("This customer has been deleted! Please report to administrator!", "Not Existed Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (vIssueUnitPrice)
            {
                this.PanelUnitPrice.BackColor = Color.Brown;
            }
            else
            {
                this.PanelUnitPrice.BackColor = Color.FromName("Control");
            }

            // Check Bank Guarantee
            if (this.CheckBankGaranteeCustomer(CusNum))
                return;
            // Check Credit Amount
            if (this.CheckCreditAmountCustomer(CusNum) == false)
                return;

            App.SetEnableController(true, BtnAdd, CmbProducts, CmbDelto, CmbCategory);

            this.TimerDeltoLoading.Enabled = true;
            this.TimerCategoryLoading.Enabled = true;

            // Confirm Shelf-Life for Picking
            query = @"
DECLARE @lCusNum AS NVARCHAR(8) = N'{1}';
DECLARE @lMethod AS NVARCHAR(25) = N'';
DECLARE @lShelfLife AS DECIMAL(18, 2) = 0;

SELECT @lMethod = ISNULL([lx].[method], N''),
        @lShelfLife = ISNULL([lx].[shelflife], 0)
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblShelfLifeForPicking] lx
WHERE ([lx].[cusnum] = @lCusNum)
        AND ([lx].[id] NOT IN
            (
                SELECT [ls].[id]
                FROM [DBUNTWHOLESALECOLTD].[dbo].[TblShelfLifeForPicking] ls
                    INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblShelfLifeForPicking_Items] ll
                        ON ([ll].[idx] = [ls].[id])
                WHERE ([ls].[cusnum] = @lCusNum)
            )
            );

DECLARE @lExpiryDate AS DATE;
DECLARE @lProductionDate AS DATE;
DECLARE @lAvailable AS DECIMAL(18, 2) = 0;
IF (@lMethod = N'MONTHS')
BEGIN
    SET @lAvailable = DATEDIFF(MONTH, GETDATE(), @lExpiryDate);
END;
ELSE IF (@lMethod = N'PERCENTAGES')
BEGIN
    DECLARE @lFullSLPercentage AS DECIMAL(18, 2) = DATEDIFF(MONTH, @lProductionDate, @lExpiryDate);
    DECLARE @lSLPercentage AS DECIMAL(18, 2) = DATEDIFF(MONTH, GETDATE(), @lExpiryDate);
    SET @lAvailable = (@lSLPercentage / @lFullSLPercentage) * 100.0;
END;

IF (@lMethod <> N'')
BEGIN
    SELECT @lMethod [method],
           @lShelfLife [shelflife],
           @lAvailable [available],
           @lExpiryDate [expirydate];
END;
";
            query = string.Format(query, DatabaseName, this.CmbBillTo.SelectedValue);
            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                string lMethod = Convert.ToString(DBNull.Value.Equals(lists.Rows[0]["method"]) ? "" : lists.Rows[0]["method"]).Trim();
                decimal lShelfLife = Convert.ToDecimal(DBNull.Value.Equals(lists.Rows[0]["shelflife"]) ? 0 : lists.Rows[0]["shelflife"]);
                decimal lAvailable = Convert.ToDecimal(DBNull.Value.Equals(lists.Rows[0]["available"]) ? 0 : lists.Rows[0]["available"]);
                DateTime lExpiryDate = Convert.ToDateTime(DBNull.Value.Equals(lists.Rows[0]["expirydate"]) ? Todate : lists.Rows[0]["expirydate"]);
                var lGUI = new FrmMessageBox();
                lGUI.lblmsg.Text = string.Format("សម្រាប់អតិថិជននេះ ត្រូវបានកំណត់យកផលិតផលនេះដែលមានអាយុកាល(ថ្ងៃ​ផុតកំណត់) មុន{0}{1}ឡើងទៅ", lShelfLife.ToString().Replace("1", "១").Replace("2", "២").Replace("3", "៣").Replace("4", "៤").Replace("5", "៥").Replace("6", "៦").Replace("7", "៧").Replace("8", "៨").Replace("9", "៩"), lMethod.Trim().Equals("MONTHS") ? "ខែ" : "%");
                lGUI.lblmsg.ForeColor = Color.Teal;
                lGUI.ShowDialog(this);
            }


        }

        private bool CheckInfoCustomer(string CusNum)
        {
            bool IsExisted = true;
            string query = @"
DECLARE @cusNum AS NVARCHAR(8) = N'{1}';
WITH lCustomerList
AS (SELECT [CusID],
           [CusNum],
           [CusName],
           [CusVat],
           [Terms],
           [Discount],
           [InvoiceDiscount],
           [CreditLimit],
           [CreditLimitAllow],
           [MaxMonthAllow],
           [ServiceRebate],
           [City],
           [AdditionalCost],
           [IssueUnitPrice],
           [Digit],
           [ServiceCost]
    FROM [Stock].[dbo].[TPRCustomer]
    WHERE [CusNum] = @cusNum
    UNION ALL
    SELECT [CusID],
           [CusNum],
           [CusName],
           [CusVat],
           [Terms],
           [Discount],
           [InvoiceDiscount],
           [CreditLimit],
           [CreditLimitAllow],
           [MaxMonthAllow],
           [ServiceRebate],
           [City],
           [AdditionalCost],
           [IssueUnitPrice],
           [Digit],
           [ServiceCost]
    FROM [DBCostLowECommerce].[dbo].[TblCustomer]
    WHERE [CusNum] = @cusNum),
     lCustomerCreditList
AS (SELECT [lu].[id],
           [lu].[cusnum],
           [lu].[cusname],
           [lu].[allowedterm],
           [lu].[allowedamount],
           [lu].[expireddate],
           [lu].[machinename],
           [lu].[createddate]
    FROM [DBUNTWHOLESALECOLTD].[dbo].[Tblcustomer-credit-amount-allow-from-manager] lu
    WHERE ((CAST([lu].[expireddate] AS DATE) >= CAST(GETDATE() AS DATE)) AND (ISNULL([lu].[allowedqtyinv], 0) > 0)))
SELECT [lc].[CusID],
       [lc].[CusNum],
       [lc].[CusName],
       [lc].[CusVat],
       CAST([lc].[Terms] AS INT) [Terms],
       [lc].[Discount],
       [lc].[InvoiceDiscount],
       CAST([lc].[CreditLimit] AS MONEY) [CreditLimit],
       ISNULL([lu].[allowedamount], CAST([lc].[CreditLimitAllow] AS MONEY)) [CreditLimitAllow],
       ISNULL([lu].[allowedterm], CAST([lc].[MaxMonthAllow] AS INT)) [MaxMonthAllow],
       [lc].[ServiceRebate],
       [lc].[City],
       [lc].[AdditionalCost],
       [lc].[IssueUnitPrice],
       [lc].[Digit],
       [lc].[ServiceCost]
FROM lCustomerList lc
    LEFT OUTER JOIN lCustomerCreditList lu
        ON ([lu].[cusnum] = [lc].[CusNum]);
    ";
            query = string.Format(query, DatabaseName, CusNum);
            var lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                DataRow row = lists.Rows[0];

                this.vServiceCost = row["ServiceCost"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["ServiceCost"]);
                this.CusItemDis = row["Discount"] == DBNull.Value ? 0f : Convert.ToSingle(row["Discount"]);
                this.CusInvoiceDis = row["InvoiceDiscount"] == DBNull.Value ? 0f : Convert.ToSingle(row["InvoiceDiscount"]);
                this.CusVAT = row["CusVat"] == DBNull.Value ? string.Empty : row["CusVat"].ToString().Trim();
                this.CusServiceRebate = row["ServiceRebate"] == DBNull.Value ? 0f : Convert.ToSingle(row["ServiceRebate"]);
                this.Terms = row["Terms"] == DBNull.Value ? 0 : Convert.ToInt32(row["Terms"]);
                this.CreditLimit = row["CreditLimit"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["CreditLimit"]);
                this.MaxMonthAllow = row["MaxMonthAllow"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaxMonthAllow"]);
                this.CreditLimitAllow = row["CreditLimitAllow"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["CreditLimitAllow"]);
                this.vCity = row["City"] == DBNull.Value ? string.Empty : row["City"].ToString().Trim();
                this.vIssueUnitPrice = row["IssueUnitPrice"] == DBNull.Value ? false : Convert.ToBoolean(row["IssueUnitPrice"]);
                this.vAdditionalCost = row["AdditionalCost"] == DBNull.Value ? false : Convert.ToBoolean(row["AdditionalCost"]);
                this.vDigit = row["Digit"] == DBNull.Value ? 2 : Convert.ToInt32(row["Digit"]);

                IsExisted = true;
            }

            else
            {
                IsExisted = false;
            }
            return IsExisted;
        }
        private bool CheckBankGaranteeCustomer(string CusNum)
        {
            bool IsExpiry = false;
            DateTime DateExpiry;
            DateTime DateAlert;
            DateTime CurDate;
            bool IsAlertForm = false;
            string Msg = "";
            string Title = "";
            string query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
SELECT [CreditLimit], [Expiry], [AlertDate], GETDATE() AS [CurDate]
FROM [Stock].[dbo].[TPRCustomerBankGarantee]
WHERE [CusId] = @CusNum
ORDER BY [Expiry];
";
            query = string.Format(query, DatabaseName, CusNum);
            var lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {
                    foreach (DataRow r in lists.Rows)
                    {
                        DateExpiry = Convert.ToDateTime(DBNull.Value.Equals(r["Expiry"]) ? Todate : r["Expiry"]);
                        DateAlert = Convert.ToDateTime(DBNull.Value.Equals(r["AlertDate"]) ? Todate : r["AlertDate"]);
                        CurDate = Convert.ToDateTime(DBNull.Value.Equals(r["CurDate"]) ? Todate : r["CurDate"]);
                        if ((DateExpiry - CurDate).Days <= 0)
                        {
                            Msg = "The customer bank guarantee expiry reaches.\nNot allowed to continue!";
                            Title = "Expiry Reaches";
                            IsExpiry = true;
                            IsAlertForm = true;
                        }
                        else if ((DateAlert - CurDate).Days <= 0)
                        {
                            Msg = $"{(DateExpiry - CurDate).Days} day(s) left for customer bank guarantee expiry.\nPlease inform the administrator.";
                            Title = "Near Expiry";
                            IsAlertForm = true;
                        }
                    }
                }
            }
            if (IsAlertForm)
            {
                FrmAlertBankGarantee frmAlertBankGarantee = new FrmAlertBankGarantee
                {
                    Text = Title,
                    LblMsg = { Text = Msg },
                    DgvShow = { DataSource = lists }
                };
                frmAlertBankGarantee.DgvShow.Refresh();
                frmAlertBankGarantee.ShowDialog();
            }

            return IsExpiry;
        }


        private bool CheckCreditAmountCustomer(string CusNum, double Amount = 0, bool isAddButton = false)
        {
            bool IsAllow = false;
            string InvNumber = "";
            DateTime ShipDate = DateTime.MinValue;
            double GrandTotal = 0;
            double CreditAmount = 0;
            string query = @"
DECLARE @RC INT;
DECLARE @cusNum NVARCHAR(10) = N'{0}';
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[getFirstInvNumberOwedOfCustomerCredit] @cusNum;
";
            query = string.Format(query, CusNum);

            DataTable CreditAmountList = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (CreditAmountList != null && CreditAmountList.Rows.Count > 0)
            {
                DataRow firstRow = CreditAmountList.Rows.Cast<DataRow>().FirstOrDefault();
                if (firstRow != null)
                {
                    InvNumber = firstRow["invNum"].ToString();
                    ShipDate = Convert.ToDateTime(firstRow["invDate"].ToString());
                    GrandTotal = Convert.ToDouble(firstRow["creditOver"]);
                }
            }

            int termOver = 0;
            int termOverCredit = 0;

            query = @"
DECLARE @RC INT;
DECLARE @cusNum NVARCHAR(10) = N'{0}';
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[getCustomerListOfCreditAmountForAdmin] @cusNum;
";
            query = string.Format(query, CusNum);

            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                DataRow row = lists.Rows[0];
                int qtyInvSetted = row["qtyInvSetted"] == DBNull.Value ? 0 : Convert.ToInt32(row["qtyInvSetted"]);

                termOver = row["termOver"] == DBNull.Value ? 0 : Convert.ToInt32(lists.AsEnumerable().FirstOrDefault()?["termOver"]);
                termOverCredit = row["termOverCredit"] == DBNull.Value ? 0 : Convert.ToInt32(lists.AsEnumerable().FirstOrDefault()?["termOverCredit"]);

                if (row["creditOver"] != DBNull.Value)
                {
                    CreditAmount += lists.AsEnumerable().Sum(lu => Convert.ToDouble(lu["creditOver"]));
                }

                if (row["termSetted"] != DBNull.Value && qtyInvSetted > 0)
                {
                    Terms = lists.AsEnumerable().Sum(lu => Convert.ToInt32(lu["termSetted"]));
                }

                if (row["creditSetted"] != DBNull.Value && qtyInvSetted > 0)
                {
                    CreditLimit = lists.AsEnumerable().Sum(lu => Convert.ToInt32(lu["creditSetted"]));
                }
            }

            CreditAmount += Amount;
            if (isAddButton)
            {
                Goto Err_CheckCreditAmount;
            }


            FrmAlertCreditAmount ofrm_;

            if (termOver >= MaxMonthAllow)
            {
                App.SetEnableController(false, BtnAdd, CmbProducts, CmbDelto, CmbCategory);
                ofrm_ = new FrmAlertCreditAmount();
                ofrm_.Text = "Reminder(Need manager to access)";
                ofrm_.LblMsg.Text = $"Max day allow credit {MaxMonthAllow} days. Latest day {termOver} due invoice. Must notify customer. Latest Invoice Number = {InvNumber}, Ship Date = {ShipDate:dd-MMM-yyyy}, Amount ${GrandTotal:N2}.\nCredit limit allow for this customer = ${CreditLimitAllow:N2}. This customer owes ${CreditAmount}. Not allow issue another invoice.";
                ofrm_.PicAlert.Visible = true;
                ofrm_.BtnOK.Visible = true;
                ofrm_.BtnYes.Visible = false;
                ofrm_.BtnNo.Visible = false;
                ofrm_.oCusNum = CusNum;
                ofrm_.loading.Enabled = true;
                ofrm_.DgvShow.DataSource = CreditAmountList;
                ofrm_.DgvShow.Refresh();
                ofrm_.ShowDialog();
                IsAllow = false;
            }
            else if (termOver >= Terms)
            {
                App.SetEnableController(false, BtnAdd, CmbProducts, CmbDelto, CmbCategory);
                ofrm_ = new FrmAlertCreditAmount();
                ofrm_.Text = "Reminder(Need account manager or manager to access)";
                ofrm_.LblMsg.Text = $"Terms Allow {Terms} days. Maximum {MaxMonthAllow} days is allow due on latest invoice. Should notify customer. Latest Invoice Number = {InvNumber}, Ship Date = {ShipDate:dd-MMM-yyyy}, Amount ${GrandTotal:N2}.\nCredit limit allow for this customer = ${CreditLimitAllow:N2}. This customer owes ${CreditAmount:N2}. Not allow issue another invoice.";
                ofrm_.PicAlert.Visible = false;
                ofrm_.BtnOK.Visible = false;
                ofrm_.BtnYes.Visible = true;
                ofrm_.BtnNo.Visible = true;
                ofrm_.oCusNum = CusNum;
                ofrm_.loading.Enabled = true;
                ofrm_.DgvShow.DataSource = CreditAmountList;
                ofrm_.DgvShow.Refresh();

                if (ofrm_.ShowDialog() == DialogResult.Yes)
                {
                    if (CreditAmount >= CreditLimitAllow)
                    {
                        ofrm_.Text = "Credit Limit (Need Manager to access)";
                        ofrm_.LblMsg.Text = $"Credit limit allow for this customer = ${CreditLimitAllow:N2}. This customer owes ${CreditAmount:N2}. Not allow issue another invoice.";
                        ofrm_.PicAlert.Visible = true;
                        ofrm_.BtnOK.Visible = true;
                        ofrm_.BtnYes.Visible = false;
                        ofrm_.BtnNo.Visible = false;
                        ofrm_.oCusNum = CusNum;
                        ofrm_.loading.Enabled = true;
                        ofrm_.DgvShow.DataSource = CreditAmountList;
                        ofrm_.DgvShow.Refresh();
                        ofrm_.ShowDialog();

                        Initialized.R_CorrectPassword = false;
                        FrmPasswordContinues lG1 = new FrmPasswordContinues();
                        lG1.R_PasswordPermission = "'Managing Director','IT Manager'";
                        lG1.ShowDialog();

                        IsAllow = Initialized.R_CorrectPassword ? true : false;
                    }
                    else
                    {
                        Initialized.R_CorrectPassword = false;
                        FrmPasswordContinues lG1 = new FrmPasswordContinues();
                        lG1.R_PasswordPermission = "'Managing Director','IT Manager','Office Manager','TakeOrder'";
                        lG1.ShowDialog();

                        IsAllow = Initialized.R_CorrectPassword ? true : false;
                    }
                }
                else
                {
                    IsAllow = false;
                }
            }
            else
            {
                App.SetEnableController(false, BtnAdd, CmbProducts, CmbDelto, CmbCategory);
                if (CreditAmount >= CreditLimitAllow)
                {
                    ofrm_ = new FrmAlertCreditAmount();
                    ofrm_.Text = "Credit Limit (Need manager to access)";
                    ofrm_.LblMsg.Text = $"Credit limit allow for this customer = ${CreditLimitAllow:N2}.\nThis customer owes ${CreditAmount:N2}. Not allow issue another invoice.";
                    ofrm_.PicAlert.Visible = true;
                    ofrm_.BtnOK.Visible = true;
                    ofrm_.BtnYes.Visible = false;
                    ofrm_.BtnNo.Visible = false;
                    ofrm_.oCusNum = CusNum;
                    ofrm_.loading.Enabled = true;
                    ofrm_.DgvShow.DataSource = CreditAmountList;
                    ofrm_.DgvShow.Refresh();
                    ofrm_.ShowDialog();
                    IsAllow = false;
                }
                else if (CreditAmount >= CreditLimit)
                {
                    ofrm_ = new FrmAlertCreditAmount();
                    ofrm_.Text = "Credit Limit (Need account manager to access)";
                    ofrm_.LblMsg.Text = $"Credit limit for this customer = ${CreditLimit:N2}.\nThis customer owes ${CreditAmount:N2}. Would you like to issue another invoice.";
                    ofrm_.PicAlert.Visible = false;
                    ofrm_.BtnOK.Visible = false;
                    ofrm_.BtnYes.Visible = true;
                    ofrm_.BtnNo.Visible = true;
                    ofrm_.oCusNum = CusNum;
                    ofrm_.loading.Enabled = true;
                    ofrm_.DgvShow.DataSource = CreditAmountList;
                    ofrm_.DgvShow.Refresh();

                    if (ofrm_.ShowDialog() == DialogResult.Yes)
                    {
                        Initialized.R_CorrectPassword = false;
                        FrmPasswordContinues lG1 = new FrmPasswordContinues();
                        lG1.R_PasswordPermission = "'Managing Director','IT Manager','Office Manager','TakeOrder'";
                        lG1.ShowDialog();

                        IsAllow = Initialized.R_CorrectPassword ? true : false;
                    }
                    else
                    {
                        IsAllow = false;
                    }
                }
                else
                {
                    App.SetEnableController(true, BtnAdd, CmbProducts, CmbDelto, CmbCategory);
                    IsAllow = true;
                }
            }

            return IsAllow;

        }

        private void chknone_CheckedChanged(object sender, EventArgs e)
        {
            if (chknone.Checked)
            {
                if (!string.IsNullOrWhiteSpace(TxtPONo.Text) && !TxtPONo.Text.Trim().Equals("N/A"))
                {
                    vponumber_ = TxtPONo.Text.Trim();
                }
                TxtPONo.Text = "N/A";
                TxtPONo.ReadOnly = true;
            }
            else
            {
                TxtPONo.Text = "";
                TxtPONo.ReadOnly = false;
            }
        }

        private void RdbOnlinePO_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbOnlinePO.Checked)
            {
                this.sFirstLoading = true;
                this.lblMsg.Text = this.RdbOnlinePO.Text.Trim().ToUpper();
                this.TimerCustomerLoading.Enabled = true;
            }
        }
        private DataTable DeliveryTakeOrderList;
        private DataTable vPromotionList;
        private DataTable vFixedPriceList;


        private void CmbBillTo_MouseDown(object sender, MouseEventArgs e)
        {
            IsKeyPress = false;
            if (DeliveryTakeOrderList != null)
            {
                if (DeliveryTakeOrderList.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure, you want to change Bill To?(Yes/No)\nRemark: If you change Bill To, All data will be lost.", "Confirm Change Bill To", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    CreateDeliveryTakeOrderList();
                }
            }
        }
        private bool IsKeyPress;

        private void CmbBillTo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            IsKeyPress = true;
        }

        private void TxtRequiredDate_MouseDown(object sender, MouseEventArgs e)
        {
            TxtRequiredDate.Text = string.Format("{0:dd-MMM-yyyy}", DTPRequiredDate.Value);
        }



        private void TxtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private double RoundUp(double value, int decimals)
        {
            return Math.Ceiling(value * Math.Pow(10, decimals)) / Math.Pow(10, decimals);
        }



        private bool IsNumeric(string value)
        {
            return decimal.TryParse(value, out _);
        }



        private void TimerChecking_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.TimerChecking.Enabled = false;
            if (string.IsNullOrWhiteSpace(CmbProducts.Text))
            {
                this.Cursor = Cursors.Default;
                return;
            }

            // Check Customer Cash Van Existed Fixed Price Or Not
            if (this.rdbcostlowecommerence.Checked)
            {
                // Do nothing
            }
            else
            {
                query = @"      DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @vBarcode AS NVARCHAR(MAX) = N'{2}';
                WITH v AS (
	                SELECT [CusNum],[Barcode]
	                FROM [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPriceSetting]
	                WHERE ([CusNum] = @vCusNum) AND ([Barcode] = @vBarcode)
	                UNION ALL
	                SELECT o.[CusNum],v.[Barcode]
	                FROM [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPriceSetting] v
	                INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblFixedPriceCustomerGroupSetting] o ON o.[GroupNumber] = ISNULL(v.[GroupNumber],0)
	                WHERE (o.[CusNum] = @vCusNum) AND (v.[Barcode] = @vBarcode)
                )
                SELECT v.*
                INTO #oPriceSetting
                FROM v;

                IF EXISTS(SELECT [CusNum] FROM [Stock].[dbo].[TPRCustomer] WHERE ([CusNum] = @vCusNum) AND (ISNULL([IsCashVan],0) = 1))
                BEGIN
	                IF EXISTS(SELECT * FROM #oPriceSetting)
	                BEGIN
		                SELECT N'NO_NEED' [Reason];
	                END;
	                ELSE
	                BEGIN
		                SELECT N'NEED' [Reason];
	                END;
                END;
                ELSE
                BEGIN
	                SELECT N'NO_NEED' [Reason];
                END;
                DROP TABLE #oPriceSetting;
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null && lists.Rows.Count > 0)
                {
                    string vReason = lists.Rows[0]["Reason"] == DBNull.Value ? "NO_NEED" : lists.Rows[0]["Reason"].ToString().Trim();
                    if (vReason.Equals("NEED"))
                    {
                        MessageBox.Show("Please contact to admin to set price for cash van first!", "Contact To Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BtnAdd.Enabled = false;
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
            }

            // Confirm Shelf-Life for Picking
            query = @"
DECLARE @lCusNum AS NVARCHAR(8) = N'{1}';
DECLARE @lBarcode AS NVARCHAR(15) = N'{2}';
DECLARE @lMethod AS NVARCHAR(25) = N'';
DECLARE @lShelfLife AS DECIMAL(18, 2) = 0;
DECLARE @lIdx AS UNIQUEIDENTIFIER = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);
DECLARE @lIsItems AS BIT = 1;

SELECT @lIdx = [lx].[id],
       @lMethod = ISNULL([lx].[method], N''),
       @lShelfLife = ISNULL([lx].[shelflife], 0)
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblShelfLifeForPicking] lx
    INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblShelfLifeForPicking_Items] ll
        ON ([ll].[idx] = [lx].[id])
WHERE ([lx].[cusnum] = @lCusNum)
      AND ([ll].[unitnumber] = @lBarcode);

IF ((@lMethod = N'') AND (@lShelfLife = 0))
BEGIN
    SET @lIsItems = 0;
    SELECT @lMethod = ISNULL([lx].[method], N''),
           @lShelfLife = ISNULL([lx].[shelflife], 0)
    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblShelfLifeForPicking] lx
    WHERE ([lx].[cusnum] = @lCusNum)
          AND ([lx].[id] NOT IN
               (
                   SELECT [ls].[id]
                   FROM [DBUNTWHOLESALECOLTD].[dbo].[TblShelfLifeForPicking] ls
                       INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblShelfLifeForPicking_Items] ll
                           ON ([ll].[idx] = [ls].[id])
                   WHERE ([ls].[cusnum] = @lCusNum)
               )
              );
END;

DECLARE @lExpiryDate AS DATE;
DECLARE @lProductionDate AS DATE;
SELECT TOP 1
       @lExpiryDate = CONVERT(DATE, [lv].[Expiry]),
       @lProductionDate = CONVERT(DATE, [lv].[ProductionDate])
FROM [Stock].[dbo].[TPRWarehouseStockIn] lv
WHERE ([lv].[ProNumy] = @lBarcode)
GROUP BY CONVERT(DATE, [lv].[Expiry]),
         CONVERT(DATE, [lv].[ProductionDate])
ORDER BY CONVERT(DATE, [lv].[Expiry]) DESC;

DECLARE @lAvailable AS DECIMAL(18, 2) = 0;
IF (@lMethod = N'MONTHS')
BEGIN
    SET @lAvailable = DATEDIFF(MONTH, GETDATE(), @lExpiryDate);
END;
ELSE IF (@lMethod = N'PERCENTAGES')
BEGIN
    DECLARE @lFullSLPercentage AS DECIMAL(18, 2) = DATEDIFF(MONTH, @lProductionDate, @lExpiryDate);
    DECLARE @lSLPercentage AS DECIMAL(18, 2) = DATEDIFF(MONTH, GETDATE(), @lExpiryDate);
    SET @lAvailable = (@lSLPercentage / @lFullSLPercentage) * 100.0;
END;

IF (@lMethod <> N'')
BEGIN
    SELECT @lIsItems [isitems],
           @lMethod [method],
           @lShelfLife [shelflife],
           @lAvailable [available],
           @lExpiryDate [expirydate];
END;
";
            query = string.Format(query, DatabaseName, this.CmbBillTo.SelectedValue, this.CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                bool lIsItems = lists.Rows[0]["isitems"] == DBNull.Value ? false : Convert.ToBoolean(lists.Rows[0]["isitems"]);
                string lMethod = lists.Rows[0]["method"] == DBNull.Value ? "" : lists.Rows[0]["method"].ToString().Trim();
                decimal lShelfLife = lists.Rows[0]["shelflife"] == DBNull.Value ? 0 : Convert.ToDecimal(lists.Rows[0]["shelflife"]);
                decimal lAvailable = lists.Rows[0]["available"] == DBNull.Value ? 0 : Convert.ToDecimal(lists.Rows[0]["available"]);
                DateTime lExpiryDate = lists.Rows[0]["expirydate"] == DBNull.Value ? Todate : Convert.ToDateTime(lists.Rows[0]["expirydate"]);

                if (lShelfLife > 0 && lAvailable < lShelfLife)
                {
                    var lGUI = new FrmMessageBox();
                    lGUI.lblmsg.Text = string.Format("សម្រាប់អតិថិជននេះ ត្រូវបានកំណត់យកផលិតផលនេះដែលមានអាយុកាល(ថ្ងៃ​ផុតកំណត់) មុន{0}{4}ឡើងទៅ{1}ចំពោះផលិតផលនេះនៅសល់អាយុកាលតែ{2}{4}តែប៉ុណ្ណោះ{1}សូមបញ្ជាក់៖ ស្តុកនៅក្នុងឃ្លាំង នៅមានតែអាយុកាល(ថ្ងៃ​ផុតកំណត់)ច្រើនបំផុតត្រឹម {3:yyyy-MMM-dd} តែប៉ុណ្ណោះ", lShelfLife.ToString().Replace("1", "១").Replace("2", "២").Replace("3", "៣").Replace("4", "៤").Replace("5", "៥").Replace("6", "៦").Replace("7", "៧").Replace("8", "៨").Replace("9", "៩"), Environment.NewLine, lAvailable.ToString().Replace("1", "១").Replace("2", "២").Replace("3", "៣").Replace("4", "៤").Replace("5", "៥").Replace("6", "៦").Replace("7", "៧").Replace("8", "៨").Replace("9", "៩"), lExpiryDate, lMethod.Trim().Equals("MONTHS") ? "ខែ" : "%");
                    lGUI.lblmsg.ForeColor = Color.Red;
                    lGUI.ShowDialog(this);
                }
                else if (lIsItems)
                {
                    var lGUI = new FrmMessageBox();
                    lGUI.lblmsg.Text = string.Format("សម្រាប់អតិថិជននេះ ត្រូវបានកំណត់យកផលិតផលនេះដែលមានអាយុកាល(ថ្ងៃ​ផុតកំណត់) មុន{0}{1}ឡើងទៅ", lShelfLife.ToString().Replace("1", "១").Replace("2", "២").Replace("3", "៣").Replace("4", "៤").Replace("5", "៥").Replace("6", "៦").Replace("7", "៧").Replace("8", "៨").Replace("9", "៩"), lMethod.Trim().Equals("MONTHS") ? "ខែ" : "%");
                    lGUI.lblmsg.ForeColor = Color.Teal;
                    lGUI.ShowDialog(this);
                }
            }

            // Separate By Supplier
            string SupNumSeparate = "";
            query = @"
  DECLARE @Barcode AS NVARCHAR(MAX) = '{1}';
                SELECT [SupNum] FROM [{0}].[dbo].[TblSuppliers_IssuePOSeparately] WHERE [SupNum] IN (
                SELECT LEFT([Sup1],8) AS [SupNum] FROM [Stock].[dbo].[TPRProducts] WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
                UNION ALL
                SELECT LEFT([Sup1],8) AS [SupNum] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
                UNION ALL
                SELECT LEFT(A.[Sup1],8) AS [SupNum] FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId] WHERE B.[OldProNumy] = @Barcode
                UNION ALL
                SELECT LEFT(A.[Sup1],8) AS [SupNum] FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId] WHERE B.[OldProNumy] = @Barcode)
       ";
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                SupNumSeparate = lists.Rows[0]["SupNum"] == DBNull.Value ? "" : lists.Rows[0]["SupNum"].ToString().Trim();
            }

            if (!string.IsNullOrWhiteSpace(SupNumSeparate) && this.DeliveryTakeOrderList != null)
            {
                var barcodeSelected = (from DataRow lx in this.DeliveryTakeOrderList.Rows
                                       where lx["SupNum"] != DBNull.Value && lx["SupNum"].ToString().Trim().Equals(SupNumSeparate)
                                       select lx["ProNumy"].ToString()).Distinct().ToArray();
                if (barcodeSelected.Length > 0)
                {
                    MessageBox.Show("Please check product again!" + Environment.NewLine + "The supplier is separate from other supplier.", "Must Separate Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.BtnAdd.Enabled = false;
                    return;
                }
            }
            // Add Shipping Cost
            double AddShippingCost = 0;
            query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
SELECT * 
FROM [Stock].[dbo].[TPRCustomer] 
WHERE [IsAddShippingCost] = 1 AND [CusNum] = @CusNum;
";
            query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
SELECT * 
FROM [Stock].[dbo].[TPRAddShippingCost] 
WHERE [CusNum] = @CusNum AND [Barcode] = @Barcode;
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null && lists.Rows.Count > 0)
                {
                    AddShippingCost = lists.Rows[0]["AmountAdd"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["AmountAdd"]);
                }
                else
                {
                    MessageBox.Show("Please contact to Office Manager to add shipping cost of product for this customer!", "Contact to Office Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnAdd.Enabled = false;
                    return;
                }
            }

            // Deactivated Item
            DataTable dtDC = CheckDeactivatedItem();
            if (dtDC.Rows.Count > 0)
            {
                if (MessageBox.Show("This Barcode is in Product Deactivated! Do you want to send email to customer?", "Confirm Deactivated Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                string email = CheckCustomerEmail().Rows[0][0].ToString();
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("This customer does not have email address.");
                    Cursor = Cursors.Default;
                    return;
                }

                MailDCSKUReport dcReport = new MailDCSKUReport();
                DataRow dr = dtDC.Rows[0];
                dcReport.Parameters["paramDear"].Value = $"Dear {CmbBillTo.Text},";
                dcReport.Parameters["paramPO"].Value = TxtPONo.Text.Replace("'", "`").Trim();
                dcReport.Parameters["paramBarcode"].Value = dr["ProNumY"].ToString();
                dcReport.Parameters["paramName"].Value = dr["ProName"].ToString();
                dcReport.Parameters["paramSize"].Value = dr["ProPacksize"].ToString();

                dcReport.CreateDocument(true);
                try
                {
                    using (var client = new SmtpClient("untwholesale.com", 465))
                    {
                        using (var message = dcReport.ExportToMail("sales@untwholesale.com", email, "Product Discontinued"))
                        {
                            foreach (DataRow drEmail in QueryCCEmail().Rows)
                            {
                                message.CC.Add(drEmail[0].ToString());
                            }

                            client.Credentials = new System.Net.NetworkCredential("sales@untwholesale.com", "sales@unt573");
                            client.EnableSsl = true;
                            client.Send(message);
                            MessageBox.Show("Your email has been sent successfully.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Send email failed." + Environment.NewLine + ex.ToString());
                }
            }

            // Old Code
            if (CheckOldItem()) return;

            // Alert New Code
            if (CheckNewCodeForCustomer())
            {
                MessageBox.Show("The Barcode has been changed! Please inform customer first!", "Not Allow To Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnAdd.Enabled = false;
                return;
            }

            // Products
            query = @"
   DECLARE @Barcode AS NVARCHAR(MAX) = N'{1}';
                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProPckPri],[ProUPriSeH],[SupNum],[SupName],[ExciseTax],[PublicLightingTax]
                FROM (
	                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProPckPri],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName],ISNULL([ExciseTax], 0) [ExciseTax],ISNULL([PublicLightingTax], 0) [PublicLightingTax]
	                FROM [Stock].[dbo].[TPRProducts]
	                WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	                UNION ALL
	                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProPckPri],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName],ISNULL([A].[ExciseTax], 0) [ExciseTax],ISNULL([A].[PublicLightingTax], 0) [PublicLightingTax]
	                FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                WHERE B.[OldProNumy] = @Barcode
                    UNION ALL
                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProPckPri],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName],ISNULL([ExciseTax], 0) [ExciseTax],ISNULL([PublicLightingTax], 0) [PublicLightingTax]
	                FROM [Stock].[dbo].[TPRProductsDeactivated]
	                WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	                UNION ALL
	                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProPckPri],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName],ISNULL([A].[ExciseTax], 0) [ExciseTax],ISNULL([A].[PublicLightingTax], 0) [PublicLightingTax]
	                FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                WHERE B.[OldProNumy] = @Barcode
                ) LISTS;
";
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                TxtQtyPerCase.Text = lists.Rows[0]["ProQtyPCase"] == DBNull.Value ? "1" : lists.Rows[0]["ProQtyPCase"].ToString();
                this.QtyPerPack = lists.Rows[0]["ProQtyPPack"] == DBNull.Value ? 1 : Convert.ToInt32(lists.Rows[0]["ProQtyPPack"]);
                TxtStock.Text = string.Format("{0:N0}", lists.Rows[0]["ProTotQty"] == DBNull.Value ? 0 : Convert.ToInt64(lists.Rows[0]["ProTotQty"]));
                this.currency = (lists.Rows[0]["ProCurr"] == DBNull.Value) ? "CUR00001   USD   1" : lists.Rows[0]["ProCurr"].ToString().Trim();

                buyin = lists.Rows[0]["ProImpPri"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["ProImpPri"]);
                buyDis = lists.Rows[0]["ProDis"] == DBNull.Value ? 0 : Convert.ToSingle(lists.Rows[0]["ProDis"]);
                buyVAT = lists.Rows[0]["ProVAT"] == DBNull.Value ? 0 : Convert.ToSingle(lists.Rows[0]["ProVAT"]);
                average = lists.Rows[0]["Average"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["Average"]);
                rSupNum = lists.Rows[0]["SupNum"] == DBNull.Value ? "" : lists.Rows[0]["SupNum"].ToString().Trim();
                rSupName = lists.Rows[0]["SupName"] == DBNull.Value ? "" : lists.Rows[0]["SupName"].ToString().Trim();
                lExciseTaxPercent = lists.Rows[0]["ExciseTax"] == DBNull.Value ? 0 : Convert.ToSingle(lists.Rows[0]["ExciseTax"]);
                lPublicLightingTaxPercent = lists.Rows[0]["PublicLightingTax"] == DBNull.Value ? 0 : Convert.ToSingle(lists.Rows[0]["PublicLightingTax"]);
                this.lUnitPrice = lists.Rows[0]["ProUPrSE"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["ProUPrSE"]);
                this.lPackPrice = lists.Rows[0]["ProPckPri"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["ProPckPri"]);
                this.lCasePrice = lists.Rows[0]["ProUPriSeH"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["ProUPriSeH"]);
                if (string.IsNullOrWhiteSpace(lists.Rows[0]["ProNumYP"].ToString())) App.SetReadOnlyController(true, TxtPackOrder);
            }
            else
            {
                MessageBox.Show("The Item is wrong. Please check item again...", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.check_pending_stock.Enabled = true;
            TxtPcsOrder.ReadOnly = false;
            TxtCTNOrder.ReadOnly = false;
            TxtPackOrder.ReadOnly = false;

            float CusDiscount = (100 - CusItemDis) / 100;
            rate = Convert.ToSingle(currency.Substring(14));
            buyin /= rate;
            buyDis = (100 - buyDis) / 100;
            buyVAT = (buyVAT / 100) + 1;
            totalBuyin = (buyin * buyDis) * ((100 + lExciseTaxPercent) / 100) * ((100 + lPublicLightingTaxPercent) / 100) * buyVAT;
            wsAfter = (wsAfter * CusDiscount) + AddShippingCost;

            string lCusNum = "";
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                lCusNum = "";
            }
            else
            {
                lCusNum = string.IsNullOrWhiteSpace(CmbBillTo.Text) ? "" : CmbBillTo.SelectedValue.ToString();
            }

            string lBarcode = "";
            if (CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue == null)
            {
                lBarcode = "";
            }
            else
            {
                lBarcode = string.IsNullOrWhiteSpace(CmbProducts.Text) ? "" : CmbProducts.SelectedValue.ToString();
            }
            double lCasePrice = 0;



            string lSql = @"
DECLARE @RC INT;
DECLARE @lCusNum AS NVARCHAR(8) = N'{0}';
DECLARE @lBarcode AS NVARCHAR(15) = N'{1}';
DECLARE @lWSPrice MONEY = 0;
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[getWSPriceForCustomer] @lCusNum,
                                                                  @lBarcode,
                                                                  @lWSPrice = @lWSPrice OUTPUT;
SELECT @lWSPrice [wsprice];
";
            lSql = string.Format(lSql, lCusNum, lBarcode);
            DataTable lTbl = Data.Selects(lSql, Initialized.GetConnectionType(Data, App));
            if (lTbl != null && lTbl.Rows.Count > 0)
            {
                DataRow lv = lTbl.Rows[0];
                lCasePrice = lv["wsprice"] == DBNull.Value ? 0 : Convert.ToDouble(lv["wsprice"]);
                this.wsAfter = lCasePrice;
            }

            // Products Delivery Logistic
            double vDeliveryLogistic = 0;
            if (vAdditionalCost)
            {
                query = @"
 DECLARE @vBarcode AS NVARCHAR(MAX) = N'{1}';
                    DECLARE @vCity AS NVARCHAR(100) = N'{2}';
                    SELECT ISNULL([DeliveryCost],0) AS [DeliveryCost] 
                    FROM [{0}].[dbo].[TblProductsDeliveryLogistic] 
                    WHERE [ProId] IN (
                    SELECT [ProID] FROM [Stock].[dbo].[TPRProducts] WHERE (ISNULL([ProNumY],'') = @vBarcode OR ISNULL([ProNumYP],'') = @vBarcode OR ISNULL([ProNumYC],'') = @vBarcode)
                    UNION ALL
                    SELECT [ProId] FROM [Stock].[dbo].[TPRProductsOldCode] WHERE [OldProNumy] = @vBarcode) 
                    AND [City] = @vCity;
";
                query = string.Format(query, DatabaseName, CmbProducts.SelectedValue, vCity);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

                if (lists != null && lists.Rows.Count > 0)
                {
                    vDeliveryLogistic = lists.Rows[0]["DeliveryCost"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["DeliveryCost"]);
                    if (vDeliveryLogistic == 0)
                    {
                        MessageBox.Show("Please check Additional Cost of product for this customer first!" + Environment.NewLine + "Please contact to Administrator.", "Not Allow To Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;
                        this.BtnAdd.Enabled = false;
                        return;
                    }
                    else
                    {

                        this.BtnAdd.Enabled = true;
                    }
                }
            }

            // Product Image
            byte[] img = null;
            query = @"
  DECLARE @Barcode AS NVARCHAR(MAX) = N'{1}';
                SELECT [ProId],[ProImage]
                FROM [Stock].[dbo].[TPRProductsPicture]
                WHERE [ProId] IN (
                SELECT [ProID] FROM [Stock].[dbo].[TPRProducts] WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
                UNION ALL
                SELECT [ProId] FROM [Stock].[dbo].[TPRProductsOldCode] WHERE [OldProNumy] = @Barcode);
";
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {

                    img = lists.Rows[0]["ProImage"] == DBNull.Value ? null : (byte[])lists.Rows[0]["ProImage"];
                    PicProducts.Image = App.BytetoImage(img);
                }
            }

            DataTable ExclusiveImpSupList = null;
            DataTable ExclusiveCusList = null;
            float SerRebate = 0;
            decimal vFixedId = 0;
            DataRow Row = null;
            double vWSTemp = 0;
            this.oFixedPriceQtyInvoicing = 0;
            this.oIsFixedPrice = false;

            if (this.rdbcostlowecommerence.Checked) goto err_costlow;
            //;


            // Fixed Prices
            query = @"
 DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @Barcode AS NVARCHAR(MAX) = N'{2}';
                SELECT v.[Id],v.[ByinPrice],v.[WSPrice],v.[QtyInvoicing]
                FROM [{0}].[dbo].[TblProductsPriceSetting] AS v
                LEFT OUTER JOIN [{0}].[dbo].[TblFixedPriceCustomerGroupSetting] AS o ON ISNULL(v.[GroupNumber],0) = ISNULL(o.[GroupNumber],0)
                WHERE (DATEDIFF(DAY,GETDATE(),v.[PeriodFrom]) <= 0 AND DATEDIFF(DAY,GETDATE(),v.[PeriodTo]) >= 0) AND (ISNULL(v.[CusNum],o.[CusNum]) = @CusNum) AND v.[Barcode] = @Barcode;
      
";
            query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                vFixedId = lists.Rows[0]["Id"] == DBNull.Value ? 0 : Convert.ToInt32(lists.Rows[0]["Id"]);
                vWSTemp = lists.Rows[0]["WSPrice"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["WSPrice"]);
                this.oFixedPriceQtyInvoicing = lists.Rows[0]["QtyInvoicing"] == DBNull.Value ? 0 : Convert.ToInt32(lists.Rows[0]["QtyInvoicing"]);
                decimal vTotalTO = 0;
                if (this.oFixedPriceQtyInvoicing > 0)
                {
                    query = @"
  DECLARE @vFixedIdLink AS DECIMAL(18,0) = {1};
                            WITH v AS (
	                            SELECT SUM([QtyInvoicing]) [Qty]
	                            FROM [{0}].[dbo].[TblProductsPriceSetting.AllowableInvoicing]
	                            WHERE ([FixedIdLink] = @vFixedIdLink)
	                            UNION ALL
	                            SELECT SUM([QtyInvoicing]) [Qty]
	                            FROM [{0}].[dbo].[TblProductsPriceSetting.AllowableInvoicing.Completed]
	                            WHERE ([FixedIdLink] = @vFixedIdLink)
                            )
                            SELECT SUM(v.[Qty]) [Qty]
                            FROM v;
";
                    query = string.Format(query, DatabaseName, vFixedId);
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null && lists.Rows.Count > 0)
                    {
                        vTotalTO = lists.Rows[0]["Qty"] == DBNull.Value ? 0 : Convert.ToDecimal(lists.Rows[0]["Qty"]);
                    }

                    if (this.oFixedPriceQtyInvoicing >= vTotalTO && this.oFixedPriceQtyInvoicing > 0)
                    {
                        string vMsg = string.Format("~ Total Fixed Price: {4:C2} ({1:N0}){0}~ Used Fixed Price: {2:N0}{0}~ Left Fixed Price: {3:N0}{0}{0}Do you want to set fixed price for Item in the Take Order? (Yes/No)", Environment.NewLine, this.oFixedPriceQtyInvoicing, vTotalTO, this.oFixedPriceQtyInvoicing - vTotalTO, vWSTemp);
                        if (MessageBox.Show(vMsg, "Confirm Fixed Price", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.oIsFixedPrice = true;
                            Row = vFixedPriceList.NewRow();
                            Row["FixedIdLink"] = vFixedId;
                            Row["Barcode"] = CmbProducts.SelectedValue;
                            Row["QtyInvoicing"] = 1;
                            vFixedPriceList.Rows.Add(Row);
                            goto WSPrice_Final;
                        }
                    }
                }
                else
                {
                    this.oIsFixedPrice = true;
                    goto WSPrice_Final;
                }
            }

            // Fixed Prices Expiry Date
            query = @"
 DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @Barcode AS NVARCHAR(MAX) = N'{2}';
                SELECT v.*
                FROM [{0}].[dbo].[TblProductsPriceSetting] AS v
                LEFT OUTER JOIN [{0}].[dbo].[TblFixedPriceCustomerGroupSetting] AS o ON ISNULL(v.[GroupNumber],0) = ISNULL(o.[GroupNumber],0)
                WHERE (DATEDIFF(DAY,GETDATE(),v.[PeriodFrom]) <= 0 AND DATEDIFF(DAY,GETDATE(),v.[PeriodTo]) < 0) AND (ISNULL(v.[CusNum],o.[CusNum]) = @CusNum) AND v.[Barcode] = @Barcode;
      
";
            query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                string oCusName = lists.Rows[0]["CusName"] == DBNull.Value ? "" : lists.Rows[0]["CusName"].ToString().Trim();
                string oBarcode = lists.Rows[0]["Barcode"] == DBNull.Value ? "" : lists.Rows[0]["Barcode"].ToString().Trim();
                string oProName = lists.Rows[0]["Description"] == DBNull.Value ? "" : lists.Rows[0]["Description"].ToString().Trim();
                double oWSFixed = lists.Rows[0]["WSPrice"] == DBNull.Value ? 0 : Convert.ToDouble(lists.Rows[0]["WSPrice"]);
                this.BtnAdd.Enabled = false;
                MessageBox.Show(string.Format("The Fixed Price was expired Date.{0}Please contact to Office Manager to confirm price again!{0}► Customer Name: {1}{0}► Barcode: {2} {3}{0}► WS Fixed Price: {4:C2}", Environment.NewLine, oCusName, oBarcode, oProName, oWSFixed), "Expiry Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                return;
            }

        err_costlow:

            // Customer Prices    
            // ExclusiveImpSup
            query = @"
DECLARE @SupNum AS NVARCHAR(8) = '{1}';
SELECT SupNo, SupName
FROM [Stock].[dbo].[TPRExclusiveImpSup]
WHERE SupNo = @SupNum;
";
            query = string.Format(query, DatabaseName, rSupNum);
            ExclusiveImpSupList = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            //Customer Prices  
            //  ExclusiveCus
            query = @"
DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
SELECT CusNum, CusName, AddPercentImport, BirthDate
FROM [Stock].[dbo].[TPRExclusiveCus]
WHERE CusNum = @CusNum;
";
            query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue);
            ExclusiveCusList = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (!CusVAT.Contains("GC") && !string.IsNullOrEmpty(CusVAT) && CusVAT != "NONE" && CusVAT != "NA" && CusVAT != "N/A" && CusVAT != "-")
            {
                SerRebate = (CusServiceRebate / 100) + 1;
                if (ExclusiveImpSupList != null && ExclusiveImpSupList.Rows.Count > 0)
                {
                    if (wsAfter > (buyin * buyDis))
                    {
                        // Do nothing
                    }
                    else
                    {
                        if ((buyin * buyDis) > (wsAfter * 1.1))
                        {
                            this.BtnAdd.Enabled = false;
                            MessageBox.Show(string.Format("Please contact to Office Manager to confirm price again!{0}► Buyin Price: {1:C4}{0}► WS Price: {2:C4}{0}Because the WS Price is smaller than Buying Price.", Environment.NewLine, totalBuyin, wsAfter), "WS Price < Buyin Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    goto WSPrice_Final;
                }
            }
            else
            {
                if (ExclusiveImpSupList != null && ExclusiveImpSupList.Rows.Count > 0)
                {
                    if (wsAfter > (buyin * buyDis))
                    {
                        // Do nothing
                    }
                    else
                    {
                        if ((buyin * buyDis) > wsAfter)
                        {
                            this.BtnAdd.Enabled = false;
                            MessageBox.Show(string.Format("Please contact to Office Manager to confirm price again!{0}► Buyin Price: {1:C4}{0}► WS Price: {2:C4}{0}Because the WS Price is smaller than Buying Price.", Environment.NewLine, totalBuyin, wsAfter), "WS Price < Buyin Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                }
            }

        WSPrice_Final:
            int lQtyPerCase = string.IsNullOrWhiteSpace(this.TxtQtyPerCase.Text) ? 1 : Convert.ToInt32(this.TxtQtyPerCase.Text.Trim());
            double lUnitPrice = lCasePrice / lQtyPerCase;
            double lPackPrice = lUnitPrice * QtyPerPack;
            this.TxtUnitPrice.Text = string.Format("{0:N" + vDigit + "}", lUnitPrice);
            this.TxtPackPrice.Text = string.Format("{0:N2}", lPackPrice);
            this.TxtWSPrice.Text = string.Format("{0:N2}", lCasePrice);
            this.IsCheckPromotion = true;

            if (RdbOnlinePO.Checked)
            {
                this.query = @"
DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
DECLARE @DeltoId AS DECIMAL(18, 0) = {2};
DECLARE @Barcode AS NVARCHAR(MAX) = N'{3}';

SELECT [x].[PONumber],
       [x].[Barcode],
       [x].[ProductName],
       [x].[Size],
       [x].[QtyPerCase],
       [x].[Price],
       [x].[PcsOrder],
       [x].[PackOrder],
       [x].[CtnOrder],
       [v].[OrderDate],
       [v].[DeliveryDate],
	   [o].[SalesmanCode],
       [v].[EmpId]
FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
    INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
        ON ([v].[Id] = [x].[POId])
    LEFT OUTER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblSetSalesmanToSalesManager] o 
        ON ([o].[EmployeeNumber] = [v].[EmpId])        
WHERE ([v].[OrderDate] IS NOT NULL)
      AND ([v].[DeliveryDate] IS NOT NULL)
      AND ([v].[CusNum] = @CusNum)
      AND ([v].[DeltoId] = @DeltoId)
      AND ([x].[Barcode] = @Barcode);
";
                this.query = string.Format(this.query, DatabaseName, this.CmbBillTo.SelectedValue, this.CmbDelto.SelectedValue, this.CmbProducts.SelectedValue);
                this.lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (this.lists != null && this.lists.Rows.Count > 0)
                {
                    this.TxtPcsOrder.Text = this.lists.Rows[0]["PcsOrder"] == DBNull.Value ? "" : this.lists.Rows[0]["PcsOrder"].ToString().Trim();
                    this.TxtPackOrder.Text = this.lists.Rows[0]["PackOrder"] == DBNull.Value ? "" : this.lists.Rows[0]["PackOrder"].ToString().Trim();
                    this.TxtCTNOrder.Text = this.lists.Rows[0]["CtnOrder"] == DBNull.Value ? "" : this.lists.Rows[0]["CtnOrder"].ToString().Trim();
                }
            }
            if (rdbcostlowecommerence.Checked)
            {
                query = @"
  DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @vBarcode AS NVARCHAR(MAX) = N'{2}';
                WITH v AS (
	                SELECT N'UNIT.NUMBER' AS Value FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumY = @vBarcode AND ISNULL(v.ProNumY,N'') <> N''
	                UNION ALL
                    SELECT N'PACK.NUMBER' AS Value FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumYP = @vBarcode AND ISNULL(v.ProNumYP,N'') <> N''
	                UNION ALL
                    SELECT N'CASE.NUMBER' AS Value FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumYC = @vBarcode AND ISNULL(v.ProNumYC,N'') <> N''
	                UNION ALL
	                SELECT N'UNIT.NUMBER' AS Value FROM [Stock].[dbo].[TPRProductsDeactivated] AS v WHERE v.ProNumY = @vBarcode AND ISNULL(v.ProNumY,N'') <> N''
	                UNION ALL
                    SELECT N'PACK.NUMBER' AS Value FROM [Stock].[dbo].[TPRProductsDeactivated] AS v WHERE v.ProNumYP = @vBarcode AND ISNULL(v.ProNumYP,N'') <> N''
	                UNION ALL
                    SELECT N'CASE.NUMBER' AS Value FROM [Stock].[dbo].[TPRProductsDeactivated] AS v WHERE v.ProNumYC = @vBarcode AND ISNULL(v.ProNumYC,N'') <> N''
	                UNION ALL
	                SELECT N'UNIT.NUMBER' AS Value FROM [Stock].[dbo].[TPRProductsOldCode] AS v WHERE v.OldProNumy = @vBarcode AND ISNULL(v.OldProNumy,N'') <> N'')
	                SELECT v.*
	            FROM v;
";
            }
            else
            {
                query = @"
 DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @vBarcode AS NVARCHAR(MAX) = N'{2}';
                IF EXISTS(SELECT * FROM [{0}].[dbo].[TblCustomerInputQtyByBarcodeSetting] WHERE [CusNum] = @vCusNum)
                BEGIN
                    IF EXISTS(SELECT * FROM [{0}].[dbo].[TblBarcodeSettingForCustomers] WHERE ([CusNum] = @vCusNum) AND (([UnitNumber] = @vBarcode) OR ([PackNumber] = @vBarcode) OR ([CaseNumber] = @vBarcode)))
                    BEGIN
	                    WITH v AS (
	                        SELECT N'UNIT.NUMBER' AS Value FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumY = @vBarcode AND ISNULL(v.ProNumY,N'') <> N''
	                        UNION ALL
                            SELECT N'PACK.NUMBER' AS Value FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumYP = @vBarcode AND ISNULL(v.ProNumYP,N'') <> N''
	                        UNION ALL
                            SELECT N'CASE.NUMBER' AS Value FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumYC = @vBarcode AND ISNULL(v.ProNumYC,N'') <> N''
	                        UNION ALL
	                        SELECT N'UNIT.NUMBER' AS Value FROM [Stock].[dbo].[TPRProductsDeactivated] AS v WHERE v.ProNumY = @vBarcode AND ISNULL(v.ProNumY,N'') <> N''
	                        UNION ALL
                            SELECT N'PACK.NUMBER' AS Value FROM [Stock].[dbo].[TPRProductsDeactivated] AS v WHERE v.ProNumYP = @vBarcode AND ISNULL(v.ProNumYP,N'') <> N''
	                        UNION ALL
                            SELECT N'CASE.NUMBER' AS Value FROM [Stock].[dbo].[TPRProductsDeactivated] AS v WHERE v.ProNumYC = @vBarcode AND ISNULL(v.ProNumYC,N'') <> N''
	                        UNION ALL
	                        SELECT N'UNIT.NUMBER' AS Value FROM [Stock].[dbo].[TPRProductsOldCode] AS v WHERE v.OldProNumy = @vBarcode AND ISNULL(v.OldProNumy,N'') <> N'')
	                        SELECT v.*
	                    FROM v;
                    END;
                    ELSE
                    BEGIN
	                    SELECT TOP 0 N'' AS Value FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumY = @vBarcode OR v.ProNumYP = @vBarcode OR v.ProNumYC = @vBarcode;
                    END;
                END;
                ELSE
                BEGIN
	                SELECT TOP 0 N'' AS Value FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumY = @vBarcode OR v.ProNumYP = @vBarcode OR v.ProNumYC = @vBarcode;
                END;
";
            }
            query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                string oValue = lists.Rows[0]["Value"] == DBNull.Value ? "" : lists.Rows[0]["Value"].ToString().Trim();
                if (oValue.Equals("UNIT.NUMBER"))
                {
                    this.vIssuePackPrice = false;
                    this.vIssueCasePrice = false;
                    this.TxtPcsOrder.ReadOnly = false;
                    this.TxtCTNOrder.ReadOnly = true;
                    this.TxtPackOrder.ReadOnly = true;
                    this.TxtPcsOrder.Focus();
                }
                else if (oValue.Equals("PACK.NUMBER"))
                {
                    this.vIssuePackPrice = true;
                    this.vIssueCasePrice = false;
                    this.TxtPcsOrder.ReadOnly = true;
                    this.TxtCTNOrder.ReadOnly = true;
                    this.TxtPackOrder.ReadOnly = false;
                    this.TxtPackOrder.Focus();
                }
                else if (oValue.Equals("CASE.NUMBER"))
                {
                    this.vIssuePackPrice = false;
                    this.vIssueCasePrice = true;
                    this.TxtPcsOrder.ReadOnly = true;
                    this.TxtCTNOrder.ReadOnly = false;
                    this.TxtPackOrder.ReadOnly = true;
                    this.TxtCTNOrder.Focus();
                }
                this.TotalAmount();
            }
            if (this.RdbOnlinePO.Checked)
            {
                this.TxtPcsOrder.ReadOnly = true;
                this.TxtCTNOrder.ReadOnly = true;
                this.TxtPackOrder.ReadOnly = true;
            }

            int stockWH = 0;
            string sql = $@"DECLARE @warehouseId UNIQUEIDENTIFIER= CAST('{this.warehouseName.id}' AS UNIQUEIDENTIFIER);
DECLARE @barcode AS NVARCHAR(15) = N'{CmbProducts.SelectedValue}';

WITH locationNotForSellList AS
  (SELECT [id] ,
          [locationid] ,
          [locationname] ,
          [location] ,
          [level] ,
          [createddate],
          N'Not For Sell' [status]
   FROM [DBWarehouses].[dbo].[.tbllocation.not.for.sell])
SELECT SUM([lw].[QtyOnHand]) [stock]
FROM [Stock].[dbo].[TPRWarehouseStockIn] lw
INNER JOIN [Stock].[dbo].[TPRWarehouseLocationName] ln on([lw].[locationid] = [ln].[mainid])
INNER JOIN [DBWarehouses].[dbo].[tblWarehouseName] lh on([ln].[warehouseId] = [lh].[id])
LEFT OUTER JOIN locationNotForSellList ll ON ([ll].[locationid] = [lw].[locationid])
WHERE (([ln].[warehouseId] = @warehouseId)
       AND ([lw].[ProNumy] = @barcode))";
            this.txtStockWarehouse.Text = $"{string.Format("{0:#,##0;(#,##0)}", stockWH)}";
            this.Cursor = Cursors.Default;



        }


        private bool IsCheckPromotion;
        private int oQtyInvoicing;
        private decimal oPromotionId;

        private void TimerCheckPromotion_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CmbProducts.Text)) return;
            TimerCheckPromotion.Enabled = false;
            string lCTNRPcs = "Pcs";
            string Barcode = CmbProducts.SelectedValue.ToString();
            string CusNum = CmbBillTo.SelectedValue.ToString();
            string iMechanic = "";
            string iCusNum = "";
            string iRemark = "";
            decimal iQtyBuy = 0;
            decimal iQtyFree = 0;
            float iDiscount = 0;
            string iBarcodeFree = "";
            string iProNameFree = "";
            string iSizeFree = "";
            string iCode = "";
            DateTime iPeriodTo = Todate;
            bool iIsBuyGroup = false;
            bool lIsBuyInCTN = false;
            decimal iTotalPcsOrder = string.IsNullOrWhiteSpace(TxtTotalPcsOrder.Text) ? 0 : Convert.ToDecimal(TxtTotalPcsOrder.Text.Trim());
            int RQtyFree = 0;
            bool iIsLimited = false;
            decimal iLimitStock = 0;
            decimal iTotalFree = 0;
            decimal iFreeTemp = 0;
            decimal iGroupNum = 0;
            DataTable ilists = null;
            int iQtyPerCase = 0;
            string lPromotionId = "";
            oQtyInvoicing = 0;
            oPromotionId = 0;
            App.ClearController(TxtBarcodeFree, TxtPcsFree, TxtItemDiscount);

            string query = @"
DECLARE @Barcode AS NVARCHAR(MAX) = '{1}';
SELECT @Barcode = ISNULL([ProNumY], N'')
FROM (
    SELECT [ProNumY]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
    UNION ALL
    SELECT B.[OldProNumy] AS [ProNumY]
    FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
    WHERE B.[OldProNumy] = @Barcode
    UNION ALL
    SELECT [ProNumY]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
    UNION ALL
    SELECT B.[OldProNumy] AS [ProNumY]
    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
    WHERE B.[OldProNumy] = @Barcode
) LISTS;

IF (@Barcode = '')
BEGIN
    SELECT TOP 0 * 
    FROM [{0}].[dbo].[TblSuppliers_NoPromotionOrDiscount];
END
ELSE
BEGIN
    SELECT * 
    FROM [{0}].[dbo].[TblSuppliers_NoPromotionOrDiscount] 
    WHERE [SupNum] IN (
        SELECT LEFT([Sup1], 8) AS [SupNum] FROM [Stock].[dbo].[TPRProducts] WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
        UNION ALL
        SELECT LEFT([Sup1], 8) AS [SupNum] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
        UNION ALL
        SELECT LEFT(A.[Sup1], 8) AS [SupNum] FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProID] WHERE B.[OldProNumy] = @Barcode
        UNION ALL
        SELECT LEFT(A.[Sup1], 8) AS [SupNum] FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProID] WHERE B.[OldProNumy] = @Barcode
    );
END
";
            query = string.Format(query, DatabaseName, Barcode);
            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {


                if (lists.Rows.Count > 0)
                {
                    iRemark = "No Promotion/Discount For Supplier";
                    goto Return_Promotion;
                }
                else
                {
                    goto Promotion;
                }
            }
        Promotion:
            query = @"
           
DECLARE @name_ AS NVARCHAR(100) = LTRIM(RTRIM(REPLACE(REPLACE(CONVERT(VARCHAR, GETDATE(), 14), N':', N''), N' ', N''))) + N'_{5}';
DECLARE @query_ AS NVARCHAR(MAX)=  N'
DECLARE @vpickingnumber AS NVARCHAR(10) = N''{2}'';
DECLARE @Barcode AS NVARCHAR(15) = N''{3}'';
DECLARE @oCusNum AS NVARCHAR(8) = N''{4}'';
WITH v
AS (SELECT [ProNumY] [UnitNumber],
           [ProName],
           [ProPacksize],
           [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts]
    UNION ALL
    SELECT B.[OldProNumy] [UnitNumber],
           A.[ProName],
           A.[ProPacksize],
           A.[ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts] AS A
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B
            ON A.[ProID] = B.[ProId]
    UNION ALL
    SELECT [ProNumY] [UnitNumber],
           [ProName],
           [ProPacksize],
           [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    UNION ALL
    SELECT B.[OldProNumy] [UnitNumber],
           A.[ProName],
           A.[ProPacksize],
           A.[ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B
            ON A.[ProID] = B.[ProId])
SELECT v.*
INTO ##vItem_takeorder_' + @name_+ '
FROM v;

WITH v
AS (SELECT i.[Id],
           i.[IsBuyInCTN],
           i.[IsBuyGroup],
           CONVERT(INT, 0) [GroupNum],
           CONVERT(NVARCHAR, i.[Code]) [Barcode],
           i.[QtyBuy],
           i.[Mechanic],
           i.[BarcodeFree],
           i.[CusNum],
           i.[CusName],
           i.[QtyFree],
           i.[Discount],
           i.[CusNumInvolve],
           i.[CusNameInvolve],
           i.[IsLimited],
           i.[LimitedStock],
           i.[QtyInvoicing],
           i.[PromotionId],
           i.[PromotionDesc],
           i.[PeriodFrom],
           i.[PeriodTo]
    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPromotionSetting] i
    WHERE (
              DATEDIFF(DAY, GETDATE(), i.[PeriodFrom]) <= 0
              AND DATEDIFF(DAY, GETDATE(), i.[PeriodTo]) >= 0
          )
          AND (CONVERT(NVARCHAR, i.[Code]) = @Barcode)
    UNION ALL
    SELECT i.[Id],
           i.[IsBuyInCTN],
           i.[IsBuyGroup],
           CONVERT(INT, o.[GroupNumber]) [GroupNum],
           o.[Barcode],
           i.[QtyBuy],
           i.[Mechanic],
           i.[BarcodeFree],
           i.[CusNum],
           i.[CusName],
           i.[QtyFree],
           i.[Discount],
           i.[CusNumInvolve],
           i.[CusNameInvolve],
           i.[IsLimited],
           i.[LimitedStock],
           i.[QtyInvoicing],
           i.[PromotionId],
           i.[PromotionDesc],
           i.[PeriodFrom],
           i.[PeriodTo]
    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPromotionSetting] i
        INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPromotionBarcodeGroupSetting] o
            ON (CONVERT(NVARCHAR, o.[GroupNumber]) = CONVERT(NVARCHAR, i.[Code]))
    WHERE (
              DATEDIFF(DAY, GETDATE(), i.[PeriodFrom]) <= 0
              AND DATEDIFF(DAY, GETDATE(), i.[PeriodTo]) >= 0
          )
          AND (o.[Barcode] = @Barcode))
SELECT v.*
INTO ##promotion_to_' + @name_+ '
FROM v;';
EXECUTE (@query_);

SELECT  @query_ =  N'
DECLARE @vpickingnumber AS NVARCHAR(10) = N''{2}'';
DECLARE @Barcode AS NVARCHAR(15) = N''{3}'';
DECLARE @oCusNum AS NVARCHAR(8) = N''{4}'';
WITH o
AS (SELECT i.[Id],
           i.[IsBuyInCTN],
           i.[IsBuyGroup],
           i.[GroupNum],
           i.[Barcode] [Code],
           CONVERT(NVARCHAR(100), N'''') [Description],
           CONVERT(NVARCHAR(30), N'''') [Size],
           CONVERT(INT, 1) [QtyPerCase],
           i.[QtyBuy],
           i.[Mechanic],
           i.[BarcodeFree],
           CONVERT(NVARCHAR(100), N'''') [ProNameFree],
           CONVERT(NVARCHAR(30), N'''') [SizeFree],
           CONVERT(INT, 1) [QtyPerCaseFree],
           i.[CusNum],
           i.[CusName],
           i.[QtyFree],
           i.[Discount],
           i.[CusNumInvolve],
           i.[CusNameInvolve],
           i.[IsLimited],
           i.[LimitedStock],
           i.[QtyInvoicing],
           i.[PromotionId],
           i.[PromotionDesc],
           i.[PeriodFrom],
           i.[PeriodTo]
    FROM ##promotion_to_' + @name_+ ' i
    WHERE (
              (COALESCE(i.[CusNum], N'''') = @oCusNum)
              OR (COALESCE(i.[CusNumInvolve], N'''') = @oCusNum)
          )
          OR
		  (
			(COALESCE(i.[CusNum], N'''') = N'''')
			 AND (COALESCE(i.[CusNumInvolve], N'''') = N'''')
		  )
    UNION ALL
    SELECT i.[Id],
           i.[IsBuyInCTN],
           i.[IsBuyGroup],
           i.[GroupNum],
           i.[Barcode] [Code],
           CONVERT(NVARCHAR(100), N'''') [Description],
           CONVERT(NVARCHAR(30), N'''') [Size],
           CONVERT(INT, 1) [QtyPerCase],
           i.[QtyBuy],
           i.[Mechanic],
           i.[BarcodeFree],
           CONVERT(NVARCHAR(100), N'''') [ProNameFree],
           CONVERT(NVARCHAR(30), N'''') [SizeFree],
           CONVERT(INT, 1) [QtyPerCaseFree],
           x.[CusNum] [CusNum],
           x.[CusName] [CusName],
           i.[QtyFree],
           i.[Discount],
           i.[CusNumInvolve],
           i.[CusNameInvolve],
           i.[IsLimited],
           i.[LimitedStock],
           i.[QtyInvoicing],
           i.[PromotionId],
           i.[PromotionDesc],
           i.[PeriodFrom],
           i.[PeriodTo]
    FROM ##promotion_to_' + @name_+ ' i
        INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPromotionGroupSetting] x
            ON (CONVERT(NVARCHAR, x.[GroupNumber]) = COALESCE(i.[CusNum], N''''))
    WHERE (COALESCE(x.[CusNum], N'''') = @oCusNum)
    UNION ALL
    SELECT i.[Id],
           i.[IsBuyInCTN],
           i.[IsBuyGroup],
           i.[GroupNum],
           i.[Barcode] [Code],
           CONVERT(NVARCHAR(100), N'''') [Description],
           CONVERT(NVARCHAR(30), N'''') [Size],
           CONVERT(INT, 1) [QtyPerCase],
           i.[QtyBuy],
           i.[Mechanic],
           i.[BarcodeFree],
           CONVERT(NVARCHAR(100), N'''') [ProNameFree],
           CONVERT(NVARCHAR(30), N'''') [SizeFree],
           CONVERT(INT, 1) [QtyPerCaseFree],
           x.[CusNum] [CusNum],
           x.[CusName] [CusName],
           i.[QtyFree],
           i.[Discount],
           i.[CusNumInvolve],
           i.[CusNameInvolve],
           i.[IsLimited],
           i.[LimitedStock],
           i.[QtyInvoicing],
           i.[PromotionId],
           i.[PromotionDesc],
           i.[PeriodFrom],
           i.[PeriodTo]
    FROM ##promotion_to_' + @name_+ ' i
        INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPromotionGroupSetting] x
            ON (CONVERT(NVARCHAR, x.[GroupNumber]) = COALESCE(i.[CusNumInvolve], N''''))
    WHERE (COALESCE(x.[CusNum], N'''') = @oCusNum))
SELECT o.*
INTO ##promotion_takeorder_' + @name_+ '
FROM o;
DROP TABLE ##promotion_to_' + @name_+ ';
';
EXECUTE (@query_);

SELECT  @query_ =  N'
DECLARE @vpickingnumber AS NVARCHAR(10) = N''{2}'';
DECLARE @Barcode AS NVARCHAR(15) = N''{3}'';
DECLARE @oCusNum AS NVARCHAR(8) = N''{4}'';
-- check take order
WITH i
AS (SELECT [takeordernumber]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.picking]
    WHERE ([pickingnumber] = @vpickingnumber)
    GROUP BY [takeordernumber]
    UNION ALL
    SELECT [takeordernumber]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.invoicing]
    WHERE ([pickingnumber] = @vpickingnumber)
    GROUP BY [takeordernumber]
    UNION ALL
    SELECT [takeordernumber]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish]
    WHERE ([pickingnumber] = @vpickingnumber)
    GROUP BY [takeordernumber])
SELECT i.[takeordernumber]
INTO ##to_takeorder_' + @name_
      + N'
FROM i
GROUP BY i.[takeordernumber];
WITH o
AS (SELECT [PromotionIdLink],[QtyInvoicing]
    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPromotionSetting.AllowableInvoicing]
    WHERE [TakeOrderNumber] IN
          (
              SELECT [takeordernumber] FROM ##to_takeorder_' + @name_
      + N'
          )
    UNION ALL
    SELECT [PromotionIdLink],[QtyInvoicing]
    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblProductsPromotionSetting.AllowableInvoicing.Completed]
    WHERE [TakeOrderNumber] IN
          (
              SELECT [takeordernumber] FROM ##to_takeorder_' + @name_
      + N'
          ))
SELECT o.[PromotionIdLink] [Id],SUM(o.[QtyInvoicing]) [QtyInvoicing]
INTO ##allowableinvoicing_takeorder_' + @name_ + N'
FROM o
GROUP BY o.[PromotionIdLink];
DROP TABLE ##to_takeorder_' + @name_
      + N';

DECLARE @id_ as decimal(18,0) = 0;
DECLARE @qtyofinvoicing_ as decimal(18,0) = 0;
DECLARE cur_ CURSOR
FOR 
SELECT o.[Id],SUM(o.[QtyInvoicing]) [QtyInvoicing]
FROM ##allowableinvoicing_takeorder_' + @name_
      + N' o
GROUP BY o.[Id];
OPEN cur_;
fetch next from cur_ into @id_,@qtyofinvoicing_;
while @@FETCH_STATUS = 0
begin
DELETE FROM ##promotion_takeorder_' + @name_
      + N'
WHERE [Id] IN
      (
          @id_
      )
	  and ([QtyInvoicing] <= @qtyofinvoicing_) ;
	  fetch next from cur_ into @id_,@qtyofinvoicing_;
end;
CLOSE cur_;
DEALLOCATE cur_;

DROP TABLE ##allowableinvoicing_takeorder_' + @name_
      + N';
-- end check take order
UPDATE i
SET i.[Description] = x.[ProName],
    i.[Size] = x.[ProPacksize],
    i.[QtyPerCase] = x.[ProQtyPCase]
FROM ##promotion_takeorder_' + @name_+ ' i
    INNER JOIN ##vItem_takeorder_' + @name_+ ' x
        ON (COALESCE(i.[Code], N'''') = COALESCE(x.[UnitNumber], N''''));

UPDATE i
SET i.[ProNameFree] = x.[ProName],
    i.[SizeFree] = x.[ProPacksize],
    i.[QtyPerCaseFree] = x.[ProQtyPCase]
FROM ##promotion_takeorder_' + @name_+ ' i
    INNER JOIN ##vItem_takeorder_' + @name_+ ' x
        ON (COALESCE(i.[BarcodeFree], N'''') = COALESCE(x.[UnitNumber], N''''));


SELECT i.*
FROM ##promotion_takeorder_' + @name_+ ' i
WHERE (COALESCE(i.[Code], N'''') = @Barcode)
      AND
      (
          (COALESCE(i.[CusNum], N'''') = @oCusNum)
          OR (COALESCE(i.[CusNumInvolve], N'''') = @oCusNum)
      )
      OR
	    (
	    (COALESCE(i.[CusNum], N'''') = N'''')
		    AND (COALESCE(i.[CusNumInvolve], N'''') = N'''')
	    )
ORDER BY i.[QtyBuy] DESC,
         i.[IsBuyGroup],
         i.[Id];

DROP TABLE ##vItem_takeorder_' + @name_+ ';
DROP TABLE ##promotion_takeorder_' + @name_+ ';
';
EXECUTE (@query_);
            ";
            query = string.Format(query, DatabaseName, "dry", "", Barcode, CusNum, Data.GetIPAddress.Replace(".", "").Trim());
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {

                foreach (DataRow r in lists.Rows)
                {
                    lPromotionId = r["PromotionDesc"] == DBNull.Value ? "" : r["PromotionDesc"].ToString().Trim();
                    iMechanic = r["Mechanic"] == DBNull.Value ? "" : r["Mechanic"].ToString().Trim();
                    oPromotionId = r["ID"] == DBNull.Value ? 0 : Convert.ToDecimal(r["ID"]);
                    iQtyBuy = r["QtyBuy"] == DBNull.Value ? 0 : Convert.ToDecimal(r["QtyBuy"]);
                    iQtyFree = r["QtyFree"] == DBNull.Value ? 0 : Convert.ToDecimal(r["QtyFree"]);
                    iDiscount = r["Discount"] == DBNull.Value ? 0 : Convert.ToSingle(r["Discount"]);
                    iBarcodeFree = r["barcodeFree"] == DBNull.Value ? "" : r["barcodeFree"].ToString().Trim();
                    iProNameFree = r["ProNameFree"] == DBNull.Value ? "" : r["ProNameFree"].ToString().Trim();
                    iSizeFree = r["SizeFree"] == DBNull.Value ? "" : r["SizeFree"].ToString().Trim();
                    iPeriodTo = r["PeriodTo"] == DBNull.Value ? Todate : Convert.ToDateTime(r["PeriodTo"]);
                    iCode = r["Code"] == DBNull.Value ? "" : r["Code"].ToString().Trim();
                    iIsBuyGroup = r["IsBuyGroup"] == DBNull.Value ? false : Convert.ToBoolean(r["IsBuyGroup"]);
                    lIsBuyInCTN = r["IsBuyInCTN"] == DBNull.Value ? false : Convert.ToBoolean(r["IsBuyInCTN"]);
                    iIsLimited = r["IsLimited"] == DBNull.Value ? false : Convert.ToBoolean(r["IsLimited"]);
                    iLimitStock = r["LimitedStock"] == DBNull.Value ? 0 : Convert.ToDecimal(r["LimitedStock"]);
                    iGroupNum = r["GroupNum"] == DBNull.Value ? 0 : Convert.ToDecimal(r["GroupNum"]);
                    iQtyPerCase = r["QtyPerCase"] == DBNull.Value ? 1 : Convert.ToInt32(r["QtyPerCase"]);
                    oQtyInvoicing = r["QtyInvoicing"] == DBNull.Value ? 0 : Convert.ToInt32(r["QtyInvoicing"]);

                    lCTNRPcs = lIsBuyInCTN ? "CTN" : "Pcs";


                    // Check Exception
                    if (iMechanic.Trim().Equals("Discount And Free") || iMechanic.Trim().Equals("Free") || iMechanic.Trim().Equals("Volume Discount"))
                    {
                        query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
DECLARE @PromotionId AS DECIMAL(18,0) = {2};
SELECT [CusNum]
FROM (
    SELECT B.[CusNum] FROM [{0}].[dbo].[TblProductsPromotionCustomerException] AS A
    INNER JOIN [{0}].[dbo].[TblProductsPromotionGroupSetting] AS B
    ON CONVERT(INT, A.[CusNum]) = B.[GroupNumber] AND ISNUMERIC(A.[CusNum]) > 0
    WHERE B.[CusNum] = @CusNum AND ([PromotionId] IS NOT NULL AND [PromotionId] = @PromotionId)
    UNION ALL
    SELECT B.[CusNum] FROM [{0}].[dbo].[TblProductsPromotionCustomerException] AS A
    INNER JOIN [{0}].[dbo].[TblProductsPromotionGroupSetting] AS B
    ON CONVERT(INT, A.[CusNum]) = B.[GroupNumber] AND ISNUMERIC(A.[CusNum]) > 0
    WHERE B.[CusNum] = @CusNum AND [PromotionId] IS NULL 
    UNION ALL
    SELECT [CusNum] FROM [{0}].[dbo].[TblProductsPromotionCustomerException]
    WHERE ISNUMERIC([CusNum]) = 0 AND [CusNum] = @CusNum AND ([PromotionId] IS NOT NULL AND [PromotionId] = @PromotionId)
    UNION ALL
    SELECT [CusNum] FROM [{0}].[dbo].[TblProductsPromotionCustomerException]
    WHERE ISNUMERIC([CusNum]) = 0 AND [CusNum] = @CusNum AND [PromotionId] IS NULL
) Lists;
";
                        query = string.Format(query, DatabaseName, CusNum, oPromotionId);
                        ilists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                        if (ilists != null && ilists.Rows.Count > 0)
                        {
                            iRemark = "";
                            goto Err_Skip_Step;
                        }
                    }


                    if (iIsBuyGroup && (iMechanic.Trim().Equals("Discount And Free") || iMechanic.Trim().Equals("Discount And Free For Customer") || iMechanic.Trim().Equals("Free") || iMechanic.Trim().Equals("Free For Customer")))
                    {
                        iTotalPcsOrder = 0;
                        iTotalFree = 0;
                        iFreeTemp = 0;
                        if (DeliveryTakeOrderList != null)
                        {
                            foreach (DataRow row in DeliveryTakeOrderList.Rows)
                            {
                                if (Convert.ToDecimal(row["PcsFree"] == DBNull.Value ? 0 : row["PcsFree"]) == 0)
                                {
                                    query = @"
DECLARE @GroupNumber AS INT = {1};
DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
SELECT [Barcode] 
FROM [{0}].[dbo].[TblProductsPromotionBarcodeGroupSetting] 
WHERE [GroupNumber] = @GroupNumber AND [Barcode] = @Barcode;
";
                                    query = string.Format(query, DatabaseName, iGroupNum, row["ProNumy"] == DBNull.Value ? "" : row["ProNumy"].ToString().Trim());
                                    ilists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                                    if (ilists != null && ilists.Rows.Count > 0)
                                    {
                                        if (lIsBuyInCTN)
                                        {
                                            iTotalPcsOrder += Convert.ToDecimal(row["TotalPcsOrder"] == DBNull.Value ? 0 : row["TotalPcsOrder"]) / Convert.ToInt32(row["ProQtyPCase"] == DBNull.Value ? 1 : row["ProQtyPCase"]);
                                        }
                                        else
                                        {
                                            iTotalPcsOrder += Convert.ToDecimal(row["TotalPcsOrder"] == DBNull.Value ? 0 : row["TotalPcsOrder"]);
                                        }
                                        iFreeTemp = 0;
                                    }
                                    else
                                    {
                                        iTotalFree -= iFreeTemp;
                                    }
                                    if (iFreeTemp < 0) iFreeTemp = 0;
                                }
                                iTotalFree += Convert.ToDecimal(row["PcsFree"] == DBNull.Value ? 0 : row["PcsFree"]);
                                iFreeTemp += Convert.ToDecimal(row["PcsFree"] == DBNull.Value ? 0 : row["PcsFree"]);
                                if (iTotalFree > 0)
                                {
                                    if (iTotalPcsOrder >= iQtyBuy)
                                    {
                                        if (lIsBuyInCTN)
                                        {
                                            iTotalPcsOrder -= iQtyBuy * (iTotalFree / iQtyFree);
                                        }
                                        else
                                        {
                                            iTotalPcsOrder -= ((iQtyBuy / iQtyPerCase) * (iTotalFree / iQtyFree)) * iQtyPerCase;
                                        }
                                        iTotalFree = 0;
                                    }
                                }
                            }
                        }
                        if (lIsBuyInCTN)
                        {
                            iTotalPcsOrder += Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtTotalPcsOrder.Text) ? "0" : TxtTotalPcsOrder.Text) / iQtyPerCase;
                        }
                        else
                        {
                            iTotalPcsOrder += Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtTotalPcsOrder.Text) ? "0" : TxtTotalPcsOrder.Text);
                        }

                        if (iTotalPcsOrder <= 0) iTotalPcsOrder = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtTotalPcsOrder.Text) ? "0" : TxtTotalPcsOrder.Text);
                    }

                    // Check Quantity Buy '

                    if (IsCheckPromotion && iTotalPcsOrder < iQtyBuy)
                    {
                        iRemark = "";
                        goto Err_Skip_Step;


                    }
                    // Customer Discount 
                    if (iMechanic.Equals("Customer Discount"))
                    {
                        iCusNum = r["CusNum"] == DBNull.Value ? "" : r["CusNum"].ToString().Trim();
                        if (IsNumeric(iCusNum))
                        {
                            query = @"
                                    DECLARE @GroupNumber AS INT = {1};
                                    DECLARE @CusNum AS NVARCHAR(8) = '{2}';
                                    SELECT [CusNum] 
                                    FROM [{0}].[dbo].[TblProductsPromotionGroupSetting] 
                                    WHERE [GroupNumber] = @GroupNumber AND [CusNum] = @CusNum;
                                    ";
                            query = string.Format(query, DatabaseName, iCusNum, CusNum);
                            ilists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                            if (ilists != null && ilists.Rows.Count > 0)
                            {
                                iCusNum = ilists.Rows[0]["CusNum"] == DBNull.Value ? "" : ilists.Rows[0]["CusNum"].ToString().Trim();
                            }
                        }
                        if (iCusNum.Trim().Equals(CusNum))
                        {
                            if (!IsCheckPromotion)
                            {
                                TxtItemDiscount.Text = iDiscount.ToString();
                                iRemark = "";
                                goto Return_Promotion;
                            }
                            else
                            {
                                iRemark += $"¤ Buy {iQtyBuy} {lCTNRPcs}, discount {iDiscount} %. The end promotion on {iPeriodTo:dd-MMM-yy}{Environment.NewLine}";
                            }
                        }


                    }

                    //  Discouhnt and Free 
                    if (iMechanic.Trim().Equals("Discount And Free"))
                    {
                        if (!IsCheckPromotion)
                        {
                            RQtyFree = (int)(iTotalPcsOrder % iQtyBuy);
                            RQtyFree = (int)((iTotalPcsOrder - RQtyFree) / iQtyBuy);
                            RQtyFree = (int)(RQtyFree * iQtyFree);
                            TxtBarcodeFree.Text = $"{iBarcodeFree}   {iProNameFree}   {iSizeFree}";
                            TxtPcsFree.Text = RQtyFree.ToString();
                            TxtItemDiscount.Text = iDiscount.ToString();
                            iRemark = "";
                            goto Return_Promotion;
                        }
                        else
                        {
                            iRemark += $"¤ Buy {Barcode} ({iQtyBuy} {lCTNRPcs}), free {iBarcodeFree} ({iQtyFree} pcs) & discount ({iDiscount}%). The end promotion on {iPeriodTo:dd-MMM-yy}{Environment.NewLine}";
                        }
                    }

                    // Discount And Free For Customer 
                    if (iMechanic.Trim().Equals("Discount And Free For Customer"))
                    {
                        iCusNum = r["CusNumInvolve"] == DBNull.Value ? "0" : r["CusNumInvolve"].ToString().Trim();
                        if (IsNumeric(iCusNum))
                        {
                            query = @"
                                DECLARE @GroupNumber AS INT = {1};
                                DECLARE @CusNum AS NVARCHAR(8) = '{2}';
                                SELECT [CusNum] 
                                FROM [{0}].[dbo].[TblProductsPromotionGroupSetting] 
                                WHERE [GroupNumber] = @GroupNumber AND [CusNum] = @CusNum;
                                ";
                            query = string.Format(query, DatabaseName, iCusNum, CusNum);
                            ilists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                            if (ilists != null && ilists.Rows.Count > 0)
                            {
                                iCusNum = ilists.Rows[0]["CusNum"] == DBNull.Value ? "" : ilists.Rows[0]["CusNum"].ToString().Trim();
                            }
                        }
                        if (iCusNum.Trim().Equals(CusNum))
                        {
                            if (!IsCheckPromotion)
                            {
                                RQtyFree = (int)(iTotalPcsOrder % iQtyBuy);
                                RQtyFree = (int)((iTotalPcsOrder - RQtyFree) / iQtyBuy);
                                RQtyFree = (int)(RQtyFree * iQtyFree);
                                TxtBarcodeFree.Text = $"{iBarcodeFree}   {iProNameFree}   {iSizeFree}";
                                TxtPcsFree.Text = RQtyFree.ToString();
                                TxtItemDiscount.Text = iDiscount.ToString();
                                iRemark = "";
                                goto Return_Promotion;
                            }
                            else
                            {
                                iRemark += $"¤ Buy {Barcode} ({iQtyBuy} {lCTNRPcs}), free {iBarcodeFree} ({iQtyFree} pcs) & discount ({iDiscount} %). The end promotion on {iPeriodTo:dd-MMM-yy}{Environment.NewLine}";
                            }
                        }
                    }

                    // Frere
                    if (iMechanic.Trim().Equals("Free"))
                    {
                        if (!IsCheckPromotion)
                        {
                            RQtyFree = (int)(iTotalPcsOrder % iQtyBuy);
                            RQtyFree = (int)((iTotalPcsOrder - RQtyFree) / iQtyBuy);
                            RQtyFree = (int)(RQtyFree * iQtyFree);
                            TxtBarcodeFree.Text = $"{iBarcodeFree}   {iProNameFree}   {iSizeFree}";
                            TxtPcsFree.Text = RQtyFree.ToString();
                            iRemark = "";
                            goto Return_Promotion;
                        }
                        else
                        {
                            iRemark += $"¤ Buy {Barcode} ({iQtyBuy} {lCTNRPcs}), free {iBarcodeFree} ({iQtyFree} pcs). The end promotion on {iPeriodTo:dd-MMM-yy}{Environment.NewLine}";
                        }
                    }


                    // Free For Customer 
                    if (iMechanic.Trim().Equals("Free For Customer"))
                    {
                        iCusNum = r["CusNumInvolve"] == DBNull.Value ? "0" : r["CusNumInvolve"].ToString().Trim();
                        if (IsNumeric(iCusNum))
                        {
                            query = @"
                                DECLARE @GroupNumber AS INT = {1};
                                DECLARE @CusNum AS NVARCHAR(8) = '{2}';
                                SELECT [CusNum] 
                                FROM [{0}].[dbo].[TblProductsPromotionGroupSetting] 
                                WHERE [GroupNumber] = @GroupNumber AND [CusNum] = @CusNum;
                                ";
                            query = string.Format(query, DatabaseName, iCusNum, CusNum);
                            ilists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                            if (ilists != null && ilists.Rows.Count > 0)
                            {
                                iCusNum = ilists.Rows[0]["CusNum"] == DBNull.Value ? "" : ilists.Rows[0]["CusNum"].ToString().Trim();
                            }
                        }
                        if (iIsLimited && iLimitStock == 0)
                        {
                            iRemark = "";
                            goto Return_Promotion;
                        }
                        if (string.Equals(iCusNum, CusNum, StringComparison.OrdinalIgnoreCase))
                        {
                            if (!IsCheckPromotion)
                            {
                                RQtyFree = (int)(iTotalPcsOrder % iQtyBuy);
                                RQtyFree = (int)((iTotalPcsOrder - RQtyFree) / iQtyBuy);
                                RQtyFree = (int)(RQtyFree * iQtyFree);
                                TxtBarcodeFree.Text = $"{iBarcodeFree}   {iProNameFree}   {iSizeFree}";
                                TxtPcsFree.Text = RQtyFree.ToString();
                                iRemark = "";
                                goto Return_Promotion;
                            }
                            else
                            {
                                iRemark += $"¤ Buy {Barcode} ({iQtyBuy} {lCTNRPcs}), free {iBarcodeFree} ({iQtyFree} pcs). The end promotion on {iPeriodTo:dd-MMM-yy}{Environment.NewLine}";
                            }
                        }
                    }
                Err_Skip_Step:

                    // Volume Discount

                    if (string.Equals(iMechanic, "Volume Discount", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!IsCheckPromotion)
                        {
                            TxtItemDiscount.Text = iDiscount.ToString();
                            iRemark = "";
                            goto Return_Promotion;
                        }
                        else
                        {
                            iRemark += $"¤ Buy {Barcode} ({iQtyBuy} {lCTNRPcs}), discount ({iDiscount}%). The end promotion on {iPeriodTo:dd-MMM-yy}{Environment.NewLine}";
                        }
                    }


                }


            }
        Return_Promotion:
            if (IsCheckPromotion)
            {
                this.TxtNote.Text = iRemark;
                this.txtpromotionid.Text = lPromotionId;
            }
            this.TxtNote.ForeColor = Color.Black;

            if (this.RdbOnlinePO.Checked)
            {
                string vNote_ = "";
                string vCusNum_ = "";
                if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null)
                {
                    vCusNum_ = "";
                }
                else
                {
                    vCusNum_ = string.IsNullOrWhiteSpace(this.CmbBillTo.Text) ? "" : this.CmbBillTo.SelectedValue.ToString();
                }
                decimal vdeltoid_ = 0;
                if (this.CmbDelto.SelectedValue is DataRowView || this.CmbDelto.SelectedValue == null)
                {
                    vdeltoid_ = 0;
                }
                else
                {
                    vdeltoid_ = string.IsNullOrWhiteSpace(this.CmbDelto.Text) ? 0 : Convert.ToDecimal(this.CmbDelto.SelectedValue);
                }
                string vBarcode_ = "";
                if (this.CmbProducts.SelectedValue is DataRowView || this.CmbProducts.SelectedValue == null)
                {
                    vBarcode_ = "";
                }
                else
                {
                    vBarcode_ = string.IsNullOrWhiteSpace(this.CmbProducts.Text) ? "" : this.CmbProducts.SelectedValue.ToString();
                }

                this.query = @"
                    DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @DeltoId_ AS DECIMAL(18, 0) = {2};
                    DECLARE @vbarcode_ AS NVARCHAR(15) = N'{3}';

                    SELECT [x].*
                    FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
                        INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
                            ON ([v].[Id] = [x].[POId])
                    WHERE ([v].[OrderDate] IS NOT NULL)
                          AND ([v].[DeliveryDate] IS NOT NULL)
                          AND ([v].[CusNum] = @CusNum)
                          AND ([v].[DeltoId] = @DeltoId_)
                          AND ([x].[IsBonus] = 1)
                          AND ([x].[Barcode] = @vbarcode_);
                    ";
                this.query = string.Format(query, DatabaseName, vCusNum_, vdeltoid_, vBarcode_);
                this.lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (this.lists != null && this.lists.Rows.Count > 0)
                {
                    vNote_ = string.Format("សូមយកឌឺឡេថ្ងៃទី{0:dd} ខែ{0:MM} ឆ្នាំ{0:yyyy}", Convert.ToDateTime(this.lists.Rows[0]["expirydate"] == DBNull.Value ? this.Todate : this.lists.Rows[0]["expirydate"]));
                }
                this.TxtNote.Text = string.Format("{0} {1}", vNote_, iRemark);
                this.TxtNote.ForeColor = Color.Red;
            }

        }




        private void check_pending_stock_Tick(object sender, EventArgs e)
        {


            this.check_pending_stock.Enabled = false;

            this.query = @"
DECLARE @RC INT;
DECLARE @barcode_ NVARCHAR(15) = N'{1}';
EXECUTE @RC = [DBPickers].[dbo].[sum_purcashorder] @barcode_;
";

            this.query = string.Format(this.query, DatabaseName, this.CmbProducts.SelectedValue);
            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            lst_check_stock_ = this.db.GetDataTableToObject<cls_check_stock>(this.lists);

            decimal _pending_stock = 0;

            if (lst_check_stock_.Count > 0)
            {
                _pending_stock = lst_check_stock_.Sum(x => x.totalpcsorder);
            }

            this.txtpendingstock.Text = string.Format("{0:N0}", _pending_stock);

        }
        List<cls_check_stock> lst_check_stock_;




        private decimal GetDigitsValue(int Digit)
        {
            string vZero = "";
            decimal value = 1;
            for (int vR = 1; vR <= Digit; vR++)
            {
                vZero += "0";
            }
            value = Convert.ToDecimal(value.ToString() + vZero);
            return value;
        }



        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TxtPONo.Text.Trim()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Please enter the P.O Number!",
                    "Enter P.O Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.TxtPONo.Focus();
                this.TxtPONo.SelectAll();
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.TxtRequiredDate.Text.Trim()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Please select Required Date!",
                    "Select Required Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.TxtRequiredDate.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.CmbBillTo.Text.Trim()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Please select any Bill To!",
                    "Select Bill To",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.CmbBillTo.Focus();
                this.CmbBillTo.SelectAll();
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.CmbDelto.Text.Trim()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Please select any Delto!",
                    "Select Delto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.CmbDelto.Focus();
                this.CmbDelto.SelectAll();
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.CmbSaleman.Text.Trim()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Please select any saleman!",
                    "Select Saleman",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.CmbSaleman.Focus();
                return;
            }
            else
            {
                string sql;
                DataTable tbl;
                int qtyPerCaseFree = 1;

                if (!string.IsNullOrWhiteSpace(this.TxtBarcodeFree.Text.Trim()) &&
                    (Convert.ToInt32(string.IsNullOrWhiteSpace(this.TxtPcsFree.Text.Trim()) ? "0" : this.TxtPcsFree.Text.Trim()) != 0) &&
                    this.switchFree.IsOn)
                {
                    string[] barcodeFree = this.TxtBarcodeFree.Text.Split(new[] { "   " }, StringSplitOptions.None);
                    sql = $@"
DECLARE @Barcode AS NVARCHAR(15) = N'{barcodeFree[0].Trim()}';
SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],[SupNum],[SupName],[ProCat]
FROM (
	SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName],[ProCat]
	FROM [Stock].[dbo].[TPRProducts]
	WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	UNION ALL
	SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName],A.[ProCat]
	FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	WHERE B.[OldProNumy] = @Barcode
    UNION ALL
    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName],[ProCat]
	FROM [Stock].[dbo].[TPRProductsDeactivated]
	WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	UNION ALL
	SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName],A.[ProCat]
	FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	WHERE B.[OldProNumy] = @Barcode
) LISTS;
";

                    tbl = Data.Selects(sql, Initialized.GetConnectionType(Data, App));

                    if (tbl != null && tbl.Rows.Count > 0)
                    {
                        qtyPerCaseFree = Convert.IsDBNull(tbl.Rows[0]["ProQtyPCase"]) ? 1 : Convert.ToInt32(tbl.Rows[0]["ProQtyPCase"]);
                    }
                }


                bool allowManuallyPromotion = false;
                decimal totalPcsOrderTemp = string.IsNullOrWhiteSpace(this.TxtTotalPcsOrder.Text.Trim())
                    ? 0
                    : Convert.ToDecimal(this.TxtTotalPcsOrder.Text.Trim());

                decimal totalPcsFree = string.IsNullOrWhiteSpace(this.TxtPcsFree.Text.Trim())
                    ? 0
                    : Convert.ToDecimal(this.TxtPcsFree.Text.Trim());

                totalPcsFree *= qtyPerCaseFree;

                if (this.warehouseName != null)
                {
                    if (this.warehouseName.allowManuallyPromotion)
                    {
                        allowManuallyPromotion = this.warehouseName.allowManuallyPromotion;
                        totalPcsOrderTemp += totalPcsFree;
                    }
                }

                if (totalPcsOrderTemp == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Please enter the Quantity Order!",
                        "Enter Quantity Order",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.TxtCTNOrder.Focus();
                    this.TxtCTNOrder.SelectAll();
                    return;
                }

                if (allowManuallyPromotion &&
                    (!string.IsNullOrWhiteSpace(this.TxtPcsFree.Text.Trim()) ||
                     !string.IsNullOrWhiteSpace(this.TxtItemDiscount.Text.Trim())))
                {
                    if (string.IsNullOrWhiteSpace(this.cmbPromotionId.Text.Trim()))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Please select any promotion id!",
                            "Select Promotion Id",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        this.cmbPromotionId.Focus();
                        return;
                    }
                }




                if (!this.chknone.Checked)
                {
                    query = @"
DECLARE @vcusnum AS NVARCHAR(8) = N'{1}';
DECLARE @vdeltoid AS DECIMAL(18,0) = {3};
DECLARE @vbarcode AS NVARCHAR(15) = N'{2}';
DECLARE @vponumber AS NVARCHAR(15) = N'{4}';
WITH v AS (
    SELECT [ponumber], [cusnum], [cusname]
    FROM [DBPickers].[dbo].[tbldeliverytakeorders.dry]
    WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([ponumber] = @vponumber)
    GROUP BY [ponumber], [cusnum], [cusname]
    UNION ALL
    SELECT [ponumber], [cusnum], [cusname]
    FROM [DBPickers].[dbo].[tbldeliverytakeorders.dry.picking]
    WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([ponumber] = @vponumber)
    GROUP BY [ponumber], [cusnum], [cusname]
    UNION ALL
    SELECT [ponumber], [cusnum], [cusname]
    FROM [DBPickers].[dbo].[tbldeliverytakeorders.dry.invoicing]
    WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([ponumber] = @vponumber)
    GROUP BY [ponumber], [cusnum], [cusname]
    UNION ALL
    SELECT [ponumber], [cusnum], [cusname]
    FROM [DBPickers].[dbo].[tbldeliverytakeorders.dry.finish]
    WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([ponumber] = @vponumber) AND CONVERT(DATE, [dateorder]) >= CONVERT(DATE, DATEADD(MONTH, -1, GETDATE()))
    GROUP BY [ponumber], [cusnum], [cusname]
    UNION ALL
    SELECT [ponumber], [cusnum], [cusname]
    FROM [DBPickers].[dbo].[tbldeliverytakeorders.dry.finish.deleted]
    WHERE (ISNULL([invnumber], N'') <> N'') AND ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([ponumber] = @vponumber) AND CONVERT(DATE, [dateorder]) >= CONVERT(DATE, DATEADD(MONTH, -1, GETDATE()))
    GROUP BY [ponumber], [cusnum], [cusname]
)
SELECT v.*
FROM v;
";
                    query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue, CmbDelto.SelectedValue, TxtPONo.Text.Replace("'", "").Trim());
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null && lists.Rows.Count > 0)
                    {
                        MessageBox.Show("Please check PO Number again!\nDuplicated PO Number!", "Duplicated PO Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtPONo.SelectionStart = 0;
                        TxtPONo.SelectionLength = TxtPONo.TextLength;
                        TxtPONo.Focus();
                        return;
                    }
                }
                else
                {
                    this.TxtPONo.Text = "N/A";
                }





                // Check Total Pcs History
                query = @"
DECLARE @cusnum_ AS NVARCHAR(8) = N'{1}';
SELECT [Id],
       [CusNum],
       [CusName],
       [CreatedDate]
FROM [DBUNTWHOLESALECOLTD].[dbo].[tbl.customer.no.need.verify.po]
WHERE ([CusNum] = @cusnum_);
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null)
                {
                    if (lists.Rows.Count > 0)
                    {

                        goto err_skip_verify_qty_of_po;
                    }
                }

                query = @"
DECLARE @vcusnum AS NVARCHAR(8) = N'{1}';
DECLARE @vdeltoid AS DECIMAL(18,0) = {3};
DECLARE @vbarcode AS NVARCHAR(15) = N'{2}';
DECLARE @vtotalqty AS DECIMAL(18, 0) = {4};
WITH v
AS (SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.picking]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.invoicing]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish.deleted]
    WHERE (ISNULL([invnumber], N'') <> N'') AND ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.picking]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.invoicing]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.finish]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.finish.deleted]
    WHERE (ISNULL([invnumber], N'') <> N'') AND ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber])
SELECT v.*
INTO #salereport
FROM v;

SELECT YEAR([v].[dateorder]) [year],
       DATENAME(MONTH, [v].[dateorder]) [month],
       MONTH([v].[dateorder]) [month_],
       (SUM([v].[totalpcs]) / COUNT(DAY([v].[dateorder]))) [totalavgpcs],
	   (SUM([v].[totalctn]) / COUNT(DAY([v].[dateorder]))) [totalavgctn]
FROM #salereport v
WHERE ([v].[dateorder] >= (DATEADD(MONTH, -3, GETDATE())))
GROUP BY YEAR([v].[dateorder]),
         DATENAME(MONTH, [v].[dateorder]),
         MONTH([v].[dateorder])
ORDER BY YEAR([v].[dateorder]) DESC,
         MONTH([v].[dateorder]) DESC,
         DATENAME(MONTH, [v].[dateorder]) DESC;

DROP TABLE #salereport;";



                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue, CmbDelto.SelectedValue, Convert.ToDecimal(string.IsNullOrWhiteSpace(this.TxtTotalPcsOrder.Text) ? "0" : this.TxtTotalPcsOrder.Text.Trim()));
                DataTable lst_avg = Data.LoaderData(query);

                query = @"
DECLARE @vcusnum AS NVARCHAR(8) = N'{1}';
DECLARE @vdeltoid AS DECIMAL(18,0) = {3};
DECLARE @vbarcode AS NVARCHAR(15) = N'{2}';
DECLARE @vtotalqty AS DECIMAL(18, 0) = {4};
WITH v
AS (SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.picking]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.invoicing]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish.deleted]
    WHERE (ISNULL([invnumber], N'') <> N'') AND ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.picking]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.invoicing]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.finish]
    WHERE ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname],
           CONVERT(DATE, [dateorder]) [dateorder],
           [takeordernumber],
           [unitnumber],
           SUM([totalpcsorder]) [totalpcs],
           SUM([totalpcsorder] / [qtypercase]) [totalctn]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.finish.deleted]
    WHERE (ISNULL([invnumber], N'') <> N'') AND ([cusnum] = @vcusnum)
          AND ([deltoid] = @vdeltoid)
          AND ([barcode] = @vbarcode)
    GROUP BY [ponumber],
             [cusnum],
             [cusname],
             CONVERT(DATE, [dateorder]),
             [takeordernumber],
             [unitnumber])
SELECT v.*
INTO #salereport
FROM v;

SELECT [v].[dateorder],
       SUM([v].[totalpcs]) [totalpcs],
       SUM([v].[totalctn]) [totalctn]
FROM #salereport v
WHERE ([v].[dateorder] >= (DATEADD(MONTH, -3, GETDATE())))
GROUP BY [v].[dateorder]
ORDER BY [v].[dateorder] DESC;

DROP TABLE #salereport;
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue, CmbDelto.SelectedValue, Convert.ToDecimal(string.IsNullOrWhiteSpace(this.TxtTotalPcsOrder.Text) ? "0" : this.TxtTotalPcsOrder.Text.Trim()));
                DataTable lst = Data.LoaderData(query);

                if (lst != null)
                {
                    if (lst.Rows.Count > 0)
                    {
                        decimal vtotalqty = lst_avg.Rows[0]["totalavgpcs"] == DBNull.Value ? 0 : Convert.ToDecimal(lst_avg.Rows[0]["totalavgpcs"]);
                        decimal vcurorder = string.IsNullOrWhiteSpace(this.TxtTotalPcsOrder.Text) ? 0 : Convert.ToDecimal(this.TxtTotalPcsOrder.Text.Trim());
                        float vpercentage = (float)Math.Ceiling((((vcurorder - vtotalqty) / vcurorder) * 100) * 100) / 100;
                        if (vpercentage > 20)
                        {
                            gui_ws_products_messagebox _gui_ = new gui_ws_products_messagebox { WindowState = FormWindowState.Normal };
                            _gui_.Text = "សូមផ្ទៀងផ្ទាត់ចំនួនកម្ម៉ង់";
                            _gui_.lblmsg.Text = "សូមពិនិត្យមើលការកម្ម៉ង់ ជាមួយអ្នកគ្រប់គ្រងម្តងទៀត...\nពីព្រោះការបញ្ជាទិញចុងក្រោយរបស់អតិថិជនគឺ តែ" + vtotalqty + " Pcs ប៉ុណ្ណោះ។\nតែឥឡូវការបញ្ជាទិញលើសមុន " + vpercentage + "% ។\n\nសូមបញ្ជាក់ថា អ្នកពិតជាបានទាក់ទងទៅអ្នកគ្រប់គ្រងពីបញ្ហនេះហើយ និងចង់បន្តដំណើរការនេះទៅមុខ?( បន្ត/មិនបន្ត )";
                            _gui_.DgvShow.DataSource = lst;
                            _gui_.DgvShow.Refresh();

                            _gui_.dgvavg.DataSource = lst_avg;
                            _gui_.dgvavg.Refresh();
                            if (_gui_.ShowDialog() == DialogResult.No) return;
                            _reason_continue = _gui_.txtreason.Text.Replace("'", "`").Trim();
                        }
                    }
                }
            err_skip_verify_qty_of_po:
                // Check Barcode Setting
                if (this.rdbcostlowecommerence.Checked)
                {
                    // Do nothing
                }
                else
                {
                    query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
IF EXISTS (
    SELECT [ProNumY] FROM [Stock].[dbo].[TPRProducts] WHERE ISNULL([ProNumYP],'') <> '' AND ISNULL([ProNumYP],'') = @Barcode
    UNION ALL
    SELECT [ProNumY] FROM [Stock].[dbo].[TPRProducts] WHERE ISNULL([ProNumYC],'') <> '' AND ISNULL([ProNumYC],'') = @Barcode
    UNION ALL
    SELECT [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE ISNULL([ProNumYC],'') <> '' AND ISNULL([ProNumYC],'') = @Barcode
    UNION ALL
    SELECT [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE ISNULL([ProNumYP],'') <> '' AND ISNULL([ProNumYP],'') = @Barcode)
BEGIN
    SELECT [UnitNumber] AS [ProNumY]
    FROM [{0}].[dbo].[TblBarcodeSettingForCustomers]
    WHERE [CusNum] = @CusNum AND [UnitNumber] IN (
        SELECT [ProNumY] FROM [Stock].[dbo].[TPRProducts] WHERE ISNULL([ProNumYP],'') <> '' AND ISNULL([ProNumYP],'') = @Barcode
        UNION ALL
        SELECT [ProNumY] FROM [Stock].[dbo].[TPRProducts] WHERE ISNULL([ProNumYC],'') <> '' AND ISNULL([ProNumYC],'') = @Barcode
        UNION ALL
        SELECT [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE ISNULL([ProNumYC],'') <> '' AND ISNULL([ProNumYC],'') = @Barcode
        UNION ALL
        SELECT [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE ISNULL([ProNumYP],'') <> '' AND ISNULL([ProNumYP],'') = @Barcode);
END
ELSE
BEGIN
    SELECT [ProNumY] FROM [Stock].[dbo].[TPRProducts] WHERE (ISNULL([ProNumY],'') <> '' AND ISNULL([ProNumY],'') = @Barcode) 
    UNION ALL
    SELECT [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE (ISNULL([ProNumY],'') <> '' AND ISNULL([ProNumY],'') = @Barcode)
    UNION ALL
    SELECT [OldProNumy] AS [ProNumY] FROM [Stock].[dbo].[TPRProductsOldCode] WHERE ISNULL([OldProNumy],'') <> '' AND ISNULL([OldProNumy],'') = @Barcode
END
";
                    query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null)
                    {
                        if (lists.Rows.Count <= 0)
                        {

                            MessageBox.Show("The barcode is Pack Number/Case Number.\nPlease set barcode for customer!", "Set Barcode For Customer First", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CmbProducts.SelectionStart = 0;
                            CmbProducts.SelectionLength = CmbProducts.Text.Length;
                            CmbProducts.Focus();
                            return;
                        }
                    }

                }



                // Check TakeOrder
                int iAllowDay = 2;
                bool iExisted = false;
                string Msg = "";
                int iIndex = 1;
                int iHours = 0;
                string iPONumber = "";
                query = @"
DECLARE @vcusnum AS NVARCHAR(8) = N'{1}';
DECLARE @vdeltoid AS DECIMAL(18,0) = {3};
DECLARE @vbarcode AS NVARCHAR(15) = N'{2}';
DECLARE @vtotalpcsorder AS DECIMAL(18,0) = {4};
WITH v AS (
    SELECT [ponumber], [cusnum], [cusname], [takeordernumber] [TakeOrderInvoiceNumber], [dateorder] [DateOrd], DATEDIFF(DAY, [dateorder], GETDATE()) AS [NumberOfOrder]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry]
    WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([totalpcsorder] = @vtotalpcsorder)
    GROUP BY [ponumber], [cusnum], [cusname], [takeordernumber], [dateorder], DATEDIFF(DAY, [dateorder], GETDATE())
    UNION ALL
    SELECT [ponumber], [cusnum], [cusname], [takeordernumber] [TakeOrderInvoiceNumber], [dateorder] [DateOrd], DATEDIFF(DAY, [dateorder], GETDATE()) AS [NumberOfOrder]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.picking]
    WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([totalpcsorder] = @vtotalpcsorder)
    GROUP BY [ponumber], [cusnum], [cusname], [takeordernumber], [dateorder], DATEDIFF(DAY, [dateorder], GETDATE())
    UNION ALL
    SELECT [ponumber], [cusnum], [cusname], [takeordernumber] [TakeOrderInvoiceNumber], [dateorder] [DateOrd], DATEDIFF(DAY, [dateorder], GETDATE()) AS [NumberOfOrder]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.invoicing]
    WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([totalpcsorder] = @vtotalpcsorder)
    GROUP BY [ponumber], [cusnum], [cusname], [takeordernumber], [dateorder], DATEDIFF(DAY, [dateorder], GETDATE())
    UNION ALL
    SELECT [ponumber], [cusnum], [cusname], [takeordernumber] [TakeOrderInvoiceNumber], [dateorder] [DateOrd], DATEDIFF(DAY, [dateorder], GETDATE()) AS [NumberOfOrder]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish]
    WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([totalpcsorder] = @vtotalpcsorder)
    GROUP BY [ponumber], [cusnum], [cusname], [takeordernumber], [dateorder], DATEDIFF(DAY, [dateorder], GETDATE())
    UNION ALL
    SELECT [ponumber], [cusnum], [cusname], [takeordernumber] [TakeOrderInvoiceNumber], [dateorder] [DateOrd], DATEDIFF(DAY, [dateorder], GETDATE()) AS [NumberOfOrder]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish.deleted]
    WHERE (ISNULL([invnumber], N'') <> N'') AND ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([totalpcsorder] = @vtotalpcsorder)
    GROUP BY [ponumber], [cusnum], [cusname], [takeordernumber], [dateorder], DATEDIFF(DAY, [dateorder], GETDATE())
)
SELECT v.*
FROM v;
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue, CmbDelto.SelectedValue, Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtTotalPcsOrder.Text) ? "0" : TxtTotalPcsOrder.Text.Trim()));
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null && lists.Rows.Count > 0)
                {
                    iPONumber = lists.Rows[0]["ponumber"] == DBNull.Value ? "" : lists.Rows[0]["ponumber"].ToString().Trim();
                    foreach (DataRow r in lists.Rows)
                    {
                        Msg += $"{iIndex}). Take Order " +
           $"{(r["TakeOrderInvoiceNumber"] == DBNull.Value ? string.Empty : r["TakeOrderInvoiceNumber"].ToString().Trim())} " +
           $"On {((r["DateOrd"] == DBNull.Value ? Todate : Convert.ToDateTime(r["DateOrd"])).ToString("dd - MMM - yyyy"))}\n";

                        iIndex++;
                        iHours = r["NumberOfOrder"] == DBNull.Value ? 1 : Convert.ToInt32(r["NumberOfOrder"]);
                        iHours *= 24;
                        iExisted = true;
                    }
                }
                if (iExisted)
                {
                    if (iHours <= 72)
                    {
                        if (this.chkgenerate.Checked && TxtPONo.Text.Replace("'", "").Trim().Equals(iPONumber.Trim()))
                        {
                            MessageBox.Show($"Please check this take order again!\nThe Take Order is existed!\n{Msg}", "Duplicated Take Order", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        else
                        {
                            MessageBox.Show($"Please check this take order again!\nThe Take Order is existed!\n{Msg}", "Duplicated Take Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    iAllowDay = 2;
                    iExisted = false;
                    Msg = "";
                    iIndex = 1;
                    iHours = 0;
                    iPONumber = "";
                    query = @" DECLARE @vcusnum AS NVARCHAR(8) = N'{1}';
                                DECLARE @vdeltoid AS DECIMAL(18,0) = {3};
                                DECLARE @vbarcode AS NVARCHAR(15) = N'{2}';
                                DECLARE @vtotalpcsorder AS DECIMAL(18,0) = {4};
                                WITH v AS (	                                
	                                SELECT [ponumber],[cusnum],[cusname],[takeordernumber] [TakeOrderInvoiceNumber],[dateorder] [DateOrd],DATEDIFF(DAY,[dateorder],GETDATE()) AS [NumberOfOrder] 
	                                FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish]
	                                WHERE ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([totalpcsorder] = @vtotalpcsorder) AND CONVERT(DATE,[dateorder]) >= CONVERT(DATE,DATEADD(MONTH,-1,GETDATE()))
	                                GROUP BY [ponumber],[cusnum],[cusname],[takeordernumber],[dateorder],DATEDIFF(DAY,[dateorder],GETDATE())
                                    UNION ALL
                                    SELECT [ponumber],[cusnum],[cusname],[takeordernumber] [TakeOrderInvoiceNumber],[dateorder] [DateOrd],DATEDIFF(DAY,[dateorder],GETDATE()) AS [NumberOfOrder] 
	                                FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish.deleted]
	                                WHERE (ISNULL([invnumber], N'') <> N'') AND ([cusnum] = @vcusnum) AND ([deltoid] = @vdeltoid) AND ([barcode] = @vbarcode) AND ([totalpcsorder] = @vtotalpcsorder) AND CONVERT(DATE,[dateorder]) >= CONVERT(DATE,DATEADD(MONTH,-1,GETDATE()))
	                                GROUP BY [ponumber],[cusnum],[cusname],[takeordernumber],[dateorder],DATEDIFF(DAY,[dateorder],GETDATE())
                                )
                                SELECT v.*
                                FROM v;";

                    query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue, CmbDelto.SelectedValue, Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtTotalPcsOrder.Text) ? "0" : TxtTotalPcsOrder.Text.Trim()));
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null && lists.Rows.Count > 0)
                    {
                        iPONumber = lists.Rows[0]["ponumber"] == DBNull.Value ? "" : lists.Rows[0]["ponumber"].ToString().Trim();
                        foreach (DataRow r in lists.Rows)
                        {
                            Msg += iIndex + "). Take Order " + (r["TakeOrderInvoiceNumber"] == DBNull.Value ? "" : r["TakeOrderInvoiceNumber"].ToString().Trim()) + " On " + string.Format("{0:dd-MMM-yyyy}", r["DateOrd"] == DBNull.Value ? Todate : Convert.ToDateTime(r["DateOrd"])) + "\n";
                            iIndex++;
                            iHours = lists.Rows[0]["NumberOfOrder"] == DBNull.Value ? 1 : Convert.ToInt32(lists.Rows[0]["NumberOfOrder"]);
                            iHours *= 24;
                            iExisted = true;
                        }
                    }
                    if (iExisted)
                    {
                        if (iHours <= 48)
                        {
                            if (TxtPONo.Text.Replace("'", "").Trim().Equals(iPONumber.Trim()))
                            {
                                //if (XtraMessageBox.Show("Please check this take order <Finish Already> again!\nThe Take Order <Finish Already> is existed!\n" + Msg, "Duplicated Take Order <Finish Already>", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                                //Initialized.R_CorrectPassword = false;
                                //FrmPasswordContinues of2 = new FrmPasswordContinues();
                                //of2.R_PasswordPermission = "'Managing Director','MD Assistant','IT Manager','Office Manager'";
                                //of2.ShowDialog();
                                //if (!Initialized.R_CorrectPassword) return;
                                MessageBox.Show("Please check this take order <Finish Already> again!\nThe Take Order <Finish Already> is existed!\n" + Msg, "Duplicated Take Order <Finish Already>", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Please check this take order <Finish Already> again!\nThe Take Order <Finish Already> is existed!\n" + Msg, "Duplicated Take Order <Finish Already>", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }












                //   'Begin Check Division
                //  REM Check Division
                string vDivision = "1";
                query = @"
DECLARE @Barcode_ AS NVARCHAR(15) = N'{1}';
WITH s
AS (SELECT LEFT(v.Sup1, 8) [SupNum]
    FROM [Stock].[dbo].[TPRProducts] v
    WHERE (
              (v.[ProNumY] = @Barcode_)
              OR (v.[ProNumYP] = @Barcode_)
              OR (v.[ProNumYC] = @Barcode_)
          )
    GROUP BY LEFT(v.Sup1, 8)
    UNION ALL
    SELECT LEFT(v.Sup1, 8) [SupNum]
    FROM [Stock].[dbo].[TPRProductsDeactivated] v
    WHERE (
              (v.[ProNumY] = @Barcode_)
              OR (v.[ProNumYP] = @Barcode_)
              OR (v.[ProNumYC] = @Barcode_)
          )
    GROUP BY LEFT(v.Sup1, 8)
    UNION ALL
    SELECT LEFT(v.Sup1, 8) [SupNum]
    FROM [Stock].[dbo].[TPRProducts] v
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] x
            ON x.ProId = v.ProID
    WHERE (x.[OldProNumy] IN ( @Barcode_ ))
    GROUP BY LEFT(v.Sup1, 8)
    UNION ALL
    SELECT LEFT(v.Sup1, 8) [SupNum]
    FROM [Stock].[dbo].[TPRProductsDeactivated] v
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] x
            ON x.ProId = v.ProID
    WHERE (x.[OldProNumy] IN ( @Barcode_ ))
    GROUP BY LEFT(v.Sup1, 8))
SELECT s.*
INTO #vsupplier
FROM s;

SELECT v.GroupName
FROM [Stock].[dbo].[TPRMap_SupplierToDelivery] v
WHERE (v.SupNum IN
       (
           SELECT o.SupNum FROM #vsupplier o GROUP BY o.SupNum
       )
      )
GROUP BY v.GroupName;

DROP TABLE #vsupplier;
";
                query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));


                if (lists != null)
                {
                    if (lists.Rows.Count > 0)
                    {
                        vDivision = lists.Rows[0]["GroupName"] == DBNull.Value ? "" : lists.Rows[0]["GroupName"].ToString().Trim();
                    }
                }
                if (vIsCustomerNoVATTinIntoDivisionVAT)
                {
                    vDivision = "DIVISION 13 VAT";
                }
                else
                {

                    if (vDivision.Trim().Equals("1"))
                    {
                        vDivision = CusVAT.Trim().Equals("") ? "DIVISION 1" : "DIVISION 1 VAT";
                    }
                    else if (vDivision.Trim().Equals("MK") || vDivision.Trim().Equals("2"))
                    {
                        vDivision = CusVAT.Trim().Equals("") ? "DIVISION 2" : "DIVISION 2 VAT";
                    }
                    else if (vDivision.Trim().Equals("LF") || vDivision.Trim().Equals("4"))
                    {
                        vDivision = CusVAT.Trim().Equals("") ? "DIVISION 4" : "DIVISION 4 VAT";
                    }
                    else
                    {
                        vDivision = CusVAT.Trim().Equals("") ?
                            string.Format("DIVISION {0}", Convert.ToDecimal(vDivision.Replace("Division", "").Replace("DIVISION", "").Trim())) :
                            string.Format("DIVISION {0} VAT", Convert.ToDecimal(vDivision.Replace("Division", "").Replace("DIVISION", "").Replace("VAT", "").Replace("vat", "").Trim()));
                    }
                }


                // End Check Division
                if (allowManuallyPromotion == true)
                {
                    if (Convert.ToDecimal(string.IsNullOrWhiteSpace(this.TxtTotalPcsOrder.Text.Trim()) ? "0" : this.TxtTotalPcsOrder.Text.Trim()) == 0
                        && Convert.ToDecimal(string.IsNullOrWhiteSpace(this.TxtPcsFree.Text.Trim()) ? "0" : this.TxtPcsFree.Text.Trim()) != 0)
                    {
                        goto manually_Promotion;
                    }
                }





                if (DeliveryTakeOrderList != null)
                {
                    string vBarcode = CmbProducts.SelectedValue.ToString();
                    // For Each vRow As DataRow In DeliveryTakeOrderList.Rows
                    //     If Trim(IIf(IsDBNull(vRow("Barcode")) = True, "", vRow("Barcode"))).Equals(vBarcode) = True Then
                    //         XtraMessageBox.Show("Please check the barcode again!", "Duplicated Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    //         Exit Sub
                    //     End If
                    // Next
                    var barcodeSelected = (from DataRow lx in DeliveryTakeOrderList.Rows.Cast<DataRow>()
                                           where (lx["Barcode"] == DBNull.Value ? "" : lx["Barcode"].ToString().Trim()).Equals(vBarcode)
                                           select lx["Barcode"].ToString()).Distinct().ToArray();
                    if (barcodeSelected.ToList().Count > 0)
                    {
                        MessageBox.Show("Please check the barcode again!", "Duplicated Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    query = @"
DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
SELECT [Id],[CusNum],[CusName],[CreatedDate]
FROM [{0}].[dbo].[TblCustomerSetting_SpecialInvoices]
WHERE ( [CusNum] = @CusNum );
";
                    query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue);
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null && lists.Rows.Count > 0) goto Err_Skip_SpecialInvoice;
                }
            Err_Skip_SpecialInvoice:
                if (TxtKhmerName.Text.Trim() == "")
                {
                    MessageBox.Show("Please, set delTo in khmer language.\nBefore continue...", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbDelto.Focus();
                    return;
                }


















                // Check Credit Amount
                if (!IsDutchmill)
                {
                    double lGAmount = string.IsNullOrWhiteSpace(TxtTotalAmount.Text) ? 0 : Convert.ToDouble(TxtTotalAmount.Text.Trim());
                    // For Each vRow As DataRow In DeliveryTakeOrderList.Rows
                    //     lGAmount += CDbl(IIf(IsDBNull(vRow("TotalAmount")) = True, 0, vRow("TotalAmount")))
                    // Next
                    double lTotalAmount = DeliveryTakeOrderList.Rows.Cast<DataRow>().Sum(lu => Convert.ToDouble(lu["TotalAmount"]));
                    lGAmount += lTotalAmount;
                    if (!CheckCreditAmountCustomer(CmbBillTo.SelectedValue.ToString(), lGAmount, true)) return;
                }
                query = @"
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
SELECT * 
FROM [Stock].[dbo].[TPRCustomerDiscontinueSKU]
WHERE [CusNum] = @CusNum AND [Barcode] = @Barcode;
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null && lists.Rows.Count > 0)
                {
                    MessageBox.Show("This customer has notify UNT of discontinue already!", "Discontinue Selling By Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Not allow when stock smaller than reserve for special customer
                query = @"
DECLARE @Barcode AS NVARCHAR(MAX) = '{1}';
DECLARE @QtyReserve AS INT = 0;
DECLARE @QtyOnHand AS INT = 0;
DECLARE @QtyPerCase AS INT = 1;

SELECT @QtyPerCase = ISNULL([ProQtyPCase],1)
FROM (
    SELECT [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE ISNULL([ProNumY],'') = @Barcode AND ISNULL([ProNumYP],'') = @Barcode AND ISNULL([ProNumYC],'') = @Barcode
    UNION ALL
    SELECT [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE ISNULL([ProNumY],'') = @Barcode AND ISNULL([ProNumYP],'') = @Barcode AND ISNULL([ProNumYC],'') = @Barcode
    UNION ALL
    SELECT [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON B.[ProId] = A.[ProID]
    WHERE ISNULL(B.[OldProNumy],'') = @Barcode
    UNION ALL
    SELECT [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON B.[ProId] = A.[ProID]
    WHERE ISNULL(B.[OldProNumy],'') = @Barcode
) LISTS
GROUP BY [ProQtyPCase];
SELECT @QtyReserve = SUM([CTNQtyReserve]) FROM [Stock].[dbo].[TPRMap_ProductReserveForSpecialCustomer] WHERE [ProNumy] = @Barcode;
SELECT @QtyOnHand = SUM([QtyOnHand]) FROM [Stock].[dbo].[TPRWarehouseStockIn] WHERE [ProNumy] = @Barcode;
SELECT CASE WHEN @QtyOnHand <= (@QtyReserve * @QtyPerCase) THEN 'NOT ENOUGH' ELSE 'ENOUGH' END AS [Result];
";
                query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null && lists.Rows.Count > 0)
                {
                    string Result = lists.Rows[0]["Result"] == DBNull.Value ? "" : lists.Rows[0]["Result"].ToString().Trim();
                    if (Result.Trim().Equals("NOT ENOUGH"))
                    {
                        Initialized.R_CorrectPassword = false;
                        FrmPasswordContinues ofrm999_ = new FrmPasswordContinues();
                        ofrm999_.R_PasswordPermission = "'Managing Director','MD Assistant','IT Manager','Office Manager'";
                        ofrm999_.ShowDialog();
                        if (!Initialized.R_CorrectPassword) return;
                    }
                }
                if (this.rdbcostlowecommerence.Checked)
                {
                    goto WSFixedPrice_Final;
                }

                // not allow to go ahead when no special code
                query = @"
    DECLARE @CusNum AS NVARCHAR(8) = '{1}';
    DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
    
    SELECT @Barcode = [Barcode]
    FROM (
        SELECT ISNULL([ProNumY],'') AS [Barcode] FROM [Stock].[dbo].[TPRProducts] WHERE ISNULL([ProNumY],'') <> '' AND ISNULL([ProNumY],'') = @Barcode
        UNION ALL
        SELECT ISNULL([ProNumYP],'') AS [Barcode] FROM [Stock].[dbo].[TPRProducts] WHERE ISNULL([ProNumYP],'') <> '' AND ISNULL([ProNumYP],'') = @Barcode
        UNION ALL
        SELECT ISNULL([ProNumYC],'') AS [Barcode] FROM [Stock].[dbo].[TPRProducts] WHERE ISNULL([ProNumYC],'') <> '' AND ISNULL([ProNumYC],'') = @Barcode
        UNION ALL
        SELECT ISNULL([ProNumY],'') AS [Barcode] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE ISNULL([ProNumY],'') <> '' AND ISNULL([ProNumY],'') = @Barcode
        UNION ALL
        SELECT ISNULL([ProNumYP],'') AS [Barcode] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE ISNULL([ProNumYP],'') <> '' AND ISNULL([ProNumYP],'') = @Barcode
        UNION ALL
        SELECT ISNULL([ProNumYC],'') AS [Barcode] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE ISNULL([ProNumYC],'') <> '' AND ISNULL([ProNumYC],'') = @Barcode
        UNION ALL
        SELECT B.[OldProNumy] AS [Barcode] FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId] WHERE B.[OldProNumy] = @Barcode
        UNION ALL
        SELECT B.[OldProNumy] AS [Barcode] FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId] WHERE B.[OldProNumy] = @Barcode
    ) lists;

    IF EXISTS (SELECT * FROM [{0}].[dbo].[TblCustomerCodes] WHERE [CusNum] = @CusNum)
    BEGIN
        SELECT * 
        FROM [{0}].[dbo].[TblCustomerCodes]
        WHERE [CusNum] = @CusNum AND [Barcode] = @Barcode;
    END
    ELSE
    BEGIN
        SELECT * 
        FROM [{0}].[dbo].[TblCustomerCodes];
    END
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null)
                {
                    if (lists.Rows.Count > 0)
                    {
                        // Do something with the lists
                    }
                    else
                    {

                        Goto Err_msg;
                    }
                }
                else
                {
                Err_msg:
                    // if (XtraMessageBox.Show("Need Add special code first." + Environment.NewLine + "Do you want to go ahead?(Yes/No)", "Need Special Code", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    MessageBox.Show("Need Add special code first." + Environment.NewLine + "Please contact to Office Manager...", "Not Allow To Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }






















                // Fixed Prices
                query = @"
    DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
    DECLARE @Barcode AS NVARCHAR(MAX) = N'{2}';
    SELECT v.[ByinPrice], v.[WSPrice]
    FROM [{0}].[dbo].[TblProductsPriceSetting] AS v
    LEFT OUTER JOIN [{0}].[dbo].[TblFixedPriceCustomerGroupSetting] AS o ON ISNULL(v.[GroupNumber], 0) = ISNULL(o.[GroupNumber], 0)
    WHERE (DATEDIFF(DAY, GETDATE(), v.[PeriodFrom]) <= 0 AND DATEDIFF(DAY, GETDATE(), v.[PeriodTo]) >= 0) 
    AND (ISNULL(v.[CusNum], o.[CusNum]) = @CusNum) AND v.[Barcode] = @Barcode;
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null)
                {
                    if (lists.Rows.Count > 0)
                    {
                        if (Convert.ToDouble(Convert.IsDBNull(lists.Rows[0]["WSPrice"]) ? 0 : lists.Rows[0]["WSPrice"]) == Convert.ToDouble(string.IsNullOrWhiteSpace(TxtWSPrice.Text.Trim()) ? "0" : TxtWSPrice.Text.Trim()))
                        {
                            goto WSFixedPrice_Final;
                        }
                    }

                }







                // Check 1wk pricing
                DataTable ProductList = null;
                DataTable ProductList1Week = null;
                bool IsProductListExisted = false;
                bool IsProductList1WeekExisted = false;
                query = @"
UPDATE x
SET [x].[ProUPriSeH] = N'0.00      '
FROM [Stock].[dbo].[TPRWSCusProductList] x
WHERE (RTRIM(LTRIM([x].[ProUPriSeH])) = N'');
UPDATE x
SET [x].[ProUPriSeH] = N'0.00      '
FROM [Stock].[dbo].[TPRWSCusProductList1Week] x
WHERE (RTRIM(LTRIM([x].[ProUPriSeH])) = N'');
DECLARE @CusNum AS NVARCHAR(8) = '{1}';
DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
SELECT @Barcode = [ProNumY]
FROM (
    SELECT [ProNumY] FROM [Stock].[dbo].[TPRProducts] WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
    UNION ALL
    SELECT [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
    UNION ALL
    SELECT B.[OldProNumy] AS [ProNumY] FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId] WHERE B.[OldProNumy] = @Barcode
    UNION ALL
    SELECT B.[OldProNumy] AS [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId] WHERE B.[OldProNumy] = @Barcode
) lists;
SELECT * 
FROM [Stock].[dbo].[TPRWSCusProductList] 
WHERE [Cusnum] = @CusNum AND [ProNumY] = @Barcode;
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                ProductList = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (ProductList != null)
                {
                    if (ProductList.Rows.Count > 0) IsProductListExisted = true;
                }


                query = @"
    DECLARE @CusNum AS NVARCHAR(8) = '{1}';
    DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
    SELECT @Barcode = [ProNumY]
    FROM (
        SELECT [ProNumY] FROM [Stock].[dbo].[TPRProducts] WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
        UNION ALL
        SELECT [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
        UNION ALL
        SELECT B.[OldProNumy] AS [ProNumY] FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId] WHERE B.[OldProNumy] = @Barcode
        UNION ALL
        SELECT B.[OldProNumy] AS [ProNumY] FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId] WHERE B.[OldProNumy] = @Barcode
    ) lists;
    SELECT * 
    FROM [Stock].[dbo].[TPRWSCusProductList1Week] 
    WHERE [Cusnum] = @CusNum AND [ProNumY] = @Barcode;
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                ProductList1Week = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (ProductList1Week != null)
                {
                    if (ProductList1Week.Rows.Count > 0) IsProductList1WeekExisted = true;
                }

                double vDeliveryLogistic = 0;
                if (vAdditionalCost)
                {
                    query = @"
        DECLARE @vBarcode AS NVARCHAR(MAX) = N'{1}';
        DECLARE @vCity AS NVARCHAR(100) = N'{2}';
        SELECT ISNULL([DeliveryCost], 0) AS [DeliveryCost] 
        FROM [{0}].[dbo].[TblProductsDeliveryLogistic] 
        WHERE [ProId] IN (
            SELECT [ProID] FROM [Stock].[dbo].[TPRProducts] WHERE (ISNULL([ProNumY], '') = @vBarcode OR ISNULL([ProNumYP], '') = @vBarcode OR ISNULL([ProNumYC], '') = @vBarcode)
            UNION ALL
            SELECT [ProId] FROM [Stock].[dbo].[TPRProductsOldCode] WHERE [OldProNumy] = @vBarcode
        ) 
        AND [City] = @vCity;
    ";
                    query = string.Format(query, DatabaseName, CmbProducts.SelectedValue, vCity);
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null)
                    {
                        if (lists.Rows.Count > 0)
                        {
                            vDeliveryLogistic = Convert.ToDouble(lists.Rows[0]["DeliveryCost"] == DBNull.Value ? 0 : lists.Rows[0]["DeliveryCost"]);
                            if (vDeliveryLogistic == 0)
                            {
                                Goto Err_CheckAdditionalCost;
                            }
                            this.BtnAdd.Enabled = true;
                        }
                        else
                        {
                            Goto Err_CheckAdditionalCost;
                        }
                    }
                    else
                    {
                    Err_CheckAdditionalCost:
                        DevExpress.XtraEditors.XtraMessageBox.Show("Please check Additional Cost of product for this customer first!" + Environment.NewLine + "Please contact to Administrator.", "Not Allow To Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;
                        this.BtnAdd.Enabled = false;
                        return;
                    }
                }
                double iWSAfter = Convert.ToDouble(string.IsNullOrWhiteSpace(this.TxtWSPrice.Text.Trim()) ? "0" : this.TxtWSPrice.Text.Trim());
                double iWSCurrent = 0;
                double iWS1WKCurrent = 0;
                DateTime iDate = Todate;
                DateTime i1WKDate = Todate;
                int iQtyPerCase = 1;

                if (!IsProductListExisted && !IsProductList1WeekExisted)
                {
                    MessageBox.Show("No price was set for this customer.", "Wholesale Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (IsProductListExisted && IsProductList1WeekExisted)
                {
                    iWSCurrent = Math.Round((Convert.ToDouble(ProductList.Rows[0].IsNull("ProUPriSeH") ? 0 : ProductList.Rows[0]["ProUPriSeH"]) + vServiceCost + vDeliveryLogistic), 2);
                    iDate = (ProductList.Rows[0].IsNull("Date") ? Todate : Convert.ToDateTime(ProductList.Rows[0]["Date"]));
                    iQtyPerCase = ProductList.Rows[0].IsNull("ProQtyPCase") ? 1 : Convert.ToInt32(ProductList.Rows[0]["ProQtyPCase"]);
                    iWS1WKCurrent = Math.Round((Convert.ToDouble(ProductList1Week.Rows[0].IsNull("ProUPriSeH") ? 0 : ProductList1Week.Rows[0]["ProUPriSeH"]) + vServiceCost + vDeliveryLogistic), 2);
                    i1WKDate = (ProductList1Week.Rows[0].IsNull("Date") ? Todate : Convert.ToDateTime(ProductList1Week.Rows[0]["Date"]));

                    if (iWSAfter != iWSCurrent && iWSCurrent != iWS1WKCurrent && iWSAfter != iWS1WKCurrent)
                    {
                        XtraMessageBox.Show(
                            "Last Updated price in one week was on '" + i1WKDate.ToString("dd-MMM-yyyy") + "' for this customer is " +
                            string.Format("{0:N2}", iWS1WKCurrent) + "/" + iQtyPerCase + " PCS." + Environment.NewLine +
                            "New current price is " + iWSAfter + "/" + iQtyPerCase + " PCS and your last update price was on '" +
                            iDate.ToString("dd-MMM-yyyy") + "' is " + iWSCurrent + "/" + iQtyPerCase + " PCS." + Environment.NewLine +
                            "Please to go update price first.", "Not Allow Continue", MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                        return;
                    }
                    else if (iWSAfter != iWSCurrent)
                    {

                        MessageBox.Show(
       "Last Updated price in one week was on '" + string.Format("{0:dd-MMM-yyyy}", i1WKDate) + "' for this customer is " + string.Format("{0:N2}", iWS1WKCurrent) + "/" + iQtyPerCase + " PCS." + Environment.NewLine +
       "Your last previous updated price was on '" + string.Format("{0:dd-MMM-yyyy}", iDate) + "' is " + string.Format("{0:N2}", iWSCurrent) + "/" + iQtyPerCase + " PCS. " + Environment.NewLine +
       "Once is one month old, you must update Customer product list first.",
       "Confirm Update Price",
       MessageBoxButtons.OK,
       MessageBoxIcon.Information);

                        query = @"
    DECLARE @DateOrd AS DATE = '{1:yyyy-MM-dd}';
    DECLARE @CusNum AS NVARCHAR(8) = '{2}';
    DECLARE @CusName AS NVARCHAR(100) = '';
    DECLARE @Barcode AS NVARCHAR(MAX) = '{3}';
    DECLARE @ProName AS NVARCHAR(100) = '';
    DECLARE @Size AS NVARCHAR(30) = '';
    DECLARE @QtyPerCase AS INT = 0;
    DECLARE @WsPrice AS MONEY = {4};
    DECLARE @PreviousWsPrice AS MONEY = {5};
    DECLARE @OnewkWsPrice AS MONEY = {6};
    SELECT @CusName = ISNULL([CusName], '') FROM [Stock].[dbo].[TPRCustomer] WHERE [CusNum] = @CusNum;
    SELECT @ProName = [ProName], @Size = [ProPacksize], @QtyPerCase = [ProQtyPCase]
    FROM (
        SELECT [ProNumY], [ProNumYP], [ProNumYC], [ProName], [ProPacksize], [ProQtyPCase], [ProQtyPPack], [ProTotQty], [ProCurr], [ProImpPri], [ProDis], [ProVAT], [ProFinBuyin], [Average], [ProUPrSE], [ProUPriSeH], LEFT([Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) AS [SupName]
        FROM [Stock].[dbo].[TPRProducts]
        WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
        UNION ALL
        SELECT B.[OldProNumy] AS [ProNumY], A.[ProNumYP], A.[ProNumYC], A.[ProName], A.[ProPacksize], A.[ProQtyPCase], A.[ProQtyPPack], B.[Stock] AS [ProTotQty], A.[ProCurr], A.[ProImpPri], A.[ProDis], A.[ProVAT], A.[ProFinBuyin], A.[Average], A.[ProUPrSE], A.[ProUPriSeH], LEFT(A.[Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING(A.[Sup1], 9, LEN([Sup1])))) AS [SupName]
        FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
        WHERE B.[OldProNumy] = @Barcode
        UNION ALL
        SELECT [ProNumY], [ProNumYP], [ProNumYC], [ProName], [ProPacksize], [ProQtyPCase], [ProQtyPPack], [ProTotQty], [ProCurr], [ProImpPri], [ProDis], [ProVAT], [ProFinBuyin], [Average], [ProUPrSE], [ProUPriSeH], LEFT([Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) AS [SupName]
        FROM [Stock].[dbo].[TPRProductsDeactivated]
        WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
        UNION ALL
        SELECT B.[OldProNumy] AS [ProNumY], A.[ProNumYP], A.[ProNumYC], A.[ProName], A.[ProPacksize], A.[ProQtyPCase], A.[ProQtyPPack], B.[Stock] AS [ProTotQty], A.[ProCurr], A.[ProImpPri], A.[ProDis], A.[ProVAT], A.[ProFinBuyin], A.[Average], A.[ProUPrSE], A.[ProUPriSeH], LEFT(A.[Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING(A.[Sup1], 9, LEN(A.[Sup1])))) AS [SupName]
        FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
        WHERE B.[OldProNumy] = @Barcode
    ) LISTS;
    INSERT INTO [Stock].[dbo].[TPRWSCusProductListReminder]([DateOrd], [CusNum], [CusName], [ProNumy], [ProName], [ProPackSize], [ProQtyPCase], [WsPrice], [PreviousWsPrice], [OnewkWsPrice])
    VALUES(@DateOrd, @CusNum, @CusName, @Barcode, @ProName, @Size, @QtyPerCase, @WsPrice, @PreviousWsPrice, @OnewkWsPrice);
";
                        //  query = string.Format(query, DatabaseName, Convert.ToDateTime(string.IsNullOrWhiteSpace(TxtOrderDate.Text.Trim()) ? Todate : TxtOrderDate.Text.Trim()), CmbBillTo.SelectedValue, CmbProducts.SelectedValue, iWSAfter, iWSCurrent, iWS1WKCurrent);
                        query = string.Format(
                            query,
                            DatabaseName,
                            string.IsNullOrWhiteSpace(TxtOrderDate.Text.Trim())
                                ? Todate
                                : Convert.ToDateTime(TxtOrderDate.Text.Trim()),
                            CmbBillTo.SelectedValue,
                            CmbProducts.SelectedValue,
                            iWSAfter,
                            iWSCurrent,
                            iWS1WKCurrent
                        );
                        Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));
                    }
                    else if (iWSAfter != iWS1WKCurrent)
                    {
                        query = @"
        DECLARE @CusNum AS NVARCHAR(8) = '{1}';
        DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
        DELETE 
        FROM [Stock].[dbo].[TPRDeliveryTakeOrderAcceptWholesalePrice] 
        WHERE [CusNum] = @CusNum AND [Barcode] = @Barcode;
    ";
                        query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                        Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));

                        if (MessageBox.Show("Last Updated price for this customer is " + string.Format("{0:N2}", iWS1WKCurrent) + "/" + iQtyPerCase + " PCS." + Environment.NewLine + "Do you want to update old pricing?(Yes/No)", "Confirm Update Old Price", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Initialized.R_CorrectPassword = false;
                            FrmPasswordContinues lG1 = new FrmPasswordContinues();
                            lG1.R_PasswordPermission = "'Managing Director','MD Assistant','IT Manager','Office Manager','TakeOrder'";
                            lG1.ShowDialog();
                            if (!Initialized.R_CorrectPassword) return;

                            if (iQtyPerCase != Convert.ToInt32(string.IsNullOrWhiteSpace(TxtQtyPerCase.Text.Trim()) ? iQtyPerCase.ToString() : TxtQtyPerCase.Text.Trim()))
                            {
                                totalBuyin = (totalBuyin / Convert.ToInt32(string.IsNullOrWhiteSpace(TxtQtyPerCase.Text.Trim()) ? iQtyPerCase.ToString() : TxtQtyPerCase.Text.Trim())) * iQtyPerCase;
                            }

                            TxtWSPrice.Text = string.Format("{0:N2}", iWS1WKCurrent);
                            TxtQtyPerCase.Text = iQtyPerCase.ToString();
                            TotalAmount();

                            query = @"
            DECLARE @CusNum AS NVARCHAR(8) = '{1}';
            DECLARE @Barcode AS NVARCHAR(MAX) = '{2}';
            DELETE FROM [Stock].[dbo].[TPRDeliveryTakeOrderAcceptWholesalePrice] WHERE [CusNum] = @CusNum AND [Barcode] = @Barcode;
            INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrderAcceptWholesalePrice]([CusNum],[Barcode],[AcceptDate])
            VALUES(@CusNum,@Barcode,GETDATE());
        ";
                            query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbProducts.SelectedValue);
                            Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));
                        }

                        else if (MsgBoxResult.No.Equals(DialogResult.No))
                        {
                            Initialized.R_CorrectPassword = false;
                            FrmPasswordContinues lG1 = new FrmPasswordContinues();
                            lG1.R_PasswordPermission = "'Managing Director','MD Assistant','IT Manager','Office Manager','TakeOrder'";
                            lG1.ShowDialog();
                            if (!Initialized.R_CorrectPassword) return;
                        }
                        else
                        {
                            return;
                        }
                    }




                }
                else if (IsProductListExisted && !IsProductList1WeekExisted)
                {
                    iWSCurrent = Convert.ToDouble(string.Format("{0:N2}", (Convert.IsDBNull(ProductList.Rows[0]["ProUPriSeH"]) ? 0 : Convert.ToDouble(ProductList.Rows[0]["ProUPriSeH"])) + vServiceCost + vDeliveryLogistic));
                    iDate = Convert.ToDateTime(Convert.IsDBNull(ProductList.Rows[0]["Date"]) ? Todate : ProductList.Rows[0]["Date"]);
                    iQtyPerCase = Convert.ToInt32(Convert.IsDBNull(ProductList.Rows[0]["ProQtyPCase"]) ? 1 : ProductList.Rows[0]["ProQtyPCase"]);
                    if (iWSAfter != iWSCurrent)
                    {
                        int Diff = (Todate - iDate).Days;
                        if (Diff > 30)
                        {
                            MessageBox.Show("Please update 'Wholesale Customer product list' for this customer first!", "Need Update Price List First", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        MessageBox.Show("Your last previous updated price was on '" + string.Format("{0:dd-MMM-yyyy}", iDate) + "' is " + string.Format("{0:N2}", iWSCurrent) + "/" + iQtyPerCase + " PCS. " + Environment.NewLine + "Once is one month old, you must update Customer product list first.", "Confirm Update Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //            query = @"
                        //    DECLARE @DateOrd AS DATE = '{1:yyyy-MM-dd}';
                        //    DECLARE @CusNum AS NVARCHAR(8) = '{2}';
                        //    DECLARE @CusName AS NVARCHAR(100) = '';
                        //    DECLARE @Barcode AS NVARCHAR(MAX) = '{3}';
                        //    DECLARE @ProName AS NVARCHAR(100) = '';
                        //    DECLARE @Size AS NVARCHAR(30) = '';
                        //    DECLARE @QtyPerCase AS INT = 0;
                        //    DECLARE @WsPrice AS MONEY = {4};
                        //    DECLARE @PreviousWsPrice AS MONEY = {5};
                        //    SELECT @CusName = ISNULL([CusName], '') FROM [Stock].[dbo].[TPRCustomer] WHERE [CusNum] = @CusNum;
                        //    SELECT @ProName = [ProName], @Size = [ProPacksize], @QtyPerCase = [ProQtyPCase]
                        //    FROM (
                        //        SELECT [ProNumY], [ProNumYP], [ProNumYC], [ProName], [ProPacksize], [ProQtyPCase], [ProQtyPPack], [ProTotQty], [ProCurr], [ProImpPri], [ProDis], [ProVAT], [ProFinBuyin], [Average], [ProUPrSE], [ProUPriSeH], LEFT([Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) AS [SupName]
                        //        FROM [Stock].[dbo].[TPRProducts]
                        //        WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
                        //        UNION ALL
                        //        SELECT B.[OldProNumy] AS [ProNumY], A.[ProNumYP], A.[ProNumYC], A.[ProName], A.[ProPacksize], A.[ProQtyPCase], A.[ProQtyPPack], B.[Stock] AS [ProTotQty], A.[ProCurr], A.[ProImpPri], A.[ProDis], A.[ProVAT], A.[ProFinBuyin], A.[Average], A.[ProUPrSE], A.[ProUPriSeH], LEFT(A.[Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING(A.[Sup1], 9, LEN(A.[Sup1])))) AS [SupName]
                        //        FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
                        //        WHERE B.[OldProNumy] = @Barcode
                        //        UNION ALL
                        //        SELECT [ProNumY], [ProNumYP], [ProNumYC], [ProName], [ProPacksize], [ProQtyPCase], [ProQtyPPack], [ProTotQty], [ProCurr], [ProImpPri], [ProDis], [ProVAT], [ProFinBuyin], [Average], [ProUPrSE], [ProUPriSeH], LEFT([Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) AS [SupName]
                        //        FROM [Stock].[dbo].[TPRProductsDeactivated]
                        //        WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
                        //        UNION ALL
                        //        SELECT B.[OldProNumy] AS [ProNumY], A.[ProNumYP], A.[ProNumYC], A.[ProName], A.[ProPacksize], A.[ProQtyPCase], A.[ProQtyPPack], B.[Stock] AS [ProTotQty], A.[ProCurr], A.[ProImpPri], A.[ProDis], A.[ProVAT], A.[ProFinBuyin], A.[Average], A.[ProUPrSE], A.[ProUPriSeH], LEFT(A.[Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING(A.[Sup1], 9, LEN(A.[Sup1])))) AS [SupName]
                        //        FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
                        //        WHERE B.[OldProNumy] = @Barcode
                        //    ) LISTS;
                        //    INSERT INTO [Stock].[dbo].[TPRWSCusProductListReminder]([DateOrd], [CusNum], [CusName], [ProNumy], [ProName], [ProPackSize], [ProQtyPCase], [WsPrice], [PreviousWsPrice])
                        //    VALUES(@DateOrd, @CusNum, @CusName, @Barcode, @ProName, @Size, @QtyPerCase, @WsPrice, @PreviousWsPrice);
                        //";
                        query = "";
                        //query = string.Format(query, DatabaseName, Convert.ToDateTime(string.IsNullOrWhiteSpace(TxtOrderDate.Text.Trim()) ? Todate : TxtOrderDate.Text.Trim()), CmbBillTo.SelectedValue, CmbProducts.SelectedValue, iWSAfter, iWSCurrent);
                        query = string.Format(query, DatabaseName, DateTime.Parse(TxtOrderDate.Text.Trim()), CmbBillTo.SelectedValue, CmbProducts.SelectedValue, iWSAfter, iWSCurrent);
                        Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));
                    }
                }
                else if (!IsProductListExisted && IsProductList1WeekExisted)
                {
                    iWSCurrent = Convert.ToDouble(Convert.IsDBNull(ProductList1Week.Rows[0]["ProUPriSeH"]) ? 0 : ProductList1Week.Rows[0]["ProUPriSeH"]);
                    iDate = Convert.ToDateTime(Convert.IsDBNull(ProductList1Week.Rows[0]["Date"]) ? Todate : ProductList1Week.Rows[0]["Date"]);
                    iQtyPerCase = Convert.ToInt32(Convert.IsDBNull(ProductList1Week.Rows[0]["ProQtyPCase"]) ? 1 : ProductList1Week.Rows[0]["ProQtyPCase"]);
                    if (iWSAfter != iWSCurrent)
                    {
                        MessageBox.Show("No previous price, only have 1wk price, Updated was on '" + string.Format("{0:dd-MMM-yyyy}", iDate) + "' for this customer is " + iWSCurrent + "/" + iQtyPerCase + " PCS.", "Not Allow Continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            WSFixedPrice_Final:
                if (DeliveryTakeOrderList.Rows.Count > 0)
                {
                    // Prevent Duplicate
                    // string iBarcode = "";
                    // foreach (DataRow r in DeliveryTakeOrderList.Rows)
                    // {
                    //     iBarcode = Trim(Convert.IsDBNull(r["ProNumy"]) ? "" : r["ProNumy"].ToString());
                    //     if (CmbProducts.SelectedValue.Equals(iBarcode))
                    //     {
                    //         XtraMessageBox.Show("This product already existed in this order!" + Environment.NewLine + "You cannot add this product anymore.", "Duplicated Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //         return;
                    //     }
                    // }

                    var barcodeSelected = (from DataRow lx in DeliveryTakeOrderList.Rows.Cast<DataRow>()
                                           where (Convert.IsDBNull(lx["ProNumy"]) ? "" : lx["ProNumy"].ToString().Trim()).Equals(CmbProducts.SelectedValue.ToString())
                                           select lx["ProNumy"].ToString()).Distinct().ToArray();
                    if (barcodeSelected.ToList().Count > 0)
                    {
                        MessageBox.Show("This product already existed in this order!" + Environment.NewLine + "You cannot add this product anymore.", "Duplicated Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                DataRow Row = null;
                int vTotalTO = 0;
                bool vAcceptPromotionSetting = false;
                // CHECK T.O FOR PROMOTION 
                if (oQtyInvoicing > 0)
                {
                    query = @"DECLARE @vPromotionIdLink AS DECIMAL(18, 0) = {1};
DECLARE @vCusNum AS NVARCHAR(8) = N'{2}';

WITH    v AS ( SELECT   SUM([QtyInvoicing]) [Qty]
               FROM     [{0}].[dbo].[TblProductsPromotionSetting.AllowableInvoicing]
               WHERE    ( [PromotionIdLink] = @vPromotionIdLink )
               UNION ALL
               SELECT   SUM([QtyInvoicing]) [Qty]
               FROM     [{0}].[dbo].[TblProductsPromotionSetting.AllowableInvoicing.Completed]
               WHERE    ( [PromotionIdLink] = @vPromotionIdLink )
             )
    SELECT  SUM(v.[Qty]) [Qty]
    INTO    #oPromotion
    FROM    v;

DECLARE @oCusNum_ AS NVARCHAR(8)= N'';
SELECT  @oCusNum_ = [CusNumInvolve]
FROM    [{0}].[dbo].[TblProductsPromotionSetting]
WHERE   ( [Id] = @vPromotionIdLink )
        AND ( [CusNum] = @vCusNum );

IF ( @oCusNum_ = @vCusNum )
    BEGIN
        UPDATE  v
        SET     v.[Qty] = 0
        FROM    #oPromotion v;
    END;                        
                    

SELECT  SUM(v.[Qty]) [Qty]
FROM    #oPromotion v;

DROP TABLE #oPromotion;";


                    query = string.Format(query, DatabaseName, oPromotionId, CmbBillTo.SelectedValue);
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));


                    if (lists != null)
                    {
                        if (lists.Rows.Count > 0)
                        {
                            vTotalTO = Convert.ToInt32(Convert.IsDBNull(lists.Rows[0]["Qty"]) ? 0 : lists.Rows[0]["Qty"]);
                        }
                    }
                    if (oQtyInvoicing > vTotalTO)
                    {
                        string vMsg = string.Format("~ Total Promotion: {1:N0}{0}~ Used Promotion: {2:N0}{0}~ Left Promotion: {3:N0}{0}{0}Do you want to set promotion for Take Order? (Yes/No)", Environment.NewLine, oQtyInvoicing, vTotalTO, (oQtyInvoicing - vTotalTO));
                        if (MessageBox.Show(vMsg, "Confirm Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Row = vPromotionList.NewRow();
                            Row["PromotionIdLink"] = oPromotionId;
                            Row["QtyInvoicing"] = 1;
                            Row["Division"] = vDivision;
                            vPromotionList.Rows.Add(Row);
                            vAcceptPromotionSetting = true;
                        }
                        else
                        {
                            TxtItemDiscount.Text = "0";
                            vAcceptPromotionSetting = false;
                            goto err_skippromotion;
                        }
                    }
                    else
                    {
                        vAcceptPromotionSetting = false;
                        goto err_skippromotion;
                    }

                }
            manually_Promotion:

                if (!string.IsNullOrWhiteSpace(TxtBarcodeFree.Text.Trim()) && Convert.ToInt32(string.IsNullOrWhiteSpace(TxtPcsFree.Text.Trim()) ? "0" : TxtPcsFree.Text.Trim()) != 0)
                {
                    string[] iBarcodeFree = TxtBarcodeFree.Text.Split(new string[] { "   " }, StringSplitOptions.None);
                    query = @"
        DECLARE @Barcode AS NVARCHAR(MAX) = N'{1}';
                        SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],[SupNum],[SupName],[ProCat]
                        FROM (
	                        SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName],[ProCat]
	                        FROM [Stock].[dbo].[TPRProducts]
	                        WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	                        UNION ALL
	                        SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName],A.[ProCat]
	                        FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                        WHERE B.[OldProNumy] = @Barcode
                            UNION ALL
                            SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName],[ProCat]
	                        FROM [Stock].[dbo].[TPRProductsDeactivated]
	                        WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	                        UNION ALL
	                        SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName],A.[ProCat]
	                        FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                        WHERE B.[OldProNumy] = @Barcode
                        ) LISTS;
                    
    ";
                    query = string.Format(query, DatabaseName, iBarcodeFree[0].Trim());
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null)
                    {
                        if (lists.Rows.Count > 0)
                        {
                            Row = DeliveryTakeOrderList.NewRow();
                            Row["Barcode"] = iBarcodeFree[0].Trim();
                            Row["ProNumy"] = Convert.IsDBNull(lists.Rows[0]["ProNumY"]) ? "" : lists.Rows[0]["ProNumY"].ToString().Trim();
                            Row["ProNumyP"] = Convert.IsDBNull(lists.Rows[0]["ProNumYP"]) ? "" : lists.Rows[0]["ProNumYP"].ToString().Trim();
                            Row["ProNumyC"] = Convert.IsDBNull(lists.Rows[0]["ProNumYC"]) ? "" : lists.Rows[0]["ProNumYC"].ToString().Trim();
                            Row["ProName"] = Convert.IsDBNull(lists.Rows[0]["ProName"]) ? "" : lists.Rows[0]["ProName"].ToString().Trim();
                            Row["ProPackSize"] = Convert.IsDBNull(lists.Rows[0]["ProPacksize"]) ? "" : lists.Rows[0]["ProPacksize"].ToString().Trim();
                            Row["ProQtyPCase"] = Convert.ToInt32(Convert.IsDBNull(lists.Rows[0]["ProQtyPCase"]) ? 1 : lists.Rows[0]["ProQtyPCase"]);
                            Row["ProCat"] = Convert.IsDBNull(lists.Rows[0]["ProCat"]) ? "" : lists.Rows[0]["ProCat"].ToString().Trim();
                            Row["SupNum"] = Convert.IsDBNull(lists.Rows[0]["SupNum"]) ? "" : lists.Rows[0]["SupNum"].ToString().Trim();
                            Row["SupName"] = Convert.IsDBNull(lists.Rows[0]["SupName"]) ? "" : lists.Rows[0]["SupName"].ToString().Trim();
                            Row["PcsFree"] = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtPcsFree.Text.Trim()) ? "0" : TxtPcsFree.Text.Trim());
                            Row["PcsOrder"] = 0;
                            Row["PackOrder"] = 0;
                            Row["CTNOrder"] = 0;
                            Row["TotalPcsOrder"] = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtPcsFree.Text.Trim()) ? "0" : TxtPcsFree.Text.Trim());
                            Row["ItemDiscount"] = 0;
                            Row["PromotionMachanic"] = "";
                            Row["Remark"] = this.rdbcostlowecommerence.Checked ? this.rdbcostlowecommerence.Text : "";
                            //   Row["Reason_Continue"] = _reason_continue;
                            ;

                            Row["TotalAmount"] = 0;
                            Row["Division"] = vDivision;
                            DeliveryTakeOrderList.Rows.Add(Row);
                        }
                    }
                }
            err_skippromotion:
                if (decimal.TryParse(this.TxtTotalPcsOrder.Text.Trim(), out decimal totalPcsOrder) && totalPcsOrder != 0)
                {


                    query = @"
    DECLARE @Barcode AS NVARCHAR(MAX) = N'{1}';
    SELECT [ProNumY], [ProNumYP], [ProNumYC], [ProName], [ProPacksize], [ProQtyPCase], [ProQtyPPack], [ProTotQty], [ProCurr], [ProImpPri], [ProDis], [ProVAT], [ProFinBuyin], [Average], [ProUPrSE], [ProUPriSeH], [SupNum], [SupName], [ProCat]
    FROM (
        SELECT [ProNumY], [ProNumYP], [ProNumYC], [ProName], [ProPacksize], [ProQtyPCase], [ProQtyPPack], [ProTotQty], [ProCurr], [ProImpPri], [ProDis], [ProVAT], [ProFinBuyin], [Average], [ProUPrSE], [ProUPriSeH], LEFT([Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) AS [SupName], [ProCat]
        FROM [Stock].[dbo].[TPRProducts]
        WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
        UNION ALL
        SELECT B.[OldProNumy] AS [ProNumY], A.[ProNumYP], A.[ProNumYC], A.[ProName], A.[ProPacksize], A.[ProQtyPCase], A.[ProQtyPPack], B.[Stock] AS [ProTotQty], A.[ProCurr], A.[ProImpPri], A.[ProDis], A.[ProVAT], A.[ProFinBuyin], A.[Average], A.[ProUPrSE], A.[ProUPriSeH], LEFT(A.[Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING(A.[Sup1], 9, LEN(A.[Sup1])))) AS [SupName], A.[ProCat]
        FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
        WHERE B.[OldProNumy] = @Barcode
        UNION ALL
        SELECT [ProNumY], [ProNumYP], [ProNumYC], [ProName], [ProPacksize], [ProQtyPCase], [ProQtyPPack], [ProTotQty], [ProCurr], [ProImpPri], [ProDis], [ProVAT], [ProFinBuyin], [Average], [ProUPrSE], [ProUPriSeH], LEFT([Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) AS [SupName], [ProCat]
        FROM [Stock].[dbo].[TPRProductsDeactivated]
        WHERE (ISNULL([ProNumY], '') = @Barcode OR ISNULL([ProNumYP], '') = @Barcode OR ISNULL([ProNumYC], '') = @Barcode)
        UNION ALL
        SELECT B.[OldProNumy] AS [ProNumY], A.[ProNumYP], A.[ProNumYC], A.[ProName], A.[ProPacksize], A.[ProQtyPCase], A.[ProQtyPPack], B.[Stock] AS [ProTotQty], A.[ProCurr], A.[ProImpPri], A.[ProDis], A.[ProVAT], A.[ProFinBuyin], A.[Average], A.[ProUPrSE], A.[ProUPriSeH], LEFT(A.[Sup1], 8) AS [SupNum], LTRIM(RTRIM(SUBSTRING(A.[Sup1], 9, LEN(A.[Sup1])))) AS [SupName], A.[ProCat]
        FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
        WHERE B.[OldProNumy] = @Barcode
    ) LISTS;
";

                    query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
                    lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null)
                    {
                        if (lists.Rows.Count > 0)
                        {
                            Row = DeliveryTakeOrderList.NewRow();
                            Row["Barcode"] = CmbProducts.SelectedValue;
                            Row["ProNumy"] = Convert.IsDBNull(lists.Rows[0]["ProNumY"]) ? "" : lists.Rows[0]["ProNumY"].ToString().Trim();
                            Row["ProNumyP"] = Convert.IsDBNull(lists.Rows[0]["ProNumYP"]) ? "" : lists.Rows[0]["ProNumYP"].ToString().Trim();
                            Row["ProNumyC"] = Convert.IsDBNull(lists.Rows[0]["ProNumYC"]) ? "" : lists.Rows[0]["ProNumYC"].ToString().Trim();
                            Row["ProName"] = Convert.IsDBNull(lists.Rows[0]["ProName"]) ? "" : lists.Rows[0]["ProName"].ToString().Trim();
                            Row["ProPackSize"] = Convert.IsDBNull(lists.Rows[0]["ProPacksize"]) ? "" : lists.Rows[0]["ProPacksize"].ToString().Trim();
                            Row["ProQtyPCase"] = Convert.ToInt32(Convert.IsDBNull(lists.Rows[0]["ProQtyPCase"]) ? 1 : lists.Rows[0]["ProQtyPCase"]);
                            Row["ProCat"] = Convert.IsDBNull(lists.Rows[0]["ProCat"]) ? "" : lists.Rows[0]["ProCat"].ToString().Trim();
                            Row["SupNum"] = Convert.IsDBNull(lists.Rows[0]["SupNum"]) ? "" : lists.Rows[0]["SupNum"].ToString().Trim();
                            Row["SupName"] = Convert.IsDBNull(lists.Rows[0]["SupName"]) ? "" : lists.Rows[0]["SupName"].ToString().Trim();
                            Row["PcsFree"] = 0;
                            Row["PcsOrder"] = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtPcsOrder.Text.Trim()) ? "0" : TxtPcsOrder.Text.Trim());
                            Row["PackOrder"] = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtPackOrder.Text.Trim()) ? "0" : TxtPackOrder.Text.Trim());
                            Row["CTNOrder"] = Convert.ToSingle(string.IsNullOrWhiteSpace(TxtCTNOrder.Text.Trim()) ? "0" : TxtCTNOrder.Text.Trim());
                            Row["TotalPcsOrder"] = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtTotalPcsOrder.Text.Trim()) ? "0" : TxtTotalPcsOrder.Text.Trim());
                            Row["ItemDiscount"] = Convert.ToSingle(string.IsNullOrWhiteSpace(TxtItemDiscount.Text.Trim()) ? "0" : TxtItemDiscount.Text.Trim());
                            Row["PromotionMachanic"] = TxtNote.Text.Trim();
                            Row["Remark"] = this.rdbcostlowecommerence.Checked ? this.rdbcostlowecommerence.Text : TxtRemark.Text.Trim();
                            Row["Reason_Continue"] = _reason_continue;
                            Row["TotalAmount"] = Convert.ToDouble(string.IsNullOrWhiteSpace(TxtTotalAmount.Text.Trim()) ? "0" : TxtTotalAmount.Text.Trim());
                            Row["Division"] = vDivision;
                            DeliveryTakeOrderList.Rows.Add(Row);
                        }
                        else
                        {

                            goto Err_Item;

                        }
                    }

                Err_Item:
                    MessageBox.Show("The Item is wrong. Please check item again...", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (RdbOnlinePO.Checked)
                {
                    TimerProductLoading.Enabled = true;
                }
                ClearProductItems();
                App.SetEnableController(false, PanelHeader, PanelBillTo, CmbSaleman);
                CmbProducts.Focus();
                DgvShow.Sort(DgvShow.Columns["Division"], System.ComponentModel.ListSortDirection.Ascending);
                LblCountRow.Text = string.Format("Count Row : {0}", DgvShow.RowCount);


            }
        }

        private void chkallitems_CheckedChanged(object sender, EventArgs e)
        {
            TimerCategoryLoading.Enabled = true;
        }

        private void CmbDelto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Panel27.Enabled = true;
            App.ClearController(TxtZone, TxtKhmerName);
            if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null) { return; }

            if (CmbDelto.Text.Trim() == "")
            {
                return;

            }
            string vCity = "";
            decimal vPeroid = 0;
            this.TxtIdDelto.Text = string.Format("{0}", CmbDelto.SelectedValue);
            if (this.rdbcostlowecommerence.Checked)
            {

                goto err_ecommerce;

            }

            // Check Lattude & Longtitude 
            string sLatitude = "";
            string sLongitude = "";

            query = @"DECLARE @Id AS DECIMAL(18,0) = {1};
                        SELECT [DefId],[DelTo],[Zone],[KhmerUnicode],[City],[Latitude],[Longitude]
                        FROM [Stock].[dbo].[TPRDelto]
                        WHERE [DefId] = @Id;";

            query = string.Format(query, DatabaseName, CmbDelto.SelectedValue);

            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {

                    sLongitude = DBNull.Value.Equals(lists.Rows[0]["Longitude"]) ? "" : lists.Rows[0]["Longitude"].ToString().Trim();
                    sLatitude = DBNull.Value.Equals(lists.Rows[0]["Latitude"]) ? "" : lists.Rows[0]["Latitude"].ToString().Trim();
                    string msg = "";
                    if (sLongitude.Trim().Equals("") && sLatitude.Trim().Equals(""))
                    {
                        msg = "Please enter the Longitude and Latitude of the outlets.";
                    }
                    else if (sLatitude.Trim().Equals(""))
                    {
                        msg = "Please enter the Longtitude of the Outlests.";
                    }
                    else if (sLongitude.Trim().Equals(""))
                    {
                        msg = "Please enter the Latitude of the outlets.";
                    }
                    int sDays = 0;
                    int sDaysLeft = 0;
                    if (msg.Trim().Equals("") == false)
                    {
                        query = @"DECLARE @app AS NVARCHAR(100) = N'Latitude-Longitude'
SELECT COALESCE([AutoNumber],0) [Days],(COALESCE([AutoNumber],0) - DATEDIFF(DAY,[CreatedDate],GETDATE())) [Left]
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblAutoNumber]
WHERE ([ProgramName] = @app);";
                        query = string.Format(query, DatabaseName, CmbDelto.SelectedValue);
                        lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                        if (lists != null)
                        {
                            if (lists.Rows.Count > 0)
                            {
                                sDays = Convert.ToInt32(Convert.IsDBNull(lists.Rows[0]["Days"]) ? 0 : lists.Rows[0]["Days"]);
                                sDaysLeft = Convert.ToInt32(Convert.IsDBNull(lists.Rows[0]["Left"]) ? 0 : lists.Rows[0]["Left"]);


                            }
                        }
                        msg += Environment.NewLine;
                        msg += string.Format("If not, the {0} day(s) later - the system will block the outlets.", sDays);
                        msg += Environment.NewLine;
                        msg += Environment.NewLine;
                        msg += string.Format("{0} Day(s) Left", sDaysLeft);

                        gui_message_box gui26_ = new gui_message_box();
                        gui26_.lblmsg.Text = msg;
                        gui26_.ShowDialog();

                        if (sDaysLeft <= 0)
                        {
                            this.Panel27.Enabled = false;
                        }

                    }

                }


            }
        err_ecommerce:

            query = @"
                    DECLARE @Id AS DECIMAL(18,0) = {1};
                    WITH sDelto
                    AS (
                        SELECT [DelTo], [Zone], [KhmerUnicode], [City]
                        FROM [Stock].[dbo].[TPRDelto]
                        WHERE [DefId] = @Id
                        UNION ALL
                        SELECT [DelTo], N'1' AS [Zone], [CusKhmerName] AS [KhmerUnicode],
                               CASE
                                   WHEN ISNULL([City], N'') = N'' THEN N'Phnom Penh'
                                   ELSE ISNULL([City], N'')
                               END AS [City]
                        FROM [DBCostLowECommerce].[dbo].[TblCustomer]
                        WHERE [DefId] = @Id
                    )
                    SELECT [DelTo], [Zone], [KhmerUnicode], [City]
                    FROM sDelto;
                    ";
            query = string.Format(query, DatabaseName, CmbDelto.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {

                    TxtZone.Text = Convert.IsDBNull(lists.Rows[0]["Zone"]) ? "" : lists.Rows[0]["Zone"].ToString().Trim();
                    TxtKhmerName.Text = Convert.IsDBNull(lists.Rows[0]["KhmerUnicode"]) ? "" : lists.Rows[0]["KhmerUnicode"].ToString().Trim();
                    vCity = Convert.IsDBNull(lists.Rows[0]["City"]) ? "" : lists.Rows[0]["City"].ToString().Trim();


                }

            }

            if (!vCity.Trim().Equals("Phnom Penh"))
            {
                vCity = "Province";
            }

            query = @"
        DECLARE @vLocation AS NVARCHAR(100) = N'{1}';
        SELECT [Id], [Location], [Period], [CreatedDate]
        FROM [{0}].[dbo].[TblDeliveryTakeOrder_PeroidToProcess]
        WHERE [Location] = @vLocation;
";
            query = string.Format(query, DatabaseName, vCity);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {
                    vPeroid = Convert.ToDecimal(Convert.IsDBNull(lists.Rows[0]["Period"]) ? 0 : lists.Rows[0]["Period"]);
                }
            }

            DTPRequiredDate.Value = Todate.AddHours((double)vPeroid);
            DTPDeliverDate.Value = Todate.AddHours((double)vPeroid);
            TxtRequiredDate.Text = string.Format("{0:dd-MMM-yyyy}", DTPRequiredDate.Value);


            if (RdbOnlinePO.Checked)
            {
                query = @"
DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
DECLARE @DeltoId AS DECIMAL(18, 0) = {2};

SELECT [x].[PONumber],
       [x].[Barcode],
       [x].[ProductName],
       [x].[Size],
       [x].[QtyPerCase],
       [x].[Price],
       [x].[PcsOrder],
       [x].[PackOrder],
       [x].[CtnOrder],
       [v].[OrderDate],
       [v].[DeliveryDate],
       [o].[SalesmanCode],
       [v].[EmpId]
FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
    INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
        ON ([v].[Id] = [x].[POId])
    LEFT OUTER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblSetSalesmanToSalesManager] o 
        ON ([o].[EmployeeNumber] = [v].[EmpId])        
WHERE ([v].[OrderDate] IS NOT NULL)
      AND ([v].[DeliveryDate] IS NOT NULL)
      AND ([v].[CusNum] = @CusNum)
      AND ([v].[DeltoId] = @DeltoId);
";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, CmbDelto.SelectedValue);
                var lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null)
                {
                    if (lists.Rows.Count > 0)
                    {
                        string saleman_ = Convert.IsDBNull(lists.Rows[0]["EmpId"]) ? "" : lists.Rows[0]["EmpId"].ToString().Trim();
                        TxtOrderDate.Text = string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(Convert.IsDBNull(lists.Rows[0]["OrderDate"]) ? Todate : lists.Rows[0]["OrderDate"]));
                        DTPDeliverDate.Value = Convert.ToDateTime(Convert.IsDBNull(lists.Rows[0]["DeliveryDate"]) ? Todate : lists.Rows[0]["DeliveryDate"]);
                        TxtPONo.Text = Convert.IsDBNull(lists.Rows[0]["PONumber"]) ? "" : lists.Rows[0]["PONumber"].ToString().Trim();
                        if (!string.IsNullOrWhiteSpace(saleman_))
                        {
                            CmbSaleman.SelectedValue = saleman_;
                            CmbSaleman.Enabled = false;
                        }
                    }
                }
            }

        }

        private void LblCheckExpiryDate_Click(object sender, EventArgs e)
        {
            if (CmbProducts.Text.Trim() == "")
            {
                return;
            }
            if (CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue == null)
            {
                return;
            }
            string vBarcode = CmbProducts.SelectedValue.ToString();
            string vCusNum = CmbBillTo.SelectedValue.ToString();
            string vCusName = CmbBillTo.Text.Trim();
            FrmCheckExpiryDate vFrm = new FrmCheckExpiryDate
            {
                vBarcode = vBarcode,
                vCusNum = vCusNum,
                vCusname = vCusName
            };
            vFrm.ShowDialog();

        }

        private void TxtIdDelto_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);

        }

        private void TxtIdDelto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                decimal vid_ = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtIdDelto.Text.Trim()) ? "0" : TxtIdDelto.Text.Trim());
                DataTable vlst_ = null;
                string vsql_ = "";
                if (rdbcostlowecommerence.Checked)
                {
                    vsql_ = @"
DECLARE @vid_ AS DECIMAL(18, 0) = {1};
SELECT *
FROM [DBCostLowECommerce].[dbo].[TblCustomer] x
WHERE ([x].[DefId] = @vid_);
";
                }
                else
                {
                    vsql_ = @"
DECLARE @vid_ AS DECIMAL(18, 0) = {1};
SELECT *
FROM [Stock].[dbo].[TPRDelto] x
WHERE ([x].[DefId] = @vid_);
";
                }

                vsql_ = string.Format(vsql_, DatabaseName, vid_);
                vlst_ = Data.Selects(vsql_, Initialized.GetConnectionType(Data, App));
                if (vlst_ != null)
                {
                    if (vlst_.Rows.Count > 0)
                    {
                        CmbBillTo.SelectedValue = Convert.IsDBNull(vlst_.Rows[0]["CusNum"]) ? "" : vlst_.Rows[0]["CusNum"].ToString().Trim();
                    }
                }
            }

        }

        private void TxtStock_TextChanged(object sender, EventArgs e)
        {
            if (sender == TxtStock || sender == txtpendingstock)
            {
                decimal _cur_stock = string.IsNullOrWhiteSpace(TxtStock.Text.Trim()) ? 0 : Convert.ToDecimal(TxtStock.Text.Trim());
                decimal _pending_stock = string.IsNullOrWhiteSpace(txtpendingstock.Text.Trim()) ? 0 : Convert.ToDecimal(txtpendingstock.Text.Trim());
                txtavailablestock.Text = string.Format("{0:N0}", (_cur_stock - _pending_stock));
            }
        }

        private void txtpendingstock_DoubleClick(object sender, EventArgs e)
        {
            if (lst_check_stock_.Count <= 0)
            {
                MessageBox.Show("No record for customer to preview!", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbBillTo.Focus();
                return;
            }

            rpt_check_stock xReport = new rpt_check_stock();
            gui_check_stock _gui_ = new gui_check_stock();
            xReport.objectDataSource1.DataSource = lst_check_stock_;
            xReport.Parameters["asof"].Value = Todate;
            xReport.RequestParameters = false;
            _gui_.docViewer.DocumentSource = xReport;
            _gui_.docViewer.PrintingSystem = xReport.PrintingSystem;
            _gui_.docViewer.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Parameters, CommandVisibility.None);
            _gui_.docViewer.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SubmitParameters, CommandVisibility.None);
            _gui_.docViewer.PrintingSystem.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
            _gui_.docViewer.Refresh();
            xReport.CreateDocument(true);
            _gui_.ShowDialog(this);
        }

        private void rdbcostlowecommerence_CheckedChanged(object sender, EventArgs e)
        {
            piccreatecustomerecommerce.Enabled = rdbcostlowecommerence.Checked;
            if (rdbcostlowecommerence.Checked)
            {
                sFirstLoading = true;
                lblMsg.Text = rdbcostlowecommerence.Text.Trim().ToUpper();
                TimerCustomerLoading.Enabled = true;
            }

        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (DeliveryTakeOrderList.Rows.Count <= 0)
            {
                MessageBox.Show("No record to process finish.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (RdbOnlinePO.Checked && CmbProducts.Items.Count > 0)
            {
                MessageBox.Show("Please check the item again, \nbecause you have the items more which must be add into list.", "Not allow to continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbProducts.Focus();
                return;
            }

            string sCusNum = "";
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                sCusNum = "";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(CmbBillTo.Text.Trim()))
                {
                    sCusNum = "";
                }
                else
                {
                    sCusNum = CmbBillTo.SelectedValue.ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(sCusNum.Trim()))
            {
                MessageBox.Show("Please select any customer first.", "Not allow to continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbBillTo.Focus();
                return;
            }

            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            int vMaxDay = App.GetDayPerMonth(Todate.Date);
            int vAlertDay = 0;
            int vIncludeDay = 0;
            DateTime vDeliveryDate = Todate.Date;
            string sql_ = "";
            DataTable lst_ = null;
            sql_ = @" DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                        SELECT [Id],[CusNum],[CusName],[AlertDay],[IncludeDay],[CreatedDate]
                        FROM [{0}].[dbo].[TblCustomerAlertDeliveryDate]
                        WHERE ([CusNum] = @vCusNum);";

            sql_ = string.Format(sql_, DatabaseName, sCusNum);
            lst_ = Data.Selects(sql_, Initialized.GetConnectionType(Data, App));


            if (lst_ != null)
            {
                if (lst_.Rows.Count > 0)
                {
                    vAlertDay = Convert.ToInt32(Convert.IsDBNull(lst_.Rows[0]["AlertDay"]) ? (vMaxDay - 2) : lst_.Rows[0]["AlertDay"]);
                    vIncludeDay = Convert.ToInt32(Convert.IsDBNull(lst_.Rows[0]["IncludeDay"]) ? 0 : lst_.Rows[0]["IncludeDay"]);
                    vDeliveryDate = vDeliveryDate.AddDays(vIncludeDay);

                    if (string.Format("{0:ddd}", vDeliveryDate).Trim().Equals("Sun"))
                    {
                        vDeliveryDate = vDeliveryDate.AddDays(1);
                    }

                    if (Todate.Date.Day >= vAlertDay)
                    {
                        if (MessageBox.Show(string.Format("This is on {0:dddd, dd-MMM-yyyy}.{2}For P.O Number, Do you want to change Delivery Date to <{1:dddd, dd-MMM-yyyy}>?(Yes/No)", Todate, vDeliveryDate, Environment.NewLine), "Confirm Delivery Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DTPDeliverDate.Value = vDeliveryDate;
                        }
                    }

                }
            }

            //Provent Caltex smaller then 10 
            double vTotalInvoicing = 0;
            vTotalInvoicing += DeliveryTakeOrderList.Rows.Cast<DataRow>().Sum(lu => Convert.ToDouble(lu["TotalAmount"]));
            bool oisprevent = false;
            sql_ = @" DECLARE @vcusnum AS NVARCHAR(8) = N'{3}';
                            DECLARE @vbarcode AS NVARCHAR(15) = N'{4}';
                            IF EXISTS(SELECT * FROM [DBInvoicing].[dbo].[.tblcustomer.prevent.amount] WHERE ([cusnum] = @vcusnum))
                            BEGIN
	                            IF EXISTS(SELECT * FROM [DBInvoicing].[dbo].[.tblcustomer.prevent.amount] WHERE ([cusnum] = @vcusnum) AND ([barcode] = @vbarcode))
	                            BEGIN
		                            SELECT N'' [Status];
	                            END;
	                            ELSE
	                            BEGIN
		                            SELECT N'Stop' [Status];
	                            END;
                            END;
                            ELSE
                            BEGIN
	                            SELECT N'' [Status];
                            END;";
            sql_ = string.Format(sql_, DatabaseName, "", "", sCusNum, DeliveryTakeOrderList.Rows[0]["Barcode"]);
            lst_ = Data.Selects(sql_, Initialized.GetConnectionType(Data, App));

            if (lst_ != null)
            {
                if (lst_.Rows.Count > 0)
                {
                    if (string.IsNullOrWhiteSpace(Convert.IsDBNull(lst_.Rows[0]["Status"]) ? "" : lst_.Rows[0]["Status"].ToString().Trim()))
                    {
                        oisprevent = false;
                    }
                    else
                    {
                        oisprevent = true;
                    }

                }

            }

            if ((vTotalInvoicing < 10) && (oisprevent == true)) // 
            {
                MessageBox.Show("The total price is smaller than 10 is not allow for caltex.\n please fill password delivery before continue! ", "Neew password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmPasswordContinues vF = new FrmPasswordContinues();
                if (vF.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
            }


            if (MessageBox.Show("Are you sure, you already to process this take order?(Yes/No)", "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Initialized.R_MessageAlert = "";
            Initialized.R_DocumentNumber = "";
            Initialized.R_LineCode = "";
            Initialized.R_DeptCode = "";
            string sMsg = "";


            if (IsDutchmill == false)
            {
                if (this.rdbcostlowecommerence.Checked == true)
                {
                    sMsg = this.rdbcostlowecommerence.Text.Trim().ToUpper();
                }
                FrmDeliveryTakeOrderMessage vFrm2_ = new FrmDeliveryTakeOrderMessage();
                vFrm2_.TxtRemark.Text = sMsg;
                if (vFrm2_.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (sCusNum.Trim().Equals("CUS00506") == true)
                {
                    FrmDeliveryTakeOrderInfoAeon vF = new FrmDeliveryTakeOrderInfoAeon();
                    vF.TxtDocumentNumber.Text = this.TxtPONo.Text.Trim();
                    vF.ShowDialog();

                }
            }





            // check Invoice Number 
            decimal InvNo = 0;
            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RCom.Connection = RCon;
            RCom.CommandText = string.Format("SELECT  * FROM [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo]  ", Data.PrefixDatabase, Data.DatabaseName);
            lst_ = new DataTable();
            lst_.Load(RCom.ExecuteReader());
            if (lst_ != null && lst_.Rows.Count > 0)
            {
                if (lst_.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(Convert.IsDBNull(lst_.Rows[0]["IsBusy"]) ? 0 : lst_.Rows[0]["IsBusy"]))
                    {
                        RCon.Close();
                        MessageBox.Show("Printer is busy!\nPlease wait a few minutes...\nAnother PC is using...", "Printer Is Busy - Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        InvNo = Convert.ToDecimal(Convert.IsDBNull(lst_.Rows[0]["PrintInvNo"]) ? 0 : lst_.Rows[0]["PrintInvNo"]);
                        RCom.CommandText = string.Format("UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 1", Data.PrefixDatabase, Data.DatabaseName);
                        RCom.ExecuteNonQuery();
                    }
                }
                else
                {
                Err_Insert:
                    RCom.CommandText = string.Format("INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo]([PrintInvNo],[IsBusy]) VALUES(0,0)", Data.PrefixDatabase, Data.DatabaseName);
                    RCom.ExecuteNonQuery();
                    InvNo = 0;
                    RCon.Close();
                    InvNo += 1;

                    // Key
                    decimal Key = 0;
                    sql_ = @"
DECLARE @ProgramName AS NVARCHAR(100) = 'TakeOrderKeyNumber';
UPDATE [{0}].[dbo].[TblAutoNumber] 
SET [AutoNumber] = 0, [CreatedDate] = GETDATE() 
WHERE [ProgramName] = @ProgramName AND DATEDIFF(DAY,[CreatedDate],GETDATE()) <> 0;

UPDATE [{0}].[dbo].[TblAutoNumber] 
SET [AutoNumber] = ISNULL([AutoNumber],0) + 1, [CreatedDate] = GETDATE() 
WHERE [ProgramName] = @ProgramName;

SELECT [AutoNumber] 
FROM [{0}].[dbo].[TblAutoNumber] 
WHERE [ProgramName] = @ProgramName;
";
                    sql_ = string.Format(sql_, DatabaseName, rSupNum);
                    lst_ = Data.Selects(sql_, Initialized.GetConnectionType(Data, App));
                    if (lst_ != null)
                    {
                        if (lst_.Rows.Count > 0)
                        {
                            Key = Convert.ToDecimal(Convert.IsDBNull(lst_.Rows[0]["AutoNumber"]) ? 0 : lst_.Rows[0]["AutoNumber"]);
                        }
                    }
                    string RelatedKey = string.Format("{0:yyMMdd}{1}", Todate, Key);

                    RCon.Open();
                    RTran = RCon.BeginTransaction();
                    try
                    {
                        RCom.Transaction = RTran;
                        RCom.Connection = RCon;
                        RCom.CommandType = CommandType.Text;
                        var names = (from row in DeliveryTakeOrderList.AsEnumerable()
                                     select row.Field<string>("Division")).Distinct();
                        foreach (string ls in names)
                        {
                            // Promotion
                            DataRow[] pro_ = vPromotionList.Select("Division = '" + ls.Trim() + "'");
                            foreach (DataRow r in pro_)
                            {
                                sql_ = @" DECLARE @vTakeOrderNumber AS NVARCHAR(25) = N'{1}';
                                DECLARE @vPromotionIdLink AS DECIMAL(18,0) = {2};
                                DECLARE @vQtyInvoicing AS INT = 1;
                                INSERT INTO [{0}].[dbo].[TblProductsPromotionSetting.AllowableInvoicing]([TakeOrderNumber],[PromotionIdLink],[QtyInvoicing],[CreatedDate])
                                VALUES(@vTakeOrderNumber,@vPromotionIdLink,@vQtyInvoicing,GETDATE());";

                                sql_ = string.Format(sql_, DatabaseName, InvNo,
                                Convert.ToInt32(Convert.IsDBNull(r["PromotionIdLink"]) ? 0 : r["PromotionIdLink"]),
                                Convert.ToInt32(Convert.IsDBNull(r["QtyInvoicing"]) ? 0 : r["QtyInvoicing"]));
                                RCom.CommandText = sql_;
                                RCom.ExecuteNonQuery();
                                // ApplicationDoEvents()

                            }
                            // TO

                            DataRow[] to_ = DeliveryTakeOrderList.Select("Division = '" + ls.Trim() + "'");





                            foreach (DataRow r in to_)
                            {

                                sql_ = @"  DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
                                DECLARE @CusName AS NVARCHAR(100) = N'';
                                DECLARE @DelToId AS DECIMAL(18,0) = {2} ;
                                DECLARE @DelTo AS NVARCHAR(100) = N'';
                                DECLARE @DateOrd AS DATE = N'{3:yyyy-MM-dd}';
                                DECLARE @DateRequired AS DATE = N'{4:yyyy-MM-dd}';
                                DECLARE @UnitNumber AS NVARCHAR(15) = N'';
                                DECLARE @Barcode AS NVARCHAR(15) = N'{5}';
                                DECLARE @ProName AS NVARCHAR(100) = N'';
                                DECLARE @Size AS NVARCHAR(30) = N'';
                                DECLARE @QtyPCase AS INT = 1;
                                DECLARE @QtyPPack AS INT = 1;
                                DECLARE @Category AS NVARCHAR(100) = N'';
                                DECLARE @PcsFree AS INT = {6};
                                DECLARE @PcsOrder AS INT = {7};
                                DECLARE @PackOrder AS INT = {8};
                                DECLARE @CTNOrder AS FLOAT = {9};
                                DECLARE @TotalPcsOrder AS INT = 0;
                                DECLARE @PONumber AS NVARCHAR(50) = N'{10}';
                                DECLARE @LogInName AS NVARCHAR(100) = N'{11}';
                                DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{12}';
                                DECLARE @PromotionMachanic AS NVARCHAR(500) = N'{13}';
                                DECLARE @ItemDiscount AS FLOAT = {14};
                                DECLARE @Remark AS NVARCHAR(100) = N'{15}';
                                DECLARE @Saleman AS NVARCHAR(100) = N'{16}';
                                DECLARE @OnlinePO AS BIT = {17};
                                DECLARE @RelatedKey AS NVARCHAR(10) = N'{18}';
                                DECLARE @IsDutchmill AS BIT = {19};
                                DECLARE @DeliveryDate AS DATE = N'{20:yyyy-MM-dd}';
                                DECLARE @Reason_Continue AS NVARCHAR(1000) = N'{21}';
                                DECLARE @warehouseId AS UNIQUEIDENTIFIER = '{22}';

                                WITH sCustomer
                                AS (SELECT [CusName] FROM [Stock].[dbo].[TPRCustomer] WHERE [CusNum] = @CusNum
                                    UNION ALL
                                    SELECT [CusName] FROM [DBCostLowECommerce].[dbo].[TblCustomer] WHERE [CusNum] = @CusNum)
                                SELECT @CusName = [CusName]
                                FROM sCustomer;

                                WITH sDelto
                                AS (SELECT [DelTo] FROM [Stock].[dbo].[TPRDelto] WHERE [DefId] = @DelToId
                                    UNION ALL
                                    SELECT [DelTo] FROM [DBCostLowECommerce].[dbo].[TblCustomer] WHERE [DefId] = @DelToId)
                                SELECT @DelTo = [DelTo]
                                FROM sDelto;

                                SELECT @UnitNumber=[ProNumY],@ProName=[ProName],@Size=[ProPacksize],@QtyPCase=ISNULL([ProQtyPCase],1),@QtyPPack=ISNULL([ProQtyPPack],1),@Category=[ProCat]
                                FROM (
	                                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName],[ProCat]
	                                FROM [Stock].[dbo].[TPRProducts]
	                                WHERE (ISNULL([ProNumY],'') = @Barcode OR ((ISNULL([ProNumYP],N'') <> N'') AND (ISNULL([ProNumYP],N'') = @Barcode)) OR ((ISNULL([ProNumYC],N'') <> N'') AND (ISNULL([ProNumYC],N'') = @Barcode)))
	                                UNION ALL
	                                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName],A.[ProCat]
	                                FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                                WHERE B.[OldProNumy] = @Barcode
	                                UNION ALL
	                                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName],[ProCat]
	                                FROM [Stock].[dbo].[TPRProductsDeactivated]
	                                WHERE (ISNULL([ProNumY],'') = @Barcode OR ((ISNULL([ProNumYP],N'') <> N'') AND (ISNULL([ProNumYP],N'') = @Barcode)) OR ((ISNULL([ProNumYC],N'') <> N'') AND (ISNULL([ProNumYC],N'') = @Barcode)))
	                                UNION ALL
	                                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName],A.[ProCat]
	                                FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                                WHERE B.[OldProNumy] = @Barcode
                                ) LISTS;
                                SET @TotalPcsOrder = ((@CTNOrder*@QtyPCase) + (@PackOrder*@QtyPPack) + @PcsOrder + @PcsFree);
                                IF (@IsDutchmill = 0)
                                BEGIN
                                    INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[warehouseId],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[DeliveryDate],[Verifed])
                                    VALUES(@CusNum,@CusName,@DelToId,@DelTo,@DateOrd,@DateRequired,@warehouseId,@UnitNumber,@Barcode,@ProName,@Size,@QtyPCase,@QtyPPack,@Category,@PcsFree,@PcsOrder,@PackOrder,@CTNOrder,@TotalPcsOrder,@PONumber,@LogInName,@TakeOrderNumber,@PromotionMachanic,@ItemDiscount,@Remark,@Saleman,GETDATE(),@DeliveryDate,N'ok');

                                    IF (@OnlinePO = 1)
                                    BEGIN
                                        INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrder_OnlineFinish]([CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],[ProNumy],[ProName],[ProPackSize],[ProQtyPCase],[PcsFree],[PcsOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[PromotionMachanic],[ProCat],[TranDate],[RemarkExpiry],[Saleman],[UserId],[UOM],[OrderNum],[Status],[CreatedDate],[FinishDate],[DeliveryDate])
                                        SELECT [CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],[ProNumy],[ProName],[ProPackSize],[ProQtyPCase],[PcsFree],[PcsOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[PromotionMachanic],[ProCat],[TranDate],[RemarkExpiry],[Saleman],[UserId],[UOM],[OrderNum],[Status],[CreatedDate],GETDATE(),@DeliveryDate
                                        FROM [{0}].[dbo].[TblDeliveryTakeOrder_Online]
                                        WHERE [CusNum] = @CusNum AND [DelTo] = @DelTo AND [ProNumy] = @Barcode AND ISNULL([TotalPcsOrder],0) = @TotalPcsOrder;

                                        DELETE FROM [{0}].[dbo].[TblDeliveryTakeOrder_Online]
                                        WHERE [CusNum] = @CusNum AND [DelTo] = @DelTo AND [ProNumy] = @Barcode AND ISNULL([TotalPcsOrder],0) = @TotalPcsOrder;
                                    END;

                                    INSERT INTO [DBStockHistory].[dbo].[TblProcessHistory]([UnitNumber],[PackNumber],[CaseNumber],[ProName],[Size],[QtyPerCase],[Supplier],[ProgramName],[TransDate],[BeforeStock],[TransQty],[EndStock],[InvNumber],[Name],[Batchcode],[Location],[RelatedKey],[CreatedDate])  
                                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],N'Delivery Take Order' AS [ProgramName],[TransDate],[BeforeStock], @TotalPcsOrder  AS [TransQty],[EndStock],@TakeOrderNumber AS [InvNumber],@CusNum + SPACE(3) + @CusName AS [Name],NULL AS [Batchcode],NULL AS [Location],@RelatedKey,GETDATE()  
                                    FROM (  
	                                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([ProTotQty],0) AS [BeforeStock],ISNULL([ProTotQty],0) AS [EndStock]  
	                                    FROM [Stock].[dbo].[TPRProducts]  
	                                    WHERE (ISNULL([ProNumY],'') = @Barcode OR ((ISNULL([ProNumYP],N'') <> N'') AND (ISNULL([ProNumYP],N'') = @Barcode)) OR ((ISNULL([ProNumYC],N'') <> N'') AND (ISNULL([ProNumYC],N'') = @Barcode)))
	                                    UNION ALL  
	                                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([ProTotQty],0) AS [BeforeStock],ISNULL([ProTotQty],0) AS [EndStock]  
	                                    FROM [Stock].[dbo].[TPRProductsDeactivated]  
	                                    WHERE (ISNULL([ProNumY],'') = @Barcode OR ((ISNULL([ProNumYP],N'') <> N'') AND (ISNULL([ProNumYP],N'') = @Barcode)) OR ((ISNULL([ProNumYC],N'') <> N'') AND (ISNULL([ProNumYC],N'') = @Barcode)))
	                                    UNION ALL  
	                                    SELECT [OldProNumy] AS [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([Stock],0) AS [BeforeStock],ISNULL([Stock],0) AS [EndStock]  
	                                    FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]  
	                                    WHERE B.[OldProNumy] = @Barcode
	                                    UNION ALL  
	                                    SELECT [OldProNumy] AS [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([Stock],0) AS [BeforeStock],ISNULL([Stock],0) AS [EndStock]  
	                                    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]  
	                                    WHERE B.[OldProNumy] = @Barcode
                                    ) LISTS;
                                END;
                                ELSE
                                BEGIN
                                    INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[warehouseId],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[DeliveryDate])
                                    VALUES(@CusNum,@CusName,@DelToId,@DelTo,@DateOrd,@DateRequired,@warehouseId,@UnitNumber,@Barcode,@ProName,@Size,@QtyPCase,@QtyPPack,@Category,@PcsFree,@PcsOrder,@PackOrder,@CTNOrder,@TotalPcsOrder,@PONumber,@LogInName,@TakeOrderNumber,@PromotionMachanic,@ItemDiscount,@Remark,@Saleman,GETDATE(),@DeliveryDate);
                                END;

                                DECLARE @oSupNum AS NVARCHAR(8) = N'';
                                DECLARE @oStock AS DECIMAL(18,0) = 0;
                                WITH oList AS (
	                                SELECT LEFT(v.Sup1,8) AS [SupNum],v.ProTotQty AS Stock FROM [Stock].[dbo].[TPRProducts] AS v WHERE v.ProNumY = @UnitNumber
	                                UNION 
	                                SELECT LEFT(v.Sup1,8) AS [SupNum],v.ProTotQty AS Stock FROM [Stock].[dbo].[TPRProductsDeactivated] AS v WHERE v.ProNumY = @UnitNumber
	                                UNION 
	                                SELECT LEFT(v.Sup1,8) AS [SupNum],o.Stock  FROM [Stock].[dbo].[TPRProducts] AS v INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS o ON o.ProId = v.ProID WHERE o.OldProNumy = @UnitNumber
	                                UNION 
	                                SELECT LEFT(v.Sup1,8) AS [SupNum],o.Stock FROM [Stock].[dbo].[TPRProductsDeactivated] AS v INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS o ON o.ProId = v.ProID WHERE o.OldProNumy = @UnitNumber
                                )
                                SELECT o.SupNum, ISNULL(SUM(o.Stock),0) AS Stock
                                INTO #vList
                                FROM oList AS o
                                GROUP BY o.SupNum;
                                SELECT @oSupNum = o.SupNum, @oStock = ISNULL(SUM(o.Stock),0)
                                FROM #vList AS o
                                GROUP BY o.SupNum;
                                IF NOT EXISTS (SELECT * FROM [Stock].[dbo].[TPRDeliveryDutchmill] WHERE SupNum IN (SELECT o.SupNum FROM #vList AS o GROUP BY o.SupNum))
                                BEGIN
	                                DECLARE @oTotalPcsOrder AS DECIMAL(18,0) = 0;
	                                WITH oList AS (		                                
                                        SELECT SUM([totalpcsorder]) [TotalPcsOrder]
                                        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry]
                                        WHERE ([unitnumber] = @UnitNumber)
                                        UNION ALL
                                        SELECT SUM([totalpcsorder]) [TotalPcsOrder]
                                        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.picking]
                                        WHERE ([unitnumber] = @UnitNumber)
                                        UNION ALL
                                        SELECT SUM([totalpcsorder]) [TotalPcsOrder]
                                        FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.invoicing]
                                        WHERE ([unitnumber] = @UnitNumber)
	                                )
	                                SELECT @oTotalPcsOrder = ISNULL(SUM(o.TotalPcsOrder),0)
	                                FROM oList AS o;

	                                IF (@oStock < @oTotalPcsOrder)
	                                BEGIN
                                        DELETE FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_AlertNotEnoughStock] WHERE ([UnitNumber] = @UnitNumber);

		                                INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_AlertNotEnoughStock]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate])
		                                VALUES(@CusNum,@CusName,@DelToId,@DelTo,@DateOrd,@DateRequired,@UnitNumber,@Barcode,@ProName,@Size,@QtyPCase,@QtyPPack,@Category,@PcsFree,@PcsOrder,@PackOrder,@CTNOrder,@TotalPcsOrder,@PONumber,@LogInName,@TakeOrderNumber,@PromotionMachanic,@ItemDiscount,@Remark,@Saleman,GETDATE());
	                                END;
                                END;
                                DROP TABLE #vList;

IF (RTRIM(LTRIM(@Reason_Continue)) <> N'')
BEGIN
    DELETE FROM [DBUNTWHOLESALECOLTD].[dbo].[tbl.customer.over.order] WHERE ([barcode] = @Barcode);

    INSERT INTO [DBUNTWHOLESALECOLTD].[dbo].[tbl.customer.over.order]
    (
        [takeordernumber],
        [cusnum],
        [cusname],
        [deltoid],
        [delto],
        [barcode],
        [proname],
        [size],
        [qtypercase],
        [totalpcsorder],
        [reason],
        [createddate]
    )
    VALUES
    (@TakeOrderNumber, @CusNum, @CusName, @DelToId, @DelTo, @Barcode, @ProName, @Size, @QtyPCase, @TotalPcsOrder, @Reason_Continue,
     GETDATE());
END;

IF (@OnlinePO = 1)
BEGIN
    DECLARE @xcurdate_ AS DATETIME = GETDATE();
    INSERT INTO [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails_Finish]
    (
        [PrimaryKey],
        [POId],
        [PONumber],
        [Barcode],
        [ProductName],
        [Size],
        [QtyPerCase],
        [QtyPerPack],
        [Price],
        [PcsOrder],
        [PackOrder],
        [CtnOrder],
        [CreatedAt],
        [UpdatedAt],
        [IsBonus],
        [expirydate],
        [TONumber],
        [FinishDate]
    )
    SELECT [x].[Id],
           [x].[POId],
           [x].[PONumber],
           [x].[Barcode],
           [x].[ProductName],
           [x].[Size],
           [x].[QtyPerCase],
           [x].[QtyPerPack],
           [x].[Price],
           [x].[PcsOrder],
           [x].[PackOrder],
           [x].[CtnOrder],
           [x].[CreatedAt],
           [x].[UpdatedAt],
           [x].[IsBonus],
           [x].[expirydate],
           @TakeOrderNumber,
           @xcurdate_
    FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails] x
        INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
            ON ([v].[Id] = [x].[POId])
    WHERE ([v].[OrderDate] IS NOT NULL)
          AND ([v].[DeliveryDate] IS NOT NULL)
          AND ([v].[CusNum] = @CusNum)
          AND ([v].[DeltoId] = @DelToId)
          AND ([x].[Barcode] = @Barcode);

    DELETE FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails]
    WHERE ([Id] IN
           (
               SELECT [PrimaryKey]
               FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails_Finish]
           )
          );

    INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dry.isbonus]
    (
        [takeordernumber],
        [unitnumber],
        [expirydate],
        [createddate]
    )
    SELECT [x].[TONumber],
           [x].[Barcode],
           [x].[expirydate],
           GETDATE()
    FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails_Finish] x
    WHERE (COALESCE([x].[TONumber], N'0') = @TakeOrderNumber)
          AND (COALESCE([x].[IsBonus], 0) = 1);
END;
                      ";

                                sql_ = string.Format(sql_, DatabaseName, CmbBillTo.SelectedValue, CmbDelto.SelectedValue,

        Convert.ToDateTime(string.IsNullOrWhiteSpace(TxtOrderDate.Text.Trim())
        ? Todate.ToString("yyyy-MM-dd") // Ensure Todate is a valid DateTime
        : TxtOrderDate.Text.Trim()),

                                DTPRequiredDate.Value, r["Barcode"],
          Convert.ToDecimal(Convert.IsDBNull(r["PcsFree"]) ? 0 : r["PcsFree"]),
          Convert.ToDecimal(Convert.IsDBNull(r["PcsOrder"]) ? 0 : r["PcsOrder"]),
          Convert.ToDecimal(Convert.IsDBNull(r["PackOrder"]) ? 0 : r["PackOrder"]),
          Convert.ToSingle(Convert.IsDBNull(r["CTNOrder"]) ? 0 : r["CTNOrder"]),
          TxtPONo.Text.Replace("'", "`").Trim(), TxtEmpName.Text.Trim(), InvNo,
          Convert.IsDBNull(r["PromotionMachanic"]) ? "" : r["PromotionMachanic"].ToString().Trim(),
          Convert.ToSingle(Convert.IsDBNull(r["ItemDiscount"]) ? 0 : r["ItemDiscount"]),
          Convert.IsDBNull(r["Remark"]) ? "" : r["Remark"].ToString().Trim(),
          CmbSaleman.SelectedValue, RdbOnlinePO.Checked ? 1 : 0, RelatedKey,
          IsDutchmill ? 1 : 0, DTPDeliverDate.Value,
          Convert.IsDBNull(r["Reason_Continue"]) ? "" : r["Reason_Continue"].ToString().Trim(), warehouseName.id
      );
                                RCom.CommandText = sql_;
                                RCom.ExecuteNonQuery();
                                // Application.DoEvents();


                                foreach (DataRow o in vFixedPriceList.Rows)
                                {
                                    if (string.IsNullOrWhiteSpace(Convert.IsDBNull(o["Barcode"]) ? "" : o["Barcode"].ToString().Trim())
                                        .Equals(string.IsNullOrWhiteSpace(Convert.IsDBNull(r["Barcode"]) ? "" : r["Barcode"].ToString().Trim())))
                                    {
                                        sql_ = @"
            DECLARE @vTakeOrderNumber AS NVARCHAR(25) = N'{1}';
            DECLARE @vFixedIdLink AS DECIMAL(18,0) = {2};
            DECLARE @vQtyInvoicing AS INT = 1;
            INSERT INTO [{0}].[dbo].[TblProductsPriceSetting.AllowableInvoicing]([TakeOrderNumber],[FixedIdLink],[QtyInvoicing],[CreatedDate])
            VALUES(@vTakeOrderNumber,@vFixedIdLink,@vQtyInvoicing,GETDATE());
        ";
                                        sql_ = string.Format(sql_, DatabaseName, InvNo,
                                            Convert.ToInt32(Convert.IsDBNull(o["FixedIdLink"]) ? 0 : o["FixedIdLink"]),
                                            Convert.ToInt32(Convert.IsDBNull(o["QtyInvoicing"]) ? 0 : o["QtyInvoicing"]));
                                        RCom.CommandText = sql_;
                                        RCom.ExecuteNonQuery();
                                        // Application.DoEvents();
                                        break;
                                    }
                                }




                            }

                            if (this.rdbcostlowecommerence.Checked == true)
                            {
                                sql_ = @"DECLARE @vTakeOrderNumber AS NVARCHAR(25) = N'{1}';
WITH sPurchase
AS (SELECT [Id],
           [CusNum],
           [CusName],
           [DelToId],
           [DelTo],
           [DateOrd],
           [DateRequired],
           [DeliveryDate],
           [UnitNumber],
           [Barcode],
           [ProName],
           [Size],
           [QtyPCase],
           [QtyPPack],
           [Category],
           [PcsFree],
           [PcsOrder],
           [PackOrder],
           [CTNOrder],
           [TotalPcsOrder],
           [PONumber],
           [LogInName],
           [TakeOrderNumber],
           [PromotionMachanic],
           [ItemDiscount],
           [Remark],
           [Saleman],
           [CreatedDate],
           CONVERT(NVARCHAR, N'Dry') [Note]
    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
    WHERE [TakeOrderNumber] = @vTakeOrderNumber
    UNION ALL
    SELECT [Id],
           [CusNum],
           [CusName],
           [DelToId],
           [DelTo],
           [DateOrd],
           [DateRequired],
           [DeliveryDate],
           [UnitNumber],
           [Barcode],
           [ProName],
           [Size],
           [QtyPCase],
           [QtyPPack],
           [Category],
           [PcsFree],
           [PcsOrder],
           [PackOrder],
           [CTNOrder],
           [TotalPcsOrder],
           [PONumber],
           [LogInName],
           [TakeOrderNumber],
           [PromotionMachanic],
           [ItemDiscount],
           [Remark],
           [Saleman],
           [CreatedDate],
           CONVERT(NVARCHAR, N'Dutchmill') [Note]
    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
    WHERE [TakeOrderNumber] = @vTakeOrderNumber)
INSERT INTO [DBCostLowECommerce].[dbo].[TblDeliveryTakeOrders]
(
    [CusNum],
    [CusName],
    [DelToId],
    [DelTo],
    [DateOrd],
    [DateRequired],
    [DeliveryDate],
    [UnitNumber],
    [Barcode],
    [ProName],
    [Size],
    [QtyPCase],
    [QtyPPack],
    [Category],
    [PcsFree],
    [PcsOrder],
    [PackOrder],
    [CTNOrder],
    [TotalPcsOrder],
    [PONumber],
    [LogInName],
    [TakeOrderNumber],
    [PromotionMachanic],
    [ItemDiscount],
    [Remark],
    [Saleman],
    [Note],
    [CreatedDate],[Verifed]
)
SELECT [CusNum],
       [CusName],
       [DelToId],
       [DelTo],
       [DateOrd],
       [DateRequired],
       [DeliveryDate],
       [UnitNumber],
       [Barcode],
       [ProName],
       [Size],
       [QtyPCase],
       [QtyPPack],
       [Category],
       [PcsFree],
       [PcsOrder],
       [PackOrder],
       [CTNOrder],
       [TotalPcsOrder],
       [PONumber],
       [LogInName],
       [TakeOrderNumber],
       [PromotionMachanic],
       [ItemDiscount],
       [Remark],
       [Saleman],
       [Note],
       GETDATE(),N'ok'
FROM sPurchase;  ";

                                sql_ = string.Format(sql_, DatabaseName, InvNo);
                                RCom.CommandText = sql_;
                                RCom.ExecuteNonQuery();
                                // Application.DOEvents();

                            }

                            if (IsDutchmill == false)
                            {
                                if (sMsg.Trim().Equals(""))
                                {
                                    Initialized.R_MessageAlert = Initialized.R_MessageAlert.Replace("'", "`").Trim();
                                }
                                else
                                {
                                    if (Initialized.R_MessageAlert.Replace("'", "`").Trim().Equals(""))
                                    {
                                        Initialized.R_MessageAlert = string.Format("{0}", sMsg);
                                    }
                                    else
                                    {
                                        if (Initialized.R_MessageAlert.Contains(sMsg))
                                        {
                                            Initialized.R_MessageAlert = string.Format("{0}", Initialized.R_MessageAlert.Replace("'", "`").Trim());
                                        }
                                        else
                                        {
                                            Initialized.R_MessageAlert = string.Format("{0}::{1}", sMsg, Initialized.R_MessageAlert.Replace("'", "`").Trim());
                                        }
                                    }
                                }

                                sql_ = @"DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{1}';
                                DECLARE @RelatedKey AS NVARCHAR(10) = N'{2}';
                                DECLARE @vMessageAlert AS NVARCHAR(MAX) = N'{3}';

                                WITH oList AS (
	                                SELECT v.ProNumY [UnitNumber],LEFT(v.Sup1,8) [SupNum]
	                                FROM [Stock].[dbo].[TPRProducts] v 
	                                GROUP BY v.ProNumY,LEFT(v.Sup1,8)
	                                UNION ALL
	                                SELECT v.ProNumY [UnitNumber],LEFT(v.Sup1,8) [SupNum]
	                                FROM [Stock].[dbo].[TPRProductsDeactivated] v 
	                                GROUP BY v.ProNumY,LEFT(v.Sup1,8)
	                                UNION ALL
	                                SELECT o.OldProNumy [UnitNumber],LEFT(v.Sup1,8) [SupNum]
	                                FROM [Stock].[dbo].[TPRProducts] v INNER JOIN [Stock].[dbo].[TPRProductsOldCode] o ON o.ProId = v.ProID
	                                GROUP BY o.OldProNumy,LEFT(v.Sup1,8)
	                                UNION ALL
	                                SELECT o.OldProNumy [UnitNumber],LEFT(v.Sup1,8) [SupNum]
	                                FROM [Stock].[dbo].[TPRProductsDeactivated] v INNER JOIN [Stock].[dbo].[TPRProductsOldCode] o ON o.ProId = v.ProID
	                                GROUP BY o.OldProNumy,LEFT(v.Sup1,8)
                                )
                                SELECT o.*
                                INTO #vProducts
                                FROM oList o;

                                WITH l AS (
	                                SELECT [SupNum],[SupName]
	                                FROM [Stock].[dbo].[TPRDeliveryDutchmill]
	                                GROUP BY [SupNum],[SupName]
	                                UNION ALL
	                                SELECT [SupNum],[SupName]
	                                FROM [Stock].[dbo].[TPRDeliveryDutchmill.Location]
	                                GROUP BY [SupNum],[SupName]
                                )
                                SELECT l.*
                                INTO #vDutchmill
                                FROM l;

                                IF NOT EXISTS (SELECT * FROM [{0}].[dbo].[TblDeliveryTakeOrders] WHERE ([TakeOrderNumber] = @TakeOrderNumber) AND [UnitNumber] IN (SELECT o.UnitNumber FROM #vProducts o WHERE o.SupNum IN (SELECT v.SupNum FROM #vDutchmill v GROUP BY v.SupNum) GROUP BY o.UnitNumber))
                                BEGIN
DECLARE @vnewtakeorder_ AS DECIMAL(18, 0) = (@TakeOrderNumber + 1);
DECLARE @vcusnum_ AS NVARCHAR(8) = N'';
DECLARE @vcusvat_ AS NVARCHAR(25) = N'';
DECLARE @vtotalrow_ AS DECIMAL(18, 0) = 0;
DECLARE @vcopies_ AS INT = 0;
DECLARE @vnum_ AS INT = 0;
DECLARE @vnum_temp_ AS DECIMAL(18, 0) = 0;
DECLARE @tbl_ AS TABLE
(
    [invnum_] [DECIMAL](18, 0) NULL
);
INSERT INTO @tbl_
(
    [invnum_]
)
VALUES
(@TakeOrderNumber);
SELECT *
INTO #lst_takeorder_{4}
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
WHERE ([TakeOrderNumber] = @TakeOrderNumber)
      AND ([CusNum] NOT IN
           (
               SELECT [CusNum]
               FROM [DBUNTWHOLESALECOLTD].[dbo].[TblSetCustomerIntoDivisionVAT]
               GROUP BY [CusNum]
           )
          )
ORDER BY [Id];

SELECT @vcusnum_ = COALESCE([x].[CusNum], N'')
FROM #lst_takeorder_{4} x
WHERE ([x].[TakeOrderNumber] = @TakeOrderNumber);

SELECT @vtotalrow_ = COUNT(*)
FROM #lst_takeorder_{4} x
WHERE ([x].[TakeOrderNumber] = @TakeOrderNumber);

SELECT @vcusvat_ = COALESCE([x].[CusVat], N'')
FROM [Stock].[dbo].[TPRCustomer] x
WHERE (COALESCE([x].[CusNum], N'') = @vcusnum_);

IF ((@vcusvat_ = N'') OR (@vcusvat_ = N'0'))
BEGIN
    SET @vnum_ = 21;
    IF (@vtotalrow_ > @vnum_)
    BEGIN
        INSERT INTO @tbl_
        (
            [invnum_]
        )
        VALUES
        (@vnewtakeorder_);
        SET @vcopies_ += 1;

        SET @vnum_temp_ = 1;
        DECLARE @oid2_ AS DECIMAL(18, 0) = 0;
        DECLARE cur_ CURSOR FOR
        SELECT [Id]
        FROM #lst_takeorder_{4} x
        WHERE ([TakeOrderNumber] = @TakeOrderNumber)
              AND ([x].[Id] NOT IN
                   (
                       SELECT TOP 21
                              [x].[Id]
                       FROM #lst_takeorder_{4} x
                       WHERE ([TakeOrderNumber] = @TakeOrderNumber)
                   )
                  )
        ORDER BY [Id];
        OPEN cur_;
        FETCH NEXT FROM cur_
        INTO @oid2_;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            IF (@vnum_ <= @vnum_temp_)
            BEGIN
                SET @vnum_temp_ = 1;
                SET @vcopies_ += 1;
                SET @vnewtakeorder_ += 1;
                INSERT INTO @tbl_
                (
                    [invnum_]
                )
                VALUES
                (@vnewtakeorder_);
            END;

            UPDATE x
            SET [x].[TakeOrderNumber] = @vnewtakeorder_
            FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] x
            WHERE ([x].[TakeOrderNumber] = @TakeOrderNumber)
                  AND ([x].[Id] = @oid2_);

            SET @vnum_temp_ += 1;
            FETCH NEXT FROM cur_
            INTO @oid2_;
        END;
        CLOSE cur_;
        DEALLOCATE cur_;
    END;
END;
ELSE
BEGIN
    SET @vnum_ = 12;
    IF (@vtotalrow_ > @vnum_)
    BEGIN
        INSERT INTO @tbl_
        (
            [invnum_]
        )
        VALUES
        (@vnewtakeorder_);
        SET @vcopies_ += 1;

        SET @vnum_temp_ = 1;
        DECLARE @oid_ AS DECIMAL(18, 0) = 0;
        DECLARE cur CURSOR FOR
        SELECT [Id]
        FROM #lst_takeorder_{4} x
        WHERE ([TakeOrderNumber] = @TakeOrderNumber)
              AND ([x].[Id] NOT IN
                   (
                       SELECT TOP 12
                              [x].[Id]
                       FROM #lst_takeorder_{4} x
                       WHERE ([TakeOrderNumber] = @TakeOrderNumber)
                   )
                  )
        ORDER BY [Id];
        OPEN cur;
        FETCH NEXT FROM cur
        INTO @oid_;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            IF (@vnum_ <= @vnum_temp_)
            BEGIN
                SET @vnum_temp_ = 1;
                SET @vcopies_ += 1;
                SET @vnewtakeorder_ += 1;
                INSERT INTO @tbl_
                (
                    [invnum_]
                )
                VALUES
                (@vnewtakeorder_);
            END;

            UPDATE x
            SET [x].[TakeOrderNumber] = @vnewtakeorder_
            FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] x
            WHERE ([x].[TakeOrderNumber] = @TakeOrderNumber)
                  AND ([x].[Id] = @oid_);

            SET @vnum_temp_ += 1;
            FETCH NEXT FROM cur
            INTO @oid_;
        END;
        CLOSE cur;
        DEALLOCATE cur;
    END;
END;

INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dry]
(
    [cusnum],
    [cusname],
    [deltoid],
    [delto],
    [dateorder],
    [daterequired],
    [deliverydate],
    [warehouseId],
    [unitnumber],
    [barcode],
    [proname],
    [size],
    [qtypercase],
    [qtyperpack],
    [category],
    [pcsfree],
    [pcsorder],
    [packorder],
    [ctnorder],
    [totalpcsorder],
    [ponumber],
    [loginname],
    [takeordernumber],
    [promotionmachanic],
    [itemdiscount],
    [remark],
    [saleman],
    [note],
    [createddate]
)
SELECT [CusNum],
       [CusName],
       [DelToId],
       [DelTo],
       [DateOrd],
       [DateRequired],
       [DeliveryDate],
       [warehouseId],
       [UnitNumber],
       [Barcode],
       [ProName],
       [Size],
       [QtyPCase],
       [QtyPPack],
       [Category],
       [PcsFree],
       [PcsOrder],
       [PackOrder],
       [CTNOrder],
       [TotalPcsOrder],
       [PONumber],
       [LogInName],
       [TakeOrderNumber],
       [PromotionMachanic],
       [ItemDiscount],
       [Remark],
       [Saleman],
       @vMessageAlert,
       [CreatedDate]
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
WHERE ([TakeOrderNumber] IN
       (
           SELECT [invnum_] FROM @tbl_
       )
      );
DROP TABLE #lst_takeorder_{4};
                                END;
                                ELSE
                                BEGIN
	                                INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill]([cusnum],[cusname],[deltoid],[delto],[dateorder],[daterequired],[deliverydate],[warehouseId],[unitnumber],[barcode],[proname],[size],[qtypercase],[qtyperpack],[category],[pcsfree],[pcsorder],[packorder],[ctnorder],[totalpcsorder],[ponumber],[loginname],[takeordernumber],[promotionmachanic],[itemdiscount],[remark],[saleman],[note],[createddate])
                                    SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[DeliveryDate],[warehouseId],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],@vMessageAlert,[CreatedDate]
                                    FROM [{0}].[dbo].[TblDeliveryTakeOrders]
                                    WHERE ([TakeOrderNumber] = @TakeOrderNumber);
                                END;

                                DROP TABLE #vDutchmill;
                                DROP TABLE #vProducts;";


                                sql_ = string.Format(sql_, DatabaseName, InvNo, RelatedKey, Initialized.R_MessageAlert, Data.GetIPAddress.Replace(".", "").Replace(":", "").Replace("/", "").Replace("-", "").Trim());
                                RCom.CommandText = sql_;
                                RCom.ExecuteNonQuery();


                                if (!string.IsNullOrWhiteSpace(Initialized.R_MessageAlert.Trim()))
                                {
                                    sql_ = $@"
        DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{InvNo}';
        DECLARE @Message AS NVARCHAR(100) = N'{Initialized.R_MessageAlert.Trim()}';
        INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrderAlertToQsDelivery]([InvNo],[CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],[Message],[RegisterDate])
        SELECT [TakeOrderNumber],[CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],@Message,GETDATE()
        FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
        WHERE [TakeOrderNumber] = @TakeOrderNumber;
    ";
                                    RCom.CommandText = sql_;
                                    RCom.ExecuteNonQuery();
                                }

                                if (!string.IsNullOrWhiteSpace(Initialized.R_DocumentNumber.Trim()) &&
                                    !string.IsNullOrWhiteSpace(Initialized.R_LineCode.Trim()) &&
                                    !string.IsNullOrWhiteSpace(Initialized.R_DeptCode.Trim()))
                                {
                                    sql_ = $@"
        DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{InvNo}';
        DECLARE @CusNum AS NVARCHAR(8) = N'{CmbBillTo.SelectedValue}';
        DECLARE @DocumentNumber AS NVARCHAR(20) = N'{Initialized.R_DocumentNumber.Trim()}';
        DECLARE @LineCode AS NVARCHAR(14) = N'{Initialized.R_LineCode.Trim()}';
        DECLARE @DeptCode AS NVARCHAR(14) = N'{Initialized.R_DeptCode.Trim()}';
        INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrder_ForAEON]([SupervisorID],[CusNum],[DocumentNumber],[LineCode],[DeptCode],[TakeOrderID],[DeliveryID])
        VALUES(NULL,@CusNum,@DocumentNumber,@LineCode,@DeptCode,@TakeOrderNumber,NULL);
    ";
                                    RCom.CommandText = sql_;
                                    RCom.ExecuteNonQuery();
                                }


                            }


                            if (RdbOnlinePO.Checked)
                            {
                                sql_ = @"
    INSERT INTO [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder_Finish]
    (
        [POId],
        [PONumber],
        [CusNum],
        [CusName],
        [CusHp1],
        [CusHp2],
        [DeltoId],
        [DeltoName],
        [OrderDate],
        [DeliveryDate],
        [SalesmanNumber],
        [EmpId],
        [CreatedAt],
        [UpdatedAt],
        [TONumber],
        [FinishDate]
    )
    SELECT [v].[Id],
           [v].[PONumber],
           [v].[CusNum],
           [v].[CusName],
           [v].[CusHp1],
           [v].[CusHp2],
           [v].[DeltoId],
           [v].[DeltoName],
           [v].[OrderDate],
           [v].[DeliveryDate],
           [v].[SalesmanNumber],
           [v].[EmpId],
           [v].[CreatedAt],
           [v].[UpdatedAt],
           [x].[TONumber],
           MAX([x].[FinishDate]) [FinishDate]
    FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder] v
        INNER JOIN [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails_Finish] x
            ON ([v].[Id] = [x].[POId])
    WHERE [v].[Id] NOT IN
          (
              SELECT [POId]
              FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrderDetails]
          )
    GROUP BY [v].[Id],
             [v].[PONumber],
             [v].[CusNum],
             [v].[CusName],
             [v].[CusHp1],
             [v].[CusHp2],
             [v].[DeltoId],
             [v].[DeltoName],
             [v].[OrderDate],
             [v].[DeliveryDate],
             [v].[SalesmanNumber],
             [v].[EmpId],
             [v].[CreatedAt],
             [v].[UpdatedAt],
             [x].[TONumber];

    DELETE FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder]
    WHERE [Id] IN
          (
              SELECT [POId] FROM [AppCustomerPurchaseOrder].[dbo].[PurchaseOrder_Finish]
          );
    ";
                                sql_ = string.Format(sql_, DatabaseName);
                                RCom.CommandText = sql_;
                                RCom.ExecuteNonQuery();

                            }
                            decimal vaddmore_ = 0;
                            if (CusVAT.Trim().Equals("") || CusVAT.Trim().Equals("0"))
                            {
                                if (to_.Length >= 21)
                                {
                                    vaddmore_ = Math.Ceiling((to_.Length - 21) / 21.0m) + 1;
                                }
                            }
                            else
                            {
                                if (to_.Length >= 12)
                                {
                                    vaddmore_ = Math.Ceiling((to_.Length - 12) / 12.0m) + 1;
                                }
                            }
                            InvNo += vaddmore_;
                            InvNo += 1;
                        }





                        if (names.ToList().Count > 0)
                        {

                            InvNo -= 1;
                        }
                        sql_ = @"DECLARE @cusNum AS NVARCHAR(8) = N'{0}';
DECLARE @takeOrderNumber AS NVARCHAR(25) = N'{1}';
UPDATE lu
SET [lu].[allowedqtyinv] = ISNULL([lu].[allowedqtyinv], 0) - 1
FROM [DBUNTWHOLESALECOLTD].[dbo].[Tblcustomer-credit-amount-allow-from-manager] lu
WHERE (
          ([lu].[cusnum] = @cusNum)
          AND (ISNULL([lu].[allowedqtyinv], 0) > 0)
      );

DELETE FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE ([TakeOrderNumber] = @takeOrderNumber);";

                        sql_ = string.Format(sql_, this.CmbBillTo.SelectedValue, InvNo);
                        RCom.CommandText = sql_;
                        RCom.ExecuteNonQuery();
                        RCom.CommandText = "UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 0, [PrintInvNo] = " + InvNo;
                        RCom.ExecuteNonQuery();
                        RTran.Commit();
                        RCon.Close();

                        MessageBox.Show("The processing have been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (RdbOnlinePO.Checked == true)
                        {

                            this.TimerCustomerLoading.Enabled = true;
                            this.refreshonlinepo.Interval = 1;

                        }
                        TimerLoading.Enabled = true;
                        CreateDeliveryTakeOrderList();
                        ClearProductItems();
                        App.SetEnableController(true, PanelHeader, PanelBillTo, CmbSaleman);
                        CmbProducts.Focus();
                    }
                    catch (SqlException ex)
                    {

                        RTran.Rollback();
                        RCon.Close();
                        RCon.Open();
                        RCom.CommandType = CommandType.Text;
                        RCom.CommandText = "UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 0";
                        RCom.ExecuteNonQuery();
                        RCon.Close();
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception ex)
                    {
                        RTran.Rollback();
                        RCon.Close();
                        RCon.Open();
                        RCom.CommandType = CommandType.Text;
                        RCom.CommandText = "UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 0"; RCom.ExecuteNonQuery();
                        RCon.Close();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void TxtPcsOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                BtnAdd_Click(BtnAdd, new System.EventArgs());

            }
        }

        private void TxtPackOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                BtnAdd_Click(BtnAdd, new System.EventArgs());

            }
        }

        private void DgvShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (DgvShow.RowCount <= 0) return;


            if (e.KeyCode == Keys.Delete)
            {
                if (DeliveryTakeOrderList != null)
                {
                    string barcode = "";
                    int totalPcs = 0;

                    // Get the current row
                    var currentRow = DgvShow.Rows[DgvShow.CurrentRow.Index];

                    // Safely extract values from the current row
                    barcode = currentRow.Cells["Barcode"].Value != null
                        ? currentRow.Cells["Barcode"].Value.ToString().Trim()
                        : "";

                    totalPcs = currentRow.Cells["TotalPcsOrders"].Value != null
                        ? Convert.ToInt32(currentRow.Cells["TotalPcsOrders"].Value)
                        : 0;

                    // Iterate over the DeliveryTakeOrderList to find and remove matching rows
                    foreach (DataRow r in DeliveryTakeOrderList.Rows)
                    {
                        string rowBarcode = r["Barcode"] != DBNull.Value
                            ? r["Barcode"].ToString().Trim()
                            : "";

                        int rowTotalPcs = r["TotalPcsOrder"] != DBNull.Value
                            ? Convert.ToInt32(r["TotalPcsOrder"])
                            : 0;

                        if (barcode.Equals(rowBarcode) && totalPcs == rowTotalPcs)
                        {
                            DeliveryTakeOrderList.Rows.Remove(r);
                            break;
                        }
                    }
                }

                // Update the row count display
                LblCountRow.Text = string.Format("Count Row: {0}", DgvShow.RowCount);
            }
        }

        private void LblProductsRefresh_Click(object sender, EventArgs e)
        {
            TimerProductLoading.Enabled = true;
        }

        private void TxtSearchStoreCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (TxtSearchStoreCode.Text.Trim() == "") return;
                e.IsInputKey = true;
                string StoreCode = TxtSearchStoreCode.Text.Trim();
                string LinkBarcode = "";
                query = @"
        DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
        DECLARE @StoreCode AS NVARCHAR(MAX) = N'{2}';
        IF EXISTS (SELECT * FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomerSettingForStoreCode] WHERE [CusNum] = @CusNum)
        BEGIN
            SELECT [Id],[CusNum],[Barcode],[ProName],[Size],[CusCode],[CreatedDate]
            FROM [DBUNTWHOLESALECOLTD].[dbo].[TblCustomerCodes]
            WHERE [CusNum] = @CusNum AND [CusCode] = @StoreCode;
        END
    ";
                query = string.Format(query, DatabaseName, CmbBillTo.SelectedValue, StoreCode);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null)
                {
                    if (lists.Rows.Count > 0)
                    {
                        LinkBarcode = DBNull.Value.Equals(lists.Rows[0]["Barcode"]) ? "" : lists.Rows[0]["Barcode"].ToString().Trim();
                        CmbProducts.SelectedValue = LinkBarcode;
                    }
                    else
                    {
                        Goto Err_CheckStorecode;
                    }
                }
                else
                {
                Err_CheckStorecode:
                    XtraMessageBox.Show("The Store code is not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void TxtCusNumSearch_KeyDown(object sender, KeyEventArgs e)
        {
            BtnAdd.Enabled = false;
            CmbBillTo.SelectedIndex = -1;
            if (string.IsNullOrWhiteSpace(TxtCusNumSearch.Text.Trim())) return;

            if (e.KeyCode == Keys.Return)
            {
                string vCusNum = "";
                if (rdbcostlowecommerence.Checked)
                {
                    vCusNum = string.Format("CEC{0:00000}", Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtCusNumSearch.Text.Trim()) ? "0" : TxtCusNumSearch.Text.Trim()));
                }
                else
                {
                    vCusNum = string.Format("CUS{0:00000}", Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtCusNumSearch.Text.Trim()) ? "0" : TxtCusNumSearch.Text.Trim()));
                }
                CmbBillTo.SelectedValue = vCusNum;
            }

        }

        private void TxtCusNumSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);

        }
        private void Wait(int interval)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < interval)
            {
                // Allows UI to remain responsive
                // Application.DoEvents();
            }
            sw.Stop();
        }

        private void DTPDeliverDate_ValueChanged(object sender, EventArgs e)
        {
            if (DTPDeliverDate.Value.Date < Todate.Date)
            {
                MessageBox.Show("Please check Delivery Date again!", "Invalid Delivery Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DTPDeliverDate.Value = Todate;
                return;
            }

        }

        private void CmbProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                DeactivatedProduct();
            }

        }
        private void DeactivatedProduct()
        {
            if (CmbProducts.Items.Count == 0) return;

            DataTable dtDC = CheckDeactivatedItem();
            if (dtDC.Rows.Count > 0)
            {
                MessageBox.Show("This Barcode is in Product Deactivated!\nSending email to office manager automatically.", "Confirm Deactivated Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MailDCSKUReport dcReport = new MailDCSKUReport();
                DataRow dr = dtDC.Rows[0];
                dcReport.Parameters["paramDear"].Value = string.Format("Dear {0},", CmbBillTo.Text);
                dcReport.Parameters["paramPO"].Value = TxtPONo.Text.Replace("'", "`").Trim();
                dcReport.Parameters["paramBarcode"].Value = dr["ProNumY"];
                dcReport.Parameters["paramName"].Value = dr["ProName"];
                dcReport.Parameters["paramSize"].Value = dr["ProPacksize"];

                dcReport.CreateDocument(true);
                try
                {
                    using (SmtpClient client = new SmtpClient("mail.untwholesale.com", 26))
                    {
                        string email = this.QueryCCEmail().Rows[0][0].ToString();
                        using (MailMessage message = dcReport.ExportToMail("sales@untwholesale.com", email, "Product Discontinued"))
                        {
                            client.Credentials = new System.Net.NetworkCredential("sales@untwholesale.com", "UNT@@!@#12345678");
                            client.EnableSsl = true;
                            client.Send(message);
                            MessageBox.Show("Your email has been sent successfully.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Send email failed.");
                }
            }
        }

        private void TxtPcsOrder_TextChanged(object sender, EventArgs e)
        {
            TotalPcsOrder();
        }


        private void TxtPackOrder_TextChanged(object sender, EventArgs e)
        {
            TotalPcsOrder();
        }

        private void TxtCTNOrder_TextChanged(object sender, EventArgs e)
        {
            TotalPcsOrder();

        }

        private void TxtQtyPerCase_TextChanged(object sender, EventArgs e)
        {
            TotalPcsOrder();

        }

        private void txtStockWarehouse_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtWSPrice_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void TxtTotalPcsOrder_TextChanged(object sender, EventArgs e)
        {
            this.refreshtotalpcs.Enabled = true;
            this.refreshtotalpcs.Interval = 500;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPcsOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);
        }

        private void TxtPackOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);


        }

        private void TxtCTNOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);

        }

        private void txtCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 10);


        }

        private void TxtCTNOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BtnAdd_Click(BtnAdd, new EventArgs());
            }

        }

        private void FrmDeliveryTakeOrder_Load(object sender, EventArgs e)
        {

        }

        private void btnAddPromotionID_Click(object sender, EventArgs e)
        {
            guiDeliveryTakeOrderPromotionId deliveryPromotionId = new guiDeliveryTakeOrderPromotionId(this.mdi_);
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;
            deliveryPromotionId.ShowDialog(this.mdi_);



        }

        private void warehouseNameColor_Tick(object sender, EventArgs e)
        {

            lblWarehouseName.ForeColor = Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256));

        }

        private void piccreatecustomerecommerce_Click(object sender, EventArgs e)
        {
            FrmCustomersECommerce gui2 = new FrmCustomersECommerce();
            gui2.ShowDialog(this.mdi_);
            this.TimerCustomerLoading.Enabled = true;


        }

        private void TxtItemDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Float, null, 15);

        }

        private void promotionIdLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.promotionIdLoading.Enabled = false;

            string sql = @"
DECLARE @RC INT;
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[getDeliveryTakeOrderPromotionId];
";

            DataTable tbl = Data.Selects(sql, Initialized.GetConnectionType(Data, App));
            List<deliveryTakeOrderPromotionIdModel> promotionList = this.db.GetDataTableToObject<deliveryTakeOrderPromotionIdModel>(tbl);
            DataTable promotionTable = ConvertToDataTable(promotionList);
            this.DataSources(cmbPromotionId, promotionTable, "promotionId", "id");

            //         this.DataSources(cmbPromotionId, (DataTable)promotionList, "promotionId", "id");

            this.Cursor = Cursors.Default;
        }
        public static DataTable ConvertToDataTable<T>(List<T> list)
        {
            DataTable table = new DataTable();
            if (list == null || list.Count == 0) return table;

            var properties = typeof(T).GetProperties();

            // Create table columns
            foreach (var prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            // Add rows
            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (var prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            return table;
        }

        private void TxtPcsFree_TextChanged(object sender, EventArgs e)
        {
            bool allowManuallyPromotion = false;
            if (this.warehouseName != null)
            {
                if (this.warehouseName.allowManuallyPromotion == true)
                {
                    allowManuallyPromotion = this.warehouseName.allowManuallyPromotion;
                }
            }
            if (allowManuallyPromotion == true)
            {
                this.TxtBarcodeFree.Text = $"";
                if (this.warehouseName == null) return;
                if (this.warehouseName.allowManuallyPromotion == false) return;
                if (Convert.ToDecimal(string.IsNullOrWhiteSpace(this.TxtPcsFree.Text.Trim()) ? "0" : this.TxtPcsFree.Text.Trim()) != 0)
                {
                    this.TxtBarcodeFree.Text = $"{this.CmbProducts.Text.Trim()}";
                }
            }

        }

        private void TxtPcsFree_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 15);

        }

        private void TxtItemDiscount_TextChanged(object sender, EventArgs e)
        {
            float discountItem = float.Parse(string.IsNullOrWhiteSpace(TxtItemDiscount.Text.Trim()) ? "0" : TxtItemDiscount.Text.Trim());
            if (discountItem > 100)
            {
                TxtItemDiscount.Text = "100";
            }
            TotalAmount();
        }

        private void refreshtotalpcs_Tick(object sender, EventArgs e)
        {
            this.refreshtotalpcs.Enabled = false;
            this.TotalAmount();
        }

        private void PicProducts_MouseHover(object sender, EventArgs e)
        {
            this.pnlnone.Top = 65; // 45
            this.pnlnone.Left = (this.Width - this.pnlnone.Width) - 170; // 110
            this.pnlnone.Visible = true;
        }
    }
}

