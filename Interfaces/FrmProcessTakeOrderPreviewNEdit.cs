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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmProcessTakeOrderPreviewNEdit : Form
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
        public DateTime vRequiredDate { get; set; }
        public string iPlanningOrder { get; set; }

        public FrmProcessTakeOrderPreviewNEdit()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);


        }

      
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DisplayLoading.Enabled = false;
            query = @"DECLARE @DateRequired AS DATE = N'{1:yyyy-MM-dd}';
                DECLARE @oPlanningOrder AS NVARCHAR(100) = N'{2}';
                WITH o AS (
	                SELECT v.ProID,v.ProNumY,v.ProNumYP,v.ProNumYC,v.ProName,v.ProPacksize,v.ProQtyPCase,v.ProQtyPPack,v.ProCat
	                FROM [Stock].[dbo].[TPRProducts] v
	                UNION ALL
                    SELECT v.ProID,v.ProNumY,v.ProNumYP,v.ProNumYC,v.ProName,v.ProPacksize,v.ProQtyPCase,v.ProQtyPPack,v.ProCat
	                FROM [Stock].[dbo].[TPRProductsDeactivated] v
	                UNION ALL
                    SELECT v.ProID,o.OldProNumy AS ProNumY,v.ProNumYP,v.ProNumYC,v.ProName,v.ProPacksize,v.ProQtyPCase,v.ProQtyPPack,v.ProCat
	                FROM [Stock].[dbo].[TPRProducts] v 
	                INNER JOIN [Stock].[dbo].[TPRProductsOldCode] o ON o.ProId = v.ProID
	                UNION ALL
                    SELECT v.ProID,o.OldProNumy AS ProNumY,v.ProNumYP,v.ProNumYC,v.ProName,v.ProPacksize,v.ProQtyPCase,v.ProQtyPPack,v.ProCat
	                FROM [Stock].[dbo].[TPRProductsDeactivated] v 
	                INNER JOIN [Stock].[dbo].[TPRProductsOldCode] o ON o.ProId = v.ProID
                )
                SELECT o.*
                INTO #vList
                FROM o;

                UPDATE v
                SET v.[ProName] = o.ProName
                ,v.[Size] = o.ProPacksize
                ,v.[QtyPCase] = CONVERT(INT,o.ProQtyPCase)
                ,v.[QtyPPack] = CONVERT(INT,o.ProQtyPPack)
                ,v.[Category] = o.ProCat
                FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill] v
                INNER JOIN #vList o ON o.ProNumY = v.UnitNumber;

                UPDATE v
                SET v.ProName = o.ProName
                ,v.Size = o.ProPacksize
                ,v.QtyPCase = CONVERT(INT,o.ProQtyPCase)
                FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] AS v
                INNER JOIN #vList o ON o.ProNumY = v.Barcode;

                UPDATE v
                SET v.[ProName] = o.ProName
                ,v.[Size] = o.ProPacksize
                ,v.[QtyPerCase] = CONVERT(INT,o.ProQtyPCase)
                FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] v
                INNER JOIN #vList o ON o.ProNumY = v.Barcode;

                DROP TABLE #vList;

                WITH v as (
                    SELECT [Barcode],[ProName],[Category] AS [Remark],[Size],[QtyPCase],ISNULL([DelTo],'') AS [CusName],SUM(ISNULL([TotalPcsOrder],0)) AS [TotalPcsOrder],[DateRequired],[DelToId]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    WHERE (ISNULL([PromotionMachanic],N'') = @oPlanningOrder) AND DATEDIFF(DAY,[DateRequired],@DateRequired) = 0
                    GROUP BY [Barcode],[ProName],[Category],[Size],[QtyPCase],ISNULL([DelTo],''),[DateRequired],[DelToId]
                    UNION ALL
                    SELECT x.[Barcode],x.[ProName],x.[Category] AS [Remark],x.[Size],x.[QtyPCase],ISNULL(x.[DelTo],'') AS [CusName],NULL AS [TotalPcsOrder],[DateRequired],x.[DelToId]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill] as x
                    WHERE (ISNULL([PromotionMachanic],N'') = @oPlanningOrder) AND DATEDIFF(DAY,x.[DateRequired],@DateRequired) = 0
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
                THEN 1 ELSE 0 END AS [Missing],v.[DelToId]
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
                THEN 1 ELSE 0 END,v.[DelToId])

				SELECT w.[Barcode],w.[ProName],w.[Remark],REPLACE(w.[Size],' ','') AS [Size],w.[QtyPCase],w.[CusName],case when isnull(w.[TotalPcsOrder],0) = 0 then null else w.[TotalPcsOrder] end as [TotalPcsOrder],
                CASE WHEN (w.[Missing] = 1 AND ISNULL(w.[TotalPcsOrder],0) <> 0) OR ISNULL(w.[DelToId],0) = 0 THEN 1 ELSE 0 END AS [Missing],
                ISNULL(v.[PiecesPerTray],1) AS [PiecesPerTray],w.[DeltoId]
				INTO #vLists
				FROM w
                LEFT OUTER JOIN [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] AS v ON v.Barcode = w.Barcode
                GROUP BY w.[Barcode],w.[ProName],w.[Remark],REPLACE(w.[Size],' ',''),w.[QtyPCase],w.[CusName],case when isnull(w.[TotalPcsOrder],0) = 0 then null else w.[TotalPcsOrder] end,
                CASE WHEN (w.[Missing] = 1 AND ISNULL(w.[TotalPcsOrder],0) <> 0) OR ISNULL(w.[DelToId],0) = 0 THEN 1 ELSE 0 END,
                ISNULL(v.[PiecesPerTray],1),w.[DeltoId]
                ORDER BY w.[Remark],w.[ProName];
				SELECT v.Barcode,v.ProName,v.Remark,v.Size,v.QtyPCase,v.PiecesPerTray,SUM(v.TotalPcsOrder) AS [Total Order],((CEILING(SUM(v.TotalPcsOrder)/ISNULL(v.PiecesPerTray,1))*ISNULL(v.PiecesPerTray,1)) - SUM(v.TotalPcsOrder)) AS [Total Extra/Left],(CEILING(SUM(v.TotalPcsOrder)/ISNULL(v.PiecesPerTray,1))*ISNULL(v.PiecesPerTray,1)) AS [Total Order To Thailand] --,ROUND(((CEILING(SUM(v.TotalPcsOrder)/ISNULL(v.PiecesPerTray,1))*ISNULL(v.PiecesPerTray,1)) / ISNULL(v.PiecesPerTray,1)),2) AS [Total Tray]
				INTO #v
				FROM #vLists AS v
				GROUP BY v.Barcode,v.ProName,v.Remark,v.Size,v.QtyPCase,v.PiecesPerTray
				ORDER BY v.Size,v.ProName;

                DELETE FROM #vLists
                WHERE (COALESCE([CusName], N'') = N'')
                      AND (COALESCE([DelToId], 0) = 0);

				DECLARE @vValue1 AS NVARCHAR(MAX) = N'';
				DECLARE @vValue2 AS NVARCHAR(MAX) = N'';
				DECLARE vCur CURSOR
				FOR SELECT N'ALTER TABLE #v ADD [' + x.CusName + '] DECIMAL(18,0) NULL ;' AS [value1],N'UPDATE v SET v.[' + x.CusName + '] = x.TotalPcsOrder FROM #v AS v INNER JOIN #vLists AS x ON x.Barcode = v.Barcode WHERE x.CusName = N''' + x.CusName + ''';' AS [value2] FROM #vLists AS x GROUP BY x.CusName ORDER BY x.CusName;
				OPEN vCur;
				FETCH NEXT FROM vCur INTO @vValue1,@vValue2;
				WHILE @@FETCH_STATUS = 0
				BEGIN
					EXEC(@vValue1);
					EXEC(@vValue2);
					FETCH NEXT FROM vCur INTO @vValue1,@vValue2;
				END
                CLOSE vCur;
				DEALLOCATE vCur;
				SELECT v.*
				FROM #v AS v
				ORDER BY v.Remark,v.Size,v.Barcode,v.ProName;
				DROP TABLE #vLists;				
				DROP TABLE #v;";


            query = string.Format(query, DatabaseName, vRequiredDate, iPlanningOrder);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            //DgvShow.Columns["ProName"].HeaderText = "Description";
            //DgvShow.Columns["QtyPCase"].HeaderText = "Q/C";
            //DgvShow.Columns["PiecesPerTray"].HeaderText = "Pieces/Tray";
            LblCountRow.Text = string.Format("Count Row : {0:N0}", DgvShow.RowCount);
            FreezeBand(DgvShow.Columns[8]);
            this.Cursor = Cursors.Default;

        }

        private void DgvShow_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 8)
            {
                DgvShow.Rows[e.RowIndex].ReadOnly = true;
            }
            else
            {
                DgvShow.Rows[e.RowIndex].ReadOnly = false;
            }

        }
        private static void FreezeBand(DataGridViewBand band)
        {
            band.Frozen = true;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.WhiteSmoke;
            band.DefaultCellStyle = style;
        }


        private void DgvShow_Paint(object sender, PaintEventArgs e)
        {
         

        }

        private void DgvShow_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Access the current row
                var row = DgvShow.Rows[e.RowIndex];

                // Apply alternating row colors
                if (e.RowIndex % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray; // Use a predefined color for clarity
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void DgvShow_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvShow.RowCount <= 0) return;

            string vBarcode = DgvShow.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
            string vHeader = DgvShow.Columns[e.ColumnIndex].HeaderText;
            decimal vPcsOrder = Convert.ToDecimal(DBNull.Value.Equals(DgvShow.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) || DgvShow.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("") ? 0 : DgvShow.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            decimal vPiecesPerTray = Convert.ToDecimal(DBNull.Value.Equals(DgvShow.Rows[e.RowIndex].Cells["PiecesPerTray"].Value) || DgvShow.Rows[e.RowIndex].Cells["PiecesPerTray"].Value.Equals("") ? 0 : DgvShow.Rows[e.RowIndex].Cells["PiecesPerTray"].Value);
            decimal vTotalOrderToThailand = (Math.Ceiling(vPcsOrder / vPiecesPerTray) * vPiecesPerTray);
            decimal vTotalExtraLeft = (vTotalOrderToThailand - vPcsOrder);

            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();

            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                query = $@"
        DECLARE @vDelTo AS NVARCHAR(100) = N'{vHeader}';
        DECLARE @vBarcode AS NVARCHAR(MAX) = N'{vBarcode}';
        DECLARE @vPcsOrder AS DECIMAL(18,0) = {vPcsOrder};
        DECLARE @vDateRequired AS DATE = N'{vRequiredDate:yyyy-MM-dd}';
        DECLARE @oPlanningOrder AS NVARCHAR(100) = N'{iPlanningOrder}';

        UPDATE [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
        SET [PcsFree] = 0,
            [PcsOrder] = @vPcsOrder,
            [PackOrder] = 0,
            [CTNOrder] = 0,
            [TotalPcsOrder] = @vPcsOrder
        WHERE (ISNULL([PromotionMachanic],N'') = @oPlanningOrder) AND [Barcode] = @vBarcode AND [DelTo] = @vDelTo AND DATEDIFF(DAY,CONVERT(DATE,[DateRequired]),@vDateRequired) = 0;
    ";
                query = string.Format(query, DatabaseName, vHeader, vBarcode, vPcsOrder, vRequiredDate, iPlanningOrder);
                RCom.CommandText = query;
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();

                query = $@"
        DECLARE @vDateRequired AS DATE = N'{vRequiredDate:yyyy-MM-dd}';
        DECLARE @vBarcode AS NVARCHAR(MAX) = N'{vBarcode}';    
        DECLARE @oPlanningOrder AS NVARCHAR(100) = N'{iPlanningOrder}';

        SELECT SUM(v.TotalPcsOrder) AS [Total Order],
               ((CEILING(SUM(v.TotalPcsOrder)/ISNULL(x.PiecesPerTray,1))*ISNULL(x.PiecesPerTray,1)) - SUM(v.TotalPcsOrder)) AS [Total Extra/Left],
               (CEILING(SUM(v.TotalPcsOrder)/ISNULL(x.PiecesPerTray,1))*ISNULL(x.PiecesPerTray,1)) AS [Total Order To Thailand]
        FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS v
        LEFT OUTER JOIN [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] AS x ON v.Barcode = x.Barcode
        WHERE (ISNULL([PromotionMachanic],N'') = @oPlanningOrder) AND v.[Barcode] = @vBarcode AND DATEDIFF(DAY,CONVERT(DATE,[DateRequired]),@vDateRequired) = 0
        GROUP BY ISNULL(x.PiecesPerTray,1);
    ";
                query = string.Format(query, DatabaseName, vRequiredDate, vBarcode, iPlanningOrder);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

                if (lists != null && lists.Rows.Count > 0)
                {
                    vPcsOrder = Convert.ToDecimal(DBNull.Value.Equals(lists.Rows[0]["Total Order"]) ? 0 : lists.Rows[0]["Total Order"]);
                    vTotalOrderToThailand = Convert.ToDecimal(DBNull.Value.Equals(lists.Rows[0]["Total Order To Thailand"]) ? 0 : lists.Rows[0]["Total Order To Thailand"]);
                    vTotalExtraLeft = Convert.ToDecimal(DBNull.Value.Equals(lists.Rows[0]["Total Extra/Left"]) ? 0 : lists.Rows[0]["Total Extra/Left"]);
                }

                DgvShow.Rows[e.RowIndex].Cells["Total Order"].Value = vPcsOrder;
                DgvShow.Rows[e.RowIndex].Cells["Total Extra/Left"].Value = vTotalExtraLeft;
                DgvShow.Rows[e.RowIndex].Cells["Total Order To Thailand"].Value = vTotalOrderToThailand;
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

        private void DgvShow_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (e.FormattedValue != null)
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.RotateTransform(270);
                    e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                    e.Graphics.ResetTransform();
                    e.Handled = true;
                }
            }

        }

        private void FrmProcessTakeOrderPreviewNEdit_Paint(object sender, PaintEventArgs e)
        {
            this.Text = string.Format("Preview & Edit Take Order For {0:dd-MMM-yyyy}", vRequiredDate);

        }

        private void FrmProcessTakeOrderPreviewNEdit_Load(object sender, EventArgs e)
        {
           this.DisplayLoading.Enabled = true;
        }
        private void LoadingInitialized()
        {


        }
    }
}
