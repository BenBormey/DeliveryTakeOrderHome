
namespace DeliveryTakeOrder.Reports
{
    partial class XtraPODutchmills
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
            DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo objectConstructorInfo1 = new DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.XrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.XrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.lbltitle = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.PODutchmill = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.companyname = new DevExpress.XtraReports.Parameters.Parameter();
            this.companyaddress = new DevExpress.XtraReports.Parameters.Parameter();
            this.planningorder = new DevExpress.XtraReports.Parameters.Parameter();
            this.planningdate = new DevExpress.XtraReports.Parameters.Parameter();
            this.shipmentdate = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PODutchmill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPanel1});
            this.TopMargin.HeightF = 148.75F;
            this.TopMargin.Name = "TopMargin";
            // 
            // XrPanel1
            // 
            this.XrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel1,
            this.XrLabel2});
            this.XrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.XrPanel1.Name = "XrPanel1";
            this.XrPanel1.SizeF = new System.Drawing.SizeF(835.0001F, 136.5F);
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
            this.XrLabel1.SizeF = new System.Drawing.SizeF(835F, 66.66669F);
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
            this.XrLabel2.SizeF = new System.Drawing.SizeF(835.0001F, 69.79166F);
            this.XrLabel2.StylePriority.UseFont = false;
            this.XrLabel2.StylePriority.UseTextAlignment = false;
            this.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrTable1});
            this.Detail.Name = "Detail";
            // 
            // XrTable1
            // 
            this.XrTable1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.XrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrTable1.Name = "XrTable1";
            this.XrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow1});
            this.XrTable1.SizeF = new System.Drawing.SizeF(835.0001F, 21.875F);
            this.XrTable1.StylePriority.UseBorderColor = false;
            this.XrTable1.StylePriority.UseBorders = false;
            // 
            // XrTableRow1
            // 
            this.XrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell1,
            this.XrTableCell2,
            this.XrTableCell3,
            this.XrTableCell5,
            this.XrTableCell4,
            this.XrTableCell6,
            this.XrTableCell7,
            this.XrTableCell8,
            this.XrTableCell9,
            this.XrTableCell10});
            this.XrTableRow1.Name = "XrTableRow1";
            this.XrTableRow1.Weight = 1D;
            // 
            // XrTableCell1
            // 
            this.XrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Barcode]")});
            this.XrTableCell1.Name = "XrTableCell1";
            this.XrTableCell1.Weight = 1.0444034903384407D;
            this.XrTableCell1.WordWrap = false;
            // 
            // XrTableCell2
            // 
            this.XrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProName]")});
            this.XrTableCell2.Name = "XrTableCell2";
            this.XrTableCell2.Weight = 2.5199710543234866D;
            this.XrTableCell2.WordWrap = false;
            // 
            // XrTableCell3
            // 
            this.XrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Remark]")});
            this.XrTableCell3.Name = "XrTableCell3";
            this.XrTableCell3.Weight = 0.52222217459832643D;
            this.XrTableCell3.WordWrap = false;
            // 
            // XrTableCell5
            // 
            this.XrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Size]")});
            this.XrTableCell5.Name = "XrTableCell5";
            this.XrTableCell5.Weight = 0.52319884075590162D;
            this.XrTableCell5.WordWrap = false;
            // 
            // XrTableCell4
            // 
            this.XrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[QtyPCase]")});
            this.XrTableCell4.Name = "XrTableCell4";
            this.XrTableCell4.StylePriority.UseTextAlignment = false;
            this.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell4.Weight = 0.39020443998384446D;
            this.XrTableCell4.WordWrap = false;
            // 
            // XrTableCell6
            // 
            this.XrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalOrder]")});
            this.XrTableCell6.Name = "XrTableCell6";
            this.XrTableCell6.StylePriority.UseTextAlignment = false;
            this.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.XrTableCell6.TextFormatString = "{0:#,##0}";
            this.XrTableCell6.Weight = 0.532488723056316D;
            this.XrTableCell6.WordWrap = false;
            // 
            // XrTableCell7
            // 
            this.XrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PiecesPerTray]")});
            this.XrTableCell7.Name = "XrTableCell7";
            this.XrTableCell7.StylePriority.UseTextAlignment = false;
            this.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell7.TextFormatString = "{0:#,##0}";
            this.XrTableCell7.Weight = 0.555968906811363D;
            this.XrTableCell7.WordWrap = false;
            // 
            // XrTableCell8
            // 
            this.XrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalExtraLeft]")});
            this.XrTableCell8.Name = "XrTableCell8";
            this.XrTableCell8.StylePriority.UseTextAlignment = false;
            this.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell8.TextFormatString = "{0:#,##0}";
            this.XrTableCell8.Weight = 0.55596886162355874D;
            this.XrTableCell8.WordWrap = false;
            // 
            // XrTableCell9
            // 
            this.XrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalOrderToThailand]")});
            this.XrTableCell9.Name = "XrTableCell9";
            this.XrTableCell9.StylePriority.UseTextAlignment = false;
            this.XrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.XrTableCell9.TextFormatString = "{0:#,##0}";
            this.XrTableCell9.Weight = 0.57584804632059361D;
            this.XrTableCell9.WordWrap = false;
            // 
            // XrTableCell10
            // 
            this.XrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalTray]")});
            this.XrTableCell10.Name = "XrTableCell10";
            this.XrTableCell10.StylePriority.UseTextAlignment = false;
            this.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.XrTableCell10.TextFormatString = "{0:#,##0}";
            this.XrTableCell10.Weight = 0.75813958235772261D;
            this.XrTableCell10.WordWrap = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbltitle,
            this.XrLabel4,
            this.XrTable2,
            this.XrLabel3});
            this.GroupHeader1.HeightF = 209.3752F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // lbltitle
            // 
            this.lbltitle.CanGrow = false;
            this.lbltitle.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PromotionMachanic]")});
            this.lbltitle.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.lbltitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbltitle.SizeF = new System.Drawing.SizeF(835.0001F, 25.00006F);
            this.lbltitle.StylePriority.UseFont = false;
            this.lbltitle.StylePriority.UseTextAlignment = false;
            this.lbltitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbltitle.WordWrap = false;
            // 
            // XrLabel4
            // 
            this.XrLabel4.CanGrow = false;
            this.XrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[planningdate]")});
            this.XrLabel4.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25.00013F);
            this.XrLabel4.Name = "XrLabel4";
            this.XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel4.SizeF = new System.Drawing.SizeF(835.0001F, 25.00006F);
            this.XrLabel4.StylePriority.UseFont = false;
            this.XrLabel4.StylePriority.UseTextAlignment = false;
            this.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel4.TextFormatString = "Export Date : {0:dd-MMM-yyyy hh:mm:ss tt}";
            this.XrLabel4.WordWrap = false;
            // 
            // XrTable2
            // 
            this.XrTable2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.XrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75.00025F);
            this.XrTable2.Name = "XrTable2";
            this.XrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow2});
            this.XrTable2.SizeF = new System.Drawing.SizeF(835.0001F, 134.375F);
            this.XrTable2.StylePriority.UseBorderColor = false;
            this.XrTable2.StylePriority.UseBorders = false;
            // 
            // XrTableRow2
            // 
            this.XrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell11,
            this.XrTableCell12,
            this.XrTableCell13,
            this.XrTableCell14,
            this.XrTableCell15,
            this.XrTableCell16,
            this.XrTableCell17,
            this.XrTableCell18,
            this.XrTableCell19,
            this.XrTableCell20});
            this.XrTableRow2.Name = "XrTableRow2";
            this.XrTableRow2.Weight = 1D;
            // 
            // XrTableCell11
            // 
            this.XrTableCell11.Angle = -270F;
            this.XrTableCell11.Name = "XrTableCell11";
            this.XrTableCell11.StylePriority.UseTextAlignment = false;
            this.XrTableCell11.Text = "()";
            this.XrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell11.Weight = 1.0444034903384407D;
            this.XrTableCell11.WordWrap = false;
            // 
            // XrTableCell12
            // 
            this.XrTableCell12.Angle = -270F;
            this.XrTableCell12.Name = "XrTableCell12";
            this.XrTableCell12.StylePriority.UseTextAlignment = false;
            this.XrTableCell12.Text = "Description";
            this.XrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell12.Weight = 2.5199710543234866D;
            this.XrTableCell12.WordWrap = false;
            // 
            // XrTableCell13
            // 
            this.XrTableCell13.Angle = -270F;
            this.XrTableCell13.Name = "XrTableCell13";
            this.XrTableCell13.StylePriority.UseTextAlignment = false;
            this.XrTableCell13.Text = "Remark";
            this.XrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell13.Weight = 0.52222217459832643D;
            this.XrTableCell13.WordWrap = false;
            // 
            // XrTableCell14
            // 
            this.XrTableCell14.Angle = -270F;
            this.XrTableCell14.Name = "XrTableCell14";
            this.XrTableCell14.StylePriority.UseTextAlignment = false;
            this.XrTableCell14.Text = "Size";
            this.XrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell14.Weight = 0.52319884075590162D;
            this.XrTableCell14.WordWrap = false;
            // 
            // XrTableCell15
            // 
            this.XrTableCell15.Angle = -270F;
            this.XrTableCell15.Name = "XrTableCell15";
            this.XrTableCell15.StylePriority.UseTextAlignment = false;
            this.XrTableCell15.Text = "Q/C";
            this.XrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell15.Weight = 0.39020443998384446D;
            this.XrTableCell15.WordWrap = false;
            // 
            // XrTableCell16
            // 
            this.XrTableCell16.Angle = -270F;
            this.XrTableCell16.Name = "XrTableCell16";
            this.XrTableCell16.StylePriority.UseTextAlignment = false;
            this.XrTableCell16.Text = "Total Order";
            this.XrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell16.Weight = 0.532488723056316D;
            this.XrTableCell16.WordWrap = false;
            // 
            // XrTableCell17
            // 
            this.XrTableCell17.Angle = -270F;
            this.XrTableCell17.Name = "XrTableCell17";
            this.XrTableCell17.StylePriority.UseTextAlignment = false;
            this.XrTableCell17.Text = "Pieces Per Tray";
            this.XrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell17.Weight = 0.555968906811363D;
            this.XrTableCell17.WordWrap = false;
            // 
            // XrTableCell18
            // 
            this.XrTableCell18.Angle = -270F;
            this.XrTableCell18.Name = "XrTableCell18";
            this.XrTableCell18.StylePriority.UseTextAlignment = false;
            this.XrTableCell18.Text = "Total Extra/Left";
            this.XrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell18.Weight = 0.55596886162355874D;
            this.XrTableCell18.WordWrap = false;
            // 
            // XrTableCell19
            // 
            this.XrTableCell19.Angle = -270F;
            this.XrTableCell19.Name = "XrTableCell19";
            this.XrTableCell19.StylePriority.UseTextAlignment = false;
            this.XrTableCell19.Text = "Total Order To Thailand";
            this.XrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell19.Weight = 0.57584804632059361D;
            this.XrTableCell19.WordWrap = false;
            // 
            // XrTableCell20
            // 
            this.XrTableCell20.Angle = -270F;
            this.XrTableCell20.Name = "XrTableCell20";
            this.XrTableCell20.StylePriority.UseTextAlignment = false;
            this.XrTableCell20.Text = "Total Tray";
            this.XrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.XrTableCell20.Weight = 0.75813958235772261D;
            this.XrTableCell20.WordWrap = false;
            // 
            // XrLabel3
            // 
            this.XrLabel3.CanGrow = false;
            this.XrLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[shipmentdate]")});
            this.XrLabel3.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50.00026F);
            this.XrLabel3.Name = "XrLabel3";
            this.XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel3.SizeF = new System.Drawing.SizeF(835.0001F, 25.00006F);
            this.XrLabel3.StylePriority.UseFont = false;
            this.XrLabel3.StylePriority.UseTextAlignment = false;
            this.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrLabel3.TextFormatString = "Shipment Date : {0:dd-MMM-yyyy}";
            this.XrLabel3.WordWrap = false;
            // 
            // PODutchmill
            // 
            this.PODutchmill.Constructor = objectConstructorInfo1;
            this.PODutchmill.DataMember = "";
            this.PODutchmill.DataSource = typeof(DeliveryTakeOrder.Dataset.PODutchmill);
            this.PODutchmill.Name = "PODutchmill";
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
            // planningorder
            // 
            this.planningorder.Description = "planningorder";
            this.planningorder.Name = "planningorder";
            // 
            // planningdate
            // 
            this.planningdate.Name = "planningdate";
            this.planningdate.Type = typeof(System.DateTime);
            // 
            // shipmentdate
            // 
            this.shipmentdate.Description = "shipmentdate";
            this.shipmentdate.Name = "shipmentdate";
            this.shipmentdate.Type = typeof(System.DateTime);
            // 
            // XtraPODutchmills
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.PODutchmill});
            this.DataSource = this.PODutchmill;
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(7, 8, 149, 0);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.companyname,
            this.companyaddress,
            this.planningorder,
            this.planningdate,
            this.shipmentdate});
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PODutchmill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.XRPanel XrPanel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRTable XrTable1;
        internal DevExpress.XtraReports.UI.XRTableRow XrTableRow1;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell1;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell2;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell3;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell5;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell4;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell6;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell7;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell8;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell9;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell10;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRLabel lbltitle;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRTable XrTable2;
        internal DevExpress.XtraReports.UI.XRTableRow XrTableRow2;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell11;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell12;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell13;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell14;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell15;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell16;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell17;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell18;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell19;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell20;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource PODutchmill;
        private DevExpress.XtraReports.Parameters.Parameter companyname;
        private DevExpress.XtraReports.Parameters.Parameter companyaddress;
        private DevExpress.XtraReports.Parameters.Parameter planningorder;
        private DevExpress.XtraReports.Parameters.Parameter planningdate;
        private DevExpress.XtraReports.Parameters.Parameter shipmentdate;
    }
}
