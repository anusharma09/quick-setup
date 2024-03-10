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
    public partial class frmLightFixtureRelease : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private     DataTable lightFixtureListTable;
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
        public frmLightFixtureRelease()
        {
            InitializeComponent();
        }
        //
        public frmLightFixtureRelease(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmLightFixtureRelease_Load(object sender, EventArgs e)
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
                txtRecordID.DataBindings.Add("text", bindingSource, "JobLightFixtureReleaseID");
                //
                lightFixtureListTable = JobLightFixture.GetJobLightFixturePullDown(jobID).Tables[0];
                repLightFixture.DataSource = lightFixtureListTable;
                repLightFixture.DisplayMember = "Type";
                repLightFixture.ValueMember = "JobLightFixtureID";
                repLightFixture.PopulateColumns();
                repLightFixture.Columns[0].Visible = false;
                lightFixtureListTable.PrimaryKey = new DataColumn[] { lightFixtureListTable.Columns["JobLightFixtureID"] };
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetLightFixtureRelease();
                }
                else
                {
                    GetLightFixtureRelease();
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
        private void GetLightFixtureReleaseDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateLightFixtureRelease(recordID);
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
            GetLightFixtureReleaseItems(recordID);
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
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridLightFixtureView, "frmLightFixtureRelease");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }


            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Light Fixture Release":
                    if (CheckLightFixtureReleaseStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetLightFixtureRelease();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "Previous Light Fixture Release":
                    if (CheckLightFixtureReleaseStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetLightFixtureRelease();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckLightFixtureReleaseStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetLightFixtureRelease();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckLightFixtureReleaseStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetLightFixtureRelease();
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

                        if (MessageBox.Show("You are about to delete the selected Light Fixture Release item. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var releaseDetailID = gridLightFixtureView.GetDataRow(selectedRowHandles[0]).ItemArray[0];
                            try
                            {
                                JobLightFixtureReleaseDetail.Remove(releaseDetailID.ToString());
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
                        if (MessageBox.Show("You are about to delete Light Fixture Release. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    JobLightFixtureRelease.Remove(txtRecordID.Text);
                                    recordID = "0";
                                    txtRecordID.Text = "0";
                                    ribbonReport.Visible = false;
                                    GetLightFixtureRelease();
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
                case "Light Fixture Release":
                    try
                    {
                        Reports.Reports.LightFixtureReleaseForm(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckLightFixtureReleaseStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveLightFixtureRelease();
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
        private void SaveLightFixtureRelease()
        {
           try
           {
               JobLightFixtureRelease light = new JobLightFixtureRelease(recordID,
                                   jobID,
                                   txtPONumber.Text,
                                   txtReleaseDate.EditValue == null ? "" : txtReleaseDate.EditValue.ToString());

                light.Save();
                if (recordID == "" || recordID == "0")
                    txtReleaseNumber.Text = light.ReleaseNumber;
                recordID = light.JobLightFixtureReleaseID;
                txtRecordID.Text = recordID;
                SaveLightFixtureReleaseItems();
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
        private void SaveLightFixtureReleaseItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                JobLightFixtureReleaseDetail item;
                if ( lightFixtureDetailDataTable != null)
                {
                    foreach (DataRow r in lightFixtureDetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                item = new  JobLightFixtureReleaseDetail(
                                                    r["JobLightFixtureReleaseDetailID"].ToString(),
                                                    recordID,
                                                    r["JobLightFixtureID"].ToString(),
                                                    r["QtyRun"].ToString(),
                                                    r["Length"].ToString(),
                                                    r["EstimatedShipDate"].ToString(),
                                                    r["Notes"].ToString());
                                item.Save();
                                r["JobLightFixtureReleaseDetailID"] = item.JobLightFixtureReleaseDetailID;

                                break;
                            case DataRowState.Deleted:
 //                               JobLightFixtureReleaseDetail.Remove(r["JobLightFixtureReleaseDetailID"].ToString());
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
        private void GetLightFixtureRelease()
        {
            GetLightFixtureReleaseDetail(recordID);
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
        private void frmLightFixtureRelease_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridLightFixtureView, "frmLightFixtureRelease");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckLightFixtureReleaseStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateLightFixtureRelease(string recordID)
        {
            try
            {
                DataRow r;
                r = JobLightFixtureRelease.GetLightFixtureRelease(recordID).Tables[0].Rows[0];

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
        private void GetLightFixtureReleaseItems(string jobLightFixtureReleaseID)
        {
            try
            {
                lightFixtureDetailDataTable = JobLightFixtureRelease.GetLightFixtureReleaseItems(jobLightFixtureReleaseID).Tables[0];

                this.grdLightFixture.DataSource = lightFixtureDetailDataTable.DefaultView;
                gridLightFixtureView.Columns["JobLightFixtureReleaseID"].Visible = false;
                gridLightFixtureView.Columns["JobLightFixtureReleaseDetailID"].Visible = false;
                gridLightFixtureView.Columns["JobLightFixtureID"].Caption = "Light Fixture";
                gridLightFixtureView.Columns["JobLightFixtureID"].ColumnEdit = repLightFixture;
                gridLightFixtureView.Columns["QtyRun"].Caption = "Qty Run";
                gridLightFixtureView.Columns["QtyRun"].ColumnEdit = repQuantity;
                gridLightFixtureView.Columns["Length"].ColumnEdit = repQuantity;
                gridLightFixtureView.Columns["EstimatedShipDate"].Caption = "Est Ship Date";
                gridLightFixtureView.Columns["Notes"].ColumnEdit = repNote;
                gridLightFixtureView.BestFitColumns();
                gridLightFixtureView.Columns["Notes"].Width = 300;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridLightFixtureView, "frmLightFixtureRelease");
                
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
                                JobLightFixtureReleaseDetail.Remove(r[0].ToString());
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

        private void gridLightFixtureView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "JobLightFixtureID")
            {
                try
                {
                    DataRow r;
                    r = lightFixtureListTable.Rows.Find(e.Value.ToString());
                    DataRow rr = gridLightFixtureView.GetDataRow(e.RowHandle);
                    rr["QtyRun"] = r[4].ToString() == "" ? 0 : r[4];
                    rr["Length"] = r[5].ToString() == "" ? 0 : r[5];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }

            }

        }
 
      
    }
}