using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptWeeklyMillionDollar : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWeeklyMillionDollar()
        {
            InitializeComponent();
            if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                logo.Image = Properties.Resources.Dynalectric;
                txtCompany.Text = "DYNALECTRIC";
            }
            else
                logo.Image = Properties.Resources.ContraCostaLogo;
        }

        private void txtJobCityState_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtJobCityState.Text = txtJobCity.Text.Trim() + ", " + txtJobState.Text.Trim();
        }

    }
}
