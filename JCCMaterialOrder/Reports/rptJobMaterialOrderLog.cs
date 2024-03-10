using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCMaterialOrder.Reports
{
    public partial class rptJobMaterialOrderLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobMaterialOrderLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
