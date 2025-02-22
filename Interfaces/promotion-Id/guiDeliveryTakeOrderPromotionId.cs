using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.Controller;
using DeliveryTakeOrder.DatabaseFrameworks;
using DeliveryTakeOrder.Declares;
using DevExpress.XtraEditors;
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

namespace DeliveryTakeOrder.Interfaces.promotion_Id
{
    public partial class guiDeliveryTakeOrderPromotionId : DevExpress.XtraEditors.XtraForm
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private APIsController app_;
        private string DatabaseName;
        private BindingSource bs;
        private MDI menuMDI;

      

        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = $"{Data.PrefixDatabase}{Data.DatabaseName}";
        }

        private void DataSources(System.Windows.Forms.ComboBox comboBoxName, object dTable, string displayMember, string valueMember)
        {
            comboBoxName.DataSource = dTable;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.ValueMember = valueMember;
        }
        public guiDeliveryTakeOrderPromotionId(MDI menuMDI)
        {
            InitializeComponent();
                      this.LoadingInitialized();
            this.menuMDI = menuMDI;

            // Add any initialization after the InitializeComponent() call.
            this.PicLogo.Image = Initialized.R_Logo;
            this.LblCompanyName.Text = Initialized.R_DatabaseName.ToUpper();
            this.loading.Enabled = true;
            this.displayLoading.Enabled = true;
        }


        private void guiDeliveryTakeOrderPromotionId_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string description = "";
            if (!string.IsNullOrWhiteSpace(this.txtDescription.Text))
            {
                description = this.txtDescription.Text.Trim();
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                XtraMessageBox.Show("Please enter the promotion id...", "Enter Promotion Id", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtDescription.Focus();
                this.txtDescription.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.cmbPromotionId.Text))
            {
                XtraMessageBox.Show("Please select any method of payment!!!", "Select Method Of Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbPromotionId.Focus();
                return;
            }

            int id = -1;
            if (this.btnCancel.Visible)
            {
                var current = this.bs.Current as deliveryTakeOrderPromotionIdModel;
                if (current != null)
                {
                    id = current.id;
                }
            }

            string sql = $@"
DECLARE @RC INT;
DECLARE @id INT = {id};
DECLARE @methodOfPayment NVARCHAR(25) = N'{this.cmbPromotionId.Text.Trim()}';
DECLARE @description NVARCHAR(100) = N'{description}';
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[saveDeliveryTakeOrderPromotionId] @id,
                                                                             @methodOfPayment,
                                                                             @description;";

            Data.ExecuteCommand(sql, Initialized.GetConnectionType(Data, App));
            this.displayLoading.Enabled = true;
            this.loading.Enabled = true;
        }
        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            var table = new DataTable();

            // Check if the list is empty
            if (!list.Any())
            {
                // Return an empty DataTable if the list is empty
                return table;
            }

            // Get the properties of the first item in the list
            var fields = list.First().GetType().GetProperties();

            // Create columns in the DataTable based on the properties
            foreach (var field in fields)
            {
                table.Columns.Add(field.Name, field.PropertyType);
            }

            // Populate the DataTable with data from the list
            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (var field in fields)
                {
                    var property = item.GetType().GetProperty(field.Name);
                    row[field.Name] = property.GetValue(item, null);
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private void displayLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.displayLoading.Enabled = false;
            string sql = @"DECLARE @RC INT;
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[getDeliveryTakeOrderPromotionId];";
            DataTable tbl = Data.Selects(sql, Initialized.GetConnectionType(Data, App));
            List<deliveryTakeOrderPromotionIdModel> mainList = this.GetDataTableToObject<deliveryTakeOrderPromotionIdModel>(tbl);
            this.bs = new BindingSource(mainList, null);
            this.lstmain.DataSource = this.bs;
            this.lstmain.Refresh();
            this.gvmain.IndicatorWidth = 50;
            this.lblcountrow.Text = $"Count Row : {this.lstmain.MainView.RowCount}";
            this.Cursor = Cursors.Default;

        }
        public List<T> GetDataTableToObject<T>(DataTable pDataTable) where T : new()
        {
            var ls = new List<T>();

            foreach (DataRow dr in pDataTable.Rows)
            {
                T o = Activator.CreateInstance<T>(); // Create a new instance of T
                object value;

                foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    try
                    {
                        if (pDataTable.Columns.Contains(p.Name))
                        {
                            // Get the property type
                            Type propType = p.PropertyType;

                            // Handle DBNull values and convert the data
                            value = dr[p.Name] == DBNull.Value ? null : Convert.ChangeType(dr[p.Name], propType);

                            // Set the value of the property
                            p.SetValue(o, value);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log or ignore)
                    }
                }

                ls.Add(o); // Add the object to the list
            }

            return ls;
        }

        private void loading_Tick(object sender, EventArgs e)
        {
            this.loading.Enabled = false;
            this.cmbPromotionId.SelectedIndex = -1;
            this.txtDescription.Text = $"";
            this.btnCancel.Visible = false;
            this.lstmain.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.loading.Enabled = true;

        }

        private void gvmain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var current = this.bs.Current as deliveryTakeOrderPromotionIdModel;
            if (current == null) return;

            if (XtraMessageBox.Show($"Are you sure, you want to delete this ( {current.description} )?(Yes/No)",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string sql = $@"
DECLARE @RC INT;
DECLARE @id INT = {current.id};
EXECUTE @RC = [DBUNTWHOLESALECOLTD].[dbo].[deleteDeliveryTakeOrderPromotionId] @id;";

            Data.ExecuteCommand(sql, Initialized.GetConnectionType(Data, App));
            this.bs.RemoveCurrent();

        }

        private void btnModify_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var current = this.bs.Current as deliveryTakeOrderPromotionIdModel;
            if (current == null) return;

            this.cmbPromotionId.SelectedText = $"{current.methodOfPayment}";
            this.txtDescription.Text = $"{current.description}";
            this.btnCancel.Visible = true;
            this.lstmain.Enabled = false;

        }
    }
    
}