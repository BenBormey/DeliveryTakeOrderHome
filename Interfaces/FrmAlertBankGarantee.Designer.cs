namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmAlertBankGarantee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlertBankGarantee));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.CreditLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LblMsg = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvShow.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreditLimit,
            this.Expiry,
            this.AlertDate,
            this.CurDate});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(0, 51);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(435, 173);
            this.DgvShow.TabIndex = 115;
            this.DgvShow.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvShow_RowPrePaint);
            // 
            // CreditLimit
            // 
            this.CreditLimit.DataPropertyName = "CreditLimit";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.CreditLimit.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreditLimit.HeaderText = "Credit Limit";
            this.CreditLimit.Name = "CreditLimit";
            this.CreditLimit.ReadOnly = true;
            // 
            // Expiry
            // 
            this.Expiry.DataPropertyName = "Expiry";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.Expiry.DefaultCellStyle = dataGridViewCellStyle2;
            this.Expiry.HeaderText = "Expiry";
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            // 
            // AlertDate
            // 
            this.AlertDate.DataPropertyName = "AlertDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.AlertDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.AlertDate.HeaderText = "AlertDate";
            this.AlertDate.Name = "AlertDate";
            this.AlertDate.ReadOnly = true;
            // 
            // CurDate
            // 
            this.CurDate.DataPropertyName = "CurDate";
            this.CurDate.HeaderText = "CurDate";
            this.CurDate.Name = "CurDate";
            this.CurDate.ReadOnly = true;
            this.CurDate.Visible = false;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnOK);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 224);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(155, 2, 155, 2);
            this.Panel2.Size = new System.Drawing.Size(435, 36);
            this.Panel2.TabIndex = 116;
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(155, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(125, 32);
            this.BtnOK.TabIndex = 113;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.LblMsg);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(435, 51);
            this.Panel1.TabIndex = 114;
            // 
            // LblMsg
            // 
            this.LblMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblMsg.Location = new System.Drawing.Point(38, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(397, 51);
            this.LblMsg.TabIndex = 0;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox1.Image = global::DeliveryTakeOrder.Properties.Resources.alert1;
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(38, 51);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            // 
            // FrmAlertBankGarantee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 260);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAlertBankGarantee";
            this.Text = "FrmAlertBankGarantee";
            this.Load += new System.EventHandler(this.FrmAlertBankGarantee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreditLimit;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        internal System.Windows.Forms.DataGridViewTextBoxColumn AlertDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CurDate;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label LblMsg;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}