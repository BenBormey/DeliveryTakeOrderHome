﻿using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DeliveryTakeOrder.Interfaces.Teamleader;
using DeliveryTakeOrder.Model;
using DevExpress.XtraGrid.Views.Grid;
using Google.Protobuf.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class FrmAlertTakeorderDeleted : Form
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private DateTime Todate;
        private string DatabaseName;
        private string query_;
        private DataTable lists_;
        private SqlConnection RCon;
        private SqlCommand RCom = new SqlCommand();
        private SqlTransaction RTran;
        private List<cls_main_takeorder> vDataList_Main;
        private List<cls_detail_takeorder> vDataList_Detail;
        private MDI menuMDI { get; set; }
        private warehouseNameModel warehouseName;
        public FrmAlertTakeorderDeleted(MDI menuMDI,warehouseNameModel warehousesName)
        {
            InitializeComponent();
        
            this.menuMDI = menuMDI;
            this.warehouseName = warehousesName;
            this.Text = string.Format("Delivery Take Order - {0}", this.warehouseName.warehouseName).ToUpper().Trim();


            this.LodingInitialized();
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.Loading.Enabled = true;




        }
        public void LodingInitialized()
        {

            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);


        }

        //private void FrmAlertTakeorderDeleted_Load(object sender, EventArgs e)
        //{
        //   
        //}


        public List<T> GetDataTableToObject<T>(DataTable pDataTable)
        {
            List<T> ls = new List<T>();
            T o;

            foreach (DataRow dr in pDataTable.Rows)
            {
                o = Activator.CreateInstance<T>();
                object value;
                foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    try
                    {
                        if (pDataTable.Columns.Contains(p.Name))
                        {
                            Type propType = p.PropertyType;
                            value = DBNull.Value.Equals(dr[p.Name]) ? null : Convert.ChangeType(dr[p.Name], propType);
                            p.SetValue(o, value, null);
                        }
                    }
                    catch (Exception)
                    {
                        // Handle exception
                    }
                }
                ls.Add(o);
            }
            return ls;
        }

        private void FrmAlertTakeorderDeleted_Load(object sender, EventArgs e)
        {
            this.Loading.Enabled = true;
        }

        private void Loading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Loading.Enabled = false;
            this.Todate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data, App));
            this.query_ = @"DECLARE @warehouseId UNIQUEIDENTIFIER = CAST('{1}' AS UNIQUEIDENTIFIER);
WITH o
AS (SELECT v.[takeordernumber],
           v.[pickingnumber],
           v.[ponumber],
           v.[barcode],
           v.[proname],
           v.[size],
           v.[qtypercase],
           v.[pcsfree],
           v.[pcsorder],
           v.[packorder],
           v.[ctnorder],
           v.[totalpcsorder]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish.deleted] v
    WHERE ([warehouseId] = @warehouseId) AND (DATEDIFF(DAY, CONVERT(DATE, v.deleteddate), GETDATE()) <= 90)
    UNION ALL
    SELECT v.[takeordernumber],
           v.[pickingnumber],
           v.[ponumber],
           v.[barcode],
           v.[proname],
           v.[size],
           v.[qtypercase],
           v.[pcsfree],
           v.[pcsorder],
           v.[packorder],
           v.[ctnorder],
           v.[totalpcsorder]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.finish.deleted] v
    WHERE ([warehouseId] = @warehouseId) AND (DATEDIFF(DAY, CONVERT(DATE, v.deleteddate), GETDATE()) <= 90))
SELECT o.[takeordernumber],
       o.[pickingnumber],
       o.[ponumber],
       o.[barcode],
       o.[proname],
       o.[size],
       o.[qtypercase],
       SUM(o.[pcsfree]) [pcsfree],
       SUM(o.[pcsorder]) [pcsorder],
       SUM(o.[packorder]) [packorder],
       SUM(o.[ctnorder]) [ctnorder],
       SUM(o.[totalpcsorder]) [totalpcsorder]
FROM o
GROUP BY o.[takeordernumber],
         o.[pickingnumber],
         o.[ponumber],
         o.[barcode],
         o.[proname],
         o.[size],
         o.[qtypercase];";

            query_ = string.Format(query_, DatabaseName, this.warehouseName.id);
            lists_ = this.Data.Selects(query_, Initialized.GetConnectionType(Data, App));
            this.vDataList_Detail = GetDataTableToObject<cls_detail_takeorder>(this.lists_);

            query_ = @"DECLARE @warehouseId UNIQUEIDENTIFIER = CAST('{1}' AS UNIQUEIDENTIFIER);
