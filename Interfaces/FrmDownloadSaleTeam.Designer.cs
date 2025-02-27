
namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmDownloadSaleTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDownloadSaleTeam));
            this.DgvShow = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelToId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOrd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PcsFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PcsOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTNOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPcsOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogInName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromotionMachanic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saleman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnDownloadTakeOrder = new System.Windows.Forms.Button();
            this.CmbTakeOrderNo = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.CmbCustomer = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TimerCustomerLoading = new System.Windows.Forms.Timer(this.components);
            this.TimerTakeOrderLoading = new System.Windows.Forms.Timer(this.components);
            this.TimerDisplayLoading = new System.Windows.Forms.Timer(this.components);
            this.Popmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuModifyTakeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuChangeCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuChangeDelto = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuChangeQtyOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuDeleteTakeOrder = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel44.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.Popmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvShow.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TakeOrderNumber,
            this.PONumber,
            this.CusNum,
            this.CusName,
            this.DelToId,
            this.DelTo,
            this.DateOrd,
            this.DateRequired,
            this.UnitNumber,
            this.Barcode,
            this.ProName,
            this.Size,
            this.QtyPCase,
            this.QtyPPack,
            this.Category,
            this.PcsFree,
            this.PcsOrder,
            this.PackOrder,
            this.CTNOrder,
            this.TotalPcsOrder,
            this.LogInName,
            this.PromotionMachanic,
            this.ItemDiscount,
            this.Remark,
            this.Saleman,
            this.CreatedDate});
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(5, 108);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(812, 352);
            this.DgvShow.TabIndex = 114;
            this.DgvShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvShow_CellContentClick);
            this.DgvShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvShow_MouseDown);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 41;
            // 
            // TakeOrderNumber
            // 
            this.TakeOrderNumber.DataPropertyName = "TakeOrderNumber";
            this.TakeOrderNumber.HeaderText = "TakeOrderNumber";
            this.TakeOrderNumber.Name = "TakeOrderNumber";
            this.TakeOrderNumber.ReadOnly = true;
            this.TakeOrderNumber.Width = 135;
            // 
            // PONumber
            // 
            this.PONumber.DataPropertyName = "PONumber";
            this.PONumber.HeaderText = "PONumber";
            this.PONumber.Name = "PONumber";
            this.PONumber.ReadOnly = true;
            this.PONumber.Width = 92;
            // 
            // CusNum
            // 
            this.CusNum.DataPropertyName = "CusNum";
            this.CusNum.HeaderText = "CusNum";
            this.CusNum.Name = "CusNum";
            this.CusNum.ReadOnly = true;
            this.CusNum.Width = 79;
            // 
            // CusName
            // 
            this.CusName.DataPropertyName = "CusName";
            this.CusName.HeaderText = "CusName";
            this.CusName.Name = "CusName";
            this.CusName.ReadOnly = true;
            this.CusName.Width = 86;
            // 
            // DelToId
            // 
            this.DelToId.DataPropertyName = "DelToId";
            this.DelToId.HeaderText = "DelToId";
            this.DelToId.Name = "DelToId";
            this.DelToId.ReadOnly = true;
            this.DelToId.Visible = false;
            this.DelToId.Width = 70;
            // 
            // DelTo
            // 
            this.DelTo.DataPropertyName = "DelTo";
            this.DelTo.HeaderText = "DelTo";
            this.DelTo.Name = "DelTo";
            this.DelTo.ReadOnly = true;
            this.DelTo.Width = 66;
            // 
            // DateOrd
            // 
            this.DateOrd.DataPropertyName = "DateOrd";
            this.DateOrd.HeaderText = "DateOrd";
            this.DateOrd.Name = "DateOrd";
            this.DateOrd.ReadOnly = true;
            this.DateOrd.Width = 80;
            // 
            // DateRequired
            // 
            this.DateRequired.DataPropertyName = "DateRequired";
            this.DateRequired.HeaderText = "DateRequired";
            this.DateRequired.Name = "DateRequired";
            this.DateRequired.ReadOnly = true;
            this.DateRequired.Width = 110;
            // 
            // UnitNumber
            // 
            this.UnitNumber.DataPropertyName = "UnitNumber";
            this.UnitNumber.HeaderText = "UnitNumber";
            this.UnitNumber.Name = "UnitNumber";
            this.UnitNumber.ReadOnly = true;
            this.UnitNumber.Visible = false;
            this.UnitNumber.Width = 88;
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Width = 81;
            // 
            // ProName
            // 
            this.ProName.DataPropertyName = "ProName";
            this.ProName.HeaderText = "ProName";
            this.ProName.Name = "ProName";
            this.ProName.ReadOnly = true;
            this.ProName.Width = 83;
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 58;
            // 
            // QtyPCase
            // 
            this.QtyPCase.DataPropertyName = "QtyPCase";
            this.QtyPCase.HeaderText = "Q/C";
            this.QtyPCase.Name = "QtyPCase";
            this.QtyPCase.ReadOnly = true;
            this.QtyPCase.Width = 56;
            // 
            // QtyPPack
            // 
            this.QtyPPack.DataPropertyName = "QtyPPack";
            this.QtyPPack.HeaderText = "QtyPPack";
            this.QtyPPack.Name = "QtyPPack";
            this.QtyPPack.ReadOnly = true;
            this.QtyPPack.Visible = false;
            this.QtyPPack.Width = 80;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Visible = false;
            this.Category.Width = 74;
            // 
            // PcsFree
            // 
            this.PcsFree.DataPropertyName = "PcsFree";
            this.PcsFree.HeaderText = "PcsFree";
            this.PcsFree.Name = "PcsFree";
            this.PcsFree.ReadOnly = true;
            this.PcsFree.Width = 79;
            // 
            // PcsOrder
            // 
            this.PcsOrder.DataPropertyName = "PcsOrder";
            this.PcsOrder.HeaderText = "PcsOrder";
            this.PcsOrder.Name = "PcsOrder";
            this.PcsOrder.ReadOnly = true;
            this.PcsOrder.Width = 85;
            // 
            // PackOrder
            // 
            this.PackOrder.DataPropertyName = "PackOrder";
            this.PackOrder.HeaderText = "PackOrder";
            this.PackOrder.Name = "PackOrder";
            this.PackOrder.ReadOnly = true;
            this.PackOrder.Width = 93;
            // 
            // CTNOrder
            // 
            this.CTNOrder.DataPropertyName = "CTNOrder";
            this.CTNOrder.HeaderText = "CTNOrder";
            this.CTNOrder.Name = "CTNOrder";
            this.CTNOrder.ReadOnly = true;
            this.CTNOrder.Width = 88;
            // 
            // TotalPcsOrder
            // 
            this.TotalPcsOrder.DataPropertyName = "TotalPcsOrder";
            this.TotalPcsOrder.HeaderText = "TotalPcsOrder";
            this.TotalPcsOrder.Name = "TotalPcsOrder";
            this.TotalPcsOrder.ReadOnly = true;
            this.TotalPcsOrder.Width = 113;
            // 
            // LogInName
            // 
            this.LogInName.DataPropertyName = "LogInName";
            this.LogInName.HeaderText = "LogInName";
            this.LogInName.Name = "LogInName";
            this.LogInName.ReadOnly = true;
            this.LogInName.Visible = false;
            this.LogInName.Width = 87;
            // 
            // PromotionMachanic
            // 
            this.PromotionMachanic.DataPropertyName = "PromotionMachanic";
            this.PromotionMachanic.HeaderText = "PromotionMachanic";
            this.PromotionMachanic.Name = "PromotionMachanic";
            this.PromotionMachanic.ReadOnly = true;
            this.PromotionMachanic.Visible = false;
            this.PromotionMachanic.Width = 126;
            // 
            // ItemDiscount
            // 
            this.ItemDiscount.DataPropertyName = "ItemDiscount";
            this.ItemDiscount.HeaderText = "ItemDiscount";
            this.ItemDiscount.Name = "ItemDiscount";
            this.ItemDiscount.ReadOnly = true;
            this.ItemDiscount.Visible = false;
            this.ItemDiscount.Width = 94;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Visible = false;
            this.Remark.Width = 69;
            // 
            // Saleman
            // 
            this.Saleman.DataPropertyName = "Saleman";
            this.Saleman.HeaderText = "Saleman";
            this.Saleman.Name = "Saleman";
            this.Saleman.ReadOnly = true;
            this.Saleman.Visible = false;
            this.Saleman.Width = 73;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "CreatedDate";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Visible = false;
            this.CreatedDate.Width = 92;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.BtnExportToExcel);
            this.Panel44.Controls.Add(this.LblCountRow);
            this.Panel44.Controls.Add(this.BtnClose);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(5, 460);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2);
            this.Panel44.Size = new System.Drawing.Size(812, 35);
            this.Panel44.TabIndex = 113;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(581, 2);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(137, 31);
            this.BtnExportToExcel.TabIndex = 12;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // LblCountRow
            // 
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblCountRow.Location = new System.Drawing.Point(2, 2);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Size = new System.Drawing.Size(147, 31);
            this.LblCountRow.TabIndex = 11;
            this.LblCountRow.Text = "Count Row : 0";
            this.LblCountRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(718, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(92, 31);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.PanelHeader);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(812, 103);
            this.Panel1.TabIndex = 112;
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.Panel2);
            this.PanelHeader.Controls.Add(this.Panel3);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelHeader.Location = new System.Drawing.Point(376, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(436, 101);
            this.PanelHeader.TabIndex = 8;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnDownloadTakeOrder);
            this.Panel2.Controls.Add(this.CmbTakeOrderNo);
            this.Panel2.Controls.Add(this.Label3);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 32);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel2.Size = new System.Drawing.Size(436, 32);
            this.Panel2.TabIndex = 2;
            // 
            // BtnDownloadTakeOrder
            // 
            this.BtnDownloadTakeOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDownloadTakeOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDownloadTakeOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnDownloadTakeOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDownloadTakeOrder.Location = new System.Drawing.Point(225, 2);
            this.BtnDownloadTakeOrder.Name = "BtnDownloadTakeOrder";
            this.BtnDownloadTakeOrder.Size = new System.Drawing.Size(211, 28);
            this.BtnDownloadTakeOrder.TabIndex = 10;
            this.BtnDownloadTakeOrder.Text = "&Download Take Order";
            this.BtnDownloadTakeOrder.UseVisualStyleBackColor = true;
            this.BtnDownloadTakeOrder.Click += new System.EventHandler(this.BtnDownloadTakeOrder_Click);
            // 
            // CmbTakeOrderNo
            // 
            this.CmbTakeOrderNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbTakeOrderNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.CmbTakeOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTakeOrderNo.FormattingEnabled = true;
            this.CmbTakeOrderNo.Location = new System.Drawing.Point(96, 2);
            this.CmbTakeOrderNo.Name = "CmbTakeOrderNo";
            this.CmbTakeOrderNo.Size = new System.Drawing.Size(129, 27);
            this.CmbTakeOrderNo.TabIndex = 1;
            this.CmbTakeOrderNo.SelectedIndexChanged += new System.EventHandler(this.CmbTakeOrderNo_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.Location = new System.Drawing.Point(0, 2);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(96, 28);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Take Order #";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.CmbCustomer);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel3.Size = new System.Drawing.Size(436, 32);
            this.Panel3.TabIndex = 1;
            // 
            // CmbCustomer
            // 
            this.CmbCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCustomer.FormattingEnabled = true;
            this.CmbCustomer.Location = new System.Drawing.Point(96, 2);
            this.CmbCustomer.Name = "CmbCustomer";
            this.CmbCustomer.Size = new System.Drawing.Size(340, 27);
            this.CmbCustomer.TabIndex = 1;
            this.CmbCustomer.SelectedIndexChanged += new System.EventHandler(this.CmbCustomer_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Location = new System.Drawing.Point(0, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(96, 28);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Customer";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PicLogo
            // 
            this.PicLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicLogo.Image = global::DeliveryTakeOrder.Properties.Resources.Logo;
            this.PicLogo.Location = new System.Drawing.Point(0, 0);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(94, 101);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 3;
            this.PicLogo.TabStop = false;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 101);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(812, 2);
            this.Panel4.TabIndex = 7;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(104, 46);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(272, 43);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(100, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(276, 23);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Q\'s MANAGEMENT SYSTEM";
            // 
            // TimerCustomerLoading
            // 
            this.TimerCustomerLoading.Interval = 5;
            this.TimerCustomerLoading.Tick += new System.EventHandler(this.TimerCustomerLoading_Tick);
            // 
            // TimerTakeOrderLoading
            // 
            this.TimerTakeOrderLoading.Interval = 5;
            this.TimerTakeOrderLoading.Tick += new System.EventHandler(this.TimerTakeOrderLoading_Tick);
            // 
            // TimerDisplayLoading
            // 
            this.TimerDisplayLoading.Interval = 5;
            this.TimerDisplayLoading.Tick += new System.EventHandler(this.TimerDisplayLoading_Tick);
            // 
            // Popmenu
            // 
            this.Popmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuModifyTakeOrder,
            this.ToolStripSeparator1,
            this.MnuDeleteTakeOrder});
            this.Popmenu.Name = "Popmenu";
            this.Popmenu.Size = new System.Drawing.Size(172, 54);
            // 
            // MnuModifyTakeOrder
            // 
            this.MnuModifyTakeOrder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuChangeCustomer,
            this.MnuChangeDelto,
            this.MnuChangeQtyOrder});
            this.MnuModifyTakeOrder.Name = "MnuModifyTakeOrder";
            this.MnuModifyTakeOrder.Size = new System.Drawing.Size(171, 22);
            this.MnuModifyTakeOrder.Text = "&Modify Take Order";
            // 
            // MnuChangeCustomer
            // 
            this.MnuChangeCustomer.Name = "MnuChangeCustomer";
            this.MnuChangeCustomer.Size = new System.Drawing.Size(170, 22);
            this.MnuChangeCustomer.Text = "Change &Customer";
            this.MnuChangeCustomer.Click += new System.EventHandler(this.MnuChangeCustomer_Click);
            // 
            // MnuChangeDelto
            // 
            this.MnuChangeDelto.Name = "MnuChangeDelto";
            this.MnuChangeDelto.Size = new System.Drawing.Size(170, 22);
            this.MnuChangeDelto.Text = "Change &Delto";
            this.MnuChangeDelto.Click += new System.EventHandler(this.MnuChangeDelto_Click);
            // 
            // MnuChangeQtyOrder
            // 
            this.MnuChangeQtyOrder.Name = "MnuChangeQtyOrder";
            this.MnuChangeQtyOrder.Size = new System.Drawing.Size(170, 22);
            this.MnuChangeQtyOrder.Text = "Change &Qty Order";
            this.MnuChangeQtyOrder.Click += new System.EventHandler(this.MnuChangeQtyOrder_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // MnuDeleteTakeOrder
            // 
            this.MnuDeleteTakeOrder.Name = "MnuDeleteTakeOrder";
            this.MnuDeleteTakeOrder.Size = new System.Drawing.Size(171, 22);
            this.MnuDeleteTakeOrder.Text = "&Delete Take Order";
            this.MnuDeleteTakeOrder.Click += new System.EventHandler(this.MnuDeleteTakeOrder_Click);
            // 
            // FrmDownloadSaleTeam
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 500);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel44);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDownloadSaleTeam";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Download Take Order From Sale Team";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDownloadSaleTeam_FormClosed);
            this.Load += new System.EventHandler(this.FrmDownloadSaleTeam_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDownloadSaleTeam_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel44.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.PanelHeader.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.Popmenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvShow;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Id;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TakeOrderNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PONumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusNum;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DelToId;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DelTo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DateOrd;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DateRequired;
        internal System.Windows.Forms.DataGridViewTextBoxColumn UnitNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Size;
        internal System.Windows.Forms.DataGridViewTextBoxColumn QtyPCase;
        internal System.Windows.Forms.DataGridViewTextBoxColumn QtyPPack;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Category;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PcsFree;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PcsOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PackOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CTNOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TotalPcsOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn LogInName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PromotionMachanic;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ItemDiscount;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Saleman;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel PanelHeader;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnDownloadTakeOrder;
        internal System.Windows.Forms.ComboBox CmbTakeOrderNo;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.ComboBox CmbCustomer;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Timer TimerCustomerLoading;
        internal System.Windows.Forms.Timer TimerTakeOrderLoading;
        internal System.Windows.Forms.Timer TimerDisplayLoading;
        internal System.Windows.Forms.ContextMenuStrip Popmenu;
        internal System.Windows.Forms.ToolStripMenuItem MnuModifyTakeOrder;
        internal System.Windows.Forms.ToolStripMenuItem MnuChangeCustomer;
        internal System.Windows.Forms.ToolStripMenuItem MnuChangeDelto;
        internal System.Windows.Forms.ToolStripMenuItem MnuChangeQtyOrder;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem MnuDeleteTakeOrder;
    }
}