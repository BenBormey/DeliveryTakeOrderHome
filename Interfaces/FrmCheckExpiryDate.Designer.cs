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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckExpiryDate));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvShow.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Expiry,
            this.Stock,
            this.Status,
            this.CurDate});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(5, 5);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(323, 214);
            this.DgvShow.TabIndex = 114;
            // 
            // Expiry
            // 
            this.Expiry.DataPropertyName = "Expiry";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.Expiry.DefaultCellStyle = dataGridViewCellStyle1;
            this.Expiry.HeaderText = "Expiry";
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            this.Expiry.Width = 69;
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
            this.Stock.Width = 66;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 69;
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
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnOK);
            this.Panel2.Controls.Add(this.BtnExport);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(5, 219);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(323, 36);
            this.Panel2.TabIndex = 115;
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOK.Image = global::DeliveryTakeOrder.Properties.Resources.OK;
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(74, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(123, 32);
            this.BtnOK.TabIndex = 113;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // BtnExport
            // 
            this.BtnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExport.Image = global::DeliveryTakeOrder.Properties.Resources.view_takeorder;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExport.Location = new System.Drawing.Point(197, 2);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(124, 32);
            this.BtnExport.TabIndex = 114;
            this.BtnExport.Text = "&Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            // 
            // FrmCheckExpiryDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 260);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel2);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCheckExpiryDate";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Expiry Date";
            this.Load += new System.EventHandler(this.FrmCheckExpiryDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Status;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CurDate;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.Button BtnExport;
    }
}