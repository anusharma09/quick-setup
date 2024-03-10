using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobPurchasingDetailN : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobPurchasingDetailN()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void GroupHeader2_AfterPrint(object sender, EventArgs e)
        {
            this.rptJobPurchasingDetailSub1.FilterString = "[PO] = '" + txtPONumber.Text + "' ";
        }

    }
}
