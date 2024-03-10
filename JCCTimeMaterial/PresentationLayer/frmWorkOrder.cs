using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using JCCTimeMaterial.BusinessLayer;
using JCCTimeMaterial.Reports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
namespace JCCTimeMaterial.PresentationLayer
{
    public partial class frmWorkOrder : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private     DataTable materialDataTable;
        private     DataTable hoursDataTable;
        private     DataTable rentalsSubContractorsTable;
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
        public frmWorkOrder()
        {
            InitializeComponent();
        }
        //
        public frmWorkOrder(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmWorkOrder_Load(object sender, EventArgs e)
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
                    }
                }


                txtRecordID.DataBindings.Add("text", bindingSource, "JobTimeMaterialWorkOrderID");
                //
                cboAddressedTo.Properties.DataSource = Contact.GetJobContactForPullDown(jobID).Tables[0];
                cboAddressedTo.Properties.DisplayMember = "Name";
                cboAddressedTo.Properties.ValueMember = "ContactID";
                cboAddressedTo.Properties.PopulateColumns();
                cboAddressedTo.Properties.ShowHeader = false;
                cboAddressedTo.Properties.Columns[0].Visible = false;
                //
                repCraft.DataSource = TimeMaterialWorkOrderHour.GetJobTimeMaterialWorkOrderCraft().Tables[0];
                repCraft.DisplayMember = "CraftDescription";
                repCraft.ValueMember = "JobTimeMaterialWorkOrderCraftID";
                repCraft.PopulateColumns();
                repCraft.Columns[0].Visible = false;
                repCraft.Columns[1].Visible = false;
                repCraft.ShowHeader = false;
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetWorkOrder();
                }
                else
                {
                    GetWorkOrder();
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
        private void GetWorkOrderDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateWorkOrder(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtWorkOrderNumber.Text = "";
                cboAddressedTo.EditValue = null;
                txtReferenceNumber.Text = "";
                txtWorkRequestedBy.Text = "";
                txtWorkOrderTitle.Text = "";
                txtWorkOrderDescription.Text = "";
                txtCustomerTracking.Text = "";
                txtTechnician.Text = "";
                radioButton2.Checked = true;
                UnProtectForm();
            }
            GetWorkOrderItems(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
        }
        //
        private void ProtectForm()
        {
            //txtWorkOrderNumber.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            //txtWorkOrderNumber.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridWorkOrderMaterialView, "frmWorkOrderMaterial");
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdWorkOrderHoursView, "frmWorkOrderHours");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }



            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Work Order":
                    if (CheckWorkOrderStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetWorkOrder();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Work Order":
                    if (CheckWorkOrderStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetWorkOrder();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckWorkOrderStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetWorkOrder();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckWorkOrderStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetWorkOrder();
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
                case "Work Order":
                    try
                    {
                       Reports.Reports.TimeMaterialWorkOrder(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckWorkOrderStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveWorkOrder();
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
        private void SaveWorkOrder()
        {
           try
           {
                TimeMaterialWorkOrder workOrder = new TimeMaterialWorkOrder(
                    recordID,
                    jobID,
                    cboAddressedTo.EditValue == null ? "" : cboAddressedTo.EditValue.ToString(),
                    txtWorkRequestedBy.Text,
                    txtReferenceNumber.Text,
                    txtWorkOrderTitle.Text,
                    txtWorkOrderDescription.Text,
                    txtCustomerTracking.Text,
                    txtTechnician.Text,
                    radioButton1.Checked
                    );
                workOrder.Save();

                if (recordID == "" || recordID == "0")
                {
                    recordID = workOrder.JobTimeMaterialWorkOrderID;
                    txtRecordID.Text = recordID;
                    txtWorkOrderNumber.Text = TimeMaterialWorkOrder.GetWorkOrderNumber(recordID);
                }
                SaveWorkOrderItems();
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
        private void GetWorkOrder()
        {
            GetWorkOrderDetail(recordID);
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

                    }
                }

            }
        }
        //
        private void frmWorkOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridWorkOrderMaterialView, "frmWorkOrderMaterial");
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdWorkOrderHoursView, "frmWorkOrderHours");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckWorkOrderStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateWorkOrder(string recordID)
        {
            try
            {
                DataRow r;
                r = TimeMaterialWorkOrder.GetTimeMaterialWorkOrder(recordID).Tables[0].Rows[0];
                txtWorkOrderNumber.Text             = r["WorkOrderNumber"].ToString();
                cboAddressedTo.EditValue            = r["AddressedToID"];
                txtReferenceNumber.Text             = r["ReferenceNumber"].ToString();
                txtWorkRequestedBy.Text             = r["WorkRequestedBy"].ToString();
                txtWorkOrderTitle.Text              = r["WorkOrderTitle"].ToString();               
                txtWorkOrderDescription.Text        = r["WorkOrderDescription"].ToString();
                txtCustomerTracking.Text            = r["CustomerTrackingNumber"].ToString();
                txtTechnician.Text                  = r["Technician"].ToString();
                if (r["WorkComplete"].ToString() == "True")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            txtReferenceNumber.ErrorText = "";
            txtWorkRequestedBy.ErrorText = "";
            txtWorkOrderTitle.ErrorText = "";
            errorMessages = false;
            //
            if (txtReferenceNumber.Text.Trim() == "")
            {
                txtReferenceNumber.ErrorText = "Reference Number is Required";
                errorMessages = true;
            }
            //
            if (txtWorkRequestedBy.Text.Trim() == "")
            {
                txtWorkRequestedBy.ErrorText = "Requested By is Required";
                errorMessages = true;
            }
            //
            if (txtWorkOrderTitle.Text.Trim() == "")
            {
                txtWorkOrderTitle.ErrorText = "Work Order Title is Required";
                errorMessages = true;
            }
        }
        //
        private void GetWorkOrderItems(string jobTimeMaterialWorkOrderID)
        {
            try
            {
                materialDataTable = TimeMaterialWorkOrderMaterial.GetJobTimeMaterialWorkOrderMaterial(jobTimeMaterialWorkOrderID).Tables[0];

                this.grdWorkOrderMaterial.DataSource = materialDataTable.DefaultView;
                gridWorkOrderMaterialView.Columns["JobTimeMaterialWorkOrderID"].Visible = false;
                gridWorkOrderMaterialView.Columns["JobTimeMaterialWorkOrderMaterialID"].Visible = false;
                gridWorkOrderMaterialView.Columns["MaterialQuantity"].ColumnEdit = repQuantity;
                gridWorkOrderMaterialView.Columns["MaterialDescription"].ColumnEdit = repDescription;
                gridWorkOrderMaterialView.Columns["MaterialQuantity"].Caption = "Quantity";
                gridWorkOrderMaterialView.Columns["MaterialDescription"].Caption = "Description";
                gridWorkOrderMaterialView.BestFitColumns();
                gridWorkOrderMaterialView.Columns["MaterialQuantity"].Width = 100;
                gridWorkOrderMaterialView.Columns["MaterialDescription"].Width = 200;
                
                hoursDataTable = TimeMaterialWorkOrderHour.GetJobTimeMaterialWorkOrderHour(jobTimeMaterialWorkOrderID).Tables[0];
                this.grdWorkOrderHours.DataSource = hoursDataTable.DefaultView;
                grdWorkOrderHoursView.Columns["JobTimeMaterialWorkOrderID"].Visible = false;
                grdWorkOrderHoursView.Columns["JobTimeMaterialWorkOrderHourID"].Visible = false;
                grdWorkOrderHoursView.Columns["Employee"].ColumnEdit = repEmployee;
                grdWorkOrderHoursView.Columns["Hours"].ColumnEdit = repHours;
                grdWorkOrderHoursView.Columns["CraftID"].ColumnEdit = repCraft;
                grdWorkOrderHoursView.Columns["Rate"].ColumnEdit = repRate;
                grdWorkOrderHoursView.Columns["CraftID"].Caption = "Craft";
                grdWorkOrderHoursView.BestFitColumns();
                grdWorkOrderHoursView.Columns["Employee"].Width = 200;
                grdWorkOrderHoursView.Columns["CraftID"].Width = 200;

                rentalsSubContractorsTable = TimeMaterialRentalsSubcontractors.GetJobTimeMaterialRentalsSubcontractors(jobTimeMaterialWorkOrderID).Tables[0];
                grdRentalSubcontractos.DataSource = rentalsSubContractorsTable.DefaultView;
                grdRentalSubcontractorsView.Columns["JobTimeMaterialWorkOrderID"].Visible = false;
                grdRentalSubcontractorsView.Columns["JobTimeMaterialRentalsSubcontratorsID"].Visible = false;
                grdRentalSubcontractorsView.BestFitColumns();
                grdRentalSubcontractorsView.Columns["Description"].Width = 200;

                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridWorkOrderMaterialView, "frmWorkOrderMaterial");
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdWorkOrderHoursView, "frmWorkOrderHours");
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
                gridWorkOrderMaterialView.OptionsBehavior.Editable = false;
                gridWorkOrderMaterialView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                grdWorkOrderHoursView.OptionsBehavior.Editable = false;
                grdWorkOrderHoursView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                grdRentalSubcontractorsView.OptionsBehavior.Editable = false;
                grdRentalSubcontractorsView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            }
            else
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    gridWorkOrderMaterialView.OptionsBehavior.Editable = true;
                        gridWorkOrderMaterialView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

                        grdWorkOrderHoursView.OptionsBehavior.Editable = true;
                        grdWorkOrderHoursView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

                    grdRentalSubcontractorsView.OptionsBehavior.Editable = true;
                    grdRentalSubcontractorsView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                        gridWorkOrderMaterialView.OptionsBehavior.Editable = false;
                        gridWorkOrderMaterialView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                        grdWorkOrderHoursView.OptionsBehavior.Editable = false;
                        grdWorkOrderHoursView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                        grdRentalSubcontractorsView.OptionsBehavior.Editable = false;
                        grdRentalSubcontractorsView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                    }
                    else
                    {
                        gridWorkOrderMaterialView.OptionsBehavior.Editable = true;
                        gridWorkOrderMaterialView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

                        grdWorkOrderHoursView.OptionsBehavior.Editable = true;
                        grdWorkOrderHoursView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

                        grdRentalSubcontractorsView.OptionsBehavior.Editable = true;
                        grdRentalSubcontractorsView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    }
                }
            }
        }
        //
        private void SaveWorkOrderItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                TimeMaterialWorkOrderMaterial material;
                if (materialDataTable != null)
                {
                    foreach (DataRow r in materialDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                material = new TimeMaterialWorkOrderMaterial (
                                                    r["JobTimeMaterialWorkOrderMaterialID"].ToString(),
                                                    recordID,
                                                    r["MaterialQuantity"].ToString(),
                                                    r["MaterialDescription"].ToString());
                                material.Save();
                                r["JobTimeMaterialWorkOrderMaterialID"] = material.JobTimeMaterialWorkOrderMaterialID;
                                
                                break;
                            case DataRowState.Deleted:
                                TimeMaterialWorkOrderMaterial.Remove(r["JobTimeMaterialWorkOrderMaterialID"].ToString());
                                break;
                        }
                    }
               }


               TimeMaterialWorkOrderHour hour;
               if (hoursDataTable != null)
               {
                   foreach (DataRow r in hoursDataTable.Rows)
                   {
                       // Update Record
                       switch (r.RowState)
                       {
                           case DataRowState.Added:
                           case DataRowState.Modified:
                               hour = new TimeMaterialWorkOrderHour(
                                                   r["JobTimeMaterialWorkOrderHourID"].ToString(),
                                                   recordID,
                                                   r["Employee"].ToString(),
                                                   r["Hours"].ToString(),
                                                   r["CraftID"].ToString(),
                                                   r["Rate"].ToString(),
                                                   r["Date"].ToString());
                               hour.Save();
                               r["JobTimeMaterialWorkOrderHourID"] = hour.JobTimeMaterialWorkOrderHourID;
                               break;
                           case DataRowState.Deleted:
                               TimeMaterialWorkOrderHour.Remove(r["JobTimeMaterialWorkOrderHourID"].ToString());
                               break;
                       }
                   }
               }

                TimeMaterialRentalsSubcontractors rentals;
                if (rentalsSubContractorsTable != null)
                {
                    foreach (DataRow r in rentalsSubContractorsTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                rentals = new TimeMaterialRentalsSubcontractors(
                                                    r["JobTimeMaterialRentalsSubcontratorsID"].ToString(),
                                                    recordID,
                                                    r["Description"].ToString(),                                                  
                                                    r["Date"].ToString());
                               rentals.Save();
                                r["JobTimeMaterialRentalsSubcontratorsID"] = rentals.JobTimeMaterialRentalsSubcontratorsId;

                                break;
                            case DataRowState.Deleted:
                                TimeMaterialRentalsSubcontractors.Remove(r["JobTimeMaterialWorkOrderHourID"].ToString());
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
        private void gridWorkOrderMaterialView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCEquipmentRentalAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void grdWorkOrderHoursView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCEquipmentRentalAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void grdRentalSubcontractors_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCEquipmentRentalAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void gridWorkOrderMaterialView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void grdWorkOrderHoursView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
        private void grdRentalSubcontractors_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void labelControl5_Click ( object sender, EventArgs e )
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtWorkOrderDescription.Text;
            f.ShowDialog();
            txtWorkOrderDescription.Text = f.MyText;
            UpdateDataChange();
        }

        private void txtWorkOrderDescription_OnTextChanged ( object source, EventArgs e )
        {
            UpdateDataChange();
        }

        private void UpdateDataChange()
        {
            dataChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }
    }
}