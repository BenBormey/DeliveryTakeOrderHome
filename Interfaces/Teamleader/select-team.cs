using DeliveryTakeOrder.Declares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DeliveryTakeOrder.Interfaces.Teamleader
{
    public partial class SelectTeamForm : Form
    {
        RMDB db;

        BindingSource bsWarehouse;
        BindingSource bsTeam;
        public SelectTeamForm()
        {
            InitializeComponent();
            lblTitle.Text = String.Format("Welcome to {0}", AppSetting.AppName);
            this.Text = lblTitle.Text;
            db = new RMDB(AppSetting.ConnectionString);


            this.bsWarehouse = new BindingSource();
            bsWarehouse.PositionChanged += new EventHandler(Position_Changed);


            this.warehouseNameLoading.Enabled = true;
            this.teamLoading.Enabled = true;
            teamLoading_tick();
        }


        private void Position_Changed(object sender, EventArgs e)
        {
            if (this.bsWarehouse is null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            warehouseNameModel currentWarehouseName = (warehouseNameModel)this.bsWarehouse.Current;
            if (currentWarehouseName is null)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            //this.picWarehouseName.Image = currentWarehouseName.photo;
        }
   
   
        private void teamLoading_tick()
        {
            this.Cursor = Cursors.WaitCursor;
            this.teamLoading.Enabled = false;
            string sqlQuery = (string)new XElement("SQL", new XCData(@"
SELECT *
INTO #team_
FROM DBUNTWHOLESALECOLTD.dbo.TblSetSaleManagerToSupplier s;

UPDATE x
SET [x].[TeamName] = N'Alpha',
    [x].[TeamID] = 1,
    [x].[SaleManagerID] = 1
FROM #team_ x
WHERE ([x].[TeamName] NOT IN ( N'Charlie', N'Delta' ));

UPDATE x
SET [x].[TeamName] = N'Charlie + Delta',
    [x].[TeamID] = 2,
    [x].[SaleManagerID] = 2
FROM #team_ x
WHERE ([x].[TeamName] IN ( N'Charlie', N'Delta' ));

SELECT DISTINCT
       s1.SaleManagerID,
       N'Team ' + s1.TeamName + N' - ' + REPLACE(STUFF(
                                                 (
                                                     SELECT ', ' + s2.SupName
                                                     FROM #team_ s2
                                                     WHERE s1.TeamID = s2.TeamID
                                                     ORDER BY SupName
                                                     FOR XML PATH('')
                                                 ),
                                                 1,
                                                 2,
                                                 N''
                                                      ),
                                                 N'&amp;',
                                                 N'&'
                                                ) AS SupName,
       1 AS OrderID
FROM #team_ s1
WHERE TeamID IS NOT NULL
ORDER BY OrderID,
         SaleManagerID;

DROP TABLE #team_;
"));

            DataTable dt = db.GetDataTable(sqlQuery);
            this.bsTeam = new BindingSource { DataSource = dt };
            GeneralModule._BindCombo(this.cmbTeam, this.bsTeam, "SaleManagerID", "SupName");
            this.Cursor = Cursors.Default;
        }

   
        public List<T> GetDataTableToObject<T>(DataTable pDataTable) where T : new()
        {
            List<T> ls = new List<T>(); foreach (DataRow dr in pDataTable.Rows)
            {
                T o = new T(); object value; foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    try { if (pDataTable.Columns.Contains(p.Name)) { var propType = p.PropertyType; value = dr[p.Name] is DBNull ? null : Convert.ChangeType(dr[p.Name], propType); p.SetValue(o, value, null); } }
                    catch (Exception ex)
                    { // Handle the exception or log it Console.WriteLine("Error setting property: " + ex.Message); } } ls.Add(o); } return ls;

                    }
                }
                ls.Add(o);
            }
            return ls;
        }

        private void cmbWarehouseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.picWarehouseName.Image = null;
            if (this.cmbWarehouseName.SelectedValue is DataRowView | this.cmbWarehouseName.SelectedValue is null)
                return;
            if (this.cmbWarehouseName.Text.Trim().Equals("") == true)
                return;

            this.Position_Changed(this.cmbWarehouseName, e);
        }

        private void SelectTeamForm_Load(object sender, EventArgs e)
        {
           

            this.Cursor = Cursors.WaitCursor; this.warehouseNameLoading.Enabled = false;
            string sql = @"DECLARE @RC INT; EXECUTE @RC = [DBWarehouses].[dbo].[getWarehouseNameList]; ";
            DataTable dt = db.GetDataTable(sql);

            List<warehouseNameModel> result = GetDataTableToObject<warehouseNameModel>(dt);
            bsWarehouse = new BindingSource { DataSource = result };
            GeneralModule._BindCombo(this.cmbWarehouseName, this.bsWarehouse, "id", "warehouseName");
            this.cmbWarehouseName.SelectedIndex = -1;
            this.Cursor = Cursors.Default;
       
        }

    
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.cmbTeam.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Please select a team!");
                //  DevExpress.XtraEditors.XtraMessageBox.Show("Please select a team!");
                return;
            }
            if (this.bsWarehouse is null | this.cmbWarehouseName.Text.Trim().Equals("") == true)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Please select which warehouse you are standing!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                // DevExpress.XtraEditors.XtraMessageBox.Show("Please select which warehouse you are standing!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            warehouseNameModel currentWarehouseName = (warehouseNameModel)this.bsWarehouse.Current;
            if (currentWarehouseName is null | this.cmbWarehouseName.Text.Trim().Equals("") == true)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Please select whcih warehouse you are stading!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //  DevExpress.XtraEditors.XtraMessageBox.Show("Please select which warehouse you are standing!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Initialized.vIsNestleOnly = false;
            AppSetting.SaleManagerID = (int)(this.bsTeam.Current as DataRowView)["SaleManagerID"]; 
            if (AppSetting.SaleManagerID == 2) Initialized.vIsNestleOnly = true;
            FrmPasswordLogin frmPasswordLogin = new FrmPasswordLogin(currentWarehouseName);
            using (FrmPasswordLogin frmLogin = new FrmPasswordLogin(currentWarehouseName))
            {
                this.Hide(); // Hide the current form before showing the next form
                frmLogin.ShowDialog(); // Use ShowDialog for modal behavior
                this.Close(); // Close the current form after FrmPasswordLogin closes
            }

            //frmPasswordLogin.Show();
            //this.Close();
        }
    }
}
                


     
