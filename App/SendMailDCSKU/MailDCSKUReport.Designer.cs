
namespace DeliveryTakeOrder.App.SendMailDCSKU
{
    partial class MailDCSKUReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailDCSKUReport));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.paramDear = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramPO = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramBarcode = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramName = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramSize = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 68.74987F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel1,
            this.XrLabel2,
            this.XrPageInfo1,
            this.XrLabel3});
            this.ReportHeader.HeightF = 328.1251F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // XrLabel1
            // 
            this.XrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[paramDear]")});
            this.XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 99.16667F);
            this.XrLabel1.Name = "XrLabel1";
            this.XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel1.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.XrLabel1.StylePriority.UseTextAlignment = false;
            this.XrLabel1.Text = "Dear";
            this.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel2
            // 
            this.XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrLabel2.Multiline = true;
            this.XrLabel2.Name = "XrLabel2";
            this.XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel2.SizeF = new System.Drawing.SizeF(650F, 71.16667F);
            this.XrLabel2.StylePriority.UseTextAlignment = false;
            this.XrLabel2.Text = "UNT WHOLESALE CO., LTD.\r\nNo.891 St. 53cc, Phum Toulpongror\r\nSangkat Chom Chao, Kh" +
    "an Porsenchey \r\nPhnom Penh, Cambodia.";
            this.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo1
            // 
            this.XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 71.16667F);
            this.XrPageInfo1.Name = "XrPageInfo1";
            this.XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.XrPageInfo1.SizeF = new System.Drawing.SizeF(200F, 23F);
            this.XrPageInfo1.StylePriority.UseTextAlignment = false;
            this.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrPageInfo1.TextFormatString = "{0:MMMM dd, yyyy}";
            // 
            // XrLabel3
            // 
            this.XrLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", resources.GetString("XrLabel3.ExpressionBindings"))});
            this.XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 122.1667F);
            this.XrLabel3.Multiline = true;
            this.XrLabel3.Name = "XrLabel3";
            this.XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel3.SizeF = new System.Drawing.SizeF(650F, 205.9584F);
            this.XrLabel3.StylePriority.UseTextAlignment = false;
            this.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // paramDear
            // 
            this.paramDear.Description = "Parameter1";
            this.paramDear.Name = "paramDear";
            // 
            // paramPO
            // 
            this.paramPO.Description = "Parameter1";
            this.paramPO.Name = "paramPO";
            // 
            // paramBarcode
            // 
            this.paramBarcode.Description = "Parameter1";
            this.paramBarcode.Name = "paramBarcode";
            // 
            // paramName
            // 
            this.paramName.Description = "Parameter1";
            this.paramName.Name = "paramName";
            // 
            // paramSize
            // 
            this.paramSize.Description = "paramSize";
            this.paramSize.Name = "paramSize";
            // 
            // MailDCSKUReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 100, 69);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramDear,
            this.paramPO,
            this.paramBarcode,
            this.paramName,
            this.paramSize});
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        private DevExpress.XtraReports.Parameters.Parameter paramDear;
        private DevExpress.XtraReports.Parameters.Parameter paramPO;
        private DevExpress.XtraReports.Parameters.Parameter paramBarcode;
        private DevExpress.XtraReports.Parameters.Parameter paramName;
        private DevExpress.XtraReports.Parameters.Parameter paramSize;
    }
}
