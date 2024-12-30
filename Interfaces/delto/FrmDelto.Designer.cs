namespace DeliveryTakeOrder.Interfaces.delto
{
    partial class FrmDelto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDelto));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabInformation = new System.Windows.Forms.TabPage();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Panel16 = new System.Windows.Forms.Panel();
            this.Navigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.BindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.MnuMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.MnuMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.BindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.NavigatorIndex = new System.Windows.Forms.ToolStripTextBox();
            this.BindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.MnuMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Panel53 = new System.Windows.Forms.Panel();
            this.TxtLongitude = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.Panel54 = new System.Windows.Forms.Panel();
            this.TxtLatitude = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.Panel13 = new System.Windows.Forms.Panel();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Panel11 = new System.Windows.Forms.Panel();
            this.TxtKhmerName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Panel10 = new System.Windows.Forms.Panel();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.RdbDeactivate = new System.Windows.Forms.RadioButton();
            this.RdbActivate = new System.Windows.Forms.RadioButton();
            this.RdbShowAll = new System.Windows.Forms.RadioButton();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.CmbStatus = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.loading = new System.Windows.Forms.Timer(this.components);
            this.displayloading = new System.Windows.Forms.Timer(this.components);
            this.zoneloading = new System.Windows.Forms.Timer(this.components);
            this.classloading = new System.Windows.Forms.Timer(this.components);
            this.cityloading = new System.Windows.Forms.Timer(this.components);
            this.customerloading = new System.Windows.Forms.Timer(this.components);
            this.imageloading = new System.Windows.Forms.Timer(this.components);
            this.deltoloading = new System.Windows.Forms.Timer(this.components);
            this.TabControl1.SuspendLayout();
            this.TabInformation.SuspendLayout();
            this.Panel9.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Navigator)).BeginInit();
            this.Navigator.SuspendLayout();
            this.Panel53.SuspendLayout();
            this.Panel54.SuspendLayout();
            this.Panel13.SuspendLayout();
            this.Panel11.SuspendLayout();
            this.Panel10.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabInformation);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.ImageList = this.ImageList1;
            this.TabControl1.Location = new System.Drawing.Point(5, 108);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(974, 498);
            this.TabControl1.TabIndex = 108;
            // 
            // TabInformation
            // 
            this.TabInformation.BackColor = System.Drawing.Color.GhostWhite;
            this.TabInformation.Controls.Add(this.Panel9);
            this.TabInformation.ImageIndex = 0;
            this.TabInformation.Location = new System.Drawing.Point(4, 28);
            this.TabInformation.Name = "TabInformation";
            this.TabInformation.Padding = new System.Windows.Forms.Padding(3);
            this.TabInformation.Size = new System.Drawing.Size(966, 466);
            this.TabInformation.TabIndex = 0;
            this.TabInformation.Text = "Information";
            // 
            // Panel9
            // 
            this.Panel9.Controls.Add(this.Panel3);
            this.Panel9.Controls.Add(this.Panel53);
            this.Panel9.Controls.Add(this.Panel54);
            this.Panel9.Controls.Add(this.Panel13);
            this.Panel9.Controls.Add(this.Panel11);
            this.Panel9.Controls.Add(this.Panel10);
            this.Panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel9.Location = new System.Drawing.Point(3, 3);
            this.Panel9.Name = "Panel9";
            this.Panel9.Size = new System.Drawing.Size(654, 460);
            this.Panel9.TabIndex = 11;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.Panel16);
            this.Panel3.Controls.Add(this.BtnRefresh);
            this.Panel3.Controls.Add(this.BtnUpdate);
            this.Panel3.Controls.Add(this.BtnSearch);
            this.Panel3.Controls.Add(this.BtnClose);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 160);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(2);
            this.Panel3.Size = new System.Drawing.Size(654, 39);
            this.Panel3.TabIndex = 107;
            // 
            // Panel16
            // 
            this.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel16.Controls.Add(this.Navigator);
            this.Panel16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel16.Location = new System.Drawing.Point(142, 2);
            this.Panel16.Name = "Panel16";
            this.Panel16.Size = new System.Drawing.Size(214, 35);
            this.Panel16.TabIndex = 104;
            // 
            // Navigator
            // 
            this.Navigator.AddNewItem = null;
            this.Navigator.BackColor = System.Drawing.SystemColors.Control;
            this.Navigator.CountItem = this.BindingNavigatorCountItem;
            this.Navigator.DeleteItem = null;
            this.Navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Navigator.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Navigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuMoveFirstItem,
            this.MnuMovePreviousItem,
            this.BindingNavigatorSeparator,
            this.NavigatorIndex,
            this.BindingNavigatorCountItem,
            this.BindingNavigatorSeparator1,
            this.MnuMoveNextItem,
            this.MnuMoveLastItem});
            this.Navigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.Navigator.Location = new System.Drawing.Point(0, 0);
            this.Navigator.MoveFirstItem = this.MnuMoveFirstItem;
            this.Navigator.MoveLastItem = this.MnuMoveLastItem;
            this.Navigator.MoveNextItem = this.MnuMoveNextItem;
            this.Navigator.MovePreviousItem = this.MnuMovePreviousItem;
            this.Navigator.Name = "Navigator";
            this.Navigator.PositionItem = this.NavigatorIndex;
            this.Navigator.Size = new System.Drawing.Size(212, 33);
            this.Navigator.TabIndex = 18;
            // 
            // BindingNavigatorCountItem
            // 
            this.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem";
            this.BindingNavigatorCountItem.Size = new System.Drawing.Size(36, 30);
            this.BindingNavigatorCountItem.Text = "of {0}";
            this.BindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // MnuMoveFirstItem
            // 
            this.MnuMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MnuMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("MnuMoveFirstItem.Image")));
            this.MnuMoveFirstItem.Name = "MnuMoveFirstItem";
            this.MnuMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.MnuMoveFirstItem.Size = new System.Drawing.Size(23, 30);
            this.MnuMoveFirstItem.Text = "Move first";
            // 
            // MnuMovePreviousItem
            // 
            this.MnuMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MnuMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("MnuMovePreviousItem.Image")));
            this.MnuMovePreviousItem.Name = "MnuMovePreviousItem";
            this.MnuMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.MnuMovePreviousItem.Size = new System.Drawing.Size(23, 30);
            this.MnuMovePreviousItem.Text = "Move previous";
            // 
            // BindingNavigatorSeparator
            // 
            this.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator";
            this.BindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
            // 
            // NavigatorIndex
            // 
            this.NavigatorIndex.AccessibleName = "Position";
            this.NavigatorIndex.BackColor = System.Drawing.SystemColors.Control;
            this.NavigatorIndex.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NavigatorIndex.Name = "NavigatorIndex";
            this.NavigatorIndex.ReadOnly = true;
            this.NavigatorIndex.Size = new System.Drawing.Size(30, 33);
            this.NavigatorIndex.Text = "0";
            this.NavigatorIndex.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NavigatorIndex.ToolTipText = "Current position";
            // 
            // BindingNavigatorSeparator1
            // 
            this.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1";
            this.BindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // MnuMoveNextItem
            // 
            this.MnuMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MnuMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("MnuMoveNextItem.Image")));
            this.MnuMoveNextItem.Name = "MnuMoveNextItem";
            this.MnuMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.MnuMoveNextItem.Size = new System.Drawing.Size(23, 30);
            this.MnuMoveNextItem.Text = "Move next";
            // 
            // MnuMoveLastItem
            // 
            this.MnuMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MnuMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("MnuMoveLastItem.Image")));
            this.MnuMoveLastItem.Name = "MnuMoveLastItem";
            this.MnuMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.MnuMoveLastItem.Size = new System.Drawing.Size(23, 30);
            this.MnuMoveLastItem.Text = "Move last";
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.BtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnRefresh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnRefresh.Image = global::DeliveryTakeOrder.Properties.Resources.refresh_16;
            this.BtnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRefresh.Location = new System.Drawing.Point(2, 2);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(140, 35);
            this.BtnRefresh.TabIndex = 109;
            this.BtnRefresh.Text = "&Refresh";
            this.BtnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefresh.UseVisualStyleBackColor = false;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnUpdate.Image = global::DeliveryTakeOrder.Properties.Resources.update_16;
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.Location = new System.Drawing.Point(356, 2);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(98, 35);
            this.BtnUpdate.TabIndex = 103;
            this.BtnUpdate.Text = "&Update";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnSearch.Image = global::DeliveryTakeOrder.Properties.Resources.Search16;
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.Location = new System.Drawing.Point(454, 2);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(95, 35);
            this.BtnSearch.TabIndex = 108;
            this.BtnSearch.Text = "&Search";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.SystemColors.Control;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnClose.Image = global::DeliveryTakeOrder.Properties.Resources.cancel_16;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.Location = new System.Drawing.Point(549, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(103, 35);
            this.BtnClose.TabIndex = 24;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Panel53
            // 
            this.Panel53.Controls.Add(this.TxtLongitude);
            this.Panel53.Controls.Add(this.Label19);
            this.Panel53.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel53.Location = new System.Drawing.Point(0, 128);
            this.Panel53.Name = "Panel53";
            this.Panel53.Padding = new System.Windows.Forms.Padding(2);
            this.Panel53.Size = new System.Drawing.Size(654, 32);
            this.Panel53.TabIndex = 126;
            // 
            // TxtLongitude
            // 
            this.TxtLongitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLongitude.Location = new System.Drawing.Point(142, 2);
            this.TxtLongitude.Name = "TxtLongitude";
            this.TxtLongitude.Size = new System.Drawing.Size(510, 28);
            this.TxtLongitude.TabIndex = 4;
            this.TxtLongitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLongitude_KeyPress);
            // 
            // Label19
            // 
            this.Label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label19.Location = new System.Drawing.Point(2, 2);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(140, 28);
            this.Label19.TabIndex = 0;
            this.Label19.Text = "Longitude (Map)";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel54
            // 
            this.Panel54.Controls.Add(this.TxtLatitude);
            this.Panel54.Controls.Add(this.Label20);
            this.Panel54.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel54.Location = new System.Drawing.Point(0, 96);
            this.Panel54.Name = "Panel54";
            this.Panel54.Padding = new System.Windows.Forms.Padding(2);
            this.Panel54.Size = new System.Drawing.Size(654, 32);
            this.Panel54.TabIndex = 125;
            // 
            // TxtLatitude
            // 
            this.TxtLatitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLatitude.Location = new System.Drawing.Point(142, 2);
            this.TxtLatitude.Name = "TxtLatitude";
            this.TxtLatitude.Size = new System.Drawing.Size(510, 28);
            this.TxtLatitude.TabIndex = 4;
            this.TxtLatitude.Enter += new System.EventHandler(this.TxtLatitude_Enter);
            this.TxtLatitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLatitude_KeyPress);
            // 
            // Label20
            // 
            this.Label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label20.Location = new System.Drawing.Point(2, 2);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(140, 28);
            this.Label20.TabIndex = 0;
            this.Label20.Text = "Latitude (Map)";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel13
            // 
            this.Panel13.Controls.Add(this.TxtName);
            this.Panel13.Controls.Add(this.Label7);
            this.Panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel13.Location = new System.Drawing.Point(0, 64);
            this.Panel13.Name = "Panel13";
            this.Panel13.Padding = new System.Windows.Forms.Padding(2);
            this.Panel13.Size = new System.Drawing.Size(654, 32);
            this.Panel13.TabIndex = 110;
            // 
            // TxtName
            // 
            this.TxtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtName.Location = new System.Drawing.Point(142, 2);
            this.TxtName.Name = "TxtName";
            this.TxtName.ReadOnly = true;
            this.TxtName.Size = new System.Drawing.Size(510, 28);
            this.TxtName.TabIndex = 1;
            this.TxtName.Enter += new System.EventHandler(this.TxtName_Enter);
            // 
            // Label7
            // 
            this.Label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label7.Location = new System.Drawing.Point(2, 2);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(140, 28);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Name";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel11
            // 
            this.Panel11.Controls.Add(this.TxtKhmerName);
            this.Panel11.Controls.Add(this.Label5);
            this.Panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel11.Location = new System.Drawing.Point(0, 32);
            this.Panel11.Name = "Panel11";
            this.Panel11.Padding = new System.Windows.Forms.Padding(2);
            this.Panel11.Size = new System.Drawing.Size(654, 32);
            this.Panel11.TabIndex = 109;
            // 
            // TxtKhmerName
            // 
            this.TxtKhmerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtKhmerName.Location = new System.Drawing.Point(142, 2);
            this.TxtKhmerName.Name = "TxtKhmerName";
            this.TxtKhmerName.ReadOnly = true;
            this.TxtKhmerName.Size = new System.Drawing.Size(510, 28);
            this.TxtKhmerName.TabIndex = 2;
            this.TxtKhmerName.Enter += new System.EventHandler(this.TxtKhmerName_Enter);
            // 
            // Label5
            // 
            this.Label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label5.Location = new System.Drawing.Point(2, 2);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(140, 28);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Khmer Name";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel10
            // 
            this.Panel10.Controls.Add(this.TxtId);
            this.Panel10.Controls.Add(this.Label4);
            this.Panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel10.Location = new System.Drawing.Point(0, 0);
            this.Panel10.Name = "Panel10";
            this.Panel10.Padding = new System.Windows.Forms.Padding(2);
            this.Panel10.Size = new System.Drawing.Size(654, 32);
            this.Panel10.TabIndex = 108;
            // 
            // TxtId
            // 
            this.TxtId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtId.Location = new System.Drawing.Point(142, 2);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(510, 28);
            this.TxtId.TabIndex = 1;
            this.TxtId.TextChanged += new System.EventHandler(this.TxtId_TextChanged);
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label4.Location = new System.Drawing.Point(2, 2);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(140, 28);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Id";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "_messagebox_dialog.png");
            this.ImageList1.Images.SetKeyName(1, "_inventory_.png");
            this.ImageList1.Images.SetKeyName(2, "_location_taget.png");
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.Panel5);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(974, 103);
            this.Panel1.TabIndex = 107;
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.RdbDeactivate);
            this.Panel5.Controls.Add(this.RdbActivate);
            this.Panel5.Controls.Add(this.RdbShowAll);
            this.Panel5.Controls.Add(this.Panel6);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel5.Location = new System.Drawing.Point(673, 0);
            this.Panel5.Name = "Panel5";
            this.Panel5.Padding = new System.Windows.Forms.Padding(2);
            this.Panel5.Size = new System.Drawing.Size(301, 101);
            this.Panel5.TabIndex = 9;
            // 
            // RdbDeactivate
            // 
            this.RdbDeactivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdbDeactivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbDeactivate.Dock = System.Windows.Forms.DockStyle.Top;
            this.RdbDeactivate.ForeColor = System.Drawing.Color.Teal;
            this.RdbDeactivate.Location = new System.Drawing.Point(2, 46);
            this.RdbDeactivate.Name = "RdbDeactivate";
            this.RdbDeactivate.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RdbDeactivate.Size = new System.Drawing.Size(297, 22);
            this.RdbDeactivate.TabIndex = 111;
            this.RdbDeactivate.Text = "Show All Deactivate";
            this.RdbDeactivate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdbDeactivate.UseVisualStyleBackColor = true;
            this.RdbDeactivate.CheckedChanged += new System.EventHandler(this.RdbDeactivate_CheckedChanged);
            // 
            // RdbActivate
            // 
            this.RdbActivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdbActivate.Checked = true;
            this.RdbActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbActivate.Dock = System.Windows.Forms.DockStyle.Top;
            this.RdbActivate.ForeColor = System.Drawing.Color.Teal;
            this.RdbActivate.Location = new System.Drawing.Point(2, 24);
            this.RdbActivate.Name = "RdbActivate";
            this.RdbActivate.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RdbActivate.Size = new System.Drawing.Size(297, 22);
            this.RdbActivate.TabIndex = 110;
            this.RdbActivate.TabStop = true;
            this.RdbActivate.Text = "Show All Activate";
            this.RdbActivate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdbActivate.UseVisualStyleBackColor = true;
            this.RdbActivate.CheckedChanged += new System.EventHandler(this.RdbActivate_CheckedChanged);
            // 
            // RdbShowAll
            // 
            this.RdbShowAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdbShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdbShowAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.RdbShowAll.ForeColor = System.Drawing.Color.Teal;
            this.RdbShowAll.Location = new System.Drawing.Point(2, 2);
            this.RdbShowAll.Name = "RdbShowAll";
            this.RdbShowAll.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RdbShowAll.Size = new System.Drawing.Size(297, 22);
            this.RdbShowAll.TabIndex = 109;
            this.RdbShowAll.Text = "Show All";
            this.RdbShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdbShowAll.UseVisualStyleBackColor = true;
            this.RdbShowAll.CheckedChanged += new System.EventHandler(this.RdbShowAll_CheckedChanged);
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.CmbStatus);
            this.Panel6.Controls.Add(this.Label2);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel6.Location = new System.Drawing.Point(2, 69);
            this.Panel6.Name = "Panel6";
            this.Panel6.Padding = new System.Windows.Forms.Padding(2);
            this.Panel6.Size = new System.Drawing.Size(297, 30);
            this.Panel6.TabIndex = 108;
            // 
            // CmbStatus
            // 
            this.CmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStatus.FormattingEnabled = true;
            this.CmbStatus.Location = new System.Drawing.Point(89, 2);
            this.CmbStatus.Name = "CmbStatus";
            this.CmbStatus.Size = new System.Drawing.Size(206, 27);
            this.CmbStatus.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Location = new System.Drawing.Point(2, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(87, 26);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Status";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.LblCompanyName);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel2.Location = new System.Drawing.Point(94, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(301, 101);
            this.Panel2.TabIndex = 8;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(2, 34);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(297, 65);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(2, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(297, 32);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Q\'s MANAGEMENT SYSTEM";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Panel4.BackColor = System.Drawing.Color.Teal;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 101);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(974, 2);
            this.Panel4.TabIndex = 7;
            // 
            // loading
            // 
            this.loading.Tick += new System.EventHandler(this.loading_Tick);
            // 
            // displayloading
            // 
            this.displayloading.Interval = 5;
            // 
            // zoneloading
            // 
            this.zoneloading.Interval = 5;
            // 
            // classloading
            // 
            this.classloading.Interval = 5;
            // 
            // cityloading
            // 
            this.cityloading.Interval = 5;
            this.cityloading.Tick += new System.EventHandler(this.cityloading_Tick);
            // 
            // customerloading
            // 
            this.customerloading.Interval = 5;
            // 
            // imageloading
            // 
            this.imageloading.Interval = 5;
            this.imageloading.Tick += new System.EventHandler(this.imageloading_Tick);
            // 
            // deltoloading
            // 
            this.deltoloading.Interval = 5;
            // 
            // FrmDelto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDelto";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDelto_FormClosing);
            this.Load += new System.EventHandler(this.FrmDelto_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDelto_Paint);
            this.TabControl1.ResumeLayout(false);
            this.TabInformation.ResumeLayout(false);
            this.Panel9.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel16.ResumeLayout(false);
            this.Panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Navigator)).EndInit();
            this.Navigator.ResumeLayout(false);
            this.Navigator.PerformLayout();
            this.Panel53.ResumeLayout(false);
            this.Panel53.PerformLayout();
            this.Panel54.ResumeLayout(false);
            this.Panel54.PerformLayout();
            this.Panel13.ResumeLayout(false);
            this.Panel13.PerformLayout();
            this.Panel11.ResumeLayout(false);
            this.Panel11.PerformLayout();
            this.Panel10.ResumeLayout(false);
            this.Panel10.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabInformation;
        internal System.Windows.Forms.Panel Panel9;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Panel Panel16;
        internal System.Windows.Forms.BindingNavigator Navigator;
        internal System.Windows.Forms.ToolStripLabel BindingNavigatorCountItem;
        internal System.Windows.Forms.ToolStripButton MnuMoveFirstItem;
        internal System.Windows.Forms.ToolStripButton MnuMovePreviousItem;
        internal System.Windows.Forms.ToolStripSeparator BindingNavigatorSeparator;
        internal System.Windows.Forms.ToolStripTextBox NavigatorIndex;
        internal System.Windows.Forms.ToolStripSeparator BindingNavigatorSeparator1;
        internal System.Windows.Forms.ToolStripButton MnuMoveNextItem;
        internal System.Windows.Forms.ToolStripButton MnuMoveLastItem;
        internal System.Windows.Forms.Button BtnRefresh;
        internal System.Windows.Forms.Button BtnUpdate;
        internal System.Windows.Forms.Button BtnSearch;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Panel Panel53;
        internal System.Windows.Forms.TextBox TxtLongitude;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Panel Panel54;
        internal System.Windows.Forms.TextBox TxtLatitude;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Panel Panel13;
        internal System.Windows.Forms.TextBox TxtName;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Panel Panel11;
        internal System.Windows.Forms.TextBox TxtKhmerName;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Panel Panel10;
        internal System.Windows.Forms.TextBox TxtId;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.RadioButton RdbDeactivate;
        internal System.Windows.Forms.RadioButton RdbActivate;
        internal System.Windows.Forms.RadioButton RdbShowAll;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.ComboBox CmbStatus;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Timer loading;
        internal System.Windows.Forms.Timer displayloading;
        internal System.Windows.Forms.Timer zoneloading;
        internal System.Windows.Forms.Timer classloading;
        internal System.Windows.Forms.Timer cityloading;
        internal System.Windows.Forms.Timer customerloading;
        internal System.Windows.Forms.Timer imageloading;
        internal System.Windows.Forms.ImageList ImageList1;
        internal System.Windows.Forms.Timer deltoloading;
    }
}