using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobProgressSummaryHistoryWIP : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobProgressSummaryHistoryWIP()
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

        private void xrLabel18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!String.IsNullOrEmpty(xrLabel18.Text))
            if (Convert.ToDouble(xrLabel18.Text.Replace("%","")) != 0)
                xrLabel18.Text = Convert.ToString(Convert.ToDouble(xrLabel18.Text.Replace("%","")) / 100)+ "%"; 
        }
     
  
   
    

      
    }
}
