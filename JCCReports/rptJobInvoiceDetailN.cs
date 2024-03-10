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
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void GroupHeader2_AfterPrint(object sender, EventArgs e)
        {
           this.rptJobInvoiceDetailSub1.FilterString = "[Inv No] = '" + txtInvoiceNumber.Text + "'";
           this.rptJobInvoiceDetailSub11.FilterString = "JobInvoiceID = '" + txtJobInvoiceID.Text + "'";   
        }
    }
}
