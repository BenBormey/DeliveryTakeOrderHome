using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliveryTakeOrder.Declares;
using Microsoft.Office.Interop;
using DevExpress.XtraReports;
using Microsoft.VisualBasic;
using gcExtensions;
using System.Security.AccessControl;
using System.Data.OleDb;
using DevExpress.XtraReports.UI;
using XtraSubreport;
using DeliveryTakeOrder.Dev;
using DeliveryTakeOrder.Interfaces.Teamleader;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmDutchmillTakeOrder : Form
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
        private warehouseNameModel warehouseName;

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
        private MDI menuMdi { get; set; }


        public FrmDutchmillTakeOrder(MDI menuMdi, warehouseNameModel warehouseName)
        {
            this.menuMdi = menuMdi;
            this.warehouseName = warehouseName;
            // this call is required bvy the designder.
            InitializeComponent();


            // add anuy initialization after the initailizeComponent() call.
        }

        private void FrmDutchmillTakeOrder_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            PlanningOrderLoading.Enabled = true;
            BillToLoading.Enabled = true;
            DrawCheckBoxInDataGridView();
        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
            this.Text = string.Format("Dutchmill Planning Order ( {0} )", vDepartment.Trim());
            this.LblTeam.Text = vDepartment.Trim().ToUpper();
            vDefaultIndex = 0;
            vFilterNotRenew = false;
        }

        private void DrawCheckBoxInDataGridView()
        {
            Rectangle rect = DgvShow.GetCellDisplayRectangle(0, -1, true);
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 10);
            vCheckBox = new CheckBox
            {
                BackColor = Color.Transparent,
                Visible = false,
                Name = "Checker",
                Size = new Size(18, 18),
                Location = rect.Location
            };
            vCheckBox.CheckedChanged += new EventHandler(vCheckBox_CheckedChanged);
            DgvShow.Controls.Add(vCheckBox);
        }
        private bool vRefresh;

        private void vCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vRefresh)
            {
                vRefresh = false;
                return;
            }

            CheckBox headerBox = (CheckBox)DgvShow.Controls.Find("Checker", true)[0];
            bool vDefaulValue = false;

            foreach (DataGridViewRow row in DgvShow.Rows)
            {
                vDefaulValue = Convert.ToBoolean(row.Cells["ManualRenew"].Value);
                // AddHandler DgvShow.CellContentClick, AddressOf DgvShow_CellContentClick
                DgvShow_CellContentClick(DgvShow, new DataGridViewCellEventArgs(0, row.Index));

                if (!vDefaulValue && !Convert.ToBoolean(row.Cells["ManualRenew"].Value))
                {
                    vRefresh = true;
                    vCheckBox.Checked = false;
                    DgvShow.CurrentCell = DgvShow.Rows[row.Index].Cells["CusName"];
                    DgvShow.Rows[row.Index].Selected = true;
                    DgvShow.RowsDefaultCellStyle.SelectionBackColor = Color.FromName("Highlight");
                    DgvShow.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }

                row.Cells["ManualRenew"].Value = headerBox.Checked;
                vRefresh = false;
            }
        }

        private decimal vDefaultIndex;
        private bool vFilterNotRenew;
        private DataTable vDisplayList;

        private void DgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvShow.RowCount <= 0) return;
            if (e.ColumnIndex != 0 && e.ColumnIndex != 1 && e.ColumnIndex != 2) return;
            if (e.RowIndex == -1) return;

            int vReNew = 0;
            int vNotAccept = 0;
            int vChangeQty = 0;
            decimal vId = 0;
            string vBarcode = "";
            string vProName = "";
            string vSize = "";
            int vQtyPerCase = 1;
            decimal vPcsOrder = 0;
            decimal vCTNOrder = 0;
            string vCusNum = "";
            string vQuery = "";

            var row = DgvShow.Rows[e.RowIndex];
            vCusNum = Convert.IsDBNull(row.Cells["CusNum"].Value) ? "" : row.Cells["CusNum"].Value.ToString().Trim();
            vId = Convert.IsDBNull(row.Cells["Id"].Value) ? 0 : Convert.ToDecimal(row.Cells["Id"].Value);
            vBarcode = Convert.IsDBNull(row.Cells["Barcode"].Value) ? "" : row.Cells["Barcode"].Value.ToString().Trim();
            vProName = Convert.IsDBNull(row.Cells["ProName"].Value) ? "" : row.Cells["ProName"].Value.ToString().Trim();
            vSize = Convert.IsDBNull(row.Cells["Size"].Value) ? "" : row.Cells["Size"].Value.ToString().Trim();
            vQtyPerCase = Convert.IsDBNull(row.Cells["QtyPerCase"].Value) ? 1 : Convert.ToInt32(row.Cells["QtyPerCase"].Value);
            vPcsOrder = Convert.IsDBNull(row.Cells["PcsOrder"].Value) ? 0 : Convert.ToDecimal(row.Cells["PcsOrder"].Value);
            vCTNOrder = Convert.IsDBNull(row.Cells["CTNOrder"].Value) ? 0 : Convert.ToDecimal(row.Cells["CTNOrder"].Value);

            if (DgvShow.Columns[e.ColumnIndex].Name.Equals("ManualRenew"))
            {
                if (Convert.ToBoolean(row.Cells["ManualNotAccept"].Value))
                {
                    MessageBox.Show("The Item is not accept.\nSo, Cannot renew this item.", "Not Accept", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                vReNew = Convert.ToBoolean(row.Cells["ManualRenew"].Value) ? 0 : 1;
                vQuery = @"
       DECLARE @vId AS DECIMAL(18,0) = {1};
                                DECLARE @vReNew AS BIT = {2};
                                UPDATE [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                                SET [Renew] = @vReNew,[NotAccept] = 0,[ChangeQty] = 0,[VerifyDate] = GETDATE(),[RequiredDate] = NULL
                                WHERE [Id] = @vId;
                            
        ";
                vQuery = string.Format(vQuery, DatabaseName, vId, vReNew);
            }
            else if (DgvShow.Columns[e.ColumnIndex].Name.Equals("ManualNotAccept"))
            {
                vNotAccept = Convert.ToBoolean(row.Cells["ManualNotAccept"].Value) ? 0 : 1;
                vQuery = @"
               DECLARE @vId AS DECIMAL(18,0) = {1};
                                DECLARE @vNotAccept AS BIT = {2};
                                UPDATE [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                                SET [NotAccept] = @vNotAccept,[Renew] = 0,[ChangeQty] = 0,[VerifyDate] = GETDATE()
                                WHERE [Id] = @vId;

                       
        ";
                vQuery = string.Format(vQuery, DatabaseName, vId, vNotAccept);
            }
            else if (DgvShow.Columns[e.ColumnIndex].Name.Equals("ManualChangeQty"))
            {
                if (Convert.ToBoolean(row.Cells["ManualChangeQty"].Value))
                {
                    vChangeQty = 0;
                }
                else
                {
                    FrmDutchmillTakeOrderQty vFrm = new FrmDutchmillTakeOrderQty
                    {
                        vId = vId,
                        vBarcode = vBarcode,
                        vProName = vProName,
                        vSize = vSize,
                        vQtyPerCase = vQtyPerCase,
                        vPcsOrder = vPcsOrder,
                        vCTNOrder = vCTNOrder
                    };
                    if (vFrm.ShowDialog(this.menuMdi) == DialogResult.Cancel) return;
                    vChangeQty = 1;
                }
                vQuery = @"
                      
          DECLARE @vId AS DECIMAL(18,0) = {1};
                                DECLARE @vChangeQty AS BIT = {2};
                                UPDATE [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                                SET [Renew] = 0,[NotAccept] = 0,[ChangeQty] = @vChangeQty,[VerifyDate] = GETDATE(),[RequiredDate] = NULL
                                WHERE [Id] = @vId;
        ";
            }

            if (DgvShow.Columns[e.ColumnIndex].Name.Equals("ManualRenew"))
            {
                vDisplayList.Rows[e.RowIndex]["Renew"] = !Convert.ToBoolean(vDisplayList.Rows[e.RowIndex]["Renew"]);
                vDisplayList.Rows[e.RowIndex]["NotAccept"] = false;
                vDisplayList.Rows[e.RowIndex]["ChangeQty"] = false;
            }
            else if (DgvShow.Columns[e.ColumnIndex].Name.Equals("ManualNotAccept"))
            {
                vDisplayList.Rows[e.RowIndex]["Renew"] = false;
                vDisplayList.Rows[e.RowIndex]["NotAccept"] = !Convert.ToBoolean(vDisplayList.Rows[e.RowIndex]["NotAccept"]);
                vDisplayList.Rows[e.RowIndex]["ChangeQty"] = false;
            }
            else if (DgvShow.Columns[e.ColumnIndex].Name.Equals("ManualChangeQty"))
            {
                vDisplayList.Rows[e.RowIndex]["Renew"] = false;
                vDisplayList.Rows[e.RowIndex]["NotAccept"] = false;
                vDisplayList.Rows[e.RowIndex]["ChangeQty"] = !Convert.ToBoolean(vDisplayList.Rows[e.RowIndex]["ChangeQty"]);
            }

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
                    CommandText = vQuery
                };
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();

                if (e.ColumnIndex == 2)
                {
                    vDefaultIndex = e.RowIndex;
                    DisplayLoading.Enabled = true;
                }
                else
                {
                    foreach (DataGridViewRow vRow in DgvShow.Rows)
                    {
                        vRow.Cells["ManualRenew"].Value = Convert.ToBoolean(vRow.Cells["Renew"].Value);
                        vRow.Cells["ManualNotAccept"].Value = Convert.ToBoolean(vRow.Cells["NotAccept"].Value);
                        vRow.Cells["ManualChangeQty"].Value = Convert.ToBoolean(vRow.Cells["ChangeQty"].Value);

                        if (!Convert.ToBoolean(vRow.Cells["ManualRenew"].Value) && !Convert.ToBoolean(vRow.Cells["ManualChangeQty"].Value))
                        {
                            vRow.DefaultCellStyle.ForeColor = Convert.ToBoolean(vRow.Cells["ManualNotAccept"].Value) ? Color.Gray : Color.Red;
                        }
                        else
                        {
                            vRow.DefaultCellStyle.ForeColor = Convert.ToBoolean(vRow.Cells["ManualNotAccept"].Value) ? Color.Gray : Color.Black;
                        }
                    }
                }
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

        private void DisplayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DisplayLoading.Enabled = false;
            if (vDisplayList == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            string vPlanning = "";
            if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
            {
                vPlanning = "";
            }
            else
            {
                vPlanning = string.IsNullOrWhiteSpace(CmbPlanningOrder.Text.Trim()) ? "" : CmbPlanningOrder.SelectedValue.ToString();
            }

            string vCusNum = "";
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                vCusNum = "";
            }
            else
            {
                vCusNum = string.IsNullOrWhiteSpace(CmbBillTo.Text.Trim()) ? "" : CmbBillTo.SelectedValue.ToString();
            }

            decimal vDeltoId = 0;
            if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
            {
                vDeltoId = 0;
            }
            else
            {
                vDeltoId = string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()) ? 0 : Convert.ToDecimal(CmbDelto.SelectedValue);
            }

            string vBarcode = CmbProducts.Text.Trim();
            if (vBarcode.Length > 13) vBarcode = vBarcode.Substring(0, 15).Trim();

            if (CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue == null)
            {
                vBarcode = vBarcode;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(CmbProducts.Text.Trim()))
                {
                    vBarcode = vBarcode;
                }
                else
                {
                    vBarcode = CmbProducts.SelectedValue.ToString();
                }
            }
            query = @"UPDATE ll
SET [ll].[CusNum] = [ld].[CusNum],
    [ll].[DeltoId] = [ld].[DefId],
    [ll].[Delto] = [ld].[DelTo]
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] ll
    INNER JOIN [Stock].[dbo].[TPRDelto] ld
        ON ([ld].[DefId] = [ll].[DeltoId]);

UPDATE ll
SET [ll].[CusName] = [lc].[CusName]
FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] ll
    INNER JOIN [Stock].[dbo].[TPRCustomer] lc
        ON ([lc].[CusNum] = [ll].[CusNum]);

                DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';
                DECLARE @vBarcode AS NVARCHAR(MAX) = N'{5}';
                DECLARE @vFilterNotRenew AS BIT = {6};

                WITH    i AS ( SELECT   [Id] ,
                                        [DefId] ,
                                        [DelTo] ,
                                        [KhmerUnicode] ,
                                        [Address] ,
                                        [KhmerAddress] ,
                                        [Zone] ,
                                        [Street] ,
                                        [HouseNumber] ,
                                        [Date] ,
                                        [ContactName1] ,
                                        [ContactName2] ,
                                        [Tel1] ,
                                        [Tel2] ,
                                        [Fax1] ,
                                        [Fax2] ,
                                        [HP1] ,
                                        [HP2] ,
                                        [Class] ,
                                        [Remark] ,
                                        [SizeOfShop] ,
                                        [DateLastInvoice] ,
                                        [AirCondition] ,
                                        [Freezer] ,
                                        [AlternativeSnacks] ,
                                        [AutomotiveProducts] ,
                                        [Beer] ,
                                        [Candy] ,
                                        [Chocolate] ,
                                        [EdibleGrocery] ,
                                        [NonEdibleGrocery] ,
                                        [FluidMilkProducts] ,
                                        [FoodServiceSupply] ,
                                        [Gum] ,
                                        [HealthAndBeautyCare] ,
                                        [Liquor] ,
                                        [PackBeveragesNonAlcoholic] ,
                                        [PackagedSweetSnacks] ,
                                        [SaltySnacks] ,
                                        [SuppliesAndServices] ,
                                        [Tobacco] ,
                                        [Wine] ,
                                        [FreshDairy] ,
                                        [FreshFluidMilkProducts] ,
                                        [FreshFrozenFoods] ,
                                        [PackagedIceCreamNovelties] ,
                                        [PerishableGrocery] ,
                                        [DelToInKhmer] ,
                                        [City] ,
                                        [Block] ,
                                        [ShopNumber] ,
                                        [SignatureImage] ,
                                        [Latitude] ,
                                        [Longitude] ,
                                        [Status] ,
                                        [CreatedDate]
                               FROM     [Stock].[dbo].[TPRDelto]
                               UNION ALL
                               SELECT   [Id] ,
                                        [DefId] ,
                                        [DelTo] ,
                                        [KhmerUnicode] ,
                                        [Address] ,
                                        [KhmerAddress] ,
                                        [Zone] ,
                                        [Street] ,
                                        [HouseNumber] ,
                                        [Date] ,
                                        [ContactName1] ,
                                        [ContactName2] ,
                                        [Tel1] ,
                                        [Tel2] ,
                                        [Fax1] ,
                                        [Fax2] ,
                                        [HP1] ,
                                        [HP2] ,
                                        [Class] ,
                                        [Remark] ,
                                        [SizeOfShop] ,
                                        [DateLastInvoice] ,
                                        [AirCondition] ,
                                        [Freezer] ,
                                        [AlternativeSnacks] ,
                                        [AutomotiveProducts] ,
                                        [Beer] ,
                                        [Candy] ,
                                        [Chocolate] ,
                                        [EdibleGrocery] ,
                                        [NonEdibleGrocery] ,
                                        [FluidMilkProducts] ,
                                        [FoodServiceSupply] ,
                                        [Gum] ,
                                        [HealthAndBeautyCare] ,
                                        [Liquor] ,
                                        [PackBeveragesNonAlcoholic] ,
                                        [PackagedSweetSnacks] ,
                                        [SaltySnacks] ,
                                        [SuppliesAndServices] ,
                                        [Tobacco] ,
                                        [Wine] ,
                                        [FreshDairy] ,
                                        [FreshFluidMilkProducts] ,
                                        [FreshFrozenFoods] ,
                                        [PackagedIceCreamNovelties] ,
                                        [PerishableGrocery] ,
                                        [DelToInKhmer] ,
                                        [City] ,
                                        [Block] ,
                                        [ShopNumber] ,
                                        [SignatureImage] ,
                                        [Latitude] ,
                                        [Longitude] ,
                                        [Status] ,
                                        [CreatedDate]
                               FROM     [Stock].[dbo].[TPRDeltoDeactivate]
                               UNION ALL
                               SELECT   [Id] ,
                                        [DefId] ,
                                        [DelTo] ,
                                        [KhmerUnicode] ,
                                        [Address] ,
                                        [KhmerAddress] ,
                                        [Zone] ,
                                        [Street] ,
                                        [HouseNumber] ,
                                        [Date] ,
                                        [ContactName1] ,
                                        [ContactName2] ,
                                        [Tel1] ,
                                        [Tel2] ,
                                        [Fax1] ,
                                        [Fax2] ,
                                        [HP1] ,
                                        [HP2] ,
                                        [Class] ,
                                        [Remark] ,
                                        [SizeOfShop] ,
                                        [DateLastInvoice] ,
                                        [AirCondition] ,
                                        [Freezer] ,
                                        [AlternativeSnacks] ,
                                        [AutomotiveProducts] ,
                                        [Beer] ,
                                        [Candy] ,
                                        [Chocolate] ,
                                        [EdibleGrocery] ,
                                        [NonEdibleGrocery] ,
                                        [FluidMilkProducts] ,
                                        [FoodServiceSupply] ,
                                        [Gum] ,
                                        [HealthAndBeautyCare] ,
                                        [Liquor] ,
                                        [PackBeveragesNonAlcoholic] ,
                                        [PackagedSweetSnacks] ,
                                        [SaltySnacks] ,
                                        [SuppliesAndServices] ,
                                        [Tobacco] ,
                                        [Wine] ,
                                        [FreshDairy] ,
                                        [FreshFluidMilkProducts] ,
                                        [FreshFrozenFoods] ,
                                        [PackagedIceCreamNovelties] ,
                                        [PerishableGrocery] ,
                                        [DelToInKhmer] ,
                                        [City] ,
                                        [Block] ,
                                        [ShopNumber] ,
                                        [SignatureImage] ,
                                        [Latitude] ,
                                        [Longitude] ,
                                        [Status] ,
                                        [CreatedDate]
                               FROM     [Stock].[dbo].[TPRDelto.Deleted]
                             )
                    SELECT  i.*
                    INTO    #oDelto
                    FROM    i;

                SELECT  i.[Renew] ,
                        i.[NotAccept] ,
                        i.[ChangeQty] ,
                        i.[Id] ,
                        i.[CusNum] ,
                        i.[CusName] ,
                        i.[DeltoId] ,
                        i.[Delto] ,
                        o.Zone ,
                        i.[UnitNumber] ,
                        i.[Barcode] ,
                        CONVERT(NVARCHAR,N'') [CusCode] ,
                        i.[ProName] ,
                        i.[Size] ,
                        i.[QtyPerCase] ,
                        i.[PcsOrder] ,
                        i.[CTNOrder] ,
                        i.[TotalPcsOrder] ,
                        i.[SupNum] ,
                        i.[SupName] ,
                        i.[Department] ,
                        i.[PlanningOrder] ,
                        i.[MachineName] ,
                        i.[IPAddress] ,
                        i.[CreatedDate] ,
                        i.[VerifyDate] ,
                        i.[RequiredDate]
                INTO    #oDutchmillOrder
                FROM    [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] i
                        INNER JOIN #oDelto o ON o.DefId = i.DeltoId
                WHERE   ( i.[Department] = @vDepartment )
                        AND ( i.[CusNum] = @vCusNum
                              OR N'' = @vCusNum
                            )
                        AND ( i.[DeltoId] = @vDeltoId
                              OR 0 = @vDeltoId
                            )
                        AND ( i.[PlanningOrder] = @vPlanningOrder )
