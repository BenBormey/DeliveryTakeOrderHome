namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmLockInvoicingDocumentARIN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.allowedday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeltoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateShip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
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
            this.allowedday,
            this.overday,
            this.Id,
            this.CusNum,
            this.CusName,
            this.DeliveryDate,
            this.SubTotal,
            this.Dis,
            this.Ser,
            this.Total,
            this.Vat,
            this.ReceiptNo,
            this.ReceiptDate,
            this.DeltoId,
            this.Delto,
            this.InvNumber,
            this.DateShip,
            this.GrandTotal,
            this.Department});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(0, 98);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(806, 211);
            this.DgvShow.TabIndex = 115;
            // 
            // allowedday
            // 
            this.allowedday.DataPropertyName = "allowedday";
            this.allowedday.HeaderText = "Allowed Day";
            this.allowedday.Name = "allowedday";
            this.allowedday.ReadOnly = true;
            this.allowedday.Width = 104;
            // 
            // overday
            // 
            this.overday.DataPropertyName = "overday";
            this.overday.HeaderText = "Over Day";
            this.overday.Name = "overday";
            this.overday.ReadOnly = true;
            this.overday.Width = 86;
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
            this.CusNum.Visible = false;
            this.CusNum.Width = 72;
            // 
            // CusName
            // 
            this.CusName.DataPropertyName = "CusName";
            this.CusName.HeaderText = "CusName";
            this.CusName.Name = "CusName";
            this.CusName.ReadOnly = true;
            this.CusName.Visible = false;
            this.CusName.Width = 78;
            // 
            // DeliveryDate
            // 
            this.DeliveryDate.DataPropertyName = "DeliveryDate";
            this.DeliveryDate.HeaderText = "DeliveryDate";
            this.DeliveryDate.Name = "DeliveryDate";
            this.DeliveryDate.ReadOnly = true;
            this.DeliveryDate.Visible = false;
            this.DeliveryDate.Width = 93;
            // 
            // SubTotal
            // 
            this.SubTotal.DataPropertyName = "SubTotal";
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Visible = false;
            this.SubTotal.Width = 75;
            // 
            // Dis
            // 
            this.Dis.DataPropertyName = "Dis";
            this.Dis.HeaderText = "Dis";
            this.Dis.Name = "Dis";
            this.Dis.ReadOnly = true;
            this.Dis.Visible = false;
            this.Dis.Width = 47;
            // 
            // Ser
            // 
            this.Ser.DataPropertyName = "Ser";
            this.Ser.HeaderText = "Ser";
            this.Ser.Name = "Ser";
            this.Ser.ReadOnly = true;
            this.Ser.Visible = false;
            this.Ser.Width = 48;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Visible = false;
            this.Total.Width = 56;
            // 
            // Vat
            // 
            this.Vat.DataPropertyName = "Vat";
            this.Vat.HeaderText = "Vat";
            this.Vat.Name = "Vat";
            this.Vat.ReadOnly = true;
            this.Vat.Visible = false;
            this.Vat.Width = 48;
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.DataPropertyName = "ReceiptNo";
            this.ReceiptNo.HeaderText = "ReceiptNo";
            this.ReceiptNo.Name = "ReceiptNo";
            this.ReceiptNo.ReadOnly = true;
            this.ReceiptNo.Visible = false;
            this.ReceiptNo.Width = 83;
            // 
            // ReceiptDate
            // 
            this.ReceiptDate.DataPropertyName = "ReceiptDate";
            this.ReceiptDate.HeaderText = "ReceiptDate";
            this.ReceiptDate.Name = "ReceiptDate";
            this.ReceiptDate.ReadOnly = true;
            this.ReceiptDate.Visible = false;
            this.ReceiptDate.Width = 92;
            // 
            // DeltoId
            // 
            this.DeltoId.DataPropertyName = "DeltoId";
            this.DeltoId.HeaderText = "Outlet #";
            this.DeltoId.Name = "DeltoId";
            this.DeltoId.ReadOnly = true;
            this.DeltoId.Width = 77;
            // 
            // Delto
            // 
            this.Delto.DataPropertyName = "Delto";
            this.Delto.HeaderText = "Outlet";
            this.Delto.Name = "Delto";
            this.Delto.ReadOnly = true;
            this.Delto.Width = 68;
            // 
            // InvNumber
            // 
            this.InvNumber.DataPropertyName = "InvNumber";
            this.InvNumber.HeaderText = "Inv. Number";
            this.InvNumber.Name = "InvNumber";
            this.InvNumber.ReadOnly = true;
            this.InvNumber.Width = 99;
            // 
            // DateShip
            // 
            this.DateShip.DataPropertyName = "DateShip";
            dataGridViewCellStyle3.Format = "dd-MMM-yy";
            this.DateShip.DefaultCellStyle = dataGridViewCellStyle3;
            this.DateShip.HeaderText = "Inv. Date";
            this.DateShip.Name = "DateShip";
            this.DateShip.ReadOnly = true;
            this.DateShip.Width = 83;
            // 
            // GrandTotal
            // 
            this.GrandTotal.DataPropertyName = "GrandTotal";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.GrandTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.GrandTotal.HeaderText = "Amount";
            this.GrandTotal.Name = "GrandTotal";
            this.GrandTotal.ReadOnly = true;
            this.GrandTotal.Width = 77;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Department";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Width = 98;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnYes);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 309);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel2.Size = new System.Drawing.Size(806, 36);
            this.Panel2.TabIndex = 116;
            // 
            // BtnYes
            // 
            this.BtnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.BtnYes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnYes.Location = new System.Drawing.Point(317, 2);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Size = new System.Drawing.Size(163, 32);
            this.BtnYes.TabIndex = 114;
            this.BtnYes.Text = "&OK";
            this.BtnYes.UseVisualStyleBackColor = true;
            this.BtnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.LblMsg);
            this.Panel1.Controls.Add(this.PicAlert);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(806, 98);
            this.Panel1.TabIndex = 114;
            // 
            // LblMsg
            // 
            this.LblMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMsg.Font = new System.Drawing.Font("Khmer OS Battambang", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblMsg.Location = new System.Drawing.Point(38, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.LblMsg.Size = new System.Drawing.Size(768, 98);
            this.LblMsg.TabIndex = 0;
            this.LblMsg.Text = "សូមពិនិត្យមើលលេខវិក្កយបត្រទាំងនេះ, មិនអនុញ្ញាត អោយចេញវិក្កយបត្របន្ថែមទៀតទេ\r\nវិក្ក" +
    "យបត្រទាំងនេះ មិនទាន់យកចូលដល់ក្រុមហ៊ុនទេ\r\nសូមទាក់ទងទៅកាន់ Document AR IN ដើម្បីបញ" +
    "្ជាក់ពីមូលហេតុ";
            this.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicAlert
            // 
            this.PicAlert.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicAlert.Image = global::DeliveryTakeOrder.Properties.Resources._alert;
            this.PicAlert.Location = new System.Drawing.Point(0, 0);
            this.PicAlert.Name = "PicAlert";
            this.PicAlert.Size = new System.Drawing.Size(38, 98);
            this.PicAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicAlert.TabIndex = 1;
            this.PicAlert.TabStop = false;
            // 
            // FrmLockInvoicingDocumentARIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 345);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLockInvoicingDocumentARIN";
            this.Text = "FrmLockInvoicingDocumentARIN";
            this.Load += new System.EventHandler(this.FrmLockInvoicingDocumentARIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn allowedday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn overday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DeliveryDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Dis;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Ser;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Total;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Vat;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DeltoId;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Delto;
        internal System.Windows.Forms.DataGridViewTextBoxColumn InvNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DateShip;
        internal System.Windows.Forms.DataGridViewTextBoxColumn GrandTotal;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Department;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnYes;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.PictureBox PicAlert;
    }
}