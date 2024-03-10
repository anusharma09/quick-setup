using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace JCCReports
{
    public partial class rptJobTransmittal : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobTransmittal()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void xrLabel33_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(xrLabel33.Text) && xrLabel33.Text.Trim().Length > 0)
                chkOther.CheckState = System.Windows.Forms.CheckState.Checked;
        }

        private void RemarksText_BeforePrint ( object sender, System.Drawing.Printing.PrintEventArgs e )
        {
            RemarksText.Rtf = ((DataRowView)GetCurrentRow()).Row["RemarkOrReply"].ToString();
        }
    }
}