--AND (i.[PlanningOrder] = @vPlanningOrder OR N'' = @vPlanningOrder)
--AND (i.[Barcode] LIKE @vBarcode + '%' OR N'' = @vBarcode)
ORDER BY                i.[CusName] ,
                        i.[Delto] ,
                        i.[Size] ,
                        i.[ProName];

                UPDATE  i
                SET     i.[CusCode] = x.[CusCode]
                FROM    #oDutchmillOrder i
                        INNER JOIN [{0}].[dbo].[TblCustomerCodes] x ON ( x.CusNum = i.CusNum ) and ( x.[Barcode] = i.[Barcode] );

                IF ( @vFilterNotRenew = 0 )
                    BEGIN
                        SELECT  i.[Renew] ,
                                i.[NotAccept] ,
                                i.[ChangeQty] ,
                                i.[Id] ,
                                i.[CusNum] ,
                                i.[CusName] ,
                                i.[DeltoId] ,
                                i.[Delto] ,
                                i.Zone ,
                                i.[UnitNumber] ,
                                i.[Barcode] ,
                                i.[CusCode] ,
                                i.[ProName] ,
                                i.[Size] ,
                                i.[QtyPerCase] ,
                                i.[PcsOrder] ,
                                i.[CTNOrder] ,
                                i.[TotalPcsOrder] ,
                                i.[SupNum] ,
                                i.[SupName] ,
                                i.[Department] ,
                                i.[PlanningOrder] ,
                                i.[MachineName] ,
                                i.[IPAddress] ,
                                i.[CreatedDate] ,
                                i.[VerifyDate] ,
                                i.[RequiredDate]
                        FROM    #oDutchmillOrder i
                        ORDER BY i.[CusName] ,
                                i.[Delto] ,
                                i.[Size] ,
                                i.[ProName];
                    END;
                ELSE
                    BEGIN
                        SELECT  i.[Renew] ,
                                i.[NotAccept] ,
                                i.[ChangeQty] ,
                                i.[Id] ,
                                i.[CusNum] ,
                                i.[CusName] ,
                                i.[DeltoId] ,
                                i.[Delto] ,
                                i.Zone ,
                                i.[UnitNumber] ,
                                i.[Barcode] ,
                                i.[CusCode] ,
                                i.[ProName] ,
                                i.[Size] ,
                                i.[QtyPerCase] ,
                                i.[PcsOrder] ,
                                i.[CTNOrder] ,
                                i.[TotalPcsOrder] ,
                                i.[SupNum] ,
                                i.[SupName] ,
                                i.[Department] ,
                                i.[PlanningOrder] ,
                                i.[MachineName] ,
                                i.[IPAddress] ,
                                i.[CreatedDate] ,
                                i.[VerifyDate] ,
                                i.[RequiredDate]
                        FROM    #oDutchmillOrder i
                        ORDER BY i.[NotAccept] ,
                                i.[Renew] ,
                                i.[ChangeQty] ,
                                i.[CusName] ,
                                i.[Delto] ,
                                i.[Size] ,
                                i.[ProName];
                    END;
			

                DROP TABLE #oDelto;
                DROP TABLE #oDutchmillOrder;";
            query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment, vBarcode, vFilterNotRenew ? 1 : 0);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            vDisplayList.Rows.Clear();
            foreach (DataRow vR in lists.Rows)
            {
                DataRow vO = vDisplayList.NewRow();
                vO["Renew"] = Convert.ToBoolean(Convert.IsDBNull(vR["Renew"]) ? 0 : vR["Renew"]);
                vO["NotAccept"] = Convert.ToBoolean(Convert.IsDBNull(vR["NotAccept"]) ? 0 : vR["NotAccept"]);
                vO["ChangeQty"] = Convert.ToBoolean(Convert.IsDBNull(vR["ChangeQty"]) ? 0 : vR["ChangeQty"]);
                vO["Id"] = Convert.ToDecimal(Convert.IsDBNull(vR["Id"]) ? 0 : vR["Id"]);
                vO["CusNum"] = Convert.IsDBNull(vR["CusNum"]) ? "" : vR["CusNum"].ToString().Trim();
                vO["CusName"] = Convert.IsDBNull(vR["CusName"]) ? "" : vR["CusName"].ToString().Trim();
                vO["DeltoId"] = Convert.ToDecimal(Convert.IsDBNull(vR["DeltoId"]) ? 0 : vR["DeltoId"]);
                vO["Delto"] = Convert.IsDBNull(vR["Delto"]) ? "" : vR["Delto"].ToString().Trim();
                vO["Zone"] = Convert.IsDBNull(vR["Zone"]) ? "" : vR["Zone"].ToString().Trim();
                vO["UnitNumber"] = Convert.IsDBNull(vR["UnitNumber"]) ? "" : vR["UnitNumber"].ToString().Trim();
                vO["Barcode"] = Convert.IsDBNull(vR["Barcode"]) ? "" : vR["Barcode"].ToString().Trim();
                vO["CusCode"] = Convert.IsDBNull(vR["CusCode"]) ? "" : vR["CusCode"].ToString().Trim();
                vO["ProName"] = Convert.IsDBNull(vR["ProName"]) ? "" : vR["ProName"].ToString().Trim();
                vO["Size"] = Convert.IsDBNull(vR["Size"]) ? "" : vR["Size"].ToString().Trim();
                vO["QtyPerCase"] = Convert.ToInt32(Convert.IsDBNull(vR["QtyPerCase"]) ? 1 : vR["QtyPerCase"]);
                vO["PcsOrder"] = Convert.ToDecimal(Convert.IsDBNull(vR["PcsOrder"]) ? 0 : vR["PcsOrder"]);
                vO["CTNOrder"] = Convert.ToDecimal(Convert.IsDBNull(vR["CTNOrder"]) ? 0 : vR["CTNOrder"]);
                vO["TotalPcsOrder"] = Convert.ToDecimal(Convert.IsDBNull(vR["TotalPcsOrder"]) ? 0 : vR["TotalPcsOrder"]);
                vO["SupNum"] = Convert.IsDBNull(vR["SupNum"]) ? "" : vR["SupNum"].ToString().Trim();
                vO["SupName"] = Convert.IsDBNull(vR["SupName"]) ? "" : vR["SupName"].ToString().Trim();
                vO["Department"] = Convert.IsDBNull(vR["Department"]) ? "" : vR["Department"].ToString().Trim();
                vO["PlanningOrder"] = Convert.IsDBNull(vR["PlanningOrder"]) ? "" : vR["PlanningOrder"].ToString().Trim();
                vO["MachineName"] = Convert.IsDBNull(vR["MachineName"]) ? "" : vR["MachineName"].ToString().Trim();
                vO["IPAddress"] = Convert.IsDBNull(vR["IPAddress"]) ? "" : vR["IPAddress"].ToString().Trim();
                vO["CreatedDate"] = Convert.ToDateTime(Convert.IsDBNull(vR["CreatedDate"]) ? Todate : vR["CreatedDate"]);
                vO["VerifyDate"] = Convert.ToDateTime(Convert.IsDBNull(vR["VerifyDate"]) ? Todate : vR["VerifyDate"]);
                vO["RequiredDate"] = Convert.IsDBNull(vR["RequiredDate"]) ? DBNull.Value : vR["RequiredDate"];
                vDisplayList.Rows.Add(vO);
            }

            foreach (DataGridViewRow vRow in DgvShow.Rows)
            {
                vRow.Cells["ManualRenew"].Value = Convert.ToBoolean(vRow.Cells["Renew"].Value);
                vRow.Cells["ManualNotAccept"].Value = Convert.ToBoolean(vRow.Cells["NotAccept"].Value);
                vRow.Cells["ManualChangeQty"].Value = Convert.ToBoolean(vRow.Cells["ChangeQty"].Value);
            }
            if (vDefaultIndex > 0 && DgvShow.RowCount > 0)
            {
                DgvShow.CurrentCell = DgvShow.Rows[(int)vDefaultIndex].Cells["Barcode"];
                DgvShow.Rows[(int)vDefaultIndex].Selected = true;
                DgvShow.RowsDefaultCellStyle.SelectionBackColor = Color.FromName("Highlight");
                DgvShow.FirstDisplayedScrollingRowIndex = (int)vDefaultIndex;
            }

            LblCountRow.Text = string.Format("Count Row : {0:N0}", DgvShow.RowCount);

            decimal vTotalCus = 0;
            decimal vTotalDelto = 0;
            decimal vTotalItems = 0;

            query = @"
     DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';
                DECLARE @vBarcode AS NVARCHAR(MAX) = N'{5}';
                
                SELECT COUNT(DISTINCT [CusNum]) AS [CusNum],COUNT(DISTINCT [DeltoId]) AS [DeltoId],COUNT(DISTINCT [UnitNumber]) AS [UnitNumber]
                FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                WHERE ([Department] = @vDepartment)
                AND ([PlanningOrder] = @vPlanningOrder OR N'' = @vPlanningOrder);
         
