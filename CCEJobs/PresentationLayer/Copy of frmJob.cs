using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCEJobs.PresentationLayer
{
    public partial class frmJob : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string jobID;
        protected BindingSource bindingSource;
        protected System.Collections.Hashtable recordHashTable = new System.Collections.Hashtable();
        protected bool dataChanged;
        private string jobStatus;
        private bool errorMessages = false;
        private bool ribbonVisible = true;
        enum ClickedButton
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
        public frmJob()
        {
            InitializeComponent();
        }

        public frmJob(string jobID, BindingSource bindingSource)
        {
            this.jobID = jobID;
            this.bindingSource = bindingSource;
            InitializeComponent();
        }

        private void frmJob_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (jobID.Length > 0 && jobID != "0")
            {
                txtRecordNo.DataBindings.Add("text", bindingSource, "RecordNo");
                ShowRibbon();
            }
            else
            {
                HideRibbon();
            }
            // Build Error Validation
            //
            UpdateErrorMessages();
            //
            // Update Lookups
            //
            cboCustomerName.Properties.DataSource = StaticTables.Customers;        
            cboCustomerName.Properties.DisplayMember = "Name";
            cboCustomerName.Properties.ValueMember = "CustomerID";
            cboCustomerName.Properties.PopulateColumns();
            cboCustomerName.Properties.ShowHeader = false;
            
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

            cboForeman.Properties.DataSource = StaticTables.Superintendent;
            cboForeman.Properties.DisplayMember = "Description";
            cboForeman.Properties.ValueMember = "SuperintendentID";
            cboForeman.Properties.PopulateColumns();
            cboForeman.Properties.ShowHeader = false;
            cboForeman.Properties.Columns[0].Visible = false;

            cboOwnerClass.Properties.DataSource = StaticTables.OwnerClass;
            cboOwnerClass.Properties.DisplayMember = "Description";
            cboOwnerClass.Properties.ValueMember = "OwnerClassID";
            cboOwnerClass.Properties.PopulateColumns();
            cboOwnerClass.Properties.ShowHeader = false;
            cboOwnerClass.Properties.Columns[0].Visible = false;

            cboRetainage.Properties.DataSource = StaticTables.Retainage;
            cboRetainage.Properties.DisplayMember = "Description";
            cboRetainage.Properties.ValueMember = "RetainageID";
            cboRetainage.Properties.PopulateColumns();
            cboRetainage.Properties.ShowHeader = false;
            cboRetainage.Properties.Columns[0].Visible = false;

            cboInsuranceProgram.Properties.DataSource = StaticTables.InsuranceProgram;
            cboInsuranceProgram.Properties.DisplayMember = "Description";
            cboInsuranceProgram.Properties.ValueMember = "InsuranceProgramID";
            cboInsuranceProgram.Properties.PopulateColumns();
            cboInsuranceProgram.Properties.ShowHeader = false;
            cboInsuranceProgram.Properties.Columns[0].Visible = false;

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

            cboLender.Properties.DataSource = StaticTables.Lender;
            cboLender.Properties.DisplayMember = "Description";
            cboLender.Properties.ValueMember = "LenderID";
            cboLender.Properties.PopulateColumns();
            cboLender.Properties.ShowHeader = false;
            cboLender.Properties.Columns[0].Visible = false;

            cboWIPEntry.Properties.DataSource = StaticTables.WIPEntry;
            cboWIPEntry.Properties.DisplayMember = "Description";
            cboWIPEntry.Properties.ValueMember = "WIPEntryID";
            cboWIPEntry.Properties.PopulateColumns();
            cboWIPEntry.Properties.ShowHeader = false;
            cboWIPEntry.Properties.Columns[0].Visible = false;

            cboBond.Properties.DataSource = StaticTables.Bond;
            cboBond.Properties.DisplayMember = "Description";
            cboBond.Properties.ValueMember = "BondID";
            cboBond.Properties.PopulateColumns();
            cboBond.Properties.ShowHeader = false;
            cboBond.Properties.Columns[0].Visible = false;

            cboBidBond.Properties.DataSource = StaticTables.BidBond;
            cboBidBond.Properties.DisplayMember = "Description";
            cboBidBond.Properties.ValueMember = "BidBondID";
            cboBidBond.Properties.PopulateColumns();
            cboBidBond.Properties.ShowHeader = false;
            cboBidBond.Properties.Columns[0].Visible = false;

            GetJob();
            if (cboJobStatus.Text.Trim() == "WON")
                ShowRibbon();
            this.Text = txtJobName.Text;
            tabJob.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnGeneral.Down = true;
            tabJob.SelectedTabPage = pagGeneral;

            this.Opacity = 1;
            this.Cursor = Cursors.Default;
           
        }
        private void HideRibbon()
        {
            ribbonCostCode.Visible = false;
            ribbonExcel.Visible = false;
            ribbonReport.Visible = false;
            ribbonVisible = false;
            tabJob.SelectedTabPage = pagGeneral;
        }
        private void ShowRibbon()
        {
            ribbonReport.Visible = true;

            if (cboJobStatus.Text.Trim() == "WON")
            {
                ribbonCostCode.Visible = true;
                ribbonExcel.Visible = true;
                btnPersonnel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLaborFeedbackReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                
            }
            else
            {
                ribbonCostCode.Visible = false;
                ribbonExcel.Visible = false;
                btnPersonnel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLaborFeedbackReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                tabJob.SelectedTabPage = pagGeneral;
            }
            ribbonVisible = true;
        }
        private void GetCostCode()
        {
            ctlJobCostCodes.JobID = jobID;
            ctlCostCodeWeekly.JobID = jobID;
            this.ctlLaborFeedBack.JobID = jobID;
            this.ctlJobProgress.JobID = jobID;
           // this.ctlCostCodeTimeCard.JobID = jobID;
            
            cboDeliveryMethod.ErrorText = "";
        }


        private void GetJobDetail()
        {
  
            if (txtRecordNo.Text.Trim().Length > 0)
            {
                UpdateJob(txtRecordNo.Text, "All");
            }
            else
            {
                txtEstimateNumber.Text = null;
                txtJobNumber.Text = null;
                cboOffice.EditValue = null;
                cboDepartment.EditValue = null;
                txtJobName.Text = null;
                txtJobDescription.Text = null;
                txtJobPhone.Text = null;
                txtJobAddress.Text = null;
                txtJobAddress2.Text = null;
                txtJobCity.Text = null;
                txtJobState.Text = null;
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
                txtContractorAddress1.Text = null;
                txtContractorCity.Text = null;
                txtContractorState.Text = null;
                txtContractorZipCode.Text = null;
                txtContractorPhone.Text = null;
                txtContractorRep.Text = null;
                chkOwnerAsCustomer.Checked = false;
                txtOwnerName.Text = null;
                txtOwnerAddress1.Text = null;
                txtOwnerCity.Text = null;
                txtOwnerState.Text = null;
                txtOwnerZipCode.Text = null;
                txtOwnerPhone.Text = null;
                txtOwnerRep.Text = null;
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
                cboJobStatus.EditValue = null;
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
                chkDesignBuild.Checked = false;
                chkDrawingReceived.Checked =  false;
                chkQuotesRequired.Checked = false;
                chkBidForm.Checked =  false;
                txtBidWalkDate.Text = null;
                txtBidWalkTime.Text = null;
                cboDeliveryMethod.Text = null;
                txtArchitectEngineer.Text = null;
                txtAddendumReceived.Text = null;
                txtJobEmail.Text = null;
                txtJobFax.Text = null;
                //
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
                //
                chkEstimateHandoff.Checked = false;
                cboEstimateHandoffGrade.EditValue = null;
                chkPMHandoff.Checked = false;
                cboPMHandoffGrade.EditValue = null;
                chkProjectStartupMeeting.Checked = false;

            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();

        }

        private void UpdateTabStatus(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCostCodes.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnCostCodesWeekly.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnLaborFeedback.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnJobProgress.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnTimeCard.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            switch (e.Item.Caption)
            {
                case "General":
                    btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnGeneral.Down = true;
                    tabJob.SelectedTabPage = pagGeneral;
                    break;

                case "Cost Codes":
                    btnCostCodes.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnCostCodes.Down = true;
                    tabJob.SelectedTabPage = pagCostCodes;
                    break;
                case "Cost Codes Weekly":
                    btnCostCodesWeekly.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnCostCodesWeekly.Down = true;
                    tabJob.SelectedTabPage = pagCostCodesWeekly;
                    break;
                case "Time Card":
                    btnTimeCard.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnTimeCard.Down = true;
                    tabJob.SelectedTabPage = pagCostCodeTimeSheet;
                    break;
                case "Labor Feedback":
                    btnLaborFeedback.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnLaborFeedback.Down = true;
                    tabJob.SelectedTabPage = pagLaborFeedback;
                    break;

                case "Job Progress":
                    btnJobProgress.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnJobProgress.Down = true;
                    tabJob.SelectedTabPage = pagJobProgress;
                    break;


            }
        }

        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "Next Job":
                    if (CheckJobStatus(ClickedButton.Next))
                    {
                        bindingSource.MoveNext();
                        GetJob();
                        ShowRibbon();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "Previous Job":
                    if (CheckJobStatus(ClickedButton.Previous))
                    {
                        bindingSource.MovePrevious();
                        GetJob();
                        ShowRibbon();
                        dataChanged = false;
                        btnUndo.Enabled = false;
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
                            btnUndo.Enabled = false;
                        }
                    }
                    break;
                case "&New":
                    if (CheckJobStatus(ClickedButton.New))
                    {
                        bindingSource.AddNew();
                        GetJob();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnSave.Enabled = false;
                        HideRibbon();
                    }
                    break;
                case "&Save":
                    if (CheckJobStatus(ClickedButton.Save) == true)
                        ShowRibbon();
                    break;
                case "&Undo":
                    bindingSource.CancelEdit();
                    GetJob();
                    ShowRibbon();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    break;
                case "&Job Sheet":
                    Reports.Reports.JobSheet(txtRecordNo.Text);
                    break;
                case "&Time Sheet":
                    try
                    {
                        if (ctlCostCodeTimeCard.SelectedDate == "")
                        {
                            MessageBox.Show("Please select a Date", CCEApplication.ApplicationName);
                        }
                        else
                        {
                            Reports.Reports.JobWeeklyTimeSheet(txtJobNumber.Text,
                                ctlCostCodeTimeCard.SelectedDate,
                                txtJobName.Text,
                                ctlCostCodeTimeCard.SelectedData);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
                case "&Labor Feedback":
                    try
                    {
                       Reports.Reports.LaborFeedback( ctlLaborFeedBack.LaborFeedbackChart,
                           ctlLaborFeedBack.LaborFeedbackGrid, 
                           txtJobName.Text, 
                            ctlLaborFeedBack.SelectedWeek);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please select a week befor printing the report", CCEApplication.ApplicationName);
                    }
                     break; 
                case "&Hours":
                    try
                    {
                        ExcelReport excelJobs = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text);
                        excelJobs.JobHoursReport();
                        excelJobs = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
                case "&Quantity":
                    try
                    {
                        ExcelReport excelQuantity = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text);
                        excelQuantity.JobQuantityReport();
                        excelQuantity = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
                case "&Labor Prod":
                    if (ctlLaborFeedBack.SelectedWeek == "")
                    {
                        MessageBox.Show("Please select Laber Feedback Date", CCEApplication.ApplicationName);
                    }
                    else
                    {
                        try
                        {
                            ExcelReport excelLaborProd = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text);
                            excelLaborProd.LaborProdReport(ctlLaborFeedBack.SelectedWeek);
                            excelLaborProd = null;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                    break;
                case "&Cost To Complete":
                    try
                    {
                        ExcelReport excelCostToComplete = new ExcelReport(jobID, txtJobNumber.Text, txtJobName.Text, txtContractorName.Text);
                        excelCostToComplete.CostToCompletion();
                        excelCostToComplete = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;

            }
        }

        private bool CheckJobStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveJob();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Please make sure to enter all required fields.", CCEApplication.ApplicationName);
                        return false;
                    }
                }
                else
                {
                    bindingSource.CancelEdit();
                    if (SelectedButton == ClickedButton.Save)
                        return false;
                    else
                    {
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        dxErrorProvider.ClearErrors();
                        return true;
                    }
                }
            }
            else
            {
                bindingSource.CancelEdit();
                dataChanged = false;
                btnUndo.Enabled = false;
                dxErrorProvider.ClearErrors();
                return true;
            }
        }

        private void SaveJob()
        {
            // Save Job

            jobID = txtRecordNo.Text.Trim();

            try
            {

                CCEJobs.BusinessLayer.Job myJob = new CCEJobs.BusinessLayer.Job(jobID,
                            cboOffice.EditValue == null ? String.Empty : cboOffice.EditValue.ToString(),
                            cboDepartment.EditValue == null ? String.Empty : cboDepartment.EditValue.ToString(),
                            txtEstimateNumber.Text,
                            txtJobNumber.Text,
                            txtJobName.Text,
                            txtJobDescription.Text,
                            txtJobAddress.Text,
                            "",
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
                            txtContractorCity.Text,
                            txtContractorState.Text,
                            txtContractorZipCode.Text,
                            txtContractorPhone.Text,
                            txtContractorRep.Text,
                            chkOwnerAsCustomer.Checked.ToString(),
                            txtOwnerName.Text,
                            txtOwnerAddress1.Text,
                            txtOwnerCity.Text,
                            txtOwnerState.Text,
                            txtOwnerZipCode.Text,
                            txtOwnerPhone.Text,
                            txtOwnerRep.Text,
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
                            cboProjectManager.EditValue == null ? String.Empty :  cboProjectManager.EditValue.ToString(),
                            cboEstimator.EditValue == null ? String.Empty : cboEstimator.EditValue.ToString(),
                            cboSuperintendent.EditValue == null ? String.Empty : cboSuperintendent.EditValue.ToString(),
                            cboForeman.EditValue == null ? String.Empty : cboForeman.EditValue.ToString(),
                            txtContractNumber.Text,
                            txtOriginalContractAmount.Text,
                            txtJobFinalContractAmount.Text,
                            chkCopyOfVendorInvoicesNeeded.Checked.ToString(),
                            chkSubcontractors.Checked.ToString(),
                            chkCertifiedPayroll.Checked.ToString(),
                            cboBond.EditValue == null ? String.Empty : cboBond.EditValue.ToString(),
                            txtBondDate.Text,
                            txtBondNumber.Text,
                            txtPONumber.Text,
                            txtContractStartDate.Text == null ? String.Empty : txtContractStartDate.Text,
                            txtContractEstComplDate.Text,
                            txtJurisdiction.Text,
                            txtMasterJobNumber.Text,
                            cboRetainage.EditValue == null ? String.Empty : cboRetainage.EditValue.ToString(),
                            cboInsuranceProgram.EditValue == null ? String.Empty : cboInsuranceProgram.EditValue.ToString(),
                            txtTotalCLPUAmount.Text,
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
                            txtPreBidAmount.Text,
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
                            chkProjectStartupMeeting.Checked.ToString());

                myJob.Save();
             
                jobID = myJob.JobID;
                txtRecordNo.Text = jobID;
                txtEstimateNumber.Text = myJob.EstimateNumber;
                txtJobNumber.Text = myJob.JobNumber;
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            GetCostCode();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            
        }

        private void GetJob()
        {
            jobID = txtRecordNo.Text;
            if (jobID == "")
                jobID = "0";
            ctlJobCostCodes.JobID = jobID;
            ctlCostCodeWeekly.JobID = jobID;
            ctlJobProgress.JobID = jobID;
            ctlCostCodeTimeCard.JobID = jobID;
            GetJobDetail();
            GetCostCode();
            this.Text = txtJobName.Text;
        }

  
 
        private void ControlValidating(object sender, CancelEventArgs e)
        {
            UpdateErrorMessages();
        }


        private bool ValidateAllControls()
        {
            UpdateErrorMessages();
            return !errorMessages;
        }

        private void AllControls_EditValue(Object sender, EventArgs e)
        {
            if (!dataChanged)
            {
                if (!chkVoid.Checked && !chkArchive.Checked)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void frmJob_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckJobStatus(ClickedButton.Close);
            foreach (Control ctl in this.tabJob.Controls["pagGeneral"].Controls)
                ctl.DataBindings.Clear();
        }

 
        private void cboCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            if (cboCustomerName.EditValue.ToString().Length > 0)
            {
                txtCustomerID.Text = cboCustomerName.EditValue.ToString();
                chkBillingAsCustomer.Checked = false;
                chkContractorAsCustomer.Checked = false;
                chkOwnerAsCustomer.Checked = false;
            }
            else
            {
                txtCustomerID.Text = String.Empty;
            }
        }

        private void chkContractorAsCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContractorAsCustomer.Checked)
            {
                txtContractorName.Text = cboCustomerName.Text;
                txtContractorAddress1.Text = txtBillingAddress1.Text;
                txtContractorCity.Text = txtBillingCity.Text;
                txtContractorState.Text = txtBillingState.Text;
                txtContractorZipCode.Text = txtBillingZipCode.Text;
                txtContractorPhone.Text = txtBillingPhone.Text;
                txtContractorRep.Text = txtBillingRep.Text;
            }
        }

        private void chkOwnerAsCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOwnerAsCustomer.Checked)
            {
                txtOwnerName.Text = cboCustomerName.Text;
                txtOwnerAddress1.Text = txtBillingAddress1.Text;
                txtOwnerCity.Text = txtBillingCity.Text;
                txtOwnerState.Text = txtBillingState.Text;
                txtOwnerZipCode.Text = txtBillingZipCode.Text;
                txtOwnerPhone.Text = txtBillingPhone.Text;
                txtOwnerRep.Text = txtBillingRep.Text;
            }
        }

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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string[] retValue = new string[2];
            frmSelect f = new frmSelect(jobStatus);
            retValue = f.SelectList();
            if (!String.IsNullOrEmpty(retValue[0].ToString()))
            {
                txtRevisionJobID.Text = retValue[0].ToString();
                if (jobStatus == "OPEN" || jobStatus == "BUDGET")
                    UpdateJob(retValue[0], "Estimate");
                else
                    UpdateJob(retValue[0], "Job");

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

        private void cboJobStatus_EditValueChanged(object sender, EventArgs e)
        {

            jobStatus = cboJobStatus.Text.Trim();
            if (jobStatus == "WON" || jobStatus == "LOST")
            {
                if (txtWONLOSTDate.Text == "")
                    txtWONLOSTDate.Text = DateTime.Now.Date.ToShortDateString();
                txtWONLOSTDate.Visible = true;
                lblWONLOSTDate.Visible = true;
            }
            else
            {
                txtWONLOSTDate.Text = "";
                txtWONLOSTDate.Visible = false;
                lblWONLOSTDate.Visible = false;
            }
            
            if ((jobStatus == "OPEN" || jobStatus == "BUDGET") && String.IsNullOrEmpty(txtEstimateNumber.Text) && String.IsNullOrEmpty(txtEstimateNumber.Text))
                btnSelect.Visible = true;
            else
                if ((jobStatus == "WON" || jobStatus == "NO BID") && String.IsNullOrEmpty(txtJobNumber.Text) && !String.IsNullOrEmpty(txtEstimateNumber.Text))
                    btnSelect.Visible = true;
                else
                    btnSelect.Visible = false;
                UpdateErrorMessages();
            AllControls_EditValue(sender , e);
        }


        private void UpdateJob(string jobID, string updateSection)
        {
            //DateTimeFormatInfo dfi = new DateTimeFormatInfo();
            

            DataRow dr;
           dr = Job.GetJob(jobID).Tables[0].Rows[0];
           switch(updateSection)
           {
               case "Estimate":
                   txtJobName.Text = dr["jobName"].ToString();
                   txtJobDescription.Text = dr["JobDescription"].ToString();
                   txtJobPhone.Text = dr["jobPhone"].ToString();
                   txtJobAddress.Text = dr["jobAddress1"].ToString();
                   txtJobAddress2.Text = dr["jobAddress2"].ToString();
                   txtJobCity.Text = dr["jobCity"].ToString();
                   txtJobState.Text = dr["JobState"].ToString();
                   txtJobZip.Text = dr["JobZip"].ToString();
                   txtJobPhone.Text = dr["JobPhone"].ToString();
                   txtRevisionEstimateNumber.Text = dr["EstimateNumber"].ToString();
                   txtRevisionJobNumber.Text = dr["JobNumber"].ToString();
                   txtRevisionDescription.Text = dr["RevisionID"].ToString() + " - " + dr["RevisionDescription"].ToString();                 
                   break;
               case "Job":
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
                   txtContractorAddress1.Text = dr["ContractorAddress"].ToString();
                   txtContractorCity.Text = dr["ContractorCity"].ToString();
                   txtContractorState.Text = dr["ContractorState"].ToString();
                   txtContractorZipCode.Text = dr["ContractorZipCode"].ToString();
                   txtContractorPhone.Text = dr["ContractorPhone"].ToString();
                   txtContractorRep.Text = dr["ContractorRep"].ToString();
                   chkOwnerAsCustomer.Checked = dr["OwnerAsCustomer"].ToString() == "True" ? true : false;
                   txtOwnerName.Text = dr["OwnerName"].ToString();
                   txtOwnerAddress1.Text = dr["OwnerAddress"].ToString();
                   txtOwnerCity.Text = dr["OwnerCity"].ToString();
                   txtOwnerState.Text = dr["OwnerState"].ToString();
                   txtOwnerZipCode.Text = dr["OwnerZipCode"].ToString();
                   txtOwnerPhone.Text = dr["OwnerPhone"].ToString();
                   txtOwnerRep.Text = dr["OwnerRep"].ToString();
                   txtRevisionEstimateNumber.Text = dr["EstimateNumber"].ToString();
                   txtRevisionJobNumber.Text = dr["JobNumber"].ToString();
                   txtRevisionDescription.Text = dr["RevisionID"].ToString() + " - " + dr["RevisionDescription"].ToString();
                   break;
               case "All":
                   txtEstimateNumber.Text = dr["EstimateNumber"].ToString();
                   txtJobNumber.Text = dr["JobNumber"].ToString();
                   cboOffice.EditValue = dr["OfficeID"];
                   cboDepartment.EditValue = dr["DepartmentID"];
                   txtJobName.Text = dr["jobName"].ToString();
                   txtJobDescription.Text = dr["JobDescription"].ToString();
                   txtJobPhone.Text = dr["jobPhone"].ToString();
                   txtJobAddress.Text = dr["jobAddress1"].ToString();
                   txtJobAddress2.Text = dr["jobAddress2"].ToString();
                   txtJobCity.Text = dr["jobCity"].ToString();
                   txtJobState.Text = dr["JobState"].ToString();
                   txtJobZip.Text = dr["JobZip"].ToString();
                   txtJobPhone.Text = dr["JobPhone"].ToString();
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
                   txtContractorAddress1.Text = dr["ContractorAddress"].ToString();
                   txtContractorCity.Text = dr["ContractorCity"].ToString();
                   txtContractorState.Text = dr["ContractorState"].ToString();
                   txtContractorZipCode.Text = dr["ContractorZipCode"].ToString();
                   txtContractorPhone.Text = dr["ContractorPhone"].ToString();
                   txtContractorRep.Text = dr["ContractorRep"].ToString();
                   chkOwnerAsCustomer.Checked = dr["OwnerAsCustomer"].ToString() == "True" ? true : false;
                   txtOwnerName.Text = dr["OwnerName"].ToString();
                   txtOwnerAddress1.Text = dr["OwnerAddress"].ToString();
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
                   txtBondDate.Text = dr["BondDate"].ToString();
                   txtBondNumber.Text = dr["BondNumber"].ToString();
                   txtPONumber.Text = dr["PONumber"].ToString();
                   txtContractStartDate.Text = String.IsNullOrEmpty(dr["ContractStartDate"].ToString()) ? null : dr["ContractStartDate"].ToString().Substring(0, 10);
                   txtContractEstComplDate.Text = String.IsNullOrEmpty(dr["ContractEstComplDate"].ToString()) ? null : dr["ContractEstComplDate"].ToString().Substring(0, 10);
                   txtJurisdiction.Text = dr["Jurisdiction"].ToString();
                   txtMasterJobNumber.Text = dr["MasterJobNumber"].ToString();
                   cboRetainage.EditValue = dr["RetainageID"];
                   cboInsuranceProgram.EditValue = dr["InsuranceProgramID"];
                   txtTotalCLPUAmount.Text = dr["totalCLPUAmount"].ToString();
                   txtGLIABName.Text = dr["GLIABName"].ToString();
                   txtUMBRLName.Text = dr["UMBRLName"].ToString();
                   chkPreliminaryNotice.Checked = dr["PreliminaryNotice"].ToString() == "True" ? true : false;
                   txtPreliminaryDateMailed.Text = String.IsNullOrEmpty(dr["PreliminaryDateMailed"].ToString()) ? null : dr["PreliminaryDateMailed"].ToString().Substring(0, 10);
                   txtPreliminaryMailedBy.Text = dr["PreliminaryMailedBy"].ToString();
                   txtComment.Text = dr["Comment"].ToString();
                   txtPostedToFileDate.Text = String.IsNullOrEmpty(dr["PostedToFileDate"].ToString()) ? null : dr["PostedToFileDate"].ToString().Substring(0, 10);
                   txtPostedToFileBy.Text = dr["PostedToFileBy"].ToString();
                   cboJobStatus.EditValue = dr["JobStatusID"];
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
                   txtCutOffDate.Text = String.IsNullOrEmpty(dr["CutOffDate"].ToString()) ? null : dr["CutOffDate"].ToString().Substring(0, 10);
                   txtBidDate.Text = String.IsNullOrEmpty(dr["bidDate"].ToString()) ? null : dr["BidDate"].ToString().Substring(0, 10);
                   txtBidTime.Text = String.IsNullOrEmpty(dr["bidTime"].ToString()) ? null : dr["bidTime"].ToString();
                   txtPreBidAmount.Text = String.IsNullOrEmpty(dr["preBidAmount"].ToString()) ? null : dr["preBidAmount"].ToString();
                   chkDesignBuild.Checked = dr["designBuild"].ToString() == "True" ? true : false;
                   chkDrawingReceived.Checked = dr["drawingReceived"].ToString() == "True" ? true : false;
                   chkQuotesRequired.Checked = dr["quotesRequired"].ToString() == "True" ? true : false;
                   chkBidForm.Checked = dr["bidForm"].ToString() == "True" ? true : false;
                   txtBidWalkDate.Text = String.IsNullOrEmpty(dr["bidWalkDate"].ToString()) ? null : dr["BidWalkDate"].ToString().Substring(0, 10);
                   txtBidWalkTime.Text = String.IsNullOrEmpty(dr["bidWalkTime"].ToString()) ? null : dr["bidWalkTime"].ToString();
                   cboDeliveryMethod.Text = dr["deliveryMethod"].ToString();
                   txtArchitectEngineer.Text = dr["architectEngineer"].ToString();
                   txtAddendumReceived.Text = dr["addendumReceived"].ToString();
                   txtJobEmail.Text = dr["jobEmail"].ToString();
                   txtJobFax.Text = dr["jobFax"].ToString();
                   cboBidTo.Text = dr["bidTo"].ToString();
                   txtWONLOSTDate.Text = String.IsNullOrEmpty(dr["WonLostDate"].ToString()) ? null : dr["WonLostDate"].ToString().Substring(0, 10);
                   txtMeetingDate.Text = String.IsNullOrEmpty(dr["meetingDate"].ToString()) ? null : dr["meetingDate"].ToString().Substring(0,10);             
                   txtMeetingTime.Text = dr["MeetingTime"].ToString();
                   txtReviewDate.Text = String.IsNullOrEmpty(dr["reviewDate"].ToString()) ? null : dr["reviewDate"].ToString().Substring(0, 10);
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
                   //
                   chkEstimateHandoff.Checked = dr["EstimateHandoff"].ToString() == "True" ? true : false;
                   cboEstimateHandoffGrade.Text = dr["EstimateHandoffGrade"].ToString();
                   chkPMHandoff.Checked = dr["PMHandoff"].ToString() == "True" ? true : false;
                   cboPMHandoffGrade.Text = dr["PMHandoffGrade"].ToString();
                   chkProjectStartupMeeting.Checked = dr["ProjectStartupMeeting"].ToString() == "True" ? true : false;
                   break;
               default:
                   break;
           }
        }
        private void UpdateErrorMessages()
        {
            errorMessages = false;
            bool newEstimate = false;
            bool modifyEstimate = false;
            bool newJob = false;
            bool newJobWithoutEstimate = false;
            bool modifyJob = false ;
            bool modifyJobWithoutEstimate = false;
            
            // Identify Job Status
            if (txtEstimateNumber.Text.Trim().Length == 0 && txtJobNumber.Text.Trim().Length == 0)
                newEstimate = true;
            if (txtEstimateNumber.Text.Trim().Length > 0 && txtJobNumber.Text.Trim().Length == 0)
                modifyEstimate = true;
            if (txtEstimateNumber.Text.Trim().Length > 0 && txtJobNumber.Text.Trim().Length == 0 && 
                cboJobStatus.Text.Trim().Length > 0 && (cboJobStatus.Text.Trim() == "WON" || cboJobStatus.Text.Trim() == "NO BID"))
                newJob = true;
            if (txtEstimateNumber.Text.Trim().Length == 0 && txtJobNumber.Text.Trim().Length == 0 &&
                cboJobStatus.Text.Trim().Length > 0 && (cboJobStatus.Text.Trim() == "WON" || cboJobStatus.Text.Trim() == "NO BID"))
                newJobWithoutEstimate = true;
            if (txtEstimateNumber.Text.Trim().Length > 0 && txtJobNumber.Text.Trim().Length > 0 )
                modifyJob = true;
            if (txtEstimateNumber.Text.Trim().Length == 0 && txtJobNumber.Text.Trim().Length > 0)
                modifyJobWithoutEstimate = true;

            // Clear Error Text
            txtBidDate.ErrorText = "";
            txtBidTime.ErrorText = "";
            txtBidWalkDate.ErrorText = "";
            txtBidWalkTime.ErrorText = "";
            txtJobFax.ErrorText = "";
            txtJobEmail.ErrorText = "";
            txtPreBidAmount.ErrorText = "";
            txtAddendumReceived.ErrorText = "";
            txtJobName.ErrorText = "";
            txtJobAddress.ErrorText = "";
            txtJobCity.ErrorText = "";
            txtJobState.ErrorText = "";
            txtJobZip.ErrorText = "";
            txtJobPhone.ErrorText = "";
            txtJobDescription.ErrorText = "";
            txtContractStartDate.ErrorText = "";
            cboJobStatus.ErrorText = "";
            cboOffice.ErrorText = "";
            cboDepartment.ErrorText = "";
            txtContractStartDate.ErrorText = "";
            txtContractEstComplDate.ErrorText = "";


            txtContractEstComplDate.ErrorText = "";


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
                if (String.IsNullOrEmpty(cboDeliveryMethod.Text) || cboDeliveryMethod.Text.Trim().Length == 0)
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
                    txtArchitectEngineer.ErrorText = "";
                if (txtAddendumReceived.Text.Trim().Length == 0)
                {
                    txtAddendumReceived.ErrorText = "Addendum Received is required";
                    errorMessages = true;
                }

            }

            if (txtJobName.Text.Trim().Length == 0)
            {
                txtJobName.ErrorText = "Job Address is required";
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
            if (txtJobZip.Text.Trim().Length == 0)
            {
                txtJobZip.ErrorText = "Job Zip Code is required";
                errorMessages = true;
            }

            if (txtJobPhone.Text.Trim().Length == 0)
            {
                txtJobPhone.ErrorText = "Job Phone is required";
                errorMessages = true;
            }

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
            //
            // Job Validation
            //
            if (cboJobStatus.Text == "WON" || cboJobStatus.Text == "NO BID")
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
        }

    
        private void txtPreBidAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPreBidAmount.Text))
            {
                lblOver1M.Enabled = false;
                chkOver1M.Enabled = false;
                if (chkOver1M.Checked)
                    chkOver1M.Checked = false;
                lblOver250K.Enabled = false;
                chkOver250K.Enabled = false;
                if (chkOver250K.Checked)
                    chkOver250K.Checked = false;

            }
            else
            {
                if (Convert.ToDecimal(txtPreBidAmount.EditValue) >= 1000000)
                {
                    lblOver1M.Enabled = true;
                    chkOver1M.Enabled = true;
                    if (!chkOver1M.Checked)
                        chkOver1M.Checked = true;
                    lblOver250K.Enabled = false;
                    chkOver250K.Enabled = false;
                    if (chkOver250K.Checked)
                        chkOver250K.Checked = false;
                }
                else if (Convert.ToDecimal(txtPreBidAmount.EditValue) >= 250000 && cboDepartment.Text == "TECHNOLOGY")
                {
                    lblOver1M.Enabled = false;
                    chkOver1M.Enabled = false;
                    if (chkOver1M.Checked)
                        chkOver1M.Checked = false;
                    lblOver250K.Enabled = true;
                    chkOver250K.Enabled = true;
                    if (!chkOver250K.Checked)
                        chkOver250K.Checked = true;
                }
                else
                {
                    lblOver1M.Enabled = false;
                    chkOver1M.Enabled = false;
                    if (chkOver1M.Checked)
                        chkOver1M.Checked = false;
                    lblOver250K.Enabled = false;
                    chkOver250K.Enabled = false;
                    if (chkOver250K.Checked)
                        chkOver250K.Checked = false;
                }
            }
            AllControls_EditValue(sender, e);
        }

        private void pagGeneral_MouseClick(object sender, MouseEventArgs e)
        {
            pagGeneral.Focus();
        }

    }
}