using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.CodeParser;
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
using static DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmDeltoListForDutchmillPO : Form
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
        

        public FrmDeltoListForDutchmillPO()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = String.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);



        }

        private void FrmDeltoListForDutchmillPO_Load(object sender, EventArgs e)
        {
            Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            TimerDeltoLoading.Enabled = true;
           
        }
        private void DataSources(ComboBox comboBoxName, DataTable dTable, string displayMember, string valueMember)
        {
            comboBoxName.DataSource = dTable;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.ValueMember = valueMember;
            comboBoxName.SelectedIndex = -1;
        }

        private void FrmDeltoListForDutchmillPO_Activated(object sender, EventArgs e)
        {
            TxtId.Focus();
        }

        private void FrmDeltoListForDutchmillPO_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            if (DgvShow.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel.Application RExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook RBook = RExcel.Workbooks.Add(System.Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet RSheet = (Microsoft.Office.Interop.Excel.Worksheet)RBook.Worksheets[1];
                RSheet.Range["A:Z"].Font.Name = "Arial";
                RSheet.Range["D:J"].Font.Name = "Webdings";
                RSheet.Range["A4:Z4"].Font.Name = "Arial";
                RSheet.Range["A:Z"].Font.Size = 8;
                RSheet.Range["D:J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                RSheet.Range["D:J"].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                RSheet.Range["A1"].Value = "Delto List For Dutchmill P.O";
                RSheet.Range["A2"].Value = "Export Date : " + DateTime.Now.ToString("dd-MMM-yy");
                RSheet.Range["A4:K4"].Font.Bold = true;
                RSheet.Range["A4"].Value = "Nº";
                RSheet.Range["B4"].Value = "#";
                RSheet.Range["C4"].Value = "Delto";
                RSheet.Range["D4"].Value = "Monday";
                RSheet.Range["E4"].Value = "Tuesday";
                RSheet.Range["F4"].Value = "Wednesday";
                RSheet.Range["G4"].Value = "Thursday";
                RSheet.Range["H4"].Value = "Friday";
                RSheet.Range["I4"].Value = "Saturday";
                RSheet.Range["J4"].Value = "Sunday";
                RSheet.Range["K4"].Value = "Created Date";
                RSheet.Range["B:B"].NumberFormat = "@";
                RSheet.Range["K:K"].NumberFormat = "dd-MMM-yy hh:mm:ss AM/PM";

                long QsRow = 5;
                foreach (DataGridViewRow QsDataRow in DgvShow.Rows)
                {
                    RSheet.Range["A" + QsRow].Value = (QsRow - 4);
                    RSheet.Range["B" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["DeltoId"].Value) ? "" : QsDataRow.Cells["DeltoId"].Value;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["Delto"].Value) ? "" : QsDataRow.Cells["Delto"].Value;
                    RSheet.Range["D" + QsRow].Value = Convert.ToBoolean(DBNull.Value.Equals(QsDataRow.Cells["Monday"].Value) ? 0 : QsDataRow.Cells["Monday"].Value) ? "a" : "";
                    RSheet.Range["E" + QsRow].Value = Convert.ToBoolean(DBNull.Value.Equals(QsDataRow.Cells["Tuesday"].Value) ? 0 : QsDataRow.Cells["Tuesday"].Value) ? "a" : "";
                    RSheet.Range["F" + QsRow].Value = Convert.ToBoolean(DBNull.Value.Equals(QsDataRow.Cells["Wednesday"].Value) ? 0 : QsDataRow.Cells["Wednesday"].Value) ? "a" : "";
                    RSheet.Range["G" + QsRow].Value = Convert.ToBoolean(DBNull.Value.Equals(QsDataRow.Cells["Thursday"].Value) ? 0 : QsDataRow.Cells["Thursday"].Value) ? "a" : "";
                    RSheet.Range["H" + QsRow].Value = Convert.ToBoolean(DBNull.Value.Equals(QsDataRow.Cells["Friday"].Value) ? 0 : QsDataRow.Cells["Friday"].Value) ? "a" : "";
                    RSheet.Range["I" + QsRow].Value = Convert.ToBoolean(DBNull.Value.Equals(QsDataRow.Cells["Saturday"].Value) ? 0 : QsDataRow.Cells["Saturday"].Value) ? "a" : "";
                    RSheet.Range["J" + QsRow].Value = Convert.ToBoolean(DBNull.Value.Equals(QsDataRow.Cells["Sunday"].Value) ? 0 : QsDataRow.Cells["Sunday"].Value) ? "a" : "";
                    RSheet.Range["K" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["CreatedDate"].Value) ? "" : QsDataRow.Cells["CreatedDate"].Value;
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

        private void FrmDeltoListForDutchmillPO_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_DatabaseName.ToUpper();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerDeltoLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerDeltoLoading.Enabled = false;
            string query = @"
    SELECT [DefId] [Id],[DelTo]
    FROM [Stock].[dbo].[TPRDelto]
    ORDER BY [DelTo];
";
            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DataSources(CmbDelto, lists, "DelTo", "Id");
            BtnCancel_Click(BtnCancel, e);
            this.Cursor = Cursors.Default;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            App.ClearController(ChkMonday, ChkTuesday, ChkWednesday, ChkWednesday, ChkThursday, ChkFriday, ChkSaturday, ChkSaturday, ChkSunday, TxtId, CmbDelto);
            App.SetVisibleController(false, BtnUpdate, BtnCancel);
            App.SetVisibleController(true, BtnAdd);
            App.SetEnableController(true, DgvShow, BtnExportToExcel);
            TimerDisplayLoading.Enabled = true;

        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, $"{10}") ;

        }

        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            
            decimal id = string.IsNullOrWhiteSpace(TxtId.Text)
    ? 0
    : Convert.ToDecimal(TxtId.Text.Trim());

            CmbDelto.SelectedValue = id;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CmbDelto.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any delto!", "Select Delto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbDelto.Focus();
                return;
            }
            else
            {
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    string query = @"
            DECLARE @DeltoId AS DECIMAL(18,0) = {1};
            DECLARE @Delto AS NVARCHAR(100) = N'{2}';
            DECLARE @Monday AS BIT = {3};
            DECLARE @Tuesday AS BIT = {4};
            DECLARE @Wednesday AS BIT = {5};
            DECLARE @Thursday AS BIT = {6};
            DECLARE @Friday AS BIT = {7};
            DECLARE @Saturday AS BIT = {8};
            DECLARE @Sunday AS BIT = {9};

            IF NOT EXISTS (SELECT * FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting] WHERE [DeltoId] = @DeltoId)
            BEGIN
                INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting]([DeltoId],[Delto],[Monday],[Tuesday],[Wednesday],[Thursday],[Friday],[Saturday],[Sunday],[CreatedDate])
                VALUES(@DeltoId,@Delto,@Monday,@Tuesday,@Wednesday,@Thursday,@Friday,@Saturday,@Sunday,GETDATE());
            END
            ELSE
            BEGIN
                UPDATE [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting]
                SET [Delto]=@Delto,[Monday]=@Monday,[Tuesday]=@Tuesday,[Wednesday]=@Wednesday,[Thursday]=@Thursday,[Friday]=@Friday,[Saturday]=@Saturday,[Sunday]=@Sunday
                WHERE [DeltoId] = @DeltoId;
            END
        ";
                    query = string.Format(query, DatabaseName, CmbDelto.SelectedValue, CmbDelto.Text.Trim(),
                                          ChkMonday.Checked ? 1 : 0,
                                          ChkTuesday.Checked ? 1 : 0,
                                          ChkWednesday.Checked ? 1 : 0,
                                          ChkThursday.Checked ? 1 : 0,
                                          ChkFriday.Checked ? 1 : 0,
                                          ChkSaturday.Checked ? 1 : 0,
                                          ChkSunday.Checked ? 1 : 0);
                    RCom.CommandText = query;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    BtnCancel_Click(BtnCancel, e);
                    TxtId.Focus();
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

        private void TimerDisplayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerDisplayLoading.Enabled = false;
            string query = @"
    SELECT [Id],[DeltoId],[Delto],[Monday],[Tuesday],[Wednesday],[Thursday],[Friday],[Saturday],[Sunday],[CreatedDate]
    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting]
    ORDER BY [Delto];