";

            query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment, vBarcode, vFilterNotRenew ? 1 : 0);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null && lists.Rows.Count > 0)
            {
                vTotalCus = Convert.ToDecimal(Convert.IsDBNull(lists.Rows[0]["CusNum"]) ? 0 : lists.Rows[0]["CusNum"]);
                vTotalDelto = Convert.ToDecimal(Convert.IsDBNull(lists.Rows[0]["DeltoId"]) ? 0 : lists.Rows[0]["DeltoId"]);
                vTotalItems = Convert.ToDecimal(Convert.IsDBNull(lists.Rows[0]["UnitNumber"]) ? 0 : lists.Rows[0]["UnitNumber"]);
            }

            LblTotalCustomer.Text = string.Format("♦ Total Customer = {0}", vTotalCus);
            LblTotalDelto.Text = string.Format("♦ Total Delto = {0}", vTotalDelto);
            this.Cursor = Cursors.Default;






        }

        private void CmbDelto_SelectedIndexChanged(object sender, EventArgs e)
        {

            TxtZone.Text = "";
            TxtKhmerName.Text = "";
            if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null) return;
            if (CmbDelto.Text.Trim().Equals("")) return;

            DisplayLoading.Enabled = true;
            decimal vDeltoId = 0;
            if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
            {
                vDeltoId = 0;
            }
            else
            {
                vDeltoId = string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()) ? 0 : Convert.ToDecimal(CmbDelto.SelectedValue);
            }

            string query = @"
           DECLARE @vDeltoId AS DECIMAL(18,0) = {1};
                        SELECT [DelTo],[Zone],[KhmerUnicode]
                        FROM [Stock].[dbo].[TPRDelto]
                        WHERE [DefId] = @vDeltoId;
    ";
            query = string.Format(query, DatabaseName, vDeltoId);
            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null && lists.Rows.Count > 0)
            {
                TxtZone.Text = Convert.IsDBNull(lists.Rows[0]["Zone"]) ? "" : lists.Rows[0]["Zone"].ToString().Trim();
                TxtKhmerName.Text = Convert.IsDBNull(lists.Rows[0]["KhmerUnicode"]) ? "" : lists.Rows[0]["KhmerUnicode"].ToString().Trim();
                CmbProducts.Focus();
            }
        }

        private void CmbDelto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CmbDelto_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Return)
            //{
            //    decimal vDeltoId = 0;
            //    if (IsNumeric(string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()) ? "0" : CmbDelto.Text.Trim()))
            //    {
            //        vDeltoId = Convert.ToDecimal(string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()) ? "0" : CmbDelto.Text.Trim());
            //        CmbDelto.SelectedValue = vDeltoId;
            //        if (string.IsNullOrWhiteSpace(CmbDelto.Text.Trim())) CmbDelto.Text = vDeltoId.ToString();
            //    }
            //}

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CmbPlanningOrder.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select the Planning Order first.", "Select Planning Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbPlanningOrder.Focus();
                return;
            }
            else if (CmbBillTo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select the Bill To.", "Select Bill To", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbBillTo.Focus();
                return;
            }
            else if (CmbDelto.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select the Delto.", "Select Delto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbDelto.Focus();
                return;
            }
            else if (Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtTotalPcsOrder.Text.Trim()) ? "0" : TxtTotalPcsOrder.Text.Trim()) == 0)
            {
                MessageBox.Show("Please enter the Quantity Order.", "Enter Quantity Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCTNOrder.Focus();
                return;
            }
            else
            {
                string vPlanning = "";
                if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
                {
                    vPlanning = "";
                }
                else
                {
                    vPlanning = string.IsNullOrWhiteSpace(CmbPlanningOrder.Text.Trim()) ? "" : CmbPlanningOrder.SelectedValue.ToString();
                }

                string vCusNum = "";
                if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
                {
                    vCusNum = "";
                }
                else
                {
                    vCusNum = string.IsNullOrWhiteSpace(CmbBillTo.Text.Trim()) ? "" : CmbBillTo.SelectedValue.ToString();
                }

                decimal vDeltoId = 0;
                if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
                {
                    vDeltoId = 0;
                }
                else
                {
                    vDeltoId = string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()) ? 0 : Convert.ToDecimal(CmbDelto.SelectedValue);
                }

                string vBarcode = "";
                if (CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue == null)
                {
                    vBarcode = "";
                }
                else
                {
                    vBarcode = string.IsNullOrWhiteSpace(CmbProducts.Text.Trim()) ? "" : CmbProducts.SelectedValue.ToString();
                }

                if (vBarcode.Trim().Equals(""))
                {
                    MessageBox.Show("Please check the Barcode again.", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbProducts.Focus();
                    return;
                }
                decimal vPcsOrder = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtPcsOrder.Text.Trim()) ? "0" : TxtPcsOrder.Text.Trim());
                decimal vCTNOrder = Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtCTNOrder.Text.Trim()) ? "0" : TxtCTNOrder.Text.Trim());

                string query = @"
 DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                    DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                    DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';
                    DECLARE @vBarcode AS NVARCHAR(MAX) = N'{5}';
                    DECLARE @vPcsOrder AS DECIMAL(18,0) = {6};
                    DECLARE @vCTNOrder AS DECIMAL(18,0) = {7};
                    SELECT *
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                    WHERE ([CusNum] = @vCusNum) 
                    --AND ([Department] = @vDepartment) 
                    AND ([DeltoId] = @vDeltoId)
                    AND ([PlanningOrder] = @vPlanningOrder)
                    AND ([Barcode] = @vBarcode)
                    --AND ([PcsOrder] = @vPcsOrder)
                    --AND ([CTNOrder] = @vCTNOrder)
                    ORDER BY [CusName],[Size],[ProName];
