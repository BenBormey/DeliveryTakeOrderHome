using System;

namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmPasswordLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPasswordLogin));
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.BtnLogIn = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarehouseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWarehouseName.Location = new System.Drawing.Point(45, 181);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(341, 32);
            this.lblWarehouseName.TabIndex = 111;
            this.lblWarehouseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(434, 100);
            this.Panel1.TabIndex = 110;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(110, 32);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(324, 65);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(110, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(324, 32);
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
            this.PicLogo.Size = new System.Drawing.Size(110, 97);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 3;
            this.PicLogo.TabStop = false;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.Teal;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 97);
            this.Panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(434, 3);
            this.Panel4.TabIndex = 7;
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogIn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogIn.ForeColor = System.Drawing.Color.Teal;
            this.BtnLogIn.Image = global::DeliveryTakeOrder.Properties.Resources.Password;
            this.BtnLogIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLogIn.Location = new System.Drawing.Point(68, 308);
            this.BtnLogIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(169, 38);
            this.BtnLogIn.TabIndex = 108;
            this.BtnLogIn.Text = "&Login";
            this.BtnLogIn.UseVisualStyleBackColor = false;
            this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.Teal;
            this.BtnExit.Image = global::DeliveryTakeOrder.Properties.Resources.Close;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExit.Location = new System.Drawing.Point(243, 308);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(143, 38);
            this.BtnExit.TabIndex = 109;
            this.BtnExit.Text = "&Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.TxtPassword);
            this.Panel2.Controls.Add(this.Label5);
            this.Panel2.Controls.Add(this.PictureBox2);
            this.Panel2.Location = new System.Drawing.Point(49, 249);
            this.Panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(337, 51);
            this.Panel2.TabIndex = 107;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPassword.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(18, 21);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtPassword.MaxLength = 25;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '◦';
            this.TxtPassword.Size = new System.Drawing.Size(317, 28);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassword_KeyPress);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label5.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(18, 2);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(161, 19);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Please enter the password :";
            // 
            // PictureBox2
            // 
            this.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox2.Image = global::DeliveryTakeOrder.Properties.Resources.Password;
            this.PictureBox2.Location = new System.Drawing.Point(2, 2);
            this.PictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(16, 47);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox2.TabIndex = 0;
            this.PictureBox2.TabStop = false;
            // 
            // FrmPasswordLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.lblWarehouseName);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.BtnLogIn);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.Panel2);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPasswordLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPasswordLogin";
            this.Activated += new System.EventHandler(this.PasswordContinues_Load);
            this.Load += new System.EventHandler(this.FrmPasswordLogin_Load);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblWarehouseName;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Button BtnLogIn;
        internal System.Windows.Forms.Button BtnExit;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TextBox TxtPassword;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.PictureBox PictureBox2;
    }
}