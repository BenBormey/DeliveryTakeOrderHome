namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmPlanningOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanningOrder));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanningOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.TxtPlanningOrder = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.CmbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel15 = new System.Windows.Forms.Panel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.DisplayLoading = new System.Windows.Forms.Timer(this.components);
            this.dayofweekloading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel3.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.Panel7.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel15.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
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
            this.Id,
            this.PlanningOrder,
            this.DayOfWeek,
            this.CreatedDate});
            this.DgvShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(5, 160);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(574, 260);
            this.DgvShow.TabIndex = 134;
            this.DgvShow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DgvShow_PreviewKeyDown);
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
            // PlanningOrder
            // 
            this.PlanningOrder.DataPropertyName = "PlanningOrder";
            this.PlanningOrder.HeaderText = "PlanningOrder";
            this.PlanningOrder.Name = "PlanningOrder";
            this.PlanningOrder.ReadOnly = true;
            this.PlanningOrder.Width = 102;
            // 
            // DayOfWeek
            // 
            this.DayOfWeek.DataPropertyName = "DayOfWeek";
            this.DayOfWeek.HeaderText = "Day Of Week";
            this.DayOfWeek.Name = "DayOfWeek";
            this.DayOfWeek.ReadOnly = true;
            this.DayOfWeek.Width = 98;
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
            // Panel3
            // 
            this.Panel3.Controls.Add(this.LblCountRow);
            this.Panel3.Controls.Add(this.BtnClose);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel3.Location = new System.Drawing.Point(5, 420);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(2);
            this.Panel3.Size = new System.Drawing.Size(574, 34);
            this.Panel3.TabIndex = 133;
            // 
            // LblCountRow
            // 
            this.LblCountRow.AutoSize = true;
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblCountRow.Location = new System.Drawing.Point(2, 2);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Size = new System.Drawing.Size(76, 19);
            this.LblCountRow.TabIndex = 128;
            this.LblCountRow.Text = "Count Row : 0";
            this.LblCountRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(471, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(101, 30);
            this.BtnClose.TabIndex = 127;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.Panel7);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel6.Location = new System.Drawing.Point(5, 110);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(574, 50);
            this.Panel6.TabIndex = 132;
            // 
            // Panel7
            // 
            this.Panel7.Controls.Add(this.Panel8);
            this.Panel7.Controls.Add(this.Panel5);
            this.Panel7.Controls.Add(this.Panel15);
            this.Panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel7.Location = new System.Drawing.Point(0, 0);
            this.Panel7.Name = "Panel7";
            this.Panel7.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.Panel7.Size = new System.Drawing.Size(574, 50);
            this.Panel7.TabIndex = 2;
            // 
            // Panel8
            // 
            this.Panel8.Controls.Add(this.TxtPlanningOrder);
            this.Panel8.Controls.Add(this.Label8);
            this.Panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel8.Location = new System.Drawing.Point(0, 0);
            this.Panel8.Name = "Panel8";
            this.Panel8.Padding = new System.Windows.Forms.Padding(2);
            this.Panel8.Size = new System.Drawing.Size(271, 50);
            this.Panel8.TabIndex = 2;
            // 
            // TxtPlanningOrder
            // 
            this.TxtPlanningOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPlanningOrder.Location = new System.Drawing.Point(2, 21);
            this.TxtPlanningOrder.Name = "TxtPlanningOrder";
            this.TxtPlanningOrder.Size = new System.Drawing.Size(267, 28);
            this.TxtPlanningOrder.TabIndex = 3;
            this.TxtPlanningOrder.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TxtPlanningOrder_PreviewKeyDown);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label8.Location = new System.Drawing.Point(2, 2);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(80, 19);
            this.Label8.TabIndex = 1;
            this.Label8.Text = "Planning Order";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.CmbDayOfWeek);
            this.Panel5.Controls.Add(this.Label2);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel5.Location = new System.Drawing.Point(271, 0);
            this.Panel5.Name = "Panel5";
            this.Panel5.Padding = new System.Windows.Forms.Padding(2);
            this.Panel5.Size = new System.Drawing.Size(196, 50);
            this.Panel5.TabIndex = 129;
            // 
            // CmbDayOfWeek
            // 
            this.CmbDayOfWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbDayOfWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDayOfWeek.FormattingEnabled = true;
            this.CmbDayOfWeek.Location = new System.Drawing.Point(2, 21);
            this.CmbDayOfWeek.Name = "CmbDayOfWeek";
            this.CmbDayOfWeek.Size = new System.Drawing.Size(192, 27);
            this.CmbDayOfWeek.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Location = new System.Drawing.Point(2, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 19);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Day Of Week";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel15
            // 
            this.Panel15.Controls.Add(this.BtnAdd);
            this.Panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel15.Location = new System.Drawing.Point(467, 0);
            this.Panel15.Name = "Panel15";
            this.Panel15.Padding = new System.Windows.Forms.Padding(2, 20, 2, 0);
            this.Panel15.Size = new System.Drawing.Size(105, 50);
            this.Panel15.TabIndex = 128;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnAdd.Image = global::DeliveryTakeOrder.Properties.Resources.add16;
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.Location = new System.Drawing.Point(2, 20);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(101, 30);
            this.BtnAdd.TabIndex = 127;
            this.BtnAdd.Text = "&Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.BtnAdd.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnAdd_PreviewKeyDown);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 7);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(574, 103);
            this.Panel1.TabIndex = 131;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.LblCompanyName);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel2.Location = new System.Drawing.Point(94, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Panel2.Size = new System.Drawing.Size(298, 101);
            this.Panel2.TabIndex = 12;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(0, 33);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(298, 68);
            this.LblCompanyName.TabIndex = 13;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(0, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(298, 23);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Q\'s MANAGEMENT SYSTEM";
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
            this.Panel4.Size = new System.Drawing.Size(574, 2);
            this.Panel4.TabIndex = 7;
            // 
            // DisplayLoading
            // 
            this.DisplayLoading.Interval = 5;
            this.DisplayLoading.Tick += new System.EventHandler(this.DisplayLoading_Tick);
            // 
            // dayofweekloading
            // 
            this.dayofweekloading.Interval = 5;
            this.dayofweekloading.Tick += new System.EventHandler(this.dayofweekloading_Tick);
            // 
            // FrmPlanningOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Panel6);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPlanningOrder";
            this.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planning Order";
            this.Load += new System.EventHandler(this.FrmPlanningOrder_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmPlanningOrder_Paint);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmPlanningOrder_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel6.ResumeLayout(false);
            this.Panel7.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.Panel8.PerformLayout();
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            this.Panel15.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PlanningOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DayOfWeek;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.Panel Panel8;
        internal System.Windows.Forms.TextBox TxtPlanningOrder;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.ComboBox CmbDayOfWeek;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel15;
        internal System.Windows.Forms.Button BtnAdd;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Timer DisplayLoading;
        internal System.Windows.Forms.Timer dayofweekloading;
    }
}