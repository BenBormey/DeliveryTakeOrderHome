namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmAlertBadPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlertBadPayment));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnNo = new System.Windows.Forms.Button();
            this.BtnYes = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LblMsg = new System.Windows.Forms.Label();
            this.PicAlert = new System.Windows.Forms.PictureBox();
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
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvShow.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CusNum,
            this.CusName,
            this.Remark,
            this.AlertDate,
            this.BlockDate,
            this.CreatedDate,
            this.Status});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(5, 103);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(796, 201);
            this.DgvShow.TabIndex = 115;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 41;
            // 
            // CusNum
            // 
            this.CusNum.DataPropertyName = "CusNum";
            this.CusNum.HeaderText = "CusNum";
            this.CusNum.Name = "CusNum";
            this.CusNum.ReadOnly = true;
            this.CusNum.Width = 79;
            // 
            // CusName
            // 
            this.CusName.DataPropertyName = "CusName";
            this.CusName.HeaderText = "CusName";
            this.CusName.Name = "CusName";
            this.CusName.ReadOnly = true;
            this.CusName.Width = 86;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 76;
            // 
            // AlertDate
            // 
            this.AlertDate.DataPropertyName = "AlertDate";
            dataGridViewCellStyle1.Format = "dd-MMM-yy";
            this.AlertDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.AlertDate.HeaderText = "Alert Date";
            this.AlertDate.Name = "AlertDate";
            this.AlertDate.ReadOnly = true;
            this.AlertDate.Width = 90;
            // 
            // BlockDate
            // 
            this.BlockDate.DataPropertyName = "BlockDate";
            dataGridViewCellStyle2.Format = "dd-MMM-yy";
            this.BlockDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.BlockDate.HeaderText = "Block Date";
            this.BlockDate.Name = "BlockDate";
            this.BlockDate.ReadOnly = true;
            this.BlockDate.Width = 95;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "CreatedDate";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Visible = false;
            this.CreatedDate.Width = 92;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 69;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnExit);
            this.Panel2.Controls.Add(this.BtnNo);
            this.Panel2.Controls.Add(this.BtnYes);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(5, 304);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel2.Size = new System.Drawing.Size(796, 36);
            this.Panel2.TabIndex = 116;
            // 
            // BtnExit
            // 
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExit.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExit.Location = new System.Drawing.Point(696, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(100, 32);
            this.BtnExit.TabIndex = 116;
            this.BtnExit.Text = "&Cancel";
            this.BtnExit.UseVisualStyleBackColor = true;
            // 
            // BtnNo
            // 
            this.BtnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.BtnNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnNo.Image = global::DeliveryTakeOrder.Properties.Resources.minus_16;
            this.BtnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNo.Location = new System.Drawing.Point(401, 2);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Size = new System.Drawing.Size(108, 32);
            this.BtnNo.TabIndex = 115;
            this.BtnNo.Text = "&No";
            this.BtnNo.UseVisualStyleBackColor = true;
            // 
            // BtnYes
            // 
            this.BtnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.BtnYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnYes.Image = global::DeliveryTakeOrder.Properties.Resources.OK;
            this.BtnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnYes.Location = new System.Drawing.Point(287, 2);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Size = new System.Drawing.Size(108, 32);
            this.BtnYes.TabIndex = 114;
            this.BtnYes.Text = "&Yes";
            this.BtnYes.UseVisualStyleBackColor = true;
            this.BtnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.LblMsg);
            this.Panel1.Controls.Add(this.PicAlert);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(796, 98);
            this.Panel1.TabIndex = 114;
            // 
            // LblMsg
            // 
            this.LblMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMsg.Font = new System.Drawing.Font("Khmer OS Battambang", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblMsg.Location = new System.Drawing.Point(38, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.LblMsg.Size = new System.Drawing.Size(758, 98);
            this.LblMsg.TabIndex = 0;
            this.LblMsg.Text = resources.GetString("LblMsg.Text");
            // 
            // PicAlert
            // 
            this.PicAlert.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicAlert.Image = global::DeliveryTakeOrder.Properties.Resources.Alert;
            this.PicAlert.Location = new System.Drawing.Point(0, 0);
            this.PicAlert.Name = "PicAlert";
            this.PicAlert.Size = new System.Drawing.Size(38, 98);
            this.PicAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicAlert.TabIndex = 1;
            this.PicAlert.TabStop = false;
            // 
            // FrmAlertBadPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 345);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAlertBadPayment";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bad Payment";
            this.Load += new System.EventHandler(this.FrmAlertBadPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        internal System.Windows.Forms.DataGridViewTextBoxColumn AlertDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn BlockDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Status;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnExit;
        internal System.Windows.Forms.Button BtnNo;
        internal System.Windows.Forms.Button BtnYes;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.PictureBox PicAlert;
    }
}