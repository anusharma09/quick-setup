using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptWeeklyEstimateBudget : DevExpress.XtraReports.UI.XtraReport
    {
        double reportTotalValue = 0;
        double subtotalValue = 0;

        public rptWeeklyEstimateBudget()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
        //
        private void txtGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtGroup.Text = txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }
        //
        private void txtTitle2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtTitle2.Text = "Report and Print Date: " + DateTime.Today.Date.ToShortDateString();
        }
        //
        private void txtSubTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtSubTotal.Text = "Total for: " + txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }
    }
}
