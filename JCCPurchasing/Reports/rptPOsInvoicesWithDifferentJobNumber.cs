using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCPurchasing.Reports
{
    public partial class rptPOsInvoicesWithDifferentJobNumber : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPOsInvoicesWithDifferentJobNumber()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
