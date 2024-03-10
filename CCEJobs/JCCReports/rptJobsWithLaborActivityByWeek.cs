using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using JCCReports;

namespace JCCReports
{
    public partial class rptJobsWithLaborActivityByWeek : DevExpress.XtraReports.UI.XtraReport
    {
        double reportTotalValue = 0;
        double subtotalValue = 0;

        public rptJobsWithLaborActivityByWeek()
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


        private void txtGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtGroup.Text = txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }



        private void txtSubTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtSubTotal.Text = "Count for: " + txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }

    

   
    

      
    }
}
