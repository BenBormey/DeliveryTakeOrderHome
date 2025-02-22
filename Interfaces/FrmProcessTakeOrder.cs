using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DeliveryTakeOrder.Dev;
using DeliveryTakeOrder.Interfaces.preview;
using DeliveryTakeOrder.Reports;
using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmProcessTakeOrder : Form
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
        private System.Windows.Forms.CheckBox vCheckBox;
        private MDI menuMdi;

        public FrmProcessTakeOrder(MDI menuMdi)
        {
            this.menuMdi = menuMdi;
            InitializeComponent();
            this.LoadingInitialized();
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.RequiredDateLoading.Enabled = true;
            this.DrawCheckBoxInDataGridView();

        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }


        private void DrawCheckBoxInDataGridView()
        {
            Rectangle rect = DgvShow.GetCellDisplayRectangle(1, -1, true);
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 10);

            System.Windows.Forms.CheckBox vCheckBox = new System.Windows.Forms.CheckBox
            {
                BackColor = Color.Transparent,
                Name = "Checker",
                Size = new Size(18, 18),
                Location = rect.Location
            };

            vCheckBox.CheckedChanged += new EventHandler(vCheckBox_CheckedChanged);
            DgvShow.Controls.Remove(vCheckBox);
            DgvShow.Controls.Add(vCheckBox);
        }

        private void vCheckBox_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            System.Windows.Forms.CheckBox headerBox = (System.Windows.Forms.CheckBox)DgvShow.Controls.Find("Checker", true)[0];
            int vSelected = 0;
            string vCusVAT = "";
            Boolean vCheckVAT = false;
            Boolean vSpecial = false;
            Boolean lOnePOOneInvoice = false;

            string lSql = "";
            lSql = @"DECLARE @CusNum AS NVARCHAR(8) = N'{1}';
                    SELECT [Id],[CusNum],[CusName],[CreatedDate]
                    FROM [{0}].[dbo].[TblCustomerSetting_SpecialInvoices]
                    WHERE [CusNum] = @CusNum;";

            lSql = string.Format(lSql, DatabaseName, DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value);
            lists = Data.Selects(lSql, Initialized.GetConnectionType(Data, App));
            if (lists is null)
            {
                if (lists.Rows.Count > 0)
                {
                    vSpecial = true;
                }
            }

            lSql = @"DECLARE @lCusNum AS NVARCHAR(8) = N'{1}';
SELECT [lc].[CusVat],
       CASE
           WHEN ISNULL([ll].[CusNum], N'') = N'' THEN
               0
           ELSE
               1
       END [lOnePOOneInvoice]
FROM [Stock].[dbo].[TPRCustomer] lc
    LEFT OUTER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblSetCustomerIntoDivisionVAT] ll
        ON ([ll].[CusNum] = [lc].[CusNum])
WHERE [lc].[CusNum] = @lCusNum;";

            lSql = string.Format(lSql, DatabaseName, DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value);
            lists = Data.Selects(lSql, Initialized.GetConnectionType(Data, App));
            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {
                    vCusVAT = DBNull.Value.Equals(lists.Rows[0]["CusVat"]) ? "" : lists.Rows[0]["CusVat"].ToString().Trim();
                    lOnePOOneInvoice = DBNull.Value.Equals(lists.Rows[0]["lOnePOOneInvoice"]) ? false : Convert.ToBoolean(lists.Rows[0]["lOnePOOneInvoice"]);

                }
            }
            foreach (DataGridViewRow row in DgvShow.Rows)
            {
                row.Cells["Tick"].Value = headerBox.Checked;
                if (Convert.ToBoolean(row.Cells["Tick"].Value) == true)
                {
                    vSelected += 1;

                }
                if (vSelected >= 21 && vSpecial == false && lOnePOOneInvoice == false)
                {
                    return;

                }
            }




        }


        private void TimerDisplayLoading_Tick(object sender, EventArgs e)
        {

        }



        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void FrmProcessTakeOrder_Load(object sender, EventArgs e)
        {

        }

        private void MnuChangeCustomer_Click(object sender, EventArgs e)
        {
            this.Popmenu.Close();
            if (DgvShow.RowCount <= 0) return;

            var currentRow = DgvShow.Rows[DgvShow.CurrentRow.Index];
            decimal vTakeOrder = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["TakeOrderNumber"].Value) ? 0 : currentRow.Cells["TakeOrderNumber"].Value);
            decimal vDeltoId = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["DelToId"].Value) ? 0 : currentRow.Cells["DelToId"].Value);
            string vCusNum = DBNull.Value.Equals(currentRow.Cells["CusNum"].Value) ? "" : currentRow.Cells["CusNum"].Value.ToString().Trim();
            string vCusName = DBNull.Value.Equals(currentRow.Cells["CusName"].Value) ? "" : currentRow.Cells["CusName"].Value.ToString().Trim();

            FrmProcessTakeOrderCustomer Frm = new FrmProcessTakeOrderCustomer
            {
                vTakeOrder = vTakeOrder,
                vCusNum = vCusNum,
                vCusName = vCusName,
                vDeltoId = vDeltoId
            };

            if (Frm.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel) return;

            TimerDisplayLoading.Enabled = true;

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MnuChangeDelto_Click(object sender, EventArgs e)
        {
            this.Popmenu.Close();
            if (DgvShow.RowCount <= 0) return;

            var currentRow = DgvShow.Rows[DgvShow.CurrentRow.Index];
            decimal vTakeOrder = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["TakeOrderNumber"].Value) ? 0 : currentRow.Cells["TakeOrderNumber"].Value);
            string vCusNum = DBNull.Value.Equals(currentRow.Cells["CusNum"].Value) ? "" : currentRow.Cells["CusNum"].Value.ToString().Trim();
            string vDeltoId = DBNull.Value.Equals(currentRow.Cells["DelToId"].Value) ? "" : currentRow.Cells["DelToId"].Value.ToString().Trim();
            string vDeltoName = DBNull.Value.Equals(currentRow.Cells["DelTo"].Value) ? "" : currentRow.Cells["DelTo"].Value.ToString().Trim();

            FrmProcessTakeOrderDelto Frm = new FrmProcessTakeOrderDelto
            {
                vTakeOrder = vTakeOrder,
                vDeltoId = vDeltoId,
                vDeltoName = vDeltoName,
                vCusNum = vCusNum
            };

            if (Frm.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel) return;

            TimerDisplayLoading.Enabled = true;

        }

        private void MnuChangeQtyOrder_Click(object sender, EventArgs e)
        {
            this.Popmenu.Close();
            if (DgvShow.RowCount <= 0) return;

            var currentRow = DgvShow.Rows[DgvShow.CurrentRow.Index];
            decimal vTakeOrder = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["TakeOrderNumber"].Value) ? 0 : currentRow.Cells["TakeOrderNumber"].Value);
            decimal vId = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["Id"].Value) ? 0 : currentRow.Cells["Id"].Value);
            string vBarcode = DBNull.Value.Equals(currentRow.Cells["Barcode"].Value) ? "" : currentRow.Cells["Barcode"].Value.ToString().Trim();
            string vProName = DBNull.Value.Equals(currentRow.Cells["ProName"].Value) ? "" : currentRow.Cells["ProName"].Value.ToString().Trim();
            string vSize = DBNull.Value.Equals(currentRow.Cells["Size"].Value) ? "" : currentRow.Cells["Size"].Value.ToString().Trim();
            int vQtyPerCase = Convert.ToInt32(DBNull.Value.Equals(currentRow.Cells["QtyPCase"].Value) ? 1 : currentRow.Cells["QtyPCase"].Value);
            decimal vPcsOrder = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["PcsOrder"].Value) ? 0 : currentRow.Cells["PcsOrder"].Value);
            decimal vPackOrder = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["PackOrder"].Value) ? 0 : currentRow.Cells["PackOrder"].Value);
            decimal vCTNOrder = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["CTNOrder"].Value) ? 0 : currentRow.Cells["CTNOrder"].Value);

            FrmProcessTakeOrderQtyOrder Frm = new FrmProcessTakeOrderQtyOrder
            {
                vTakeOrder = vTakeOrder,
                vBarcode = vBarcode,
                vProName = vProName,
                vSize = vSize,
                vQtyPerCase = vQtyPerCase,
                vPcsOrder = vPcsOrder,
                vPackOrder = vPackOrder,
                vCTNOrder = vCTNOrder,
                vId = vId
            };

            if (Frm.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel) return;

            TimerDisplayLoading.Enabled = true;

        }

        private void TimerCustomerLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerCustomerLoading.Enabled = false;
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            DateTime vRequiredDate = Todate;

            if (CmbRequiredDate.SelectedValue is DataRowView || CmbRequiredDate.SelectedValue == null)
            {
                vRequiredDate = Todate;
            }
            else
            {
                if (CmbRequiredDate.Text.Trim().Equals(""))
                {
                    vRequiredDate = Todate;
                }
                else
                {
                    vRequiredDate = (DateTime)CmbRequiredDate.SelectedValue;
                }
            }

            query = @"
 DECLARE @vRequiredDate AS DATE = N'{1:yyyy-MM-dd}';
                SELECT [CusNum],[CusName],[Customer]
                FROM (
                    --SELECT 0 AS [Index], N'CUS00000' AS [CusNum],N'All Customers' AS [CusName],N'All Customers' AS [Customer]
                    --UNION ALL
                    SELECT 1 AS [Index], [CusNum],[CusName],ISNULL([CusNum],'') + SPACE(3) + ISNULL([CusName],'') AS [Customer]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    WHERE (CONVERT(DATE,[DateRequired]) = @vRequiredDate)
                    GROUP BY [CusNum],[CusName],ISNULL([CusNum],'') + SPACE(3) + ISNULL([CusName],'')
                ) LISTS
                ORDER BY [Index],[CusName];
