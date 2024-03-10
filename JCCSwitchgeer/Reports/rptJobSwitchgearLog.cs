using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCSwitchgear.Reports
{
    public partial class rptJobSwitchgearLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobSwitchgearLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
           this.rptJobSwitchgearLogSub1.FilterString = "JobSwitchgearID = '" + txtSwitchgearID.Text + "'";

        }
    }
}
