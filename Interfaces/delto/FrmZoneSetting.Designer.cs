namespace DeliveryTakeOrder.Interfaces.delto
{
    partial class FrmZoneSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZoneSetting));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel14 = new System.Windows.Forms.Panel();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.CmbCity = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.TxtZone = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Panel15 = new System.Windows.Forms.Panel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.cityloading = new System.Windows.Forms.Timer(this.components);
            this.displayloading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel14.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel9.SuspendLayout();
            this.Panel15.SuspendLayout();
            this.Panel1.SuspendLayout();
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
            this.ID,
            this.Zone,
            this.City,
            this.RegisterDate});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(6, 194);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(647, 324);
            this.DgvShow.TabIndex = 127;
            this.DgvShow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DgvShow_PreviewKeyDown);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // Zone
            // 
            this.Zone.DataPropertyName = "Zone";
            this.Zone.HeaderText = "Zone";
            this.Zone.Name = "Zone";
            this.Zone.ReadOnly = true;
            this.Zone.Width = 63;
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Width = 56;
            // 
            // RegisterDate
            // 
            this.RegisterDate.DataPropertyName = "RegisterDate";
            this.RegisterDate.HeaderText = "RegisterDate";
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.ReadOnly = true;
            this.RegisterDate.Visible = false;
            this.RegisterDate.Width = 94;
            // 
            // Panel14
            // 
            this.Panel14.BackColor = System.Drawing.Color.Transparent;
            this.Panel14.Controls.Add(this.LblCountRow);
            this.Panel14.Controls.Add(this.BtnExportToExcel);
            this.Panel14.Controls.Add(this.BtnClose);
            this.Panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel14.Location = new System.Drawing.Point(6, 518);
            this.Panel14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel14.Name = "Panel14";
            this.Panel14.Padding = new System.Windows.Forms.Padding(2);
            this.Panel14.Size = new System.Drawing.Size(647, 36);
            this.Panel14.TabIndex = 126;
            // 
            // LblCountRow
            // 
            this.LblCountRow.AutoSize = true;
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblCountRow.ForeColor = System.Drawing.Color.Black;
            this.LblCountRow.Location = new System.Drawing.Point(2, 2);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Size = new System.Drawing.Size(84, 19);
            this.LblCountRow.TabIndex = 131;
            this.LblCountRow.Text = "Count Row : 0";
            this.LblCountRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(364, 2);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Padding = new System.Windows.Forms.Padding(2);
            this.BtnExportToExcel.Size = new System.Drawing.Size(181, 32);
            this.BtnExportToExcel.TabIndex = 130;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(545, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Padding = new System.Windows.Forms.Padding(2);
            this.BtnClose.Size = new System.Drawing.Size(100, 32);
            this.BtnClose.TabIndex = 129;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.Panel3);
            this.Panel2.Controls.Add(this.Panel9);
            this.Panel2.Controls.Add(this.Panel15);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(6, 130);
            this.Panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(647, 64);
            this.Panel2.TabIndex = 125;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.CmbCity);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(259, 0);
            this.Panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel3.Size = new System.Drawing.Size(286, 64);
            this.Panel3.TabIndex = 115;
            // 
            // CmbCity
            // 
            this.CmbCity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCity.FormattingEnabled = true;
            this.CmbCity.Location = new System.Drawing.Point(2, 32);
            this.CmbCity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CmbCity.Name = "CmbCity";
            this.CmbCity.Size = new System.Drawing.Size(282, 27);
            this.CmbCity.TabIndex = 117;
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(2, 3);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(282, 29);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "City";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel9
            // 
            this.Panel9.BackColor = System.Drawing.Color.Transparent;
            this.Panel9.Controls.Add(this.TxtZone);
            this.Panel9.Controls.Add(this.Label7);
            this.Panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel9.Location = new System.Drawing.Point(0, 0);
            this.Panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel9.Name = "Panel9";
            this.Panel9.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel9.Size = new System.Drawing.Size(259, 64);
            this.Panel9.TabIndex = 125;
            // 
            // TxtZone
            // 
            this.TxtZone.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtZone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtZone.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtZone.Location = new System.Drawing.Point(2, 32);
            this.TxtZone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtZone.MaxLength = 50;
            this.TxtZone.Name = "TxtZone";
            this.TxtZone.Size = new System.Drawing.Size(255, 28);
            this.TxtZone.TabIndex = 2;
            this.TxtZone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label7
            // 
            this.Label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(2, 3);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(255, 29);
            this.Label7.TabIndex = 1;
            this.Label7.Text = "Zone";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel15
            // 
            this.Panel15.BackColor = System.Drawing.Color.Transparent;
            this.Panel15.Controls.Add(this.BtnAdd);
            this.Panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel15.Location = new System.Drawing.Point(545, 0);
            this.Panel15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel15.Name = "Panel15";
            this.Panel15.Padding = new System.Windows.Forms.Padding(2, 25, 2, 3);
            this.Panel15.Size = new System.Drawing.Size(102, 64);
            this.Panel15.TabIndex = 129;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnAdd.Image = global::DeliveryTakeOrder.Properties.Resources.add16;
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.Location = new System.Drawing.Point(2, 25);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Padding = new System.Windows.Forms.Padding(2);
            this.BtnAdd.Size = new System.Drawing.Size(98, 36);
            this.BtnAdd.TabIndex = 128;
            this.BtnAdd.Text = "&Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(6, 7);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(647, 123);
            this.Panel1.TabIndex = 124;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.Teal;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 120);
            this.Panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(647, 3);
            this.Panel4.TabIndex = 7;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(116, 46);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(302, 63);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(116, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(302, 23);
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
            this.PicLogo.Size = new System.Drawing.Size(110, 120);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 3;
            this.PicLogo.TabStop = false;
            // 
            // cityloading
            // 
            this.cityloading.Interval = 5;
            this.cityloading.Tick += new System.EventHandler(this.cityloading_Tick);
            // 
            // displayloading
            // 
            this.displayloading.Interval = 5;
            this.displayloading.Tick += new System.EventHandler(this.displayloading_Tick);
            // 
            // FrmZoneSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 561);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel14);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmZoneSetting";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zone Setting";
            this.Load += new System.EventHandler(this.FrmZoneSetting_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmZoneSetting_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel14.ResumeLayout(false);
            this.Panel14.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel9.ResumeLayout(false);
            this.Panel9.PerformLayout();
            this.Panel15.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ID;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Zone;
        internal System.Windows.Forms.DataGridViewTextBoxColumn City;
        internal System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
        internal System.Windows.Forms.Panel Panel14;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.ComboBox CmbCity;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel9;
        internal System.Windows.Forms.TextBox TxtZone;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Panel Panel15;
        internal System.Windows.Forms.Button BtnAdd;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Timer cityloading;
        internal System.Windows.Forms.Timer displayloading;
    }
}