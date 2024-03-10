using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCPurchasing.Reports
{
    public partial class rptAdHocPurchaseOrdersListByVendor : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAdHocPurchaseOrdersListByVendor()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
