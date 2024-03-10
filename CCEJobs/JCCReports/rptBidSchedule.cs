using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptBidSchedule : DevExpress.XtraReports.UI.XtraReport
    {
        public enum LaborAnalysisView
        {
            List,
            Phase,
            Code,
            Employee,
            Week,
            HoursType,
            Craft
        }
        //
        public enum ReportTypeView
        {
            Detail,
            Summary
        }
        
        
        public rptBidSchedule()
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

        private void txtBidTo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (txtBidToType.Text == "OWNER")
                txtBidTo.Text = txtOwnerName.Text;
            else
                if (txtBidToType.Text == "CONTRACTOR")
                    txtBidTo.Text = txtContractorName.Text;
                else
                    txtBidTo.Text = "";
        }

        private void rptBidSchedule_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
           
        }

        private void txtMessage_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (txtBidDate.Text.Trim().Length > 0)
                {
                     if (Convert.ToDateTime(txtBidDate.Text) < DateTime.Today && txtJobStatus.Text.Trim() == "OPEN")
                     {
                         txtMessage.Text = "Please update this Estimate information. The BID DATE is older than the Report Date";
                         txtMessage.ForeColor = Color.Maroon;
                     }
                     else
                         txtMessage.Text = "";
                }
                else
                    txtMessage.Text = "";
            }
            catch (Exception ex)
            { }
        }


        private void txtTitle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtTitle.Text = " BID SCHEDULE - " + txtOfficeName.Text;
        }

       

    }
}
