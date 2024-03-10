using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CCEJobs.Subcontracts
{
    public partial class ctlSubcontract : UserControl
    {
        private string jobID;
        private string subcontractID;
        private bool errorMessages = false;
        private bool dataChanged = false;

        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;

        public enum ClickedButton
        {
            New,
            Save
        }
        public ctlSubcontract()
        {
            InitializeComponent();
        }

        public Security.Security.JobCaller JobCaller
        {
            set
            {
                jobCaller = value;
            }
        }        
        public string JobID
        {
            set
            {
                jobID = value;
                if (jobID == "")
                    jobID = "0";
                GetJobSubcontract();
            }
        }

        public bool IsUpdated
        {
            get { return dataChanged; }
        }

        public bool IsUpdatedCostCodes
        {
            get {return ctlSubcontractBudget.IsUpdated;}
        }
        public void SaveSubcontractCostCodes()
        {
            ctlSubcontractBudget.SaveSubcontractCostCodes();
        }
        private void ctlSubcontract_Load(object sender, EventArgs e)
        {
            Program.programHlp.SetHelpNavigator(this, HelpNavigator.TopicId);
            Program.programHlp.SetHelpKeyword(this, "2");
            //
            this.Cursor = Cursors.WaitCursor;
            tabSubcontract.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnGeneral.Down = true;
            tabSubcontract.SelectedTabPage = pagSubcontract;
            //
            cboVendor.Properties.DataSource =  JCCBusinessLayer.StaticTables.Vendors;
            cboVendor.Properties.DisplayMember = "Name";
            cboVendor.Properties.ValueMember = "VendorID";
            cboVendor.Properties.PopulateColumns();
            cboVendor.Properties.ShowHeader = false;
            //
            UpdateErrorMessages();
            SetControlAccess();
            
            this.Cursor = Cursors.Default;
        }

        private void UpdateTabStatus(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSubcontract.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnSubBudget.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            switch (e.Item.Caption)
            {
                case "Sub Info":
                    btnSubcontract.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnSubcontract.Down = true;
                    tabSubcontract.SelectedTabPage = pagSubcontract;
                    Program.programHlp.SetHelpKeyword(this, "2");
                    break;
                case "Sub Budget":
                    btnSubBudget.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnSubBudget.Down = true;
                    tabSubcontract.SelectedTabPage = pagBudget;
                    Program.programHlp.SetHelpKeyword(this, "31");
                    break;
            }
        }

        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUp.Enabled = false;
            btnDown.Enabled = false;

            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "&New":
                    if (CheckSubcontractStatus(ClickedButton.New))
                    {
                        subcontractID = "";
                        GetSubcontract(subcontractID);
                        dataChanged = false;
                        btnSave.Enabled = false;
                        NewSubcontractEnvironment();   
                    }
                    break;
                case "&Save":
                    if (CheckSubcontractStatus(ClickedButton.Save) == true)
                    {
                        //UpdateSubcontractEnvironment();
                    }
                        
                    break;
                case "&Sub Info. Sheet":
                    try
                    {
                        Reports.Reports.SubcontractSheet(jobID, subcontractID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
                    }
                    break;

                case "&Subcontract Sheet":
                    try
                    {
                        Reports.Reports.SubcontractChangeOrderDetail(ctlSubcontractBudget.SubcontractChangeOrderID, jobID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
                    }
                    break;
                case "&Change Order List":
                    try
                    {
                        Reports.Reports.SubcontractChangeOrderList(subcontractID, jobID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
                    }
                    break;
                case "&Subcontract Log":
                    try
                    {
                        Reports.Reports.JobSubcontractLog(subcontractID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
                    }
                    break;
            }
            //SetFormAccess();
        }

        public bool CheckSubcontractStatus(ClickedButton SelectedButton)
        {
            DialogResult result;
            bool retValue = false;
            //
            if (dataChanged)
            {
                result = MessageBox.Show("Save Subcontract changes?", JCCBusinessLayer.CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        if (ValidateAllControls())
                        {
                            SaveSubcontract();
                            dataChanged = false;
                            retValue = true;
                            GetJobSubcontract();
                        }
                        else
                        {
                            MessageBox.Show("Please make sure to enter all required fields.", JCCBusinessLayer.CCEApplication.ApplicationName);
                            retValue = false;
                        }
                        break;
                    case DialogResult.No:
                        if (String.IsNullOrEmpty(subcontractID))
                            UpdateCurrentSubcontract();
                        else 
                            GetSubcontract(subcontractID);
                        if (SelectedButton == ClickedButton.Save)
                            retValue = false;
                        else
                        {
                            dataChanged = false;
                            dxErrorProvider.ClearErrors();
                            retValue = true;
                        }
                        dataChanged = false;
                        break;
                    case DialogResult.Cancel:
                        if (SelectedButton == ClickedButton.Save)
                            retValue = false;
                        else
                        {
                            dataChanged = false;
                            dxErrorProvider.ClearErrors();
                            retValue = false;
                        }
                        break;
                }

            }
            else
            {
                dataChanged = false;
                dxErrorProvider.ClearErrors();
                retValue = true;
            }
            return retValue;
        }

        private void GetJobSubcontract()
        {
            try
            {

                grdSubcontracts.DataSource = Subcontract.GetSubcontracts(jobID).Tables[0];
                grdSubcontractView.Columns["SubcontractID"].Visible = false;
                grdSubcontractView.Columns["SubcontractNumber"].Caption = "Subcontract #";
                grdSubcontractView.Columns["ContractDescription"].Caption = "Description";
                grdSubcontractView.BestFitColumns();
                if (grdSubcontractView.RowCount == 0)
                    NewSubcontractEnvironment();
                //
                // Work on this item when finding a solution
                //
                // Find the current row
               // DevExpress.XtraGrid.Views.Base.ColumnView View = grdSubcontracts.MainView as DevExpress.XtraGrid.Views.Base.ColumnView;
               // DevExpress.XtraGrid.Columns.GridColumn col = View.Columns["SubcontractID"];
               /// col.Visible = true;
               // int rowHandle = 0;
                
               // rowHandle = View.LocateByDisplayText(rowHandle, col, subcontractID);
                
                
               // grdSubcontractView.SelectRow(rowHandle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
            }
        }

        private void grdSubcontractView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateCurrentSubcontract();
        }

        private void UpdateCurrentSubcontract()
        {
            if (grdSubcontractView.SelectedRowsCount <= 0)
            {
                GetSubcontract("");
                return;
            }
            try
            {
                DataRow dataRow = null;
                dataRow = grdSubcontractView.GetDataRow(grdSubcontractView.GetSelectedRows()[0]);

                subcontractID = dataRow["SubcontractID"].ToString(); ;
                GetSubcontract(subcontractID);
                UpdateErrorMessages();
                UpdateSubcontractEnvironment();
                ctlSubcontractBudget.JobCaller = jobCaller;
                ctlSubcontractBudget.SubcontractID = subcontractID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
            }
        }

        private void NewSubcontractEnvironment()
        {
            ribbonReport.Visible = false;
            ribbonProductivity.Visible = false;
            lblMSA.Visible = true;
            chkMSA.Visible = true;
            lblSequenceNumber.Visible = true;
            cboSequenceNumber.Visible = true;
            cboSequenceNumber.Text = "";
            //
            btnSubcontract.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnSubcontract.Down = true;
            tabSubcontract.SelectedTabPage = pagSubcontract;
            Program.programHlp.SetHelpKeyword(this, "2");
        }
        private void UpdateSubcontractEnvironment()
        {
            ribbonReport.Visible = true;
            ribbonProductivity.Visible = true;
            lblSequenceNumber.Visible = false;
            cboSequenceNumber.Visible = false;
            lblMSA.Visible = false;
            chkMSA.Visible = false;
        }
        private void SaveSubcontract()
        {
            try
            {
                Subcontract sub = new Subcontract(subcontractID, 
                                                jobID, 
                                                txtSubcontractNumber.Text,
                                                chkMSA.Checked.ToString(),
                                                txtVendorID.Text,
                                                txtContractDescription.Text,
                                                txtRetainagePercent.Text,
                                                chkPerformanceBondRequired.Checked.ToString(),
                                                txtDateBondReceived.Text,
                                                chkContractRequired.Checked.ToString(),
                                                txtDateContractReceived.Text,
                                                chkInsuranceCertifiedRequired.Checked.ToString(),
                                                txtInsuranceCertificateExpiredDateA.Text,
                                                txtInsuranceCertificateExpiredDateB.Text,
                                                txtInsuranceCertificateExpiredDateC.Text,
                                                txtContractDate.Text,
                                                String.IsNullOrEmpty(txtOriginalContract.Text) ? "0" : txtOriginalContract.EditValue.ToString(),
                                                String.IsNullOrEmpty(txtBuyoutAmount.Text) ? "0" : txtBuyoutAmount.EditValue.ToString(),
                                                chkLienWaiverFlag.Checked.ToString(),
                                                txtLienWaiverDate.Text,
                                                chkSubmittalRequiredFlag.Checked.ToString(),
                                                txtSubmittalReceivedDate.Text,
                                                String.IsNullOrEmpty(cboSequenceNumber.Text)? "": cboSequenceNumber.Text,
                                                txtReleaseNumber.Text,
                                                txtPONumber.Text);
                sub.Save();
                subcontractID = sub.SubcontractID;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
            }

        }
        private void GetSubcontract(string subcontractID)
        {
            if (!String.IsNullOrEmpty(subcontractID))
            {
                try
                {
                    DataRow r = Subcontract.GetSubcontract(subcontractID).Tables[0].Rows[0] ;

                    txtSubcontractNumber.Text = r["SubcontractNumber"].ToString();
                    chkMSA.Checked = r["MSA"].ToString() == "True" ? true : false;
                    cboVendor.EditValue = r["VendorID"].ToString();
                    txtVendorID.Text = r["VendorID"].ToString();
                    txtContractDescription.Text = r["ContractDescription"].ToString();
                    txtRetainagePercent.Text = r["retainagePercent"].ToString();
                    txtContractDate.Text = String.IsNullOrEmpty(r["ContractDate"].ToString()) ? null : r["ContractDate"].ToString().Substring(0, 10);
                    txtOriginalContract.Text = r["OriginalContract"].ToString();
                    txtBuyoutAmount.Text = r["BuyoutAmount"].ToString();
                    
                    chkPerformanceBondRequired.Checked = r["PerformanceBondRequired"].ToString() == "True" ? true : false;
                    txtDateBondReceived.Text = String.IsNullOrEmpty(r["DateBondReceived"].ToString()) ? null : r["DateBondReceived"].ToString().Substring(0, 10);
                    chkContractRequired.Checked = r["ContractRequired"].ToString() == "True" ? true : false;
                    txtDateContractReceived.Text = String.IsNullOrEmpty(r["DateContractReceived"].ToString()) ? null : r["DateContractReceived"].ToString().Substring(0, 10);
                    chkInsuranceCertifiedRequired.Checked = r["InsuranceCertificateRequired"].ToString() == "True" ? true : false;
                    txtInsuranceCertificateExpiredDateA.Text = String.IsNullOrEmpty(r["InsuranceCertificateExpiredDateA"].ToString()) ? null : r["InsuranceCertificateExpiredDateA"].ToString().Substring(0, 10);
                    txtInsuranceCertificateExpiredDateB.Text = String.IsNullOrEmpty(r["InsuranceCertificateExpiredDateB"].ToString()) ? null : r["InsuranceCertificateExpiredDateB"].ToString().Substring(0, 10);
                    txtInsuranceCertificateExpiredDateC.Text = String.IsNullOrEmpty(r["InsuranceCertificateExpiredDateC"].ToString()) ? null : r["InsuranceCertificateExpiredDateC"].ToString().Substring(0, 10);
                    chkLienWaiverFlag.Checked = r["LienWaiverFlag"].ToString() == "True" ? true : false;
                    txtLienWaiverDate.Text = String.IsNullOrEmpty(r["LienWaiverDate"].ToString()) ? null : r["LienWaiverDate"].ToString().Substring(0, 10);
                    chkSubmittalRequiredFlag.Checked = r["SubmittalRequiredFlag"].ToString() == "True" ? true : false;
                    txtSubmittalReceivedDate.Text = String.IsNullOrEmpty(r["SubmittalReceivedDate"].ToString()) ? null : r["SubmittalReceivedDate"].ToString().Substring(0, 10);
                    txtReleaseNumber.Text = r["ReleaseNumber"].ToString();
                    txtPONumber.Text = r["PONumber"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, JCCBusinessLayer.CCEApplication.ApplicationName);
                }
            }
            else
            {
                txtSubcontractNumber.Text = null;
                chkMSA.Checked = false;
                cboVendor.EditValue = String.Empty;
                txtContractDescription.Text = null;
                txtRetainagePercent.Text = null;
                txtContractDate.Text = null;
                txtOriginalContract.Text = null;
                txtBuyoutAmount.Text = null;
                //
                chkPerformanceBondRequired.Checked = false;
                txtDateBondReceived.Text = null;
                chkContractRequired.Checked = false;
                txtDateContractReceived.Text = null;
                chkInsuranceCertifiedRequired.Checked = false;
                txtInsuranceCertificateExpiredDateA.Text = null;
                txtInsuranceCertificateExpiredDateB.Text = null;
                txtInsuranceCertificateExpiredDateC.Text = null;
                chkLienWaiverFlag.Checked = false;
                txtLienWaiverDate.Text = null;
                chkSubmittalRequiredFlag.Checked = false;
                txtSubmittalReceivedDate.Text = null;
                txtReleaseNumber.Text = null;
                txtPONumber.Text = null;
            }
            dataChanged = false;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
        }
        //
        private void cboVendor_EditValueChanged(object sender, EventArgs e)
        {
            txtVendorID.Text = cboVendor.EditValue.ToString();
            AllControls_EditValue(sender, e);
        }
        //
        private void UpdateErrorMessages()
        {
            errorMessages = false;
            cboSequenceNumber.ErrorText = "";
            cboVendor.ErrorText = "";
            txtContractDescription.ErrorText = "";
            txtContractDate.ErrorText = "";
            txtOriginalContract.ErrorText = "";

            txtDateBondReceived.ErrorText = "";
            txtDateContractReceived.ErrorText = "";
            txtInsuranceCertificateExpiredDateA.ErrorText = "";
            txtInsuranceCertificateExpiredDateB.ErrorText = "";
            txtInsuranceCertificateExpiredDateC.ErrorText = "";
            txtLienWaiverDate.ErrorText = "";
            txtSubmittalReceivedDate.ErrorText = "";

            if (String.IsNullOrEmpty(subcontractID))
            {
                if (cboSequenceNumber.Text.Trim().Length == 0)
                {
                    cboSequenceNumber.ErrorText = "Sequence Number is Required";
                    errorMessages = true;
                }
            }
            if (cboVendor.Text.Trim().Length == 0)
            {
                cboVendor.ErrorText = "Vendor is Required";
                errorMessages = true;
            }
            if (txtContractDescription.Text.Trim().Length == 0)
            {
                txtContractDescription.ErrorText = "Subcontract Description is Required";
                errorMessages = true;
            }
            if (txtContractDate.Text.Trim().Length == 0)
            {
                txtContractDate.ErrorText = "Contract Dare is Required";
                errorMessages = true;
            }
            if (chkPerformanceBondRequired.CheckState == CheckState.Checked)
            {
                if (txtDateBondReceived.Text.Trim().Length == 0)
                {
                    txtDateBondReceived.ErrorText = "Date Bond Rec. is Required";
                    errorMessages = true;
                }
            }
            else
                txtDateBondReceived.Text = null;
            if (chkContractRequired.CheckState == CheckState.Checked)
            {
                if (txtDateContractReceived.Text.Trim().Length == 0)
                {
                    txtDateContractReceived.ErrorText = "Date Contract Recd. is Required";
                    errorMessages = true;
                }
            }
            else
                txtDateContractReceived.Text = null;
            if (chkInsuranceCertifiedRequired.CheckState == CheckState.Checked)
            {
                if (txtInsuranceCertificateExpiredDateA.Text.Trim().Length == 0 &&
                    txtInsuranceCertificateExpiredDateB.Text.Trim().Length == 0 &&
                    txtInsuranceCertificateExpiredDateC.Text.Trim().Length == 0)
                {
                    txtInsuranceCertificateExpiredDateA.ErrorText = "G/L, W/C, or Auto is Required";
                    txtInsuranceCertificateExpiredDateB.ErrorText = "G/L, W/C, or Auto is Required";
                    txtInsuranceCertificateExpiredDateC.ErrorText = "G/L, W/C, or Auto is Required";
                    errorMessages = true;
                }
            }
            else
            {
                txtInsuranceCertificateExpiredDateA.Text = null;
                txtInsuranceCertificateExpiredDateB.Text = null;
                txtInsuranceCertificateExpiredDateC.Text = null;
            }
            if (chkLienWaiverFlag.CheckState == CheckState.Checked)
            {
                if (txtLienWaiverDate.Text.Trim().Length == 0)
                {
                    txtLienWaiverDate.ErrorText = "Date Last Recd. is Required";
                    errorMessages = true;
                }
            }
            else
                txtLienWaiverDate.Text = null;
            if (chkSubmittalRequiredFlag.CheckState == CheckState.Checked)
            {
                if (txtSubmittalReceivedDate.Text.Trim().Length == 0)
                {
                    txtSubmittalReceivedDate.ErrorText = "Date Submittal Recd. is Required";
                    errorMessages = true;
                }
            }
            else
                txtSubmittalReceivedDate.Text = null;
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
                string myString = myControl.Text.Trim().ToUpper();

                if (myString != myControl.Text.Trim())
                    myControl.Text = myControl.Text.ToString().ToUpper();
            }
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
            {
                dataChanged = false;
                return;
            }


        //    if (!dataChanged)
        //    {
               //
               // Add Flag for Those Status
               // if (!chkVoid.Checked && !chkArchive.Checked)
                {
                    dataChanged = true;
                    btnSave.Enabled = true;
                    btnNew.Enabled = false;
                }
          //  }
            UpdateErrorMessages();
        }

        private void grdSubcontractView_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (dataChanged)
            {
                if (CheckSubcontractStatus(ClickedButton.Save) == true)
                {
                   // Atef Bakir
                    // ribbonReport.Visible = true;
                   // ribbonProductivity.Visible = true;
                }
                if (dataChanged)
                    e.Allow = false;
            }
        }

        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly )
            {
                ribbonSubcontractAction.Visible = false;
                
            }
            else
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadWriteCreate || Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.RedWriteCreateSB )
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                else
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                ribbonSubcontractAction.Visible = true;
            }
        }

       
    }
}
