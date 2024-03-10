using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCSwitchgear.Reports
{
    public partial class rptJobSwitchgearReleaseLogSub : DevExpress.XtraReports.UI.XtraReport
    {
        string jobNumber = "";
        public rptJobSwitchgearReleaseLogSub()
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
