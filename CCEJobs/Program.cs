using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CCEJobs.PresentationLayer;
using JCCBusinessLayer;
using CCEJobs.Utilities;

//using System.Runtime.InteropServices;
namespace CCEJobs
{
    static class Program
    {

        public static HelpProvider programHlp = new HelpProvider();


       // [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
       // static extern ushort GlobalAddAtom(string lpString);
       // [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
       // static extern ushort GlobalFindAtom(string lpString);
       // [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
       // static extern ushort GlobalDeleteAtom(ushort atom);
       
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.UserSkins.OfficeSkins.Register();


            programHlp.HelpNamespace = Application.StartupPath.ToString() + "\\JobCostManagementSystem.chm";
         //   string atomStr = Application.ProductName + Application.ProductVersion + "1";
         //   ushort atom = GlobalFindAtom(atomStr);


         //   if (atom == 0)
           {

         //       atom = GlobalAddAtom(atomStr);
                try
                {

                    // Original Start-up
                    Security.Security.Connection = CCEApplication.Connection;
                    Security.Security.GetUserAccess();

                 //   if (Security.Security.UserJCCAccess == Security.Security.Access.NoAccess &&
                 //       Security.Security.UserJCCDashboardAccess == Security.Security.Access.NoAccess)
                 //       MessageBox.Show("You do not have access to the Application...!", CCEApplication.ApplicationName);
                 //   else
                 //   {


                        JCCReports.CCEApplication.Company = CCEApplication.Company;
                        JCCReports.CCEApplication.Connection = CCEApplication.Connection;

                        JCCBusinessLayer.CCEApplication.Company = CCEApplication.Company;
                        JCCBusinessLayer.CCEApplication.Connection = CCEApplication.Connection;
                        JCCBusinessLayer.CCEApplication.EstimatesLocation = CCEApplication.EstimatesLocation;
                        JCCBusinessLayer.CCEApplication.FormsLocation = CCEApplication.FormsLocation;
                        JCCBusinessLayer.CCEApplication.JobsLocation = CCEApplication.JobsLocation;
                        JCCBusinessLayer.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCBusinessLayer.CCEApplication.ExcelTemplatesLocation = CCEApplication.ExcelTemplatesLocation;
                        
                        JCCPurchasing.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCPurchasing.CCEApplication.Connection = CCEApplication.Connection;
                        JCCPurchasing.CCEApplication.Company = CCEApplication.Company;

                        CCEOTProjects.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        CCEOTProjects.CCEApplication.Connection = CCEApplication.Connection;
                        CCEOTProjects.CCEApplication.ProjectOpportunityLocation = CCEApplication.ProjectOpportunityLocation;
                        CCEOTProjects.CCEApplication.Company = CCEApplication.Company;


                        JCCEquipmentRental.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCEquipmentRental.CCEApplication.Connection = CCEApplication.Connection;
                        JCCEquipmentRental.CCEApplication.Company = CCEApplication.Company;

                        JCCMaterialOrder.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCMaterialOrder.CCEApplication.Connection = CCEApplication.Connection;
                        JCCMaterialOrder.CCEApplication.Company = CCEApplication.Company;

                        JCCDailyLog.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCDailyLog.CCEApplication.Connection = CCEApplication.Connection;
                        JCCDailyLog.CCEApplication.Company = CCEApplication.Company;

                        JCCTimeMaterial.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCTimeMaterial.CCEApplication.Connection = CCEApplication.Connection;
                        JCCTimeMaterial.CCEApplication.Company = CCEApplication.Company;

                        JCCSwitchgear.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCSwitchgear.CCEApplication.Connection = CCEApplication.Connection;
                        JCCSwitchgear.CCEApplication.Company = CCEApplication.Company;

                        JCCLightFixture.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCLightFixture.CCEApplication.Connection = CCEApplication.Connection;
                        JCCLightFixture.CCEApplication.Company = CCEApplication.Company;

                        JCCSmallPO.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCSmallPO.CCEApplication.Connection = CCEApplication.Connection;
                        JCCSmallPO.CCEApplication.Company = CCEApplication.Company;


                        JCCSubcontractDocument.CCEApplication.ApplicationName = CCEApplication.ApplicationName;
                        JCCSubcontractDocument.CCEApplication.Connection = CCEApplication.Connection;
                        JCCSubcontractDocument.CCEApplication.Company = CCEApplication.Company;


                        //
                        if (!Security.Security.hasAccess)
                            MessageBox.Show("You do not have access to the Application...!", CCEApplication.ApplicationName);
                        else
                        {
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            //frmSplash myForm = new frmSplash();

                            //myForm.Show();
                            Application.Run(new SystemSplashScreen());
                            
                            //StaticTables.PopulateStaticTables();
                            //JCCPurchasing.BusinessLayer.StaticTables.PopulateStaticTables();
                            //JCCEquipment.BusinessLayer.StaticTables.PopulateStaticTables();
                            //RepositoryItems.UpdateRepositoryItems();
                            //JCCEquipment.BusinessLayer.RepositoryItems.UpdateRepositoryItems();
                            //CCEOTProjects.BusinessLayer.StaticTables.PopulateStaticTables();
                            //CCEPayment.BusinessLayer.StaticTables.PopulateStaticTables();
                            
                            
                            
                            Application.Run(new frmMain());
                        }

                   // }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
           //     GlobalDeleteAtom(atom);
            }
        }
    }
}