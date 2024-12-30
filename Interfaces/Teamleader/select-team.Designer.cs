using System.Windows.Forms;

namespace DeliveryTakeOrder.Interfaces.Teamleader
{
    partial class SelectTeamForm
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
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbWarehouseName = new System.Windows.Forms.ComboBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbTeam = new System.Windows.Forms.ComboBox();
            this.panLine = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.warehouseNameLoading = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.teamLoading = new System.Windows.Forms.Timer(this.components);
            this.btnSelect = new System.Windows.Forms.Button();
            this.picWarehouseName = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(26, 227);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(112, 13);
            this.Label2.TabIndex = 21;
            this.Label2.Text = "Warehouse Name:";
            // 
            // cmbWarehouseName
            // 
            this.cmbWarehouseName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWarehouseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouseName.FormattingEnabled = true;
            this.cmbWarehouseName.Location = new System.Drawing.Point(26, 245);
            this.cmbWarehouseName.Name = "cmbWarehouseName";
            this.cmbWarehouseName.Size = new System.Drawing.Size(621, 21);
            this.cmbWarehouseName.TabIndex = 20;
            this.cmbWarehouseName.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouseName_SelectedIndexChanged);
            // 
            // Button2
            // 
            this.Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.ForeColor = System.Drawing.Color.Teal;
            this.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button2.Location = new System.Drawing.Point(537, 314);
            this.Button2.Name = "Button2";
            this.Button2.Padding = new System.Windows.Forms.Padding(2);
            this.Button2.Size = new System.Drawing.Size(110, 34);
            this.Button2.TabIndex = 19;
            this.Button2.Text = "Cancel";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(26, 269);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(82, 13);
            this.Label1.TabIndex = 17;
            this.Label1.Text = "Select Team:";
            // 
            // cmbTeam
            // 
            this.cmbTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeam.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTeam.FormattingEnabled = true;
            this.cmbTeam.Location = new System.Drawing.Point(26, 287);
            this.cmbTeam.Name = "cmbTeam";
            this.cmbTeam.Size = new System.Drawing.Size(621, 21);
            this.cmbTeam.TabIndex = 16;
            // 
            // panLine
            // 
            this.panLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panLine.BackColor = System.Drawing.SystemColors.Highlight;
            this.panLine.Location = new System.Drawing.Point(0, 80);
            this.panLine.Name = "panLine";
            this.panLine.Size = new System.Drawing.Size(674, 2);
            this.panLine.TabIndex = 15;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(78, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 21);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Welcome";
            // 
            // btnSelect
            // 
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.Teal;
            this.btnSelect.Image = global::DeliveryTakeOrder.Properties.Resources.Check_Arrival16;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(382, 314);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(2);
            this.btnSelect.Size = new System.Drawing.Size(149, 34);
            this.btnSelect.TabIndex = 24;
            this.btnSelect.Text = "&Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // picWarehouseName
            // 
            this.picWarehouseName.Location = new System.Drawing.Point(29, 88);
            this.picWarehouseName.Name = "picWarehouseName";
            this.picWarehouseName.Size = new System.Drawing.Size(618, 136);
            this.picWarehouseName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWarehouseName.TabIndex = 22;
            this.picWarehouseName.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::DeliveryTakeOrder.Properties.Resources.Logo;
            this.PictureBox1.Location = new System.Drawing.Point(0, 10);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(72, 72);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 13;
            this.PictureBox1.TabStop = false;
            // 
            // SelectTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 358);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.picWarehouseName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbWarehouseName);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbTeam);
            this.Controls.Add(this.panLine);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.PictureBox1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.Name = "SelectTeamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "select_team";
            this.Load += new System.EventHandler(this.SelectTeamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picWarehouseName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbWarehouseName;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbTeam;
        internal System.Windows.Forms.Panel panLine;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private Timer warehouseNameLoading;
        private Timer timer2;
        private Timer teamLoading;
        internal Button btnSelect;
    }
}