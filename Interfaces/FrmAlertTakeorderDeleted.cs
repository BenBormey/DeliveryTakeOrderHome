using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DeliveryTakeOrder.Model;
using Google.Protobuf.Collections;
using System;
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

        public FrmAlertTakeorderDeleted()
        {
            InitializeComponent();
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
            query_ = @"WITH o
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
    WHERE (DATEDIFF(DAY, CONVERT(DATE, v.deleteddate), GETDATE()) <= 90)
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
    WHERE (DATEDIFF(DAY, CONVERT(DATE, v.deleteddate), GETDATE()) <= 90))
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

            query_ = string.Format(query_, DatabaseName);
            lists_ = this.Data.Selects(query_, Initialized.GetConnectionType(Data, App));
            this.vDataList_Detail = GetDataTableToObject<cls_detail_takeorder>(this.lists_);

            query_ = @"WITH v
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
            this.query_ = string.Format(this.query_, this.DatabaseName);
            this.lists_ = this.Data.Selects(this.query_, Initialized.GetConnectionType(this.Data, this.App));
            //this.vDataList_Main = GetDataTableToObject<cls_main_takeorder>(this.lists_);
            //this.gridcontroller.DataSource = this.vDataList_Main;
            //this.gridcontroller.Refresh();
            //this.lblcountrow.Text = string.Format("Count Row : {0}", this.gridcontroller.MainView.RowCount);
            //this.Cursor = Cursors.Default;



        }
    }
}
