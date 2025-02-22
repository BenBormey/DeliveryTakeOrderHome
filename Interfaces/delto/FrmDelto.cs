using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces.delto
{
    public partial class FrmDelto : Form
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
        private System.Data.DataTable olists;
        private BindingSource DataBindingSource;
        private List<cls_delto_image> lst_image;
        private List<cls_delto_image> cur_lst_image;
        private decimal index_;
        private MDI mdi_;

        public FrmDelto(MDI mdi_)
        {
            InitializeComponent();
            this.mdi_ = mdi_;

        }

        private void FrmDelto_Load(object sender, EventArgs e)
        {
            this.customerloading.Enabled = true;
            this.deltoloading.Enabled = true;
            this.zoneloading.Enabled = true;
            this.classloading.Enabled = true;
            this.cityloading.Enabled = true;
            this.loading.Enabled = true;
        } 
        private  void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);

        }
        private void DataSources(System.Windows.Forms.ComboBox comboBoxName, System.Data.DataTable dTable, string displayMember, string valueMember)
        {
            comboBoxName.DataSource = dTable;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.ValueMember = valueMember;
            comboBoxName.SelectedIndex = -1;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmDelto_Paint(object sender, PaintEventArgs e)
        {
            PicLogo.Image = Initialized.R_Logo;
            LblCompanyName.Text = Initialized.R_DatabaseName.ToUpper();
        }
        private System.Data.DataTable oStatusList;

        private void loading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.loading.Enabled = false;
            otodate = Data.Get_CURRENT_DATE(Initialized.GetConnectionType(Data , App));
            App.ClearController(TxtId, TxtKhmerName, TxtName, TxtLatitude, TxtLongitude, CmbStatus);
            
            // Clear
            ClearDataBindings(TxtId, TxtKhmerName, TxtName, TxtLatitude, TxtLongitude, CmbStatus);

            // Loding of status 
            if (oStatusList != null) oStatusList = null;
            oStatusList = new System.Data.DataTable();
            oStatusList.Columns.Add("Display", typeof(string));
            oStatusList.Columns.Add("Value", typeof(string));

            DataRow oRow = oStatusList.NewRow();
            oRow["Display"] = "Activate";
            oRow["Value"] = "Activate";
            oStatusList.Rows.Add(oRow);

            oRow = oStatusList.NewRow();
            oRow["Display"] = "Deactivate";
            oRow["Value"] = "Deactivate";
            oStatusList.Rows.Add(oRow);

            DataSources(CmbStatus, oStatusList, "Display", "Value");
            CmbStatus.SelectedIndex = 0;

            oquery = @" WITH v AS (
                            {2}SELECT [Id],[DefId],[DelTo],[KhmerUnicode],[Address],[KhmerAddress],[Zone],[Street],[HouseNumber],[Date],[ContactName1],[ContactName2],[Tel1],[Tel2],[Fax1],[Fax2],[HP1],[HP2],[Class],[Remark],[SizeOfShop],[DateLastInvoice],[AirCondition],[Freezer],[AlternativeSnacks],[AutomotiveProducts],[Beer],[Candy],[Chocolate],[EdibleGrocery],[NonEdibleGrocery],[FluidMilkProducts],[FoodServiceSupply],[Gum],[HealthAndBeautyCare],[Liquor],[PackBeveragesNonAlcoholic],[PackagedSweetSnacks],[SaltySnacks],[SuppliesAndServices],[Tobacco],[Wine],[FreshDairy],[FreshFluidMilkProducts],[FreshFrozenFoods],[PackagedIceCreamNovelties],[PerishableGrocery],[DelToInKhmer],[City],[Block],[ShopNumber],[SignatureImage],[Latitude],[Longitude],[Status],[CreatedDate],[IsNoNeedCallcardVisit],[CusNum],[MainId],
                            {2}RTRIM(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([Tel1], N'(', N''), N')', N''), N'+', N''), N'855', N''),N' ',N''))) [Tel1_],
                            {2}RTRIM(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([Tel2], N'(', N''), N')', N''), N'+', N''),N'855',N''),N' ',N''))) [Tel2_],
                            {2}RTRIM(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([HP1], N'(', N''), N')', N''), N'+', N''), N'855', N''),N' ',N''))) [HP1_],
                            {2}RTRIM(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([HP2], N'(', N''), N')', N''), N'+', N''), N'855', N''),N' ',N''))) [HP2_]
                            {2}FROM [Stock].[dbo].[TPRDelto]
                            {1}UNION ALL
                            {3}SELECT [Id],[DefId],[DelTo],[KhmerUnicode],[Address],[KhmerAddress],[Zone],[Street],[HouseNumber],[Date],[ContactName1],[ContactName2],[Tel1],[Tel2],[Fax1],[Fax2],[HP1],[HP2],[Class],[Remark],[SizeOfShop],[DateLastInvoice],[AirCondition],[Freezer],[AlternativeSnacks],[AutomotiveProducts],[Beer],[Candy],[Chocolate],[EdibleGrocery],[NonEdibleGrocery],[FluidMilkProducts],[FoodServiceSupply],[Gum],[HealthAndBeautyCare],[Liquor],[PackBeveragesNonAlcoholic],[PackagedSweetSnacks],[SaltySnacks],[SuppliesAndServices],[Tobacco],[Wine],[FreshDairy],[FreshFluidMilkProducts],[FreshFrozenFoods],[PackagedIceCreamNovelties],[PerishableGrocery],[DelToInKhmer],[City],[Block],[ShopNumber],[SignatureImage],[Latitude],[Longitude],[Status],[CreatedDate],[IsNoNeedCallcardVisit],[CusNum],[MainId],
                            {3}RTRIM(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([Tel1], N'(', N''), N')', N''), N'+', N''), N'855', N''),N' ',N''))) [Tel1_],
                            {3}RTRIM(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([Tel2], N'(', N''), N')', N''), N'+', N''),N'855',N''),N' ',N''))) [Tel2_],
                            {3}RTRIM(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([HP1], N'(', N''), N')', N''), N'+', N''), N'855', N''),N' ',N''))) [HP1_],
                            {3}RTRIM(LTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([HP2], N'(', N''), N')', N''), N'+', N''), N'855', N''),N' ',N''))) [HP2_]
                            {3}FROM [Stock].[dbo].[TPRDeltoDeactivate]                            
                        )
                        SELECT v.*
                        FROM v
                        ORDER BY v.[DefId];";
            oquery = string.Format(oquery, DatabaseName, RdbShowAll.Checked ? "" : "--", RdbShowAll.Checked || RdbActivate.Checked ? "" : "--", RdbShowAll.Checked || RdbDeactivate.Checked ? "" : "--");
            olists = Data.Selects(oquery, Initialized.GetConnectionType(Data, App));

            if (DataBindingSource != null) DataBindingSource = null;
            DataBindingSource = new BindingSource
            {
                DataSource = olists
            };

            if (olists != null && olists.Rows.Count > 0)
            {
                App.SetEnableController(true, BtnUpdate, Navigator, BtnSearch);
            }

            this.imageloading_Tick(imageloading, e);
            this.displayloading.Enabled = true;
            this.Cursor = Cursors.Default;


        }
        private void ClearDataBindings(params object[] val)
        {
            foreach (var r in val)
            {
                ((Control)r).DataBindings.Clear();
            }
        }

        private void imageloading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.imageloading.Enabled = false;
            this.index_ = 0;
            this.oquery = @"
