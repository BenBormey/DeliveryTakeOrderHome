using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.CodeParser;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
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
    public partial class FrmDelayPrintInvoicingForDutchmill : Form
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
        private CheckBox vCheckBox;

        public FrmDelayPrintInvoicingForDutchmill()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = String.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }

        private void FrmDelayPrintInvoicingForDutchmill_Load(object sender, EventArgs e)
        {
            this.loading.Enabled = true;

        }
        private void vCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerBox = (CheckBox)DgvShow.Controls.Find("Checker", true)[0];
            foreach (DataGridViewRow row in DgvShow.Rows)
            {
                row.Cells[0].Value = headerBox.Checked;
            }
        }


        private void DataSources(ComboBox comboBoxName, DataTable dTable, string displayMember, string valueMember)
        {
            comboBoxName.DataSource = dTable;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.ValueMember = valueMember;
            comboBoxName.SelectedIndex = -1;
        }
        private void DrawCheckBoxInDataGridView()
        {
            Rectangle rect = DgvShow.GetCellDisplayRectangle(0, -1, true);
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 10);
            vCheckBox = new CheckBox
            {
                BackColor = Color.Transparent,
                Name = "Checker",
                Size = new Size(18, 18),
                Location = rect.Location
            };
            vCheckBox.CheckedChanged += new EventHandler(vCheckBox_CheckedChanged);
            DgvShow.Controls.Add(vCheckBox);
        }

        private void loading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.loading.Enabled = false;
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.dtpfrom.Value = this.Todate;
            this.dtpto.Value = this.Todate.AddDays(7);
            this.itemsloading.Enabled = true;
            this.Cursor = Cursors.Default;

        }

        private void displayloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.displayloading.Enabled = false;
            query = @"with o as (
	select i.[ProNumY],i.[ProNumYP],i.[ProNumYC],i.[ProName],i.[KhmerNameUnicode] [KhmerName],i.[ProPacksize],i.[ProQtyPCase]
	from [Stock].[dbo].[TPRProducts] i
	union all
	select i.[ProNumY],i.[ProNumYP],i.[ProNumYC],i.[ProName],i.[KhmerNameUnicode] [KhmerName],i.[ProPacksize],i.[ProQtyPCase]
	from [Stock].[dbo].[TPRProductsDeactivated] i
	union all
	select o.[OldProNumy] [ProNumY],i.[ProNumYP],i.[ProNumYC],i.[ProName],i.[KhmerNameUnicode] [KhmerName],i.[ProPacksize],i.[ProQtyPCase]
	from [Stock].[dbo].[TPRProducts] i
	inner join [Stock].[dbo].[TPRProductsOldCode] o on (o.ProId = i.[ProID])
	union all
	select o.[OldProNumy] [ProNumY],i.[ProNumYP],i.[ProNumYC],i.[ProName],i.[KhmerNameUnicode] [KhmerName],i.[ProPacksize],i.[ProQtyPCase]
	from [Stock].[dbo].[TPRProductsDeactivated] i
	inner join [Stock].[dbo].[TPRProductsOldCode] o on (o.ProId = i.[ProID])
)
select o.*
into #items
from o;

SELECT i.[id]      
      ,i.[barcode]
	  ,o.[ProName],o.[ProPacksize]
      ,i.[lockfrom]
      ,i.[lockto]
      ,i.[createddate]
	  ,case when convert(date,i.[lockfrom]) <=convert(date,getdate())
  and convert(date,i.[lockto]) >=convert(date,getdate()) then 1 else 0 end [status]
  FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.delayprintinvoicing] i
  inner join #items o on ((isnull(i.[barcode],N'') = isnull(o.[ProNumY],N'')) and (isnull(i.[barcode],N'') <> N'') )
  or ((isnull(i.[barcode],N'') = isnull(o.[ProNumYP],N'')) and (isnull(o.[ProNumYP],N'') <> N'') )
  or ((isnull(i.[barcode],N'') = isnull(o.[ProNumYC],N'')) and (isnull(o.[ProNumYC],N'') <> N'') );

