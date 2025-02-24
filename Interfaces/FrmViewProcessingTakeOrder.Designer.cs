namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmViewProcessingTakeOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewProcessingTakeOrder));
            this.Panel10 = new System.Windows.Forms.Panel();
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOrd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProNumy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProPackSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProQtyPCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PcsFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PcsOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTNOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPcsOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogInName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeOrderInvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintInvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromotionMachanic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemarkExpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saleman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.CmbDate = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel18 = new System.Windows.Forms.Panel();
            this.CmbDelto = new System.Windows.Forms.ComboBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.CmbCustomer = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.cmbDistributor = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.CustomerLoading = new System.Windows.Forms.Timer(this.components);
            this.DateLoading = new System.Windows.Forms.Timer(this.components);
            this.displayloading = new System.Windows.Forms.Timer(this.components);
            this.DeltoLoading = new System.Windows.Forms.Timer(this.components);
            this.distributorLoading = new System.Windows.Forms.Timer(this.components);
            this.Panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel7.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel9.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel18.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDistributor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel10
            // 
            this.Panel10.Controls.Add(this.DgvShow);
            this.Panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel10.Location = new System.Drawing.Point(6, 145);
            this.Panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel10.Name = "Panel10";
            this.Panel10.Size = new System.Drawing.Size(872, 375);
            this.Panel10.TabIndex = 119;
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CusName,
            this.CusNum,
            this.DelTo,
            this.DateOrd,
            this.DateRequired,
            this.DeliveryDate,
            this.ProNumy,
            this.ProName,
            this.ProPackSize,
            this.ProQtyPCase,
            this.PcsFree,
            this.PcsOrder,
            this.CTNOrder,
            this.TotalPcsOrder,
            this.PONumber,
            this.LogInName,
            this.TakeOrderInvoiceNumber,
            this.PrintInvoiceNumber,
            this.PromotionMachanic,
            this.ProCat,
            this.ItemDiscount,
            this.RemarkExpiry,
            this.RelatedKey,
            this.Saleman,
            this.Status});
            this.DgvShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(0, 0);
            this.DgvShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(872, 375);
            this.DgvShow.TabIndex = 114;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CusName
            // 
            this.CusName.DataPropertyName = "CusName";
            this.CusName.HeaderText = "Customer Name";
            this.CusName.Name = "CusName";
            this.CusName.ReadOnly = true;
            // 
            // CusNum
            // 
            this.CusNum.DataPropertyName = "CusNum";
            this.CusNum.HeaderText = "CusNum";
            this.CusNum.Name = "CusNum";
            this.CusNum.ReadOnly = true;
            this.CusNum.Visible = false;
            // 
            // DelTo
            // 
            this.DelTo.DataPropertyName = "DelTo";
            this.DelTo.HeaderText = "DelTo";
            this.DelTo.Name = "DelTo";
            this.DelTo.ReadOnly = true;
            // 
            // DateOrd
            // 
            this.DateOrd.DataPropertyName = "DateOrd";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.DateOrd.DefaultCellStyle = dataGridViewCellStyle1;
            this.DateOrd.HeaderText = "Ord. Date";
            this.DateOrd.Name = "DateOrd";
            this.DateOrd.ReadOnly = true;
            // 
            // DateRequired
            // 
            this.DateRequired.DataPropertyName = "DateRequired";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.DateRequired.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateRequired.HeaderText = "Required Date";
            this.DateRequired.Name = "DateRequired";
            this.DateRequired.ReadOnly = true;
            // 
            // DeliveryDate
            // 
            this.DeliveryDate.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.DeliveryDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.DeliveryDate.HeaderText = "Delivery Date";
            this.DeliveryDate.Name = "DeliveryDate";
            this.DeliveryDate.ReadOnly = true;
            // 
            // ProNumy
            // 
            this.ProNumy.DataPropertyName = "ProNumy";
            this.ProNumy.HeaderText = "Barcode";
            this.ProNumy.Name = "ProNumy";
            this.ProNumy.ReadOnly = true;
            // 
            // ProName
            // 
            this.ProName.DataPropertyName = "ProName";
            this.ProName.HeaderText = "Product Name";
            this.ProName.Name = "ProName";
            this.ProName.ReadOnly = true;
            // 
            // ProPackSize
            // 
            this.ProPackSize.DataPropertyName = "ProPackSize";
            this.ProPackSize.HeaderText = "Size";
            this.ProPackSize.Name = "ProPackSize";
            this.ProPackSize.ReadOnly = true;
            // 
            // ProQtyPCase
            // 
            this.ProQtyPCase.DataPropertyName = "ProQtyPCase";
            this.ProQtyPCase.HeaderText = "Q/C";
            this.ProQtyPCase.Name = "ProQtyPCase";
            this.ProQtyPCase.ReadOnly = true;
            // 
            // PcsFree
            // 
            this.PcsFree.DataPropertyName = "PcsFree";
            this.PcsFree.HeaderText = "Pcs Free";
            this.PcsFree.Name = "PcsFree";
            this.PcsFree.ReadOnly = true;
            // 
            // PcsOrder
            // 
            this.PcsOrder.DataPropertyName = "PcsOrder";
            this.PcsOrder.HeaderText = "Pcs Order";
            this.PcsOrder.Name = "PcsOrder";
            this.PcsOrder.ReadOnly = true;
            // 
            // CTNOrder
            // 
            this.CTNOrder.DataPropertyName = "CTNOrder";
            this.CTNOrder.HeaderText = "CTN Order";
            this.CTNOrder.Name = "CTNOrder";
            this.CTNOrder.ReadOnly = true;
            // 
            // TotalPcsOrder
            // 
            this.TotalPcsOrder.DataPropertyName = "TotalPcsOrder";
            this.TotalPcsOrder.HeaderText = "Total Pcs Order";
            this.TotalPcsOrder.Name = "TotalPcsOrder";
            this.TotalPcsOrder.ReadOnly = true;
            // 
            // PONumber
            // 
            this.PONumber.DataPropertyName = "PONumber";
            this.PONumber.HeaderText = "PO Number";
            this.PONumber.Name = "PONumber";
            this.PONumber.ReadOnly = true;
            // 
            // LogInName
            // 
            this.LogInName.DataPropertyName = "LogInName";
            this.LogInName.HeaderText = "LogInName";
            this.LogInName.Name = "LogInName";
            this.LogInName.ReadOnly = true;
            this.LogInName.Visible = false;
            // 
            // TakeOrderInvoiceNumber
            // 
            this.TakeOrderInvoiceNumber.DataPropertyName = "TakeOrderInvoiceNumber";
            this.TakeOrderInvoiceNumber.HeaderText = "T.O Number";
            this.TakeOrderInvoiceNumber.Name = "TakeOrderInvoiceNumber";
            this.TakeOrderInvoiceNumber.ReadOnly = true;
            // 
            // PrintInvoiceNumber
            // 
            this.PrintInvoiceNumber.DataPropertyName = "PrintInvoiceNumber";
            this.PrintInvoiceNumber.HeaderText = "Picking Number";
            this.PrintInvoiceNumber.Name = "PrintInvoiceNumber";
            this.PrintInvoiceNumber.ReadOnly = true;
            // 
            // PromotionMachanic
            // 
            this.PromotionMachanic.DataPropertyName = "PromotionMachanic";
            this.PromotionMachanic.HeaderText = "PromotionMachanic";
            this.PromotionMachanic.Name = "PromotionMachanic";
            this.PromotionMachanic.ReadOnly = true;
            this.PromotionMachanic.Visible = false;
            // 
            // ProCat
            // 
            this.ProCat.DataPropertyName = "ProCat";
            this.ProCat.HeaderText = "ProCat";
            this.ProCat.Name = "ProCat";
            this.ProCat.ReadOnly = true;
            this.ProCat.Visible = false;
            // 
            // ItemDiscount
            // 
            this.ItemDiscount.DataPropertyName = "ItemDiscount";
            this.ItemDiscount.HeaderText = "ItemDiscount";
            this.ItemDiscount.Name = "ItemDiscount";
            this.ItemDiscount.ReadOnly = true;
            this.ItemDiscount.Visible = false;
            // 
            // RemarkExpiry
            // 
            this.RemarkExpiry.DataPropertyName = "RemarkExpiry";
            this.RemarkExpiry.HeaderText = "RemarkExpiry";
            this.RemarkExpiry.Name = "RemarkExpiry";
            this.RemarkExpiry.ReadOnly = true;
            this.RemarkExpiry.Visible = false;
            // 
            // RelatedKey
            // 
            this.RelatedKey.DataPropertyName = "RelatedKey";
            this.RelatedKey.HeaderText = "RelatedKey";
            this.RelatedKey.Name = "RelatedKey";
            this.RelatedKey.ReadOnly = true;
            this.RelatedKey.Visible = false;
            // 
            // Saleman
            // 
            this.Saleman.DataPropertyName = "Saleman";
            this.Saleman.HeaderText = "Saleman";
            this.Saleman.Name = "Saleman";
            this.Saleman.ReadOnly = true;
            this.Saleman.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Panel7
            // 
            this.Panel7.Controls.Add(this.Panel5);
            this.Panel7.Controls.Add(this.Panel9);
            this.Panel7.Controls.Add(this.LblCountRow);
            this.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel7.Location = new System.Drawing.Point(6, 520);
            this.Panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel7.Name = "Panel7";
            this.Panel7.Size = new System.Drawing.Size(872, 34);
            this.Panel7.TabIndex = 118;
            // 
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Panel5.Controls.Add(this.txtbarcode);
            this.Panel5.Controls.Add(this.BtnSearch);
            this.Panel5.Controls.Add(this.Label3);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel5.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel5.Location = new System.Drawing.Point(84, 0);
            this.Panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel5.Name = "Panel5";
            this.Panel5.Padding = new System.Windows.Forms.Padding(2);
            this.Panel5.Size = new System.Drawing.Size(396, 34);
            this.Panel5.TabIndex = 114;
            // 
            // txtbarcode
            // 
            this.txtbarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbarcode.Location = new System.Drawing.Point(132, 2);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(160, 28);
            this.txtbarcode.TabIndex = 113;
            this.txtbarcode.TextChanged += new System.EventHandler(this.txtbarcode_TextChanged);
            this.txtbarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarcode_KeyPress);
            this.txtbarcode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbarcode_PreviewKeyDown);
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnSearch.Image = global::DeliveryTakeOrder.Properties.Resources.view_takeorder;
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.Location = new System.Drawing.Point(292, 2);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(102, 30);
            this.BtnSearch.TabIndex = 112;
            this.BtnSearch.Text = "&Search";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.ForeColor = System.Drawing.Color.Teal;
            this.Label3.Location = new System.Drawing.Point(2, 2);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(130, 30);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Search By Barcode";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel9
            // 
            this.Panel9.Controls.Add(this.BtnExportToExcel);
            this.Panel9.Controls.Add(this.BtnClose);
            this.Panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel9.Location = new System.Drawing.Point(588, 0);
            this.Panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel9.Name = "Panel9";
            this.Panel9.Padding = new System.Windows.Forms.Padding(2);
            this.Panel9.Size = new System.Drawing.Size(284, 34);
            this.Panel9.TabIndex = 0;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.BackColor = System.Drawing.SystemColors.Control;
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExportToExcel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(2, 2);
            this.BtnExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(178, 30);
            this.BtnExportToExcel.TabIndex = 110;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = false;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.SystemColors.Control;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.Cancel16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(180, 2);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(102, 30);
            this.BtnClose.TabIndex = 111;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblCountRow
            // 
            this.LblCountRow.AutoSize = true;
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblCountRow.Location = new System.Drawing.Point(0, 0);
            this.LblCountRow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.LblCountRow.Size = new System.Drawing.Size(84, 26);
            this.LblCountRow.TabIndex = 113;
            this.LblCountRow.Text = "Count Row : 0";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.label4);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(6, 7);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(872, 138);
            this.Panel1.TabIndex = 117;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(128, 57);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(277, 63);
            this.LblCompanyName.TabIndex = 11;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Panel3);
            this.Panel2.Controls.Add(this.Panel18);
            this.Panel2.Controls.Add(this.Panel8);
            this.Panel2.Controls.Add(this.Panel6);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel2.Location = new System.Drawing.Point(457, 0);
            this.Panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(415, 135);
            this.Panel2.TabIndex = 10;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.CmbDate);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel3.Location = new System.Drawing.Point(0, 86);
            this.Panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(2);
            this.Panel3.Size = new System.Drawing.Size(415, 30);
            this.Panel3.TabIndex = 1;
            // 
            // CmbDate
            // 
            this.CmbDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDate.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
            this.CmbDate.FormattingEnabled = true;
            this.CmbDate.Location = new System.Drawing.Point(99, 2);
            this.CmbDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CmbDate.Name = "CmbDate";
            this.CmbDate.Size = new System.Drawing.Size(314, 25);
            this.CmbDate.TabIndex = 1;
            this.CmbDate.SelectedIndexChanged += new System.EventHandler(this.CmbInvoiceNumber_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(2, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(97, 26);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Required Date";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel18
            // 
            this.Panel18.Controls.Add(this.CmbDelto);
            this.Panel18.Controls.Add(this.Label14);
            this.Panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel18.Location = new System.Drawing.Point(0, 57);
            this.Panel18.Name = "Panel18";
            this.Panel18.Padding = new System.Windows.Forms.Padding(2);
            this.Panel18.Size = new System.Drawing.Size(415, 29);
            this.Panel18.TabIndex = 119;
            // 
            // CmbDelto
            // 
            this.CmbDelto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbDelto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbDelto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDelto.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
            this.CmbDelto.FormattingEnabled = true;
            this.CmbDelto.Location = new System.Drawing.Point(99, 2);
            this.CmbDelto.Name = "CmbDelto";
            this.CmbDelto.Size = new System.Drawing.Size(314, 25);
            this.CmbDelto.TabIndex = 2;
            this.CmbDelto.SelectedIndexChanged += new System.EventHandler(this.CmbDelto_SelectedIndexChanged);
            // 
            // Label14
            // 
            this.Label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label14.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
            this.Label14.Location = new System.Drawing.Point(2, 2);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(97, 25);
            this.Label14.TabIndex = 0;
            this.Label14.Text = "Delto";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel8
            // 
            this.Panel8.BackColor = System.Drawing.Color.Transparent;
            this.Panel8.Controls.Add(this.CmbCustomer);
            this.Panel8.Controls.Add(this.Label11);
            this.Panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel8.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel8.Location = new System.Drawing.Point(0, 28);
            this.Panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel8.Name = "Panel8";
            this.Panel8.Padding = new System.Windows.Forms.Padding(2);
            this.Panel8.Size = new System.Drawing.Size(415, 29);
            this.Panel8.TabIndex = 0;
            // 
            // CmbCustomer
            // 
            this.CmbCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCustomer.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
            this.CmbCustomer.FormattingEnabled = true;
            this.CmbCustomer.Location = new System.Drawing.Point(99, 2);
            this.CmbCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CmbCustomer.Name = "CmbCustomer";
            this.CmbCustomer.Size = new System.Drawing.Size(314, 25);
            this.CmbCustomer.TabIndex = 1;
            this.CmbCustomer.SelectedIndexChanged += new System.EventHandler(this.CmbCustomer_SelectedIndexChanged);
            // 
            // Label11
            // 
            this.Label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label11.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(2, 2);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(97, 25);
            this.Label11.TabIndex = 0;
            this.Label11.Text = "Customer";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel6
            // 
            this.Panel6.BackColor = System.Drawing.Color.Transparent;
            this.Panel6.Controls.Add(this.cmbDistributor);
            this.Panel6.Controls.Add(this.label1);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel6.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel6.Location = new System.Drawing.Point(0, 0);
            this.Panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel6.Name = "Panel6";
            this.Panel6.Padding = new System.Windows.Forms.Padding(2);
            this.Panel6.Size = new System.Drawing.Size(415, 28);
            this.Panel6.TabIndex = 120;
            // 
            // cmbDistributor
            // 
            this.cmbDistributor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDistributor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDistributor.Location = new System.Drawing.Point(99, 2);
            this.cmbDistributor.Name = "cmbDistributor";
            this.cmbDistributor.Properties.AllowMultiSelect = true;
            this.cmbDistributor.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
            this.cmbDistributor.Properties.Appearance.Options.UseFont = true;
            this.cmbDistributor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDistributor.Properties.DropDownRows = 15;
            this.cmbDistributor.Properties.IncrementalSearch = true;
            this.cmbDistributor.Size = new System.Drawing.Size(314, 24);
            this.cmbDistributor.TabIndex = 143;
            this.cmbDistributor.ToolTip = "Please select any supplier which you want to preview";
            this.cmbDistributor.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cmbDistributor_Closed);
            this.cmbDistributor.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.cmbDistributor_CustomDisplayText);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distributor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(116, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Q\'s MANAGEMENT SYSTEM";
            // 
            // PicLogo
            // 
            this.PicLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicLogo.Image = global::DeliveryTakeOrder.Properties.Resources.Logo;
            this.PicLogo.Location = new System.Drawing.Point(0, 0);
            this.PicLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(110, 135);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 3;
            this.PicLogo.TabStop = false;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 135);
            this.Panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(872, 3);
            this.Panel4.TabIndex = 7;
            // 
            // CustomerLoading
            // 
            this.CustomerLoading.Interval = 5;
            this.CustomerLoading.Tick += new System.EventHandler(this.CustomerLoading_Tick);
            // 
            // DateLoading
            // 
            this.DateLoading.Interval = 5;
            this.DateLoading.Tick += new System.EventHandler(this.DateLoading_Tick);
            // 
            // displayloading
            // 
            this.displayloading.Interval = 5;
            this.displayloading.Tick += new System.EventHandler(this.displayloading_Tick);
            // 
            // DeltoLoading
            // 
            this.DeltoLoading.Interval = 5;
            this.DeltoLoading.Tick += new System.EventHandler(this.DeltoLoading_Tick);
            // 
            // distributorLoading
            // 
            this.distributorLoading.Interval = 5;
            this.distributorLoading.Tick += new System.EventHandler(this.distributorLoading_Tick);
            // 
            // FrmViewProcessingTakeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.Panel10);
            this.Controls.Add(this.Panel7);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmViewProcessingTakeOrder";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Processing Take Order";
            this.Activated += new System.EventHandler(this.FrmViewProcessingTakeOrder_Activated);
            this.Load += new System.EventHandler(this.FrmViewProcessingTakeOrder_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmViewProcessingTakeOrder_Paint);
            this.Panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel7.ResumeLayout(false);
            this.Panel7.PerformLayout();
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            this.Panel9.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel18.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbDistributor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel10;
        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ID;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DelTo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DateOrd;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DateRequired;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DeliveryDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProNumy;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProPackSize;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProQtyPCase;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PcsFree;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PcsOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CTNOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TotalPcsOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PONumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn LogInName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TakeOrderInvoiceNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PrintInvoiceNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PromotionMachanic;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProCat;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ItemDiscount;
        internal System.Windows.Forms.DataGridViewTextBoxColumn RemarkExpiry;
        internal System.Windows.Forms.DataGridViewTextBoxColumn RelatedKey;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Saleman;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Status;
        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.TextBox txtbarcode;
        internal System.Windows.Forms.Button BtnSearch;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel9;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Timer CustomerLoading;
        internal System.Windows.Forms.Timer DateLoading;
        internal System.Windows.Forms.Timer displayloading;
        internal System.Windows.Forms.Timer DeltoLoading;
        internal System.Windows.Forms.Timer distributorLoading;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.ComboBox CmbDate;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel18;
        internal System.Windows.Forms.ComboBox CmbDelto;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Panel Panel8;
        internal System.Windows.Forms.ComboBox CmbCustomer;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Panel Panel6;
        internal DevExpress.XtraEditors.CheckedComboBoxEdit cmbDistributor;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label LblCompanyName;
    }
}