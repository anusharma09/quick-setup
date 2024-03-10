using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace JCCReports
{
    public partial class rptChangeOrderContract : DevExpress.XtraReports.UI.XtraReport
    {
        public rptChangeOrderContract()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();

            float SubcontractsAmount = 0;
            float TotalSubcontracts = 0;
            float SubcontractAdministrationCost = 0;

           
           
            TotalSubcontracts = SubcontractsAmount + SubcontractAdministrationCost;
            TotalSubcontractsValue.Text = "Atef Bakir"; // TotalSubcontracts.ToString();
            ApprenticeCost.DataBindings.Add("Text", this.DataSource, "ApprenticeCost","{0:c2}");
            ApprenticeLaborRate.DataBindings.Add("Text", this.DataSource, "ApprenticeLaborRate","{0:c2}");
            EstimatedApprenticeHours.DataBindings.Add("Text", this.DataSource, "EstimatedApprenticeHours","{0:n2}");
            Superintendent.DataBindings.Add("Text", this.DataSource, "SuperintendentCost", "{0:c2}");
        }
        
        private void xrLabel121_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel120_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void TotalSubcontractsValue_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // SubcontractsAmount
            // SubcontractAdministrationCost
            decimal amount = 0;
            decimal cost = 0;
            decimal total = 0;
            try
            {
                decimal.TryParse(GetCurrentColumnValue("SubcontractsAmount").ToString(), out amount);
            }
            catch { }
            try
            {
                decimal.TryParse(GetCurrentColumnValue("SubcontractAdministrationCost").ToString(), out cost);
            }
            catch { }
            total = amount + cost;
            TotalSubcontractsValue.Text = String.Format("{0:c2}", total);
        }

      
    }
}
