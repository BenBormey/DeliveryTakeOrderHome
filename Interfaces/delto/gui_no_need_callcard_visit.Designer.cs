namespace DeliveryTakeOrder.Interfaces.delto
{
    partial class gui_no_need_callcard_visit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gui_no_need_callcard_visit));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salemancode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salemanname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salemannumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Button1 = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.DgvShow);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(544, 312);
            this.Panel1.TabIndex = 1;
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvShow.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.salemancode,
            this.salemanname,
            this.salemannumber,
            this.position,
            this.weekday});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(0, 0);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(544, 218);
            this.DgvShow.TabIndex = 124;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 42;
            // 
            // salemancode
            // 
            this.salemancode.DataPropertyName = "salemancode";
            this.salemancode.HeaderText = "Saleman Code";
            this.salemancode.Name = "salemancode";
            this.salemancode.ReadOnly = true;
            this.salemancode.Width = 97;
            // 
            // salemanname
            // 
            this.salemanname.DataPropertyName = "salemanname";
            this.salemanname.HeaderText = "Saleman Name";
            this.salemanname.Name = "salemanname";
            this.salemanname.ReadOnly = true;
            this.salemanname.Width = 98;
            // 
            // salemannumber
            // 
            this.salemannumber.DataPropertyName = "salemannumber";
            this.salemannumber.HeaderText = "Saleman Number";
            this.salemannumber.Name = "salemannumber";
            this.salemannumber.ReadOnly = true;
            this.salemannumber.Width = 109;
            // 
            // position
            // 
            this.position.DataPropertyName = "position";
            this.position.HeaderText = "Position";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            this.position.Width = 74;
            // 
            // weekday
            // 
            this.weekday.DataPropertyName = "weekday";
            this.weekday.HeaderText = "Week\'s Day";
            this.weekday.Name = "weekday";
            this.weekday.ReadOnly = true;
            this.weekday.Width = 84;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Button1);
            this.Panel2.Controls.Add(this.BtnAdd);
            this.Panel2.Controls.Add(this.Label7);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 218);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(544, 94);
            this.Panel2.TabIndex = 0;
            // 
            // Button1
            // 
            this.Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button1.Image = global::DeliveryTakeOrder.Properties.Resources.Cancel16;
            this.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.Location = new System.Drawing.Point(275, 62);
            this.Button1.Name = "Button1";
            this.Button1.Padding = new System.Windows.Forms.Padding(2);
            this.Button1.Size = new System.Drawing.Size(98, 27);
            this.Button1.TabIndex = 130;
            this.Button1.Text = "&No";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnAdd.Image = global::DeliveryTakeOrder.Properties.Resources.Check_Arrival16;
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.Location = new System.Drawing.Point(171, 62);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Padding = new System.Windows.Forms.Padding(2);
            this.BtnAdd.Size = new System.Drawing.Size(98, 27);
            this.BtnAdd.TabIndex = 129;
            this.BtnAdd.Text = "&Yes";
            this.BtnAdd.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Teal;
            this.Label7.Location = new System.Drawing.Point(0, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(544, 50);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "All salemans in list above, must remove from list.\r\nNo need salemans go to visit!" +
    "\r\nDo you want to remove all salemans as like have in list above ?(Yes/No)";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gui_no_need_callcard_visit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(554, 322);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "gui_no_need_callcard_visit";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No Need Callcard Set";
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn salemancode;
        internal System.Windows.Forms.DataGridViewTextBoxColumn salemanname;
        internal System.Windows.Forms.DataGridViewTextBoxColumn salemannumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn position;
        internal System.Windows.Forms.DataGridViewTextBoxColumn weekday;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button BtnAdd;
        internal System.Windows.Forms.Label Label7;
    }
}