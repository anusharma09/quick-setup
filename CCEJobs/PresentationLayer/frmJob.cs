using CCEJobs.Controls;
using JCCBusinessLayer;
using JCCReports;
using Security.BusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CCEJobs.PresentationLayer
{
    public partial class frmJob : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        protected Security.Security.JobCaller formCaller;
        protected string jobID;
        protected BindingSource bindingSource;
        protected System.Collections.Hashtable recordHashTable = new System.Collections.Hashtable();
        protected bool dataChanged;
        private string jobStatus;
        private bool errorMessages = false;
        private string starbuilderJobNumber = "0";
        private bool log = false;
        private bool isBidInfo = false;
        private bool isWeeklyQuantity = false;
        private bool isJobProgress = false;
        private bool isJobProgressSummary = false;
        private bool isLaborFeedback = false;
        private string currentModule = "";
        private string jobStatusBefore = "";
        private bool callFromUpdateJob = true;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        protected bool isFourDigit = false;
        protected int isReadOnly = 0;

        //
        private enum ClickedButton
        {
            Next,
            Previous,
            Delete,
            New,
            Save,
            Undo,
            Print,
            Close
        };
        //
        public frmJob()
        {
            InitializeComponent();

        }
        //
        public frmJob(string jobID, BindingSource bindingSource, Security.Security.JobCaller caller)
        {
            InitializeComponent();
            this.jobID = jobID;
            this.bindingSource = bindingSource;
            formCaller = caller;
        }
        //
        public frmJob(string jobID, BindingSource bindingSource, Security.Security.JobCaller caller, bool isFourDigit)
        {
            InitializeComponent();
            this.jobID = jobID;
            this.bindingSource = bindingSource;
            this.isFourDigit = isFourDigit;
            if (isFourDigit)
            {
                lblSelect.Visible = false;
                radioSelect.Visible = false;
                cboSelect.Visible = false;
                btnBillingSummary.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSubcontractsInvoices.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnBillingHistoryReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSubcontractsInvoicesReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        //
        private void frmJob_Load(object sender, EventArgs e)
        {
            if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.WIPPreparation)
            {
                btnCostAnalysis.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

            // Help Items
            Program.programHlp.ResetShowHelp(this);
            Program.programHlp.SetHelpNavigator(this, HelpNavigator.TableOfContents);
            //   Program.programHlp.SetHelpNavigator(this, HelpNavigator.`);
            // Program.programHlp.SetHelpString(this, "1002");

            Cursor = Cursors.WaitCursor;
            ribJob.SelectedPage = ribbonPageJob;
            if (jobID.Length > 0 && jobID != "0")
            {
                if (isFourDigit)
                {
                    Visible = false;
                    txtRecordNo.DataBindings.Add("text", bindingSource, "JobNumber");
                    txtJobNumber.DataBindings.Add("text", bindingSource, "JobNumber");
                    txtJobName.DataBindings.Add("text", bindingSource, "JobName");
                    if (formCaller == Security.Security.JobCaller.JCCJob)
                    {
                        chkReadOnly.DataBindings.Add("text", bindingSource, "ReadOnly");
                        Security.Security.SetCurrentJobReadOnly(chkReadOnly.Text);
                    }
                    else
                    {
                        Security.Security.SetCurrentJobReadOnly("True");
                    }

                    txtRecordNo.Text = jobID;
                }
                else
                {
                    if (formCaller == Security.Security.JobCaller.JCCJob)
                    {
                        chkReadOnly.DataBindings.Add("text", bindingSource, "ReadOnly");
                        Security.Security.SetCurrentJobReadOnly(chkReadOnly.Text);
                    }
                    else
                    {
                        Security.Security.SetCurrentJobReadOnly("True");
                    }

                    txtRecordNo.DataBindings.Add("text", bindingSource, "RecordNo");
                    txtRecordNo.Text = jobID;
                }
            }
            else
            {
                ribbonPrebidRFI.Visible = false;
                ribbonProjectProposal.Visible = false;
            }
            if (!isFourDigit)
            {
                UpdateErrorMessages();
                cboCustomerName.Properties.DataSource = StaticTables.Customers;
                cboCustomerName.Properties.DisplayMember = "Name";
                cboCustomerName.Properties.ValueMember = "CustomerID";
                cboCustomerName.Properties.PopulateColumns();
                cboCustomerName.Properties.ShowHeader = false;
                cboContractorName.Properties.DataSource = StaticTables.Customers;
                cboContractorName.Properties.DisplayMember = "Name";
                cboContractorName.Properties.ValueMember = "CustomerID";
                cboContractorName.Properties.PopulateColumns();
                cboContractorName.Properties.ShowHeader = false;
                cboOwnerName.Properties.DataSource = StaticTables.Customers;
                cboOwnerName.Properties.DisplayMember = "Name";
                cboOwnerName.Properties.ValueMember = "CustomerID";
                cboOwnerName.Properties.PopulateColumns();
                cboOwnerName.Properties.ShowHeader = false;
                cboOwnerContractor.Properties.DataSource = StaticTables.Customers;
                cboOwnerContractor.Properties.DisplayMember = "Name";
                cboOwnerContractor.Properties.ValueMember = "CustomerID";
                cboOwnerContractor.Properties.PopulateColumns();
                cboOwnerContractor.Properties.ShowHeader = false;
                cboContractorOwner.Properties.DataSource = StaticTables.Customers;
                cboContractorOwner.Properties.DisplayMember = "Name";
                cboContractorOwner.Properties.ValueMember = "CustomerID";
                cboContractorOwner.Properties.PopulateColumns();
                cboContractorOwner.Properties.ShowHeader = false;
                cboWorkType.Properties.DataSource = StaticTables.WorkType;
                cboWorkType.Properties.DisplayMember = "Description";
                cboWorkType.Properties.ValueMember = "WorkTypeID";
                cboWorkType.Properties.PopulateColumns();
                cboWorkType.Properties.ShowHeader = false;
                cboWorkType.Properties.Columns[0].Visible = false;
                cboContractType.Properties.DataSource = StaticTables.ContractType;
                cboContractType.Properties.DisplayMember = "Description";
                cboContractType.Properties.ValueMember = "ContractTypeID";
                cboContractType.Properties.PopulateColumns();
                cboContractType.Properties.ShowHeader = false;
                cboContractType.Properties.Columns[0].Visible = false;
                cboProjectManager.Properties.DataSource = StaticTables.ProjectManager;
                cboProjectManager.Properties.DisplayMember = "Description";
                cboProjectManager.Properties.ValueMember = "ProjectManagerID";
                cboProjectManager.Properties.PopulateColumns();
                cboProjectManager.Properties.ShowHeader = false;
                cboProjectManager.Properties.Columns[0].Visible = false;
                cboEstimator.Properties.DataSource = StaticTables.Estimator;
                cboEstimator.Properties.DisplayMember = "Description";
                cboEstimator.Properties.ValueMember = "EstimatorID";
                cboEstimator.Properties.PopulateColumns();
                cboEstimator.Properties.ShowHeader = false;
                cboEstimator.Properties.Columns[0].Visible = false;
                cboSuperintendent.Properties.DataSource = StaticTables.Superintendent;
                cboSuperintendent.Properties.DisplayMember = "Description";
                cboSuperintendent.Properties.ValueMember = "SuperintendentID";
                cboSuperintendent.Properties.PopulateColumns();
                cboSuperintendent.Properties.ShowHeader = false;
                cboSuperintendent.Properties.Columns[0].Visible = false;
                cboForeman.Properties.DataSource = StaticTables.Foreman;
                cboForeman.Properties.DisplayMember = "Description";
                cboForeman.Properties.ValueMember = "ForemanID";
                cboForeman.Properties.PopulateColumns();
                cboForeman.Properties.ShowHeader = false;
                cboForeman.Properties.Columns[0].Visible = false;
                cboDepartment.Properties.DataSource = StaticTables.Department;
                cboDepartment.Properties.DisplayMember = "DepartmentName";
                cboDepartment.Properties.ValueMember = "DepartmentID";
                cboDepartment.Properties.PopulateColumns();
                cboDepartment.Properties.ShowHeader = false;
                cboDepartment.Properties.Columns[0].Visible = false;
                cboOffice.Properties.DataSource = StaticTables.Office;
                cboOffice.Properties.PopulateColumns();
                cboOffice.Properties.DisplayMember = "OfficeName";
                cboOffice.Properties.ValueMember = "OfficeID";
                cboOffice.Properties.ShowHeader = false;
                cboOffice.Properties.Columns[0].Visible = false;
                cboJobStatus.Properties.DataSource = StaticTables.JobStatus;
                cboJobStatus.Properties.DisplayMember = "JobStatus";
                cboJobStatus.Properties.ValueMember = "JobStatusID";
                cboJobStatus.Properties.PopulateColumns();
                cboJobStatus.Properties.ShowHeader = false;
                cboJobStatus.Properties.Columns[0].Visible = false;
                cboBidBond.Properties.DataSource = StaticTables.BidBond;
                cboBidBond.Properties.DisplayMember = "Description";
                cboBidBond.Properties.ValueMember = "BidBondID";
                cboBidBond.Properties.PopulateColumns();
                cboBidBond.Properties.ShowHeader = false;
                cboBidBond.Properties.Columns[0].Visible = false;
                cboOwnerClass.Properties.DataSource = StaticTables.OwnerClass;
                cboOwnerClass.Properties.DisplayMember = "Description";
                cboOwnerClass.Properties.ValueMember = "OwnerClassID";
                cboOwnerClass.Properties.PopulateColumns();
                cboOwnerClass.Properties.ShowHeader = false;
                cboRetainage.Properties.DataSource = StaticTables.Retainage;
                cboRetainage.Properties.DisplayMember = "Description";
                cboRetainage.Properties.ValueMember = "RetainageID";
                cboRetainage.Properties.PopulateColumns();
                cboRetainage.Properties.ShowHeader = false;
                cboInsuranceProgram.Properties.DataSource = StaticTables.InsuranceProgram;
                cboInsuranceProgram.Properties.DisplayMember = "Description";
                cboInsuranceProgram.Properties.ValueMember = "InsuranceProgramID";
                cboInsuranceProgram.Properties.PopulateColumns();
                cboInsuranceProgram.Properties.ShowHeader = false;
                cboLender.Properties.DataSource = StaticTables.Lender;
                cboLender.Properties.DisplayMember = "Description";
                cboLender.Properties.ValueMember = "LenderID";
                cboLender.Properties.PopulateColumns();
                cboLender.Properties.ShowHeader = false;
                cboWIPEntry.Properties.DataSource = StaticTables.WIPEntry;
                cboWIPEntry.Properties.DisplayMember = "Description";
                cboWIPEntry.Properties.ValueMember = "WIPEntryID";
                cboWIPEntry.Properties.PopulateColumns();
                cboWIPEntry.Properties.ShowHeader = false;
                cboBond.Properties.DataSource = StaticTables.Bond;
                cboBond.Properties.DisplayMember = "Description";
                cboBond.Properties.ValueMember = "BondID";
                cboBond.Properties.PopulateColumns();
                cboBond.Properties.ShowHeader = false;
                cboSalesRep.Properties.DataSource = StaticTables.SalesRep;
                cboSalesRep.Properties.DisplayMember = "Description";
                cboSalesRep.Properties.ValueMember = "SalesRepID";
                cboSalesRep.Properties.PopulateColumns();
                cboSalesRep.Properties.ShowHeader = false;
                cboSalesRep.Properties.Columns[0].Visible = false;
                cboJobTech.Properties.DataSource = StaticTables.JobTech;
                cboJobTech.Properties.DisplayMember = "Description";
                cboJobTech.Properties.ValueMember = "JobTechID";
                cboJobTech.Properties.PopulateColumns();
                cboJobTech.Properties.ShowHeader = false;
                cboJobTech.Properties.Columns[0].Visible = false;
                cboValidationCode.Properties.DataSource = StaticTables.Account;
                cboValidationCode.Properties.DisplayMember = "Validation Code";
                cboValidationCode.Properties.ValueMember = "AccountID";
                cboValidationCode.Properties.PopulateColumns();
                cboValidationCode.Properties.ShowHeader = false;
                cboUnitType.Properties.DataSource = StaticTables.UnitType;
                cboUnitType.Properties.PopulateColumns();
                cboUnitType.Properties.DisplayMember = "UnitType";
                cboUnitType.Properties.ValueMember = "UnitTypeCode";
                cboUnitType.Properties.ShowHeader = false;
                cboUnitType.Properties.Columns[0].Visible = false;
                GetJob();
                if (jobID.Length > 0 && jobID != "0")
                {
                    ShowRibbon();
                }
                else
                {
                    HideRibbon();
                }
                SetFormAccess();
                Text = txtJobNumber.Text + " - " + txtJobName.Text;
                tabJob.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                btnGeneral.Down = true;
                tabJob.SelectedTabPage = pagGeneral;
                Opacity = 1;
                Cursor = Cursors.Default;
                GetJobLogQualification();
                currentModule = "B";
                UpdateJobLog(currentModule);
                radioSelect.SelectedIndex = 1;
            }
            else
            {
                Text = txtJobNumber.Text + " - " + txtJobName.Text;
                tabJob.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                btnGeneral.Down = true;
                tabJob.SelectedTabPage = pagLaborAnalysis;
                Opacity = 1;
                Cursor = Cursors.Default;
                radioSelect.SelectedIndex = 1;

                ribbonPageAnalysis.Visible = true;
                ribbonPageJob.Visible = false;
                ribbonPageDocuments.Visible = false;
                RibbonPageContract.Visible = false;
                ribbonPageMaterial.Visible = false;
                dataChanged = false;
                currentButtonName = "Labor Analysis";
                UpdateTabStatusByName(currentButtonName);
                Visible = true;
            }
            Visible = true;

            if (jobID != "0" && !string.IsNullOrEmpty(txtJobNumber.Text.Trim()) && Job.IsJobUpdatedOnStarBuilder(txtJobNumber.Text.Trim()).Tables[0].Rows.Count > 0)
            {

                MessageBox.Show("There are some changes in the star builder for this job. This job would be recalculated", CCEApplication.ApplicationName);
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("Calculating", "Calculating job items ...");
                Calculate();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                Job.ResetSyncTable(txtJobNumber.Text.Trim());
            }

            //if (jobID == "0")
            //{
            //    //tabJob.SelectedTabPage = pagGeneral;
            //    //tabJobDetail.SelectedTabPage = pgBid;
            //    //tabJob.Refresh();
            //    //UpdateTabStatusByName("Job Info.");
            //    //currentButtonName = "Job Info.";
            //    //return;
            //    //Thread.Sleep(3000);

            //}
        }
        //
        private void HideRibbon()
        {
            pgScopeOfWork.PageVisible = false;
            pgContact.PageVisible = false;
            pgBiddingContractors.PageVisible = false;
            ribbonCostCode.Visible = false;
            ribbonExcel.Visible = false;
            ribbonReport.Visible = false;
            ribbonUpdate.Visible = false;
            ribbonSubcontracts.Visible = false;
            ribbonProjectProposal.Visible = false;
            ribbonPageAnalysis.Visible = false;
            ribbonPageDocuments.Visible = false;
            tabJob.SelectedTabPage = pagGeneral;
            RibbonPageContract.Visible = false;
            ribbonPageMaterial.Visible = false;
            ribbonPageCorrespondence.Visible = false;
            ribbonPageOperations.Visible = false;
            tabJob.SelectedTabPage = pagGeneral;
            pgInsurance.PageVisible = false;

        }
        //
        private void ShowRibbon()
        {
            pgScopeOfWork.PageVisible = true;
            pgContact.PageVisible = true;
            ctlJobContact.comboIsLoaded = false;
            ctlJobContact.JobCaller = formCaller;
            ctlJobContact.JobID = jobID;
            pgBiddingContractors.PageVisible = true;
            ribbonPageDocuments.Visible = true;
            ribbonPrebidRFI.Visible = true;
            ribbonProjectProposal.Visible = true;
            pgInsurance.PageVisible = true;
            if (txtJobNumber.Text.Trim() == "")
            {
                ribbonCostCode.Visible = false;
                ribbonExcel.Visible = false;
                ribbonReport.Visible = false;
                ribbonUpdate.Visible = false;
                ribbonSubcontracts.Visible = false;
               // ribbonProjectProposal.Visible = false;
                ribbonPageAnalysis.Visible = false;
                RibbonPageContract.Visible = false;
                ribbonPageMaterial.Visible = false;
                ribbonPageCorrespondence.Visible = false;
                ribbonPageOperations.Visible = false;
                if (jobID.Length > 0)
                {
                    ribbonReport.Visible = true;
                    UpdateTabStatusByName("Job Info.");
                    currentButtonName = "Job Info.";
                }
                tabJob.SelectedTabPage = pagGeneral;
            }
            else
            {
                ribbonCostCode.Visible = true;
                ribbonExcel.Visible = true;
                ribbonReport.Visible = true;
                ribbonSubcontracts.Visible = false;
                if (JCCBusinessLayer.Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
                {
                    ribbonProjectProposal.Visible = true;
                }
                else
                {
                    ribbonProjectProposal.Visible = false;
                }

                ribbonPageAnalysis.Visible = true;
                RibbonPageContract.Visible = true;
                ribbonPageMaterial.Visible = true;
                ribbonPageCorrespondence.Visible = true;
                ribbonPageOperations.Visible = true;


                if (formCaller != Security.Security.JobCaller.JCCDashboard)
                {
                    ribbonUpdate.Visible = true;
                }
                else
                {
                    ribbonUpdate.Visible = false;
                }
            }
            if (chkVoid.Checked || chkArchive.Checked)
            {
                ribbonUpdate.Visible = false;
            }

            if (txtJobNumber.Text.Trim() == "")
            {
                if (jobID.Length > 0)
                {
                    btnWeeklyQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnPersonnel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnQuantitySheet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnJobProgressSummaryReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnLaborFeedbackReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnLaborPerformanceFactorReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnCostCodesToResearch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnMonthEndCommentsReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }
            else
            {
                btnWeeklyQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnPersonnel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnQuantitySheet.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnJobProgressSummaryReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLaborFeedbackReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLaborPerformanceFactorReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnCostCodesToResearch.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnMonthEndCommentsReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            if (jobStatus.ToUpper() == "WON")
            {
                if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
                    pgAssignUser.PageVisible = true;
            }
            else
                pgAssignUser.PageVisible = false;

        }
        //
        private void GetCostCode()
        {
            // Task task = new Task(new Action(UpdateTabs));
            // task.Start();
            UpdateTabs();
            ArchiveVoidStatus();
        }
        //
        public void UpdateTabs()
        {
            //Cursor = Cursors.WaitCursor;
            try
            {


                ctlCostCodeWeekly.JobCaller = formCaller;
                ctlCostCodeWeekly.JobID = jobID;
                ctlLaborFeedBack1.JobID = jobID;
                ctlCostCodeTimeCard.JobID = jobID;
                ctlLaborPerformanceFactor.JobID = jobID;
                ctlJobDocuments.JobID = "0";
                ctlJobInvoiceDetail.JobID = "0";
                ctlJobInvoiceDetail.JobCaller = formCaller;
                ctlJobPurchaseDetail.JobNumber = "0";
                ctlJobPurchaseDetail.IsClosed = chkArchive.Checked.ToString() == "True" ? true : false;
                ctlJobPurchaseDetail.JobCaller = formCaller;
                ctlLaborAnalysis.JobID = "0";
                ctlJobCostAnalysis.JobID = jobID; // changed by anu
                ctlJobLog.JobID = "0";
                ctlJobProgressComment.JobID = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            finally
            {
                // Cursor = Cursors.Default;
            }
        }


        //
        public void UpdateTabsFourDigits()
        {
            Cursor = Cursors.WaitCursor;
            ctlLaborAnalysis.IsFourDigit = isFourDigit;
            ctlLaborAnalysis.JobID = "0";
            ctlJobInvoiceDetail.JobID = "0";
            ctlJobInvoiceDetail.JobCaller = formCaller;
            ctlJobInvoiceDetail.IsFourDigit = isFourDigit;
            ctlJobPurchaseDetail.JobNumber = "0";
            ctlJobPurchaseDetail.IsFourDigit = isFourDigit;
            ctlJobInvoicesNoPO.JobID = "0";
            ctlJobCostAnalysis.JobID = "0";
            Cursor = Cursors.Default;
        }
        //
        private void UpdateJobLog(string module)
        {

            bool bUpdate = true;
            if (module.Trim().Length == 0)
            {
                return;
            }

            switch (module)
            {
                case "B":
                    bUpdate = isBidInfo;
                    isBidInfo = true;
                    break;
                case "W":
                    bUpdate = isWeeklyQuantity;
                    isWeeklyQuantity = true;
                    break;
                case "P":
                    bUpdate = isJobProgress;
                    isJobProgress = true;
                    break;
                case "S":
                    bUpdate = isJobProgressSummary;
                    isJobProgressSummary = true;
                    break;
                case "L":
                    bUpdate = isLaborFeedback;
                    isLaborFeedback = false;
                    break;
            }

            if (!bUpdate && log)
            {
                JobLog jobLog = new JobLog("", jobID, Security.Security.UserID.ToString(), module);
                jobLog.Save();
            }
        }
        private void GetJobLogQualification()
        {
            if (String.IsNullOrEmpty(txtJobNumber.Text))
            {
                log = false;
                return;
            }
            if (cboJobStatus.Text.Trim() == "WON" && chkArchive.CheckState != CheckState.Checked && txtJobNumber.Text.Trim().Length > 0)
            {
                log = true;
                isBidInfo = false;
                isWeeklyQuantity = false;
                isJobProgress = false;
                isJobProgressSummary = false;
                isLaborFeedback = false;
            }
            else
            {
                log = false;
            }
        }
        //
        private void GetJobDetail()
        {
            GetJobPrequalKeyword();
            ctlJobContact.JobCaller = formCaller;
            ctlJobContact.JobID = jobID;
            ctlJobBiddingContractor.JobCaller = formCaller;
            ctlJobBiddingContractor.JobID = jobID;
            ctlAssignJobs.JobCaller = formCaller;
            ctlAssignJobs.JobID = jobID;
            if (txtRecordNo.Text.Trim().Length > 0)
            {
                UpdateJob(txtRecordNo.Text, "All");
            }
            else
            {
                starbuilderJobNumber = "0";
                cboUnitType.EditValue = null;
                txtUnits.Text = null;
                txtOpportunityNumber.Text = null;
                txtEstimateNumber.Text = null;
                txtJobNumber.Text = null;
                cboOffice.EditValue = null;
                cboDepartment.EditValue = null;
                txtJobName.Text = null;
                txtJobDescription.Text = null;
                txtJobPhone.Text = null;
                txtJobAddress.Text = null;
                txtJobCity.Text = null;
                txtJobAddress2.Text = null;
                txtJobState.Text = "CA";
                txtJobZip.Text = null;
                txtJobPhone.Text = null;
                cboCustomerName.EditValue = String.Empty;
                txtCustomerID.Text = null;
                chkBillingAsCustomer.Checked = false;
                txtBillingAddress1.Text = null;
                txtBillingAddress2.Text = null;
                txtBillingCity.Text = null;
                txtBillingState.Text = null;
                txtBillingZipCode.Text = null;
                txtBillingPhone.Text = null;
                txtBillingRep.Text = null;
                cboOwnerClass.EditValue = null;
                chkContractorAsCustomer.Checked = false;
                txtContractorName.Text = null;
                txtOwnerContractor.Text = null;
                txtContractorOwner.Text = null;
                txtContractorAddress1.Text = null;
                txtContractorAddress2.Text = null;
                txtContractorCity.Text = null;
                txtContractorState.Text = null;
                txtContractorZipCode.Text = null;
                txtContractorPhone.Text = null;
                txtContractorRep.Text = null;
                chkOwnerAsCustomer.Checked = false;
                txtOwnerName.Text = null;
                txtOwnerAddress1.Text = null;
                txtOwnerAddress2.Text = null;
                txtOwnerCity.Text = null;
                txtOwnerState.Text = null;
                txtOwnerZipCode.Text = null;
                txtOwnerPhone.Text = null;
                txtOwnerRep.Text = null;
                txtOwnerContractor.Text = null;
                txtContractorOwner.Text = null;
                chkLaborRates.Checked = false;
                cboAlphaCodes.EditValue = null;
                cboOtherLabor.EditValue = null;
                txtMaterialMU.Text = null;
                cboOtherMaterial.EditValue = null;
                txtReleaseNumber.Text = null;
                cboCCEEquip.EditValue = null;
                txtOutsideRentalMU.Text = null;
                txtSubcontractMU.Text = null;
                chkOtherMU.Checked = false;
                cboWorkType.EditValue = null;
                cboContractType.EditValue = null;
                cboProjectManager.EditValue = null;
                cboEstimator.EditValue = null;
                cboSuperintendent.EditValue = null;
                cboForeman.EditValue = null;
                txtContractNumber.Text = null;
                txtOriginalContractAmount.Text = null;
                txtJobFinalContractAmount.Text = null;
                chkCopyOfVendorInvoicesNeeded.Checked = false;
                chkSubcontractors.Checked = false;
                chkCertifiedPayroll.Checked = false;
                cboBond.EditValue = null;
                txtBondDate.Text = null;
                txtBondNumber.Text = null;
                txtPONumber.Text = null;
                txtContractStartDate.Text = null;
                txtContractEstComplDate.Text = null;
                txtJurisdiction.Text = null;
                txtMasterJobNumber.Text = null;
                cboRetainage.EditValue = null;
                cboInsuranceProgram.EditValue = null;
                txtTotalCLPUAmount.Text = null;
                txtGLIABName.Text = null;
                txtUMBRLName.Text = null;
                chkPreliminaryNotice.Checked = false;
                txtPreliminaryDateMailed.Text = null;
                txtPreliminaryMailedBy.Text = String.Empty;
                txtComment.Text = null;
                txtPostedToFileDate.Text = null;
                txtPostedToFileBy.Text = null;
                callFromUpdateJob = true;
                cboJobStatus.EditValue = null;
                callFromUpdateJob = false;
                chkCustomerIsSubcontractor.Checked = false;
                txtCustomerSubcontractors.Text = null;
                chkWIPRequired.Checked = false;
                cboWIPStatus.EditValue = null;
                cboWIPEntry.EditValue = null;
                cboTrade.EditValue = null;
                cboLender.EditValue = null;
                txtLenderName.Text = null;
                txtLenderAddress.Text = null;
                txtLenderCity.Text = null;
                txtLenderState.Text = null;
                txtLenderZip.Text = null;
                cboReleaseToCustomer.EditValue = null;
                chkSignedDaily.Checked = false;
                chkSignedWorkOrder.Checked = false;
                chkTimeSheetSigned.Checked = false;
                chkSubContractorInvoicesRequired.Checked = false;
                chkCustomerAuthorizedForm.Checked = false;
                chkTimeSheetSigned.Checked = false;
                chkMultipleCopies.Checked = false;
                chkBillingFrequency.Checked = false;
                chkClientPercentNotification.Checked = false;
                chkLienRelease.Checked = false;
                txtCutOffDate.Text = null;
                txtBidDate.Text = null;
                txtBidTime.Text = null;
                txtPreBidAmount.Text = null;
                txtFinalBidAmount.Text = null;
                chkDesignBuild.Checked = false;
                chkDrawingReceived.Checked = false;
                chkQuotesRequired.Checked = false;
                chkBidForm.Checked = false;
                txtBidWalkDate.Text = null;
                txtBidWalkTime.Text = null;
                cboDeliveryMethod.Text = null;
                txtArchitectEngineer.Text = null;
                txtAddendumReceived.Text = null;
                txtJobEmail.Text = null;
                txtJobFax.Text = null;
                txtWONLOSTDate.Text = null;
                txtMeetingDate.Text = null;
                txtMeetingTime.Text = null;
                txtReviewDate.Text = null;
                txtReviewTime.Text = null;
                chkOver250K.Checked = false;
                chkOver1M.Checked = false;
                chkVoid.Checked = false;
                chkArchive.Checked = false;
                cboBidBond.EditValue = null;
                txtRevisionEstimateNumber.Text = null;
                txtRevisionJobNumber.Text = null;
                txtRevisionDescription.Text = null;
                txtRevisionID.Text = null;
                txtRevisionJobID.Text = null;
                chkEstimateHandoff.Checked = false;
                cboEstimateHandoffGrade.EditValue = null;
                chkPMHandoff.Checked = false;
                cboPMHandoffGrade.EditValue = null;
                chkProjectStartupMeeting.Checked = false;
                chkDropOffComplianceReport.Checked = false;
                chkDashboardExclude.Checked = false;
                chkTrackChangeOrder.Checked = false;
                chkProjectCloseoutMeeting.Checked = false;
                txtWIPComments.Text = null;
                cboSalesRep.EditValue = null;
                cboJobTech.EditValue = null;
                radioJobCostLevelCode.SelectedIndex = 0;
                radioBillingLevelCode.SelectedIndex = 2;
                chkJobCertifiedFlag.Checked = false;
                chkJobTaxFlag.Checked = false;
                cboValidationCode.EditValue = 15;
                txtJobGLAccount.Text = null;
                txtJobOverheadEquipment.Text = null;
                txtJobOverheadLabor.Text = null;
                txtJobOverheadMaterial.Text = null;
                txtJobOverheadSubcontractor.Text = null;
                txtJobOverheadOther.Text = null;
                txtJobCompletedPercent.Text = null;
                txtJobOwnerPercent.Text = null;
                txtJobBurdenPercent.Text = null;
                txtJobSalesTaxPercent.Text = null;
                txtDuration.Text = null;
                radioJobBillingType.SelectedIndex = 0;
                chkSaveHistory.Checked = false;
                radioJobCertifiedReportType.SelectedIndex = 0;
                chkStatementOfCompliance.Checked = false;
                chkAlwaysPrintReport.Checked = false;
                chkDeductionDetail.Checked = false;
                chkInsuranceRequiredToBeReviewed.Checked = false;
                groupCertifiedPayrollInformation.Visible = false;
                chkSaveHistory.Checked = true;
                radioBillingLevelCode.SelectedIndex = 0;
                radioJobCostLevelCode.SelectedIndex = 2;
                chkWIPRequired.Checked = true;
                chkOCIPClosed.Checked = false;
                chkCompetitve.Checked = false;
                txtOCIPClosedDate.Text = null;
                radioCertifiedContractorOrSubcontractor.SelectedIndex = 1;
                radioJobCertifiedReportType.SelectedIndex = 2;
                txtCertifiedWeekNumber.Text = "1";
                txtLastReportNumber.Text = "0";
                txtNextReportNumber.Text = "1";
                chkStatementOfCompliance.Checked = true;
                chkAlwaysPrintReport.Checked = true;
                chkDeductionDetail.Checked = true;
                chkWIPRequired.Checked = true;
                cboWIPStatus.Text = "OPEN";
                cboBidBond.EditValue = 4;
                cboJobStatus.EditValue = 8;
                btnSelect.Visible = false;
                lblWONLOSTDate.Visible = false;
                txtWONLOSTDate.Visible = false;
                txtCustomerComment.Text = null;
                txtScopeOfWork.Text = null;
                chkCompletedOps.Checked = false;
                chkGLAutoWC.Checked = false;
                chkProfLiab.Checked = false;
                txtCompletedOps.Text = null;
                txtGLAutoWC.Text = null;
                txtProfLiab.Text = null;
                txtInsuranceProjectName.Text = null;
                txtInsuranceProjectNumber.Text = null;
                //txtAdditionalInsured.Text = null;
            }
            groupCertifiedPayrollInformation.Visible = chkJobCertifiedFlag.Checked;
            tabJobDetail.SelectedTabPage = pgStarBuilder;
            tabJobDetail.SelectedTabPage = pgBid;
            btnSave.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
            cboCustomerName.ErrorText = "";
            UpdateScopeOfWorkScreen();
        }
        //
        private void UpdateScopeOfWorkScreen()
        {
            panScopeOfWork.Visible = false;
            btnScopeOfWork.Visible = false;
        }
        //
        private void GetJobPrequalKeyword()
        {
            try
            {
                Cursor = Cursors.AppStarting;

                grdKeywords.DataSource = JobPrequal.GetJobPrequalKeyword(jobID).Tables[0];
                grdKeywordsView.Columns["Group"].Group();
                grdKeywordsView.ExpandAllGroups();
                grdKeywordsView.Columns["JobPrequalKeywordID"].Visible = false;
                grdKeywordsView.Columns["PrequalKeywordID"].Visible = false;
                grdKeywordsView.Columns["PrequalKeyword"].Caption = "Prequal Keyword";
                grdKeywordsView.Columns["PrequalKeyword"].OptionsColumn.AllowEdit = false;
                grdKeywordsView.BestFitColumns();

                if (formCaller == Security.Security.JobCaller.JCCDashboard)
                {
                    grdKeywordsView.Columns["Selected"].OptionsColumn.AllowEdit = false;
                }



                //grdKeywordsView.BestFitColumns();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateTabStatus(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckSaveChanges())
            {
                return;
            }

            btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCostCodes.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCostCodesWeekly.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnLaborFeedback.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobProgress.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobProgressWIP.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobProgressSummary.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobProgressSummaryWIP.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnTimeCard.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnLaborPerformanceFactor.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnLaborAnalysis.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnBillingSummary.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSubcontracts.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCostAnalysis.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnPurchasingSummary.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnInvoicesNoPO.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobDocumentsExplorer.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobDocumentsList.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnTMLaborRates.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnTMMiscRates.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnTMMarkups.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCustomerWorkorder.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobEmployee.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnWeeklyTimeSheet.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnInvoice.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnInvoice.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobEquipment.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobHistory.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSubcontractsInvoices.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnInvoiceBatch.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSVSetup.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSVWorksheet.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSVScheduleValue.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSVInvoice.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSVInvoiceSheet.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobProgressComment.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;

            btnContractDefaultValues.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnContractRFI.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnMaterialMajorPO.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCorrespondenceTransmittal.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCorrespondenceSubmittal.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnMeetingMinutesSchedule.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCorrespondenceLetter.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnOperationsRentals.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnMaterialOrder.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnDailyLog.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnTimeMaterial.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSwitchgear.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnLightFixture.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSmallPO.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnPreBidRFI.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnProjectProposal.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            currentButtonArg = e;
            currentButtonName = e.Item.Caption;
            UpdateTabStatusByName(currentButtonName);


        }
        private void UpdateTabStatusByName(string tabName)
        {
            currentModule = "";
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", ""); 
            if (jobID == "0")
            {
                tabName = "Job Info.";
            }

            switch (tabName)
            {
                case "Job Info.":
                    btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnGeneral.Down = true;
                    tabJob.SelectedTabPage = pagGeneral;
                    // Program.programHlp.SetHelpKeyword(this, "1002");
                    currentModule = "B";
                    UpdateJobLog(currentModule);
                    break;
                case "Job Budget":
                    ctlJobCostCodes.JobCaller = formCaller;
                    ctlJobCostCodes.IsClosed = chkArchive.Checked.ToString() == "True" ? true : false;
                    ctlJobCostCodes.JobID = jobID;
                    ctlJobCostCodes.JobNumber = txtJobNumber.Text;
                    ctlJobCostCodes.ContractType = cboContractType.Text.Trim();
                    ctlJobCostCodes.TrackChangeOrder = chkTrackChangeOrder.Checked.ToString() == "True" ? true : false;
                    btnCostCodes.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnCostCodes.Down = true;
                    tabJob.SelectedTabPage = pagCostCodes;
                    //Program.programHlp.SetHelpKeyword(this, "1003");
                    break;
                case "Weekly Quantities":
                    btnCostCodesWeekly.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnCostCodesWeekly.Down = true;
                    tabJob.SelectedTabPage = pagCostCodesWeekly;
                    //Program.programHlp.SetHelpKeyword(this, "1001");
                    currentModule = "W";
                    UpdateJobLog(currentModule);
                    break;
                case "Time && Qty ":
                    btnTimeCard.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnTimeCard.Down = true;
                    tabJob.SelectedTabPage = pagCostCodeTimeSheet;
                    ctlCostCodeTimeCard.JobID = jobID;
                    //Program.programHlp.SetHelpKeyword(this, "1004");
                    break;
                case "Pre-bid RFI":
                    btnPreBidRFI.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnPreBidRFI.Down = true;
                    tabJob.SelectedTabPage = pagPreBidRFI;
                    ctlPreBidRFI.JobID = jobID;
                    //Program.programHlp.SetHelpKeyword(this, "1004");
                    break;


                case "Project Proposal":
                    btnProjectProposal.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnProjectProposal.Down = true;
                    tabJob.SelectedTabPage = pagProjectProposal;
                    ctlProjectProposal.JobID = jobID; //Anu - need to amend this
                    //ctlProjectProposal.EstimateNumber=estimate


                    break;
                case "Labor Feedback":
                    btnLaborFeedback.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnLaborFeedback.Down = true;
                    tabJob.SelectedTabPage = pagLaborFeedback;
                    //Program.programHlp.SetHelpKeyword(this, "36");
                    currentModule = "L";
                    UpdateJobLog(currentModule);
                    break;
                case "Job Progress":
                    ctlJobProgress.JobCaller = formCaller;
                    ctlJobProgress.IsClosed = chkArchive.Checked.ToString() == "True" ? true : false;
                    ctlJobProgress.JobID = jobID;
                    btnJobProgress.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobProgress.Down = true;
                    tabJob.SelectedTabPage = pagJobProgress;
                    //Program.programHlp.SetHelpKeyword(this, "34");
                    currentModule = "P";
                    UpdateJobLog(currentModule);
                    break;
                case "Job Progress (WIP)":
                    ctlJobProgressWIP.JobCaller = formCaller;
                    ctlJobProgressWIP.JobID = jobID;
                    btnJobProgressWIP.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobProgressWIP.Down = true;
                    tabJob.SelectedTabPage = pagJobProgressWIP;
                    //Program.programHlp.SetHelpKeyword(this, "34");
                    break;
                case "Job Progress Summary":
                    ctlJobProgressSummary.JobCaller = formCaller;
                    ctlJobProgressSummary.ContractType = cboContractType.Text.Trim();
                    ctlJobProgressSummary.TrackChangeOrder = chkTrackChangeOrder.Checked.ToString() == "True" ? true : false;
                    ctlJobProgressSummary.JobID = jobID;

                    btnJobProgressSummary.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobProgressSummary.Down = true;
                    tabJob.SelectedTabPage = pagJobProgressSummary;
                    //Program.programHlp.SetHelpKeyword(this, "35");
                    currentModule = "S";
                    UpdateJobLog(currentModule);
                    break;
                case "Job Progress Summary (WIP)":
                    ctlJobProgressSummaryWIP.JobCaller = formCaller;
                    ctlJobProgressSummaryWIP.ContractType = cboContractType.Text.Trim();
                    ctlJobProgressSummaryWIP.TrackChangeOrder = chkTrackChangeOrder.Checked.ToString() == "True" ? true : false;
                    ctlJobProgressSummaryWIP.JobID = jobID;

                    btnJobProgressSummaryWIP.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobProgressSummaryWIP.Down = true;
                    tabJob.SelectedTabPage = pagJobProgressSummaryWIP;
                    //Program.programHlp.SetHelpKeyword(this, "35");
                    break;
                case "Labor Perf. Factor":
                    btnLaborPerformanceFactor.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnLaborPerformanceFactor.Down = true;
                    tabJob.SelectedTabPage = pagLaborPerformanceFactor;
                    //Program.programHlp.SetHelpKeyword(this, "37");
                    break;
                case "Labor Analysis":
                    btnLaborAnalysis.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnLaborAnalysis.Down = true;
                    tabJob.SelectedTabPage = pagLaborAnalysis;
                    ctlLaborAnalysis.IsFourDigit = isFourDigit;
                    ctlLaborAnalysis.JobID = jobID;
                    break;
                case "Billing Summary":
                    btnBillingSummary.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnBillingSummary.Down = true;
                    tabJob.SelectedTabPage = pagInvoiceDetail;
                    if (isFourDigit)
                    {
                        ctlJobInvoiceDetail.JobID = "0";
                    }
                    else
                    {
                        ctlJobInvoiceDetail.JobID = jobID;
                    }

                    break;
                case "Purchasing Summary":
                    btnPurchasingSummary.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnPurchasingSummary.Down = true;
                    tabJob.SelectedTabPage = pagPurchaseDetail;
                    ctlJobPurchaseDetail.JobNumber = txtJobNumber.Text;
                    ctlJobPurchaseDetail.IsClosed = chkArchive.Checked.ToString() == "True" ? true : false;
                    ctlJobPurchaseDetail.JobCaller = formCaller;
                    break;
                case "Invoices No PO":
                    btnInvoicesNoPO.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnInvoicesNoPO.Down = true;
                    tabJob.SelectedTabPage = pagInvoicesNoPO;
                    ctlJobInvoicesNoPO.JobID = txtJobNumber.Text;
                    break;
                case "Subcontracts Invoices":
                    btnSubcontractsInvoices.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnSubcontractsInvoices.Down = true;
                    tabJob.SelectedTabPage = pagSubcontractsInvoices;
                    ctlJobSubcontractsInvoices.JobID = jobID;
                    break;
                case "Cost Analysis":
                    btnCostAnalysis.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnCostAnalysis.Down = true;
                    tabJob.SelectedTabPage = pagCostAnalysis;
                    ctlJobCostAnalysis.IsFourDigit = isFourDigit;
                    ctlJobCostAnalysis.JobID = jobID;
                    break;
                case "Job Documents ":
                    btnJobDocumentsList.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobDocumentsList.Down = true;
                    tabJob.SelectedTabPage = pagJobDocuments;
                    ctlJobDocuments.JobID = jobID;
                    break;
                case "Job Documents Explorer":
                    btnJobDocumentsExplorer.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobDocumentsExplorer.Down = true;
                    tabJob.SelectedTabPage = pagJobDocumentsExplorer;
                    ctlJobDocumentsExplorer.JobID = jobID;
                    break;

                case "Job Log":
                    btnJobLogList.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobLogList.Down = true;
                    tabJob.SelectedTabPage = pagJobLog;
                    ctlJobLog.JobID = jobID;
                    break;


                case "Month End Comments":
                    btnJobProgressComment.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobProgressComment.Down = true;
                    tabJob.SelectedTabPage = pagJobProgressComment;
                    ctlJobProgressComment.JobID = jobID;
                    break;

                case "Default Values":
                    btnContractDefaultValues.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnContractDefaultValues.Down = true;
                    tabJob.SelectedTabPage = pagDefaultValues;
                    ctlJobDefaultValues.JobCaller = formCaller;
                    ctlJobDefaultValues.JobID = jobID;
                    break;
                case "RFI":
                    btnContractRFI.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnContractRFI.Down = true;
                    tabJob.SelectedTabPage = pagContractRFI;
                    ctlJobContractRFI.JobCaller = formCaller;
                    ctlJobContractRFI.JobID = jobID;
                    break;
                case "Major PO":
                    btnMaterialMajorPO.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnMaterialMajorPO.Down = true;
                    tabJob.SelectedTabPage = pagMajorPO;
                    ctlJobMaterialMajorPO.JobCaller = formCaller;
                    ctlJobMaterialMajorPO.JobID = jobID;
                    break;
                case "Small PO":
                    btnSmallPO.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnSmallPO.Down = true;
                    tabJob.SelectedTabPage = pagSmallPO;
                    ctlJobSmallPO.JobCaller = formCaller;
                    ctlJobSmallPO.JobID = jobID;
                    break;
                case "Transmittal":
                    btnCorrespondenceTransmittal.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnCorrespondenceTransmittal.Down = true;
                    tabJob.SelectedTabPage = pagTransmittal;
                    ctlJobTransmittal.JobCaller = formCaller;
                    ctlJobTransmittal.JobID = jobID;
                    break;
                case "Submittal":
                    btnCorrespondenceSubmittal.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnCorrespondenceSubmittal.Down = true;
                    tabJob.SelectedTabPage = pagSubmittal;
                    ctlJobSubmittal.JobCaller = formCaller;
                    ctlJobSubmittal.JobID = jobID;
                    break;
                case "Meeting Schedule":
                    btnMeetingMinutesSchedule.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnMeetingMinutesSchedule.Down = true;
                    tabJob.SelectedTabPage = pagMeetingMinutesSchedule;
                    ctlMeetingMinutesSchedule.JobCaller = formCaller;
                    ctlMeetingMinutesSchedule.JobID = jobID;
                    break;
                case "Letter":
                    btnCorrespondenceLetter.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnCorrespondenceLetter.Down = true;
                    tabJob.SelectedTabPage = pagCorrespondenceLetter;
                    ctlJobCorrespondenceLetter.JobCaller = formCaller;
                    ctlJobCorrespondenceLetter.JobID = jobID;
                    break;
                case "Rentals":
                    btnOperationsRentals.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnOperationsRentals.Down = true;
                    tabJob.SelectedTabPage = pagEquipmentRental;
                    ctlEquipmentRental.JobCaller = formCaller;
                    ctlEquipmentRental.JobID = jobID;
                    break;
                case "Material Orders":
                    btnMaterialOrder.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnMaterialOrder.Down = true;
                    tabJob.SelectedTabPage = pagMaterialOrder;
                    ctlMaterialOrder.JobCaller = formCaller;
                    ctlMaterialOrder.JobID = jobID;
                    break;
                case "Daily Log":
                    btnDailyLog.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnDailyLog.Down = true;
                    tabJob.SelectedTabPage = pagDailyLog;
                    ctlDailyLog.JobCaller = formCaller;
                    ctlDailyLog.JobID = jobID;
                    break;
                case "Time & Material":
                    btnTimeMaterial.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnTimeMaterial.Down = true;
                    tabJob.SelectedTabPage = pagTimeMaterial;
                    ctlTimeMaterialLog.JobCaller = formCaller;
                    ctlTimeMaterialLog.JobID = jobID;
                    break;
                case "Switchgear":
                    btnSwitchgear.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnSwitchgear.Down = true;
                    tabJob.SelectedTabPage = pagSwitchgear;
                    ctlJobSwitchgear.JobCaller = formCaller;
                    ctlJobSwitchgear.JobID = jobID;
                    break;
                case "Light Fixture":
                    btnLightFixture.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnLightFixture.Down = true;
                    tabJob.SelectedTabPage = pagLightFixture;
                    ctlJobLightFixture.JobCaller = formCaller;
                    ctlJobLightFixture.JobID = jobID;
                    break;
            }
            // DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();

        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckSaveChanges())
            {
                return;
            }

            btnUp.Enabled = false;
            btnDown.Enabled = false;
            string perid = "";
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            try
            {

                switch (name)
                {
                    case "Next Job":
                        if (!isFourDigit)
                        {
                            if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                            {
                                bindingSource.MoveNext();
                                if (formCaller == Security.Security.JobCaller.JCCJob)
                                {
                                    Security.Security.SetCurrentJobReadOnly(chkReadOnly.Text);
                                }

                                GetJob();
                                if (!String.IsNullOrEmpty(currentButtonName))
                                {
                                    UpdateTabStatusByName(currentButtonName);
                                }
                                ShowRibbon();
                                dataChanged = false;
                            }
                            else
                            {
                                CheckSaveChanges();
                                if (CheckJobStatus(ClickedButton.Next))
                                {
                                    bindingSource.MoveNext();
                                    if (formCaller == Security.Security.JobCaller.JCCJob)
                                    {
                                        Security.Security.SetCurrentJobReadOnly(chkReadOnly.Text);
                                    }

                                    GetJob();
                                    if (!String.IsNullOrEmpty(currentButtonName))
                                    {
                                        UpdateTabStatusByName(currentButtonName);
                                    }
                                    ShowRibbon();
                                    dataChanged = false;
                                }
                            }
                            GetJobLogQualification();
                            UpdateJobLog(currentModule);
                        }
                        else
                        {
                            bindingSource.MoveNext();
                            if (formCaller == Security.Security.JobCaller.JCCJob)
                            {
                                Security.Security.SetCurrentJobReadOnly(chkReadOnly.Text);
                            }

                            jobID = txtRecordNo.Text;
                            UpdateTabsFourDigits();
                            if (!String.IsNullOrEmpty(currentButtonName))
                            {
                                UpdateTabStatusByName(currentButtonName);
                            }
                            dataChanged = false;
                            Text = txtJobNumber.Text + " - " + txtJobName.Text;
                        }
                        break;
                    case "Previous Job":
                        if (!isFourDigit)
                        {
                            if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                            {
                                bindingSource.MovePrevious();
                                if (formCaller == Security.Security.JobCaller.JCCJob)
                                {
                                    Security.Security.SetCurrentJobReadOnly(chkReadOnly.Text);
                                }

                                GetJob();
                                if (!String.IsNullOrEmpty(currentButtonName))
                                {
                                    UpdateTabStatusByName(currentButtonName);
                                }
                                ShowRibbon();
                                dataChanged = false;
                            }
                            else
                            {
                                CheckSaveChanges();
                                if (CheckJobStatus(ClickedButton.Previous))
                                {
                                    bindingSource.MovePrevious();
                                    if (formCaller == Security.Security.JobCaller.JCCJob)
                                    {
                                        Security.Security.SetCurrentJobReadOnly(chkReadOnly.Text);
                                    }

                                    GetJob();
                                    if (!String.IsNullOrEmpty(currentButtonName))
                                    {
                                        UpdateTabStatusByName(currentButtonName);
                                    }
                                    ShowRibbon();
                                    dataChanged = false;
                                }
                            }
                            GetJobLogQualification();
                            UpdateJobLog(currentModule);
                        }
                        else
                        {
                            bindingSource.MovePrevious();
                            if (formCaller == Security.Security.JobCaller.JCCJob)
                            {
                                Security.Security.SetCurrentJobReadOnly(chkReadOnly.Text);
                            }

                            jobID = txtRecordNo.Text;
                            UpdateTabsFourDigits();
                            if (!String.IsNullOrEmpty(currentButtonName))
                            {
                                UpdateTabStatusByName(currentButtonName);
                            }
                            dataChanged = false;
                            Text = txtJobNumber.Text + " - " + txtJobName.Text;
                        }
                        break;
                    case "&Delete":
                        if (txtJobNumber.Text.Trim().Length > 0)
                        {
                            if (MessageBox.Show("Delete current Job", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                bindingSource.RemoveCurrent();
                                GetJob();
                                ShowRibbon();
                                dataChanged = false;
                            }
                        }
                        break;
                    case "&New":
                        CheckSaveChanges();
                        if (CheckJobStatus(ClickedButton.New))
                        {
                            bindingSource.AddNew();
                            txtRecordNo.Text = "";
                            GetJob();
                            dataChanged = false;
                            btnSave.Enabled = false;
                            HideRibbon();
                        }
                        break;
                    case "&Save":
                        if (CheckJobStatus(ClickedButton.Save) == true)
                        {
                            ShowRibbon();
                        }

                        GetJobLogQualification();
                        UpdateJobLog(currentModule);
                        break;
                    case "&Undo":
                        bindingSource.CancelEdit();
                        GetJob();
                        ShowRibbon();
                        dataChanged = false;
                        break;
                    case "&Job Info. Sheet":
                        Reports.JobSheet(txtRecordNo.Text);
                        break;
                    case "Job Progress Summary":
                        string period = "";
                        if (ctlJobProgressSummary.CurrentPeriod == false && ctlJobProgressSummary.Period.Trim().Length > 0)
                        {
                            period = ctlJobProgressSummary.Period;
                        }

                        Reports.JobProgressSummary(txtRecordNo.Text, txtJobNumber.Text, txtJobName.Text, period);
                        break;
                    case "Job Progress Summary (WIP)":
                        string period1 = "";
                        if (ctlJobProgressSummaryWIP.CurrentPeriod == false && ctlJobProgressSummaryWIP.Period.Trim().Length > 0)
                        {
                            period1 = ctlJobProgressSummaryWIP.Period;
                        }

                        Reports.JobProgressSummaryWIP(txtRecordNo.Text, txtJobNumber.Text, txtJobName.Text, period1);
                        break;
                    case "Total Budget":
                        string period2 = " ";
                        if (ctlJobProgress.CurrentPeriod == false && ctlJobProgress.Period.Trim().Length > 0)
                        {
                            period1 = ctlJobProgress.Period;
                        }

                        Reports.JobTotalBudget(txtRecordNo.Text, txtJobNumber.Text, txtJobName.Text, period2);
                        break;
                    case "Budget Sheet":
                        if (ctlJobCostCodes.IsUpdated)
                        {
                            ctlJobCostCodes.SaveJobCostCodes();
                        }

                        Reports.JobChangeOrderDetail(ctlJobCostCodes.JobChangeOrderID, jobID);
                        break;
                    case "&Change Order List":
                        Reports.JobChangeOrderList(jobID, txtJobNumber.Text, txtJobName.Text);
                        break;
                    case "&Change Order Log":
                        Reports.JobChangeOrderLog(jobID, txtJobNumber.Text, txtJobName.Text,
                            ctlJobCostCodes.ReportTable,
                            ctlJobCostCodes.ReportSort,
                            ctlJobCostCodes.ReportFilter);
                        break;
                    case "Outstanding Change Order Log":
                        Reports.JobOutstandingChangeOrderLog(jobID, txtJobNumber.Text, txtJobName.Text);
                        break;
                    case "&Time Sheet":
                        // waiting = new DevExpress.Utils.WaitDialogForm("", "... " + "Preparing" + " ...");
                        ExcelReport excelWeeklyTimeSheet = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text, "");
                        excelWeeklyTimeSheet.JobWeeklyTimeSheet(jobID, txtJobNumber.Text,
                                    ctlCostCodeTimeCard.SelectedDate,
                                    txtJobName.Text,
                                    ctlCostCodeTimeCard.SelectedData);
                        excelWeeklyTimeSheet = null;
                        break;
                    case "&Quantity Sheet":
                        // waiting = new DevExpress.Utils.WaitDialogForm("", "... " + "Preparing" + " ...");
                        ExcelReport excelWeeklyQuantitySheet = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text, "");
                        excelWeeklyQuantitySheet.JobWeeklyQuantitySheet(jobID, txtJobNumber.Text,
                                    ctlCostCodeTimeCard.SelectedDate,
                                    txtJobName.Text,
                                    ctlCostCodeTimeCard.SelectedData);
                        excelWeeklyQuantitySheet = null;
                        break;
                    case "&Labor Feedback":
                        try
                        {
                            Reports.LaborFeedback(ctlLaborFeedBack1.LaborFeedbackChart,
                                ctlLaborFeedBack1.LaborFeedbackGrid,
                                txtJobName.Text,
                                 ctlLaborFeedBack1.SelectedWeek, jobID, txtJobNumber.Text, ctlLaborFeedBack1.EmployeeName);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Please select a week befor printing the report", CCEApplication.ApplicationName);
                        }
                        break;
                    case "&Labor Perf. Factor":
                        Reports.LaborPerformanceFactor(ctlLaborPerformanceFactor.LaborPerformanceFactorChart,
                            ctlLaborPerformanceFactor.LaborPerformanceFactorGrid,
                            txtJobName.Text,
                            txtJobNumber.Text, jobID);
                        break;
                    case "&Weekly Quantity":
                        try
                        {
                            Reports.WeeklyQuantity(txtJobName.Text, ctlCostCodeWeekly.SelectedWeek, jobID, txtJobNumber.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Please select a week befor printing the report", CCEApplication.ApplicationName);
                        }
                        break;
                    case "&Hours":
                        //  waiting = new DevExpress.Utils.WaitDialogForm("", "... " + "Preparing" + " ...");
                        ExcelReport excelJobs = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text, "");
                        excelJobs.JobHoursReport();
                        excelJobs = null;

                        break;
                    case "&Quantity":
                        // waiting = new DevExpress.Utils.WaitDialogForm("", "... " + "Preparing" + " ...");
                        ExcelReport excelQuantity = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text, "");
                        excelQuantity.JobQuantityReport();
                        excelQuantity = null;

                        break;
                    case "&Budget Worksheet":
                        //  waiting = new DevExpress.Utils.WaitDialogForm("", "... " + "Preparing" + " ...");
                        if (ctlJobProgress.CurrentPeriod == false && ctlJobProgress.Period.Trim().Length > 0)
                        {
                            perid = ctlJobProgress.Period;
                        }

                        ExcelReport excelTotalCost = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text, perid);
                        excelTotalCost.TotalCost();
                        excelTotalCost = null;

                        break;
                    case "&Job Progress":
                        //waiting = new DevExpress.Utils.WaitDialogForm("", "... " + "Preparing" + " ...");

                        if (ctlJobProgress.CurrentPeriod == false && ctlJobProgress.Period.Trim().Length > 0)
                        {
                            perid = ctlJobProgress.Period;
                        }

                        ExcelReport excelCostToComplete = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text, perid);
                        excelCostToComplete.CostToCompletion(ctlJobProgress.CheckedSummary);
                        excelCostToComplete = null;

                        break;
                    case "&Job Progress (WIP)":
                        //  waiting = new DevExpress.Utils.WaitDialogForm("", "... " + "Preparing" + " ...");

                        if (ctlJobProgress.CurrentPeriod == false && ctlJobProgress.Period.Trim().Length > 0)
                        {
                            perid = ctlJobProgress.Period;
                        }

                        ExcelReport excelCostToComplete1 = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text, perid);
                        excelCostToComplete1.CostToCompletionWIP();
                        excelCostToComplete1 = null;

                        break;
                    case "&Cost Codes To Research":
                        Reports.JobCostCodesToResearch(jobID, txtJobNumber.Text, txtJobName.Text);
                        break;
                    case "&Recalc Job":
                        DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("Calculating", "Calculating job items ...");
                        Calculate();
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();

                        break;
                    case "&Labor Analysis":
                        Reports.JobLaborAnalysis(jobID,
                                    txtJobNumber.Text,
                                    txtJobName.Text,
                                    ctlLaborAnalysis.LaborAnalysisTable,
                                 (Reports.LaborAnalysisView)ctlLaborAnalysis.LaborView,
                                  (Reports.ReportTypeView)ctlLaborAnalysis.ReportType, ctlLaborAnalysis.Filter);
                        break;
                    case "&Cost Analysis":
                        Reports.JobCostAnalysis(jobID,
                                    txtJobNumber.Text,
                                    txtJobName.Text,
                                    ctlJobCostAnalysis.CostAnalysisTable,
                                (Reports.CostAnalysisView)ctlJobCostAnalysis.CostView,
                                 (Reports.ReportTypeView)ctlJobCostAnalysis.ReportType, ctlJobCostAnalysis.Filter);
                        break;
                    case "&Billing History":
                        if (ctlJobInvoiceDetail.ReportOption == 2)
                        {
                            Reports.JobInvoiceDetailAging(ctlJobInvoiceDetail.JobInvoiceDetailAgingDataSet);
                        }
                        else
                        {
                            Reports.JobInvoiceDetail(jobID, txtJobNumber.Text, txtJobName.Text, ctlJobInvoiceDetail.JobInvoiceDetailDataSet, ctlJobInvoiceDetail.Filter);
                        }

                        break;
                    case "&Purchasing History":
                        Reports.JobPurchasingDetail(jobID, txtJobNumber.Text, txtJobName.Text, ctlJobPurchaseDetail.JobPurchaseDetailDataSet, ctlJobPurchaseDetail.ReportType, ctlJobPurchaseDetail.Filter);
                        break;
                    case "&Invoices No PO":
                        Reports.JobInvoicesNoPO(jobID, txtJobNumber.Text, txtJobName.Text, ctlJobInvoicesNoPO.JobInvoiceDetailDataSet.Tables[0], ctlJobInvoicesNoPO.Filter);
                        break;
                    case "Contract Status":
                        Reports.JobContractLog(jobID);
                        break;
                    case "&Month End Comments":
                        Reports.JobMonthEndComments(
                                    txtJobNumber.Text,
                                    txtJobName.Text,
                                    ctlJobProgressComment.CommentTable,
                                    ctlJobProgressComment.CommentSort,
                                    ctlJobProgressComment.CommentFilter);
                        break;
                    case "&Prelim Info":
                        WordDocuments.PrintPrelimInfoReport(txtRecordNo.Text);
                        break;
                    case "&Job Documents":
                        Reports.JobDocumentsList(jobID,
                                    txtEstimateNumber.Text,
                                    txtJobNumber.Text,
                                    txtJobName.Text,
                                    ctlJobDocuments.DocumentTable);
                        break;
                    case "&Job Log":
                        Reports.JobLogList(jobID,
                                    txtJobNumber.Text,
                                    txtJobName.Text,
                                    String.IsNullOrEmpty(cboContractType.Text) ? "" : cboContractType.Text,
                                    ctlJobLog.JobLogTable, ctlJobLog.Filter);
                        break;
                    case "&Job RFI Log":
                        Reports.JobRFILog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobContractRFI.RFIDataTable,
                                 ctlJobContractRFI.RFISort,
                                 ctlJobContractRFI.RFIFilter);
                        break;
                    case "&RFI Sheet":
                        Reports.JobRFISheet(jobID, ctlJobContractRFI.RFIID);
                        break;
                    case "&Change Order Contract":
                        Reports.ChangeOrderContract(jobID, ctlJobCostCodes.JobChangeOrderID);
                        break;
                    case "&Change Order Letter":
                        Reports.ChangeOrderLetter(jobID, ctlJobCostCodes.JobChangeOrderID);
                        break;
                    case "Change Order Contract && Letter":
                        Reports.ChangeOrderContractLetter(jobID, ctlJobCostCodes.JobChangeOrderID);
                        break;
                    case "Major PO":
                        Reports.MajorPO(jobID, ctlJobMaterialMajorPO.MajorPOID);
                        break;
                    case "Small PO":
                        JCCSmallPO.Reports.Reports.SmallPOForm(jobID, ctlJobSmallPO.SmallPOID);
                        break;

                    case "Attachment (MPO)":
                        if (ctlJobMaterialMajorPO.MajorPOType == "MPO")
                        {
                            WordDocuments.PrintAttachmentMPO(ctlJobMaterialMajorPO.MajorPOID);
                        }

                        break;

                    case "Subcontract Agreement":
                        if (ctlJobMaterialMajorPO.MajorPOType == "SUB") // // need to blank parameter to generate report - by anu 
                        {
                            WordDocuments.PrintSubcontractAgreement(ctlJobMaterialMajorPO.MajorPOID);
                        }

                        break;

                    case "&Subcontracts Invoices": // added by anu
                        if (ctlJobMaterialMajorPO.MajorPOType == "")
                        {
                            Reports.JobSubcontractsInvoices(jobID, txtJobNumber.Text,
                                 txtJobName.Text, ctlJobSubcontractsInvoices.JobInvoiceDetailDataSet.Tables[0],

                                  ctlJobSubcontractsInvoices.Filter);


                        }

                        break;

                    case "Job Major PO Log":
                        Reports.JobMajorPOLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobMaterialMajorPO.MajorPODataTable,
                                 ctlJobMaterialMajorPO.MajorPOSort,
                                 ctlJobMaterialMajorPO.MajorPOFilter);
                        break;

                    case "Job Small PO Log":
                        JCCSmallPO.Reports.Reports.JobSmallOrderLog(jobID, txtJobNumber.Text,
                                   txtJobName.Text,
                                   ctlJobSmallPO.SmallPODataTable,
                                   ctlJobSmallPO.SmallPOSort,
                                   ctlJobSmallPO.SmallPOFilter);
                        break;


                    case "Job Transmittal Log":
                        Reports.JobTransmittalLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobTransmittal.TransmittalDataTable,
                                 ctlJobTransmittal.TransmittalSort,
                                 ctlJobTransmittal.TransmittalFilter);
                        break;
                    case "Transmittal Form":
                        Reports.TransmittalForm(jobID, ctlJobTransmittal.TransmittalID);
                        break;
                    case "Job Submittal Log":
                        Reports.JobSubmittalLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobSubmittal.SubmittalDataSet,
                                 ctlJobSubmittal.SubmittalSort,
                                 ctlJobSubmittal.SubmittalFilter);
                        break;
                    case "Submittal":
                        Reports.SubmittalForm(jobID, ctlJobSubmittal.SubmittalID);
                        break;
                    case "Meeting Minutes":
                        Reports.MeetingMinutes(jobID, ctlMeetingMinutesSchedule.MeetingMinutesScheduleID,
                            ctlMeetingMinutesSchedule.MeetingMinutesSubjectID);
                        break;
                    case "Meeting Schedule Log":
                        Reports.MeetingMinutesLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlMeetingMinutesSchedule.MeetingMinutesScheduleDataTable,
                                 ctlMeetingMinutesSchedule.MeetingMinutesScheduleSort,
                                 ctlMeetingMinutesSchedule.MeetingMinutesScheduleFilter);
                        break;
                    case "Letter Log":
                        Reports.CorrespondenceLetterLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobCorrespondenceLetter.CorrespondenceLetterDataTable,
                                 ctlJobCorrespondenceLetter.CorrespondenceLetterSort,
                                 ctlJobCorrespondenceLetter.CorrespondenceLetterFilter);
                        break;
                    case "Letter":
                        Reports.CorrespondenceLetter(jobID, ctlJobCorrespondenceLetter.CorrespondenceLetterID);
                        break;
                    case "Equipment Rental Log":
                        JCCEquipmentRental.Reports.Reports.JobEquipmentRentalLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlEquipmentRental.EquipmentRentalDataTable,
                                 ctlEquipmentRental.EquipmentRentalSort,
                                 ctlEquipmentRental.EquimentRentalFilter);
                        break;
                    case "Equipment Rental":
                        JCCEquipmentRental.Reports.Reports.EquipmentRentalForm(jobID, ctlEquipmentRental.JobEquipmentRentalID);
                        break;
                    case "Material Order Log":
                        JCCMaterialOrder.Reports.Reports.JobMaterialOrderLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlMaterialOrder.MaterialOrderDataTable,
                                 ctlMaterialOrder.MaterialOrderSort,
                                 ctlMaterialOrder.MaterialOrderFilter);
                        break;
                    case "Material Order":
                        JCCMaterialOrder.Reports.Reports.MaterialOrderForm(jobID, ctlMaterialOrder.JobMaterialOrderID);
                        break;
                    case "Daily Job Log": // this is changed 
                        JCCDailyLog.Reports.Reports.JobDailyLogLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlDailyLog.DailyLogDataTable,
                                 ctlDailyLog.DailyLogSort,
                                 ctlDailyLog.DailyLogFilter,
                                 ctlDailyLog.ReportType);
                        break;
                    case "Daily Log":
                        JCCDailyLog.Reports.Reports.DailyLogForm(jobID,
                                     ctlDailyLog.JobDailyLogID);
                        break;
                    case "Time && Material Log":
                        JCCTimeMaterial.Reports.Reports.JobTimeMaterialLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlTimeMaterialLog.TimeMaterialLogDataTable,
                                 ctlTimeMaterialLog.TimeMaterialLogSort,
                                 ctlTimeMaterialLog.TimeMaterialLogFilter);
                        break;
                    case "Time && Material Work Order":
                        JCCTimeMaterial.Reports.Reports.TimeMaterialWorkOrder(jobID,
                                 ctlTimeMaterialLog.JobTimeMaterialLogID);
                        break;
                    case "Switchgear Log":
                        JCCSwitchgear.Reports.Reports.JobSwitchgearLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobSwitchgear.SwitchgearDataSet,
                                 ctlJobSwitchgear.SwitchgearSort,
                                 ctlJobSwitchgear.SwitchgearFilter);
                        break;
                    case "Switchgear Release Log":
                        JCCSwitchgear.Reports.Reports.JobSwitchgearReleaseLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobSwitchgear.SwitchgearReleaseDataSet,
                                 ctlJobSwitchgear.SwitchgearReleaseSort,
                                 ctlJobSwitchgear.SwitchgearReleaseFilter);
                        break;
                    case "Switchgear Revision Log":
                        JCCSwitchgear.Reports.Reports.JobSwitchgearRevisionLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobSwitchgear.SwitchgearRevisionDataSet,
                                 ctlJobSwitchgear.SwitchgearRevisionSort,
                                 ctlJobSwitchgear.SwitchgearRevisionFilter);
                        break;
                    case "Switchgear Release Form":
                        JCCSwitchgear.Reports.Reports.SwitchgearReleaseForm(jobID,
                                 ctlJobSwitchgear.SwitchgearReleaseID);
                        break;
                    case "Switchgear Revision Form":
                        JCCSwitchgear.Reports.Reports.SwitchgearRevisionForm(jobID,
                                 ctlJobSwitchgear.SwitchgearRevisionID);
                        break;
                    case "Light Fixture Log":
                        JCCLightFixture.Reports.Reports.JobLightFixtureLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobLightFixture.LightFixtureDataSet,
                                 ctlJobLightFixture.LightFixtureSort,
                                 ctlJobLightFixture.LightFixtureFilter);
                        break;
                    case "Light Fixture Release Log":
                        JCCLightFixture.Reports.Reports.JobLightFixtureReleaseLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobLightFixture.LightFixtureReleaseDataSet,
                                 ctlJobLightFixture.LightFixtureReleaseSort,
                                 ctlJobLightFixture.LightFixtureReleaseFilter);
                        break;
                    case "Light Fixture Revision Log":
                        JCCLightFixture.Reports.Reports.JobLightFixtureRevisionLog(jobID, txtJobNumber.Text,
                                 txtJobName.Text,
                                 ctlJobLightFixture.LightFixtureRevisionDataSet,
                                 ctlJobLightFixture.LightFixtureRevisionSort,
                                 ctlJobLightFixture.LightFixtureRevisionFilter);
                        break;
                    case "Light Fixture Release Form":
                        JCCLightFixture.Reports.Reports.LightFixtureReleaseForm(jobID,
                        ctlJobLightFixture.LightFixtureReleaseID);
                        break;
                    case "Light Fixture Revision Form":
                        JCCLightFixture.Reports.Reports.LightFixtureRevisionForm(jobID,
                        ctlJobLightFixture.LightFixtureRevisionID);
                        break;
                    case "&Sub Attachment A":
                        try
                        {
                            WordDocuments.PrintSubAttachmentA(jobID);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                        break;
                }
                btnUp.Enabled = true;
                btnDown.Enabled = true;
                SetFormAccess();


            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == "Cannot find table 0.".ToString())
                { }
                else
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }


        }
        //
        private bool CheckJobStatus(ClickedButton SelectedButton)
        {
            DialogResult result;
            bool retValue = false;
            //
            if (dataChanged)
            {
                result = MessageBox.Show("Save the job changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        if (ValidateAllControls())
                        {
                            SaveJob();
                            bindingSource.EndEdit();
                            dataChanged = false;
                            retValue = true;
                        }
                        else
                        {
                            MessageBox.Show("Please make sure to enter all required fields.", CCEApplication.ApplicationName);
                            retValue = false;
                        }
                        break;
                    case DialogResult.No:
                        GetJob();
                        bindingSource.CancelEdit();
                        if (SelectedButton == ClickedButton.Save)
                        {
                            retValue = false;
                        }
                        else
                        {
                            dataChanged = false;
                            dxErrorProvider.ClearErrors();
                            retValue = true;
                        }
                        break;
                    case DialogResult.Cancel:
                        bindingSource.CancelEdit();
                        if (SelectedButton == ClickedButton.Save)
                        {
                            retValue = true;
                        }
                        else
                        {
                            dataChanged = false;
                            dxErrorProvider.ClearErrors();
                            retValue = false;
                        }
                        break;
                }
            }
            else
            {
                bindingSource.CancelEdit();
                dataChanged = false;
                dxErrorProvider.ClearErrors();
                retValue = true;
            }
            return retValue;
        }
        //
        private void SaveJob()
        {
            // DevExpress.Utils.WaitDialogForm waitSave = new DevExpress.Utils.WaitDialogForm("", "... Saving Job ...");
            //jobID = txtRecordNo.Text.Trim();
            // DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");

            if (jobID.Trim() == "0")
            {
                jobID = "";
            }

            string certifiedContractorOrSubcontractor = "";
            string jobCertifiedReportType = "";

            if (radioCertifiedContractorOrSubcontractor.SelectedIndex == 0)
            {
                certifiedContractorOrSubcontractor = "C";
            }
            else
            {
                certifiedContractorOrSubcontractor = "S";
            }

            switch (radioJobCertifiedReportType.SelectedIndex)
            {
                case 0:
                    jobCertifiedReportType = "A";
                    break;
                case 1:
                    jobCertifiedReportType = "B";
                    break;
                case 2:
                    jobCertifiedReportType = "E";
                    break;
                case 3:
                    jobCertifiedReportType = "F";
                    break;
                case 4:
                    jobCertifiedReportType = "C";
                    break;
                case 5:
                    jobCertifiedReportType = "D";
                    break;
                case 6:
                    jobCertifiedReportType = "G";
                    break;
                case 7:
                    jobCertifiedReportType = "H";
                    break;
                default:
                    jobCertifiedReportType = "A";
                    break;
            }
            try
            {
                string name = txtJobName.Text;

                //name = String.IsNullOrEmpty(name) ? "" : name.ToUpper().Trim().Replace("'", "''").Replace((char)34, (char)32).Replace("\\", "").Replace("/", "").Replace("*", "").Replace(":", "").Replace("?", "").Replace(">", "").Replace("<", "").Replace("|", "");
                name = String.IsNullOrEmpty(name) ? "" : name.ToUpper().Trim().Replace((char)34, (char)32).Replace("\\", "").Replace("/", "").Replace("*", "").Replace(":", "").Replace("?", "").Replace(">", "").Replace("<", "").Replace("|", "");
                txtJobName.Text = name;

                Job myJob = new Job(jobID,
                            cboOffice.EditValue == null ? String.Empty : cboOffice.EditValue.ToString(),
                            cboDepartment.EditValue == null ? String.Empty : cboDepartment.EditValue.ToString(),
                            txtEstimateNumber.Text,
                            txtJobNumber.Text,
                            txtJobName.Text,
                            txtJobDescription.Text,
                            txtJobAddress.Text,
                            txtJobAddress2.Text,
                            txtJobCity.Text,
                            txtJobState.Text,
                            txtJobZip.Text,
                            txtJobPhone.Text,
                            txtCustomerID.Text.Trim() == "" ? null : txtCustomerID.Text,
                            chkBillingAsCustomer.Checked.ToString(),
                            txtBillingAddress1.Text,
                            txtBillingAddress2.Text,
                            txtBillingCity.Text,
                            txtBillingState.Text,
                            txtBillingZipCode.Text,
                            txtBillingPhone.Text,
                            txtBillingRep.Text,
                            cboOwnerClass.EditValue == null ? String.Empty : cboOwnerClass.EditValue.ToString(),
                            chkContractorAsCustomer.Checked.ToString(),
                            txtContractorName.Text,
                            txtContractorAddress1.Text,
                            txtContractorAddress2.Text,
                            txtContractorCity.Text,
                            txtContractorState.Text,
                            txtContractorZipCode.Text,
                            txtContractorPhone.Text,
                            txtContractorRep.Text,
                            chkOwnerAsCustomer.Checked.ToString(),
                            txtOwnerName.Text,
                            txtOwnerAddress1.Text,
                            txtOwnerAddress2.Text,
                            txtOwnerCity.Text,
                            txtOwnerState.Text,
                            txtOwnerZipCode.Text,
                            txtOwnerPhone.Text,
                            txtOwnerRep.Text,
                            txtOwnerContractor.Text,
                            chkLaborRates.Checked.ToString(),
                            cboAlphaCodes.EditValue == null ? String.Empty : cboAlphaCodes.EditValue.ToString(),
                            cboOtherLabor.EditValue == null ? String.Empty : cboOtherLabor.EditValue.ToString(),
                            txtMaterialMU.Text,
                            cboOtherMaterial.EditValue == null ? String.Empty : cboOtherMaterial.EditValue.ToString(),
                            txtReleaseNumber.Text,
                            cboCCEEquip.EditValue == null ? String.Empty : cboCCEEquip.EditValue.ToString(),
                            txtOutsideRentalMU.Text,
                            txtSubcontractMU.Text,
                            chkOtherMU.Checked.ToString(),
                            cboWorkType.EditValue == null ? String.Empty : cboWorkType.EditValue.ToString(),
                            cboContractType.EditValue == null ? String.Empty : cboContractType.EditValue.ToString(),
                            cboProjectManager.EditValue == null ? String.Empty : cboProjectManager.EditValue.ToString(),
                            cboEstimator.EditValue == null ? String.Empty : cboEstimator.EditValue.ToString(),
                            cboSuperintendent.EditValue == null ? String.Empty : cboSuperintendent.EditValue.ToString(),
                            cboForeman.EditValue == null ? String.Empty : cboForeman.EditValue.ToString(),
                            txtContractNumber.Text,
                            txtOriginalContractAmount.EditValue == null ? String.Empty : txtOriginalContractAmount.EditValue.ToString(),
                            txtJobFinalContractAmount.EditValue == null ? String.Empty : txtJobFinalContractAmount.EditValue.ToString(),
                            chkCopyOfVendorInvoicesNeeded.Checked.ToString(),
                            chkSubcontractors.Checked.ToString(),
                            chkCertifiedPayroll.Checked.ToString(),
                            cboBond.EditValue == null ? String.Empty : cboBond.EditValue.ToString(),
                            txtBondDate.EditValue == null ? String.Empty : txtBondDate.EditValue.ToString(),
                            txtBondNumber.Text,
                            txtPONumber.Text,
                            txtContractStartDate.Text == null ? String.Empty : txtContractStartDate.Text,
                            txtContractEstComplDate.Text,
                            txtJurisdiction.Text,
                            txtMasterJobNumber.Text,
                            cboRetainage.EditValue == null ? String.Empty : cboRetainage.EditValue.ToString(),
                            cboInsuranceProgram.EditValue == null ? String.Empty : cboInsuranceProgram.EditValue.ToString(),
                            txtTotalCLPUAmount.EditValue == null ? String.Empty : txtTotalCLPUAmount.EditValue.ToString(),
                            txtGLIABName.Text,
                            txtUMBRLName.Text,
                            chkPreliminaryNotice.Checked.ToString(),
                            txtPreliminaryDateMailed.Text,
                            txtPreliminaryMailedBy.Text,
                            txtComment.Text,
                            txtPostedToFileDate.Text,
                            txtPostedToFileBy.Text,
                            cboJobStatus.EditValue == null ? String.Empty : cboJobStatus.EditValue.ToString(),
                            chkCustomerIsSubcontractor.Checked.ToString(),
                            txtCustomerSubcontractors.Text,
                            chkWIPRequired.Checked.ToString(),
                            cboWIPStatus.EditValue == null ? String.Empty : cboWIPStatus.EditValue.ToString(),
                            cboWIPEntry.EditValue == null ? String.Empty : cboWIPEntry.EditValue.ToString(),
                            cboTrade.EditValue == null ? String.Empty : cboTrade.EditValue.ToString(),
                            cboLender.EditValue == null ? String.Empty : cboLender.EditValue.ToString(),
                            txtLenderName.Text,
                            txtLenderAddress.Text,
                            txtLenderCity.Text,
                            txtLenderState.Text,
                            txtLenderZip.Text,
                            cboReleaseToCustomer.EditValue == null ? String.Empty : cboReleaseToCustomer.EditValue.ToString(),
                            chkSignedDaily.Checked.ToString(),
                            chkSignedWorkOrder.Checked.ToString(),
                            chkTimeSheetSigned.Checked.ToString(),
                            chkSubContractorInvoicesRequired.Checked.ToString(),
                            chkCustomerAuthorizedForm.Checked.ToString(),
                            chkTrackingSpreadsheets.Checked.ToString(),
                            chkMultipleCopies.Checked.ToString(),
                            chkBillingFrequency.Checked.ToString(),
                            chkClientPercentNotification.Checked.ToString(),
                            chkLienRelease.Checked.ToString(),
                            txtCutOffDate.Text,
                            txtBidDate.Text,
                            txtBidTime.Text,
                            txtPreBidAmount.EditValue == null ? String.Empty : txtPreBidAmount.EditValue.ToString(),
                            txtFinalBidAmount.EditValue == null ? String.Empty : txtFinalBidAmount.EditValue.ToString(),
                            chkDesignBuild.Checked.ToString(),
                            chkDrawingReceived.Checked.ToString(),
                            chkQuotesRequired.Checked.ToString(),
                            chkBidForm.Checked.ToString(),
                            txtBidWalkDate.Text,
                            txtBidWalkTime.Text,
                            cboDeliveryMethod.Text,
                            txtArchitectEngineer.Text,
                            txtAddendumReceived.Text,
                            txtJobEmail.Text,
                            txtJobFax.Text,
                            cboBidTo.Text,
                            txtWONLOSTDate.Text,
                            txtMeetingDate.Text,
                            txtMeetingTime.Text,
                            txtReviewDate.Text,
                            txtReviewTime.Text,
                            chkOver250K.Checked.ToString(),
                            chkOver1M.Checked.ToString(),
                            chkVoid.Checked.ToString(),
                            chkArchive.Checked.ToString(),
                            txtRevisionJobID.Text,
                            txtRevisionID.Text,
                            cboBidBond.EditValue == null ? String.Empty : cboBidBond.EditValue.ToString(),
                            chkEstimateHandoff.Checked.ToString(),
                            cboEstimateHandoffGrade.EditValue == null ? String.Empty : cboEstimateHandoffGrade.EditValue.ToString(),
                            chkPMHandoff.Checked.ToString(),
                            cboPMHandoffGrade.EditValue == null ? String.Empty : cboPMHandoffGrade.EditValue.ToString(),
                            chkProjectStartupMeeting.Checked.ToString(),
                            cboSalesRep.EditValue == null ? String.Empty : cboSalesRep.EditValue.ToString(),
                            cboJobTech.EditValue == null ? String.Empty : cboJobTech.EditValue.ToString(),
                            Convert.ToChar(radioJobCostLevelCode.SelectedIndex + 65).ToString(),
                            Convert.ToChar(radioBillingLevelCode.SelectedIndex + 65).ToString(),
                            chkJobCertifiedFlag.Checked.ToString(),
                            chkJobTaxFlag.Checked.ToString(),
                            cboValidationCode.EditValue == null ? String.Empty : cboValidationCode.GetColumnValue("Validation Code").ToString(),
                            txtJobGLAccount.Text,
                            txtJobOverheadEquipment.EditValue == null ? String.Empty : txtJobOverheadEquipment.EditValue.ToString(),
                            txtJobOverheadLabor.Text,
                            txtJobOverheadMaterial.Text,
                            txtJobOverheadSubcontractor.Text,
                            txtJobOverheadOther.Text,
                            txtJobCompletedPercent.Text,
                            txtJobOwnerPercent.Text,
                            txtJobBurdenPercent.Text,
                            txtJobSalesTaxPercent.Text,
                            Convert.ToChar(radioJobBillingType.SelectedIndex + 65).ToString(),
                            chkSaveHistory.Checked.ToString(),
                            jobCertifiedReportType,
                            chkStatementOfCompliance.Checked.ToString(),
                            chkAlwaysPrintReport.Checked.ToString(),
                            chkDeductionDetail.Checked.ToString(),
                            certifiedContractorOrSubcontractor,
                            txtCertifiedWeekNumber.Text,
                            txtLastReportNumber.Text,
                            txtNextReportNumber.Text,
                            chkDropOffComplianceReport.Checked.ToString(),
                            chkProjectCloseoutMeeting.Checked.ToString(),
                            txtWIPComments.Text,
                            txtDuration.Text,
                            chkDashboardExclude.Checked.ToString(),
                            chkTrackChangeOrder.Checked.ToString(),
                            chkInsuranceRequiredToBeReviewed.Checked.ToString(),
                            txtOCIPClosedDate.Text,
                            chkOCIPClosed.Checked.ToString(),
                            chkCompetitve.Checked.ToString(),
                            txtCustomerComment.Text,
                            txtScopeOfWork.Text,
                            cboUnitType.EditValue == null ? "" : cboUnitType.EditValue.ToString(),
                            txtUnits.Text,
                            chkCompletedOps.Checked.ToString(),
                            chkGLAutoWC.Checked.ToString(),
                            chkProfLiab.Checked.ToString(),
                            txtCompletedOps.Text,
                            txtGLAutoWC.Text,
                            txtProfLiab.Text,
                            txtAdditionalInsured.Text.ToString());
                myJob.Save();
                jobID = myJob.JobID;

                txtRecordNo.Text = jobID;
                ctlAssignJobs.JobID = jobID;
                txtEstimateNumber.Text = myJob.EstimateNumber;
                txtJobNumber.Text = myJob.JobNumber;
                txtInsuranceProjectName.Text = myJob.jobName;
                txtInsuranceProjectNumber.Text = myJob.JobNumber;
                btnSelect.Visible = true;
                lblWONLOSTDate.Visible = true;
                txtWONLOSTDate.Visible = true;
                UpdateWIPRequiredStatus();
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            GetCostCode();
            btnSave.Enabled = false;
            //DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
        }
        //
        private void ArchiveVoidStatus()
        {
            if (!chkArchive.Checked && !chkVoid.Checked)
            {
                ctlCostCodeWeekly.Updateable = true;
                ctlJobCostCodes.Updateable = true;
                ctlJobProgress.Updateable = true;
                ctlJobProgress.IsClosed = false;
                btnSelect.Visible = true;
            }
            else
            {
                ctlCostCodeWeekly.Updateable = false;
                ctlJobCostCodes.Updateable = false;
                ctlJobProgress.Updateable = false;
                ctlJobProgress.IsClosed = true;
                btnSelect.Visible = false;
            }
        }

        private void GetJob()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");
            jobID = txtRecordNo.Text;
            if (jobID == "")
            {
                jobID = "0";
            }

            /*   ctlJobCostCodes.JobID = jobID;
               ctlJobCostCodes.JobNumber = txtJobNumber.Text;
               ctlJobCostCodes.TrackChangeOrder = chkTrackChangeOrder.Checked.ToString() == "True" ? true : false;
               ctlCostCodeWeekly.JobID = jobID;
               ctlJobProgress.JobID = jobID;
               ctlCostCodeTimeCard.JobID = jobID;
               ctlJobProgressSummary.JobID = jobID;
            //  // ctlSubcontract.JobID = jobID;
               ctlLaborAnalysis.JobID = "0";
               ctlJobInvoiceDetail.JobID = "0";
            // //  ctlJobPurchaseDetail.JobNumber = "0";
               ctlJobCostAnalysis.JobID = "0";
               ctlJobDocuments.JobID = "0"; 
               */
            GetJobDetail();
            GetCostCode();
            Text = txtJobNumber.Text + " - " + txtJobName.Text;
            ArchiveVoidStatus();





            DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();



        }
        //
        private void ControlValidating(object sender, CancelEventArgs e)
        {
            UpdateErrorMessages();
        }
        //
        private bool ValidateAllControls()
        {
            UpdateErrorMessages();
            return !errorMessages;
        }
        //
        private void AllControls_EditValue(Object sender, EventArgs e)
        {
            DevExpress.XtraEditors.BaseControl myControl = (DevExpress.XtraEditors.BaseControl)sender;
            if (myControl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
            {
                string myString = myControl.Text.Trim().ToUpper();

                if (myString != myControl.Text.Trim())
                {
                    myControl.Text = myControl.Text.ToString().ToUpper();
                }
            }
            if ((formCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                //|| 
                //(Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.RedWriteCreateSB && 
                //     starbuilderJobNumber != "0")
                )
            {
                dataChanged = false;
                return;
            }
            if (!dataChanged)
            {
                if (!chkVoid.Checked && !chkArchive.Checked)
                {
                    dataChanged = true;
                    btnSave.Enabled = true;
                }
            }
        }
        // 
        private void cboCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            PopulateCustomerInformation();
            AllControls_EditValue(sender, e);
        }
        //
        private void PopulateCustomerInformation()
        {
            try
            {
                if (cboCustomerName.Text.Trim().Length > 0 || txtCustomerID.Text.Trim().Length > 0)
                {
                    DataRow dr = Customer.GetCustomer(cboCustomerName.EditValue.ToString()).Tables[0].Rows[0];
                    txtCustomerID.Text = dr["CustomerID"].ToString();
                    txtCustomerAddress1.Text = dr["Address1"].ToString();
                    txtCustomerAddress2.Text = dr["Address2"].ToString();
                    txtCustomerCity.Text = dr["City"].ToString();
                    txtCustomerState.Text = dr["State"].ToString();
                    txtCustomerZipCode.Text = dr["ZipCode"].ToString();
                    txtCustomerPhone.Text = dr["Telephone"].ToString();
                    txtCustomerRep.Text = dr["Contact"].ToString();
                }
                else
                {
                    txtCustomerID.Text = String.Empty;
                    txtCustomerAddress1.Text = String.Empty;
                    txtCustomerAddress2.Text = String.Empty;
                    txtCustomerCity.Text = String.Empty;
                    txtCustomerState.Text = String.Empty;
                    txtCustomerZipCode.Text = String.Empty;
                    txtCustomerPhone.Text = String.Empty;
                    txtCustomerRep.Text = String.Empty;
                }
            }
            catch (Exception)
            { }
        }
        //
        private void chkContractorAsCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContractorAsCustomer.Checked)
            {
                txtContractorName.Text = cboCustomerName.Text;
                txtContractorAddress1.Text = txtCustomerAddress1.Text;
                txtContractorAddress2.Text = txtCustomerAddress2.Text;
                txtContractorCity.Text = txtCustomerCity.Text;
                txtContractorState.Text = txtCustomerState.Text;
                txtContractorZipCode.Text = txtCustomerZipCode.Text;
                txtContractorPhone.Text = txtCustomerPhone.Text;
                txtContractorRep.Text = txtCustomerRep.Text;
            }
            else
            {
                // txtContractorName.Text = "";
                txtContractorAddress1.Text = "";
                txtContractorAddress2.Text = "";
                txtContractorCity.Text = "";
                txtContractorState.Text = "";
                txtContractorZipCode.Text = "";
                txtContractorPhone.Text = "";
                txtContractorRep.Text = "";
            }
        }
        //
        private void chkOwnerAsCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOwnerAsCustomer.Checked)
            {
                txtOwnerName.Text = cboCustomerName.Text;
                txtOwnerAddress1.Text = txtBillingAddress1.Text;
                txtOwnerAddress2.Text = txtBillingAddress2.Text;
                txtOwnerCity.Text = txtBillingCity.Text;
                txtOwnerState.Text = txtBillingState.Text;
                txtOwnerZipCode.Text = txtBillingZipCode.Text;
                txtOwnerPhone.Text = txtBillingPhone.Text;
                txtOwnerRep.Text = txtBillingRep.Text;
            }
        }
        //
        private void chkBillingAsCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (cboCustomerName.EditValue.ToString().Length > 0 && chkBillingAsCustomer.Checked)
            {
                try
                {
                    DataRow dr = Customer.GetCustomer(cboCustomerName.EditValue.ToString()).Tables[0].Rows[0];
                    txtCustomerID.Text = dr["CustomerID"].ToString();
                    txtBillingAddress1.Text = dr["Address1"].ToString();
                    txtBillingAddress2.Text = dr["Address2"].ToString();
                    txtBillingCity.Text = dr["City"].ToString();
                    txtBillingState.Text = dr["State"].ToString();
                    txtBillingZipCode.Text = dr["ZipCode"].ToString();
                    txtBillingPhone.Text = dr["Telephone"].ToString();
                    txtBillingRep.Text = dr["Contact"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }
        //
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string[] retValue = new string[2];
            frmSelect f = new frmSelect(jobStatus);
            retValue = f.SelectList();
            if (!String.IsNullOrEmpty(retValue[0].ToString()))
            {
                txtRevisionJobID.Text = retValue[0].ToString();
                txtRevisionDescription.Text = retValue[1];
                if (!String.IsNullOrEmpty(retValue[1]))
                {
                    txtRevisionID.Text = retValue[1].Substring(0, 1);
                }
            }
            else
            {
                txtRevisionJobID.Text = null;
                txtRevisionID.Text = null;
            }
        }
        // 
        private void cboJobStatus_EditValueChanged(object sender, EventArgs e)
        {
            jobStatus = cboJobStatus.Text.Trim();
            if (jobStatus == "WON" &&
                //Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.RedWriteCreateSB && 
                jobStatus != jobStatusBefore &&
                !callFromUpdateJob)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.RedWriteCreateSB &&
                    txtRevisionEstimateNumber.Text.Trim().Length == 0 &&
                    txtRevisionJobNumber.Text.Trim().Length == 0
                    )
                {
                    cboJobStatus.Visible = false;
                    cboJobStatus.AllowDrop = false;
                    cboJobStatus.ErrorText = "You don't have access to change Status to WON";
                    if (jobStatusBefore.Length > 0)
                    {
                        cboJobStatus.Text = jobStatusBefore;
                    }
                    else
                    {
                        cboJobStatus.Text = "BUDGET";
                    }

                    cboJobStatus.AllowDrop = true;
                    cboJobStatus.ClosePopup();
                    cboJobStatus.Visible = true;
                    return;
                }
            }
            jobStatusBefore = cboJobStatus.Text.Trim();
            if (jobStatus == "")
            {
                lblSelect.Visible = true;
                lblSelect.Text = "Select a Job Template:";
                cboSelect.Visible = true;
                radioSelect.Visible = true;
            }
            else
            {
                //lblSelect.Visible = false;
                lblSelect.Text = "  Contract Type: " + cboContractType.Text;
                cboSelect.Visible = false;
                radioSelect.Visible = false;
            }
            if (jobStatus == "WON" || jobStatus == "LOST")
            {
                if (txtWONLOSTDate.Text == "")
                {
                    txtWONLOSTDate.Text = DateTime.Now.Date.ToShortDateString();
                }

                txtWONLOSTDate.Visible = true;
                lblWONLOSTDate.Visible = true;

                if (jobStatus == "WON")
                {
                    UpdateWIPRequiredStatus();
                }
            }
            else
            {
            }
            UpdateErrorMessages();
            AllControls_EditValue(sender, e);
        }
        //
        private void UpdateJob(string jobID, string updateSection)
        {
            DataRow dr;
            try
            {
                dr = Job.GetJob(jobID).Tables[0].Rows[0];
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                return;
            }
            switch (updateSection)
            {
                case "Estimate":
                    txtJobName.Text = dr["jobName"].ToString();
                    txtJobDescription.Text = dr["JobDescription"].ToString();
                    txtJobPhone.Text = dr["jobPhone"].ToString();
                    txtJobAddress.Text = dr["jobAddress1"].ToString();
                    txtJobCity.Text = dr["jobCity"].ToString();
                    txtJobAddress2.Text = dr["jobAddress2"].ToString();
                    txtJobState.Text = dr["JobState"].ToString();
                    txtJobZip.Text = dr["JobZip"].ToString();
                    txtJobPhone.Text = dr["JobPhone"].ToString();
                    txtRevisionEstimateNumber.Text = dr["EstimateNumber"].ToString();
                    txtRevisionJobNumber.Text = dr["JobNumber"].ToString();
                    txtRevisionDescription.Text = dr["RevisionID"].ToString() + " - " + dr["RevisionDescription"].ToString();
                    break;
                case "Job":
                    break;
                case "All":
                    /* San Diego */
                    //starbuilderJobNumber = String.IsNullOrEmpty(dr["Job_no"].ToString()) ? "0" : dr["Job_no"].ToString();

                    txtInsuranceProjectNumber.Text = dr["JobNumber"].ToString();
                    txtInsuranceProjectName.Text = dr["jobName"].ToString();
                    txtAdditionalInsured.Text = string.IsNullOrEmpty(dr["AdditionalInsured"].ToString()) || dr["AdditionalInsured"].ToString() == "" ? "Dynalectric Company, EMCOR GROUP INC." : dr["AdditionalInsured"].ToString();
                    txtRevisionEstimateNumber.Text = dr["RevisionEstimateNumber"].ToString();
                    txtRevisionJobNumber.Text = dr["RevisionJobNumber"].ToString();
                    txtRevisionDescription.Text = dr["RevisionID"].ToString() + " - " + dr["RevisionDescription"].ToString();
                    txtOpportunityNumber.Text = dr["OTProjectNumber"].ToString();
                    txtEstimateNumber.Text = dr["EstimateNumber"].ToString();
                    txtJobNumber.Text = dr["JobNumber"].ToString();
                    cboOffice.EditValue = dr["OfficeID"];
                    cboDepartment.EditValue = dr["DepartmentID"];
                    txtJobName.Text = dr["jobName"].ToString();
                    txtJobDescription.Text = dr["JobDescription"].ToString();
                    txtJobPhone.Text = dr["jobPhone"].ToString();
                    txtJobAddress.Text = dr["jobAddress1"].ToString();
                    txtJobCity.Text = dr["jobCity"].ToString();
                    txtJobAddress2.Text = dr["jobAddress2"].ToString();
                    txtJobState.Text = dr["JobState"].ToString();
                    txtJobZip.Text = dr["JobZip"].ToString();
                    txtJobPhone.Text = dr["JobPhone"].ToString();
                    txtOwnerContractor.Text = dr["OwnerName"].ToString();
                    txtContractorOwner.Text = dr["ContractorName"].ToString();
                    //
                    cboCustomerName.EditValue = dr["CustomerID"].ToString();
                    txtCustomerID.Text = dr["CustomerID"].ToString();
                    chkBillingAsCustomer.Checked = dr["BillingAsCustomer"].ToString() == "True" ? true : false;
                    txtBillingAddress1.Text = dr["BillingAddress1"].ToString();
                    txtBillingAddress2.Text = dr["BillingAddress2"].ToString();
                    txtBillingCity.Text = dr["BillingCity"].ToString();
                    txtBillingState.Text = dr["BillingState"].ToString();
                    txtBillingZipCode.Text = dr["BillingZipCode"].ToString();
                    txtBillingPhone.Text = dr["BillingPhone"].ToString();
                    txtBillingRep.Text = dr["BillingRep"].ToString();
                    cboOwnerClass.EditValue = dr["OwnerClassID"];
                    chkContractorAsCustomer.Checked = dr["ContractorAsCustomer"].ToString() == "True" ? true : false;
                    txtContractorName.Text = dr["ContractorName"].ToString();
                    txtContractorAddress1.Text = dr["ContractorAddress1"].ToString();
                    txtContractorAddress2.Text = dr["ContractorAddress2"].ToString();
                    txtContractorCity.Text = dr["ContractorCity"].ToString();
                    txtContractorState.Text = dr["ContractorState"].ToString();
                    txtContractorZipCode.Text = dr["ContractorZipCode"].ToString();
                    txtContractorPhone.Text = dr["ContractorPhone"].ToString();
                    txtContractorRep.Text = dr["ContractorRep"].ToString();
                    chkOwnerAsCustomer.Checked = dr["OwnerAsCustomer"].ToString() == "True" ? true : false;
                    txtOwnerName.Text = dr["OwnerName"].ToString();
                    txtOwnerAddress1.Text = dr["OwnerAddress1"].ToString();
                    txtOwnerAddress2.Text = dr["OwnerAddress2"].ToString();
                    txtOwnerCity.Text = dr["OwnerCity"].ToString();
                    txtOwnerState.Text = dr["OwnerState"].ToString();
                    txtOwnerZipCode.Text = dr["OwnerZipCode"].ToString();
                    txtOwnerPhone.Text = dr["OwnerPhone"].ToString();
                    txtOwnerRep.Text = dr["OwnerRep"].ToString();
                    //
                    chkLaborRates.Checked = dr["LaborRates"].ToString() == "True" ? true : false;
                    cboAlphaCodes.EditValue = dr["AlphaCodes"].ToString();
                    cboOtherLabor.EditValue = dr["OtherLabor"].ToString();
                    txtMaterialMU.Text = dr["MaterialMU"].ToString();
                    cboOtherMaterial.EditValue = dr["OtherMaterial"].ToString();
                    txtReleaseNumber.Text = dr["ReleaseNumber"].ToString();
                    cboCCEEquip.EditValue = dr["CCEEquip"].ToString();
                    txtOutsideRentalMU.Text = dr["OutsideRentalMU"].ToString();
                    txtSubcontractMU.Text = dr["SubcontractMU"].ToString();
                    chkOtherMU.Checked = dr["OtherMU"].ToString() == "True" ? true : false;
                    cboWorkType.EditValue = dr["WorkTypeID"];
                    cboContractType.EditValue = dr["ContractTypeID"];
                    cboProjectManager.EditValue = dr["ProjectManagerID"];
                    cboEstimator.EditValue = dr["EstimatorID"];
                    cboSuperintendent.EditValue = dr["SuperIntendentID"];
                    cboForeman.EditValue = dr["ForemanID"];
                    txtContractNumber.Text = dr["ContractNumber"].ToString();
                    txtOriginalContractAmount.Text = dr["OriginalContractAmount"].ToString();
                    txtJobFinalContractAmount.Text = dr["JobFinalContractAmount"].ToString();
                    chkCopyOfVendorInvoicesNeeded.Checked = dr["CopyOfVendorInvoicesNeeded"].ToString() == "True" ? true : false;
                    chkSubcontractors.Checked = dr["Subcontractors"].ToString() == "True" ? true : false;
                    chkCertifiedPayroll.Checked = dr["CertifiedPayroll"].ToString() == "True" ? true : false;
                    cboBond.EditValue = dr["BondID"];
                    txtBondDate.EditValue = String.IsNullOrEmpty(dr["BondDate"].ToString()) ? null : dr["BondDate"];
                    txtBondNumber.Text = dr["BondNumber"].ToString();
                    txtPONumber.Text = dr["PONumber"].ToString();
                    txtContractStartDate.EditValue = String.IsNullOrEmpty(dr["ContractStartDate"].ToString()) ? null : dr["ContractStartDate"];
                    txtContractEstComplDate.EditValue = String.IsNullOrEmpty(dr["ContractEstComplDate"].ToString()) ? null : dr["ContractEstComplDate"];
                    txtJurisdiction.Text = dr["Jurisdiction"].ToString();
                    txtMasterJobNumber.Text = dr["MasterJobNumber"].ToString();
                    cboRetainage.EditValue = dr["RetainageID"];
                    cboInsuranceProgram.EditValue = dr["InsuranceProgramID"];
                    txtTotalCLPUAmount.Text = dr["totalCLPUAmount"].ToString();
                    txtGLIABName.Text = dr["GLIABName"].ToString();
                    txtUMBRLName.Text = dr["UMBRLName"].ToString();
                    chkPreliminaryNotice.Checked = dr["PreliminaryNotice"].ToString() == "True" ? true : false;
                    txtPreliminaryDateMailed.EditValue = String.IsNullOrEmpty(dr["PreliminaryDateMailed"].ToString()) ? null : dr["PreliminaryDateMailed"];
                    txtPreliminaryMailedBy.Text = dr["PreliminaryMailedBy"].ToString();
                    txtComment.Text = dr["Comment"].ToString();
                    txtPostedToFileDate.Text = String.IsNullOrEmpty(dr["PostedToFileDate"].ToString()) ? null : dr["PostedToFileDate"].ToString().Substring(0, 10);
                    txtPostedToFileBy.Text = dr["PostedToFileBy"].ToString();
                    callFromUpdateJob = true;
                    cboJobStatus.EditValue = dr["JobStatusID"];
                    callFromUpdateJob = false;
                    chkCustomerIsSubcontractor.Checked = dr["CustomerIsSubcontractor"].ToString() == "True" ? true : false;
                    txtCustomerSubcontractors.Text = dr["customerSubcontractors"].ToString();
                    chkWIPRequired.Checked = dr["WIPRequired"].ToString() == "True" ? true : false;
                    cboWIPStatus.EditValue = dr["WIPStatus"].ToString();
                    cboWIPEntry.EditValue = dr["WIPEntryID"];
                    cboTrade.EditValue = dr["trade"].ToString();
                    cboLender.EditValue = dr["lenderID"];
                    txtLenderName.Text = dr["LenderName"].ToString();
                    txtLenderAddress.Text = dr["lenderAddress"].ToString();
                    txtLenderCity.Text = dr["lenderCity"].ToString();
                    txtLenderState.Text = dr["lenderState"].ToString();
                    txtLenderZip.Text = dr["lenderZip"].ToString();
                    cboReleaseToCustomer.EditValue = dr["releaseToCustomer"].ToString();
                    chkSignedDaily.Checked = dr["SignedDaily"].ToString() == "True" ? true : false;
                    chkSignedWorkOrder.Checked = dr["SignedWorkOrder"].ToString() == "True" ? true : false;
                    chkTimeSheetSigned.Checked = dr["timeSheetSigned"].ToString() == "True" ? true : false;
                    chkSubContractorInvoicesRequired.Checked = dr["subContractorInvoicesRequired"].ToString() == "True" ? true : false;
                    chkCustomerAuthorizedForm.Checked = dr["CustomerAuthorizedForm"].ToString() == "True" ? true : false;
                    chkTrackingSpreadsheets.Checked = dr["trackingSpreadsheets"].ToString() == "True" ? true : false;
                    chkMultipleCopies.Checked = dr["multipleCopies"].ToString() == "True" ? true : false;
                    chkBillingFrequency.Checked = dr["billingFrequency"].ToString() == "True" ? true : false;
                    chkClientPercentNotification.Checked = dr["ClientPercentNotification"].ToString() == "True" ? true : false;
                    chkLienRelease.Checked = dr["lienRelease"].ToString() == "True" ? true : false;
                    txtCutOffDate.EditValue = String.IsNullOrEmpty(dr["CutOffDate"].ToString()) ? null : dr["CutOffDate"];
                    txtBidDate.EditValue = String.IsNullOrEmpty(dr["bidDate"].ToString()) ? null : dr["BidDate"];
                    txtBidTime.Text = String.IsNullOrEmpty(dr["bidTime"].ToString()) ? null : dr["bidTime"].ToString();
                    txtPreBidAmount.Text = String.IsNullOrEmpty(dr["preBidAmount"].ToString()) ? null : dr["preBidAmount"].ToString();
                    txtFinalBidAmount.Text = String.IsNullOrEmpty(dr["FinalBidAmount"].ToString()) ? null : dr["FinalBidAmount"].ToString();
                    chkDesignBuild.Checked = dr["designBuild"].ToString() == "True" ? true : false;
                    chkDrawingReceived.Checked = dr["drawingReceived"].ToString() == "True" ? true : false;
                    chkQuotesRequired.Checked = dr["quotesRequired"].ToString() == "True" ? true : false;
                    chkBidForm.Checked = dr["bidForm"].ToString() == "True" ? true : false;
                    txtBidWalkDate.EditValue = String.IsNullOrEmpty(dr["bidWalkDate"].ToString()) ? null : dr["bidWalkDate"];
                    txtBidWalkTime.Text = String.IsNullOrEmpty(dr["bidWalkTime"].ToString()) ? null : dr["bidWalkTime"].ToString();
                    cboDeliveryMethod.Text = dr["deliveryMethod"].ToString();
                    txtArchitectEngineer.Text = dr["architectEngineer"].ToString();
                    txtAddendumReceived.Text = dr["addendumReceived"].ToString();
                    txtJobEmail.Text = dr["jobEmail"].ToString();
                    txtJobFax.Text = dr["jobFax"].ToString();
                    cboBidTo.Text = dr["bidTo"].ToString();
                    txtWONLOSTDate.EditValue = String.IsNullOrEmpty(dr["WonLostDate"].ToString()) ? null : dr["WonLostDate"];
                    txtMeetingDate.EditValue = String.IsNullOrEmpty(dr["meetingDate"].ToString()) ? null : dr["meetingDate"];
                    txtMeetingTime.Text = dr["MeetingTime"].ToString();
                    txtReviewDate.EditValue = String.IsNullOrEmpty(dr["reviewDate"].ToString()) ? null : dr["reviewDate"];

                    txtReviewTime.Text = dr["ReviewTime"].ToString();
                    chkOver250K.Checked = dr["over250k"].ToString() == "True" ? true : false;
                    chkOver1M.Checked = dr["over1M"].ToString() == "True" ? true : false;
                    chkVoid.Checked = dr["void"].ToString() == "True" ? true : false;
                    chkArchive.Checked = dr["archived"].ToString() == "True" ? true : false;
                    cboBidBond.EditValue = dr["BidBondID"];
                    //
                    txtRevisionEstimateNumber.Text = dr["RevisionEstimateNumber"].ToString();
                    txtRevisionJobNumber.Text = dr["RevisionJobNumber"].ToString();
                    txtRevisionDescription.Text = dr["RevisionID"].ToString() + " - " + dr["RevisionDescription"].ToString();
                    txtRevisionID.Text = dr["RevisionID"].ToString();
                    txtRevisionJobID.Text = dr["RevisionJobID"].ToString();
                    txtDuration.Text = dr["Duration"].ToString();
                    //
                    chkEstimateHandoff.Checked = dr["EstimateHandoff"].ToString() == "True" ? true : false;
                    cboEstimateHandoffGrade.Text = dr["EstimateHandoffGrade"].ToString();
                    chkPMHandoff.Checked = dr["PMHandoff"].ToString() == "True" ? true : false;
                    cboPMHandoffGrade.Text = dr["PMHandoffGrade"].ToString();
                    chkProjectStartupMeeting.Checked = dr["ProjectStartupMeeting"].ToString() == "True" ? true : false;
                    chkDropOffComplianceReport.Checked = dr["DropOffComplianceReport"].ToString() == "True" ? true : false;
                    chkProjectCloseoutMeeting.Checked = dr["ProjectCloseoutMeeting"].ToString() == "True" ? true : false;
                    chkDashboardExclude.Checked = dr["Dashboard"].ToString() == "True" ? true : false;
                    chkTrackChangeOrder.Checked = dr["TrackChangeOrder"].ToString() == "True" ? true : false;
                    chkInsuranceRequiredToBeReviewed.Checked = dr["InsuranceRequiredToBeReviewed"].ToString() == "True" ? true : false;
                    chkOCIPClosed.Checked = dr["OCIPClosed"].ToString() == "True" ? true : false;
                    chkCompetitve.Checked = dr["Competitive"].ToString() == "True" ? true : false;
                    txtOCIPClosedDate.Text = String.IsNullOrEmpty(dr["OCIPClosedDate"].ToString()) ? null : String.Format("{0:MM/dd/yyyy}", dr["OCIPClosedDate"]);
                    txtCustomerComment.Text = dr["CustomerComment"].ToString();
                    txtScopeOfWork.Text = dr["ScopeOfWork"].ToString();
                    cboCustomerName.ErrorText = "";
                    cboSalesRep.EditValue = dr["SalesRepID"];
                    cboJobTech.EditValue = dr["JobTechID"];
                    if (String.IsNullOrEmpty(dr["JobCostLevelCode"].ToString()))
                    {
                        radioJobCostLevelCode.SelectedIndex = 2;
                    }
                    else
                    {
                        switch (dr["JobCostLevelCode"].ToString())
                        {
                            case "A":
                                radioJobCostLevelCode.SelectedIndex = 0;
                                break;
                            case "B":
                                radioJobCostLevelCode.SelectedIndex = 1;
                                break;
                            case "C":
                            default:
                                radioJobCostLevelCode.SelectedIndex = 2;
                                break;
                        }
                    }
                    if (String.IsNullOrEmpty(dr["BillingLevelCode"].ToString()))
                    {
                        radioBillingLevelCode.SelectedIndex = 0;
                    }
                    else
                    {
                        switch (dr["BillingLevelCode"].ToString())
                        {
                            case "A":
                            default:
                                radioBillingLevelCode.SelectedIndex = 0;
                                break;
                            case "B":
                                radioBillingLevelCode.SelectedIndex = 1;
                                break;
                            case "C":
                                radioBillingLevelCode.SelectedIndex = 2;
                                break;
                        }
                    }
                    chkJobCertifiedFlag.Checked = dr["JobCertifiedFlag"].ToString() == "True" ? true : false;
                    chkJobTaxFlag.Checked = dr["JobTaxFlag"].ToString() == "True" ? true : false;

                    StaticTables.Account.DefaultView.Sort = "Validation Code";
                    DataRowView[] r = StaticTables.Account.DefaultView.FindRows(dr["JobValidationCode"].ToString());
                    if (r != null && r.LongLength > 0)
                    {
                        cboValidationCode.EditValue = r[0]["AccountID"];
                    }
                    else
                    {
                        cboValidationCode.EditValue = null;
                    }

                    txtJobGLAccount.Text = dr["JobGLAccount"].ToString();
                    txtJobOverheadEquipment.Text = dr["JobOverheadEquipment"].ToString();
                    txtJobOverheadLabor.Text = dr["JobOverheadLabor"].ToString();
                    txtJobOverheadMaterial.Text = dr["JobOverheadMaterial"].ToString();
                    txtJobOverheadSubcontractor.Text = dr["JobOverheadSubcontractor"].ToString();
                    txtJobOverheadOther.Text = dr["JobOverheadOther"].ToString();
                    txtJobCompletedPercent.Text = dr["JobPercentCompletion"].ToString();
                    txtJobOwnerPercent.Text = dr["JobOwnerCompletion"].ToString();
                    txtJobBurdenPercent.Text = dr["JobBurdenPercent"].ToString();
                    txtJobSalesTaxPercent.Text = dr["JobSalesTaxPercent"].ToString();
                    if (String.IsNullOrEmpty(dr["JobBillingType"].ToString()))
                    {
                        radioJobBillingType.SelectedIndex = 0;
                    }
                    else
                    {
                        switch (dr["JobBillingType"].ToString())
                        {
                            case "A":
                            default:
                                radioJobBillingType.SelectedIndex = 0;
                                break;
                            case "B":
                                radioJobBillingType.SelectedIndex = 1;
                                break;
                            case "C":
                                radioJobBillingType.SelectedIndex = 2;
                                break;
                            case "D":
                                radioJobBillingType.SelectedIndex = 3;
                                break;
                        }
                    }
                    chkSaveHistory.Checked = dr["JobSaveHistoryFlag"].ToString() == "True" ? true : false;
                    if (String.IsNullOrEmpty(dr["JobCertifiedReportType"].ToString()))
                    {
                        radioJobCertifiedReportType.SelectedIndex = 0;
                    }
                    else
                    {
                        switch (dr["JobCertifiedReportType"].ToString())
                        {
                            case "A":
                                radioJobCertifiedReportType.SelectedIndex = 0;
                                break;
                            case "B":
                                radioJobCertifiedReportType.SelectedIndex = 1;
                                break;
                            case "E":
                                radioJobCertifiedReportType.SelectedIndex = 2;
                                break;
                            case "F":
                                radioJobCertifiedReportType.SelectedIndex = 3;
                                break;
                            case "C":
                                radioJobCertifiedReportType.SelectedIndex = 4;
                                break;
                            case "D":
                                radioJobCertifiedReportType.SelectedIndex = 5;
                                break;
                            case "G":
                                radioJobCertifiedReportType.SelectedIndex = 6;
                                break;
                            case "H":
                                radioJobCertifiedReportType.SelectedIndex = 7;
                                break;
                            default:
                                radioJobCertifiedReportType.SelectedIndex = 0;
                                break;
                        }
                    }
                    chkStatementOfCompliance.Checked = dr["PrintStatementOfCompliance"].ToString() == "True" ? true : false;
                    chkAlwaysPrintReport.Checked = dr["PrintAlwaysPrintReport"].ToString() == "True" ? true : false;
                    chkDeductionDetail.Checked = dr["PrintDeductionDetail"].ToString() == "True" ? true : false;
                    if (String.IsNullOrEmpty(dr["CertifiedContractorOrSubcontractor"].ToString()))
                    {
                        radioCertifiedContractorOrSubcontractor.SelectedIndex = 1;
                    }
                    else
                    {
                        switch (dr["CertifiedContractorOrSubcontractor"].ToString())
                        {
                            case "C":
                                radioCertifiedContractorOrSubcontractor.SelectedIndex = 0;
                                break;
                            case "S":
                            default:
                                radioCertifiedContractorOrSubcontractor.SelectedIndex = 1;
                                break;
                        }
                    }
                    txtCertifiedWeekNumber.Text = dr["CertifiedWeekNumber"].ToString();
                    txtLastReportNumber.Text = dr["LastReportNumber"].ToString();
                    txtNextReportNumber.Text = dr["NextReportNumber"].ToString();
                    txtWIPComments.Text = dr["WIPComments"].ToString();
                    cboUnitType.EditValue = dr["UnitType"].ToString();
                    txtUnits.Text = String.IsNullOrEmpty(dr["Units"].ToString()) ? null : dr["Units"].ToString();

                    chkCompletedOps.Checked = dr["CompletedOps"].ToString() == "True" ? true : false;
                    chkGLAutoWC.Checked = dr["GLAutoWC"].ToString() == "True" ? true : false;
                    chkProfLiab.Checked = dr["ProfLiab"].ToString() == "True" ? true : false;


                    txtCompletedOps.Text = String.IsNullOrEmpty(dr["CompletedOpsYears"].ToString()) ? null : dr["CompletedOpsYears"].ToString();
                    txtGLAutoWC.Text = String.IsNullOrEmpty(dr["GLAutoWCYears"].ToString()) ? null : dr["GLAutoWCYears"].ToString();
                    txtProfLiab.Text = String.IsNullOrEmpty(dr["ProfLiabYears"].ToString()) ? null : dr["ProfLiabYears"].ToString();

                    PopulateCustomerInformation();
                    break;
                default:
                    break;
            }
            tabJobDetail.SelectedTabPage = pgStarBuilder;
            tabJobDetail.SelectedTabPage = pgBid;
            cboCustomerName.ErrorText = "";
            btnSelect.Visible = true;
            lblWONLOSTDate.Visible = true;
            txtWONLOSTDate.Visible = true;
            jobStatusBefore = cboJobStatus.Text.Trim();
            UpdateWIPRequiredStatus();
            UpdateScopeOfWorkScreen();

        }
        //
        private void UpdateErrorMessages()
        {
            bool errorCustomer = false;
            errorMessages = false;
            bool newJobWithoutEstimate = false;
            bool modifyJobWithoutEstimate = false;

            // Identify Job Status
            if (txtEstimateNumber.Text.Trim().Length == 0 && txtJobNumber.Text.Trim().Length == 0)
            {
            }

            if (txtEstimateNumber.Text.Trim().Length > 0 && txtJobNumber.Text.Trim().Length == 0)
            {
            }

            if (txtEstimateNumber.Text.Trim().Length > 0 && txtJobNumber.Text.Trim().Length == 0 &&
                cboJobStatus.Text.Trim().Length > 0 && (cboJobStatus.Text.Trim() == "WON"))
            {
            }

            if (txtEstimateNumber.Text.Trim().Length == 0 && txtJobNumber.Text.Trim().Length == 0 &&
                cboJobStatus.Text.Trim().Length > 0 && (cboJobStatus.Text.Trim() == "WON"))
            {
                newJobWithoutEstimate = true;
            }

            if (txtEstimateNumber.Text.Trim().Length > 0 && txtJobNumber.Text.Trim().Length > 0)
            {
            }

            if (txtEstimateNumber.Text.Trim().Length == 0 && txtJobNumber.Text.Trim().Length > 0)
            {
                modifyJobWithoutEstimate = true;
            }

            // Clear Error Text
            txtJobNumber.ErrorText = "";
            txtBidDate.ErrorText = "";
            txtBidTime.ErrorText = "";
            txtBidWalkDate.ErrorText = "";
            txtBidWalkTime.ErrorText = "";
            txtJobFax.ErrorText = "";
            txtJobEmail.ErrorText = "";
            txtPreBidAmount.ErrorText = "";
            txtAddendumReceived.ErrorText = "";
            txtArchitectEngineer.ErrorText = "";
            txtJobName.ErrorText = "";
            txtJobAddress.ErrorText = "";
            txtJobAddress2.ErrorText = "";
            txtJobCity.ErrorText = "";
            txtJobState.ErrorText = "";
            txtJobZip.ErrorText = "";
            //txtJobPhone.ErrorText = "";
            txtJobDescription.ErrorText = "";
            txtContractStartDate.ErrorText = "";
            cboJobStatus.ErrorText = "";
            cboOffice.ErrorText = "";
            cboDepartment.ErrorText = "";
            txtContractStartDate.ErrorText = "";
            txtContractEstComplDate.ErrorText = "";
            txtContractEstComplDate.ErrorText = "";
            cboWorkType.ErrorText = "";
            cboContractType.ErrorText = "";
            //cboProjectManager.ErrorText = "";
            cboEstimator.ErrorText = "";
            cboSalesRep.ErrorText = "";
            cboJobTech.ErrorText = "";
            cboCustomerName.ErrorText = "";
            cboBidTo.ErrorText = "";
            txtOwnerContractor.ErrorText = "";
            txtContractorOwner.ErrorText = "";
            //cboSuperintendent.ErrorText = "";
            //cboForeman.ErrorText = "";
            cboDeliveryMethod.ErrorText = "";
            //
            if (chkWIPRequired.EditValue != null && chkWIPRequired.EditValue.ToString() == "False" && cboJobStatus.Text.Trim() == "WON"
                && txtJobNumber.Properties.ReadOnly == false)
            {
                if (txtJobNumber.Text.Trim().Length == 0)
                {
                    txtJobNumber.ErrorText = "Non WIP Job - Job Number Is Required!";
                    errorMessages = true;
                }
                else
                {
                    try
                    {
                        Job.IsTheJobInTheSystem(txtJobNumber.Text);
                    }
                    catch (Exception ex)
                    {
                        txtJobNumber.ErrorText = ex.Message;
                        errorMessages = true;
                    }
                }

            }

            if (!modifyJobWithoutEstimate && !newJobWithoutEstimate)
            {

                if (txtBidDate.Text.Trim().Length == 0)
                {
                    txtBidDate.ErrorText = "Bid Date is required";
                    errorMessages = true;
                }
                if (txtBidTime.Text.Trim().Length == 0)
                {
                    txtBidTime.ErrorText = "Bid Time is required";
                    errorMessages = true;
                }
                if (txtBidWalkDate.Text.Trim().Length == 0)
                {
                    txtBidWalkDate.ErrorText = "Bid Walk Date is required";
                    errorMessages = true;
                }
                if (txtBidWalkTime.Text.Trim().Length == 0)
                {
                    txtBidWalkTime.ErrorText = "Bid Walk Time is required";
                    errorMessages = true;
                }
                if (cboDeliveryMethod.Text.Trim().Length == 0)
                {
                    cboDeliveryMethod.ErrorText = "Delivery Method is required";
                    errorMessages = true;
                }
                if (cboDeliveryMethod.Text.Trim() == "Faxed")
                {
                    if (txtJobFax.Text.Trim().Length == 0)
                    {
                        txtJobFax.ErrorText = "Fax is required";
                        errorMessages = true;
                    }
                }
                if (cboDeliveryMethod.Text.Trim() == "E-Mailed")
                {
                    if (txtJobEmail.Text.Trim().Length == 0)
                    {
                        txtJobEmail.ErrorText = "E-Mail is required";
                        errorMessages = true;
                    }
                }
                if (txtPreBidAmount.Text.Trim().Length == 0)
                {
                    txtPreBidAmount.ErrorText = "Pre-Bid Amount is required";
                    errorMessages = true;
                }
                if (txtArchitectEngineer.Text.Trim().Length == 0)
                {
                    txtArchitectEngineer.ErrorText = "Architect Engineer is required";
                    errorMessages = true;
                }
                else
                {
                    txtArchitectEngineer.ErrorText = "";
                }

                if (txtAddendumReceived.Text.Trim().Length == 0)
                {
                    txtAddendumReceived.ErrorText = "Addendum Received is required";
                    errorMessages = true;
                }
                if (cboEstimator.Text.Trim().Length == 0)
                {
                    cboEstimator.ErrorText = "Estimator is required";
                    errorMessages = true;
                }
                if (cboBidTo.Text.Trim().Length == 0)
                {
                    cboBidTo.ErrorText = "Bid To is required";
                    errorMessages = true;
                }
                if (cboBidTo.Text == "Owner")
                {
                    if (txtOwnerContractor.Text.Trim().Length == 0)
                    {
                        txtOwnerContractor.ErrorText = "Owner is required";
                        errorMessages = true;
                    }
                }
                else
                {
                    if (txtContractorOwner.Text.Trim().Length == 0)
                    {
                        txtContractorOwner.ErrorText = "Contractor is required";
                        errorMessages = true;
                    }
                    if (txtOwnerContractor.Text.Trim().Length == 0)
                    {
                        txtOwnerContractor.ErrorText = "Owner is required";
                        errorMessages = true;
                    }

                }

            }
            if (txtJobName.Text.Trim().Length == 0)
            {
                txtJobName.ErrorText = "Job Name is required";
                errorMessages = true;
            }
            if (txtJobAddress.Text.Trim().Length == 0)
            {
                txtJobAddress.ErrorText = "Job Address is required";
                errorMessages = true;
            }
            if (txtJobCity.Text.Trim().Length == 0)
            {
                txtJobCity.ErrorText = "Job City is required";
                errorMessages = true;
            }
            if (txtJobState.Text.Trim().Length == 0)
            {
                txtJobState.ErrorText = "Job State is required";
                errorMessages = true;
            }
            if (txtJobZip.Text.Trim().Length == 0 || txtJobZip.Text.Trim().Length != 5)
            {
                txtJobZip.ErrorText = "5 Digits Job Zip Code is required - If there is no Zip Code, use 99999 instead";
                errorMessages = true;
            }
            /* if (txtJobPhone.Text.Trim().Length == 0)
             {
                 txtJobPhone.ErrorText = "Job Phone is required";
                 errorMessages = true;
             }*/




            if (txtJobDescription.Text.Trim().Length == 0)
            {
                txtJobDescription.ErrorText = "Job Description is required";
                errorMessages = true;
            }
            if (cboJobStatus.Text.Trim().Length == 0)
            {
                cboJobStatus.ErrorText = "Job Status is required";
                errorMessages = true;
            }
            if (cboOffice.Text.Trim().Length == 0)
            {
                cboOffice.ErrorText = "Office is required";
                errorMessages = true;
            }
            if (cboDepartment.Text.Trim().Length == 0)
            {
                cboDepartment.ErrorText = "Department is required";
                errorMessages = true;
            }
            if (cboWorkType.Text.Trim().Length == 0)
            {
                cboWorkType.ErrorText = "Work Type is required";
                errorMessages = true;
            }
            if (cboContractType.Text.Trim().Length == 0)
            {
                cboContractType.ErrorText = "Contract Type is required";
                errorMessages = true;
            }
            /* if (cboProjectManager.Text.Trim().Length == 0)
             {
                 cboProjectManager.ErrorText = "Project Manager is required";
                 errorMessages = true;
             }*/
            if (cboJobStatus.Text != null && cboJobStatus.Text.Trim() == "WON")
            {
                /* if (cboSuperintendent.Text.Trim().Length == 0)
                 {
                     cboSuperintendent.ErrorText = "Superintendent is required";
                     errorMessages = true;
                 } */
                /* if (cboForeman.Text.Trim().Length == 0)
                 {
                     cboForeman.ErrorText = "Foreman is required";
                     errorMessages = true;
                 }
                 */

                if (chkWIPRequired.EditValue != null && chkWIPRequired.EditValue.ToString() == "False")
                { }
                else
                {
                    if (txtContractStartDate.Text.Trim().Length == 0)
                    {
                        txtContractStartDate.ErrorText = "Contract Start Date is required";
                        errorMessages = true;
                    }
                    if (txtContractEstComplDate.Text.Trim().Length == 0)
                    {
                        txtContractEstComplDate.ErrorText = "Contract Estimate Completion Date is required";
                        errorMessages = true;
                    }

                }


                if (txtCustomerID.Text.Trim().Length == 0)
                {
                    txtCustomerID.ErrorText = "Customer ID is required";
                    errorCustomer = true;
                }
                else
                {
                    txtCustomerID.ErrorText = "";
                }
            }
            if (errorMessages)
            {
                tabJobDetail.SelectedTabPage = pgBid;
            }
            else
            {
                if (errorCustomer)
                {
                    errorMessages = errorCustomer;
                    tabJobDetail.SelectedTabPage = pgCustomer;
                }
            }
        }
        //
        private void txtPreBidAmount_EditValueChanged(object sender, EventArgs e)
        {
            CheckBidAmount();
            AllControls_EditValue(sender, e);
        }
        private void CheckBidAmount()
        {
            Single preBidAmount = 0;
            Single finalBidAmount = 0;
            Single amount = 0;

            if (!String.IsNullOrEmpty(txtPreBidAmount.Text))
            {
                preBidAmount = Convert.ToSingle(txtPreBidAmount.EditValue);
            }

            if (!String.IsNullOrEmpty(txtFinalBidAmount.Text))
            {
                finalBidAmount = Convert.ToSingle(txtFinalBidAmount.EditValue);
            }

            if (finalBidAmount > 0)
            {
                amount = finalBidAmount;
            }
            else
            {
                amount = preBidAmount;
            }

            if (amount == 0)
            {
                lblOver1M.Enabled = false;
                chkOver1M.Enabled = false;
                if (chkOver1M.Checked)
                {
                    chkOver1M.Checked = false;
                }

                lblOver250K.Enabled = false;
                chkOver250K.Enabled = false;
                if (chkOver250K.Checked)
                {
                    chkOver250K.Checked = false;
                }
            }
            else
            {
                if (amount >= 1000000)
                {
                    lblOver1M.Enabled = true;
                    chkOver1M.Enabled = true;
                    if (!chkOver1M.Checked)
                    {
                        chkOver1M.Checked = true;
                    }

                    lblOver250K.Enabled = false;
                    chkOver250K.Enabled = false;
                    if (chkOver250K.Checked)
                    {
                        chkOver250K.Checked = false;
                    }
                }
                else if (amount >= 250000 && cboDepartment.Text == "TECHNOLOGY")
                {
                    lblOver1M.Enabled = false;
                    chkOver1M.Enabled = false;
                    if (chkOver1M.Checked)
                    {
                        chkOver1M.Checked = false;
                    }

                    lblOver250K.Enabled = true;
                    chkOver250K.Enabled = true;
                    if (!chkOver250K.Checked)
                    {
                        chkOver250K.Checked = true;
                    }
                }
                else
                {
                    lblOver1M.Enabled = false;
                    chkOver1M.Enabled = false;
                    if (chkOver1M.Checked)
                    {
                        chkOver1M.Checked = false;
                    }

                    lblOver250K.Enabled = false;
                    chkOver250K.Enabled = false;
                    if (chkOver250K.Checked)
                    {
                        chkOver250K.Checked = false;
                    }
                }
            }
        }
        //
        private void pagGeneral_MouseClick(object sender, MouseEventArgs e)
        {
            pagGeneral.Focus();
        }
        //
        private bool CheckSaveChanges()
        {
            bool status = true;

            status = CheckJobStatus(ClickedButton.Save);

            if (ctlCostCodeWeekly.IsUpdated)
            {
                ctlCostCodeWeekly.SaveChanges(true);
            }
            if (ctlJobProgress.IsUpdated)
            {
                ctlJobProgress.SaveChanges(true);
            }
            //if (ctlJobEmployee.IsUpdated)
            //    ctlJobEmployee.SaveJobEmployees();
            if (ctlJobCostCodes.IsUpdated)
            {
                ctlJobCostCodes.SaveJobCostCodes();
            }

            if (ctlJobCostCodes.IsUpdatedChangeOrder)
            {
                ctlJobCostCodes.SaveJobChangeOrdder();
            }

            if (ctlCostCodeWeekly.IsUpdated || ctlJobProgress.IsUpdated || ctlJobCostCodes.IsUpdated ||
                ctlJobCostCodes.IsUpdatedChangeOrder ||
                 dataChanged)
            {
                status = false;
            }
            /* if (ctlSubcontract.IsUpdated)
    ctlSubcontract.CheckSubcontractStatus(CCEJobs.Subcontracts.ctlSubcontract.ClickedButton.Save);
if (ctlSubcontract.IsUpdatedCostCodes)
    ctlSubcontract.SaveSubcontractCostCodes();
*/
            // if (ctlCostCodeWeekly.IsUpdated || ctlJobProgress.IsUpdated || ctlJobCostCodes.IsUpdated || ctlSubcontract.IsUpdated || ctlSubcontract.IsUpdatedCostCodes)
            //     status = false;

            return status;
        }
        //
        private void cboOwnerClass_Popup(object sender, EventArgs e)
        {
            if (cboOwnerClass.Tag == null)
            {
                cboOwnerClass.CancelPopup();
                cboOwnerClass.Properties.Columns[0].Visible = false;
                cboOwnerClass.Tag = "1";
                cboOwnerClass.ShowPopup();
            }
        }
        //
        private void cboRetainage_Popup(object sender, EventArgs e)
        {
            if (cboRetainage.Tag == null)
            {
                cboRetainage.CancelPopup();
                cboRetainage.Properties.Columns[0].Visible = false;
                cboRetainage.Tag = "1";
                cboRetainage.ShowPopup();
            }
        }
        //
        private void cboInsuranceProgram_Popup(object sender, EventArgs e)
        {
            if (cboInsuranceProgram.Tag == null)
            {
                cboInsuranceProgram.CancelPopup();
                cboInsuranceProgram.Properties.Columns[0].Visible = false;
                cboInsuranceProgram.Tag = "1";
                cboInsuranceProgram.ShowPopup();
            }
        }
        //
        private void cboLender_Popup(object sender, EventArgs e)
        {
            if (cboLender.Tag == null)
            {
                cboLender.CancelPopup();
                cboLender.Properties.Columns[0].Visible = false;
                cboLender.Tag = "1";
                cboLender.ShowPopup();
            }
        }
        //
        private void cboWIPEntry_Popup(object sender, EventArgs e)
        {
            if (cboWIPEntry.Tag == null)
            {
                cboWIPEntry.CancelPopup();
                cboWIPEntry.Properties.Columns[0].Visible = false;
                cboWIPEntry.Tag = "1";
                cboWIPEntry.ShowPopup();
            }
        }
        //
        private void cboBond_Popup(object sender, EventArgs e)
        {
            if (cboBond.Tag == null)
            {
                cboBond.CancelPopup();
                cboBond.Properties.Columns[0].Visible = false;
                cboBond.Tag = "1";
                cboBond.ShowPopup();
            }
        }
        //
        private void cboAccountValidationCode_Popup(object sender, EventArgs e)
        {
            if (cboValidationCode.Tag == null)
            {
                cboValidationCode.Visible = false;
                cboValidationCode.CancelPopup();
                cboValidationCode.Properties.Columns[0].Visible = false;
                cboValidationCode.Tag = "1";
                cboValidationCode.Visible = true;
                cboValidationCode.ShowPopup();
            }
        }
        //
        private void cboAccountValidationCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboValidationCode.EditValue == null)
            {
                txtJobGLAccount.Text = "";
                return;
            }
            try
            {
                txtJobGLAccount.Text = cboValidationCode.GetColumnValue("Account #").ToString();
            }
            catch (Exception)
            {
            }
        }
        //
        private void cboContractorName_EditValueChanged(object sender, EventArgs e)
        {
            if (cboContractorName.EditValue.ToString().Length > 0)
            {
                DataRow dr = Customer.GetCustomer(cboContractorName.EditValue.ToString()).Tables[0].Rows[0];
                txtContractorName.Text = cboContractorName.Text;
                txtContractorAddress1.Text = dr["Address1"].ToString();
                txtContractorAddress2.Text = dr["Address2"].ToString();
                txtContractorCity.Text = dr["City"].ToString();
                txtContractorState.Text = dr["State"].ToString();
                txtContractorZipCode.Text = dr["ZipCode"].ToString();
                txtContractorPhone.Text = dr["Telephone"].ToString();
                txtContractorRep.Text = dr["Contact"].ToString();
            }
        }
        //
        private void cboOwnerContractor_EditValueChanged(object sender, EventArgs e)
        {
            txtOwnerContractor.Text = cboOwnerContractor.Text;

            DataRow dr = Customer.GetCustomer(cboOwnerContractor.EditValue.ToString()).Tables[0].Rows[0];
            txtOwnerName.Text = cboOwnerContractor.Text;
            txtOwnerAddress1.Text = dr["Address1"].ToString();
            txtOwnerAddress2.Text = dr["Address2"].ToString();
            txtOwnerCity.Text = dr["City"].ToString();
            txtOwnerState.Text = dr["State"].ToString();
            txtOwnerZipCode.Text = dr["ZipCode"].ToString();
            txtOwnerPhone.Text = dr["Telephone"].ToString();
            txtOwnerRep.Text = dr["Contact"].ToString();
        }
        //
        private void cboOwnerName_EditValueChanged(object sender, EventArgs e)
        {
            if (cboOwnerName.EditValue.ToString().Length > 0)
            {

                DataRow dr = Customer.GetCustomer(cboOwnerName.EditValue.ToString()).Tables[0].Rows[0];
                txtOwnerName.Text = cboOwnerName.Text;
                txtOwnerAddress1.Text = dr["Address1"].ToString();
                txtOwnerAddress2.Text = dr["Address2"].ToString();
                txtOwnerCity.Text = dr["City"].ToString();
                txtOwnerState.Text = dr["State"].ToString();
                txtOwnerZipCode.Text = dr["ZipCode"].ToString();
                txtOwnerPhone.Text = dr["Telephone"].ToString();
                txtOwnerRep.Text = dr["Contact"].ToString();
            }
        }
        //
        private void chkJobCertifiedFlag_EditValueChanged(object sender, EventArgs e)
        {
            groupCertifiedPayrollInformation.Visible = chkJobCertifiedFlag.Checked;
            AllControls_EditValue(sender, e);
        }
        //
        private void frmJob_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSaveChanges())
            {
                e.Cancel = true;
                return;
            }
            if (!CheckJobStatus(ClickedButton.Close))
            {
                e.Cancel = true;
                return;
            }
            foreach (Control ctl in tabJob.Controls["pagGeneral"].Controls)
            {
                ctl.DataBindings.Clear();
            }

            Security.Security.SetCurrentJobReadOnly("");
        }
        //
        private void txtLastReportNumber_EditValueChanged(object sender, EventArgs e)
        {
            txtNextReportNumber.Text = Convert.ToString(Int16.Parse(txtLastReportNumber.Text) + 1);
            AllControls_EditValue(sender, e);
        }
        //
        private void SetFormAccess()
        {

            if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.RedWriteCreateSB)
            {
                pgPricing.PageVisible = false;
                pgContract.PageVisible = false;
                pgMisc.PageVisible = false;
                pgStarBuilder.PageVisible = false;
            }

            if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
              Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
            {
                btnJobProgressWIP.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnJobProgressWIPExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnJobProgressSummaryWIP.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                // btnContractStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                // btnJobProgressSummaryWIPReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (txtJobNumber.Text.Trim() == "")
                {
                    // New job 
                    // bid
                    if (jobID.Length > 0)
                    {
                        btnJobProgressSummaryWIPReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
                else
                {
                    btnJobProgressSummaryWIPReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
            }
            else
            {
                btnJobProgressWIP.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnJobProgressWIPExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnJobProgressSummaryWIP.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //btnContractStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnJobProgressSummaryWIPReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (Security.Security.UserJCCAccess != Security.Security.Access.ApplicationAdministrator &&
                Security.Security.UserJCCAccess != Security.Security.Access.JCCAdministrator)
            {
                chkArchive.Properties.ReadOnly = true;
                chkVoid.Properties.ReadOnly = true;
                chkDropOffComplianceReport.Properties.ReadOnly = true;
                chkDashboardExclude.Properties.ReadOnly = true;
                chkDropOffComplianceReport.Visible = false;
                lblDropOffComplianceReport.Visible = false;
                chkDashboardExclude.Visible = false;
                lblDashboardExclude.Visible = false;
            }
            else
            {
                chkArchive.Properties.ReadOnly = true;
                chkDropOffComplianceReport.Properties.ReadOnly = false;
                chkDropOffComplianceReport.Visible = true;
                lblDropOffComplianceReport.Visible = true;
                chkDashboardExclude.Properties.ReadOnly = false;
                chkDashboardExclude.Visible = true;
                lblDashboardExclude.Visible = true;

            }
            if (formCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
            {
                ribbonAction.Visible = false;
                ribbonUpdate.Visible = false;
                DisableControls();
                if (Security.Security.currentJobReadOnly)
                {
                    DisableControlsReadOnly();
                }
            }
            else
            {
                ribbonUpdate.Visible = true;
                ribbonAction.Visible = true;
                if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadWriteCreate && Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.RedWriteCreateSB))
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }


                if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.RedWriteCreateSB &&
                    starbuilderJobNumber != "0"))
                {
                    DisableControls();
                    lblWarning.Visible = true;
                }
                else
                {
                    lblWarning.Visible = false;
                    EnableControls();
                }
            }
        }

        private void DisableControlsReadOnly()
        {


        }


        private void DisableControls()
        {
            foreach (DevExpress.XtraTab.XtraTabPage page in tabJobDetail.TabPages)
            {
                foreach (Control ctl in page.Controls)
                {
                    if (ctl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.DateEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.LookUpEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.ComboBoxEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.CheckEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.RadioGroup" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.SimpleButton" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.GroupControl" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.PanelControl")
                    {
                        ctl.Enabled = false;
                        ctl.ForeColor = Color.Blue;
                    }
                }
            }
        }
        private void EnableControls()
        {
            foreach (DevExpress.XtraTab.XtraTabPage page in tabJobDetail.TabPages)
            {
                foreach (Control ctl in page.Controls)
                {
                    if (ctl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.DateEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.LookUpEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.ComboBoxEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.CheckEdit" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.RadioGroup" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.SimpleButton" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.GroupControl" ||
                        ctl.GetType().ToString() == "DevExpress.XtraEditors.PanelControl")
                    {
                        ctl.Enabled = true;
                        ctl.ForeColor = Color.Black;
                    }
                }
            }
        }
        //
        private void txtFinalBidAmount_EditValueChanged(object sender, EventArgs e)
        {
            CheckBidAmount();
            AllControls_EditValue(sender, e);
        }
        //
        private void cboDepartment_EditValueChanged(object sender, EventArgs e)
        {
            CheckBidAmount();
            AllControls_EditValue(sender, e);
        }
        //
        private void txtRevisionJobID_EditValueChanged(object sender, EventArgs e)
        {
            // GET The Job Number And Estimate Number for the Link
            if (!String.IsNullOrEmpty(txtRevisionJobID.Text))
            {
                DataSet ds;
                try
                {
                    ds = Job.GetRevision(txtRevisionJobID.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtRevisionEstimateNumber.Text = ds.Tables[0].Rows[0]["EstimateNumber"].ToString();
                        txtRevisionJobNumber.Text = ds.Tables[0].Rows[0]["JobNumber"].ToString();
                    }
                    else
                    {
                        txtRevisionEstimateNumber.Text = "";
                        txtRevisionJobNumber.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
                AllControls_EditValue(sender, e);
            }

        }
        //
        private void txtOwnerContractor_EditValueChanged(object sender, EventArgs e)
        {

            txtOwnerName.Text = txtOwnerContractor.Text;

            txtOwnerAddress1.Text = "";
            txtOwnerAddress2.Text = "";
            txtOwnerCity.Text = "";
            txtOwnerState.Text = "";
            txtOwnerZipCode.Text = "";
            txtOwnerPhone.Text = "";
            txtOwnerRep.Text = "";

            AllControls_EditValue(sender, e);
        }
        //
        private void cboContractType_EditValueChanged(object sender, EventArgs e)
        {
            lblSelect.Text = "  Contract Type: " + cboContractType.Text;
            if (!String.IsNullOrEmpty(cboContractType.Text))
            {
                switch (cboContractType.Text)
                {
                    case "TIME & MATERIAL":
                    case "GUARANTEED MAXIMUM":
                    case "COST PLUS":
                    case "UNIT PRICE":
                        lblTrackChangeOrder.Visible = true;
                        chkTrackChangeOrder.Visible = true;
                        break;
                    default:
                        lblTrackChangeOrder.Visible = false;
                        chkTrackChangeOrder.Visible = false;
                        break;
                }
            }
            else
            {
                lblTrackChangeOrder.Visible = false;
                chkTrackChangeOrder.Visible = false;
            }
            chkTrackChangeOrder.CheckState = CheckState.Unchecked;
            AllControls_EditValue(sender, e);
        }
        //
        private void cboCustomerName_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                cboCustomerName.EditValue = null;
                e.Handled = true;
            }
        }
        //
        private void txtContractorName_EditValueChanged(object sender, EventArgs e)
        {
            txtContractorOwner.Text = txtContractorName.Text;
            AllControls_EditValue(sender, e);
        }
        //
        private void chkBillingAsCustomer_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkBillingAsCustomer.CheckState == CheckState.Checked)
            {
                txtBillingAddress1.Text = txtCustomerAddress1.Text;
                txtBillingAddress2.Text = txtCustomerAddress2.Text;
                txtBillingCity.Text = txtCustomerCity.Text;
                txtBillingState.Text = txtCustomerState.Text;
                txtBillingZipCode.Text = txtCustomerZipCode.Text;
                txtBillingRep.Text = txtCustomerRep.Text;
                txtBillingPhone.Text = txtCustomerPhone.Text;
            }

            AllControls_EditValue(sender, e);
        }
        //
        private void txtOwnerName_EditValueChanged(object sender, EventArgs e)
        {
            txtOwnerContractor.Text = txtOwnerName.Text;
            AllControls_EditValue(sender, e);
        }
        //
        private void cboContractorOwner_EditValueChanged(object sender, EventArgs e)
        {
            txtContractorOwner.Text = cboContractorOwner.Text;

            DataRow dr = Customer.GetCustomer(cboContractorOwner.EditValue.ToString()).Tables[0].Rows[0];
            txtContractorName.Text = cboContractorOwner.Text;
            txtContractorAddress1.Text = dr["Address1"].ToString();
            txtContractorAddress2.Text = dr["Address2"].ToString();
            txtContractorCity.Text = dr["City"].ToString();
            txtContractorState.Text = dr["State"].ToString();
            txtContractorZipCode.Text = dr["ZipCode"].ToString();
            txtContractorPhone.Text = dr["Telephone"].ToString();
            txtContractorRep.Text = dr["Contact"].ToString();
        }
        //
        private void txtContractorOwner_EditValueChanged(object sender, EventArgs e)
        {
            txtContractorName.Text = txtContractorOwner.Text;
            txtContractorAddress1.Text = "";
            txtContractorAddress2.Text = "";
            txtContractorCity.Text = "";
            txtContractorState.Text = "";
            txtContractorZipCode.Text = "";
            txtContractorPhone.Text = "";
            txtContractorRep.Text = "";

            AllControls_EditValue(sender, e);
        }
        //
        private void cboSelect_EditValueChanged(object sender, EventArgs e)
        {
            string recordKey = cboSelect.EditValue == null ? String.Empty : cboSelect.EditValue.ToString();
            //
            // 
            //
            if (recordKey.Trim().Length != 0)
            {

                DataRow dr;
                if (radioSelect.SelectedIndex == 1)
                {
                    dr = Job.GetJobTemplate(recordKey).Tables[0].Rows[0];
                }
                else
                {
                    dr = Job.GetEstimateTemplate(recordKey).Tables[0].Rows[0];
                }

                txtJobName.Text = dr["jobName"].ToString();
                txtJobDescription.Text = dr["JobDescription"].ToString();
                txtJobPhone.Text = dr["jobPhone"].ToString();
                txtJobAddress.Text = dr["jobAddress1"].ToString();
                txtJobCity.Text = dr["jobCity"].ToString();
                txtJobAddress2.Text = dr["jobAddress2"].ToString();
                txtJobState.Text = dr["JobState"].ToString();
                txtJobZip.Text = dr["JobZip"].ToString();
                txtJobPhone.Text = dr["JobPhone"].ToString();
                txtOwnerContractor.Text = dr["OwnerName"].ToString();
                txtContractorOwner.Text = dr["ContractorName"].ToString();

                cboCustomerName.EditValue = dr["CustomerID"].ToString();
                txtCustomerID.Text = dr["CustomerID"].ToString();
                chkBillingAsCustomer.Checked = dr["BillingAsCustomer"].ToString() == "True" ? true : false;
                txtBillingAddress1.Text = dr["BillingAddress1"].ToString();
                txtBillingAddress2.Text = dr["BillingAddress2"].ToString();
                txtBillingCity.Text = dr["BillingCity"].ToString();
                txtBillingState.Text = dr["BillingState"].ToString();
                txtBillingZipCode.Text = dr["BillingZipCode"].ToString();
                txtBillingPhone.Text = dr["BillingPhone"].ToString();
                txtBillingRep.Text = dr["BillingRep"].ToString();
                cboOwnerClass.EditValue = dr["OwnerClassID"];
                chkContractorAsCustomer.Checked = dr["ContractorAsCustomer"].ToString() == "True" ? true : false;
                txtContractorName.Text = dr["ContractorName"].ToString();
                txtContractorAddress1.Text = dr["ContractorAddress1"].ToString();
                txtContractorAddress2.Text = dr["ContractorAddress2"].ToString();
                txtContractorCity.Text = dr["ContractorCity"].ToString();
                txtContractorState.Text = dr["ContractorState"].ToString();
                txtContractorZipCode.Text = dr["ContractorZipCode"].ToString();
                txtContractorPhone.Text = dr["ContractorPhone"].ToString();
                txtContractorRep.Text = dr["ContractorRep"].ToString();
                chkOwnerAsCustomer.Checked = dr["OwnerAsCustomer"].ToString() == "True" ? true : false;
                txtOwnerName.Text = dr["OwnerName"].ToString();
                txtOwnerAddress1.Text = dr["OwnerAddress1"].ToString();
                txtOwnerAddress2.Text = dr["OwnerAddress2"].ToString();
                txtOwnerCity.Text = dr["OwnerCity"].ToString();
                txtOwnerState.Text = dr["OwnerState"].ToString();
                txtOwnerZipCode.Text = dr["OwnerZipCode"].ToString();
                txtOwnerPhone.Text = dr["OwnerPhone"].ToString();
                txtOwnerRep.Text = dr["OwnerRep"].ToString();

                cboOffice.EditValue = dr["OfficeID"];
                cboDepartment.EditValue = dr["DepartmentID"];
                cboWorkType.EditValue = dr["WorkTypeID"];
                cboContractType.EditValue = dr["ContractTypeID"];
                cboProjectManager.EditValue = dr["ProjectManagerID"];
                cboEstimator.EditValue = dr["EstimatorID"];
                cboSuperintendent.EditValue = dr["SuperIntendentID"];
                cboForeman.EditValue = dr["ForemanID"];

                txtArchitectEngineer.Text = dr["architectEngineer"].ToString();
                txtAddendumReceived.Text = dr["addendumReceived"].ToString();
                txtJobEmail.Text = dr["jobEmail"].ToString();
                txtJobFax.Text = dr["jobFax"].ToString();
                cboBidTo.Text = dr["bidTo"].ToString();

            }
        }
        //
        private void cboBidTo_EditValueChanged(object sender, EventArgs e)
        {
            UpdateErrorMessages();
            AllControls_EditValue(sender, e);
        }
        //
        private void radioSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboSelect_EditValueChanged
            cboSelect.EditValueChanged -= cboSelect_EditValueChanged;
            if (radioSelect.SelectedIndex == 1)
            {
                cboSelect.Properties.DataSource = StaticTables.JobsList;
                cboSelect.Properties.DisplayMember = "Job Name";
                cboSelect.Properties.ValueMember = "Job Number";
            }
            else
            {
                cboSelect.Properties.DataSource = StaticTables.EstimateList;
                cboSelect.Properties.DisplayMember = "Job Name";
                cboSelect.Properties.ValueMember = "Estimate Number";
            }
            cboSelect.EditValueChanged += new EventHandler(cboSelect_EditValueChanged);
            cboSelect.EditValue = null;
            cboSelect.Properties.PopulateColumns();
        }

        private void ctlJobCostCodes_Starbuilder(object sender, StarbuilderEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            try
            {
                if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator ||
                    Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator)
                {
                    Job.UpdateJobStatistics(txtJobNumber.Text, ctlJobProgress.Period);
                }
                else
                {
                    Job.UpdateJobStatistics(txtJobNumber.Text, "");
                }
                // Check if Job is closed then move Job folders from Active to Archive folder
                bool isArchived = Job.CheckStatusOfJob(txtJobNumber.Text);
                if (isArchived)
                {
                    ArchiveJobFolderOnJobClose(txtJobNumber.Text);
                }
                UpdateTabs();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show("There is an error recalculating this job. Please try again.", CCEApplication.ApplicationName);
            }
        }

        private void ArchiveJobFolderOnJobClose(string jobNumber)
        {
            try
            {
                DataSet dsFolderInfo = Job.GetJobFolderInfo(jobNumber);
                Job.CopyJobToArchiveFolder(dsFolderInfo);
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show("There is some problem while moving closed job folder to archive", CCEApplication.ApplicationName);
            }
        }
        //
        private void grdKeywordsView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (grdKeywordsView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdKeywordsView.GetDataRow(grdKeywordsView.GetSelectedRows()[0]);
                if (r == null)
                {
                    return;
                }

                Cursor = Cursors.AppStarting;
                {
                    try
                    {
                        string selected = r["Selected"].ToString();
                        string jobPrequalKeywordID = r["JobPrequalKeywordID"].ToString().Trim();
                        string prequalKeywordID = r["PrequalKeywordID"].ToString().Trim();

                        if (selected == "False" && jobPrequalKeywordID.Length > 0)
                        {
                            JobPrequal.Remove(jobPrequalKeywordID);
                        }
                        else
                        {
                            if (selected == "True")
                            {
                                JobPrequal jobPrequal = new JobPrequal(jobPrequalKeywordID, jobID, prequalKeywordID);
                                jobPrequal.Save();
                                r["JobPrequalKeywordID"] = jobPrequal.JobPrequalKeywordID;
                            }
                        }
                        Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                }
            }
        }

        private void txtScopeOfWork_EditValueChanged(object sender, EventArgs e)
        {
            if (formCaller == Security.Security.JobCaller.JCCDashboard)
            {
                return;
            }

            btnScopeOfWork.Visible = true;
            panScopeOfWork.Visible = true;
        }

        private void btnScopeOfWork_Click(object sender, EventArgs e)
        {
            JobPrequal.UpdatePrequalComment(jobID, txtScopeOfWork.Text);
            UpdateScopeOfWorkScreen();
        }

        private void Contact_Click(object sender, EventArgs e)
        {
            ctlJobContact.JobCaller = formCaller;
            ctlJobContact.JobID = jobID;
        }

        private void txtJobName_EditValueChanged(object sender, EventArgs e)
        {

            AllControls_EditValue(sender, e);
        }

        private void chkWIPRequired_EditValueChanged(object sender, EventArgs e)
        {
            UpdateWIPRequiredStatus();
            AllControls_EditValue(sender, e);
        }
        //
        private void UpdateWIPRequiredStatus()
        {
            if (chkWIPRequired.EditValue != null && chkWIPRequired.EditValue.ToString() == "False" && cboJobStatus.Text.Trim() == "WON")
            {
                if (txtJobNumber.Text.Trim().Length == 0)
                {
                    txtJobNumber.Properties.ReadOnly = false;
                }
                else
                {
                    txtJobNumber.Properties.ReadOnly = true;
                }
            }
            else
            {
                txtJobNumber.Properties.ReadOnly = true;
            }

            //UpdateErrorMessages();
        }
    }
}
