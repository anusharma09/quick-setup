using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobSubmittalLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobSubmittalLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
            this.sub.ReportSource.FilterString = "JobSubmittalID = '" + txtSubmittalID.Text + "'";
            
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void txtSubmittalID_AfterPrint(object sender, EventArgs e)
        {
           // this.rptJobSubmittalLogSub1.FilterString = "JobSubmittalID = '" + txtSubmittalID.Text + "'";

        }
    }
}
