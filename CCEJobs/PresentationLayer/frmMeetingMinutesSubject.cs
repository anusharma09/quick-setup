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
    public partial class frmMeetingMinutesSubject : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected bool bColumnWidthChanged = false;
        protected   string recordID;
        protected   string jobID;
        protected   BindingSource bindingSource = new BindingSource();
        protected   bool dataChanged;
        private     bool errorMessages = false;
        protected   DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected   string currentButtonName = "";
        private     bool changesStatus = false;
        private     DataTable meetingMinutesSubjectDetailDataTable;
        private     bool isUpdated = false;
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
        public frmMeetingMinutesSubject()
        {
            InitializeComponent();
        }
        //
        public frmMeetingMinutesSubject(string recordID, string jobID)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            try
            {
                this.bindingSource.DataSource = MeetingMinutesSubject.GetJobMeetingMinutesSubject(jobID).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            InitializeComponent();
        }
        //
        private void frmMeetingMinutesSubject_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly  || Security.Security.currentJobReadOnly)
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false; 
                }
                txtRecordID.DataBindings.Add("text", bindingSource, "MeetingMinutesSubjectID");
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    GetMeetingMinutesSubject();
                }
                else
                {
                    GetMeetingMinutesSubject();
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
        private void GetMeetingMinutesSubjectDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateMeetingMinutesSubject(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtMeetingMinutesSubject.Text = "";
                UnProtectForm();
            }
            GetMeetingMinutesSubjectItems(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
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

            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridMeetingMinutesSubjectView, "frmMeetingMinutesSubject");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }


            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Meeting Minutes Subject":
                    if (CheckMeetingMinutesSubjectStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        GetMeetingMinutesSubject();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Meeting Minutes Subject":
                    if (CheckMeetingMinutesSubjectStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        GetMeetingMinutesSubject();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckMeetingMinutesSubjectStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        GetMeetingMinutesSubject();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckMeetingMinutesSubjectStatus(ClickedButton.Save))
                    {
                    }
                    break;
                case "&Undo":
                    GetMeetingMinutesSubject();
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
            }
        }
        //
        private bool CheckMeetingMinutesSubjectStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveMeetingMinutesSubject();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
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
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveMeetingMinutesSubject()
        {
           try
           {
                MeetingMinutesSubject meetingMinutesSubject = new MeetingMinutesSubject(recordID,
                                        jobID,
                                        txtMeetingMinutesSubject.Text);
                meetingMinutesSubject.Save();

                if (recordID == "0" || recordID == "")
                    GetMeetingMinutesSubjectDefault();
                recordID = meetingMinutesSubject.MeetingMinutesSubjectID;
                txtRecordID.Text = recordID;
                SaveMeetingMinutesSubjectItems();

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
        }
        //
        //
        private void GetMeetingMinutesSubjectDefault()
        {
            try
            {
                meetingMinutesSubjectDetailDataTable = MeetingMinutesTopicDefault.GetMeetingMinutesTopicDefault().Tables[0];

                this.grdMeetingMinutesSubject.DataSource = meetingMinutesSubjectDetailDataTable.DefaultView;

                gridMeetingMinutesSubjectView.Columns["MeetingMinutesTopicID"].Visible = false;
                gridMeetingMinutesSubjectView.Columns["MeetingMinutesSubjectID"].Visible = false;
                gridMeetingMinutesSubjectView.Columns["Topic"].ColumnEdit = repNote;

                foreach (DataRow r in meetingMinutesSubjectDetailDataTable.Rows)
                    r.SetModified();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridMeetingMinutesSubjectView, "frmMeetingMinutesSubject"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetMeetingMinutesSubject()
        {
            GetMeetingMinutesSubjectDetail(recordID);
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
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    //btnCopy.Enabled = false;
                }
            }
        }
        //
        private void frmMeetingMinutesSubject_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridMeetingMinutesSubjectView, "frmMeetingMinutesSubject");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckMeetingMinutesSubjectStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateMeetingMinutesSubject(string recordID)
        {
            try
            {
                DataRow r;
                r = MeetingMinutesSubject.GetMeetingMinutesSubject(recordID).Tables[0].Rows[0];
                txtMeetingMinutesSubject.Text   = r["MeetingMinutesSubject"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            txtMeetingMinutesSubject.ErrorText = "";
            errorMessages = false;
            //
            if (txtMeetingMinutesSubject.Text.Trim() == "")
            {
                txtMeetingMinutesSubject.ErrorText = "Location is Required";
                errorMessages = true;
            }
        }
        //
        private void GetMeetingMinutesSubjectItems(string meetingMinutesSubjectID)
        {
            try
            {
                meetingMinutesSubjectDetailDataTable = MeetingMinutesTopic.GetSubjectMeetingMinutesTopic(meetingMinutesSubjectID).Tables[0];

                this.grdMeetingMinutesSubject.DataSource = meetingMinutesSubjectDetailDataTable.DefaultView;

                gridMeetingMinutesSubjectView.Columns["MeetingMinutesTopicID"].Visible = false;
                gridMeetingMinutesSubjectView.Columns["MeetingMinutesSubjectID"].Visible = false;
                gridMeetingMinutesSubjectView.Columns["Topic"].ColumnEdit = repNote;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridMeetingMinutesSubjectView, "frmMeetingMinutesSubject");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void SetControlAccess()
        {
            if (recordID == "" || recordID == "0")
            {
                gridMeetingMinutesSubjectView.OptionsBehavior.Editable = false;
                gridMeetingMinutesSubjectView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    gridMeetingMinutesSubjectView.OptionsBehavior.Editable = false;
                    gridMeetingMinutesSubjectView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                }
                else
                {
                    gridMeetingMinutesSubjectView.OptionsBehavior.Editable = true;
                    gridMeetingMinutesSubjectView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }

            }
        }
        //
        private void SaveMeetingMinutesSubjectItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                MeetingMinutesTopic meetingMinutesTopic;
                if (meetingMinutesSubjectDetailDataTable != null)
                {
                    foreach (DataRow r in meetingMinutesSubjectDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                meetingMinutesTopic = new MeetingMinutesTopic(
                                                    r["MeetingMinutesTopicID"].ToString(),
                                                    recordID,
                                                    r["Topic"].ToString());
                                meetingMinutesTopic.Save();
                                r["MeetingMinutesTopicID"] = meetingMinutesTopic.MeetingMinutesTopicID;
                                
                                break;
                            case DataRowState.Deleted:
                                MeetingMinutesItem.Remove(r["MeetingMinutesTopicID"].ToString());
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
        private void gridMeetingMinutesSubjectView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void gridMeetingMinutesSubjectView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}