";
            query = string.Format(query, DatabaseName, vRequiredDate);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbCustomer, lists, "CusName", "CusNum");
            this.Cursor = Cursors.Default;

        }

        private void TimerTakeOrderLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerTakeOrderLoading.Enabled = false;
            CmbTakeOrderNo.DataSource = null;
            string CusNum = "";

            if (CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (CmbCustomer.Text.Trim().Equals(""))
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = CmbCustomer.SelectedValue.ToString();
                }
            }

            decimal vDeltoId = 0;

            if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
            {
                vDeltoId = 0;
            }
            else
            {
                if (CmbDelto.Text.Trim().Equals(""))
                {
                    vDeltoId = 0;
                }
                else
                {
                    vDeltoId = Convert.ToDecimal(CmbDelto.SelectedValue);
                }
            }

            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            DateTime vRequiredDate = Todate;

            if (CmbRequiredDate.SelectedValue is DataRowView || CmbRequiredDate.SelectedValue == null)
            {
                vRequiredDate = Todate;
            }
            else
            {
                if (CmbRequiredDate.Text.Trim().Equals(""))
                {
                    vRequiredDate = Todate;
                }
                else
                {
                    vRequiredDate = (DateTime)CmbRequiredDate.SelectedValue;
                }
            }

            query = @"  DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                    DECLARE @vDateRequired AS DATE = N'{3:yyyy-MM-dd}';
                    SELECT [TakeOrderNumber]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    WHERE ([CusNum] = @vCusNum OR N'CUS00000' = @vCusNum) 
                    AND ([DelToId] = @vDeltoId OR 0 = @vDeltoId)
                    AND (DATEDIFF(DAY,[DateRequired],@vDateRequired) = 0 OR DATEDIFF(DAY,GETDATE(),@vDateRequired) = 0)
                    GROUP BY [TakeOrderNumber]
                    ORDER BY [TakeOrderNumber];";

            query = string.Format(query, DatabaseName, CusNum, vDeltoId, vRequiredDate);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbTakeOrderNo, lists, "TakeOrderNumber", "TakeOrderNumber");
            this.Cursor = Cursors.Default;
        }

        private void DeltoLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DeltoLoading.Enabled = false;
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            DateTime vRequiredDate = Todate;

            if (CmbRequiredDate.SelectedValue is DataRowView || CmbRequiredDate.SelectedValue == null)
            {
                vRequiredDate = Todate;
            }
            else
            {
                if (CmbRequiredDate.Text.Trim().Equals(""))
                {
                    vRequiredDate = Todate;
                }
                else
                {
                    vRequiredDate = (DateTime)CmbRequiredDate.SelectedValue;
                }
            }

            string CusNum = "";

            if (CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (CmbCustomer.Text.Trim().Equals(""))
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = CmbCustomer.SelectedValue.ToString();
                }
            }

            query = @"
    UPDATE v
                        SET v.[DelTo] = o.[DelTo]
                        FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS v
                        INNER JOIN [Stock].[dbo].[TPRDelto] AS o ON o.DefId = v.[DeltoId];

                        UPDATE v
                        SET v.[DelTo] = o.[DelTo]
                        FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] AS v
                        INNER JOIN [Stock].[dbo].[TPRDelto] AS o ON o.DefId = v.[DeltoId];

                        DECLARE @vRequiredDate AS DATE = N'{1:yyyy-MM-dd}';
                        DECLARE @vCusNum AS NVARCHAR(8) = N'{2}';
                        SELECT [DelToId],[DelTo]
                        FROM (
                            SELECT 1 AS [Index], [DelToId],[DelTo]
                            FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                            WHERE (CONVERT(DATE,[DateRequired]) = @vRequiredDate) AND ([CusNum] = @vCusNum OR N'CUS00000' = @vCusNum)
                            GROUP BY [DelToId],[DelTo]
                        ) LISTS
                        ORDER BY [Index],[DelTo];
";
            query = string.Format(query, DatabaseName, vRequiredDate, CusNum);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbDelto, lists, "DelTo", "DelToId");
            this.Cursor = Cursors.Default;

        }

        private void RequiredDateLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RequiredDateLoading.Enabled = false;
            string CusNum = "";

            if (CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (CmbCustomer.Text.Trim().Equals(""))
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = CmbCustomer.SelectedValue.ToString();
                }
            }

            decimal vDeltoId = 0;

            if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null)
            {
                vDeltoId = 0;
            }
            else
            {
                if (CmbDelto.Text.Trim().Equals(""))
                {
                    vDeltoId = 0;
                }
                else
                {
                    vDeltoId = Convert.ToDecimal(CmbDelto.SelectedValue);
                }
            }

            query = @"
 DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                SELECT [DateRequired]
                FROM (
                    SELECT [DateRequired]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    --WHERE ([CusNum] = @vCusNum OR N'CUS00000' = @vCusNum) AND ([DelToId] = @vDeltoId OR 0 = @vDeltoId)
                    GROUP BY [DateRequired]
                ) LISTS
                ORDER BY [DateRequired];
