using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobPurchasingDetailNI : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobPurchasingDetailNI()
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

        private void GroupHeader2_AfterPrint(object sender, EventArgs e)
        {
            this.rptJobPurchasingDetailSubI1.FilterString = "[PO] = '" + txtPONumber.Text + "' ";
        }

    }
}
