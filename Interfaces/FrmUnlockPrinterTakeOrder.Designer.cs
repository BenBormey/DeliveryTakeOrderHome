namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmUnlockPrinterTakeOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnlockPrinterTakeOrder));
            this.Panel7 = new System.Windows.Forms.Panel();
            this.BtnUnlockPrinter = new System.Windows.Forms.Button();
            this.PicStatus = new System.Windows.Forms.PictureBox();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TimerLoading = new System.Windows.Forms.Timer(this.components);
            this.Panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicStatus)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel7
            // 
            this.Panel7.Controls.Add(this.BtnUnlockPrinter);
            this.Panel7.Controls.Add(this.PicStatus);
            this.Panel7.Location = new System.Drawing.Point(52, 191);
            this.Panel7.Name = "Panel7";
            this.Panel7.Size = new System.Drawing.Size(294, 36);
            this.Panel7.TabIndex = 118;
            // 
            // BtnUnlockPrinter
            // 
            this.BtnUnlockPrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUnlockPrinter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnUnlockPrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnUnlockPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUnlockPrinter.Location = new System.Drawing.Point(42, 0);
            this.BtnUnlockPrinter.Name = "BtnUnlockPrinter";
            this.BtnUnlockPrinter.Size = new System.Drawing.Size(252, 36);
            this.BtnUnlockPrinter.TabIndex = 113;
            this.BtnUnlockPrinter.Text = "&UNLOCK PRINTER";
            this.BtnUnlockPrinter.UseVisualStyleBackColor = true;
            this.BtnUnlockPrinter.Click += new System.EventHandler(this.BtnUnlockPrinter_Click);
            // 
            // PicStatus
            // 
            this.PicStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicStatus.Image = global::DeliveryTakeOrder.Properties.Resources.Unlock_Printer;
            this.PicStatus.Location = new System.Drawing.Point(0, 0);
            this.PicStatus.Name = "PicStatus";
            this.PicStatus.Size = new System.Drawing.Size(42, 36);
            this.PicStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicStatus.TabIndex = 113;
            this.PicStatus.TabStop = false;
            // 
            // Panel6
            // 
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel6.Location = new System.Drawing.Point(5, 103);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(389, 5);
            this.Panel6.TabIndex = 117;
            // 
            // Panel5
            // 
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel5.Location = new System.Drawing.Point(5, 294);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(389, 5);
            this.Panel5.TabIndex = 116;
            // 
            // Panel3
            // 
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel3.Location = new System.Drawing.Point(394, 103);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(5, 196);
            this.Panel3.TabIndex = 115;
            // 
            // Panel2
            // 
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel2.Location = new System.Drawing.Point(0, 103);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(5, 196);
            this.Panel2.TabIndex = 114;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(399, 103);
            this.Panel1.TabIndex = 113;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 101);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(399, 2);
            this.Panel4.TabIndex = 7;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(115, 55);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(272, 43);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PicLogo
            // 
            this.PicLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicLogo.Image = global::DeliveryTakeOrder.Properties.Resources.Logo;
            this.PicLogo.Location = new System.Drawing.Point(12, 4);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(94, 94);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 3;
            this.PicLogo.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(111, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(276, 23);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Q\'s MANAGEMENT SYSTEM";
            // 
            // TimerLoading
            // 
            this.TimerLoading.Interval = 5;
            this.TimerLoading.Tick += new System.EventHandler(this.TimerLoading_Tick);
            // 
            // FrmUnlockPrinterTakeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 299);
            this.Controls.Add(this.Panel7);
            this.Controls.Add(this.Panel6);
            this.Controls.Add(this.Panel5);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUnlockPrinterTakeOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unlock Printer";
            this.Load += new System.EventHandler(this.FrmUnlockPrinterTakeOrder_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmUnlockPrinterTakeOrder_Paint);
            this.Panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicStatus)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.Button BtnUnlockPrinter;
        internal System.Windows.Forms.PictureBox PicStatus;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Timer TimerLoading;
    }
}