";
            query = string.Format(query, DatabaseName, CusNum, vDeltoId);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbRequiredDate, lists, "DateRequired", "DateRequired");
            this.Cursor = Cursors.Default;

        }

        private void CmbDelto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDelto.SelectedValue is DataRowView || CmbDelto.SelectedValue == null) return;
            if (CmbDelto.Text.Trim().Equals("")) return;
            //RequiredDateLoading.Enabled = true;
            //TimerTakeOrderLoading.Enabled = true;
            TimerDisplayLoading.Enabled = true;

        }

        private void CmbRequiredDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbRequiredDate.SelectedValue is DataRowView || CmbRequiredDate.SelectedValue == null) return;
            if (CmbRequiredDate.Text.Trim().Equals("")) return;
            TimerCustomerLoading.Enabled = true;
            TimerDisplayLoading.Enabled = true;

        }

        private void CmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null) return;
            if (CmbCustomer.Text.Trim().Equals("")) return;
            //Initialized.R_AllUnpaid = true;
            //if (CmbCustomer.SelectedValue.Equals("CUS00000"))
            //{
            //    FrmPODutchmillSelected Frm = new FrmPODutchmillSelected();
            //    if (Frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            //}
            DeltoLoading.Enabled = true;
            TimerDisplayLoading.Enabled = true;

        }

        private void CmbTakeOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTakeOrderNo.SelectedValue is DataRowView || CmbTakeOrderNo.SelectedValue == null) return;
            if (CmbTakeOrderNo.Text.Trim().Equals("")) return;
            TimerDisplayLoading.Enabled = true;

        }

        private void TimerDisplayLoading_Tick_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.TimerDisplayLoading.Enabled = false;
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            DateTime vRequiredDate = Todate;

            if (this.CmbRequiredDate.SelectedValue is DataRowView || this.CmbRequiredDate.SelectedValue == null)
            {
                vRequiredDate = Todate;
            }
            else
            {
                if (this.CmbRequiredDate.Text.Trim().Equals(""))
                {
                    vRequiredDate = Todate;
                }
                else
                {
                    vRequiredDate = (DateTime)this.CmbRequiredDate.SelectedValue;
                }
            }

            string CusNum = "";

            if (this.CmbCustomer.SelectedValue is DataRowView || this.CmbCustomer.SelectedValue == null)
            {
                CusNum = "";
            }
            else
            {
                if (this.CmbCustomer.Text.Trim().Equals(""))
                {
                    CusNum = "";
                }
                else
                {
                    CusNum = this.CmbCustomer.SelectedValue.ToString();
                }
            }

            decimal vDeltoId = 0;

            if (this.CmbDelto.SelectedValue is DataRowView || this.CmbDelto.SelectedValue == null)
            {
                vDeltoId = 0;
            }
            else
            {
                if (this.CmbDelto.Text.Trim().Equals(""))
                {
                    vDeltoId = 0;
                }
                else
                {
                    vDeltoId = Convert.ToDecimal(this.CmbDelto.SelectedValue);
                }
            }

            decimal TakeOrderNo = 0;

            if (this.CmbTakeOrderNo.SelectedValue is DataRowView || this.CmbTakeOrderNo.SelectedValue == null)
            {
                TakeOrderNo = 0;
            }
            else
            {
                if (this.CmbTakeOrderNo.Text.Trim().Equals(""))
                {
                    TakeOrderNo = 0;
                }
                else
                {
                    TakeOrderNo = Convert.ToDecimal(this.CmbTakeOrderNo.SelectedValue);
                }
            }

            if ((CusNum.Trim().Equals("") == false) && (vDeltoId != 0))
            {
                query = @"DECLARE @RC INT;
DECLARE @lRequiredDate DATE = N'{1:yyyy-MM-dd}';
DECLARE @lCusNum NVARCHAR(8) = N'{2}';
DECLARE @lDeltoId DECIMAL(18, 0) = {3};
DECLARE @lIsWSPrice BIT = {8};
EXECUTE @RC = [DBPickers].[dbo].[calculatedTakeOrderDutchmillProcess] @lRequiredDate,
                                                                      @lCusNum,
                                                                      @lDeltoId,
                                                                      @lIsWSPrice;";
            }
            else
            {
                query = @"DECLARE @RC INT;
DECLARE @lRequiredDate DATE = N'{1:yyyy-MM-dd}';
DECLARE @lCusNum NVARCHAR(8) = N'{2}';
DECLARE @lDeltoId DECIMAL(18, 0) = {3};
DECLARE @lTakeOrderNo DECIMAL(18, 0) = {4};
EXECUTE @RC = [DBPickers].[dbo].[getTakeOrderDutchmillProcess] @lRequiredDate,
                                                               @lCusNum,
                                                               @lDeltoId,
                                                               @lTakeOrderNo;";
            }
            query = string.Format(query, DatabaseName, vRequiredDate, CusNum, vDeltoId, TakeOrderNo, Initialized.R_AllUnpaid ? 0 : 1, Initialized.R_DateFrom, Initialized.R_DateTo, this.chkshowprice.Checked ? 1 : 0);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row: {0:N0}", DgvShow.Rows.Count);
            int CountR;
            CountR = 0;

            while (CountR < DgvShow.Rows.Count)
            {
                if (CountR % 2 == 0)
                {
                    DgvShow.Rows[CountR].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    DgvShow.Rows[CountR].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
                CountR++;

            }
            this.Cursor = Cursors.Default;



        }

        private void BtnProcessTakeOrder_Click(object sender, EventArgs e)
        {
            if (CmbCustomer.Text.Trim().Equals("") || CmbCustomer.Text.Trim().Equals("CUS00000"))
            {
                MessageBox.Show("Please select any customer first.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DevExpress.XtraEditors.XtraMessageBox.Show("Please select any customer first.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbCustomer.Focus();
                return;
            }
            else if (CmbDelto.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any delto.", "Select Delto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbDelto.Focus();
                return;
            }
            else if (CmbRequiredDate.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any required date.", "Select Required Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbRequiredDate.Focus();
                return;
            }
            else if (DgvShow.Rows.Count <= 0)
            {
                MessageBox.Show("No record to process finish.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check Required Date
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            DateTime oMinRequiredDate = Todate;
            decimal oDayAllow = 0;
            query = @"   DECLARE @oCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @oDelToId AS DECIMAL(18,0) = {2};
                SELECT ISNULL(MIN([DateRequired]),CAST(GETDATE() AS DATE)) AS [DateRequired]
                FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                WHERE [CusNum] = @oCusNum AND [DelToId] = @oDelToId;
";
            query = string.Format(query, DatabaseName, CmbCustomer.SelectedValue, CmbDelto.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null && lists.Rows.Count > 0)
            {
                oMinRequiredDate = Convert.ToDateTime(DBNull.Value.Equals(lists.Rows[0]["DateRequired"]) ? Todate : lists.Rows[0]["DateRequired"]);
            }

            oDayAllow = (decimal)(oMinRequiredDate - Convert.ToDateTime(CmbRequiredDate.Text)).TotalDays;
            if (oDayAllow >= 0) oDayAllow = (decimal)(Todate - Convert.ToDateTime(CmbRequiredDate.Text)).TotalDays;

            if (oDayAllow <= -6)
            {
                if (MessageBox.Show("Please check required date again.\nThe required date not allow to process this week.\nDo you want to go ahead?(Yes/No)", "Not Allow Required Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    CmbRequiredDate.Focus();
                    return;
                }
            }

            string vId = "";
            string vlstBarcode_ = "";


            string[] idSelected = (from DataGridViewRow row in this.DgvShow.Rows.Cast<DataGridViewRow>()
                                   where (Convert.ToBoolean(row.Cells["Tick"].Value) == true) && (Convert.ToDecimal(DBNull.Value.Equals(row.Cells["TotalPcsOrder"].Value) ? 0 : row.Cells["TotalPcsOrder"].Value) > 0)
                                   select row.Cells["Id"].Value.ToString()).Distinct().ToArray();
            vId = string.Join(",", idSelected);

            string[] barcodeSelected = (from DataGridViewRow row in this.DgvShow.Rows.Cast<DataGridViewRow>()
                                        where (Convert.ToBoolean(row.Cells["Tick"].Value) == true) && (Convert.ToDecimal(DBNull.Value.Equals(row.Cells["TotalPcsOrder"].Value) ? 0 : row.Cells["TotalPcsOrder"].Value) > 0)
                                        select row.Cells["Barcode"].Value.ToString()).Distinct().ToArray();
            vlstBarcode_ = string.Join(",", barcodeSelected);

            if (vId.Trim().Equals(""))
            {
                MessageBox.Show("Please tick the row(s) which you want to process the take order.", "Tick Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DgvShow.Focus();
                return;
            }

            string CusNum = Convert.ToString(DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value) ? "" : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value);
            if (MessageBox.Show("Are you sure, you already to process this take order?(Yes/No)", "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            Initialized.R_MessageAlert = "";
            Initialized.R_DocumentNumber = "";
            Initialized.R_LineCode = "";
            Initialized.R_DeptCode = "";

            string vPONumber = Convert.ToString(DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["PONumber"].Value) ? "" : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["PONumber"].Value);
            DateTime? vDeliveryDate = Convert.ToDateTime(DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["DateRequired"].Value) ? Todate.Date : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["DateRequired"].Value);

            FrmDeliveryTakeOrderMessage vFrm = new FrmDeliveryTakeOrderMessage { vPONumber = vPONumber, vTodate = Todate };
            vFrm.DTPDeliveryDate.Value = (DateTime)vDeliveryDate;
            vFrm.CheckBox1.Checked = true;
            if (vFrm.ShowDialog(this) == DialogResult.Cancel) return;

            vPONumber = vFrm.vPONumber;
            vDeliveryDate = vFrm.vDeliveryDate;

            FrmDeliveryTakeOrderInfoAeon vFrm2_ = new FrmDeliveryTakeOrderInfoAeon();
            vFrm2_.ShowDialog();

            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));

            string vCusNum = "";
            if (CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null)
            {
                vCusNum = "";
            }
            else
            {
                vCusNum = CmbCustomer.Text.Trim() == "" ? "" : CmbCustomer.SelectedValue.ToString();
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

            DateTime vRequiredDate = Todate;
            if (CmbRequiredDate.SelectedValue is DataRowView || CmbRequiredDate.SelectedValue == null)
            {
                vRequiredDate = Todate;
            }
            else
            {
                vRequiredDate = CmbRequiredDate.Text.Trim() == "" ? Todate : Convert.ToDateTime(CmbRequiredDate.SelectedValue);
            }

            query = @"DECLARE @cusNum AS NVARCHAR(8) = N'{1}';
DECLARE @barcodeSelected AS NVARCHAR(MAX) = N'{2}';
DECLARE @deltoId AS DECIMAL(18, 0) = {3};
DECLARE @poNumber AS NVARCHAR(25) = N'{4}';

IF (@barcodeSelected IS NULL)
    SET @barcodeSelected = N'';

SET @barcodeSelected = CASE
                           WHEN RIGHT(@barcodeSelected, 1) = N',' THEN
                               @barcodeSelected
                           ELSE
                               CONCAT(@barcodeSelected, N',')
                       END;
DECLARE @lItemList AS TABLE
(
    [barcode] NVARCHAR(25) NULL
);
WITH lItem ([barcode], [item])
AS (SELECT LEFT(@barcodeSelected, CHARINDEX(N',', @barcodeSelected) - 1) [barcode],
           STUFF(@barcodeSelected, 1, CHARINDEX(N',', @barcodeSelected), N'') [item]
    UNION ALL
    SELECT LEFT([item], CHARINDEX(N',', [item]) - 1) [barcode],
           STUFF([item], 1, CHARINDEX(N',', [item]), N'') [item]
    FROM lItem
    WHERE [item] <> N'')
INSERT INTO @lItemList
(
    [barcode]
)
SELECT [barcode]
FROM lItem
GROUP BY [barcode]
OPTION (MAXRECURSION 32767);

WITH v
AS (SELECT [ponumber],
           [cusnum],
           [cusname]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill]
    WHERE ([cusnum] = @cusNum)
          AND ([deltoid] = @deltoId)
          AND ([barcode] IN
               (
                   SELECT [barcode] FROM @lItemList GROUP BY [barcode]
               )
              )
          AND ([ponumber] = @poNumber)
    GROUP BY [ponumber],
             [cusnum],
             [cusname]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.picking]
    WHERE ([cusnum] = @cusNum)
          AND ([deltoid] = @deltoId)
          AND ([barcode] IN
               (
                   SELECT [barcode] FROM @lItemList GROUP BY [barcode]
               )
              )
          AND ([ponumber] = @poNumber)
    GROUP BY [ponumber],
             [cusnum],
             [cusname]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.invoicing]
    WHERE ([cusnum] = @cusNum)
          AND ([deltoid] = @deltoId)
          AND ([barcode] IN
               (
                   SELECT [barcode] FROM @lItemList GROUP BY [barcode]
               )
              )
          AND ([ponumber] = @poNumber)
    GROUP BY [ponumber],
             [cusnum],
             [cusname]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.finish]
    WHERE ([cusnum] = @cusNum)
          AND ([deltoid] = @deltoId)
          AND ([barcode] IN
               (
                   SELECT [barcode] FROM @lItemList GROUP BY [barcode]
               )
              )
          AND ([ponumber] = @poNumber)
          AND CONVERT(DATE, [dateorder]) >= CONVERT(DATE, DATEADD(MONTH, -1, GETDATE()))
    GROUP BY [ponumber],
             [cusnum],
             [cusname])
