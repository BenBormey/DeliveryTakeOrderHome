using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.CodeParser;
using DevExpress.PivotGrid.OLAP;
using DevExpress.XtraRichEdit.Import.Doc;
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
    public partial class FrmZoneSetting : Form
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

        public FrmZoneSetting()
        {
            InitializeComponent();
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }

        private void FrmZoneSetting_Load(object sender, EventArgs e)
        {
            this.cityloading.Enabled = true;
            this.displayloading.Enabled = true;

        }
        private void DataSources(ComboBox ComboBoxName, DataTable DTable, string DisplayMember, string ValueMember)
        {
            ComboBoxName.DataSource = DTable;
            ComboBoxName.DisplayMember = DisplayMember;
            ComboBoxName.ValueMember = ValueMember;
            ComboBoxName.SelectedIndex = -1;
        }

        private void FrmZoneSetting_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_CompanyName.ToUpper();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CmbCity.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select any customer!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbCity.Focus();
                return;
            }
            else if (TxtZone.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the zone!", "Enter Zone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtZone.Focus();
                return;
            }
            else
            {
                string oCity = "";
                if (CmbCity.SelectedValue is DataRowView || CmbCity.SelectedValue == null)
                {
                    oCity = "";
                }
                else
                {
                    if (CmbCity.Text.Trim() == "")
                    {
                        oCity = "";
                    }
                    else
                    {
                        oCity = CmbCity.SelectedValue.ToString();
                    }
                }

                string oZone = string.IsNullOrWhiteSpace(TxtZone.Text.Trim()) ? "" : TxtZone.Text.Trim();

                oquery = @"
        DECLARE @vZone AS NVARCHAR(50) = N'{1}';
        SELECT *
        FROM [Stock].[dbo].[TPREstimateSalesForecast_Zone]
        WHERE (ISNULL([Zone], N'') = @vZone);
    ";
                oquery = string.Format(oquery, DatabaseName, oZone);
                olists = Data.Selects(oquery, Initialized.GetConnectionType(Data, App));
                if (olists != null && olists.Rows.Count > 0)
                {
                    MessageBox.Show("The Zone is existed already.", "Duplicated Zone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtZone.SelectionStart = 0;
                    TxtZone.SelectionLength = TxtZone.TextLength;
                    TxtZone.Focus();
                    return;
                }

                oquery = @"
        DECLARE @vZone AS NVARCHAR(50) = N'{1}';
        DECLARE @vCity AS NVARCHAR(100) = N'{2}';
        IF NOT EXISTS(SELECT * FROM [Stock].[dbo].[TPREstimateSalesForecast_Zone] WHERE (Zone = @vZone))
        BEGIN
            INSERT INTO [Stock].[dbo].[TPREstimateSalesForecast_Zone]([Zone],[City],[RegisterDate])
            VALUES(@vZone, @vCity, GETDATE());
        END
        ELSE
        BEGIN
            UPDATE v
            SET v.[City] = @vCity
            FROM [Stock].[dbo].[TPREstimateSalesForecast_Zone] v
            WHERE (v.Zone = @vZone);
        END
    ";
                oquery = string.Format(oquery, DatabaseName, oZone, oCity);
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
        INSERT INTO [Stock].[dbo].[TPREstimateSalesForecast_Zone.Deleted]([Zone],[City],[RegisterDate],[DeletedDate])
        SELECT [Zone],[City],[RegisterDate],GETDATE()
        FROM [Stock].[dbo].[TPREstimateSalesForecast_Zone]
        WHERE ([ID] = @vId);

        DELETE FROM [Stock].[dbo].[TPREstimateSalesForecast_Zone]
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
            if (DgvShow.RowCount > 0) {

                Microsoft.Office.Interop.Excel.Application RExcel;
                Microsoft.Office.Interop.Excel.Workbook RBook;
                Microsoft.Office.Interop.Excel.Worksheet RSheet;
                RExcel = (Microsoft.Office.Interop.Excel.Application)Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
                RBook = RExcel.Workbooks.Add(Type.Missing);
                RSheet = (Microsoft.Office.Interop.Excel.Worksheet)RBook.Worksheets[1];
                RSheet.Range["A:Z"].Font.Name = "Arial";
                RSheet.Range["A:Z"].Font.Size = 8;
                RSheet.Range["A1"].Value = "Zone List";
                RSheet.Range["A2"].Value = "Export Date : " + DateTime.Now.ToString("dd-MMM-yy");
                RSheet.Range["A4:J4"].Font.Bold = true;
                RSheet.Range["A4"].Value = "Nº";
                RSheet.Range["B4"].Value = "Zone";
                RSheet.Range["C4"].Value = "City";
                RSheet.Range["D4"].Value = "Created Date";
                RSheet.Range["B:B"].NumberFormat = "@";
                RSheet.Range["D:D"].NumberFormat = "dd-MMM-yy hh:mm:ss tt";
                long QsRow = 5;
                foreach (DataGridViewRow QsDataRow in DgvShow.Rows)
                {
                    RSheet.Range["A" + QsRow].Value = (QsRow - 4);
                    RSheet.Range["B" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["Zone"].Value) ? "" : QsDataRow.Cells["Zone"].Value;
                    RSheet.Range["C" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["City"].Value) ? "" : QsDataRow.Cells["City"].Value;
                    RSheet.Range["D" + QsRow].Value = DBNull.Value.Equals(QsDataRow.Cells["RegisterDate"].Value) ? "" : QsDataRow.Cells["RegisterDate"].Value;
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

        private void cityloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.cityloading.Enabled = false;
            oquery = @" WITH v AS (
	                        SELECT N'Phnom Penh' [City]
	                        UNION ALL
	                        SELECT [City]
	                        FROM [{0}].[dbo].[TblCities]
	                        GROUP BY [City]
                        )
                        SELECT v.[City]
                        FROM v
                        GROUP BY v.[City]
                        ORDER BY v.[City];";
            oquery = string.Format(oquery, DatabaseName);
            olists = Data.Selects(oquery, Initialized.GetConnectionType(Data, App));
            DataSources(CmbCity, olists, "City", "City");
            this.Cursor = Cursors.Default;
        }

        private void displayloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.displayloading.Enabled = false;
            oquery = @"   SELECT *
                        FROM [Stock].[dbo].[TPREstimateSalesForecast_Zone] 
                        ORDER BY CONVERT(DECIMAL,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([Zone],N'A',N''),N'B',N''),N'C',N''),N'D',N''),N'E',N''),N'F',N''),N'G',N''),N'H',N''),N'I',N''),N'J',N''),N'K',N''),N'L',N''),N'M',N''),N'N',N''),N'O',N''),N'P',N''),N'Q',N''),N'R',N''),N'S',N''),N'T',N''),N'U',N''),N'V',N''),N'W',N''),N'X',N''),N'Y',N''),N'Z',N''));";
            
            oquery =string.Format(oquery, DatabaseName);
            olists = Data.Selects(oquery, Initialized.GetConnectionType(Data, App));
            DgvShow.DataSource = olists;
            DgvShow.Refresh();
            LblCountRow.Text = string.Format("Count Row : {0}", DgvShow.Rows.Count);  
            this.Cursor= Cursors.Default;

        
        
        }
    }
}
