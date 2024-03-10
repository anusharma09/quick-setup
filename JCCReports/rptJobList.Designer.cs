namespace JCCReports
{
    partial class rptJobList
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
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.txtProjectManager = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDepartment = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPhone = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCustomer = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEstimator = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOffice = new DevExpress.XtraReports.UI.XRLabel();
            this.txtContractType = new DevExpress.XtraReports.UI.XRLabel();
            this.txtJobName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBidDate = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEstimateNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtProjectManager,
            this.txtDepartment,
            this.txtPhone,
            this.txtCustomer,
            this.txtEstimator,
            this.txtOffice,
            this.txtContractType,
            this.txtJobName,
            this.txtBidDate,
            this.txtEstimateNumber});
            this.Detail.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detail.HeightF = 17F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.OddStyleName = "xrControlStyle1";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Estimate No", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Job No", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.StyleName = "xrControlStyle1";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtProjectManager
            // 
            this.txtProjectManager.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Project Manager")});
            this.txtProjectManager.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectManager.LocationFloat = new DevExpress.Utils.PointFloat(701F, 0F);
            this.txtProjectManager.Name = "txtProjectManager";
            this.txtProjectManager.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtProjectManager.SizeF = new System.Drawing.SizeF(107F, 17F);
            this.txtProjectManager.Text = "txtProjectManager";
            this.txtProjectManager.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtProjectManager.WordWrap = false;
            // 
            // txtDepartment
            // 
            this.txtDepartment.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Department")});
            this.txtDepartment.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.LocationFloat = new DevExpress.Utils.PointFloat(885F, 0F);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDepartment.SizeF = new System.Drawing.SizeF(90F, 17F);
            this.txtDepartment.Text = "txtDepartment";
            this.txtDepartment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtDepartment.WordWrap = false;
            // 
            // txtPhone
            // 
            this.txtPhone.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.JobPhone")});
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.LocationFloat = new DevExpress.Utils.PointFloat(976F, 0F);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPhone.SizeF = new System.Drawing.SizeF(67F, 17F);
            this.txtPhone.Text = "txtPhone";
            this.txtPhone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtPhone.WordWrap = false;
            // 
            // txtCustomer
            // 
            this.txtCustomer.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Customer")});
            this.txtCustomer.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.LocationFloat = new DevExpress.Utils.PointFloat(379F, 0F);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCustomer.SizeF = new System.Drawing.SizeF(179F, 17F);
            this.txtCustomer.Text = "txtCustomer";
            this.txtCustomer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtCustomer.WordWrap = false;
            // 
            // txtEstimator
            // 
            this.txtEstimator.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Estimator")});
            this.txtEstimator.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimator.LocationFloat = new DevExpress.Utils.PointFloat(581F, 0F);
            this.txtEstimator.Name = "txtEstimator";
            this.txtEstimator.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEstimator.SizeF = new System.Drawing.SizeF(119F, 17F);
            this.txtEstimator.Text = "txtEstimator";
            this.txtEstimator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtEstimator.WordWrap = false;
            // 
            // txtOffice
            // 
            this.txtOffice.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Office")});
            this.txtOffice.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOffice.LocationFloat = new DevExpress.Utils.PointFloat(809F, 0F);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOffice.SizeF = new System.Drawing.SizeF(76F, 17F);
            this.txtOffice.Text = "txtOffice";
            this.txtOffice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtOffice.WordWrap = false;
            // 
            // txtContractType
            // 
            this.txtContractType.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Contract Type", "{0:c}")});
            this.txtContractType.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractType.LocationFloat = new DevExpress.Utils.PointFloat(266F, 0F);
            this.txtContractType.Name = "txtContractType";
            this.txtContractType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtContractType.SizeF = new System.Drawing.SizeF(109F, 17F);
            xrSummary1.FormatString = "{0:c}";
            this.txtContractType.Summary = xrSummary1;
            this.txtContractType.Text = "txtContractType";
            this.txtContractType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtContractType.WordWrap = false;
            // 
            // txtJobName
            // 
            this.txtJobName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Job Name")});
            this.txtJobName.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobName.LocationFloat = new DevExpress.Utils.PointFloat(116F, 0F);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtJobName.SizeF = new System.Drawing.SizeF(143F, 17F);
            this.txtJobName.Text = "txtJobName";
            this.txtJobName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtJobName.WordWrap = false;
            // 
            // txtBidDate
            // 
            this.txtBidDate.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Job No")});
            this.txtBidDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBidDate.LocationFloat = new DevExpress.Utils.PointFloat(57F, 0F);
            this.txtBidDate.Name = "txtBidDate";
            this.txtBidDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBidDate.SizeF = new System.Drawing.SizeF(57F, 17F);
            this.txtBidDate.Text = "txtBidDate";
            this.txtBidDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtBidDate.WordWrap = false;
            // 
            // txtEstimateNumber
            // 
            this.txtEstimateNumber.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Estimate No")});
            this.txtEstimateNumber.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimateNumber.LocationFloat = new DevExpress.Utils.PointFloat(5F, 0F);
            this.txtEstimateNumber.Name = "txtEstimateNumber";
            this.txtEstimateNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEstimateNumber.SizeF = new System.Drawing.SizeF(45F, 17F);
            this.txtEstimateNumber.Text = "txtEstimateNumber";
            this.txtEstimateNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.txtEstimateNumber.WordWrap = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
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
            this.PageHeader.HeightF = 112F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(976F, 88F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(66F, 17F);
            this.xrLabel1.Text = "Phone";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // logo
            // 
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8F);
            this.logo.Name = "logo";
            this.logo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.logo.SizeF = new System.Drawing.SizeF(240F, 65F);
            this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLine5
            // 
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 104F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine5.SizeF = new System.Drawing.SizeF(1050F, 8F);
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Maroon;
            this.txtTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34F);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTitle.SizeF = new System.Drawing.SizeF(1050F, 25F);
            this.txtTitle.Text = "Job List";
            this.txtTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 78F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine1.SizeF = new System.Drawing.SizeF(1050F, 8F);
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine2.SizeF = new System.Drawing.SizeF(1050F, 8F);
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(5F, 86F);
            this.xrLabel21.Multiline = true;
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(53F, 17F);
            this.xrLabel21.Text = "Estimate #";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(57F, 86F);
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(49F, 17F);
            this.xrLabel22.Text = "Job No";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(116F, 86F);
            this.xrLabel23.Multiline = true;
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(126F, 17F);
            this.xrLabel23.Text = "Job Name";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(266F, 86F);
            this.xrLabel24.Multiline = true;
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(92F, 17F);
            this.xrLabel24.Text = "Contract Type";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(379F, 86F);
            this.xrLabel25.Multiline = true;
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(121F, 17F);
            this.xrLabel25.Text = "Customer";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(581F, 88F);
            this.xrLabel26.Multiline = true;
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(85F, 17F);
            this.xrLabel26.Text = "Estimator";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(701F, 88F);
            this.xrLabel27.Multiline = true;
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(74F, 17F);
            this.xrLabel27.Text = "Project Manager";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(885F, 88F);
            this.xrLabel28.Multiline = true;
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(75F, 17F);
            this.xrLabel28.Text = "Department";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(809F, 88F);
            this.xrLabel29.Multiline = true;
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(45F, 17F);
            this.xrLabel29.Text = "Office";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.ForeColor = System.Drawing.Color.Maroon;
            this.txtCompany.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8F);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCompany.SizeF = new System.Drawing.SizeF(1050F, 25F);
            this.txtCompany.Text = "CONTRA COSTA ELECTRIC, INC.";
            this.txtCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel125
            // 
            this.xrLabel125.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel125.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel125.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8F);
            this.xrLabel125.Multiline = true;
            this.xrLabel125.Name = "xrLabel125";
            this.xrLabel125.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel125.SizeF = new System.Drawing.SizeF(67F, 17F);
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
            this.PageFooter.HeightF = 26F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.ForeColor = System.Drawing.Color.Maroon;
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(1016F, 9F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(33F, 17F);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(983F, 8F);
            this.xrLabel20.Multiline = true;
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(34F, 17F);
            this.xrLabel20.Text = "Page:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.ForeColor = System.Drawing.Color.Maroon;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(67F, 9F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(175F, 17F);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine4
            // 
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine4.SizeF = new System.Drawing.SizeF(1050F, 8F);
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.BackColor = System.Drawing.Color.Transparent;
            this.xrControlStyle1.BorderColor = System.Drawing.Color.Black;
            this.xrControlStyle1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrControlStyle1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrControlStyle1.BorderWidth = 1F;
            this.xrControlStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrControlStyle1.ForeColor = System.Drawing.Color.Black;
            this.xrControlStyle1.Name = "xrControlStyle1";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3});
            this.ReportFooter.HeightF = 33F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblAccount.Estimate No")});
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(225F, 8F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 17F);
            xrSummary2.FormatString = "{0:n0}";
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel4.Summary = xrSummary2;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(175F, 8F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(50F, 17F);
            this.xrLabel3.Text = "Count:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 25F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 25F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // rptJobList
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportFooter,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "15.1";
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
        private DevExpress.XtraReports.UI.XRLabel txtContractType;
        private DevExpress.XtraReports.UI.XRLabel txtJobName;
        private DevExpress.XtraReports.UI.XRLabel txtBidDate;
        private DevExpress.XtraReports.UI.XRLabel txtEstimateNumber;
        private DevExpress.XtraReports.UI.XRLabel txtOffice;
        private DevExpress.XtraReports.UI.XRLabel txtCustomer;
        private DevExpress.XtraReports.UI.XRLabel txtEstimator;
        private DevExpress.XtraReports.UI.XRLabel txtProjectManager;
        private DevExpress.XtraReports.UI.XRLabel txtDepartment;
        private DevExpress.XtraReports.UI.XRLabel txtPhone;
        private DevExpress.XtraReports.UI.XRPictureBox logo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}
