using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobMajorPOLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobMajorPOLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Status.Text = GetCurrentColumnValue("Status").ToString();
        }
    }
}