SELECT [ID],
       [DeltoID],
       [ImgDelto]
FROM [Stock].[dbo].[TPRDeltoPicture];
";
            this.oquery = string.Format(this.oquery, DatabaseName);
            this.olists = Data.Selects(this.oquery, Initialized.GetConnectionType(Data, App));
            this.lst_image = this.GetDataTableToObject<cls_delto_image>(this.olists);
            this.Cursor = Cursors.Default;

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.TxtLatitude.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the Latitude!", "Enter Latitude", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TxtLatitude.Focus();
                return;
            }
            else if (this.TxtLongitude.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the Longitude!", "Enter Longitude", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TxtLongitude.Focus();
                return;
            }

            decimal sDeltoId = this.TxtId.Text.Trim().Equals("") ? 0 : Convert.ToDecimal(this.TxtId.Text.Trim());
            string sLatitude = this.TxtLatitude.Text.Trim().Equals("") ? "" : this.TxtLatitude.Text.Trim();
            string sLongitude = this.TxtLongitude.Text.Trim().Equals("") ? "" : this.TxtLongitude.Text.Trim();

            oquery = @"
    DECLARE @oDefId as decimal(18,0) = {1};
    DECLARE @oLatitude as nvarchar(25) = N'{2}';
    DECLARE @oLongitude as nvarchar(25) = N'{3}';

    IF EXISTS (SELECT * FROM [Stock].[dbo].[TPRDelto] WHERE ([DefId] = @oDefId))
    BEGIN
        UPDATE o
        SET  o.[Latitude] = @oLatitude,
             o.[Longitude] = @oLongitude
        FROM [Stock].[dbo].[TPRDelto] o
        WHERE (o.[DefId] = @oDefId);
    END;
    ELSE IF EXISTS (SELECT * FROM [Stock].[dbo].[TPRDeltoDeactivate] WHERE ([DefId] = @oDefId))
    BEGIN
        UPDATE o
        SET  o.[Latitude] = @oLatitude,
             o.[Longitude] = @oLongitude
        FROM [Stock].[dbo].[TPRDeltoDeactivate] o
        WHERE (o.[DefId] = @oDefId);
    END;
