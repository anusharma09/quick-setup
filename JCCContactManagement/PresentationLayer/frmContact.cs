using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCContactManagement.BusinessLayer;
using JCCContactManagement;
using System.Web;
using System.Net.Mail;
namespace JCCContactManagement.PresentationLayer
{
    public partial class frmContact : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
        protected string companyID = "0";
        protected BindingSource bindingSource;
        protected bool dataChanged;
        private bool errorMessages = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        private bool changesStatus = false;
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
        public frmContact()
        {
            InitializeComponent();
        }
        //
        public frmContact(string recordID, BindingSource bindingSource)
        {
            this.recordID = recordID;

            this.bindingSource = bindingSource;
            InitializeComponent();
        }
        //
        public frmContact(string recordID, BindingSource bindingSource, string companyID)
        {
            this.recordID = recordID;
            this.companyID = companyID;
            this.bindingSource = bindingSource;
            InitializeComponent();
        }
        //
        private void frmContact_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                tabMaster.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

                 if (Security.Security.UserJCCContactManagementAccessLevel == Security.Security.AccessLevel.ReadOnly)
                  {
                      btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                      btnSave.Enabled = false;
                      btnUndo.Enabled = false;
                  }
                  else
                  {
                      if (Security.Security.UserJCCContactManagementAccessLevel != Security.Security.AccessLevel.ReadWriteCreate)
                          btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                  }
                 
