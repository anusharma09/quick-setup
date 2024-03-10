using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace JCCContactManagement.Reports
{
    public partial class rptAdHocContactListByIndustry : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAdHocContactListByIndustry()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
