using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCEJobs.Controls;
using JCCBusinessLayer;
using CCEJobs.Utilities;
using System.Reflection;
//
namespace CCEJobs.PresentationLayer
{
    public enum DashboardMenuItems
    {
        Jobs,
        JobsSummary,
        JobCostAnalysis
    }
    //
    public enum DefaultTab
    {
        Jobs,
        Dashboard,
        Purchasing,
        EquipmentRental,
        MaterialOrder,
        ProjectOpportunities,
        SmallPO,
        FieldOperation,
        Contacts,
        None
    }
    //
    public partial class frmMain : Form
    {
        ctlJobList jobList;
        ctlJobDashboard jobDashboard;
        ctlJobSummaryDashboard jobSummaryDashboard;
        JCCPurchasing.Controls.ctlPOList purchasing;
        JCCEquipmentRental.Controls.ctlEquipmentRentalList equipmentRental;
        JCCMaterialOrder.Controls.ctlMaterialOrderList materialOrder;
        JCCSmallPO.Controls.ctlSmallPOList smallPOList;
        public bool IsStarbuilderSynchronizationOn = true;
        DashboardMenuItems dashboardMenuItem;
        DefaultTab defaultTab = DefaultTab.None;
        CCEOTProjects.Controls.ctlOTProjectList projectOpportunities;
        ctlFieldOperationList fieldOperationList;
        ctlGlobalContacts globalContacts;

