namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDeliveryTakeOrderMessage
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TxtRemark = new System.Windows.Forms.TextBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.PanelPONumber = new System.Windows.Forms.Panel();
            this.TxtPONumber = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.BtnFinish = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.DTPDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.Panel1.SuspendLayout();
            this.PanelPONumber.SuspendLayout();
            this.Panel44.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TxtRemark);
            this.Panel1.Controls.Add(this.Label28);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(5, 109);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(2);
            this.Panel1.Size = new System.Drawing.Size(238, 169);
            this.Panel1.TabIndex = 116;
            // 
            // TxtRemark
            // 
            this.TxtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtRemark.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRemark.Location = new System.Drawing.Point(2, 28);
            this.TxtRemark.Multiline = true;
            this.TxtRemark.Name = "TxtRemark";
            this.TxtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtRemark.Size = new System.Drawing.Size(234, 139);
            this.TxtRemark.TabIndex = 113;
            // 
            // Label28
            // 
            this.Label28.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label28.Location = new System.Drawing.Point(2, 2);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(234, 26);
            this.Label28.TabIndex = 112;
            this.Label28.Text = "Enter the message to alert";
            this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelPONumber
            // 
            this.PanelPONumber.Controls.Add(this.TxtPONumber);
            this.PanelPONumber.Controls.Add(this.Label1);
            this.PanelPONumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelPONumber.Location = new System.Drawing.Point(5, 57);
            this.PanelPONumber.Name = "PanelPONumber";
            this.PanelPONumber.Padding = new System.Windows.Forms.Padding(2);
            this.PanelPONumber.Size = new System.Drawing.Size(238, 52);
            this.PanelPONumber.TabIndex = 117;
            // 
            // TxtPONumber
            // 
            this.TxtPONumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPONumber.Location = new System.Drawing.Point(2, 28);
            this.TxtPONumber.Name = "TxtPONumber";
            this.TxtPONumber.Size = new System.Drawing.Size(234, 20);
            this.TxtPONumber.TabIndex = 113;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(2, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(234, 26);
            this.Label1.TabIndex = 112;
            this.Label1.Text = "P.O Number";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.BtnFinish);
            this.Panel44.Controls.Add(this.BtnClose);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(5, 278);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2);
            this.Panel44.Size = new System.Drawing.Size(238, 35);
            this.Panel44.TabIndex = 115;
            // 
            // BtnFinish
            // 
            this.BtnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFinish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnFinish.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnFinish.Image = global::DeliveryTakeOrder.Properties.Resources.refresh_16;
            this.BtnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFinish.Location = new System.Drawing.Point(3, 2);
            this.BtnFinish.Name = "BtnFinish";
            this.BtnFinish.Size = new System.Drawing.Size(141, 31);
            this.BtnFinish.TabIndex = 10;
            this.BtnFinish.Text = "&Finish Take Order";
            this.BtnFinish.UseVisualStyleBackColor = true;
            this.BtnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(144, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(92, 31);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "&Cancel";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.DTPDeliveryDate);
            this.Panel2.Controls.Add(this.CheckBox1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(5, 5);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(238, 52);
            this.Panel2.TabIndex = 118;
            // 
            // DTPDeliveryDate
            // 
            this.DTPDeliveryDate.CalendarFont = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPDeliveryDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DTPDeliveryDate.CustomFormat = "dd-MMM-yyyy";
            this.DTPDeliveryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTPDeliveryDate.Enabled = false;
            this.DTPDeliveryDate.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPDeliveryDate.Location = new System.Drawing.Point(2, 19);
            this.DTPDeliveryDate.Name = "DTPDeliveryDate";
            this.DTPDeliveryDate.Size = new System.Drawing.Size(234, 28);
            this.DTPDeliveryDate.TabIndex = 114;
            this.DTPDeliveryDate.ValueChanged += new System.EventHandler(this.DTPDeliveryDate_ValueChanged);
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckBox1.ForeColor = System.Drawing.Color.Teal;
            this.CheckBox1.Location = new System.Drawing.Point(2, 2);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(234, 17);
            this.CheckBox1.TabIndex = 113;
            this.CheckBox1.Text = "Delivery Date";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // FrmDeliveryTakeOrderMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 318);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.PanelPONumber);
            this.Controls.Add(this.Panel44);
            this.Controls.Add(this.Panel2);
            this.Name = "FrmDeliveryTakeOrderMessage";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Remark";
            this.Load += new System.EventHandler(this.FrmDeliveryTakeOrderMessage_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.PanelPONumber.ResumeLayout(false);
            this.PanelPONumber.PerformLayout();
            this.Panel44.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox TxtRemark;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.Panel PanelPONumber;
        internal System.Windows.Forms.TextBox TxtPONumber;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button BtnFinish;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.DateTimePicker DTPDeliveryDate;
        internal System.Windows.Forms.CheckBox CheckBox1;
    }
}