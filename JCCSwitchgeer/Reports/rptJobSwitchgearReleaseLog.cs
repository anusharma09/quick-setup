using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCSwitchgear.Reports
{
    public partial class rptJobSwitchgearReleaseLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobSwitchgearReleaseLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
            XRBinding binding = new XRBinding("Text", this.DataSource, "JobSwitchgearReleaseID", "{0:n0}");
            txtSwitchgearReleaseID.DataBindings.Add(binding);

        }

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
           this.rptJobSwitchgearReleaseLogSub1.FilterString = "JobSwitchgearReleaseID = '" + txtSwitchgearReleaseID.Text + "'";

        }
    }
}
