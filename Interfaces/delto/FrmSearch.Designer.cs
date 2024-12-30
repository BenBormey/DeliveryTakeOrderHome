namespace DeliveryTakeOrder.Interfaces.delto
{
    partial class FrmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
            this.rdbphonenumber = new System.Windows.Forms.RadioButton();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.RdbCustomerName = new System.Windows.Forms.RadioButton();
            this.RdbCustomerId = new System.Windows.Forms.RadioButton();
            this.Panel13 = new System.Windows.Forms.Panel();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.LblMsg = new System.Windows.Forms.Label();
            this.Panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbphonenumber
            // 
            this.rdbphonenumber.AutoSize = true;
            this.rdbphonenumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbphonenumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rdbphonenumber.Location = new System.Drawing.Point(48, 61);
            this.rdbphonenumber.Name = "rdbphonenumber";
            this.rdbphonenumber.Size = new System.Drawing.Size(102, 17);
            this.rdbphonenumber.TabIndex = 22;
            this.rdbphonenumber.Text = "Phone Number";
            this.rdbphonenumber.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(167, 131);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(108, 30);
            this.BtnCancel.TabIndex = 21;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(48, 131);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(113, 30);
            this.BtnOK.TabIndex = 20;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // RdbCustomerName
            // 
            this.RdbCustomerName.AutoSize = true;
            this.RdbCustomerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RdbCustomerName.Location = new System.Drawing.Point(48, 38);
            this.RdbCustomerName.Name = "RdbCustomerName";
            this.RdbCustomerName.Size = new System.Drawing.Size(106, 17);
            this.RdbCustomerName.TabIndex = 19;
            this.RdbCustomerName.Text = "Customer Name";
            this.RdbCustomerName.UseVisualStyleBackColor = true;
            // 
            // RdbCustomerId
            // 
            this.RdbCustomerId.AutoSize = true;
            this.RdbCustomerId.Checked = true;
            this.RdbCustomerId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbCustomerId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RdbCustomerId.Location = new System.Drawing.Point(48, 15);
            this.RdbCustomerId.Name = "RdbCustomerId";
            this.RdbCustomerId.Size = new System.Drawing.Size(87, 17);
            this.RdbCustomerId.TabIndex = 18;
            this.RdbCustomerId.TabStop = true;
            this.RdbCustomerId.Text = "Customer Id";
            this.RdbCustomerId.UseVisualStyleBackColor = true;
            this.RdbCustomerId.CheckedChanged += new System.EventHandler(this.RdbCustomerId_CheckedChanged);
            // 
            // Panel13
            // 
            this.Panel13.BackColor = System.Drawing.Color.Transparent;
            this.Panel13.Controls.Add(this.TxtSearch);
            this.Panel13.Controls.Add(this.LblMsg);
            this.Panel13.ForeColor = System.Drawing.Color.Maroon;
            this.Panel13.Location = new System.Drawing.Point(48, 81);
            this.Panel13.Name = "Panel13";
            this.Panel13.Size = new System.Drawing.Size(227, 44);
            this.Panel13.TabIndex = 17;
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.Color.Black;
            this.TxtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtSearch.Location = new System.Drawing.Point(0, 22);
            this.TxtSearch.MaxLength = 100;
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(227, 22);
            this.TxtSearch.TabIndex = 0;
            this.TxtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearch_KeyPress);
            // 
            // LblMsg
            // 
            this.LblMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LblMsg.Location = new System.Drawing.Point(0, 0);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(227, 22);
            this.LblMsg.TabIndex = 0;
            this.LblMsg.Text = "Please enter the customer id :";
            this.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(318, 173);
            this.ControlBox = false;
            this.Controls.Add(this.rdbphonenumber);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.RdbCustomerName);
            this.Controls.Add(this.RdbCustomerId);
            this.Controls.Add(this.Panel13);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Search...";
            this.Activated += new System.EventHandler(this.FrmSearch_Activated);
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmSearch_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmSearch_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmSearch_MouseUp);
            this.Panel13.ResumeLayout(false);
            this.Panel13.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RadioButton rdbphonenumber;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.RadioButton RdbCustomerName;
        internal System.Windows.Forms.RadioButton RdbCustomerId;
        internal System.Windows.Forms.Panel Panel13;
        internal System.Windows.Forms.TextBox TxtSearch;
        internal System.Windows.Forms.Label LblMsg;
    }
}