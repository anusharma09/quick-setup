using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using BakirConsulting.DataAccessLayer;
//using WindowsClient.Reports;
//using WindowsClient.BusinessLayer;

namespace WindowsClient.PresentationLayer
{
  
    public partial class frmStaff : DevExpress.XtraBars.Ribbon.RibbonForm
    {      
        //private DevExpress.XtraReports.UI.XtraReport staffReport;
        protected int recordID;
        protected BindingSource bindingSource;
        protected System.Collections.Hashtable recordHashTable = new System.Collections.Hashtable();
        protected bool dataChanged;

        public frmStaff()
        {
            InitializeComponent();
            

        }

        public frmStaff(int RecordID, BindingSource BindingSource)
        {
            recordID = RecordID;
            bindingSource = BindingSource;
            InitializeComponent();
            

            
        }
        
        private void frmStaff_Load(object sender, EventArgs e)
        {
            
            cboStaffRole.Properties.DataSource = StaticTabbles.staffRole;
            cboStaffRole.Properties.PopulateColumns();
            cboStaffRole.Properties.DisplayMember = "StaffRoleDescription";
            cboStaffRole.Properties.ValueMember = "StaffRoleID";
            cboStaffRole.Properties.Columns[0].Visible = false;
            //
            // Bind Data Source
            cboStaffRole.DataBindings.Add("EditValue", bindingSource, "Staff Role");
            cboUserAccess.DataBindings.Add("text", bindingSource, "User Access");
            txtLoginID.DataBindings.Add("text", bindingSource, "Login ID");
            txtLastName.DataBindings.Add("text", bindingSource, "Last Name");
            txtFirstName.DataBindings.Add("text", bindingSource, "First Name");
            txtPhone.DataBindings.Add("text", bindingSource, "Phone");
            txtEmail.DataBindings.Add("text", bindingSource, "Email");
            txtNote.DataBindings.Add("text", bindingSource, "Note");
            txtStaffID.DataBindings.Add("text", bindingSource, "StaffID");
            chkSystemUser.DataBindings.Add("EditValue", bindingSource, "System User");
            
           
            // Bulid Error validation
            recordHashTable.Add("cboStaffRole", "Staff Role is Required");
            recordHashTable.Add("txtFirstName", "First Name is Required");
            recordHashTable.Add("txtLastName", "Last Name is Required");

            dataChanged = false;
            btnUndo.Enabled = false;
            if (recordID == 0)
                bindingSource.AddNew();
            GetStaffAccount();
                

        }
        private void GetStaffAccount()
        {
            int staffID;

            if (txtStaffID.Text.Trim().Length > 0)
                staffID = int.Parse(txtStaffID.Text.Trim());
            else
                staffID = 0;

            this.grdStaffAccount.DataSource = StaffAccount.GetAll(staffID).Tables[0].DefaultView;
            this.grdStaffAccount.MainView.PopulateColumns();
            grdView.Columns[0].ColumnEdit = staffRepository;

            grdView.Columns[2].ColumnEdit = SearchRepositoryItems.accountList;
            SearchRepositoryItems.accountList.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            grdView.Columns[2].OptionsColumn.AllowEdit = true;
            grdView.Columns[1].Visible = false;
            grdView.Columns[3].ColumnEdit = StaffAccountNote;
            grdView.Columns[3].Visible = false;
            grdView.Columns[2].Caption = "Account";
            grdView.Columns[2].Width = 500;
            grdView.Columns[0].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            grdView.Columns[0].OptionsFilter.AllowFilter = false;
            grdView.Columns[0].OptionsColumn.AllowEdit = false;
            grdView.Columns[0].OptionsColumn.AllowFocus = false;
            grdView.Columns[0].OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            grdView.Columns[0].OptionsColumn.AllowMove = false;
            grdView.Columns[0].OptionsColumn.AllowSize = false;
            grdView.Columns[0].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            grdView.Columns[0].OptionsColumn.ShowCaption = false;
            grdView.Columns[0].OptionsColumn.FixedWidth = true;
            grdView.Columns[0].Width = 30;
            grdView.Images = imageCollection4;
            grdView.Columns[0].ImageIndex = 0;
            if ( txtStaffID.Text.Trim().Length> 0)
                grdStaffAccount.Enabled = true;
            else
                grdStaffAccount.Enabled = false;
        }

        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "Next Staff":
                    if (CheckStaffStatus())
                    {
                        bindingSource.MoveNext();
                        GetStaffAccount();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "Previous Staff":
                    if (CheckStaffStatus())
                    {
                        bindingSource.MovePrevious();
                        GetStaffAccount();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "&Delete":
                    if (txtStaffID.Text.Trim().Length > 0)
                    {
                        if (MessageBox.Show("Delete current staff", App.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            bindingSource.RemoveCurrent();
                            GetStaffAccount();
                            dataChanged = false;
                            btnUndo.Enabled = false;
                        }
                    }
                    break;
                case "&New":
                    if (CheckStaffStatus())
                    {
                        bindingSource.AddNew();
                        GetStaffAccount();
                        chkSystemUser.Checked = false;
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "&Save":
                    CheckStaffStatus();
                    break;
                case "&Undo":
                    bindingSource.CancelEdit();
                    GetStaffAccount();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    break;
                case "&Print":
                    staffReport = new WindowsClient.Reports.StaffReport( Convert.ToInt16( txtStaffID.Text));

                    WindowsClient.PresentationLayer.frmReport myReport = new frmReport(staffReport);
                    myReport.ShowDialog();
                    break;
            }

        }
        private bool CheckStaffStatus()
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", App.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.ValidateChildren())
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
        protected virtual void SaveRecord()
        {
            int staffID = 0;

            if (txtStaffID.Text.Trim().Length > 0)         
                staffID = int.Parse(txtStaffID.Text.Trim());

            if (!chkSystemUser.Checked)
            {
                cboUserAccess.Text = "NoAccess";
                txtLoginID.Text = "";
            }

            Staff newStaff = new Staff(staffID,
                                        cboStaffRole.EditValue.ToString(),
                                        chkSystemUser.Checked,
                                        txtLoginID.Text.Trim(),
                                        cboUserAccess.Text.Trim(),
                                        txtFirstName.Text.Trim(),
                                        txtLastName.Text.Trim(),
                                        txtPhone.Text.Trim(),
                                        txtEmail.Text.Trim(),
                                        txtNote.Text.Trim());
                newStaff.Save();
                txtStaffID.Text = newStaff.StaffID.ToString();
                newStaff = null;
        }
        private void ControlValidating(object sender, CancelEventArgs e)
        {
            string key;
            string value;

            key = ((Control)sender).Name;
            if (recordHashTable.ContainsKey(key))
            {
                value = recordHashTable[key].ToString();
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
      

        private void allControls_EditValueChanged(object sender, EventArgs e)
        {
            string name;

            dataChanged = true;
            btnUndo.Enabled = true;
            name = ((Control)sender).Name;
            switch (name)
            {
                case "txtLastName":
                case "txtFirstName":
                    this.Text = txtLastName.Text.Trim() + ", " + txtFirstName.Text.Trim();
                    break;
                case "chkSystemUser":
                    if (chkSystemUser.Checked)
                    {
                        recordHashTable.Add("txtLoginID", "Login ID is Required");
                        recordHashTable.Add("cboUserAccess", "User Access is Required");
                        lblLoginID.Visible = true;
                        lblUserAccess.Visible = true;
                        txtLoginID.Visible = true;
                        cboUserAccess.Visible = true;

                    }
                    else
                    {
                        recordHashTable.Remove("txtLoginID");
                        recordHashTable.Remove("cboUserAccess");
                        dxErrorProvider1.SetError(txtLoginID, null);
                        dxErrorProvider1.SetError(cboUserAccess, null);
                        lblLoginID.Visible = false;
                        lblUserAccess.Visible = false;
                        txtLoginID.Visible = false;
                        cboUserAccess.Visible = false;

                    }
                    break;
            }

        }

        private void frmStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckStaffStatus();          
            foreach (Control ctl in this.Controls)
                ctl.DataBindings.Clear();         
        }

        //
        // Validate the data entry for the Sales Accout
        //

        private void grdView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn column1 = grdView.Columns["AccountID"];
            if (grdView.GetRowCellValue(e.RowHandle, column1).ToString() == "")
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                grdView.SetColumnError(column1, "Account is required");
            }
            else
            {
                SaveStaffAccount(); 
            }

        }

        private void grdView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void SaveStaffAccount()
        {
            DataRow row;
            string staffAccountID;
            string staffID;
            string accountID;
            string note;
            row = grdView.GetDataRow(grdView.GetSelectedRows()[0]);

            staffAccountID = row[0].ToString();
            staffID = row[1].ToString();
            accountID = row[2].ToString();
            note = row[3].ToString();

            staffID = txtStaffID.Text.Trim();
          
            if (staffAccountID == "")           // New Account
            {
                staffAccountID = "0";
            }
            StaffAccount staffAccount = new StaffAccount(Convert.ToInt16(staffAccountID),
                                                staffID,
                                                accountID);

            staffAccount.Save();
            row[0] = staffAccount.StaffAccountID.ToString();
        }

        private void labelControl19_Click(object sender, EventArgs e)
        {

        }
    }
}