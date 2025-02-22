using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.CodeParser;
using DevExpress.Utils.Design;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using ProtoBuf.Meta;
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
    public partial class FrmSetPiecesPerTray : Form
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

        public FrmSetPiecesPerTray()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            App.ClearController(TxtQtyPerCase, TxtPiecesPerTray);
            App.SetVisibleController(false, BtnUpdate, BtnCancel);
            App.SetVisibleController(true, BtnAdd);
            App.SetEnableController(true, BtnExportToExcel, DgvShow);
            CmbProducts.Focus();

        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void ItemLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ItemLoading.Enabled = false;
            query = @"SELECT [Barcode],[ProName],[Display]
                FROM (
	                SELECT ISNULL([ProNumY],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                FROM [Stock].[dbo].[TPRProducts]
                    WHERE ISNULL([ProNumY],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                    AND ISNULL([ProNumY],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting])
                    GROUP BY ISNULL([ProNumY],''),ISNULL([ProName],''),ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                UNION ALL 
	                SELECT ISNULL([ProNumYP],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                FROM [Stock].[dbo].[TPRProducts]
	                WHERE ISNULL([ProNumYP],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                    AND ISNULL([ProNumYP],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting])
                    GROUP BY ISNULL([ProNumYP],''),ISNULL([ProName],''),ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                UNION ALL 
	                SELECT ISNULL([ProNumYC],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                FROM [Stock].[dbo].[TPRProducts]
	                WHERE ISNULL([ProNumYC],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                    AND ISNULL([ProNumYC],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting])
                    GROUP BY ISNULL([ProNumYC],''),ISNULL([ProName],''),ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                UNION ALL
                    SELECT ISNULL([ProNumY],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                FROM [Stock].[dbo].[TPRProductsDeactivated]
                    WHERE ISNULL([ProNumY],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                    AND ISNULL([ProNumY],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting])
                    GROUP BY ISNULL([ProNumY],''),ISNULL([ProName],''),ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                UNION ALL 
	                SELECT ISNULL([ProNumYP],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                FROM [Stock].[dbo].[TPRProductsDeactivated]
	                WHERE ISNULL([ProNumYP],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                    AND ISNULL([ProNumYP],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting])
                    GROUP BY ISNULL([ProNumYP],''),ISNULL([ProName],''),ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                UNION ALL 
	                SELECT ISNULL([ProNumYC],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                FROM [Stock].[dbo].[TPRProductsDeactivated]
	                WHERE ISNULL([ProNumYC],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                    AND ISNULL([ProNumYC],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting])
                    GROUP BY ISNULL([ProNumYC],''),ISNULL([ProName],''),ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                UNION ALL 
	                SELECT ISNULL([B].[OldProNumy],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
                    WHERE ISNULL([OldProNumy],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                    AND ISNULL([OldProNumy],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting])
                    GROUP BY ISNULL([B].[OldProNumy],''),ISNULL([ProName],''),ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
                    UNION ALL 
	                SELECT ISNULL([B].[OldProNumy],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
                    WHERE ISNULL([OldProNumy],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                    AND ISNULL([OldProNumy],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting])
                    GROUP BY ISNULL([B].[OldProNumy],''),ISNULL([ProName],''),ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
                ) Lists
                GROUP BY [Barcode],[ProName],[Display]
                ORDER BY [ProName];";
            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbProducts, lists, "Display", "Barcode");
            this.Cursor = Cursors.Default;

        }


        private void DisplayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DisplayLoading.Enabled = false;

            query = @"
    SELECT [Id], [Barcode], [ProName], [Size], [QtyPCase], [PiecesPerTray], [CreatedDate]
    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting]
    ORDER BY [ProName], [Size];
";
            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row : {0}", DgvShow.RowCount);
            this.Cursor = Cursors.Default;

        }
        private void ProductSearch(ComboBox ComboName)
        {
            string RBarcode = ((ComboBox)ComboName).Text.Trim();
            if (RBarcode.Length > 13)
                RBarcode = RBarcode.Substring(0, 15).Trim();

            if (double.TryParse(RBarcode.Trim(), out double numericValue))
                RBarcode = string.Format("{0:0000000000000}", numericValue);

            DataTable TableProducts = (DataTable)((ComboBox)ComboName).DataSource;

            for (int i = 0; i < TableProducts.Rows.Count; i++)
            {
                string displayItem = TableProducts.Rows[i][((ComboBox)ComboName).DisplayMember].ToString();
                string valueItem = TableProducts.Rows[i][((ComboBox)ComboName).ValueMember].ToString();

                valueItem = valueItem.Substring(0, Math.Min(RBarcode.Length, valueItem.Length)).Trim();

                if (valueItem.Equals(RBarcode))
                {
                    ((ComboBox)ComboName).SelectedIndex = i;
                    break;
                }
            }

            TxtPiecesPerTray.Focus();

        }



        private void CmbProducts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;

            if ((e.KeyChar >= (char)Keys.A && e.KeyChar <= (char)Keys.Z) || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
            {
                if (!string.IsNullOrWhiteSpace(CmbProducts.Text.Trim()) && !double.TryParse(CmbProducts.Text.Trim(), out _))
                    e.Handled = true;

                e.KeyChar = char.ToUpper(e.KeyChar);

            }
            else
            {
                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 15);
            }



        }

        private void FrmSetPiecesPerTray_Load(object sender, EventArgs e)
        {
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            ItemLoading.Enabled = true;
            DisplayLoading.Enabled = true;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if (CmbProducts.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any product!", "Select Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbProducts.Focus();
                return;

            }
            else if (Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtPiecesPerTray.Text.Trim()) ? "0" : TxtPiecesPerTray.Text.Trim()) == 0)
            {
                MessageBox.Show("Please enter the pieces per tray!", "Enter Pieces Per Tray", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPiecesPerTray.Focus();
                return;
            }
            else
            {
                string vBarcode;
                decimal vPiecePerTray = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtPiecesPerTray.Text.Trim()) ? "0" : TxtPiecesPerTray.Text.Trim());
                if (CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue == null)
                {

                    vBarcode = "";

                }
                else
                {
                    if (CmbProducts.Text.Trim() == "")
                    {
                        vBarcode = "";
                    }
                    else
                    {
                        vBarcode = CmbProducts.SelectedValue.ToString();
                    }
                }
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom = new SqlCommand();
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    if (sender == BtnAdd)
                    {
                        query = @"   DECLARE @vBarcode AS NVARCHAR(MAX) = N'{1}';
                            DECLARE @vPiecesPerTray AS DECIMAL(18,0) = {2};
                            WITH vItem AS (
	                            SELECT [ProNumY] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProducts]
	                            WHERE (ISNULL([ProNumY],'') = @vBarcode)
	                            UNION ALL
	                            SELECT [ProNumYP] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProducts]
	                            WHERE (ISNULL([ProNumYP],'') = @vBarcode)
	                            UNION ALL
	                            SELECT [ProNumYC] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProducts]
	                            WHERE (ISNULL([ProNumYC],'') = @vBarcode)
	                            UNION ALL
	                            SELECT B.[OldProNumy] AS [Barcode],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                            WHERE B.[OldProNumy] = @vBarcode
                                UNION ALL
                                SELECT [ProNumY] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProductsDeactivated]
	                            WHERE (ISNULL([ProNumY],'') = @vBarcode)
	                            UNION ALL
	                            SELECT [ProNumYP] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProductsDeactivated]
	                            WHERE (ISNULL([ProNumYP],'') = @vBarcode)
	                            UNION ALL
	                            SELECT [ProNumYC] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProductsDeactivated]
	                            WHERE (ISNULL([ProNumYC],'') = @vBarcode)
	                            UNION ALL
	                            SELECT B.[OldProNumy] AS [Barcode],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                            WHERE B.[OldProNumy] = @vBarcode
                            )
                            INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting]([Barcode],[ProName],[Size],[QtyPCase],[PiecesPerTray],[CreatedDate])
                            SELECT vItem.Barcode,vItem.ProName,vItem.ProPacksize,vItem.ProQtyPCase,@vPiecesPerTray,GETDATE()
                            FROM vItem
                            WHERE vItem.Barcode = @vBarcode AND N'' <> @vBarcode;";

                        query = string.Format(query, DatabaseName, vBarcode, vPiecePerTray);
                    }
                    else
                    {
                        decimal vId = Convert.ToDecimal(DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value) ? 0 : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value);
                        query = @"DECLARE @vBarcode AS NVARCHAR(MAX) = N'{1}';
                            DECLARE @vPiecesPerTray AS DECIMAL(18,0) = {2};
                            DECLARE @vId AS DECIMAL = {3};
                            WITH vItem AS (
	                            SELECT [ProNumY] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProducts]
	                            WHERE (ISNULL([ProNumY],'') = @vBarcode)
	                            UNION ALL
	                            SELECT [ProNumYP] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProducts]
	                            WHERE (ISNULL([ProNumYP],'') = @vBarcode)
	                            UNION ALL
	                            SELECT [ProNumYC] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProducts]
	                            WHERE (ISNULL([ProNumYC],'') = @vBarcode)
	                            UNION ALL
	                            SELECT B.[OldProNumy] AS [Barcode],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                            WHERE B.[OldProNumy] = @vBarcode
                                UNION ALL
                                SELECT [ProNumY] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProductsDeactivated]
	                            WHERE (ISNULL([ProNumY],'') = @vBarcode)
	                            UNION ALL
	                            SELECT [ProNumYP] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProductsDeactivated]
	                            WHERE (ISNULL([ProNumYP],'') = @vBarcode)
	                            UNION ALL
	                            SELECT [ProNumYC] AS [Barcode],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProductsDeactivated]
	                            WHERE (ISNULL([ProNumYC],'') = @vBarcode)
	                            UNION ALL
	                            SELECT B.[OldProNumy] AS [Barcode],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName]
	                            FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                            WHERE B.[OldProNumy] = @vBarcode
                            )
                            UPDATE v
                            SET [Barcode] = vItem.Barcode,
                            [ProName] = vItem.ProName,
                            [Size] = vItem.ProPacksize,
                            [QtyPCase] = vItem.ProQtyPCase,
                            [PiecesPerTray] = @vPiecesPerTray
                            FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] AS v
                            INNER JOIN vItem ON vItem.Barcode = @vBarcode AND v.Id = @vId
                            WHERE (vItem.Barcode = @vBarcode AND N'' <> @vBarcode) AND v.Id = @vId;";

                        query = string.Format(query, DatabaseName, vBarcode, vPiecePerTray, vId);

                    }
                    RCom.CommandText = query; RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    MessageBox.Show("Setting Pieces Per Treay have been completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            if (DgvShow.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel.Application RExcel;
                Microsoft.Office.Interop.Excel.Workbook RBook;
                Microsoft.Office.Interop.Excel.Worksheet RSheet;
                RExcel = new Microsoft.Office.Interop.Excel.Application();
                RBook = RExcel.Workbooks.Add(Type.Missing);
                RSheet = RBook.Worksheets[1];
                RSheet.Range["A:Z"].Font.Name = "Arial";
                RSheet.Range["A:Z"].Font.Size = 8;
                RSheet.Range["A1"].Value = "Account Setting Report";
                RSheet.Range["A2"].Value = "Export Date : " + DateTime.Now.ToString("dd-MMM-yy");
                RSheet.Range["A4"].Value = "Nº";
                RSheet.Range["B4"].Value = "Barcode";
                RSheet.Range["C4"].Value = "Product Name";
                RSheet.Range["D4"].Value = "Size";
                RSheet.Range["E4"].Value = "Q/C";
                RSheet.Range["F4"].Value = "Pieces Per Tray";
                RSheet.Range["G4"].Value = "Created Date";
                RSheet.Range["B:B"].NumberFormat = "@";
                RSheet.Range["G:G"].NumberFormat = "dd-MMM-yy hh:mm:ss AM/PM";
                RSheet.Range["A4:O4"].WrapText = true;
                RSheet.Range["A4:O4"].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                RSheet.Range["A4:O4"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                long QsRow = 5;
                foreach (DataGridViewRow QsDataRow in DgvShow.Rows)
                {
                    RSheet.Range["A" + QsRow].Value = (QsRow - 4);
                    RSheet.Range["B" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["Barcode"].Value) ? "" : QsDataRow.Cells["Barcode"].Value;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ProName"].Value) ? "" : QsDataRow.Cells["ProName"].Value;
                    RSheet.Range["D" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["Size"].Value) ? "" : QsDataRow.Cells["Size"].Value;
                    RSheet.Range["E" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["QtyPCase"].Value) ? "" : QsDataRow.Cells["QtyPCase"].Value;
                    RSheet.Range["F" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["PiecesPerTray"].Value) ? "" : QsDataRow.Cells["PiecesPerTray"].Value;
                    RSheet.Range["G" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CreatedDate"].Value) ? "" : QsDataRow.Cells["CreatedDate"].Value;
                    QsRow++;
                }
                RSheet.Columns.AutoFit();
                RSheet.Range["A:A"].ColumnWidth = 4;
                RExcel.Visible = true;
                App.ReleaseObject(RSheet);
                App.ReleaseObject(RBook);
                App.ReleaseObject(RExcel);
            }

        }

        private void DgvShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void DgvShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (DgvShow.RowCount <= 0) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure, you want to delete this?(Yes/No)", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                decimal vId = Convert.ToDecimal(DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value) ? 0 : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value);
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom = new SqlCommand();
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    query = @"
DECLARE @vId AS DECIMAL = {1};
INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting_Deleted]([Barcode],[ProName],[Size],[QtyPCase],[PiecesPerTray],[CreatedDate],[DeletedDate])
SELECT [Barcode],[ProName],[Size],[QtyPCase],[PiecesPerTray],[CreatedDate],GETDATE()
FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting]
WHERE [Id] = @vId;

