namespace DeliveryTakeOrder.Interfaces.WS_Products_List
{
    partial class gui_ws_products_messagebox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel20 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.dgvavg = new System.Windows.Forms.DataGridView();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalavgpcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalavgctn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.dateorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalpcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalctn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblmsg = new System.Windows.Forms.Label();
            this.Panel14 = new System.Windows.Forms.Panel();
            this.txtreason = new System.Windows.Forms.TextBox();
            this.Panel15 = new System.Windows.Forms.Panel();
            this.Label10 = new System.Windows.Forms.Label();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.BtnFinish = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel20.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvavg)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel14.SuspendLayout();
            this.Panel15.SuspendLayout();
            this.Panel44.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel20
            // 
            this.Panel20.Controls.Add(this.Panel2);
            this.Panel20.Controls.Add(this.Panel1);
            this.Panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel20.Location = new System.Drawing.Point(2, 2);
            this.Panel20.Name = "Panel20";
            this.Panel20.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Panel20.Size = new System.Drawing.Size(640, 215);
            this.Panel20.TabIndex = 117;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.dgvavg);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(293, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Panel2.Size = new System.Drawing.Size(345, 215);
            this.Panel2.TabIndex = 115;
            // 
            // dgvavg
            // 
            this.dgvavg.AllowUserToAddRows = false;
            this.dgvavg.AllowUserToDeleteRows = false;
            this.dgvavg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvavg.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvavg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvavg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.year,
            this.month,
            this.month_,
            this.totalavgpcs,
            this.totalavgctn});
            this.dgvavg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvavg.Location = new System.Drawing.Point(2, 23);
            this.dgvavg.Name = "dgvavg";
            this.dgvavg.ReadOnly = true;
            this.dgvavg.RowHeadersWidth = 25;
            this.dgvavg.Size = new System.Drawing.Size(341, 192);
            this.dgvavg.TabIndex = 112;
            // 
            // year
            // 
            this.year.DataPropertyName = "year";
            this.year.HeaderText = "Year";
            this.year.Name = "year";
            this.year.ReadOnly = true;
            this.year.Width = 57;
            // 
            // month
            // 
            this.month.DataPropertyName = "month";
            this.month.HeaderText = "Month";
            this.month.Name = "month";
            this.month.ReadOnly = true;
            this.month.Width = 64;
            // 
            // month_
            // 
            this.month_.DataPropertyName = "month_";
            this.month_.HeaderText = "month_";
            this.month_.Name = "month_";
            this.month_.ReadOnly = true;
            this.month_.Visible = false;
            this.month_.Width = 70;
            // 
            // totalavgpcs
            // 
            this.totalavgpcs.DataPropertyName = "totalavgpcs";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N0";
            this.totalavgpcs.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalavgpcs.HeaderText = "T. Avg Pcs";
            this.totalavgpcs.Name = "totalavgpcs";
            this.totalavgpcs.ReadOnly = true;
            this.totalavgpcs.Width = 86;
            // 
            // totalavgctn
            // 
            this.totalavgctn.DataPropertyName = "totalavgctn";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            this.totalavgctn.DefaultCellStyle = dataGridViewCellStyle7;
            this.totalavgctn.HeaderText = "T. Avg CTN";
            this.totalavgctn.Name = "totalavgctn";
            this.totalavgctn.ReadOnly = true;
            this.totalavgctn.Width = 87;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Blue;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(341, 23);
            this.Label1.TabIndex = 113;
            this.Label1.Text = "របាយការណ៍លក់មធ្យម ៣ ខែចុងក្រោយ";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.DgvShow);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.Location = new System.Drawing.Point(2, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Panel1.Size = new System.Drawing.Size(291, 215);
            this.Panel1.TabIndex = 114;
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvShow.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateorder,
            this.totalpcs,
            this.totalctn});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(2, 23);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(287, 192);
            this.DgvShow.TabIndex = 112;
            // 
            // dateorder
            // 
            this.dateorder.DataPropertyName = "dateorder";
            dataGridViewCellStyle8.Format = "dd-MMM-yyyy";
            this.dateorder.DefaultCellStyle = dataGridViewCellStyle8;
            this.dateorder.HeaderText = "Date";
            this.dateorder.Name = "dateorder";
            this.dateorder.ReadOnly = true;
            this.dateorder.Width = 56;
            // 
            // totalpcs
            // 
            this.totalpcs.DataPropertyName = "totalpcs";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "N0";
            this.totalpcs.DefaultCellStyle = dataGridViewCellStyle9;
            this.totalpcs.HeaderText = "Total Pcs";
            this.totalpcs.Name = "totalpcs";
            this.totalpcs.ReadOnly = true;
            this.totalpcs.Width = 79;
            // 
            // totalctn
            // 
            this.totalctn.DataPropertyName = "totalctn";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "N2";
            this.totalctn.DefaultCellStyle = dataGridViewCellStyle10;
            this.totalctn.HeaderText = "Total CTN";
            this.totalctn.Name = "totalctn";
            this.totalctn.ReadOnly = true;
            this.totalctn.Width = 80;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Blue;
            this.Label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(2, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(287, 23);
            this.Label6.TabIndex = 113;
            this.Label6.Text = "របាយការណ៍លក់ ៣ ខែចុងក្រោយ";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmsg
            // 
            this.lblmsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblmsg.Font = new System.Drawing.Font("Khmer OS Siemreap", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.ForeColor = System.Drawing.Color.Maroon;
            this.lblmsg.Location = new System.Drawing.Point(2, 217);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(640, 122);
            this.lblmsg.TabIndex = 115;
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel14
            // 
            this.Panel14.Controls.Add(this.txtreason);
            this.Panel14.Controls.Add(this.Panel15);
            this.Panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel14.Location = new System.Drawing.Point(2, 339);
            this.Panel14.Name = "Panel14";
            this.Panel14.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Panel14.Size = new System.Drawing.Size(640, 87);
            this.Panel14.TabIndex = 118;
            // 
            // txtreason
            // 
            this.txtreason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtreason.Font = new System.Drawing.Font("Khmer OS Siemreap", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreason.Location = new System.Drawing.Point(2, 24);
            this.txtreason.Multiline = true;
            this.txtreason.Name = "txtreason";
            this.txtreason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtreason.Size = new System.Drawing.Size(636, 63);
            this.txtreason.TabIndex = 2;
            // 
            // Panel15
            // 
            this.Panel15.Controls.Add(this.Label10);
            this.Panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel15.Location = new System.Drawing.Point(2, 0);
            this.Panel15.Name = "Panel15";
            this.Panel15.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel15.Size = new System.Drawing.Size(636, 24);
            this.Panel15.TabIndex = 1;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label10.ForeColor = System.Drawing.Color.Teal;
            this.Label10.Location = new System.Drawing.Point(0, 2);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(256, 19);
            this.Label10.TabIndex = 0;
            this.Label10.Text = "ករណី អ្នកចង់បន្ត សូមបញ្ចូលហេតុផលអោយបានត្រឹមត្រូវ";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.BtnFinish);
            this.Panel44.Controls.Add(this.BtnClose);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(2, 426);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2);
            this.Panel44.Size = new System.Drawing.Size(640, 35);
            this.Panel44.TabIndex = 116;
            // 
            // BtnFinish
            // 
            this.BtnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFinish.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.BtnFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnFinish.Image = global::DeliveryTakeOrder.Properties.Resources.tick_16;
            this.BtnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFinish.Location = new System.Drawing.Point(217, 3);
            this.BtnFinish.Name = "BtnFinish";
            this.BtnFinish.Size = new System.Drawing.Size(100, 31);
            this.BtnFinish.TabIndex = 10;
            this.BtnFinish.Text = "បន្ត";
            this.BtnFinish.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.No;
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(323, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(100, 31);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "មិនបន្ត";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // gui_ws_products_messagebox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 463);
            this.Controls.Add(this.Panel20);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.Panel14);
            this.Controls.Add(this.Panel44);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gui_ws_products_messagebox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "gui_ws_products_messagebox";
            this.Panel20.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvavg)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel14.ResumeLayout(false);
            this.Panel14.PerformLayout();
            this.Panel15.ResumeLayout(false);
            this.Panel15.PerformLayout();
            this.Panel44.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel20;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.DataGridView dgvavg;
        internal System.Windows.Forms.DataGridViewTextBoxColumn year;
        internal System.Windows.Forms.DataGridViewTextBoxColumn month;
        internal System.Windows.Forms.DataGridViewTextBoxColumn month_;
        internal System.Windows.Forms.DataGridViewTextBoxColumn totalavgpcs;
        internal System.Windows.Forms.DataGridViewTextBoxColumn totalavgctn;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn dateorder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn totalpcs;
        internal System.Windows.Forms.DataGridViewTextBoxColumn totalctn;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblmsg;
        internal System.Windows.Forms.Panel Panel14;
        internal System.Windows.Forms.TextBox txtreason;
        internal System.Windows.Forms.Panel Panel15;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button BtnFinish;
        internal System.Windows.Forms.Button BtnClose;
    }
}