namespace JCCReports
{
    partial class rptJobMasterProposalSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptJobMasterProposalSheet));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.AlternatePricingTotal = new DevExpress.XtraReports.UI.XRSubreport();
            this.pricingAlternate = new DevExpress.XtraReports.UI.XRSubreport();
            this.pricingTotal = new DevExpress.XtraReports.UI.XRSubreport();
            this.Pricing = new DevExpress.XtraReports.UI.XRSubreport();
            this.LeadTime = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Alternate = new DevExpress.XtraReports.UI.XRRichText();
            this.GenInfo = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Exclusion = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPricing = new DevExpress.XtraReports.UI.XRLabel();
            this.Desription = new DevExpress.XtraReports.UI.XRRichText();
            this.Clarification = new DevExpress.XtraReports.UI.XRRichText();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.txtLicense = new DevExpress.XtraReports.UI.XRLabel();
            this.DynaAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEmail = new DevExpress.XtraReports.UI.XRLabel();
            this.txtZipCountry = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFax = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPhone = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDynaEstNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.LeadTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alternate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exclusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clarification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AlternatePricingTotal,
            this.pricingAlternate,
            this.pricingTotal,
            this.Pricing,
            this.LeadTime,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel11,
            this.xrLabel8,
            this.Alternate,
            this.GenInfo,
            this.xrLabel5,
            this.Exclusion,
            this.xrLabel4,
            this.xrLabel3,
            this.lblPricing,
            this.Desription,
            this.Clarification});
            this.Detail.HeightF = 1220.733F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // AlternatePricingTotal
            // 
            this.AlternatePricingTotal.CanShrink = true;
            this.AlternatePricingTotal.LocationFloat = new DevExpress.Utils.PointFloat(0F, 286.6907F);
            this.AlternatePricingTotal.Name = "AlternatePricingTotal";
            this.AlternatePricingTotal.ReportSource = new JCCReports.rptJobMasterProposalAlternatePricingTotalSUM();
            this.AlternatePricingTotal.SizeF = new System.Drawing.SizeF(709.9995F, 30.20834F);
            this.AlternatePricingTotal.Visible = false;
            // 
            // pricingAlternate
            // 
            this.pricingAlternate.CanShrink = true;
            this.pricingAlternate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 221.9824F);
            this.pricingAlternate.Name = "pricingAlternate";
            this.pricingAlternate.ReportSource = new JCCReports.rptJobMasterProposalAlternatePricing();
            this.pricingAlternate.SizeF = new System.Drawing.SizeF(710F, 64.70831F);
            // 
            // pricingTotal
            // 
            this.pricingTotal.CanShrink = true;
            this.pricingTotal.LocationFloat = new DevExpress.Utils.PointFloat(0F, 176.149F);
            this.pricingTotal.Name = "pricingTotal";
            this.pricingTotal.ReportSource = new JCCReports.rptJobMasterProposalPricingTotalSUM();
            this.pricingTotal.SizeF = new System.Drawing.SizeF(709.9995F, 30.20834F);
            // 
            // Pricing
            // 
            this.Pricing.CanShrink = true;
            this.Pricing.LocationFloat = new DevExpress.Utils.PointFloat(0.0005086263F, 104.607F);
            this.Pricing.Name = "Pricing";
            this.Pricing.ReportSource = new JCCReports.rptJobMasterProposalPricing();
            this.Pricing.SizeF = new System.Drawing.SizeF(709.9995F, 71.54203F);
            // 
            // LeadTime
            // 
            this.LeadTime.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.LeadTime.BorderWidth = 0F;
            this.LeadTime.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.LeadTime.LocationFloat = new DevExpress.Utils.PointFloat(8.000819F, 570.6084F);
            this.LeadTime.Name = "LeadTime";
            this.LeadTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.LeadTime.SerializableRtfString = resources.GetString("LeadTime.SerializableRtfString");
            this.LeadTime.SizeF = new System.Drawing.SizeF(712F, 110.0833F);
            this.LeadTime.StylePriority.UseBorderWidth = false;
            this.LeadTime.StylePriority.UseFont = false;
            this.LeadTime.StylePriority.UsePadding = false;
            this.LeadTime.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.LeadTime_BeforePrint);
            // 
            // xrLabel14
            // 
            this.xrLabel14.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel14.BorderWidth = 0F;
            this.xrLabel14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(6.999382F, 531.9905F);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(711.9999F, 20.125F);
            this.xrLabel14.StylePriority.UseBorderWidth = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseForeColor = false;
            this.xrLabel14.Text = "Lead Information:";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(6.999397F, 1193.733F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.xrLabel13.SizeF = new System.Drawing.SizeF(170F, 17F);
            this.xrLabel13.StylePriority.UseForeColor = false;
            this.xrLabel13.StylePriority.UsePadding = false;
            this.xrLabel13.Text = "DYNALECTRIC COMPANY";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(6.999397F, 1113.608F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(716.9998F, 22.20837F);
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.Text = "Sincerely,";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(6.999493F, 1074.733F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(716.9998F, 27.41675F);
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.Text = "Please do not hesitate to call if you have any questions or if you require furthe" +
    "r information.";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Alternate
            // 
            this.Alternate.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Alternate.BorderWidth = 0F;
            this.Alternate.CanShrink = true;
            this.Alternate.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.Alternate.KeepTogether = true;
            this.Alternate.LocationFloat = new DevExpress.Utils.PointFloat(6.999397F, 436.4047F);
            this.Alternate.Name = "Alternate";
            this.Alternate.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.Alternate.SerializableRtfString = resources.GetString("Alternate.SerializableRtfString");
            this.Alternate.SizeF = new System.Drawing.SizeF(712F, 64.76535F);
            this.Alternate.StylePriority.UseBorderWidth = false;
            this.Alternate.StylePriority.UseFont = false;
            this.Alternate.StylePriority.UsePadding = false;
            this.Alternate.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Alternate_BeforePrint);
            // 
            // GenInfo
            // 
            this.GenInfo.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.GenInfo.BorderWidth = 0F;
            this.GenInfo.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.GenInfo.LocationFloat = new DevExpress.Utils.PointFloat(6.999636F, 351.1636F);
            this.GenInfo.Name = "GenInfo";
            this.GenInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.GenInfo.SerializableRtfString = resources.GetString("GenInfo.SerializableRtfString");
            this.GenInfo.SizeF = new System.Drawing.SizeF(712.0001F, 67.375F);
            this.GenInfo.StylePriority.UseBorderWidth = false;
            this.GenInfo.StylePriority.UseFont = false;
            this.GenInfo.StylePriority.UsePadding = false;
            this.GenInfo.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GenInfo_BeforePrint);
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.Teal;
            this.xrLabel5.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.ForeColor = System.Drawing.Color.White;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(8.000596F, 329.9936F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(712.0001F, 21.17F);
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.Text = "B. Scope Information : Our Proposal includes but is not limited to the following:" +
    "";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Exclusion
            // 
            this.Exclusion.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Exclusion.BorderWidth = 0F;
            this.Exclusion.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.Exclusion.LocationFloat = new DevExpress.Utils.PointFloat(6.999382F, 920.2327F);
            this.Exclusion.Name = "Exclusion";
            this.Exclusion.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.Exclusion.SerializableRtfString = resources.GetString("Exclusion.SerializableRtfString");
            this.Exclusion.SizeF = new System.Drawing.SizeF(711.9999F, 136.1249F);
            this.Exclusion.StylePriority.UseBorderWidth = false;
            this.Exclusion.StylePriority.UseFont = false;
            this.Exclusion.StylePriority.UsePadding = false;
            this.Exclusion.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Exclusion_BeforePrint);
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.Teal;
            this.xrLabel4.BorderColor = System.Drawing.Color.White;
            this.xrLabel4.BorderWidth = 0F;
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.White;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(6.999493F, 879.8334F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(712F, 21.17F);
            this.xrLabel4.StylePriority.UseBackColor = false;
            this.xrLabel4.StylePriority.UseBorderColor = false;
            this.xrLabel4.StylePriority.UseBorderWidth = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.Text = "C. Exclusions: The following items are excluded from our scope of work:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel3.BorderWidth = 0F;
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(8.000819F, 707.506F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(711.9999F, 20.125F);
            this.xrLabel3.StylePriority.UseBorderWidth = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.Text = "Clarifications:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPricing
            // 
            this.lblPricing.BackColor = System.Drawing.Color.Teal;
            this.lblPricing.BorderColor = System.Drawing.Color.White;
            this.lblPricing.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPricing.ForeColor = System.Drawing.Color.White;
            this.lblPricing.LocationFloat = new DevExpress.Utils.PointFloat(7.99977F, 70.74998F);
            this.lblPricing.Multiline = true;
            this.lblPricing.Name = "lblPricing";
            this.lblPricing.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPricing.SizeF = new System.Drawing.SizeF(712F, 21.16667F);
            this.lblPricing.StylePriority.UseBackColor = false;
            this.lblPricing.StylePriority.UseBorderColor = false;
            this.lblPricing.StylePriority.UseFont = false;
            this.lblPricing.StylePriority.UseForeColor = false;
            this.lblPricing.StylePriority.UseTextAlignment = false;
            this.lblPricing.Text = "A. Pricing";
            this.lblPricing.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblPricing.WordWrap = false;
            // 
            // Desription
            // 
            this.Desription.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Desription.BorderWidth = 0F;
            this.Desription.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.Desription.LocationFloat = new DevExpress.Utils.PointFloat(7.999992F, 10.00001F);
            this.Desription.Name = "Desription";
            this.Desription.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.Desription.SerializableRtfString = resources.GetString("Desription.SerializableRtfString");
            this.Desription.SizeF = new System.Drawing.SizeF(711.9999F, 49.29164F);
            this.Desription.StylePriority.UseBorderColor = false;
            this.Desription.StylePriority.UseBorderDashStyle = false;
            this.Desription.StylePriority.UseBorders = false;
            this.Desription.StylePriority.UseBorderWidth = false;
            this.Desription.StylePriority.UseFont = false;
            this.Desription.StylePriority.UsePadding = false;
            this.Desription.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.RFIText_BeforePrint);
            // 
            // Clarification
            // 
            this.Clarification.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Clarification.BorderWidth = 0F;
            this.Clarification.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.Clarification.LocationFloat = new DevExpress.Utils.PointFloat(8.000596F, 744.6722F);
            this.Clarification.Name = "Clarification";
            this.Clarification.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.Clarification.SerializableRtfString = resources.GetString("Clarification.SerializableRtfString");
            this.Clarification.SizeF = new System.Drawing.SizeF(711.9999F, 116.3334F);
            this.Clarification.StylePriority.UseBorderWidth = false;
            this.Clarification.StylePriority.UseFont = false;
            this.Clarification.StylePriority.UsePadding = false;
            this.Clarification.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.RFIResponse_BeforePrint);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtLicense,
            this.DynaAddress,
            this.txtEmail,
            this.txtZipCountry,
            this.txtFax,
            this.txtPhone,
            this.xrTable1,
            this.logo});
            this.ReportHeader.HeightF = 220F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtLicense
            // 
            this.txtLicense.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.txtLicense.ForeColor = System.Drawing.Color.Black;
            this.txtLicense.LocationFloat = new DevExpress.Utils.PointFloat(587F, 85F);
            this.txtLicense.Multiline = true;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtLicense.SizeF = new System.Drawing.SizeF(160.9998F, 17F);
            this.txtLicense.StylePriority.UseFont = false;
            this.txtLicense.StylePriority.UseForeColor = false;
            this.txtLicense.StylePriority.UseTextAlignment = false;
            this.txtLicense.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DynaAddress
            // 
            this.DynaAddress.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DynaAddress.ForeColor = System.Drawing.Color.Black;
            this.DynaAddress.LocationFloat = new DevExpress.Utils.PointFloat(587F, 0F);
            this.DynaAddress.Multiline = true;
            this.DynaAddress.Name = "DynaAddress";
            this.DynaAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DynaAddress.SizeF = new System.Drawing.SizeF(162F, 17F);
            this.DynaAddress.StylePriority.UseForeColor = false;
            this.DynaAddress.StylePriority.UseTextAlignment = false;
            this.DynaAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.LocationFloat = new DevExpress.Utils.PointFloat(587F, 68F);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmail.SizeF = new System.Drawing.SizeF(160.9998F, 17F);
            this.txtEmail.StylePriority.UseForeColor = false;
            this.txtEmail.StylePriority.UseTextAlignment = false;
            this.txtEmail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtZipCountry
            // 
            this.txtZipCountry.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZipCountry.ForeColor = System.Drawing.Color.Black;
            this.txtZipCountry.LocationFloat = new DevExpress.Utils.PointFloat(587F, 17F);
            this.txtZipCountry.Multiline = true;
            this.txtZipCountry.Name = "txtZipCountry";
            this.txtZipCountry.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtZipCountry.SizeF = new System.Drawing.SizeF(162F, 17F);
            this.txtZipCountry.StylePriority.UseForeColor = false;
            this.txtZipCountry.StylePriority.UseTextAlignment = false;
            this.txtZipCountry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.ForeColor = System.Drawing.Color.Black;
            this.txtFax.LocationFloat = new DevExpress.Utils.PointFloat(587F, 51F);
            this.txtFax.Multiline = true;
            this.txtFax.Name = "txtFax";
            this.txtFax.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFax.SizeF = new System.Drawing.SizeF(160.9998F, 17F);
            this.txtFax.StylePriority.UseForeColor = false;
            this.txtFax.StylePriority.UseTextAlignment = false;
            this.txtFax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.LocationFloat = new DevExpress.Utils.PointFloat(587F, 34F);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPhone.SizeF = new System.Drawing.SizeF(160.9999F, 17F);
            this.txtPhone.StylePriority.UseFont = false;
            this.txtPhone.StylePriority.UseForeColor = false;
            this.txtPhone.StylePriority.UseTextAlignment = false;
            this.txtPhone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(6.999922F, 117.4167F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(716.9998F, 102.5833F);
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.BorderWidth = 0F;
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTableRow1.StylePriority.UseBorderWidth = false;
            this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BorderWidth = 0F;
            this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.xrDynaEstNo,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel29,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel40,
            this.xrLabel37,
            this.xrLabel30});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell1.StylePriority.UseBorderWidth = false;
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell1.Weight = 0.99302649930263542D;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BorderWidth = 0F;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AAAA.REV")});
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(651.1669F, 8.000024F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(45.41632F, 16.99999F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel2.WordWrap = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(580.0001F, 7.999992F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(71.16675F, 17.00001F);
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.Text = "Revision #";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrDynaEstNo
            // 
            this.xrDynaEstNo.BorderWidth = 0F;
            this.xrDynaEstNo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AAAA.DynaEstimate")});
            this.xrDynaEstNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrDynaEstNo.LocationFloat = new DevExpress.Utils.PointFloat(117.1667F, 76F);
            this.xrDynaEstNo.Name = "xrDynaEstNo";
            this.xrDynaEstNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrDynaEstNo.SizeF = new System.Drawing.SizeF(223F, 17F);
            this.xrDynaEstNo.Text = "xrLabelDynaEstimate";
            this.xrDynaEstNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(3.000088F, 76F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(82.99998F, 17F);
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.Text = "Dyna Est #";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(3.000088F, 59F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(58.66669F, 17F);
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.Text = "Subject:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.ForeColor = System.Drawing.Color.Black;
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(3.000088F, 42F);
            this.xrLabel29.Multiline = true;
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(42F, 17F);
            this.xrLabel29.StylePriority.UseForeColor = false;
            this.xrLabel29.Text = "Attn:";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.BorderWidth = 0F;
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AAAA.Subject")});
            this.xrLabel18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(117.1667F, 59F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(223F, 17F);
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.BorderWidth = 0F;
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AAAA.CompanyName")});
            this.xrLabel17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(117.1667F, 42F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(223F, 17F);
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel17.WordWrap = false;
            // 
            // xrLabel16
            // 
            this.xrLabel16.BorderWidth = 0F;
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AAAA.UserName")});
            this.xrLabel16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(117.1667F, 25F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(223F, 17F);
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel16.WordWrap = false;
            // 
            // xrLabel40
            // 
            this.xrLabel40.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel40.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel40.ForeColor = System.Drawing.Color.Black;
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(3.000085F, 25F);
            this.xrLabel40.Multiline = true;
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(42F, 17F);
            this.xrLabel40.StylePriority.UseForeColor = false;
            this.xrLabel40.Text = "To:";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel37
            // 
            this.xrLabel37.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel37.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.ForeColor = System.Drawing.Color.Black;
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(3.000085F, 7.999992F);
            this.xrLabel37.Multiline = true;
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(38.875F, 17F);
            this.xrLabel37.StylePriority.UseForeColor = false;
            this.xrLabel37.Text = "Date:";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel30
            // 
            this.xrLabel30.BorderWidth = 0F;
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AAAA.Date", "{0:MM/dd/yyyy}")});
            this.xrLabel30.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(117.1667F, 7.999992F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(112.8333F, 17F);
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "xrLabel30";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel30.WordWrap = false;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell2.Weight = 0.0069735006973645547D;
            // 
            // logo
            // 
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.logo.Name = "logo";
            this.logo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.logo.SizeF = new System.Drawing.SizeF(240F, 65F);
            this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 60F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 60F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // rptJobMasterProposalSheet
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.ReportHeader,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Margins = new System.Drawing.Printing.Margins(60, 41, 60, 60);
            this.Version = "15.1";
            this.DataSourceRowChanged += new DevExpress.XtraReports.UI.DataSourceRowEventHandler(this.rptJobRFISheet_DataSourceRowChanged);
            ((System.ComponentModel.ISupportInitialize)(this.LeadTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alternate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exclusion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clarification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPictureBox logo;
        public DevExpress.XtraReports.UI.XRLabel txtPhone;
        public DevExpress.XtraReports.UI.XRLabel txtFax;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel30;
        private DevExpress.XtraReports.UI.XRRichText Desription;
        private DevExpress.XtraReports.UI.XRRichText Clarification;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel xrLabel40;
        private DevExpress.XtraReports.UI.XRLabel xrLabel37;
        private DevExpress.XtraReports.UI.XRLabel lblPricing;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRRichText Exclusion;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRRichText GenInfo;
        private DevExpress.XtraReports.UI.XRRichText Alternate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrDynaEstNo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRRichText LeadTime;
        public DevExpress.XtraReports.UI.XRSubreport Pricing;
        public DevExpress.XtraReports.UI.XRSubreport pricingTotal;
        public DevExpress.XtraReports.UI.XRSubreport pricingAlternate;
        public DevExpress.XtraReports.UI.XRSubreport AlternatePricingTotal;
        public DevExpress.XtraReports.UI.XRLabel txtEmail;
        public DevExpress.XtraReports.UI.XRLabel txtZipCountry;
        public DevExpress.XtraReports.UI.XRLabel DynaAddress;
        public DevExpress.XtraReports.UI.XRLabel txtLicense;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}
