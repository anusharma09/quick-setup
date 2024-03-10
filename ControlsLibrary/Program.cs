using System;
using System.Collections.Generic;
using System.Windows.Forms;

//using System.Runtime.InteropServices;
namespace  ControlsLibrary
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
           


            programHlp.HelpNamespace = Application.StartupPath.ToString() + "\\JobCostManagementSystem.chm";
         //   string atomStr = Application.ProductName + Application.ProductVersion + "1";
         //   ushort atom = GlobalFindAtom(atomStr);


         //   if (atom == 0)
           {

         //       atom = GlobalAddAtom(atomStr);
                try
                {

    
         
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            //frmSplash myForm = new frmSplash();

                            //myForm.Show();
                            Application.Run(new Form1());
                            
                            //StaticTables.PopulateStaticTables();
                            //JCCPurchasing.BusinessLayer.StaticTables.PopulateStaticTables();
                            //JCCEquipment.BusinessLayer.StaticTables.PopulateStaticTables();
                            //RepositoryItems.UpdateRepositoryItems();
                            //JCCEquipment.BusinessLayer.RepositoryItems.UpdateRepositoryItems();
                            //CCEOTProjects.BusinessLayer.StaticTables.PopulateStaticTables();
                            //CCEPayment.BusinessLayer.StaticTables.PopulateStaticTables();
                            
                            
                            
                           // Application.Run(new MSWord());
                        

                   // }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
           //     GlobalDeleteAtom(atom);
            }
        }
    }
}