SELECT v.*
FROM v;";
            query = string.Format(query, DatabaseName, vCusNum, vlstBarcode_, vDeltoId, vPONumber);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                MessageBox.Show("Please check PO Number again!\nDuplicated PO Number!", "Duplicated PO Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmPasswordContinues vFrm3_ = new FrmPasswordContinues();
                Initialized.R_CorrectPassword = false;
                vFrm3_.R_PasswordPermission = "'Managing Director','MD Assistant','IT Manager','Office Manager'";
                vFrm3_.ShowDialog();
                if (Initialized.R_CorrectPassword == false) return;
            }

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
                    MessageBox.Show("Please wait a few minutes...\nAnother PC is using...", "Invoice Number's Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // Key
            long Key = 0;
            query = @"
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
            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                Key = Convert.ToInt64(DBNull.Value.Equals(lists.Rows[0]["AutoNumber"]) ? 0 : lists.Rows[0]["AutoNumber"]);
            }
            string RelatedKey = string.Format("{0:yyMMdd}{1}", Todate, Key);

            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();
            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;

                query = @"DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                    DECLARE @vRequiredDate AS DATE = N'{3:yyyy-MM-dd}';
                    DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{4}';
                    DECLARE @RelatedKey AS NVARCHAR(10) = N'{5}';
                    DECLARE @vPONumber AS NVARCHAR(50) = N'{7}';
                    DECLARE @vDeliveryDate AS NVARCHAR(MAX) = N'{8}';
                    DECLARE @vMessageAlert AS NVARCHAR(MAX) = N'{9}';

                    INSERT INTO [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[DeliveryDate],[Verifed])
                    SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],@vPONumber AS [PONumber],[LogInName],@TakeOrderNumber AS [TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],GETDATE(),CASE WHEN (@vDeliveryDate = N'') THEN CONVERT(DATE,[DateRequired]) ELSE CONVERT(DATE,@vDeliveryDate) END,N'ok'
                    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    --WHERE ([CusNum] = @vCusNum) AND ([DelToId] = @vDeltoId) AND (CONVERT(DATE,[DateRequired]) = @vRequiredDate);
                    WHERE [Id] IN ({6});

                    INSERT INTO [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill_Finish]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[FinishDate],[DeliveryDate])
                    SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],@vPONumber AS [PONumber],[LogInName],@TakeOrderNumber AS [TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],GETDATE(),CASE WHEN (@vDeliveryDate = N'') THEN CONVERT(DATE,[DateRequired]) ELSE CONVERT(DATE,@vDeliveryDate) END
                    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    --WHERE ([CusNum] = @vCusNum) AND ([DelToId] = @vDeltoId) AND (CONVERT(DATE,[DateRequired]) = @vRequiredDate);
                    WHERE [Id] IN ({6});

                    INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill]([cusnum],[cusname],[deltoid],[delto],[dateorder],[daterequired],[deliverydate],[unitnumber],[barcode],[proname],[size],[qtypercase],[qtyperpack],[category],[pcsfree],[pcsorder],[packorder],[ctnorder],[totalpcsorder],[ponumber],[loginname],[takeordernumber],[promotionmachanic],[itemdiscount],[remark],[saleman],[note],[createddate])
                    SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[DeliveryDate],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],@vMessageAlert,[CreatedDate]
                    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
                    WHERE ([TakeOrderNumber] = @TakeOrderNumber);

                    -- Old Takeorder
                    --INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrder]([CusName],[CusNum],[DelTo],[DateOrd],[DateRequired],[ProNumy],[ProName],[ProPackSize],[ProQtyPCase],[PcsFree],[PcsOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderInvoiceNumber],[PrintInvoiceNumber],[PromotionMachanic],[ProCat],[ItemDiscount],[TranDate],[RemarkExpiry],[RelatedKey],[Saleman],[DeliveryDate])
                    --SELECT [CusName],[CusNum],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[ProName],[Size],[QtyPCase],[PcsFree],(ISNULL([PcsOrder],0) + (ISNULL([PackOrder],0) * ISNULL([QtyPPack],1))),[CTNOrder],[TotalPcsOrder],@vPONumber AS [PONumber],[LogInName],@TakeOrderNumber AS [TakeOrderNumber],NULL,[PromotionMachanic],[Category],[ItemDiscount],[CreatedDate],[Remark],@RelatedKey,[Saleman],CASE WHEN (@vDeliveryDate = N'') THEN CONVERT(DATE,[DateRequired]) ELSE CONVERT(DATE,@vDeliveryDate) END
                    -- FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
                    --WHERE [TakeOrderNumber] = @TakeOrderNumber;

                    --INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrderServiceLevel]([CusNum],[CusName],[DelTo],[DateOrd],[ShipDate],[Barcode],[ProName],[Size],[QtyPerCase],[PcsFree],[PcsOrder],[CTNOrder],[ActualOrder],[ActualDelivered],[TakeOrderNo],[TakeOrderDate],[PrintInvNo],[PrintDate],[InvoiceNo],[InvoiceDate],[RemarkStatus])
                    --SELECT [CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[ProName],[Size],[QtyPCase],[PcsFree],(ISNULL([PcsOrder],0) + (ISNULL([PackOrder],0) * ISNULL([QtyPPack],1))),[CTNOrder],[TotalPcsOrder],0,[TakeOrderNumber],[CreatedDate],NULL,NULL,NULL,NULL,[Remark]
                    --FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
                    --WHERE [TakeOrderNumber] = @TakeOrderNumber;

                    INSERT INTO [DBStockHistory].[dbo].[TblProcessHistory]([UnitNumber],[PackNumber],[CaseNumber],[ProName],[Size],[QtyPerCase],[Supplier],[ProgramName],[TransDate],[BeforeStock],[TransQty],[EndStock],[InvNumber],[Name],[Batchcode],[Location],[RelatedKey],[CreatedDate])  
                    SELECT v.[ProNumY],v.[ProNumYP],v.[ProNumYC],v.[ProName],v.[ProPacksize],v.[ProQtyPCase],v.[Sup1],N'Delivery Take Order' AS [ProgramName],v.[TransDate],v.[BeforeStock], x.[TotalPcsOrder]  AS [TransQty],v.[EndStock],@TakeOrderNumber AS [InvNumber],x.[CusNum] + SPACE(3) + x.[CusName] AS [Name],NULL AS [Batchcode],NULL AS [Location],@RelatedKey,GETDATE()  
                    FROM (  
	                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([ProTotQty],0) AS [BeforeStock],ISNULL([ProTotQty],0) AS [EndStock]  
	                    FROM [Stock].[dbo].[TPRProducts]  
	                    WHERE (ISNULL([ProNumY],'') IN (SELECT [UnitNumber] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE [TakeOrderNumber] = @TakeOrderNumber))
	                    UNION ALL  
	                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([ProTotQty],0) AS [BeforeStock],ISNULL([ProTotQty],0) AS [EndStock]  
	                    FROM [Stock].[dbo].[TPRProductsDeactivated]  
	                    WHERE (ISNULL([ProNumY],'') IN (SELECT [UnitNumber] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE [TakeOrderNumber] = @TakeOrderNumber))
	                    UNION ALL  
	                    SELECT [OldProNumy] AS [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([Stock],0) AS [BeforeStock],ISNULL([Stock],0) AS [EndStock]  
	                    FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]  
	                    WHERE B.[OldProNumy] IN (SELECT [UnitNumber] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE [TakeOrderNumber] = @TakeOrderNumber)
	                    UNION ALL  
	                    SELECT [OldProNumy] AS [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([Stock],0) AS [BeforeStock],ISNULL([Stock],0) AS [EndStock]  
	                    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]  
	                    WHERE B.[OldProNumy] IN (SELECT [UnitNumber] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE [TakeOrderNumber] = @TakeOrderNumber)
                    ) v INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS x ON v.[ProNumY] = x.[UnitNumber];

                    DELETE FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    --WHERE ([CusNum] = @vCusNum) AND ([DelToId] = @vDeltoId) AND (CONVERT(DATE,[DateRequired]) = @vRequiredDate);
                    WHERE [Id] IN ({6});";

                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vRequiredDate, vInvNo, RelatedKey, vId, vPONumber, DBNull.Value.Equals(vDeliveryDate) ? "" : string.Format("{0:yyyy-MM-dd}", vDeliveryDate), Initialized.R_MessageAlert.Trim());
                RCom.CommandText = query;
                RCom.ExecuteNonQuery();
                if (Initialized.R_MessageAlert.Trim() != "")
                {
                    query = @"
             DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{1}';
                        DECLARE @Message AS NVARCHAR(100) = N'{2}';
                        INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrderAlertToQsDelivery]([InvNo],[CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],[Message],[RegisterDate])
                        SELECT [TakeOrderNumber],[CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],@Message,GETDATE()
                        FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
                        WHERE [TakeOrderNumber] = @TakeOrderNumber;
    ";
                    query = string.Format(query, DatabaseName, vInvNo, Initialized.R_MessageAlert.Trim());
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                }

                if (Initialized.R_DocumentNumber.Trim() != "" && Initialized.R_LineCode.Trim() != "" && Initialized.R_DeptCode.Trim() != "")
                {
                    query = @"
       DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{1}';
                        DECLARE @CusNum AS NVARCHAR(8) = N'{2}';
                        DECLARE @DocumentNumber AS NVARCHAR(20) = N'{3}';
                        DECLARE @LineCode AS NVARCHAR(14) = N'{4}';
                        DECLARE @DeptCode AS NVARCHAR(14) = N'{5}';
                        INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrder_ForAEON]([SupervisorID],[CusNum],[DocumentNumber],[LineCode],[DeptCode],[TakeOrderID],[DeliveryID])
                        VALUES(NULL,@CusNum,@DocumentNumber,@LineCode,@DeptCode,@TakeOrderNumber,NULL);

    ";
                    query = string.Format(query, DatabaseName, vInvNo, CusNum, Initialized.R_DocumentNumber.Trim(), Initialized.R_LineCode.Trim(), Initialized.R_DeptCode.Trim());
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                }

                RCom.CommandText = "UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 0,[PrintInvNo] = ([PrintInvNo] + 1);";
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();
                this.separateItemLoading.Enabled = true;
                MessageBox.Show("The processing has been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TimerTakeOrderLoading.Enabled = true;
                this.TimerDisplayLoading.Enabled = true;

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

        private void chkshowprice_CheckedChanged(object sender, EventArgs e)
        {
            this.TimerDisplayLoading.Enabled = true;
        }

        private void BtnPreviewNEditTakeOrder_Click(object sender, EventArgs e)
        {
            FrmPODutchmillDate_ vF1 = new FrmPODutchmillDate_();
            vF1.ChkLock.Visible = false;
            vF1.BtnExportToExcel.Text = "&Preview";
            vF1.BtnExportToExcel.Image = DeliveryTakeOrder.Properties.Resources.Search16;
            if (vF1.ShowDialog() == DialogResult.Cancel) return;

            string iPlanningOrder = vF1.iPlanningOrder;
            DateTime vRequiredDate = vF1.iRequiredDate;

            FrmProcessTakeOrderPreviewNEdit vF2 = new FrmProcessTakeOrderPreviewNEdit
            {
                WindowState = FormWindowState.Maximized,
                vRequiredDate = vRequiredDate,
                iPlanningOrder = iPlanningOrder
            };
            vF2.ShowDialog(this.menuMdi);

        }

        private void DgvShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (DgvShow.RowCount <= 0) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.IsInputKey = true;
                MnuDeleteTakeOrder_Click(MnuDeleteTakeOrder, new System.EventArgs());
            }

        }

        private void MnuDeleteTakeOrder_Click(object sender, EventArgs e)
        {
            this.Popmenu.Close();
            if (DgvShow.RowCount <= 0) return;

            decimal lId = 0;
            if (MessageBox.Show("Are you sure, you want to delete the selected barcodes?(Yes/No)", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();

            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;

                foreach (DataGridViewRow r in DgvShow.SelectedRows)
                {
                    lId = Convert.ToDecimal(DBNull.Value.Equals(r.Cells["Id"].Value) ? 0 : r.Cells["Id"].Value);
                    query = $@"
            DECLARE @lId AS DECIMAL(18,0) = {lId};
            INSERT INTO [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill_Deleted]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[DeletedDate])
            SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],GETDATE()
            FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
            WHERE [Id] = @lId;

            DELETE FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
            WHERE [Id] = @lId;
        ";
                    query = string.Format(query, DatabaseName, lId);
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                }

                RTran.Commit();
                RCon.Close();
                MessageBox.Show("Deleting has been completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TimerTakeOrderLoading.Enabled = true;
                this.TimerDisplayLoading.Enabled = true;
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

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            FrmPODutchmillDate Frm = new FrmPODutchmillDate();
            if (Frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            DateTime RequiredDate = Frm.iRequiredDate;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            DateTime oTodate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            query = @"DECLARE @vquery AS nvarchar(max) = N'';

SELECT
  @vquery += N'
SELECT [InvNumber],[PONumber],[CusNum],[CusCom],[ShipDate],[DelTo],[GrandTotal],N''' + v.Division + N''' [Division]
FROM [Stock].[dbo].[' + v.[TableName]
  + ']
WHERE (ISNULL([PAID],''0'') = ''0'') 
AND [CusNum] IN (SELECT [CusNum] FROM #vCustomerList GROUP BY [CusNum]) 
UNION ALL 
'
FROM [Stock].[dbo].[AAllDivisionPayment] v
WHERE v.[Division] NOT IN (N'Division2 VAT',N'Division2','Division8', 'Division8 VAT', 'Division9',
'Division9 VAT', 'Division11', 'Division11 VAT')
ORDER BY v.[Division];

SET @vquery = SUBSTRING(@vquery, 0, (LEN(@vquery) - 11));

SET @vquery = N'
DECLARE @vDateRequired AS DATE = ''{1:yyyy-MM-dd}'';
SELECT [CusNum],[CusName]
INTO #vCustomerList
FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
WHERE ( CONVERT(DATE,[DateRequired]) = CONVERT(DATE,@vDateRequired))
GROUP BY [CusNum],[CusName];

WITH o as (
' + @vquery
+ N'
)
SELECT o.[InvNumber],o.[PONumber],o.[CusNum],o.[CusCom],o.[ShipDate],o.[DelTo],o.[GrandTotal],o.[Division]
INTO #credit
FROM o;

declare @itbl as nvarchar(max) = N'''';
declare @idivision as nvarchar(100) = N'''';
declare @itbl_ as table 
(
    [InvNumber] [NVARCHAR](25) NULL ,
	[Division] [NVARCHAR] (100) NULL
);

declare cur cursor
for
SELECT v.TableName,v.Division
FROM [Stock].[dbo].[AAllDivisionStatement] v
WHERE   v.[Division] NOT IN (N''Division2 VAT'', N''Division2'', ''Division8'', ''Division8 VAT'', ''Division9'',
                              ''Division9 VAT'', ''Division11'', ''Division11 VAT'' )
							  group by v.TableName,v.Division;
open cur;
fetch next from cur into @itbl, @idivision;
while @@FETCH_STATUS = 0
begin
	insert into @itbl_ ([InvNumber],[Division])
	exec (N''
	select [InvNumber], N'''''' + @idivision + N''''''
	from [Stock].[dbo].['' + @itbl + N''] o
	group by [InvNumber];
	'');

	UPDATE i
	SET i.[InvNumber] = NULL
	FROM #credit i
	INNER JOIN @itbl_ o ON ( o.Division = i.Division ) and ( o.[InvNumber] = i.[InvNumber] );

	DELETE
	FROM #credit
	WHERE ( [InvNumber] IS NULL );

    DELETE FROM @itbl_;

	fetch next from cur into @itbl, @idivision;
end;
close cur;
deallocate cur;

WITH v AS (
SELECT x.CusNum,x.CusName,x.Terms,x.MaxMonthAllow,x.CreditLimit,x.CreditLimitAllow
FROM Stock.dbo.TPRCustomer x
)
SELECT v.CusNum,v.CusName,v.Terms,v.MaxMonthAllow,v.CreditLimit,v.CreditLimitAllow
INTO #customer
FROM v;

SELECT o.CusNum,v.CusName,SUM(o.GrandTotal) AS GrandTotal,v.CreditLimit,v.CreditLimitAllow
,v.Terms,v.MaxMonthAllow,DATEDIFF(DAY,MIN(o.ShipDate),GETDATE()) [LatestInvoice]
,CASE WHEN (SUM(o.GrandTotal) >= v.CreditLimitAllow) THEN (SUM(o.GrandTotal) - v.CreditLimitAllow) ELSE (SUM(o.GrandTotal) - v.CreditLimit) END [OverCredit]
INTO #credit_amount
FROM #credit o INNER JOIN #customer v ON v.CusNum = o.CusNum
GROUP BY o.CusNum,v.CusName,v.CreditLimit,v.CreditLimitAllow,v.Terms,v.MaxMonthAllow
HAVING (SUM(o.GrandTotal) >= v.CreditLimit)
       OR (SUM(o.GrandTotal) >= v.CreditLimitAllow)
	   OR (DATEDIFF(DAY, MIN(o.ShipDate), GETDATE()) > v.MaxMonthAllow);

DELETE
FROM #credit_amount
WHERE [CusNum] IN (SELECT [CusNum]
FROM [{0}].[dbo].[TblCustomer.Unlock.Credit.Dutchmill]
WHERE (ISNULL([Unlock],0) = 1)
GROUP BY [CusNum]);

SELECT *
FROM #credit_amount
ORDER BY [CusName],[OverCredit] DESC;

DROP TABLE #vCustomerList;
DROP TABLE #credit;
DROP TABLE #credit_amount;
DROP TABLE #customer;
';
EXEC (@vquery);
";
            query = string.Format(query, DatabaseName, RequiredDate);
            var oPaymentlists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            var vreport = new sCredit();
            var vadapter = new OleDbDataAdapter();
            var vds = new DataSet();
            ReportPrintTool vtool;
            Application.DoEvents();

            if (oPaymentlists != null)
            {
                if (oPaymentlists.Rows.Count > 0)
                {
                    vreport = new sCredit();
                    vadapter = new OleDbDataAdapter();
                    vds = new DataSet();
                    vtool = new ReportPrintTool(vreport);

                    vreport.Parameters["companyname"].Value = string.Format("{0}{1}{2}", Initialized.R_CompanyKhmerName, Environment.NewLine, Initialized.R_CompanyName);
                    vreport.Parameters["companyaddress"].Value = string.Format("{0}{1}{2}{1}Tel:{3}",
                        Initialized.R_CompanyKhmAddress.Replace(Environment.NewLine, "").Trim(),
                        Environment.NewLine,
                        Initialized.R_CompanyAddress.Replace(Environment.NewLine, "").Trim(),
                        Initialized.R_CompanyTelephone);
                    vreport.Parameters["currentdate"].Value = oTodate;

                    vreport.DataSource = oPaymentlists;
                    vreport.DataAdapter = vadapter;
                    vreport.DataMember = "dtOverCredit";
                    vreport.RequestParameters = false;

                    var gui1_ = new gui_preview { WindowState = FormWindowState.Maximized };
                    gui1_.docviewer.DocumentSource = vreport;
                    gui1_.docviewer.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Customize, DevExpress.XtraPrinting.CommandVisibility.None);
                    gui1_.docviewer.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, DevExpress.XtraPrinting.CommandVisibility.None);

                    vreport.CreateDocument(true);
                    gui1_.ShowDialog(this);
                    return;
                }
            }
            query = @" DECLARE @DateRequired AS DATE = N'{1:yyyy-MM-dd}';
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
                    SELECT [Barcode],[ProName],[Category] AS [Remark],[Size],[QtyPCase],ISNULL([DelTo],'') AS [CusName],SUM(ISNULL([TotalPcsOrder],0)) AS [TotalPcsOrder],[DateRequired],[DelToId],[PromotionMachanic]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    WHERE DATEDIFF(DAY,[DateRequired],@DateRequired) = 0
                    GROUP BY [Barcode],[ProName],[Category],[Size],[QtyPCase],ISNULL([DelTo],''),[DateRequired],[DelToId],[PromotionMachanic]
                    UNION ALL
                    SELECT x.[Barcode],x.[ProName],x.[Category] AS [Remark],x.[Size],x.[QtyPCase],ISNULL(x.[DelTo],'') AS [CusName],NULL AS [TotalPcsOrder],[DateRequired],x.[DelToId],x.[PromotionMachanic]
                    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill] as x
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
                THEN 1 ELSE 0 END AS [Missing],v.[DelToId],
                REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(v.[PromotionMachanic],N'1,',N''),N'1 ,',N''),N'1.',N''),N'1 .',N''),N'2,',N''),N'2 ,',N''),N'2.',N''),N'2 .',N''),N'3,',N''),N'3 ,',N''),N'3.',N''),N'3 .',N''),N'4,',N''),N'4 ,',N''),N'4.',N''),N'4 .',N''),N'5,',N''),N'5 ,',N''),N'5.',N''),N'5 .',N''),N'6,',N''),N'6 ,',N''),N'6.',N''),N'6 .',N''),N'7,',N''),N'7 ,',N''),N'7.',N''),N'7 .',N''),N'8,',N''),N'8 ,',N''),N'8.',N''),N'8 .',N''),N'9,',N''),N'9 ,',N''),N'9.',N''),N'9 .',N''),N'0,',N''),N'0 ,',N''),N'0.',N''),N'0 .',N'') [PromotionMachanic]
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
                THEN 1 ELSE 0 END,v.[DelToId],
                REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(v.[PromotionMachanic],N'1,',N''),N'1 ,',N''),N'1.',N''),N'1 .',N''),N'2,',N''),N'2 ,',N''),N'2.',N''),N'2 .',N''),N'3,',N''),N'3 ,',N''),N'3.',N''),N'3 .',N''),N'4,',N''),N'4 ,',N''),N'4.',N''),N'4 .',N''),N'5,',N''),N'5 ,',N''),N'5.',N''),N'5 .',N''),N'6,',N''),N'6 ,',N''),N'6.',N''),N'6 .',N''),N'7,',N''),N'7 ,',N''),N'7.',N''),N'7 .',N''),N'8,',N''),N'8 ,',N''),N'8.',N''),N'8 .',N''),N'9,',N''),N'9 ,',N''),N'9.',N''),N'9 .',N''),N'0,',N''),N'0 ,',N''),N'0.',N''),N'0 .',N''))

				SELECT w.[Barcode],w.[ProName],w.[Remark],REPLACE(w.[Size],' ','') AS [Size],w.[QtyPCase],w.[CusName],case when isnull(w.[TotalPcsOrder],0) = 0 then null else w.[TotalPcsOrder] end as [TotalPcsOrder],
                CASE WHEN (w.[Missing] = 1 AND ISNULL(w.[TotalPcsOrder],0) <> 0) OR ISNULL(w.[DelToId],0) = 0 THEN 1 ELSE 0 END AS [Missing],
                ISNULL(v.[PiecesPerTray],1) AS [PiecesPerTray],w.[DeltoId],w.[PromotionMachanic]
				INTO #vLists
				FROM w
                LEFT OUTER JOIN [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_TraySetting] AS v ON v.Barcode = w.Barcode
                GROUP BY w.[Barcode],w.[ProName],w.[Remark],REPLACE(w.[Size],' ',''),w.[QtyPCase],w.[CusName],case when isnull(w.[TotalPcsOrder],0) = 0 then null else w.[TotalPcsOrder] end,
                CASE WHEN (w.[Missing] = 1 AND ISNULL(w.[TotalPcsOrder],0) <> 0) OR ISNULL(w.[DelToId],0) = 0 THEN 1 ELSE 0 END,
                ISNULL(v.[PiecesPerTray],1),w.[DeltoId],w.[PromotionMachanic]
                ORDER BY w.[Remark],w.[ProName];
				SELECT v.Barcode,v.ProName,v.Remark,v.Size,v.QtyPCase,v.PiecesPerTray,SUM(v.TotalPcsOrder) AS [TotalOrder],((CEILING(SUM(v.TotalPcsOrder)/ISNULL(v.PiecesPerTray,1))*ISNULL(v.PiecesPerTray,1)) - SUM(v.TotalPcsOrder)) AS [TotalExtraLeft],(CEILING(SUM(v.TotalPcsOrder)/ISNULL(v.PiecesPerTray,1))*ISNULL(v.PiecesPerTray,1)) AS [TotalOrderToThailand],ROUND(((CEILING(SUM(v.TotalPcsOrder)/ISNULL(v.PiecesPerTray,1))*ISNULL(v.PiecesPerTray,1)) / ISNULL(v.PiecesPerTray,1)),2) AS [TotalTray],v.[PromotionMachanic]
				INTO #v
				FROM #vLists AS v
				GROUP BY v.Barcode,v.ProName,v.Remark,v.Size,v.QtyPCase,v.PiecesPerTray,v.[PromotionMachanic]
				ORDER BY v.Size,v.ProName;

				SELECT v.*
				FROM #v AS v
				ORDER BY v.Remark,v.Size,v.Barcode,v.ProName;
				DROP TABLE #vLists;
				DROP TABLE #v;";

            query = string.Format(query, DatabaseName, RequiredDate);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));


            var vAdapter1 = new OleDbDataAdapter();
            var vReport1 = new XtraPODutchmills();
            var vTool1 = new ReportPrintTool(vReport1);

            vReport1.Parameters["companyname"].Value = string.Format("{0}{1}{2}", Initialized.R_CompanyKhmerName, Environment.NewLine, Initialized.R_CompanyName);
            vReport1.Parameters["companyaddress"].Value = string.Format("{0}{1}{2}{1}Tel:{3}",
                Initialized.R_CompanyKhmAddress.Replace(Environment.NewLine, "").Trim(),
                Environment.NewLine,
                Initialized.R_CompanyAddress.Replace(Environment.NewLine, "").Trim(),
                Initialized.R_CompanyTelephone);
            vReport1.Parameters["planningorder"].Value = string.Format("DUTCHMILL ( {0:dddd} )", RequiredDate).ToUpper();
            vReport1.Parameters["planningdate"].Value = oTodate;
            vReport1.Parameters["shipmentdate"].Value = RequiredDate;

            vReport1.DataSource = lists;
            vReport1.DataAdapter = vAdapter1;
            vReport1.DataMember = "XrPODutchmill";
            vReport1.RequestParameters = false;

            // Uncomment to customize report tool if needed
            // vTool1.AutoShowParametersPanel = false;
            // vTool1.PrinterSettings.Copies = 1;
            // vTool1.ShowRibbonPreviewDialog();

            var gui_ = new gui_preview { WindowState = FormWindowState.Maximized };
            gui_.docviewer.DocumentSource = vReport1;
            gui_.docviewer.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Customize, DevExpress.XtraPrinting.CommandVisibility.None);
            gui_.docviewer.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, DevExpress.XtraPrinting.CommandVisibility.None);

            vReport1.CreateDocument(true);
            gui_.ShowDialog(this);

            this.Cursor = Cursors.Default;




        }

        private void separateItemLoading_Tick(object sender, EventArgs e)
        {
            this.separateItemLoading.Enabled = false;
            string lSql = string.Empty;
            DataTable lTbl;
            lSql = @"
DECLARE @RC INT;
EXECUTE @RC = [DBPickers].[dbo].[auto_check_item_separately];
";
            lTbl = Data.Selects(lSql, Initialized.GetConnectionType(Data, App));

        }

        private void DgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vSelected = 0;
            string vCusVAT = "";
            bool vCheckVAT = false;
            bool vSpecial = false;
            bool lOnePOOneInvoice = false;
            string lSql = string.Empty;
            DataTable lTbl;

            if (e.ColumnIndex == 0)
            {
                DgvShow.Rows[e.RowIndex].Cells["Tick"].Value = !Convert.ToBoolean(DgvShow.Rows[e.RowIndex].Cells["Tick"].Value);
                lSql = $@"
        DECLARE @CusNum AS NVARCHAR(8) = N'{DgvShow.Rows[e.RowIndex].Cells["CusNum"].Value}';
        SELECT [Id],[CusNum],[CusName],[CreatedDate]
        FROM [{DatabaseName}].[dbo].[TblCustomerSetting_SpecialInvoices]
        WHERE [CusNum] = @CusNum;
    ";
                lTbl = Data.Selects(lSql, Initialized.GetConnectionType(Data, App));
                if (lTbl != null && lTbl.Rows.Count > 0) vSpecial = true;

                foreach (DataGridViewRow row in DgvShow.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Tick"].Value))
                    {
                        if (vSpecial) goto Err_Skip_SpecialInvoice;
                        if (!vCheckVAT)
                        {
                            vCusVAT = "";
                            lOnePOOneInvoice = false;
                            lSql = $@"
                    DECLARE @lCusNum AS NVARCHAR(8) = N'{row.Cells["CusNum"].Value}';
                    SELECT [lc].[CusVat],
                           CASE
                               WHEN ISNULL([ll].[CusNum], N'') = N'' THEN
                                   0
                               ELSE
                                   1
                           END [lOnePOOneInvoice]
                    FROM [Stock].[dbo].[TPRCustomer] lc
                        LEFT OUTER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblSetCustomerIntoDivisionVAT] ll
                            ON ([ll].[CusNum] = [lc].[CusNum])
                    WHERE [lc].[CusNum] = @lCusNum;
                ";
                            lTbl = Data.Selects(lSql, Initialized.GetConnectionType(Data, App));
                            if (lTbl != null && lTbl.Rows.Count > 0)
                            {
                                vCusVAT = lTbl.Rows[0]["CusVat"] == DBNull.Value ? "" : lTbl.Rows[0]["CusVat"].ToString().Trim();
                                lOnePOOneInvoice = lTbl.Rows[0]["lOnePOOneInvoice"] == DBNull.Value ? false : Convert.ToBoolean(lTbl.Rows[0]["lOnePOOneInvoice"]);
                            }
                            vCheckVAT = true;
                        }
                        if (vCusVAT.Trim().Equals("") || vCusVAT.Trim().Equals("0"))
                        {
                            if (vSelected >= 21)
                            {
                                MessageBox.Show("The Invoice allows 21 rows only!", "21 Rows", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DgvShow.Rows[e.RowIndex].Cells["Tick"].Value = false;
                                break;
                            }
                        }
                        else
                        {
                            if (vSelected >= 12 && !lOnePOOneInvoice)
                            {
                                MessageBox.Show("The Invoice allows 12 rows only!", "12 Rows", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DgvShow.Rows[e.RowIndex].Cells["Tick"].Value = false;
                                break;
                            }
                        }
                    Err_Skip_SpecialInvoice:
                        vSelected++;
                    }
                }
            }
            LblSeletedRow.Text = $"Selected Row : {vSelected}";

        }

        //private void DgvShow_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //this.Popmenu.Close();
        //    //if (DgvShow.RowCount <= 0) return;
        //    //if (e.Button == MouseButtons.Right) this.Popmenu.Show(DgvShow, new System.Drawing.Point(e.X, e.Y));


        //}

        private void FrmProcessTakeOrder_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_DatabaseName.ToUpper();

        }

        private void FrmProcessTakeOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void BtnProcessTakeOrder_Click_1(object sender, EventArgs e)
        {
            if (CmbCustomer.Text.Trim().Equals("") || CmbCustomer.Text.Trim().Equals("CUS00000"))
            {
                MessageBox.Show("Please select any customer first.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbCustomer.Focus();
                return;
            }
            else if (CmbDelto.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any delto.", "Select Delto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbDelto.Focus();
                return;
            }
            else if (CmbRequiredDate.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any required date.", "Select Required Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbRequiredDate.Focus();
                return;
            }
            else if (DgvShow.Rows.Count <= 0)
            {
                MessageBox.Show("No record to process finish.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check Required Date
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            DateTime oMinRequiredDate = Todate;
            decimal oDayAllow = 0;
            query = @"
     DECLARE @oCusNum AS NVARCHAR(8) = N'{1}';
                DECLARE @oDelToId AS DECIMAL(18,0) = {2};
                SELECT ISNULL(MIN([DateRequired]),CAST(GETDATE() AS DATE)) AS [DateRequired]
                FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                WHERE [CusNum] = @oCusNum AND [DelToId] = @oDelToId;
";
            query = string.Format(query, DatabaseName, CmbCustomer.SelectedValue, CmbDelto.SelectedValue);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null && lists.Rows.Count > 0)
            {
                oMinRequiredDate = Convert.ToDateTime(DBNull.Value.Equals(lists.Rows[0]["DateRequired"]) ? Todate : lists.Rows[0]["DateRequired"]);
            }

            oDayAllow = (decimal)(oMinRequiredDate - Convert.ToDateTime(CmbRequiredDate.Text)).TotalDays;
            if (oDayAllow >= 0) oDayAllow = (decimal)(Todate - Convert.ToDateTime(CmbRequiredDate.Text)).TotalDays;

            if (oDayAllow <= -6)
            {
                if (MessageBox.Show("Please check required date again.\nThe required date not allow to process this week.\nDo you want to go ahead?(Yes/No)", "Not Allow Required Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    CmbRequiredDate.Focus();
                    return;
                }
            }

            string vId = "";
            string vlstBarcode_ = "";

            string[] idSelected = (from DataGridViewRow row in this.DgvShow.Rows.Cast<DataGridViewRow>()
                                   where (Convert.ToBoolean(row.Cells["Tick"].Value) == true) && (Convert.ToDecimal(DBNull.Value.Equals(row.Cells["TotalPcsOrder"].Value) ? 0 : row.Cells["TotalPcsOrder"].Value) > 0)
                                   select row.Cells["Id"].Value.ToString()).Distinct().ToArray();
            vId = string.Join(",", idSelected);

            string[] barcodeSelected = (from DataGridViewRow row in this.DgvShow.Rows.Cast<DataGridViewRow>()
                                        where (Convert.ToBoolean(row.Cells["Tick"].Value) == true) && (Convert.ToDecimal(DBNull.Value.Equals(row.Cells["TotalPcsOrder"].Value) ? 0 : row.Cells["TotalPcsOrder"].Value) > 0)
                                        select row.Cells["Barcode"].Value.ToString()).Distinct().ToArray();
            vlstBarcode_ = string.Join(",", barcodeSelected);


            if (vId.Trim().Equals(""))
            {
                MessageBox.Show("Please tick the row(s) which you want to process the take order.", "Tick Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DgvShow.Focus();
                return;
            }

            string CusNum = DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value) ? "" : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["CusNum"].Value.ToString().Trim();
            if (MessageBox.Show("Are you sure, you already to process this take order?(Yes/No)", "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            Initialized.R_MessageAlert = "";
            Initialized.R_DocumentNumber = "";
            Initialized.R_LineCode = "";
            Initialized.R_DeptCode = "";

            string vPONumber = DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["PONumber"].Value) ? "" : DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["PONumber"].Value.ToString().Trim();
            DateTime vDeliveryDate = DBNull.Value.Equals(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["DateRequired"].Value) ? Todate.Date : Convert.ToDateTime(DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["DateRequired"].Value);

            FrmDeliveryTakeOrderMessage vFrm = new FrmDeliveryTakeOrderMessage { vPONumber = vPONumber, vTodate = Todate };
            vFrm.DTPDeliveryDate.Value = vDeliveryDate;
            vFrm.CheckBox1.Checked = true;
            if (vFrm.ShowDialog(this) == DialogResult.Cancel) return;

            vPONumber = vFrm.vPONumber;
            vDeliveryDate = (DateTime)vFrm.vDeliveryDate;

            FrmDeliveryTakeOrderInfoAeon vFrm2_ = new FrmDeliveryTakeOrderInfoAeon();
            vFrm2_.ShowDialog();

            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));

            string vCusNum = "";
            if (CmbCustomer.SelectedValue is DataRowView || CmbCustomer.SelectedValue == null)
            {
                vCusNum = "";
            }
            else
            {
                vCusNum = CmbCustomer.Text.Trim() == "" ? "" : CmbCustomer.SelectedValue.ToString();
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

            DateTime vRequiredDate = Todate;
            if (CmbRequiredDate.SelectedValue is DataRowView || CmbRequiredDate.SelectedValue == null)
            {
                vRequiredDate = Todate;
            }
            else
            {
                vRequiredDate = CmbRequiredDate.Text.Trim() == "" ? Todate : Convert.ToDateTime(CmbRequiredDate.SelectedValue);
            }
            // P.O Number existed or not 
            query = @"DECLARE @cusNum AS NVARCHAR(8) = N'{1}';
DECLARE @barcodeSelected AS NVARCHAR(MAX) = N'{2}';
DECLARE @deltoId AS DECIMAL(18, 0) = {3};
DECLARE @poNumber AS NVARCHAR(25) = N'{4}';

IF (@barcodeSelected IS NULL)
    SET @barcodeSelected = N'';

SET @barcodeSelected = CASE
                           WHEN RIGHT(@barcodeSelected, 1) = N',' THEN
                               @barcodeSelected
                           ELSE
                               CONCAT(@barcodeSelected, N',')
                       END;
DECLARE @lItemList AS TABLE
(
    [barcode] NVARCHAR(25) NULL
);
WITH lItem ([barcode], [item])
AS (SELECT LEFT(@barcodeSelected, CHARINDEX(N',', @barcodeSelected) - 1) [barcode],
           STUFF(@barcodeSelected, 1, CHARINDEX(N',', @barcodeSelected), N'') [item]
    UNION ALL
    SELECT LEFT([item], CHARINDEX(N',', [item]) - 1) [barcode],
           STUFF([item], 1, CHARINDEX(N',', [item]), N'') [item]
    FROM lItem
    WHERE [item] <> N'')
INSERT INTO @lItemList
(
    [barcode]
)
SELECT [barcode]
FROM lItem
GROUP BY [barcode]
OPTION (MAXRECURSION 32767);

WITH v
AS (SELECT [ponumber],
           [cusnum],
           [cusname]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill]
    WHERE ([cusnum] = @cusNum)
          AND ([deltoid] = @deltoId)
          AND ([barcode] IN
               (
                   SELECT [barcode] FROM @lItemList GROUP BY [barcode]
               )
              )
          AND ([ponumber] = @poNumber)
    GROUP BY [ponumber],
             [cusnum],
             [cusname]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.picking]
    WHERE ([cusnum] = @cusNum)
          AND ([deltoid] = @deltoId)
          AND ([barcode] IN
               (
                   SELECT [barcode] FROM @lItemList GROUP BY [barcode]
               )
              )
          AND ([ponumber] = @poNumber)
    GROUP BY [ponumber],
             [cusnum],
             [cusname]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.invoicing]
    WHERE ([cusnum] = @cusNum)
          AND ([deltoid] = @deltoId)
          AND ([barcode] IN
               (
                   SELECT [barcode] FROM @lItemList GROUP BY [barcode]
               )
              )
          AND ([ponumber] = @poNumber)
    GROUP BY [ponumber],
             [cusnum],
             [cusname]
    UNION ALL
    SELECT [ponumber],
           [cusnum],
           [cusname]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.finish]
    WHERE ([cusnum] = @cusNum)
          AND ([deltoid] = @deltoId)
          AND ([barcode] IN
               (
                   SELECT [barcode] FROM @lItemList GROUP BY [barcode]
               )
              )
          AND ([ponumber] = @poNumber)
          AND CONVERT(DATE, [dateorder]) >= CONVERT(DATE, DATEADD(MONTH, -1, GETDATE()))
    GROUP BY [ponumber],
             [cusnum],
             [cusname])
