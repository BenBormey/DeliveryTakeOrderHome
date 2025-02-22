
namespace DeliveryTakeOrder.Interfaces.promotion_Id
{
    partial class guiDeliveryTakeOrderPromotionId
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiDeliveryTakeOrderPromotionId));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.lstmain = new DevExpress.XtraGrid.GridControl();
            this.gvmain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.methodOfPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.promotionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.maindelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.mainmodify = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnModify = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.btnexporttoexcel = new DevExpress.XtraEditors.SimpleButton();
            this.SeparatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.lblcountrow = new System.Windows.Forms.Label();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.cmbPromotionId = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.loading = new System.Windows.Forms.Timer(this.components);
            this.displayLoading = new System.Windows.Forms.Timer(this.components);
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstmain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvmain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModify)).BeginInit();
            this.Panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeparatorControl1)).BeginInit();
            this.Panel5.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.lstmain);
            this.Panel3.Controls.Add(this.Panel6);
            this.Panel3.Controls.Add(this.Panel5);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(5, 73);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(2);
            this.Panel3.Size = new System.Drawing.Size(768, 476);
            this.Panel3.TabIndex = 109;
            // 
            // lstmain
            // 
            this.lstmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstmain.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstmain.Location = new System.Drawing.Point(2, 92);
            this.lstmain.MainView = this.gvmain;
            this.lstmain.Name = "lstmain";
            this.lstmain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDelete,
            this.btnModify});
            this.lstmain.Size = new System.Drawing.Size(764, 347);
            this.lstmain.TabIndex = 20;
            this.lstmain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvmain});
            // 
            // gvmain
            // 
            this.gvmain.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvmain.AppearancePrint.EvenRow.Options.UseFont = true;
            this.gvmain.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.gvmain.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gvmain.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.gvmain.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.GroupRow.Options.UseFont = true;
            this.gvmain.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gvmain.AppearancePrint.Lines.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.Lines.Options.UseFont = true;
            this.gvmain.AppearancePrint.OddRow.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.OddRow.Options.UseFont = true;
            this.gvmain.AppearancePrint.Preview.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.Preview.Options.UseFont = true;
            this.gvmain.AppearancePrint.Row.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            this.gvmain.AppearancePrint.Row.Options.UseFont = true;
            this.gvmain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.methodOfPayment,
            this.description,
            this.createdDate,
            this.promotionId,
            this.maindelete,
            this.mainmodify});
            this.gvmain.GridControl = this.lstmain;
            this.gvmain.Name = "gvmain";
            this.gvmain.OptionsBehavior.ReadOnly = true;
            this.gvmain.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvmain.OptionsView.ShowGroupPanel = false;
            this.gvmain.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvmain_CustomDrawRowIndicator);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // methodOfPayment
            // 
            this.methodOfPayment.Caption = "Method Of Payment";
            this.methodOfPayment.FieldName = "methodOfPayment";
            this.methodOfPayment.MinWidth = 100;
            this.methodOfPayment.Name = "methodOfPayment";
            this.methodOfPayment.Visible = true;
            this.methodOfPayment.VisibleIndex = 0;
            this.methodOfPayment.Width = 167;
            // 
            // description
            // 
            this.description.Caption = "Description";
            this.description.FieldName = "description";
            this.description.MinWidth = 250;
            this.description.Name = "description";
            this.description.Visible = true;
            this.description.VisibleIndex = 1;
            this.description.Width = 250;
            // 
            // createdDate
            // 
            this.createdDate.Caption = "Created Date";
            this.createdDate.DisplayFormat.FormatString = "dd-MMM-yy hh:mm:ss tt";
            this.createdDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.createdDate.FieldName = "createdDate";
            this.createdDate.MinWidth = 150;
            this.createdDate.Name = "createdDate";
            this.createdDate.Visible = true;
            this.createdDate.VisibleIndex = 2;
            this.createdDate.Width = 150;
            // 
            // promotionId
            // 
            this.promotionId.Caption = "Promotion Id";
            this.promotionId.FieldName = "promotionId";
            this.promotionId.Name = "promotionId";
            // 
            // maindelete
            // 
            this.maindelete.ColumnEdit = this.btnDelete;
            this.maindelete.MaxWidth = 25;
            this.maindelete.MinWidth = 25;
            this.maindelete.Name = "maindelete";
            this.maindelete.Visible = true;
            this.maindelete.VisibleIndex = 3;
            this.maindelete.Width = 25;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            editorButtonImageOptions1.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnDelete_ButtonClick);
            // 
            // mainmodify
            // 
            this.mainmodify.ColumnEdit = this.btnModify;
            this.mainmodify.MaxWidth = 25;
            this.mainmodify.MinWidth = 25;
            this.mainmodify.Name = "mainmodify";
            this.mainmodify.Visible = true;
            this.mainmodify.VisibleIndex = 4;
            this.mainmodify.Width = 25;
            // 
            // btnModify
            // 
            this.btnModify.AutoHeight = false;
            editorButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions2.SvgImage")));
            editorButtonImageOptions2.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnModify.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnModify.Name = "btnModify";
            this.btnModify.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnModify.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnModify_ButtonClick);
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.btnexporttoexcel);
            this.Panel6.Controls.Add(this.SeparatorControl1);
            this.Panel6.Controls.Add(this.lblcountrow);
            this.Panel6.Controls.Add(this.btnclose);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel6.Location = new System.Drawing.Point(2, 439);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(764, 35);
            this.Panel6.TabIndex = 25;
            // 
            // btnexporttoexcel
            // 
            this.btnexporttoexcel.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexporttoexcel.Appearance.Options.UseFont = true;
            this.btnexporttoexcel.AppearanceHovered.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnexporttoexcel.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnexporttoexcel.AppearanceHovered.Options.UseBackColor = true;
            this.btnexporttoexcel.AppearanceHovered.Options.UseForeColor = true;
            this.btnexporttoexcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexporttoexcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnexporttoexcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnexporttoexcel.ImageOptions.SvgImage")));
            this.btnexporttoexcel.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnexporttoexcel.Location = new System.Drawing.Point(473, 0);
            this.btnexporttoexcel.Name = "btnexporttoexcel";
            this.btnexporttoexcel.Size = new System.Drawing.Size(176, 35);
            this.btnexporttoexcel.TabIndex = 24;
            this.btnexporttoexcel.Text = "&Export To Excel";
            // 
            // SeparatorControl1
            // 
            this.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.SeparatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.SeparatorControl1.Location = new System.Drawing.Point(649, 0);
            this.SeparatorControl1.Name = "SeparatorControl1";
            this.SeparatorControl1.Padding = new System.Windows.Forms.Padding(4);
            this.SeparatorControl1.Size = new System.Drawing.Size(10, 35);
            this.SeparatorControl1.TabIndex = 25;
            // 
            // lblcountrow
            // 
            this.lblcountrow.AutoSize = true;
            this.lblcountrow.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblcountrow.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountrow.Location = new System.Drawing.Point(0, 0);
            this.lblcountrow.Name = "lblcountrow";
            this.lblcountrow.Size = new System.Drawing.Size(74, 13);
            this.lblcountrow.TabIndex = 21;
            this.lblcountrow.Text = "Count Row : 0";
            // 
            // btnclose
            // 
            this.btnclose.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Appearance.Options.UseFont = true;
            this.btnclose.AppearanceHovered.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnclose.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnclose.AppearanceHovered.Options.UseBackColor = true;
            this.btnclose.AppearanceHovered.Options.UseForeColor = true;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnclose.ImageOptions.SvgImage")));
            this.btnclose.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnclose.Location = new System.Drawing.Point(659, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(105, 35);
            this.btnclose.TabIndex = 22;
            this.btnclose.Text = "&Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.cmbPromotionId);
            this.Panel5.Controls.Add(this.Label6);
            this.Panel5.Controls.Add(this.txtDescription);
            this.Panel5.Controls.Add(this.btnCancel);
            this.Panel5.Controls.Add(this.btnSave);
            this.Panel5.Controls.Add(this.Label2);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel5.Location = new System.Drawing.Point(2, 2);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(764, 90);
            this.Panel5.TabIndex = 0;
            // 
            // cmbPromotionId
            // 
            this.cmbPromotionId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPromotionId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPromotionId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPromotionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPromotionId.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPromotionId.FormattingEnabled = true;
            this.cmbPromotionId.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"});
            this.cmbPromotionId.Location = new System.Drawing.Point(11, 21);
            this.cmbPromotionId.Name = "cmbPromotionId";
            this.cmbPromotionId.Size = new System.Drawing.Size(345, 21);
            this.cmbPromotionId.TabIndex = 138;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label6.Location = new System.Drawing.Point(8, 5);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(104, 13);
            this.Label6.TabIndex = 137;
            this.Label6.Text = "Method Of Payment";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescription.Location = new System.Drawing.Point(11, 61);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(345, 22);
            this.txtDescription.TabIndex = 112;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.AppearanceHovered.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.AppearanceHovered.Options.UseBackColor = true;
            this.btnCancel.AppearanceHovered.Options.UseForeColor = true;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnCancel.Location = new System.Drawing.Point(504, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 32);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.AppearanceHovered.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.AppearanceHovered.Options.UseBackColor = true;
            this.btnSave.AppearanceHovered.Options.UseForeColor = true;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnSave.Location = new System.Drawing.Point(362, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 32);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label2.Location = new System.Drawing.Point(8, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Description";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.PicLogo);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(768, 68);
            this.Panel1.TabIndex = 108;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.LblCompanyName);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel2.Location = new System.Drawing.Point(66, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(295, 66);
            this.Panel2.TabIndex = 107;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.Teal;
            this.LblCompanyName.Location = new System.Drawing.Point(2, 34);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(291, 30);
            this.LblCompanyName.TabIndex = 6;
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Teal;
            this.Label1.Location = new System.Drawing.Point(2, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(291, 32);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Q\'s MANAGEMENT SYSTEM";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicLogo
            // 
            this.PicLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicLogo.Location = new System.Drawing.Point(0, 0);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(66, 66);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 3;
            this.PicLogo.TabStop = false;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.Teal;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel4.Location = new System.Drawing.Point(0, 66);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(768, 2);
            this.Panel4.TabIndex = 7;
            // 
            // loading
            // 
            this.loading.Interval = 5;
            this.loading.Tick += new System.EventHandler(this.loading_Tick);
            // 
            // displayLoading
            // 
            this.displayLoading.Interval = 5;
            this.displayLoading.Tick += new System.EventHandler(this.displayLoading_Tick);
            // 
            // guiDeliveryTakeOrderPromotionId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 554);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Panel1);
            this.Name = "guiDeliveryTakeOrderPromotionId";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROMOTION ID";
            this.Load += new System.EventHandler(this.guiDeliveryTakeOrderPromotionId_Load);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstmain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvmain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModify)).EndInit();
            this.Panel6.ResumeLayout(false);
            this.Panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeparatorControl1)).EndInit();
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel3;
        internal DevExpress.XtraGrid.GridControl lstmain;
        internal DevExpress.XtraGrid.Views.Grid.GridView gvmain;
        internal DevExpress.XtraGrid.Columns.GridColumn id;
        internal DevExpress.XtraGrid.Columns.GridColumn methodOfPayment;
        internal DevExpress.XtraGrid.Columns.GridColumn description;
        internal DevExpress.XtraGrid.Columns.GridColumn createdDate;
        internal DevExpress.XtraGrid.Columns.GridColumn promotionId;
        internal DevExpress.XtraGrid.Columns.GridColumn maindelete;
        internal DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        internal DevExpress.XtraGrid.Columns.GridColumn mainmodify;
        internal DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnModify;
        internal System.Windows.Forms.Panel Panel6;
        internal DevExpress.XtraEditors.SimpleButton btnexporttoexcel;
        internal DevExpress.XtraEditors.SeparatorControl SeparatorControl1;
        internal System.Windows.Forms.Label lblcountrow;
        internal DevExpress.XtraEditors.SimpleButton btnclose;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.ComboBox cmbPromotionId;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtDescription;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
        internal DevExpress.XtraEditors.SimpleButton btnSave;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label LblCompanyName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PicLogo;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Timer loading;
        internal System.Windows.Forms.Timer displayLoading;
    }
}