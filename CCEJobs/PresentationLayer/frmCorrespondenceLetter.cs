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
using System.Collections;
namespace CCEJobs.PresentationLayer
{
    public partial class frmCorrespondenceLetter : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected   string recordID;
        protected   string jobID;
        protected   BindingSource bindingSource;
        protected   bool dataChanged;
        private     bool errorMessages = false;
        protected   DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected   string currentButtonName = "";
        private     bool changesStatus = false;
        DataTable contact;
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
        public frmCorrespondenceLetter()
        {
            InitializeComponent();
        }
        //
        public frmCorrespondenceLetter(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmCorrespondenceLetter_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly )
                {
                    btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    Note.Enabled = false;
                }
                txtRecordID.DataBindings.Add("text", bindingSource, "JobCorrespondenceLetterID");
                contact = Contact.GetJobContactForPullDown(jobID).Tables[0];
                cboContact.Properties.DataSource = contact;
                cboContact.Properties.DisplayMember = "Name";
                cboContact.Properties.ValueMember = "ContactID";
                cboContact.Properties.PopulateColumns();
                cboContact.Properties.ShowHeader = false;
                //cboSubcontractor.Properties.Columns[0].Visible = false;

                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetCorrespondenceLetter();
                }
                else
                {
                    GetCorrespondenceLetter();
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
        private void GetCorrespondenceLetterDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateCorrespondenceLetter(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtCorrespondenceLetterDate.EditValue = null;
                cboContact.EditValue = null;
                txtFrom.Text = "";
                txtTitle.Text = "";
                txtCorrespondenceLetterNumber.Text = "";
                txtCorrespondenceLetterDescription.Text = "";
                txtCorrespondenceLetterNote.Text = "";
                rdoCostImpact.SelectedIndex = 0;
                lblSubject.Visible = false;
                txtSubject.Visible = false;
                try
                {
                    DataTable t = JobTransmittal.GetJobDefaultFrom(jobID).Tables[0];
                    if (t.Rows.Count > 0)
                        txtFrom.Text = t.Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                UnProtectForm();
            }
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            if (recordID != "0")
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
            dataChanged = false;
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
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Letter":
                    if (CheckCorrespondenceLetterStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetCorrespondenceLetter();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "Previous Letter":
                    if (CheckCorrespondenceLetterStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetCorrespondenceLetter();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckCorrespondenceLetterStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetCorrespondenceLetter();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckCorrespondenceLetterStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetCorrespondenceLetter();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    //btnCopy.Enabled = true;
                    break;
                /*case "&Copy":
                    recordID = "0";
                    txtRecordID.Text = "0";
                    txtJobRFINumber.Text = "";
                    ribbonReport.Visible = false;
                    dataChanged = true;
                    btnUndo.Enabled = false;
                    btnCopy.Enabled = false;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    UnProtectForm();
                    break;*/
                case "&Delete":
                    if (MessageBox.Show("You are about to delete Correspondence Letter. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                JobCorrespondenceLetter.Remove(txtRecordID.Text);
                                recordID = "0";
                                txtRecordID.Text = "0";
                                ribbonReport.Visible = false;
                                GetCorrespondenceLetter();
                                dataChanged = false;
                                btnUndo.Enabled = false;
                                //btnCopy.Enabled = false;
                                btnSave.Enabled = false;
                                btnDelete.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                            }
                        }
                    }
                    break;
                case "Letter":
                    try
                    {
                        Reports.CorrespondenceLetter(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckCorrespondenceLetterStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveCorrespondenceLetter();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
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
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
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
                //btnCopy.Enabled = true;
                btnDelete.Enabled = true;
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveCorrespondenceLetter()
        {
           try
           {
               JobCorrespondenceLetter letter = new JobCorrespondenceLetter(recordID,
                                   jobID,
                                   cboContact.EditValue == null ? "" : cboContact.EditValue.ToString(),
                                   txtFrom.Text,
                                   txtCorrespondenceLetterDate.Text,
                                   txtCorrespondenceLetterNumber.Text,
                                   txtCorrespondenceLetterDescription.Text,
                                   txtCorrespondenceLetterNote.Text,
                                   rdoCostImpact.SelectedIndex.ToString(),
                                   txtSubject.Text,
                                   txtTitle.Text);
                                   
                letter.Save();

                recordID = letter.JobCorrespondenceLetterID;
                txtRecordID.Text = recordID;
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
            //btnCopy.Enabled = true;
            btnDelete.Enabled = true;
        }
        //
        private void GetCorrespondenceLetter()
        {
            GetCorrespondenceLetterDetail(recordID);
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
          /*  DevExpress.XtraEditors.BaseControl myControl = (DevExpress.XtraEditors.BaseControl)sender;
            if (myControl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
            {
              //  string myString = myControl.Text.Trim().ToUpper();

               // if (myString != myControl.Text.Trim())
               //     myControl.Text = myControl.Text.ToString().ToUpper();
            }*/
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    //btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
        }
        //
        private void frmCorrespondenceLetter_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckCorrespondenceLetterStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateCorrespondenceLetter(string recordID)
        {
            try
            {
                DataRow r;
                r = JobCorrespondenceLetter.GetJobCorrespondenceLetter(recordID).Tables[0].Rows[0];
                cboContact.EditValue                    = r["ContactID"];
                txtFrom.Text                            = r["From"].ToString();
                txtCorrespondenceLetterDate.EditValue   = r["CorrespondenceLetterDate"];
                rdoCostImpact.SelectedIndex             = (int)r["CostImpact"];
                txtCorrespondenceLetterNumber.Text      = r["CorrespondenceLetterNumber"].ToString();
                txtCorrespondenceLetterDescription.Text = r["CorrespondenceLetterDescription"].ToString();
                txtCorrespondenceLetterNote.Text        = r["CorrespondenceLetterNote"].ToString();
                if (rdoCostImpact.SelectedIndex == 2)
                {
                    lblSubject.Visible = true;
                    txtSubject.Visible = true;
                    txtSubject.Text = r["Subject"].ToString();
                }
                else 
                {
                    lblSubject.Visible = false;
                    txtSubject.Visible = false;
                    txtSubject.Text = "";
                }
                txtTitle.Text = r["Title"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            cboContact.ErrorText = "";
            txtFrom.ErrorText = "";
            txtCorrespondenceLetterDate.ErrorText = "";
            txtCorrespondenceLetterNumber.ErrorText = "";
            txtCorrespondenceLetterDescription.ErrorText = "";
            txtSubject.ErrorText = "";

            errorMessages = false;
            //
            if (cboContact.EditValue == null)
            {
                cboContact.ErrorText = "Contact is Required";
                errorMessages = true;
            }
            //
            if (txtFrom.Text.Trim() == "")
            {
                txtFrom.ErrorText = "From is Required";
                errorMessages = true;
            }
            //
            if (txtCorrespondenceLetterDate.Text.Trim() == "")
            {
                txtCorrespondenceLetterDate.ErrorText = "Date is Required";
                errorMessages = true;
            }
            //
            if (txtCorrespondenceLetterNumber.Text.Trim() == "")
            {
                txtCorrespondenceLetterNumber.ErrorText = "Number is Required";
                errorMessages = true;
            }
            //
            if (txtCorrespondenceLetterDescription.Text.Trim() == "")
            {
                txtCorrespondenceLetterDescription.ErrorText = "Description is Required";
                errorMessages = true;
            }
            if (rdoCostImpact.SelectedIndex == 2)
            {
                if (txtSubject.Text.Trim() == "")
                {
                    txtSubject.ErrorText = "Subject is Required";
                    errorMessages = true;
                }
            }
        }
        //
        private void SetControlAccess()
        {
           
        }

        private void cboContact_EditValueChanged(object sender, EventArgs e)
        {
            if (cboContact.EditValue == null || cboContact.EditValue.ToString().Trim() == "")
            {
                txtCompany.Text = "";
            }
            else
            {
                int i = 0;
                contact.DefaultView.Sort = "ContactID";
                i = contact.DefaultView.Find(cboContact.EditValue.ToString());
                if (i != -1)
                    txtCompany.Text = contact.DefaultView[i][2].ToString();
                else
                    txtCompany.Text = "";

            }

            AllControls_EditValue(sender, e);
        }

        private void rdoCostImpact_EditValueChanged(object sender, EventArgs e)
        {
            if (rdoCostImpact.SelectedIndex == 2)
            {
              lblSubject.Visible = true;
              txtSubject.Visible = true;
            }
            else 
            {
                lblSubject.Visible = false;
                txtSubject.Visible = false;
                txtSubject.Text = "";
            }

            AllControls_EditValue(sender, e);
        }

        private void Note_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtCorrespondenceLetterNote.Text;
            f.ShowDialog();
            txtCorrespondenceLetterNote.Text = f.MyText;

            if (!dataChanged)
            {
                dataChanged = true;
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        //
    }
}