using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobLaborAnalysis : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobLaborAnalysis()
        {
            InitializeComponent();
            if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                logo.Image = Properties.Resources.Dynalectric;
                txtCompany.Text = "DYNALECTRIC";
                txtLicense.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
                txtFax.Text = "";
            }
            else
                logo.Image = Properties.Resources.ContraCostaLogo;
        }
    }
}
