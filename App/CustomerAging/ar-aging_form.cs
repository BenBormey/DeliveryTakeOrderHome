using DeliveryTakeOrder.Dev;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.App.CustomerAging
{
    public partial class ar_aging_form : PreviewForm
    {

        public ar_aging_form()
        {
            generalCtrl = new general_controller_class();
            InitializeComponent();

            // generalCtrl = new general_controller_class();
            // this.panBoth.BackColor = ColorTranslator.FromHtml("#9A0089");
            // this.panTerm.BackColor = ColorTranslator.FromHtml("#0099BC");
            // this.panCredit.BackColor = ColorTranslator.FromHtml("#E81123");


        }
        private BindingSource bsData = new BindingSource();

        private general_controller_class generalCtrl;

        private List<ARAging> lsData = new List<ARAging>();
        private Panel panel1;
        private Button btnSelectInvoice;
        private Button btnAudit;
        private Button btnHome;
        private Button btnSetRemark;
        private Label label6;
        private Label label4;
        private Label label3;
        private AgingReport xReport;

        public override void LoadReport()
        {
            FillData();
            if (lsData.Count == 0)
            {
                MessageBox.Show("Nop data to show!");
                this.Close();
                return;
            }
            LoadMainReport();

        }
        private void FrmAlertCreditAmount_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void FrmAlertCreditAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                GoHome();
            }

        }

        private void FrmAlertCreditAmount_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
        private void ARAgingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.H)
            {
                GoHome();
            }
        }

        private void GoHome()
        {
            // Logic to go home, like navigating to the home page or resetting the form
        }

        public string CusNum { get; set; }
        //public DataRow DrCustomer { get; set; }
        //public DataRow DrSupplier { get; set; }
        public DataRow DrTeam { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsA { get; set; } = true;

        public bool IsAll { get; set; } = true;
        public bool IsB { get; set; } = true;
        public bool IsC { get; set; } = true;
        public bool IsCurrent { get; set; } = true;
        public bool IsD { get; set; } = true;
        public bool IsE { get; set; } = true;
        public bool IsExcludeZero { get; set; }
        public bool IsIncludeOther { get; set; }

        public bool IsTeam { get; set; } = false;

        public string SupNum { get; set; }





        private void button8_Click(object sender, EventArgs e)
        {
            //XtraTabPage page = tabMain.SelectedTabPage;
            //BindingSource bsDatasource = ((PreviewControl)page.Controls[0]).Datasource;
            //AgingCallcardFilterForm frmFilter = new AgingCallcardFilterForm();

            //frmFilter.FillSortableList<ARAgingDetail>(bsDatasource);
            //frmFilter.ShowDialog(this);

            ////List<ARAgingDetail> lsTmp = frmFilter.GetDatasource<ARAgingDetail>();

            //if (frmFilter.IsCancel)
            //{
            //    lsTmp.ForEach(x => x.IsChecked = true);
            //    return;
            //}

            //List<ARAgingDetail> ls = lsTmp.Where(x => x.IsChecked)
            //                              .Select(y => y.Clone())
            //                              .Cast<ARAgingDetail>()
            //                              .ToList();

            //BindingSource bs = new BindingSource(ls, null);

            //if (page.Name.Contains("All Invoices"))
            //{
            //    NewAllDetailReport(bs, $"Filtered {page.Text}");
            //}
            //else
            //{
            //    NewDetailReport(bs, $"Filtered {page.Text}");
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void ar_aging_form_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectInvoice_Click(object sender, EventArgs e)
        {
            XtraTabPage page = tabMain.SelectedTabPage;
            BindingSource bsDatasource = (BindingSource)((PreviewControl)page.Controls[0]).Datasource;

            AgingCallcardFilterForm frmFilter = new AgingCallcardFilterForm();

            frmFilter.FillSortableList<ARAgingDetail>(bsDatasource);
            frmFilter.ShowDialog(this);

            List<ARAgingDetail> lsTmp = frmFilter.GetDatasource<ARAgingDetail>();

            if (frmFilter.IsCancel)
            {
                lsTmp.ForEach(x => x.IsChecked = true);
                return;
            }

            List<ARAgingDetail> ls = lsTmp.Where(x => x.IsChecked)
                                          .Select(y => y.Clone())
                                          .Cast<ARAgingDetail>()
                                          .ToList();

            BindingSource bs = new BindingSource(ls, null);

            if (page.Name.Contains("All Invoices"))
            {
                //    NewAllDetailReport(bs, $"Filtered {page.Text}");
            }
            else
            {
                NewDetailReport(bs, $"Filtered {page.Text}");
            }
        }
        private void NewAllDatailReport(BindingSource pBs, string pText)
        {

            var rpt = new AgingCallcardAllDetailReport
            {
                Name = $"{DateTime.Now.Ticks} {pText}"
            };

            rpt.DataSource = pBs;
            rpt.paramAsOfDate.Value = this.DueDate;
            PreviewReport(rpt, pText);
        }

        // Method to create Audit Report
        private void NewAuditReport(BindingSource pBs, string pText)
        {
            var rpt = new AgingCallcardAuditReport
            {
                Name = $"{DateTime.Now.Ticks} {pText}"
            };

            rpt.DataSource = pBs;
            rpt.paramAsOfDate.Value = this.DueDate;
            PreviewReport(rpt, pText);
        }

        // Method to create Detail Report
        private void NewDetailReport(BindingSource pBs, string pText)
        {
            ar_aging_report_detail rpt = new ar_aging_report_detail
            {
                Name = $"{DateTime.Now.Ticks} {pText}"
            };

            rpt.DataSource = pBs;
            rpt.paramAsOfDate.Value = this.DueDate;

            rpt.cellInvoiceNumber.PreviewClick += ShowInvoiceDetail;
            rpt.cellGrandTotal.PreviewClick += ShowInvoiceDetail;

            PreviewReport(rpt, pText);
        }

        // Method to preview the report
        private void PreviewReport(XtraReport pReport, string pText)
        {
            var pc = new PreviewControl
            {
                docViewer = { PrintingSystem = pReport.PrintingSystem },
                Datasource = pReport.DataSource
            };

            pReport.CreateDocument(true);

            var page = new XtraTabPage
            {
                Name = pText,
                Text = pText
            };
            page.Controls.Add(pc);

            this.tabMain.TabPages.Add(page);
            page.Show();
        }

        // Method to render a detailed report
        private void RenderDetailReport(ARAging pObjectAging, int pStartAge, int pEndAge)
        {
            ARAging oAge = pObjectAging;
            //   var bs = new BindingSource(GetARAgingDetail(pStartAge, pEndAge, oAge.CusNum), null);
            string text = $"Invoice - {oAge.CusName}";
            //  NewDetailReport(bs, text);
        }

        // Method to show the invoice detail when clicked
        private void ShowInvoiceDetail(object sender, PreviewMouseEventArgs e)
        {
            ARAgingDetail o = (ARAgingDetail)e.Brick.Value;
            var bs = new BindingSource(generalCtrl.GetInvoiceDetail(o.Division, o.InvNumber), null);

            string txt = $"Inv {o.InvNumber}";
            var rpt = new AgingInvoiceDetailReport
            {
                Name = $"{DateTime.Now.Ticks} {txt}",
                DataSource = bs
            };

            PreviewReport(rpt, txt);
        }

        // Method to load the report
        //public override void LoadReport()
        //{
        //    FillData();
        //    if (lsData.Count == 0)
        //    {
        //        MessageBox.Show("No data to show!");
        //        this.Close();
        //        return;
        //    }
        //    LoadMainReport();
        //}


        private void LoadMainReport()
        {
            // Create the report and set its data source
            xReport = new AgingReport { DataSource = bsData };

            // Attach event handlers to various cells for click events


            // Optionally, hide columns if required
            // xReport.cellA.Visible = false;
            // xReport.cellAHead.Visible = false;((AgingReport)this.xReport).cellCurrent.PreviewClick += cellCurrentClick;

            ((AgingReport)this.xReport).cellCurrent.PreviewClick += new PreviewMouseEventHandler(cellCurrentClick);
            ((AgingReport)this.xReport).cellAA.PreviewClick += new PreviewMouseEventHandler(cellAAClick);
            ((AgingReport)this.xReport).cellAB.PreviewClick += new PreviewMouseEventHandler(cellABClick);
            ((AgingReport)this.xReport).cellA.PreviewClick += new PreviewMouseEventHandler(cellAClick);
            ((AgingReport)this.xReport).cellB.PreviewClick += new PreviewMouseEventHandler(cellBClick);
            ((AgingReport)this.xReport).cellC.PreviewClick += new PreviewMouseEventHandler(cellCClick);
            ((AgingReport)this.xReport).cellD.PreviewClick += new PreviewMouseEventHandler(cellDClick);
            ((AgingReport)this.xReport).cellE.PreviewClick += new PreviewMouseEventHandler(cellEClick);
            ((AgingReport)this.xReport).cellTotal.PreviewClick += new PreviewMouseEventHandler(cellTotalClick);
            ((AgingReport)this.xReport).cellCustomer.PreviewClick += new PreviewMouseEventHandler(cellCustomerClick);


            if (!IsAll)
            {
                // Remove columns conditionally based on flags
                if (!IsA)
                {
                    xReport.xtblData.DeleteColumn(xReport.cellA, true);
                    xReport.xtblHeader.DeleteColumn(xReport.cellAHead, true);
                    xReport.xtblSum.DeleteColumn(xReport.cellASum, true);
                }

                if (!IsB)
                {
                    xReport.xtblData.DeleteColumn(xReport.cellB, true);
                    xReport.xtblHeader.DeleteColumn(xReport.cellBHead, true);
                    xReport.xtblSum.DeleteColumn(xReport.cellBSum, true);
                }

                if (!IsC)
                {
                    xReport.xtblData.DeleteColumn(xReport.cellC, true);
                    xReport.xtblHeader.DeleteColumn(xReport.cellCHead, true);
                    xReport.xtblSum.DeleteColumn(xReport.cellCSum, true);
                }

                if (!IsD)
                {
                    xReport.xtblData.DeleteColumn(xReport.cellD, true);
                    xReport.xtblHeader.DeleteColumn(xReport.cellDHead, true);
                    xReport.xtblSum.DeleteColumn(xReport.cellDSum, true);
                }

                if (!IsE)
                {
                    xReport.xtblData.DeleteColumn(xReport.cellE, true);
                    xReport.xtblHeader.DeleteColumn(xReport.CellEHead, true);
                    xReport.xtblSum.DeleteColumn(xReport.cellESum, true);
                }

                // Filter out entries where Total equals zero
                lsData = lsData.Where(x => x.Total != 0).ToList();
                bsData.DataSource = lsData;
            }

            // Set the filter name based on the flag
            string filterName = string.Empty;

            // Optionally set filter for Team or Supplier (commented out in original code)
            // if (IsTeam)
            // {
            //     filterName = string.Format("Team: {0}", DrTeam["TeamName"]);
            // }
            // else
            // {
            //     if (!DrSupplier["SupNum"].Equals("SUP00000"))
            //     {
            //         filterName = string.Format("Supplier: {0}", DrSupplier["SupName"]);
            //     }
            // }

            // Attach event handler for tab page selection change


            // Set parameters for the report
            xReport.RequestParameters = false;
            xReport.paramAsOfDate.Value = this.DueDate;
            xReport.paramFilterName.Value = filterName;

            pcMain.docViewer.PrintingSystem = xReport.PrintingSystem;

            xReport.CreateDocument();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetRemark = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnSelectInvoice = new System.Windows.Forms.Button();
            this.panTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.panel1);
            this.panTitle.Size = new System.Drawing.Size(1034, 44);
            this.panTitle.Controls.SetChildIndex(this.panel1, 0);
            // 
            // pcMain
            // 
            this.pcMain.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pcMain.Appearance.Options.UseFont = true;
            this.pcMain.Size = new System.Drawing.Size(1032, 465);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSetRemark);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnAudit);
            this.panel1.Controls.Add(this.btnSelectInvoice);
            this.panel1.Location = new System.Drawing.Point(252, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 43);
            this.panel1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(634, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Over Term";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(634, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Over Term && Credit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(634, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Over Credit";
            // 
            // btnSetRemark
            // 
            this.btnSetRemark.Location = new System.Drawing.Point(457, 8);
            this.btnSetRemark.Name = "btnSetRemark";
            this.btnSetRemark.Size = new System.Drawing.Size(125, 27);
            this.btnSetRemark.TabIndex = 3;
            this.btnSetRemark.Text = "Set Remark";
            this.btnSetRemark.UseVisualStyleBackColor = true;
            this.btnSetRemark.Click += new System.EventHandler(this.btnSetRemark_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = global::DeliveryTakeOrder.Properties.Resources.house;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(326, 8);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(125, 27);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home (Ctrl + H)";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.Image = global::DeliveryTakeOrder.Properties.Resources.clipboard;
            this.btnAudit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAudit.Location = new System.Drawing.Point(186, 8);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(134, 27);
            this.btnAudit.TabIndex = 1;
            this.btnAudit.Text = "View Audit Form";
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnSelectInvoice
            // 
            this.btnSelectInvoice.Image = global::DeliveryTakeOrder.Properties.Resources.list;
            this.btnSelectInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectInvoice.Location = new System.Drawing.Point(42, 6);
            this.btnSelectInvoice.Name = "btnSelectInvoice";
            this.btnSelectInvoice.Size = new System.Drawing.Size(125, 27);
            this.btnSelectInvoice.TabIndex = 0;
            this.btnSelectInvoice.Text = "Select Invoice";
            this.btnSelectInvoice.UseVisualStyleBackColor = true;
            this.btnSelectInvoice.Click += new System.EventHandler(this.btnSelectInvoice_Click);
            // 
            // ar_aging_form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1034, 558);
            this.Name = "ar_aging_form";
            this.Load += new System.EventHandler(this.ar_aging_form_Load_1);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ar_aging_form_Load_1(object sender, EventArgs e)
        {

        }


        private void FillData()
        {
            string sqlQuery = @" -- {0}
    DECLARE @dueDate DATE
    = GETDATE(),
        @Query NVARCHAR(MAX) = N'',
        @StatementInv NVARCHAR(MAX) = N'',
        @SelectClause NVARCHAR(MAX) = N'
            SELECT  P.InvNumber,
                    P.PONumber,
                    P.ShipDate,
                    P.DelTo,
                    P.GrandTotal,
                    P.PAID,
                    P.CusNum,
                    D.SupNum,
                    D.DeltoId';

SELECT @Query += @SelectClause + N', N''' + D.TableName + N''' AS TableName, N''' + D.Division + N''' AS Division '
                 + N' FROM Stock.dbo.' + D.TableName + ' AS D INNER JOIN Stock.dbo.' + P.TableName
                 + ' AS P ON P.InvNumber = D.InvNumber UNION ALL'
FROM dbo.Sys_AllDetailTables AS D
    INNER JOIN dbo.Sys_AllPaymentTables AS P
        ON P.Paired = D.Paired
WHERE D.TypeValue = 1
      AND D.Division NOT IN ( N'Division8', N'Division8 VAT', N'Division9', N'Division9 VAT', N'Division11',
                              N'Division11 VAT'
                            );

SET @Query = LEFT(@Query, LEN(@Query) - LEN(' UNION ALL '));

SELECT @StatementInv += N'SELECT InvNumber , CusNum, CAST(DateRegister AS DATE) AS StatementDate,''' + Division
                        + ''' AS Division FROM Stock.dbo.' + TableName + N' UNION ALL '
FROM dbo.Sys_AllStatementTables
WHERE TypeValue = 1;

SET @StatementInv = LEFT(@StatementInv, LEN(@StatementInv) - LEN(' UNION ALL '));

SELECT @Query
    = N'
            DECLARE @dueDate DATE = ''' + REPLACE(CONVERT(NVARCHAR(20), @dueDate, 111), '/', '-') + ''';'
      + N'

;WITH vDelivery AS (' + @Query
      + N'),
     vARAging
AS (SELECT D.InvNumber,
           C.CusNum,
           C.CusName,
           CASE
               WHEN C.Status = ''Activate'' THEN
                   C.Terms
               ELSE
                   0
           END AS Terms,
           CASE
               WHEN C.Status = ''Activate'' THEN
                   C.CreditLimit
               ELSE
                   0
           END AS CreditLimit,
           DATEDIFF(DAY, D.ShipDate, @dueDate) AS DaysOver,
           D.GrandTotal AS GrandTotal,
           D.Division
    FROM vDelivery AS D
        LEFT OUTER JOIN Stock.dbo.TPRCustomer AS C
            ON C.CusNum = D.CusNum
        LEFT OUTER JOIN (' + @StatementInv
      + ') AS Stm
            ON Stm.InvNumber = D.InvNumber
               AND Stm.CusNum = C.CusNum
               AND Stm.Division = D.Division
    WHERE D.PAID <> N''PAID''
          AND CONVERT(DATE, D.ShipDate) <= @dueDate
          AND Stm.InvNumber IS NULL
          {2}
    GROUP BY C.CusNum,
             C.CusName,
             C.Terms,
             C.CreditLimit,
             DATEDIFF(DAY, D.ShipDate, @dueDate),
             D.InvNumber,
             D.GrandTotal,
             D.Division,
             C.Status),
     vARAging2
AS (SELECT vARAging.InvNumber,
           vARAging.CusNum,
           vARAging.CusName,
           vARAging.Terms,
           vARAging.CreditLimit,
           CASE
               WHEN vARAging.DaysOver = 0 THEN
                   vARAging.GrandTotal
           END AS [Current],
           CASE
               WHEN vARAging.DaysOver >= 1
                    AND vARAging.DaysOver <= 7 THEN
                   vARAging.GrandTotal
           END AS AA,
           CASE
               WHEN vARAging.DaysOver >= 8
                    AND vARAging.DaysOver <= 15 THEN
                   vARAging.GrandTotal
           END AS AB,
           CASE
               WHEN vARAging.DaysOver >= 16
                    AND vARAging.DaysOver <= 30 THEN
                   vARAging.GrandTotal
           END AS A,
           CASE
               WHEN vARAging.DaysOver >= 31
                    AND vARAging.DaysOver <= 45 THEN
                   vARAging.GrandTotal
           END AS B,
           CASE
               WHEN vARAging.DaysOver >= 46
                    AND vARAging.DaysOver <= 60 THEN
                   vARAging.GrandTotal
           END AS C,
           CASE
               WHEN vARAging.DaysOver >= 61
                    AND vARAging.DaysOver <= 90 THEN
                   vARAging.GrandTotal
           END AS D,
           CASE
               WHEN vARAging.DaysOver > 90 THEN
                   vARAging.GrandTotal
           END AS E,
           CASE
               WHEN vARAging.DaysOver >= 1
                    AND vARAging.DaysOver <= 7 THEN
                   vARAging.DaysOver
           END AS AA_Max,
           CASE
               WHEN vARAging.DaysOver >= 8
                    AND vARAging.DaysOver <= 18 THEN
                   vARAging.DaysOver
           END AS AB_Max,
           CASE
               WHEN vARAging.DaysOver >= 16
                    AND vARAging.DaysOver <= 30 THEN
                   vARAging.DaysOver
           END AS A_Max,
           CASE
               WHEN vARAging.DaysOver >= 31
                    AND vARAging.DaysOver <= 45 THEN
                   vARAging.DaysOver
           END AS B_Max,
           CASE
               WHEN vARAging.DaysOver >= 46
                    AND vARAging.DaysOver <= 60 THEN
                   vARAging.DaysOver
           END AS C_Max,
           CASE
               WHEN vARAging.DaysOver >= 61
                    AND vARAging.DaysOver <= 90 THEN
                   vARAging.DaysOver
           END AS D_Max,
           CASE
               WHEN vARAging.DaysOver > 90 THEN
                   vARAging.DaysOver
           END AS E_Max,
           vARAging.DaysOver
    FROM vARAging)'
      + N'
SELECT	vARAging2.CusNum,
        vARAging2.CusName,
        vARAging2.Terms,
        vARAging2.CreditLimit,
        SUM(ISNULL(vARAging2.[Current], 0)) AS [Current],
        SUM(ISNULL(vARAging2.AA, 0)) AS AA,
        SUM(ISNULL(vARAging2.AB, 0)) AS AB,
        SUM(ISNULL(vARAging2.A, 0)) AS A,
        SUM(ISNULL(vARAging2.B, 0)) AS B,
        SUM(ISNULL(vARAging2.C, 0)) AS C,
        SUM(ISNULL(vARAging2.D, 0)) AS D,
        SUM(ISNULL(vARAging2.E, 0)) AS E,
        CASE WHEN -1 = {3} THEN SUM(ISNULL(vARAging2.A, 0)) + SUM(ISNULL(vARAging2.AA, 0)) + SUM(ISNULL(vARAging2.AB, 0)) ELSE 0 END 
        + CASE WHEN -1 = {4} THEN SUM(ISNULL(vARAging2.B, 0)) ELSE 0 END 
        + CASE WHEN -1 = {5} THEN SUM(ISNULL(vARAging2.C, 0)) ELSE 0 END
        + CASE WHEN -1 = {6} THEN SUM(ISNULL(vARAging2.D, 0)) ELSE 0 END 
        + CASE WHEN -1 = {7} THEN SUM(ISNULL(vARAging2.E, 0)) ELSE 0 END AS Total,
        MAX(ISNULL(vARAging2.AA_Max, 0)) AS AA_Max,
        MAX(ISNULL(vARAging2.AB_Max, 0)) AS AB_Max,
        MAX(ISNULL(vARAging2.A_Max, 0)) AS A_Max,
        MAX(ISNULL(vARAging2.B_Max, 0)) AS B_Max,
        MAX(ISNULL(vARAging2.C_Max, 0)) AS C_Max,
        MAX(ISNULL(vARAging2.D_Max, 0)) AS D_Max,
        MAX(ISNULL(vARAging2.E_Max, 0)) AS E_Max,
        MAX(vARAging2.DaysOver) AS Total_Max
FROM vARAging2
WHERE (
          vARAging2.CusNum = N''{1}''
          OR N''CUS00000'' = N''{1}''
      )
GROUP BY vARAging2.CusName,
         vARAging2.CusNum,
         vARAging2.Terms,
         vARAging2.CreditLimit
ORDER BY vARAging2.CusName';

EXEC (@Query);";
            sqlQuery = string.Format(sqlQuery,
                         RMDB.SqlDate(this.DueDate),
                         this.CusNum,
                         string.Empty,
                         (int)-1,
                         (int)-1,
                         (int)-1,
                         (int)-1,
                         (int)-1);

            lsData = db.GetDataTableToObject<ARAging>(sqlQuery);

            foreach (ARAging oAR in lsData)
            {
                oAR.Remarks = QueryRemark(oAR.CusNum);
            }

            bsData.DataSource = lsData;

        }
        private List<ARAgingRemark> QueryRemark(string pCusNum)
        {
            string sqlQuery = @"
SELECT D.RemarkId,
       D.CusNum,
       D.DateCheck,
       D.Remark,
       D.FollowUpDate,
       D.Terminal,
       D.CreatedAt,
       D.ModifiedAt,
       I.InvNumber
FROM dbo.TblARAgingRemarkDetail AS D
    INNER JOIN dbo.TblARAgingRemarkInvoice AS I
        ON I.RemarkId = D.RemarkId
WHERE D.CusNum = '{0}';";

            sqlQuery = string.Format(sqlQuery, pCusNum);
            List<ARAgingRemark> ls = db.GetDataTableToObject<ARAgingRemark>(sqlQuery);

            if (ls.Count > 0)
            {
                List<ARAgingDetail> lsDetail = GetARAgingDetail(1, int.MaxValue, pCusNum);
                List<ARAgingRemark> lsToRemove = new List<ARAgingRemark>();

                foreach (var o in ls.ToList())
                {
                    var obj = lsDetail.Where(x => x.CusNum.Equals(o.CusNum) && x.InvNumber.ToString().Equals(o.InvNumber));
                    if (!obj.Any())
                    {
                        ls.Remove(o);
                    }
                }
            }

            ls = ls.GroupBy(r => new { r.DateCheck, r.FollowUpDate, r.Remark })
                   .Select(g => new ARAgingRemark
                   {
                       DateCheck = g.Key.DateCheck,
                       FollowUpDate = g.Key.FollowUpDate,
                       Remark = g.Key.Remark
                   })
                   .ToList();

            return ls;
        }

        private List<ARAgingDetail> GetARAgingDetail(int pStartAge, int pEndAge, string pCusNum)
        {
            // Function implementation goes here
            string sqlQuery = @"DECLARE @dueDate DATE
    = GETDATE(),
        @Query NVARCHAR(MAX) = N'',
        @StatementInv NVARCHAR(MAX) = N'',
        @SelectClause NVARCHAR(MAX) = N'
            SELECT  P.InvNumber,
                    P.PONumber,
                    P.ShipDate,
                    P.DueDate,
                    P.DelTo,
                    P.GrandTotal,
                    P.PAID,
                    P.CusNum,
                    D.SupNum,
                    D.DeltoId';

SELECT @Query += @SelectClause + N', N''' + D.TableName + N''' AS TableName, N''' + D.Division + N''' AS Division '
                 + N' FROM Stock.dbo.' + D.TableName + ' AS D INNER JOIN Stock.dbo.' + P.TableName
                 + ' AS P ON P.InvNumber = D.InvNumber UNION ALL'
FROM dbo.Sys_AllDetailTables AS D
    INNER JOIN dbo.Sys_AllPaymentTables AS P
        ON P.Paired = D.Paired
WHERE D.TypeValue = 1
      AND D.Division NOT IN ( N'Division8', N'Division8 VAT', N'Division9', N'Division9 VAT', N'Division11',
                              N'Division11 VAT'
                            );

SET @Query = LEFT(@Query, LEN(@Query) - LEN(' UNION ALL '));

SELECT @StatementInv += N'SELECT InvNumber , CusNum, CAST(DateRegister AS DATE) AS StatementDate,''' + Division
                        + ''' AS Division FROM Stock.dbo.' + TableName + N' UNION ALL '
FROM dbo.Sys_AllStatementTables
WHERE TypeValue = 1;

SET @StatementInv = LEFT(@StatementInv, LEN(@StatementInv) - LEN(' UNION ALL '));

SELECT @Query
    = N'
            DECLARE @dueDate DATE = ''' + REPLACE(CONVERT(NVARCHAR(20), @dueDate, 111), '/', '-')
      + ''';            

;WITH vDelivery AS (' + @Query
      + N'),
     vARAging
AS (SELECT D.InvNumber,
           D.PONumber,
           D.ShipDate,
           D.DueDate,
           C.CusNum,
           C.CusName,
           D.DeltoId,
           T.DelTo,
           DATEDIFF(DAY, D.ShipDate, @dueDate) AS DaysOver,
           D.GrandTotal,
           D.Division
    FROM vDelivery AS D
        LEFT OUTER JOIN Stock.dbo.TPRCustomer AS C
            ON C.CusNum = D.CusNum
        LEFT OUTER JOIN Stock.dbo.TPRDelto AS T
            ON D.DeltoId = T.DefId
        LEFT OUTER JOIN (' + @StatementInv
      + ') AS Stm
            ON Stm.InvNumber = D.InvNumber
               AND Stm.CusNum = C.CusNum
               AND Stm.Division = D.Division
    WHERE D.PAID <> N''PAID''
          AND CONVERT(DATE, D.ShipDate) <= @dueDate
          AND Stm.InvNumber IS NULL
          {4}
    GROUP BY D.InvNumber,
             D.PONumber,
             D.ShipDate,
             D.DueDate,
             C.CusNum,
             C.CusName,
             D.DeltoId,
             T.DelTo,
             DATEDIFF(DAY, D.ShipDate, @dueDate),
             D.GrandTotal,
             D.Division)
SELECT *,
STUFF((
SELECT N'','' + [Type] + N'' = $ '' + REPLACE(convert(nvarchar,cast(sum([CreditLimit]) as money),1), ''.00'', '''') + N'' | Expiry Date: '' + replace(convert(nvarchar,[Expiry],6),N'' '',N''-'')
  FROM [Stock].[dbo].[TPRCustomerBankGarantee] 
  WHERE ([CusId] = vARAging.CusNum)
  group by replace(convert(nvarchar,[Expiry],6),N'' '',N''-'')
      ,[Type]

            FOR XML PATH('''')
         ), 1, 1, '''')[IsBgorLandTitle]
FROM vARAging
WHERE vARAging.DaysOver
      BETWEEN {1} AND {2}
      AND (vARAging.CusNum = N''{3}'' OR N''CUS00000'' = N''{3}'')
ORDER BY vARAging.DaysOver DESC, vARAging.InvNumber';

EXEC (@Query);";
            string sqlFilterSupplier = string.Empty;

            sqlQuery = string.Format(sqlQuery,
                                    RMDB.SqlDate(this.DueDate),  // Call the SqlDate method with the parameter
                                    pStartAge,
                                    pEndAge,
                                    pCusNum,
                                    sqlFilterSupplier);


            List<ARAgingDetail> lsAgingDetail = db.GetDataTableToObject<ARAgingDetail>(sqlQuery);
            return lsAgingDetail;

        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            XtraTabPage page = this.tabMain.SelectedTabPage;
            BindingSource bsDatasource = (BindingSource)((PreviewControl)page.Controls[0]).Datasource;
            NewAuditReport(bsDatasource, string.Format("Audit Form {0}", page.Text.Replace("Invoice", string.Empty)));

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GoHome();
        }
        private void cellAAClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 1, 7);
        }

        private void cellABClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 8, 15);
        }

        private void cellAClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 16, 30);
        }

        private void cellBClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 31, 45);
        }

        private void cellCClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 46, 60);
        }

        private void cellCurrentClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 0, 0);
        }

        private void cellCustomerClick(object sender, PreviewMouseEventArgs e)
        {
            ARAging oAge = (ARAging)e.Brick.Value;
            ar_aging frm = new ar_aging(oAge.CusNum, this.DueDate);
            if (frm.IsClose) return;
            frm.ShowDialog(this.MdiParent);
        }

        private void cellDClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 61, 90);
        }

        private void cellEClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 91, int.MaxValue);
        }

        private void cellTotalClick(object sender, PreviewMouseEventArgs e)
        {
            RenderDetailReport((ARAging)e.Brick.Value, 1, int.MaxValue);
        }

        private void btnSetRemark_Click(object sender, EventArgs e)
        {

        }
    }

}