drop table #items;";

            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row : {0}", this.DgvShow.Rows.Count);
            this.Cursor = Cursors.Default;

        }

        private void itemsloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
           this.itemsloading.Enabled = false;
            query = @"SELECT [Barcode]
      ,[ProName]
      ,ISNULL([Barcode],N'') + SPACE(3) + ISNULL([ProName],N'') + SPACE(3) + ISNULL([Size],N'') [Display]      
  FROM [DBUNTWHOLESALECOLTD].[dbo].[TblDeliveryTakeOrders_DutchmillOrder]
  where isnull([Barcode],N'') not in (
  SELECT [barcode]
  FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.delayprintinvoicing]
  where convert(date,[lockfrom]) <=convert(date,getdate())
  and convert(date,[lockto]) >=convert(date,getdate())
  group by [barcode]
  )
  group by [Barcode]
      ,[ProName]
      ,ISNULL([Barcode],N'') + SPACE(3) + ISNULL([ProName],N'') + SPACE(3) + ISNULL([Size],N'')
order by [ProName];";


            query= string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            this.DataSources(CmbItems, lists, "Display", "Barcode");
            this.Cursor = Cursors.Default;
        }
        private void CmbRequiredDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.itemsloading.Enabled = true;
            this.displayloading.Enabled = true;
        }

        private void CmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.displayloading.Enabled=true;

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void CmbItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;

            if ((e.KeyChar >= (char)Keys.A && e.KeyChar <= (char)Keys.Z) || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
            {
                if (CmbItems.Text.Trim() != "" && !Information.IsNumeric(CmbItems.Text.Trim())) e.Handled = true;
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else
            {
                App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 15);
            }

        }

        private void CmbItems_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                CmbItems.SelectedText = "";
            }

            if (e.Control && e.KeyCode == Keys.V)
            {
                CmbItems.Text = Clipboard.GetText();
                CmbItems.SelectionStart = CmbItems.Text.Length;
                CmbItems.Focus();
            }

            if (e.KeyCode == Keys.Return)
            {
                if (CmbItems.Text.Trim() != "")
                {
                    ProductSearch(CmbItems);
                }
            }

        }
        private void ProductSearch(ComboBox comboName)
        {
            if (CmbItems.Items.Count <= 0) return;

            string rBarcode = comboName.Text.Trim();
            if (rBarcode.Length > 13) rBarcode = rBarcode.Substring(0, 15).Trim();
            if (Information.IsNumeric(rBarcode.Trim())) rBarcode = string.Format("{0:0000000000000}", Convert.ToDecimal(rBarcode));

            DataTable tableProducts = (DataTable)comboName.DataSource;
            for (int i = 0; i < tableProducts.Rows.Count; i++)
            {
                string displayItem = tableProducts.Rows[i][comboName.DisplayMember].ToString();
                string valueItem = tableProducts.Rows[i][comboName.ValueMember].ToString();
                valueItem = valueItem.Substring(0, rBarcode.Length).Trim();
                if (valueItem.Equals(rBarcode))
                {
                    comboName.SelectedIndex = i;
                    break;
                }
            }
        }

        private void BtnLockItems_Click(object sender, EventArgs e)
        {
            string iitems = "";
            if (CmbItems.SelectedValue is DataRowView || CmbItems.SelectedValue == null)
            {
                iitems = "";
            }
            else
            {
                if (CmbItems.Text.Trim().Equals(""))
                {
                    iitems = "";
                }
                else
                {
                    iitems = CmbItems.SelectedValue.ToString();
                }
            }

            if (iitems.Trim().Equals(""))
            {
                MessageBox.Show("Please select any items which you want to lock.", "Select Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbItems.Focus();
                return;
            }

            DateTime ifrom = dtpfrom.Value;
            DateTime ito = dtpto.Value;
            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();

            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                query = @"declare @ibarcode as nvarchar(15) = N'{1}';
declare @ilockfrom as date = '{2:yyyy-MM-dd}';
declare @ilockto as date = '{3:yyyy-MM-dd}';
INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.delayprintinvoicing]
           ([barcode]
           ,[lockfrom]
           ,[lockto]
           ,[createddate])
     VALUES
           (@ibarcode
           ,@ilockfrom
           ,@ilockto
           ,getdate());";

                query = string.Format(query, DatabaseName, iitems, ifrom, ito);
                RCom.CommandText = query;
                RCom.ExecuteNonQuery();
                Application.DoEvents();
                RTran.Commit();
                RCon.Close();
                MessageBox.Show("The Items have been lock. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
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

        private void dtpto_ValueChanged(object sender, EventArgs e)
        {
            if (Math.Abs((dtpfrom.Value - dtpto.Value).Days) > 7)
            {
                dtpto.Value = dtpfrom.Value.AddDays(7);
            }

        }

        private void dtpfrom_ValueChanged(object sender, EventArgs e)
        {
            if (Math.Abs((dtpfrom.Value - dtpto.Value).Days) > 7)
            {
                dtpto.Value = dtpfrom.Value.AddDays(7);
            }

        }

        private void DgvShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (DgvShow.Rows.Count <= 0) return;
            if (e.KeyCode != Keys.Delete) return;

            var currentRow = DgvShow.Rows[DgvShow.CurrentRow.Index];
            string oItems = DBNull.Value.Equals(currentRow.Cells["barcode"].Value) ? "" : currentRow.Cells["barcode"].Value.ToString();
            decimal oId = DBNull.Value.Equals(currentRow.Cells["id"].Value) ? 0 : Convert.ToDecimal(currentRow.Cells["id"].Value);

            if (MessageBox.Show($"Are you sure, you want to delete this item ( {oItems} )? (Yes/No)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();

            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                query = @"declare @id as decimal (18,0) = {1};
INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.delayprintinvoicing.Deleted]
           ([barcode]
           ,[lockfrom]
           ,[lockto]
           ,[createddate],[Deleteddate])
SELECT 
      [barcode]
      ,[lockfrom]
      ,[lockto]
      ,[createddate],getdate()
  FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.delayprintinvoicing]
  where [id] = @id;

  delete FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.delayprintinvoicing]
  where [id] = @id;";


                query = string.Format(query, DatabaseName, oId);
                RCom.CommandText = query;
                RCom.ExecuteNonQuery();
                Application.DoEvents();
                RTran.Commit();
                RCon.Close();
                this.itemsloading.Enabled = true;
                this.displayloading.Enabled = true;
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

        private void btnexporttoexcel_Click(object sender, EventArgs e)
        {
            if (DgvShow.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel.Application RExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook RBook = RExcel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet RSheet = (Microsoft.Office.Interop.Excel.Worksheet)RBook.Worksheets[1];
                RSheet.Range["A:Z"].Font.Name = "Arial";
                RSheet.Range["A:Z"].Font.Size = 8;
                RSheet.Range["A1"].Value = "Locked Item List";
                RSheet.Range["A2"].Value = "Export Date : " + this.Todate.ToString("dd-MMM-yy");
                RSheet.Range["A4"].Value = "Nº";
                RSheet.Range["B4"].Value = "Barcode";
                RSheet.Range["C4"].Value = "Description";
                RSheet.Range["D4"].Value = "Size";
                RSheet.Range["E4"].Value = "Lock Date ( From )";
                RSheet.Range["F4"].Value = "Lock Date ( To )";
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
                    RSheet.Range["B" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["barcode"].Value) ? "" : QsDataRow.Cells["barcode"].Value;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ProName"].Value) ? "" : QsDataRow.Cells["ProName"].Value;
                    RSheet.Range["D" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ProPacksize"].Value) ? "" : QsDataRow.Cells["ProPacksize"].Value;
                    RSheet.Range["E" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["lockfrom"].Value) ? "" : QsDataRow.Cells["lockfrom"].Value;
                    RSheet.Range["F" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["lockto"].Value) ? "" : QsDataRow.Cells["lockto"].Value;
                    RSheet.Range["G" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["createddate"].Value) ? "" : QsDataRow.Cells["createddate"].Value;
                    QsRow++;
                }

                RSheet.Columns.AutoFit();
                RSheet.Range["A:A"].ColumnWidth = 4;
                RExcel.Visible = true;

                App.ReleaseObject(RSheet);
                App.ReleaseObject(RBook);
                App.ReleaseObject(RExcel);
            }
            else
            {
                MessageBox.Show("No record to export to excel.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void DgvShow_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            bool oStatus = Convert.ToBoolean(DBNull.Value.Equals(DgvShow.Rows[e.RowIndex].Cells["status"].Value) ? 0 : DgvShow.Rows[e.RowIndex].Cells["status"].Value);
            if (!oStatus)
            {
                DgvShow.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                DgvShow.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }

        }
    }
}
