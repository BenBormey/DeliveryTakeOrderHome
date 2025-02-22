
namespace DeliveryTakeOrder.Dev
{
    partial class sExpiryDate
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
            this.components = new System.ComponentModel.Container();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.XrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.XrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrPanel3 = new DevExpress.XtraReports.UI.XRPanel();
            this.XrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrPanel4 = new DevExpress.XtraReports.UI.XRPanel();
            this.XrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.XrCrossBandLine1 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.XrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.OverCreditNTerm1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.companyname = new DevExpress.XtraReports.Parameters.Parameter();
            this.companyaddress = new DevExpress.XtraReports.Parameters.Parameter();
            this.cusnum = new DevExpress.XtraReports.Parameters.Parameter();
            this.cusname = new DevExpress.XtraReports.Parameters.Parameter();
            this.currentdate = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.OverCreditNTerm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPanel1,
            this.XrLine1,
            this.XrLabel3,
            this.XrLabel4,
            this.XrPanel2,
            this.XrPanel3,
            this.XrLabel25,
            this.XrLabel41,
            this.XrPanel4});
            this.TopMargin.HeightF = 489.1667F;
            this.TopMargin.Name = "TopMargin";
            // 
            // XrPanel1
            // 
            this.XrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel1,
            this.XrLabel2});
            this.XrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(2.000061F, 27.35417F);
            this.XrPanel1.Name = "XrPanel1";
            this.XrPanel1.SizeF = new System.Drawing.SizeF(766.9999F, 136.5F);
            // 
            // XrLabel1
            // 
            this.XrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.companyaddress]")});
            this.XrLabel1.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.0001033147F, 69.79166F);
            this.XrLabel1.Multiline = true;
            this.XrLabel1.Name = "XrLabel1";
            this.XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel1.SizeF = new System.Drawing.SizeF(766.9999F, 66.6667F);
            this.XrLabel1.StylePriority.UseFont = false;
            this.XrLabel1.StylePriority.UseTextAlignment = false;
            this.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // XrLabel2
            // 
            this.XrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.companyname]")});
            this.XrLabel2.Font = new System.Drawing.Font("Khmer OS Muol", 12F);
            this.XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrLabel2.Multiline = true;
            this.XrLabel2.Name = "XrLabel2";
            this.XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel2.SizeF = new System.Drawing.SizeF(767F, 69.79166F);
            this.XrLabel2.StylePriority.UseFont = false;
            this.XrLabel2.StylePriority.UseTextAlignment = false;
            this.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // XrLine1
            // 
            this.XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(2.000061F, 163.8542F);
            this.XrLine1.Name = "XrLine1";
            this.XrLine1.SizeF = new System.Drawing.SizeF(766.9999F, 8.791656F);
            // 
            // XrLabel3
            // 
            this.XrLabel3.CanGrow = false;
            this.XrLabel3.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(2.000062F, 172.6458F);
            this.XrLabel3.Name = "XrLabel3";
            this.XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel3.SizeF = new System.Drawing.SizeF(766.9999F, 25.00006F);
            this.XrLabel3.StylePriority.UseFont = false;
            this.XrLabel3.StylePriority.UseTextAlignment = false;
            this.XrLabel3.Text = "EXPIRY DATE REPORT";
            this.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel3.WordWrap = false;
            // 
            // XrLabel4
            // 
            this.XrLabel4.CanGrow = false;
            this.XrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.currentdate]")});
            this.XrLabel4.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(2.000061F, 197.6459F);
            this.XrLabel4.Name = "XrLabel4";
            this.XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel4.SizeF = new System.Drawing.SizeF(766.9999F, 25.00006F);
            this.XrLabel4.StylePriority.UseFont = false;
            this.XrLabel4.StylePriority.UseTextAlignment = false;
            this.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel4.TextFormatString = "Export Date : {0:dd-MMM-yyyy hh:mm:ss tt}";
            this.XrLabel4.WordWrap = false;
            // 
            // XrPanel2
            // 
            this.XrPanel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel8,
            this.XrLabel9,
            this.XrLabel7,
            this.XrLabel6,
            this.XrLabel5});
            this.XrPanel2.LocationFloat = new DevExpress.Utils.PointFloat(2.000149F, 227.646F);
            this.XrPanel2.Name = "XrPanel2";
            this.XrPanel2.SizeF = new System.Drawing.SizeF(766.9999F, 75.43739F);
            this.XrPanel2.StylePriority.UseBorders = false;
            // 
            // XrLabel8
            // 
            this.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel8.CanGrow = false;
            this.XrLabel8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.cusname]")});
            this.XrLabel8.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(104.4998F, 50.00013F);
            this.XrLabel8.Name = "XrLabel8";
            this.XrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel8.SizeF = new System.Drawing.SizeF(662.5F, 25.00006F);
            this.XrLabel8.StylePriority.UseBorders = false;
            this.XrLabel8.StylePriority.UseFont = false;
            this.XrLabel8.StylePriority.UseTextAlignment = false;
            this.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel8.WordWrap = false;
            // 
            // XrLabel9
            // 
            this.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel9.CanGrow = false;
            this.XrLabel9.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50.00013F);
            this.XrLabel9.Name = "XrLabel9";
            this.XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel9.SizeF = new System.Drawing.SizeF(104.4998F, 25.00006F);
            this.XrLabel9.StylePriority.UseBorders = false;
            this.XrLabel9.StylePriority.UseFont = false;
            this.XrLabel9.StylePriority.UseTextAlignment = false;
            this.XrLabel9.Text = "Customer Name :";
            this.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel9.WordWrap = false;
            // 
            // XrLabel7
            // 
            this.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel7.CanGrow = false;
            this.XrLabel7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters.cusnum]")});
            this.XrLabel7.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(104.4998F, 25.00006F);
            this.XrLabel7.Name = "XrLabel7";
            this.XrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel7.SizeF = new System.Drawing.SizeF(662.5F, 25.00005F);
            this.XrLabel7.StylePriority.UseBorders = false;
            this.XrLabel7.StylePriority.UseFont = false;
            this.XrLabel7.StylePriority.UseTextAlignment = false;
            this.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel7.WordWrap = false;
            // 
            // XrLabel6
            // 
            this.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel6.CanGrow = false;
            this.XrLabel6.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25.00006F);
            this.XrLabel6.Name = "XrLabel6";
            this.XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel6.SizeF = new System.Drawing.SizeF(104.4998F, 25.00005F);
            this.XrLabel6.StylePriority.UseBorders = false;
            this.XrLabel6.StylePriority.UseFont = false;
            this.XrLabel6.StylePriority.UseTextAlignment = false;
            this.XrLabel6.Text = "Customer # :";
            this.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel6.WordWrap = false;
            // 
            // XrLabel5
            // 
            this.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel5.CanGrow = false;
            this.XrLabel5.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrLabel5.Name = "XrLabel5";
            this.XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel5.SizeF = new System.Drawing.SizeF(766.9999F, 25.00006F);
            this.XrLabel5.StylePriority.UseBorders = false;
            this.XrLabel5.StylePriority.UseFont = false;
            this.XrLabel5.StylePriority.UseTextAlignment = false;
            this.XrLabel5.Text = "FOR CUSTOMER :";
            this.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel5.WordWrap = false;
            // 
            // XrPanel3
            // 
            this.XrPanel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrPanel3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel24,
            this.XrLabel17,
            this.XrLabel18,
            this.XrLabel19,
            this.XrLabel20,
            this.XrLabel21,
            this.XrLabel22,
            this.XrLabel23,
            this.XrLabel16,
            this.XrLabel15,
            this.XrLabel14,
            this.XrLabel13,
            this.XrLabel12,
            this.XrLabel11,
            this.XrLabel10});
            this.XrPanel3.LocationFloat = new DevExpress.Utils.PointFloat(2.000149F, 344.9375F);
            this.XrPanel3.Name = "XrPanel3";
            this.XrPanel3.SizeF = new System.Drawing.SizeF(766.9999F, 78.125F);
            this.XrPanel3.StylePriority.UseBorders = false;
            // 
            // XrLabel24
            // 
            this.XrLabel24.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel24.CanGrow = false;
            this.XrLabel24.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[KhmerName]")});
            this.XrLabel24.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(313.4995F, 52.00012F);
            this.XrLabel24.Name = "XrLabel24";
            this.XrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel24.SizeF = new System.Drawing.SizeF(233.6665F, 26.00006F);
            this.XrLabel24.StylePriority.UseBorders = false;
            this.XrLabel24.StylePriority.UseFont = false;
            this.XrLabel24.StylePriority.UseTextAlignment = false;
            this.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel24.WordWrap = false;
            // 
            // XrLabel17
            // 
            this.XrLabel17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel17.CanGrow = false;
            this.XrLabel17.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockIn]")});
            this.XrLabel17.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(668.6656F, 26.00009F);
            this.XrLabel17.Name = "XrLabel17";
            this.XrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel17.SizeF = new System.Drawing.SizeF(98.33417F, 52.12492F);
            this.XrLabel17.StylePriority.UseBorders = false;
            this.XrLabel17.StylePriority.UseFont = false;
            this.XrLabel17.StylePriority.UseTextAlignment = false;
            this.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel17.TextFormatString = "{0:n0}";
            this.XrLabel17.WordWrap = false;
            // 
            // XrLabel18
            // 
            this.XrLabel18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel18.CanGrow = false;
            this.XrLabel18.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[QtyPerCase]")});
            this.XrLabel18.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(607.9158F, 26.00009F);
            this.XrLabel18.Name = "XrLabel18";
            this.XrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel18.SizeF = new System.Drawing.SizeF(60.74982F, 52.12492F);
            this.XrLabel18.StylePriority.UseBorders = false;
            this.XrLabel18.StylePriority.UseFont = false;
            this.XrLabel18.StylePriority.UseTextAlignment = false;
            this.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel18.WordWrap = false;
            // 
            // XrLabel19
            // 
            this.XrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel19.CanGrow = false;
            this.XrLabel19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Size]")});
            this.XrLabel19.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(547.166F, 26.00009F);
            this.XrLabel19.Name = "XrLabel19";
            this.XrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel19.SizeF = new System.Drawing.SizeF(60.74982F, 52.12492F);
            this.XrLabel19.StylePriority.UseBorders = false;
            this.XrLabel19.StylePriority.UseFont = false;
            this.XrLabel19.StylePriority.UseTextAlignment = false;
            this.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel19.WordWrap = false;
            // 
            // XrLabel20
            // 
            this.XrLabel20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.XrLabel20.CanGrow = false;
            this.XrLabel20.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProName]")});
            this.XrLabel20.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(313.4995F, 26.00006F);
            this.XrLabel20.Name = "XrLabel20";
            this.XrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel20.SizeF = new System.Drawing.SizeF(233.6665F, 26.00006F);
            this.XrLabel20.StylePriority.UseBorders = false;
            this.XrLabel20.StylePriority.UseFont = false;
            this.XrLabel20.StylePriority.UseTextAlignment = false;
            this.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel20.WordWrap = false;
            // 
            // XrLabel21
            // 
            this.XrLabel21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel21.CanGrow = false;
            this.XrLabel21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CaseNumber]")});
            this.XrLabel21.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(208.9997F, 26.00009F);
            this.XrLabel21.Name = "XrLabel21";
            this.XrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel21.SizeF = new System.Drawing.SizeF(104.4998F, 52.00011F);
            this.XrLabel21.StylePriority.UseBorders = false;
            this.XrLabel21.StylePriority.UseFont = false;
            this.XrLabel21.StylePriority.UseTextAlignment = false;
            this.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel21.WordWrap = false;
            // 
            // XrLabel22
            // 
            this.XrLabel22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel22.CanGrow = false;
            this.XrLabel22.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PackNumber]")});
            this.XrLabel22.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(104.4999F, 26.00009F);
            this.XrLabel22.Name = "XrLabel22";
            this.XrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel22.SizeF = new System.Drawing.SizeF(104.4998F, 52.00011F);
            this.XrLabel22.StylePriority.UseBorders = false;
            this.XrLabel22.StylePriority.UseFont = false;
            this.XrLabel22.StylePriority.UseTextAlignment = false;
            this.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel22.WordWrap = false;
            // 
            // XrLabel23
            // 
            this.XrLabel23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel23.CanGrow = false;
            this.XrLabel23.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UnitNumber]")});
            this.XrLabel23.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 26.00009F);
            this.XrLabel23.Name = "XrLabel23";
            this.XrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel23.SizeF = new System.Drawing.SizeF(104.4998F, 52.00005F);
            this.XrLabel23.StylePriority.UseBorders = false;
            this.XrLabel23.StylePriority.UseFont = false;
            this.XrLabel23.StylePriority.UseTextAlignment = false;
            this.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.XrLabel23.WordWrap = false;
            // 
            // XrLabel16
            // 
            this.XrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel16.CanGrow = false;
            this.XrLabel16.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(668.6656F, 0F);
            this.XrLabel16.Name = "XrLabel16";
            this.XrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel16.SizeF = new System.Drawing.SizeF(98.33417F, 26.00006F);
            this.XrLabel16.StylePriority.UseBorders = false;
            this.XrLabel16.StylePriority.UseFont = false;
            this.XrLabel16.StylePriority.UseTextAlignment = false;
            this.XrLabel16.Text = "Stock( Pcs )";
            this.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel16.WordWrap = false;
            // 
            // XrLabel15
            // 
            this.XrLabel15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel15.CanGrow = false;
            this.XrLabel15.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(607.9158F, 0F);
            this.XrLabel15.Name = "XrLabel15";
            this.XrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel15.SizeF = new System.Drawing.SizeF(60.74982F, 26.00006F);
            this.XrLabel15.StylePriority.UseBorders = false;
            this.XrLabel15.StylePriority.UseFont = false;
            this.XrLabel15.StylePriority.UseTextAlignment = false;
            this.XrLabel15.Text = "Q/C";
            this.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel15.WordWrap = false;
            // 
            // XrLabel14
            // 
            this.XrLabel14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel14.CanGrow = false;
            this.XrLabel14.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(547.166F, 0F);
            this.XrLabel14.Name = "XrLabel14";
            this.XrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel14.SizeF = new System.Drawing.SizeF(60.74982F, 26.00006F);
            this.XrLabel14.StylePriority.UseBorders = false;
            this.XrLabel14.StylePriority.UseFont = false;
            this.XrLabel14.StylePriority.UseTextAlignment = false;
            this.XrLabel14.Text = "Size";
            this.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel14.WordWrap = false;
            // 
            // XrLabel13
            // 
            this.XrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel13.CanGrow = false;
            this.XrLabel13.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(313.4995F, 0F);
            this.XrLabel13.Name = "XrLabel13";
            this.XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel13.SizeF = new System.Drawing.SizeF(233.6665F, 26.00006F);
            this.XrLabel13.StylePriority.UseBorders = false;
            this.XrLabel13.StylePriority.UseFont = false;
            this.XrLabel13.StylePriority.UseTextAlignment = false;
            this.XrLabel13.Text = "Product Name";
            this.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel13.WordWrap = false;
            // 
            // XrLabel12
            // 
            this.XrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel12.CanGrow = false;
            this.XrLabel12.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(208.9996F, 1.335144E-05F);
            this.XrLabel12.Name = "XrLabel12";
            this.XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel12.SizeF = new System.Drawing.SizeF(104.4998F, 26.00005F);
            this.XrLabel12.StylePriority.UseBorders = false;
            this.XrLabel12.StylePriority.UseFont = false;
            this.XrLabel12.StylePriority.UseTextAlignment = false;
            this.XrLabel12.Text = "Case Number";
            this.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel12.WordWrap = false;
            // 
            // XrLabel11
            // 
            this.XrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel11.CanGrow = false;
            this.XrLabel11.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(104.4998F, 1.335144E-05F);
            this.XrLabel11.Name = "XrLabel11";
            this.XrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel11.SizeF = new System.Drawing.SizeF(104.4998F, 26.00005F);
            this.XrLabel11.StylePriority.UseBorders = false;
            this.XrLabel11.StylePriority.UseFont = false;
            this.XrLabel11.StylePriority.UseTextAlignment = false;
            this.XrLabel11.Text = "Pack Number";
            this.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel11.WordWrap = false;
            // 
            // XrLabel10
            // 
            this.XrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel10.CanGrow = false;
            this.XrLabel10.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(1.525879E-05F, 0F);
            this.XrLabel10.Name = "XrLabel10";
            this.XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel10.SizeF = new System.Drawing.SizeF(104.4998F, 26.00005F);
            this.XrLabel10.StylePriority.UseBorders = false;
            this.XrLabel10.StylePriority.UseFont = false;
            this.XrLabel10.StylePriority.UseTextAlignment = false;
            this.XrLabel10.Text = "Unit Number";
            this.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel10.WordWrap = false;
            // 
            // XrLabel25
            // 
            this.XrLabel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.XrLabel25.CanGrow = false;
            this.XrLabel25.Font = new System.Drawing.Font("Khmer OS Siemreap", 8F, System.Drawing.FontStyle.Bold);
            this.XrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(2.000061F, 319.9374F);
            this.XrLabel25.Name = "XrLabel25";
            this.XrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel25.SizeF = new System.Drawing.SizeF(766.9999F, 25.00006F);
            this.XrLabel25.StylePriority.UseBackColor = false;
            this.XrLabel25.StylePriority.UseFont = false;
            this.XrLabel25.StylePriority.UseTextAlignment = false;
            this.XrLabel25.Text = "SELECTED ITEM";
            this.XrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrLabel25.WordWrap = false;
            // 
            // XrLabel41
            // 
            this.XrLabel41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.XrLabel41.CanGrow = false;
            this.XrLabel41.Font = new System.Drawing.Font("Khmer OS Siemreap", 8F, System.Drawing.FontStyle.Bold);
            this.XrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(2.000031F, 435.5624F);
            this.XrLabel41.Name = "XrLabel41";
            this.XrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel41.SizeF = new System.Drawing.SizeF(766.9999F, 25.00006F);
            this.XrLabel41.StylePriority.UseBackColor = false;
            this.XrLabel41.StylePriority.UseFont = false;
            this.XrLabel41.StylePriority.UseTextAlignment = false;
            this.XrLabel41.Text = "WAREHOUSE LOCATION";
            this.XrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrLabel41.WordWrap = false;
            // 
            // XrPanel4
            // 
            this.XrPanel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrPanel4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel34,
            this.XrLabel30,
            this.XrLabel27,
            this.XrLabel32,
            this.XrLabel35,
            this.XrLabel37});
            this.XrPanel4.LocationFloat = new DevExpress.Utils.PointFloat(2.000117F, 460.5625F);
            this.XrPanel4.Name = "XrPanel4";
            this.XrPanel4.SizeF = new System.Drawing.SizeF(766.9999F, 26.04166F);
            this.XrPanel4.StylePriority.UseBorders = false;
            // 
            // XrLabel34
            // 
            this.XrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel34.CanGrow = false;
            this.XrLabel34.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(277.7494F, 0.02072652F);
            this.XrLabel34.Name = "XrLabel34";
            this.XrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel34.SizeF = new System.Drawing.SizeF(130.542F, 26.00012F);
            this.XrLabel34.StylePriority.UseBorders = false;
            this.XrLabel34.StylePriority.UseFont = false;
            this.XrLabel34.StylePriority.UseTextAlignment = false;
            this.XrLabel34.Text = "Level";
            this.XrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel34.WordWrap = false;
            // 
            // XrLabel30
            // 
            this.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel30.CanGrow = false;
            this.XrLabel30.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(138.8747F, 0.02077007F);
            this.XrLabel30.Name = "XrLabel30";
            this.XrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel30.SizeF = new System.Drawing.SizeF(138.8747F, 26.00012F);
            this.XrLabel30.StylePriority.UseBorders = false;
            this.XrLabel30.StylePriority.UseFont = false;
            this.XrLabel30.StylePriority.UseTextAlignment = false;
            this.XrLabel30.Text = "Location";
            this.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel30.WordWrap = false;
            // 
            // XrLabel27
            // 
            this.XrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel27.CanGrow = false;
            this.XrLabel27.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.02077007F);
            this.XrLabel27.Name = "XrLabel27";
            this.XrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel27.SizeF = new System.Drawing.SizeF(138.8747F, 26.00012F);
            this.XrLabel27.StylePriority.UseBorders = false;
            this.XrLabel27.StylePriority.UseFont = false;
            this.XrLabel27.StylePriority.UseTextAlignment = false;
            this.XrLabel27.Text = "Building";
            this.XrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel27.WordWrap = false;
            // 
            // XrLabel32
            // 
            this.XrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel32.CanGrow = false;
            this.XrLabel32.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(668.6656F, 0.02072652F);
            this.XrLabel32.Name = "XrLabel32";
            this.XrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel32.SizeF = new System.Drawing.SizeF(98.33411F, 26.00012F);
            this.XrLabel32.StylePriority.UseBorders = false;
            this.XrLabel32.StylePriority.UseFont = false;
            this.XrLabel32.StylePriority.UseTextAlignment = false;
            this.XrLabel32.Text = "Status";
            this.XrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel32.WordWrap = false;
            // 
            // XrLabel35
            // 
            this.XrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel35.CanGrow = false;
            this.XrLabel35.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(547.1661F, 0F);
            this.XrLabel35.Name = "XrLabel35";
            this.XrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel35.SizeF = new System.Drawing.SizeF(121.4996F, 26.00012F);
            this.XrLabel35.StylePriority.UseBorders = false;
            this.XrLabel35.StylePriority.UseFont = false;
            this.XrLabel35.StylePriority.UseTextAlignment = false;
            this.XrLabel35.Text = "Expiry Date";
            this.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel35.WordWrap = false;
            // 
            // XrLabel37
            // 
            this.XrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.XrLabel37.CanGrow = false;
            this.XrLabel37.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(408.2914F, 0F);
            this.XrLabel37.Name = "XrLabel37";
            this.XrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel37.SizeF = new System.Drawing.SizeF(138.8747F, 26.00012F);
            this.XrLabel37.StylePriority.UseBorders = false;
            this.XrLabel37.StylePriority.UseFont = false;
            this.XrLabel37.StylePriority.UseTextAlignment = false;
            this.XrLabel37.Text = "Qty On Hand";
            this.XrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel37.WordWrap = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPageInfo1});
            this.BottomMargin.HeightF = 68.41673F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // XrPageInfo1
            // 
            this.XrPageInfo1.Font = new System.Drawing.Font("Khmer OS Battambang", 7F);
            this.XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(279.7495F, 3.458468F);
            this.XrPageInfo1.Name = "XrPageInfo1";
            this.XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo1.SizeF = new System.Drawing.SizeF(193.6238F, 25F);
            this.XrPageInfo1.StylePriority.UseFont = false;
            this.XrPageInfo1.StylePriority.UseTextAlignment = false;
            this.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrPageInfo1.TextFormatString = "Page {0:n0} of {1:n0}";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // XrCrossBandLine1
            // 
            this.XrCrossBandLine1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.XrCrossBandLine1.EndBand = this.BottomMargin;
            this.XrCrossBandLine1.EndPointFloat = new DevExpress.Utils.PointFloat(141.625F, 2.416644F);
            this.XrCrossBandLine1.Name = "XrCrossBandLine1";
            this.XrCrossBandLine1.StartBand = this.TopMargin;
            this.XrCrossBandLine1.StartPointFloat = new DevExpress.Utils.PointFloat(141.625F, 460.5624F);
            this.XrCrossBandLine1.WidthF = 1.041667F;
            // 
            // XrCrossBandBox1
            // 
            this.XrCrossBandBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.XrCrossBandBox1.BorderWidth = 1F;
            this.XrCrossBandBox1.EndBand = this.BottomMargin;
            this.XrCrossBandBox1.EndPointFloat = new DevExpress.Utils.PointFloat(2.000213F, 3.458438F);
            this.XrCrossBandBox1.Name = "XrCrossBandBox1";
            this.XrCrossBandBox1.StartBand = this.TopMargin;
            this.XrCrossBandBox1.StartPointFloat = new DevExpress.Utils.PointFloat(2.000213F, 461.4583F);
            this.XrCrossBandBox1.WidthF = 766.9996F;
            // 
            // OverCreditNTerm1
            // 
            this.OverCreditNTerm1.DataSource = typeof(DeliveryTakeOrder.Dataset.ExpiryDate);
            this.OverCreditNTerm1.Name = "OverCreditNTerm1";
            // 
            // companyname
            // 
            this.companyname.Description = "companyname";
            this.companyname.Name = "companyname";
            // 
            // companyaddress
            // 
            this.companyaddress.Description = "companyaddress";
            this.companyaddress.Name = "companyaddress";
            // 
            // cusnum
            // 
            this.cusnum.Description = "cusnum";
            this.cusnum.Name = "cusnum";
            // 
            // cusname
            // 
            this.cusname.Description = "cusname";
            this.cusname.Name = "cusname";
            // 
            // currentdate
            // 
            this.currentdate.Description = "currentdate";
            this.currentdate.Name = "currentdate";
            this.currentdate.Type = typeof(System.DateTime);
            // 
            // sExpiryDate
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.OverCreditNTerm1});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.XrCrossBandLine1,
            this.XrCrossBandBox1});
            this.DataSource = this.OverCreditNTerm1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(24, 32, 489, 68);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.companyname,
            this.companyaddress,
            this.cusnum,
            this.cusname,
            this.currentdate});
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.OverCreditNTerm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.XRPanel XrPanel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRPanel XrPanel2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel8;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel7;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel6;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel5;
        internal DevExpress.XtraReports.UI.XRPanel XrPanel3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel24;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel17;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel18;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel19;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel20;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel21;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel22;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel23;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel16;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel15;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel14;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel11;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel25;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel41;
        internal DevExpress.XtraReports.UI.XRPanel XrPanel4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel34;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel30;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel27;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel32;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel35;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel37;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.XRCrossBandLine XrCrossBandLine1;
        internal DevExpress.XtraReports.UI.XRCrossBandBox XrCrossBandBox1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource OverCreditNTerm1;
        private DevExpress.XtraReports.Parameters.Parameter companyname;
        private DevExpress.XtraReports.Parameters.Parameter companyaddress;
        private DevExpress.XtraReports.Parameters.Parameter cusnum;
        private DevExpress.XtraReports.Parameters.Parameter cusname;
        private DevExpress.XtraReports.Parameters.Parameter currentdate;
    }
}
