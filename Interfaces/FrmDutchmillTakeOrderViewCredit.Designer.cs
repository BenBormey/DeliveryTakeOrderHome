
namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDutchmillTakeOrderViewCredit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDutchmillTakeOrderViewCredit));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.InvNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.DisplayLoading = new System.Windows.Forms.Timer(this.components);
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
            this.InvNumber,
            this.PONumber,
            this.CusNum,
            this.CusName,
            this.ShipDate,
            this.DelTo,
            this.GrandTotal});
            this.DgvShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(6, 7);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(768, 381);
            this.DgvShow.TabIndex = 114;
            // 
            // InvNumber
            // 
            this.InvNumber.DataPropertyName = "InvNumber";
            this.InvNumber.HeaderText = "Invoice #";
            this.InvNumber.Name = "InvNumber";
            this.InvNumber.ReadOnly = true;
            this.InvNumber.Width = 106;
            // 
            // PONumber
            // 
            this.PONumber.DataPropertyName = "PONumber";
            this.PONumber.HeaderText = "P.O #";
            this.PONumber.Name = "PONumber";
            this.PONumber.ReadOnly = true;
            this.PONumber.Width = 106;
            // 
            // CusNum
            // 
            this.CusNum.DataPropertyName = "CusNum";
            this.CusNum.HeaderText = "Customer #";
            this.CusNum.Name = "CusNum";
            this.CusNum.ReadOnly = true;
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
            // ShipDate
            // 
            this.ShipDate.DataPropertyName = "ShipDate";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.ShipDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShipDate.HeaderText = "Ship Date";
            this.ShipDate.Name = "ShipDate";
            this.ShipDate.ReadOnly = true;
            this.ShipDate.Width = 106;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.GrandTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrandTotal.HeaderText = "Amount";
            this.GrandTotal.Name = "GrandTotal";
            this.GrandTotal.ReadOnly = true;
            this.GrandTotal.Width = 106;
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
            this.Panel44.Size = new System.Drawing.Size(768, 36);
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
            this.BtnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(489, 3);
            this.BtnExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(184, 30);
            this.BtnExportToExcel.TabIndex = 10;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(673, 3);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(93, 30);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // DisplayLoading
            // 
            this.DisplayLoading.Interval = 5;
            this.DisplayLoading.Tick += new System.EventHandler(this.DisplayLoading_Tick);
            // 
            // FrmDutchmillTakeOrderViewCredit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 431);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel44);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDutchmillTakeOrderViewCredit";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDutchmillTakeOrderViewCredit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDutchmillTakeOrderViewCredit_FormClosed);
            this.Load += new System.EventHandler(this.FrmDutchmillTakeOrderViewCredit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel44.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn InvNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PONumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ShipDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DelTo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn GrandTotal;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Timer DisplayLoading;
    }
}