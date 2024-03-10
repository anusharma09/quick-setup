using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobSummaryDashboardSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobSummaryDashboardSummary()
        {
            InitializeComponent();
            if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                logo.Image = Properties.Resources.Dynalectric;
                txtCompany.Text = "DYNALECTRIC";
                txtAddress.Text = "";
                txtLicense.Text = "";
                txtPhone.Text = "";
                txtFax.Text = "";
            }
            else
                logo.Image = Properties.Resources.ContraCostaLogo;
        }

    }
}
