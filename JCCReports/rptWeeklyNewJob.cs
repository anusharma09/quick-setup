using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptWeeklyNewJob : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWeeklyNewJob()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
        }


        private void txtDepartmentTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtDepartmentTotal.Text = "Total for: " + txtOffice.Text.Trim() + " - " + txtDepartment.Text;
        }

        private void txtGroupHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtGroupHeader.Text = txtOffice.Text.Trim() + " - " + txtDepartment.Text;
        }
    }
}
