namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDutchmillTakeOrderViewSummaryCredit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDutchmillTakeOrderViewSummaryCredit));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditLimitAllow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatestInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel44.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CusNum,
            this.CusName,
            this.DelTo,
            this.GrandTotal,
            this.CreditLimit,
            this.CreditLimitAllow,
            this.LatestInvoice,
            this.OverCredit});
            this.DgvShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(6, 7);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(845, 381);
            this.DgvShow.TabIndex = 114;
            // 
            // CusNum
            // 
            this.CusNum.DataPropertyName = "CusNum";
            this.CusNum.HeaderText = "Customer #";
            this.CusNum.Name = "CusNum";
            this.CusNum.ReadOnly = true;
            this.CusNum.Visible = false;
            this.CusNum.Width = 106;
            // 
            // CusName
            // 
            this.CusName.DataPropertyName = "CusName";
            this.CusName.HeaderText = "Customer Name";
            this.CusName.Name = "CusName";
            this.CusName.ReadOnly = true;
            this.CusName.Width = 105;
            // 
            // DelTo
            // 
            this.DelTo.DataPropertyName = "DelTo";
            this.DelTo.HeaderText = "DelTo";
            this.DelTo.Name = "DelTo";
            this.DelTo.ReadOnly = true;
            this.DelTo.Width = 106;
            // 
            // GrandTotal
            // 
            this.GrandTotal.DataPropertyName = "GrandTotal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            this.GrandTotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrandTotal.HeaderText = "Grand Total";
            this.GrandTotal.Name = "GrandTotal";
            this.GrandTotal.ReadOnly = true;
            this.GrandTotal.Width = 106;
            // 
            // CreditLimit
            // 
            this.CreditLimit.DataPropertyName = "CreditLimit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.CreditLimit.DefaultCellStyle = dataGridViewCellStyle2;
            this.CreditLimit.HeaderText = "Credit Limit";
            this.CreditLimit.Name = "CreditLimit";
            this.CreditLimit.ReadOnly = true;
            // 
            // CreditLimitAllow
            // 
            this.CreditLimitAllow.DataPropertyName = "CreditLimitAllow";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.CreditLimitAllow.DefaultCellStyle = dataGridViewCellStyle3;
            this.CreditLimitAllow.HeaderText = "Credit Allow";
            this.CreditLimitAllow.Name = "CreditLimitAllow";
            this.CreditLimitAllow.ReadOnly = true;
            // 
            // LatestInvoice
            // 
            this.LatestInvoice.DataPropertyName = "LatestInvoice";
            this.LatestInvoice.HeaderText = "Latest Invoice";
            this.LatestInvoice.Name = "LatestInvoice";
            this.LatestInvoice.ReadOnly = true;
            // 
            // OverCredit
            // 
            this.OverCredit.DataPropertyName = "OverCredit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.OverCredit.DefaultCellStyle = dataGridViewCellStyle4;
            this.OverCredit.HeaderText = "Over Credit";
            this.OverCredit.Name = "OverCredit";
            this.OverCredit.ReadOnly = true;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.LblCountRow);
            this.Panel44.Controls.Add(this.BtnExportToExcel);
            this.Panel44.Controls.Add(this.BtnCancel);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(6, 388);
            this.Panel44.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel44.Size = new System.Drawing.Size(845, 36);
            this.Panel44.TabIndex = 113;
            // 
            // LblCountRow
            // 
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblCountRow.Location = new System.Drawing.Point(2, 3);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Size = new System.Drawing.Size(122, 30);
            this.LblCountRow.TabIndex = 12;
            this.LblCountRow.Text = "Count Row : 0";
            this.LblCountRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(566, 3);
            this.BtnExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(184, 30);
            this.BtnExportToExcel.TabIndex = 10;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(750, 3);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(93, 30);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmDutchmillTakeOrderViewSummaryCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 431);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel44);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDutchmillTakeOrderViewSummaryCredit";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Over Credit ~ Customer List";
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel44.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DelTo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn GrandTotal;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreditLimit;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreditLimitAllow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn LatestInvoice;
        internal System.Windows.Forms.DataGridViewTextBoxColumn OverCredit;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Button BtnCancel;
    }
}