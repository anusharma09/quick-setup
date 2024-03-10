using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCLightFixture.Reports
{
    public partial class rptJobLightFixtureReleaseForm : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobLightFixtureReleaseForm()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
        
    }
}
