namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDeltoListForDutchmillPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeltoListForDutchmillPO));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeltoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Sunday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.CmbDelto = new System.Windows.Forms.ComboBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.ChkTuesday = new System.Windows.Forms.CheckBox();
            this.ChkMonday = new System.Windows.Forms.CheckBox();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.ChkThursday = new System.Windows.Forms.CheckBox();
            this.ChkWednesday = new System.Windows.Forms.CheckBox();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.ChkSaturday = new System.Windows.Forms.CheckBox();
            this.ChkFriday = new System.Windows.Forms.CheckBox();
            this.Panel10 = new System.Windows.Forms.Panel();
            this.ChkSunday = new System.Windows.Forms.CheckBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TimerDeltoLoading = new System.Windows.Forms.Timer(this.components);
            this.TimerDisplayLoading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel5.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel7.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel9.SuspendLayout();
            this.Panel10.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel44.SuspendLayout();
            this.Panel1.SuspendLayout();
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
            this.DeltoId,
            this.Delto,
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Saturday,
            this.Sunday,
            this.CreatedDate});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(5, 168);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(803, 298);
            this.DgvShow.TabIndex = 117;
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
            // DeltoId
            // 
            this.DeltoId.DataPropertyName = "DeltoId";
            this.DeltoId.HeaderText = "#";
            this.DeltoId.Name = "DeltoId";
            this.DeltoId.ReadOnly = true;
            this.DeltoId.Width = 40;
            // 
            // Delto
            // 
            this.Delto.DataPropertyName = "Delto";
            this.Delto.HeaderText = "Delto";
            this.Delto.Name = "Delto";
            this.Delto.ReadOnly = true;
            this.Delto.Width = 63;
            // 
            // Monday
            // 
            this.Monday.DataPropertyName = "Monday";
            this.Monday.HeaderText = "Monday";
            this.Monday.Name = "Monday";
            this.Monday.ReadOnly = true;
            this.Monday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Monday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Monday.Width = 78;
            // 
            // Tuesday
            // 
            this.Tuesday.DataPropertyName = "Tuesday";
            this.Tuesday.HeaderText = "Tuesday";
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.ReadOnly = true;
            this.Tuesday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tuesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Tuesday.Width = 82;
            // 
            // Wednesday
            // 
            this.Wednesday.DataPropertyName = "Wednesday";
            this.Wednesday.HeaderText = "Wednesday";
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.ReadOnly = true;
            this.Wednesday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Wednesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Wednesday.Width = 99;
            // 
            // Thursday
            // 
            this.Thursday.DataPropertyName = "Thursday";
            this.Thursday.HeaderText = "Thursday";
            this.Thursday.Name = "Thursday";
            this.Thursday.ReadOnly = true;
            this.Thursday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Thursday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Thursday.Width = 86;
            // 
            // Friday
            // 
            this.Friday.DataPropertyName = "Friday";
            this.Friday.HeaderText = "Friday";
            this.Friday.Name = "Friday";
            this.Friday.ReadOnly = true;
            this.Friday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Friday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Friday.Width = 69;
            // 
            // Saturday
            // 
            this.Saturday.DataPropertyName = "Saturday";
            this.Saturday.HeaderText = "Saturday";
            this.Saturday.Name = "Saturday";
            this.Saturday.ReadOnly = true;
            this.Saturday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Saturday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Saturday.Width = 84;
            // 
            // Sunday
            // 
            this.Sunday.DataPropertyName = "Sunday";
            this.Sunday.HeaderText = "Sunday";
            this.Sunday.Name = "Sunday";
            this.Sunday.ReadOnly = true;
            this.Sunday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sunday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Sunday.Width = 76;
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
            // Panel5
            // 
            this.Panel5.Controls.Add(this.Panel6);
            this.Panel5.Controls.Add(this.Panel7);
            this.Panel5.Controls.Add(this.Panel8);
            this.Panel5.Controls.Add(this.Panel9);
            this.Panel5.Controls.Add(this.Panel10);
            this.Panel5.Controls.Add(this.Panel2);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel5.Location = new System.Drawing.Point(5, 108);
            this.Panel5.Name = "Panel5";
            this.Panel5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel5.Size = new System.Drawing.Size(803, 60);
            this.Panel5.TabIndex = 116;
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.CmbDelto);
            this.Panel6.Controls.Add(this.Panel3);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel6.Location = new System.Drawing.Point(0, 2);
            this.Panel6.Name = "Panel6";
            this.Panel6.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.Panel6.Size = new System.Drawing.Size(316, 56);
            this.Panel6.TabIndex = 3;
            // 
            // CmbDelto
            // 
            this.CmbDelto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbDelto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbDelto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDelto.FormattingEnabled = true;
            this.CmbDelto.Location = new System.Drawing.Point(0, 27);
            this.CmbDelto.Name = "CmbDelto";
            this.CmbDelto.Size = new System.Drawing.Size(314, 27);
            this.CmbDelto.TabIndex = 1;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.Label4);
            this.Panel3.Controls.Add(this.TxtId);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 2);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(314, 25);
            this.Panel3.TabIndex = 2;
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label4.Location = new System.Drawing.Point(0, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(228, 25);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "Delto";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtId
            // 
            this.TxtId.Dock = System.Windows.Forms.DockStyle.Right;
            this.TxtId.Location = new System.Drawing.Point(228, 0);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(86, 28);
            this.TxtId.TabIndex = 2;
            this.TxtId.TextChanged += new System.EventHandler(this.TxtId_TextChanged);
            this.TxtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtId_KeyPress);
            // 
            // Panel7
            // 
            this.Panel7.Controls.Add(this.ChkTuesday);
            this.Panel7.Controls.Add(this.ChkMonday);
            this.Panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel7.Location = new System.Drawing.Point(316, 2);
            this.Panel7.Name = "Panel7";
            this.Panel7.Padding = new System.Windows.Forms.Padding(2);
            this.Panel7.Size = new System.Drawing.Size(100, 56);
            this.Panel7.TabIndex = 4;
            // 
            // ChkTuesday
            // 
            this.ChkTuesday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkTuesday.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChkTuesday.ForeColor = System.Drawing.Color.Teal;
            this.ChkTuesday.Location = new System.Drawing.Point(2, 27);
            this.ChkTuesday.Name = "ChkTuesday";
            this.ChkTuesday.Size = new System.Drawing.Size(96, 25);
            this.ChkTuesday.TabIndex = 1;
            this.ChkTuesday.Text = "Tuesday";
            this.ChkTuesday.UseVisualStyleBackColor = true;
            // 
            // ChkMonday
            // 
            this.ChkMonday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkMonday.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChkMonday.ForeColor = System.Drawing.Color.Teal;
            this.ChkMonday.Location = new System.Drawing.Point(2, 2);
            this.ChkMonday.Name = "ChkMonday";
            this.ChkMonday.Size = new System.Drawing.Size(96, 25);
            this.ChkMonday.TabIndex = 0;
            this.ChkMonday.Text = "Monday";
            this.ChkMonday.UseVisualStyleBackColor = true;
            // 
            // Panel8
            // 
            this.Panel8.Controls.Add(this.ChkThursday);
            this.Panel8.Controls.Add(this.ChkWednesday);
            this.Panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel8.Location = new System.Drawing.Point(416, 2);
            this.Panel8.Name = "Panel8";
            this.Panel8.Padding = new System.Windows.Forms.Padding(2);
            this.Panel8.Size = new System.Drawing.Size(100, 56);
            this.Panel8.TabIndex = 5;
            // 
            // ChkThursday
            // 
            this.ChkThursday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkThursday.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChkThursday.ForeColor = System.Drawing.Color.Teal;
            this.ChkThursday.Location = new System.Drawing.Point(2, 27);
            this.ChkThursday.Name = "ChkThursday";
            this.ChkThursday.Size = new System.Drawing.Size(96, 25);
            this.ChkThursday.TabIndex = 1;
            this.ChkThursday.Text = "Thursday";
            this.ChkThursday.UseVisualStyleBackColor = true;
            // 
            // ChkWednesday
            // 
            this.ChkWednesday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkWednesday.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChkWednesday.ForeColor = System.Drawing.Color.Teal;
            this.ChkWednesday.Location = new System.Drawing.Point(2, 2);
            this.ChkWednesday.Name = "ChkWednesday";
            this.ChkWednesday.Size = new System.Drawing.Size(96, 25);
            this.ChkWednesday.TabIndex = 0;
            this.ChkWednesday.Text = "Wednesday";
            this.ChkWednesday.UseVisualStyleBackColor = true;
            // 
            // Panel9
            // 
            this.Panel9.Controls.Add(this.ChkSaturday);
            this.Panel9.Controls.Add(this.ChkFriday);
            this.Panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel9.Location = new System.Drawing.Point(516, 2);
            this.Panel9.Name = "Panel9";
            this.Panel9.Padding = new System.Windows.Forms.Padding(2);
            this.Panel9.Size = new System.Drawing.Size(100, 56);
            this.Panel9.TabIndex = 6;
            // 
            // ChkSaturday
            // 
            this.ChkSaturday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkSaturday.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChkSaturday.ForeColor = System.Drawing.Color.Teal;
            this.ChkSaturday.Location = new System.Drawing.Point(2, 27);
            this.ChkSaturday.Name = "ChkSaturday";
            this.ChkSaturday.Size = new System.Drawing.Size(96, 25);
            this.ChkSaturday.TabIndex = 1;
            this.ChkSaturday.Text = "Saturday";
            this.ChkSaturday.UseVisualStyleBackColor = true;
            // 
            // ChkFriday
            // 
            this.ChkFriday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkFriday.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChkFriday.ForeColor = System.Drawing.Color.Teal;
            this.ChkFriday.Location = new System.Drawing.Point(2, 2);
            this.ChkFriday.Name = "ChkFriday";
            this.ChkFriday.Size = new System.Drawing.Size(96, 25);
            this.ChkFriday.TabIndex = 0;
            this.ChkFriday.Text = "Friday";
            this.ChkFriday.UseVisualStyleBackColor = true;
            // 
            // Panel10
            // 
            this.Panel10.Controls.Add(this.ChkSunday);
            this.Panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel10.Location = new System.Drawing.Point(616, 2);
            this.Panel10.Name = "Panel10";
            this.Panel10.Padding = new System.Windows.Forms.Padding(2);
            this.Panel10.Size = new System.Drawing.Size(100, 56);
            this.Panel10.TabIndex = 7;
            // 
            // ChkSunday
            // 
            this.ChkSunday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkSunday.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChkSunday.ForeColor = System.Drawing.Color.Teal;
            this.ChkSunday.Location = new System.Drawing.Point(2, 2);
            this.ChkSunday.Name = "ChkSunday";
            this.ChkSunday.Size = new System.Drawing.Size(96, 25);
            this.ChkSunday.TabIndex = 0;
            this.ChkSunday.Text = "Sunday";
            this.ChkSunday.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnAdd);
            this.Panel2.Controls.Add(this.BtnCancel);
            this.Panel2.Controls.Add(this.BtnUpdate);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel2.Location = new System.Drawing.Point(716, 2);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(87, 56);
            this.Panel2.TabIndex = 8;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnAdd.Image = global::DeliveryTakeOrder.Properties.Resources.add16;
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.Location = new System.Drawing.Point(2, 10);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(83, 37);
            this.BtnAdd.TabIndex = 12;
            this.BtnAdd.Text = "&Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(2, 30);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(83, 28);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "C&ancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnUpdate.Image = global::DeliveryTakeOrder.Properties.Resources.update_16;
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.Location = new System.Drawing.Point(2, 2);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(83, 28);
            this.BtnUpdate.TabIndex = 10;
            this.BtnUpdate.Text = "&Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Visible = false;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.BtnExportToExcel);
            this.Panel44.Controls.Add(this.LblCountRow);
            this.Panel44.Controls.Add(this.BtnClose);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(5, 466);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2);
            this.Panel44.Size = new System.Drawing.Size(803, 35);
            this.Panel44.TabIndex = 115;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(572, 2);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(137, 31);
            this.BtnExportToExcel.TabIndex = 12;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
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
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(709, 2);
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
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(803, 103);
            this.Panel1.TabIndex = 114;
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
            this.Panel4.Size = new System.Drawing.Size(803, 2);
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
            // TimerDeltoLoading
            // 
            this.TimerDeltoLoading.Interval = 5;
            this.TimerDeltoLoading.Tick += new System.EventHandler(this.TimerDeltoLoading_Tick);
            // 
            // TimerDisplayLoading
            // 
            this.TimerDisplayLoading.Interval = 5;
            this.TimerDisplayLoading.Tick += new System.EventHandler(this.TimerDisplayLoading_Tick);
            // 
            // FrmDeltoListForDutchmillPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 506);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel5);
            this.Controls.Add(this.Panel44);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDeltoListForDutchmillPO";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delto List For Dutchmill P.O";
            this.Activated += new System.EventHandler(this.FrmDeltoListForDutchmillPO_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDeltoListForDutchmillPO_FormClosed);
            this.Load += new System.EventHandler(this.FrmDeltoListForDutchmillPO_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDeltoListForDutchmillPO_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel5.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel7.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.Panel9.ResumeLayout(false);
            this.Panel10.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel44.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DeltoId;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Delto;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Monday;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Tuesday;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Wednesday;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Thursday;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Friday;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Saturday;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Sunday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.ComboBox CmbDelto;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox TxtId;
        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.CheckBox ChkTuesday;
        internal System.Windows.Forms.CheckBox ChkMonday;
        internal System.Windows.Forms.Panel Panel8;
        internal System.Windows.Forms.CheckBox ChkThursday;
        internal System.Windows.Forms.CheckBox ChkWednesday;
        internal System.Windows.Forms.Panel Panel9;
        internal System.Windows.Forms.CheckBox ChkSaturday;
        internal System.Windows.Forms.CheckBox ChkFriday;
        internal System.Windows.Forms.Panel Panel10;
        internal System.Windows.Forms.CheckBox ChkSunday;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnAdd;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Button BtnUpdate;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Timer TimerDeltoLoading;
        internal System.Windows.Forms.Timer TimerDisplayLoading;
    }
}