namespace DeliveryTakeOrder.Interfaces
{
    partial class MDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblversion = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDeliveryTakeOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetExpiryForPicking = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuDeliveryTakeOrder_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudelto = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuUnlockPrinterTakeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSetPiecesPerTray = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuDeliveryTakeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTakeOrderForDutchmill = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDownloadTakeOrderFromSaleTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuProcessTakeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDelayPrintInvoicing = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuDeltoListForDutchmillPO = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTakeOrderProcessing = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuwsproductslist = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuViewProcessingTakeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnurestartapplication = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.AlertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuurgentstocktoclear = new System.Windows.Forms.ToolStripMenuItem();
            this.Loading = new System.Windows.Forms.Timer(this.components);
            this.XtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.MnuTODeleted = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.BackColor = System.Drawing.Color.Teal;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblversion});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 431);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(632, 22);
            this.StatusStrip1.TabIndex = 8;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // lblversion
            // 
            this.lblversion.BackColor = System.Drawing.Color.Transparent;
            this.lblversion.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblversion.ForeColor = System.Drawing.Color.White;
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(85, 17);
            this.lblversion.Text = "Version 9.0.0";
            this.lblversion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.Color.White;
            this.MenuStrip1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.AlertToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(632, 24);
            this.MenuStrip1.TabIndex = 9;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuDeliveryTakeOrders,
            this.mnudelto,
            this.ToolStripSeparator5,
            this.MnuUnlockPrinterTakeOrder,
            this.ToolStripMenuItem2,
            this.ToolStripSeparator2,
            this.mnuwsproductslist,
            this.MnuViewProcessingTakeOrder,
            this.ToolStripMenuItem1,
            this.MnuChangePassword,
            this.ToolStripMenuItem3,
            this.mnurestartapplication,
            this.ToolStripSeparator4,
            this.MnuExit});
            this.FileToolStripMenuItem.Image = global::DeliveryTakeOrder.Properties.Resources.file;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.FileToolStripMenuItem.Text = "&File     ";
            // 
            // MnuDeliveryTakeOrders
            // 
            this.MnuDeliveryTakeOrders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetExpiryForPicking,
            this.ToolStripSeparator3,
            this.MnuDeliveryTakeOrder_});
            this.MnuDeliveryTakeOrders.Image = global::DeliveryTakeOrder.Properties.Resources.checklist16;
            this.MnuDeliveryTakeOrders.Name = "MnuDeliveryTakeOrders";
            this.MnuDeliveryTakeOrders.Size = new System.Drawing.Size(228, 22);
            this.MnuDeliveryTakeOrders.Text = "&Delivery Take Order";
            // 
            // mnuSetExpiryForPicking
            // 
            this.mnuSetExpiryForPicking.Image = global::DeliveryTakeOrder.Properties.Resources._expired_date;
            this.mnuSetExpiryForPicking.Name = "mnuSetExpiryForPicking";
            this.mnuSetExpiryForPicking.Size = new System.Drawing.Size(239, 22);
            this.mnuSetExpiryForPicking.Text = "&Set Period Expiry For Picking";
            this.mnuSetExpiryForPicking.Visible = false;
            this.mnuSetExpiryForPicking.Click += new System.EventHandler(this.mnuSetExpiryForPicking_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(236, 6);
            this.ToolStripSeparator3.Visible = false;
            // 
            // MnuDeliveryTakeOrder_
            // 
            this.MnuDeliveryTakeOrder_.Image = global::DeliveryTakeOrder.Properties.Resources.take_order;
            this.MnuDeliveryTakeOrder_.Name = "MnuDeliveryTakeOrder_";
            this.MnuDeliveryTakeOrder_.Size = new System.Drawing.Size(239, 22);
            this.MnuDeliveryTakeOrder_.Text = "&Delivery Take Order";
            this.MnuDeliveryTakeOrder_.Click += new System.EventHandler(this.MnuDeliveryTakeOrder__Click);
            // 
            // mnudelto
            // 
            this.mnudelto.Image = global::DeliveryTakeOrder.Properties.Resources.Add_User;
            this.mnudelto.Name = "mnudelto";
            this.mnudelto.Size = new System.Drawing.Size(228, 22);
            this.mnudelto.Text = "Delto";
            this.mnudelto.Visible = false;
            this.mnudelto.Click += new System.EventHandler(this.mnudelto_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(225, 6);
            this.ToolStripSeparator5.Visible = false;
            // 
            // MnuUnlockPrinterTakeOrder
            // 
            this.MnuUnlockPrinterTakeOrder.Image = global::DeliveryTakeOrder.Properties.Resources.Unlock_Printer;
            this.MnuUnlockPrinterTakeOrder.Name = "MnuUnlockPrinterTakeOrder";
            this.MnuUnlockPrinterTakeOrder.Size = new System.Drawing.Size(228, 22);
            this.MnuUnlockPrinterTakeOrder.Text = "&Unlock Printer Take Order";
            this.MnuUnlockPrinterTakeOrder.Click += new System.EventHandler(this.MnuUnlockPrinterTakeOrder_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSetPiecesPerTray,
            this.ToolStripSeparator1,
            this.MnuDeliveryTakeOrder,
            this.MnuTakeOrderForDutchmill,
            this.MnuDownloadTakeOrderFromSaleTeam,
            this.MnuProcessTakeOrder,
            this.MnuDelayPrintInvoicing,
            this.ToolStripMenuItem4,
            this.MnuDeltoListForDutchmillPO,
            this.MnuTakeOrderProcessing});
            this.ToolStripMenuItem2.Image = global::DeliveryTakeOrder.Properties.Resources.to;
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(228, 22);
            this.ToolStripMenuItem2.Text = "&Dutchmill";
            // 
            // MnuSetPiecesPerTray
            // 
            this.MnuSetPiecesPerTray.Image = global::DeliveryTakeOrder.Properties.Resources.tray;
            this.MnuSetPiecesPerTray.Name = "MnuSetPiecesPerTray";
            this.MnuSetPiecesPerTray.Size = new System.Drawing.Size(295, 22);
            this.MnuSetPiecesPerTray.Text = "&Set Pieces Per Tray";
            this.MnuSetPiecesPerTray.Click += new System.EventHandler(this.MnuSetPiecesPerTray_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(292, 6);
            // 
            // MnuDeliveryTakeOrder
            // 
            this.MnuDeliveryTakeOrder.Image = global::DeliveryTakeOrder.Properties.Resources.Check_Arrival;
            this.MnuDeliveryTakeOrder.Name = "MnuDeliveryTakeOrder";
            this.MnuDeliveryTakeOrder.Size = new System.Drawing.Size(295, 22);
            this.MnuDeliveryTakeOrder.Text = "Dutchmill &Order";
            this.MnuDeliveryTakeOrder.Click += new System.EventHandler(this.MnuDeliveryTakeOrder_Click);
            // 
            // MnuTakeOrderForDutchmill
            // 
            this.MnuTakeOrderForDutchmill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.MnuTakeOrderForDutchmill.Image = global::DeliveryTakeOrder.Properties.Resources.circle_old_code;
            this.MnuTakeOrderForDutchmill.Name = "MnuTakeOrderForDutchmill";
            this.MnuTakeOrderForDutchmill.Size = new System.Drawing.Size(295, 22);
            this.MnuTakeOrderForDutchmill.Text = "&Take Order";
            this.MnuTakeOrderForDutchmill.Visible = false;
            this.MnuTakeOrderForDutchmill.Click += new System.EventHandler(this.MnuTakeOrderForDutchmill_Click);
            // 
            // MnuDownloadTakeOrderFromSaleTeam
            // 
            this.MnuDownloadTakeOrderFromSaleTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.MnuDownloadTakeOrderFromSaleTeam.Image = global::DeliveryTakeOrder.Properties.Resources.Download;
            this.MnuDownloadTakeOrderFromSaleTeam.Name = "MnuDownloadTakeOrderFromSaleTeam";
            this.MnuDownloadTakeOrderFromSaleTeam.Size = new System.Drawing.Size(295, 22);
            this.MnuDownloadTakeOrderFromSaleTeam.Text = "D&ownload Take Order From Sale Team";
            this.MnuDownloadTakeOrderFromSaleTeam.Visible = false;
            this.MnuDownloadTakeOrderFromSaleTeam.Click += new System.EventHandler(this.MnuDownloadTakeOrderFromSaleTeam_Click);
            // 
            // MnuProcessTakeOrder
            // 
            this.MnuProcessTakeOrder.Image = global::DeliveryTakeOrder.Properties.Resources.update_16;
            this.MnuProcessTakeOrder.Name = "MnuProcessTakeOrder";
            this.MnuProcessTakeOrder.Size = new System.Drawing.Size(295, 22);
            this.MnuProcessTakeOrder.Text = "&Process Take Order";
            this.MnuProcessTakeOrder.Click += new System.EventHandler(this.MnuProcessTakeOrder_Click);
            // 
            // MnuDelayPrintInvoicing
            // 
            this.MnuDelayPrintInvoicing.Image = global::DeliveryTakeOrder.Properties.Resources.late;
            this.MnuDelayPrintInvoicing.Name = "MnuDelayPrintInvoicing";
            this.MnuDelayPrintInvoicing.Size = new System.Drawing.Size(295, 22);
            this.MnuDelayPrintInvoicing.Text = "Lock Items - Print Invoicing";
            this.MnuDelayPrintInvoicing.Click += new System.EventHandler(this.MnuDelayPrintInvoicing_Click);
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(292, 6);
            // 
            // MnuDeltoListForDutchmillPO
            // 
            this.MnuDeltoListForDutchmillPO.Image = global::DeliveryTakeOrder.Properties.Resources.Separately;
            this.MnuDeltoListForDutchmillPO.Name = "MnuDeltoListForDutchmillPO";
            this.MnuDeltoListForDutchmillPO.Size = new System.Drawing.Size(295, 22);
            this.MnuDeltoListForDutchmillPO.Text = "&Delto List For Dutchmill P.O";
            this.MnuDeltoListForDutchmillPO.Click += new System.EventHandler(this.MnuDeltoListForDutchmillPO_Click);
            // 
            // MnuTakeOrderProcessing
            // 
            this.MnuTakeOrderProcessing.Image = global::DeliveryTakeOrder.Properties.Resources.circle_old_code;
            this.MnuTakeOrderProcessing.Name = "MnuTakeOrderProcessing";
            this.MnuTakeOrderProcessing.Size = new System.Drawing.Size(295, 22);
            this.MnuTakeOrderProcessing.Text = "&Take Order Processing";
            this.MnuTakeOrderProcessing.Click += new System.EventHandler(this.MnuTakeOrderProcessing_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // mnuwsproductslist
            // 
            this.mnuwsproductslist.Image = global::DeliveryTakeOrder.Properties.Resources.budget;
            this.mnuwsproductslist.Name = "mnuwsproductslist";
            this.mnuwsproductslist.Size = new System.Drawing.Size(228, 22);
            this.mnuwsproductslist.Text = "&WS Products List";
            this.mnuwsproductslist.Click += new System.EventHandler(this.mnuwsproductslist_Click);
            // 
            // MnuViewProcessingTakeOrder
            // 
            this.MnuViewProcessingTakeOrder.Image = global::DeliveryTakeOrder.Properties.Resources.Search16;
            this.MnuViewProcessingTakeOrder.Name = "MnuViewProcessingTakeOrder";
            this.MnuViewProcessingTakeOrder.Size = new System.Drawing.Size(228, 22);
            this.MnuViewProcessingTakeOrder.Text = "&View Processing Takeorder";
            this.MnuViewProcessingTakeOrder.Click += new System.EventHandler(this.MnuViewProcessingTakeOrder_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // MnuChangePassword
            // 
            this.MnuChangePassword.Image = global::DeliveryTakeOrder.Properties.Resources.Password;
            this.MnuChangePassword.Name = "MnuChangePassword";
            this.MnuChangePassword.Size = new System.Drawing.Size(228, 22);
            this.MnuChangePassword.Text = "&Change Password";
            this.MnuChangePassword.Click += new System.EventHandler(this.MnuChangePassword_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(225, 6);
            // 
            // mnurestartapplication
            // 
            this.mnurestartapplication.Image = global::DeliveryTakeOrder.Properties.Resources.arrow_circle_double;
            this.mnurestartapplication.Name = "mnurestartapplication";
            this.mnurestartapplication.Size = new System.Drawing.Size(228, 22);
            this.mnurestartapplication.Text = "&Log Off";
            this.mnurestartapplication.Click += new System.EventHandler(this.mnurestartapplication_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(225, 6);
            // 
            // MnuExit
            // 
            this.MnuExit.Image = global::DeliveryTakeOrder.Properties.Resources.Close;
            this.MnuExit.Name = "MnuExit";
            this.MnuExit.Size = new System.Drawing.Size(228, 22);
            this.MnuExit.Text = "&Exit";
            // 
            // AlertToolStripMenuItem
            // 
            this.AlertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuTODeleted,
            this.ToolStripMenuItem5,
            this.mnuurgentstocktoclear});
            this.AlertToolStripMenuItem.Name = "AlertToolStripMenuItem";
            this.AlertToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.AlertToolStripMenuItem.Text = "Alert     ";
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuurgentstocktoclear
            // 
            this.mnuurgentstocktoclear.Image = global::DeliveryTakeOrder.Properties.Resources.emergency_;
            this.mnuurgentstocktoclear.Name = "mnuurgentstocktoclear";
            this.mnuurgentstocktoclear.Size = new System.Drawing.Size(198, 22);
            this.mnuurgentstocktoclear.Text = "&Urgent Stock to Clear";
            this.mnuurgentstocktoclear.Click += new System.EventHandler(this.mnuurgentstocktoclear_Click);
            // 
            // Loading
            // 
            this.Loading.Interval = 5;
            this.Loading.Tick += new System.EventHandler(this.Loading_Tick);
            // 
            // XtraTabbedMdiManager1
            // 
            this.XtraTabbedMdiManager1.MdiParent = this;
            // 
            // MnuTODeleted
            // 
            this.MnuTODeleted.Image = global::DeliveryTakeOrder.Properties.Resources.Deleted16;
            this.MnuTODeleted.Name = "MnuTODeleted";
            this.MnuTODeleted.Size = new System.Drawing.Size(198, 22);
            this.MnuTODeleted.Text = "T.O Deleted";
            this.MnuTODeleted.Click += new System.EventHandler(this.MnuTODeleted_Click_1);
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.StatusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDI";
            this.Text = "Delivery Take Order";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDI_FormClosed);
            this.Load += new System.EventHandler(this.MDI_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel lblversion;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem MnuDeliveryTakeOrders;
        internal System.Windows.Forms.ToolStripMenuItem mnuSetExpiryForPicking;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripMenuItem MnuDeliveryTakeOrder_;
        internal System.Windows.Forms.ToolStripMenuItem mnudelto;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        internal System.Windows.Forms.ToolStripMenuItem MnuUnlockPrinterTakeOrder;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem MnuSetPiecesPerTray;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem MnuDeliveryTakeOrder;
        internal System.Windows.Forms.ToolStripMenuItem MnuTakeOrderForDutchmill;
        internal System.Windows.Forms.ToolStripMenuItem MnuDownloadTakeOrderFromSaleTeam;
        internal System.Windows.Forms.ToolStripMenuItem MnuProcessTakeOrder;
        internal System.Windows.Forms.ToolStripMenuItem MnuDelayPrintInvoicing;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem MnuDeltoListForDutchmillPO;
        internal System.Windows.Forms.ToolStripMenuItem MnuTakeOrderProcessing;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripMenuItem mnuwsproductslist;
        internal System.Windows.Forms.ToolStripMenuItem MnuViewProcessingTakeOrder;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem MnuChangePassword;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem mnurestartapplication;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripMenuItem MnuExit;
        internal System.Windows.Forms.ToolStripMenuItem AlertToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem5;
        internal System.Windows.Forms.ToolStripMenuItem mnuurgentstocktoclear;
        internal System.Windows.Forms.Timer Loading;
        internal DevExpress.XtraTabbedMdi.XtraTabbedMdiManager XtraTabbedMdiManager1;
        internal System.Windows.Forms.ToolStripMenuItem MnuTODeleted;
    }
}



