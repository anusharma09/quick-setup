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
    public partial class frmSwitchgearRelease : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private     DataTable switchgearListTable;
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
        public frmSwitchgearRelease()
        {
            InitializeComponent();
        }
        //
        public frmSwitchgearRelease(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmSwitchgearRelease_Load(object sender, EventArgs e)
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
                txtRecordID.DataBindings.Add("text", bindingSource, "JobSwitchgearReleaseID");
                //
                switchgearListTable = Switchgear.GetSwitchgearPullDown(jobID).Tables[0];
                repSwitchgear.DataSource = switchgearListTable;
                repSwitchgear.DisplayMember = "Description";
                repSwitchgear.ValueMember = "JobSwitchgearID";
                repSwitchgear.PopulateColumns();
                repSwitchgear.Columns[0].Visible = false;
                switchgearListTable.PrimaryKey = new DataColumn[] { switchgearListTable.Columns["JobSwitchgearID"] };
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetSwitchgearRelease();
                }
                else
                {
                    GetSwitchgearRelease();
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
        private void GetSwitchgearReleaseDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateSwitchgearRelease(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtReleaseNumber.Text = "";
                txtPONumber.Text = "";
                txtReleaseDate.EditValue = null;
                UnProtectForm();
            }
            GetSwitchgearReleaseItems(recordID);
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
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridSwitchgearView, "frmSwitchgearRelease");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }


            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Switchgear Release":
                    if (CheckSwitchgearReleaseStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetSwitchgearRelease();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "Previous Switchgear Release":
                    if (CheckSwitchgearReleaseStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetSwitchgearRelease();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckSwitchgearReleaseStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetSwitchgearRelease();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckSwitchgearReleaseStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetSwitchgearRelease();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    //btnCopy.Enabled = true;
                    btnDelete.Enabled = true;
                    break;
                case "&Delete":
                    Int32[] selectedRowHandles = gridSwitchgearView.GetSelectedRows();
                    if (selectedRowHandles.Length > 0 && gridSwitchgearView.DataRowCount > 0)
                    {
                        if (gridSwitchgearView.GetDataRow(selectedRowHandles[0]) == null)
                            return;

                        if (MessageBox.Show("You are about to delete the selected Switchgear Release item. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var releaseDetailID = gridSwitchgearView.GetDataRow(selectedRowHandles[0]).ItemArray[0];
                            try
                            {
                                SwitchgearReleaseDetail.Remove(releaseDetailID.ToString());
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
                       if (MessageBox.Show("You are about to delete Switchgear Release. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    SwitchgearRelease.Remove(txtRecordID.Text);
                                    recordID = "0";
                                    txtRecordID.Text = "0";
                                    ribbonReport.Visible = false;
                                    GetSwitchgearRelease();
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

                case "Switchgear Release":
                    try
                    {
                        Reports.Reports.SwitchgearReleaseForm(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckSwitchgearReleaseStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveSwitchgearRelease();
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
        private void SaveSwitchgearRelease()
        {
           try
           {
               SwitchgearRelease switchgear = new SwitchgearRelease(recordID,
                                   jobID,
                                   txtPONumber.Text,
                                   txtReleaseDate.EditValue == null ? "" : txtReleaseDate.EditValue.ToString());

                switchgear.Save();
                if (recordID == "" || recordID == "0")
                    txtReleaseNumber.Text = switchgear.ReleaseNumber;
                recordID = switchgear.JobSwitchgearReleaseID;
                txtRecordID.Text = recordID;
                SaveSwitchgearReleaseItems();
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
        private void SaveSwitchgearReleaseItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                SwitchgearReleaseDetail item;
                if ( switchgearDetailDataTable != null)
                {
                    foreach (DataRow r in switchgearDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                item = new  SwitchgearReleaseDetail(
                                                    r["JobSwitchgearReleaseDetailID"].ToString(),
                                                    recordID,
                                                    r["JobSwitchgearID"].ToString(),
                                                    r["Quantity"].ToString(),
                                                    r["EstimatedShipDate"].ToString(),
                                                    r["Notes"].ToString());
                                item.Save();
                                r["JobSwitchgearReleaseDetailID"] = item.JobSwitchgearReleaseDetailID;

                                break;
                            case DataRowState.Deleted:
 //                               SwitchgearReleaseDetail.Remove(r["JobSwitchgearReleaseDetailID"].ToString());
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
        private void GetSwitchgearRelease()
        {
            GetSwitchgearReleaseDetail(recordID);
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
        private void frmSwitchgearRelease_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridSwitchgearView, "frmSwitchgearRelease");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckSwitchgearReleaseStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateSwitchgearRelease(string recordID)
        {
            try
            {
                DataRow r;
                r = SwitchgearRelease.GetSwitchgearRelease(recordID).Tables[0].Rows[0];

                txtReleaseNumber.Text         = r["ReleaseNumber"].ToString();
                txtPONumber.Text              = r["PONumber"].ToString();
                txtReleaseDate.EditValue       = r["ReleaseDate"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            txtPONumber.ErrorText = "";
            txtReleaseDate.ErrorText = "";
            errorMessages = false;
            //
            if (txtPONumber.Text.Trim() == "")
            {
                txtPONumber.ErrorText = "PO Number is Requried";
                errorMessages = true;
            }
            //
            if (txtReleaseDate.Text.Trim() == "")
            {
                txtReleaseDate.ErrorText = "Release Date is Requried";
                errorMessages = true;
            }            
        }
        //
        private void GetSwitchgearReleaseItems(string jobSwitchgearReleaseID)
        {
            try
            {
                switchgearDetailDataTable = SwitchgearRelease.GetSwitchgearReleaseItems(jobSwitchgearReleaseID).Tables[0];

                this.grdSwitchgear.DataSource = switchgearDetailDataTable.DefaultView;
                gridSwitchgearView.Columns["JobSwitchgearReleaseID"].Visible = false;
                gridSwitchgearView.Columns["JobSwitchgearReleaseDetailID"].Visible = false;
                gridSwitchgearView.Columns["JobSwitchgearID"].Caption = "Switchgear";
                gridSwitchgearView.Columns["JobSwitchgearID"].ColumnEdit = repSwitchgear;
                gridSwitchgearView.Columns["Quantity"].Caption = "Quantity";
                gridSwitchgearView.Columns["Quantity"].ColumnEdit = repQuantity;
                gridSwitchgearView.Columns["EstimatedShipDate"].Caption = "Est Ship Date";
                gridSwitchgearView.Columns["Notes"].ColumnEdit = repNote;
                gridSwitchgearView.BestFitColumns();
                gridSwitchgearView.Columns["Notes"].Width = 300;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridSwitchgearView, "frmSwitchgearRelease");
                
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

        private void gridSwitchgearView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRowView r = (DataRowView)e.Row;
            if (r[2].ToString().Trim().Length == 0)
            {
                e.ErrorText = "Switchgear is required ...";

                e.Valid = false;

            }

        }

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
                                SwitchgearReleaseDetail.Remove(r[0].ToString());
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

        private void gridSwitchgearView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "JobSwitchgearID")
            {
                try
                {
                    DataRow r;
                    r = switchgearListTable.Rows.Find(e.Value.ToString());
                    DataRow rr = gridSwitchgearView.GetDataRow(e.RowHandle);
                    rr["Quantity"] = r[3].ToString() == "" ? 0 : r[3];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
                
            }
        }

        
 
      
    }
}