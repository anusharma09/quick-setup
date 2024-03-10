using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCSwitchgear.Reports
{
    public partial class rptJobSwitchgearReleaseForm : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobSwitchgearReleaseForm()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
        
    }
}
