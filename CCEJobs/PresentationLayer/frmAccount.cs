using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BakirConsulting.DataAccessLayer;
using WindowsClient.Reports;
using WindowsClient.Controls;
using WindowsClient.BusinessLayer;

namespace WindowsClient.PresentationLayer
{
    public partial class frmAccount : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DevExpress.XtraReports.UI.XtraReport accountReport;
        protected int recordID;
        protected BindingSource bindingSource;
        protected System.Collections.Hashtable recordHasTable = new System.Collections.Hashtable();
        protected bool dataChanged;

        public frmAccount()
        {
            InitializeComponent();
        }

        public frmAccount(int RecordID)
        {
            recordID = RecordID;
            InitializeComponent();
        }

        public frmAccount(int RecordID, BindingSource BindingSource)
        {
            recordID = RecordID;
            bindingSource = BindingSource;
            InitializeComponent();
        }


        private void frmAccount_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            tabAccount.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnGeneral.Down = true;
            //
            // Load Combo Box
            //
            cboAccountGroup.Properties.DataSource = StaticTabbles.accountGroup;
            cboAccountGroup.Properties.PopulateColumns();
            cboAccountGroup.Properties.DisplayMember = "AccountGroupDescription";
            cboAccountGroup.Properties.ValueMember = "AccountGroupID";
            cboAccountGroup.Properties.Columns[0].Visible = false;

            cboAccountType.Properties.DataSource = StaticTabbles.accountType;
            cboAccountType.Properties.PopulateColumns();
            cboAccountType.Properties.DisplayMember = "AccountTypeDescription";
            cboAccountType.Properties.ValueMember = "AccountTypeID";
            cboAccountType.Properties.Columns[0].Visible = false;

            cboStrategicImportance.Properties.DataSource = StaticTabbles.strategicImportance;
            cboStrategicImportance.Properties.PopulateColumns();
            cboStrategicImportance.Properties.DisplayMember = "StrategicImportanceDescription";
            cboStrategicImportance.Properties.ValueMember = "StrategicImportanceID";
            cboStrategicImportance.Properties.Columns[0].Visible = false;

            cboLIS.Properties.DataSource = StaticTabbles.lis;
            cboLIS.Properties.PopulateColumns();
            cboLIS.Properties.DisplayMember = "LISDescription";
            cboLIS.Properties.ValueMember = "LASID";
            cboLIS.Properties.Columns[0].Visible = false;

            cboAccountRegion.Properties.DataSource = StaticTabbles.accountRegion;
            cboAccountRegion.Properties.PopulateColumns();
            cboAccountRegion.Properties.DisplayMember = "AccountRegionDescription";
            cboAccountRegion.Properties.ValueMember = "AccountRegionID";
            cboAccountRegion.Properties.Columns[0].Visible = false;
            //
            // Binding Data Source
            //
            txtAccountID.DataBindings.Add("text", bindingSource, "Account ID");
            txtAccountNumber.DataBindings.Add("text", bindingSource, "Account Number");
            txtAccountName.DataBindings.Add("text", bindingSource, "Account Name");
            txtAddress.DataBindings.Add("text", bindingSource, "Address");
            txtCity.DataBindings.Add("text", bindingSource, "City");
            txtState.DataBindings.Add("text", bindingSource, "State");

