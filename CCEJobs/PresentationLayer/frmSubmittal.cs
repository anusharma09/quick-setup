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
    public partial class frmSubmittal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected bool bColumnWidthChanged = false;
        protected   string recordID;
        protected   string jobID;
        protected   BindingSource bindingSource;
        protected   bool dataChanged;
        private     bool errorMessages = false;
        protected   DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected   string currentButtonName = "";
        private     bool changesStatus = false;
        private     DataTable submittalDetailDataTable;
        private     RepositoryItemLookUpEdit submittalStatus = new RepositoryItemLookUpEdit();
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
        public frmSubmittal()
        {
            InitializeComponent();
        }
        //
        public frmSubmittal(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmSubmittal_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly )
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false; 
                }
                txtRecordID.DataBindings.Add("text", bindingSource, "JobSubmittalID");
                //
                cboJobSubmittalSpec.Properties.DataSource = JobSubmittalSpec.GetJobSubmittalSpec(jobID).Tables[0];
                cboJobSubmittalSpec.Properties.PopulateColumns();
                cboJobSubmittalSpec.Properties.DisplayMember = "JobSubmittalSpecDescription";
                cboJobSubmittalSpec.Properties.ValueMember = "JobSubmittalSpecID";
                cboJobSubmittalSpec.Properties.ShowHeader = false;
                cboJobSubmittalSpec.Properties.Columns["JobSubmittalSpecID"].Visible = false;
                //
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                submittalStatus.DataSource = JobSubmittalStatus.GetJobSubmittalStatus().Tables[0];
                submittalStatus.DisplayMember = "JobSubmittalStatusDescription";
                submittalStatus.ValueMember = "JobSubmittalStatusID";
                col.Caption = "ID";
                col.FieldName = "JobSubmittalStatusID";
                col.Visible = false;
                submittalStatus.Columns.Add(col);
                col1.Caption = "Status";
                col1.FieldName = "JobSubmittalStatusDescription";
                col1.Visible = true;
                submittalStatus.Columns.Add(col1);
                submittalStatus.NullText = "";
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetSubmittal();
                }
                else
                {
                    GetSubmittal();
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
        private void GetSubmittalDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateSubmittal(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtTitle.Text = "";
                cboJobSubmittalSpec.EditValue = null;
                UnProtectForm();
            }
            GetSubmittalItems(recordID);
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


            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridSubmittal, "frmSubmittal");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }


            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Submittal":
                    if (CheckSubmittalStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetSubmittal();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnDelete.Enabled = true;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Submittal":
                    if (CheckSubmittalStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetSubmittal();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckSubmittalStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetSubmittal();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckSubmittalStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetSubmittal();
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
                    if (MessageBox.Show("You are about to delete Submittal. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                JobSubmittal.Delete(txtRecordID.Text);
                                recordID = "0";
                                txtRecordID.Text = "0";
                                ribbonReport.Visible = false;
                                GetSubmittal();
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
                case "Submittal":
                    try
                    {
                        Reports.SubmittalForm(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckSubmittalStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveSubmittal();
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
        private void SaveSubmittal()
        {
           try
           {
               JobSubmittal submittal = new JobSubmittal(recordID,
                                   jobID,
                                   cboJobSubmittalSpec.EditValue == null ? "" : cboJobSubmittalSpec.EditValue.ToString(),
                                   txtTitle.Text);
                submittal.Save();

                recordID = submittal.JobSubmittalID;
                txtRecordID.Text = recordID;
                SaveSubmittalItems();
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
        private void GetSubmittal()
        {
            GetSubmittalDetail(recordID);
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
                    btnDelete.Enabled = false;
                }
            }
        }
        //
        private void frmSubmittal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridSubmittal, "frmSubmittal");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            CheckSubmittalStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateSubmittal(string recordID)
        {
            try
            {
                DataRow r;
                r = JobSubmittal.GetJobSubmittalDetail(recordID).Tables[0].Rows[0];
                cboJobSubmittalSpec.EditValue   = r["JobSubmittalSpecID"];
                txtTitle.Text                    = r["Title"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
           // txtTitle.ErrorText = "";
            cboJobSubmittalSpec.ErrorText = "";
            errorMessages = false;
            //
            if (cboJobSubmittalSpec.Text.Trim() == "")
            {
                cboJobSubmittalSpec.ErrorText = "Spec is Requried";
                errorMessages = true;
            }
            //
          /*  if (txtTitle.Text.Trim() == "")
            {
                txtTitle.ErrorText = "Title is Required";
                errorMessages = true;
            }
           */
        }
        //
        private void GetSubmittalItems(string jobSubmittalID)
        {
            try
            {
                submittalDetailDataTable = JobSubmittalDetail.GetSubmittalDetail(jobSubmittalID).Tables[0];

                this.grdSubmittal.DataSource = submittalDetailDataTable.DefaultView;

                gridSubmittal.Columns["JobSubmittalDetailID"].Visible = false;
                gridSubmittal.Columns["JobSubmittalID"].Visible = false;
                gridSubmittal.Columns["Note"].ColumnEdit = repNote;
                gridSubmittal.Columns["RevisionNumber"].Caption = "Rev No.";
                gridSubmittal.Columns["RevisionNumber"].ColumnEdit = repRevision;
                gridSubmittal.Columns["JobSubmittalStatusID"].ColumnEdit = submittalStatus;
                gridSubmittal.Columns["JobSubmittalStatusID"].Caption = "Status";
                gridSubmittal.Columns["SubmittedDate"].Caption = "Submitted Date";
                gridSubmittal.Columns["ReceivedDate"].Caption = "Received Date";
                gridSubmittal.Columns["RevisionNumber"].OptionsColumn.AllowEdit = false;
                gridSubmittal.BestFitColumns();
                gridSubmittal.Columns["Note"].Width = 300;
                gridSubmittal.Columns["JobSubmittalStatusID"].Width = 150;

                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridSubmittal, "frmSubmittal");
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
                gridSubmittal.OptionsBehavior.Editable = false;
                gridSubmittal.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    gridSubmittal.OptionsBehavior.Editable = false;
                    gridSubmittal.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                }
                else
                {
                    gridSubmittal.OptionsBehavior.Editable = true;
                    gridSubmittal.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }

            }
        }
        //
        private void SaveSubmittalItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                JobSubmittalDetail submittalDetail;
                if (submittalDetailDataTable != null)
                {
                    foreach (DataRow r in submittalDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                submittalDetail = new JobSubmittalDetail(
                                                    r["JobSubmittalDetailID"].ToString(),
                                                    recordID,
                                                    r["RevisionNumber"].ToString(),
                                                    r["JobSubmittalStatusID"].ToString(),
                                                    r["SubmittedDate"].ToString(),
                                                    r["ReceivedDate"].ToString(),
                                                    r["Note"].ToString());
                                submittalDetail.Save();
                                r["JobSubmittalDetailID"] = submittalDetail.JobSubmittalDetailID;
                                r["RevisionNumber"] = submittalDetail.RevisionNumber;
                                
                                break;
                            case DataRowState.Deleted:
                                JobSubmittalDetail.Delete(r["JobSubmittalDetailID"].ToString());
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
        private void gridSubmittalView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                }
            }
        }

        private void gridSubmittal_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
        //
    }
}