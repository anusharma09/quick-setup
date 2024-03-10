using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace JCCReports
{
   public class CCEApplication
    {
        public static string Connection = "";
           // "Server=" + JCCBusinessLayer.Settings.Default.Server + "; " +
           // "Database=" + JCCBusinessLayer.Settings.Default.database + "; " +
           // "uid=" + Encryption.Decrypt(JCCBusinessLayer.Settings.Default.u1) + "; " +
           // "pwd=" + Encryption.Decrypt(JCCBusinessLayer.Settings.Default.u2) + "; Connect Timeout=0 "; //; pooling='true'; Max Pool Size=200";
        public static string ApplicationName = "CCE Job Cost Codes";
        public static string FormsLocation = "";
            //JCCBusinessLayer.Settings.Default.FormsLocation;
        public static string EstimatesLocation = "";
            // JCCBusinessLayer.Settings.Default.EstimatesLocation;
        public static string JobsLocation = "";
            //JCCBusinessLayer.Settings.Default.JobsLocation;
        public static string ExcelTemplatesLocation = "";
       public static string Company = "";
             //JCCBusinessLayer.Settings.Default.ExcelTemplatesLocation;
    }
}