";

                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment, vBarcode, vPcsOrder, vCTNOrder);
                DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

                if (lists != null && lists.Rows.Count > 0)
                {
                    if (MessageBox.Show("Please check the Barcode again!\nThe Barcode is existed already.\nDo you want to go ahead? (Yes/No)", "Duplicated Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        CmbProducts.Focus();
                        return;
                    }
                }

                query = @"DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                        DECLARE @vCusName AS NVARCHAR(100) = N'';
                        DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                        DECLARE @vDelto AS NVARCHAR(100) = N'';
                        DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                        DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';
                        DECLARE @vBarcode AS NVARCHAR(MAX) = N'{5}';
                        DECLARE @vMachineName AS NVARCHAR(100) = N'{6}';
                        DECLARE @vIPAddress AS NVARCHAR(25) = N'{7}';
                        DECLARE @vPcsOrder AS DECIMAL(18,0) = {8};
                        DECLARE @vCTNOrder AS DECIMAL(18,0) = {9};
                        DECLARE @vTotalPcsOrder AS DECIMAL(18,0) = 0;
                        DECLARE @vUnitNumber AS NVARCHAR(MAX) = N'';
                        DECLARE @vProName AS NVARCHAR(100) = N'';
                        DECLARE @vSize AS NVARCHAR(30) = N'';
                        DECLARE @vQtyPerCase AS INT = 1;
                        DECLARE @vSupNum AS NVARCHAR(8) = N'';
                        DECLARE @vSupName AS NVARCHAR(100) = N'';
                        DECLARE @vRenew AS BIT = 0;
                        DECLARE @vNotAccept AS BIT = 0;
                        DECLARE @vChangeQty AS BIT = 0;

                        SELECT @vCusName = v.CusName FROM [Stock].[dbo].[TPRCustomer] AS v WHERE v.CusNum = @vCusNum;
                        SELECT @vDelto = v.DelTo FROM [Stock].[dbo].[TPRDelto] AS v WHERE v.DefId = @vDeltoId;
                        WITH vItems AS (
                        SELECT [ProNumY] AS [UnitNumber],[ProName],[ProPacksize] AS [Size],[ProQtyPCase] AS [QtyPerCase],RTRIM(LTRIM(LEFT([Sup1],8))) AS [SupNum],RTRIM(LTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
                        FROM [Stock].[dbo].[TPRProducts]
                        WHERE (ISNULL([ProNumY],N'') = @vBarcode OR ISNULL([ProNumYP],N'') = @vBarcode OR ISNULL([ProNumYC],N'') = @vBarcode)
                        UNION ALL
                        SELECT [ProNumY] AS [UnitNumber],[ProName],[ProPacksize] AS [Size],[ProQtyPCase] AS [QtyPerCase],RTRIM(LTRIM(LEFT([Sup1],8))) AS [SupNum],RTRIM(LTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
                        FROM [Stock].[dbo].[TPRProductsDeactivated]
                        WHERE (ISNULL([ProNumY],N'') = @vBarcode OR ISNULL([ProNumYP],N'') = @vBarcode OR ISNULL([ProNumYC],N'') = @vBarcode)
                        UNION ALL
                        SELECT x.[OldProNumy] AS [UnitNumber],v.[ProName],v.[ProPacksize] AS [Size],v.[ProQtyPCase] AS [QtyPerCase],RTRIM(LTRIM(LEFT(v.[Sup1],8))) AS [SupNum],RTRIM(LTRIM(SUBSTRING(v.[Sup1],9,LEN(v.[Sup1])))) AS [SupName]
                        FROM [Stock].[dbo].[TPRProducts] AS v INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS x ON x.ProId = v.ProID
                        WHERE x.[OldProNumy] = @vBarcode
                        UNION ALL
                        SELECT x.[OldProNumy] AS [UnitNumber],v.[ProName],v.[ProPacksize] AS [Size],v.[ProQtyPCase] AS [QtyPerCase],RTRIM(LTRIM(LEFT(v.[Sup1],8))) AS [SupNum],RTRIM(LTRIM(SUBSTRING(v.[Sup1],9,LEN(v.[Sup1])))) AS [SupName]
                        FROM [Stock].[dbo].[TPRProductsDeactivated] AS v INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS x ON x.ProId = v.ProID
                        WHERE x.[OldProNumy] = @vBarcode)
                        SELECT @vUnitNumber = vItems.UnitNumber,
                        @vProName = vItems.ProName,
                        @vSize = vItems.Size,
                        @vQtyPerCase = vItems.QtyPerCase,
                        @vSupNum = vItems.SupNum,
                        @vSupName = vItems.SupName
                        FROM vItems
                        GROUP BY vItems.UnitNumber,vItems.ProName,vItems.Size,vItems.QtyPerCase,vItems.SupNum,vItems.SupName;
                        IF (@vQtyPerCase IS NULL) SET @vQtyPerCase = 1;
                        SET @vTotalPcsOrder = (@vPcsOrder) + (@vCTNOrder * @vQtyPerCase);
                        INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]([CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate])
                        VALUES(@vCusNum,@vCusName,@vDeltoId,@vDelto,@vUnitNumber,@vBarcode,@vProName,@vSize,@vQtyPerCase,@vPcsOrder,@vCTNOrder,@vTotalPcsOrder,@vSupNum,@vSupName,@vRenew,@vNotAccept,@vChangeQty,@vDepartment,@vPlanningOrder,@vMachineName,@vIPAddress,GETDATE(),GETDATE());";

                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment, vBarcode, Environment.MachineName, "", vPcsOrder, vCTNOrder);
                return;
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
                    vDefaultIndex = vDisplayList.Rows.Count <= 0 ? -1 : vDisplayList.Rows.Count;
                    DisplayLoading.Enabled = true;
                    CmbProducts.SelectedIndex = -1;
                    CmbProducts.Focus();
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

        private void picplanningorder_Click(object sender, EventArgs e)
        {

            FrmPlanningOrder oFrm = new FrmPlanningOrder
            {
                WindowState = FormWindowState.Normal,
                vDepartment = vDepartment
            };
            oFrm.ShowDialog();
            this.CmbPlanningOrder.SelectedIndex = -1;
            this.PlanningOrderLoading.Enabled = true;


        }

        private void PlanningOrderLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.PlanningOrderLoading.Enabled = false;
            this.vDefaultIndex = -1;
            query = @"WITH v AS (
	                        SELECT [PlanningOrder]
	                        FROM [{0}].[dbo].[TblDeliveryTakeOrders_PlanningOrder]
	                        GROUP BY [PlanningOrder]
                        )
                        SELECT v.[PlanningOrder]
                        FROM v
                        GROUP BY v.[PlanningOrder]
                        ORDER BY v.[PlanningOrder];";
            query = string.Format(query, DatabaseName);
            DataTable oLists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            this.DataSources(this.CmbPlanningOrder, oLists, "PlanningOrder", "PlanningOrder");
            this.Cursor = Cursors.Default;

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
            string vCusNum = "";
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                vCusNum = "";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(CmbBillTo.Text.Trim()))
                {
                    vCusNum = "";
                }
                else
                {
                    vCusNum = CmbBillTo.SelectedValue.ToString();
                }
            }

            query = @"DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
WITH lItems
AS (SELECT [ProNumY] AS [Barcode],
           [ProName] AS [ProName],
           CONCAT([ProNumY], SPACE(3), [ProName], SPACE(3), [ProPacksize]) [Display],
           LEFT([Sup1], 8) [SupNum]
    FROM [Stock].[dbo].[TPRProducts]
    GROUP BY [ProNumY],
             [ProName],
             CONCAT([ProNumY], SPACE(3), [ProName], SPACE(3), [ProPacksize]),
             LEFT([Sup1], 8)
    UNION ALL
    SELECT ISNULL([ProNumYP], '') AS [Barcode],
           [ProName] AS [ProName],
           CONCAT(ISNULL([ProNumYP], ''), SPACE(3), [ProName], SPACE(3), [ProPacksize]) [Display],
           LEFT([Sup1], 8) [SupNum]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE (ISNULL([ProNumYP], N'') <> N'')
    GROUP BY ISNULL([ProNumYP], ''),
             [ProName],
             CONCAT(ISNULL([ProNumYP], ''), SPACE(3), [ProName], SPACE(3), [ProPacksize]),
             LEFT([Sup1], 8)
    UNION ALL
    SELECT ISNULL([ProNumYC], '') AS [Barcode],
           [ProName] AS [ProName],
           CONCAT(ISNULL([ProNumYC], ''), SPACE(3), [ProName], SPACE(3), [ProPacksize]) [Display],
           LEFT([Sup1], 8) [SupNum]
    FROM [Stock].[dbo].[TPRProducts]
    WHERE (ISNULL([ProNumYC], N'') <> N'')
    GROUP BY ISNULL([ProNumYC], ''),
             [ProName],
             CONCAT(ISNULL([ProNumYC], ''), SPACE(3), [ProName], SPACE(3), [ProPacksize]),
             LEFT([Sup1], 8)
    UNION ALL
    SELECT ISNULL([ll].[OldProNumy], '') AS [Barcode],
           [l].[ProName] AS [ProName],
           CONCAT(ISNULL([ll].[OldProNumy], ''), SPACE(3), [l].[ProName], SPACE(3), [l].[ProPacksize]) [Display],
           LEFT([l].[Sup1], 8) [SupNum]
    FROM [Stock].[dbo].[TPRProducts] l
        INNER JOIN [Stock].[dbo].[TPRProductsOldCode] ll
            ON [ll].[ProId] = [l].[ProID]
    WHERE (ISNULL([OldProNumy], N'') <> N'')
    GROUP BY ISNULL([ll].[OldProNumy], ''),
             [l].[ProName],
             CONCAT(ISNULL([ll].[OldProNumy], ''), SPACE(3), [l].[ProName], SPACE(3), [l].[ProPacksize]),
             LEFT([l].[Sup1], 8))
SELECT [l].[Barcode],
       [l].[ProName],
       [l].[Display]
FROM lItems l
WHERE [l].[SupNum] IN
      (
          SELECT [SupNum]
          FROM [Stock].[dbo].[TPRDeliveryDutchmill]
          GROUP BY [SupNum]
          UNION ALL
          SELECT [SupNum]
          FROM [Stock].[dbo].[TPRDeliveryDutchmill.Location]
          GROUP BY [SupNum]
      )
      AND [l].[Barcode] IN
          (
              SELECT [ProNumY]
              FROM [Stock].[dbo].[TPRWSCusProductList]
              WHERE ([CusNum] = @CusNum)
              GROUP BY [ProNumY]
          )
GROUP BY [l].[Barcode],
         [l].[ProName],
         [l].[Display]
ORDER BY [l].[ProName];";

            query = string.Format(query, DatabaseName, vCusNum);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbProducts, lists, "Display", "Barcode");

            // lists  = Data.Selects()
            this.Cursor = Cursors.Default;

        }

        private void DeltoLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            DeltoLoading.Enabled = false;
            string cusnum = "";
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                cusnum = "";

            }
            else
            {
                if (CmbBillTo.Text.Trim() == "")
                {
                    cusnum = "";
                }
                else
                {
                    cusnum = CmbBillTo.SelectedValue.ToString();
                }
            }
            query = @"DECLARE @CusNum AS NVARCHAR(8) = '{1}';
                        UPDATE v
                        SET v.[DelTo] = o.[DelTo]
                        FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS v
                        INNER JOIN [Stock].[dbo].[TPRDelto] AS o ON o.DefId = v.[DeltoId];

                        UPDATE v
                        SET v.[DelTo] = o.[DelTo]
                        FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] AS v
                        INNER JOIN [Stock].[dbo].[TPRDelto] AS o ON o.DefId = v.[DeltoId];
                        
                        SELECT [DefId] [Id],[DelTo]
                        FROM [Stock].[dbo].[TPRDelto]
                        WHERE ([CusNum] = @CusNum)
                        GROUP BY [DefId],[DelTo]
                        ORDER BY [DelTo];";
            query = string.Format(query, DatabaseName, cusnum);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbDelto, lists, "DelTo", "Id");
            this.Cursor = Cursors.Default;

        }

        private void BtnViewCredit_Click(object sender, EventArgs e)
        {

            if (CmbPlanningOrder.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any planning order!", "Select Planning Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbPlanningOrder.Focus();
                return;
            }

            string vPlanning = "";
            if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
            {
                vPlanning = "";
            }
            else
            {
                vPlanning = string.IsNullOrWhiteSpace(CmbPlanningOrder.Text.Trim()) ? "" : CmbPlanningOrder.SelectedValue.ToString();
            }

            FrmDutchmillTakeOrderViewSummaryCredit vFrm = new FrmDutchmillTakeOrderViewSummaryCredit
            {
                vPlanning = vPlanning,
                vDepartment = vDepartment
            };

            if (vFrm.ShowDialog(this) == DialogResult.Cancel) return;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            string vPlanning = "";
            if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
            {
                vPlanning = "";
            }
            else
            {
                vPlanning = string.IsNullOrWhiteSpace(CmbPlanningOrder.Text.Trim()) ? "" : CmbPlanningOrder.SelectedValue.ToString();
            }

            vPlanning = vPlanning.Replace("0.", "").Replace("1.", "").Replace("2.", "").Replace("3.", "").Replace("4.", "").Replace("5.", "").Replace("6.", "").Replace("7.", "").Replace("8.", "").Replace("9.", "")
                                 .Replace("0 .", "").Replace("1 .", "").Replace("2 .", "").Replace("3 .", "").Replace("4 .", "").Replace("5 .", "").Replace("6 .", "").Replace("7 .", "").Replace("8 .", "").Replace("9 .", "")
                                 .Replace("0,", "").Replace("1,", "").Replace("2,", "").Replace("3,", "").Replace("4,", "").Replace("5,", "").Replace("6,", "").Replace("7,", "").Replace("8,", "").Replace("9,", "")
                                 .Replace("0 ,", "").Replace("1 ,", "").Replace("2 ,", "").Replace("3 ,", "").Replace("4 ,", "").Replace("5 ,", "").Replace("6 ,", "").Replace("7 ,", "").Replace("8 ,", "").Replace("9 ,", "");
            vPlanning = string.Format("{0} ( {1} )", vPlanning.Trim().ToUpper(), LblTeam.Text.Trim());
            DateTime oTodate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            OleDbDataAdapter vAdapter1 = new OleDbDataAdapter();
            sExportPlanningOrder vReport1 = new sExportPlanningOrder();
            ReportPrintTool vTool1 = new ReportPrintTool(vReport1);

            vReport1.Parameters["companyname"].Value = string.Format("{0}{1}{2}", Initialized.R_CompanyKhmerName, Environment.NewLine, Initialized.R_CompanyName);
            vReport1.Parameters["companyaddress"].Value = string.Format("{0}{1}{2}{1}Tel:{3}", Initialized.R_CompanyKhmAddress.Replace(Environment.NewLine, "").Trim(), Environment.NewLine, Initialized.R_CompanyAddress.Replace(Environment.NewLine, "").Trim(), Initialized.R_CompanyTelephone);
            vReport1.Parameters["planningorder"].Value = vPlanning;
            vReport1.Parameters["planningdate"].Value = oTodate;
            vReport1.DataSource = vDisplayList.Copy();
            vReport1.DataAdapter = vAdapter1;
            vReport1.DataMember = "dtExportPlanningOrder";
            vReport1.RequestParameters = false;
            vTool1.AutoShowParametersPanel = false;
            vTool1.PrinterSettings.Copies = 1;
            vTool1.ShowRibbonPreviewDialog();

        }

        private void MnuChangePlanningOrder_Click(object sender, EventArgs e)
        {
            this.Popmain.Close();
            if (DgvShow.Rows.Count <= 0) return;

            string vPlanning = "";
            if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
            {
                vPlanning = "";
            }
            else
            {
                vPlanning = string.IsNullOrWhiteSpace(CmbPlanningOrder.Text.Trim()) ? "" : CmbPlanningOrder.SelectedValue.ToString();
            }

            vDefaultIndex = DgvShow.CurrentRow.Index;
            string vCusNum = Convert.IsDBNull(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value) ? "" : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value.ToString().Trim();
            string vCusName = Convert.IsDBNull(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusName"].Value) ? "" : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusName"].Value.ToString().Trim();
            decimal vDeltoId = Convert.ToDecimal(Convert.IsDBNull(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["DeltoId"].Value) ? 0 : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["DeltoId"].Value);
            string vDelto = Convert.IsDBNull(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Delto"].Value) ? "" : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Delto"].Value.ToString().Trim();
            decimal vId = Convert.ToDecimal(Convert.IsDBNull(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value) ? 0 : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value);

            FrmDutchmillTakeOrderPlanningOrder vFrm = new FrmDutchmillTakeOrderPlanningOrder
            {
                vCusNum = vCusNum,
                vCusName = vCusName,
                vDepartment = vDepartment,
                vPlanning = vPlanning,
                vDeltoId = vDeltoId,
                vDelto = vDelto,
                vId = vId
            };

            if (vFrm.ShowDialog(this) == DialogResult.Cancel) return;
            DgvShow.Rows.RemoveAt((int)vDefaultIndex);

            string vCusNum_ = "";
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                vCusNum_ = "";
            }
            else
            {
                vCusNum_ = string.IsNullOrWhiteSpace(CmbBillTo.Text.Trim()) ? "" : CmbBillTo.SelectedValue.ToString();
            }

            decimal vDeltoId_ = 0;
            if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
            {
                vDeltoId_ = 0;
            }
            else
            {
                vDeltoId_ = string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()) ? 0 : Convert.ToDecimal(CmbDelto.SelectedValue);
            }

            string vBarcode = CmbProducts.Text.Trim();
            if (vBarcode.Length > 13) vBarcode = vBarcode.Substring(0, 15).Trim();
            if (!(CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue == null))
            {
                vBarcode = string.IsNullOrWhiteSpace(CmbProducts.Text.Trim()) ? vBarcode : CmbProducts.SelectedValue.ToString();
            }

            decimal vTotalCus = 0;
            decimal vTotalDelto = 0;
            decimal vTotalItems = 0;

            query = @"
   DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';
                DECLARE @vBarcode AS NVARCHAR(MAX) = N'{5}';
                
                SELECT COUNT(DISTINCT [CusNum]) AS [CusNum],COUNT(DISTINCT [DeltoId]) AS [DeltoId],COUNT(DISTINCT [UnitNumber]) AS [UnitNumber]
                FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                WHERE ([Department] = @vDepartment)
                AND ([PlanningOrder] = @vPlanningOrder OR N'' = @vPlanningOrder);  
