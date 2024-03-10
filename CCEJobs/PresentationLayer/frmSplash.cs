using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using JCCBusinessLayer;


namespace CCEJobs.PresentationLayer
{
    partial class frmSplash : Form
    {
        int timerCounter;
        int i;
        private bool isTablesUpdated = false;

        public frmSplash()
        {
            InitializeComponent();

            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelProductVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelProductCopyright.Text = AssemblyCopyright;
        }

        #region Assembly Attribute Accessors

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
                // return Assembly.GetExecutingAssembly().GetName().Version.ToString();
                return StaticTables.DefaultValuelistForVersion;
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
        #endregion
        //
        private void timer1_Tick(object sender, EventArgs e)
        {


            if (i > 30)
            {
                lblUpdate.Text = "Loading";
                i = 0;
            }
            else
            {
                lblUpdate.Text = lblUpdate.Text + ".";
                i = i + 1;
            }
            timerCounter++;
            if (isTablesUpdated && timerCounter > 20)
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
        private void LoadTables()
        {
            StaticTables.PopulateStaticTables();
            RepositoryItems.UpdateRepositoryItems();
            isTablesUpdated = true;
            JCCPurchasing.BusinessLayer.StaticTables.PopulateStaticTables();
            CCEOTProjects.BusinessLayer.StaticTables.PopulateStaticTables();
        }
    }
}
