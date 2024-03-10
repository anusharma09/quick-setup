using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCDailyLog.Reports
{
    public partial class rptJobDailyLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobDailyLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void rptJobDailyLog_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            productiveNarrative.Rtf = GetCurrentColumnValue("ProductiveNarrative").ToString();
        }

        
    }
}