";

            query = string.Format(query, DatabaseName, vCusNum_, vDeltoId_, vPlanning, vDepartment, vBarcode, vFilterNotRenew ? 1 : 0);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null && lists.Rows.Count > 0)
            {
                vTotalCus = Convert.ToDecimal(Convert.IsDBNull(lists.Rows[0]["CusNum"]) ? 0 : lists.Rows[0]["CusNum"]);
                vTotalDelto = Convert.ToDecimal(Convert.IsDBNull(lists.Rows[0]["DeltoId"]) ? 0 : lists.Rows[0]["DeltoId"]);
                vTotalItems = Convert.ToDecimal(Convert.IsDBNull(lists.Rows[0]["UnitNumber"]) ? 0 : lists.Rows[0]["UnitNumber"]);
            }

            LblTotalCustomer.Text = $"♦ Total Customer = {vTotalCus}";
            LblTotalDelto.Text = $"♦ Total Delto = {vTotalDelto}";

        }

        private void MnuChangeCustomer_Click(object sender, EventArgs e)  // Not fix
        {

            this.Popmain.Close();
            if (DgvShow.Rows.Count <= 0) return;

            string vPlanning = "";
            if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
            {
                vPlanning = "";
            }
            else
            {
                vPlanning = CmbPlanningOrder.SelectedValue.ToString();
            }

            vDefaultIndex = DgvShow.CurrentRow.Index;
            string vCusNum = Convert.IsDBNull(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value) ? "".Trim() : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value.ToString().Trim();
            string vCusName = Convert.IsDBNull(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusName"].Value) ? "".Trim() : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusName"].Value.ToString().Trim();
            decimal vDeltoId = Convert.ToDecimal(Convert.IsDBNull(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["DeltoId"].Value) ? 0 : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["DeltoId"].Value);

            FrmDutchmillTakeOrderCustomer vFrm = new FrmDutchmillTakeOrderCustomer
            {
                vCusNum = vCusNum,
                vCusName = vCusName,
                vDepartment = vDepartment,
                vPlanning = vPlanning,
                vDeltoId = vDeltoId
            };

            if (vFrm.ShowDialog(this) == DialogResult.Cancel) return;

            CmbBillTo.SelectedIndex = -1;
            CmbDelto.SelectedIndex = -1;
            DisplayLoading.Enabled = true;
        }


        private bool CheckInfoCustomer()
        {
            bool isExisted = true;

            string query = $@"
    DECLARE @CusNum AS NVARCHAR(8) = '{CusNum}';
    SELECT [CusID],[CusNum],[CusName],[CusVat],[Terms],[Discount],[InvoiceDiscount],[CreditLimit],
           [CreditLimitAllow],[MaxMonthAllow],[ServiceRebate]
    FROM [Stock].[dbo].[TPRCustomer]
    WHERE [CusNum] = @CusNum;";

            var lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null && lists.Rows.Count > 0)
            {
                CusItemDis = lists.Rows[0]["Discount"] == DBNull.Value ? 0f : Convert.ToSingle(lists.Rows[0]["Discount"]);
                CusInvoiceDis = lists.Rows[0]["InvoiceDiscount"] == DBNull.Value ? 0f : Convert.ToSingle(lists.Rows[0]["InvoiceDiscount"]);
                CusVAT = lists.Rows[0]["CusVat"] == DBNull.Value ? "" : lists.Rows[0]["CusVat"].ToString().Trim();
                CusServiceRebate = lists.Rows[0]["ServiceRebate"] == DBNull.Value ? 0f : Convert.ToSingle(lists.Rows[0]["ServiceRebate"]);
                Terms = lists.Rows[0]["Terms"] == DBNull.Value ? 0 : Convert.ToInt32(lists.Rows[0]["Terms"]);
                CreditLimit = lists.Rows[0]["CreditLimit"] == DBNull.Value ? 0d : Convert.ToDouble(lists.Rows[0]["CreditLimit"]);
                MaxMonthAllow = lists.Rows[0]["MaxMonthAllow"] == DBNull.Value ? 0 : Convert.ToInt32(lists.Rows[0]["MaxMonthAllow"]);
                CreditLimitAllow = lists.Rows[0]["CreditLimitAllow"] == DBNull.Value ? 0d : Convert.ToDouble(lists.Rows[0]["CreditLimitAllow"]);
                isExisted = true;
            }
            else
            {
                isExisted = false;
            }

            return isExisted;

        }
        private float CusItemDis;
        private float CusInvoiceDis;
        private string CusVAT;
        private float CusServiceRebate;
        private int Terms;
        private double CreditLimit;
        private int MaxMonthAllow;
        private double CreditLimitAllow;



        private void CmbPlanningOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null) return;
            if (CmbPlanningOrder.Text.Trim().Equals("")) return;

            vDefaultIndex = -1;
            if (vDisplayList != null) vDisplayList = null;

            vDisplayList = new DataTable();
            vDisplayList.Columns.Add("Renew", typeof(bool));
            vDisplayList.Columns.Add("NotAccept", typeof(bool));
            vDisplayList.Columns.Add("ChangeQty", typeof(bool));
            vDisplayList.Columns.Add("Id", typeof(decimal));
            vDisplayList.Columns.Add("CusNum", typeof(string));
            vDisplayList.Columns.Add("CusName", typeof(string));
            vDisplayList.Columns.Add("DeltoId", typeof(decimal));
            vDisplayList.Columns.Add("Delto", typeof(string));
            vDisplayList.Columns.Add("Zone", typeof(string));
            vDisplayList.Columns.Add("UnitNumber", typeof(string));
            vDisplayList.Columns.Add("Barcode", typeof(string));
            vDisplayList.Columns.Add("CusCode", typeof(string));
            vDisplayList.Columns.Add("ProName", typeof(string));
            vDisplayList.Columns.Add("Size", typeof(string));
            vDisplayList.Columns.Add("QtyPerCase", typeof(int));
            vDisplayList.Columns.Add("PcsOrder", typeof(decimal));
            vDisplayList.Columns.Add("CTNOrder", typeof(decimal));
            vDisplayList.Columns.Add("TotalPcsOrder", typeof(decimal));
            vDisplayList.Columns.Add("SupNum", typeof(string));
            vDisplayList.Columns.Add("SupName", typeof(string));
            vDisplayList.Columns.Add("Department", typeof(string));
            vDisplayList.Columns.Add("PlanningOrder", typeof(string));
            vDisplayList.Columns.Add("MachineName", typeof(string));
            vDisplayList.Columns.Add("IPAddress", typeof(string));
            vDisplayList.Columns.Add("CreatedDate", typeof(DateTime));
            vDisplayList.Columns.Add("VerifyDate", typeof(DateTime));
            vDisplayList.Columns.Add("RequiredDate", typeof(DateTime));

            DgvShow.DataSource = vDisplayList;
            DgvShow.Refresh();
            //CmbBillTo.SelectedIndex = -1;
            //CmbDelto.SelectedIndex = -1;
            DisplayLoading.Enabled = true;

        }

        private void BillToLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            BillToLoading.Enabled = false;
            string distributorSelected = $"{this.warehouseName.id}";

            query = @"
    DECLARE @distributorId NVARCHAR(MAX) = N'{1}';

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

                SELECT [CusNum],[CusName]
                FROM [Stock].[dbo].[TPRCustomer]
                WHERE ([Status] = N'Activate') AND
                (
                    ([distributorUnderId] IN
                    (
                        SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
                    )
                    )
                    OR (CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)IN
                        (
                            SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
                        )
                        )
                )
                GROUP BY [CusNum],[CusName]
                ORDER BY [CusName];
