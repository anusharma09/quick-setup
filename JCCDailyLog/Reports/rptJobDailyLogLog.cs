using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCDailyLog.Reports
{
    public partial class rptJobDailyLogLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobDailyLogLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
