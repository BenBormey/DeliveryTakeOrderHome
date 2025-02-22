
namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmAlertCustomerHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.InvNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Division = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.Loading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvShow.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvNumber,
            this.ShipDate,
            this.CusNum,
            this.CusCom,
            this.Division});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(5, 5);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(583, 214);
            this.DgvShow.TabIndex = 114;
            // 
            // InvNumber
            // 
            this.InvNumber.DataPropertyName = "InvNumber";
            this.InvNumber.HeaderText = "Invoice #";
            this.InvNumber.Name = "InvNumber";
            this.InvNumber.ReadOnly = true;
            this.InvNumber.Width = 72;
            // 
            // ShipDate
            // 
            this.ShipDate.DataPropertyName = "ShipDate";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.ShipDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShipDate.HeaderText = "Ship Date";
            this.ShipDate.Name = "ShipDate";
            this.ShipDate.ReadOnly = true;
            this.ShipDate.Width = 72;
            // 
            // CusNum
            // 
            this.CusNum.DataPropertyName = "CusNum";
            this.CusNum.HeaderText = "Customer #";
            this.CusNum.Name = "CusNum";
            this.CusNum.ReadOnly = true;
            this.CusNum.Width = 82;
            // 
            // CusCom
            // 
            this.CusCom.DataPropertyName = "CusCom";
            this.CusCom.HeaderText = "Customer Name";
            this.CusCom.Name = "CusCom";
            this.CusCom.ReadOnly = true;
            this.CusCom.Width = 99;
            // 
            // Division
            // 
            this.Division.DataPropertyName = "Division";
            this.Division.HeaderText = "Division";
            this.Division.Name = "Division";
            this.Division.ReadOnly = true;
            this.Division.Width = 68;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnOK);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(5, 219);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(200, 2, 200, 2);
            this.Panel2.Size = new System.Drawing.Size(583, 36);
            this.Panel2.TabIndex = 115;
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOK.Location = new System.Drawing.Point(200, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(183, 32);
            this.BtnOK.TabIndex = 113;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // Loading
            // 
            this.Loading.Interval = 5;
            this.Loading.Tick += new System.EventHandler(this.Loading_Tick);
            // 
            // FrmAlertCustomerHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 260);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel2);
            this.Name = "FrmAlertCustomerHistory";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "History Customer Delivery";
            this.Load += new System.EventHandler(this.FrmAlertCustomerHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn InvNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ShipDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusCom;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Division;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.Timer Loading;
    }
}