                txtRecordID.DataBindings.Add("text", bindingSource, "CMContactID");
                //   
                if (!StaticTables.IsLoaded)
                    StaticTables.PopulateStaticTables();
                cboCMContactDepartment.Properties.DataSource = StaticTables.Department;
                cboCMContactDepartment.Properties.PopulateColumns();
                cboCMContactDepartment.Properties.DisplayMember = "Description";
                cboCMContactDepartment.Properties.ValueMember = "ID";
                cboCMContactDepartment.Properties.ShowHeader = false;
                //
                cboCMCompany.Properties.DataSource = StaticTables.Company;
                cboCMCompany.Properties.PopulateColumns();
                cboCMCompany.Properties.DisplayMember = "Description";
                cboCMCompany.Properties.ValueMember = "ID";
                cboCMCompany.Properties.ShowHeader = false;
                //
                cboCMContactStatus.Properties.DataSource = StaticTables.Status;
                cboCMContactStatus.Properties.PopulateColumns();
                cboCMContactStatus.Properties.DisplayMember = "Description";
                cboCMContactStatus.Properties.ValueMember = "ID";
                cboCMContactStatus.Properties.ShowHeader = false;
                //
                cboCMContactReferredBy.Properties.DataSource = StaticTables.ReferredBy;
                cboCMContactReferredBy.Properties.PopulateColumns();
                cboCMContactReferredBy.Properties.DisplayMember = "Description";
                cboCMContactReferredBy.Properties.ValueMember = "ID";
                cboCMContactReferredBy.Properties.ShowHeader = false;
                //
                cboCMContactTitle.Properties.DataSource = StaticTables.Title;
                cboCMContactTitle.Properties.PopulateColumns();
                cboCMContactTitle.Properties.DisplayMember = "Description";
                cboCMContactTitle.Properties.ValueMember = "ID";
                cboCMContactTitle.Properties.ShowHeader = false;
                //
                UpdateErrorMessages();
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    ribbonProductivity.Visible = false;
                    txtRecordID.Text = recordID;
                    GetContact();
                }
                else
                {
                    ribbonReport.Visible = false;
                    ribbonProductivity.Visible = false;
                    GetContact();
                }
                if (companyID != "0")
                {
                    cboCMCompany.Properties.ReadOnly = true;
                    cboCMCompany.EditValue = int.Parse(companyID);
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
        private void GetContactDetail(string recordID)
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateContact(recordID);
                btnCopy.Enabled = true;
                this.Focus();
            }
            else
            {
                cboCMCompany.EditValue = null;
                chkCMContactKeyContact.CheckState = CheckState.Unchecked;
                chkCMLotusNotes.CheckState = CheckState.Unchecked;
                txtCMContactLastName.Text = "";
                txtCMContactFirstName.Text = "";
                txtCMContactInitial.Text = "";
                txtCMContactSalutation.Text = "";
                cboCMContactDepartment.EditValue = null;
                cboCMContactStatus.EditValue = null;
                cboCMContactReferredBy.EditValue = null;
                txtCMContactPhone.Text = "";
                txtCMContactPhoneExtension.Text = "";
                txtCMContactMobile.Text = "";
                txtCMContactFax.Text = "";
                txtCMContactEmail.Text = "";
                txtCMContactWebSite.Text = "";
                txtCMContactAddress.Text = "";
                txtCMContactAddress2.Text = "";
                txtCMContactCity.Text = "";
                txtCMContactState.Text = "";
                txtCMContactZip.Text = "";
                txtCMContactCountry.Text = "";
                txtCMContactCreateBy.Text = "";
                txtCMContactCreateDate.Text = "";
                txtCMContactEditBy.Text = "";
                txtCMContactEditDate.Text = "";
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
            UpdateFormStatus();
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Contact":
                    if (CheckToolStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        GetContact();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                        ribbonReport.Visible = false;
                        ribbonProductivity.Visible = false;
                        UpdateTabStatusByName(currentButtonName);
                    }
                    break;
                case "Previous Contact":
                    if (CheckToolStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        GetContact();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                        ribbonReport.Visible = false;
                        ribbonProductivity.Visible = false;
                        UpdateTabStatusByName(currentButtonName);
                    }
                    break;
                case "&New":
                    if (CheckToolStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        GetContact();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        ribbonReport.Visible = false;
                        ribbonProductivity.Visible = false;
                        UpdateTabStatusByName("Contact Info.");
                    }
                    break;
                case "&Save":
                    if (CheckToolStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = false;
                        ribbonProductivity.Visible = false;
                    }
                    break;
                case "&Undo":
                    txtCMContactLastName.Select();
                    txtCMContactLastName.Select(0, 0);
                    bindingSource.CancelEdit();
                    GetContact();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    btnCopy.Enabled = true;
                    break;
                case "&Copy":
                    txtCMContactLastName.Text = "";
                    txtCMContactFirstName.Text = "";
                    txtCMContactInitial.Text = "";
                    recordID = "0";
                    txtRecordID.Text = "0";
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnCopy.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    ribbonReport.Visible = false;
                    ribbonProductivity.Visible = false;
                    UpdateTabStatusByName("Contact Info.");
                    UpdateFormStatus();
                    break;
            }
        }
        //
        private bool CheckToolStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveContact();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
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
                        btnCopy.Enabled = true;
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
                btnCopy.Enabled = true;
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveContact()
        {
              if (txtRecordID.Text.Length == 0)
              {
                  recordID = "0";
              }
              else
                  recordID = txtRecordID.Text.Trim();
            try
            {
                 CMContact  contact = new CMContact(recordID,
                                                    cboCMCompany.EditValue == null ? String.Empty : cboCMCompany.EditValue.ToString(),
                                                    txtCMContactLastName.Text,
                                                    txtCMContactFirstName.Text,
                                                    txtCMContactInitial.Text,
                                                    txtCMContactSalutation.Text,
                                                    chkCMContactKeyContact.Checked.ToString(),
                                                    chkCMLotusNotes.Checked.ToString(),
                                                    cboCMContactTitle.EditValue == null ? String.Empty : cboCMContactTitle.EditValue.ToString(),
                                                    cboCMContactDepartment.EditValue == null ? String.Empty : cboCMContactDepartment.EditValue.ToString(),
                                                    cboCMContactStatus.EditValue == null ? String.Empty : cboCMContactStatus.EditValue.ToString(),
                                                    cboCMContactReferredBy.EditValue == null ? String.Empty : cboCMContactReferredBy.EditValue.ToString(),
                                                    txtCMContactPhone.Text,
                                                    txtCMContactPhoneExtension.Text,
                                                    txtCMContactMobile.Text,
                                                    txtCMContactFax.Text,
                                                    txtCMContactEmail.Text,
                                                    txtCMContactWebSite.Text,
                                                    txtCMContactAddress.Text,
                                                    txtCMContactAddress2.Text,
                                                    txtCMContactCity.Text,
                                                    txtCMContactState.Text,
                                                    txtCMContactZip.Text,
                                                    txtCMContactCountry.Text,
                                                    txtCMContactCreateDate.Text,
                                                    txtCMContactCreateBy.Text,
                                                    txtCMContactEditDate.Text,
                                                    txtCMContactEditBy.Text);
                contact.Save();

                recordID = contact.CMContactID;
                txtRecordID.Text = recordID;
                UpdateFormStatus();
                changesStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnCopy.Enabled = true;
        }
        //
        private void GetContact()
        {
            GetContactDetail(recordID);
            this.Text = txtCMContactLastName.Text;
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
                string myString = myControl.Text.Trim().ToUpper();

                if (myString != myControl.Text.Trim())
                    myControl.Text = myControl.Text.ToString().ToUpper();
            }
            if (!dataChanged)
            {
                if (Security.Security.UserJCCContactManagementAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnCopy.Enabled = false;
                }
            }
        }
        //
        private void frmContact_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckToolStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        //
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateContact(string recordID)
        {
            try
            {
                DataRow dr;
                dr = CMContact.GetCMContact(recordID).Tables[0].Rows[0];
                cboCMCompany.EditValue                      = dr["Company"];
                txtCMContactLastName.Text                   = dr["Last Name"].ToString();
                txtCMContactFirstName.Text                  = dr["First Name"].ToString();
                txtCMContactInitial.Text                    = dr["Initial"].ToString();
                txtCMContactSalutation.Text                 = dr["Salutation"].ToString();
                chkCMContactKeyContact.Checked              = dr["Key Contact"].ToString() == "True" ? true : false;
                chkCMLotusNotes.Checked                     = dr["Lotus Notes"].ToString() == "True" ? true : false;
                cboCMContactTitle.EditValue                 = dr["Title"];          
                cboCMContactDepartment.EditValue            = dr["Department"];     
                cboCMContactStatus.EditValue                = dr["Status"];         
                cboCMContactReferredBy.EditValue            = dr["Referred By"];     
                txtCMContactPhone.Text                      = dr["Phone"].ToString();         
                txtCMContactPhoneExtension.Text             = dr["Ext"].ToString(); 
                txtCMContactMobile.Text                     = dr["Mobile"].ToString();         
                txtCMContactFax.Text                        = dr["Fax"].ToString();            
                txtCMContactEmail.Text                      = dr["Email"].ToString();          
                txtCMContactWebSite.Text                    = dr["Web Site"].ToString();        
                txtCMContactAddress.Text                    = dr["Address"].ToString();        
                txtCMContactAddress2.Text                   = dr["Address2"].ToString();       
                txtCMContactCity.Text                       = dr["City"].ToString();           
                txtCMContactState.Text                      = dr["State"].ToString();          
                txtCMContactZip.Text                        = dr["Zip"].ToString();            
                txtCMContactCountry.Text                    = dr["Country"].ToString();        
                txtCMContactCreateDate.Text                 = dr["Create Date"].ToString();
                txtCMContactCreateBy.Text                   = dr["Create By"].ToString();
                txtCMContactEditDate.Text                   = dr["Edit Date"].ToString();
                txtCMContactEditBy.Text                     = dr["Edit By"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateFormStatus()
        {
            /*
            if (recordID == "0")
            {
                txtCMContact.Properties.ReadOnly = false;

            }
            else
            {
                if (chkIsCustomer.CheckState == CheckState.Checked || chkIsVendor.CheckState == CheckState.Checked)
                {
                    txtCMContact.Properties.ReadOnly = true;
                }
                else
                {
                    txtCMContact.Properties.ReadOnly = false;

                }
            }
             */
        }
        //
        private void UpdateErrorMessages()
        {     
            errorMessages = false;
            //
            txtCMContactLastName.ErrorText = "";
            txtCMContactFirstName.ErrorText = "";
            txtCMContactInitial.ErrorText = "";
            txtCMContactAddress.ErrorText = "";
            txtCMContactCity.ErrorText = "";
            txtCMContactState.ErrorText = "";
            txtCMContactZip.ErrorText = "";
            txtCMContactPhone.ErrorText = "";
            //
            if (txtCMContactLastName.Text.Trim().Length == 0)
            {
                txtCMContactLastName.ErrorText = "Contact Last Name is required";
                errorMessages = true;
            }
            if (txtCMContactFirstName.Text.Trim().Length == 0)
            {
                txtCMContactFirstName.ErrorText = "Contact First Name is required";
                errorMessages = true;
            }
            if (txtCMContactAddress.Text.Trim().Length == 0)
            {
                txtCMContactAddress.ErrorText = "Address is required";
                errorMessages = true;
            }
            if (txtCMContactCity.Text.Trim().Length == 0)
            {
                txtCMContactCity.ErrorText = "City is required";
                errorMessages = true;
            }
            if (txtCMContactState.Text.Trim().Length == 0)
            {
                txtCMContactState.ErrorText = "State is required";
                errorMessages = true;
            }
            if (txtCMContactZip.Text.Trim().Length == 0)
            {
                txtCMContactZip.ErrorText = "Zip is required";
                errorMessages = true;
            }
            if (txtCMContactPhone.Text.Trim().Length == 0)
            {
                txtCMContactPhone.ErrorText = "Phone is required";
                errorMessages = true;
            }
        }
        //
        private void UpdateTabStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            btnContacts.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
            currentButtonArg = e;
            currentButtonName = e.Item.Caption;
            UpdateTabStatusByName(currentButtonName);
        }
        //
        private void UpdateTabStatusByName(string tabName)
        {
            switch (tabName)
            {
                case "Contact Info.":
                    btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnGeneral.Down = true;
                    tabMaster.SelectedTabPage = pagMasterDetail;
                    break;
                case "Contacts":
                    btnContacts.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnContacts.Down = true;
                    // ******************************************************
                    // This is where the contacts will be called 
                    // This could be another thing related to the contact such 
                    // as activities
                    // ******************************************************
                    tabMaster.SelectedTabPage = pagContacts;
                    break;
               default:
                    btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnGeneral.Down = true;
                    tabMaster.SelectedTabPage = pagMasterDetail;
                    break;
            } 
        }
        //
        private void cboCMCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboCMCompany.EditValue = null;
            }
        }
        //
        private void cboCMContactDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboCMContactDepartment.EditValue = null;
            }
        }
        //
        private void cboCMContactTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboCMContactTitle.EditValue = null;
            }
        }
        //
        private void cboCMContactStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboCMContactStatus.EditValue = null;
            }
        }
        //
        private void cboCMContactReferredBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboCMContactReferredBy.EditValue = null;
            }
        }
        //
    }
}