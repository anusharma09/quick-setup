using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptPrequalSheet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPrequalSheet()
        {
            InitializeComponent();
            if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                logo.Image = Properties.Resources.Dynalectric;
                txtCompany.Text = "DYNALECTRIC";
                txtAddress.Text = "";
                txtFax.Text = "";
                txtLicense.Text = "";
                txtPhone.Text = "";
            }
            else
                logo.Image = Properties.Resources.ContraCostaLogo;
        }

    }
}
