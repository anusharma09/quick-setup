using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCEOTProjects.BusinessLayer;
using CCEOTProjects;
using System.Web;
using System.Net.Mail;

using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace CCEOTProjects.PresentationLayer
{
    public partial class frmProjectOpportunity : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string                    recordID;
        protected BindingSource             bindingSource;
        protected bool                      dataChanged;
        private bool                        errorMessages = false;
        private bool                        approvalStatus = false;
        private bool                        forwardForApprovalStatus = false;
        private bool                        worktypeStatus = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        private bool                        projectApproval = false;
        private bool                        projectApproval5Million = false;
        private bool                        changesStatus = false;
        private bool                        ccApproval = false;
        private string                      assignedTo;

        private Int64                      sessionID = 0;

        
        //
        enum ClickedButton
        {
            Next,
            Previous,
            Delete,
            New,
            Save,
            Undo,
            Close
        };  
        //
        public frmProjectOpportunity()
        {
            InitializeComponent();
        }
        //
        public frmProjectOpportunity(string recordID, BindingSource bindingSource)
        {
            this.recordID = recordID;
            this.bindingSource = bindingSource;
            this.sessionID = 0;
            InitializeComponent();
        }
        //
        private void frmProjectOpportunity_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                tabMaster.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

                if (Security.Security.UserJCCProjectOpportunityAccessLevel == Security.Security.AccessLevel.ReadOnly)
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                }
                else
                {
                    if (Security.Security.UserJCCProjectOpportunityAccessLevel != Security.Security.AccessLevel.ReadWriteCreate)
                        btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
               
                txtRecordID.DataBindings.Add("text", bindingSource, "OTProjectID");

                cboOffice.Properties.DataSource = StaticTables.Office;
                cboOffice.Properties.PopulateColumns();
                cboOffice.Properties.DisplayMember = "Name";
                cboOffice.Properties.ValueMember = "OfficeID";
                cboOffice.Properties.ShowHeader = false;
                cboOffice.Properties.Columns[0].Visible = false;

                cboDepartment.Properties.DataSource = StaticTables.Department;
                cboDepartment.Properties.PopulateColumns();
                cboDepartment.Properties.DisplayMember = "Name";
                cboDepartment.Properties.ValueMember = "DepartmentID";
                cboDepartment.Properties.ShowHeader = false;
                cboDepartment.Properties.Columns[0].Visible = false;

                cboWorkType.Properties.DataSource = StaticTables.WorkType;
                cboWorkType.Properties.PopulateColumns();
                cboWorkType.Properties.DisplayMember = "Description";
                cboWorkType.Properties.ValueMember = "WorkTypeID";
                cboWorkType.Properties.ShowHeader = false;
                cboWorkType.Properties.Columns[0].Visible = false;

                cboOTProjectStatus.Properties.DataSource = StaticTables.OTStatus;
                cboOTProjectStatus.Properties.PopulateColumns();
                cboOTProjectStatus.Properties.DisplayMember = "OTStatusDescription";
                cboOTProjectStatus.Properties.ValueMember = "OTStatusID";
                cboOTProjectStatus.Properties.ShowHeader = false;
                cboOTProjectStatus.Properties.Columns[0].Visible = false;

               /* cboAssignedTo.Properties.DataSource = StaticTables.AssignedTo;
                cboAssignedTo.Properties.PopulateColumns();
                cboAssignedTo.Properties.DisplayMember = "UserName";
                cboAssignedTo.Properties.ValueMember = "UserLANID";
                cboAssignedTo.Properties.ShowHeader = false;
                cboAssignedTo.Properties.Columns[0].Visible = false;
                */

                cboUnitType.Properties.DataSource = StaticTables.UnitType;
                cboUnitType.Properties.PopulateColumns();
                cboUnitType.Properties.DisplayMember = "UnitType";
                cboUnitType.Properties.ValueMember = "UnitTypeCode";
                cboUnitType.Properties.ShowHeader = false;
                cboUnitType.Properties.Columns[0].Visible = false;

                UpdateErrorMessages();
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    ribbonProductivity.Visible = false;
                }
                else
                {
                    ribbonReport.Visible = true;
                    ribbonProductivity.Visible = true;
                    GetProject();
                }
                txtRecordID.Text = this.recordID;
                this.Opacity = 1;
                this.Cursor = Cursors.Default;
                sessionID = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetProjectDetail(string recordID)
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateProject(recordID);
                if (chkApproved.CheckState == CheckState.Checked)
                    approvalStatus = true;
                else
                    approvalStatus = false;
                if (chkForwardForApproval.CheckState == CheckState.Checked)
                    forwardForApprovalStatus = true;
                else
                    forwardForApprovalStatus = false;
                this.Focus();
                ccApproval = false;
            }
            else
            {
                forwardForApprovalStatus = false;
                approvalStatus = false;
                projectApproval = false;
                projectApproval5Million = false;
                ccApproval = false;

                txtOTProjectNumber.Text = "";
                txtEstimateNumber.Text = "";
                txtJobNumber.Text = "";
                txtOTProjectName.Text = "";
                chkRush.CheckState = CheckState.Unchecked;
                cboOTProjectStatus.EditValue = null;
                cboAssignedTo.EditValue = null;
                chkAssignedToAccepted.CheckState = CheckState.Unchecked;
                txtOTProjectAddress.Text = "";
                cboWorkType.EditValue = null;
                txtOTProjectCity.Text = "";
                txtOTProjectState.Text = "";
                txtOTProjectZip.Text = "";
                cboOffice.EditValue = null;
                txtWebSite.Text = "";
                cboDepartment.EditValue = null;
                cboUnitType.EditValue = null;
                txtUnits.Text = null;
                txtBidDate.Text = "";
                txtBidWalkDate.Text = "";
                chkBidAsPrime.CheckState = CheckState.Unchecked;
                chkBidAsSub.CheckState = CheckState.Unchecked;
                chkBidBondRequired.CheckState = CheckState.Unchecked;
                txtBidTime.Text = null;
                txtBidWalkTime.Text = null;
                chkPPBRequired.CheckState = CheckState.Unchecked;
                txtNextActionNeeded.Text = "";
                txtNextActionDate.Text = "";
                txtNextActionDateAuto.Text = "";
                txtPrequalDate.Text = "";
                txtCCERepForBidWalk.Text = "";
                chkBidToOwner.CheckState = CheckState.Unchecked;
                chkBidToContractor.CheckState = CheckState.Unchecked;
                chkBidToDeveloper.CheckState = CheckState.Unchecked;
                chkBidToOther.CheckState = CheckState.Unchecked;
                txtBidToOtherDescription.Text = "";
                txtDescription.Text = "";
                txtProjectTotalDollar.Text = "";
                txtElectricalDollar.Text = "";
                chkForwardForApproval.CheckState = CheckState.Unchecked;
                chkEngineered.CheckState = CheckState.Unchecked;
                chkLEED.CheckState = CheckState.Unchecked;
                chkDesignBuild.CheckState = CheckState.Unchecked;
                chkDesignAssist.CheckState = CheckState.Unchecked;
                chkPLA.CheckState = CheckState.Unchecked;
                chkPrevailingWage.CheckState = CheckState.Unchecked;
                chkBudgetOnly.CheckState = CheckState.Unchecked;
                chkBid.CheckState = CheckState.Unchecked;
                chkNegotiated.CheckState = CheckState.Unchecked;
                txtOther.Text = "";
                cboFinanceInPlace.Text = "";
                chkMinorityRequirements.CheckState = CheckState.Unchecked;
                txtMinorityType.Text = "";
                cboPrequalRequired.Text = "";
                chkDrawingAvailable.CheckState = CheckState.Unchecked;
                txtOpportunityValue.Text = "";
                txtSubmittedBy.Text = "";
                txtSubmittedDate.Text = "";
                chkApproved.CheckState = CheckState.Unchecked;
                txtApprovedBy.Text = "";
                chkPApproved.CheckState = CheckState.Unchecked;
                txtPApprovedBy.Text = "";
                txtOwnerName.Text = "";
                txtOwnerAddress.Text = "";
                txtOwnerCity.Text = "";
                txtOwnerState.Text = "";
                txtOwnerZip.Text = "";
                txtOwnerContactName.Text = "";
                txtOwnerContactEmail.Text = "";
                txtOwnerContactPhone.Text = "";
                txtOwnerContactFax.Text = "";
                txtGeneralContractorName.Text = "";
                txtGeneralContractorAddress.Text = "";
                txtGeneralContractorCity.Text = "";
                txtGeneralContractorState.Text = "";
                txtGeneralContractorZip.Text = "";
                txtGeneralContractorContactName.Text = "";
                txtGeneralContractorContactEmail.Text = "";
                txtGeneralContractorContactPhone.Text = "";
                txtGeneralContractorContactFax.Text = "";
                txtArchitectName.Text = "";
                txtArchitectAddress.Text = "";
                txtArchitectCity.Text = "";
                txtArchitectState.Text = "";
                txtArchitectZip.Text = "";
                txtArchitectContactName.Text = "";
                txtArchitectContactEmail.Text = "";
                txtArchitectContactPhone.Text = "";
                txtArchitectContactFax.Text = "";
                txtEngineerName.Text = "";
                txtEngineerAddress.Text = "";
                txtEngineerCity.Text = "";
                txtEngineerState.Text = "";
                txtEngineerZip.Text = "";
                txtEngineerContactName.Text = "";
                txtEngineerContactEmail.Text = "";
                txtEngineerContactPhone.Text = "";
                txtEngineerContactFax.Text = "";
                cboBidWalk.Text = "";
                txtSource.Text = "";
                txtReferenceNumber.Text = "";
                txtStatusDate.Text = "";
                txtNextActionTime.Text = null;
                txtUnits.Text = null;
                cboUnitType.EditValue = "";
                cboOTProjectStatus.Properties.ReadOnly = false;
                cboWorkType.Properties.ReadOnly = false;
                cboOffice.Properties.ReadOnly = false;
                cboDepartment.Properties.ReadOnly = false;
                cboAssignedTo.Properties.ReadOnly = false;
                cboUnitType.Properties.ReadOnly = false;
                txtOTProjectName.Properties.ReadOnly = false;
                txtOTProjectAddress.Properties.ReadOnly = false;
                txtOTProjectCity.Properties.ReadOnly = false;
                txtOTProjectState.Properties.ReadOnly = false;
                txtOTProjectZip.Properties.ReadOnly = false;
                txtBidDate.Properties.ReadOnly = false;
                txtBidTime.Properties.ReadOnly = false;
                txtBidWalkDate.Properties.ReadOnly = false;
                txtBidWalkTime.Properties.ReadOnly = false;
                txtUnits.Properties.ReadOnly = false;
                chkApproved.Properties.ReadOnly = true;
                chkPApproved.Properties.ReadOnly = true;
                chkForwardForApproval.Properties.ReadOnly = false;
                lblAssignmentToMe.Visible = false;
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
            sessionID = 0;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "Next Project":
                    if (!ctlProjectAssignments.IsRowChanged())
                    {
                        if (CheckJobStatus(ClickedButton.Next))
                        {
                            if (changesStatus)
                            {
                                Email();
                                changesStatus = false;
                            }
                            bindingSource.MoveNext();
                            recordID = txtRecordID.Text;
                            GetProject();
                            dataChanged = false;
                            btnUndo.Enabled = false;
                            ribbonReport.Visible = true;
                            ribbonProductivity.Visible = true;
                            UpdateTabStatusByName(currentButtonName);
                        }
                    }
                    break;
                case "Previous Project":
                    if (!ctlProjectAssignments.IsRowChanged())
                    {
                        if (CheckJobStatus(ClickedButton.Previous))
                        {
                            if (changesStatus)
                            {
                                Email();
                                changesStatus = false;
                            }
                            bindingSource.MovePrevious();
                            recordID = txtRecordID.Text;
                            GetProject();
                            dataChanged = false;
                            btnUndo.Enabled = false;
                            ribbonReport.Visible = true;
                            ribbonProductivity.Visible = true;
                            UpdateTabStatusByName(currentButtonName);
                            ccApproval = false;
                        }
                    }
                    break;
                case "&New":
                    if (!ctlProjectAssignments.IsRowChanged())
                    {
                        if (CheckJobStatus(ClickedButton.New))
                        {
                            if (changesStatus)
                            {
                                Email();
                                changesStatus = false;
                            }

                            recordID = "0";
                            sessionID = 0;
                            txtRecordID.Text = "0";
                            GetProject();
                            dataChanged = false;
                            btnUndo.Enabled = false;
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                            ribbonReport.Visible = false;
                            ribbonProductivity.Visible = false;
                            UpdateTabStatusByName("Project Info.");
                            ccApproval = false;
                        }
                    }
                    break;
                case "&Save":
                    if (CheckJobStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                        ribbonProductivity.Visible = true;
                    }
                    break;
                case "&Undo":

                    txtOTProjectName.Select();
                    txtOTProjectName.Select(0, 0);
                    bindingSource.CancelEdit();
                    GetProject();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    ccApproval = false;
                    break;
                case "&Info Sheet":
                    try
                    {
                       Reports.Reports.ProjectSheet(recordID);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
                case "&Documents":
                    try
                    {
                        Reports.Reports.ProjectDocumentsList(txtOTProjectNumber.Text,
                                                            txtOTProjectName.Text,
                                                            ctlProjectDocuments.DocumentTable);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
                case "&Web Links":
                    try
                    {
                        Reports.Reports.ProjectWebLinks(txtOTProjectNumber.Text,
                                                            txtOTProjectName.Text,
                                                            ctlProjectWebLinks.WebLinkTable);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
                case "&Notes":
                    try
                    {
                        Reports.Reports.ProjectNotes(txtOTProjectNumber.Text,
                                                            txtOTProjectName.Text,
                                                            ctlProjectNotes.NoteTable,
                                                            ctlProjectNotes.NoteSort,
                                                            ctlProjectNotes.NoteFilter);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
                case "&Assignments":
                    try
                    {
                        Reports.Reports.ProjectAssignments(recordID,
                                                            txtOTProjectNumber.Text,
                                                            txtOTProjectName.Text,
                                                            ctlProjectAssignments.AssignmentTable,
                                                            ctlProjectAssignments.AssignmentSort,
                                                            ctlProjectAssignments.AssignmentFilter,
                                                            ctlProjectAssignments.AssignmentSortField,
                                                            ctlProjectAssignments.AssignmentFilterField);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
                case "&Audit":
                    try
                    {
                        Reports.Reports.ProjectAudit(txtOTProjectNumber.Text,
                                                            txtOTProjectName.Text,
                                                            ctlProjectAudit.AuditTable,
                                                            ctlProjectAudit.AuditSort,
                                                            ctlProjectAudit.AuditFilter);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
            }
        }
        //
        private bool CheckJobStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveProject();
                        bindingSource.EndEdit();
                        //bindingSource.ResetCurrentItem();
                        //bindingSource.ResetBindings(true);
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
        //
        private void SaveProject()
        {
          /*  if (txtRecordID.Text.Length == 0)
            {
                recordID = "0";
            }
            else
                recordID = txtRecordID.Text.Trim();
           */
            try
            {
                // NextAction Date Auto
                string nextActionDateAuto = "";
                if (txtBidDate.Text.Length > 0)
                {
                    if (nextActionDateAuto == "")
                        nextActionDateAuto = txtBidDate.Text;
                    else
                    {
                        if (DateTime.Compare(DateTime.Parse(nextActionDateAuto), DateTime.Parse(txtBidDate.Text)) > 0)
                            nextActionDateAuto = txtBidDate.Text;
                    }
                }
                //
                if (txtBidWalkDate.Text.Length > 0)
                {
                    if (nextActionDateAuto == "")
                        nextActionDateAuto = txtBidWalkDate.Text;
                    else
                    {
                        if (DateTime.Compare(DateTime.Parse(nextActionDateAuto), DateTime.Parse(txtBidWalkDate.Text)) > 0)
                            nextActionDateAuto = txtBidWalkDate.Text;
                    }
                }
                //
                if (txtNextActionDate.Text.Length > 0)
                {
                    if (nextActionDateAuto == "")
                        nextActionDateAuto = txtNextActionDate.Text;
                    else
                    {
                        if (DateTime.Compare(DateTime.Parse(nextActionDateAuto), DateTime.Parse(txtNextActionDate.Text)) > 0)
                            nextActionDateAuto = txtNextActionDate.Text;
                    }
                }
                //
                if (txtPrequalDate.Text.Length > 0)
                {
                    if (nextActionDateAuto == "")
                        nextActionDateAuto = txtPrequalDate.Text;
                    else
                    {
                        if (DateTime.Compare(DateTime.Parse(nextActionDateAuto), DateTime.Parse(txtPrequalDate.Text)) > 0)
                            nextActionDateAuto = txtPrequalDate.Text;
                    }
                }

                txtNextActionDateAuto.Text = nextActionDateAuto;

                OTProject project = new OTProject(recordID,
                          txtOTProjectNumber.Text,
                          cboOTProjectStatus.EditValue == null ? String.Empty : cboOTProjectStatus.EditValue.ToString(),
                          cboWorkType.EditValue == null ? String.Empty : cboWorkType.EditValue.ToString(),
                          cboOffice.EditValue == null ? String.Empty : cboOffice.EditValue.ToString(),
                          cboDepartment.EditValue == null ? String.Empty : cboDepartment.EditValue.ToString(),
                          cboAssignedTo.EditValue == null ? String.Empty : cboAssignedTo.EditValue.ToString(),
                          chkAssignedToAccepted.Checked.ToString(),
                          txtEstimateNumber.Text,
                          chkRush.Checked.ToString(),
                          txtOTProjectName.Text,
                          txtOTProjectAddress.Text,
                          txtOTProjectCity.Text,
                          txtOTProjectState.Text,
                          txtOTProjectZip.Text,
                          chkBidBondRequired.Checked.ToString(),
                          chkPPBRequired.Checked.ToString(),
                          txtBidDate.Text,
                          txtBidTime.Text,
                          txtBidWalkDate.Text,
                          txtBidWalkTime.Text,
                          txtCCERepForBidWalk.Text,
                          chkBidAsPrime.Checked.ToString(),
                          chkBidAsSub.Checked.ToString(),
                          txtNextActionNeeded.Text,
                          txtNextActionDate.Text,
                          txtNextActionDateAuto.Text,
                          txtPrequalDate.Text,
                          chkBidToOwner.Checked.ToString(),
                          chkBidToContractor.Checked.ToString(),
                          chkBidToDeveloper.Checked.ToString(),
                          chkBidToOwner.Checked.ToString(),
                          txtBidToOtherDescription.Text,
                          txtDescription.Text,
                          txtProjectTotalDollar.Text,
                          txtElectricalDollar.Text,
                          chkForwardForApproval.Checked.ToString(),
                          chkEngineered.Checked.ToString(),
                          chkLEED.Checked.ToString(),
                          chkDesignBuild.Checked.ToString(),
                          chkDesignAssist.Checked.ToString(),
                          chkPLA.Checked.ToString(),
                          chkPrevailingWage.Checked.ToString(),
                          chkBudgetOnly.Checked.ToString(),
                          chkBid.Checked.ToString(),
                          chkNegotiated.Checked.ToString(),
                          txtOther.Text,
                          cboFinanceInPlace.Text,
                          chkMinorityRequirements.Checked.ToString(),
                          txtMinorityType.Text,
                          cboPrequalRequired.Text,
                          chkDrawingAvailable.Checked.ToString(),
                          txtOpportunityValue.Text,
                          txtNote.Text,
                          txtWebSite.Text,
                          txtOwnerName.Text,
                          txtOwnerAddress.Text,
                          txtOwnerCity.Text,
                          txtOwnerState.Text,
                          txtOwnerZip.Text,
                          txtOwnerContactName.Text,
                          txtOwnerContactEmail.Text,
                          txtOwnerContactPhone.Text,
                          txtOwnerContactFax.Text,
                          txtGeneralContractorName.Text,
                          txtGeneralContractorAddress.Text,
                          txtGeneralContractorCity.Text,
                          txtGeneralContractorState.Text,
                          txtGeneralContractorZip.Text,
                          txtGeneralContractorContactName.Text,
                          txtGeneralContractorContactEmail.Text,
                          txtGeneralContractorContactPhone.Text,
                          txtGeneralContractorContactFax.Text,
                          txtDeveloperName.Text,
                          txtDeveloperAddress.Text,
                          txtDeveloperCity.Text,
                          txtDeveloperState.Text,
                          txtDeveloperZip.Text,
                          txtDeveloperContactName.Text,
                          txtDeveloperContactEmail.Text,
                          txtDeveloperContactPhone.Text,
                          txtDeveloperContactFax.Text,
                          txtArchitectName.Text,
                          txtArchitectAddress.Text,
                          txtArchitectCity.Text,
                          txtArchitectState.Text,
                          txtArchitectZip.Text,
                          txtArchitectContactName.Text,
                          txtArchitectContactEmail.Text,
                          txtArchitectContactPhone.Text,
                          txtArchitectContactFax.Text,
                          txtEngineerName.Text,
                          txtEngineerAddress.Text,
                          txtEngineerCity.Text,
                          txtEngineerState.Text,
                          txtEngineerZip.Text,
                          txtEngineerContactName.Text,
                          txtEngineerContactEmail.Text,
                          txtEngineerContactPhone.Text,
                          txtEngineerContactFax.Text,
                          txtSubmittedBy.Text,
                          txtSubmittedDate.Text,
                          chkApproved.Checked.ToString(),
                          txtApprovedBy.Text,
                          chkPApproved.Checked.ToString(),
                          txtPApprovedBy.Text,
                          DateTime.Today.ToShortDateString(),
                          Security.Security.LoginID.ToUpper(),
                          cboBidWalk.Text,
                          txtSource.Text,
                          txtReferenceNumber.Text,
                          txtStatusDate.Text,
                          txtNextActionTime.Text,
                          cboUnitType.EditValue == null ? "" : cboUnitType.EditValue.ToString(),
                          txtUnits.Text);
                project.Save();
                recordID = project.OTProjectID; 
                txtRecordID.Text = recordID;
                if (txtOTProjectNumber.Text == "" || txtEstimateNumber.Text == "")
                {
                    DataTable table = OTProject.GetProjectAndEstimateNumber(recordID).Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        string queryForupdateJob = txtEstimateNumber.Text = table.Rows[0]["EstimateNumber"].ToString();
                        txtOTProjectNumber.Text = table.Rows[0]["OTProjectNumber"].ToString();
                        txtSubmittedBy.Text = table.Rows[0]["SubmittedBy"].ToString();
                        txtSubmittedDate.Text = table.Rows[0]["SubmittedDate"].ToString();
                        txtApprovedBy.Text = table.Rows[0]["ApprovedBy"].ToString();
                        txtPApprovedBy.Text = table.Rows[0]["PApprovedBy"].ToString();
                        projectApproval = table.Rows[0]["ProjectApproval"].ToString() == "True" ? true : false;
                        projectApproval5Million = table.Rows[0]["ProjectApproval5Million"].ToString() == "True" ? true : false;
                        #region created by anu to update job status as new
                        if (!string.IsNullOrEmpty(queryForupdateJob))
                        {
                            //queryForupdateJob = "UPDATE tblJob SET IsNewJob = 1 WHERE EstimateNumber = " + queryForupdateJob;
                            queryForupdateJob = "UPDATE tblJob SET IsNewJob = 1 WHERE EstimateNumber = '" + queryForupdateJob + "' ";
                            DataBaseUtil.ExecuteNonQuery(queryForupdateJob, CCEApplication.Connection, CommandType.Text);
                        }
                        #endregion
                    }
                }
                UpdateFormStatus();
                // Keep tracking of the changes
                changesStatus = true;
                // Get OTAuditID
                if (chkForwardForApproval.CheckState == CheckState.Checked && sessionID == 0)
                {
                    sessionID = Audit.GetSessionID(recordID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
        }
        //
        private void GetProject()
        {
            GetProjectDetail(recordID);
            this.Text = txtOTProjectName.Text;
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
                    myControl.Text = myControl.Text.ToString().ToUpper();
            }
            txtOTProjectCity.Text = txtOTProjectCity.Text.ToUpper();
            if (!dataChanged)
            {
                if (Security.Security.UserJCCProjectOpportunityAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }
        //
        private void frmJob_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckJobStatus(ClickedButton.Close);
            if (changesStatus)
            {
                Email();
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateProject(string recordID)
        {
            try
            {
                DataRow dr;
                dr = OTProject.GetOTProject(recordID).Tables[0].Rows[0];

                txtOTProjectNumber.Text             = dr["OTProjectNumber"].ToString();
                cboOTProjectStatus.EditValue        = dr["OTProjectStatusID"];
                cboWorkType.EditValue               = dr["WorkTypeID"]; 
                cboOffice.EditValue                 = dr["OfficeID"];
                cboDepartment.EditValue             = dr["DepartmentID"];
                cboAssignedTo.EditValue             = dr["AssignedTo"].ToString();
                chkAssignedToAccepted.Checked       = dr["AssignedToAccepted"].ToString() == "True" ? true : false;
                txtEstimateNumber.Text              = dr["EstimateNumber"].ToString();
                txtJobNumber.Text                   = dr["JobNumber"].ToString();
                chkRush.Checked                     = dr["Rush"].ToString() == "True" ? true : false;
                txtOTProjectName.Text               = dr["OTProjectName"].ToString();
                txtOTProjectAddress.Text            = dr["OTProjectAddress"].ToString();
                txtOTProjectCity.Text               = dr["OTProjectCity"].ToString();
                txtOTProjectState.Text              = dr["OTProjectState"].ToString();
                txtOTProjectZip.Text                = dr["OTProjectZip"].ToString();
                chkBidBondRequired.Checked          = dr["BidBondRequired"].ToString() == "True" ? true : false;
                chkPPBRequired.Checked              = dr["PPBRequired"].ToString() == "True" ? true : false;
                txtBidDate.Text                     = dr["BidDate"].ToString();
                txtBidTime.Text                     = String.IsNullOrEmpty(dr["BidTime"].ToString()) ? null : dr["BidTime"].ToString();
                txtBidWalkDate.Text                 = dr["BidWalkDate"].ToString();
                txtBidWalkTime.Text                 = String.IsNullOrEmpty(dr["BidWalkTime"].ToString()) ? null : dr["BidWalkTime"].ToString();
                txtCCERepForBidWalk.Text            = dr["CCERepForBidWalk"].ToString();
                chkBidAsPrime.Checked               = dr["BiddingAsPrime"].ToString() == "True" ? true : false;
                chkBidAsSub.Checked                 = dr["BiddingAsSub"].ToString() == "True" ? true : false;
                txtNextActionNeeded.Text            = dr["NextActionNeeded"].ToString();
                txtNextActionDateAuto.Text          = dr["NextActionDateAuto"].ToString();
                txtPrequalDate.Text                 = dr["PrequalDate"].ToString();
                txtNextActionDate.Text              = dr["NextActionDate"].ToString();
                chkBidToOwner.Checked               = dr["BidToOwner"].ToString() == "True" ? true : false;
                chkBidToContractor.Checked          = dr["BidToContractor"].ToString() == "True" ? true : false;
                chkBidToDeveloper.Checked           = dr["BidToDeveloper"].ToString() == "True" ? true : false;
                chkBidToOwner.Checked               = dr["BidToOwner"].ToString() == "True" ? true : false;
                txtBidToOtherDescription.Text       = dr["BidToOtherDescription"].ToString();
                txtDescription.Text                 = dr["Description"].ToString();
                txtProjectTotalDollar.Text          = dr["ProjectTotalDollar"].ToString();
                txtElectricalDollar.Text            = dr["ElectricalDollar"].ToString(); 
                chkForwardForApproval.Checked       = dr["ForwardForApproval"].ToString() == "True" ? true : false;
                chkEngineered.Checked               = dr["Engineered"].ToString() == "True" ? true : false;
                chkLEED.Checked                     = dr["LEED"].ToString() == "True" ? true : false;
                chkDesignBuild.Checked              = dr["DesignBuild"].ToString() == "True" ? true : false;
                chkDesignAssist.Checked             = dr["DesignAssist"].ToString() == "True" ? true : false;
                chkPLA.Checked                      = dr["PLA"].ToString() == "True" ? true : false;
                chkPrevailingWage.Checked           = dr["PrevailingWage"].ToString() == "True" ? true : false;
                chkBudgetOnly.Checked               = dr["BudgetOnly"].ToString() == "True" ? true : false;
                chkBid.Checked                      = dr["Bid"].ToString() == "True" ? true : false;
                chkNegotiated.Checked               = dr["Negotiated"].ToString() == "True" ? true : false;
                txtOther.Text                       = dr["Other"].ToString();
                cboFinanceInPlace.Text              = dr["FinanceInPlace"].ToString();
                chkMinorityRequirements.Checked     = dr["MinorityRequirements"].ToString() == "True" ? true : false;
                txtMinorityType.Text                = dr["MinorityType"].ToString();
                cboPrequalRequired.Text             = dr["PrequalRequired"].ToString();
                chkDrawingAvailable.Checked         = dr["DrawingAvailable"].ToString() == "True" ? true : false;
                txtOpportunityValue.Text            = dr["OpportunityValue"].ToString();
                txtNote.Text                        = dr["Note"].ToString();
                txtWebSite.Text                     = dr["WebSite"].ToString();
                txtOwnerName.Text                   = dr["OwnerName"].ToString();
                txtOwnerAddress.Text                = dr["OwnerAddress"].ToString();
                txtOwnerCity.Text                   = dr["OwnerCity"].ToString();
                txtOwnerState.Text                  = dr["OwnerState"].ToString();
                txtOwnerZip.Text                    = dr["OwnerZip"].ToString();
                txtOwnerContactName.Text            = dr["OwnerContactName"].ToString();
                txtOwnerContactEmail.Text           = dr["OwnerContactEmail"].ToString();
                txtOwnerContactPhone.Text           = dr["OwnerContactPhone"].ToString();
                txtOwnerContactFax.Text             = dr["OwnerContactFax"].ToString();
                txtGeneralContractorName.Text       = dr["GeneralContractorName"].ToString();
                txtGeneralContractorAddress.Text    = dr["GeneralContractorAddress"].ToString();
                txtGeneralContractorCity.Text       = dr["GeneralContractorCity"].ToString();
                txtGeneralContractorState.Text      = dr["GeneralContractorState"].ToString();
                txtGeneralContractorZip.Text        = dr["GeneralContractorZip"].ToString();
                txtGeneralContractorContactName.Text = dr["GeneralContractorContactName"].ToString();
                txtGeneralContractorContactEmail.Text = dr["GeneralContractorContactEmail"].ToString();
                txtGeneralContractorContactPhone.Text = dr["GeneralContractorContactPhone"].ToString();
                txtGeneralContractorContactFax.Text = dr["GeneralContractorContactFax"].ToString();
                txtDeveloperName.Text               = dr["DeveloperName"].ToString();
                txtDeveloperAddress.Text            = dr["DeveloperAddress"].ToString();
                txtDeveloperCity.Text               = dr["DeveloperCity"].ToString();
                txtDeveloperState.Text              = dr["DeveloperState"].ToString();
                txtDeveloperZip.Text                = dr["DeveloperZip"].ToString();
                txtDeveloperContactName.Text        = dr["DeveloperContactName"].ToString();
                txtDeveloperContactEmail.Text       = dr["DeveloperContactEmail"].ToString();
                txtDeveloperContactPhone.Text       = dr["DeveloperContactPhone"].ToString();
                txtDeveloperContactFax.Text         = dr["DeveloperContactFax"].ToString();
                txtArchitectName.Text               = dr["ArchitectName"].ToString();
                txtArchitectAddress.Text            = dr["ArchitectAddress"].ToString();
                txtArchitectCity.Text               = dr["ArchitectCity"].ToString();
                txtArchitectState.Text              = dr["ArchitectState"].ToString();
                txtArchitectZip.Text                = dr["ArchitectZip"].ToString();
                txtArchitectContactName.Text        = dr["ArchitectContactName"].ToString();
                txtArchitectContactEmail.Text       = dr["ArchitectContactEmail"].ToString();
                txtArchitectContactPhone.Text       = dr["ArchitectContactPhone"].ToString();
                txtArchitectContactFax.Text         = dr["ArchitectContactFax"].ToString();
                txtEngineerName.Text                = dr["EngineerName"].ToString();
                txtEngineerAddress.Text             = dr["EngineerAddress"].ToString();
                txtEngineerCity.Text                = dr["EngineerCity"].ToString();
                txtEngineerState.Text               = dr["EngineerState"].ToString();
                txtEngineerZip.Text                 = dr["EngineerZip"].ToString();
                txtEngineerContactName.Text         = dr["EngineerContactName"].ToString();
                txtEngineerContactEmail.Text        = dr["EngineerContactEmail"].ToString();
                txtEngineerContactPhone.Text        = dr["EngineerContactPhone"].ToString();
                txtEngineerContactFax.Text          = dr["EngineerContactFax"].ToString();
                txtSubmittedBy.Text                 = dr["SubmittedByName"].ToString();
                txtSubmittedDate.Text               = dr["SubmittedDate"].ToString();
                chkApproved.Checked                 = dr["Approved"].ToString() == "True" ? true : false;
                txtApprovedBy.Text                  = dr["ApprovedBy"].ToString();
                chkPApproved.Checked                = dr["PApproved"].ToString() == "True" ? true : false;
                txtPApprovedBy.Text                 = dr["PApprovedBy"].ToString();
                cboBidWalk.Text                     = dr["BidWalk"].ToString();
                txtSource.Text                      = dr["Source"].ToString();
                txtReferenceNumber.Text             = dr["ReferenceNumber"].ToString();
                txtStatusDate.Text                  = dr["StatusDate"].ToString();
                txtNextActionTime.Text              = String.IsNullOrEmpty(dr["NextActionTime"].ToString()) ? null : dr["NextActionTime"].ToString();
                cboUnitType.EditValue               = dr["UnitType"].ToString();
                txtUnits.Text                       = String.IsNullOrEmpty(dr["Units"].ToString()) ? null : dr["Units"].ToString();
                projectApproval                     = dr["ProjectApproval"].ToString() == "True" ? true : false;
                projectApproval5Million             = dr["ProjectApproval5Million"].ToString() == "True" ? true : false;
                if (dr["AssignmentNumberToMe"].ToString().Trim() == "0")
                    lblAssignmentToMe.Visible = false;
                else
                {
                    lblAssignmentToMe.Visible = true;
                    lblAssignmentToMe.Text = "Incomplete Assignments To Me: (" + dr["AssignmentNumberToMe"].ToString() + ")";
                }

                if (dr["AssignmentNumberByMe"].ToString().Trim() == "0")
                    lblAssignmentByMe.Visible = false;
                else
                {
                    lblAssignmentByMe.Visible = true;
                    lblAssignmentByMe.Text = "Incomplete Assignments By Me: (" + dr["AssignmentNumberByMe"].ToString() + ")";
                }



                UpdateFormStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateFormStatus()
        {
            if (chkForwardForApproval.CheckState == CheckState.Checked)
            {
                chkForwardForApproval.Properties.ReadOnly = true;
                if (chkApproved.CheckState == CheckState.Checked)
                    chkApproved.Properties.ReadOnly = true;
                else
                {
                    if (projectApproval)
                        chkApproved.Properties.ReadOnly = false;
                    else
                        chkApproved.Properties.ReadOnly = true;
                }
                if (chkPApproved.CheckState == CheckState.Checked)
                    chkPApproved.Properties.ReadOnly = true;
                else
                {
                    if (projectApproval5Million  
                        &&(Double.Parse(txtElectricalDollar.Text.Replace("(", "-").Replace(")", "").Replace("$", "").Replace(",", "")) >= 5000000)
                        )
                        chkPApproved.Properties.ReadOnly = false;
                    else
                        chkPApproved.Properties.ReadOnly = true;
                }

            }
            else
            {
                chkForwardForApproval.Properties.ReadOnly = false;
                chkPApproved.Properties.ReadOnly = true;
                chkApproved.Properties.ReadOnly = true;
            }

            if (cboOTProjectStatus.EditValue != null && cboOTProjectStatus.EditValue.ToString() == "1")
            {
                cboOTProjectStatus.Properties.ReadOnly = true;
                cboWorkType.Properties.ReadOnly = true;
                cboOffice.Properties.ReadOnly = true;
                cboDepartment.Properties.ReadOnly = true;
                cboUnitType.Properties.ReadOnly = true;
                //cboAssignedTo.Properties.ReadOnly = true;
                txtOTProjectName.Properties.ReadOnly = true;
                txtOTProjectAddress.Properties.ReadOnly = true;
                txtOTProjectCity.Properties.ReadOnly = true;
                txtOTProjectState.Properties.ReadOnly = true;
                txtOTProjectZip.Properties.ReadOnly = true;
                txtBidDate.Properties.ReadOnly = true;
                txtBidTime.Properties.ReadOnly = true;
                txtBidWalkDate.Properties.ReadOnly = true;
                txtBidWalkTime.Properties.ReadOnly = true;
                txtUnits.Properties.ReadOnly = true;
            }
            else
            {
                cboOTProjectStatus.Properties.ReadOnly = false;
                cboWorkType.Properties.ReadOnly = false;
                cboOffice.Properties.ReadOnly = false;
                cboDepartment.Properties.ReadOnly = false;
                cboUnitType.Properties.ReadOnly = false;
                //cboAssignedTo.Properties.ReadOnly = false;
                txtOTProjectName.Properties.ReadOnly = false;
                txtOTProjectAddress.Properties.ReadOnly = false;
                txtOTProjectCity.Properties.ReadOnly = false;
                txtOTProjectState.Properties.ReadOnly = false;
                txtOTProjectZip.Properties.ReadOnly = false;
                txtBidDate.Properties.ReadOnly = false;
                txtBidTime.Properties.ReadOnly = false;
                txtBidWalkDate.Properties.ReadOnly = false;
                txtBidWalkTime.Properties.ReadOnly = false;
                txtUnits.Properties.ReadOnly = false;
            }
        }
        //
        private void UpdateErrorMessages()
        {
            errorMessages = false;
            txtOTProjectName.ErrorText = "";
            txtOTProjectAddress.ErrorText = "";
            txtOTProjectCity.ErrorText = "";
            txtOTProjectState.ErrorText = "";
            txtBidDate.ErrorText = "";
            cboOTProjectStatus.ErrorText = "";
            cboBidWalk.ErrorText = "";
            cboPrequalRequired.ErrorText = "";
            txtElectricalDollar.ErrorText = "";
            txtDescription.ErrorText = "";
            txtOwnerName.ErrorText = "";
            txtGeneralContractorName.ErrorText = "";
            cboWorkType.ErrorText = "";
            cboOffice.ErrorText = "";
            cboDepartment.ErrorText = "";
            cboWorkType.ErrorText = "";
            chkApproved.ErrorText = "";
            chkPApproved.ErrorText = "";
            txtApprovedBy.ErrorText = "";
            txtPApprovedBy.ErrorText = "";

            if (txtOTProjectName.Text.Trim().Length == 0)
            {
                txtOTProjectName.ErrorText = "Project Name is required";
                errorMessages = true;
            }
            if (txtOTProjectAddress.Text.Trim().Length == 0)
            {
                txtOTProjectAddress.ErrorText = "Project Address is required";
                errorMessages = true;
            }
            if (txtOTProjectCity.Text.Trim().Length == 0)
            {
                txtOTProjectCity.ErrorText = "Project City is required";
                errorMessages = true;
            }
            if (txtOTProjectState.Text.Trim().Length == 0)
            {
                txtOTProjectState.ErrorText = "Project State is required";
                errorMessages = true;
            }
            if (txtBidDate.Text.Trim().Length == 0)
            {
                txtBidDate.ErrorText = "Bid Date is required";
                errorMessages = true;
            }
            if (cboBidWalk.Text.Trim().Length == 0)
            {
                cboBidWalk.ErrorText = "Bid Walk is required";
                errorMessages = true;
            }
            if (cboPrequalRequired.Text.Trim().Length == 0)
            {
                cboPrequalRequired.ErrorText = "Prequal Required? is required";
                errorMessages = true;
            }
            if ( String.IsNullOrEmpty(txtElectricalDollar.Text) || Double.Parse(txtElectricalDollar.Text.Replace("(","-").Replace(")","").Replace(",","").Replace("$","")) == 0)
            {
                txtElectricalDollar.ErrorText = "Electrical $ is required";
                errorMessages = true;
            }
            if (txtDescription.Text.Trim().Length == 0)
            {
                txtDescription.ErrorText = "Description is required";
                errorMessages = true;
            }
            if (txtOwnerName.Text.Trim().Length == 0)
            {
                txtOwnerName.ErrorText = "Owner Name is required";
                errorMessages = true;
            }
            if (txtGeneralContractorName.Text.Trim().Length == 0)
            {
                txtGeneralContractorName.ErrorText = "General Contractor Name is required";
                errorMessages = true;
            }
            if (chkForwardForApproval.CheckState == CheckState.Checked || chkApproved.CheckState == CheckState.Checked  || chkPApproved.CheckState == CheckState.Checked)
            {
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

            }
            if (cboOTProjectStatus.Text.Trim().Length == 0)
            {
                cboOTProjectStatus.ErrorText = "Project Status is required";
                errorMessages = true;
            }
            else
            {
                if (cboOTProjectStatus.EditValue.ToString() == "1")
                {
                    if (cboWorkType.Text.Trim().Length == 0)
                    {
                        cboWorkType.ErrorText = "Work Type is required";
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
                  //  if (projectApproval)
                    {
                        if (chkApproved.CheckState != CheckState.Checked || txtApprovedBy.Text.Trim().Length == 0)
                        {
                            chkApproved.ErrorText = "Approval is required";
                            errorMessages = true;
                        }
                    }
                   // else
                   // {
                   //     chkApproved.ErrorText = "Approval is required";
                   //     errorMessages = true;

                    //}
                    //if (projectApproval5Million)
                    {
                        if ((chkPApproved.CheckState != CheckState.Checked || txtPApprovedBy.Text.Trim().Length == 0) &&
                            (String.IsNullOrEmpty(txtElectricalDollar.Text) || Double.Parse(txtElectricalDollar.Text.Replace("(", "-").Replace(")", "").Replace(",", "").Replace("$", "")) >= 5000000))
                        {
                            chkPApproved.ErrorText = "Approval is required";
                            errorMessages = true;
                        }
                    }
                    //else
                   // {
                   //     chkPApproved.ErrorText = "Approval is required";
                   //     errorMessages = true;

                   // }
                }
            }
        }    
        //
        private void cboModel_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
               // cboModel.EditValue = String.Empty;
            } 
        }
        //
        private void txtElectricalDollar_EditValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtElectricalDollar.Text))
                if (Double.Parse(txtElectricalDollar.Text.Replace("(", "-").Replace(")", "").Replace("$", "").Replace(",", "")) >= 5000000)
                    if (chkForwardForApproval.CheckState != CheckState.Checked)
                        chkForwardForApproval.CheckState = CheckState.Checked;
            AllControls_EditValue(sender, e);
        }
        //
        private void ApprovalOverFiveMillionEmail()
        {
            MailMessage message;
            SmtpClient client;
            //
            try
            {
                DataTable table = OTProject.GetApprovalOverFiveMillion(txtRecordID.Text).Tables[0];

                if (table.Rows.Count > 0)
                {
                    message = new MailMessage(
                         "sg3admin@dyna-sd.com",
                         "sg3admin@dyna-sd.com",
                         "Project Opportunity Changes",
                          "");
                    message.To.Clear();
                    foreach (DataRow r in table.Rows)
                    {
                        if (r["UserLANID"].ToString().ToUpper() != Security.Security.LoginID.ToUpper())
                            message.To.Add(r["EMail"].ToString());
                    }

                    message.Body = "The following Project Opportunity requires approval: \n\n" +
                                    "     Project Number: " + txtOTProjectNumber.Text + "\n" +
                                    "     Project Name: " + txtOTProjectName.Text;

                    if (message.To.Count > 0)
                    {
                        client = new SmtpClient("10.1.3.15");
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            message = null;
            client = null;
        }
        //
        private void ApprovalEmail()
        {
            MailMessage message;
            SmtpClient client;
            //
            try
            {
                DataTable table = OTProject.GetApproval(txtRecordID.Text).Tables[0];

                if (table.Rows.Count > 0)
                {
                    message = new MailMessage(
                         "sg3admin@dyna-sd.com",
                         "sg3admin@dyna-sd.com",
                         "Project Opportunity Changes",
                          "");
                    message.To.Clear();
                    foreach (DataRow r in table.Rows)
                    {
                        if (r["UserLANID"].ToString().ToUpper() != Security.Security.LoginID.ToUpper())
                            message.To.Add(r["EMail"].ToString());
                    }

                    message.Body = "The following Project Opportunity requires approval: \n\n" +
                                    "     Project Number: " + txtOTProjectNumber.Text + "\n" +
                                    "     Project Name: " + txtOTProjectName.Text;

                    if (message.To.Count > 0)
                    {
                        client = new SmtpClient("10.1.3.15");
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            message = null;
            client = null;
        }
        //
        private void ChangesEmail()
        {
            MailMessage message;
            SmtpClient client;
            //
            try
            {
                DataTable table = OTProject.GetChangesNotification(txtRecordID.Text).Tables[0];

                if (table.Rows.Count > 0)
                {
                    message = new MailMessage(
                         "sg3admin@dyna-sd.com",
                         "sg3admin@dyna-sd.com",
                         "Project Opportunity Changes",
                          "");
                    message.To.Clear();
                    foreach (DataRow r in table.Rows)
                    {
                        if (r["UserLANID"].ToString().ToUpper() != Security.Security.LoginID.ToUpper())
                            message.To.Add(r["EMail"].ToString());
                    }
                
                    message.Body = "The following Project Opportunity has been changed: \n\n" +
                                    "     Project Number: " + txtOTProjectNumber.Text + "\n" +
                                    "     Project Name: " + txtOTProjectName.Text + "\n\n";

                    // Email Changes ------
                    if (sessionID > 0)
                    {
                        DataTable t = Audit.GetSessionAudit(recordID, sessionID.ToString().Trim()).Tables[0];
                        foreach (DataRow r in t.Rows)
                            message.Body += r["Audit"].ToString() + "\n";

                        sessionID = 0;
                    }
                    //
                    if (message.To.Count > 0)
                    {
                        client = new SmtpClient("10.1.3.15");
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            message = null;
            client = null;
        }
        //
        private void CCEmail()
        {
            MailMessage message;
            SmtpClient client;
            //
            try
            {
                DataTable table = OTProject.GetCCNotification(txtRecordID.Text).Tables[0];

                if (table.Rows.Count > 0)
                {
                    message = new MailMessage(
                         "sg3admin@dyna-sd.com",
                         "sg3admin@dyna-sd.com",
                         "Project Opportunity Changes",
                          "");
                    message.To.Clear();
                    foreach (DataRow r in table.Rows)
                    {
                        if (r["UserLANID"].ToString().ToUpper() != Security.Security.LoginID.ToUpper())
                            message.To.Add(r["EMail"].ToString());
                    }

                    message.Body = "The following Project Opportunity has been Approved: \n\n" +
                                    "     Project Number: " + txtOTProjectNumber.Text + "\n" +
                                    "     Project Name: " + txtOTProjectName.Text;

                    if (message.To.Count > 0)
                    {
                        client = new SmtpClient("10.1.3.15");
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            message = null;
            client = null;
        }
        //
        private void cboOTProjectStatus_EditValueChanged(object sender, EventArgs e)
        {
            txtStatusDate.Text = DateTime.Now.ToShortDateString();
            AllControls_EditValue(sender, e);
        }
        //
        private void UpdateTabStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnGeneral.ButtonStyle      = DevExpress.XtraBars.BarButtonStyle.Default;
            btnDocuments.ButtonStyle    = DevExpress.XtraBars.BarButtonStyle.Default;
            btnWebLinks.ButtonStyle     = DevExpress.XtraBars.BarButtonStyle.Default;
            btnNotes.ButtonStyle        = DevExpress.XtraBars.BarButtonStyle.Default;
            btnAudit.ButtonStyle        = DevExpress.XtraBars.BarButtonStyle.Default;
            btnAssignments.ButtonStyle  = DevExpress.XtraBars.BarButtonStyle.Default;

            currentButtonArg = e;
            currentButtonName = e.Item.Caption;
            UpdateTabStatusByName(currentButtonName);
        }
        //
        private void UpdateTabStatusByName(string tabName)
        {
            switch (tabName)
            {
                case "Project Info.":
                    btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnGeneral.Down = true;
                    tabMaster.SelectedTabPage = pagMasterDetail;
                    break;
                case "Assignments":
                    btnAssignments.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnAssignments.Down = true;
                    tabMaster.SelectedTabPage = pagAssignments;
                    ctlProjectAssignments.OTProjectID = txtRecordID.Text;
                    break;
                case "Documents":
                    btnDocuments.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnDocuments.Down = true;
                    tabMaster.SelectedTabPage = pagDocuments;
                    ctlProjectDocuments.OTProjectID = txtRecordID.Text;
                    break;
                case "Web Links":
                    btnWebLinks.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnWebLinks.Down = true;
                    tabMaster.SelectedTabPage = pagWebLinks;
                    ctlProjectWebLinks.OTProjectID = txtRecordID.Text;
                    break;
                case "Notes":
                    btnNotes.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnNotes.Down = true;
                    tabMaster.SelectedTabPage = pagNotes;
                    ctlProjectNotes.OTProjectID = txtRecordID.Text;
                    break;
                case "Audit":
                    btnAudit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnAudit.Down = true;
                    tabMaster.SelectedTabPage = pagAudit;
                    ctlProjectAudit.OTProjectID = txtRecordID.Text;
                    break;
                default:
                    btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnGeneral.Down = true;
                    tabMaster.SelectedTabPage = pagMasterDetail;
                    break;
            }
        }
        //
        private void chkApproved_EditValueChanged(object sender, EventArgs e)
        {
            ccApproval = true;
            AllControls_EditValue(sender, e);
        }
        //
        private void chkPApproved_EditValueChanged(object sender, EventArgs e)
        {
            ccApproval = true;
            AllControls_EditValue(sender, e);
        }
        //
        private void cboAssignedTo_EditValueChanged(object sender, EventArgs e)
        {
            chkAssignedToAccepted.CheckState = CheckState.Unchecked;
            AllControls_EditValue(sender, e);
        }
        //
        private void Email()
        {
            try
            {
                if (chkForwardForApproval.CheckState == CheckState.Checked)
                {
                    // Start Changes Notification
                    if (changesStatus == true)
                    {
                        ChangesEmail();
                        changesStatus = false;
                    }
                    // The Email Process -- 
                    if (chkForwardForApproval.CheckState == CheckState.Checked && forwardForApprovalStatus == false)
                    {
                        ApprovalEmail();
                        forwardForApprovalStatus = true;
                    }
                    //
                    if (chkApproved.CheckState == CheckState.Checked && approvalStatus == false)
                    {
                        if (Double.Parse(txtElectricalDollar.Text.Replace("(", "-").Replace(")", "").Replace("$", "").Replace(",", "")) >= 5000000 && approvalStatus == false)
                            ApprovalOverFiveMillionEmail();
                        approvalStatus = true;
                    }
                    //
                    if (ccApproval)
                    {
                        CCEmail();
                        ccApproval = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void cboUnitType_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUnitType.Text.Trim() == "")
                txtUnits.Text = null;
            AllControls_EditValue(sender, e);
        }
    }
}