        public frmMain()
        {
            InitializeComponent();
            Program.programHlp.ResetShowHelp(this);
            Program.programHlp.SetHelpNavigator(this, HelpNavigator.TableOfContents);
            string path = Application.StartupPath;
            sharedDictionaryStorage1.Dictionaries[0].DictionaryPath = path + "\\american.xlg";
            //sharedDictionaryStorage1.Dictionaries[0].AlphabetPath = path + "\\american.xlg";
            sharedDictionaryStorage1.Dictionaries[1].DictionaryPath = path + "\\JCCCust.txt";
            // sharedDictionaryStorage1.Dictionaries[1].AlphabetPath = path + "\\JCCCust.txt";

            
             IsStarbuilderSynchronizationOn = StarbuilderSynching.IsSynchingActiveWithStarbuilder;

             if (Security.Security.UserJCCAccess == Security.Security.Access.NoAccess)
                navBarJobs.Visible = false;
            else
            {
                navBarJobs.Visible = true;
                jobList = new ctlJobList();
                if (defaultTab == DefaultTab.None)
                    defaultTab = DefaultTab.Jobs;
            }
            //
            if (Security.Security.UserJCCDashboardAccess == Security.Security.Access.NoAccess)
                navBarDashboard.Visible = false;
            else
            {
                navBarDashboard.Visible = true;
                jobDashboard = new ctlJobDashboard();
                jobSummaryDashboard = new ctlJobSummaryDashboard();
                dashboardMenuItem = DashboardMenuItems.Jobs;
                navBarViewJobsSummary.Visible = false;
                navBarViewJobsSummary.Dock = DockStyle.Bottom;
                if (defaultTab == DefaultTab.None)
                    defaultTab = DefaultTab.Dashboard;

            }
            //
            if (Security.Security.UserJCCPurchasingAccess == Security.Security.Access.NoAccess)
                navBarPurchasing.Visible = false;
            else
            {
                navBarPurchasing.Visible = true;
                purchasing = new JCCPurchasing.Controls.ctlPOList();
                if (defaultTab == DefaultTab.None)
                    defaultTab = DefaultTab.Purchasing;
            }
            //
            if (Security.Security.UserJCCEquipmentRentalAccess != Security.Security.Access.NoAccess)
            {
                navBarEquipmentRental.Visible = true;
                navBarMaterialOrder.Visible = true;
                equipmentRental = new JCCEquipmentRental.Controls.ctlEquipmentRentalList();
                materialOrder = new JCCMaterialOrder.Controls.ctlMaterialOrderList();
                if (defaultTab == DefaultTab.None)
                    defaultTab = DefaultTab.EquipmentRental;
            }
            else
            {
                navBarEquipmentRental.Visible = false;
                navBarMaterialOrder.Visible = false;
            }
            if (Security.Security.UserJCCProjectOpportunityAccess == Security.Security.Access.NoAccess) // ||
                navBarProjctOpportunities.Visible = false;
            else
            {
                projectOpportunities = new CCEOTProjects.Controls.ctlOTProjectList();
                if (defaultTab == DefaultTab.None)
                    defaultTab = DefaultTab.ProjectOpportunities;
            }
            if (Security.Security.UserJCCSmallPOAccess == Security.Security.Access.NoAccess) // ||
                navBarSmallPO.Visible = false;
            else
            {
                smallPOList = new JCCSmallPO.Controls.ctlSmallPOList();
                if (defaultTab == DefaultTab.None)
                    defaultTab = DefaultTab.SmallPO;
            }
            if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator || Security.Security.UserJCCFieldOperation == Security.Security.Access.JCCFieldOperation)
            {
                fieldOperationList = new ctlFieldOperationList();
                if (defaultTab == DefaultTab.None)
                    defaultTab = DefaultTab.FieldOperation;
            }
            else
            {
                navBarFieldOperation.Visible = false;
            }
            if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator || Security.Security.UserJCCGlobalContact == Security.Security.Access.JCCGlobalContact)
            {
                globalContacts = new ctlGlobalContacts();
                if (defaultTab == DefaultTab.None)
                    defaultTab = DefaultTab.Contacts;
            }
            else
            {
                navBarContacts.Visible = false;
            }
        }
        //
        //public string AssemblyVersion
        //{
        //    get
        //    {
        //        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        //    }
        //}
        private void frmMain_Load(object sender, EventArgs e)
        {
            string tabCaption = "";
            string version = StaticTables.DefaultValuelistForVersion;
            SetupUserEnvironment();
            //this.Text = this.Text + "         Server: " + CCEJobs.Properties.Settings.Default.Server + " - " +
            //    " Database: " + CCEJobs.Properties.Settings.Default.database + " - " +
            //    " User ID: " + Security.Security.LoginID;
            this.Text = version + "         Server: " + CCEJobs.Properties.Settings.Default.Server + " - " +
                " Database: " + CCEJobs.Properties.Settings.Default.database + " - " +
                " User ID: " + Security.Security.LoginID;
            switch (defaultTab)
            {
                case DefaultTab.Jobs:
                    tabCaption = "Jobs";
                    break;
                case DefaultTab.Dashboard:
                    tabCaption = "Dashboard";
                    break;
                case DefaultTab.Purchasing:
                    tabCaption = "Purchasing";
                    break;
                case DefaultTab.EquipmentRental:
                    tabCaption = "Equipment Rental";
                    break;
                case DefaultTab.MaterialOrder:
                    tabCaption = "Material Order";
                    break;
                case DefaultTab.ProjectOpportunities:
                    tabCaption = "Project Opportunities";
                    break;
                case DefaultTab.SmallPO:
                    tabCaption = "Small PO";
                    break;
                case DefaultTab.FieldOperation:
                    tabCaption = "Field Operation";
                    break;
                case DefaultTab.Contacts:
                    tabCaption = "Contacts";
                    break;
            }
            ActiveTab(tabCaption);
            this.Opacity = 1;
        }
        //
        private void radioGroupJobView_SelectedIndexChanged(object sender, EventArgs e)
        {
            jobList.UpdateListView((JobListView)radioGroupJobView.SelectedIndex);
        }
        // 
        private void navBarMain_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            ActiveTab(e.Group.Caption);
        }
        //
        private void ActiveTab(string tabCaption)
        {
            switch (tabCaption)
            {
                case "Purchasing":
                    panMain.Controls.Clear();
                    panMain.Controls.Add(purchasing);
                    purchasing.Dock = DockStyle.Fill;
                    break;
                case "Jobs":
                    panMain.Controls.Clear();
                    panMain.Controls.Add(jobList);
                    jobList.Dock = DockStyle.Fill;
                    break;
                case "Dashboard":
                    panMain.Controls.Clear();
                    switch (dashboardMenuItem)
                    {
                        case DashboardMenuItems.Jobs:
                            panMain.Controls.Add(jobDashboard);
                            jobDashboard.Dock = DockStyle.Fill;
                            // Program.programHlp.ResetShowHelp(this);
                            // Program.programHlp.SetHelpNavigator(this, HelpNavigator.TableOfContents);

                            //Program.programHlp.SetHelpNavigator(this, HelpNavigator.TopicId);
                            //Program.programHlp.SetHelpString(this, "1006");

                            break;
                        case DashboardMenuItems.JobsSummary:
                            panMain.Controls.Add(jobSummaryDashboard);
                            jobSummaryDashboard.Dock = DockStyle.Fill;
                            //Program.programHlp.ResetShowHelp(this);
                            //Program.programHlp.SetHelpNavigator(this, HelpNavigator.TableOfContents);
                            //Program.programHlp.SetHelpNavigator(this, HelpNavigator.TopicId);
                            // Program.programHlp.SetHelpString(this, "1007");

                            break;
                    }
                    break;
                case "Equipment Rental":
                    panMain.Controls.Clear();
                    panMain.Controls.Add(equipmentRental);
                    equipmentRental.Dock = DockStyle.Fill;
                    break;
                case "Material Order":
                    panMain.Controls.Clear();
                    panMain.Controls.Add(materialOrder);
                    materialOrder.Dock = DockStyle.Fill;
                    break;
                case "Project Opportunities":
                    panMain.Controls.Clear();
                    panMain.Controls.Add(projectOpportunities);
                    projectOpportunities.Dock = DockStyle.Fill;
                    break;
                case "Small PO":
                    panMain.Controls.Clear();
                    panMain.Controls.Add(smallPOList);
                    smallPOList.Dock = DockStyle.Fill;
                    break;
                case "Field Operations":
                    panMain.Controls.Clear();
                    panMain.Controls.Add(fieldOperationList);
                    fieldOperationList.Dock = DockStyle.Fill;
                    break;
                case "Contacts":
                    panMain.Controls.Clear();
                    panMain.Controls.Add(globalContacts);
                    globalContacts.Dock = DockStyle.Fill;
                    break;
            }
        }
        //
        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mnuContents":
                    Help.ShowHelp(this, Program.programHlp.HelpNamespace, HelpNavigator.TableOfContents);
                    break;
                case "mnuAbout":
                    frmAbout frmAbount = new frmAbout();
                    frmAbount.ShowDialog();
                    break;
                case "mnuExit":
                    this.Close();
                    break;
                case "mnuProgressSummaryMonthEnd":
                    frmJobProgressHistory frmJobProgressHistory = new frmJobProgressHistory();
                    frmJobProgressHistory.ShowDialog();
                    break;
                case "mnuUserSecurity":
                    Security.Security.StartSecurity();
                    break;
                case "mnuJobSystemDefaultValues":
                    frmJobSystemDefaultValues f = new frmJobSystemDefaultValues();
                    f.ShowDialog();
                    break;

                case "mnuImportJob":
                    frmImportJob ff = new frmImportJob();
                    ff.ShowDialog();
                    break;
                case "mnuSubcontractDocuments":
                    JCCSubcontractDocument.frmSubcontractMaintenance fff = new JCCSubcontractDocument.frmSubcontractMaintenance();
                    fff.ShowDialog();
                    break;

                case "mnuTaxRate":
                    frmTaxRate fTax = new frmTaxRate();
                    fTax.ShowDialog();
                    break;
                case "mnuOnOffSynchronizationwithStarbuilder":
                    var caption = IsStarbuilderSynchronizationOn ? "Turn Off" : "Turn On";
                    if (MessageBox.Show("You are going to " + caption + " synching with Star Builder. Are you sure ?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        IsStarbuilderSynchronizationOn = IsStarbuilderSynchronizationOn ? false : true;
                        StarbuilderSynching.UpdateSynching(IsStarbuilderSynchronizationOn);
                        if (IsStarbuilderSynchronizationOn)
                        {
                            StarbuilderSynching.syncChangeOrders();
                            MessageBox.Show("Synching with Star Builder is started and would be completed within 1 hour.", CCEApplication.ApplicationName);
                        }
                        mnuOnOffSynchronizationwithStarbuilder.Caption = IsStarbuilderSynchronizationOn ? "Turn OFF Synching with Star builder" : "Turn ON Synching with Star builder";
                    }
                    break;
                case "mnuMasterAgreementNumber":
                    Security.Security.StartMasterAgreement();
                    break;
            }
        }

        //
        private void SetupUserEnvironment()
        {
            if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator ||
                Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
                Security.Security.UserJCCImportStarbuilderJobsAccess == Security.Security.Access.JCCImportStarbuilderJobs

                )
            {
                mnuUtilities.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
                {
                    mnuApplicationAdministration.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    mnuJCCAdministration.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    mnuJobSystemDefaultValues.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    mnuImportJob.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    mnuOnOffSynchronizationwithStarbuilder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    mnuTaxRate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    mnuOnOffSynchronizationwithStarbuilder.Caption = IsStarbuilderSynchronizationOn ? "Turn OFF Synching with Star builder" : "Turn ON Synching with Star builder";

                }
                else
                {
                    if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator)
                    {
                        mnuJCCAdministration.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        mnuApplicationAdministration.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        mnuJobSystemDefaultValues.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
                if (Security.Security.UserJCCImportStarbuilderJobsAccess == Security.Security.Access.JCCImportStarbuilderJobs)
                    mnuImportJob.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            }
            else
                mnuUtilities.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        //
        private void radioGroupPOView_SelectedIndexChanged(object sender, EventArgs e)
        {
            purchasing.UpdateListView((JCCPurchasing.Controls.POListView)radioGroupPOView.SelectedIndex);
        }

        //
        private void navBarDashboard_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            switch (e.Link.Caption)
            {
                case "Jobs":
                    if (dashboardMenuItem != DashboardMenuItems.Jobs)
                    {
                        dashboardMenuItem = DashboardMenuItems.Jobs;
                        panMain.Controls.Clear();
                        panMain.Controls.Add(jobDashboard);
                        jobDashboard.Dock = DockStyle.Fill;
                        navBarViewJobsSummary.Visible = false;
                        navBarViewJobsSummary.Dock = DockStyle.Bottom;
                        navBarViewJobs.Visible = true;
                        navBarViewJobs.Dock = DockStyle.Top;
                        //Program.programHlp.ResetShowHelp(this);
                        //Program.programHlp.SetHelpNavigator(this, HelpNavigator.TableOfContents);
                        // Program.programHlp.SetHelpNavigator(this, HelpNavigator.TopicId);
                        // Program.programHlp.SetHelpString(this, "1006");



                    }
                    break;
                case "Jobs Summary":
                    if (dashboardMenuItem != DashboardMenuItems.JobsSummary)
                    {
                        dashboardMenuItem = DashboardMenuItems.JobsSummary;
                        panMain.Controls.Clear();
                        panMain.Controls.Add(jobSummaryDashboard);
                        jobSummaryDashboard.Dock = DockStyle.Fill;
                        navBarViewJobs.Visible = false;
                        navBarViewJobs.Dock = DockStyle.Bottom;
                        navBarViewJobsSummary.Visible = true;
                        navBarViewJobsSummary.Dock = DockStyle.Top;
                        //Program.programHlp.ResetShowHelp(this);
                        //Program.programHlp.SetHelpNavigator(this, HelpNavigator.TableOfContents);
                        //Program.programHlp.SetHelpNavigator(this, HelpNavigator.TopicId);
                        //Program.programHlp.SetHelpString(this, "1007");

                    }
                    break;
            }
        }
        //
        private void radioGroupJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            jobDashboard.UpdateView((JobDashboardView)radioGroupJobs.SelectedIndex);
        }
        //
        private void radioGroupJobsSummary_SelectedIndexChanged(object sender, EventArgs e)
        {
            jobSummaryDashboard.UpdateView((JobSummaryDashboardView)radioGroupJobsSummary.SelectedIndex);
        }

        //
        private void radioGroupEquipmentRentalView_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipmentRental.UpdateListView((JCCEquipmentRental.Controls.EquipmentRentalListView)radioGroupEquipmentRentalView.SelectedIndex);
        }

        private void radioGroupMaterialOrderView_SelectedIndexChanged(object sender, EventArgs e)
        {
            materialOrder.UpdateListView((JCCMaterialOrder.Controls.MaterialOrderListView)radioGroupMaterialOrderView.SelectedIndex);
        }

        private void radioGroupProjectOpportunitiesView_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectOpportunities.UpdateListView((CCEOTProjects.Controls.ProjectListView)radioGroupProjectOpportunitiesView.SelectedIndex);
        }

        private void radioGroupSmallPOView_SelectedIndexChanged(object sender, EventArgs e)
        {
            smallPOList.UpdateListView((JCCSmallPO.Controls.SmallPOListView)radioGroupSmallPOView.SelectedIndex);
        }


    }
}