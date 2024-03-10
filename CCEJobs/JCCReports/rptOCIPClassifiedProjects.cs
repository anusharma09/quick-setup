using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptOCIPClassifiedProjects : DevExpress.XtraReports.UI.XtraReport
    {
        public rptOCIPClassifiedProjects()
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


        private void txtGroupHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtGroupHeader.Text = txtOffice.Text.Trim() + " - " + txtDepartment.Text;
        }

    }
}
