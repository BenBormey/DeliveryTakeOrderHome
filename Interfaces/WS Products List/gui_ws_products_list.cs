using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DeliveryTakeOrder.Interfaces;
using DeliveryTakeOrder.Interfaces.Teamleader;
using DeliveryTakeOrder.Interfaces.WS_Products_List;
using DevExpress.CodeParser;
using DevExpress.XtraPrinting;
using Microsoft.Reporting.WinForms;
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

namespace DeliveryTakeOrder.WS_Products_List
{
    public partial class gui_ws_products_list : Form
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
        public RMDB db { get; set; }

        private int QtyPerPack { get; set; }
        private int vDigit { get; set; }
        private bool vIssueUnitPrice { get; set; }

        private MDI menuMdi { get; set; }
        warehouseNameModel warehouseName;
        public gui_ws_products_list(MDI MDI, warehouseNameModel warehouseName)
        {
            InitializeComponent();
            this.menuMdi = menuMdi;
            this.warehouseName = warehouseName;

            this.LoadingInitialized();
            this.db = new RMDB();


            
        }
        private void LoadingInitialized()
        {
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


        private void gui_ws_products_list_Load(object sender, EventArgs e)
        {
            this.customerloading.Enabled = true;
            this.itemloading.Enabled = true;
        }

        private void customerloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.customerloading.Enabled = false;
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.dtpdate.Value = this.Todate;
            this.query = $@"DECLARE @warehouseId UNIQUEIDENTIFIER = CAST('{this.warehouseName.id}' AS UNIQUEIDENTIFIER);

IF (@warehouseId IS NULL)
    SET @warehouseId = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);

WITH customerList
AS (SELECT [CusNum],
           [CusName],
           CONCAT([CusName], SPACE(3), N'(', CAST(REPLACE([CusNum], N'CUS', N'') AS INT), N')') [display]
    FROM [Stock].[dbo].[TPRCustomer]
    WHERE ([Status] = 'Activate')
          AND
          (
              ([distributorUnderId] = @warehouseId)
              OR (CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER) = @warehouseId)
          )
    GROUP BY [CusNum],
             [CusName],
             CONCAT([CusName], SPACE(3), N'(', CAST(REPLACE([CusNum], N'CUS', N'') AS INT), N')'))
SELECT [CusNum],
       [CusName],
       [display]
FROM customerList
GROUP BY [CusNum],
         [CusName],
         [display]
ORDER BY [CusName];
";


            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            this.DataSources(CmbBillTo, lists, "display", "CusNum");
            this.Cursor = Cursors.Default;
        }

        private void itemloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.itemloading.Enabled = false;
            this.query = @"SELECT [Barcode],
       [ProName],
       [Display]
FROM
(
    SELECT ISNULL([ProNumY], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumY], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProducts]
    GROUP BY ISNULL([ProNumY], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumY], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([ProNumYP], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumYP], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE ISNULL([ProNumYP], '') <> ''
    GROUP BY ISNULL([ProNumYP], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumYP], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([ProNumYC], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumYC], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE ISNULL([ProNumYC], '') <> ''
    GROUP BY ISNULL([ProNumYC], ''),
             ISNULL([ProName], ''),
             ISNULL([ProNumYC], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
    UNION ALL
    SELECT ISNULL([ProNumY], '') AS [Barcode],
           ISNULL([ProName], '') AS [ProName],
           ISNULL([ProNumY], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '') AS [Display]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE (ISNULL([ProTotQty], 0) <> 0)
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
    GROUP BY ISNULL([B].[OldProNumy], ''),
             ISNULL([ProName], ''),
             ISNULL([B].[OldProNumy], '') + SPACE(3) + ISNULL([ProName], '') + SPACE(3) + ISNULL([ProPacksize], '')
) Lists
GROUP BY [Barcode],
         [ProName],
         [Display]
