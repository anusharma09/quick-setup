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
    public partial class frmCompany : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
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
        public frmCompany()
        {
            InitializeComponent();
        }
        //
        public frmCompany(string recordID, BindingSource bindingSource)
        {
            this.recordID = recordID;
            this.bindingSource = bindingSource;
            InitializeComponent();
        }
        //
        private void frmCompany_Load(object sender, EventArgs e)
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
                 
                txtRecordID.DataBindings.Add("text", bindingSource, "CMCompanyID");
                //   
                if (!StaticTables.IsLoaded)
                    StaticTables.PopulateStaticTables();
                cboCMCompanyIndustry.Properties.DataSource = StaticTables.Industry;
                cboCMCompanyIndustry.Properties.PopulateColumns();
                cboCMCompanyIndustry.Properties.DisplayMember = "Description";
                cboCMCompanyIndustry.Properties.ValueMember = "ID";
                cboCMCompanyIndustry.Properties.ShowHeader = false;
                cboCMCompanyIndustry.Properties.Columns[0].Visible = false;
                //
                cboCMCompanyReferredBy.Properties.DataSource = StaticTables.ReferredBy;
                cboCMCompanyReferredBy.Properties.PopulateColumns();
                cboCMCompanyReferredBy.Properties.DisplayMember = "Description";
                cboCMCompanyReferredBy.Properties.ValueMember = "ID";
                cboCMCompanyReferredBy.Properties.ShowHeader = false;
                cboCMCompanyReferredBy.Properties.Columns[0].Visible = false;
                //
                cboCMCompanyStatus.Properties.DataSource = StaticTables.Status;
                cboCMCompanyStatus.Properties.PopulateColumns();
                cboCMCompanyStatus.Properties.DisplayMember = "Description";
                cboCMCompanyStatus.Properties.ValueMember = "ID";
                cboCMCompanyStatus.Properties.ShowHeader = false;
                cboCMCompanyStatus.Properties.Columns[0].Visible = false;
                //
                cboCMCompanyTerritory.Properties.DataSource = StaticTables.Territory;
                cboCMCompanyTerritory.Properties.PopulateColumns();
                cboCMCompanyTerritory.Properties.DisplayMember = "Description";
                cboCMCompanyTerritory.Properties.ValueMember = "ID";
                cboCMCompanyTerritory.Properties.ShowHeader = false;
                cboCMCompanyTerritory.Properties.Columns[0].Visible = false;
                //
                UpdateErrorMessages();
                if (recordID == "0")
                {
                    txtRecordID.Text = recordID;
                    ribbonReport.Visible = false;
                    ribbonProductivity.Visible = false;
                    GetCompany();
                }
                else
                {
                    ribbonReport.Visible = false;
                    ribbonProductivity.Visible = true;
                    GetCompany();
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
        private void GetCompanyDetail(string recordID)
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateCompany(recordID);
                btnCopy.Enabled = true;
                this.Focus();
            }
            else
            {
                txtCMCompanySystemID.Text = "";
                txtCMCompanyAlphaName.Text = "";
                txtCMCompanyName.Text = "";
                txtCMCompanyAddress.Text = "";
                txtCMCompanyAddress2.Text = "";
                txtCMCompanyCity.Text = "";
                txtCMCompanyState.Text = "";
                txtCMCompanyZip.Text = "";
                txtCMCompanyCountry.Text = "";
                txtCMCompanyPhone.Text = "";
                txtCMCompanyFax.Text = "";
                txtCMCompanyTollFree.Text = "";
                txtCMCompanyWebSite.Text = "";
                cboCMCompanyStatus.EditValue = null;
                cboCMCompanyReferredBy.EditValue = null;
                txtCMCompanyDivision.Text = "";
                cboCMCompanyIndustry.EditValue = null;
                txtCMCompanyRevenue.Text = "";
                txtCMCompanyNumberOfEmployees.Text = "";
                txtCMCompanyRegion.Text = "";
                cboCMCompanyTerritory.EditValue = null;
                txtCMCompanyDescription.Text = "";
                txtCMCompanyCreateBy.Text = "";
                txtCMCompanyCreateDate.Text = "";
                txtCMCompanyEditBy.Text = "";
                txtCMCompanyEditDate.Text = "";
                chkIsCustomer.CheckState = CheckState.Unchecked;
                chkIsVendor.CheckState = CheckState.Unchecked;
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
               case "Next Company":
                    if (CheckToolStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        GetCompany();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                        ribbonReport.Visible = false;
                        ribbonProductivity.Visible = true;
                        UpdateTabStatusByName(currentButtonName);
                    }
                    break;
                case "Previous Company":
                    if (CheckToolStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        GetCompany();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = true;
                        ribbonReport.Visible = false;
                        ribbonProductivity.Visible = true;
                        UpdateTabStatusByName(currentButtonName);
                    }
                    break;
                case "&New":
                    if (CheckToolStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        GetCompany();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        ribbonReport.Visible = false;
                        ribbonProductivity.Visible = false;
                        UpdateTabStatusByName("Company Info.");
                    }
                    break;
                case "&Save":
                    if (CheckToolStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = false;
                        ribbonProductivity.Visible = true;
                    }
                    break;
                case "&Undo":
                    txtCMCompanyName.Select();
                    txtCMCompanyName.Select(0, 0);
                    bindingSource.CancelEdit();
                    GetCompany();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    btnCopy.Enabled = true;
                    break;
                case "&Copy":
                    txtCMCompanyName.Text = "";
                    txtCMCompanyDescription.Text = "";
                    recordID = "0";
                    txtRecordID.Text = "0";
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnCopy.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    ribbonReport.Visible = false;
                    ribbonProductivity.Visible = false;
                    UpdateTabStatusByName("Company Info.");
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
                        SaveCompany();
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
        private void SaveCompany()
        {
              if (txtRecordID.Text.Length == 0)
              {
                  recordID = "0";
              }
              else
                  recordID = txtRecordID.Text.Trim();
            try
            {
                 CMCompany  company = new CMCompany(recordID,
                                                    String.Empty,        // Company Parent Code
                                                    txtCMCompanySystemID.Text,
                                                    txtCMCompanyAlphaName.Text,
                                                    txtCMCompanyName.Text,
                                                    txtCMCompanyAddress.Text,
                                                    txtCMCompanyAddress2.Text,
                                                    txtCMCompanyCity.Text,
                                                    txtCMCompanyState.Text,
                                                    txtCMCompanyZip.Text,
                                                    txtCMCompanyCountry.Text,
                                                    txtCMCompanyPhone.Text,
                                                    txtCMCompanyFax.Text,
                                                    txtCMCompanyTollFree.Text,
                                                    txtCMCompanyWebSite.Text,
                                                    cboCMCompanyStatus.EditValue == null ? String.Empty : cboCMCompanyStatus.EditValue.ToString(),
                                                    cboCMCompanyReferredBy.EditValue == null ? String.Empty : cboCMCompanyReferredBy.EditValue.ToString(),
                                                    txtCMCompanyDivision.Text,
                                                    cboCMCompanyIndustry.EditValue == null ? String.Empty : cboCMCompanyIndustry.EditValue.ToString(),
                                                    txtCMCompanyRevenue.Text,
                                                    txtCMCompanyNumberOfEmployees.Text,
                                                    txtCMCompanyRegion.Text,
                                                    cboCMCompanyTerritory.EditValue == null ? String.Empty : cboCMCompanyTerritory.EditValue.ToString(),
                                                    txtCMCompanyDescription.Text,
                                                    txtCMCompanyCreateDate.Text,
                                                    txtCMCompanyCreateBy.Text,
                                                    txtCMCompanyEditDate.Text,
                                                    txtCMCompanyEditBy.Text);
                company.Save();

                recordID = company.CMCompanyID;
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
        private void GetCompany()
        {
            GetCompanyDetail(recordID);
            this.Text = txtCMCompanyName.Text;
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
        private void frmCompany_FormClosed(object sender, FormClosedEventArgs e)
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
        private void UpdateCompany(string recordID)
        {
            try
            {
                DataRow dr;
                dr = CMCompany.GetCMCompany(recordID).Tables[0].Rows[0];
                txtCMCompanySystemID.Text                   = dr["Company ID"].ToString();
                txtCMCompanyAlphaName.Text                  = dr["Alpha Name"].ToString();
                txtCMCompanyName.Text                       = dr["Company Name"].ToString();
                txtCMCompanyAddress.Text                    = dr["Address"].ToString();
                txtCMCompanyAddress2.Text                   = dr["Address2"].ToString();
                txtCMCompanyCity.Text                       = dr["City"].ToString();
                txtCMCompanyState.Text                      = dr["State"].ToString();
                txtCMCompanyZip.Text                        = dr["Zip"].ToString();
                txtCMCompanyCountry.Text                    = dr["Country"].ToString();
                txtCMCompanyPhone.Text                      = dr["Phone"].ToString();
                txtCMCompanyFax.Text                        = dr["Fax"].ToString();
                txtCMCompanyTollFree.Text                   = dr["Toll Free"].ToString();
                txtCMCompanyWebSite.Text                    = dr["Web Site"].ToString();
                cboCMCompanyStatus.EditValue                = dr["Status"];
                cboCMCompanyReferredBy.EditValue            = dr["Referred By"];
                txtCMCompanyDivision.Text                   = dr["Division"].ToString();
                cboCMCompanyIndustry.EditValue              = dr["Industry"];
                txtCMCompanyRevenue.Text                    = dr["Revenue"].ToString();
                txtCMCompanyNumberOfEmployees.Text          = dr["Number of Emp"].ToString();
                txtCMCompanyRegion.Text                     = dr["Region"].ToString();
                cboCMCompanyTerritory.EditValue             = dr["Territory"];
                txtCMCompanyDescription.Text                = dr["Description"].ToString();
                txtCMCompanyCreateDate.Text                 = dr["Create Date"].ToString();
                txtCMCompanyCreateBy.Text                   = dr["Create By"].ToString();
                txtCMCompanyEditDate.Text                   = dr["Edit Date"].ToString();
                txtCMCompanyEditBy.Text                     = dr["Edit By"].ToString();
                chkIsCustomer.Checked                       = dr["Is Customer"].ToString() == "True" ? true : false;
                chkIsVendor.Checked                         = dr["Is Vendor"].ToString() == "True" ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        // Start Here
        private void UpdateFormStatus()
        {
            if (recordID == "0")
            {
                txtCMCompanyName.Properties.ReadOnly = false;
                txtCMCompanyAddress.Properties.ReadOnly = false;
                txtCMCompanyAddress2.Properties.ReadOnly = false;
                txtCMCompanyCity.Properties.ReadOnly = false;
                txtCMCompanyState.Properties.ReadOnly = false;
                txtCMCompanyZip.Properties.ReadOnly = false;
                txtCMCompanyCountry.Properties.ReadOnly = false;
                txtCMCompanyPhone.Properties.ReadOnly = false;
                txtCMCompanyFax.Properties.ReadOnly = false;
            }
            else
            {
                if (chkIsCustomer.CheckState == CheckState.Checked || chkIsVendor.CheckState == CheckState.Checked)
                {
                    txtCMCompanyName.Properties.ReadOnly = true;
                    txtCMCompanyAddress.Properties.ReadOnly = true;
                    txtCMCompanyAddress2.Properties.ReadOnly = true;
                    txtCMCompanyCity.Properties.ReadOnly = true;
                    txtCMCompanyState.Properties.ReadOnly = true;
                    txtCMCompanyZip.Properties.ReadOnly = true;
                    txtCMCompanyCountry.Properties.ReadOnly = true;
                    txtCMCompanyPhone.Properties.ReadOnly = true;
                    txtCMCompanyFax.Properties.ReadOnly = true;
                }
                else
                {
                    txtCMCompanyName.Properties.ReadOnly = false;
                    txtCMCompanyAddress.Properties.ReadOnly = false;
                    txtCMCompanyAddress2.Properties.ReadOnly = false;
                    txtCMCompanyCity.Properties.ReadOnly = false;
                    txtCMCompanyState.Properties.ReadOnly = false;
                    txtCMCompanyZip.Properties.ReadOnly = false;
                    txtCMCompanyCountry.Properties.ReadOnly = false;
                    txtCMCompanyPhone.Properties.ReadOnly = false;
                    txtCMCompanyFax.Properties.ReadOnly = false;
                }
            }
        }
        //
        private void UpdateErrorMessages()
        {     
            errorMessages = false;
            //
            txtCMCompanyName.ErrorText = "";
            txtCMCompanyAddress.ErrorText = "";
            txtCMCompanyCity.ErrorText = "";
            txtCMCompanyState.ErrorText = "";
            txtCMCompanyZip.ErrorText = "";
            txtCMCompanyPhone.ErrorText = "";
            txtCMCompanyFax.ErrorText = "";
            //
            if (txtCMCompanyName.Text.Trim().Length == 0)
            {
                txtCMCompanyName.ErrorText = "Company name is required";
                errorMessages = true;
            }
            if (txtCMCompanyAddress.Text.Trim().Length == 0)
            {
                txtCMCompanyAddress.ErrorText = "Address is required";
                errorMessages = true;
            }
            if (txtCMCompanyCity.Text.Trim().Length == 0)
            {
                txtCMCompanyCity.ErrorText = "City is required";
                errorMessages = true;
            }
            if (txtCMCompanyState.Text.Trim().Length == 0)
            {
                txtCMCompanyState.ErrorText = "State is required";
                errorMessages = true;
            }
            if (txtCMCompanyZip.Text.Trim().Length == 0)
            {
                txtCMCompanyZip.ErrorText = "Zip is required";
                errorMessages = true;
            }
            if (txtCMCompanyPhone.Text.Trim().Length == 0)
            {
                txtCMCompanyPhone.ErrorText = "Phone is required";
                errorMessages = true;
            }
            if (txtCMCompanyFax.Text.Trim().Length == 0)
            {
                txtCMCompanyFax.ErrorText = "Fax name is required";
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
                case "Company Info.":
                    btnGeneral.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnGeneral.Down = true;
                    tabMaster.SelectedTabPage = pagMasterDetail;
                    break;
                case "Contacts":
                    btnContacts.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                    btnContacts.Down = true;
                    ctlCompanyContacts.CompamyID = txtRecordID.Text;
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
        private void cboCMCompanyStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboCMCompanyStatus.EditValue = null;
            }
        }
        //
        private void cboCMCompanyReferredBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboCMCompanyReferredBy.EditValue = null;
            }
        }
        //
        private void cboCMCompanyIndustry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboCMCompanyIndustry.EditValue = null;
            }
        }
    }
}