using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCLightFixture.Reports
{
    public partial class rptJobLightFixtureLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobLightFixtureLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
           this.rptJobLightFixtureLogSub1.FilterString = "JobLightFixtureID = '" + txtLightFixtureID.Text + "'";

        }
    }
}
