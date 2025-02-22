using DeliveryTakeOrder.Dev;
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
    public partial class ar_agingform : PreviewFor
    {
        public ar_agingform()
        {
            InitializeComponent();
        }

        private void ar_agingform_Load(object sender, EventArgs e)
        {
  
        }
        private BindingSource bsData = new BindingSource();

        private general_controller_class generalCtrl;

        private List<ARAging> lsData = new List<ARAging>();
     
        private AgingReport xReport;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // panTitle
            // 
       
            // 
            // ar_agingform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(890, 572);
            this.Name = "ar_agingform";
            this.Load += new System.EventHandler(this.ar_agingform_Load_1);
            this.ResumeLayout(false);

        }

        private void ar_agingform_Load_1(object sender, EventArgs e)
        {

        }
    }
}
