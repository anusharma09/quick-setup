using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit;
using JCCBusinessLayer;
using JCCReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CCEJobs.PresentationLayer
{
    public partial class frmEmployee : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
        protected BindingSource bindingSource;
        protected bool dataChanged;
        private bool errorMessages = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        protected int defaultRFIContactID;
        protected int defaultFromID;
        private bool changesStatus = false;
        private bool bColumnWidthChanged = false;

        public string profilePicName = null;
        private string classificationID = "";
        private string terminationID = "";
        private string trainingID = "";
        private string evalID = "";
        private string badgeID = "";
        private string safetyID = "";
        private string attachmentID = "";
        private string defaultPic = CCEApplication.DestinationPicLocation + "DefaultProfilePic.jpg";
        private bool isNew = false;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repCDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repTDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
        private DataTable dtTraining = null;
        private DataTable dtEval = null;
        private DataTable dtBadging = null;
        private DataTable dtSafetyNotes = null;
        private DataTable dtAttachments = null;
        private bool isTrainingToBeUpdated = false;
        private bool isEvalToBeUpdated = false;
        private string queryWhere = string.Empty;
        private bool ssnValidation = false;
        private string terminationReasonMsg = "";
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
        public frmEmployee ()
        {
            InitializeComponent();
        }
        //
        public frmEmployee ( string recordID, BindingSource bindingSource, bool isNew )
        {
            this.recordID = recordID;
            this.bindingSource = bindingSource;
            this.isNew = isNew;
            InitializeComponent();
        }
        //
        private void frmEmployee_Load ( object sender, EventArgs e )
        {
            try
            {
                repCDate.MaxValue = DateTime.Now;
                repTDate.MaxValue = DateTime.Now;
                Cursor = Cursors.AppStarting;
                riPopup.PopupFormMinSize = new Size(500, 300);
                if (Security.Security.UserJCCFieldOperationLevel == Security.Security.AccessLevel.ReadOnly)
                {
                    DisableControl();
                }

                txtRecordID.DataBindings.Add("text", bindingSource, "EmployeeID");

                cboEmployeeStatus.Properties.DataSource = StaticTables.Apprenticeship;
                cboEmployeeStatus.Properties.DisplayMember = "Status";
                cboEmployeeStatus.Properties.ValueMember = "ID";
                cboEmployeeStatus.Properties.PopulateColumns();
                cboEmployeeStatus.Properties.ShowHeader = false;
                cboEmployeeStatus.Properties.Columns[0].Visible = false;

                cboApprenticeship.Properties.DataSource = StaticTables.Apprenticeship;
                cboApprenticeship.Properties.DisplayMember = "Status";
                cboApprenticeship.Properties.ValueMember = "ID";
                cboApprenticeship.Properties.PopulateColumns();
                cboApprenticeship.Properties.ShowHeader = false;
                cboApprenticeship.Properties.Columns[0].Visible = false;

                Employee.ProfilePicDestinationPath = CCEApplication.DestinationPicLocation;
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                Employee.EmployeeId = recordID;
                queryWhere = " WHERE A.EmployeeID = " + recordID;
                if (recordID == "0")
                {
                    GetEmployee();
                    DisableTabPages();
                }
                else
                {
                    GetEmployee();
                    EnableTabPages();
                }
                GetPastClassification();
                GetPastTermination();
                GetEmployeeTrainings(queryWhere);
                GetEmployeeEvaluation();
                GetEmployeeBadging();
                GetSafety();
                GetSafetyAttachments();
                Opacity = 1;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetEmployeeDetail ( string recordID )
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateEmployeeDetail(recordID);
                if (Security.Security.UserJCCFieldOperationLevel == Security.Security.AccessLevel.ReadOnly)
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnCopy.Enabled = true;
                    btnDelete.Enabled = true;
                }

                Focus();
            }
            else
            {
                cboApprenticeship.EditValue = null;
                cboEmployeeStatus.EditValue = null;
                cboColor.SelectedIndex = 0;
                txtlastName.Text = "";
                txtFirstName.Text = "";
                txtMiddleName.Text = "";
                txtNickName.Text = "";
                txtEmailAddress.Text = "";
                txtApprenticeshipLocation.Text = "";
                txtHireDate.Text = "";
                txtPrimaryContact.Text = "";
                txtDynaAssigned.Text = "";
                txtEmployeeNumber.Text = "";
                txtShirtSize.Text = "";
                txtSSn.Text = "";
                txtUnionNumber.Text = "";
                txtCassification.Text = "";
                txtClassificationDate.Text = "";
                txtTurnoutDate.Text = "";
                txtTerminationReason.Text = "";
                txtTerminationDate.Text = "";
                txtGeneralNotes.Text = "";
                pictureBox2.BackColor = Color.Transparent;
                grdClassification.DataSource = null;
                grdTermination.DataSource = null;
                grdTraining.DataSource = null;
                grdEvaluation.DataSource = null;
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
        }
        //
        private void allButtons_ItemClick ( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {

            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "&New":
                    if (ValidateEmployee(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        Employee.EmployeeId = "0";
                        queryWhere = " WHERE A.EmployeeID = " + recordID;
                        isNew = true;
                        pictureBox1.Image = new Bitmap(CCEApplication.DestinationPicLocation + "DefaultProfilePic.jpg");
                        pictureBox1.Tag = CCEApplication.DestinationPicLocation + "DefaultProfilePic.jpg";
                        GetEmployee();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        DisableTabPages();
                    }
                    break;
                case "&Save":
                    ValidateEmployee(ClickedButton.Save);
                    break;
                case "&Undo":
                    GetEmployee();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    if (!isNew)
                    {
                        btnDelete.Enabled = true;
                    }

                    if (Security.Security.UserJCCFieldOperationLevel == Security.Security.AccessLevel.ReadOnly)
                    {
                        btnCopy.Enabled = false;
                    }
                    else
                    {
                        btnCopy.Enabled = true;
                    }
                    break;
                case "&Delete":
                    if (MessageBox.Show("Are you sure you want to delete the employee?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteEmployee();
                    }
                    break;
                case "&Training":
                    try
                    {
                        string query = " WHERE A.EmployeeID= " + recordID;
                        if (txtFrom.Text.Length > 0 && txtTo.Text.Length > 0)
                        {
                            query += " AND (A.TrainingDate BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "')";
                        }
                        else
                        {
                            if (txtFrom.Text.Length > 0)
                            {
                                query += " AND A.TrainingDate = '" + txtFrom.Text + "' ";
                            }

                            if (txtTo.Text.Length > 0)
                            {
                                query += " AND A.TrainingDate = '" + txtTo.Text + "' ";
                            }
                        }
                        Reports.EmployeeTraining(recordID, query);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }

        private void grdClassificationView_InvalidRowException ( object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e )
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdClassificationView_ValidateRow ( object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e )
        {
            bool valid = true;
            string message = "";
            DataRow r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save Past Classification Changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["Classification"].ToString().Trim() == "")
                {
                    message = "Classification is Required ..\n";
                    valid = false;
                }
                if (r["ClassificationDate"].ToString().Trim() == "")
                {
                    message = message + "Classification Date is Required ..\n";
                    valid = false;
                }
                if (valid)
                {
                    UpdateClassification();
                }
                else
                {
                    MessageBox.Show(message, CCEApplication.ApplicationName);
                    e.Valid = false;
                }
            }
            else
            {
                if (r["ClassificationID"] == DBNull.Value)
                {
                    grdClassificationView.DeleteRow(e.RowHandle);
                }

                r.CancelEdit();
            }
        }

        private void grdClassificationView_FocusedRowChanged ( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (grdClassificationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);
                if (r == null)
                {
                    classificationID = "0";
                }
                else
                {
                    classificationID = r["ClassificationID"].ToString();
                }
            }

        }

        private void grdClassificationView_KeyDown ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Classification?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            Classification.Delete(r[0].ToString());
                            grdClassificationView.DeleteRow(grdClassificationView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

        private void grdTerminationView_InvalidRowException ( object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e )
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdTerminationView_ValidateRow ( object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e )
        {
            bool valid = true;
            string message = "";
            DataRow r = grdTerminationView.GetDataRow(grdTerminationView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save Past Termination Changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["Reason"].ToString().Trim() == "")
                {
                    message = "Termination Reason is Required ..\n";
                    valid = false;
                }
                if (r["TerminationDate"].ToString().Trim() == "")
                {
                    message = message + "Termination Date is Required ..\n";
                    valid = false;
                }
                if (valid)
                {
                    UpdateTermination();
                }
                else
                {
                    MessageBox.Show(message, CCEApplication.ApplicationName);
                    e.Valid = false;
                }
            }
            else
            {
                if (r["TerminationID"] == DBNull.Value)
                {
                    grdTerminationView.DeleteRow(e.RowHandle);
                }

                r.CancelEdit();
            }
        }

        private void grdTerminationView_FocusedRowChanged ( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (grdTerminationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdTerminationView.GetDataRow(grdTerminationView.GetSelectedRows()[0]);
                if (r == null)
                {
                    terminationID = "0";
                }
                else
                {
                    terminationID = r["TerminationID"].ToString();
                }
            }

        }

        private void grdTerminationView_KeyDown ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdTerminationView.GetDataRow(grdTerminationView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Termination?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            Termination.Delete(r[0].ToString());
                            grdTerminationView.DeleteRow(grdTerminationView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

       private void grdTerminationView_CustomRowCellEditForEditing ( object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e )
        {
            if (e.CellValue != null)
            {
                if (e.Column.FieldName == "Reason")
                    e.RepositoryItem = riPopup;
            }
        }
        void riPopup_QueryPopUp ( object sender, CancelEventArgs e )
        {
            BaseEdit editor = (BaseEdit)sender;
            richEditControl.Document.RtfText = editor.EditValue.ToString();
        }

        void riPopup_QueryDisplayText ( object sender, QueryDisplayTextEventArgs e )
        {
            e.DisplayText = richEditControl.Document.Text;
        }

        void riPopup_QueryResultValue ( object sender, QueryResultValueEventArgs e )
        {
            e.Value = richEditControl.Document.RtfText;
        }

        private void riPopup_CloseUp ( object sender, CloseUpEventArgs e )
        {
            if (!e.AcceptValue)
            {
                PopupContainerEdit pSender = (PopupContainerEdit)sender;
                RichEditControl rEdit = (RichEditControl)pSender.Properties.PopupControl.Controls[0];
                rEdit.Document.RtfText = e.Value.ToString();
            }
        }
        /*  private void grdTrainingView_ValidateRow ( object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e )
          {
              bool valid = true;
              string message = "";
              DataRow r = grdTrainingView.GetDataRow(grdTrainingView.GetSelectedRows()[0]);

              if (MessageBox.Show("Save Training Details?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
              {
                  // Validate Fields
                  if (r["TrainingDate"].ToString().Trim() == "")
                  {
                      message = "Training date is Required ..\n";
                      valid = false;
                  }
                  if (valid)
                  {
                      UpdateTraining();
                  }
                  else
                  {
                      MessageBox.Show(message, CCEApplication.ApplicationName);
                      e.Valid = false;
                  }
              }
              else
              {
                  if (r["TrainingID"] == DBNull.Value)
                  {
                      grdTrainingView.DeleteRow(e.RowHandle);
                  }

                  r.CancelEdit();
              }
          }
          */
        private void grdTrainingView_FocusedRowChanged ( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (grdTrainingView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdTrainingView.GetDataRow(grdTrainingView.GetSelectedRows()[0]);
                if (r == null)
                {
                    trainingID = "0";
                }
                else
                {
                    trainingID = r["TrainingID"].ToString();
                }
            }

        }

        private void grdTrainingView_KeyDown ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdTrainingView.GetDataRow(grdTrainingView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Training Detail?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            EmployeeTraining.Delete(r["TrainingID"].ToString());
                            grdTrainingView.DeleteRow(grdTrainingView.GetSelectedRows()[0]);
                            if (grdTrainingView.DataRowCount == 0)
                            {
                                btnSaveTraining.Visible = false;
                                btnTrainingCancel.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

        private void grdEvaluationView_FocusedRowChanged ( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (grdEvaluationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdEvaluationView.GetDataRow(grdEvaluationView.GetSelectedRows()[0]);
                if (r == null)
                {
                    evalID = "0";
                }
                else
                {
                    evalID = r["EvaluationID"].ToString();
                }
            }

        }

        private void grdEvaluationView_KeyDown ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdEvaluationView.GetDataRow(grdEvaluationView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Evaluation Detail?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            EmployeeEvaluation.Delete(r["EvaluationID"].ToString());
                            grdEvaluationView.DeleteRow(grdEvaluationView.GetSelectedRows()[0]);
                            if (grdEvaluationView.DataRowCount == 0)
                            {
                                btnEvalSave.Visible = false;
                                btnEvalCancel.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

        private void grdBadgingView_FocusedRowChanged ( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (grdViewBadging.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdViewBadging.GetDataRow(grdViewBadging.GetSelectedRows()[0]);
                if (r == null)
                {
                    badgeID = "0";
                }
                else
                {
                    badgeID = r["BadgeID"].ToString();
                }
            }

        }

        private void grdBadgingView_KeyDown ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdViewBadging.GetDataRow(grdViewBadging.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Badging Detail?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            EmployeeBadging.Delete(r["BadgeID"].ToString());
                            grdViewBadging.DeleteRow(grdViewBadging.GetSelectedRows()[0]);
                            if (grdViewBadging.DataRowCount == 0)
                            {
                                btnBadgingSave.Visible = false;
                                btnbadgingCancel.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

        private void grdSafetyNoteView_FocusedRowChanged ( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (grdSafetyNotesView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdSafetyNotesView.GetDataRow(grdSafetyNotesView.GetSelectedRows()[0]);
                if (r == null)
                {
                    safetyID = "0";
                    grdAttachmemts.Enabled = false;
                }
                else
                {
                    safetyID = r["SafetyNoteID"].ToString();
                    if (!String.IsNullOrEmpty(safetyID))
                    {
                        grdAttachmemts.Enabled = true;
                    }
                }
            }
            GetSafetyAttachments();

        }

        private void grdSafetyNoteView_KeyDown ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdSafetyNotesView.GetDataRow(grdSafetyNotesView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Safety Note Detail?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            EmployeeSafetyNotes.Delete(r["SafetyNoteID"].ToString());
                            grdSafetyNotesView.DeleteRow(grdSafetyNotesView.GetSelectedRows()[0]);
                            GetSafetyAttachments();
                            if (grdSafetyNotesView.DataRowCount == 0)
                            {
                                btnSaftySave.Visible = false;
                                btnSafetyCancel.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

        private void grdAttachmentView_InvalidRowException ( object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e )
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdAttachmentView_ValidateRow ( object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e )
        {
            bool valid = true;
            string message = "";
            DataRow r = grdAttachmemtsView.GetDataRow(grdAttachmemtsView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save Safety Note Attachment Changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["AttachmentName"].ToString().Trim() == "" && r["AttachmentPath"].ToString().Trim() == "")
                {
                    message = "Add attachment document ..\n";
                    valid = false;
                }
                if (valid)
                {
                    SaveSafetyNoteAttachment();
                }
                else
                {
                    MessageBox.Show(message, CCEApplication.ApplicationName);
                    e.Valid = false;
                }
            }
            else
            {
                if (r["AttchmentID"] == DBNull.Value)
                {
                    grdAttachmemtsView.DeleteRow(e.RowHandle);
                }

                r.CancelEdit();
            }
        }

        private void grdAttachmentView_FocusedRowChanged ( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (grdAttachmemtsView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdAttachmemtsView.GetDataRow(grdAttachmemtsView.GetSelectedRows()[0]);
                if (r == null)
                {
                    attachmentID = "0";
                }
                else
                {
                    attachmentID = r["AttchmentID"].ToString();
                }
            }

        }

        private void grdAttachmentView_KeyDown ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdAttachmemtsView.GetDataRow(grdAttachmemtsView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Safety Note attachment?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            SafetyNoteAttachment.Delete(r[0].ToString());
                            grdAttachmemtsView.DeleteRow(grdAttachmemtsView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

        private void repAddAttachment_OpenLink ( object sender, EventArgs e )
        {
            string file = "";

            try
            {
                openFile.FileName = "";
                openFile.Multiselect = false;
                openFile.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF;*.PDF)|*.BMP;*.JPG;*.PNG;*.GIF;*.PDF|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    foreach (string attachment in openFile.FileNames)
                    {
                        file = attachment.ToString();
                        FileInfo fi = new FileInfo(file);
                        string fileType = Path.GetExtension(fi.Name);
                        DataRow r = grdTrainingView.GetDataRow(grdTrainingView.GetSelectedRows()[0]);
                        if (r != null)
                        {
                            r["AttachmentName"] = fi.Name;
                            r["AttachmentPath"] = file;
                        }
                        else
                        {
                            grdTrainingView.AddNewRow();
                            r = grdTrainingView.GetDataRow(grdTrainingView.GetSelectedRows()[0]);
                            r["AttachmentName"] = fi.Name;
                            r["AttachmentPath"] = file;
                        }
                        grdTrainingView.RefreshRow(grdTrainingView.GetSelectedRows()[0]);
                        //grdTrainingView_ValidateRow(sender, ee);
                        // grdTrainingView.ValidateRow += new ValidateRowEventHandler(this.grdTrainingView_ValidateRow);
                    }
                    grdTrainingView.UpdateCurrentRow();
                    btnSaveTraining.Visible = true;
                    btnTrainingCancel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repDeleteAttachment_OpenLink ( object sender, EventArgs e )
        {
            DataRow r = grdTrainingView.GetDataRow(grdTrainingView.GetSelectedRows()[0]);
            if (r != null)
            {

                if (MessageBox.Show("Delete Selected Training Detail?", JCCDailyLog.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(r[0].ToString()))
                        {
                            EmployeeTraining.Delete(r[0].ToString());
                        }
                        grdTrainingView.DeleteRow(grdTrainingView.GetSelectedRows()[0]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, JCCDailyLog.CCEApplication.ApplicationName);
                    }
                }
            }
        }

        private void repPreviewAttachment_Click ( object sender, EventArgs e )
        {
            try
            {
                string file = "";
                DataRow r = grdTrainingView.GetDataRow(grdTrainingView.GetSelectedRows()[0]);
                if (r != null)
                {
                    file = r["AttachmentPath"].ToString();
                    if (file.Trim().Length > 0)
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = @file;
                        proc.Start();
                    }
                    else
                    {
                        MessageBox.Show("There is no attachment attached to preview.");
                    }
                }
                else
                {
                    MessageBox.Show("Please save the attachment to preview.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repEvalAdd_OpenLink ( object sender, EventArgs e )
        {
            string file = "";

            try
            {
                openFile.FileName = "";
                openFile.Multiselect = false;
                openFile.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF;*.PDF)|*.BMP;*.JPG;*.PNG;*.GIF;*.PDF|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    foreach (string attachment in openFile.FileNames)
                    {
                        file = attachment.ToString();
                        FileInfo fi = new FileInfo(file);
                        string fileType = Path.GetExtension(fi.Name);
                        DataRow r = grdEvaluationView.GetDataRow(grdEvaluationView.GetSelectedRows()[0]);
                        if (r != null)
                        {
                            r["AttachmentName"] = fi.Name;
                            r["AttachmentPath"] = file;
                        }
                        else
                        {
                            grdEvaluationView.AddNewRow();
                            r = grdEvaluationView.GetDataRow(grdEvaluationView.GetSelectedRows()[0]);
                            r["AttachmentName"] = fi.Name;
                            r["AttachmentPath"] = file;
                        }
                        grdEvaluationView.RefreshRow(grdEvaluationView.GetSelectedRows()[0]);
                    }
                    grdEvaluationView.UpdateCurrentRow();
                    btnEvalSave.Visible = true;
                    btnEvalCancel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repEvalPreviewAttachment_Click ( object sender, EventArgs e )
        {
            try
            {
                string file = "";
                DataRow r = grdEvaluationView.GetDataRow(grdEvaluationView.GetSelectedRows()[0]);
                if (r != null)
                {
                    file = r["AttachmentPath"].ToString();
                    if (file.Trim().Length > 0)
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = @file;
                        proc.Start();
                    }
                    else
                    {
                        MessageBox.Show("There is no attachment attached to preview.");
                    }
                }
                else
                {
                    MessageBox.Show("Please save the attachment to preview.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repBadgeAdd_OpenLink ( object sender, EventArgs e )
        {
            string file = "";

            try
            {
                openFile.FileName = "";
                openFile.Multiselect = false;
                openFile.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF;*.PDF)|*.BMP;*.JPG;*.PNG;*.GIF;*.PDF|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    foreach (string attachment in openFile.FileNames)
                    {
                        file = attachment.ToString();
                        FileInfo fi = new FileInfo(file);
                        string fileType = Path.GetExtension(fi.Name);
                        DataRow r = grdViewBadging.GetDataRow(grdViewBadging.GetSelectedRows()[0]);
                        if (r != null)
                        {
                            r["AttachmentName"] = fi.Name;
                            r["AttachmentPath"] = file;
                        }
                        else
                        {
                            grdViewBadging.AddNewRow();
                            r = grdViewBadging.GetDataRow(grdViewBadging.GetSelectedRows()[0]);
                            r["AttachmentName"] = fi.Name;
                            r["AttachmentPath"] = file;
                        }
                        grdViewBadging.RefreshRow(grdViewBadging.GetSelectedRows()[0]);
                    }
                    grdViewBadging.UpdateCurrentRow();
                    btnBadgingSave.Visible = true;
                    btnbadgingCancel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repBadgePreviewAttachment_Click ( object sender, EventArgs e )
        {
            try
            {
                string file = "";
                DataRow r = grdViewBadging.GetDataRow(grdViewBadging.GetSelectedRows()[0]);
                if (r != null)
                {
                    file = r["AttachmentPath"].ToString();
                    if (file.Trim().Length > 0)
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = @file;
                        proc.Start();
                    }
                    else
                    {
                        MessageBox.Show("There is no attachment attached to preview.");
                    }
                }
                else
                {
                    MessageBox.Show("Please save the attachment to preview.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repAttachmentAdd_OpenLink ( object sender, EventArgs e )
        {
            string file = "";

            try
            {
                openFile.FileName = "";
                openFile.Multiselect = false;
                openFile.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF;*.PDF)|*.BMP;*.JPG;*.PNG;*.GIF;*.PDF|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    foreach (string attachment in openFile.FileNames)
                    {
                        file = attachment.ToString();
                        FileInfo fi = new FileInfo(file);
                        string fileType = Path.GetExtension(fi.Name);
                        DataRow r = grdAttachmemtsView.GetDataRow(grdAttachmemtsView.GetSelectedRows()[0]);
                        if (r != null)
                        {
                            r["AttachmentName"] = fi.Name;
                            r["AttachmentPath"] = file;
                            updateAttachment(r);
                        }
                        else
                        {
                            grdAttachmemtsView.AddNewRow();
                            r = grdAttachmemtsView.GetDataRow(grdAttachmemtsView.GetSelectedRows()[0]);
                            r["AttachmentName"] = fi.Name;
                            r["AttachmentPath"] = file;
                        }
                        grdAttachmemtsView.RefreshRow(grdAttachmemtsView.GetSelectedRows()[0]);
                    }
                    grdAttachmemtsView.UpdateCurrentRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void repAttachmentPreview_Click ( object sender, EventArgs e )
        {
            try
            {
                string file = "";
                DataRow r = grdAttachmemtsView.GetDataRow(grdAttachmemtsView.GetSelectedRows()[0]);
                if (r != null)
                {
                    file = r["AttachmentPath"].ToString();
                    if (file.Trim().Length > 0)
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = @file;
                        proc.Start();
                    }
                    else
                    {
                        MessageBox.Show("There is no attachment attached to preview.");
                    }
                }
                else
                {
                    MessageBox.Show("Please save the attachment to preview.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void DeleteEmployee ()
        {
            try
            {
                bool status = Employee.Delete();
                if (status)
                {
                    MessageBox.Show("Employee is deleted successfully.");
                    dataChanged = false;
                    Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private bool ValidateEmployee ( ClickedButton SelectedButton )
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveEmployee();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnDelete.Enabled = true;
                        if (Security.Security.UserJCCFieldOperationLevel == Security.Security.AccessLevel.ReadOnly)
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
                        if (!ssnValidation)
                        {
                            MessageBox.Show("Please make sure to enter all required fields.", CCEApplication.ApplicationName);
                        }
                        else
                        {
                            ssnValidation = false;
                        }
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
                        if (Security.Security.UserJCCFieldOperationLevel == Security.Security.AccessLevel.ReadOnly)
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
                if (Security.Security.UserJCCFieldOperationLevel == Security.Security.AccessLevel.ReadOnly)
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
        private void SaveEmployee ()
        {
            try
            {
                string path = "";
                if (pictureBox1.Tag == null)
                {
                    path = defaultPic;
                }
                else
                {
                    path = pictureBox1.Tag.ToString();
                }

                Employee emp = new Employee(txtFirstName.Text,
                            txtlastName.Text,
                            txtMiddleName.Text,
                            txtNickName.Text,
                            txtEmailAddress.Text,
                            cboApprenticeship.EditValue == null ? "" : cboApprenticeship.EditValue.ToString(),
                            txtApprenticeshipLocation.Text,
                            cboEmployeeStatus.EditValue == null ? "" : cboEmployeeStatus.EditValue.ToString(),
                            txtHireDate.Text,
                            txtPrimaryContact.Text,
                            txtDynaAssigned.Text, txtEmployeeNumber.Text,
                            txtSSn.Text,
                            txtShirtSize.Text,
                            txtUnionNumber.Text,
                            txtCassification.Text,
                            txtClassificationDate.Text,
                            txtTurnoutDate.Text,
                            txtTerminationReason.Text,
                            txtTerminationDate.Text,
                            path,
                            txtGeneralNotes.Text,
                            txtApprenticeshipLocation.Text,
                            cboColor.Text);
                emp.Save();
                if (recordID == "0" || recordID == "")
                {
                    recordID = Employee.EmployeeId;
                    EnableTabPages();
                    MessageBox.Show("New Employee is added successfully.");
                }
                else
                {
                    MessageBox.Show("Employee is updated successfully.");
                }
                GetPastClassification();
                GetPastTermination();
                queryWhere = " WHERE A.EmployeeID = " + recordID;
                GetEmployeeTrainings(queryWhere);
                GetEmployeeEvaluation();
                GetEmployeeBadging();
                GetSafety();
                GetSafetyAttachments();
                txtRecordID.Text = recordID;
                changesStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            if (Security.Security.UserJCCFieldOperationLevel == Security.Security.AccessLevel.ReadOnly)
            {
                btnCopy.Enabled = false;
            }
            else
            {
                btnCopy.Enabled = true;
            }
        }

        private void GetEmployee ()
        {
            GetEmployeeDetail(recordID);
        }

        private bool ValidateAllControls ()
        {
            UpdateErrorMessages("SAVE");
            return !errorMessages;
        }
        //
        private void AllControls_EditValue ( Object sender, EventArgs e )
        {
            EnableControl();
        }

        private void TrainingControls_EditValue ( Object sender, EventArgs e )
        {
            btnClear.Visible = true;
        }


        private void grdTrainingView_CellValueChanged ( Object sender, EventArgs e )
        {
            btnSaveTraining.Visible = true;
            btnTrainingCancel.Visible = true;
            isTrainingToBeUpdated = true;
        }

        private void grdEvaluationView_CellValueChanged ( Object sender, EventArgs e )
        {
            btnEvalSave.Visible = true;
            btnEvalCancel.Visible = true;
            isEvalToBeUpdated = true;
        }

        private void grdBadgingView_CellValueChanged ( Object sender, EventArgs e )
        {
            btnbadgingCancel.Visible = true;
            btnBadgingSave.Visible = true;
        }

        private void grdSafetyNoteView_CellValueChanged ( Object sender, EventArgs e )
        {
            btnSafetyCancel.Visible = true;
            btnSaftySave.Visible = true;
        }

        private void EnableControl ()
        {
            if (!dataChanged)
            {
                dataChanged = true;
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
                btnCopy.Enabled = false;
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
                    // Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdDocumentView, "frmRFIDocument");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            ValidateEmployee(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }

        }

        private void UpdateEmployeeDetail ( string recordID )
        {
            try
            {
                DataRow r;
                DataSet ds = Employee.GetEmployeeDetail(Convert.ToInt32(recordID));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    r = Employee.GetEmployeeDetail(Convert.ToInt32(recordID)).Tables[0].Rows[0];
                    int ActiveID = 0;
                    int ApprenticeshipActiveID = 0;
                    if (!string.IsNullOrEmpty(r["IsEmployeeActive"].ToString()))
                    {
                        if (Convert.ToBoolean(r["IsEmployeeActive"]))
                        {
                            ActiveID = 1;
                        }
                        else
                        {
                            ActiveID = 2;
                        }
                    }
                    if (!string.IsNullOrEmpty(r["ApprenticeshipCompleted"].ToString()))
                    {
                        if (Convert.ToBoolean(r["ApprenticeshipCompleted"]))
                        {
                            ApprenticeshipActiveID = 1;
                        }
                        else
                        {
                            ApprenticeshipActiveID = 2;
                        }
                    }

                    string path = "";
                    if (!string.IsNullOrEmpty(r["ProfilePic"].ToString()))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(r["ProfilePic"].ToString());
                        List<string> ls = FieldOperation.searchFile(directoryInfo.Parent.FullName, directoryInfo.Name);
                        if (ls.Count > 0)
                        {
                            path = r["ProfilePic"].ToString();
                        }
                        else
                        {
                            path = defaultPic;
                        }
                    }
                    else
                    {
                        path = defaultPic;
                    }

                    cboApprenticeship.EditValue = ApprenticeshipActiveID;
                    cboEmployeeStatus.EditValue = ActiveID;
                    txtFirstName.Text = r["FirstName"].ToString();
                    txtlastName.Text = r["LastName"].ToString();
                    txtMiddleName.EditValue = r["MiddleName"];
                    txtNickName.Text = r["NickName"].ToString();
                    txtEmailAddress.Text = r["EmailAddress"].ToString();
                    txtPrimaryContact.Text = r["PrimaryContactNumber"].ToString();
                    txtDynaAssigned.Text = r["DynaAssignedPhone"].ToString();
                    txtHireDate.EditValue = r["HireDate"];
                    txtEmployeeNumber.Text = r["DynaEmployeeNumber"].ToString();
                    txtSSn.Text = r["SocialSecurityNumber"].ToString();
                    txtUnionNumber.Text = r["UnionMemberNumber"].ToString();
                    txtTurnoutDate.EditValue = r["TurnOutDate"];
                    pictureBox1.Image = new Bitmap(path);
                    pictureBox1.Tag = path;
                    txtShirtSize.Text = r["ShirtSize"].ToString();
                    txtClassificationDate.EditValue = r["ClassificationDate"];
                    txtCassification.Text = r["Classification"].ToString();
                    txtTerminationDate.EditValue = r["TerminationDate"];
                    txtTerminationReason.Text = r["Reason"].ToString();
                    txtApprenticeshipLocation.Text = r["ApprenticeshipLocation"].ToString();
                    txtGeneralNotes.Text = r["Notes"].ToString();
                    Employee.OldProfilePic = r["ProfilePic"].ToString();
                    if (String.IsNullOrEmpty(r["Color"].ToString()))
                    {
                        cboColor.SelectedIndex = 0;
                    }
                    else
                    {
                        cboColor.Text = r["Color"].ToString();
                    }

                    SetPictureBackgroundColor();
                    Employee.oldClassification = r["Classification"].ToString();
                    Employee.oldTermination = r["Reason"].ToString();
                }
                else
                {
                    MessageBox.Show("Employee does not exists.");
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void UpdateErrorMessages ( string from = "" )
        {
            errorMessages = false;

            // cboRFIToContact.ErrorText = "";             
            txtFirstName.ErrorText = "";
            txtlastName.ErrorText = "";
            txtEmailAddress.ErrorText = "";
            //txtRFIText.ErrorText = "";                        

            if (txtFirstName.Text.Trim().Length == 0)
            {
                txtFirstName.ErrorText = "First name is required.";
                errorMessages = true;
            }
            if (txtlastName.Text.Trim().Length == 0)
            {
                txtlastName.ErrorText = "Last name is required.";
                errorMessages = true;
            }
            if (txtEmailAddress.Text.Trim().Length == 0)
            {
                txtEmailAddress.ErrorText = "Email address is required.";
                errorMessages = true;
            }
            if (txtEmailAddress.Text.Trim().Length == 0)
            {
                txtEmailAddress.ErrorText = "Email address is required.";
                errorMessages = true;
            }
            if (txtEmailAddress.Text.Trim().Length > 0)
            {
                bool isEmail = Regex.IsMatch(txtEmailAddress.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    txtEmailAddress.ErrorText = "Format of email address is not correct.";
                    errorMessages = true;
                }
            }
            if (from == "SAVE")
            {
                if (txtSSn.Text.Trim().Length > 4)
                {
                    bool isSSN = Regex.IsMatch(txtSSn.Text, "^(?!219-09-9999|078-05-1120)(?!666|000|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0{4})\\d{4}$", RegexOptions.IgnoreCase);
                    if (!isSSN)
                    {
                        MessageBox.Show("SSN formate is not correct.");
                        ssnValidation = true;
                        errorMessages = true;
                    }
                }
            }
            if (txtCassification.Text.Trim().Length > 0)
            {
                if (txtClassificationDate.Text.Trim().Length == 0)
                {
                    txtClassificationDate.ErrorText = "Classification Date is required.";
                    errorMessages = true;
                }
            }
            if (txtClassificationDate.Text.Trim().Length > 0)
            {
                if (txtCassification.Text.Trim().Length == 0)
                {
                    txtCassification.ErrorText = "Classification is required.";
                    errorMessages = true;
                }
            }
            if (txtTerminationReason.length > 1)
            {
                if (txtTerminationDate.Text.Trim().Length == 0)
                {
                    txtTerminationDate.ErrorText = "Termination Date is required.";
                    errorMessages = true;
                }
            }
            if (txtTerminationDate.Text.Trim().Length > 0)
            {
                if (txtTerminationReason.length <= 1)
                {
                    MessageBox.Show("Termination reason is required.");
                    ssnValidation = true;
                    errorMessages = true;
                }
            }

            if (cboApprenticeship.Text.Trim().Length == 0)
            {
                cboApprenticeship.ErrorText = "Select apprenticeship completed value.";
                errorMessages = true;
            }
            else
            {
                cboApprenticeship.ErrorText = null;
            }

            if (cboEmployeeStatus.Text.Trim().Length == 0)
            {
                cboEmployeeStatus.ErrorText = "Select employee status.";
                errorMessages = true;
            }
            else
            {
                cboEmployeeStatus.ErrorText = null;
            }
        }

        private void UpdateDataChange ()
        {
            dataChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                pictureBox1.Tag = opnfd.FileName;
                profilePicName = opnfd.FileName;
                EnableControl();
            }
        }

        private void GetPastClassification ()
        {
            grdClassification.DataSource = Employee.GetPastClassification().Tables[0];

            grdClassificationView.Columns["Classification"].ColumnEdit = repClassification;
            //grdClassificationView.Columns["Assigned By"].ColumnEdit = repAddedBy;
            grdClassificationView.Columns["Classification"].Width = 600;
            grdClassificationView.Columns["ClassificationDate"].ColumnEdit = repCDate;
            grdClassificationView.Columns["ClassificationDate"].Width = 100;
            grdClassificationView.Columns["ClassificationID"].Visible = false;
        }

        private void GetPastTermination ()
        {
           // RepositoryItem editorForRichEditDisplay = new RepositoryItemRichTextEdit();
          //  grdTermination.RepositoryItems.Add(editorForRichEditDisplay);
            grdTermination.DataSource = Employee.GetPastTermination().Tables[0];

            grdTerminationView.Columns["Reason"].ColumnEdit = repTerminationReason; //repTermination;
            grdTerminationView.Columns["Reason"].Width = 600;
            grdTerminationView.Columns["TerminationDate"].ColumnEdit = repTDate;
            grdTerminationView.Columns["TerminationDate"].Width = 100;
            grdTerminationView.Columns["TerminationID"].Visible = false;
        }

        private void GetEmployeeTrainings ( string where )
        {
            dtTraining = Employee.GetEmployeeTrainingData(where).Tables[0];
            grdTraining.DataSource = dtTraining;
            grdTrainingView.Columns["TrainingDescription"].ColumnEdit = repTrainingDesc;
            grdTrainingView.Columns["AttachmentName"].ColumnEdit = repAttachmentName;
            grdTrainingView.Columns["AddAttachment"].ColumnEdit = repAddAttachment;
            grdTrainingView.Columns["Preview"].ColumnEdit = repPreviewAttachment;
            grdTrainingView.Columns["HoursOfTraining"].ColumnEdit = txtHours;
            grdTrainingView.Columns["HoursOfTraining"].Caption = "Hours";
            grdTrainingView.Columns["TrainingID"].Visible = false;
            grdTrainingView.Columns["num_row"].Visible = false;
            grdTrainingView.Columns["EmployeeName"].Visible = false;
            grdTrainingView.Columns["DynaEmployeeNumber"].Visible = false;

            grdTrainingView.Columns["TrainingDescription"].Width = 180;
            grdTrainingView.Columns["AttachmentPath"].Width = 200;
            grdTrainingView.Columns["AttachmentName"].Width = 100;
            grdTrainingView.Columns["ExpirationDate"].Caption = "Exp. Date";
            grdTrainingView.Columns["ExpirationDate"].Width = 60;
            grdTrainingView.Columns["HoursOfTraining"].Width = 45;
            grdTrainingView.Columns["AttachmentPath"].OptionsColumn.AllowEdit = false;
        }

        private void GetEmployeeEvaluation ()
        {
            dtEval = Employee.GetEmployeeEvaluationData(recordID).Tables[0];
            grdEvaluation.DataSource = dtEval;
            grdEvaluationView.Columns["Classification"].ColumnEdit = repNotes;
            grdEvaluationView.Columns["AttachmentName"].ColumnEdit = repEvalAttachment;
            grdEvaluationView.Columns["Comments"].ColumnEdit = repEvalComments;
            grdEvaluationView.Columns["AddAttachment"].ColumnEdit = repEvalAdd;
            grdEvaluationView.Columns["Preview"].ColumnEdit = repEvalPreviewAttachment;
            grdEvaluationView.Columns["EvaluationID"].Visible = false;

            grdEvaluationView.Columns["EvaluationDate"].Caption = "Date";
            grdEvaluationView.Columns["Comments"].Width = 200;
            grdEvaluationView.Columns["AttachmentPath"].Width = 200;
            grdEvaluationView.Columns["AttachmentName"].Width = 100;
            grdEvaluationView.Columns["AttachmentPath"].OptionsColumn.AllowEdit = false;
        }

        private void GetEmployeeBadging ()
        {
            dtBadging = Employee.GetEmployeeBadgingData(recordID).Tables[0];
            grdBadging.DataSource = dtBadging;
            grdViewBadging.Columns["BadgeType"].ColumnEdit = repBadgeType;
            grdViewBadging.Columns["AttachmentName"].ColumnEdit = repBadgeAttachment;
            grdViewBadging.Columns["Notes"].ColumnEdit = repBadgeNotes;
            grdViewBadging.Columns["AddAttachment"].ColumnEdit = repBadgeAdd;
            grdViewBadging.Columns["Preview"].ColumnEdit = repBadgePreview;
            grdViewBadging.Columns["BadgeID"].Visible = false;

            grdViewBadging.Columns["ExpirationDate"].Caption = "Exp. Date";
            grdViewBadging.Columns["Notes"].Width = 200;
            grdViewBadging.Columns["AttachmentPath"].Width = 100;
            grdViewBadging.Columns["AttachmentName"].Width = 100;
            grdViewBadging.Columns["AttachmentPath"].OptionsColumn.AllowEdit = false;
        }

        private void GetSafety ()
        {
            try
            {
                dtSafetyNotes = Employee.GetEmployeeSafetyNotesData(recordID).Tables[0];
                grdSafetyNotes.DataSource = dtSafetyNotes;

                grdSafetyNotesView.Columns["Comments"].ColumnEdit = repSafetyComments;
                grdSafetyNotesView.Columns["SafetyNoteID"].Visible = false;

                RepositoryItemLookUpEdit riComboBox = new RepositoryItemLookUpEdit();
                riComboBox.DataSource = StaticTables.Type_Injury;
                riComboBox.DisplayMember = "Type";
                riComboBox.ValueMember = "Type";
                riComboBox.PopulateColumns();
                riComboBox.ShowHeader = false;
                riComboBox.Columns[0].Visible = false;
                riComboBox.NullText = string.Empty;
                grdSafetyNotes.RepositoryItems.Add(riComboBox);

                RepositoryItemLookUpEdit riComboBoxDoctorNote = new RepositoryItemLookUpEdit();
                riComboBoxDoctorNote.DataSource = StaticTables.Apprenticeship;
                riComboBoxDoctorNote.DisplayMember = "Status";
                riComboBoxDoctorNote.ValueMember = "Status";
                riComboBoxDoctorNote.PopulateColumns();
                riComboBoxDoctorNote.ShowHeader = false;
                riComboBoxDoctorNote.Columns[0].Visible = false;
                riComboBoxDoctorNote.NullText = string.Empty;
                grdSafetyNotes.RepositoryItems.Add(riComboBoxDoctorNote);

                grdSafetyNotesView.Columns["InjuryType"].ColumnEdit = riComboBox;
                grdSafetyNotesView.Columns["DoctorNotes"].ColumnEdit = riComboBoxDoctorNote;
                grdSafetyNotesView.Columns["InjuryType"].Caption = "Type of Injury";
                grdSafetyNotesView.Columns["Comments"].Width = 450;
                grdSafetyNotesView.Columns["InjuryType"].Width = 100;
                grdSafetyNotesView.Columns["DoctorNotes"].Width = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetSafetyAttachments ()
        {
            try
            {
                string noteID = "0";
                if (grdSafetyNotesView.DataRowCount > 0)
                {
                    DataRow r = grdSafetyNotesView.GetDataRow(grdSafetyNotesView.GetSelectedRows()[0]);
                    if (r == null)
                    {
                        noteID = "0";
                    }
                    else
                    {
                        noteID = r["SafetyNoteID"].ToString();
                    }
                }

                dtAttachments = Employee.GetEmployeeSafetyNotesAttachments(String.IsNullOrEmpty(noteID) ? "0" : noteID).Tables[0];
                grdAttachmemts.DataSource = dtAttachments;
                grdAttachmemtsView.Columns["AttachmentName"].ColumnEdit = repSafetyAttachmentName;
                grdAttachmemtsView.Columns["AttachmentPath"].ColumnEdit = repSafetyPath;
                grdAttachmemtsView.Columns["AddAttachment"].ColumnEdit = repSafetyAdd;
                grdAttachmemtsView.Columns["Preview"].ColumnEdit = repSafetyPreview;
                grdAttachmemtsView.Columns["AttchmentID"].Visible = false;
                grdAttachmemtsView.Columns["AttachmentPath"].OptionsColumn.AllowEdit = false;

                grdAttachmemtsView.Columns["AttachmentPath"].Width = 300;
                grdAttachmemtsView.Columns["AttachmentName"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateClassification ()
        {
            if (grdClassificationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);
                Cursor = Cursors.AppStarting;
                if (r == null)
                {
                    return;
                }

                try
                {
                    Classification classif = new Classification(r["Classification"].ToString(),
                                        r["ClassificationDate"].ToString(),
                                        r["ClassificationID"].ToString(),
                                       recordID);
                    classif.Save();
                    classificationID = classif.ClassificationID;
                    Cursor = Cursors.Default;
                    r["ClassificationID"] = classificationID;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }

        private void UpdateTermination ()
        {
            if (grdTerminationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdTerminationView.GetDataRow(grdTerminationView.GetSelectedRows()[0]);
                Cursor = Cursors.AppStarting;
                if (r == null)
                {
                    return;
                }

                try
                {
                    Termination term = new Termination(r["Reason"].ToString(),
                                        r["TerminationDate"].ToString(),
                                        r["TerminationID"].ToString(),
                                       recordID);
                    term.Save();
                    terminationID = term.TerminationID;
                    Cursor = Cursors.Default;
                    r["TerminationID"] = terminationID;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }

        private void DisableTabPages ()
        {
            xtraTabPage1.PageEnabled = false;
            xtraTabPage2.PageEnabled = false;
            xtraTabPage3.PageEnabled = false;
            xtraTabPage5.PageEnabled = false;
            xtraTabPage6.PageEnabled = false;
            xtraTabPage7.PageEnabled = false;
        }

        private void EnableTabPages ()
        {
            xtraTabPage1.PageEnabled = true;
            xtraTabPage2.PageEnabled = true;
            xtraTabPage3.PageEnabled = true;
            xtraTabPage5.PageEnabled = true;
            xtraTabPage6.PageEnabled = true;
            xtraTabPage7.PageEnabled = true;
        }

        private void cboColor_SelectedIndexChanged ( object sender, EventArgs e )
        {
            SetPictureBackgroundColor();
        }

        private void SetPictureBackgroundColor ()
        {
            try
            {
                switch (cboColor.Text.ToString())
                {
                    case "RED":
                        pictureBox2.BackColor = Color.Red;
                        break;
                    case "GREEN":
                        pictureBox2.BackColor = Color.Green;
                        break;
                    case "YELLOW":
                        pictureBox2.BackColor = Color.Yellow;
                        break;
                    case "NONE":
                        pictureBox2.BackColor = Color.Transparent;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DisableControl ()
        {
            try
            {
                btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSave.Enabled = false;
                btnUndo.Enabled = false;
                btnCopy.Enabled = false;
                button1.Enabled = false;
                cboColor.Enabled = false;
                cboApprenticeship.Enabled = false;
                txtApprenticeshipLocation.Enabled = false;
                txtlastName.Enabled = false;
                txtFirstName.Enabled = false;
                txtMiddleName.Enabled = false;
                txtNickName.Enabled = false;
                txtEmailAddress.Enabled = false;
                txtPrimaryContact.Enabled = false;
                txtDynaAssigned.Enabled = false;
                txtHireDate.Enabled = false;
                txtCassification.Enabled = false;
                txtClassificationDate.Enabled = false;
                txtEmployeeNumber.Enabled = false;
                txtSSn.Enabled = false;
                txtUnionNumber.Enabled = false;
                txtShirtSize.Enabled = false;
                txtTurnoutDate.Enabled = false;
                cboEmployeeStatus.Enabled = false;
                txtTerminationDate.Enabled = false;
                txtTerminationReason.Enabled = false;
                txtGeneralNotes.Enabled = false;
                grdClassification.Enabled = false;
                grdTermination.Enabled = false;
                btnEvalSave.Enabled = false;
                btnSaveTraining.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void SaveTrainings ()
        {
            try
            {
                grdTrainingView.MoveNext();
                Cursor = Cursors.AppStarting;
                EmployeeTraining training = null;
                bool dataChangedT = false;
                bool noDataT = false;
                int rowsUpdatedCount = 0;
                if (dtTraining != null)
                {
                    if (MessageBox.Show("Are you sure you want to save the Training details?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (DataRow r in dtTraining.Rows)
                        {
                            // Update Record
                            switch (r.RowState)
                            {
                                case DataRowState.Added:
                                case DataRowState.Modified:
                                    training = new EmployeeTraining(r["TrainingDescription"].ToString(),
                                                r["AttachmentName"].ToString(),
                                                r["TrainingDate"].ToString(),
                                                r["ExpirationDate"].ToString(),
                                                r["AttachmentPath"].ToString(),
                                                recordID,
                                                r["TrainingID"].ToString(),
                                                r["HoursOfTraining"].ToString());
                                    if (r["TrainingDescription"].ToString().Trim() == "" && r["AttachmentName"].ToString().Trim() == "" && r["TrainingDate"].ToString().Trim() == ""
                                        && r["ExpirationDate"].ToString().Trim() == "" && r["AttachmentPath"].ToString().Trim() == "" && r["HoursOfTraining"].ToString().Trim() == "")
                                    {
                                        noDataT = true;
                                    }

                                    else
                                    {
                                        dataChangedT = true;
                                        training.Save();
                                        trainingID = training.TrainingID;
                                        r["TrainingID"] = trainingID;
                                        rowsUpdatedCount++;
                                    }
                                    break;
                            }
                        }
                        if (dataChangedT)
                        {
                            MessageBox.Show("Training details added/updated successfully.");
                            GetEmployeeTrainings(queryWhere);
                        }
                    }
                    else
                    {
                        return;
                    }

                    if ((!dataChangedT || noDataT) && rowsUpdatedCount == 0)
                    {
                        MessageBox.Show("There is no Training data to Save");
                        GetEmployeeTrainings(queryWhere);
                    }
                }
                else
                {
                    MessageBox.Show("There is no record to save.");
                }

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }


        private void SaveEvaluation ()
        {
            try
            {
                grdEvaluationView.MoveNext();
                Cursor = Cursors.AppStarting;
                EmployeeEvaluation evaluation = null;
                bool dataChangedE = false;
                bool noDataE = false;
                int rowsUpdatedCount = 0;
                if (dtEval != null)
                {
                    if (MessageBox.Show("Are you sure you want to save the Evaluation details?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (DataRow r in dtEval.Rows)
                        {
                            // Update Record
                            switch (r.RowState)
                            {
                                case DataRowState.Added:
                                case DataRowState.Modified:
                                    evaluation = new EmployeeEvaluation(r["Classification"].ToString(),
                                                r["AttachmentName"].ToString(),
                                                r["EvaluationDate"].ToString(),
                                                r["AttachmentPath"].ToString(),
                                                recordID,
                                                r["EvaluationID"].ToString(),
                                                 r["Comments"].ToString());
                                    if (String.IsNullOrEmpty(r["Classification"].ToString().Trim()) && String.IsNullOrEmpty(r["AttachmentName"].ToString().Trim()) && String.IsNullOrEmpty(r["AttachmentPath"].ToString().Trim())
                                        && String.IsNullOrEmpty(r["Comments"].ToString().Trim()) && String.IsNullOrEmpty(r["EvaluationDate"].ToString().Trim()))
                                    {
                                        noDataE = true;
                                    }
                                    else
                                    {
                                        dataChangedE = true;
                                        evaluation.Save();
                                        evalID = evaluation.EvaluationID;
                                        r["EvaluationID"] = evalID;
                                        rowsUpdatedCount++;
                                    }
                                    break;
                            }
                        }
                        if (dataChangedE)
                        {
                            MessageBox.Show("Evaluation details added/updated successfully.");
                            GetEmployeeEvaluation();
                        }
                    }
                    else
                    {
                        return;
                    }

                    if ((!dataChangedE || noDataE) && rowsUpdatedCount == 0)
                    {
                        MessageBox.Show("There is no Evaluation data to Save");
                        GetEmployeeEvaluation();
                    }
                }
                else
                {
                    MessageBox.Show("There is no record to save.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void SaveBadging ()
        {
            try
            {
                grdViewBadging.MoveNext();
                Cursor = Cursors.AppStarting;
                EmployeeBadging badging = null;
                bool dataChangedB = false;
                bool noDataB = false;
                int rowsUpdatedCount = 0;
                if (dtBadging != null)
                {
                    if (MessageBox.Show("Are you sure you want to save the Badging details?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (DataRow r in dtBadging.Rows)
                        {
                            // Update Record
                            switch (r.RowState)
                            {
                                case DataRowState.Added:
                                case DataRowState.Modified:
                                    badging = new EmployeeBadging(r["Notes"].ToString(),
                                                r["AttachmentName"].ToString(),
                                                r["IssueDate"].ToString(),
                                                r["AttachmentPath"].ToString(),
                                                recordID,
                                                r["BadgeID"].ToString(),
                                                r["ExpirationDate"].ToString(),
                                                r["BadgeType"].ToString());
                                    if (String.IsNullOrEmpty(r["BadgeType"].ToString().Trim()) && String.IsNullOrEmpty(r["AttachmentName"].ToString().Trim()) && String.IsNullOrEmpty(r["AttachmentPath"].ToString().Trim())
                                        && String.IsNullOrEmpty(r["Notes"].ToString().Trim()) && String.IsNullOrEmpty(r["IssueDate"].ToString().Trim()) && String.IsNullOrEmpty(r["ExpirationDate"].ToString().Trim()))
                                    {
                                        noDataB = true;
                                    }
                                    else
                                    {
                                        dataChangedB = true;
                                        badging.Save();
                                        badgeID = badging.BadgeID;
                                        r["BadgeID"] = badgeID;
                                        rowsUpdatedCount++;
                                    }
                                    break;
                            }
                        }
                        if (dataChangedB)
                        {
                            MessageBox.Show("Badging details added/updated successfully.");
                            GetEmployeeBadging();
                        }
                    }
                    else
                    {
                        return;
                    }

                    if ((!dataChangedB || noDataB) && rowsUpdatedCount == 0)
                    {
                        MessageBox.Show("There is no Badging data to Save");
                        GetEmployeeBadging();
                    }
                }
                else
                {
                    MessageBox.Show("There is no record to save.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void SaveSafetyNotes ()
        {
            try
            {
                grdSafetyNotesView.MoveNext();
                Cursor = Cursors.AppStarting;
                EmployeeSafetyNotes safety = null;
                bool dataChangedB = false;
                bool noDataB = false;
                int rowsUpdatedCount = 0;
                if (dtSafetyNotes != null)
                {
                    if (MessageBox.Show("Are you sure you want to save the Safety Note details?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (DataRow r in dtSafetyNotes.Rows)
                        {
                            // Update Record
                            switch (r.RowState)
                            {
                                case DataRowState.Added:
                                case DataRowState.Modified:
                                    safety = new EmployeeSafetyNotes(r["InjuryType"].ToString(),
                                                r["InjuryDate"].ToString(),
                                                r["DoctorNotes"].ToString(),
                                                r["Comments"].ToString(),
                                                recordID,
                                                r["SafetyNoteID"].ToString());
                                    if (String.IsNullOrEmpty(r["InjuryType"].ToString().Trim()) && String.IsNullOrEmpty(r["InjuryDate"].ToString().Trim()) && String.IsNullOrEmpty(r["DoctorNotes"].ToString().Trim())
                                        && String.IsNullOrEmpty(r["Comments"].ToString().Trim()))
                                    {
                                        noDataB = true;
                                    }
                                    else
                                    {
                                        dataChangedB = true;
                                        safety.Save();
                                        safetyID = safety.SafetyNoteID;
                                        r["SafetyNoteID"] = safetyID;
                                        rowsUpdatedCount++;
                                    }
                                    break;
                            }
                        }
                        if (dataChangedB)
                        {
                            MessageBox.Show("Safety Note details added/updated successfully.");
                            GetSafety();
                            grdAttachmemts.Enabled = true;
                        }
                    }
                    else
                    {
                        return;
                    }

                    if ((!dataChangedB || noDataB) && rowsUpdatedCount == 0)
                    {
                        MessageBox.Show("There is no Safety Note data to Save");
                        GetSafety();
                    }
                }
                else
                {
                    MessageBox.Show("There is no record to save.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void SaveSafetyNoteAttachment ()
        {
            if (grdAttachmemtsView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdAttachmemtsView.GetDataRow(grdAttachmemtsView.GetSelectedRows()[0]);
                Cursor = Cursors.AppStarting;
                if (r == null)
                {
                    return;
                }

                try
                {
                    if (!string.IsNullOrEmpty(safetyID))
                    {
                        SafetyNoteAttachment attch = new SafetyNoteAttachment(r["AttachmentName"].ToString(),
                                            r["AttachmentPath"].ToString(),
                                            safetyID,
                                           r["AttchmentID"].ToString());
                        attch.Save();
                        attachmentID = attch.AttachmentID;
                        Cursor = Cursors.Default;
                        r["AttchmentID"] = attachmentID;
                    }
                    else
                    {
                        MessageBox.Show("Save safety note first to upload attachments.");
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }
        private void updateAttachment ( DataRow r )
        {
            try
            {
                bool valid = true;
                string message = "";
                if (MessageBox.Show("Save Safety Note Attachment Changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Validate Fields
                    if (r["AttachmentName"].ToString().Trim() == "" && r["AttachmentPath"].ToString().Trim() == "")
                    {
                        message = "Add attachment document ..\n";
                        valid = false;
                    }
                    if (valid)
                    {
                        SaveSafetyNoteAttachment();
                    }
                    else
                    {
                        MessageBox.Show(message, CCEApplication.ApplicationName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSaveTraining_Click ( object sender, EventArgs e )
        {
            SaveTrainings();
        }

        private void btnTrainingCancel_Click ( object sender, EventArgs e )
        {
            GetEmployeeTrainings(queryWhere);
        }

        private void btnSearch_Click ( object sender, EventArgs e )
        {
            queryWhere = " WHERE A.EmployeeID= " + recordID;
            if (txtFrom.Text.Length > 0 && txtTo.Text.Length > 0)
            {
                queryWhere += " AND (A.TrainingDate BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "')";
            }
            else
            {
                if (txtFrom.Text.Length > 0)
                {
                    queryWhere += " AND A.TrainingDate = '" + txtFrom.Text + "' ";
                }

                if (txtTo.Text.Length > 0)
                {
                    queryWhere += " AND A.TrainingDate = '" + txtTo.Text + "' ";
                }
            }

            GetEmployeeTrainings(queryWhere);
        }

        private void btnClear_Click ( object sender, EventArgs e )
        {
            txtTo.Text = null;
            txtFrom.Text = null;
            queryWhere = "WHERE A.EmployeeID = " + recordID;
            GetEmployeeTrainings(queryWhere);
        }
        private void btnEvalSave_Click ( object sender, EventArgs e )
        {
            SaveEvaluation();
        }

        private void btnEvalCancel_Click ( object sender, EventArgs e )
        {
            GetEmployeeEvaluation();
        }

        private void btnBadgingSave_Click ( object sender, EventArgs e )
        {
            SaveBadging();
        }

        private void btnbadgingCancel_Click ( object sender, EventArgs e )
        {
            GetEmployeeBadging();
        }

        private void btnSaftySave_Click ( object sender, EventArgs e )
        {
            SaveSafetyNotes();
        }

        private void btnSafetyCancel_Click ( object sender, EventArgs e )
        {
            GetSafety();
        }

        private void txtSSn_TextChanged ( object sender, EventArgs e )
        {
            EnableControl();
        }

        private void txtGeneralNotes_OnTextChanged ( object source, EventArgs e )
        {
            EnableControl();
        }
        private void txtTerminationReason_OnTextChanged ( object source, EventArgs e )
        {
            EnableControl();
        }


        private void labelControl4_Click ( object sender, EventArgs e )
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = txtGeneralNotes.Text
            };
            f.ShowDialog();
            txtGeneralNotes.Text = f.MyText;
            EnableControl();
        }
        private void labelControl27_Click ( object sender, EventArgs e )
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = txtTerminationReason.Text
            };
            f.ShowDialog();
            txtTerminationReason.Text = f.MyText;
            EnableControl();
        }

        private void xtraTabPage4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}