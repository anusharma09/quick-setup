using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCPurchasing.Reports
{
    public partial class rptPOsWithNoInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPOsWithNoInvoice()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void txtGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtGroup.Text = txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }

        private void txtSubTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtSubTotal.Text = "Total for: " + txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }
    }
}