";
            query = string.Format(query, DatabaseName);
            lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = lists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row : {0}", DgvShow.RowCount);
            this.Cursor = Cursors.Default;

        }

        private void DgvShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (DgvShow.RowCount <= 0) return;

            var currentRow = DgvShow.Rows[DgvShow.CurrentRow.Index];
            decimal id = Convert.ToDecimal(DBNull.Value.Equals(currentRow.Cells["Id"].Value) ? 0 : currentRow.Cells["Id"].Value);
            string delto = DBNull.Value.Equals(currentRow.Cells["Delto"].Value) ? "" : currentRow.Cells["Delto"].Value.ToString().Trim();

            if (MessageBox.Show($"Are you sure, you want to remove the {delto}?(Yes/No)", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
            RCon.Open();
            RTran = RCon.BeginTransaction();

            try
            {
                RCom.Transaction = RTran;
                RCom.Connection = RCon;
                RCom.CommandType = CommandType.Text;
                string query = @"
        DECLARE @Id AS DECIMAL(18,0) = {1};

        INSERT INTO [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting_Deleted]([DeltoId],[Delto],[Monday],[Tuesday],[Wednesday],[Thursday],[Friday],[Saturday],[Sunday],[CreatedDate],[DeletedDate])
        SELECT [DeltoId],[Delto],[Monday],[Tuesday],[Wednesday],[Thursday],[Friday],[Saturday],[Sunday],[CreatedDate],GETDATE()
        FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting]
        WHERE [Id] = @Id;

        DELETE FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill_DeltoSetting] 
        WHERE [Id] = @Id;
    ";
                query = string.Format(query, DatabaseName, id);
                RCom.CommandText = query;
                RCom.ExecuteNonQuery();
                RTran.Commit();
                RCon.Close();
                BtnCancel_Click(BtnCancel, e);
                TxtId.Focus();
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
