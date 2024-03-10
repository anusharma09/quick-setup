using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Text;

namespace JCCReports
{
    public partial class rptJobPrelimInfo : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobPrelimInfo ()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
        private void GeneralContractorInfo_BeforePrint ( object sender, System.Drawing.Printing.PrintEventArgs e )
        {
            StringBuilder rtfText = new StringBuilder();
            string customerAddress = ((DataRowView)GetCurrentRow()).Row["CustomerAddress"].ToString();
            string customerName = ((DataRowView)GetCurrentRow()).Row["CustomerName"].ToString();
            string customerCity = ((DataRowView)GetCurrentRow()).Row["CustomerCityStateZip"].ToString();
            string contractorName = ((DataRowView)GetCurrentRow()).Row["ContractorName"].ToString();
            string contractorAddress = ((DataRowView)GetCurrentRow()).Row["ContractorAddress"].ToString();
            string contractorCity = ((DataRowView)GetCurrentRow()).Row["ContractorCityStateZip"].ToString();
            if (!Convert.ToBoolean(((DataRowView)GetCurrentRow()).Row["ContractorAsCustomer"]))
            {
                rtfText.Append(customerName + Environment.NewLine + customerAddress + Environment.NewLine + customerCity);
                rtfText.Append(Environment.NewLine + Environment.NewLine+ contractorName + Environment.NewLine + contractorAddress.Replace(",","") + Environment.NewLine + contractorCity);
            }
            else
                rtfText.Append(customerName + Environment.NewLine + customerAddress + Environment.NewLine + customerCity);
            GeneralContractorInfo.Rtf = rtfText.ToString();
        }
        private void xrBondingInfo_BeforePrint ( object sender, System.Drawing.Printing.PrintEventArgs e )
        {
            StringBuilder rtfText = new StringBuilder();
            if (((DataRowView)GetCurrentRow()).Row["BondingInfoName"].ToString() == "N/A")
            {
                rtfText.Append("N/A");
            }
            else
            {
                rtfText.Append("ALLIANT INSURANCE SERVICES, INC.");
                rtfText.Append(Environment.NewLine);
                rtfText.Append("333 EARLE OVINGTON BOULEVARD, SUITE 700");
                rtfText.Append(Environment.NewLine);
                rtfText.Append("UNIONDALE, NY 11553");
                rtfText.Append(Environment.NewLine);
                rtfText.Append(Environment.NewLine);
                rtfText.Append("TRAVELERS CASUALTY & SURETY OF AMERICA & FEDERAL INS. CO.");
                rtfText.Append(Environment.NewLine);
                rtfText.Append("ONE TOWER SQ. (TR)");
                rtfText.Append(Environment.NewLine);
                rtfText.Append("HARTFORD, CT 06183 (TR) &");
                rtfText.Append(Environment.NewLine);
                rtfText.Append("15 MOUNTAIN VIEW RD. (FE)");
                rtfText.Append(Environment.NewLine);
                rtfText.Append("WARREN, NJ 07059 (FE)");
            }
            xrBondingInfo.Rtf = rtfText.ToString();
        }
    }
}