            txtCountry.DataBindings.Add("text", bindingSource, "Country");
            txtZipCode.DataBindings.Add("text", bindingSource, "Postal Code");
            txtWebAddress.DataBindings.Add("text", bindingSource, "Web Site Address");
            txtBBStaffNumber.DataBindings.Add("text", bindingSource, "BBS Staff Number");
            txtNATLABStaffNumber.DataBindings.Add("text", bindingSource, "NAT Lab Staff Number");
            txtShiftNumber.DataBindings.Add("text", bindingSource, "Shift Hours");
            txtCustomerSince.DataBindings.Add("text", bindingSource, "Customer Since");
            cboStrategicImportance.DataBindings.Add("EditValue", bindingSource, "Strategic Importance");
            cboAccountGroup.DataBindings.Add("EditValue", bindingSource, "Group");
            cboAccountRegion.DataBindings.Add("EditValue", bindingSource, "Region");
            cboAccountType.DataBindings.Add("EditValue", bindingSource, "Type");
            cboLIS.DataBindings.Add("EditValue", bindingSource, "LIS");
            chkDRM.DataBindings.Add("EditValue", bindingSource, "DRM");
            txtMainPhone.DataBindings.Add("text", bindingSource, "Main Phone");
            txtMainFax.DataBindings.Add("text", bindingSource, "Main Fax");
            txtLatitude.DataBindings.Add("text", bindingSource, "Latitude");
            txtLongitude.DataBindings.Add("text", bindingSource, "Longitude");

            //
            // Build Error Validation
            //
            recordHasTable.Add("txtAccountNumber", "Account Number is Required");
            recordHasTable.Add("txtAccountName", "Account Name is Required");
            recordHasTable.Add("txtAddress", "Address is Required");
            recordHasTable.Add("txtCity", "City is Required");
            recordHasTable.Add("txtState", "State is Required");
            recordHasTable.Add("txtZipCode", "Zip Code is Required");
            recordHasTable.Add("txtCountry", "Country is Required");
            recordHasTable.Add("txtCustomerSince", "Customer Since is Required");
            recordHasTable.Add("cboStrategicImportance", "Strategic Importance is Required");
            recordHasTable.Add("cboAccountGroup", "Account Group is Required");
            recordHasTable.Add("cboAccountRegion", "Account Region is Required");
            recordHasTable.Add("cboAccountType", "Account Type is Required");
            recordHasTable.Add("cboLIS", "LIS is Required");

