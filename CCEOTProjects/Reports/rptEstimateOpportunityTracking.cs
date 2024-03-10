using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CCEOTProjects.Reports
{
    public partial class rptEstimateOpportunityTracking : DevExpress.XtraReports.UI.XtraReport
    {
        public rptEstimateOpportunityTracking()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

       
    }
}
