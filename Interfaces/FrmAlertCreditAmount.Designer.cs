namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmAlertCreditAmount
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
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.InvNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnPreviewAging = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnNo = new System.Windows.Forms.Button();
            this.BtnYes = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LblMsg = new System.Windows.Forms.Label();
            this.lblbankgarantee = new System.Windows.Forms.Label();
            this.PicAlert = new System.Windows.Forms.PictureBox();
            this.loading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvNumber,
            this.PONumber,
            this.ShipDate,
            this.CusNum,
            this.CusName,
            this.DelTo,
            this.GrandTotal});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(0, 87);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(750, 278);
            this.DgvShow.TabIndex = 115;
            // 
            // InvNumber
            // 
            this.InvNumber.DataPropertyName = "invNum";
            this.InvNumber.FillWeight = 11.56349F;
            this.InvNumber.HeaderText = "Invoice #";
            this.InvNumber.Name = "InvNumber";
            this.InvNumber.ReadOnly = true;
            this.InvNumber.Width = 125;
            // 
            // PONumber
            // 
            this.PONumber.DataPropertyName = "poNum";
            this.PONumber.HeaderText = "P.O #";
            this.PONumber.Name = "PONumber";
            this.PONumber.ReadOnly = true;
            this.PONumber.Visible = false;
            this.PONumber.Width = 33;
            // 
            // ShipDate
            // 
            this.ShipDate.DataPropertyName = "invDate";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.ShipDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShipDate.FillWeight = 0.9058067F;
            this.ShipDate.HeaderText = "Invoice Date";
            this.ShipDate.Name = "ShipDate";
            this.ShipDate.ReadOnly = true;
            // 
            // CusNum
            // 
            this.CusNum.DataPropertyName = "cusNum";
            this.CusNum.HeaderText = "Cus. #";
            this.CusNum.Name = "CusNum";
            this.CusNum.ReadOnly = true;
            this.CusNum.Visible = false;
            // 
            // CusName
            // 
            this.CusName.DataPropertyName = "cusName";
            this.CusName.FillWeight = 45.57738F;
            this.CusName.HeaderText = "Customer Name";
            this.CusName.Name = "CusName";
            this.CusName.ReadOnly = true;
            this.CusName.Width = 150;
            // 
            // DelTo
            // 
            this.DelTo.DataPropertyName = "delto";
            this.DelTo.FillWeight = 188.1462F;
            this.DelTo.HeaderText = "DelTo";
            this.DelTo.Name = "DelTo";
            this.DelTo.ReadOnly = true;
            this.DelTo.Width = 150;
            // 
            // GrandTotal
            // 
            this.GrandTotal.DataPropertyName = "creditOver";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "$ #,###,##0.00;(#,###,##0.00)";
            this.GrandTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrandTotal.FillWeight = 253.8071F;
            this.GrandTotal.HeaderText = "Amount";
            this.GrandTotal.Name = "GrandTotal";
            this.GrandTotal.ReadOnly = true;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnPreviewAging);
            this.Panel2.Controls.Add(this.BtnOK);
            this.Panel2.Controls.Add(this.BtnNo);
            this.Panel2.Controls.Add(this.BtnYes);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 365);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel2.Size = new System.Drawing.Size(750, 36);
            this.Panel2.TabIndex = 116;
            // 
            // btnPreviewAging
            // 
            this.btnPreviewAging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewAging.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviewAging.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPreviewAging.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPreviewAging.Image = global::DeliveryTakeOrder.Properties.Resources.view_takeorder;
            this.btnPreviewAging.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreviewAging.Location = new System.Drawing.Point(620, 2);
            this.btnPreviewAging.Name = "btnPreviewAging";
            this.btnPreviewAging.Size = new System.Drawing.Size(127, 32);
            this.btnPreviewAging.TabIndex = 116;
            this.btnPreviewAging.Text = "&Preview Aging";
            this.btnPreviewAging.UseVisualStyleBackColor = true;
            this.btnPreviewAging.Click += new System.EventHandler(this.btnPreviewAging_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOK.Image = global::DeliveryTakeOrder.Properties.Resources.OK;
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(313, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(115, 32);
            this.BtnOK.TabIndex = 113;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Visible = false;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnNo
            // 
            this.BtnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.BtnNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnNo.Image = global::DeliveryTakeOrder.Properties.Resources.Cancel16;
            this.BtnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNo.Location = new System.Drawing.Point(373, 2);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Size = new System.Drawing.Size(115, 32);
            this.BtnNo.TabIndex = 115;
            this.BtnNo.Text = "&No";
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.Visible = false;
            // 
            // BtnYes
            // 
            this.BtnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.BtnYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnYes.Image = global::DeliveryTakeOrder.Properties.Resources.OK;
            this.BtnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnYes.Location = new System.Drawing.Point(252, 2);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Size = new System.Drawing.Size(115, 32);
            this.BtnYes.TabIndex = 114;
            this.BtnYes.Text = "&Yes";
            this.BtnYes.UseVisualStyleBackColor = true;
            this.BtnYes.Visible = false;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.LblMsg);
            this.Panel1.Controls.Add(this.lblbankgarantee);
            this.Panel1.Controls.Add(this.PicAlert);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(750, 87);
            this.Panel1.TabIndex = 114;
            // 
            // LblMsg
            // 
            this.LblMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblMsg.Location = new System.Drawing.Point(38, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(712, 62);
            this.LblMsg.TabIndex = 0;
            // 
            // lblbankgarantee
            // 
            this.lblbankgarantee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblbankgarantee.ForeColor = System.Drawing.Color.Teal;
            this.lblbankgarantee.Location = new System.Drawing.Point(38, 62);
            this.lblbankgarantee.Name = "lblbankgarantee";
            this.lblbankgarantee.Size = new System.Drawing.Size(712, 25);
            this.lblbankgarantee.TabIndex = 2;
            this.lblbankgarantee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PicAlert
            // 
            this.PicAlert.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicAlert.Image = global::DeliveryTakeOrder.Properties.Resources.Alert;
            this.PicAlert.Location = new System.Drawing.Point(0, 0);
            this.PicAlert.Name = "PicAlert";
            this.PicAlert.Size = new System.Drawing.Size(38, 87);
            this.PicAlert.TabIndex = 1;
            this.PicAlert.TabStop = false;
            // 
            // loading
            // 
            this.loading.Interval = 5;
            this.loading.Tick += new System.EventHandler(this.loading_Tick);
            // 
            // ar_aging_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 401);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ar_aging_form";
            this.Text = "ar_aging_form";
            this.Load += new System.EventHandler(this.FrmAlertCreditAmount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn InvNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PONumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ShipDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DelTo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn GrandTotal;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnPreviewAging;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.Button BtnNo;
        internal System.Windows.Forms.Button BtnYes;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.Label lblbankgarantee;
        internal System.Windows.Forms.PictureBox PicAlert;
        internal System.Windows.Forms.Timer loading;
    }
}