            dataChanged = false;
            btnUndo.Enabled = false;
            if (recordID == 0)
                bindingSource.AddNew();
            UpdateControls();
            UpdateDonationRevenue();
            this.Cursor = Cursors.Default;
        }

        //
        // 

        private void btnGeneral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            UpdateButtonStatus();
            btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnGeneral.Down = true;
            tabAccount.SelectedTabPage = pgGeneral;
           
        }


        private void btnSolution_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateButtonStatus();
            btnSolution.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnSolution.Down = true;
            tabAccount.SelectedTabPage = pgSolution;

        }

        private void btnContact_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateButtonStatus();
            btnContact.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnContact.Down = true;
            tabAccount.SelectedTabPage = pgContact;

        }

        private void btnStaff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateButtonStatus(); 
            btnStaff.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnStaff.Down = true;
            tabAccount.SelectedTabPage = pgStaff;
        }

        private void btnDonation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateButtonStatus(); 
            btnDonation.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnDonation.Down = true;
            tabAccount.SelectedTabPage = pgDonation;

        }

        private void btnRevenue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateButtonStatus();
            btnRevenue.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnRevenue.Down = true;
            tabAccount.SelectedTabPage = pgRevenue;
        }

  
        private void btnNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateButtonStatus();
            btnNote.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnNote.Down = true;
            tabAccount.SelectedTabPage = pgNote;
        }

        private void btnRUF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateButtonStatus();
            btnRUF.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnRUF.Down = true;
            tabAccount.SelectedTabPage = pgRUF;
        }
        private void UpdateButtonStatus()
        {
                btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                btnSolution.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                btnSoftware.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                btnContact.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                btnStaff.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                btnDonation.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                btnRevenue.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                btnNote.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                btnRUF.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
        
        
        }

        private void iPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accountReport = new WindowsClient.Reports.AccountReport(recordID);
            
            
            WindowsClient.PresentationLayer.frmReport myReport = new frmReport(accountReport);
            myReport.ShowDialog();
            
        }
      
        //
        // Buttons Status
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            this.Cursor = Cursors.WaitCursor;
            switch (name)
            {
                case "Next Account":
                    if (CheckAccountStatus())
                    {
                        bindingSource.MoveNext();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (txtAccountID.Text.Trim().Length == 0)
                            recordID = 0;
                        else
                            recordID = Int16.Parse(txtAccountID.Text);
                        UpdateControls();
                        UpdateDonationRevenue();
                    }
                    break;
                case "Previous Account":
                    if (CheckAccountStatus())
                    {
                        bindingSource.MovePrevious();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (txtAccountID.Text.Trim().Length == 0)
                            recordID = 0;
                        else
                            recordID = Int16.Parse(txtAccountID.Text);
                        UpdateControls();
                        UpdateDonationRevenue();

                    }
                    break;
                case "&Delete":
                    if (txtAccountID.Text.Trim().Length > 0)
                    {
                        if (MessageBox.Show("Delete current Account", App.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DeleteAccount();
                            bindingSource.RemoveCurrent();
                            dataChanged = false;
                            btnUndo.Enabled = false;
                          
                        }
                    }
                    break;
                case "New":
                    if (CheckAccountStatus())
                    {
                        bindingSource.AddNew();
                        chkDRM.Checked = false;
                        dataChanged = false;
                        btnUndo.Enabled = false;

                        UpdateControls();

                    }
                    break;
                case "&Save":
                    CheckAccountStatus();                   
                    break;
                case "&Undo":
                    bindingSource.CancelEdit();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    break;
                case "&Print":
                   // staffReport = new WindowsClient.Reports.StaffReport(Convert.ToInt16(txtStaffID.Text));

                   // WindowsClient.PresentationLayer.frmReport myReport = new frmReport(staffReport);
                   // myReport.ShowDialog();
                    break;
            }
            this.Cursor = Cursors.Default;
        }

        private bool CheckAccountStatus()
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", App.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveRecord();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    bindingSource.CancelEdit();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    dxErrorProvider1.ClearErrors();
                    return true;
                }
            }
            else
            {
                bindingSource.CancelEdit();
                dataChanged = false;
                btnUndo.Enabled = false;
                dxErrorProvider1.ClearErrors();
                return true;
            }
        }
        

        private void SaveRecord()
        {
            int accountID = 0;
            if (txtAccountID.Text.Trim().Length > 0)
                accountID = Int16.Parse(txtAccountID.Text.Trim());
            try
            {
                Account account = new Account(accountID,
                                            txtAccountNumber.Text.Trim(),
                                            cboAccountType.EditValue.ToString(),
                                            cboAccountGroup.EditValue.ToString(),
                                            cboAccountRegion.EditValue.ToString(),
                                            txtAccountName.Text,
                                            txtLatitude.Text,
                                            txtLongitude.Text,
                                            txtAddress.Text,
                                            txtCity.Text,
                                            txtState.Text,
                                            txtZipCode.Text,
                                            txtCountry.Text,
                                            txtBBStaffNumber.Text,
                                            txtNATLABStaffNumber.Text,
                                            txtWebAddress.Text,
                                            txtShiftNumber.Text,
                                            txtCustomerSince.Text,
                                            txtMainPhone.Text,
                                            txtMainFax.Text,
                                            cboStrategicImportance.EditValue.ToString(),
                                            cboLIS.EditValue.ToString(),
                                            chkDRM.Checked);
                account.Save();
                txtAccountID.Text = account.AccountID.ToString();
                account = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, App.ApplicationName, MessageBoxButtons.OK);
                bindingSource.CancelEdit();
                dataChanged = false;
                btnUndo.Enabled = false;
            }

        }

        private void ControlValidating(object sender, CancelEventArgs e)
        {
            string key;
            string value;

            key = ((Control)sender).Name;
            if (recordHasTable.ContainsKey(key))
            {
                value = recordHasTable[key].ToString();
                if (((Control)sender).Text.Trim().Length == 0)
                {
                    dxErrorProvider1.SetError((Control)sender, value);
                    e.Cancel = true;
                    
                }
                else
                {
                    dxErrorProvider1.SetError((Control)sender, null);
                }
            }
        }


        private void AllControls_EditValueChanged(object sender, EventArgs e)
        {

            dataChanged = true;
            btnUndo.Enabled = true;        
        }

        private bool ValidateAllControls()
        {

           bool returnValue = true;
 
            foreach (string key in recordHasTable.Keys)
           {

               if (this.panelControl2.Controls[key].Text.Trim().Length == 0)
               {
                   dxErrorProvider1.SetError(this.panelControl2.Controls[key], recordHasTable[key].ToString());
                   returnValue= false;
               }
                else
                   dxErrorProvider1.SetError(this.panelControl2.Controls[key], null);
           }
            return returnValue;

                
        }

        private void ctlAccountSystem_FocusRowChange(object sender, int RecordID)
        {
            ctlAccountSystemAssay.UpdateGrid(RecordID);
            ctlAccountSystemInstrument.UpdateGrid(RecordID);
            ctlAccountSystemEval.UpdateGrid(RecordID);
            ctlAccountSystemNote.UpdateGrid(RecordID);
        }

        private void frmAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckAccountStatus();
            foreach (Control ctl in this.panelControl2.Controls)
                ctl.DataBindings.Clear();
        }

        private void ctlAccountSystemAssay_FocusRowChange(object sender, int RecordID)
        {
            ctlAccountSystemAssayPathogen.UpdateGrid(RecordID);
        }

        private void ctlAccountSystemInstrument_FocusRowChange(object sender, int RecordID)
        {
            ctlAccountSystemInstrumentSoftware.UpdateGrid(RecordID);
        }

        private void btnSoftware_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateButtonStatus();
            btnSoftware.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            btnSoftware.Down = true;
            tabAccount.SelectedTabPage = pgSoftware;
        }

        private void UpdateControls()
        {
            ctlAccountSystem.UpdateGrid(recordID);
            ctlAccountContact.UpdateGrid(recordID);
            ctlAccountStaff.UpdateGrid(recordID);
           
            ctlAccountSoftware.UpdateGrid(recordID);
            ctlAccountDonation.UpdateGrid(recordID);
            ctlAccountRevenue.UpdateGrid(recordID);
            ctlAccountNote.UpdateGrid(recordID);
            ctlAccountRUF.UpdateGrid(recordID);
        }

        private void UpdateDonationRevenue()
        {
            DataSet ds;
            DataRow dr;

            int accountID = 0;
            if (txtAccountID.Text.Trim().Length > 0)
                accountID = Int16.Parse(txtAccountID.Text.Trim());
            try
            {
                txtDonationNumber.Text = Account.AccountDonation(accountID);
                txtRevenue.Text = Account.AccountRevenue(accountID);
                ds = Account.AccountMainContact(accountID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    txtTitle.Text = dr[3].ToString();
                    txtRole.Text = dr[11].ToString();
                    txtFirstName.Text = dr[4].ToString();
                    txtLastName.Text = dr[5].ToString();
                    txtPhone.Text = dr[6].ToString();
                    txtFax.Text = dr[7].ToString();
                    txtEmail.Text = dr[8].ToString();
                }
                else
                {
                    txtTitle.Text = "";
                    txtRole.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPhone.Text = "";
                    txtFax.Text = "";
                    txtEmail.Text = "";
                }

                ds = Account.AccountRUF(accountID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    txtActualRUF.Text = dr[3].ToString();
                    txtTargetRUF.Text = dr[4].ToString();
                }
                else
                {
                    txtActualRUF.Text = "";
                    txtTargetRUF.Text = "";
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, App.ApplicationName, MessageBoxButtons.OK);
            }
        }

        private void DeleteAccount()
        {
            int accountID = 0;
            if (txtAccountID.Text.Trim().Length > 0)
                accountID = Int16.Parse(txtAccountID.Text.Trim());
            if (accountID > 0)
            {
                try
                {
                    Account.Remove(accountID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, App.ApplicationName, MessageBoxButtons.OK);
                }
            }
        }



    }
}