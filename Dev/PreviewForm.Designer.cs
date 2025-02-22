
using System.Drawing;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Dev
{
    partial class PreviewForm
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
            this.documentViewerRibbonController1 = new DevExpress.XtraPrinting.Preview.DocumentViewerRibbonController(this.components);
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.pageMain = new DevExpress.XtraTab.XtraTabPage();
            this.pcMain = new DeliveryTakeOrder.Dev.PreviewControl();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.panTitle = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.documentViewerRibbonController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentViewerRibbonController1
            // 
            this.documentViewerRibbonController1.RibbonStatusBar = this.ribbonStatusBar1;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 465);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Size = new System.Drawing.Size(883, 20);
            // 
            // tabMain
            // 
            this.tabMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.pageMain;
            this.tabMain.Size = new System.Drawing.Size(885, 510);
            this.tabMain.TabIndex = 0;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageMain});
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.pcMain);
            this.pageMain.Controls.Add(this.ribbonStatusBar1);
            this.pageMain.Name = "pageMain";
            this.pageMain.Size = new System.Drawing.Size(883, 485);
            this.pageMain.Text = "Main";
            // 
            // pcMain
            // 
            this.pcMain.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pcMain.Appearance.Options.UseFont = true;
            this.pcMain.Datasource = null;
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.Location = new System.Drawing.Point(0, 0);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(883, 465);
            this.pcMain.TabIndex = 5;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.panTitle);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tabMain);
            this.splitMain.Size = new System.Drawing.Size(885, 558);
            this.splitMain.SplitterDistance = 44;
            this.splitMain.TabIndex = 5;
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panTitle.Controls.Add(this.Label2);
            this.panTitle.Controls.Add(this.Label1);
            this.panTitle.Controls.Add(this.PictureBox1);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(885, 44);
            this.panTitle.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(46, 23);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(127, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "UNT Wholesale Co., LTD ";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(46, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(173, 16);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Q\'s MANAGEMENT SYSTEM";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::DeliveryTakeOrder.Properties.Resources.Logo;
            this.PictureBox1.Location = new System.Drawing.Point(3, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(37, 37);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // PreviewForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 558);
            this.Controls.Add(this.splitMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "PreviewForm";
            this.Text = "PreviewForm";
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            this.Shown += new System.EventHandler(this.PreviewForm_Shown_1);
            ((System.ComponentModel.ISupportInitialize)(this.documentViewerRibbonController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraPrinting.Preview.DocumentViewerRibbonController documentViewerRibbonController1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        internal DevExpress.XtraTab.XtraTabControl tabMain;
        internal DevExpress.XtraTab.XtraTabPage pageMain;
        internal System.Windows.Forms.SplitContainer splitMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        protected Panel panTitle;
        internal Label Label2;
        internal Label Label1;
        internal PictureBox PictureBox1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public PreviewControl pcMain;
    }
}