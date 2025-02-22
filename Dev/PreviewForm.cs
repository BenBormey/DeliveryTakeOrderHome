﻿using DeliveryTakeOrder.App.CustomerAging;
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

namespace DeliveryTakeOrder.Dev
{
    public partial class PreviewForm : DevExpress.XtraEditors.XtraForm
    {
     
        AgingReport xReport;

     

        public RMDB db { get; set; }
        public PreviewForm()
        {
            InitializeComponent();
            db = new RMDB(AppSetting.ConnectionString);
            this.WindowState = FormWindowState.Maximized;
        }

    
   
        private void PreviewForm_Shown(object sender, EventArgs e)
        {
          //  LoadReport();
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {

        }
        public virtual void LoadReport()
        {

        }

        private void btnSelectInvoice_Click(object sender, EventArgs e)
        {

        }

        private void PreviewForm_Shown_1(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}