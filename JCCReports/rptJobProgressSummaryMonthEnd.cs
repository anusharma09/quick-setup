using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobProgressSummaryMonthEnd : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobProgressSummaryMonthEnd()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
      
    }
}