using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CCEOTProjects.Reports
{
    public partial class rptAdHocProjctOpportunitiesAnalysis : DevExpress.XtraReports.UI.XtraReport
    {
        private double opportunity = 0;
        private double estimate = 0;
        private double job = 0;

        private double opportunityG = 0;
        private double estimateG = 0;
        private double jobG = 0;

        public rptAdHocProjctOpportunitiesAnalysis()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void Percent1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double percent = 0;
            if (opportunity > 0)
                percent = estimate / opportunity;
            Percent1.Text = String.Format("{0:0.00%}", Convert.ToDouble(percent));
        }
        private void txtOpportunity_AfterPrint(object sender, EventArgs e)
        {
            opportunity += Convert.ToDouble(txtOpportunity.Text.Trim().Replace(",", ""));
            opportunityG += Convert.ToDouble(txtOpportunity.Text.Trim().Replace(",", ""));
        }

        private void txtEstimate_AfterPrint(object sender, EventArgs e)
        {
            estimate += Convert.ToDouble(txtEstimate.Text.Trim().Replace(",", ""));
            estimateG += Convert.ToDouble(txtEstimate.Text.Trim().Replace(",", ""));
        }

        private void txtJob_AfterPrint(object sender, EventArgs e)
        {
            job += Convert.ToDouble(txtJob.Text.Trim().Replace(",", ""));
            jobG += Convert.ToDouble(txtJob.Text.Trim().Replace(",", ""));

        }

        private void Percent2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double percent = 0;
            if (estimate > 0)
                percent = job / estimate;
            Percent2.Text = String.Format("{0:0.00%}", Convert.ToDouble(percent));
        }

        private void Percent3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double percent = 0;
            if (opportunity > 0)
                percent = job / opportunity;
            Percent3.Text = String.Format("{0:0.00%}", Convert.ToDouble(percent));
        }

        private void xrLabel15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double percent = 0;
            if (opportunityG > 0)
                percent = estimateG / opportunityG;
            xrLabel17.Text = String.Format("{0:0.00%}", Convert.ToDouble(percent));
        }

        private void xrLabel20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double percent = 0;
            if (estimateG > 0)
                percent = jobG / estimateG;
            xrLabel20.Text = String.Format("{0:0.00%}", Convert.ToDouble(percent));
        }

        private void xrLabel22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double percent = 0;
            if (opportunityG > 0)
                percent = jobG / opportunityG;
            xrLabel22.Text = String.Format("{0:0.00%}", Convert.ToDouble(percent));
            opportunityG = 0;
            estimateG = 0;
            jobG = 0;
        }
    }
}
