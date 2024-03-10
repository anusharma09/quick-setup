using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using JCCReports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
namespace CCEJobs.PresentationLayer
{
    public partial class frmJobRFI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
        protected string jobID;
        protected BindingSource bindingSource;
        DataTable contact;
        protected bool dataChanged;
        private bool errorMessages = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        protected int defaultRFIContactID;
        protected int defaultFromID;
        private bool        changesStatus = false;
        private bool        bColumnWidthChanged = false;
        private DataTable   documentDataTable;
        private bool isUpdated = false;
        private RowObjectEventArgs ee;

        private string errorMessageText = null;
        //
        enum ClickedButton
        {
            Next,
            Previous,
            Delete,
            New,
            Save,
            Undo,
            Close,
            Copy
        };
        //
        public frmJobRFI()
        {
            InitializeComponent();
        }
        //
        public frmJobRFI(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmJobRFI_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman &&
                    !Security.Security.currentJobReadOnly)
                {
                    // btnSave.Enabled = false;
                    // btnUndo.Enabled = false;
                }
                else
                {

                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly
                        || Security.Security.currentJobReadOnly)
                    {
                        btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnSave.Enabled = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = false;
                    }
                }




                 
                txtRecordID.DataBindings.Add("text", bindingSource, "JobRFIID");
                //
                contact = Contact.GetJobContactForPullDown(jobID).Tables[0]; 
                cboRFIToContact.Properties.DataSource = contact;
                cboRFIToContact.Properties.PopulateColumns();
                cboRFIToContact.Properties.DisplayMember = "Name";
                cboRFIToContact.Properties.ValueMember = "ContactID";
                cboRFIToContact.Properties.ShowHeader = false;
                cboRFIToContact.Properties.Columns[0].Visible = false;
                //
                cboRFIFrom.Properties.DataSource = contact;
                cboRFIFrom.Properties.PopulateColumns();
                cboRFIFrom.Properties.DisplayMember = "Name";
                cboRFIFrom.Properties.ValueMember = "ContactID";
                cboRFIFrom.Properties.ShowHeader = false;
                cboRFIFrom.Properties.Columns[0].Visible = false;
                //
                cboChangeOrderID.Properties.DataSource = JobChangeOrder.GetJobChangeOrdersPullDown(jobID).Tables[0];
                cboChangeOrderID.Properties.PopulateColumns();
                cboChangeOrderID.Properties.DisplayMember = "JobChangeOrderNumber";
                cboChangeOrderID.Properties.ValueMember = "JobChangeOrderID";
                cboChangeOrderID.Properties.ShowHeader = false;
                cboChangeOrderID.Properties.Columns[0].Visible = false;
                // Default values
                defaultRFIContactID = JobDefaultValues.GetJobDefaultRFIContact(jobID);
                defaultFromID = JobDefaultValues.GetJobDefaultFrom(jobID);
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetJobRFI();
                }
                else
                {
                    GetJobRFI();
                    ribbonReport.Visible = true;
                }
                this.Opacity = 1;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetJobRFIDetail(string recordID)
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateJobRFI(recordID);
                ProtectForm();
                  if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                      btnCopy.Enabled = false;
                  else
                      btnCopy.Enabled = true;
                this.Focus();
            }
            else
            {
                radioStatusOpenClosed.SelectedIndex = 0;
                radioCostImpactYesNo.SelectedIndex = 1;
                cboRFIToContact.EditValue = null;
                cboChangeOrderID.EditValue = null;
                cboRFIFrom.EditValue = null;

                txtJobRFINumber.Text = "";
                txtJobRFINumberRev.Text = "";
                txtRFISubject.Text = "";
                txtRFIText.Text = "";
                txtRFIResponse.Text = "";
                txtResponseBy.Text = "";
                txtResponseDate.Text = "";
                txtRFIToCompany.Text = "";
                txtRFIGeneralNumber.Text = "";
                txtRFIDate.Text = "";
                chkDesignDetailRequired.CheckState = CheckState.Unchecked;
                chkDelayingJob.CheckState = CheckState.Unchecked;
                chkVoid.CheckState = CheckState.Unchecked;
                txtPhoneDiscussionDate.Text = "";
                txtAnswerNeededBy.Text = "";
                txtEmailBody.Text = "";
                if (defaultRFIContactID > 0)
                    cboRFIToContact.EditValue = defaultRFIContactID;
                if (defaultFromID > 0)
                    cboRFIFrom.EditValue = defaultFromID;

                UnProtectForm();
            }
            GetDocuments(recordID);
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
        }
        //
        private void ProtectForm()
        {
           
        }
        //
        private void UnProtectForm()
        {
            
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdDocumentView, "frmRFIDocument");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next RFI":
                    if (CheckRFIStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetJobRFI();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                            btnCopy.Enabled = false;
                        else
                            btnCopy.Enabled = true;
                    }
                    break;
                case "Previous RFI":
                    if (CheckRFIStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetJobRFI();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                            btnCopy.Enabled = false;
                        else
                            btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckRFIStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetJobRFI();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckRFIStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetJobRFI();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                        btnCopy.Enabled = false;
                    else
                        btnCopy.Enabled = true;
                    break;
                case "&Copy":
                    if (MessageBox.Show("Do you want to create a new Revision for the current RFI", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo ) == DialogResult.Yes)
                        {
                            recordID = "0";
                            txtRecordID.Text = "0";
                            // txtJobRFINumber.Text = "";
                            txtJobRFINumberRev.Text = "";
                            chkVoid.CheckState = CheckState.Unchecked;
                            ribbonReport.Visible = false;
                            dataChanged = true;
                            btnUndo.Enabled = false;
                            btnCopy.Enabled = false;
                            btnSave.Enabled = true;
                            btnDelete.Enabled = false;
                            UnProtectForm();
                        }
                    }
                    break;
               /* case "&RFI Sheet":
                    try
                    {
                        Reports.Reports.ServiceTicketReport(txtServNumber.Text, siteID);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break; */
            }
        }
        //
        private bool CheckRFIStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveJobRFI();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                            btnCopy.Enabled = false;
                        else
                            btnCopy.Enabled = true;
                        return true;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(errorMessageText))
                        {
                            MessageBox.Show("Please make sure to enter RFI Text field value.", CCEOTProjects.CCEApplication.ApplicationName);
                            errorMessageText = null;
                        }
                        else
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
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                            btnCopy.Enabled = false;
                        else
                            btnCopy.Enabled = true;
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
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    btnCopy.Enabled = false;
                else
                    btnCopy.Enabled = true;
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveJobRFI()
        {
           try
           {
            JobRFI jobRFI = new JobRFI(recordID,
                            jobID,
                            txtJobRFINumber.Text,
                            txtJobRFINumberRev.Text,
                            cboChangeOrderID.EditValue == null ? "" : cboChangeOrderID.EditValue.ToString(),
                            cboRFIToContact.EditValue == null ? "" : cboRFIToContact.EditValue.ToString(),
                            txtRFISubject.Text,
                            cboRFIFrom.EditValue == null ? "" : cboRFIFrom.EditValue.ToString(),
                            txtRFIDate.Text,
                            txtRFIText.Text,
                            txtRFIGeneralNumber.Text,
                            chkDesignDetailRequired.Checked.ToString(),
                            chkDelayingJob.Checked.ToString(),
                            txtDiscussedOnPhoneWith.Text,
                            txtPhoneDiscussionDate.Text,
                            txtAnswerNeededBy.Text,
                            radioStatusOpenClosed.SelectedIndex.ToString(),
                            radioCostImpactYesNo.SelectedIndex.ToString(),
                            txtRFIResponse.Text,
                            txtResponseDate.Text,
                            txtResponseBy.Text,
                            txtEmailBody.Text,
                            chkVoid.Checked.ToString());                                  
                jobRFI.Save();
                if (recordID == "0" || recordID == "")
                {
                    recordID = jobRFI.JobRFIID;
                    txtJobRFINumber.Text = jobRFI.JobRFINumber;
                    txtJobRFINumberRev.Text = jobRFI.JobRFINumberRev;
                }
                
                txtRecordID.Text = recordID;
                SaveDocuments();
                SetControlAccess();

                ProtectForm();
                changesStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                btnCopy.Enabled = false;
            else
                btnCopy.Enabled = true;
        }
        //
        private void SaveDocuments()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                JobRFIDocument  document;
                if (documentDataTable != null)
                {
                    foreach (DataRow r in documentDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                document = new JobRFIDocument(
                                                    r["JobRFIDocumentID"].ToString(),
                                                    recordID,
                                                    r["Document"].ToString(),
                                                    r["Email"].ToString());
                                document.Save();
                                r["JobRFIDocumentID"] = document.JobRFIDocumentID;

                                break;
                            case DataRowState.Deleted:
                                JobRFIDocument.Remove(r["JobRFIDocumentID"].ToString());
                                break;
                        }
                    }
                }
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }




        //
        private void GetJobRFI()
        {
            GetJobRFIDetail(recordID);
            this.Text = txtRFISubject.Text;
            SetControlAccess();
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
              //  string myString = myControl.Text.Trim().ToUpper();

               // if (myString != myControl.Text.Trim())
               //     myControl.Text = myControl.Text.ToString().ToUpper();
            }
            if (!dataChanged)
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                    }
                    else
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
                        btnCopy.Enabled = false;

                    }
                }
            }
        }
        //
        private void frmServiceTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdDocumentView, "frmRFIDocument");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckRFIStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateJobRFI(string recordID)
        {
            try
            {
                DataRow r;
                r = JobRFI.GetRFI(recordID).Tables[0].Rows[0];

                cboChangeOrderID.EditValue                      = r["JobChangeOrderID"];
                txtJobRFINumber.Text                            = r["JobRFINumber"].ToString();
                txtJobRFINumberRev.Text                         = r["JobRFINumberRev"].ToString();
                cboRFIToContact.EditValue                       = r["RFIToContactID"];
                txtRFISubject.Text                              = r["RFISubject"].ToString();
                cboRFIFrom.EditValue                            = r["RFIFromID"];
                txtRFIDate.EditValue                            = r["RFIDate"];
                txtRFIText.Text                                 = r["RFIText"].ToString();
                txtRFIGeneralNumber.Text                        = r["RFIGeneralNumber"].ToString();
                chkDesignDetailRequired.EditValue               = r["DesignDetailRequired"];
                chkDelayingJob.EditValue                        = r["DelayJob"];
                chkVoid.EditValue                               = r["Void"];
                txtDiscussedOnPhoneWith.Text                    = r["DiscussedOnPhoneWith"].ToString();
                txtPhoneDiscussionDate.EditValue                = r["PhoneDiscussionDate"];
                txtAnswerNeededBy.EditValue                     = r["AnsweredNeededBy"];
                radioStatusOpenClosed.SelectedIndex             = r["StatusOpenClosed"].ToString() == "False" ? 0 : 1; ;
                radioCostImpactYesNo.SelectedIndex              = r["CostImpactYesNo"].ToString() == "False" ? 0 : 1;
                txtRFIResponse.Text                             = r["RFIResponse"].ToString();
                txtResponseDate.EditValue                       = r["ResponseDate"];
                txtResponseBy.Text                              = r["ResponseBy"].ToString();
                txtEmailBody.Text                               = r["EmailBody"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
       
 
        private void UpdateErrorMessages()
        {     
            errorMessages = false;

            cboRFIToContact.ErrorText = "";             
            txtRFISubject.ErrorText = "";                     
            cboRFIFrom.ErrorText = "";                     
            txtRFIDate.ErrorText = "";                  
            //txtRFIText.ErrorText = "";                        

            if (cboRFIToContact.Text.Trim().Length == 0)
            {
                cboRFIToContact.ErrorText = "RFI To Contact is required";
                errorMessages = true;
            }
            if (txtRFISubject.Text.Trim().Length == 0)
            {
                txtRFISubject.ErrorText = "Subject is required";
                errorMessages = true;
            }
            if (cboRFIFrom.Text.Trim().Length == 0)
            {
                cboRFIFrom.ErrorText = "From is required";
                errorMessages = true;
            }
            if (txtRFIDate.Text.Trim().Length == 0)
            {
                txtRFIDate.ErrorText = "Date is required";
                errorMessages = true;
            }
            if (txtRFIText.length <= 1)
            {
                errorMessageText = " RFI Text is required.";
                errorMessages = true;
            }
           
        }
        //
        private void GetDocuments(string jobRFIID)
        {
            try
            {
                documentDataTable = JobRFIDocument.GetDocuments(jobRFIID).Tables[0];

                this.grdDocument.DataSource = documentDataTable.DefaultView;
                grdDocumentView.Columns["JobRFIDocumentID"].Visible = false;
                grdDocumentView.Columns["JobRFIID"].Visible = false;
                grdDocumentView.Columns["Link"].ColumnEdit = repAddPicture;
                grdDocumentView.Columns["Link"].OptionsColumn.AllowEdit = true;
                grdDocumentView.Columns["Document"].OptionsColumn.AllowEdit = false;
                grdDocumentView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdDocumentView, "frmRFIDocument");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void SetControlAccess()
        {
            if (recordID == "" || recordID == "0" || Security.Security.currentJobReadOnly)
            {
                grdDocumentView.OptionsBehavior.Editable = false;
                grdDocumentView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    grdDocumentView.OptionsBehavior.Editable = false;
                    grdDocumentView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                }
                else
                {
                    grdDocumentView.OptionsBehavior.Editable = true;
                    grdDocumentView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }

            }
        }



        private void btnRFISheet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               
               Reports.JobRFISheet(jobID, recordID);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
        }
        //
        private void cboRFIToContact_EditValueChanged(object sender, EventArgs e)
        {
            if (cboRFIToContact.EditValue == null || cboRFIToContact.EditValue.ToString().Trim() == "")
            {
                txtRFIToCompany.Text = "";
            }
            else
            {
                int i = 0;
                contact.DefaultView.Sort = "ContactID";
                i = contact.DefaultView.Find(cboRFIToContact.EditValue.ToString());
                if (i != -1)
                    txtRFIToCompany.Text = contact.DefaultView[i][2].ToString();
                else
                    txtRFIToCompany.Text = "";
                
            }

            AllControls_EditValue(sender, e);
        }
        //
        private void btnRFIEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("You are about to Email the RFI. Contine?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Reports.JobRFIEmail(jobID, recordID);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
        }

        private void grdDocumentView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void grdDocumentView_DoubleClick(object sender, EventArgs e)
        {
            string file = "";
            DataRow r = grdDocumentView.GetDataRow(grdDocumentView.GetSelectedRows()[0]);
            if (r != null)
            {
                file = r["Document"].ToString();
                if (file.Trim().Length > 0)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = @file;
                    proc.Start();
                }
               
            }
        }

        private void grdDocumentView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            grdDocumentView.SetRowCellValue(e.RowHandle, grdDocumentView.Columns["Link"],
                (Object)"Link");
        }

        private void grdDocumentView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdDocumentView.GetDataRow(grdDocumentView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("Delete Selected Item?", JCCDailyLog.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                JobRFIDocument.Remove(r[0].ToString());
                                grdDocumentView.DeleteRow(grdDocumentView.GetSelectedRows()[0]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                            }
                        }
                    }
                } 
            }
        }

        private void grdDocumentView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                }
                else
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    //btnCopy.Enabled = false;
                    btnDelete.Enabled = false;

                }
                
            }
        }

        private void repAddPicture_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            string file = "";

            try
            {
                grdDocumentView.SetRowCellValue(grdDocumentView.GetSelectedRows()[0], grdDocumentView.Columns["Link"],
                (Object)"Link");

                openFile.FileName = "";

                openFile.Filter = "All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    file = openFile.FileName.ToString();
                    DataRow r = grdDocumentView.GetDataRow(grdDocumentView.GetSelectedRows()[0]);
                   if (r != null)
                   {
                       r["Document"] = file;
                       //documentDataTable.Rows.Add()
                   }
                   else
                   {
                       grdDocumentView.AddNewRow();
                       r = grdDocumentView.GetDataRow(grdDocumentView.GetSelectedRows()[0]);
                       r["Document"] = file;
                   }
                    grdDocumentView.RefreshRow(grdDocumentView.GetSelectedRows()[0]);
                    grdDocumentView_RowUpdated(sender, ee); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        private void labelControl5_Click ( object sender, EventArgs e )
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtRFIText.Text;
            f.ShowDialog();
            txtRFIText.Text = f.MyText;
            UpdateDataChange();
        }

        private void labelControl9_Click ( object sender, EventArgs e )
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtRFIResponse.Text;
            f.ShowDialog();
            txtRFIResponse.Text = f.MyText;
            UpdateDataChange();
        }
        private void UpdateDataChange ()
        {
            dataChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }
    }
}