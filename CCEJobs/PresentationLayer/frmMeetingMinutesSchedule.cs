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
    public partial class frmMeetingMinutesSchedule : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected bool bColumnWidthChanged = false;
        protected bool bColumnWidthChangedd = false;
        protected   string recordID;
        protected   string jobID;
        protected   BindingSource bindingSource;
        protected   bool dataChanged;
        private     bool errorMessages = false;
        protected   DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected   string currentButtonName = "";
        private     bool changesStatus = false;
        private     DataTable meetingMinutesScheduleDetailDataTable;
        private     DataTable meetingMinutesAttendeeDetailDataTable;
        private     bool isUpdated = false;
        private     RepositoryItemLookUpEdit topics = new RepositoryItemLookUpEdit();
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
        public frmMeetingMinutesSchedule()
        {
            InitializeComponent();
        }
        //
        public frmMeetingMinutesSchedule(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmMeetingMinutesSchedule_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly  || Security.Security.currentJobReadOnly)
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                }
                txtRecordID.DataBindings.Add("text", bindingSource, "MeetingMinutesScheduleID");
                //
                PopulateSubject();
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetMeetingMinutesSchedule();
                }
                else
                {
                    GetMeetingMinutesSchedule();
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
        private void GetMeetingMinutesScheduleDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateMeetingMinutesSchedule(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                cboMeetingMinutesSubject.EditValue = null;
                txtScheduledDate.EditValue = null;
                txtStartTime.EditValue = null;
                txtEndTime.EditValue = null;
                txtLocation.Text = "";
                UnProtectForm();
            }
            GetMeetingMinutesScheduleItems(recordID);
            GetMeetingMinutesAttendee(recordID);
            
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnCopy.Enabled = true;
            btnDelete.Enabled = true;
            dataChanged = false;
            if (recordID != "0")
            {
                btnDelete.Enabled = true;
                btnCopy.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnCopy.Enabled = false;
            }
            dataChanged = false;
        }
        //
        private void ProtectForm()
        {
            cboMeetingMinutesSubject.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            cboMeetingMinutesSubject.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridMeetingMinutesScheduleView, "frmMeetingsSchedule");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            if (bColumnWidthChangedd)
            {
                bColumnWidthChangedd = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdMeetingMinutesAttendeeView, "frmMeetingsScheduleAttendee");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }




            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Meeting Schedule":
                    if (CheckMeetingMinutesScheduleStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetMeetingMinutesSchedule();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "Previous Meeting Schedule":
                    if (CheckMeetingMinutesScheduleStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetMeetingMinutesSchedule();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckMeetingMinutesScheduleStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetMeetingMinutesSchedule();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnCopy.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckMeetingMinutesScheduleStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetMeetingMinutesSchedule();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    btnCopy.Enabled = true;
                    btnDelete.Enabled = true;
                    break;
                case "&Delete":
                    if (MessageBox.Show("You are about to delete the current Meeting Minutes and related Items and Attendees. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("You are sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {

                                MeetingMinutesSchedule.Remove(recordID);
                                recordID = "0";
                                txtRecordID.Text = "0";
                                ribbonReport.Visible = false;
                                GetMeetingMinutesSchedule();
                                dataChanged = false;
                                btnUndo.Enabled = false;
                                btnCopy.Enabled = false;
                                btnSave.Enabled = false;
                                btnDelete.Enabled = false;
                                btnCopy.Enabled = false;
                                btnDelete.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                            }
                        }
                    }
                    break;
                case "&Copy":

                    if (MessageBox.Show("You are about to copy the current Meeting Minutes and related Items and Attendees. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.No)
                    { }
                    else
                    {
                        try
                        {
                            recordID = MeetingMinutesSchedule.CopyMeetingMinutesSchedule(txtRecordID.Text).Tables[0].Rows[0][0].ToString();
                            txtRecordID.Text = recordID;
                            GetMeetingMinutesSchedule();
                            dataChanged = true;
                            btnUndo.Enabled = false;
                            btnCopy.Enabled = false;
                            btnSave.Enabled = true;
                            btnDelete.Enabled = false;
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                    break;
                case "Meeting Minutes":
                    try
                    {
                        Reports.MeetingMinutes(jobID,recordID, cboMeetingMinutesSubject.EditValue == null ? "0" : cboMeetingMinutesSubject.EditValue.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckMeetingMinutesScheduleStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveMeetingMinutesSchedule();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
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
                        btnCopy.Enabled = true;
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
                btnCopy.Enabled = true;
                btnDelete.Enabled = true;
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveMeetingMinutesSchedule()
        {
           try
           {
               MeetingMinutesSchedule meetingMinutesSchedule = new MeetingMinutesSchedule(recordID,
                                        cboMeetingMinutesSubject.EditValue == null ? "" : cboMeetingMinutesSubject.EditValue.ToString(),
                                        txtScheduledDate.Text,
                                        txtStartTime.Text,
                                        txtEndTime.Text,
                                        txtLocation.Text);
               meetingMinutesSchedule.Save();

               recordID = meetingMinutesSchedule.MeetingMinutesScheduleID;
                txtRecordID.Text = recordID;
                SaveMeetingMinutesScheduleItems();
                SaveMeetingMinutesAttendeeItems();

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
            btnCopy.Enabled = true;
            btnDelete.Enabled = true;
        }
        //
        private void GetMeetingMinutesSchedule()
        {
            GetMeetingMinutesScheduleDetail(recordID);
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
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
        }
        //
        private void frmMeetingMinutesSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridMeetingMinutesScheduleView, "frmMeetingsSchedule");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            if (bColumnWidthChangedd)
            {
                bColumnWidthChangedd = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdMeetingMinutesAttendeeView, "frmMeetingsScheduleAttendee");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckMeetingMinutesScheduleStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateMeetingMinutesSchedule(string recordID)
        {
            try
            {
                DataRow r;
                r = MeetingMinutesSchedule.GetMeetingMinutesSchedule(recordID).Tables[0].Rows[0];
                cboMeetingMinutesSubject.EditValue      = r["MeetingMinutesSubjectID"];
                txtScheduledDate.EditValue = String.IsNullOrEmpty(r["ScheduledDate"].ToString()) ? null  : r["ScheduledDate"];
                txtStartTime.Text                       = r["StartTime"].ToString();
                txtEndTime.Text                         = r["EndTime"].ToString();
                txtLocation.Text                        = r["Location"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            cboMeetingMinutesSubject.ErrorText = "";
            txtScheduledDate.ErrorText = "";
            txtStartTime.ErrorText = "";
            txtEndTime.ErrorText = "";
            txtLocation.ErrorText = "";
            errorMessages = false;
            //
            if (cboMeetingMinutesSubject.Text.Trim() == "")
            {
                cboMeetingMinutesSubject.ErrorText = "Meeting Subject is Requried";
                errorMessages = true;
            }
            //
            if (txtScheduledDate.Text.Trim() == "")
            {
                txtScheduledDate.ErrorText = "Scheduled Date is Required";
                errorMessages = true;
            }
            //
            if (txtStartTime.Text.Trim() == "")
            {
                txtStartTime.ErrorText = "Start Time is Required";
                errorMessages = true;
            }
            if (txtEndTime.Text.Trim() == "")
            {
                txtEndTime.ErrorText = "End Time is Required";
                errorMessages = true;
            }
            //
            if (txtLocation.Text.Trim() == "")
            {
                txtLocation.ErrorText = "Location is Required";
                errorMessages = true;
            }
        }
        //
        private void GetMeetingMinutesScheduleItems(string meetingMinutesScheduleID)
        {
            try
            {
                meetingMinutesScheduleDetailDataTable = MeetingMinutesItem.GetScheduleMeetingMinutesItem(meetingMinutesScheduleID, cboMeetingMinutesSubject.EditValue == null ? "0" : cboMeetingMinutesSubject.EditValue.ToString()).Tables[0];
                this.grdMeetingMinutesSchedule.DataSource = meetingMinutesScheduleDetailDataTable.DefaultView;

                gridMeetingMinutesScheduleView.Columns["MeetingMinutesItemID"].Visible = false;
                gridMeetingMinutesScheduleView.Columns["MeetingMinutesScheduleID"].Visible = false;
                //gridMeetingMinutesScheduleView.Columns["No"].Visible = false;
                gridMeetingMinutesScheduleView.Columns["No"].OptionsColumn.AllowEdit = false;


                gridMeetingMinutesScheduleView.Columns["MeetingMinutesTopicID"].ColumnEdit = topics;
                gridMeetingMinutesScheduleView.Columns["Status"].ColumnEdit = repStatus;
                gridMeetingMinutesScheduleView.Columns["MeetingMinutesTopicID"].Caption = "Topic";
                gridMeetingMinutesScheduleView.Columns["MeetingMinutesItemCode"].Caption = "Code";
                gridMeetingMinutesScheduleView.Columns["MeetingMinutesItemCode"].Width = 35;
                gridMeetingMinutesScheduleView.Columns["Action"].Width = 200;
                gridMeetingMinutesScheduleView.Columns["Action"].ColumnEdit = repNote;  
                gridMeetingMinutesScheduleView.Columns["AssignedTo"].Caption = "Assigned To";
                gridMeetingMinutesScheduleView.Columns["AssignmentDate"].Caption = "Assign Date";
                gridMeetingMinutesScheduleView.Columns["StatusDate"].Caption = "Status Date";
                gridMeetingMinutesScheduleView.Columns["CompletionDate"].Caption = "Comp Date";

                gridMeetingMinutesScheduleView.Columns["AssignedTo"].ColumnEdit = repAttendeeList;
                repAttendeeList.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridMeetingMinutesScheduleView, "frmMeetingsSchedule");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetMeetingMinutesAttendee(string meetingMinutesScheduleID)
        {
            try
            {
                meetingMinutesAttendeeDetailDataTable = MeetingMinutesAttendee.GetScheduleMeetingMinutesAttendee(meetingMinutesScheduleID).Tables[0];

                this.grdMeetingMinutesAttendee.DataSource = meetingMinutesAttendeeDetailDataTable.DefaultView;

                repAttendeeList.DataSource = meetingMinutesAttendeeDetailDataTable;
                repAttendeeList.DisplayMember = "Attendee";
                repAttendeeList.ValueMember = "Attendee";
                repAttendeeList.PopulateColumns();
                repAttendeeList.Columns[0].Visible = false;
                repAttendeeList.Columns[1].Visible = false;
                repAttendeeList.Columns[3].Caption = "Required Status";
                repAttendeeList.Columns[4].Visible = false;
                grdMeetingMinutesAttendeeView.Columns["MeetingMinutesAttendeeID"].Visible = false;
                grdMeetingMinutesAttendeeView.Columns["MeetingMinutesScheduleID"].Visible = false;

                grdMeetingMinutesAttendeeView.Columns["Attendee"].ColumnEdit = repAttendee;
                grdMeetingMinutesAttendeeView.Columns["RequiredStatus"].Caption = "Required Status";
                grdMeetingMinutesAttendeeView.Columns["RequiredStatus"].ColumnEdit = repAttendeeStatus;
                grdMeetingMinutesAttendeeView.BestFitColumns();

                /* gridMeetingMinutesScheduleView.Columns["Note"].ColumnEdit = repNote;
                 gridMeetingMinutesScheduleView.Columns["RevisionNumber"].Caption = "Rev No.";
                 gridMeetingMinutesScheduleView.Columns["JobSubmittalStatusID"].ColumnEdit = submittalStatus;
                 gridMeetingMinutesScheduleView.Columns["JobSubmittalStatusID"].Caption = "Status";
                 gridMeetingMinutesScheduleView.Columns["SubmittedDate"].Caption = "Submitted Date";
                 gridMeetingMinutesScheduleView.Columns["ReceivedDate"].Caption = "Received Date";
                 gridMeetingMinutesScheduleView.Columns["RevisionNumber"].OptionsColumn.AllowEdit = false;
                 gridMeetingMinutesScheduleView.BestFitColumns();
                 gridMeetingMinutesScheduleView.Columns["Note"].Width = 300;
                 gridMeetingMinutesScheduleView.Columns["JobSubmittalStatusID"].Width = 150;
                 */
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdMeetingMinutesAttendeeView, "frmMeetingsScheduleAttendee");

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
                gridMeetingMinutesScheduleView.OptionsBehavior.Editable = false;
                gridMeetingMinutesScheduleView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                grdMeetingMinutesAttendeeView.OptionsBehavior.Editable = false;
                grdMeetingMinutesAttendeeView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            }
            else
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    gridMeetingMinutesScheduleView.OptionsBehavior.Editable = false;
                    gridMeetingMinutesScheduleView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    grdMeetingMinutesAttendeeView.OptionsBehavior.Editable = false;
                    grdMeetingMinutesAttendeeView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                }
                else
                {
                    gridMeetingMinutesScheduleView.OptionsBehavior.Editable = true;
                    gridMeetingMinutesScheduleView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    grdMeetingMinutesAttendeeView.OptionsBehavior.Editable = true;
                    grdMeetingMinutesAttendeeView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    gridMeetingMinutesScheduleView.Columns["MeetingMinutesItemCode"].OptionsColumn.AllowEdit = false;
                }
            }
        }
        //
        private void SaveMeetingMinutesScheduleItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                string scheduleID = "";
                MeetingMinutesItem meetingMinutesItem;
                if (meetingMinutesScheduleDetailDataTable != null)
                {
                    foreach (DataRow r in meetingMinutesScheduleDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                scheduleID = "";
                                if (r["MeetingMinutesScheduleID"].ToString().Trim() == "")
                                    scheduleID = recordID;
                                else
                                    scheduleID = r["MeetingMinutesScheduleID"].ToString().Trim();
                                meetingMinutesItem = new MeetingMinutesItem(
                                                    r["MeetingMinutesItemID"].ToString(),
                                                    scheduleID,
                                                    r["MeetingMinutesTopicID"].ToString(),
                                                    r["Action"].ToString(),
                                                    r["AssignedTo"].ToString(),
                                                    r["AssignmentDate"].ToString(),
                                                    r["Status"].ToString(),
                                                    r["StatusDate"].ToString(),
                                                    r["CompletionDate"].ToString());
                                meetingMinutesItem.Save();
                                r["MeetingMinutesItemID"] = meetingMinutesItem.MeetingMinutesItemID;
                                
                                break;
                            case DataRowState.Deleted:
                                MeetingMinutesItem.Remove(r["MeetingMinutesItemID"].ToString());
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
        private void SaveMeetingMinutesAttendeeItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                MeetingMinutesAttendee meetingMinutesAttendee;
                if (meetingMinutesAttendeeDetailDataTable != null)
                {
                    foreach (DataRow r in meetingMinutesAttendeeDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                meetingMinutesAttendee = new MeetingMinutesAttendee(
                                                    r["MeetingMinutesAttendeeID"].ToString(),
                                                    recordID,
                                                    r["Attendee"].ToString(),
                                                    r["RequiredStatus"].ToString(),
                                                    r["Attended"].ToString());
                                meetingMinutesAttendee.Save();
                                r["MeetingMinutesAttendeeID"] = meetingMinutesAttendee.MeetingMinutesAttendeeID;

                                break;
                            case DataRowState.Deleted:
                                MeetingMinutesItem.Remove(r["MeetingMinutesAttendeeID"].ToString());
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
        private void gridMeetingMinutesScheduleView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
        }

        private void cboMeetingMinutesSubject_EditValueChanged(object sender, EventArgs e)
        {
            if (cboMeetingMinutesSubject.EditValue == null)
                return;
            PopulateTopic();
    
            AllControls_EditValue(sender, e);
        }

        private void txtNewSubject_Click(object sender, EventArgs e)
        {
            frmMeetingMinutesSubject f;
            if (cboMeetingMinutesSubject.EditValue == null)
                f = new frmMeetingMinutesSubject("0", jobID);
            else
                f = new frmMeetingMinutesSubject(cboMeetingMinutesSubject.EditValue.ToString(), jobID);
            f.ShowDialog();
            PopulateSubject();
            PopulateTopic();
        }
        //
        private void PopulateSubject()
        {
            try
            {
                cboMeetingMinutesSubject.Properties.DataSource = MeetingMinutesSubject.GetJobMeetingMinutesSubject(jobID).Tables[0];
                cboMeetingMinutesSubject.Properties.PopulateColumns();
                cboMeetingMinutesSubject.Properties.DisplayMember = "MeetingMinutesSubject";
                cboMeetingMinutesSubject.Properties.ValueMember = "MeetingMinutesSubjectID";
                cboMeetingMinutesSubject.Properties.ShowHeader = false;
                cboMeetingMinutesSubject.Properties.Columns["MeetingMinutesSubjectID"].Visible = false;
                cboMeetingMinutesSubject.Properties.Columns["JobID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }

        }
        //
        private void PopulateTopic()
        {
            try
            {
                topics.Columns.Clear();
                if (cboMeetingMinutesSubject.EditValue == null)
                    return;
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                topics.DataSource = MeetingMinutesTopic.GetSubjectMeetingMinutesTopic(cboMeetingMinutesSubject.EditValue.ToString()).Tables[0];
                topics.DisplayMember = "Topic";
                topics.ValueMember = "MeetingMinutesTopicID";
                col.Caption = "ID";
                col.FieldName = "MeetingMinutesTopicID";
                col.Visible = false;
                topics.Columns.Add(col);
                col1.Caption = "Topic";
                col1.FieldName = "Topic";
                col1.Visible = true;
                topics.Columns.Add(col1);
                topics.NullText = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void grdMeetingMinutesAttendeeView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
        }

        private void gridMeetingMinutesScheduleView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    return;
                DataRow r = gridMeetingMinutesScheduleView.GetDataRow(gridMeetingMinutesScheduleView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {
                    if (MessageBox.Show("You are about to delete the Action Item. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                            try
                            {
                                MeetingMinutesItem.Remove(r["MeetingMinutesItemID"].ToString());
                                gridMeetingMinutesScheduleView.DeleteRow(gridMeetingMinutesScheduleView.GetSelectedRows()[0]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                            }
                    }
                }
            }
        }

        private void grdMeetingMinutesAttendeeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    return;
                DataRow r = grdMeetingMinutesAttendeeView.GetDataRow(grdMeetingMinutesAttendeeView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {
                    if (MessageBox.Show("You are about to delete the Attendee. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            MeetingMinutesAttendee.Remove(r["MeetingMinutesAttendeeID"].ToString());
                            grdMeetingMinutesAttendeeView.DeleteRow(grdMeetingMinutesAttendeeView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

        private void gridMeetingMinutesScheduleView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void grdMeetingMinutesAttendeeView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedd = true;
        }
        //
    }
}