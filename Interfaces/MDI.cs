using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DeliveryTakeOrder.Interfaces.Teamleader;
using DeliveryTakeOrder.WS_Products_List;
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
    public partial class MDI : Form
    {
        private int childFormNumber = 0;
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private string DatabaseName;

        public string ProgramName { get; set; }

        private string query;
        private DataTable lists;

        private string vquery;
        private DataTable vlists;
        private msr_declares vs_  = new msr_declares();
        private warehouseNameModel warehouseName;
        public MDI(warehouseNameModel warehouseName)
        {
            //this call is required by the designer
            this.warehouseName = warehouseName;
            InitializeComponent();
            this.Text = string.Format("Delivert Take Order - {0}", this.warehouseName.warehouseName).ToUpper().Trim();
            // Add any initallization after the InitializeComponent() call.
            this.LoadingInitialized();

        }
        private void LoadingInitialized() {
            Initialized.LoadingInitialized(Data, App); 
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
            AppSetting.InitialCompany(); }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            string version_ = string.Empty;
            this.vquery = @"
DECLARE @app_id AS DECIMAL(18, 0) = {1};
SELECT [id],
       [app_id],
       [app_name],
       [app_version],
       [createddate]
FROM [DBUNTWHOLESALECOLTD].[dbo].[_tblversions] s
WHERE ([s].[app_id] = @app_id);
";
            this.vquery = string.Format(this.vquery, this.DatabaseName, this.vs_.app_id);
            
            this.vlists = Data.Selects(this.vquery, Initialized.GetConnectionType(Data, App)); 
           

            if (this.vlists != null && this.vlists.Rows.Count > 0)
            {
                version_ = this.vlists.Rows[0]["app_version"] == DBNull.Value
                           ? string.Empty
                           : this.vlists.Rows[0]["app_version"].ToString().Trim();
            }

            if (!version_.Trim().Equals(this.vs_.app_version.Trim()))
            {
                MessageBox.Show(
                    string.Format("Please contact IT Support to change the old version ( {0} ) to the new version ( {1} ).",
                                  this.vs_.app_version.Trim(), version_),
                    "Invalid Version",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            StringBuilder lBuilder = new StringBuilder(version_.ToUpper());
            int lStartIndex = lBuilder.Length - (lBuilder.Length % 1);
            for (int i = lStartIndex; i >= 1; i--)
            {
                lBuilder.Insert(i, ' ');
            }
            this.lblversion.Text = string.Format("V E R S I O N {0}", lBuilder.ToString());

            if (Initialized.CheckCompaniesExistOrNot(Data, App))
            {
                if (AppSetting.SaleManagerID == 2)
                {
                    this.ToolStripMenuItem5.Visible = true;
                    this.mnuurgentstocktoclear.Visible = true;
                    UrgentStockToClear frmUrgent = new UrgentStockToClear();
                    if (frmUrgent.IsShow) frmUrgent.ShowDialog(this);
                }
                else
                {
                    this.ToolStripMenuItem5.Visible = false;
                    this.mnuurgentstocktoclear.Visible = false;
                }

                this.WindowState = FormWindowState.Maximized;

                this.query = @"
WITH v AS
(
    SELECT [id],
           [takeordernumber],
           [reason],
           [createddate]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dry.waiting.approve.clearing]
    UNION ALL
    SELECT [id],
           [takeordernumber],
           [reason],
           [createddate]
    FROM [DBPickers].[dbo].[.tbldeliverytakeorders.dutchmill.waiting.approve.clearing]
)
SELECT v.*
FROM v;
";
                this.query = string.Format(this.query, this.DatabaseName);
                this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));

                if (this.lists != null && this.lists.Rows.Count > 0)
                {
                    FrmAlertTakeorderDeleted vFrm = new FrmAlertTakeorderDeleted(this,warehouseName)
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized
                    };
                    vFrm.Show();
                }
            }
            else
            {
                MessageBox.Show(
                    "Cannot find company name!\nPlease contact IT Assistant to create a company name!",
                    "Invalid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Environment.Exit(0);
            }
        }
        //public class msr_declares
        //{
        //    public decimal app_id { get; set; } = 10;
        //    public string app_name { get; set; } = "Qs Delivery Take Order (UNT Wholesale)";
        //    public string app_version { get; set; } = "2.4.4";
        //}

        private void MnuDeliveryTakeOrder__Click(object sender, EventArgs e)
        {
            //FrmDeliveryTakeOrder frmdeliverytakeorder   = new FrmDeliveryTakeOrder();
    
            //frmdeliverytakeorder.ShowDialog();
            FrmDeliveryTakeOrder frm = new FrmDeliveryTakeOrder(this, this.warehouseName)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized,
                IsDutchmill = false,
                ProgramName = ProgramName
            };
            frm.Show();
        }

        private void MnuDeliveryTakeOrder_Click(object sender, EventArgs e)
        {
            FrmDutchmillTakeOrder frm = new FrmDutchmillTakeOrder(this,warehouseName)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized,
                vDepartment = "Admin Team"
            };
            frm.Show();

        }

        private void Loading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Loading.Enabled = false;

            query = @"
    UPDATE v
    SET v.[CusName] = o.CusName
    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill] v
    INNER JOIN [Stock].[dbo].[TPRCustomer] o ON (o.CusNum = v.CusNum);

    UPDATE v
    SET v.[CusName] = o.CusName
    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] v
    INNER JOIN [Stock].[dbo].[TPRCustomer] o ON (o.CusNum = v.CusNum);

    UPDATE v
    SET v.[CusName] = o.CusName
    FROM [{0}].[dbo].[TblDeliveryTakeOrders] v
    INNER JOIN [Stock].[dbo].[TPRCustomer] o ON (o.CusNum = v.CusNum);

    UPDATE v
    SET v.[CusName] = o.CusName
    FROM [Stock].[dbo].[TPRDeliveryTakeOrder] v
    INNER JOIN [Stock].[dbo].[TPRCustomer] o ON (o.CusNum = v.CusNum);

    UPDATE v
    SET v.[CusName] = o.CusName
    FROM [Stock].[dbo].[TPRDeliveryTakeOrderAfterPrint] v
    INNER JOIN [Stock].[dbo].[TPRCustomer] o ON (o.CusNum = v.CusNum);

    UPDATE v
    SET v.[CusName] = o.CusName
    FROM [Stock].[dbo].[TPRDeliveryTakeOrderAfterPrintWaiting] v
    INNER JOIN [Stock].[dbo].[TPRCustomer] o ON (o.CusNum = v.CusNum);

    UPDATE v
    SET v.[CusName] = o.CusName
    FROM [Stock].[dbo].[TPRDeliveryTakeOrderAfterPrintWaitingPicking] v
    INNER JOIN [Stock].[dbo].[TPRCustomer] o ON (o.CusNum = v.CusNum);

    UPDATE v
    SET v.[Delto] = o.Delto
    FROM [{0}].[dbo].[TblDeliveryTakeOrders_DutchmillOrder] v
    INNER JOIN [Stock].[dbo].[TPRDelto] o ON (o.DefId = v.DeltoId);

    UPDATE v
    SET v.[Delto] = o.Delto
    FROM [{0}].[dbo].[TblDeliveryTakeOrders_Dutchmill] v
    INNER JOIN [Stock].[dbo].[TPRDelto] o ON (o.DefId = v.DeltoId);

    UPDATE v
    SET v.[Delto] = o.Delto
    FROM [{0}].[dbo].[TblDeliveryTakeOrders] v
    INNER JOIN [Stock].[dbo].[TPRDelto] o ON (o.DefId = v.DeltoId);
