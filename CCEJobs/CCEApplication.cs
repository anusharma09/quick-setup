using System;
using System.Collections.Generic;
using System.Text;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using JCCBusinessLayer;

//
//

namespace CCEJobs
{
    public class CCEApplication
    {
    
        public static string Connection =
            "Server=" + CCEJobs.Properties.Settings.Default.Server + "; " +
            "Database=" + CCEJobs.Properties.Settings.Default.database + "; " +
            "uid=" + Encryption.Decrypt(CCEJobs.Properties.Settings.Default.u1) + "; " +
            "pwd=" + Encryption.Decrypt(CCEJobs.Properties.Settings.Default.u2) + "; Connect Timeout=5000;  "; //; pooling='true'; Max Pool Size=200";
        public static string ApplicationName = "CCE Job Cost Codes";
        public static string FormsLocation =
            CCEJobs.Properties.Settings.Default.FormsLocation;
        public static string EstimatesLocation =
            CCEJobs.Properties.Settings.Default.EstimatesLocation;
        public static string JobsLocation =
            CCEJobs.Properties.Settings.Default.JobsLocation;
        public static string ExcelTemplatesLocation =
             CCEJobs.Properties.Settings.Default.ExcelTemplatesLocation;
        public static string Company =
             CCEJobs.Properties.Settings.Default.Company;
        public static string ProjectOpportunityLocation =
            CCEJobs.Properties.Settings.Default.ProjectOpportunityLocation;
        public static string LogFile =
            CCEJobs.Properties.Settings.Default.LogFile;
        public static string ProfilePicLocation =
            CCEJobs.Properties.Settings.Default.ProfilePicLocation;
        public static string DestinationPicLocation =
           CCEJobs.Properties.Settings.Default.DestinationPicLocation;
        //public static string ToolWatchDatabase =
        //    CCEJobs.Properties.Settings.Default.ToolwatchDatabase;

    }
}
