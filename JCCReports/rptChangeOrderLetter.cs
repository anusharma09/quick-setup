using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptChangeOrderLetter : DevExpress.XtraReports.UI.XtraReport
    {
        public rptChangeOrderLetter()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void rptChangeOrderLetter_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            LetterWorkDescription.Rtf = GetCurrentColumnValue("LetterWorkDescription").ToString();
            ChangeOrderStipulationsParagraph1.Rtf = GetCurrentColumnValue("ChangeOrderStipulationsParagraph1").ToString();
            ChangeOrderStipulationsParagraph2.Rtf = GetCurrentColumnValue("ChangeOrderStipulationsParagraph2").ToString();
            LetterExclusion.Rtf = GetCurrentColumnValue("LetterExclusion").ToString();
        }

        private void Revision_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (Revision.Text.Trim().Length == 0)
                lblRev.Visible = false;
        }
    }
}
