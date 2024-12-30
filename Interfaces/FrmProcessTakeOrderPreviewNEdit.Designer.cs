namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmProcessTakeOrderPreviewNEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcessTakeOrderPreviewNEdit));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.DisplayLoading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel44.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DgvShow.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvShow.ColumnHeadersHeight = 150;
            this.DgvShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(6, 7);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(772, 511);
            this.DgvShow.TabIndex = 114;
            this.DgvShow.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvShow_CellEndEdit);
            this.DgvShow.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvShow_CellEnter);
            this.DgvShow.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DgvShow_CellPainting);
            this.DgvShow.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvShow_RowPostPaint);
            this.DgvShow.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvShow_Paint);
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.LblCountRow);
            this.Panel44.Controls.Add(this.BtnClose);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(6, 518);
            this.Panel44.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel44.Size = new System.Drawing.Size(772, 36);
            this.Panel44.TabIndex = 113;
            // 
            // LblCountRow
            // 
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblCountRow.Location = new System.Drawing.Point(2, 3);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Size = new System.Drawing.Size(147, 30);
            this.LblCountRow.TabIndex = 12;
            this.LblCountRow.Text = "Count Row : 0";
            this.LblCountRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.Cancel16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(678, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(92, 30);
            this.BtnClose.TabIndex = 10;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // DisplayLoading
            // 
            this.DisplayLoading.Interval = 5;
            this.DisplayLoading.Tick += new System.EventHandler(this.DisplayLoading_Tick);
            // 
            // FrmProcessTakeOrderPreviewNEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel44);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmProcessTakeOrderPreviewNEdit";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview & Edit Take Order";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmProcessTakeOrderPreviewNEdit_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel44.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Timer DisplayLoading;
    }
}