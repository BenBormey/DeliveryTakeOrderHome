
namespace DeliveryTakeOrder.Interfaces.customer_e_commerce
{
    partial class FrmExportType
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.RdbAllActivateCustomers = new System.Windows.Forms.RadioButton();
            this.RdbAllDeactivateCustomers = new System.Windows.Forms.RadioButton();
            this.RdbAllExport = new System.Windows.Forms.RadioButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.TimerLoading = new System.Windows.Forms.Timer(this.components);
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.SystemColors.Control;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.Cancel16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(319, 302);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(86, 42);
            this.BtnClose.TabIndex = 117;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.BackColor = System.Drawing.SystemColors.Control;
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnExportToExcel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(124, 233);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(167, 42);
            this.BtnExportToExcel.TabIndex = 116;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = false;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // RdbAllActivateCustomers
            // 
            this.RdbAllActivateCustomers.AutoSize = true;
            this.RdbAllActivateCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbAllActivateCustomers.Location = new System.Drawing.Point(124, 203);
            this.RdbAllActivateCustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RdbAllActivateCustomers.Name = "RdbAllActivateCustomers";
            this.RdbAllActivateCustomers.Size = new System.Drawing.Size(154, 23);
            this.RdbAllActivateCustomers.TabIndex = 115;
            this.RdbAllActivateCustomers.Text = "All Activate Customers";
            this.RdbAllActivateCustomers.UseVisualStyleBackColor = true;
            // 
            // RdbAllDeactivateCustomers
            // 
            this.RdbAllDeactivateCustomers.AutoSize = true;
            this.RdbAllDeactivateCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbAllDeactivateCustomers.Location = new System.Drawing.Point(124, 172);
            this.RdbAllDeactivateCustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RdbAllDeactivateCustomers.Name = "RdbAllDeactivateCustomers";
            this.RdbAllDeactivateCustomers.Size = new System.Drawing.Size(167, 23);
            this.RdbAllDeactivateCustomers.TabIndex = 114;
            this.RdbAllDeactivateCustomers.Text = "All Deactivate Customers";
            this.RdbAllDeactivateCustomers.UseVisualStyleBackColor = true;
            // 
            // RdbAllExport
            // 
            this.RdbAllExport.AutoSize = true;
            this.RdbAllExport.Checked = true;
            this.RdbAllExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbAllExport.Location = new System.Drawing.Point(124, 141);
            this.RdbAllExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RdbAllExport.Name = "RdbAllExport";
            this.RdbAllExport.Size = new System.Drawing.Size(81, 23);
            this.RdbAllExport.TabIndex = 113;
            this.RdbAllExport.TabStop = true;
            this.RdbAllExport.Text = "All Export";
            this.RdbAllExport.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(6, 7);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(402, 100);
            this.Panel1.TabIndex = 112;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(100, 43);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(302, 54);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(100, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(302, 43);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Q\'s MANAGEMENT SYSTEM";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicLogo
            // 
            this.PicLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicLogo.Image = global::DeliveryTakeOrder.Properties.Resources.Logo;
            this.PicLogo.Location = new System.Drawing.Point(0, 0);
            this.PicLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(100, 97);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 3;
            this.PicLogo.TabStop = false;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 97);
            this.Panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(402, 3);
            this.Panel4.TabIndex = 7;
            // 
            // TimerLoading
            // 
            this.TimerLoading.Interval = 5;
            this.TimerLoading.Tick += new System.EventHandler(this.TimerLoading_Tick);
            // 
            // FrmExportType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 352);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnExportToExcel);
            this.Controls.Add(this.RdbAllActivateCustomers);
            this.Controls.Add(this.RdbAllDeactivateCustomers);
            this.Controls.Add(this.RdbAllExport);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmExportType";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Text = "Type Of Export";
            this.Load += new System.EventHandler(this.FrmExportType_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmExportType_Paint);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.RadioButton RdbAllActivateCustomers;
        internal System.Windows.Forms.RadioButton RdbAllDeactivateCustomers;
        internal System.Windows.Forms.RadioButton RdbAllExport;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Timer TimerLoading;
    }
}