ORDER BY [ProName];";

            this.query = string.Format(this.query, this.DatabaseName);
            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            this.DataSources(this.CmbProducts, this.lists, "Display", "Barcode");
            this.Cursor = Cursors.Default;
        }

        private void checking_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.checking.Enabled = false;
            if (CmbProducts.Text.Trim() == "")
            {
                this.Cursor = Cursors.Default;
                return;
            }
             // Deactivated Itemn 
            DataTable dtDC = CheckDeactivatedItem();
            if (dtDC.Rows.Count > 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("This Barcode is in Product Deactivated!", "Confirm Deactivated Item", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            // Old Code 
            this.CheckOldItem();

            // Product 
            query = @" DECLARE @Barcode AS NVARCHAR(MAX) = N'{1}';
                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],CONVERT(MONEY,CASE WHEN RTRIM(LTRIM(ISNULL([ProPckPri], N''))) = N'' THEN N'0' ELSE RTRIM(LTRIM(ISNULL([ProPckPri], N''))) END ) [ProPckPri],[ProUPriSeH],[SupNum],[SupName],[status]
                FROM (
	                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProPckPri],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName], CONVERT(NVARCHAR(100), N'Activate') [status]
	                FROM [Stock].[dbo].[TPRProducts]
	                WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	                UNION ALL
	                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProPckPri],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName], CONVERT(NVARCHAR(100), N'Old Code (Activate)') [status]
	                FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                WHERE B.[OldProNumy] = @Barcode
                    UNION ALL
                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProPckPri],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName], CONVERT(NVARCHAR(100), N'Deactivated') [status]
	                FROM [Stock].[dbo].[TPRProductsDeactivated]
	                WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	                UNION ALL
	                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProPckPri],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName], CONVERT(NVARCHAR(100), N'Old Code (Deactivated)') [status]
	                FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                WHERE B.[OldProNumy] = @Barcode
                ) LISTS;";
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue.ToString());
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {
                    TxtQtyPerCase.Text = Convert.ToInt32(lists.Rows[0]["ProQtyPCase"] is DBNull ? 1 : lists.Rows[0]["ProQtyPCase"]).ToString() ;

                    if (lists.Rows[0]["ProQtyPPack"] is DBNull)
                    {
                        QtyPerPack = 1;
                        TxtQtyPerPack.Text = "";
                    }
                    else
                    {
                        var qtyPerPackValue = lists.Rows[0]["ProQtyPPack"].ToString().Trim();
                        QtyPerPack = string.IsNullOrEmpty(qtyPerPackValue) ? 1 : Convert.ToInt32(qtyPerPackValue);
                        TxtQtyPerPack.Text = QtyPerPack.ToString();
                    }

                    txtstatus.Text = lists.Rows[0]["status"] is DBNull ? "" : lists.Rows[0]["status"].ToString().Trim();
                }
                else
                {
                    Goto Check_Item;
                }
            }
            else
            {
            Check_Item:
                DevExpress.XtraEditors.XtraMessageBox.Show("The Item is wrong. Please check item again...",
                    "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

            int lQtyPerCase = string.IsNullOrWhiteSpace(TxtQtyPerCase.Text) ? 1 : Convert.ToInt32(TxtQtyPerCase.Text.Trim());
            double lUnitPrice = 0;
            double lPackPrice = 0;
            double lCasePrice = 0;

            string lSql = $@"
DECLARE @RC INT;
DECLARE @lCusNum AS NVARCHAR(8) = N'{lCusNum}';
DECLARE @lBarcode AS NVARCHAR(15) = N'{lBarcode}';
DECLARE @lWSPrice MONEY = 0;
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[getWSPriceForCustomer] @lCusNum,
                                                                  @lBarcode,
                                                                  @lWSPrice = @lWSPrice OUTPUT;
SELECT @lWSPrice AS wsprice;";

            DataTable lTbl = Data.Selects(lSql, Initialized.GetConnectionType(Data, App));

            if (lTbl != null && lTbl.Rows.Count > 0)
            {
                DataRow lv = lTbl.Rows[0];
                lCasePrice = lv["wsprice"] == DBNull.Value ? 0 : Convert.ToDouble(lv["wsprice"]);
            }

            lUnitPrice = lCasePrice / lQtyPerCase;
            lPackPrice = lUnitPrice * QtyPerPack;

            TxtUnitPrice.Text = lUnitPrice.ToString($"N{vDigit}");
            TxtPackPrice.Text = lPackPrice.ToString("N2");
            TxtWSPrice.Text = lCasePrice.ToString("N2");

            this.Cursor = Cursors.Default;


        }

        private void loading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.loading.Enabled = false;
            string vCusNum = "";
            if(this.CmbBillTo.SelectedValue is DataTable || this.CmbBillTo.SelectedValue is null)
            {

            }
            else
            {
                vCusNum = this.CmbBillTo.SelectedValue.ToString();
            }
            this.query = @"WITH lItems
AS (SELECT [ProID] [proid],
           [ProNumY] [unitnumber]
    FROM [Stock].[dbo].[TPRProducts]
    UNION ALL
    SELECT [ProID] [proid],
           [ProNumY] [unitnumber]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE (ISNULL([ProTotQty], 0) <> 0)
    UNION ALL
    SELECT [lx].[ProID] [proid],
           [ls].[OldProNumy] [unitnumber]
    FROM [Stock].[dbo].[TPRProducts] lx
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] ls
            ON ([ls].[ProId] = [lx].[ProID])
    UNION ALL
    SELECT [lx].[ProID] [proid],
           [ls].[OldProNumy] [unitnumber]
    FROM [Stock].[dbo].[TPRProductsDeactivated] lx
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] ls
            ON ([ls].[ProId] = [lx].[ProID])
    WHERE (ISNULL([Stock], 0) <> 0))
SELECT lItems.unitnumber
INTO #lItems
FROM lItems
GROUP BY lItems.unitnumber;

INSERT INTO [Stock].[dbo].[TPRWSCusProductList_Deleted]
(
    [CusNum],
    [ProNumY],
    [ProName],
    [ProPackSize],
    [ProQtyPCase],
    [ProUPriSeH],
    [Date],
    [ProSKU],
    [ChangeOrNot],
    [Condition],
    [OrderCycle],
    [ProCat],
    [CusName],
    [PriceChange],
    [ProDis],
    [ServiceRebate],
    [SupNum],
    [SupName],
    [LastPurchase],
    [LastInvNo],
    [LastInvType],
    [TotalPurchaseQty],
    [StartDate],
    [CreatedDate],
    [DeletedDate]
)
SELECT [CusNum],
       [ProNumY],
       [ProName],
       [ProPackSize],
       [ProQtyPCase],
       [ProUPriSeH],
       [Date],
       [ProSKU],
       [ChangeOrNot],
       [Condition],
       [OrderCycle],
       [ProCat],
       [CusName],
       [PriceChange],
       [ProDis],
       [ServiceRebate],
       [SupNum],
       [SupName],
       [LastPurchase],
       [LastInvNo],
       [LastInvType],
       [TotalPurchaseQty],
       [StartDate],
       [CreatedDate],
       GETDATE()
FROM [Stock].[dbo].[TPRWSCusProductList]
WHERE ([ProNumY] NOT IN
       (
           SELECT lItems.unitnumber FROM #lItems lItems GROUP BY lItems.unitnumber
       )
      );

