
namespace DeliveryTakeOrder.Dev
{
    partial class PreviewFor
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
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.pageMain = new DevExpress.XtraTab.XtraTabPage();
            this.pcMain = new DeliveryTakeOrder.Dev.PreviewControl();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.DefaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.pageMain;
            this.tabMain.Size = new System.Drawing.Size(890, 524);
            this.tabMain.TabIndex = 0;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageMain});
            // 
            // pageMain
            // 
            this.pageMain.AllowTouchScroll = true;
            this.pageMain.Controls.Add(this.pcMain);
            this.pageMain.Name = "pageMain";
            this.pageMain.Size = new System.Drawing.Size(888, 499);
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
            this.pcMain.Size = new System.Drawing.Size(888, 499);
            this.pcMain.TabIndex = 0;
            this.pcMain.Load += new System.EventHandler(this.pcMain_Load);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tabMain);
            this.splitMain.Size = new System.Drawing.Size(890, 572);
            this.splitMain.SplitterDistance = 44;
            this.splitMain.TabIndex = 3;
            // 
            // DefaultLookAndFeel1
            // 
            this.DefaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
            // 
            // PreviewFor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 572);
            this.Controls.Add(this.splitMain);
            this.Name = "PreviewFor";
            this.Text = "PreviewFor";
            this.Load += new System.EventHandler(this.PreviewFor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal DevExpress.XtraTab.XtraTabControl tabMain;
        internal DevExpress.XtraTab.XtraTabPage pageMain;
        private PreviewControl pcMain;
        internal System.Windows.Forms.SplitContainer splitMain;
        internal DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel1;
    }
}