";
            query = string.Format(query, DatabaseName);
            Data.ExecuteCommand(query, Initialized.GetConnectionType(Data, App));

            this.Cursor = Cursors.Default;

        }

        private void MnuSetPiecesPerTray_Click(object sender, EventArgs e)
        {
            FrmSetPiecesPerTray Frm = new FrmSetPiecesPerTray { MdiParent = this };
            Frm.Show();
        }

        private void mnudelto_Click(object sender, EventArgs e)
        {

        }

        private void MnuTakeOrderForDutchmill_Click(object sender, EventArgs e)
        {

        }

        private void MnuDownloadTakeOrderFromSaleTeam_Click(object sender, EventArgs e)
        {

        }

        private void mnurestartapplication_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void MnuChangePassword_Click(object sender, EventArgs e)
        {
            FrmChangePassword fui = new FrmChangePassword();
            fui.MdiParent = this;
            fui.ProgramName = "TakeOrder";
            fui.Show();
        }

        private void MnuProcessTakeOrder_Click(object sender, EventArgs e)
        {
            FrmProcessTakeOrder Frm = new FrmProcessTakeOrder(this);
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void MnuViewProcessingTakeOrder_Click(object sender, EventArgs e)
        {
            FrmViewProcessingTakeOrder vFrm = new FrmViewProcessingTakeOrder
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            vFrm.Show();

        }

        private void MnuDelayPrintInvoicing_Click(object sender, EventArgs e)
        {
            FrmDelayPrintInvoicingForDutchmill vFrm = new FrmDelayPrintInvoicingForDutchmill
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            vFrm.Show();


        }

        private void MnuTODeleted_Click(object sender, EventArgs e)
        {
               
        }

        private void MnuDeltoListForDutchmillPO_Click(object sender, EventArgs e)
        {
            FrmDeltoListForDutchmillPO Frm = new FrmDeltoListForDutchmillPO
            {
                MdiParent = this
            };
            Frm.Show();

        }

        private void mnuwsproductslist_Click(object sender, EventArgs e)
        {
            gui_ws_products_list gui_ = new gui_ws_products_list(this,warehouseName)
            {
                MdiParent = this
            };
            gui_.Show();

        }

        private void MnuUnlockPrinterTakeOrder_Click(object sender, EventArgs e)
        {
            FrmUnlockPrinterTakeOrder vFrm = new FrmUnlockPrinterTakeOrder
            {
                MdiParent = this,
                WindowState = FormWindowState.Normal
            };
            vFrm.Show();

        }

        private void mnuurgentstocktoclear_Click(object sender, EventArgs e)
        {
            UrgentStockToClear frm = new UrgentStockToClear();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuSetExpiryForPicking_Click(object sender, EventArgs e)
        {
            FrmSetExpiryForPicking vFrm = new FrmSetExpiryForPicking();
            vFrm.MdiParent = this;
            vFrm.WindowState = FormWindowState.Maximized;
            this.Show();
        }

        private void MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MnuTakeOrderProcessing_Click(object sender, EventArgs e)
        {

        }

        private void MnuTODeleted_Click_1(object sender, EventArgs e)
        {
            FrmAlertTakeorderDeleted gui = new FrmAlertTakeorderDeleted(this, this.warehouseName);
            gui.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            gui.Show();
        }
    }
   
}
