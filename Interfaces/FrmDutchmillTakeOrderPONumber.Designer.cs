namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDutchmillTakeOrderPONumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDutchmillTakeOrderPONumber));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.DTPRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.TxtOrderDate = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.PanelPO = new System.Windows.Forms.Panel();
            this.TxtPONo = new System.Windows.Forms.TextBox();
            this.PicRefreshPO = new System.Windows.Forms.PictureBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.PanelPO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicRefreshPO)).BeginInit();
            this.Panel44.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.DTPRequiredDate);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(6, 71);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel1.Size = new System.Drawing.Size(292, 32);
            this.Panel1.TabIndex = 117;
            // 
            // DTPRequiredDate
            // 
            this.DTPRequiredDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DTPRequiredDate.CustomFormat = "dd-MMM-yyyy";
            this.DTPRequiredDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTPRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPRequiredDate.Location = new System.Drawing.Point(100, 2);
            this.DTPRequiredDate.Name = "DTPRequiredDate";
            this.DTPRequiredDate.Size = new System.Drawing.Size(192, 28);
            this.DTPRequiredDate.TabIndex = 5;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label1.Location = new System.Drawing.Point(0, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 28);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Required Date";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.TxtOrderDate);
            this.Panel3.Controls.Add(this.Label3);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(6, 39);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel3.Size = new System.Drawing.Size(292, 32);
            this.Panel3.TabIndex = 116;
            // 
            // TxtOrderDate
            // 
            this.TxtOrderDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtOrderDate.Location = new System.Drawing.Point(100, 2);
            this.TxtOrderDate.Name = "TxtOrderDate";
            this.TxtOrderDate.ReadOnly = true;
            this.TxtOrderDate.Size = new System.Drawing.Size(192, 28);
            this.TxtOrderDate.TabIndex = 3;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.Location = new System.Drawing.Point(0, 2);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(100, 28);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Order Date";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PanelPO
            // 
            this.PanelPO.Controls.Add(this.TxtPONo);
            this.PanelPO.Controls.Add(this.PicRefreshPO);
            this.PanelPO.Controls.Add(this.Label7);
            this.PanelPO.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelPO.Location = new System.Drawing.Point(6, 7);
            this.PanelPO.Name = "PanelPO";
            this.PanelPO.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.PanelPO.Size = new System.Drawing.Size(292, 32);
            this.PanelPO.TabIndex = 115;
            // 
            // TxtPONo
            // 
            this.TxtPONo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPONo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPONo.Location = new System.Drawing.Point(100, 2);
            this.TxtPONo.Name = "TxtPONo";
            this.TxtPONo.ReadOnly = true;
            this.TxtPONo.Size = new System.Drawing.Size(172, 28);
            this.TxtPONo.TabIndex = 1;
            // 
            // PicRefreshPO
            // 
            this.PicRefreshPO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicRefreshPO.Dock = System.Windows.Forms.DockStyle.Right;
            this.PicRefreshPO.Image = global::DeliveryTakeOrder.Properties.Resources.refresh_16;
            this.PicRefreshPO.Location = new System.Drawing.Point(272, 2);
            this.PicRefreshPO.Name = "PicRefreshPO";
            this.PicRefreshPO.Size = new System.Drawing.Size(20, 28);
            this.PicRefreshPO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicRefreshPO.TabIndex = 4;
            this.PicRefreshPO.TabStop = false;
            this.PicRefreshPO.Visible = false;
            this.PicRefreshPO.Click += new System.EventHandler(this.PicRefreshPO_Click);
            // 
            // Label7
            // 
            this.Label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label7.Location = new System.Drawing.Point(0, 2);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(100, 28);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "P.O #";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.BtnUpdate);
            this.Panel44.Controls.Add(this.BtnCancel);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(6, 115);
            this.Panel44.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel44.Size = new System.Drawing.Size(292, 36);
            this.Panel44.TabIndex = 114;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnUpdate.Image = global::DeliveryTakeOrder.Properties.Resources.renew;
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.Location = new System.Drawing.Point(110, 3);
            this.BtnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(96, 30);
            this.BtnUpdate.TabIndex = 10;
            this.BtnUpdate.Text = "&Go Ahead";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(206, 3);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(84, 30);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmDutchmillTakeOrderPONumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 158);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.PanelPO);
            this.Controls.Add(this.Panel44);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDutchmillTakeOrderPONumber";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Required Date";
            this.Load += new System.EventHandler(this.FrmDutchmillTakeOrderPONumber_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.PanelPO.ResumeLayout(false);
            this.PanelPO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicRefreshPO)).EndInit();
            this.Panel44.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DateTimePicker DTPRequiredDate;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.TextBox TxtOrderDate;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel PanelPO;
        internal System.Windows.Forms.TextBox TxtPONo;
        internal System.Windows.Forms.PictureBox PicRefreshPO;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button BtnUpdate;
        internal System.Windows.Forms.Button BtnCancel;
    }
}