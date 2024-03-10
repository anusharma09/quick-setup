using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCDailyLog.BusinessLayer;
//using JCCDailyLog.Reports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
using System.IO;

namespace JCCDailyLog.PresentationLayer
{
    public partial class frmDailyLog : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
        protected string jobID;
        protected BindingSource bindingSource;
        protected bool dataChanged;
        private bool errorMessages = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        private bool changesStatus = false;
        private string jobNumber = "";
        private bool bColumnWidthChanged;
        private DataTable pictureDataTable;
        private bool isUpdated = false;
        private RowObjectEventArgs ee;
        private string logDate = string.Empty;
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
        public frmDailyLog()
        {
            InitializeComponent();
        }
        //
        public frmDailyLog(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID = recordID;
            this.jobID = jobID;
            this.bindingSource = bindingSource;
            InitializeComponent();
        }
        //
        private void frmDailyLog_Load(object sender, EventArgs e)
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



                if (jobID != "0")
                {
                    lblJobNumber.Visible = false;
                    txtJobNumber.Visible = false;
                }

                txtRecordID.DataBindings.Add("text", bindingSource, "JobDailyLogID");
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    hyperLinkEdit3.Enabled = false;
                    btnDelete.Enabled = false;
                    GetDailyLog();
                }
                else
                {
                    GetDailyLog();
                    ribbonReport.Visible = true;
                    hyperLinkEdit3.Enabled = true;
                    btnDelete.Enabled = true;
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
        private void GetDailyLogDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateDailyLog(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtJobNumber.Text = "";
                txtDailyLogNumber.Text = "";
                txtLogDate.Text = "";
                txtWeatherCondition.Text = "";
                txtNumberOfElectricians.EditValue = null;
                txtRental1.Text = "";
                txtRental2.Text = "";
                txtRental3.Text = "";
                chkInspectionToday.CheckState = CheckState.Unchecked;
                txtInspectionTodayDescription.Text = "";
                chkProgressPicturesTaken.CheckState = CheckState.Unchecked;
                txtProgressPicturesTakenDescription.Text = "";
                chkAccidentOnJob.CheckState = CheckState.Unchecked;
                txtAccidentOnJobDescription.Text = "";
                chkAccidentReportFiled.CheckState = CheckState.Unchecked;
                chkSafetyMeetingToday.CheckState = CheckState.Unchecked;
                txtSafetyMeetingTodayDescription.Text = "";
                chkExtraWorkRequested.CheckState = CheckState.Unchecked;
                txtExtraWorkRequestedDescription.Text = "";
                chkBackChargeRequired.CheckState = CheckState.Unchecked;
                txtBackChargeRequiredDescription.Text = "";
                chkScheduledWorkDelayed.CheckState = CheckState.Unchecked;
                txtScheduledWorkDelayedDescription.Text = "";
                chkDelayCausedByOthers.CheckState = CheckState.Unchecked;
                txtDelayCausedByOthersDescription.Text = "";
                chkDisruptionReportFiled.CheckState = CheckState.Unchecked;
                txtDisruptionReportFiledDescription.Text = "";
                txtProductiveNarrative.Text = "";
                UnProtectForm();
            }
            GetPictures(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
        }
        //
        private void ProtectForm()
        {
            txtJobNumber.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            txtJobNumber.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPictureView, "frmDailyLogPicture");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }


            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "Next Daily Log":
                    if (CheckDailyLogStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        hyperLinkEdit3.Enabled = true;
                        btnDelete.Enabled = true;
                        GetDailyLog();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Daily Log":
                    if (CheckDailyLogStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        hyperLinkEdit3.Enabled = true;
                        btnDelete.Enabled = true;
                        GetDailyLog();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckDailyLogStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        hyperLinkEdit3.Enabled = false;
                        btnDelete.Enabled = false;
                        GetDailyLog();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                    }
                    break;
                case "&Save":                 
                    if (CheckDailyLogStatus(ClickedButton.Save))
                    {
                        btnDelete.Enabled = true;
                        ribbonReport.Visible = true;
                        hyperLinkEdit3.Enabled = true;
                    }
                    break;
                case "&Undo":
                    GetDailyLog();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    btnCopy.Enabled = true;
                    break;

                case "&Delete":
                    if (MessageBox.Show("Are you sure ? You want to delete the daily log.", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteDailyLog();
                        this.Close();
                    }
                    break;
                case "&Copy":
                    recordID = "0";
                    txtRecordID.Text = "0";
                    txtLogDate.Text = "";
                    txtLogDate.EditValue = null;
                    txtDailyLogNumber.Text = "";
                    ribbonReport.Visible = false;
                    hyperLinkEdit3.Enabled = false;
                    dataChanged = true;
                    btnUndo.Enabled = false;
                    btnCopy.Enabled = false;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    UnProtectForm();
                    break;
                case "Daily Log":
                    try
                    {
                        Reports.Reports.DailyLogForm(jobID, recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckDailyLogStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveDailyLog();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                        logDate = txtLogDate.Text;
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
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveDailyLog()
        {
            try
            {
                DailyLog log = new DailyLog(recordID,
                                             jobID,
                                           txtLogDate.Text,
                                           txtWeatherCondition.Text,
                                           txtNumberOfElectricians.EditValue == null ? "" : txtNumberOfElectricians.EditValue.ToString(),
                                           txtRental1.Text,
                                           txtRental2.Text,
                                           txtRental3.Text,
                                           chkInspectionToday.Checked.ToString(),
                                           txtInspectionTodayDescription.Text,
                                           chkProgressPicturesTaken.Checked.ToString(),
                                           txtProgressPicturesTakenDescription.Text,
                                           chkAccidentOnJob.Checked.ToString(),
                                           txtAccidentOnJobDescription.Text,
                                           chkAccidentReportFiled.Checked.ToString(),
                                           chkSafetyMeetingToday.Checked.ToString(),
                                           txtSafetyMeetingTodayDescription.Text,
                                           chkExtraWorkRequested.Checked.ToString(),
                                           txtExtraWorkRequestedDescription.Text,
                                           chkBackChargeRequired.Checked.ToString(),
                                           txtBackChargeRequiredDescription.Text,
                                           chkScheduledWorkDelayed.Checked.ToString(),
                                           txtScheduledWorkDelayedDescription.Text,
                                           chkDelayCausedByOthers.Checked.ToString(),
                                           txtDelayCausedByOthersDescription.Text,
                                           chkDisruptionReportFiled.Checked.ToString(),
                                           txtDisruptionReportFiledDescription.Text,
                                           txtProductiveNarrative.Text);
                log.Save();
                recordID = log.JobDailyLogID;
                txtRecordID.Text = recordID;
                DataRow r = DailyLog.GetDailyLogNumber(recordID).Tables[0].Rows[0];
                txtDailyLogNumber.Text = r["DailyLogNumber"].ToString();
                SavePictures();
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
        }

        private void DeleteDailyLog()
        {
            try
            {
                DailyLog.Remove(recordID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        private void SavePictures()
        {

            try
            {
                grdPictureView.MoveNext();
                this.Cursor = Cursors.AppStarting;
                DailyLogPicture picture;
                if (pictureDataTable != null)
                {
                    foreach (DataRow r in pictureDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                if (!String.IsNullOrEmpty(r["Picture"].ToString()))
                                {
                                      picture = new DailyLogPicture(
                                                        r["JobDailyLogPictureID"].ToString(),
                                                        recordID,
                                                        r["PictureTitle"].ToString(),
                                                        r["Picture"].ToString(),
                                                        "True");
                                    picture.Save();
                                    r["JobDailyLogPictureID"] = picture.JobDailyLogPictureID;
                                }

                                break;
                            case DataRowState.Deleted:
                                //DailyLogPicture.Remove(r["JobDailyLogPictureID"].ToString());
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
        private void GetDailyLog()
        {
            GetDailyLogDetail(recordID);
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
        private void frmDailyLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPictureView, "frmDailyLogPicture");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            CheckDailyLogStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateDailyLog(string recordID)
        {
            try
            {
                DataRow r;
                r = DailyLog.GetDailyLog(recordID).Tables[0].Rows[0];
                // txtJobNumber.Text               = r["JobNumber"].ToString();
                txtDailyLogNumber.Text = r["DailyLogNumber"].ToString();
                txtLogDate.EditValue = r["LogDate"];
                logDate = txtLogDate.Text;
                txtWeatherCondition.Text = r["WeatherCondition"].ToString();
                txtNumberOfElectricians.EditValue = r["NumberOfElectricians"];
                txtRental1.Text = r["Rental1"].ToString();
                txtRental2.Text = r["Rental2"].ToString();
                txtRental3.Text = r["Rental3"].ToString();
                chkInspectionToday.EditValue = r["InspectionToday"];
                txtInspectionTodayDescription.Text = r["InspectionTodayDescription"].ToString();
                chkProgressPicturesTaken.EditValue = r["ProgressPicturesTaken"];
                txtProgressPicturesTakenDescription.Text = r["ProgressPicturesTakenDescription"].ToString();
                chkAccidentOnJob.EditValue = r["AccidentOnJob"];
                txtAccidentOnJobDescription.Text = r["AccidentOnJobDescription"].ToString();
                chkAccidentReportFiled.EditValue = r["AccidentReportFiled"];
                chkSafetyMeetingToday.EditValue = r["SafetyMeetingToday"];
                txtSafetyMeetingTodayDescription.Text = r["SafetyMeetingTodayDescription"].ToString();
                chkExtraWorkRequested.EditValue = r["ExtraWorkRequested"];
                txtExtraWorkRequestedDescription.Text = r["ExtraWorkRequestedDescription"].ToString();
                chkBackChargeRequired.EditValue = r["BackChargeRequired"];
                txtBackChargeRequiredDescription.Text = r["BackChargeRequiredDescription"].ToString();
                chkScheduledWorkDelayed.EditValue = r["ScheduledWorkDelayed"];
                txtScheduledWorkDelayedDescription.Text = r["ScheduledWorkDelayedDescription"].ToString();
                chkDelayCausedByOthers.EditValue = r["DelayedCausedByOthers"];
                txtDelayCausedByOthersDescription.Text = r["DelayedCausedByOthersDescription"].ToString();
                chkDisruptionReportFiled.EditValue = r["DisruptionReportFiled"];
                txtDisruptionReportFiledDescription.Text = r["DisruptionReportFiledDescription"].ToString();
                txtProductiveNarrative.Text = r["ProductiveNarrative"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            txtJobNumber.ErrorText = "";
            txtLogDate.ErrorText = "";

            errorMessages = false;
            //
            /* if (txtJobNumber.Visible)
             {
                 if (recordID == "" || recordID == "0")
                 {
                     if (txtJobNumber.Text.Trim().Length == 0)
                     {
                         txtJobNumber.ErrorText = "Job Number is Required";
                         errorMessages = true;
                     }
                     else
                     {

                         //jobID = EquipmentRental.GetJobID(txtJobNumber.Text.Trim());
                         if (jobID == "0" || jobID == "")
                         {
                             txtJobNumber.ErrorText = "Job does not exist or your access is denied!";
                             errorMessages = true;
                         }
                     }
                 }
             }
             */
            //
            if (txtLogDate.Text.Trim() == "")
            {
                txtLogDate.ErrorText = "Log Date is Requried";
                errorMessages = true;
            }
            else
            {
                //if (recordID == "" || recordID == "0")
                //{

                if (logDate.Trim() != txtLogDate.Text.Trim())
                {
                    if (DailyLog.IsDateUsed(jobID, txtLogDate.Text))
                    {
                        txtLogDate.ErrorText = "A log for this date is in the database";
                        errorMessages = true;
                    }
                }
               //}
            }
            //
        }
        //
        private void GetPictures(string jobDailyLogID)
        {
            try
            {
                pictureDataTable = DailyLogPicture.GetPictures(jobDailyLogID).Tables[0];

                this.grdPicture.DataSource = pictureDataTable.DefaultView;
                grdPictureView.Columns["JobDailyLogPictureID"].Visible = false;
                grdPictureView.Columns["JobDailyLogID"].Visible = false;
                grdPictureView.Columns["Include"].Visible = false;
                grdPictureView.Columns["PictureTitle"].Caption = "Title";
                grdPictureView.Columns["PictureTitle"].ColumnEdit = repPictureTitle;

                grdPictureView.Columns["Pic"].ColumnEdit = repAddPicture;
                grdPictureView.Columns["Pic"].OptionsColumn.AllowEdit = true;
                grdPictureView.Columns["Pic"].Caption = "Add/Edit Attachment";

                grdPictureView.Columns["FileExtension"].Caption = "Attachment Type";
                grdPictureView.Columns["FileExtension"].OptionsColumn.ReadOnly = true;

                grdPictureView.Columns["Picture"].ColumnEdit = repPreviewPicture;
                grdPictureView.Columns["Picture"].OptionsColumn.AllowEdit = true;
                grdPictureView.Columns["Picture"].Caption = "Preview Attachment";

                grdPictureView.Columns["IsDeleted"].ColumnEdit = repDeletePicture;
                //grdPictureView.Columns["IsDeleted"].OptionsColumn.AllowEdit = true;
                grdPictureView.Columns["IsDeleted"].Caption = "Delete Attachment";

                grdPictureView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdPictureView, "frmDailyLogPicture");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        //
        private void SetControlAccess()
        {
            if (recordID == "" || recordID == "0" || Security.Security.currentJobReadOnly)
            {
                grdPictureView.OptionsBehavior.Editable = false;
                grdPictureView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                Edit.Enabled = false;
            }
            else
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    grdPictureView.OptionsBehavior.Editable = true;
                    grdPictureView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    Edit.Enabled = true;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                        grdPictureView.OptionsBehavior.Editable = false;
                        grdPictureView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        Edit.Enabled = false;
                    }
                    else
                    {
                        grdPictureView.OptionsBehavior.Editable = true;
                        grdPictureView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        Edit.Enabled = true;
                    }

                }

            }

        }

        private void grdPictureView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void grdPictureView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
    (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdPictureView.GetDataRow(grdPictureView.GetSelectedRows()[0]);
                    if (r != null)
                    {

                        if (MessageBox.Show("Delete Selected Item?", JCCDailyLog.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(r[0].ToString()))
                                {
                                    DailyLogPicture.Remove(r[0].ToString());
                                }
                                grdPictureView.DeleteRow(grdPictureView.GetSelectedRows()[0]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, JCCDailyLog.CCEApplication.ApplicationName);
                            }
                        }
                    }
                }
            }
        }

        private void grdPictureView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
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
                        //btnCopy.Enabled = false;
                        btnDelete.Enabled = false;

                    }
                }
            }
        }

        private void UploadPics_OpenLink(object sender, EventArgs e)
        {

            string file = "";
     
            try
            {
                openFile.FileName = "";
                this.openFile.Multiselect = true;
                openFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    foreach (var picture in openFile.FileNames)
                    {
                        file = picture.ToString();
                        FileInfo fi = new FileInfo(file);
                        string fileType = Path.GetExtension(fi.Name);
                        if (grdPictureView.GetSelectedRows().Length == 0)
                        {
                            grdPictureView.AddNewRow();
                            DataRow r = grdPictureView.GetDataRow(grdPictureView.GetSelectedRows()[0]);
                            r["Picture"] = file;
                            r["FileExtension"] = getFileType(fileType.Replace(".", ""));
                        }
                        else
                        {
                            DataRow r = grdPictureView.GetDataRow(grdPictureView.GetSelectedRows()[0]);
                            if (r != null && r["Picture"] == null || r != null && String.IsNullOrEmpty(r["Picture"].ToString()))
                            {
                                r["Picture"] = file;
                                r["FileExtension"] = getFileType(fileType.Replace(".", ""));
                            }
                            else
                            {
                                grdPictureView.AddNewRow();
                                DataRow row = grdPictureView.GetDataRow(grdPictureView.GetSelectedRows()[0]);
                                row["Picture"] = file;
                                row["FileExtension"] = getFileType(fileType.Replace(".", ""));
                            }
                        }
                    }
                    grdPictureView.UpdateCurrentRow();

                    grdPictureView.RefreshRow(grdPictureView.GetSelectedRows()[0]);
                    grdPictureView_RowUpdated(sender, ee);
                    this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repAddPicture_OpenLink(object sender, EventArgs e)
        {
            string file = "";

            try
            {
                openFile.FileName = "";
                this.openFile.Multiselect = false;
                openFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    foreach (var picture in openFile.FileNames)
                    {
                        file = picture.ToString();
                        FileInfo fi = new FileInfo(file);
                        string fileType = Path.GetExtension(fi.Name);
                        DataRow r = grdPictureView.GetDataRow(grdPictureView.GetSelectedRows()[0]);
                        if (r != null)
                        {
                            r["Picture"] = file;
                            r["FileExtension"] = getFileType(fileType.Replace(".", ""));
                        }
                        else
                        {
                            grdPictureView.AddNewRow();
                            r = grdPictureView.GetDataRow(grdPictureView.GetSelectedRows()[0]);
                            r["Picture"] = file;
                            r["FileExtension"] = getFileType(fileType.Replace(".", ""));
                        }
                        grdPictureView.RefreshRow(grdPictureView.GetSelectedRows()[0]);
                        grdPictureView_RowUpdated(sender, ee);
                    }
                    grdPictureView.UpdateCurrentRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repDeletePicture_OpenLink(object sender, EventArgs e)
        {
            DataRow r = grdPictureView.GetDataRow(grdPictureView.GetSelectedRows()[0]);
            if (r != null)
            {

                if (MessageBox.Show("Delete Selected Item?", JCCDailyLog.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(r[0].ToString()))
                        {
                            DailyLogPicture.Remove(r[0].ToString());
                        }
                        grdPictureView.DeleteRow(grdPictureView.GetSelectedRows()[0]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, JCCDailyLog.CCEApplication.ApplicationName);
                    }
                }
            }
        }

        private void grdPictureView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            grdPictureView.SetRowCellValue(e.RowHandle, grdPictureView.Columns["Pic"],
                (Object)"Pic");

            grdPictureView.SetRowCellValue(e.RowHandle, grdPictureView.Columns["IsDeleted"],
               (Object)0);
        }

        private void grdPictureView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string file = "";
                DataRow r = grdPictureView.GetDataRow(grdPictureView.GetSelectedRows()[0]);
                if (r != null)
                {
                    file = r["Picture"].ToString();
                    if (file.Trim().Length > 0)
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = @file;
                        proc.Start();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void Note_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtProductiveNarrative.Text;
            f.ShowDialog();
            txtProductiveNarrative.Text = f.MyText;

            if (!dataChanged)
            {
                dataChanged = true;
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private string getFileType(string filename)
        {
            switch(filename.ToLower())
            {
                case "pdf":
                    return "PDF";
                case "jpg":
                    return "IMAGE";
                case "jpeg":
                    return "IMAGE";
                case "png":
                    return "IMAGE";
                case "gif":
                    return "IMAGE";
                case "raw":
                    return "IMAGE";
                case "bmp":
                    return "IMAGE";
                default:
                    return filename;
            }
        }
    }
}