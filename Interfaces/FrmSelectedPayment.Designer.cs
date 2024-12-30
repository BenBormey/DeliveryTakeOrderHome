namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmSelectedPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectedPayment));
            this.TxtId = new System.Windows.Forms.TextBox();
            this.BtnPreview = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.RdbAllTransaction = new System.Windows.Forms.RadioButton();
            this.RdbAllUnpaid = new System.Windows.Forms.RadioButton();
            this.Panel1.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(290, 109);
            this.TxtId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(21, 28);
            this.TxtId.TabIndex = 124;
            this.TxtId.Visible = false;
            // 
            // BtnPreview
            // 
            this.BtnPreview.BackColor = System.Drawing.SystemColors.Control;
            this.BtnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPreview.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnPreview.Image = global::DeliveryTakeOrder.Properties.Resources.view_takeorder;
            this.BtnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPreview.Location = new System.Drawing.Point(37, 148);
            this.BtnPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(119, 33);
            this.BtnPreview.TabIndex = 123;
            this.BtnPreview.Text = "&Preview";
            this.BtnPreview.UseVisualStyleBackColor = false;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(162, 148);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(119, 33);
            this.BtnCancel.TabIndex = 122;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.DTPTo);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(158, 90);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(119, 50);
            this.Panel1.TabIndex = 121;
            // 
            // DTPTo
            // 
            this.DTPTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DTPTo.CustomFormat = "dd-MMM-yyyy";
            this.DTPTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPTo.Location = new System.Drawing.Point(0, 19);
            this.DTPTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(119, 28);
            this.DTPTo.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(119, 19);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "To :";
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.DTPFrom);
            this.Panel3.Controls.Add(this.Label3);
            this.Panel3.Location = new System.Drawing.Point(33, 90);
            this.Panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(119, 50);
            this.Panel3.TabIndex = 120;
            // 
            // DTPFrom
            // 
            this.DTPFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DTPFrom.CustomFormat = "dd-MMM-yyyy";
            this.DTPFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFrom.Location = new System.Drawing.Point(0, 19);
            this.DTPFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(119, 28);
            this.DTPFrom.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(119, 19);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "From :";
            // 
            // RdbAllTransaction
            // 
            this.RdbAllTransaction.AutoSize = true;
            this.RdbAllTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbAllTransaction.Location = new System.Drawing.Point(23, 59);
            this.RdbAllTransaction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RdbAllTransaction.Name = "RdbAllTransaction";
            this.RdbAllTransaction.Size = new System.Drawing.Size(98, 23);
            this.RdbAllTransaction.TabIndex = 119;
            this.RdbAllTransaction.Text = "All Transaction";
            this.RdbAllTransaction.UseVisualStyleBackColor = true;
            this.RdbAllTransaction.CheckedChanged += new System.EventHandler(this.RdbAllTransaction_CheckedChanged);
            // 
            // RdbAllUnpaid
            // 
            this.RdbAllUnpaid.AutoSize = true;
            this.RdbAllUnpaid.Checked = true;
            this.RdbAllUnpaid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbAllUnpaid.Location = new System.Drawing.Point(23, 28);
            this.RdbAllUnpaid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RdbAllUnpaid.Name = "RdbAllUnpaid";
            this.RdbAllUnpaid.Size = new System.Drawing.Size(74, 23);
            this.RdbAllUnpaid.TabIndex = 118;
            this.RdbAllUnpaid.TabStop = true;
            this.RdbAllUnpaid.Text = "All Unpaid";
            this.RdbAllUnpaid.UseVisualStyleBackColor = true;
            // 
            // FrmSelectedPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 208);
            this.ControlBox = false;
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.RdbAllTransaction);
            this.Controls.Add(this.RdbAllUnpaid);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSelectedPayment";
            this.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.FrmSelectedPayment_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TxtId;
        internal System.Windows.Forms.Button BtnPreview;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DateTimePicker DTPTo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.DateTimePicker DTPFrom;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.RadioButton RdbAllTransaction;
        internal System.Windows.Forms.RadioButton RdbAllUnpaid;
    }
}