namespace JCCReports
{
    partial class rptLaborFeedbackReport
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
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.grdLaborFeedback = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.txtEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtJobNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtLaborPerformanceFactor = new DevExpress.XtraReports.UI.XRLabel();
            this.txtWeekEnding = new DevExpress.XtraReports.UI.XRLabel();
            this.txtJobName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.txtPhone = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFax = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCompany = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel125 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.grdLaborFeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.Detail.Height = 17;
            this.Detail.Name = "Detail";
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.Location = new System.Drawing.Point(42, 0);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.Size = new System.Drawing.Size(6, 6);
            this.winControlContainer1.WinControl = this.grdLaborFeedback;
            // 
            // grdLaborFeedback
            // 
            this.grdLaborFeedback.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdLaborFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLaborFeedback.Location = new System.Drawing.Point(0, 0);
            this.grdLaborFeedback.Name = "grdLaborFeedback";
            this.grdLaborFeedback.OptionsMenu.EnableFieldValueMenu = false;
            this.grdLaborFeedback.OptionsMenu.EnableHeaderAreaMenu = false;
            this.grdLaborFeedback.OptionsMenu.EnableHeaderMenu = false;
            this.grdLaborFeedback.OptionsView.ShowColumnHeaders = false;
            this.grdLaborFeedback.OptionsView.ShowDataHeaders = false;
            this.grdLaborFeedback.OptionsView.ShowFilterHeaders = false;
            this.grdLaborFeedback.Size = new System.Drawing.Size(6, 6);
            this.grdLaborFeedback.TabIndex = 2;
            this.grdLaborFeedback.CustomCellDisplayText += new DevExpress.XtraPivotGrid.PivotCellDisplayTextEventHandler(this.grdLaborFeedback_CustomCellDisplayText);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtEmployeeName,
            this.lblEmployeeName,
            this.txtJobNumber,
            this.xrLabel4,
            this.xrLabel5,
            this.txtLaborPerformanceFactor,
            this.txtWeekEnding,
            this.txtJobName,
            this.xrLabel2,
            this.xrLabel1,
            this.logo,
            this.txtPhone,
            this.xrLabel9,
            this.xrLabel12,
            this.txtFax,
            this.txtCompany,
            this.txtAddress});
            this.PageHeader.Height = 184;
            this.PageHeader.Name = "PageHeader";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(742, 167);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmployeeName.ParentStyleUsing.UseFont = false;
            this.txtEmployeeName.Size = new System.Drawing.Size(242, 17);
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom;
            this.txtEmployeeName.Summary = xrSummary1;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.ForeColor = System.Drawing.Color.Maroon;
            this.lblEmployeeName.Location = new System.Drawing.Point(608, 167);
            this.lblEmployeeName.Multiline = true;
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEmployeeName.ParentStyleUsing.UseFont = false;
            this.lblEmployeeName.ParentStyleUsing.UseForeColor = false;
            this.lblEmployeeName.Size = new System.Drawing.Size(117, 17);
            this.lblEmployeeName.Text = "Employee Name:";
            this.lblEmployeeName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNumber.Location = new System.Drawing.Point(125, 116);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtJobNumber.ParentStyleUsing.UseFont = false;
            this.txtJobNumber.Size = new System.Drawing.Size(325, 17);
            this.txtJobNumber.Text = "JobName";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel4.Location = new System.Drawing.Point(0, 116);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(117, 17);
            this.xrLabel4.Text = "Job Number:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel5.Location = new System.Drawing.Point(0, 167);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(117, 17);
            this.xrLabel5.Text = "Labor Perf. Factor:";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtLaborPerformanceFactor
            // 
            this.txtLaborPerformanceFactor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaborPerformanceFactor.Location = new System.Drawing.Point(125, 167);
            this.txtLaborPerformanceFactor.Name = "txtLaborPerformanceFactor";
            this.txtLaborPerformanceFactor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtLaborPerformanceFactor.ParentStyleUsing.UseFont = false;
            this.txtLaborPerformanceFactor.Size = new System.Drawing.Size(325, 17);
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom;
            this.txtLaborPerformanceFactor.Summary = xrSummary2;
            // 
            // txtWeekEnding
            // 
            this.txtWeekEnding.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeekEnding.Location = new System.Drawing.Point(125, 150);
            this.txtWeekEnding.Name = "txtWeekEnding";
            this.txtWeekEnding.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtWeekEnding.ParentStyleUsing.UseFont = false;
            this.txtWeekEnding.Size = new System.Drawing.Size(325, 17);
            xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom;
            this.txtWeekEnding.Summary = xrSummary3;
            this.txtWeekEnding.Text = "WeekEnding";
            // 
            // txtJobName
            // 
            this.txtJobName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobName.Location = new System.Drawing.Point(125, 133);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtJobName.ParentStyleUsing.UseFont = false;
            this.txtJobName.Size = new System.Drawing.Size(325, 17);
            this.txtJobName.Text = "JobName";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel2.Location = new System.Drawing.Point(0, 150);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(117, 17);
            this.xrLabel2.Text = "Week Ending:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel1.Location = new System.Drawing.Point(0, 133);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(117, 17);
            this.xrLabel1.Text = "Job Name:";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(225, 42);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.Maroon;
            this.txtPhone.Location = new System.Drawing.Point(624, 25);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPhone.ParentStyleUsing.UseFont = false;
            this.txtPhone.ParentStyleUsing.UseForeColor = false;
            this.txtPhone.Size = new System.Drawing.Size(368, 17);
            this.txtPhone.Text = "(935) 229-4250\r\n";
            this.txtPhone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel9.Location = new System.Drawing.Point(624, 8);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(368, 17);
            this.xrLabel9.Text = "California License # 129885";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel12.Location = new System.Drawing.Point(0, 67);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.ParentStyleUsing.UseForeColor = false;
            this.xrLabel12.Size = new System.Drawing.Size(992, 25);
            this.xrLabel12.Text = "Labor Feedback Report";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.ForeColor = System.Drawing.Color.Maroon;
            this.txtFax.Location = new System.Drawing.Point(624, 42);
            this.txtFax.Multiline = true;
            this.txtFax.Name = "txtFax";
            this.txtFax.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFax.ParentStyleUsing.UseFont = false;
            this.txtFax.ParentStyleUsing.UseForeColor = false;
            this.txtFax.Size = new System.Drawing.Size(368, 17);
            this.txtFax.Text = "Fax: (925) 335-2878\r\n";
            this.txtFax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.txtCompany.Size = new System.Drawing.Size(992, 25);
            this.txtCompany.Text = "CONTRA COSTA ELECTRIC, INC.";
            this.txtCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.Maroon;
            this.txtAddress.Location = new System.Drawing.Point(0, 42);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAddress.ParentStyleUsing.UseFont = false;
            this.txtAddress.ParentStyleUsing.UseForeColor = false;
            this.txtAddress.Size = new System.Drawing.Size(992, 17);
            this.txtAddress.Text = "Home Office: 825 Howe Road     P.O. Box 2523    Martinez, California 95553\r\n";
            this.txtAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrLabel125,
            this.xrLabel3,
            this.xrPageInfo1,
            this.xrLine3});
            this.PageFooter.Height = 29;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.ForeColor = System.Drawing.Color.Maroon;
            this.xrPageInfo2.Location = new System.Drawing.Point(67, 8);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.ParentStyleUsing.UseForeColor = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(175, 17);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel125
            // 
            this.xrLabel125.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Maroon;
            this.xrLabel3.Location = new System.Drawing.Point(919, 8);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(33, 17);
            this.xrLabel3.Text = "Page:";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.ForeColor = System.Drawing.Color.Maroon;
            this.xrPageInfo1.Location = new System.Drawing.Point(960, 8);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.ParentStyleUsing.UseForeColor = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(33, 17);
            // 
            // xrLine3
            // 
            this.xrLine3.Location = new System.Drawing.Point(0, 0);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.Size = new System.Drawing.Size(992, 8);
            // 
            // xrChart1
            // 
            this.xrChart1.Location = new System.Drawing.Point(8, 17);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.PaletteName = "Equity";
            this.xrChart1.ParentStyleUsing.UseBackColor = false;
            this.xrChart1.ParentStyleUsing.UseBorderColor = false;
            this.xrChart1.ParentStyleUsing.UseBorders = false;
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.xrChart1.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.xrChart1.Size = new System.Drawing.Size(992, 500);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageBreak1,
            this.xrChart1});
            this.ReportFooter.Height = 533;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.Location = new System.Drawing.Point(0, 0);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.Name = "xrControlStyle1";
            // 
            // rptLaborFeedbackReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            ((System.ComponentModel.ISupportInitialize)(this.grdLaborFeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        public DevExpress.XtraReports.UI.XRChart xrChart1;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        public DevExpress.XtraPivotGrid.PivotGridControl grdLaborFeedback;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel txtCompany;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRPictureBox logo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        public DevExpress.XtraReports.UI.XRLabel txtJobName;
        public DevExpress.XtraReports.UI.XRLabel txtWeekEnding;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel125;
        public DevExpress.XtraReports.UI.XRLabel txtAddress;
        public DevExpress.XtraReports.UI.XRLabel txtPhone;
        public DevExpress.XtraReports.UI.XRLabel txtFax;
        public DevExpress.XtraReports.UI.XRLabel txtLaborPerformanceFactor;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        public DevExpress.XtraReports.UI.XRLabel txtJobNumber;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        public DevExpress.XtraReports.UI.XRLabel txtEmployeeName;
        public DevExpress.XtraReports.UI.XRLabel lblEmployeeName;
    }
}
