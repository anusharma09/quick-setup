using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobDashboardDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobDashboardDetail()
        {
            InitializeComponent();
            if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                logo.Image = Properties.Resources.Dynalectric;
                txtCompany.Text = "DYNALECTRIC";
                txtAddress.Text = "";
                txtLicense.Text = "";
                txtFax.Text = "";
                txtPhone.Text = "";
            }
            else
                logo.Image = Properties.Resources.ContraCostaLogo;
        }
    }
}
