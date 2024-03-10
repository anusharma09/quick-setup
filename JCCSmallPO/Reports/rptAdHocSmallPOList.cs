using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace JCCSmallPO.Reports
{
    public partial class rptAdHocSmallPOList : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAdHocSmallPOList()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
