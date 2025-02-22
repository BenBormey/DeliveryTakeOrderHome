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
    public partial class PreviewControl : DevExpress.XtraEditors.XtraUserControl
    {
        public PreviewControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        object _ds;
        public object Datasource
        {
            get { return _ds; }
            set { _ds = value; }
        }

    }
    
}
