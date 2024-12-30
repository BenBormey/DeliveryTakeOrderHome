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

namespace DeliveryTakeOrder.Interfaces.delto
{
    public partial class FrmClassSetting : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private SwitchKeyboardLanguage Key = new SwitchKeyboardLanguage();
        private DateTime otodate;
        private PrintToPrinter Printer = new PrintToPrinter();
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
        private LocalReport Report;
        private ReportParameter RParameter;
        private string DatabaseName;
        private string oquery;
        private DataTable olists;

        public FrmClassSetting()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }

        private void FrmClassSetting_Load(object sender, EventArgs e)
        {
            this.CmbClassType.Enabled = true;
            this.displayloading.Enabled = true;
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

        private void FrmClassSetting_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CmbClassType.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any customer!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbClassType.Focus();
                return;
            }
            else if (TxtClassName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the zone!", "Enter Zone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtClassName.Focus();
                return;
            }
            else
            {
                string oClassType = "";
                if(CmbClassType.SelectedValue is DataRowView || CmbClassType.SelectedValue  == null)
                {
                    oClassType = "";
                }
                else
                {
                    if(CmbClassType.Text.Trim() == "")
                    {
                        oClassType = "";

                    }
                    else
                    {
                        oClassType = CmbClassType.SelectedValue.ToString();

                    }
                }

                string oClassName = string.IsNullOrWhiteSpace(TxtClassName.Text.Trim()) ? "" : TxtClassName.Text.Trim();
                oquery = @"  DECLARE @oClassName AS NVARCHAR(100) = N'{1}';
                            SELECT *
                            FROM [Stock].[dbo].[TPRDelto_Class]
                            WHERE (ISNULL([ClassName],N'') = @oClassName);";
                oquery = string.Format(oquery, DatabaseName, oClassName);
                olists = Data.Selects(oquery, Initialized.GetConnectionType(Data, App));
                if (olists != null) {

                    if (olists.Rows.Count > 0) {

                        MessageBox.Show("The Class Name is existed already.", "Duplicated Class Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtClassName.SelectionStart = 0;
                        TxtClassName.SelectionLength = TxtClassName.TextLength;
                        TxtClassName.Focus();
                    }
                }
                oquery = @"  DECLARE @oClassType AS NVARCHAR(10) = N'{1}';
                            DECLARE @oClassName AS NVARCHAR(100) = N'{2}';
                            IF NOT EXISTS(SELECT * FROM [Stock].[dbo].[TPRDelto_Class] WHERE (ClassName = @oClassName))
                            BEGIN
	                            INSERT INTO [Stock].[dbo].[TPRDelto_Class]([ClassName],[ClassType],[SetDate])
	                            VALUES(@oClassName,@oClassType,GETDATE());
                            END
                            ELSE
                            BEGIN
	                            UPDATE v
	                            SET v.[ClassType] = @oClassType
	                            FROM [Stock].[dbo].[TPRDelto_Class] v
	                            WHERE (v.ClassName = @oClassName);
                            END";
                oquery = string.Format(oquery, DatabaseName, oClassType, oClassName);
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    RCom.CommandText = oquery;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
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

        }

        private void DgvShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DgvShow.RowCount <= 0) return;
                if (MessageBox.Show("Are you sure, you want to delete this?(Yes/No)", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                oquery = @"
        DECLARE @vId AS DECIMAL(18,0) = {1};
        INSERT INTO [Stock].[dbo].[TPRDelto_Class.Deleted]([ClassName],[SetDate],[ClassType],[DeletedDate])
        SELECT [ClassName],[SetDate],[ClassType],GETDATE()
        FROM [Stock].[dbo].[TPRDelto_Class]
        WHERE ([ID] = @vId);

        DELETE FROM [Stock].[dbo].[TPRDelto_Class]
        WHERE ([ID] = @vId);
    ";
                oquery = string.Format(oquery, DatabaseName, DgvShow.Rows[DgvShow.CurrentRow.Index].Cells["Id"].Value);
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;
                    RCom.CommandText = oquery;
                    RCom.ExecuteNonQuery();
                    RTran.Commit();
                    RCon.Close();
                    MessageBox.Show("Deleting have been completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DgvShow.Rows.Remove(DgvShow.Rows[DgvShow.CurrentRow.Index]);
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
                RExcel = (Microsoft.Office.Interop.Excel.Application)Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
                RBook = RExcel.Workbooks.Add(Type.Missing);
                RSheet = (Microsoft.Office.Interop.Excel.Worksheet)RBook.Worksheets[1];
                RSheet.Range["A:Z"].Font.Name = "Arial";
                RSheet.Range["A:Z"].Font.Size = 8;
                RSheet.Range["A1"].Value = "Class List";
                RSheet.Range["A2"].Value = "Export Date : " + DateTime.Now.ToString("dd-MMM-yy");
                RSheet.Range["A4:J4"].Font.Bold = true;
                RSheet.Range["A4"].Value = "Nº";
                RSheet.Range["B4"].Value = "Class Name";
                RSheet.Range["C4"].Value = "Class Type";
                RSheet.Range["D4"].Value = "Created Date";
                RSheet.Range["B:B"].NumberFormat = "@";
                RSheet.Range["D:D"].NumberFormat = "dd-MMM-yy hh:mm:ss AM/PM";
                long QsRow = 5;
                foreach (DataGridViewRow QsDataRow in DgvShow.Rows)
                {
                    RSheet.Range["A" + QsRow].Value = (QsRow - 4);
                    RSheet.Range["B" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ClassName"].Value) ? "" : QsDataRow.Cells["ClassName"].Value;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["ClassType"].Value) ? "" : QsDataRow.Cells["ClassType"].Value;
                    RSheet.Range["D" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["SetDate"].Value) ? "" : QsDataRow.Cells["SetDate"].Value;
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

        private void classtypeloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.classtypeloading.Enabled = false;

            oquery = @"
    WITH v AS (
        SELECT [ClassType]
        FROM [Stock].[dbo].[TPRDelto_Class]
        WHERE (ISNULL([ClassType], N'') <> N'')
        GROUP BY [ClassType]
    )
    SELECT v.[ClassType]
    FROM v
    GROUP BY v.[ClassType]
    ORDER BY v.[ClassType];
";

            oquery = string.Format(oquery, DatabaseName);
            olists = Data.Selects(oquery, Initialized.GetConnectionType(Data, App));
            DataSources(CmbClassType, olists, "ClassType", "ClassType");

            this.Cursor = Cursors.Default;

        }

        private void displayloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.displayloading.Enabled = false;

            oquery = @"
    SELECT [ID],[ClassName],[ClassType],[SetDate]
    FROM [Stock].[dbo].[TPRDelto_Class]
    ORDER BY [ClassName];
";

            oquery = string.Format(oquery, DatabaseName);
            olists = Data.Selects(oquery, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = olists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row : {0}", DgvShow.RowCount);
            this.Cursor = Cursors.Default;

        }
    }
}