";
            oquery = string.Format(oquery, DatabaseName, sDeltoId, sLatitude, sLongitude);

            using (SqlConnection R_Con = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
            {
                SqlCommand R_Com = new SqlCommand();
                SqlTransaction R_Tran;
                R_Con.Open();
                R_Tran = R_Con.BeginTransaction();
                try
                {
                    R_Com.Transaction = R_Tran;
                    R_Com.Connection = R_Con;
                    R_Com.CommandType = CommandType.Text;
                    R_Com.CommandText = oquery;
                    R_Com.ExecuteNonQuery();
                    R_Tran.Commit();
                    R_Con.Close();
                    MessageBox.Show("Update successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (SqlException ex)
                {
                    R_Tran.Rollback();
                    R_Con.Close();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    R_Tran.Rollback();
                    R_Con.Close();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        public List<T> GetDataTableToObject<T>(System.Data.DataTable pDataTable)
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
        Err_Again:
            Initialized.R_SearchValue = "";
            Initialized.R_IsCancel = true;
            FrmSearch vFrm = new FrmSearch();
            vFrm.RdbCustomerId.Text = "Delto Id";
            vFrm.RdbCustomerName.Text = "Delto Name";
            vFrm.ShowDialog();
            if (Initialized.R_IsCancel) return;
            if (!string.IsNullOrEmpty(Initialized.R_SearchValue))
            {
                switch (vFrm.typeofsearching_)
                {
                    case FrmSearch.typeofsearching.Id:
                        DataBindingSource.Filter = string.Format("[DefId] = {0}", Convert.ToDecimal(Initialized.R_SearchValue));
                        break;
                    case FrmSearch.typeofsearching.Name:
                        DataBindingSource.Filter = string.Format("[DelTo] LIKE '%{0}%'", Initialized.R_SearchValue);
                        break;
                    default:
                        DataBindingSource.Filter = string.Format("([Tel1_] = '{0}') OR ([Tel2_] = '{0}') OR ([HP1_] = '{0}') OR ([HP1_] = '{0}')", Initialized.R_SearchValue);
                        break;
                }
                if (DataBindingSource.Count <= 0)
                {
                    MessageBox.Show("Searching the value is not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Err_Again;
                }
                else
                {
                    MessageBox.Show("Searching is " + DataBindingSource.Count + " found(s)!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void TxtKhmerName_Enter(object sender, EventArgs e)
        {
            Key.SwitchKeyboardLang(SwitchKeyboardLanguage.Type_Of_Language.LANG_KHMER);

        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            Key.SwitchKeyboardLang(SwitchKeyboardLanguage.Type_Of_Language.LANG_KHMER);

        }

        private void TxtLatitude_Enter(object sender, EventArgs e)
        {

        }

        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            decimal vDefId_ = string.IsNullOrWhiteSpace(this.TxtId.Text.Trim()) ? 0 : Convert.ToDecimal(this.TxtId.Text.Trim());
            this.cur_lst_image = this.lst_image.Where(x => x.DeltoID == vDefId_).ToList();

        }

        private void RdbDeactivate_CheckedChanged(object sender, EventArgs e)
        {
            this.loading.Enabled = true;
        }

        private void RdbActivate_CheckedChanged(object sender, EventArgs e)
        {
            this.loading.Enabled = true;
        }
        
        private void RdbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            this.loading.Enabled = true;
        }

        private void TxtLatitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Float, null, 25);
        }

        private void cityloading_Tick(object sender, EventArgs e)
        {

        }

        private void TxtLongitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Float, null, 25);

        }

        private void FrmDelto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Key.SwitchKeyboardLang(SwitchKeyboardLanguage.Type_Of_Language.LANG_ENGLISH);
        }
        //private ApplicationFramework App = new ApplicationFramework();


    }
}
