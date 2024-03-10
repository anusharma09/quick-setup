using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptWeeklyEstimateSuccessful : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWeeklyEstimateSuccessful()
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

        // Current Report
        private void txtValue_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string jobStatus = txtJobStatus.Text.Trim();
            string preBidAmount = txtPreBidAmount.Text.Trim().Replace(",","").Replace("$","");
            string jobFinalContractAmount = txtJobFinalContractAmount.Text.Trim().Replace(",","").Replace("$","");

        
            if (jobStatus == "PENDING" || jobStatus == "LOST" || jobStatus == "WON")
            {
                txtValue.Text = String.Format("{0:c0}", Convert.ToDouble(jobFinalContractAmount));
            }
            else
            {
                if (jobStatus == "OPEN")
                {
                    txtValue.Text = String.Format("{0:c0}", Convert.ToDouble(preBidAmount));
                }
                else
                {
                    txtValue.Text = String.Format("{0:c0}", Convert.ToDouble("0")); 
                }

            }

        }
       
        private void txtGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtGroup.Text = txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }

        private void txtTitle2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtStartDate.Text) && String.IsNullOrEmpty(txtEndDate.Text))
                txtTitle2.Text = "For Week: " + txtStartDate.Text.Substring(0, 11) + " - To: " + txtEndDate.Text.Substring(0, 11);
            else
                txtTitle2.Text = "";
        }

        private void txtSubTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtSubTotal.Text = "Total for: " + txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }

   
    

      
    }
}
