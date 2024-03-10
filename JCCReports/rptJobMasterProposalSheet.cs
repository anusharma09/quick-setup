using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace JCCReports
{
    public partial class rptJobMasterProposalSheet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobMasterProposalSheet()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
          //  txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void RFIText_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Desription.Rtf = ((DataRowView)GetCurrentRow()).Row["Desription"].ToString();
        }

        private void RFIResponse_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Clarification.Rtf = ((DataRowView)GetCurrentRow()).Row["Clarification"].ToString();
        }

        private void rptJobRFISheet_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
               
        }

        private void CostImpact_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           // CostImpact.CheckState = ((DataRowView)GetCurrentRow()).Row["CostImpactYesNo"].ToString() == "True" ? 
               // System.Windows.Forms.CheckState.Unchecked: System.Windows.Forms.CheckState.Checked;
        }

        private void GenInfo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GenInfo.Rtf = ((DataRowView)GetCurrentRow()).Row["GenInfo"].ToString();
        }

        private void Alternate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Alternate.Rtf = ((DataRowView)GetCurrentRow()).Row["Alternate"].ToString();
        }

        private void Exclusion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Exclusion.Rtf = ((DataRowView)GetCurrentRow()).Row["Exclusion"].ToString();
        }

        private void LeadTime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            LeadTime.Rtf = ((DataRowView)GetCurrentRow()).Row["LeadTime"].ToString();
        }
    }
}
