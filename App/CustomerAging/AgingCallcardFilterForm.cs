using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.App.CustomerAging
{
    public partial class AgingCallcardFilterForm : Form
    {
        BindingSource bs;
        public bool IsCancel = true;
        object ls;
        public AgingCallcardFilterForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public List<T> GetDatasource<T>()
        {
            return ((SortableBindingList<T>)ls)
                .AsEnumerable()
                .Select(x =>
                {
                    if (x is ICloneable cloneable)
                    {
                        return (T)cloneable.Clone(); // Clone using ICloneable if available
        }
                    return x; // Return the object itself if not cloneable
    })
                .ToList();

        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (var o in (IEnumerable<dynamic>)bs.DataSource)
            {
                o.IsChecked = false;
            }
            dgvData.Refresh();

        }

        private void AgingCallcardFilterForm_Load(object sender, EventArgs e)
        {

        }

        private void DesignDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void FillSortableList<T>(object lsBs)
        {
            var lsTmp = lsBs.GetType().GetProperty("DataSource").GetValue(lsBs);
            var lsSource = (List<T>)lsTmp; // Cast DataSource to List<T>
            var ls = new SortableBindingList<T>();

            foreach (var item in lsSource)
            {
                if (item is ICloneable cloneableItem)
                {
                    // Clone only if the item is ICloneable
                    ls.Add((T)cloneableItem.Clone());
                }
                else
                {
                    // If not cloneable, add the item as is (you may handle this case differently)
                    ls.Add(item);
                }
            }

            bs = new BindingSource(ls, null);
            dgvData.DataSource = bs;
            DesignDgv();

        }


        private void DesignDgv()
        {
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (col.Name != "IsChecked") col.ReadOnly = true;
                col.Visible = false;
            }
            dgvData.Columns["IsChecked"].Visible = true;
            dgvData.Columns["InvNumber"].Visible = true;
            dgvData.Columns["PONumber"].Visible = true;
            dgvData.Columns["ShipDate"].Visible = true;
            dgvData.Columns["DueDate"].Visible = true;
            dgvData.Columns["GrandTotal"].Visible = true;
            dgvData.Columns["Division"].Visible = true;

            if (dgvData.Columns.Contains("Delto"))
                dgvData.Columns["Delto"].Visible = true;

            dgvData.Columns["CusName"].Visible = true;
            dgvData.Columns["DaysOver"].Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (var o in (List<ARAgingDetail>)bs.DataSource)
            {
                o.IsChecked = false;
            }
            dgvData.Refresh();



        }

        private void Button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvData.SelectedRows)
            {
                var o = (ARAgingDetail)dr.DataBoundItem;
                o.IsChecked = true;
            }
            dgvData.Refresh();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach (var o in (IEnumerable<ARAgingDetail>)bs.DataSource)
            {
                o.IsChecked = false;
            }
            dgvData.Refresh();

        }
    }
}