";
            query = string.Format(query, DatabaseName, distributorSelected);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbBillTo, lists, "CusName", "CusNum");

            this.Cursor = Cursors.Default;

        }

        private void CmbBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                return;

            }
            if (CmbBillTo.Text.Trim().Equals("") == true)
            {
                return;
            }
            string CusNum = "";
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
            {
                CusNum = "";

            }
            else
            {
                if (CmbBillTo.Text.Trim() == "")
                {
                    CusNum = "";

                }
                else
                {
                    CusNum = CmbBillTo.SelectedValue.ToString();
                }
            }


            // Alert Customer Bad Payment 
            PCustomerRemark.Visible = false;
            Panel3.Enabled = true;
            query = @" DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                        SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate]
                        FROM [{0}].[dbo].[TblCustomerRemarkSetting]
                        WHERE ([CusNum] = @vCusNum) 
                        AND (([Status] = N'Both') OR ([Status] = N'Dutchmill'))
                        AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE()));                ";

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
                    TxtCustomerRemark.Text = string.Format("*សូមចំណាំ៖{1}{0}", vCustomerRemark, Environment.NewLine);
                    PCustomerRemark.Visible = true;
                    decimal vExpiry = (decimal)(vBlockDate.Date - Todate.Date).TotalDays;
                    if (vExpiry <= 0)
                    {
                        Panel3.Enabled = false;
                    }
                    else
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(5000);
                        PCustomerRemark.Visible = false;
                        TxtCustomerRemark.Text = "";
                    }
                }
            }

            DeltoLoading.Enabled = true;
            ItemLoading.Enabled = true;
            DisplayLoading.Enabled = true;

        }

        private void BtnRetrieveTakeOrder_Click_1(object sender, EventArgs e)
        {
            if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue is null)
            {
                MessageBox.Show("Please Select any planning order!", "Select Planning ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbPlanningOrder.Focus();
                return;
                //        ElseIf CmbBillTo.Text.Trim().Equals("") = True Then
                //    MessageBox.Show("Please select any bill to!", "Select Bill To", MessageBoxButtons.OK, MessageBoxIcon.Information)
                //    CmbBillTo.Focus()
                //    Exit Sub
                //ElseIf CmbDelto.Text.Trim().Equals("") = True Then
                //    MessageBox.Show("Please select any delto!", "Select Delto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                //    CmbDelto.Focus()
                //    Exit Sub
            }
            else
            {
                string vPlanning = "";
                if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
                {
                    vPlanning = string.Empty;
                }
                else
                {
                    if (CmbPlanningOrder.Text.Trim() == "")
                    {
                        vPlanning = "";
                    }
                    else
                    {

                        vPlanning = CmbPlanningOrder.SelectedValue.ToString();
                    }
                }
                string vCusNum = "";
                if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
                {
                    vCusNum = "";
                }
                else
                {
                    vCusNum = string.IsNullOrWhiteSpace(CmbBillTo.Text.Trim()) ? "" : CmbBillTo.SelectedValue.ToString();
                }

                decimal vDeltoId = 0;
                if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
                {
                    vDeltoId = 0;
                }
                else
                {
                    vDeltoId = string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()) ? 0 : Convert.ToDecimal(CmbDelto.SelectedValue);
                }

                query = @"
    DECLARE @vCusNum AS NVARCHAR(8) = N'{vCusNum}';
    DECLARE @vDeltoId AS DECIMAL(18,0) = {vDeltoId};
    DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{vPlanning}';
    DECLARE @vDepartment AS NVARCHAR(50) = N'{vDepartment}';
    
    WITH vTakeOrder AS (
    SELECT [TakeOrderNumber]
    FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrderFinish]
    WHERE ([Department] = @vDepartment)
    --AND ([CusNum] = @vCusNum) 
    --AND ([DeltoId] = @vDeltoId)
    AND ([PlanningOrder] = @vPlanningOrder))
    SELECT [PONumber] + ' ( ' + CONVERT(NVARCHAR,[DateRequired]) + ' ) ' AS [PONumber],[DateRequired]
    FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_Dutchmill] 
    WHERE [TakeOrderNumber] IN (SELECT vTakeOrder.TakeOrderNumber FROM vTakeOrder)
    GROUP BY [PONumber] + ' ( ' + CONVERT(NVARCHAR,[DateRequired]) + ' ) ', [DateRequired]
    ORDER BY [DateRequired] DESC;
";
                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
                DateTime vDateRequired = Todate;
                FrmDutchmillTakeOrderRetrieve vFrm = new FrmDutchmillTakeOrderRetrieve
                {
                    vDateRequired = vDateRequired,
                    vList = lists,
                    vCusNum = vCusNum,
                    vDeltoId = vDeltoId,
                    vPlanning = vPlanning,
                    vDepartment = vDepartment
                };

                if (vFrm.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }
                vDateRequired = vFrm.vDateRequired;
                query = @"DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                    DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                    DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';
                    DECLARE @vDateRequired AS DATE = N'{5:yyyy-MM-dd}';

                    UPDATE v
                    SET v.[PcsOrder] = x.PcsOrder
                    ,v.[CTNOrder] = x.CTNOrder
                    ,v.[TotalPcsOrder] = x.TotalPcsOrder
                    ,v.[Renew] = x.Renew
                    ,v.[NotAccept] = x.NotAccept
                    ,v.[ChangeQty] = x.ChangeQty
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] AS v
                    INNER JOIN [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrderFinish] AS x ON x.Barcode = v.Barcode AND x.CusNum = v.CusNum AND x.DeltoId = v.DeltoId AND x.Department = v.Department AND x.PlanningOrder = v.PlanningOrder
                    WHERE (x.[Department] = @vDepartment)
                    --AND (x.[CusNum] = @vCusNum) 
                    --AND (x.[DeltoId] = @vDeltoId)
                    AND (x.[PlanningOrder] = @vPlanningOrder)
                    AND (DATEDIFF(DAY,x.[DateRequired],@vDateRequired) = 0);
                    
                    INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrderRetrieve]([TakeOrderNumber],[DateOrd],[DateRequired],[PONumber],[CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate],[FinishDate],[RetrievedDate])
                    SELECT [TakeOrderNumber],[DateOrd],[DateRequired],[PONumber],[CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate],[FinishDate],GETDATE()
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrderFinish]
                    WHERE ([Department] = @vDepartment)
                    --AND ([CusNum] = @vCusNum) 
                    --AND ([DeltoId] = @vDeltoId)
                    AND ([PlanningOrder] = @vPlanningOrder)
                    AND (DATEDIFF(DAY,[DateRequired],@vDateRequired) = 0);

                    DELETE FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrderFinish]
                    WHERE ([Department] = @vDepartment)
                    --AND ([CusNum] = @vCusNum) 
                    --AND ([DeltoId] = @vDeltoId)
                    AND ([PlanningOrder] = @vPlanningOrder)
                    AND (DATEDIFF(DAY,[DateRequired],@vDateRequired) = 0);

                    INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_Deleted]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[DeletedDate])
                    SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],GETDATE()
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    WHERE ([Department] = @vDepartment)
                    --AND ([CusNum] = @vCusNum)
                    --AND ([DelToId] = @vDeltoId) 
                    AND (DATEDIFF(DAY,[DateRequired],@vDateRequired) = 0);

                    DELETE FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    WHERE ([Department] = @vDepartment)
                    --AND ([CusNum] = @vCusNum) 
                    --AND ([DelToId] = @vDeltoId) 
                    AND (DATEDIFF(DAY,[DateRequired],@vDateRequired) = 0);";

                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment, vDateRequired);

                return;
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {

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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    RTran.Rollback();
                    RCon.Close();
                    RCon.Open();
                    RCom.CommandType = CommandType.Text;
                    RCom.CommandText = "UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 0";
                    RCom.ExecuteNonQuery();
                    RCon.Close();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
        }

        private void DgvShow_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var row = DgvShow.Rows[e.RowIndex];
            if (Convert.ToBoolean(row.Cells["ManualRenew"].Value) == false && Convert.ToBoolean(row.Cells["ManualChangeQty"].Value) == false)
            {
                if (Convert.ToBoolean(row.Cells["ManualNotAccept"].Value) == true)
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            else
            {
                if (Convert.ToBoolean(row.Cells["ManualNotAccept"].Value) == true)
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            if (e.RowIndex % 2 == 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void DgvShow_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow vRow in DgvShow.Rows)
            {
                vRow.Cells["ManualRenew"].Value = Convert.ToBoolean(vRow.Cells["Renew"].Value);
                vRow.Cells["ManualNotAccept"].Value = Convert.ToBoolean(vRow.Cells["NotAccept"].Value);
                vRow.Cells["ManualChangeQty"].Value = Convert.ToBoolean(vRow.Cells["ChangeQty"].Value);
            }

        }

        private void DgvShow_MouseDown(object sender, MouseEventArgs e)
        {
            this.Popmain.Close();
            if (DgvShow.Rows.Count <= 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.Popmain.Show(DgvShow, new System.Drawing.Point(e.X, e.Y));
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //    private void BtnFinish_Click_1(object sender, EventArgs e)
        //    {
        //        if (CmbPlanningOrder.Text.Trim().Equals(""))
        //        {
        //            MessageBox.Show("Please select any planning order!", "Select Planning Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            CmbPlanningOrder.Focus();
        //            return;
        //        }
        //        else
        //        {
        //            string vPlanning = "";
        //            if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
        //            {
        //                vPlanning = "";
        //            }
        //            else
        //            {
        //                vPlanning = CmbPlanningOrder.Text.Trim() == "" ? "" : CmbPlanningOrder.SelectedValue.ToString();
        //            }

        //            query = @"
        //    DECLARE @vPlanning AS NVARCHAR(50) = N'{vPlanning}';
        //    DECLARE @vDepartment AS NVARCHAR(50) = N'{vDepartment}';
        //    SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate],
        //    CASE WHEN DATEDIFF(DAY,CONVERT(DATE,GETDATE()),CONVERT(DATE,[BlockDate])) <=0 THEN N'Block' ELSE N'' END [Status]
        //    FROM [{DatabaseName}].[dbo].[TblCustomerRemarkSetting]
        //    WHERE ([CusNum] IN (SELECT [CusNum] FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE ([Department] = @vDepartment) AND ([PlanningOrder] = @vPlanning) AND ([NotAccept] = 0) GROUP BY [CusNum])) 
        //    AND (([Status] = N'Both') OR ([Status] = N'Dutchmill'))
        //    AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE())); 
        //";
        //            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
        //            if (lists != null && lists.Rows.Count > 0)
        //            {
        //                FrmAlertBadPayment vF = new FrmAlertBadPayment();
        //                vF.DgvShow.DataSource = lists;
        //                vF.DgvShow.Refresh();
        //                var vResult = vF.ShowDialog();
        //                if (vResult == DialogResult.Cancel)
        //                {
        //                    return;
        //                }
        //                else if (vResult == DialogResult.No)
        //                {
        //                    query = @"
        //            DECLARE @vPlanning AS NVARCHAR(50) = N'{vPlanning}';
        //            DECLARE @vDepartment AS NVARCHAR(50) = N'{vDepartment}';
        //            WITH v AS (
        //                SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate],
        //                CASE WHEN DATEDIFF(DAY,CONVERT(DATE,GETDATE()),CONVERT(DATE,[BlockDate])) <=0 THEN N'Block' ELSE N'' END [Status]
        //                FROM [{DatabaseName}].[dbo].[TblCustomerRemarkSetting]
        //                WHERE ([CusNum] IN (SELECT [CusNum] FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE ([Department] = @vDepartment) AND ([PlanningOrder] = @vPlanning) AND ([NotAccept] = 0) GROUP BY [CusNum])) 
        //                AND (([Status] = N'Both') OR ([Status] = N'Dutchmill'))
        //                AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE()))
        //            )
        //            UPDATE o
        //            SET o.[NotAccept] = 1, o.[Renew] = 0, o.[ChangeQty] = 0
        //            FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] o
        //            WHERE (o.[Department] = @vDepartment) AND (o.[PlanningOrder] = @vPlanning) AND (o.[NotAccept] = 0)
        //            AND o.[CusNum] IN (SELECT v.[CusNum] FROM v);
        //        ";
        //                    Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));
        //                }
        //                else if (vResult == DialogResult.Yes)
        //                {
        //                    query = @"
        //            DECLARE @vPlanning AS NVARCHAR(50) = N'{vPlanning}';
        //            DECLARE @vDepartment AS NVARCHAR(50) = N'{vDepartment}';
        //            WITH v AS (
        //                SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate],
        //                CASE WHEN DATEDIFF(DAY,CONVERT(DATE,GETDATE()),CONVERT(DATE,[BlockDate])) <=0 THEN N'Block' ELSE N'' END [Status]
        //                FROM [{DatabaseName}].[dbo].[TblCustomerRemarkSetting]
        //                WHERE ([CusNum] IN (SELECT [CusNum] FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE ([Department] = @vDepartment) AND ([PlanningOrder] = @vPlanning) AND ([NotAccept] = 0) GROUP BY [CusNum])) 
        //                AND (([Status] = N'Both') OR ([Status] = N'Dutchmill'))
        //                AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE()))
        //            )
        //            UPDATE o
        //            SET o.[NotAccept] = 1, o.[Renew] = 0, o.[ChangeQty] = 0
        //            FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] o
        //            WHERE (o.[Department] = @vDepartment) AND (o.[PlanningOrder] = @vPlanning) AND (o.[NotAccept] = 0)
        //            AND o.[CusNum] IN (SELECT v.[CusNum] FROM v WHERE (v.[Status] = N'Block'));
        //        ";
        //                    Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));
        //                }
        //            }
        //        }

        //    }

        private void CmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = true;
            TxtQtyPerCase.Text = "";
            TxtPcsOrder.Text = "";
            TxtCTNOrder.Text = "";
            TxtTotalPcsOrder.Text = "";

            if (CmbProducts.Text.Trim() == "") return;
            if (CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue == null) return;

            string vBarcode = "";
            if (CmbProducts.SelectedValue is DataRowView || CmbProducts.SelectedValue == null)
            {
                vBarcode = "";
            }
            else
            {
                vBarcode = CmbProducts.Text.Trim() == "" ? "" : CmbProducts.SelectedValue.ToString();
            }

            query = @"
     DECLARE @Barcode AS NVARCHAR(MAX) = N'{1}';
                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],[SupNum],[SupName]
                FROM (
	                SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                FROM [Stock].[dbo].[TPRProducts]
	                WHERE (
                        ISNULL([ProNumY], '') = @Barcode
                        OR
                        (
                            (ISNULL([ProNumYP], N'') = N'')
                            AND (ISNULL([ProNumYP], N'') = @Barcode)
                        )
                        OR
                        (
                            (ISNULL([ProNumYC], N'') = N'')
                            AND (ISNULL([ProNumYC], '') = @Barcode)
                        )
                    )
	                UNION ALL
	                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName]
	                FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                WHERE B.[OldProNumy] = @Barcode
                    UNION ALL
                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[ProQtyPPack],[ProTotQty],[ProCurr],[ProImpPri],[ProDis],[ProVAT],[ProFinBuyin],[Average],[ProUPrSE],[ProUPriSeH],LEFT([Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING([Sup1],9,LEN([Sup1])))) AS [SupName]
	                FROM [Stock].[dbo].[TPRProductsDeactivated]
	                WHERE (
                        ISNULL([ProNumY], '') = @Barcode
                        OR
                        (
                            (ISNULL([ProNumYP], N'') = N'')
                            AND (ISNULL([ProNumYP], N'') = @Barcode)
                        )
                        OR
                        (
                            (ISNULL([ProNumYC], N'') = N'')
                            AND (ISNULL([ProNumYC], '') = @Barcode)
                        )
                    )
	                UNION ALL
	                SELECT B.[OldProNumy] AS [ProNumY],A.[ProNumYP],A.[ProNumYC],A.[ProName],A.[ProPacksize],A.[ProQtyPCase],A.[ProQtyPPack],B.[Stock] AS [ProTotQty],A.[ProCurr],A.[ProImpPri],A.[ProDis],A.[ProVAT],A.[ProFinBuyin],A.[Average],A.[ProUPrSE],A.[ProUPriSeH],LEFT(A.[Sup1],8) AS [SupNum],LTRIM(RTRIM(SUBSTRING(A.[Sup1],9,LEN(A.[Sup1])))) AS [SupName]
	                FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]
	                WHERE B.[OldProNumy] = @Barcode
                ) LISTS;
