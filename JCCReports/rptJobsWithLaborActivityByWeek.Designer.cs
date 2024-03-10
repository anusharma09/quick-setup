namespace JCCReports
{
    partial class rptJobsWithLaborActivityByWeek
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
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtJobName = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.txtTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtWeekend = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCompany = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel125 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.txtDepartment = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGroup = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.txtSubTotalValue = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSubTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.txtOffice = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtReportTotalValue = new DevExpress.XtraReports.UI.XRLabel();
            this.txtReportTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel1,
            this.txtJobName});
            this.Detail.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detail.HeightF = 17F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.OddStyleName = "xrControlStyle1";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("EstimateNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.StyleName = "xrControlStyle1";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblJobBalance.JobNumber")});
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(158F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(56F, 17F);
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel4.WordWrap = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblJobBalance.Foreman")});
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(500F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(242F, 17F);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel1.WordWrap = false;
            // 
            // txtJobName
            // 
            this.txtJobName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblJobBalance.JobName")});
            this.txtJobName.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobName.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtJobName.SizeF = new System.Drawing.SizeF(242F, 17F);
            this.txtJobName.Text = "txtJobName";
            this.txtJobName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.txtJobName.WordWrap = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtTitle,
            this.xrLabel3,
            this.xrLabel2,
            this.txtWeekend,
            this.xrLabel7,
            this.xrLine5,
            this.logo,
            this.xrLabel24,
            this.txtCompany});
            this.PageHeader.HeightF = 119F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Maroon;
            this.txtTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34F);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTitle.SizeF = new System.Drawing.SizeF(775F, 25F);
            this.txtTitle.Text = "JOBS WITH LABOR ACTIVITIES BY WEEK";
            this.txtTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(500F, 92F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(242F, 17F);
            this.xrLabel3.Text = "Foreman";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(250F, 92F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(242F, 17F);
            this.xrLabel2.Text = "Job Name";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtWeekend
            // 
            this.txtWeekend.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeekend.LocationFloat = new DevExpress.Utils.PointFloat(58F, 73F);
            this.txtWeekend.Name = "txtWeekend";
            this.txtWeekend.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtWeekend.SizeF = new System.Drawing.SizeF(100F, 17F);
            this.txtWeekend.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 73F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(56F, 17F);
            this.xrLabel7.Text = "Weekend:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine5
            // 
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine5.SizeF = new System.Drawing.SizeF(775F, 8F);
            // 
            // logo
            // 
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.logo.Name = "logo";
            this.logo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.logo.SizeF = new System.Drawing.SizeF(240F, 65F);
            this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(158F, 92F);
            this.xrLabel24.Multiline = true;
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(56F, 17F);
            this.xrLabel24.Text = "Job #";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.ForeColor = System.Drawing.Color.Maroon;
            this.txtCompany.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8F);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCompany.SizeF = new System.Drawing.SizeF(775F, 25F);
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(738F, 9F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(33F, 17F);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(671F, 8F);
            this.xrLabel20.Multiline = true;
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(67F, 17F);
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
            this.xrLine4.SizeF = new System.Drawing.SizeF(775F, 8F);
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
            // txtDepartment
            // 
            this.txtDepartment.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblJobBalance.Department")});
            this.txtDepartment.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDepartment.SizeF = new System.Drawing.SizeF(17F, 8F);
            this.txtDepartment.Text = "txtDepartment";
            this.txtDepartment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.txtDepartment.Visible = false;
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroup.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGroup.SizeF = new System.Drawing.SizeF(292F, 17F);
            this.txtGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.txtGroup.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.txtGroup_BeforePrint);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtSubTotalValue,
            this.txtSubTotal});
            this.GroupFooter1.HeightF = 35F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtSubTotalValue
            // 
            this.txtSubTotalValue.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.txtSubTotalValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblJobBalance.JobNumber")});
            this.txtSubTotalValue.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotalValue.LocationFloat = new DevExpress.Utils.PointFloat(300F, 8F);
            this.txtSubTotalValue.Name = "txtSubTotalValue";
            this.txtSubTotalValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSubTotalValue.SizeF = new System.Drawing.SizeF(125F, 17F);
            xrSummary1.FormatString = "{0:n0}";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.txtSubTotalValue.Summary = xrSummary1;
            this.txtSubTotalValue.Text = "txtSubTotalValue";
            this.txtSubTotalValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.LocationFloat = new DevExpress.Utils.PointFloat(33F, 8F);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSubTotal.SizeF = new System.Drawing.SizeF(242F, 17F);
            this.txtSubTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.txtSubTotal.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.txtSubTotal_BeforePrint);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtDepartment,
            this.txtOffice,
            this.txtGroup});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Office", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Department", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeader1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtOffice
            // 
            this.txtOffice.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblJobBalance.Office")});
            this.txtOffice.LocationFloat = new DevExpress.Utils.PointFloat(675F, 0F);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOffice.SizeF = new System.Drawing.SizeF(17F, 17F);
            this.txtOffice.Text = "txtOffice";
            this.txtOffice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.txtOffice.Visible = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtReportTotalValue,
            this.txtReportTotal});
            this.ReportFooter.HeightF = 33F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtReportTotalValue
            // 
            this.txtReportTotalValue.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.txtReportTotalValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "up_JCWeeklyEstimateBudgetReport.bidAmount")});
            this.txtReportTotalValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportTotalValue.LocationFloat = new DevExpress.Utils.PointFloat(300F, 0F);
            this.txtReportTotalValue.Name = "txtReportTotalValue";
            this.txtReportTotalValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtReportTotalValue.SizeF = new System.Drawing.SizeF(125F, 17F);
            xrSummary2.FormatString = "{0:n0}";
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.txtReportTotalValue.Summary = xrSummary2;
            this.txtReportTotalValue.Text = "txtReportTotalValue";
            this.txtReportTotalValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtReportTotal
            // 
            this.txtReportTotal.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.txtReportTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportTotal.LocationFloat = new DevExpress.Utils.PointFloat(33F, 0F);
            this.txtReportTotal.Name = "txtReportTotal";
            this.txtReportTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtReportTotal.SizeF = new System.Drawing.SizeF(242F, 17F);
            this.txtReportTotal.Text = "Report Count:";
            this.txtReportTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            // rptJobsWithLaborActivityByWeek
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.GroupFooter1,
            this.GroupHeader1,
            this.ReportFooter,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "15.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPictureBox logo;
        private DevExpress.XtraReports.UI.XRLabel txtCompany;
        private DevExpress.XtraReports.UI.XRLabel txtTitle;
        private DevExpress.XtraReports.UI.XRLabel xrLabel125;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLabel txtJobName;
        private DevExpress.XtraReports.UI.XRLabel txtGroup;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel txtDepartment;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtOffice;
        private DevExpress.XtraReports.UI.XRLabel txtSubTotal;
        private DevExpress.XtraReports.UI.XRLabel txtSubTotalValue;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel txtReportTotalValue;
        private DevExpress.XtraReports.UI.XRLabel txtReportTotal;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        public DevExpress.XtraReports.UI.XRLabel txtWeekend;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}
