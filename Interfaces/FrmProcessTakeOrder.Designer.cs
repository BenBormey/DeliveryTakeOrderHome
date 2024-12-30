namespace DeliveryTakeOrder.Interfaces
{
    partial class FrmProcessTakeOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcessTakeOrder));
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
            this.CusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caseprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PcsFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PcsOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTNOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPcsOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogInName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromotionMachanic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saleman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Panel44 = new System.Windows.Forms.Panel();
            this.LblSeletedRow = new System.Windows.Forms.Label();
            this.BtnProcessTakeOrder = new System.Windows.Forms.Button();
            this.BtnPreviewNEditTakeOrder = new System.Windows.Forms.Button();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LblCountRow = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.chkshowprice = new System.Windows.Forms.CheckBox();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.CmbDelto = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.CmbCustomer = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.CmbTakeOrderNo = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbRequiredDate = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
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
            this.DeltoLoading = new System.Windows.Forms.Timer(this.components);
            this.RequiredDateLoading = new System.Windows.Forms.Timer(this.components);
            this.separateItemLoading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).BeginInit();
            this.Panel44.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.Panel7.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.Popmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvShow
            // 
            this.DgvShow.AllowUserToAddRows = false;
            this.DgvShow.AllowUserToDeleteRows = false;
            this.DgvShow.BackgroundColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.CusCode,
            this.ProName,
            this.Size,
            this.QtyPCase,
            this.QtyPPack,
            this.Category,
            this.unitprice,
            this.packprice,
            this.caseprice,
            this.PcsFree,
            this.PcsOrder,
            this.PackOrder,
            this.CTNOrder,
            this.TotalPcsOrder,
            this.ItemDiscount,
            this.amount,
            this.LogInName,
            this.PromotionMachanic,
            this.Remark,
            this.Saleman,
            this.CreatedDate,
            this.Tick});
            this.DgvShow.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvShow.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvShow.Location = new System.Drawing.Point(0, 103);
            this.DgvShow.Name = "DgvShow";
            this.DgvShow.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvShow.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvShow.RowHeadersWidth = 25;
            this.DgvShow.Size = new System.Drawing.Size(1122, 380);
            this.DgvShow.TabIndex = 114;
            this.DgvShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvShow_CellContentClick);
            this.DgvShow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DgvShow_PreviewKeyDown);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 44;
            // 
            // TakeOrderNumber
            // 
            this.TakeOrderNumber.DataPropertyName = "TakeOrderNumber";
            this.TakeOrderNumber.HeaderText = "TakeOrderNumber";
            this.TakeOrderNumber.Name = "TakeOrderNumber";
            this.TakeOrderNumber.ReadOnly = true;
            this.TakeOrderNumber.Visible = false;
            this.TakeOrderNumber.Width = 135;
            // 
            // PONumber
            // 
            this.PONumber.DataPropertyName = "PONumber";
            this.PONumber.HeaderText = "PONumber";
            this.PONumber.Name = "PONumber";
            this.PONumber.ReadOnly = true;
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
            // 
            // DelToId
            // 
            this.DelToId.DataPropertyName = "DelToId";
            this.DelToId.HeaderText = "DelToId";
            this.DelToId.Name = "DelToId";
            this.DelToId.ReadOnly = true;
            this.DelToId.Visible = false;
            this.DelToId.Width = 60;
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
            this.DateOrd.HeaderText = "DateOrd";
            this.DateOrd.Name = "DateOrd";
            this.DateOrd.ReadOnly = true;
            this.DateOrd.Width = 90;
            // 
            // DateRequired
            // 
            this.DateRequired.DataPropertyName = "DateRequired";
            this.DateRequired.HeaderText = "DateRequired";
            this.DateRequired.Name = "DateRequired";
            this.DateRequired.ReadOnly = true;
            this.DateRequired.Width = 90;
            // 
            // UnitNumber
            // 
            this.UnitNumber.DataPropertyName = "UnitNumber";
            this.UnitNumber.HeaderText = "UnitNumber";
            this.UnitNumber.Name = "UnitNumber";
            this.UnitNumber.ReadOnly = true;
            this.UnitNumber.Visible = false;
            this.UnitNumber.Width = 98;
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Width = 81;
            // 
            // CusCode
            // 
            this.CusCode.DataPropertyName = "CusCode";
            this.CusCode.HeaderText = "Items Code";
            this.CusCode.Name = "CusCode";
            this.CusCode.ReadOnly = true;
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
            this.QtyPPack.Width = 91;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Visible = false;
            this.Category.Width = 85;
            // 
            // unitprice
            // 
            this.unitprice.DataPropertyName = "unitprice";
            this.unitprice.HeaderText = "Unit Price";
            this.unitprice.Name = "unitprice";
            this.unitprice.ReadOnly = true;
            // 
            // packprice
            // 
            this.packprice.DataPropertyName = "packprice";
            this.packprice.HeaderText = "packprice";
            this.packprice.Name = "packprice";
            this.packprice.ReadOnly = true;
            this.packprice.Visible = false;
            // 
            // caseprice
            // 
            this.caseprice.DataPropertyName = "caseprice";
            dataGridViewCellStyle2.Format = "#,##0.00;(#,##0.00)";
            this.caseprice.DefaultCellStyle = dataGridViewCellStyle2;
            this.caseprice.HeaderText = "WS Price";
            this.caseprice.Name = "caseprice";
            this.caseprice.ReadOnly = true;
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
            // ItemDiscount
            // 
            this.ItemDiscount.DataPropertyName = "ItemDiscount";
            this.ItemDiscount.HeaderText = "Dis. %";
            this.ItemDiscount.Name = "ItemDiscount";
            this.ItemDiscount.ReadOnly = true;
            this.ItemDiscount.Width = 106;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            dataGridViewCellStyle3.Format = "#,##0.00;(#,##0.00)";
            this.amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // LogInName
            // 
            this.LogInName.DataPropertyName = "LogInName";
            this.LogInName.HeaderText = "LogInName";
            this.LogInName.Name = "LogInName";
            this.LogInName.ReadOnly = true;
            this.LogInName.Visible = false;
            this.LogInName.Width = 95;
            // 
            // PromotionMachanic
            // 
            this.PromotionMachanic.DataPropertyName = "PromotionMachanic";
            this.PromotionMachanic.HeaderText = "PromotionMachanic";
            this.PromotionMachanic.Name = "PromotionMachanic";
            this.PromotionMachanic.ReadOnly = true;
            this.PromotionMachanic.Visible = false;
            this.PromotionMachanic.Width = 143;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Visible = false;
            this.Remark.Width = 76;
            // 
            // Saleman
            // 
            this.Saleman.DataPropertyName = "Saleman";
            this.Saleman.HeaderText = "Saleman";
            this.Saleman.Name = "Saleman";
            this.Saleman.ReadOnly = true;
            this.Saleman.Visible = false;
            this.Saleman.Width = 81;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "CreatedDate";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Visible = false;
            this.CreatedDate.Width = 104;
            // 
            // Tick
            // 
            this.Tick.HeaderText = "";
            this.Tick.MinimumWidth = 25;
            this.Tick.Name = "Tick";
            this.Tick.ReadOnly = true;
            this.Tick.Width = 25;
            // 
            // Panel44
            // 
            this.Panel44.Controls.Add(this.LblSeletedRow);
            this.Panel44.Controls.Add(this.BtnProcessTakeOrder);
            this.Panel44.Controls.Add(this.BtnPreviewNEditTakeOrder);
            this.Panel44.Controls.Add(this.BtnExportToExcel);
            this.Panel44.Controls.Add(this.BtnClose);
            this.Panel44.Controls.Add(this.LblCountRow);
            this.Panel44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel44.Location = new System.Drawing.Point(0, 483);
            this.Panel44.Name = "Panel44";
            this.Panel44.Padding = new System.Windows.Forms.Padding(2);
            this.Panel44.Size = new System.Drawing.Size(1122, 35);
            this.Panel44.TabIndex = 113;
            // 
            // LblSeletedRow
            // 
            this.LblSeletedRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblSeletedRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSeletedRow.Location = new System.Drawing.Point(149, 2);
            this.LblSeletedRow.Name = "LblSeletedRow";
            this.LblSeletedRow.Size = new System.Drawing.Size(147, 31);
            this.LblSeletedRow.TabIndex = 13;
            this.LblSeletedRow.Text = "Selected Row : 0";
            this.LblSeletedRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnProcessTakeOrder
            // 
            this.BtnProcessTakeOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProcessTakeOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnProcessTakeOrder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProcessTakeOrder.ForeColor = System.Drawing.Color.Teal;
            this.BtnProcessTakeOrder.Image = global::DeliveryTakeOrder.Properties.Resources._verify;
            this.BtnProcessTakeOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProcessTakeOrder.Location = new System.Drawing.Point(483, 2);
            this.BtnProcessTakeOrder.Name = "BtnProcessTakeOrder";
            this.BtnProcessTakeOrder.Size = new System.Drawing.Size(190, 31);
            this.BtnProcessTakeOrder.TabIndex = 10;
            this.BtnProcessTakeOrder.Text = "&Process Take Order";
            this.BtnProcessTakeOrder.UseVisualStyleBackColor = true;
            this.BtnProcessTakeOrder.Click += new System.EventHandler(this.BtnProcessTakeOrder_Click_1);
            // 
            // BtnPreviewNEditTakeOrder
            // 
            this.BtnPreviewNEditTakeOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPreviewNEditTakeOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnPreviewNEditTakeOrder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreviewNEditTakeOrder.ForeColor = System.Drawing.Color.Teal;
            this.BtnPreviewNEditTakeOrder.Image = global::DeliveryTakeOrder.Properties.Resources._search_;
            this.BtnPreviewNEditTakeOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPreviewNEditTakeOrder.Location = new System.Drawing.Point(673, 2);
            this.BtnPreviewNEditTakeOrder.Name = "BtnPreviewNEditTakeOrder";
            this.BtnPreviewNEditTakeOrder.Size = new System.Drawing.Size(156, 31);
            this.BtnPreviewNEditTakeOrder.TabIndex = 14;
            this.BtnPreviewNEditTakeOrder.Text = "Preview && &Edit";
            this.BtnPreviewNEditTakeOrder.UseVisualStyleBackColor = true;
            this.BtnPreviewNEditTakeOrder.Click += new System.EventHandler(this.BtnPreviewNEditTakeOrder_Click);
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExportToExcel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportToExcel.ForeColor = System.Drawing.Color.Teal;
            this.BtnExportToExcel.Image = global::DeliveryTakeOrder.Properties.Resources.Excel16;
            this.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportToExcel.Location = new System.Drawing.Point(829, 2);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Size = new System.Drawing.Size(164, 31);
            this.BtnExportToExcel.TabIndex = 12;
            this.BtnExportToExcel.Text = "&Export To Excel";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.Teal;
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources._close_;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(993, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(127, 31);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblCountRow
            // 
            this.LblCountRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblCountRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCountRow.Location = new System.Drawing.Point(2, 2);
            this.LblCountRow.Name = "LblCountRow";
            this.LblCountRow.Size = new System.Drawing.Size(147, 31);
            this.LblCountRow.TabIndex = 11;
            this.LblCountRow.Text = "Count Row : 0";
            this.LblCountRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.Panel6);
            this.Panel1.Controls.Add(this.PanelHeader);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.LblCompanyName);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1122, 103);
            this.Panel1.TabIndex = 112;
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.Panel7);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel6.Location = new System.Drawing.Point(564, 0);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(122, 101);
            this.Panel6.TabIndex = 9;
            // 
            // Panel7
            // 
            this.Panel7.Controls.Add(this.chkshowprice);
            this.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel7.Location = new System.Drawing.Point(0, 69);
            this.Panel7.Name = "Panel7";
            this.Panel7.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel7.Size = new System.Drawing.Size(122, 32);
            this.Panel7.TabIndex = 3;
            // 
            // chkshowprice
            // 
            this.chkshowprice.BackColor = System.Drawing.Color.Teal;
            this.chkshowprice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkshowprice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkshowprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkshowprice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkshowprice.Location = new System.Drawing.Point(0, 2);
            this.chkshowprice.Name = "chkshowprice";
            this.chkshowprice.Size = new System.Drawing.Size(122, 28);
            this.chkshowprice.TabIndex = 0;
            this.chkshowprice.Text = "Show Price";
            this.chkshowprice.UseVisualStyleBackColor = false;
            this.chkshowprice.CheckedChanged += new System.EventHandler(this.chkshowprice_CheckedChanged);
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.Panel5);
            this.PanelHeader.Controls.Add(this.Panel3);
            this.PanelHeader.Controls.Add(this.Panel2);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelHeader.Location = new System.Drawing.Point(686, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(436, 101);
            this.PanelHeader.TabIndex = 8;
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.CmbDelto);
            this.Panel5.Controls.Add(this.Label4);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel5.Location = new System.Drawing.Point(0, 64);
            this.Panel5.Name = "Panel5";
            this.Panel5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel5.Size = new System.Drawing.Size(436, 32);
            this.Panel5.TabIndex = 3;
            // 
            // CmbDelto
            // 
            this.CmbDelto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbDelto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbDelto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbDelto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbDelto.FormattingEnabled = true;
            this.CmbDelto.Location = new System.Drawing.Point(96, 2);
            this.CmbDelto.Name = "CmbDelto";
            this.CmbDelto.Size = new System.Drawing.Size(340, 27);
            this.CmbDelto.TabIndex = 1;
            this.CmbDelto.SelectedIndexChanged += new System.EventHandler(this.CmbDelto_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label4.Location = new System.Drawing.Point(0, 2);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(96, 28);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Delto";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.CmbCustomer);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 32);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel3.Size = new System.Drawing.Size(436, 32);
            this.Panel3.TabIndex = 1;
            // 
            // CmbCustomer
            // 
            this.CmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
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
            // Panel2
            // 
            this.Panel2.Controls.Add(this.CmbTakeOrderNo);
            this.Panel2.Controls.Add(this.Label3);
            this.Panel2.Controls.Add(this.CmbRequiredDate);
            this.Panel2.Controls.Add(this.Label5);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Panel2.Size = new System.Drawing.Size(436, 32);
            this.Panel2.TabIndex = 2;
            // 
            // CmbTakeOrderNo
            // 
            this.CmbTakeOrderNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbTakeOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbTakeOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTakeOrderNo.FormattingEnabled = true;
            this.CmbTakeOrderNo.Location = new System.Drawing.Point(307, 2);
            this.CmbTakeOrderNo.Name = "CmbTakeOrderNo";
            this.CmbTakeOrderNo.Size = new System.Drawing.Size(129, 27);
            this.CmbTakeOrderNo.TabIndex = 1;
            this.CmbTakeOrderNo.Visible = false;
            this.CmbTakeOrderNo.SelectedIndexChanged += new System.EventHandler(this.CmbTakeOrderNo_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.Location = new System.Drawing.Point(225, 2);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(82, 28);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Take Order #";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Label3.Visible = false;
            // 
            // CmbRequiredDate
            // 
            this.CmbRequiredDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbRequiredDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.CmbRequiredDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRequiredDate.FormattingEnabled = true;
            this.CmbRequiredDate.Location = new System.Drawing.Point(96, 2);
            this.CmbRequiredDate.Name = "CmbRequiredDate";
            this.CmbRequiredDate.Size = new System.Drawing.Size(129, 27);
            this.CmbRequiredDate.TabIndex = 3;
            this.CmbRequiredDate.SelectedIndexChanged += new System.EventHandler(this.CmbRequiredDate_SelectedIndexChanged);
            // 
            // Label5
            // 
            this.Label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label5.Location = new System.Drawing.Point(0, 2);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(96, 28);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Required Date";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.Panel4.Size = new System.Drawing.Size(1122, 2);
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
            this.TimerDisplayLoading.Tick += new System.EventHandler(this.TimerDisplayLoading_Tick_1);
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
            this.MnuDeleteTakeOrder.Text = "&Delete Barcode";
            this.MnuDeleteTakeOrder.Click += new System.EventHandler(this.MnuDeleteTakeOrder_Click);
            // 
            // DeltoLoading
            // 
            this.DeltoLoading.Interval = 5;
            this.DeltoLoading.Tick += new System.EventHandler(this.DeltoLoading_Tick);
            // 
            // RequiredDateLoading
            // 
            this.RequiredDateLoading.Interval = 5;
            this.RequiredDateLoading.Tick += new System.EventHandler(this.RequiredDateLoading_Tick);
            // 
            // separateItemLoading
            // 
            this.separateItemLoading.Interval = 5;
            this.separateItemLoading.Tick += new System.EventHandler(this.separateItemLoading_Tick);
            // 
            // FrmProcessTakeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 518);
            this.Controls.Add(this.DgvShow);
            this.Controls.Add(this.Panel44);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmProcessTakeOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Take Order";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProcessTakeOrder_FormClosed);
            this.Load += new System.EventHandler(this.FrmProcessTakeOrder_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmProcessTakeOrder_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShow)).EndInit();
            this.Panel44.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel6.ResumeLayout(false);
            this.Panel7.ResumeLayout(false);
            this.PanelHeader.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
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
        internal System.Windows.Forms.DataGridViewTextBoxColumn CusCode;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Size;
        internal System.Windows.Forms.DataGridViewTextBoxColumn QtyPCase;
        internal System.Windows.Forms.DataGridViewTextBoxColumn QtyPPack;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Category;
        internal System.Windows.Forms.DataGridViewTextBoxColumn unitprice;
        internal System.Windows.Forms.DataGridViewTextBoxColumn packprice;
        internal System.Windows.Forms.DataGridViewTextBoxColumn caseprice;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PcsFree;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PcsOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PackOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CTNOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TotalPcsOrder;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ItemDiscount;
        internal System.Windows.Forms.DataGridViewTextBoxColumn amount;
        internal System.Windows.Forms.DataGridViewTextBoxColumn LogInName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PromotionMachanic;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Saleman;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Tick;
        internal System.Windows.Forms.Panel Panel44;
        internal System.Windows.Forms.Label LblSeletedRow;
        internal System.Windows.Forms.Button BtnProcessTakeOrder;
        internal System.Windows.Forms.Button BtnPreviewNEditTakeOrder;
        internal System.Windows.Forms.Button BtnExportToExcel;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Label LblCountRow;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.CheckBox chkshowprice;
        internal System.Windows.Forms.Panel PanelHeader;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.ComboBox CmbDelto;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.ComboBox CmbCustomer;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ComboBox CmbTakeOrderNo;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox CmbRequiredDate;
        internal System.Windows.Forms.Label Label5;
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
        internal System.Windows.Forms.Timer DeltoLoading;
        internal System.Windows.Forms.Timer RequiredDateLoading;
        internal System.Windows.Forms.Timer separateItemLoading;
    }
}