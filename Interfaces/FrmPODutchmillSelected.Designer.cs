
namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmPODutchmillSelected
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
            // BtnPreview
            // 
            this.BtnPreview.BackColor = System.Drawing.SystemColors.Control;
            this.BtnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPreview.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnPreview.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPreview.Location = new System.Drawing.Point(62, 141);
            this.BtnPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(139, 38);
            this.BtnPreview.TabIndex = 122;
            this.BtnPreview.Text = "&Preview";
            this.BtnPreview.UseVisualStyleBackColor = false;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(208, 141);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(139, 38);
            this.BtnCancel.TabIndex = 121;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.DTPTo);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(208, 86);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(139, 50);
            this.Panel1.TabIndex = 120;
            this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
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
            this.DTPTo.Size = new System.Drawing.Size(139, 28);
            this.DTPTo.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(139, 19);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "To :";
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.DTPFrom);
            this.Panel3.Controls.Add(this.Label3);
            this.Panel3.Location = new System.Drawing.Point(62, 86);
            this.Panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(139, 50);
            this.Panel3.TabIndex = 119;
            this.Panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DTPFrom.CustomFormat = "dd-MMM-yyyy";
            this.DTPFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFrom.Location = new System.Drawing.Point(0, 19);
            this.DTPFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DTPFrom.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(139, 28);
            this.DTPFrom.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(139, 19);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "From :";
            // 
            // RdbAllTransaction
            // 
            this.RdbAllTransaction.AutoSize = true;
            this.RdbAllTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbAllTransaction.Location = new System.Drawing.Point(44, 55);
            this.RdbAllTransaction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RdbAllTransaction.Name = "RdbAllTransaction";
            this.RdbAllTransaction.Size = new System.Drawing.Size(111, 23);
            this.RdbAllTransaction.TabIndex = 118;
            this.RdbAllTransaction.Text = "All Transaction";
            this.RdbAllTransaction.UseVisualStyleBackColor = true;
            this.RdbAllTransaction.CheckedChanged += new System.EventHandler(this.RdbAllTransaction_CheckedChanged);
            // 
            // RdbAllUnpaid
            // 
            this.RdbAllUnpaid.AutoSize = true;
            this.RdbAllUnpaid.Checked = true;
            this.RdbAllUnpaid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbAllUnpaid.Location = new System.Drawing.Point(44, 24);
            this.RdbAllUnpaid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RdbAllUnpaid.Name = "RdbAllUnpaid";
            this.RdbAllUnpaid.Size = new System.Drawing.Size(132, 23);
            this.RdbAllUnpaid.TabIndex = 117;
            this.RdbAllUnpaid.TabStop = true;
            this.RdbAllUnpaid.Text = "All Not Yet Process";
            this.RdbAllUnpaid.UseVisualStyleBackColor = true;
            this.RdbAllUnpaid.CheckedChanged += new System.EventHandler(this.RdbAllUnpaid_CheckedChanged);
            // 
            // FrmPODutchmillSelected
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 202);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.RdbAllTransaction);
            this.Controls.Add(this.RdbAllUnpaid);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPODutchmillSelected";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPODutchmillSelected_FormClosed);
            this.Load += new System.EventHandler(this.FrmPODutchmillSelected_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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