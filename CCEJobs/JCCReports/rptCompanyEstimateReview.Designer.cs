namespace JCCReports
{
    partial class rptCompanyEstimateReview
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtContractorName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCustomerName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBond = new DevExpress.XtraReports.UI.XRLabel();
            this.txtJobNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEstimator = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOwner = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCustomerClass = new DevExpress.XtraReports.UI.XRLabel();
            this.txtJobStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.txtValue = new DevExpress.XtraReports.UI.XRLabel();
            this.txtJobName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBidDate = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEstimateNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.txtTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCompany = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel125 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.txtContractorName,
            this.txtCustomerName,
            this.txtBond,
            this.txtJobNumber,
            this.txtEstimator,
            this.txtOwner,
            this.txtCustomerClass,
            this.txtJobStatus,
            this.txtValue,
            this.txtJobName,
            this.txtBidDate,
            this.txtEstimateNumber});
            this.Detail.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detail.Height = 17;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.OddStyleName = "xrControlStyle1";
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("EstimateNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.StyleName = "xrControlStyle1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "JOBs.ContractorName", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(542, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(176, 17);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtContractorName
            // 
            this.txtContractorName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.OwnerName", "")});
            this.txtContractorName.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractorName.Location = new System.Drawing.Point(708, 0);
            this.txtContractorName.Name = "txtContractorName";
            this.txtContractorName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtContractorName.ParentStyleUsing.UseFont = false;
            this.txtContractorName.Size = new System.Drawing.Size(2, 17);
            this.txtContractorName.Text = "txtContractorName";
            this.txtContractorName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtContractorName.Visible = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.CustomerName", "")});
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(692, 0);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCustomerName.ParentStyleUsing.UseFont = false;
            this.txtCustomerName.Size = new System.Drawing.Size(2, 17);
            this.txtCustomerName.Text = "txtCustomerName";
            this.txtCustomerName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtCustomerName.Visible = false;
            // 
            // txtBond
            // 
            this.txtBond.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.BidBond", "")});
            this.txtBond.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBond.Location = new System.Drawing.Point(728, 0);
            this.txtBond.Name = "txtBond";
            this.txtBond.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBond.ParentStyleUsing.UseFont = false;
            this.txtBond.Size = new System.Drawing.Size(78, 17);
            this.txtBond.Text = "txtBond";
            this.txtBond.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.JobNumber", "")});
            this.txtJobNumber.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNumber.Location = new System.Drawing.Point(867, 0);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtJobNumber.ParentStyleUsing.UseFont = false;
            this.txtJobNumber.Size = new System.Drawing.Size(36, 17);
            this.txtJobNumber.Text = "txtJobNumber";
            this.txtJobNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtEstimator
            // 
            this.txtEstimator.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.Estimator", "")});
            this.txtEstimator.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimator.Location = new System.Drawing.Point(917, 0);
            this.txtEstimator.Name = "txtEstimator";
            this.txtEstimator.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEstimator.ParentStyleUsing.UseFont = false;
            this.txtEstimator.Size = new System.Drawing.Size(128, 17);
            this.txtEstimator.Text = "txtEstimator";
            this.txtEstimator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtOwner
            // 
            this.txtOwner.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "JOBs.OwnerName", "")});
            this.txtOwner.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwner.Location = new System.Drawing.Point(365, 0);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOwner.ParentStyleUsing.UseFont = false;
            this.txtOwner.Size = new System.Drawing.Size(176, 17);
            this.txtOwner.Text = "txtOwner";
            this.txtOwner.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtOwner.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.txtOwner_BeforePrint);
            // 
            // txtCustomerClass
            // 
            this.txtCustomerClass.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.OwnerClass", "")});
            this.txtCustomerClass.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerClass.Location = new System.Drawing.Point(701, 0);
            this.txtCustomerClass.Name = "txtCustomerClass";
            this.txtCustomerClass.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCustomerClass.ParentStyleUsing.UseFont = false;
            this.txtCustomerClass.Size = new System.Drawing.Size(8, 17);
            this.txtCustomerClass.Text = "txtCustomerClass";
            this.txtCustomerClass.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtCustomerClass.Visible = false;
            // 
            // txtJobStatus
            // 
            this.txtJobStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.JobStatus", "")});
            this.txtJobStatus.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobStatus.Location = new System.Drawing.Point(807, 0);
            this.txtJobStatus.Name = "txtJobStatus";
            this.txtJobStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtJobStatus.ParentStyleUsing.UseFont = false;
            this.txtJobStatus.Size = new System.Drawing.Size(54, 17);
            this.txtJobStatus.Text = "txtJobStatus";
            this.txtJobStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtValue
            // 
            this.txtValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.ApproxValue", "{0:c}")});
            this.txtValue.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(293, 0);
            this.txtValue.Name = "txtValue";
            this.txtValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtValue.ParentStyleUsing.UseFont = false;
            this.txtValue.Size = new System.Drawing.Size(69, 17);
            xrSummary1.FormatString = "{0:c}";
            this.txtValue.Summary = xrSummary1;
            this.txtValue.Text = "txtValue";
            this.txtValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // txtJobName
            // 
            this.txtJobName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.JobName", "")});
            this.txtJobName.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobName.Location = new System.Drawing.Point(116, 0);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtJobName.ParentStyleUsing.UseFont = false;
            this.txtJobName.Size = new System.Drawing.Size(176, 17);
            this.txtJobName.Text = "txtJobName";
            this.txtJobName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtBidDate
            // 
            this.txtBidDate.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.BidDate", "{0:MM/dd/yyyy}")});
            this.txtBidDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBidDate.Location = new System.Drawing.Point(57, 0);
            this.txtBidDate.Name = "txtBidDate";
            this.txtBidDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBidDate.ParentStyleUsing.UseFont = false;
            this.txtBidDate.Size = new System.Drawing.Size(57, 17);
            this.txtBidDate.Text = "txtBidDate";
            this.txtBidDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtEstimateNumber
            // 
            this.txtEstimateNumber.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCCompanyEstimateReviewReport;1.EstimateNumber", "")});
            this.txtEstimateNumber.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimateNumber.Location = new System.Drawing.Point(5, 0);
            this.txtEstimateNumber.Name = "txtEstimateNumber";
            this.txtEstimateNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEstimateNumber.ParentStyleUsing.UseFont = false;
            this.txtEstimateNumber.Size = new System.Drawing.Size(45, 17);
            this.txtEstimateNumber.Text = "txtEstimateNumber";
            this.txtEstimateNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.logo,
            this.xrLine5,
            this.txtTitle,
            this.xrLine1,
            this.xrLine2,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabel27,
            this.xrLabel28,
            this.xrLabel29,
            this.txtCompany});
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel2.Location = new System.Drawing.Point(542, 74);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(143, 17);
            this.xrLabel2.Text = "Contractor";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(0, 8);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(225, 42);
            // 
            // xrLine5
            // 
            this.xrLine5.Location = new System.Drawing.Point(0, 92);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.Size = new System.Drawing.Size(1050, 8);
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Maroon;
            this.txtTitle.Location = new System.Drawing.Point(0, 34);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTitle.ParentStyleUsing.UseFont = false;
            this.txtTitle.ParentStyleUsing.UseForeColor = false;
            this.txtTitle.Size = new System.Drawing.Size(1050, 25);
            this.txtTitle.Text = "Estimate Number Review";
            this.txtTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 66);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(1050, 8);
            // 
            // xrLine2
            // 
            this.xrLine2.Location = new System.Drawing.Point(0, 0);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(1050, 8);
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel21.Location = new System.Drawing.Point(5, 74);
            this.xrLabel21.Multiline = true;
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.ParentStyleUsing.UseForeColor = false;
            this.xrLabel21.Size = new System.Drawing.Size(53, 17);
            this.xrLabel21.Text = "Estimate No.";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel22.Location = new System.Drawing.Point(57, 74);
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.ParentStyleUsing.UseForeColor = false;
            this.xrLabel22.Size = new System.Drawing.Size(49, 17);
            this.xrLabel22.Text = "Bid Date";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel23.Location = new System.Drawing.Point(116, 74);
            this.xrLabel23.Multiline = true;
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.ParentStyleUsing.UseForeColor = false;
            this.xrLabel23.Size = new System.Drawing.Size(126, 17);
            this.xrLabel23.Text = "Project Name";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel24.Location = new System.Drawing.Point(293, 74);
            this.xrLabel24.Multiline = true;
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.ParentStyleUsing.UseForeColor = false;
            this.xrLabel24.Size = new System.Drawing.Size(56, 17);
            this.xrLabel24.Text = "Value";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel25.Location = new System.Drawing.Point(365, 74);
            this.xrLabel25.Multiline = true;
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.ParentStyleUsing.UseForeColor = false;
            this.xrLabel25.Size = new System.Drawing.Size(143, 17);
            this.xrLabel25.Text = "Owner";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel26.Location = new System.Drawing.Point(728, 75);
            this.xrLabel26.Multiline = true;
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.ParentStyleUsing.UseFont = false;
            this.xrLabel26.ParentStyleUsing.UseForeColor = false;
            this.xrLabel26.Size = new System.Drawing.Size(75, 17);
            this.xrLabel26.Text = "Bid Bond";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel27.Location = new System.Drawing.Point(807, 74);
            this.xrLabel27.Multiline = true;
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.ParentStyleUsing.UseFont = false;
            this.xrLabel27.ParentStyleUsing.UseForeColor = false;
            this.xrLabel27.Size = new System.Drawing.Size(54, 17);
            this.xrLabel27.Text = "Bid Status";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel28.Location = new System.Drawing.Point(917, 74);
            this.xrLabel28.Multiline = true;
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.ParentStyleUsing.UseFont = false;
            this.xrLabel28.ParentStyleUsing.UseForeColor = false;
            this.xrLabel28.Size = new System.Drawing.Size(75, 17);
            this.xrLabel28.Text = "Estimator";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel29.Location = new System.Drawing.Point(867, 74);
            this.xrLabel29.Multiline = true;
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.ParentStyleUsing.UseFont = false;
            this.xrLabel29.ParentStyleUsing.UseForeColor = false;
            this.xrLabel29.Size = new System.Drawing.Size(45, 17);
            this.xrLabel29.Text = "Job No.";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.ForeColor = System.Drawing.Color.Maroon;
            this.txtCompany.Location = new System.Drawing.Point(0, 8);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCompany.ParentStyleUsing.UseFont = false;
            this.txtCompany.ParentStyleUsing.UseForeColor = false;
            this.txtCompany.Size = new System.Drawing.Size(1050, 25);
            this.txtCompany.Text = "CONTRA COSTA ELECTRIC, INC.";
            this.txtCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel125
            // 
            this.xrLabel125.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel125.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel125.Location = new System.Drawing.Point(0, 8);
            this.xrLabel125.Multiline = true;
            this.xrLabel125.Name = "xrLabel125";
            this.xrLabel125.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel125.ParentStyleUsing.UseFont = false;
            this.xrLabel125.ParentStyleUsing.UseForeColor = false;
            this.xrLabel125.Size = new System.Drawing.Size(67, 17);
            this.xrLabel125.Text = "Print Date:";
            this.xrLabel125.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrLabel20,
            this.xrPageInfo1,
            this.xrLabel125,
            this.xrLine4});
            this.PageFooter.Height = 26;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.ForeColor = System.Drawing.Color.Maroon;
            this.xrPageInfo2.Location = new System.Drawing.Point(1016, 9);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.ParentStyleUsing.UseForeColor = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(33, 17);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel20.Location = new System.Drawing.Point(983, 8);
            this.xrLabel20.Multiline = true;
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.ParentStyleUsing.UseForeColor = false;
            this.xrLabel20.Size = new System.Drawing.Size(34, 17);
            this.xrLabel20.Text = "Page:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.ForeColor = System.Drawing.Color.Maroon;
            this.xrPageInfo1.Location = new System.Drawing.Point(67, 9);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.ParentStyleUsing.UseForeColor = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(175, 17);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine4
            // 
            this.xrLine4.Location = new System.Drawing.Point(0, 0);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.Size = new System.Drawing.Size(1050, 8);
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.Name = "xrControlStyle1";
            // 
            // rptCompanyEstimateReview
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter});
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel txtCompany;
        private DevExpress.XtraReports.UI.XRLabel txtTitle;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel125;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel txtValue;
        private DevExpress.XtraReports.UI.XRLabel txtJobName;
        private DevExpress.XtraReports.UI.XRLabel txtBidDate;
        private DevExpress.XtraReports.UI.XRLabel txtEstimateNumber;
        private DevExpress.XtraReports.UI.XRLabel txtJobStatus;
        private DevExpress.XtraReports.UI.XRLabel txtOwner;
        private DevExpress.XtraReports.UI.XRLabel txtCustomerClass;
        private DevExpress.XtraReports.UI.XRLabel txtCustomerName;
        private DevExpress.XtraReports.UI.XRLabel txtContractorName;
        private DevExpress.XtraReports.UI.XRLabel txtBond;
        private DevExpress.XtraReports.UI.XRLabel txtJobNumber;
        private DevExpress.XtraReports.UI.XRLabel txtEstimator;
        private DevExpress.XtraReports.UI.XRPictureBox logo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
    }
}
