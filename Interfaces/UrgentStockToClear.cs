using DeliveryTakeOrder.Declares;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces
{
    public partial class UrgentStockToClear : Form
    {
        RMDB db;
        public bool IsShow = false;
        public UrgentStockToClear()
        {
            db = AppSetting.DBMain;
            InitializeComponent();
            BindingSource bsData = new BindingSource(this.QueryUrgentStock(), null);
            this.xgcUrgent.DataSource = bsData;
           
            xdgvUrgent.ExpandAllGroups();

            if (bsData.Count > 0)
            {
                IsShow = true;
            }

        }
        public DataTable QueryUrgentStock()
        {
            string sqlQuery = @"
SELECT *
INTO #team_
FROM DBUNTWHOLESALECOLTD.dbo.TblSetSaleManagerToSupplier s;

UPDATE x
SET [x].[TeamName] = N'Alpha',
    [x].[TeamID] = 1,
    [x].[SaleManagerID] = 1
FROM #team_ x
WHERE ([x].[TeamName] <> N'Charlie');

UPDATE x
SET [x].[TeamName] = N'Charlie',
    [x].[TeamID] = 2,
    [x].[SaleManagerID] = 2
FROM #team_ x
WHERE ([x].[TeamName] = N'Charlie');

SELECT LEFT(P.Sup1, 8) AS SupNum,
       SM.SupName,
       P.ProNumY,
       P.ProName,
       P.ProPacksize,
       P.ProQtyPCase,
       L.location,
       L.level,
       W.LocName,
       W.Expiry,
       W.QtyOnHand,
       W.QtyOnHand / P.ProQtyPCase AS QtyOnHandCtn
FROM DBWarehouses.dbo.[.tbllocation.not.for.sell] AS L
    INNER JOIN Stock.dbo.TPRWarehouseStockIn AS W
        ON W.LocName = L.locationname
           AND L.level = W.LocationLevel
           AND W.Location = L.location
    INNER JOIN Stock.dbo.TPRProducts AS P
        ON P.ProNumY = W.ProNumy
    INNER JOIN
    (
        SELECT SupNum,
               SupName
        FROM #team_
        WHERE SaleManagerID = @SaleManagerID
    ) AS SM
        ON SM.SupNum = LEFT(P.Sup1, 8);

DROP TABLE #team_;
";

            sqlQuery = string.Format(sqlQuery, AppSetting.SaleManagerID);
            return db.GetDataTable(sqlQuery);
        }


        private void UrgentStockToClear_Load(object sender, EventArgs e)
        {
            //FrmDelto
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog frmSave = new SaveFileDialog();
            frmSave.Filter = "Excel (*.xlsx)|*.xlsx";
            frmSave.FileName = "Urgent Stock to Clear";
            frmSave.RestoreDirectory = true;

            if (frmSave.ShowDialog(this) == DialogResult.OK)
            {
                XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx
                {
                    AllowGrouping = DevExpress.Utils.DefaultBoolean.True,
                    FitToPrintedPageWidth = true,
                    SheetName = "Urgent Stock to Clear"
                };

                xgcUrgent.ExportToXlsx(frmSave.OpenFile(), advOptions);
            }

        }
    }
}