WITH v
AS (SELECT i.[id],
           i.[takeordernumber],
           o.[pickingnumber],
           o.[pickingdate],
           o.[cusnum],
           o.[cusname],
           o.[deltoid],
           o.[delto],
           o.[dateorder],
           o.[daterequired],
           o.[deliverydate],
           i.[reason],
           i.[createddate]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.waiting.approve.clearing] i
        INNER JOIN [DBPickers].[dbo].[.tbldeliverytakeorders.dry.finish.deleted] o
            ON (i.[takeordernumber] = o.[takeordernumber])
    WHERE (o.[warehouseId] = @warehouseId)
    GROUP BY i.[id],
             i.[takeordernumber],
             o.[pickingnumber],
             o.[pickingdate],
             o.[cusnum],
             o.[cusname],
             o.[deltoid],
             o.[delto],
             o.[dateorder],
             o.[daterequired],
             o.[deliverydate],
             i.[reason],
             i.[createddate]
    UNION ALL
    SELECT i.[id],
           i.[takeordernumber],
           o.[pickingnumber],
           o.[pickingdate],
           o.[cusnum],
           o.[cusname],
           o.[deltoid],
           o.[delto],
           o.[dateorder],
           o.[daterequired],
           o.[deliverydate],
           i.[reason],
           i.[createddate]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.waiting.approve.clearing] i
        INNER JOIN [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.finish.deleted] o
            ON (i.[takeordernumber] = o.[takeordernumber])
    WHERE (o.[warehouseId] = @warehouseId)
    GROUP BY i.[id],
             i.[takeordernumber],
             o.[pickingnumber],
             o.[pickingdate],
             o.[cusnum],
             o.[cusname],
             o.[deltoid],
             o.[delto],
             o.[dateorder],
             o.[daterequired],
             o.[deliverydate],
             i.[reason],
             i.[createddate])
SELECT v.[id],
       v.[takeordernumber],
       v.[pickingnumber],
       v.[pickingdate],
       v.[cusnum],
       v.[cusname],
       v.[deltoid],
       v.[delto],
       v.[dateorder],
       v.[daterequired],
       v.[deliverydate],
       v.[reason],
       v.[createddate]
FROM v
ORDER BY v.[createddate] DESC;";
            this.query_ = string.Format(this.query_, this.DatabaseName, this.warehouseName.id);
            this.lists_ = this.Data.Selects(this.query_, Initialized.GetConnectionType(this.Data, this.App));
            this.vDataList_Main = GetDataTableToObject<cls_main_takeorder>(this.lists_);
            this.gridcontroller.DataSource = this.vDataList_Main;
            this.gridcontroller.Refresh();
            this.lblcountrow.Text = string.Format("Count Row : {0}", this.gridcontroller.MainView.RowCount);
            this.Cursor = Cursors.Default;




        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string value = "";
            foreach (int i in (IEnumerable)this.dviewer_main.GetSelectedRows())
            {
                value += string.Format("{0},", Convert.ToDecimal(this.dviewer_main.GetRowCellValue(i, "id")));
            }

            if(value.Trim().Equals("") == true)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select any row which you want to stop alert.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            value += string.Format("{0}", 0);

            Initialized.R_CorrectPassword = false;
            FrmPasswordContinues passwordGUI = new FrmPasswordContinues();

            passwordGUI.R_PasswordPermission = "'Managing Director','MD Assistant','IT Manager','Office Manager'";
            passwordGUI.ShowDialog();
            if(Initialized.R_CorrectPassword == false)
            {
                RCon = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App)));
                RCon.Open();
                RTran = RCon.BeginTransaction();
                try
                {
                    RCom.Transaction = RTran;
                    RCom.Connection = RCon;
                    RCom.CommandType = CommandType.Text;

                    this.query_ = @"DECLARE @ipaddress AS NVARCHAR(100) = N'{2}';
DECLARE @pcname AS NVARCHAR(100) = N'{3}';
INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dry.waiting.approve.clearing.finish]
(
[takeordernumber],
[reason],
[createddate],
[pcname],
[ipaddress],
[approveddate]
)
SELECT [takeordernumber],
    [reason],
    [createddate],
    @pcname,
    @ipaddress,
    GETDATE()
FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.waiting.approve.clearing]
WHERE ([id] IN ({1}));

DELETE FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.waiting.approve.clearing]
WHERE ([id] IN ({1}));

INSERT INTO [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.waiting.approve.clearing.finish]
(
[takeordernumber],
[reason],
[createddate],
[pcname],
[ipaddress],
[approveddate]
)
SELECT [takeordernumber],
    [reason],
    [createddate],
    @pcname,
    @ipaddress,
    GETDATE()
FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.waiting.approve.clearing]
WHERE ([id] IN ({1}));

DELETE FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.waiting.approve.clearing]
WHERE ([id] IN ({1}));";


                    this.query_ = string.Format(this.query_, DatabaseName, value, Data.GetIPAddress, Data.GetComputerName);
                    RCom.CommandText = this.query_;
                    RCom.ExecuteNonQuery();
                    Application.DoEvents();
                    RTran.Commit();
                    RCon.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show("The processing have been finished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Loading.Enabled = true;


                }catch(SqlException ex)
                {
                    RTran.Rollback();
                    RCon.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }catch(Exception ex)
                {
                    RTran.Rollback();
            RCon.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }

        }

        private void dviewer_main_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            GridView view = (GridView)sender;
            cls_main_takeorder row_ = (cls_main_takeorder)view.GetRow(e.RowHandle);
            if (row_ != null)
            {
                e.IsEmpty = !this.vDataList_Detail.Any(x => x.pickingnumber == row_.pickingnumber);
            }

        }

        private void dviewer_main_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            GridView view = (GridView)sender;
            cls_main_takeorder row_ = (cls_main_takeorder)view.GetRow(e.RowHandle);
            if (row_ != null)
            {
                e.ChildList = this.vDataList_Detail.Where(x => x.pickingnumber == row_.pickingnumber).ToList();
            }

        }

        private void dviewer_main_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;

        }

        private void dviewer_main_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "DetailView";
        }
    }
}
