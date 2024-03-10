using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptPreJobPlanning : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPreJobPlanning()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void txtGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtGroup.Text = txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }

        private void xrLabel8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrLabel8.Text == "01/01/1900")
                xrLabel8.Text = "";
        }

        private void xrLabel9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrLabel9.Text == "01/01/1900")
                xrLabel9.Text = "";
        }

        private void xrLabel10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrLabel10.Text == "01/01/1900")
                xrLabel10.Text = "";
        }

    }
}
