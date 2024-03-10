using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobProgressSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobProgressSummary()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();

            SetReportAccess();
        }
        private void SetReportAccess()
        {
            if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
                Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
            {
                lblWIP1.Visible = true;
                lblWIP2.Visible = true;
                lblWIP3.Visible = true;
                lblWIP4.Visible = true;
                txtWIPCostToCompleteLaborHours100.Visible = true;
                txtWIPCostToCompleteLaborHours500.Visible = true;
                txtWIPCostToCompleteLaborHours.Visible = true;
                txtWIPCostToCompleteLabor.Visible = true;
                txtWIPCostToCompleteLabor100.Visible = true;
                txtWIPCostToCompleteLabor500.Visible = true; 
                txtWIPCostToCompleteMaterial.Visible = true;
                txtWIPCostToCompleteRental.Visible = true;
                txtWIPCostToCompleteSubcontract.Visible = true;
                txtWIPCostToCompleteDJC.Visible = true;
                txtWIPCostToComplete.Visible = true;
            }
            else
            {
                lblWIP1.Visible = false;
                lblWIP2.Visible = false;
                lblWIP3.Visible = false;
                lblWIP4.Visible = false;
                txtWIPCostToCompleteLaborHours100.Visible = false;
                txtWIPCostToCompleteLaborHours500.Visible = false;
                txtWIPCostToCompleteLaborHours.Visible = false;
                txtWIPCostToCompleteLabor.Visible = false;
                txtWIPCostToCompleteLabor100.Visible = false;
                txtWIPCostToCompleteLabor500.Visible = false;
                txtWIPCostToCompleteMaterial.Visible = false;
                txtWIPCostToCompleteRental.Visible = false;
                txtWIPCostToCompleteSubcontract.Visible = false;
                txtWIPCostToCompleteDJC.Visible = false;
                txtWIPCostToComplete.Visible = false;
            }
        }
    }
}
