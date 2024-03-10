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
    public partial class frmTransmittal : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private     DataTable transmittalDetailDataTable;
        private     bool isUpdated = false;
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
        public frmTransmittal()
        {
            InitializeComponent();
        }
        //
        public frmTransmittal(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmTransmittal_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly )
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false; 
                }
                txtRecordID.DataBindings.Add("text", bindingSource, "JobTransmittalID");
                //
             /*   cboContact.Properties.DataSource = Contact.GetJobContactCompanyForPullDown(jobID).Tables[0];
                cboContact.Properties.DisplayMember = "Company";
                cboContact.Properties.ValueMember = "ContactID";
                cboContact.Properties.PopulateColumns();
                cboContact.Properties.ShowHeader = false;
              */

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
                    GetTransmittal();
                }
                else
                {
                    GetTransmittal();
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
        private void GetTransmittalDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateTransmittal(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtTransmittalNumber.Text = "";
                cboContact.EditValue = null;
                txtTransmittalDate.Text = "";
                txtFrom.Text = "";
                txtShipVia.Text = "";
                chkEnclosed.CheckState = CheckState.Unchecked;
                chkUnderSeparateCover.CheckState = CheckState.Unchecked;
                chkOriginals.CheckState = CheckState.Unchecked;
                chkSubmittals.CheckState = CheckState.Unchecked;
                chkDrawingsPrints.CheckState = CheckState.Unchecked;
                chkOMManuals.CheckState = CheckState.Unchecked;
                chkLetters.CheckState = CheckState.Unchecked;
                chkChangeOrders.CheckState = CheckState.Unchecked;
                chkSpecifications.CheckState = CheckState.Unchecked;
                txtOtherInfo.Text = "";
                chkForYourReview.CheckState = CheckState.Unchecked;
                chkForYourInformation.CheckState = CheckState.Unchecked;
                chkForYourFiles.CheckState = CheckState.Unchecked;
                chkForYourApproval.CheckState = CheckState.Unchecked;
                chkActionRequired.CheckState = CheckState.Unchecked;
                chkAsRequested.CheckState = CheckState.Unchecked;
                chkReplyRequested.CheckState = CheckState.Unchecked;
                txtRemarkOrReply.Text = "";
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
            GetTransmittalItems(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
        }
        //
        private void ProtectForm()
        {
            //txtTransmittalNumber.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            //txtTransmittalNumber.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridTransmittalView, "frmTransmittal");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }



            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Transmittal":
                    if (CheckTransmittalStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetTransmittal();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Transmittal":
                    if (CheckTransmittalStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetTransmittal();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckTransmittalStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetTransmittal();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckTransmittalStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetTransmittal();
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
                case "Transmittal":
                    try
                    {
                        Reports.TransmittalForm(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckTransmittalStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveTransmittal();
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
        private void SaveTransmittal()
        {
           try
           {
               JobTransmittal transmittal = new JobTransmittal(recordID,
                                   jobID,
                                   txtTransmittalNumber.Text,
                                   cboContact.EditValue == null ? "" : cboContact.EditValue.ToString(),
                                   txtTransmittalDate.Text,
                                   txtFrom.Text,
                                   txtShipVia.Text,
                                   chkEnclosed.Checked.ToString(),
                                   chkUnderSeparateCover.Checked.ToString(),
                                   chkOriginals.Checked.ToString(),
                                   chkSubmittals.Checked.ToString(),
                                   chkDrawingsPrints.Checked.ToString(),
                                   chkOMManuals.Checked.ToString(),
                                   chkLetters.Checked.ToString(),
                                   chkChangeOrders.Checked.ToString(),
                                   chkSpecifications.Checked.ToString(),
                                   txtOtherInfo.Text,
                                   chkForYourReview.Checked.ToString(),
                                   chkForYourInformation.Checked.ToString(),
                                   chkForYourFiles.Checked.ToString(),
                                   chkForYourApproval.Checked.ToString(),
                                   chkActionRequired.Checked.ToString(),
                                   chkAsRequested.Checked.ToString(),
                                   chkReplyRequested.Checked.ToString(),
                                   txtRemarkOrReply.Text);
                transmittal.Save();

                recordID = transmittal.JobTransmittalID;
                txtRecordID.Text = recordID;
                txtTransmittalNumber.Text = transmittal.TransmittalNumber.Replace("'","");
                SaveTransmittalItems();
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
        private void GetTransmittal()
        {
            GetTransmittalDetail(recordID);
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
        private void frmTransmittal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridTransmittalView, "frmTransmittal");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
            }
            CheckTransmittalStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateTransmittal(string recordID)
        {
            try
            {
                DataRow r;
                r = JobTransmittal.GetTransmittalDetail(recordID).Tables[0].Rows[0];
                txtTransmittalNumber.Text       = r["TransmittalNumber"].ToString().Replace("'", "");
                cboContact.EditValue            = r["ContactID"];
                txtTransmittalDate.EditValue    = r["TransmittalDate"];
                txtFrom.Text                    = r["From"].ToString();
                txtShipVia.Text                 = r["ShipVia"].ToString();
                chkEnclosed.EditValue           = r["Enclosed"];      
                chkUnderSeparateCover.EditValue = r["UnderSeparateCover"];
                chkOriginals.EditValue          = r["Originals"];
                chkSubmittals.EditValue         = r["Submittals"];
                chkDrawingsPrints.EditValue     = r["DrawingsPrints"];
                chkOMManuals.EditValue          = r["OMManuals"];
                chkLetters.EditValue            = r["Letters"];
                chkChangeOrders.EditValue       = r["ChangeOrders"];
                chkSpecifications.EditValue     = r["Specifications"];
                txtOtherInfo.Text               = r["OtherInfo"].ToString();
                chkForYourReview.EditValue      = r["ForYourReview"];
                chkForYourInformation.EditValue = r["ForYourInformation"];
                chkForYourFiles.EditValue       = r["ForYourFiles"];
                chkForYourApproval.EditValue    = r["ForYourApproval"];
                chkActionRequired.EditValue     = r["ActionRequired"];
                chkAsRequested.EditValue        = r["AsRequired"];
                chkReplyRequested.EditValue     = r["ReplyRequested"];
                txtRemarkOrReply.Text           = r["RemarkOrReply"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            //txtTransmittalNumber.ErrorText = "";
            txtTransmittalDate.ErrorText = "";
            txtFrom.ErrorText = "";
            cboContact.ErrorText = "";
            errorMessages = false;
            //
            //if (recordID == "" || recordID == "0")
            //{
            //    if (txtTransmittalNumber.Text.Trim().Length == 0)
            //    {
            //        txtTransmittalNumber.ErrorText = "Transmittal No. is Required";
            //        errorMessages = true;
            //    }
            //    else
            //    {

            //        if (JobTransmittal.IsTransmittalInDatabase(txtTransmittalNumber.Text.Trim(), jobID))
            //        {
            //            txtTransmittalNumber.ErrorText = "Transmittal No. is in the Database";
            //            errorMessages = true;
            //        }
            //    }
            //}
            //
            if (cboContact.Text.Trim() == "")
            {
                cboContact.ErrorText = "Contact is Requried";
                errorMessages = true;
            }
            //
            if (txtTransmittalDate.Text.Trim() == "")
            {
                txtTransmittalDate.ErrorText = "Transmittal Date is Required";
                errorMessages = true;
            }
            //
            if (txtFrom.Text.Trim() == "")
            {
                txtFrom.ErrorText = "From is Required";
                errorMessages = true;
            }
        }
        //
        private void GetTransmittalItems(string jobTransmittalID)
        {
            try
            {
                transmittalDetailDataTable = JobTransmittalDetail.GetTransmittalDetail(jobTransmittalID).Tables[0];

                this.grdTransmittal.DataSource = transmittalDetailDataTable.DefaultView;

                gridTransmittalView.Columns["JobTransmittalID"].Visible = false;
                gridTransmittalView.Columns["JobTransmittalDetailID"].Visible = false;
                gridTransmittalView.Columns["Description"].ColumnEdit = repDescription;
                gridTransmittalView.Columns["Copies"].ColumnEdit = repCopies;
                gridTransmittalView.Columns["ItemNumber"].ColumnEdit = repCopies;
                gridTransmittalView.Columns["ItemNumber"].Caption = "Item No.";
                gridTransmittalView.BestFitColumns();
                gridTransmittalView.Columns["Description"].Width = 400;
                gridTransmittalView.Columns["Copies"].Width = 50;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridTransmittalView, "frmTransmittal");
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
                gridTransmittalView.OptionsBehavior.Editable = false;
                gridTransmittalView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    gridTransmittalView.OptionsBehavior.Editable = false;
                    gridTransmittalView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                }
                else
                {
                    gridTransmittalView.OptionsBehavior.Editable = true;
                    gridTransmittalView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }

            }
        }
        //
        private void SaveTransmittalItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                JobTransmittalDetail transmittalDetail;
                if (transmittalDetailDataTable != null)
                {
                    foreach (DataRow r in transmittalDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                transmittalDetail = new JobTransmittalDetail (
                                                    r["JobTransmittalDetailID"].ToString(),
                                                    recordID,
                                                    r["ItemNumber"].ToString(),
                                                    r["Copies"].ToString(),
                                                    r["Description"].ToString());
                                transmittalDetail.Save();
                                r["JobTransmittalDetailID"] = transmittalDetail.JobTransmittalDetailID;
                                r.AcceptChanges();
                                
                                break;
                            case DataRowState.Deleted:
                                JobTransmittalDetail.Delete(r["JobTransmittalDetailID"].ToString());
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
        private void gridTransmittalView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
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

        private void gridTransmittalView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void labelControl5_Click ( object sender, EventArgs e )
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtRemarkOrReply.Text;
            f.ShowDialog();
            txtRemarkOrReply.Text = f.MyText;
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