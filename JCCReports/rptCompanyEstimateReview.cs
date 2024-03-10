using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptCompanyEstimateReview : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCompanyEstimateReview()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
     
        private void txtOwner_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string slash = "";
            if (txtCustomerClass.Text.Trim().Length > 0)
                slash = " ** ";
            if (txtCustomerClass.Text.Trim() ==  "OWNER/DEVELOPER")
                txtOwner.Text = txtCustomerName.Text.Trim() + slash + txtCustomerClass.Text.Trim();
            else
                txtOwner.Text = txtContractorName.Text.Trim() + slash + txtCustomerClass.Text.Trim();
        }
    }
}
