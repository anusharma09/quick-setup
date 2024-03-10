using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace JCCContactManagement.Reports
{
    public partial class rptAdHocContactListByStatus : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAdHocContactListByStatus()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
