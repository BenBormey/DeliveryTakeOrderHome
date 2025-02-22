
namespace DeliveryTakeOrder.App.CustomerAging
{
    partial class ar_aging_init
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
            this.rbTeam = new System.Windows.Forms.RadioButton();
            this.cboTeam = new System.Windows.Forms.ComboBox();
            this.rbSupplier = new System.Windows.Forms.RadioButton();
            this.grpAging = new System.Windows.Forms.GroupBox();
            this.chkExludeZero = new System.Windows.Forms.CheckBox();
            this.chkE = new System.Windows.Forms.CheckBox();
            this.chkD = new System.Windows.Forms.CheckBox();
            this.chkB = new System.Windows.Forms.CheckBox();
            this.chkC = new System.Windows.Forms.CheckBox();
            this.chkA = new System.Windows.Forms.CheckBox();
            this.chkCurrent = new System.Windows.Forms.CheckBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panLine = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpAging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbTeam
            // 
            this.rbTeam.Location = new System.Drawing.Point(22, 186);
            this.rbTeam.Name = "rbTeam";
            this.rbTeam.Size = new System.Drawing.Size(66, 17);
            this.rbTeam.TabIndex = 39;
            this.rbTeam.Text = "Team:";
            this.rbTeam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTeam.UseVisualStyleBackColor = true;
            // 
            // cboTeam
            // 
            this.cboTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeam.Enabled = false;
            this.cboTeam.FormattingEnabled = true;
            this.cboTeam.Location = new System.Drawing.Point(94, 185);
            this.cboTeam.Name = "cboTeam";
            this.cboTeam.Size = new System.Drawing.Size(313, 21);
            this.cboTeam.TabIndex = 38;
            // 
            // rbSupplier
            // 
            this.rbSupplier.Checked = true;
            this.rbSupplier.Location = new System.Drawing.Point(22, 159);
            this.rbSupplier.Name = "rbSupplier";
            this.rbSupplier.Size = new System.Drawing.Size(66, 17);
            this.rbSupplier.TabIndex = 37;
            this.rbSupplier.TabStop = true;
            this.rbSupplier.Text = "Supplier:";
            this.rbSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbSupplier.UseVisualStyleBackColor = true;
            // 
            // grpAging
            // 
            this.grpAging.Controls.Add(this.chkExludeZero);
            this.grpAging.Controls.Add(this.chkE);
            this.grpAging.Controls.Add(this.chkD);
            this.grpAging.Controls.Add(this.chkB);
            this.grpAging.Controls.Add(this.chkC);
            this.grpAging.Controls.Add(this.chkA);
            this.grpAging.Controls.Add(this.chkCurrent);
            this.grpAging.Controls.Add(this.chkSelectAll);
            this.grpAging.Location = new System.Drawing.Point(26, 238);
            this.grpAging.Name = "grpAging";
            this.grpAging.Size = new System.Drawing.Size(391, 70);
            this.grpAging.TabIndex = 36;
            this.grpAging.TabStop = false;
            this.grpAging.Text = "Aging";
            // 
            // chkExludeZero
            // 
            this.chkExludeZero.AutoSize = true;
            this.chkExludeZero.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkExludeZero.Location = new System.Drawing.Point(81, 19);
            this.chkExludeZero.Name = "chkExludeZero";
            this.chkExludeZero.Size = new System.Drawing.Size(73, 17);
            this.chkExludeZero.TabIndex = 7;
            this.chkExludeZero.Text = "Exclude 0";
            this.chkExludeZero.UseVisualStyleBackColor = true;
            this.chkExludeZero.Visible = false;
            // 
            // chkE
            // 
            this.chkE.AutoSize = true;
            this.chkE.Checked = true;
            this.chkE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkE.Enabled = false;
            this.chkE.Location = new System.Drawing.Point(338, 42);
            this.chkE.Name = "chkE";
            this.chkE.Size = new System.Drawing.Size(44, 17);
            this.chkE.TabIndex = 6;
            this.chkE.Text = ">90";
            this.chkE.UseVisualStyleBackColor = true;
            // 
            // chkD
            // 
            this.chkD.AutoSize = true;
            this.chkD.Checked = true;
            this.chkD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkD.Enabled = false;
            this.chkD.Location = new System.Drawing.Point(273, 42);
            this.chkD.Name = "chkD";
            this.chkD.Size = new System.Drawing.Size(53, 17);
            this.chkD.TabIndex = 5;
            this.chkD.Text = "61-90";
            this.chkD.UseVisualStyleBackColor = true;
            // 
            // chkB
            // 
            this.chkB.AutoSize = true;
            this.chkB.Checked = true;
            this.chkB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkB.Enabled = false;
            this.chkB.Location = new System.Drawing.Point(140, 42);
            this.chkB.Name = "chkB";
            this.chkB.Size = new System.Drawing.Size(56, 17);
            this.chkB.TabIndex = 4;
            this.chkB.Text = "31-45 ";
            this.chkB.UseVisualStyleBackColor = true;
            // 
            // chkC
            // 
            this.chkC.AutoSize = true;
            this.chkC.Checked = true;
            this.chkC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkC.Enabled = false;
            this.chkC.Location = new System.Drawing.Point(208, 42);
            this.chkC.Name = "chkC";
            this.chkC.Size = new System.Drawing.Size(53, 17);
            this.chkC.TabIndex = 3;
            this.chkC.Text = "46-60";
            this.chkC.UseVisualStyleBackColor = true;
            // 
            // chkA
            // 
            this.chkA.AutoSize = true;
            this.chkA.Checked = true;
            this.chkA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkA.Enabled = false;
            this.chkA.Location = new System.Drawing.Point(81, 42);
            this.chkA.Name = "chkA";
            this.chkA.Size = new System.Drawing.Size(47, 17);
            this.chkA.TabIndex = 2;
            this.chkA.Text = "1-30";
            this.chkA.UseVisualStyleBackColor = true;
            // 
            // chkCurrent
            // 
            this.chkCurrent.AutoSize = true;
            this.chkCurrent.Checked = true;
            this.chkCurrent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCurrent.Enabled = false;
            this.chkCurrent.Location = new System.Drawing.Point(9, 42);
            this.chkCurrent.Name = "chkCurrent";
            this.chkCurrent.Size = new System.Drawing.Size(60, 17);
            this.chkCurrent.TabIndex = 1;
            this.chkCurrent.Text = "Current";
            this.chkCurrent.UseVisualStyleBackColor = true;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkSelectAll.Location = new System.Drawing.Point(9, 19);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(94, 158);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(313, 21);
            this.cboSupplier.TabIndex = 35;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(34, 134);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(54, 13);
            this.Label3.TabIndex = 34;
            this.Label3.Text = "Customer:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(94, 131);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(313, 21);
            this.cboCustomer.TabIndex = 26;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(319, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(94, 212);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(105, 20);
            this.dtpStartDate.TabIndex = 28;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(55, 216);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(34, 13);
            this.Label5.TabIndex = 33;
            this.Label5.Text = "As of:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(212, 314);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 30);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // panLine
            // 
            this.panLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panLine.BackColor = System.Drawing.SystemColors.Highlight;
            this.panLine.Location = new System.Drawing.Point(2, 80);
            this.panLine.Name = "panLine";
            this.panLine.Size = new System.Drawing.Size(428, 2);
            this.panLine.TabIndex = 31;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(80, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 24);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "AR Aging Report";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::DeliveryTakeOrder.Properties.Resources.Logo;
            this.PictureBox1.Location = new System.Drawing.Point(2, 9);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(72, 72);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 27;
            this.PictureBox1.TabStop = false;
            // 
            // ar_aging_init
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 339);
            this.Controls.Add(this.rbTeam);
            this.Controls.Add(this.cboTeam);
            this.Controls.Add(this.rbSupplier);
            this.Controls.Add(this.grpAging);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panLine);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.PictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "ar_aging_init";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Daily Report";
            this.Load += new System.EventHandler(this.ar_aging_init_Load);
            this.grpAging.ResumeLayout(false);
            this.grpAging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RadioButton rbTeam;
        internal System.Windows.Forms.ComboBox cboTeam;
        internal System.Windows.Forms.RadioButton rbSupplier;
        internal System.Windows.Forms.GroupBox grpAging;
        internal System.Windows.Forms.CheckBox chkExludeZero;
        internal System.Windows.Forms.CheckBox chkE;
        internal System.Windows.Forms.CheckBox chkD;
        internal System.Windows.Forms.CheckBox chkB;
        internal System.Windows.Forms.CheckBox chkC;
        internal System.Windows.Forms.CheckBox chkA;
        internal System.Windows.Forms.CheckBox chkCurrent;
        internal System.Windows.Forms.CheckBox chkSelectAll;
        internal System.Windows.Forms.ComboBox cboSupplier;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cboCustomer;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.DateTimePicker dtpStartDate;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Panel panLine;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}