DELETE FROM [Stock].[dbo].[TPRWSCusProductList]
WHERE ([ProNumY] NOT IN
       (
           SELECT lItems.unitnumber FROM #lItems lItems GROUP BY lItems.unitnumber
       )
      );

INSERT INTO [Stock].[dbo].[TPRWSCusProductList1Week_Deleted]
(
    [ID],
    [CusNum],
    [ProNumY],
    [ProName],
    [ProPackSize],
    [ProQtyPCase],
    [ProUPriSeH],
    [Date],
    [ProSKU],
    [ChangeOrNot],
    [Condition],
    [OrderCycle],
    [ProCat],
    [CusName],
    [PriceChange],
    [ProDis],
    [ServiceRebate],
    [SupNum],
    [SupName],
    [LastPurchase],
    [LastInvNo],
    [LastInvType],
    [TotalPurchaseQty],
    [StartDate],
    [CreatedDate],
    [DeletedDate]
)
SELECT [ID],
       [CusNum],
       [ProNumY],
       [ProName],
       [ProPackSize],
       [ProQtyPCase],
       [ProUPriSeH],
       [Date],
       [ProSKU],
       [ChangeOrNot],
       [Condition],
       [OrderCycle],
       [ProCat],
       [CusName],
       [PriceChange],
       [ProDis],
       [ServiceRebate],
       [SupNum],
       [SupName],
       [LastPurchase],
       [LastInvNo],
       [LastInvType],
       [TotalPurchaseQty],
       [StartDate],
       [CreatedDate],
       GETDATE()
FROM [Stock].[dbo].[TPRWSCusProductList1Week]
WHERE ([ProNumY] NOT IN
       (
           SELECT lItems.unitnumber FROM #lItems lItems GROUP BY lItems.unitnumber
       )
      );

DELETE FROM [Stock].[dbo].[TPRWSCusProductList1Week]
WHERE ([ProNumY] NOT IN
       (
           SELECT lItems.unitnumber FROM #lItems lItems GROUP BY lItems.unitnumber
       )
      );

DROP TABLE #lItems;





DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
UPDATE x
SET [x].[CusName] = [o].[CusName]
FROM [Stock].[dbo].[TPRWSCusProductList] x
    INNER JOIN [Stock].[dbo].[TPRCustomer] o
        ON ([o].[CusNum] = [x].[CusNum])
WHERE ([x].[CusNum] = @vCusNum);

