namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmProcessTakeOrderCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcessTakeOrderCustomer));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.CmbCustomer = new System.Windows.Forms.ComboBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel42 = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.TxtCusName = new System.Windows.Forms.TextBox();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.TxtCusNum = new System.Windows.Forms.TextBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.ChkChangeAll = new System.Windows.Forms.CheckBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TimerCustomerLoading = new System.Windows.Forms.Timer(this.components);
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel42.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.Panel44.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.CmbCustomer);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(6, 61);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Panel1.Size = new System.Drawing.Size(371, 54);
            this.Panel1.TabIndex = 115;
            // 
            // CmbCustomer
            // 
            this.CmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbCustomer.FormattingEnabled = true;
            this.CmbCustomer.Location = new System.Drawing.Point(2, 25);
            this.CmbCustomer.Name = "CmbCustomer";
            this.CmbCustomer.Size = new System.Drawing.Size(367, 21);
            this.CmbCustomer.TabIndex = 2;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(2, 0);
            this.Panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Panel2.Size = new System.Drawing.Size(367, 25);
            this.Panel2.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(0, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(367, 19);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "New Customer";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel42
            // 
            this.Panel42.Controls.Add(this.Panel5);
            this.Panel42.Controls.Add(this.Panel3);
            this.Panel42.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel42.Location = new System.Drawing.Point(6, 7);
            this.Panel42.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel42.Name = "Panel42";
            this.Panel42.Size = new System.Drawing.Size(371, 54);
            this.Panel42.TabIndex = 114;
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.TxtCusName);
            this.Panel5.Controls.Add(this.Panel6);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel5.Location = new System.Drawing.Point(101, 0);
            this.Panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel5.Name = "Panel5";
            this.Panel5.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Panel5.Size = new System.Drawing.Size(270, 54);
            this.Panel5.TabIndex = 114;
            // 
            // TxtCusName
            // 
            this.TxtCusName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCusName.Location = new System.Drawing.Point(2, 25);
            this.TxtCusName.Name = "TxtCusName";
            this.TxtCusName.ReadOnly = true;
            this.TxtCusName.Size = new System.Drawing.Size(266, 20);
            this.TxtCusName.TabIndex = 115;
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.Label3);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel6.Location = new System.Drawing.Point(2, 0);
            this.Panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel6.Name = "Panel6";
            this.Panel6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Panel6.Size = new System.Drawing.Size(266, 25);
            this.Panel6.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label3.Location = new System.Drawing.Point(0, 3);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(266, 19);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Customer Name";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.TxtCusNum);
            this.Panel3.Controls.Add(this.Panel4);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Panel3.Size = new System.Drawing.Size(101, 54);
            this.Panel3.TabIndex = 113;
            // 
            // TxtCusNum
            // 
            this.TxtCusNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCusNum.Location = new System.Drawing.Point(2, 25);
            this.TxtCusNum.Name = "TxtCusNum";
            this.TxtCusNum.ReadOnly = true;
            this.TxtCusNum.Size = new System.Drawing.Size(97, 20);
            this.TxtCusNum.TabIndex = 115;
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.Label2);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(2, 0);
            this.Panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Panel4.Size = new System.Drawing.Size(97, 25);
            this.Panel4.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Location = new System.Drawing.Point(0, 3);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(97, 19);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Customer #";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.ChkChangeAll);
            this.Panel44.Controls.Add(this.BtnUpdate);
            this.Panel44.Controls.Add(this.BtnCancel);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(6, 114);
            this.Panel44.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel44.Size = new System.Drawing.Size(371, 36);
            this.Panel44.TabIndex = 113;
            // 
            // ChkChangeAll
            // 
            this.ChkChangeAll.AutoSize = true;
            this.ChkChangeAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkChangeAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.ChkChangeAll.ForeColor = System.Drawing.Color.Teal;
            this.ChkChangeAll.Location = new System.Drawing.Point(2, 3);
            this.ChkChangeAll.Name = "ChkChangeAll";
            this.ChkChangeAll.Size = new System.Drawing.Size(77, 30);
            this.ChkChangeAll.TabIndex = 12;
            this.ChkChangeAll.Text = "Change All";
            this.ChkChangeAll.UseVisualStyleBackColor = true;
            this.ChkChangeAll.CheckedChanged += new System.EventHandler(this.ChkChangeAll_CheckedChanged);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnUpdate.Image = global::DeliveryTakeOrder.Properties.Resources.refresh_16;
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.Location = new System.Drawing.Point(186, 3);
            this.BtnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(99, 30);
            this.BtnUpdate.TabIndex = 10;
            this.BtnUpdate.Text = "&Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.Image = global::DeliveryTakeOrder.Properties.Resources.Cancel16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(285, 3);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(84, 30);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TimerCustomerLoading
            // 
            this.TimerCustomerLoading.Interval = 5;
            this.TimerCustomerLoading.Tick += new System.EventHandler(this.TimerCustomerLoading_Tick);
            // 
            // FrmProcessTakeOrderCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 157);
            this.ControlBox = false;
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel42);
            this.Controls.Add(this.Panel44);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProcessTakeOrderCustomer";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Customer";
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel42.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            this.Panel6.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel4.ResumeLayout(false);
            this.Panel44.ResumeLayout(false);
            this.Panel44.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ComboBox CmbCustomer;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel42;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.TextBox TxtCusName;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.TextBox TxtCusNum;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.CheckBox ChkChangeAll;
        internal System.Windows.Forms.Button BtnUpdate;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Timer TimerCustomerLoading;
    }
}