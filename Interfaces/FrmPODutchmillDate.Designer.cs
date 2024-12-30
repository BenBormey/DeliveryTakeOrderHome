namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmPODutchmillDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPODutchmillDate));
            this.Panel44 = new System.Windows.Forms.Panel();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ChkLock = new System.Windows.Forms.CheckBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.CmbRequiredDate = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.requireddateloading = new System.Windows.Forms.Timer(this.components);
            this.Panel44.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.BtnExportToExcel);
            this.Panel44.Controls.Add(this.BtnCancel);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel44.Location = new System.Drawing.Point(10, 99);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2);
            this.Panel44.Size = new System.Drawing.Size(244, 35);
            this.Panel44.TabIndex = 114;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(2, 2);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(158, 31);
            this.BtnExportToExcel.TabIndex = 12;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(160, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(82, 31);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ChkLock);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(10, 70);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(2);
            this.Panel1.Size = new System.Drawing.Size(244, 29);
            this.Panel1.TabIndex = 115;
            // 
            // ChkLock
            // 
            this.ChkLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkLock.ForeColor = System.Drawing.Color.Maroon;
            this.ChkLock.Location = new System.Drawing.Point(2, 2);
            this.ChkLock.Name = "ChkLock";
            this.ChkLock.Size = new System.Drawing.Size(240, 25);
            this.ChkLock.TabIndex = 0;
            this.ChkLock.Text = "Lock Take Order";
            this.ChkLock.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.CmbRequiredDate);
            this.Panel2.Controls.Add(this.Label3);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(10, 10);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel2.Size = new System.Drawing.Size(244, 60);
            this.Panel2.TabIndex = 113;
            // 
            // CmbRequiredDate
            // 
            this.CmbRequiredDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbRequiredDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbRequiredDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRequiredDate.FormattingEnabled = true;
            this.CmbRequiredDate.Location = new System.Drawing.Point(0, 30);
            this.CmbRequiredDate.Name = "CmbRequiredDate";
            this.CmbRequiredDate.Size = new System.Drawing.Size(244, 27);
            this.CmbRequiredDate.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Location = new System.Drawing.Point(0, 2);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(244, 28);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Required Date";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // requireddateloading
            // 
            this.requireddateloading.Interval = 5;
            this.requireddateloading.Tick += new System.EventHandler(this.requireddateloading_Tick);
            // 
            // FrmPODutchmillDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 147);
            this.ControlBox = false;
            this.Controls.Add(this.Panel44);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPODutchmillDate";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPODutchmillDate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPODutchmillDate_FormClosed);
            this.Load += new System.EventHandler(this.FrmPODutchmillDate_Load);
            this.Panel44.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.CheckBox ChkLock;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ComboBox CmbRequiredDate;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Timer requireddateloading;
    }
}