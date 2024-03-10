using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCLightFixture.BusinessLayer;
using JCCLightFixture.Reports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
namespace JCCLightFixture.PresentationLayer
{
    public partial class frmLightFixtureRevision : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private     DataTable lightFixtureDetailDataTable;
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
        public frmLightFixtureRevision()
        {
            InitializeComponent();
        }
        //
        public frmLightFixtureRevision(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmLightFixtureRevision_Load(object sender, EventArgs e)
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
                txtRecordID.DataBindings.Add("text", bindingSource, "JobLightFixtureRevisionID");
                //
                repLightFixture.DataSource = JobLightFixture.GetJobLightFixturePullDown(jobID).Tables[0];
                repLightFixture.DisplayMember = "Type";
                repLightFixture.ValueMember = "JobLightFixtureID";
                repLightFixture.PopulateColumns();
                repLightFixture.Columns[0].Visible = false;
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetLightFixtureRevision();
                }
                else
                {
                    GetLightFixtureRevision();
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
        private void GetLightFixtureRevisionDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateLightFixtureRevision(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtRevisionNumber.Text = "";
                txtRevisionDate.EditValue = null;
                UnProtectForm();
            }
            GetLightFixtureRevisionItems(recordID);
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
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridLightFixtureView, "frmLightFixtureRevision");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Light Fixture Revision":
                    if (CheckLightFixtureRevisionStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetLightFixtureRevision();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "Previous Light Fixture Revision":
                    if (CheckLightFixtureRevisionStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetLightFixtureRevision();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckLightFixtureRevisionStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetLightFixtureRevision();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckLightFixtureRevisionStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetLightFixtureRevision();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    //btnCopy.Enabled = true;
                    btnDelete.Enabled = true;
                    break;
                case "&Delete":
                    Int32[] selectedRowHandles = gridLightFixtureView.GetSelectedRows();
                    if (selectedRowHandles.Length > 0 && gridLightFixtureView.DataRowCount > 0)
                    {
                        if (gridLightFixtureView.GetDataRow(selectedRowHandles[0]) == null)
                            return;

                        if (MessageBox.Show("You are about to delete the selected Light Fixture Revision item. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var revisionDetailID = gridLightFixtureView.GetDataRow(selectedRowHandles[0]).ItemArray[0];
                            try
                            {
                                JobLightFixtureRevisionDetail.Remove(revisionDetailID.ToString());
                                gridLightFixtureView.DeleteRow(gridLightFixtureView.GetSelectedRows()[0]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("You are about to delete Light Fixture Revision. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    JobLightFixtureRevision.Remove(txtRecordID.Text);
                                    recordID = "0";
                                    txtRecordID.Text = "0";
                                    ribbonReport.Visible = false;
                                    GetLightFixtureRevision();
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
                case "Light Fixture Revision":
                    try
                    {
                        Reports.Reports.LightFixtureRevisionForm(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckLightFixtureRevisionStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveLightFixtureRevision();
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
        private void SaveLightFixtureRevision()
        {
           try
           {
               JobLightFixtureRevision light = new JobLightFixtureRevision(recordID,
                                   jobID,
                                   txtRevisionDate.EditValue == null ? "" : txtRevisionDate.EditValue.ToString());

                light.Save();
                if (recordID == "" || recordID == "0")
                    txtRevisionNumber.Text = light.RevisionNumber;
                recordID = light.JobLightFixtureRevisionID;
                txtRecordID.Text = recordID;
                SaveLightFixtureRevisionItems();
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
        private void SaveLightFixtureRevisionItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                JobLightFixtureRevisionDetail item;
                if ( lightFixtureDetailDataTable != null)
                {
                    foreach (DataRow r in lightFixtureDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                item = new  JobLightFixtureRevisionDetail(
                                                    r["JobLightFixtureRevisionDetailID"].ToString(),
                                                    recordID,
                                                    r["JobLightFixtureID"].ToString(),
                                                    r["QtyRun"].ToString(),
                                                    r["Length"].ToString(),
                                                    r["EstimatedShipDate"].ToString(),
                                                    r["Notes"].ToString());
                                item.Save();
                                r["JobLightFixtureRevisionDetailID"] = item.JobLightFixtureRevisionDetailID;

                                break;
                            case DataRowState.Deleted:
  //                              JobLightFixtureRevisionDetail.Remove(r["JobLightFixtureRevisionDetailID"].ToString());
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
        private void GetLightFixtureRevision()
        {
            GetLightFixtureRevisionDetail(recordID);
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
        private void frmLightFixtureRevision_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckLightFixtureRevisionStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateLightFixtureRevision(string recordID)
        {
            try
            {
                DataRow r;
                r = JobLightFixtureRevision.GetLightFixtureRevision(recordID).Tables[0].Rows[0];

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
        private void GetLightFixtureRevisionItems(string jobLightFixtureRevisionID)
        {
            try
            {
                lightFixtureDetailDataTable = JobLightFixtureRevision.GetLightFixtureRevisionItems(jobLightFixtureRevisionID).Tables[0];

                this.grdLightFixture.DataSource = lightFixtureDetailDataTable.DefaultView;
                gridLightFixtureView.Columns["JobLightFixtureRevisionID"].Visible = false;
                gridLightFixtureView.Columns["JobLightFixtureRevisionDetailID"].Visible = false;
                gridLightFixtureView.Columns["JobLightFixtureID"].Caption = "Light Fixture";
                gridLightFixtureView.Columns["JobLightFixtureID"].ColumnEdit = repLightFixture;
                gridLightFixtureView.Columns["QtyRun"].Caption = "Qty Run";
                gridLightFixtureView.Columns["QtyRun"].ColumnEdit = repQuantity;
                gridLightFixtureView.Columns["Length"].ColumnEdit = repQuantity;
                gridLightFixtureView.Columns["EstimatedShipDate"].Caption = "Est Ship Date";
                gridLightFixtureView.Columns["Notes"].ColumnEdit = repNote;
                gridLightFixtureView.BestFitColumns();
                gridLightFixtureView.Columns["Notes"].Width = 300;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridLightFixtureView, "frmLightFixtureRevision");
                
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
                gridLightFixtureView.OptionsBehavior.Editable = false;
                gridLightFixtureView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    gridLightFixtureView.OptionsBehavior.Editable = true;
                    gridLightFixtureView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                        gridLightFixtureView.OptionsBehavior.Editable = false;
                        gridLightFixtureView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    }
                    else
                    {
                        gridLightFixtureView.OptionsBehavior.Editable = true;
                        gridLightFixtureView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    }

                }

            }


        }

        private void gridLightFixtureView_RowUpdated(object sender, RowObjectEventArgs e)
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

        private void gridLightFixtureView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRowView r = (DataRowView) e.Row;
            if (r[2].ToString().Trim().Length == 0)
            {
                e.ErrorText = "Light Fixture is required ...";
               
                e.Valid = false;
                
            }
        }

        private void gridLightFixtureView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
                (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = gridLightFixtureView.GetDataRow(gridLightFixtureView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("Delete Selected Item?", JCCLightFixture.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                JobLightFixtureRevisionDetail.Remove(r[0].ToString());
                                gridLightFixtureView.DeleteRow(gridLightFixtureView.GetSelectedRows()[0]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, JCCLightFixture.CCEApplication.ApplicationName);
                            }
                        }
                    }
                }
            }
        }

        private void gridLightFixtureView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
 
      
    }
}