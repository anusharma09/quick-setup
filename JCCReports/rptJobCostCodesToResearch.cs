using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace JCCReports
{
    public partial class rptJobCostCodesToResearch : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobCostCodesToResearch()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            float estPerFattor = 0;
            float costPerFactor = 0;
            float committedHrs = 0;
            float committedQty = 0;

            DataRowView r = (DataRowView)GetCurrentRow();

            estPerFattor =  float.Parse( r["Estimated Perf Factor"].ToString());
            costPerFactor = float.Parse(r["Revised Perf Factor"].ToString());
            committedHrs = float.Parse(r["Committed Hrs"].ToString());
            committedQty = float.Parse(r["Committed Qty"].ToString());

            if (estPerFattor > 1.001 || costPerFactor > 1.001)
            {
                Detail.StyleName = styleBlue.Name;
            }
            else
            {
                if (committedHrs > 0 && committedQty == 0)
                    Detail.StyleName = styleRed.Name;
                else
                    Detail.StyleName = styleWhite.Name;
            }
        }

    }
}
