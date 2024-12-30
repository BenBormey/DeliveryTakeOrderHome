using DeliveryTakeOrder.ApplicationFrameworks;
using DeliveryTakeOrder.DatabaseFrameworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces.delto
{
    public partial class FrmDelto_Selected : Form
    {
      
            private DatabaseFramework Data = new DatabaseFramework();
            private ApplicationFramework App = new ApplicationFramework();
            private string DatabaseName;
            public bool vExportDetail { get; set; }
            public string vCity { get; set; }

   
        

        public FrmDelto_Selected()
        {
            InitializeComponent();
        }

        private void FrmDelto_Selected_Load(object sender, EventArgs e)
        {

        }
    }
}