WITH vItem
AS (SELECT [ProNumY] [UnitNumber],
           LEFT([Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) [SupName],
           [ProName],
           [ProCat],
           [ProPacksize] [Size],
           [ProSKU],
           [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts]
    UNION ALL
    SELECT [ProNumY] [UnitNumber],
           LEFT([Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) [SupName],
           [ProName],
           [ProCat],
           [ProPacksize] [Size],
           [ProSKU],
           [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    UNION ALL
    SELECT [v].[OldProNumy] [UnitNumber],
           LEFT([x].[Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([x].[Sup1], 9, LEN([Sup1])))) [SupName],
           [x].[ProName],
           [x].[ProCat],
           [x].[ProPacksize] [Size],
           [x].[ProSKU],
           [x].[ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    UNION ALL
    SELECT [v].[OldProNumy] [UnitNumber],
           LEFT([x].[Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([x].[Sup1], 9, LEN([Sup1])))) [SupName],
           [x].[ProName],
           [x].[ProCat],
           [x].[ProPacksize] [Size],
           [x].[ProSKU],
           [x].[ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID]))
SELECT [x].[UnitNumber],
       [x].[SupNum],
       COALESCE([o].[SupName], [x].[SupName]) [SupName],
       [x].[ProName],
       [x].[ProCat],
       [x].[Size],
       [x].[ProSKU],
       [x].[ProQtyPCase]
INTO #vlst_items
FROM vItem x
    INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblSuppliers] o
        ON ([o].[SupId] = [x].[SupNum]);

SELECT [x].[CusNum],
       [x].[CusName],
       COALESCE([v].[SupNum], [x].[SupNum]) [SupNum],
       COALESCE([v].[SupName], [x].[SupName]) [SupName],
       COALESCE([v].[UnitNumber], [x].[ProNumY]) [UnitNumber],
       COALESCE([v].[ProName], [x].[ProName]) [Description],
       COALESCE([v].[Size], [x].[ProPackSize]) [Size],
       CONVERT(DECIMAL, COALESCE([v].[ProQtyPCase], [x].[ProQtyPCase])) [QtyPerCase],
       CONVERT(MONEY, COALESCE([x].[ProUPriSeH], N'0')) [WS],
       CONVERT(DATE, [x].[Date]) [Dates],
       [x].[ChangeOrNot],
       [x].[Condition],
       [x].[OrderCycle],
       [x].[PriceChange],
       CONVERT(FLOAT, COALESCE([x].[ProDis], 0)) [Discount],
       CONVERT(FLOAT, COALESCE([x].[ServiceRebate], 0)) [ServiceRebate],
       CONVERT(DATE, [x].[LastPurchase]) [LastPurchase],
       [x].[LastInvNo],
       [x].[LastInvType],
       CONVERT(FLOAT, COALESCE([x].[TotalPurchaseQty], 0)) [TotalPurchaseQty],
       CONVERT(DATE, [x].[StartDate]) [StartDate]
FROM [Stock].[dbo].[TPRWSCusProductList] x
    INNER JOIN #vlst_items v
        ON ([v].[UnitNumber] = [x].[ProNumY])
WHERE ([x].[CusNum] = @vCusNum)
{2}
ORDER BY [x].[SupName],
         [x].[ProName];

DROP TABLE #vlst_items;";
            this.query = string.Format(this.query, DatabaseName, vCusNum, this.condition_);
            this.lists = this.Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            List<cls_ws_products_list> lst_ = this.db.GetDataTableToObject<cls_ws_products_list>(this.lists);
            if (lst_.Count <= 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("No record for customer to preview!", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CmbBillTo.Focus();
                return;
            }
            rpt_ws_products_list xReport = new rpt_ws_products_list();
            // AddHandler xReport.cellLostOver.PreviewClick, AddressOf LostOverClickHandler
            // AddHandler xReport.cellTotalLostOver.PreviewClick, AddressOf TotalLostOverClickHandler
      
                xReport.objectDataSource1.DataSource = lst_;
                xReport.Parameters["asof"].Value = this.Todate;
                xReport.RequestParameters = false;
                docViewer.DocumentSource = xReport;
                docViewer.PrintingSystem = xReport.PrintingSystem;
                docViewer.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Parameters, CommandVisibility.None);
                docViewer.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SubmitParameters, CommandVisibility.None);
                docViewer.PrintingSystem.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
                docViewer.Refresh();
                xReport.CreateDocument(true);
            

            this.condition_ = "";
            this.Cursor = Cursors.Default;



        }
        private string condition_;


        private DataTable CheckDeactivatedItem()
        {
            bool IsDeactivated = false;
            query = @" DECLARE @Barcode AS NVARCHAR(MAX) = '{1}';
                SELECT * 
                FROM [Stock].[dbo].[TPRProductsDeactivated] 
                WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode);
    ";

            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            return lists;

        }
        private bool CheckOldItem()
        {
            bool IsOldItem = false;
            string NewBarcode = "";
            long ProId = 0;
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if(lists != null)
            {
                if(lists.Rows.Count > 0)
                {
                     ProId = Convert.ToInt64(DBNull.Value.Equals(this.lists.Rows[0]["ProId"]) ? 0 : this.lists.Rows[0]["ProId"]);
                    string query = @"
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
                    DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                    if (lists != null)
                    {
                        if (lists.Rows.Count > 0)
                        {
                             NewBarcode = DBNull.Value.Equals(lists.Rows[0]["ProNumY"]) ? "" : lists.Rows[0]["ProNumY"].ToString().Trim();
                            if (MessageBox.Show(string.Format("This item is old code <{0}>.\nDo you want to change the old code <{0}> to new code <{1}>?(Yes/No)", CmbProducts.SelectedValue, NewBarcode), "Confirm Change Old Code", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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

                }
            }
            return IsOldItem;
        }

        private void CmbBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.App.SetEnableController(true, btnadd, CmbProducts);
            this.App.ClearController(CmbProducts, TxtQtyPerCase, TxtUnitPrice, TxtWSPrice);
            if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null) return;
            if (this.CmbBillTo.Text.Trim() == "") return;

            string CusNum = "";
            if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (this.CmbBillTo.Text.Trim() == "")
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = this.CmbBillTo.SelectedValue.ToString();
                }
            }

            DataTable oList;

            query = @" DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate]
                FROM [{0}].[dbo].[TblCustomerRemarkSetting]
                WHERE ([CusNum] = @vCusNum) 
                AND (([Status] = N'Both') OR ([Status] = N'Dry Items'))
                AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE()));     ";

            query = string.Format(query, DatabaseName, CusNum);
            DataTable oRemarkList = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (oRemarkList != null)
            {
                if (oRemarkList.Rows.Count > 0)
                {
                    DateTime vBlockDate = DBNull.Value.Equals(oRemarkList.Rows[0]["BlockDate"]) ? Todate : Convert.ToDateTime(oRemarkList.Rows[0]["BlockDate"]);
                    string vCustomerRemark = "";
                    vCustomerRemark = DBNull.Value.Equals(oRemarkList.Rows[0]["Remark"]) ? "" : oRemarkList.Rows[0]["Remark"].ToString().Trim();
                    vCustomerRemark += DBNull.Value.Equals(oRemarkList.Rows[0]["BlockDate"]) ? "" : string.Format("{1}អតិថិជននេះនឹងប្លុកនៅថ្ងៃទី : {0:dd-MMM-yyyy}", Convert.ToDateTime(oRemarkList.Rows[0]["BlockDate"]), Environment.NewLine);
                }
            }

            // Check Info Customer
            if (!CheckInfoCustomer(CusNum))
            {
                btnadd.Enabled = false;
                MessageBox.Show("This customer has been deleted! Please report to administrator!", "Not Existed Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (vIssueUnitPrice)
            {
                PanelUnitPrice.BackColor = Color.Brown;
            }
            else
            {
                PanelUnitPrice.BackColor = Color.FromName("Control");
            }

            App.SetEnableController(true, btnadd, CmbProducts);
            this.loading.Enabled = true;

        }
        private bool CheckInfoCustomer(string CusNum)
        {
            bool IsExisted = true;
            string query = @"
        DECLARE @CusNum AS NVARCHAR(8) = '{1}';
        SELECT [CusID],[CusNum],[CusName],[CusVat],[Terms],[Discount],[InvoiceDiscount],[CreditLimit],[CreditLimitAllow],[MaxMonthAllow],[ServiceRebate],[City],[AdditionalCost],[IssueUnitPrice],[Digit],[ServiceCost]
        FROM [Stock].[dbo].[TPRCustomer]
        WHERE [CusNum] = @CusNum;
    ";
            query = string.Format(query, DatabaseName, CusNum);
            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {
                    this.vIssueUnitPrice = Convert.ToBoolean(DBNull.Value.Equals(lists.Rows[0]["IssueUnitPrice"]) ? 0 : lists.Rows[0]["IssueUnitPrice"]);
                    this.vDigit = Convert.ToInt32(DBNull.Value.Equals(lists.Rows[0]["Digit"]) ? 2 : lists.Rows[0]["Digit"]);
                    IsExisted = true;
                }
                else
                {
                    IsExisted = false;
                }
            }
            else
            {
                IsExisted = false;
            }
            return IsExisted;
        }

        private void CmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ClearProductIteam();
            if (CmbProducts.Text.Trim().Equals("")) return;

            if (this.CmbProducts.SelectedValue is DataRowView || this.CmbProducts.SelectedValue == null) return;
            this.checking.Enabled = true;

        }
        private void ClearProductIteam()
        {
            this.btnadd.Enabled = true;
            this.App.ClearController(TxtQtyPerCase, TxtWSPrice, TxtUnitPrice, TxtPackPrice, txtcondition, txtstatus);
        }
        private double RoundUp(double value , int decimals)
        {
            return Math.Ceiling(value * (10 ^ decimals)) / (10 ^ decimals);
        }
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            string vCusNum = "";
            if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null)
            {
            }
            else
            {
                if (!this.CmbBillTo.Text.Trim().Equals(""))
                {
                    vCusNum = this.CmbBillTo.SelectedValue.ToString();
                }
            }
            if (vCusNum.Trim().Equals(""))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select any customer first!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CmbBillTo.Focus();
                return;
            }

            string vAbleToChangeOrNot = "";
            if (!this.CmbAbleToChangeorNot.Text.Trim().Equals(""))
            {
                vAbleToChangeOrNot = this.CmbAbleToChangeorNot.Text.Trim();
            }
            if (vAbleToChangeOrNot.Trim().Equals(""))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select any Able To Change or Not first!", "Select Able To Change or Not", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CmbAbleToChangeorNot.Focus();
                return;
            }

            string vOrderCycle = "";
            if (!this.CmbOrderCycle.Text.Trim().Equals(""))
            {
                vOrderCycle = this.CmbOrderCycle.Text.Trim();
            }
            if (vOrderCycle.Trim().Equals(""))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select any Order Cycle first!", "Select Order Cycle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CmbOrderCycle.Focus();
                return;
            }

            string vItem = "";
            if (this.CmbProducts.SelectedValue is DataRowView || this.CmbProducts.SelectedValue == null)
            {
            }
            else
            {
                if (!this.CmbProducts.Text.Trim().Equals(""))
                {
                    vItem = this.CmbProducts.SelectedValue.ToString();
                }
            }
            if (vItem.Trim().Equals(""))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select any item first!", "Select Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CmbProducts.Focus();
                return;
            }

            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();
            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                query = @"
