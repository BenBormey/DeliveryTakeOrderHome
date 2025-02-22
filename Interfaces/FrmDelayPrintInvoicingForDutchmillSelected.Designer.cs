
namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDelayPrintInvoicingForDutchmillSelected
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnDelayItems = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.dtpActiveDate = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(162, 112);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(91, 37);
            this.BtnCancel.TabIndex = 119;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnDelayItems
            // 
            this.BtnDelayItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelayItems.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnDelayItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnDelayItems.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDelayItems.Location = new System.Drawing.Point(38, 112);
            this.BtnDelayItems.Name = "BtnDelayItems";
            this.BtnDelayItems.Size = new System.Drawing.Size(118, 37);
            this.BtnDelayItems.TabIndex = 118;
            this.BtnDelayItems.Text = "&Set";
            this.BtnDelayItems.UseVisualStyleBackColor = true;
            this.BtnDelayItems.Click += new System.EventHandler(this.BtnDelayItems_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.dtpActiveDate);
            this.Panel2.Controls.Add(this.Label5);
            this.Panel2.Location = new System.Drawing.Point(38, 45);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(215, 61);
            this.Panel2.TabIndex = 117;
            this.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // dtpActiveDate
            // 
            this.dtpActiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpActiveDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpActiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActiveDate.Location = new System.Drawing.Point(2, 30);
            this.dtpActiveDate.Name = "dtpActiveDate";
            this.dtpActiveDate.Size = new System.Drawing.Size(211, 28);
            this.dtpActiveDate.TabIndex = 115;
            this.dtpActiveDate.ValueChanged += new System.EventHandler(this.dtpActiveDate_ValueChanged);
            // 
            // Label5
            // 
            this.Label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label5.Location = new System.Drawing.Point(2, 2);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(211, 28);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Active Date";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDelayPrintInvoicingForDutchmillSelected
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 181);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnDelayItems);
            this.Controls.Add(this.Panel2);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDelayPrintInvoicingForDutchmillSelected";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Active Back";
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Button BtnDelayItems;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.DateTimePicker dtpActiveDate;
        internal System.Windows.Forms.Label Label5;
    }
}