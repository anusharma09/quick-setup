using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCPurchasing.Reports
{
    public partial class rptAdHocPurchaseOrdersListByProjectManager : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAdHocPurchaseOrdersListByProjectManager()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
