namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDutchmillTakeOrderRetrieve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDutchmillTakeOrderRetrieve));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.CmbPONumber = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.Panel44.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.CmbPONumber);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(6, 7);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel1.Size = new System.Drawing.Size(282, 60);
            this.Panel1.TabIndex = 115;
            // 
            // CmbPONumber
            // 
            this.CmbPONumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbPONumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbPONumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPONumber.FormattingEnabled = true;
            this.CmbPONumber.Location = new System.Drawing.Point(0, 30);
            this.CmbPONumber.Name = "CmbPONumber";
            this.CmbPONumber.Size = new System.Drawing.Size(282, 27);
            this.CmbPONumber.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(282, 28);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "P.O Number/Required Date";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.BtnUpdate);
            this.Panel44.Controls.Add(this.BtnCancel);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(6, 66);
            this.Panel44.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel44.Size = new System.Drawing.Size(282, 36);
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
            this.BtnUpdate.Location = new System.Drawing.Point(100, 3);
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
            this.BtnCancel.Location = new System.Drawing.Point(196, 3);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(84, 30);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmDutchmillTakeOrderRetrieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 109);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel44);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDutchmillTakeOrderRetrieve";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retrieve Take Order";
            this.Load += new System.EventHandler(this.FrmDutchmillTakeOrderRetrieve_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel44.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ComboBox CmbPONumber;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button BtnUpdate;
        internal System.Windows.Forms.Button BtnCancel;
    }
}