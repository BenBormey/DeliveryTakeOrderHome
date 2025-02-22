
namespace DeliveryTakeOrder.Interfaces.WS_Products_List
{
    partial class FrmOverCreditAmountOrCreditTerm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditLimitAllow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxMonthAllow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Average = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicAlert = new System.Windows.Forms.PictureBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAlert)).BeginInit();
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
            this.CusNum,
            this.CusCom,
            this.GrandTotal,
            this.Overday,
            this.CreditLimitAllow,
            this.MaxMonthAllow,
            this.Average});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(43, 5);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(800, 333);
            this.DgvShow.TabIndex = 115;
            this.DgvShow.UseWaitCursor = true;
            this.DgvShow.Visible = false;
            // 
            // CusNum
            // 
            this.CusNum.DataPropertyName = "CusNum";
            this.CusNum.HeaderText = "Cus. #";
            this.CusNum.Name = "CusNum";
            this.CusNum.ReadOnly = true;
            this.CusNum.Width = 62;
            // 
            // CusCom
            // 
            this.CusCom.DataPropertyName = "CusCom";
            this.CusCom.HeaderText = "Customer";
            this.CusCom.Name = "CusCom";
            this.CusCom.ReadOnly = true;
            this.CusCom.Width = 86;
            // 
            // GrandTotal
            // 
            this.GrandTotal.DataPropertyName = "GrandTotal";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "C2";
            this.GrandTotal.DefaultCellStyle = dataGridViewCellStyle11;
            this.GrandTotal.HeaderText = "Grand Total";
            this.GrandTotal.Name = "GrandTotal";
            this.GrandTotal.ReadOnly = true;
            this.GrandTotal.Width = 92;
            // 
            // Overday
            // 
            this.Overday.DataPropertyName = "Overday";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "N0";
            this.Overday.DefaultCellStyle = dataGridViewCellStyle12;
            this.Overday.HeaderText = "Over Day";
            this.Overday.Name = "Overday";
            this.Overday.ReadOnly = true;
            this.Overday.Width = 79;
            // 
            // CreditLimitAllow
            // 
            this.CreditLimitAllow.DataPropertyName = "CreditLimitAllow";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "C2";
            this.CreditLimitAllow.DefaultCellStyle = dataGridViewCellStyle13;
            this.CreditLimitAllow.HeaderText = "Credit (Allow)";
            this.CreditLimitAllow.Name = "CreditLimitAllow";
            this.CreditLimitAllow.ReadOnly = true;
            // 
            // MaxMonthAllow
            // 
            this.MaxMonthAllow.DataPropertyName = "MaxMonthAllow";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "N0";
            this.MaxMonthAllow.DefaultCellStyle = dataGridViewCellStyle14;
            this.MaxMonthAllow.HeaderText = "Term (Allow)";
            this.MaxMonthAllow.Name = "MaxMonthAllow";
            this.MaxMonthAllow.ReadOnly = true;
            this.MaxMonthAllow.Width = 95;
            // 
            // Average
            // 
            this.Average.DataPropertyName = "Average";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "C2";
            this.Average.DefaultCellStyle = dataGridViewCellStyle15;
            this.Average.HeaderText = "Average (Last 3 Months)";
            this.Average.Name = "Average";
            this.Average.ReadOnly = true;
            this.Average.Width = 114;
            // 
            // PicAlert
            // 
            this.PicAlert.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicAlert.Image = global::DeliveryTakeOrder.Properties.Resources.Alert;
            this.PicAlert.Location = new System.Drawing.Point(5, 5);
            this.PicAlert.Name = "PicAlert";
            this.PicAlert.Size = new System.Drawing.Size(38, 333);
            this.PicAlert.TabIndex = 117;
            this.PicAlert.TabStop = false;
            this.PicAlert.UseWaitCursor = true;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnExportToExcel);
            this.Panel2.Controls.Add(this.BtnOK);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(5, 338);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel2.Size = new System.Drawing.Size(838, 36);
            this.Panel2.TabIndex = 116;
            this.Panel2.UseWaitCursor = true;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(702, 2);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(136, 32);
            this.BtnExportToExcel.TabIndex = 114;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.UseWaitCursor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOK.Image = global::DeliveryTakeOrder.Properties.Resources.OK;
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(340, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(115, 32);
            this.BtnOK.TabIndex = 113;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.UseWaitCursor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // FrmOverCreditAmountOrCreditTerm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 379);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.PicAlert);
            this.Controls.Add(this.Panel2);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmOverCreditAmountOrCreditTerm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Credit Amount";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.FrmOverCreditAmountOrCreditTerm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAlert)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusCom;
        internal System.Windows.Forms.DataGridViewTextBoxColumn GrandTotal;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Overday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreditLimitAllow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn MaxMonthAllow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Average;
        internal System.Windows.Forms.PictureBox PicAlert;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Button BtnOK;
    }
}