using System;
using System.Reflection;
using System.Threading;
using JCCBusinessLayer;

using DevExpress.XtraSplashScreen;

namespace CCEJobs.Utilities
{
    public partial class SystemSplashScreen : SplashScreen
    {
        int timerCounter;
        int i;
        private bool isTablesUpdated = false;
        public SystemSplashScreen()
        {
            InitializeComponent();
            StaticTables.PopulateStaticTables();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelProductVersion.Text = String.Format("Version {0}", StaticTables.DefaultValuelistForVersion);
            this.labelProductCopyright.Text = AssemblyCopyright;
            labelProductName.BackColor = System.Drawing.Color.Transparent;
        }

        #region Overrides

        //public override void ProcessCommand(Enum cmd, object arg)
        //{
        //    base.ProcessCommand(cmd, arg);
        //}

        #endregion

        public enum SplashScreenCommand
        {
        }


        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        //
        public string AssemblyVersion
        {
            get
            {
                return StaticTables.DefaultValuelistForVersion;
                //return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        //
        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        //
        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        //
        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        //
        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            timerCounter++;
            if ( timerCounter > 30)
            {
                this.Close();
            }
        }
        //
        private void frmSplash_Activated(object sender, EventArgs e)
        {
            Thread th = new Thread(LoadTables);
            th.Start();
            isTablesUpdated = true;
        }
        //
        private   void LoadTables()
        {
             //StaticTables.PopulateStaticTables();
            RepositoryItems.UpdateRepositoryItems();
            //isTablesUpdated = true;
             JCCPurchasing.BusinessLayer.StaticTables.PopulateStaticTables();
             CCEOTProjects.BusinessLayer.StaticTables.PopulateStaticTables();
           // this.labelProductVersion.Text = StaticTables.DefaultValuelistForVersion;
            isTablesUpdated = true;
        }
    }
}