DECLARE @vCusNum AS NVARCHAR(15) = N'{1}';
DECLARE @vProNumY AS NVARCHAR(15) = N'{2}';
DECLARE @vProName AS NVARCHAR(100) = N'';
DECLARE @vProPackSize AS NVARCHAR(30) = N'';
DECLARE @vProQtyPCase AS CHAR(10) = N'';
DECLARE @vProUPriSeH AS CHAR(10) = N'{3}';
DECLARE @vDate AS DATETIME = '{4:yyyy-MM-dd}';
DECLARE @vProSKU AS NVARCHAR(15) = N'';
DECLARE @vChangeOrNot AS NVARCHAR(17) = N'{5}';
DECLARE @vCondition AS NVARCHAR(100) = N'{6}';
DECLARE @vOrderCycle AS NVARCHAR(15) = N'{7}';
DECLARE @vProCat AS VARCHAR(30) = N'';
DECLARE @vCusName AS NVARCHAR(100) = N'';
DECLARE @vPriceChange AS NVARCHAR(50) = N'New Product';
DECLARE @vProDis AS REAL = 0;
DECLARE @vServiceRebate AS REAL = 0;
DECLARE @vSupNum AS NVARCHAR(50) = N'';
DECLARE @vSupName AS NVARCHAR(100) = N'';
DECLARE @vLastPurchase AS DATETIME = NULL;
DECLARE @vLastInvNo AS NVARCHAR(12) = NULL;
DECLARE @vLastInvType AS NVARCHAR(12) = NULL;
DECLARE @vTotalPurchaseQty AS FLOAT = 0;
DECLARE @vStartDate AS DATETIME = NULL;

SELECT @vCusName = COALESCE([CusName], N''),
       @vProDis = COALESCE([Discount], 0),
       @vServiceRebate = COALESCE([ServiceRebate], 0)
FROM [Stock].[dbo].[TPRCustomer]
WHERE ([CusNum] = @vCusNum);

