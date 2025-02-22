namespace DeliveryTakeOrder.Interfaces
{
    partial class UrgentStockToClear
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.xgcUrgent = new DevExpress.XtraGrid.GridControl();
            this.xdgvUrgent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DefaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xgcUrgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdgvUrgent)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.xgcUrgent);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 25);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(952, 470);
            this.Panel1.TabIndex = 3;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::DeliveryTakeOrder.Properties.Resources.icons8_error_48;
            this.PictureBox1.Location = new System.Drawing.Point(11, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(50, 50);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 44;
            this.PictureBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.Location = new System.Drawing.Point(67, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(226, 30);
            this.Label1.TabIndex = 43;
            this.Label1.Text = "Urgent Stock to Clear";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnOk);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 495);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(9, 12, 36, 12);
            this.Panel2.Size = new System.Drawing.Size(952, 58);
            this.Panel2.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(821, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 34);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(952, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "ToolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(91, 22);
            this.toolStripButton1.Text = "Export Excel";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // xgcUrgent
            // 
            this.xgcUrgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xgcUrgent.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.xgcUrgent.Location = new System.Drawing.Point(11, 57);
            this.xgcUrgent.MainView = this.xdgvUrgent;
            this.xgcUrgent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.xgcUrgent.Name = "xgcUrgent";
            this.xgcUrgent.Size = new System.Drawing.Size(930, 381);
            this.xgcUrgent.TabIndex = 45;
            this.xgcUrgent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.xdgvUrgent});
            // 
            // xdgvUrgent
            // 
            this.xdgvUrgent.Appearance.EvenRow.BackColor = System.Drawing.Color.Azure;
            this.xdgvUrgent.Appearance.EvenRow.Options.UseBackColor = true;
            this.xdgvUrgent.Appearance.GroupRow.BackColor = System.Drawing.Color.White;
            this.xdgvUrgent.Appearance.GroupRow.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xdgvUrgent.Appearance.GroupRow.Options.UseBackColor = true;
            this.xdgvUrgent.Appearance.GroupRow.Options.UseFont = true;
            this.xdgvUrgent.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xdgvUrgent.Appearance.HeaderPanel.Options.UseFont = true;
            this.xdgvUrgent.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.xdgvUrgent.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xdgvUrgent.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xdgvUrgent.Appearance.Row.Options.UseFont = true;
            this.xdgvUrgent.ColumnPanelRowHeight = 35;
            this.xdgvUrgent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumn5,
            this.GridColumn10,
            this.GridColumn1,
            this.GridColumn2,
            this.GridColumn8,
            this.GridColumn3,
            this.GridColumn7,
            this.GridColumn6,
            this.GridColumn9,
            this.GridColumn4,
            this.GridColumn11});
            this.xdgvUrgent.GridControl = this.xgcUrgent;
            this.xdgvUrgent.GroupCount = 1;
            this.xdgvUrgent.LevelIndent = 0;
            this.xdgvUrgent.Name = "xdgvUrgent";
            this.xdgvUrgent.OptionsBehavior.Editable = false;
            this.xdgvUrgent.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.xdgvUrgent.OptionsView.EnableAppearanceEvenRow = true;
            this.xdgvUrgent.OptionsView.ShowGroupPanel = false;
            this.xdgvUrgent.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.GridColumn5, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.GridColumn9, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // GridColumn5
            // 
            this.GridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GridColumn5.Caption = "Supplier";
            this.GridColumn5.FieldName = "SupName";
            this.GridColumn5.Name = "GridColumn5";
            this.GridColumn5.OptionsColumn.FixedWidth = true;
            this.GridColumn5.Visible = true;
            this.GridColumn5.VisibleIndex = 0;
            this.GridColumn5.Width = 169;
            // 
            // GridColumn10
            // 
            this.GridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn10.Caption = "Barcode";
            this.GridColumn10.FieldName = "ProNumY";
            this.GridColumn10.Name = "GridColumn10";
            this.GridColumn10.OptionsColumn.FixedWidth = true;
            this.GridColumn10.Visible = true;
            this.GridColumn10.VisibleIndex = 0;
            this.GridColumn10.Width = 113;
            // 
            // GridColumn1
            // 
            this.GridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn1.Caption = "Description";
            this.GridColumn1.FieldName = "ProName";
            this.GridColumn1.Name = "GridColumn1";
            this.GridColumn1.Visible = true;
            this.GridColumn1.VisibleIndex = 1;
            this.GridColumn1.Width = 298;
            // 
            // GridColumn2
            // 
            this.GridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn2.Caption = "Size";
            this.GridColumn2.FieldName = "ProPacksize";
            this.GridColumn2.Name = "GridColumn2";
            this.GridColumn2.OptionsColumn.FixedWidth = true;
            this.GridColumn2.Visible = true;
            this.GridColumn2.VisibleIndex = 2;
            this.GridColumn2.Width = 72;
            // 
            // GridColumn8
            // 
            this.GridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn8.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.GridColumn8.Caption = "Qty Per Case";
            this.GridColumn8.FieldName = "ProQtyPCase";
            this.GridColumn8.Name = "GridColumn8";
            this.GridColumn8.OptionsColumn.FixedWidth = true;
            this.GridColumn8.Visible = true;
            this.GridColumn8.VisibleIndex = 3;
            this.GridColumn8.Width = 58;
            // 
            // GridColumn3
            // 
            this.GridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn3.Caption = "Location";
            this.GridColumn3.FieldName = "location";
            this.GridColumn3.Name = "GridColumn3";
            this.GridColumn3.OptionsColumn.FixedWidth = true;
            this.GridColumn3.Visible = true;
            this.GridColumn3.VisibleIndex = 4;
            this.GridColumn3.Width = 90;
            // 
            // GridColumn7
            // 
            this.GridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn7.Caption = "Level";
            this.GridColumn7.FieldName = "level";
            this.GridColumn7.Name = "GridColumn7";
            this.GridColumn7.OptionsColumn.FixedWidth = true;
            this.GridColumn7.Visible = true;
            this.GridColumn7.VisibleIndex = 5;
            this.GridColumn7.Width = 52;
            // 
            // GridColumn6
            // 
            this.GridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn6.Caption = "Pallet";
            this.GridColumn6.FieldName = "LocName";
            this.GridColumn6.Name = "GridColumn6";
            this.GridColumn6.OptionsColumn.FixedWidth = true;
            this.GridColumn6.Visible = true;
            this.GridColumn6.VisibleIndex = 6;
            this.GridColumn6.Width = 58;
            // 
            // GridColumn9
            // 
            this.GridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn9.Caption = "Expiry";
            this.GridColumn9.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn9.FieldName = "Expiry";
            this.GridColumn9.Name = "GridColumn9";
            this.GridColumn9.OptionsColumn.FixedWidth = true;
            this.GridColumn9.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.GridColumn9.Visible = true;
            this.GridColumn9.VisibleIndex = 7;
            this.GridColumn9.Width = 90;
            // 
            // GridColumn4
            // 
            this.GridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.GridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.GridColumn4.Caption = "Warehouse Stock (Pcs)";
            this.GridColumn4.DisplayFormat.FormatString = "N0";
            this.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.GridColumn4.FieldName = "QtyOnHand";
            this.GridColumn4.Name = "GridColumn4";
            this.GridColumn4.OptionsColumn.FixedWidth = true;
            this.GridColumn4.Visible = true;
            this.GridColumn4.VisibleIndex = 8;
            this.GridColumn4.Width = 73;
            // 
            // GridColumn11
            // 
            this.GridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.GridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridColumn11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.GridColumn11.Caption = "Warehouse Stock (Ctn)";
            this.GridColumn11.DisplayFormat.FormatString = "N2";
            this.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.GridColumn11.FieldName = "QtyOnHandCtn";
            this.GridColumn11.Name = "GridColumn11";
            this.GridColumn11.OptionsColumn.FixedWidth = true;
            this.GridColumn11.Visible = true;
            this.GridColumn11.VisibleIndex = 9;
            this.GridColumn11.Width = 78;
            // 
            // DefaultLookAndFeel1
            // 
            this.DefaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
            // 
            // UrgentStockToClear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 553);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "UrgentStockToClear";
            this.Text = "UrgentStockToClear";
            this.Load += new System.EventHandler(this.UrgentStockToClear_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xgcUrgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xdgvUrgent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripButton toolStripButton1;
        internal DevExpress.XtraGrid.GridControl xgcUrgent;
        internal DevExpress.XtraGrid.Views.Grid.GridView xdgvUrgent;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn5;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn10;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn1;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn2;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn8;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn3;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn7;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn6;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn9;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn4;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn11;
        internal DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel1;
    }
}