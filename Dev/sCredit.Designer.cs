
namespace DeliveryTakeOrder.Dev
{
    partial class sCredit
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.OverCreditNTerm1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.XrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.companyname = new DevExpress.XtraReports.Parameters.Parameter();
            this.companyaddress = new DevExpress.XtraReports.Parameters.Parameter();
            this.currentdate = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.OverCreditNTerm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // OverCreditNTerm1
            // 
            this.OverCreditNTerm1.DataSource = typeof(DeliveryTakeOrder.Dataset.OverCreditNTerm);
            this.OverCreditNTerm1.Name = "OverCreditNTerm1";
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel4,
            this.XrLabel3,
            this.XrLine1,
            this.XrPanel1,
            this.XrTable2});
            this.TopMargin.HeightF = 239.0416F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPageInfo1});
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrTable1});
            this.Detail.HeightF = 24.50002F;
            this.Detail.Name = "Detail";
            // 
            // XrLabel4
            // 
            this.XrLabel4.CanGrow = false;
            this.XrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[currentdate]")});
            this.XrLabel4.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(4.500061F, 180.2917F);
            this.XrLabel4.Name = "XrLabel4";
            this.XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel4.SizeF = new System.Drawing.SizeF(766.9999F, 25.00006F);
            this.XrLabel4.StylePriority.UseFont = false;
            this.XrLabel4.StylePriority.UseTextAlignment = false;
            this.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel4.TextFormatString = "Export Date : {0:dd-MMM-yyyy hh:mm:ss tt}";
            this.XrLabel4.WordWrap = false;
            // 
            // XrLabel3
            // 
            this.XrLabel3.CanGrow = false;
            this.XrLabel3.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(4.500062F, 155.2916F);
            this.XrLabel3.Name = "XrLabel3";
            this.XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel3.SizeF = new System.Drawing.SizeF(766.9999F, 25.00006F);
            this.XrLabel3.StylePriority.UseFont = false;
            this.XrLabel3.StylePriority.UseTextAlignment = false;
            this.XrLabel3.Text = "CREDIT AMOUNT REPORT";
            this.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel3.WordWrap = false;
            // 
            // XrLine1
            // 
            this.XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(4.500061F, 146.5F);
            this.XrLine1.Name = "XrLine1";
            this.XrLine1.SizeF = new System.Drawing.SizeF(766.9999F, 8.791656F);
            // 
            // XrPanel1
            // 
            this.XrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel1,
            this.XrLabel2});
            this.XrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(4.500061F, 10F);
            this.XrPanel1.Name = "XrPanel1";
            this.XrPanel1.SizeF = new System.Drawing.SizeF(766.9999F, 136.5F);
            // 
            // XrLabel1
            // 
            this.XrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[companyaddress]")});
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
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[companyname]")});
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
            // XrTable2
            // 
            this.XrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable2.LocationFloat = new DevExpress.Utils.PointFloat(4.500165F, 218.2918F);
            this.XrTable2.Name = "XrTable2";
            this.XrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow2});
            this.XrTable2.SizeF = new System.Drawing.SizeF(766.9998F, 19.79167F);
            this.XrTable2.StylePriority.UseBorders = false;
            // 
            // XrTableRow2
            // 
            this.XrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell9,
            this.XrTableCell10,
            this.XrTableCell11,
            this.XrTableCell13,
            this.XrTableCell14,
            this.XrTableCell15,
            this.XrTableCell16,
            this.XrTableCell12,
            this.XrTableCell17,
            this.XrTableCell18});
            this.XrTableRow2.Name = "XrTableRow2";
            this.XrTableRow2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.XrTableRow2.StylePriority.UsePadding = false;
            this.XrTableRow2.StylePriority.UseTextAlignment = false;
            this.XrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrTableRow2.Weight = 1D;
            // 
            // XrTableCell9
            // 
            this.XrTableCell9.CanGrow = false;
            this.XrTableCell9.Name = "XrTableCell9";
            this.XrTableCell9.Text = "No.";
            this.XrTableCell9.Weight = 0.40983591647147921D;
            this.XrTableCell9.WordWrap = false;
            // 
            // XrTableCell10
            // 
            this.XrTableCell10.CanGrow = false;
            this.XrTableCell10.Name = "XrTableCell10";
            this.XrTableCell10.Text = "Customer #";
            this.XrTableCell10.Weight = 0.80327878891029114D;
            this.XrTableCell10.WordWrap = false;
            // 
            // XrTableCell11
            // 
            this.XrTableCell11.CanGrow = false;
            this.XrTableCell11.Name = "XrTableCell11";
            this.XrTableCell11.Text = "Customer Name";
            this.XrTableCell11.Weight = 2.0081963993995773D;
            this.XrTableCell11.WordWrap = false;
            // 
            // XrTableCell13
            // 
            this.XrTableCell13.CanGrow = false;
            this.XrTableCell13.Name = "XrTableCell13";
            this.XrTableCell13.Text = "Owe Amount";
            this.XrTableCell13.Weight = 0.84360572168632442D;
            this.XrTableCell13.WordWrap = false;
            // 
            // XrTableCell14
            // 
            this.XrTableCell14.CanGrow = false;
            this.XrTableCell14.Name = "XrTableCell14";
            this.XrTableCell14.Text = "Credit Amount";
            this.XrTableCell14.Weight = 0.87892659005947926D;
            this.XrTableCell14.WordWrap = false;
            // 
            // XrTableCell15
            // 
            this.XrTableCell15.CanGrow = false;
            this.XrTableCell15.Name = "XrTableCell15";
            this.XrTableCell15.Text = "Credit Allow";
            this.XrTableCell15.Weight = 0.72541112516589834D;
            this.XrTableCell15.WordWrap = false;
            // 
            // XrTableCell16
            // 
            this.XrTableCell16.CanGrow = false;
            this.XrTableCell16.Name = "XrTableCell16";
            this.XrTableCell16.Text = "Term";
            this.XrTableCell16.Weight = 0.49812165148820631D;
            this.XrTableCell16.WordWrap = false;
            // 
            // XrTableCell12
            // 
            this.XrTableCell12.CanGrow = false;
            this.XrTableCell12.Name = "XrTableCell12";
            this.XrTableCell12.Text = "Term Allow";
            this.XrTableCell12.Weight = 0.72606751073224074D;
            this.XrTableCell12.WordWrap = false;
            // 
            // XrTableCell17
            // 
            this.XrTableCell17.CanGrow = false;
            this.XrTableCell17.Name = "XrTableCell17";
            this.XrTableCell17.Text = "Latest Inv.";
            this.XrTableCell17.Weight = 0.73835995340633653D;
            this.XrTableCell17.WordWrap = false;
            // 
            // XrTableCell18
            // 
            this.XrTableCell18.CanGrow = false;
            this.XrTableCell18.Name = "XrTableCell18";
            this.XrTableCell18.Text = "Over Credit Amount";
            this.XrTableCell18.Weight = 1.421309856285639D;
            this.XrTableCell18.WordWrap = false;
            // 
            // XrTable1
            // 
            this.XrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable1.LocationFloat = new DevExpress.Utils.PointFloat(4.500166F, 0F);
            this.XrTable1.Name = "XrTable1";
            this.XrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow1});
            this.XrTable1.SizeF = new System.Drawing.SizeF(766.9997F, 23.95833F);
            this.XrTable1.StylePriority.UseBorders = false;
            // 
            // XrTableRow1
            // 
            this.XrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell1,
            this.XrTableCell2,
            this.XrTableCell3,
            this.XrTableCell4,
            this.XrTableCell5,
            this.XrTableCell6,
            this.XrTableCell7,
            this.XrTableCell8,
            this.XrTableCell19,
            this.XrTableCell20});
            this.XrTableRow1.Name = "XrTableRow1";
            this.XrTableRow1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.XrTableRow1.StylePriority.UsePadding = false;
            this.XrTableRow1.Weight = 1D;
            // 
            // XrTableCell1
            // 
            this.XrTableCell1.CanGrow = false;
            this.XrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber([CusNum])")});
            this.XrTableCell1.Name = "XrTableCell1";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.XrTableCell1.Summary = xrSummary1;
            this.XrTableCell1.Weight = 0.40690103447478387D;
            this.XrTableCell1.WordWrap = false;
            // 
            // XrTableCell2
            // 
            this.XrTableCell2.CanGrow = false;
            this.XrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CusNum]")});
            this.XrTableCell2.Name = "XrTableCell2";
            this.XrTableCell2.Text = "XrTableCell2";
            this.XrTableCell2.Weight = 0.79752604068360355D;
            this.XrTableCell2.WordWrap = false;
            // 
            // XrTableCell3
            // 
            this.XrTableCell3.CanGrow = false;
            this.XrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CusName]")});
            this.XrTableCell3.Name = "XrTableCell3";
            this.XrTableCell3.Text = "XrTableCell3";
            this.XrTableCell3.Weight = 1.9938156083486909D;
            this.XrTableCell3.WordWrap = false;
            // 
            // XrTableCell4
            // 
            this.XrTableCell4.CanGrow = false;
            this.XrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GrandTotal]")});
            this.XrTableCell4.Name = "XrTableCell4";
            this.XrTableCell4.StylePriority.UseTextAlignment = false;
            this.XrTableCell4.Text = "XrTableCell4";
            this.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.XrTableCell4.TextFormatString = "{0:c2}";
            this.XrTableCell4.Weight = 0.8375644634423508D;
            this.XrTableCell4.WordWrap = false;
            // 
            // XrTableCell5
            // 
            this.XrTableCell5.CanGrow = false;
            this.XrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CreditLimit]")});
            this.XrTableCell5.Name = "XrTableCell5";
            this.XrTableCell5.StylePriority.UseTextAlignment = false;
            this.XrTableCell5.Text = "XrTableCell5";
            this.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.XrTableCell5.TextFormatString = "{0:c2}";
            this.XrTableCell5.Weight = 0.872632393293537D;
            this.XrTableCell5.WordWrap = false;
            // 
            // XrTableCell6
            // 
            this.XrTableCell6.CanGrow = false;
            this.XrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CreditLimitAllow]")});
            this.XrTableCell6.Name = "XrTableCell6";
            this.XrTableCell6.StylePriority.UseTextAlignment = false;
            this.XrTableCell6.Text = "XrTableCell6";
            this.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.XrTableCell6.TextFormatString = "{0:c2}";
            this.XrTableCell6.Weight = 0.72021598427136113D;
            this.XrTableCell6.WordWrap = false;
            // 
            // XrTableCell7
            // 
            this.XrTableCell7.CanGrow = false;
            this.XrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Terms]")});
            this.XrTableCell7.Name = "XrTableCell7";
            this.XrTableCell7.StylePriority.UseTextAlignment = false;
            this.XrTableCell7.Text = "XrTableCell7";
            this.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell7.Weight = 0.49455378236523562D;
            this.XrTableCell7.WordWrap = false;
            // 
            // XrTableCell8
            // 
            this.XrTableCell8.CanGrow = false;
            this.XrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MaxMonthAllow]")});
            this.XrTableCell8.Name = "XrTableCell8";
            this.XrTableCell8.StylePriority.UseTextAlignment = false;
            this.XrTableCell8.Text = "XrTableCell8";
            this.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell8.Weight = 0.7208693706470215D;
            this.XrTableCell8.WordWrap = false;
            // 
            // XrTableCell19
            // 
            this.XrTableCell19.CanGrow = false;
            this.XrTableCell19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[LatestInvoice]")});
            this.XrTableCell19.Name = "XrTableCell19";
            this.XrTableCell19.StylePriority.UseTextAlignment = false;
            this.XrTableCell19.Text = "XrTableCell19";
            this.XrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell19.Weight = 0.73307110193216873D;
            this.XrTableCell19.WordWrap = false;
            // 
            // XrTableCell20
            // 
            this.XrTableCell20.CanGrow = false;
            this.XrTableCell20.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OverCredit]")});
            this.XrTableCell20.Name = "XrTableCell20";
            this.XrTableCell20.StylePriority.UseTextAlignment = false;
            this.XrTableCell20.Text = "XrTableCell20";
            this.XrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.XrTableCell20.TextFormatString = "{0:c2}";
            this.XrTableCell20.Weight = 1.4111316807780523D;
            this.XrTableCell20.WordWrap = false;
            // 
            // XrPageInfo1
            // 
            this.XrPageInfo1.Font = new System.Drawing.Font("Khmer OS Battambang", 7F);
            this.XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(291.1881F, 23.33333F);
            this.XrPageInfo1.Name = "XrPageInfo1";
            this.XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo1.SizeF = new System.Drawing.SizeF(193.6238F, 16.66667F);
            this.XrPageInfo1.StylePriority.UseFont = false;
            this.XrPageInfo1.StylePriority.UseTextAlignment = false;
            this.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrPageInfo1.TextFormatString = "Page {0:n0} of {1:n0}";
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
            // currentdate
            // 
            this.currentdate.Description = "currentdate";
            this.currentdate.Name = "currentdate";
            this.currentdate.Type = typeof(System.DateTime);
            // 
            // sCredit
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.OverCreditNTerm1});
            this.DataMember = "dtOverCredit";
            this.DataSource = this.OverCreditNTerm1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(24, 27, 239, 50);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.companyname,
            this.companyaddress,
            this.currentdate});
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.OverCreditNTerm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.DataAccess.ObjectBinding.ObjectDataSource OverCreditNTerm1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRPanel XrPanel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRTable XrTable2;
        internal DevExpress.XtraReports.UI.XRTableRow XrTableRow2;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell9;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell10;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell11;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell13;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell14;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell15;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell16;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell12;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell17;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell18;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRTable XrTable1;
        internal DevExpress.XtraReports.UI.XRTableRow XrTableRow1;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell1;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell2;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell3;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell4;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell5;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell6;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell7;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell8;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell19;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell20;
        private DevExpress.XtraReports.Parameters.Parameter companyname;
        private DevExpress.XtraReports.Parameters.Parameter companyaddress;
        private DevExpress.XtraReports.Parameters.Parameter currentdate;
    }
}
