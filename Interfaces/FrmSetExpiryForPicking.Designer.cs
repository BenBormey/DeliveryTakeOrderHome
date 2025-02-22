
namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmSetExpiryForPicking
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
            this.Panel3 = new System.Windows.Forms.Panel();
            this.dgvshow = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodbeforeexpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.btnexporttoexcel = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblcountrow = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.cmbcustomer = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.cmbperiodbeforeexpiry = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.btnadd = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.loading = new System.Windows.Forms.Timer(this.components);
            this.customerloading = new System.Windows.Forms.Timer(this.components);
            this.periodloading = new System.Windows.Forms.Timer(this.components);
            this.displayloading = new System.Windows.Forms.Timer(this.components);
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvshow)).BeginInit();
            this.Panel9.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.Panel7.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.dgvshow);
            this.Panel3.Controls.Add(this.Panel9);
            this.Panel3.Controls.Add(this.Panel5);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(5, 108);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(2);
            this.Panel3.Size = new System.Drawing.Size(597, 391);
            this.Panel3.TabIndex = 110;
            // 
            // dgvshow
            // 
            this.dgvshow.AllowUserToAddRows = false;
            this.dgvshow.AllowUserToDeleteRows = false;
            this.dgvshow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvshow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvshow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cusnum,
            this.cusname,
            this.periodbeforeexpiry,
            this.createddate});
            this.dgvshow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvshow.Location = new System.Drawing.Point(2, 49);
            this.dgvshow.Name = "dgvshow";
            this.dgvshow.ReadOnly = true;
            this.dgvshow.Size = new System.Drawing.Size(593, 305);
            this.dgvshow.TabIndex = 110;
            this.dgvshow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvshow_KeyDown);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 42;
            // 
            // cusnum
            // 
            this.cusnum.DataPropertyName = "cusnum";
            this.cusnum.HeaderText = "#";
            this.cusnum.Name = "cusnum";
            this.cusnum.ReadOnly = true;
            this.cusnum.Width = 39;
            // 
            // cusname
            // 
            this.cusname.DataPropertyName = "cusname";
            this.cusname.HeaderText = "Customer";
            this.cusname.Name = "cusname";
            this.cusname.ReadOnly = true;
            this.cusname.Width = 81;
            // 
            // periodbeforeexpiry
            // 
            this.periodbeforeexpiry.DataPropertyName = "periodbeforeexpiry";
            this.periodbeforeexpiry.HeaderText = "Period Before Expiry";
            this.periodbeforeexpiry.Name = "periodbeforeexpiry";
            this.periodbeforeexpiry.ReadOnly = true;
            this.periodbeforeexpiry.Width = 123;
            // 
            // createddate
            // 
            this.createddate.DataPropertyName = "createddate";
            this.createddate.HeaderText = "createddate";
            this.createddate.Name = "createddate";
            this.createddate.ReadOnly = true;
            this.createddate.Visible = false;
            this.createddate.Width = 93;
            // 
            // Panel9
            // 
            this.Panel9.BackColor = System.Drawing.SystemColors.Control;
            this.Panel9.Controls.Add(this.btnexporttoexcel);
            this.Panel9.Controls.Add(this.btnclose);
            this.Panel9.Controls.Add(this.lblcountrow);
            this.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel9.Location = new System.Drawing.Point(2, 354);
            this.Panel9.Name = "Panel9";
            this.Panel9.Padding = new System.Windows.Forms.Padding(2);
            this.Panel9.Size = new System.Drawing.Size(593, 35);
            this.Panel9.TabIndex = 109;
            // 
            // btnexporttoexcel
            // 
            this.btnexporttoexcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexporttoexcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnexporttoexcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel;
            this.btnexporttoexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexporttoexcel.Location = new System.Drawing.Point(305, 2);
            this.btnexporttoexcel.Name = "btnexporttoexcel";
            this.btnexporttoexcel.Size = new System.Drawing.Size(174, 31);
            this.btnexporttoexcel.TabIndex = 13;
            this.btnexporttoexcel.Text = "&Export To Excel";
            this.btnexporttoexcel.UseVisualStyleBackColor = true;
            this.btnexporttoexcel.Click += new System.EventHandler(this.btnexporttoexcel_Click);
            // 
            // btnclose
            // 
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.Image = global::DeliveryTakeOrder.Properties.Resources._close_;
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnclose.Location = new System.Drawing.Point(479, 2);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(112, 31);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblcountrow
            // 
            this.lblcountrow.AutoSize = true;
            this.lblcountrow.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblcountrow.Location = new System.Drawing.Point(2, 2);
            this.lblcountrow.Name = "lblcountrow";
            this.lblcountrow.Size = new System.Drawing.Size(80, 13);
            this.lblcountrow.TabIndex = 11;
            this.lblcountrow.Text = "Count Row : 0";
            this.lblcountrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.SystemColors.Control;
            this.Panel5.Controls.Add(this.Panel6);
            this.Panel5.Controls.Add(this.Panel7);
            this.Panel5.Controls.Add(this.Panel8);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel5.Location = new System.Drawing.Point(2, 2);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(593, 47);
            this.Panel5.TabIndex = 108;
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.cmbcustomer);
            this.Panel6.Controls.Add(this.Label2);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel6.Location = new System.Drawing.Point(0, 0);
            this.Panel6.Name = "Panel6";
            this.Panel6.Padding = new System.Windows.Forms.Padding(2);
            this.Panel6.Size = new System.Drawing.Size(305, 47);
            this.Panel6.TabIndex = 8;
            // 
            // cmbcustomer
            // 
            this.cmbcustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbcustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbcustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcustomer.FormattingEnabled = true;
            this.cmbcustomer.Location = new System.Drawing.Point(2, 22);
            this.cmbcustomer.Name = "cmbcustomer";
            this.cmbcustomer.Size = new System.Drawing.Size(301, 21);
            this.cmbcustomer.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Location = new System.Drawing.Point(2, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(301, 20);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Customer";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel7
            // 
            this.Panel7.Controls.Add(this.cmbperiodbeforeexpiry);
            this.Panel7.Controls.Add(this.Label4);
            this.Panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel7.Location = new System.Drawing.Point(305, 0);
            this.Panel7.Name = "Panel7";
            this.Panel7.Padding = new System.Windows.Forms.Padding(2);
            this.Panel7.Size = new System.Drawing.Size(172, 47);
            this.Panel7.TabIndex = 9;
            // 
            // cmbperiodbeforeexpiry
            // 
            this.cmbperiodbeforeexpiry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbperiodbeforeexpiry.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbperiodbeforeexpiry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbperiodbeforeexpiry.FormattingEnabled = true;
            this.cmbperiodbeforeexpiry.Location = new System.Drawing.Point(2, 22);
            this.cmbperiodbeforeexpiry.Name = "cmbperiodbeforeexpiry";
            this.cmbperiodbeforeexpiry.Size = new System.Drawing.Size(168, 21);
            this.cmbperiodbeforeexpiry.TabIndex = 1;
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label4.Location = new System.Drawing.Point(2, 2);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(168, 20);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Period Before Expiry";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel8
            // 
            this.Panel8.Controls.Add(this.btnadd);
            this.Panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel8.Location = new System.Drawing.Point(477, 0);
            this.Panel8.Name = "Panel8";
            this.Panel8.Padding = new System.Windows.Forms.Padding(2);
            this.Panel8.Size = new System.Drawing.Size(116, 47);
            this.Panel8.TabIndex = 10;
            // 
            // btnadd
            // 
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnadd.Location = new System.Drawing.Point(2, 14);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(112, 31);
            this.btnadd.TabIndex = 10;
            this.btnadd.Text = "&Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(597, 103);
            this.Panel1.TabIndex = 109;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Firebrick;
            this.Label3.Location = new System.Drawing.Point(408, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(189, 101);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "USE FOR NESTLE ONLY";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.LblCompanyName);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel2.Location = new System.Drawing.Point(94, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(314, 101);
            this.Panel2.TabIndex = 8;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(2, 35);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(310, 64);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(2, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(310, 33);
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
            this.Panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 101);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(597, 2);
            this.Panel4.TabIndex = 7;
            // 
            // loading
            // 
            this.loading.Interval = 5;
            this.loading.Tick += new System.EventHandler(this.loading_Tick);
            // 
            // customerloading
            // 
            this.customerloading.Interval = 5;
            this.customerloading.Tick += new System.EventHandler(this.customerloading_Tick);
            // 
            // periodloading
            // 
            this.periodloading.Interval = 5;
            this.periodloading.Tick += new System.EventHandler(this.periodloading_Tick);
            // 
            // displayloading
            // 
            this.displayloading.Interval = 5;
            this.displayloading.Tick += new System.EventHandler(this.displayloading_Tick);
            // 
            // FrmSetExpiryForPicking
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 504);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "FrmSetExpiryForPicking";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Set Period Expiry For Picking";
            this.Load += new System.EventHandler(this.FrmSetExpiryForPicking_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmSetExpiryForPicking_Paint);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvshow)).EndInit();
            this.Panel9.ResumeLayout(false);
            this.Panel9.PerformLayout();
            this.Panel5.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.Panel7.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.DataGridView dgvshow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn cusnum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn cusname;
        internal System.Windows.Forms.DataGridViewTextBoxColumn periodbeforeexpiry;
        internal System.Windows.Forms.DataGridViewTextBoxColumn createddate;
        internal System.Windows.Forms.Panel Panel9;
        internal System.Windows.Forms.Button btnexporttoexcel;
        internal System.Windows.Forms.Button btnclose;
        internal System.Windows.Forms.Label lblcountrow;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.ComboBox cmbcustomer;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.ComboBox cmbperiodbeforeexpiry;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Panel Panel8;
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Timer loading;
        internal System.Windows.Forms.Timer customerloading;
        internal System.Windows.Forms.Timer periodloading;
        internal System.Windows.Forms.Timer displayloading;
    }
}