namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmSetPiecesPerTray
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetPiecesPerTray));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PiecesPerTray = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.TxtPiecesPerTray = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel36 = new System.Windows.Forms.Panel();
            this.Panel37 = new System.Windows.Forms.Panel();
            this.TxtQtyPerCase = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.CmbProducts = new System.Windows.Forms.ComboBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.ItemLoading = new System.Windows.Forms.Timer(this.components);
            this.DisplayLoading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel44.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel36.SuspendLayout();
            this.Panel37.SuspendLayout();
            this.Panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvShow.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Barcode,
            this.ProName,
            this.Size,
            this.QtyPCase,
            this.PiecesPerTray,
            this.CreatedDate});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(5, 108);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(818, 359);
            this.DgvShow.TabIndex = 114;
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
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Width = 81;
            // 
            // ProName
            // 
            this.ProName.DataPropertyName = "ProName";
            this.ProName.HeaderText = "Product Name";
            this.ProName.Name = "ProName";
            this.ProName.ReadOnly = true;
            this.ProName.Width = 111;
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 58;
            // 
            // QtyPCase
            // 
            this.QtyPCase.DataPropertyName = "QtyPCase";
            this.QtyPCase.HeaderText = "Q/C";
            this.QtyPCase.Name = "QtyPCase";
            this.QtyPCase.ReadOnly = true;
            this.QtyPCase.Width = 56;
            // 
            // PiecesPerTray
            // 
            this.PiecesPerTray.DataPropertyName = "PiecesPerTray";
            this.PiecesPerTray.HeaderText = "Pieces Per Tray";
            this.PiecesPerTray.Name = "PiecesPerTray";
            this.PiecesPerTray.ReadOnly = true;
            this.PiecesPerTray.Width = 120;
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
            // Panel44
            // 
            this.Panel44.Controls.Add(this.BtnExportToExcel);
            this.Panel44.Controls.Add(this.LblCountRow);
            this.Panel44.Controls.Add(this.BtnClose);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(5, 467);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2);
            this.Panel44.Size = new System.Drawing.Size(818, 35);
            this.Panel44.TabIndex = 113;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(587, 2);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(137, 31);
            this.BtnExportToExcel.TabIndex = 12;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            // 
            // LblCountRow
            // 
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblCountRow.Location = new System.Drawing.Point(2, 2);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Size = new System.Drawing.Size(147, 31);
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
            this.BtnClose.Location = new System.Drawing.Point(724, 2);
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
            this.Panel1.Controls.Add(this.PanelHeader);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(818, 103);
            this.Panel1.TabIndex = 112;
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.BtnAdd);
            this.PanelHeader.Controls.Add(this.BtnUpdate);
            this.PanelHeader.Controls.Add(this.BtnCancel);
            this.PanelHeader.Controls.Add(this.Panel2);
            this.PanelHeader.Controls.Add(this.Panel36);
            this.PanelHeader.Controls.Add(this.Panel5);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelHeader.Location = new System.Drawing.Point(382, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(436, 101);
            this.PanelHeader.TabIndex = 8;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnAdd.Image = global::DeliveryTakeOrder.Properties.Resources.add16;
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.Location = new System.Drawing.Point(328, 32);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(108, 35);
            this.BtnAdd.TabIndex = 13;
            this.BtnAdd.Text = "&Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.Location = new System.Drawing.Point(328, 32);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(108, 35);
            this.BtnUpdate.TabIndex = 15;
            this.BtnUpdate.Text = "&Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Visible = false;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.Image = global::DeliveryTakeOrder.Properties.Resources.Cancel16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(328, 66);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(108, 35);
            this.BtnCancel.TabIndex = 14;
            this.BtnCancel.Text = "C&ancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Panel3);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel2.Location = new System.Drawing.Point(149, 32);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(179, 69);
            this.Panel2.TabIndex = 12;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.TxtPiecesPerTray);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(2, 2);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel3.Size = new System.Drawing.Size(175, 30);
            this.Panel3.TabIndex = 1;
            // 
            // TxtPiecesPerTray
            // 
            this.TxtPiecesPerTray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPiecesPerTray.Location = new System.Drawing.Point(103, 2);
            this.TxtPiecesPerTray.Name = "TxtPiecesPerTray";
            this.TxtPiecesPerTray.Size = new System.Drawing.Size(72, 28);
            this.TxtPiecesPerTray.TabIndex = 3;
            this.TxtPiecesPerTray.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Location = new System.Drawing.Point(0, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(103, 26);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Pieces Per Tray";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel36
            // 
            this.Panel36.Controls.Add(this.Panel37);
            this.Panel36.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel36.Location = new System.Drawing.Point(0, 32);
            this.Panel36.Name = "Panel36";
            this.Panel36.Padding = new System.Windows.Forms.Padding(2);
            this.Panel36.Size = new System.Drawing.Size(149, 69);
            this.Panel36.TabIndex = 11;
            // 
            // Panel37
            // 
            this.Panel37.Controls.Add(this.TxtQtyPerCase);
            this.Panel37.Controls.Add(this.Label22);
            this.Panel37.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel37.Location = new System.Drawing.Point(2, 2);
            this.Panel37.Name = "Panel37";
            this.Panel37.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel37.Size = new System.Drawing.Size(145, 30);
            this.Panel37.TabIndex = 1;
            // 
            // TxtQtyPerCase
            // 
            this.TxtQtyPerCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtQtyPerCase.Location = new System.Drawing.Point(89, 2);
            this.TxtQtyPerCase.Name = "TxtQtyPerCase";
            this.TxtQtyPerCase.ReadOnly = true;
            this.TxtQtyPerCase.Size = new System.Drawing.Size(56, 28);
            this.TxtQtyPerCase.TabIndex = 3;
            this.TxtQtyPerCase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label22
            // 
            this.Label22.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label22.Location = new System.Drawing.Point(0, 2);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(89, 26);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Q/C";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.CmbProducts);
            this.Panel5.Controls.Add(this.Label14);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel5.Location = new System.Drawing.Point(0, 0);
            this.Panel5.Name = "Panel5";
            this.Panel5.Padding = new System.Windows.Forms.Padding(2);
            this.Panel5.Size = new System.Drawing.Size(436, 32);
            this.Panel5.TabIndex = 2;
            // 
            // CmbProducts
            // 
            this.CmbProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbProducts.FormattingEnabled = true;
            this.CmbProducts.Location = new System.Drawing.Point(91, 2);
            this.CmbProducts.Name = "CmbProducts";
            this.CmbProducts.Size = new System.Drawing.Size(343, 27);
            this.CmbProducts.TabIndex = 3;
            this.CmbProducts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbProducts_KeyPress);
            // 
            // Label14
            // 
            this.Label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label14.Location = new System.Drawing.Point(2, 2);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(89, 28);
            this.Label14.TabIndex = 4;
            this.Label14.Text = "Product Items";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.Panel4.Size = new System.Drawing.Size(818, 2);
            this.Panel4.TabIndex = 7;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(104, 46);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(272, 43);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(100, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(276, 23);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Q\'s MANAGEMENT SYSTEM";
            // 
            // ItemLoading
            // 
            this.ItemLoading.Interval = 5;
            this.ItemLoading.Tick += new System.EventHandler(this.ItemLoading_Tick);
            // 
            // DisplayLoading
            // 
            this.DisplayLoading.Interval = 5;
            this.DisplayLoading.Tick += new System.EventHandler(this.DisplayLoading_Tick);
            // 
            // FrmSetPiecesPerTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 507);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel44);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSetPiecesPerTray";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Pieces Per Tray";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSetPiecesPerTray_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel44.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.PanelHeader.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel36.ResumeLayout(false);
            this.Panel37.ResumeLayout(false);
            this.Panel37.PerformLayout();
            this.Panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Size;
        internal System.Windows.Forms.DataGridViewTextBoxColumn QtyPCase;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PiecesPerTray;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel PanelHeader;
        internal System.Windows.Forms.Button BtnAdd;
        internal System.Windows.Forms.Button BtnUpdate;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.TextBox TxtPiecesPerTray;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel36;
        internal System.Windows.Forms.Panel Panel37;
        internal System.Windows.Forms.TextBox TxtQtyPerCase;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.ComboBox CmbProducts;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Timer ItemLoading;
        internal System.Windows.Forms.Timer DisplayLoading;
    }
}