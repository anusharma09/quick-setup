using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobInvoiceDetailN : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobInvoiceDetailN()
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
           this.rptJobInvoiceDetailSub1.FilterString = "[Inv No] = '" + txtInvoiceNumber.Text + "'";   
        }

    }
}