WITH vItem
AS (SELECT [ProNumY],
           LEFT([Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) [SupName],
           [ProName],
           [ProCat],
           [ProPacksize],
           [ProSKU],
           [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE (COALESCE([ProNumY], N'') = @vProNumY)
          OR
          (
              (COALESCE([ProNumYP], N'') <> N'')
              AND (COALESCE([ProNumYP], N'') = @vProNumY)
          )
          OR
          (
              (COALESCE([ProNumYC], N'') <> N'')
              AND (COALESCE([ProNumYC], N'') = @vProNumY)
          )
    UNION ALL
    SELECT [ProNumY],
           LEFT([Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) [SupName],
           [ProName],
           [ProCat],
           [ProPacksize],
           [ProSKU],
           [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    WHERE (COALESCE([ProNumY], N'') = @vProNumY)
          OR
          (
              (COALESCE([ProNumYP], N'') <> N'')
              AND (COALESCE([ProNumYP], N'') = @vProNumY)
          )
          OR
          (
              (COALESCE([ProNumYC], N'') <> N'')
              AND (COALESCE([ProNumYC], N'') = @vProNumY)
          )
    UNION ALL
    SELECT [v].[OldProNumy] [ProNumY],
           LEFT([x].[Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([x].[Sup1], 9, LEN([Sup1])))) [SupName],
           [x].[ProName],
           [x].[ProCat],
           [x].[ProPacksize],
           [x].[ProSKU],
           [x].[ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE (COALESCE([v].[OldProNumy], N'') = @vProNumY)
    UNION ALL
    SELECT [v].[OldProNumy] [ProNumY],
           LEFT([x].[Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([x].[Sup1], 9, LEN([Sup1])))) [SupName],
           [x].[ProName],
           [x].[ProCat],
           [x].[ProPacksize],
           [x].[ProSKU],
           [x].[ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    WHERE (COALESCE([v].[OldProNumy], N'') = @vProNumY))
SELECT @vProName = [x].[ProName],
       @vProPackSize = [x].[ProPacksize],
       @vProQtyPCase = [x].[ProQtyPCase],
       @vProSKU = [x].[ProSKU],
       @vProCat = [x].[ProCat],
       @vSupNum = [x].[SupNum],
       @vSupName = [x].[SupName]
FROM vItem x;

IF NOT EXISTS
(
    SELECT *
    FROM [Stock].[dbo].[TPRWSCusProductList]
    WHERE ([CusNum] = @vCusNum)
          AND ([ProNumY] = @vProNumY)
)
BEGIN
    INSERT INTO [Stock].[dbo].[TPRWSCusProductList]
    (
        [CusNum],
        [ProNumY],
        [ProName],
        [ProPackSize],
        [ProQtyPCase],
        [ProUPriSeH],
        [Date],
        [ProSKU],
        [ChangeOrNot],
        [Condition],
        [OrderCycle],
        [ProCat],
        [CusName],
        [PriceChange],
        [ProDis],
        [ServiceRebate],
        [SupNum],
        [SupName],
        [LastPurchase],
        [LastInvNo],
        [LastInvType],
        [TotalPurchaseQty],
        [StartDate]
    )
    VALUES
    (@vCusNum, @vProNumY, @vProName, @vProPackSize, @vProQtyPCase, @vProUPriSeH, @vDate, @vProSKU, @vChangeOrNot,
     @vCondition, @vOrderCycle, @vProCat, @vCusName, @vPriceChange, @vProDis, @vServiceRebate, @vSupNum, @vSupName,
     @vLastPurchase, @vLastInvNo, @vLastInvType, @vTotalPurchaseQty, @vStartDate);
END;
ELSE
BEGIN
    UPDATE x
    SET [x].[ProName] = @vProName,
        [x].[ProPackSize] = @vProPackSize,
        [x].[ProQtyPCase] = @vProQtyPCase,
        [x].[ProUPriSeH] = @vProUPriSeH,
        [x].[Date] = @vDate,
        [x].[ProSKU] = @vProSKU,
        [x].[ChangeOrNot] = @vChangeOrNot,
        [x].[Condition] = @vCondition,
        [x].[OrderCycle] = @vOrderCycle,
        [x].[ProCat] = @vProCat,
        [x].[CusName] = @vCusName,
        [x].[PriceChange] = @vPriceChange,
        [x].[ProDis] = @vProDis,
        [x].[ServiceRebate] = @vServiceRebate,
        [x].[SupNum] = @vSupNum,
        [x].[SupName] = @vSupName
    FROM [Stock].[dbo].[TPRWSCusProductList] x
    WHERE ([x].[CusNum] = @vCusNum)
          AND ([x].[ProNumY] = @vProNumY);
END;
DELETE [Stock].[dbo].[TPRDeletingProductExpiryInDeliveryTakeOrder]
WHERE [Barcode] = @vProNumY;";

                query = string.Format(query, DatabaseName, vCusNum, vItem, this.TxtWSPrice.Text.Trim(), this.dtpdate.Value, vAbleToChangeOrNot, this.txtcondition.Text.Replace("'", "`").Trim(), vOrderCycle);
                RCom.CommandText = query;
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show("The processing have been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.ClearProductIteam();
                CmbProducts.Focus();
                this.loading.Enabled = true;


            }
            catch (SqlException ex)
            {
                RTran.Rollback();
                RCon.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                RTran.Rollback();
                RCon.Close();
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CmbAbleToChangeorNot_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vAbleToChangeOrNot = "";
            if (this.CmbAbleToChangeorNot.Text.Trim().Equals(""))
            {

            }
            else
            {
                vAbleToChangeOrNot = this.CmbAbleToChangeorNot.Text.Trim();
            }

            if (vAbleToChangeOrNot.Trim().Equals("Returnable"))
            {
                this.txtcondition.ReadOnly = false;
                this.txtcondition.Focus();

            }
            else
            {
                this.txtcondition.ReadOnly = true;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string lCusNum = "";
            if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null)
            {
            }
            else
            {
                if (!this.CmbBillTo.Text.Trim().Equals(""))
                {
                    lCusNum = this.CmbBillTo.SelectedValue.ToString();
                }
            }
            if (lCusNum.Trim().Equals(""))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select any customer first!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CmbBillTo.Focus();
                return;
            }

            Initialized.R_CorrectPassword = false;
            FrmPasswordContinues lGUI = new FrmPasswordContinues();
            lGUI.Text = "Password For Office Manager Only";
            lGUI.R_PasswordPermission = "'Managing Director','IT Manager','Office Manager'";
            lGUI.ShowDialog();
            if (Initialized.R_CorrectPassword == false) return;

            if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure, you want to update the price list for the customer?(Yes/No)", "Confirm Update Price List", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            string vItem = "";

            this.query = @"DECLARE @lCusNum AS NVARCHAR(8) = N'{1}';
WITH vItem
AS (SELECT [ProNumY] [UnitNumber],
           LEFT([Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) [SupName],
           [ProName],
           [ProCat],
           [ProPacksize] [Size],
           [ProSKU],
           [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts]
    UNION ALL
    SELECT [ProNumY] [UnitNumber],
           LEFT([Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) [SupName],
           [ProName],
           [ProCat],
           [ProPacksize] [Size],
           [ProSKU],
           [ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    UNION ALL
    SELECT [v].[OldProNumy] [UnitNumber],
           LEFT([x].[Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([x].[Sup1], 9, LEN([Sup1])))) [SupName],
           [x].[ProName],
           [x].[ProCat],
           [x].[ProPacksize] [Size],
           [x].[ProSKU],
           [x].[ProQtyPCase]
    FROM [Stock].[dbo].[TPRProducts] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    UNION ALL
    SELECT [v].[OldProNumy] [UnitNumber],
           LEFT([x].[Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([x].[Sup1], 9, LEN([Sup1])))) [SupName],
           [x].[ProName],
           [x].[ProCat],
           [x].[ProPacksize] [Size],
           [x].[ProSKU],
           [x].[ProQtyPCase]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])),
     lFinalItems
AS (SELECT [ls].[UnitNumber],
           [ls].[SupNum],
           COALESCE([lo].[SupName], [ls].[SupName]) [SupName],
           [ls].[ProName],
           [ls].[ProCat],
           [ls].[Size],
           [ls].[ProSKU],
           [ls].[ProQtyPCase]
    FROM vItem ls
        INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblSuppliers] lo
            ON ([lo].[SupId] = [ls].[SupNum]))
SELECT [x].[CusNum],
       [x].[CusName],
       COALESCE([v].[SupNum], [x].[SupNum]) [SupNum],
       COALESCE([v].[SupName], [x].[SupName]) [SupName],
       COALESCE([v].[UnitNumber], [x].[ProNumY]) [UnitNumber],
       COALESCE([v].[ProName], [x].[ProName]) [Description],
       COALESCE([v].[Size], [x].[ProPackSize]) [Size],
       CONVERT(DECIMAL, COALESCE([v].[ProQtyPCase], [x].[ProQtyPCase])) [QtyPerCase],
       CONVERT(MONEY, COALESCE([x].[ProUPriSeH], N'0')) [WS],
       CONVERT(DATE, [x].[Date]) [Dates],
       [x].[ChangeOrNot],
       [x].[Condition],
       [x].[OrderCycle],
       [x].[PriceChange],
       CONVERT(FLOAT, COALESCE([x].[ProDis], 0)) [Discount],
       CONVERT(FLOAT, COALESCE([x].[ServiceRebate], 0)) [ServiceRebate],
       CONVERT(DATE, [x].[LastPurchase]) [LastPurchase],
       [x].[LastInvNo],
       [x].[LastInvType],
       CONVERT(FLOAT, COALESCE([x].[TotalPurchaseQty], 0)) [TotalPurchaseQty],
       CONVERT(DATE, [x].[StartDate]) [StartDate]
FROM [Stock].[dbo].[TPRWSCusProductList] x
    INNER JOIN lFinalItems v
        ON ([v].[UnitNumber] = [x].[ProNumY])
WHERE ([x].[CusNum] = @lCusNum)
ORDER BY [x].[SupName],
         [x].[ProName];";

            this.query = string.Format(this.query, DatabaseName, lCusNum);
            this.lists = this.Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
            List<cls_ws_products_list> lst_ = this.db.GetDataTableToObject<cls_ws_products_list>(this.lists);
            if (lst_.Count <= 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("No record to update!", "No Record");
                return;
            }

            SqlConnection RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();

            try
            {
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                RCom.CommandTimeout = 600;
                this.Cursor = Cursors.WaitCursor;
                this.lblprocessing.Visible = true;
                Application.DoEvents();
                this.query = @"
DECLARE @RC INT;
DECLARE @lCusNum NVARCHAR(8) = N'{1}';
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[updateWSPriceForCustomer] @lCusNum;
";
                this.query = string.Format(this.query, DatabaseName, lCusNum);
                RCom.CommandText = this.query;
                RCom.ExecuteNonQuery();
                RCon.Close();
                this.lblprocessing.Visible = false;
                this.Cursor = Cursors.Default;
                Application.DoEvents();
                DevExpress.XtraEditors.XtraMessageBox.Show("The processing has been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ClearProductIteam();
                this.CmbProducts.Focus();
                this.loading.Enabled = true;

            }catch(SqlException ex)
            {
                RCon.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch(Exception ex)
            {
                RCon.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string vCusNum = "";
            if (this.CmbBillTo.SelectedValue is DataRowView || this.CmbBillTo.SelectedValue == null)
            {
            }
            else
            {
                if (!this.CmbBillTo.Text.Trim().Equals(""))
                {
                    vCusNum = this.CmbBillTo.SelectedValue.ToString();
                }
            }
            if (vCusNum.Trim().Equals(""))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select any customer first!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CmbBillTo.Focus();
                return;
            }

            string vItem = "";
            if (this.CmbProducts.SelectedValue is DataRowView || this.CmbProducts.SelectedValue == null)
            {
            }
            else
            {
                if (!this.CmbProducts.Text.Trim().Equals(""))
                {
                    vItem = this.CmbProducts.SelectedValue.ToString();
                }
            }
            if (vItem.Trim().Equals(""))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select any item first!", "Select Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CmbProducts.Focus();
                return;
            }

            if (DevExpress.XtraEditors.XtraMessageBox.Show("When you delete this, it will also delete your one week price list as well.\nDo you want to go ahead?(Yes/No)", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            Initialized.R_CorrectPassword = false;
            FrmPasswordContinues lGUI = new FrmPasswordContinues();
            lGUI.Text = "Password For Office Manager Only";
            lGUI.R_PasswordPermission = "'Managing Director','IT Manager','Office Manager'";
            lGUI.ShowDialog();
            if (Initialized.R_CorrectPassword == false) return;

            SqlConnection RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            SqlTransaction RTran = RCon.BeginTransaction();
            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                query = @"DECLARE @vCusNum AS NVARCHAR(50) = N'{1}';
DECLARE @vProNumY AS NVARCHAR(15) = N'{2}';
WITH vItem
AS (SELECT [ProNumY] [UnitNumber],
           LEFT([Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) [SupName],
           [ProName],
           [ProCat],
           [ProPacksize] [Size],
           [ProSKU],
           [ProQtyPCase],
           COALESCE([ProTotQty], 0) [Stock]
    FROM [Stock].[dbo].[TPRProducts]
    UNION ALL
    SELECT [ProNumY] [UnitNumber],
           LEFT([Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([Sup1], 9, LEN([Sup1])))) [SupName],
           [ProName],
           [ProCat],
           [ProPacksize] [Size],
           [ProSKU],
           [ProQtyPCase],
           COALESCE([ProTotQty], 0) [Stock]
    FROM [Stock].[dbo].[TPRProductsDeactivated]
    UNION ALL
    SELECT [v].[OldProNumy] [UnitNumber],
           LEFT([x].[Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([x].[Sup1], 9, LEN([Sup1])))) [SupName],
           [x].[ProName],
           [x].[ProCat],
           [x].[ProPacksize] [Size],
           [x].[ProSKU],
           [x].[ProQtyPCase],
           COALESCE([v].[Stock], 0) [Stock]
    FROM [Stock].[dbo].[TPRProducts] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID])
    UNION ALL
    SELECT [v].[OldProNumy] [UnitNumber],
           LEFT([x].[Sup1], 8) [SupNum],
           RTRIM(LTRIM(SUBSTRING([x].[Sup1], 9, LEN([Sup1])))) [SupName],
           [x].[ProName],
           [x].[ProCat],
           [x].[ProPacksize] [Size],
           [x].[ProSKU],
           [x].[ProQtyPCase],
           COALESCE([v].[Stock], 0) [Stock]
    FROM [Stock].[dbo].[TPRProductsDeactivated] x
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] v
            ON ([v].[ProId] = [x].[ProID]))
SELECT [x].[UnitNumber],
       [x].[SupNum],
       COALESCE([o].[SupName], [x].[SupName]) [SupName],
       [x].[ProName],
       [x].[ProCat],
       [x].[Size],
       [x].[ProSKU],
       [x].[ProQtyPCase],
       [x].[Stock]
INTO #vlst_items
FROM vItem x
    INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblSuppliers] o
        ON ([o].[SupId] = [x].[SupNum]);

INSERT INTO [Stock].[dbo].[TPRDeletingProductExpiryInDeliveryTakeOrder]
(
    [Barcode],
    [ProName],
    [Size],
    [QTYPerCTN],
    [ProPrice],
    [ProDate],
    [Stock],
    [LastPurchase],
    [CusName],
    [StartDate],
    [Remark],
    [Del_Date]
)
SELECT COALESCE([v].[UnitNumber], [x].[ProNumY]) [UnitNumber],
       COALESCE([v].[ProName], [x].[ProName]) [Description],
       COALESCE([v].[Size], [x].[ProPackSize]) [Size],
       CONVERT(DECIMAL, COALESCE([v].[ProQtyPCase], [x].[ProQtyPCase])) [QtyPerCase],
       CONVERT(MONEY, COALESCE([x].[ProUPriSeH], N'0')) [WS],
       CONVERT(DATE, [x].[Date]) [Dates],
       CONVERT(DECIMAL, COALESCE([v].[Stock], 0)) [Stock],
       CONVERT(DATE, [x].[LastPurchase]) [LastPurchase],
       [x].[CusName],
       CONVERT(DATE, [x].[StartDate]) [StartDate],
       N'Record has been delete by user list',
       GETDATE()
FROM [Stock].[dbo].[TPRWSCusProductList] x
    INNER JOIN #vlst_items v
        ON ([v].[UnitNumber] = [x].[ProNumY])
WHERE ([x].[CusNum] = @vCusNum)
      AND ([x].[ProNumY] = @vProNumY);

DROP TABLE #vlst_items;

DELETE FROM [Stock].[dbo].[TPRWSCusProductList]
WHERE ([CusNum] = @vCusNum)
      AND ([ProNumY] = @vProNumY);

DELETE FROM [Stock].[dbo].[TPRWSCusProductList1Week]
WHERE ([CusNum] = @vCusNum)
      AND ([ProNumY] = @vProNumY);";
                query = String.Format(query, DatabaseName, vCusNum, vItem);
                RCom.CommandText = query;
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show("The processing have been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.ClearProductIteam();
                CmbProducts.Focus();
                this.loading.Enabled = true;


            }catch(SqlException ex)
            {
                RTran.Rollback();
                RCon.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                RTran.Rollback();
                RCon.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.condition_ = "AND ([x].[PriceChange] <> N'')";
            this.loading.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.loading.Enabled = true;
        }
    }
}
