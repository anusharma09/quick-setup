using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCLightFixture.Reports
{
    public partial class rptJobLightFixtureRevisionLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobLightFixtureRevisionLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
           this.rptJobLightFixtureReleaseLogSub1.FilterString = "JobLightFixtureRevisionID = '" + txtLightFixtureRevisionID.Text + "'";

        }
    }
}