";
            query = string.Format(query, DatabaseName, vBarcode);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                TxtQtyPerCase.Text = Convert.ToInt32(DBNull.Value.Equals(lists.Rows[0]["ProQtyPCase"]) ? 1 : lists.Rows[0]["ProQtyPCase"]).ToString();
            }
            else
            {
                BtnAdd.Enabled = false;
                MessageBox.Show("The Item is wrong. Please check item again...", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void CmbProducts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;

            if ((e.KeyChar >= (char)Keys.A && e.KeyChar <= (char)Keys.Z) || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
            {
                if (CmbProducts.Text.Trim() != "" && !Information.IsNumeric(CmbProducts.Text.Trim())) e.Handled = true;
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else
            {
                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 15);
            }

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
                if (CmbProducts.Text.Trim() != "")
                {
                    ProductSearch(CmbProducts);
                }
            }

        }
        private void ProductSearch(ComboBox comboName)
        {
            string rBarcode = comboName.Text.Trim();
            if (rBarcode.Length > 13) rBarcode = rBarcode.Substring(0, 15).Trim();
            if (Information.IsNumeric(rBarcode.Trim())) rBarcode = string.Format("{0:0000000000000}", Convert.ToDouble(rBarcode));

            DataTable tableProducts = (DataTable)comboName.DataSource;
            bool vIsExisted = false;

            for (int i = 0; i < tableProducts.Rows.Count; i++)
            {
                string displayItem = tableProducts.Rows[i][comboName.DisplayMember].ToString();
                string valueItem = tableProducts.Rows[i][comboName.ValueMember].ToString();
                valueItem = valueItem.Substring(0, rBarcode.Length).Trim();

                if (valueItem.Equals(rBarcode))
                {
                    comboName.SelectedIndex = i;
                    vIsExisted = true;
                    break;
                }
            }

            if (vIsExisted)
            {
                TxtCTNOrder.Focus();
            }
            else
            {
                CmbProducts.Focus();
            }
        }

        private void TxtTotalPcsOrder_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPcsOrder_TextChanged(object sender, EventArgs e)
        {
            vTotalPcsOrder();
        }
        private void vTotalPcsOrder()
        {
            int vQtyPCase = string.IsNullOrWhiteSpace(TxtQtyPerCase.Text.Trim()) ? 1 : Convert.ToInt32(TxtQtyPerCase.Text.Trim());
            decimal vPcsOrder = string.IsNullOrWhiteSpace(TxtPcsOrder.Text.Trim()) ? 0 : Convert.ToDecimal(TxtPcsOrder.Text.Trim());
            decimal vCTNOrder = string.IsNullOrWhiteSpace(TxtCTNOrder.Text.Trim()) ? 0 : Convert.ToDecimal(TxtCTNOrder.Text.Trim());
            decimal vTotalPcsOrder = vPcsOrder + (vCTNOrder * vQtyPCase);
            TxtTotalPcsOrder.Text = string.Format("{0:N0}", vTotalPcsOrder);
        }

        private void TxtCTNOrder_TextChanged(object sender, EventArgs e)
        {
            vTotalPcsOrder();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (CmbPlanningOrder.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any planning order!", "Select Planning Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbPlanningOrder.Focus();
                return;
                //else if (CmbBillTo.Text.Trim().Equals("")) {
                //    MessageBox.Show("Please select any bill to!", "Select Bill To", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    CmbBillTo.Focus();
                //    return;
                //else if (CmbDelto.Text.Trim().Equals("")) {
                //    MessageBox.Show("Please select any delto!", "Select Delto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    CmbDelto.Focus();
                //    return;
            }
            else
            {

                string vPlanning = "";
                if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
                {
                    vPlanning = "";
                }
                else
                {
                    vPlanning = CmbPlanningOrder.Text.Trim() == "" ? "" : CmbPlanningOrder.SelectedValue.ToString();
                }

                query = @"
                     DECLARE @vPlanning AS NVARCHAR(50) = N'{1}';
                    DECLARE @vDepartment AS NVARCHAR(50) = N'{2}';
                    SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate],
                    CASE WHEN DATEDIFF(DAY,CONVERT(DATE,GETDATE()),CONVERT(DATE,[BlockDate])) <=0 THEN N'Block' ELSE N'' END [Status]
                    FROM [{0}].[dbo].[TblCustomerRemarkSetting]
                    WHERE ([CusNum] IN (SELECT [CusNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE ([Department] = @vDepartment) AND ([PlanningOrder] = @vPlanning) AND ([NotAccept] = 0) GROUP BY [CusNum])) 
                    AND (([Status] = N'Both') OR ([Status] = N'Dutchmill'))
                    AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE())); 
";
                query = string.Format(query, DatabaseName, vPlanning, vDepartment);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null && lists.Rows.Count > 0)
                {
                    FrmAlertBadPayment vF = new FrmAlertBadPayment();
                    vF.DgvShow.DataSource = lists;
                    vF.DgvShow.Refresh();
                    var vResult = vF.ShowDialog();
                    if (vResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (vResult == DialogResult.No)
                    {
                        query = @"
           DECLARE @vPlanning AS NVARCHAR(50) = N'{1}';
                            DECLARE @vDepartment AS NVARCHAR(50) = N'{2}';
                            WITH v AS (
                                SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate],
                                CASE WHEN DATEDIFF(DAY,CONVERT(DATE,GETDATE()),CONVERT(DATE,[BlockDate])) <=0 THEN N'Block' ELSE N'' END [Status]
                                FROM [{0}].[dbo].[TblCustomerRemarkSetting]
                                WHERE ([CusNum] IN (SELECT [CusNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE ([Department] = @vDepartment) AND ([PlanningOrder] = @vPlanning) AND ([NotAccept] = 0) GROUP BY [CusNum])) 
                                AND (([Status] = N'Both') OR ([Status] = N'Dutchmill'))
                                AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE()))
                            )
                            UPDATE o
                            SET o.[NotAccept] = 1, o.[Renew] = 0, o.[ChangeQty] = 0
                            FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] o
                            WHERE (o.[Department] = @vDepartment) AND (o.[PlanningOrder] = @vPlanning) AND (o.[NotAccept] = 0)
                            AND o.[CusNum] IN (SELECT v.[CusNum] FROM v);
        ";
                        query = string.Format(query, DatabaseName, vPlanning, vDepartment);
                        Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));
                    }
                    else if (vResult == DialogResult.Yes)
                    {
                        query = @"
           DECLARE @vPlanning AS NVARCHAR(50) = N'{1}';
                            DECLARE @vDepartment AS NVARCHAR(50) = N'{2}';
                            WITH v AS (
                                SELECT [Id],[CusNum],[CusName],[Remark],[AlertDate],[BlockDate],[CreatedDate],
                                CASE WHEN DATEDIFF(DAY,CONVERT(DATE,GETDATE()),CONVERT(DATE,[BlockDate])) <=0 THEN N'Block' ELSE N'' END [Status]
                                FROM [{0}].[dbo].[TblCustomerRemarkSetting]
                                WHERE ([CusNum] IN (SELECT [CusNum] FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] WHERE ([Department] = @vDepartment) AND ([PlanningOrder] = @vPlanning) AND ([NotAccept] = 0) GROUP BY [CusNum])) 
                                AND (([Status] = N'Both') OR ([Status] = N'Dutchmill'))
                                AND (CONVERT(DATE,[AlertDate]) <= CONVERT(DATE,GETDATE()))
                            )
                            UPDATE o
                            SET o.[NotAccept] = 1, o.[Renew] = 0, o.[ChangeQty] = 0
                            FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] o
                            WHERE (o.[Department] = @vDepartment) AND (o.[PlanningOrder] = @vPlanning) AND (o.[NotAccept] = 0)
                            AND o.[CusNum] IN (SELECT v.[CusNum] FROM v WHERE (v.[Status] = N'Block'));
        ";
                        query = string.Format(query, DatabaseName, vPlanning, vDepartment);
                        Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));
                    }
                }



                CmbPlanningOrder_SelectedIndexChanged(CmbPlanningOrder, e);
                vFilterNotRenew = false;

                vPlanning = "";
                if (CmbPlanningOrder.SelectedValue is DataRowView || CmbPlanningOrder.SelectedValue == null)
                {
                    vPlanning = "";
                }
                else
                {
                    vPlanning = CmbPlanningOrder.Text.Trim() == "" ? "" : CmbPlanningOrder.SelectedValue.ToString();
                }

                string vCusNum = "";
                if (CmbBillTo.SelectedValue is DataRowView || CmbBillTo.SelectedValue == null)
                {
                    vCusNum = "";
                }
                else
                {
                    vCusNum = CmbBillTo.Text.Trim() == "" ? "" : CmbBillTo.SelectedValue.ToString();
                }

                decimal vDeltoId = 0;
                if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
                {
                    vDeltoId = 0;
                }
                else
                {
                    vDeltoId = CmbDelto.Text.Trim() == "" ? 0 : Convert.ToDecimal(CmbDelto.SelectedValue);
                }

                string vMessage = "";
                query = @"
  DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                    DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                    DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';

                    SELECT [Renew],[NotAccept],[ChangeQty],[Id],[CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate],[RequiredDate]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                    WHERE ([Department] = @vDepartment)
                    --AND ([CusNum] = @vCusNum) 
                    --AND ([DeltoId] = @vDeltoId)
                    AND ([PlanningOrder] = @vPlanningOrder)
                    AND (ISNULL([Renew],0) = 0)
                    AND (ISNULL([NotAccept],0) = 0)
                    AND (ISNULL([ChangeQty],0) = 0)
                    ORDER BY [CusName],[Size],[ProName];
