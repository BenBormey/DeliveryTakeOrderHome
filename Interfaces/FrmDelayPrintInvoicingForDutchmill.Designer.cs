namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDelayPrintInvoicingForDutchmill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDelayPrintInvoicingForDutchmill));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProPacksize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockfrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.btnexporttoexcel = new System.Windows.Forms.Button();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.CmbItems = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.BtnLockItems = new System.Windows.Forms.Button();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.Label4 = new System.Windows.Forms.Label();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.loading = new System.Windows.Forms.Timer(this.components);
            this.displayloading = new System.Windows.Forms.Timer(this.components);
            this.itemsloading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel44.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvShow.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.barcode,
            this.ProName,
            this.ProPacksize,
            this.lockfrom,
            this.lockto,
            this.createddate,
            this.status});
            this.DgvShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(5, 108);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(974, 463);
            this.DgvShow.TabIndex = 116;
            this.DgvShow.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvShow_RowPostPaint);
            this.DgvShow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DgvShow_PreviewKeyDown);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 40;
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "Barcode";
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            this.barcode.Width = 75;
            // 
            // ProName
            // 
            this.ProName.DataPropertyName = "ProName";
            this.ProName.HeaderText = "Description";
            this.ProName.Name = "ProName";
            this.ProName.ReadOnly = true;
            this.ProName.Width = 88;
            // 
            // ProPacksize
            // 
            this.ProPacksize.DataPropertyName = "ProPacksize";
            this.ProPacksize.HeaderText = "Size";
            this.ProPacksize.Name = "ProPacksize";
            this.ProPacksize.ReadOnly = true;
            this.ProPacksize.Width = 54;
            // 
            // lockfrom
            // 
            this.lockfrom.DataPropertyName = "lockfrom";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.lockfrom.DefaultCellStyle = dataGridViewCellStyle1;
            this.lockfrom.HeaderText = "Lock Date ( From) ";
            this.lockfrom.Name = "lockfrom";
            this.lockfrom.ReadOnly = true;
            this.lockfrom.Width = 130;
            // 
            // lockto
            // 
            this.lockto.DataPropertyName = "lockto";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.lockto.DefaultCellStyle = dataGridViewCellStyle2;
            this.lockto.HeaderText = "Lock Date ( To )";
            this.lockto.Name = "lockto";
            this.lockto.ReadOnly = true;
            this.lockto.Width = 116;
            // 
            // createddate
            // 
            this.createddate.DataPropertyName = "createddate";
            this.createddate.HeaderText = "createddate";
            this.createddate.Name = "createddate";
            this.createddate.ReadOnly = true;
            this.createddate.Visible = false;
            this.createddate.Width = 89;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            this.status.Width = 60;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.btnexporttoexcel);
            this.Panel44.Controls.Add(this.LblCountRow);
            this.Panel44.Controls.Add(this.BtnClose);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(5, 571);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2);
            this.Panel44.Size = new System.Drawing.Size(974, 35);
            this.Panel44.TabIndex = 115;
            // 
            // btnexporttoexcel
            // 
            this.btnexporttoexcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexporttoexcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnexporttoexcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnexporttoexcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.btnexporttoexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexporttoexcel.Location = new System.Drawing.Point(730, 2);
            this.btnexporttoexcel.Name = "btnexporttoexcel";
            this.btnexporttoexcel.Size = new System.Drawing.Size(150, 31);
            this.btnexporttoexcel.TabIndex = 118;
            this.btnexporttoexcel.Text = "&Export To Excel";
            this.btnexporttoexcel.UseVisualStyleBackColor = true;
            this.btnexporttoexcel.Click += new System.EventHandler(this.btnexporttoexcel_Click);
            // 
            // LblCountRow
            // 
            this.LblCountRow.AutoSize = true;
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblCountRow.Location = new System.Drawing.Point(2, 2);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Size = new System.Drawing.Size(76, 19);
            this.LblCountRow.TabIndex = 11;
            this.LblCountRow.Text = "Count Row : 0";
            this.LblCountRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.Cancel16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(880, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(92, 31);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.Panel5);
            this.Panel1.Controls.Add(this.PanelHeader);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(974, 103);
            this.Panel1.TabIndex = 114;
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.Panel3);
            this.Panel5.Controls.Add(this.Panel6);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel5.Location = new System.Drawing.Point(414, 0);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(560, 101);
            this.Panel5.TabIndex = 115;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.CmbItems);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel3.Location = new System.Drawing.Point(0, 37);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel3.Size = new System.Drawing.Size(560, 32);
            this.Panel3.TabIndex = 114;
            // 
            // CmbItems
            // 
            this.CmbItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbItems.FormattingEnabled = true;
            this.CmbItems.Location = new System.Drawing.Point(86, 2);
            this.CmbItems.Name = "CmbItems";
            this.CmbItems.Size = new System.Drawing.Size(474, 27);
            this.CmbItems.TabIndex = 5;
            this.CmbItems.SelectedIndexChanged += new System.EventHandler(this.CmbItems_SelectedIndexChanged);
            this.CmbItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbItems_KeyPress);
            this.CmbItems.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CmbItems_PreviewKeyDown);
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Location = new System.Drawing.Point(0, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 28);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Product Item";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.BtnLockItems);
            this.Panel6.Controls.Add(this.dtpto);
            this.Panel6.Controls.Add(this.Label4);
            this.Panel6.Controls.Add(this.dtpfrom);
            this.Panel6.Controls.Add(this.Label3);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel6.Location = new System.Drawing.Point(0, 69);
            this.Panel6.Name = "Panel6";
            this.Panel6.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel6.Size = new System.Drawing.Size(560, 32);
            this.Panel6.TabIndex = 115;
            // 
            // BtnLockItems
            // 
            this.BtnLockItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLockItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnLockItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnLockItems.Image = global::DeliveryTakeOrder.Properties.Resources._lock_16;
            this.BtnLockItems.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLockItems.Location = new System.Drawing.Point(358, 2);
            this.BtnLockItems.Name = "BtnLockItems";
            this.BtnLockItems.Size = new System.Drawing.Size(126, 28);
            this.BtnLockItems.TabIndex = 117;
            this.BtnLockItems.Text = "Lock Items";
            this.BtnLockItems.UseVisualStyleBackColor = true;
            this.BtnLockItems.Click += new System.EventHandler(this.BtnLockItems_Click);
            // 
            // dtpto
            // 
            this.dtpto.CustomFormat = "dd-MMM-yyyy";
            this.dtpto.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpto.Location = new System.Drawing.Point(238, 2);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(120, 28);
            this.dtpto.TabIndex = 119;
            this.dtpto.ValueChanged += new System.EventHandler(this.dtpto_ValueChanged);
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label4.Location = new System.Drawing.Point(206, 2);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 28);
            this.Label4.TabIndex = 118;
            this.Label4.Text = "To";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpfrom
            // 
            this.dtpfrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpfrom.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfrom.Location = new System.Drawing.Point(86, 2);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(120, 28);
            this.dtpfrom.TabIndex = 116;
            this.dtpfrom.ValueChanged += new System.EventHandler(this.dtpfrom_ValueChanged);
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.Location = new System.Drawing.Point(0, 2);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(86, 28);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Lock From";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.LblCompanyName);
            this.PanelHeader.Controls.Add(this.Label1);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelHeader.Location = new System.Drawing.Point(94, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Padding = new System.Windows.Forms.Padding(2);
            this.PanelHeader.Size = new System.Drawing.Size(316, 101);
            this.PanelHeader.TabIndex = 8;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(2, 30);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(312, 69);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(2, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(312, 28);
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
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(94, 101);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 3;
            this.PicLogo.TabStop = false;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 101);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(974, 2);
            this.Panel4.TabIndex = 7;
            // 
            // loading
            // 
            this.loading.Interval = 5;
            this.loading.Tick += new System.EventHandler(this.loading_Tick);
            // 
            // displayloading
            // 
            this.displayloading.Interval = 5;
            this.displayloading.Tick += new System.EventHandler(this.displayloading_Tick);
            // 
            // itemsloading
            // 
            this.itemsloading.Interval = 5;
            this.itemsloading.Tick += new System.EventHandler(this.itemsloading_Tick);
            // 
            // FrmDelayPrintInvoicingForDutchmill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel44);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDelayPrintInvoicingForDutchmill";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dutchmill - Lock Print Invoicing";
            this.Load += new System.EventHandler(this.FrmDelayPrintInvoicingForDutchmill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel44.ResumeLayout(false);
            this.Panel44.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.PanelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProPacksize;
        internal System.Windows.Forms.DataGridViewTextBoxColumn lockfrom;
        internal System.Windows.Forms.DataGridViewTextBoxColumn lockto;
        internal System.Windows.Forms.DataGridViewTextBoxColumn createddate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn status;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button btnexporttoexcel;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.ComboBox CmbItems;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.Button BtnLockItems;
        internal System.Windows.Forms.DateTimePicker dtpto;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker dtpfrom;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel PanelHeader;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Timer loading;
        internal System.Windows.Forms.Timer displayloading;
        internal System.Windows.Forms.Timer itemsloading;
    }
}