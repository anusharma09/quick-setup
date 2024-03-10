using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCSwitchgear.Reports
{
    public partial class rptJobSwitchgearRevisionForm : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobSwitchgearRevisionForm()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            RevisionNumber.Text = GetCurrentColumnValue("RevisionNumber").ToString();
            RevisionDate.Text = GetCurrentColumnValue("RevisionDate").ToString().Substring(0, 10);

        }
        
    }
}
