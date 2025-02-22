using DeliveryTakeOrder.Declares;
using DevExpress.XtraEditors;
using System;
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
    public partial class ar_aging : DevExpress.XtraEditors.XtraForm
    {
        public ar_aging(string pCusNum, DateTime pDueDate )
        {
            InitializeComponent();
            RMDB db = new RMDB(AppSetting.ConnectionString);
            DataTable dt = GetData(pCusNum);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No bank guarantee.");
                this.IsClose = true;
                this.Close();
                return;
            }
            lblCustomer.Text = dt.Rows[0]["CusName"].ToString();
            lblCredit.Text = Convert.ToDouble(dt.Rows[0]["CreditLimit"]).ToString("N2");
            lblAlertDate.Text = Convert.ToDateTime(dt.Rows[0]["AlertDate"]).ToString("yyyy-MM-dd");
            DateTime expDate = Convert.ToDateTime(dt.Rows[0]["Expiry"]);
            int dayLeft = (expDate - pDueDate).Days;
            string dayLeftText = string.Format("({0} days left)", dayLeft);
            if (dayLeft <= 0)
            {
                dayLeftText = "(Expired)";
                lblExpiryDate.ForeColor = Color.IndianRed;
            }
            lblExpiryDate.Text = string.Format("{0}   {1}", expDate.ToString("yyyy-MM-dd"), dayLeftText);

        }
        RMDB db;
            string cusNum;
        public bool IsClose = false;
        private void ar_aging_Load(object sender, EventArgs e)
        {

        }
        private DataTable GetData(string pCusNum)
        {
            string sqlQuery = @"
        SELECT Id,
               CusId,
               CusName,
               CreditLimit,
               Expiry,
               AlertDate
        FROM Stock.dbo.TPRCustomerBankGarantee
        WHERE CusId = N'{0}';
    ";

            sqlQuery = string.Format(sqlQuery, pCusNum);
            return db.GetDataTable(sqlQuery);
        }

    }
}