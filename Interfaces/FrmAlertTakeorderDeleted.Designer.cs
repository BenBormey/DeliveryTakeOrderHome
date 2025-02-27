namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmAlertTakeorderDeleted
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlertTakeorderDeleted));
            this.dviewer_detail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.takeordernumber_detail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pickingnumber_detail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ponumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.proname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qtypercase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcsfree = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcsorder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.packorder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ctnorder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.totalpcsorder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridcontroller = new DevExpress.XtraGrid.GridControl();
            this.dviewer_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.takeordernumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pickingnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pickingdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cusnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cusname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deltoid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.delto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateorder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.daterequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deliverydate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createddate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblcountrow = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Loading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dviewer_detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontroller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dviewer_main)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dviewer_detail
            // 
            this.dviewer_detail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.takeordernumber_detail,
            this.pickingnumber_detail,
            this.ponumber,
            this.barcode,
            this.proname,
            this.size,
            this.qtypercase,
            this.pcsfree,
            this.pcsorder,
            this.packorder,
            this.ctnorder,
            this.totalpcsorder});
            this.dviewer_detail.GridControl = this.gridcontroller;
            this.dviewer_detail.Name = "dviewer_detail";
            this.dviewer_detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dviewer_detail.OptionsBehavior.Editable = false;
            this.dviewer_detail.OptionsBehavior.ReadOnly = true;
            this.dviewer_detail.OptionsPrint.EnableAppearanceOddRow = true;
            this.dviewer_detail.OptionsView.ShowGroupPanel = false;
            // 
            // takeordernumber_detail
            // 
            this.takeordernumber_detail.Caption = "T.O Number";
            this.takeordernumber_detail.FieldName = "takeordernumber";
            this.takeordernumber_detail.Name = "takeordernumber_detail";
            // 
            // pickingnumber_detail
            // 
            this.pickingnumber_detail.Caption = "pickingnumber";
            this.pickingnumber_detail.FieldName = "pickingnumber";
            this.pickingnumber_detail.Name = "pickingnumber_detail";
            // 
            // ponumber
            // 
            this.ponumber.Caption = "P.O Number";
            this.ponumber.FieldName = "ponumber";
            this.ponumber.Name = "ponumber";
            this.ponumber.Visible = true;
            this.ponumber.VisibleIndex = 0;
            // 
            // barcode
            // 
            this.barcode.Caption = "Barcode";
            this.barcode.FieldName = "barcode";
            this.barcode.Name = "barcode";
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 1;
            // 
            // proname
            // 
            this.proname.Caption = "Description";
            this.proname.FieldName = "proname";
            this.proname.Name = "proname";
            this.proname.Visible = true;
            this.proname.VisibleIndex = 2;
            // 
            // size
            // 
            this.size.Caption = "Size";
            this.size.FieldName = "size";
            this.size.Name = "size";
            this.size.Visible = true;
            this.size.VisibleIndex = 3;
            // 
            // qtypercase
            // 
            this.qtypercase.Caption = "Q/C";
            this.qtypercase.FieldName = "qtypercase";
            this.qtypercase.Name = "qtypercase";
            this.qtypercase.Visible = true;
            this.qtypercase.VisibleIndex = 4;
            // 
            // pcsfree
            // 
            this.pcsfree.Caption = "Pcs Free";
            this.pcsfree.FieldName = "pcsfree";
            this.pcsfree.Name = "pcsfree";
            this.pcsfree.Visible = true;
            this.pcsfree.VisibleIndex = 5;
            // 
            // pcsorder
            // 
            this.pcsorder.Caption = "Ord. Pcs";
            this.pcsorder.FieldName = "pcsorder";
            this.pcsorder.Name = "pcsorder";
            this.pcsorder.Visible = true;
            this.pcsorder.VisibleIndex = 6;
            // 
            // packorder
            // 
            this.packorder.Caption = "Ord. Pack";
            this.packorder.FieldName = "packorder";
            this.packorder.Name = "packorder";
            this.packorder.Visible = true;
            this.packorder.VisibleIndex = 7;
            // 
            // ctnorder
            // 
            this.ctnorder.Caption = "Ord. CTN";
            this.ctnorder.FieldName = "ctnorder";
            this.ctnorder.Name = "ctnorder";
            this.ctnorder.Visible = true;
            this.ctnorder.VisibleIndex = 8;
            // 
            // totalpcsorder
            // 
            this.totalpcsorder.Caption = "Total Ord. Pcs ";
            this.totalpcsorder.FieldName = "totalpcsorder";
            this.totalpcsorder.Name = "totalpcsorder";
            this.totalpcsorder.Visible = true;
            this.totalpcsorder.VisibleIndex = 9;
            // 
            // gridcontroller
            // 
            this.gridcontroller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridcontroller.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode1.LevelTemplate = this.dviewer_detail;
            gridLevelNode1.RelationName = "DetailView";
            this.gridcontroller.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridcontroller.Location = new System.Drawing.Point(0, 0);
            this.gridcontroller.MainView = this.dviewer_main;
            this.gridcontroller.Name = "gridcontroller";
            this.gridcontroller.Size = new System.Drawing.Size(984, 525);
            this.gridcontroller.TabIndex = 117;
            this.gridcontroller.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dviewer_main,
            this.dviewer_detail});
            // 
            // dviewer_main
            // 
            this.dviewer_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.takeordernumber,
            this.pickingnumber,
            this.pickingdate,
            this.cusnum,
            this.cusname,
            this.deltoid,
            this.delto,
            this.dateorder,
            this.daterequired,
            this.deliverydate,
            this.reason,
            this.createddate});
            this.dviewer_main.CustomizationFormBounds = new System.Drawing.Rectangle(596, 435, 260, 232);
            this.dviewer_main.GridControl = this.gridcontroller;
            this.dviewer_main.Name = "dviewer_main";
            this.dviewer_main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dviewer_main.OptionsBehavior.Editable = false;
            this.dviewer_main.OptionsBehavior.ReadOnly = true;
            this.dviewer_main.OptionsDetail.ShowDetailTabs = false;
            this.dviewer_main.OptionsPrint.EnableAppearanceOddRow = true;
            this.dviewer_main.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.dviewer_main.OptionsSelection.MultiSelect = true;
            this.dviewer_main.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.dviewer_main.OptionsView.ShowGroupPanel = false;
            this.dviewer_main.MasterRowEmpty += new DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventHandler(this.dviewer_main_MasterRowEmpty);
            this.dviewer_main.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.dviewer_main_MasterRowGetChildList);
            this.dviewer_main.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.dviewer_main_MasterRowGetRelationName);
            this.dviewer_main.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.dviewer_main_MasterRowGetRelationCount);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // takeordernumber
            // 
            this.takeordernumber.Caption = "T.O Number";
            this.takeordernumber.FieldName = "takeordernumber";
            this.takeordernumber.Name = "takeordernumber";
            // 
            // pickingnumber
            // 
            this.pickingnumber.Caption = "Picking Number";
            this.pickingnumber.FieldName = "pickingnumber";
            this.pickingnumber.Name = "pickingnumber";
            this.pickingnumber.Visible = true;
            this.pickingnumber.VisibleIndex = 1;
            // 
            // pickingdate
            // 
            this.pickingdate.Caption = "Picking Date";
            this.pickingdate.FieldName = "pickingdate";
            this.pickingdate.Name = "pickingdate";
            this.pickingdate.Visible = true;
            this.pickingdate.VisibleIndex = 2;
            // 
            // cusnum
            // 
            this.cusnum.Caption = "cusnum";
            this.cusnum.FieldName = "cusnum";
            this.cusnum.Name = "cusnum";
            // 
            // cusname
            // 
            this.cusname.Caption = "Customer Name";
            this.cusname.FieldName = "cusname";
            this.cusname.Name = "cusname";
            this.cusname.Visible = true;
            this.cusname.VisibleIndex = 3;
            // 
            // deltoid
            // 
            this.deltoid.Caption = "deltoid";
            this.deltoid.FieldName = "deltoid";
            this.deltoid.Name = "deltoid";
            // 
            // delto
            // 
            this.delto.Caption = "Delto";
            this.delto.FieldName = "delto";
            this.delto.Name = "delto";
            this.delto.Visible = true;
            this.delto.VisibleIndex = 4;
            // 
            // dateorder
            // 
            this.dateorder.Caption = "Ord. Date";
            this.dateorder.FieldName = "dateorder";
            this.dateorder.Name = "dateorder";
            this.dateorder.Visible = true;
            this.dateorder.VisibleIndex = 5;
            // 
            // daterequired
            // 
            this.daterequired.Caption = "Req. Date";
            this.daterequired.FieldName = "daterequired";
            this.daterequired.Name = "daterequired";
            this.daterequired.Visible = true;
            this.daterequired.VisibleIndex = 6;
            // 
            // deliverydate
            // 
            this.deliverydate.Caption = "Del. Date";
            this.deliverydate.FieldName = "deliverydate";
            this.deliverydate.Name = "deliverydate";
            this.deliverydate.Visible = true;
            this.deliverydate.VisibleIndex = 7;
            // 
            // reason
            // 
            this.reason.Caption = "Reason";
            this.reason.FieldName = "reason";
            this.reason.Name = "reason";
            this.reason.Visible = true;
            this.reason.VisibleIndex = 8;
            // 
            // createddate
            // 
            this.createddate.Caption = "createddate";
            this.createddate.FieldName = "createddate";
            this.createddate.Name = "createddate";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.lblcountrow);
            this.Panel2.Controls.Add(this.BtnOK);
            this.Panel2.Controls.Add(this.BtnCancel);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 525);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(984, 36);
            this.Panel2.TabIndex = 116;
            // 
            // lblcountrow
            // 
            this.lblcountrow.AutoSize = true;
            this.lblcountrow.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblcountrow.Location = new System.Drawing.Point(2, 2);
            this.lblcountrow.Name = "lblcountrow";
            this.lblcountrow.Size = new System.Drawing.Size(76, 19);
            this.lblcountrow.TabIndex = 115;
            this.lblcountrow.Text = "Count Row : 0";
            this.lblcountrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOK.Image = global::DeliveryTakeOrder.Properties.Resources.OK;
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(691, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(164, 32);
            this.BtnOK.TabIndex = 113;
            this.BtnOK.Text = "&Accept Deletion";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(855, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(127, 32);
            this.BtnCancel.TabIndex = 114;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Loading
            // 
            this.Loading.Interval = 5;
            this.Loading.Tick += new System.EventHandler(this.Loading_Tick);
            // 
            // FrmAlertTakeorderDeleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.gridcontroller);
            this.Controls.Add(this.Panel2);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAlertTakeorderDeleted";
            this.Text = "T.O Deletion";
            this.Load += new System.EventHandler(this.FrmAlertTakeorderDeleted_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dviewer_detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontroller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dviewer_main)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblcountrow;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Timer Loading;
        internal DevExpress.XtraGrid.GridControl gridcontroller;
        internal DevExpress.XtraGrid.Views.Grid.GridView dviewer_detail;
        internal DevExpress.XtraGrid.Columns.GridColumn takeordernumber_detail;
        internal DevExpress.XtraGrid.Columns.GridColumn pickingnumber_detail;
        internal DevExpress.XtraGrid.Columns.GridColumn ponumber;
        internal DevExpress.XtraGrid.Columns.GridColumn barcode;
        internal DevExpress.XtraGrid.Columns.GridColumn proname;
        internal DevExpress.XtraGrid.Columns.GridColumn size;
        internal DevExpress.XtraGrid.Columns.GridColumn qtypercase;
        internal DevExpress.XtraGrid.Columns.GridColumn pcsfree;
        internal DevExpress.XtraGrid.Columns.GridColumn pcsorder;
        internal DevExpress.XtraGrid.Columns.GridColumn packorder;
        internal DevExpress.XtraGrid.Columns.GridColumn ctnorder;
        internal DevExpress.XtraGrid.Columns.GridColumn totalpcsorder;
        internal DevExpress.XtraGrid.Views.Grid.GridView dviewer_main;
        internal DevExpress.XtraGrid.Columns.GridColumn id;
        internal DevExpress.XtraGrid.Columns.GridColumn takeordernumber;
        internal DevExpress.XtraGrid.Columns.GridColumn pickingnumber;
        internal DevExpress.XtraGrid.Columns.GridColumn pickingdate;
        internal DevExpress.XtraGrid.Columns.GridColumn cusnum;
        internal DevExpress.XtraGrid.Columns.GridColumn cusname;
        internal DevExpress.XtraGrid.Columns.GridColumn deltoid;
        internal DevExpress.XtraGrid.Columns.GridColumn delto;
        internal DevExpress.XtraGrid.Columns.GridColumn dateorder;
        internal DevExpress.XtraGrid.Columns.GridColumn daterequired;
        internal DevExpress.XtraGrid.Columns.GridColumn deliverydate;
        internal DevExpress.XtraGrid.Columns.GridColumn reason;
        internal DevExpress.XtraGrid.Columns.GridColumn createddate;
    }
}