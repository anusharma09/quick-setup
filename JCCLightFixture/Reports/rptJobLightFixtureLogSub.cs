using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCLightFixture.Reports
{
    public partial class rptJobLightFixtureLogSub : DevExpress.XtraReports.UI.XtraReport
    {
        string jobNumber = "";
        public rptJobLightFixtureLogSub()
        {
            InitializeComponent();  
        }
        public string JobNumber
        {
            set
            {
                jobNumber = value;
            }
        }
    }
}
