using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCDailyLog.Reports
{
    public partial class rptJobDailyLogSummaryLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobDailyLogSummaryLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
        public rptJobDailyLogSummaryLog(int reportType)
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();

            switch (reportType)
            {
                case 1:
                    lblTitle.Text += " - INSPECTION";
                    break;
                case 2:
                    lblTitle.Text += " - PICTURES";
                    break;
                case 3:
                    lblTitle.Text += " - ACCIDENT";
                    break;
                case 4:
                    lblTitle.Text += " - SAFETY MEETING";
                    break;
                case 5:
                    lblTitle.Text += " - EXTRA WORK";
                    break;
                case 6:
                    lblTitle.Text += " - BACK CHARGE";
                    break;
                case 7:
                    lblTitle.Text += " - WORK DELAYED";
                    break;
                case 8:
                    lblTitle.Text += " - DELAY BY OTHERS";
                    break;
                case 9:
                    lblTitle.Text += " - DISRUPTION REPORT";
                    break;
            }
        }
    }
}