";
                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment);
                lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
                if (lists != null)
                {

                    foreach (DataRow r in lists.Rows)
                    {
                        vMessage += $"► {(r["Barcode"] == DBNull.Value ? "" : r["Barcode"].ToString().Trim())} = " +
                                    $"{(r["TotalPcsOrder"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TotalPcsOrder"]))} Pcs\n";
                    }
                    Console.WriteLine(vMessage);
                }

                if (!string.IsNullOrWhiteSpace(vMessage))
                {
                    vMessage = "Please renew the items:\n" + vMessage;
                    MessageBox.Show(vMessage, "Need Renew Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vFilterNotRenew = true;
                    DisplayLoading.Enabled = true;
                    return;
                }


                if (MessageBox.Show("Are you sure, you already to renew the items?(Yes/No)", "Confirm Renew", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
                decimal vTakeOrderNumber = 0;
                DateTime vDateOrder = DateTime.Today;
                DateTime vRequiredDate = DateTime.Today;
                string vPONumber = "";
                FrmDutchmillTakeOrderPONumber vFrm = new FrmDutchmillTakeOrderPONumber { vDateOrder = vDateOrder, vRequiredDate = vRequiredDate, vPONumber = vPONumber };
                if (vFrm.ShowDialog(this) == DialogResult.Cancel) return;

                vDateOrder = vFrm.vDateOrder;
                vRequiredDate = vFrm.vRequiredDate;
                vPONumber = vFrm.vPONumber;

                // Check Invoice Number
                long vInvNo = 0;
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                RCom.CommandText = string.Format("SELECT * FROM [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo]", DatabaseName);
                lists = new DataTable();
                lists.Load(RCom.ExecuteReader());
                if (lists != null && lists.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(DBNull.Value.Equals(lists.Rows[0]["IsBusy"]) ? 0 : lists.Rows[0]["IsBusy"]) == true)
                    {
                        RCon.Close();
                        MessageBox.Show("Printer is busy!\nPlease wait a few minutes...\nAnother PC is using...", "Printer Is Busy - Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        vInvNo = Convert.ToInt64(DBNull.Value.Equals(lists.Rows[0]["PrintInvNo"]) ? 0 : lists.Rows[0]["PrintInvNo"]);
                        RCom.CommandText = string.Format("UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 1", DatabaseName);
                        RCom.ExecuteNonQuery();
                    }
                }
                else
                {
                    RCom.CommandText = string.Format("INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo]([PrintInvNo],[IsBusy]) VALUES(0,0)", DatabaseName);
                    RCom.ExecuteNonQuery();
                    vInvNo = 0;
                }
                RCon.Close();
                vInvNo += 1;
                vTakeOrderNumber = vInvNo;


                query = @"
   DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                    DECLARE @vPlanningOrder AS NVARCHAR(50) = N'{3}';
                    DECLARE @vDepartment AS NVARCHAR(50) = N'{4}';
                    DECLARE @vTakeOrderNumber AS NVARCHAR(25) = N'{5}';
                    DECLARE @vDateOrder AS DATE = N'{6:yyyy-MM-dd}';
                    DECLARE @vRequiredDate AS DATE = N'{7:yyyy-MM-dd}';
                    DECLARE @vPONumber AS NVARCHAR(50) = N'{8}';

                    INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrderFinish]([TakeOrderNumber],[DateOrd],[DateRequired],[PONumber],[CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate],[FinishDate])
                    SELECT @vTakeOrderNumber,@vDateOrder,@vRequiredDate,@vPONumber,[CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],[IPAddress],[CreatedDate],[VerifyDate],GETDATE()
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                    WHERE ([Department] = @vDepartment)
                    --AND ([CusNum] = @vCusNum) 
                    --AND ([DeltoId] = @vDeltoId)
                    AND ((ISNULL([Renew],0) = 1) OR (ISNULL([ChangeQty],0) = 1))
                    AND (ISNULL([NotAccept],0) = 0)
                    AND ([PlanningOrder] = @vPlanningOrder);

                    INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate])
                    SELECT [CusNum],[CusName],[DeltoId],[Delto],@vDateOrder,@vRequiredDate,[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],NULL,NULL,0,[PcsOrder],0,[CTNOrder],[TotalPcsOrder],@vPONumber,[MachineName],@vTakeOrderNumber,[PlanningOrder],0,[Department],[IPAddress],GETDATE()
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
                    WHERE ([Department] = @vDepartment)
                    --AND ([CusNum] = @vCusNum) 
                    --AND ([DeltoId] = @vDeltoId)
                    AND ((ISNULL([Renew],0) = 1) OR (ISNULL([ChangeQty],0) = 1))
                    AND (ISNULL([NotAccept],0) = 0)
                    AND ([PlanningOrder] = @vPlanningOrder);

                    UPDATE v
                    SET v.Renew = 0, v.ChangeQty = 0, v.RequiredDate = @vRequiredDate
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] AS v
                    WHERE (v.[Department] = @vDepartment)
                    --AND (v.[CusNum] = @vCusNum)
                    --AND (v.[DeltoId] = @vDeltoId)
                    AND ((ISNULL([Renew],0) = 1) OR (ISNULL([ChangeQty],0) = 1))
                    AND (ISNULL([NotAccept],0) = 0)
                    AND (v.[PlanningOrder] = @vPlanningOrder);
";
                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vPlanning, vDepartment, vTakeOrderNumber, vDateOrder, vRequiredDate, vPONumber);
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
                    RCom.CommandText = $"UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 0,[PrintInvNo] = {vInvNo};";
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    MessageBox.Show("Processing Take Order has been completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vFilterNotRenew = false;
                    vDefaultIndex = 0;
                    DisplayLoading.Enabled = true;
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    RTran.Rollback();
                    RCon.Close();
                    RCon.Open();
                    RCom.CommandType = CommandType.Text;
                    RCom.CommandText = "UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 0";
                    RCom.ExecuteNonQuery();
                    RCon.Close();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
        }

        private bool CheckBankGaranteeCustomer()
        {
            bool isExpiry = false;
            DateTime dateExpiry;
            DateTime dateAlert;
            DateTime curDate;
            bool isAlertForm = false;
            string msg = "";
            string title = "";

            string query = $@"
    DECLARE @CusNum AS NVARCHAR(8) = '{CusNum}';
    SELECT [CreditLimit], [Expiry], [AlertDate], GETDATE() AS [CurDate]
    FROM [Stock].[dbo].[TPRCustomerBankGarantee]
    WHERE [CusId] = @CusNum
    ORDER BY [Expiry];";

            var lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null && lists.Rows.Count > 0)
            {
                foreach (DataRow r in lists.Rows)
                {
                    dateExpiry = r["Expiry"] == DBNull.Value ? Todate : Convert.ToDateTime(r["Expiry"]);
                    dateAlert = r["AlertDate"] == DBNull.Value ? Todate : Convert.ToDateTime(r["AlertDate"]);
                    curDate = r["CurDate"] == DBNull.Value ? Todate : Convert.ToDateTime(r["CurDate"]);

                    if ((curDate - dateExpiry).Days >= 0)
                    {
                        msg = "The customer bank guarantee expiry reaches.\nNot allowed to continue!";
                        title = "Expiry Reaches";
                        isExpiry = true;
                        isAlertForm = true;
                    }
                    else if ((curDate - dateAlert).Days >= 0)
                    {
                        msg = $"{(dateExpiry - curDate).Days} day(s) left for customer bank guarantee expiry.\nPlease inform the administrator.";
                        title = "Near Expiry";
                        isAlertForm = true;
                    }
                }
            }

            if (isAlertForm)
            {
                FrmAlertBankGarantee FrmAlertBankGarantee = new FrmAlertBankGarantee();
                FrmAlertBankGarantee.Text = title;
                FrmAlertBankGarantee.LblMsg.Text = msg;
                FrmAlertBankGarantee.DgvShow.DataSource = lists;
                FrmAlertBankGarantee.DgvShow.Refresh();
                FrmAlertBankGarantee.ShowDialog();
            }

            return isExpiry;

        }

        private void DgvShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (DgvShow.RowCount <= 0) return;

            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to delete all selected items? (Yes/No)",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                string vId = "";

                foreach (DataGridViewRow r in DgvShow.Rows)
                {
                    if (r.Selected)
                    {
                        vId += $"{(r.Cells["Id"].Value == DBNull.Value ? 0 : Convert.ToDecimal(r.Cells["Id"].Value))},";
                    }
                }

                if (string.IsNullOrWhiteSpace(vId))
                {
                    vId = "0";
                }
                else
                {
                    vId = vId.TrimEnd(',');
                }

                vDefaultIndex = 0;

                string query = $@"
        INSERT INTO [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder_Deleting]
        ([CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],[CTNOrder],
        [TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],[MachineName],
        [IPAddress],[CreatedDate],[VerifyDate],[DeletedDate])
        SELECT [CusNum],[CusName],[DeltoId],[Delto],[UnitNumber],[Barcode],[ProName],[Size],[QtyPerCase],[PcsOrder],
        [CTNOrder],[TotalPcsOrder],[SupNum],[SupName],[Renew],[NotAccept],[ChangeQty],[Department],[PlanningOrder],
        [MachineName],[IPAddress],[CreatedDate],[VerifyDate], GETDATE()
        FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
        WHERE [Id] IN ({vId});

        DELETE FROM [{DatabaseName}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
        WHERE [Id] IN ({vId});
    ";

                using (SqlConnection RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
                {
                    RCon.Open();
                    SqlTransaction RTran = RCon.BeginTransaction();

                    try
                    {
                        using (SqlCommand RCom = new SqlCommand(query, RCon, RTran))
                        {
                            RCom.CommandType = CommandType.Text;
                            RCom.ExecuteNonQuery();
                        }

                        RTran.Commit();
                        DisplayLoading.Enabled = true;
                    }
                    catch (SqlException ex)
                    {
                        RTran.Rollback();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        RTran.Rollback();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        RCon.Close();
                    }
                }
            }

        }

        private void TxtPcsOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                TxtCTNOrder.Focus();
            }
            else if (e.KeyCode == Keys.Return)
            {
                BtnAdd_Click(BtnAdd, new System.EventArgs());
            }
        }

        private void FrmDutchmillTakeOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void FrmDutchmillTakeOrder_Paint(object sender, PaintEventArgs e)
        {
            this.PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_DatabaseName;
        }

        private void TxtPcsOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 6);

        }

        private void TxtCTNOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            decimal vQtyPCase = string.IsNullOrWhiteSpace(TxtQtyPerCase.Text.Trim()) ? 1 : Convert.ToDecimal(TxtQtyPerCase.Text.Trim());

            if (vQtyPCase % 2 == 0)
            {
                string[] vStr = TxtCTNOrder.Text.Trim().Split('.');

                if (vStr.Length > 1)
                {
                    if (vStr[1].Trim().Length >= 2)
                        e.Handled = true;
                }

                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Float, null, 6);
            }
            else
            {
                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 6);
            }

        }

        private void TxtCTNOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                BtnAdd.Focus();
            }
            else if (e.KeyCode == Keys.Return)
            {
                BtnAdd_Click(BtnAdd, new EventArgs());
            }

        }

        private void CmbProducts_TextChanged(object sender, EventArgs e)
        {
            DisplayLoading.Enabled = true;
        }

        private void CmbDelto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                decimal vDeltoId = 0;

                if (decimal.TryParse(string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()) ? "0" : CmbDelto.Text.Trim(), out vDeltoId))
                {
                    CmbDelto.SelectedValue = vDeltoId;
                    if (string.IsNullOrWhiteSpace(CmbDelto.Text.Trim()))
                    {
                        CmbDelto.Text = vDeltoId.ToString();
                    }
                }
            }

        }
    }
}
