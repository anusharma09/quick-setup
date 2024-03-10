using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using JCCBusinessLayer;
using JCCReports;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CCEJobs.PresentationLayer
{
    public partial class frmPreBidRFI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
        protected string jobID;
        protected BindingSource bindingSource;
        protected bool dataChanged;
        private bool errorMessages = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        protected int defaultRFIContactID;
        protected int defaultFromID;
        private bool changesStatus = false;
        private bool bColumnWidthChanged = false;
        private DataTable documentDataTable;
        private RowObjectEventArgs ee;
        private InitNewRowEventArgs eee;
        private bool isUpdated = false;
        private string errorMessageText = null;

        //
        private enum ClickedButton
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
        public frmPreBidRFI ()
        {
            InitializeComponent();
        }
        //
        public frmPreBidRFI ( string recordID, string otProjectID, BindingSource bindingSource )
        {
            this.recordID = recordID;
            jobID = otProjectID;
            this.bindingSource = bindingSource;
            InitializeComponent();
        }
        //
        private void frmOpportunityRFI_Load ( object sender, EventArgs e )
        {
            try
            {
                Cursor = Cursors.AppStarting;

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
                txtRecordID.DataBindings.Add("text", bindingSource, "PreBidRFIID");
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetOpprotunityRFI();
                }
                else
                {
                    GetOpprotunityRFI();
                    ribbonReport.Visible = true;
                }
                Opacity = 1;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName);
            }
        }
        //
        private void GetOpportunityRFIDetail ( string recordID )
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateOpprotunityRFI(recordID);
                ProtectForm();
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    btnCopy.Enabled = false;
                }
                else
                {
                    btnCopy.Enabled = true;
                }

                Focus();
            }
            else
            {
                radioStatusOpenClosed.SelectedIndex = 0;
                radioCostImpactYesNo.SelectedIndex = 1;
                txtFromPerson.Text = "";
                textToPerson.Text = "";
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
                chkVoid.CheckState = CheckState.Unchecked;
                txtPhoneDiscussionDate.Text = "";
                txtAnswerNeededBy.Text = "";
                txtEmailBody.Text = "";
                UnProtectForm();
            }
            GetDocuments(recordID);
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
        }
        //
        private void ProtectForm ()
        {

        }
        //
        private void UnProtectForm ()
        {

        }
        //
        private void allButtons_ItemClick ( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdDocumentView, "frmRFIDocument");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName); }

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
                        GetOpprotunityRFI();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                        {
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnCopy.Enabled = true;
                        }
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
                        GetOpprotunityRFI();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                        {
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnCopy.Enabled = true;
                        }
                    }
                    break;
                case "&New":
                    if (CheckRFIStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetOpprotunityRFI();
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
                    GetOpprotunityRFI();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                        btnCopy.Enabled = false;
                    }
                    else
                    {
                        btnCopy.Enabled = true;
                    }

                    break;
                case "&Copy":

                    if (MessageBox.Show("Do you want to create a new Revision for the current RFI", CCEOTProjects.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("Are you sure?", CCEOTProjects.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            recordID = "0";
                            txtRecordID.Text = "0";
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
            }
        }
        //
        private bool CheckRFIStatus ( ClickedButton SelectedButton )
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEOTProjects.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveOpportunityRFI();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                        {
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnCopy.Enabled = true;
                        }

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
                            MessageBox.Show("Please make sure to enter all required fields.", CCEOTProjects.CCEApplication.ApplicationName);
                        return false;
                    }
                }
                else
                {
                    bindingSource.CancelEdit();
                    if (SelectedButton == ClickedButton.Save)
                    {
                        return false;
                    }
                    else
                    {
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                        {
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnCopy.Enabled = true;
                        }

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
                {
                    btnCopy.Enabled = false;
                }
                else
                {
                    btnCopy.Enabled = true;
                }

                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveOpportunityRFI ()
        {
            try
            {
                PreBidRFI opportunityRFI = new PreBidRFI(recordID,
                                jobID,
                                txtJobRFINumber.Text,
                                txtJobRFINumberRev.Text,
                                textToPerson.Text,
                                txtRFISubject.Text,
                                txtFromPerson.Text,
                                txtRFIDate.Text,
                                txtRFIText.Text,
                                txtRFIGeneralNumber.Text,
                                chkDesignDetailRequired.Checked.ToString(),
                                txtDiscussedOnPhoneWith.Text,
                                txtPhoneDiscussionDate.Text,
                                txtAnswerNeededBy.Text,
                                radioStatusOpenClosed.SelectedIndex.ToString(),
                                radioCostImpactYesNo.SelectedIndex.ToString(),
                                txtRFIResponse.Text,
                                txtResponseDate.Text,
                                txtResponseBy.Text,
                                txtEmailBody.Text,
                                chkVoid.Checked.ToString(),
                                txtRFIToCompany.Text);
                opportunityRFI.Save();
                if (recordID == "0" || recordID == "")
                {
                    recordID = opportunityRFI.OpportunityRFIID;
                    txtJobRFINumber.Text = opportunityRFI.OpportunityRFINumber;
                    txtJobRFINumberRev.Text = opportunityRFI.OpportunityRFINumberRev;
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
            {
                btnCopy.Enabled = false;
            }
            else
            {
                btnCopy.Enabled = true;
            }
        }
        //
        private void SaveDocuments ()
        {

            try
            {
                Cursor = Cursors.AppStarting;
                PreBidRFIDocument document;
                if (documentDataTable != null)
                {
                    foreach (DataRow r in documentDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                document = new PreBidRFIDocument(
                                                    r["PreBidRFIDocumentID"].ToString(),
                                                    recordID,
                                                    r["Document"].ToString(),
                                                    r["Email"].ToString());
                                document.Save();
                                r["PreBidRFIDocumentID"] = document.OpportunityRFIDocumentID;

                                break;
                            case DataRowState.Deleted:
                                PreBidRFIDocument.Remove(r["PreBidRFIDocumentID"].ToString());
                                break;
                        }
                    }
                }
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName);
            }
        }




        //
        private void GetOpprotunityRFI ()
        {
            GetOpportunityRFIDetail(recordID);
            Text = txtRFISubject.Text;
            SetControlAccess();
        }
        //
        private void ControlValidating ( object sender, CancelEventArgs e )
        {
            UpdateErrorMessages();
        }
        //
        private bool ValidateAllControls ()
        {
            UpdateErrorMessages();
            return !errorMessages;
        }
        //
        private void AllControls_EditValue ( Object sender, EventArgs e )
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
        private void frmServiceTicket_FormClosed ( object sender, FormClosedEventArgs e )
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdDocumentView, "frmRFIDocument");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName); }

            }
            CheckRFIStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus ()
        {
        }
        //
        private void UpdateOpprotunityRFI ( string recordID )
        {
            try
            {
                DataRow r;
                r = PreBidRFI.GetRFI(recordID).Tables[0].Rows[0];

                txtJobRFINumber.Text = r["PreBidRFINumber"].ToString();
                txtJobRFINumberRev.Text = r["PreBidRFINumberRev"].ToString();
                textToPerson.Text = r["RFIToContact"].ToString();
                txtRFISubject.Text = r["RFISubject"].ToString();
                txtFromPerson.Text = r["RFIFrom"].ToString();
                txtRFIDate.EditValue = r["RFIDate"];
                txtRFIText.Text = r["RFIText"].ToString();
                txtRFIGeneralNumber.Text = r["RFIGeneralNumber"].ToString();
                chkDesignDetailRequired.EditValue = r["DesignDetailRequired"];
                chkVoid.EditValue = r["Void"];
                txtDiscussedOnPhoneWith.Text = r["DiscussedOnPhoneWith"].ToString();
                txtPhoneDiscussionDate.EditValue = r["PhoneDiscussionDate"];
                txtAnswerNeededBy.EditValue = r["AnsweredNeededBy"];
                radioStatusOpenClosed.SelectedIndex = r["StatusOpenClosed"].ToString() == "False" ? 0 : 1; ;
                radioCostImpactYesNo.SelectedIndex = r["CostImpactYesNo"].ToString() == "False" ? 0 : 1;
                txtRFIResponse.Text = r["RFIResponse"].ToString();
                txtResponseDate.EditValue = r["ResponseDate"];
                txtResponseBy.Text = r["ResponseBy"].ToString();
                txtEmailBody.Text = r["EmailBody"].ToString();
                txtRFIToCompany.Text = r["RFIToCompany"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName);
            }
        }
        //


        private void UpdateErrorMessages ()
        {
            errorMessages = false;

            textToPerson.ErrorText = "";
            txtRFISubject.ErrorText = "";
            txtFromPerson.ErrorText = "";
            txtRFIDate.ErrorText = "";
            // txtRFIText.ErrorText = "";                        

            if (textToPerson.Text.Trim().Length == 0)
            {
                textToPerson.ErrorText = "RFI To Contact is required";
                errorMessages = true;
            }
            if (txtRFISubject.Text.Trim().Length == 0)
            {
                txtRFISubject.ErrorText = "Subject is required";
                errorMessages = true;
            }
            if (txtFromPerson.Text.Trim().Length == 0)
            {
                txtFromPerson.ErrorText = "From is required";
                errorMessages = true;
            }
            if (txtRFIDate.Text.Trim().Length == 0)
            {
                txtRFIDate.ErrorText = "Date is required";
                errorMessages = true;
            }

            //if (txtRFIText.Text.Trim().Length == 0)
            //{
            //    //  txtRFIText.ErrorText = "Text is required";
            //    errorMessages = true;
            //}

            if (txtRFIText.length <= 1)
            {
                errorMessages = true;
                errorMessageText = " RFI Text is required.";
            }

        }
        private void GetDocuments ( string jobRFIID )
        {
            try
            {
                documentDataTable = PreBidRFIDocument.GetDocuments(jobRFIID).Tables[0];

                grdDocument.DataSource = documentDataTable.DefaultView;
                if (grdDocumentView.Columns["PreBidRFIDocumentID"] != null)
                {
                    grdDocumentView.Columns["PreBidRFIDocumentID"].Visible = false;
                    grdDocumentView.Columns["PreBidRFIID"].Visible = false;
                    grdDocumentView.Columns["Link"].ColumnEdit = repAddPicture;
                    grdDocumentView.Columns["Link"].OptionsColumn.AllowEdit = true;
                    grdDocumentView.Columns["Document"].OptionsColumn.AllowEdit = false;
                }
                grdDocumentView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdDocumentView, "frmRFIDocument");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName);
            }
        }

        private void SetControlAccess ()
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



        private void btnRFISheet_ItemClick ( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {

                Reports.PreBidRFISheet(jobID, recordID);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName); }
        }
        //
        /* private void cboRFIToContact_EditValueChanged(object sender, EventArgs e)
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
         */

        private void btnRFIEmail_ItemClick ( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                if (MessageBox.Show("You are about to Email the RFI. Contine?", CCEOTProjects.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Reports.JobRFIEmail(jobID, recordID);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName); }
        }

        private void grdDocumentView_ColumnWidthChanged ( object sender, ColumnEventArgs e )
        {
            bColumnWidthChanged = true;
        }

        private void grdDocumentView_DoubleClick ( object sender, EventArgs e )
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

        private void grdDocumentView_InitNewRow ( object sender, InitNewRowEventArgs e )
        {
            grdDocumentView.SetRowCellValue(e.RowHandle, grdDocumentView.Columns["Link"],
                "Link");
        }

        private void grdDocumentView_KeyDown ( object sender, KeyEventArgs e )
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
                                PreBidRFIDocument.Remove(r[0].ToString());
                                grdDocumentView.DeleteRow(grdDocumentView.GetSelectedRows()[0]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName);
                            }
                        }
                    }
                }
            }
        }

        private void grdDocumentView_RowUpdated ( object sender, RowObjectEventArgs e )
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

        private void repAddPicture_OpenLink ( object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e )
        {
            string file = "";

            try
            {
                grdDocumentView.SetRowCellValue(grdDocumentView.GetSelectedRows()[0], grdDocumentView.Columns["Link"],
                "Link");

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
                    }
                    else
                    {
                        grdDocumentView.AddNewRow();
                        r = grdDocumentView.GetDataRow(grdDocumentView.GetSelectedRows()[0]);
                        r["Document"] = file;
                    }
                    documentDataTable.Rows.Add(r);
                    grdDocumentView.RefreshRow(grdDocumentView.GetSelectedRows()[0]);
                    grdDocumentView_RowUpdated(sender, ee);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEOTProjects.CCEApplication.ApplicationName);
            }
        }

        private void txtRFIText_OnTextChanged ( object source, EventArgs e )
        {
            UpdateDataChange();
        }

        private void txtRFIResponse_OnTextChanged ( object source, EventArgs e )
        {
            UpdateDataChange();
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