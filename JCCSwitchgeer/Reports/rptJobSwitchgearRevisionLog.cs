using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCSwitchgear.Reports
{
    public partial class rptJobSwitchgearRevisionLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobSwitchgearRevisionLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
            XRBinding binding = new XRBinding("Text", this.DataSource, "JobSwitchgearRevisionID", "{0:n0}");
            txtSwitchgearRevisionID.DataBindings.Add(binding);
        }

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
          this.rptJobSwitchgearReleaseLogSub1.FilterString = "JobSwitchgearRevisionID = '" + txtSwitchgearRevisionID.Text + "'";

        }
    }
}

