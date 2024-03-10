using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobByCostCodes : DevExpress.XtraReports.UI.XtraReport
    {
        double reportTotalValue = 0;
        double subtotalValue = 0;
        string jobNumber = "";

        public rptJobByCostCodes()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }


        private void txtGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (txtOffice.Text.Trim().Length > 0)
                txtGroup.Text = txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }

        private void txtTitle2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          //  txtTitle2.Text = "Report and Print Date: " + DateTime.Today.Date.ToShortDateString();
        }

        private void txtSubTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (txtOffice.Text.Trim().Length > 0)
                txtSubTotal.Text = "Total for: " + txtOffice.Text.Trim() + " - " + txtDepartment.Text.Trim();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataRowView r = (DataRowView)GetCurrentRow();
            if (r != null)
            {
                if (r["job_no"].ToString() != jobNumber)
                {
                    jobNumber = r["job_no"].ToString();
                    txtJobName.Visible = true;
                    txtJobNumber.Visible = true;
                    txtValue.Visible = true;

                }
                else
                {
                    txtJobName.Visible = false;
                    txtJobNumber.Visible = false;
                    txtValue.Visible = false;
                }
            }
        }

    

   
    

      
    }
}
