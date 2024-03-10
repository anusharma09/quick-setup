using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCSwitchgear.BusinessLayer;
using JCCSwitchgear.Reports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
namespace JCCSwitchgear.PresentationLayer
{
    public partial class frmSwitchgearRevision : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private     DataTable switchgearDetailDataTable;
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
        public frmSwitchgearRevision()
        {
            InitializeComponent();
        }
        //
        public frmSwitchgearRevision(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmSwitchgearRevision_Load(object sender, EventArgs e)
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
                        btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnSave.Enabled = false;
                        btnUndo.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
                txtRecordID.DataBindings.Add("text", bindingSource, "JobSwitchgearRevisionID");
                //
                repSwitchgear.DataSource = Switchgear.GetSwitchgearPullDown(jobID).Tables[0];
                repSwitchgear.DisplayMember = "Description";
                repSwitchgear.ValueMember = "JobSwitchgearID";
                repSwitchgear.PopulateColumns();
                repSwitchgear.Columns[0].Visible = false;
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetSwitchgearRevision();
                }
                else
                {
                    GetSwitchgearRevision();
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
        private void GetSwitchgearRevisionDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateSwitchgearRevision(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtRevisionNumber.Text = "";
                txtRevisionDate.EditValue = null;
                UnProtectForm();
            }
            GetSwitchgearRevisionItems(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnDelete.Enabled = true;
            dataChanged = false;
            if (recordID != "0")
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
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
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridSwitchgearView, "frmSwitchgearRevision");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Switchgear Revision":
                    if (CheckSwitchgearRevisionStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetSwitchgearRevision();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "Previous Switchgear Revision":
                    if (CheckSwitchgearRevisionStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetSwitchgearRevision();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckSwitchgearRevisionStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetSwitchgearRevision();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckSwitchgearRevisionStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetSwitchgearRevision();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    //btnCopy.Enabled = true;
                    break;
                case "&Delete":
                    Int32[] selectedRowHandles = gridSwitchgearView.GetSelectedRows();
                    if (selectedRowHandles.Length > 0 && gridSwitchgearView.DataRowCount > 0)
                    {
                        if (gridSwitchgearView.GetDataRow(selectedRowHandles[0]) == null)
                            return;

                        if (MessageBox.Show("You are about to delete the selected Switchgear Revision item. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var revisionDetailID = gridSwitchgearView.GetDataRow(selectedRowHandles[0]).ItemArray[0];
                            try
                            {
                                SwitchgearRevisionDetail.Remove(revisionDetailID.ToString());
                                gridSwitchgearView.DeleteRow(gridSwitchgearView.GetSelectedRows()[0]);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("You are about to delete Switchgear Revision. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    SwitchgearRevision.Remove(txtRecordID.Text);
                                    recordID = "0";
                                    txtRecordID.Text = "0";
                                    ribbonReport.Visible = false;
                                    GetSwitchgearRevision();
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
                    }

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
                case "Switchgear Revision":
                    try
                    {
                        Reports.Reports.SwitchgearRevisionForm(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckSwitchgearRevisionStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveSwitchgearRevision();
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
        private void SaveSwitchgearRevision()
        {
           try
           {
               SwitchgearRevision switchgear = new SwitchgearRevision(recordID,
                                   jobID,
                                   txtRevisionDate.EditValue == null ? "" : txtRevisionDate.EditValue.ToString());

                switchgear.Save();
                if (recordID == "" || recordID == "0")
                    txtRevisionNumber.Text = switchgear.RevisionNumber;
                recordID = switchgear.JobSwitchgearRevisionID;
                txtRecordID.Text = recordID;
                SaveSwitchgearRevisionItems();
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
        //
        private void SaveSwitchgearRevisionItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                SwitchgearRevisionDetail item;
                if ( switchgearDetailDataTable != null)
                {
                    foreach (DataRow r in switchgearDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                item = new  SwitchgearRevisionDetail(
                                                    r["JobSwitchgearRevisionDetailID"].ToString(),
                                                    recordID,
                                                    r["JobSwitchgearID"].ToString(),
                                                    r["Quantity"].ToString(),
                                                    r["EstimatedShipDate"].ToString(),
                                                    r["Notes"].ToString());
                                item.Save();
                                r["JobSwitchgearRevisionDetailID"] = item.JobSwitchgearRevisionDetailID;

                                break;
                            case DataRowState.Deleted:
 //                               SwitchgearRevisionDetail.Remove(r["JobSwitchgearRevisionDetailID"].ToString());
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
        private void GetSwitchgearRevision()
        {
            GetSwitchgearRevisionDetail(recordID);
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
        //
        private void frmSwitchgearRevision_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckSwitchgearRevisionStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateSwitchgearRevision(string recordID)
        {
            try
            {
                DataRow r;
                r = SwitchgearRevision.GetSwitchgearRevision(recordID).Tables[0].Rows[0];

                txtRevisionNumber.Text         = r["RevisionNumber"].ToString();
                txtRevisionDate.EditValue       = r["RevisionDate"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            txtRevisionDate.ErrorText = "";
            errorMessages = false;
            //
            //
            if (txtRevisionDate.Text.Trim() == "")
            {
                txtRevisionDate.ErrorText = "Revision Date is Requried";
                errorMessages = true;
            }            
        }
        //
        private void GetSwitchgearRevisionItems(string jobSwitchgearRevisionID)
        {
            try
            {
                switchgearDetailDataTable = SwitchgearRevision.GetSwitchgearRevisionItems(jobSwitchgearRevisionID).Tables[0];

                this.grdSwitchgear.DataSource = switchgearDetailDataTable.DefaultView;
                gridSwitchgearView.Columns["JobSwitchgearRevisionID"].Visible = false;
                gridSwitchgearView.Columns["JobSwitchgearRevisionDetailID"].Visible = false;
                gridSwitchgearView.Columns["JobSwitchgearID"].Caption = "Switchgear";
                gridSwitchgearView.Columns["JobSwitchgearID"].ColumnEdit = repSwitchgear;
                gridSwitchgearView.Columns["Quantity"].Caption = "Quantity";
                gridSwitchgearView.Columns["Quantity"].ColumnEdit = repQuantity;
                gridSwitchgearView.Columns["EstimatedShipDate"].Caption = "Est Ship Date";
                gridSwitchgearView.Columns["Notes"].ColumnEdit = repNote;
                gridSwitchgearView.BestFitColumns();
                gridSwitchgearView.Columns["Notes"].Width = 300;   
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridSwitchgearView, "frmSwitchgearRevision");
                
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
                gridSwitchgearView.OptionsBehavior.Editable = false;
                gridSwitchgearView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    gridSwitchgearView.OptionsBehavior.Editable = true;
                    gridSwitchgearView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                        gridSwitchgearView.OptionsBehavior.Editable = false;
                        gridSwitchgearView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    }
                    else
                    {
                        gridSwitchgearView.OptionsBehavior.Editable = true;
                        gridSwitchgearView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    }

                }

            }
        }

        private void gridSwitchgearView_RowUpdated(object sender, RowObjectEventArgs e)
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
        //
        private void gridSwitchgearView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRowView r = (DataRowView)e.Row;
            if (r[2].ToString().Trim().Length == 0)
            {
                e.ErrorText = "Switchgear is required ...";

                e.Valid = false;

            }

        }
        //
        private void gridSwitchgearView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
                (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = gridSwitchgearView.GetDataRow(gridSwitchgearView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("Delete Selected Item?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                SwitchgearRevisionDetail.Remove(r[0].ToString());
                                gridSwitchgearView.DeleteRow(gridSwitchgearView.GetSelectedRows()[0]);
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

        private void gridSwitchgearView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        
 
      
    }
}