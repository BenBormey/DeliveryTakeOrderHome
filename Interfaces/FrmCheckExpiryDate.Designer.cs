namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmCheckExpiryDate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckExpiryDate));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.warehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyPerCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmbWarehouseName = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.Loading = new System.Windows.Forms.Timer(this.components);
            this.warehouseNameLoading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWarehouseName.Properties)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.warehouseName,
            this.unitNumber,
            this.proName,
            this.size,
            this.qtyPerCase,
            this.batchcode,
            this.expiryDate,
            this.Stock,
            this.Status,
            this.CurDate});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(4, 40);
            this.DgvShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(626, 298);
            this.DgvShow.TabIndex = 115;
            this.DgvShow.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvShow_RowPrePaint);
            this.DgvShow.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvShow_Paint);
            // 
            // warehouseName
            // 
            this.warehouseName.DataPropertyName = "warehouseName";
            this.warehouseName.HeaderText = "Warehouse Name";
            this.warehouseName.Name = "warehouseName";
            this.warehouseName.ReadOnly = true;
            this.warehouseName.Width = 150;
            // 
            // unitNumber
            // 
            this.unitNumber.DataPropertyName = "unitNumber";
            this.unitNumber.HeaderText = "Barcode";
            this.unitNumber.Name = "unitNumber";
            this.unitNumber.ReadOnly = true;
            this.unitNumber.Visible = false;
            // 
            // proName
            // 
            this.proName.DataPropertyName = "proName";
            this.proName.HeaderText = "Description";
            this.proName.Name = "proName";
            this.proName.ReadOnly = true;
            this.proName.Visible = false;
            // 
            // size
            // 
            this.size.DataPropertyName = "size";
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Visible = false;
            // 
            // qtyPerCase
            // 
            this.qtyPerCase.DataPropertyName = "qtyPerCase";
            this.qtyPerCase.HeaderText = "Q/C";
            this.qtyPerCase.Name = "qtyPerCase";
            this.qtyPerCase.ReadOnly = true;
            this.qtyPerCase.Visible = false;
            // 
            // batchcode
            // 
            this.batchcode.DataPropertyName = "batchcode";
            this.batchcode.HeaderText = "Batchcode";
            this.batchcode.Name = "batchcode";
            this.batchcode.ReadOnly = true;
            this.batchcode.Width = 125;
            // 
            // expiryDate
            // 
            this.expiryDate.DataPropertyName = "expiryDate";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.expiryDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.expiryDate.HeaderText = "Expiry Date";
            this.expiryDate.Name = "expiryDate";
            this.expiryDate.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            this.Stock.DefaultCellStyle = dataGridViewCellStyle2;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // CurDate
            // 
            this.CurDate.DataPropertyName = "CurDate";
            this.CurDate.HeaderText = "CurDate";
            this.CurDate.Name = "CurDate";
            this.CurDate.ReadOnly = true;
            this.CurDate.Visible = false;
            this.CurDate.Width = 79;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmbWarehouseName);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(4, 3);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Panel1.Size = new System.Drawing.Size(626, 37);
            this.Panel1.TabIndex = 117;
            // 
            // cmbWarehouseName
            // 
            this.cmbWarehouseName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWarehouseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbWarehouseName.EditValue = "";
            this.cmbWarehouseName.Location = new System.Drawing.Point(2, 14);
            this.cmbWarehouseName.Name = "cmbWarehouseName";
            this.cmbWarehouseName.Properties.AllowMultiSelect = true;
            this.cmbWarehouseName.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouseName.Properties.Appearance.Options.UseFont = true;
            this.cmbWarehouseName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbWarehouseName.Properties.DropDownRows = 25;
            this.cmbWarehouseName.Properties.IncrementalSearch = true;
            this.cmbWarehouseName.Size = new System.Drawing.Size(622, 20);
            this.cmbWarehouseName.TabIndex = 139;
            this.cmbWarehouseName.ToolTip = "Please select any sd name";
            this.cmbWarehouseName.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cmbWarehouseName_Closed);
            this.cmbWarehouseName.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.cmbWarehouseName_CustomDisplayText);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(2, 1);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(112, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "Warehouse Name:";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnOK);
            this.Panel2.Controls.Add(this.BtnExport);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(4, 338);
            this.Panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Panel2.Size = new System.Drawing.Size(626, 35);
            this.Panel2.TabIndex = 116;
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOK.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnOK.Image = global::DeliveryTakeOrder.Properties.Resources.OK;
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(374, 1);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(131, 33);
            this.BtnOK.TabIndex = 113;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click_1);
            // 
            // BtnExport
            // 
            this.BtnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExport.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExport.Image = global::DeliveryTakeOrder.Properties.Resources.view_takeorder;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExport.Location = new System.Drawing.Point(505, 1);
            this.BtnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(119, 33);
            this.BtnExport.TabIndex = 114;
            this.BtnExport.Text = "&Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // Loading
            // 
            this.Loading.Interval = 5;
            this.Loading.Tick += new System.EventHandler(this.Loading_Tick);
            // 
            // warehouseNameLoading
            // 
            this.warehouseNameLoading.Interval = 5;
            this.warehouseNameLoading.Tick += new System.EventHandler(this.warehouseNameLoading_Tick);
            // 
            // FrmCheckExpiryDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 376);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCheckExpiryDate";
            this.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Text = "Expiry Date";
            this.Load += new System.EventHandler(this.FrmCheckExpiryDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWarehouseName.Properties)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn warehouseName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn unitNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn proName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn size;
        internal System.Windows.Forms.DataGridViewTextBoxColumn qtyPerCase;
        internal System.Windows.Forms.DataGridViewTextBoxColumn batchcode;
        internal System.Windows.Forms.DataGridViewTextBoxColumn expiryDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Status;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CurDate;
        internal System.Windows.Forms.Panel Panel1;
        internal DevExpress.XtraEditors.CheckedComboBoxEdit cmbWarehouseName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.Button BtnExport;
        internal System.Windows.Forms.Timer Loading;
        internal System.Windows.Forms.Timer warehouseNameLoading;
    }
}