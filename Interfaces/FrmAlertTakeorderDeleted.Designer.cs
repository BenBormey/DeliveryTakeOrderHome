namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmAlertTakeorderDeleted
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlertTakeorderDeleted));
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblcountrow = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Loading = new System.Windows.Forms.Timer(this.components);
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.lblcountrow);
            this.Panel2.Controls.Add(this.BtnOK);
            this.Panel2.Controls.Add(this.BtnCancel);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 525);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(984, 36);
            this.Panel2.TabIndex = 116;
            // 
            // lblcountrow
            // 
            this.lblcountrow.AutoSize = true;
            this.lblcountrow.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblcountrow.Location = new System.Drawing.Point(2, 2);
            this.lblcountrow.Name = "lblcountrow";
            this.lblcountrow.Size = new System.Drawing.Size(76, 19);
            this.lblcountrow.TabIndex = 115;
            this.lblcountrow.Text = "Count Row : 0";
            this.lblcountrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(691, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(164, 32);
            this.BtnOK.TabIndex = 113;
            this.BtnOK.Text = "&Accept Deletion";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(855, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(127, 32);
            this.BtnCancel.TabIndex = 114;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // Loading
            // 
            this.Loading.Interval = 5;
            this.Loading.Tick += new System.EventHandler(this.Loading_Tick);
            // 
            // FrmAlertTakeorderDeleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.Panel2);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAlertTakeorderDeleted";
            this.Text = "T.O Deletion";
            this.Load += new System.EventHandler(this.FrmAlertTakeorderDeleted_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblcountrow;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Timer Loading;
    }
}