SELECT v.*
FROM v;";

            query = string.Format(query, DatabaseName, vCusNum, vlstBarcode_, vDeltoId, vPONumber);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));

            if (lists != null && lists.Rows.Count > 0)
            {
                MessageBox.Show("Please check PO Number again!\nDuplicated PO Number!", "Duplicated PO Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmPasswordContinues vFrm3_ = new FrmPasswordContinues();
                Initialized.R_CorrectPassword = false;
                vFrm3_.R_PasswordPermission = "'Managing Director','MD Assistant','IT Manager','Office Manager'";
                vFrm3_.ShowDialog();
                if (Initialized.R_CorrectPassword == false) return;
            }

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
                    MessageBox.Show("Please wait a few minutes...\nAnother PC is using...", "Invoice Number's Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // Key
            long Key = 0;
            query = @"
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
            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            if (lists != null && lists.Rows.Count > 0)
            {
                Key = Convert.ToInt64(DBNull.Value.Equals(lists.Rows[0]["AutoNumber"]) ? 0 : lists.Rows[0]["AutoNumber"]);
            }
            string RelatedKey = string.Format("{0:yyMMdd}{1}", Todate, Key);

            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();
            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                query = @"DECLARE @vCusNum AS NVARCHAR(8) = N'{1}';
                    DECLARE @vDeltoId AS DECIMAL(18,0) = {2};
                    DECLARE @vRequiredDate AS DATE = N'{3:yyyy-MM-dd}';
                    DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{4}';
                    DECLARE @RelatedKey AS NVARCHAR(10) = N'{5}';
                    DECLARE @vPONumber AS NVARCHAR(50) = N'{7}';
                    DECLARE @vDeliveryDate AS NVARCHAR(MAX) = N'{8}';
                    DECLARE @vMessageAlert AS NVARCHAR(MAX) = N'{9}';

                    INSERT INTO [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[DeliveryDate],[Verifed])
                    SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],@vPONumber AS [PONumber],[LogInName],@TakeOrderNumber AS [TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],GETDATE(),CASE WHEN (@vDeliveryDate = N'') THEN CONVERT(DATE,[DateRequired]) ELSE CONVERT(DATE,@vDeliveryDate) END,N'ok'
                    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    --WHERE ([CusNum] = @vCusNum) AND ([DelToId] = @vDeltoId) AND (CONVERT(DATE,[DateRequired]) = @vRequiredDate);
                    WHERE [Id] IN ({6});

                    INSERT INTO [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill_Finish]([CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],[FinishDate],[DeliveryDate])
                    SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],@vPONumber AS [PONumber],[LogInName],@TakeOrderNumber AS [TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],[CreatedDate],GETDATE(),CASE WHEN (@vDeliveryDate = N'') THEN CONVERT(DATE,[DateRequired]) ELSE CONVERT(DATE,@vDeliveryDate) END
                    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    --WHERE ([CusNum] = @vCusNum) AND ([DelToId] = @vDeltoId) AND (CONVERT(DATE,[DateRequired]) = @vRequiredDate);
                    WHERE [Id] IN ({6});

                    INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill]([cusnum],[cusname],[deltoid],[delto],[dateorder],[daterequired],[deliverydate],[unitnumber],[barcode],[proname],[size],[qtypercase],[qtyperpack],[category],[pcsfree],[pcsorder],[packorder],[ctnorder],[totalpcsorder],[ponumber],[loginname],[takeordernumber],[promotionmachanic],[itemdiscount],[remark],[saleman],[note],[createddate])
                    SELECT [CusNum],[CusName],[DelToId],[DelTo],[DateOrd],[DateRequired],[DeliveryDate],[UnitNumber],[Barcode],[ProName],[Size],[QtyPCase],[QtyPPack],[Category],[PcsFree],[PcsOrder],[PackOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderNumber],[PromotionMachanic],[ItemDiscount],[Remark],[Saleman],@vMessageAlert,[CreatedDate]
                    FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
                    WHERE ([TakeOrderNumber] = @TakeOrderNumber);

                    -- Old Takeorder
                    --INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrder]([CusName],[CusNum],[DelTo],[DateOrd],[DateRequired],[ProNumy],[ProName],[ProPackSize],[ProQtyPCase],[PcsFree],[PcsOrder],[CTNOrder],[TotalPcsOrder],[PONumber],[LogInName],[TakeOrderInvoiceNumber],[PrintInvoiceNumber],[PromotionMachanic],[ProCat],[ItemDiscount],[TranDate],[RemarkExpiry],[RelatedKey],[Saleman],[DeliveryDate])
                    --SELECT [CusName],[CusNum],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[ProName],[Size],[QtyPCase],[PcsFree],(ISNULL([PcsOrder],0) + (ISNULL([PackOrder],0) * ISNULL([QtyPPack],1))),[CTNOrder],[TotalPcsOrder],@vPONumber AS [PONumber],[LogInName],@TakeOrderNumber AS [TakeOrderNumber],NULL,[PromotionMachanic],[Category],[ItemDiscount],[CreatedDate],[Remark],@RelatedKey,[Saleman],CASE WHEN (@vDeliveryDate = N'') THEN CONVERT(DATE,[DateRequired]) ELSE CONVERT(DATE,@vDeliveryDate) END
                    -- FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
                    --WHERE [TakeOrderNumber] = @TakeOrderNumber;

                    --INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrderServiceLevel]([CusNum],[CusName],[DelTo],[DateOrd],[ShipDate],[Barcode],[ProName],[Size],[QtyPerCase],[PcsFree],[PcsOrder],[CTNOrder],[ActualOrder],[ActualDelivered],[TakeOrderNo],[TakeOrderDate],[PrintInvNo],[PrintDate],[InvoiceNo],[InvoiceDate],[RemarkStatus])
                    --SELECT [CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],[UnitNumber],[ProName],[Size],[QtyPCase],[PcsFree],(ISNULL([PcsOrder],0) + (ISNULL([PackOrder],0) * ISNULL([QtyPPack],1))),[CTNOrder],[TotalPcsOrder],0,[TakeOrderNumber],[CreatedDate],NULL,NULL,NULL,NULL,[Remark]
                    --FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
                    --WHERE [TakeOrderNumber] = @TakeOrderNumber;

                    INSERT INTO [DBStockHistory].[dbo].[TblProcessHistory]([UnitNumber],[PackNumber],[CaseNumber],[ProName],[Size],[QtyPerCase],[Supplier],[ProgramName],[TransDate],[BeforeStock],[TransQty],[EndStock],[InvNumber],[Name],[Batchcode],[Location],[RelatedKey],[CreatedDate])  
                    SELECT v.[ProNumY],v.[ProNumYP],v.[ProNumYC],v.[ProName],v.[ProPacksize],v.[ProQtyPCase],v.[Sup1],N'Delivery Take Order' AS [ProgramName],v.[TransDate],v.[BeforeStock], x.[TotalPcsOrder]  AS [TransQty],v.[EndStock],@TakeOrderNumber AS [InvNumber],x.[CusNum] + SPACE(3) + x.[CusName] AS [Name],NULL AS [Batchcode],NULL AS [Location],@RelatedKey,GETDATE()  
                    FROM (  
	                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([ProTotQty],0) AS [BeforeStock],ISNULL([ProTotQty],0) AS [EndStock]  
	                    FROM [Stock].[dbo].[TPRProducts]  
	                    WHERE (ISNULL([ProNumY],'') IN (SELECT [UnitNumber] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE [TakeOrderNumber] = @TakeOrderNumber))
	                    UNION ALL  
	                    SELECT [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([ProTotQty],0) AS [BeforeStock],ISNULL([ProTotQty],0) AS [EndStock]  
	                    FROM [Stock].[dbo].[TPRProductsDeactivated]  
	                    WHERE (ISNULL([ProNumY],'') IN (SELECT [UnitNumber] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE [TakeOrderNumber] = @TakeOrderNumber))
	                    UNION ALL  
	                    SELECT [OldProNumy] AS [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([Stock],0) AS [BeforeStock],ISNULL([Stock],0) AS [EndStock]  
	                    FROM [Stock].[dbo].[TPRProducts] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]  
	                    WHERE B.[OldProNumy] IN (SELECT [UnitNumber] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE [TakeOrderNumber] = @TakeOrderNumber)
	                    UNION ALL  
	                    SELECT [OldProNumy] AS [ProNumY],[ProNumYP],[ProNumYC],[ProName],[ProPacksize],[ProQtyPCase],[Sup1],CONVERT(DATE,GETDATE()) AS [TransDate],ISNULL([Stock],0) AS [BeforeStock],ISNULL([Stock],0) AS [EndStock]  
	                    FROM [Stock].[dbo].[TPRProductsDeactivated] AS A INNER JOIN [Stock].[dbo].[TPRProductsOldCode] AS B ON A.[ProID] = B.[ProId]  
	                    WHERE B.[OldProNumy] IN (SELECT [UnitNumber] FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders] WHERE [TakeOrderNumber] = @TakeOrderNumber)
                    ) v INNER JOIN [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill] AS x ON v.[ProNumY] = x.[UnitNumber];

                    DELETE FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_Dutchmill]
                    --WHERE ([CusNum] = @vCusNum) AND ([DelToId] = @vDeltoId) AND (CONVERT(DATE,[DateRequired]) = @vRequiredDate);
                    WHERE [Id] IN ({6});";
                query = string.Format(query, DatabaseName, vCusNum, vDeltoId, vRequiredDate, vInvNo, RelatedKey, vId, vPONumber, DBNull.Value.Equals(vDeliveryDate) ? "" : string.Format("{0:yyyy-MM-dd}", vDeliveryDate), Initialized.R_MessageAlert.Trim());
                RCom.CommandText = query;
                RCom.ExecuteNonQuery();
                if (Initialized.R_MessageAlert.Trim() != "")
                {
                    query = $@"
        DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{vInvNo}';
        DECLARE @Message AS NVARCHAR(100) = N'{Initialized.R_MessageAlert.Trim()}';
        INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrderAlertToQsDelivery]([InvNo],[CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],[Message],[RegisterDate])
        SELECT [TakeOrderNumber],[CusNum],[CusName],[DelTo],[DateOrd],[DateRequired],@Message,GETDATE()
        FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders]
        WHERE [TakeOrderNumber] = @TakeOrderNumber;
    ";
                    query = string.Format(query, DatabaseName, vInvNo, Initialized.R_MessageAlert.Trim());
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                }

                if (Initialized.R_DocumentNumber.Trim() != "" && Initialized.R_LineCode.Trim() != "" && Initialized.R_DeptCode.Trim() != "")
                {
                    query = @"
            DECLARE @TakeOrderNumber AS NVARCHAR(25) = N'{1}';
                        DECLARE @CusNum AS NVARCHAR(8) = N'{2}';
                        DECLARE @DocumentNumber AS NVARCHAR(20) = N'{3}';
                        DECLARE @LineCode AS NVARCHAR(14) = N'{4}';
                        DECLARE @DeptCode AS NVARCHAR(14) = N'{5}';
                        INSERT INTO [Stock].[dbo].[TPRDeliveryTakeOrder_ForAEON]([SupervisorID],[CusNum],[DocumentNumber],[LineCode],[DeptCode],[TakeOrderID],[DeliveryID])
                        VALUES(NULL,@CusNum,@DocumentNumber,@LineCode,@DeptCode,@TakeOrderNumber,NULL);
           
    ";
                    query = string.Format(query, DatabaseName, vInvNo, CusNum, Initialized.R_DocumentNumber.Trim(), Initialized.R_LineCode.Trim(), Initialized.R_DeptCode.Trim());
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                }

                RCom.CommandText = "UPDATE [Stock].[dbo].[TPRDeliveryTakeOrdPrintInvNo] SET [IsBusy] = 0,[PrintInvNo] = ([PrintInvNo] + 1);";
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();
                this.separateItemLoading.Enabled = true;
                MessageBox.Show("The processing has been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TimerTakeOrderLoading.Enabled = true;
                this.TimerDisplayLoading.Enabled = true;





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
}