DELETE FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting]
WHERE [Id] = @vId;
";
                    query = string.Format(query, DatabaseName, vId);
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    DisplayLoading.Enabled = true;
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

        private void DgvShow_DoubleClick(object sender, EventArgs e)
        {
            if (DgvShow.RowCount <= 0)
            {
                return;
            }
            using (DataGridViewRow row = DgvShow.Rows[DgvShow.CurrentRow.Index])
            {
                string vBarcode = DBNull.Value.Equals(row.Cells["Barcode"].Value) ? "" : row.Cells["Barcode"].Value.ToString().Trim();
                decimal vPiecePerTray = Convert.ToDecimal(DBNull.Value.Equals(row.Cells["PiecesPerTray"].Value) ? 0 : row.Cells["PiecesPerTray"].Value);
                query = @"DECLARE @vBarcode AS NVARCHAR(MAX) = N'{1}';
                    SELECT [Barcode],[ProName],[Display]
                    FROM (
	                    SELECT ISNULL([ProNumY],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                    FROM [Stock].[dbo].[TPRProducts]
                        WHERE ISNULL([ProNumY],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                        AND ISNULL([ProNumY],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] WHERE [Barcode] <> @vBarcode)
                        GROUP BY ISNULL([ProNumY],''),ISNULL([ProName],''),ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                    UNION ALL 
	                    SELECT ISNULL([ProNumYP],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                    FROM [Stock].[dbo].[TPRProducts]
	                    WHERE ISNULL([ProNumYP],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                        AND ISNULL([ProNumYP],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] WHERE [Barcode] <> @vBarcode)
                        GROUP BY ISNULL([ProNumYP],''),ISNULL([ProName],''),ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                    UNION ALL 
	                    SELECT ISNULL([ProNumYC],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                    FROM [Stock].[dbo].[TPRProducts]
	                    WHERE ISNULL([ProNumYC],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                        AND ISNULL([ProNumYC],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] WHERE [Barcode] <> @vBarcode)
                        GROUP BY ISNULL([ProNumYC],''),ISNULL([ProName],''),ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                    UNION ALL
                        SELECT ISNULL([ProNumY],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                    FROM [Stock].[dbo].[TPRProductsDeactivated]
                        WHERE ISNULL([ProNumY],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                        AND ISNULL([ProNumY],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] WHERE [Barcode] <> @vBarcode)
                        GROUP BY ISNULL([ProNumY],''),ISNULL([ProName],''),ISNULL([ProNumY],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                    UNION ALL 
	                    SELECT ISNULL([ProNumYP],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                    FROM [Stock].[dbo].[TPRProductsDeactivated]
	                    WHERE ISNULL([ProNumYP],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                        AND ISNULL([ProNumYP],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] WHERE [Barcode] <> @vBarcode)
                        GROUP BY ISNULL([ProNumYP],''),ISNULL([ProName],''),ISNULL([ProNumYP],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                    UNION ALL 
	                    SELECT ISNULL([ProNumYC],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                    FROM [Stock].[dbo].[TPRProductsDeactivated]
	                    WHERE ISNULL([ProNumYC],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                        AND ISNULL([ProNumYC],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] WHERE [Barcode] <> @vBarcode)
                        GROUP BY ISNULL([ProNumYC],''),ISNULL([ProName],''),ISNULL([ProNumYC],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
	                    UNION ALL 
	                    SELECT ISNULL([B].[OldProNumy],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                    FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
                        WHERE ISNULL([OldProNumy],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                        AND ISNULL([OldProNumy],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] WHERE [Barcode] <> @vBarcode)
                        GROUP BY ISNULL([B].[OldProNumy],''),ISNULL([ProName],''),ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
                        UNION ALL 
	                    SELECT ISNULL([B].[OldProNumy],'') AS [Barcode],ISNULL([ProName],'') AS [ProName],ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'') AS [Display]
	                    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
                        WHERE ISNULL([OldProNumy],'') <> '' AND LEFT([Sup1],8) IN (SELECT [SupNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillSetting])
                        AND ISNULL([OldProNumy],'') NOT IN (SELECT [Barcode] FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] WHERE [Barcode] <> @vBarcode)
                        GROUP BY ISNULL([B].[OldProNumy],''),ISNULL([ProName],''),ISNULL([B].[OldProNumy],'') + SPACE(3) + ISNULL([ProName],'') + SPACE(3) + ISNULL([ProPacksize],'')
                    ) Lists
                    GROUP BY [Barcode],[ProName],[Display]
                    ORDER BY [ProName];";
                query = string.Format(query, DatabaseName, vBarcode);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                DataSources(CmbProducts, lists, "Display", "Barcode");
                CmbProducts.SelectedValue = vBarcode;
                TxtPiecesPerTray.Text = String.Format("{0:N0}", vPiecePerTray);
                App.SetVisibleController(true, BtnUpdate, BtnCancel);
                App.SetVisibleController(false, BtnAdd);
                App.SetEnableController(false, BtnExportToExcel, DgvShow);
            }
        }

        private void FrmSetPiecesPerTray_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();
        }

        private void CmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtQtyPerCase.Text = "";
            if (CmbProducts.Text.Trim() == "")
            {
                return;
            }
            if (CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue != null)
            {
                query = @"   DECLARE @Barcode AS NVARCHAR(MAX) = N'{1}';
                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],[SupNum],[SupName]
                FROM (
	                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                FROM [Stock].[dbo].[TPRProducts]
	                WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	                UNION ALL
	                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName]
	                FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                WHERE B.[OldProNumy] = @Barcode
                    UNION ALL
                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                FROM [Stock].[dbo].[TPRProductsDeactivated]
	                WHERE (ISNULL([ProNumY],'') = @Barcode OR ISNULL([ProNumYP],'') = @Barcode OR ISNULL([ProNumYC],'') = @Barcode)
	                UNION ALL
	                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName]
	                FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                WHERE B.[OldProNumy] = @Barcode
                ) LISTS;";
            }
            query = string.Format(query, DatabaseName, CmbProducts.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {
                    TxtQtyPerCase.Text = Convert.ToInt32(lists.Rows[0]["ProQtyPCase"] == DBNull.Value ? 1 : lists.Rows[0]["ProQtyPCase"]).ToString();
                }
                else
                {
                    Goto Check_Item;
                }
            }
            else
            {
            Check_Item:
                MessageBox.Show("The Item is wrong. Please check item again...", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbProducts.Focus();
               return ;


            }

        }

        private void CmbProducts_MouseDown(object sender, MouseEventArgs e)
        {

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
    }
}
