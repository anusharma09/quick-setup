using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit;
using JCCBusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using JCCReports;
using DevExpress.XtraGrid.Views.Base;

namespace CCEJobs.PresentationLayer
{
    public partial class frmProjectProposal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string globalProposalID;
        protected string JobID;
        protected string globalUser;
        protected string globalREV;
        protected BindingSource bindingSource;
        protected bool dataChanged;
        private bool errorMessages = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        protected int defaultRFIContactID;
        protected int defaultFromID;
        private bool changesStatus = false;
        private bool bColumnWidthChanged = false;

        public string profilePicName = null;
        private string pricingID = "";
        private string alternatePricingID = "";
        private string terminationID = "";
        private string trainingID = "";
        private string evalID = "";
        private string badgeID = "";
        private string safetyID = "";
        private string attachmentID = "";
        private string defaultPic = CCEApplication.DestinationPicLocation + "DefaultProfilePic.jpg";
        private bool isNew = false;
        // private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repCDate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
        // private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repTDate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

        private string queryWhere = string.Empty;
        private bool ssnValidation = false;

        private enum ClickedButton
        {

            Delete,
            New,
            Save,
            Undo,
            Close,
            Copy,
            Reports
        };
        //
        DataTable contact;
        public frmProjectProposal()
        {
            InitializeComponent();
        }
        //
        public frmProjectProposal(string proposalID, string jobID, BindingSource bindingSource, bool isNew, string user, string rev)
        {
            this.globalProposalID = proposalID;
            this.JobID = jobID;
            this.globalUser = user;
            this.globalREV = rev;
            this.bindingSource = bindingSource;
            this.isNew = isNew;
            InitializeComponent();
        }
        //
        private void frmProjectProposal_Load(object sender, EventArgs e)
        {
            try
            {
                // proposalID = "0";
                Cursor = Cursors.AppStarting;
                riPopup.PopupFormMinSize = new Size(500, 300);
                textDynaEstimateNumber.Enabled = false;

                if (globalProposalID == "0")
                {
                    BindContacts();
                    GetDefaultDescription();
                    GetDefaultLeadTimes();
                    GetDefaultClarification();
                    GetDefaultGenInfoAndAlternates();
                    GetDefaultExclusion();
                    GetProposals();
                    GetPricing(0, 0, 0);
                    GetPricingAlternate(0, 0, 0);
                    DisableTabPages();
                    UpdateErrorMessages();
                }
                else
                {

                    UserDetails();
                    EnableTabPages();
                    btnDelete.Enabled = true;
                    btnRev.Enabled = true;
                    btnCopy.Enabled = true;
                }
                string str = string.Empty;
                if (!string.IsNullOrEmpty(cboRevision.Text))
                {
                    str = cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1);
                }
                if (!string.IsNullOrEmpty(cboRevision.Text) && (str == "0"))
                { btnDelete.Enabled = false; }

                Opacity = 1;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        public void UserDetails()
        {
            BindContacts();
            GetProposals();

            if (isCopy == true && (!string.IsNullOrEmpty(revCopy)))
            {
                GetPricing(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(revCopy));
                GetPricingAlternate(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(revCopy));

            }
            else
            {
                GetPricing(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                GetPricingAlternate(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
            }

            DataSet dsDescription = new DataSet();
            if (isCopy == true && (!string.IsNullOrEmpty(revCopy)))
            {
                dsDescription = ProjectProposal.GetProposalDescription(globalProposalID, this.globalUser, this.revCopy);
            }
            else

            { dsDescription = ProjectProposal.GetProposalDescription(globalProposalID, this.globalUser, this.globalREV); }

            if (dsDescription.Tables[0].Rows.Count > 0)
            {
                DataRow r = dsDescription.Tables[0].Rows[0];
                richBoxEditorDescription.Text = r["Value"].ToString();
            }
            else { GetDefaultDescription(); }


            DataSet dsLeadTime = new DataSet();

            if (isCopy == true && (!string.IsNullOrEmpty(revCopy)))
            {
                dsLeadTime = ProjectProposal.GetProposalleadTime(globalProposalID, this.globalUser, this.revCopy);
            }

            else
            { dsLeadTime = ProjectProposal.GetProposalleadTime(globalProposalID, this.globalUser, this.globalREV); }

            if (dsLeadTime.Tables[0].Rows.Count > 0)
            {
                DataRow r = dsLeadTime.Tables[0].Rows[0];
                richBoxEditorLeadTimes.Text = r["Value"].ToString();
            }
            else { GetDefaultLeadTimes(); }
            DataSet dsClarification = new DataSet();
            ;
            if (isCopy == true && (!string.IsNullOrEmpty(revCopy)))
            {
                dsClarification = ProjectProposal.GetProposalClarification(globalProposalID, this.globalUser, this.revCopy);
            }
            else
            {
                dsClarification = ProjectProposal.GetProposalClarification(globalProposalID, this.globalUser, this.globalREV);
            }


            if (dsClarification.Tables[0].Rows.Count > 0)
            {
                DataRow r = dsClarification.Tables[0].Rows[0];
                richBoxEditorClarification.Text = r["Value"].ToString();
            }
            else { GetDefaultClarification(); }

            DataSet dsGenInfoandAlternaten = new DataSet();
            if (isCopy == true && (!string.IsNullOrEmpty(revCopy)))
            {
                dsGenInfoandAlternaten = ProjectProposal.GetProposalGenInfoAndAlternate(globalProposalID, this.globalUser, this.revCopy);
            }
            else
            {
                dsGenInfoandAlternaten = ProjectProposal.GetProposalGenInfoAndAlternate(globalProposalID, this.globalUser, this.globalREV);
            }


            if (dsGenInfoandAlternaten.Tables[0].Rows.Count > 0)
            {
                DataRow r = dsGenInfoandAlternaten.Tables[0].Rows[0];

                richBoxEditorScopeGenInfo.Text = r["Value"].ToString();
                richBoxEditorScopeAlternate.Text = r["Value2"].ToString();
            }
            else { GetDefaultGenInfoAndAlternates(); }


            DataSet dsExclusion = new DataSet();
            if (isCopy == true && (!string.IsNullOrEmpty(revCopy)))
            {
                dsExclusion = ProjectProposal.GetProposalExclusion(globalProposalID, this.globalUser, this.revCopy);
            }
            else { dsExclusion = ProjectProposal.GetProposalExclusion(globalProposalID, this.globalUser, this.globalREV); }

            if (dsExclusion.Tables[0].Rows.Count > 0)
            {
                DataRow r = dsExclusion.Tables[0].Rows[0];
                richBoxEditorExclusion.Text = r["Value"].ToString();
            }
            else { GetDefaultExclusion(); }
        }
        public void GetProposalDescription(string proposalID)
        {

        }

        public void BindContacts()
        {


            contact = Contact.GetJobContactForPullDown(JobID).Tables[0];
            comboToPerson.Properties.DataSource = contact;
            comboToPerson.Properties.PopulateColumns();
            comboToPerson.Properties.DisplayMember = "Name";
            comboToPerson.Properties.ValueMember = "ContactID";
            comboToPerson.Properties.ShowHeader = false;
            comboToPerson.Properties.Columns[0].Visible = false;
        }

        private void GetDefaultGenInfoAndAlternates()
        {
            DataRow r;
            DataRow r1;
            DataSet ds = ProjectProposal.GetGenInfoAndAlternates();
            if (ds.Tables[0].Rows.Count > 0)
            {
                r = ds.Tables[0].Rows[0];
                r1 = ds.Tables[0].Rows[1];
                richBoxEditorScopeGenInfo.Text = r["Value"].ToString();
                richBoxEditorScopeAlternate.Text = r1["Value"].ToString();
            }
        }
        private void GetDefaultClarification()
        {
            DataRow r;
            DataSet ds = ProjectProposal.GetClarification();
            if (ds.Tables[0].Rows.Count > 0)
            {
                r = ds.Tables[0].Rows[0];
                richBoxEditorClarification.Text = r["Value"].ToString();
            }
        }
        private void GetDefaultExclusion()
        {
            DataRow r;
            DataSet ds = ProjectProposal.GetDefaultExclusion();
            if (ds.Tables[0].Rows.Count > 0)
            {
                r = ds.Tables[0].Rows[0];
                richBoxEditorExclusion.Text = r["Value"].ToString();
            }
        }

        private void GetDefaultDescription()
        {
            DataRow r;
            DataSet ds = ProjectProposal.GetDefaultDescription();
            if (ds.Tables[0].Rows.Count > 0)
            {
                r = ds.Tables[0].Rows[0];
                richBoxEditorDescription.Text = r["value"].ToString();
            }
        }

        private void GetDefaultLeadTimes()
        {
            DataRow r;
            DataSet ds = ProjectProposal.GetLeadTimes();
            if (ds.Tables[0].Rows.Count > 0)
            {
                r = ds.Tables[0].Rows[0];
                richBoxEditorLeadTimes.Text = r["value"].ToString();
            }
        }


        private void GetEmployeeDetail(string proposalID)
        {
            changesStatus = false;
            if (proposalID.Length > 0 && proposalID != "0")
            {
                GetProposalDetail(proposalID);

                Focus();
            }
            else
            {

                DataTable dt = ProjectProposal.GetJobAndEstimateNumber(JobID);
                txt1Date.Text = "";

                textEditSubject.EditValue = dt.Rows[0]["JobName"].ToString();
                textDynaEstimateNumber.Text = dt.Rows[0]["EstimateNumber"].ToString();
                textDynaEstimateNumber.Enabled = false;
                txt1Date.EditValue = string.Empty;
                comboToPerson.EditValue = null;
                comboToCompany.EditValue = string.Empty;
                comboToPerson.Enabled = true;
                comboToCompany.Enabled = true;

                GetDefaultDescription();
                GetDefaultLeadTimes();
                GetDefaultClarification();
                GetDefaultGenInfoAndAlternates();
                GetDefaultExclusion();
                // GetProposals();
                GetPricing(0, 0, 0);
                GetPricingAlternate(0, 0, 0);
                DisableTabPages();
                contact = Contact.GetJobContactForPullDown(JobID).Tables[0];
                comboToPerson.Properties.DataSource = contact;
                comboToPerson.Properties.PopulateColumns();
                comboToPerson.Properties.DisplayMember = "Name";
                comboToPerson.Properties.ValueMember = "ContactID";
                comboToPerson.Properties.ShowHeader = false;
                comboToPerson.Properties.Columns[0].Visible = false;
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
        }

        public void New()
        {
            globalProposalID = "0";
            txtRecordID.Text = "0";
            ProjectProposal.globalProposalID = "0";
            // queryWhere = " WHERE A.ProposalID = " + globalProposalID;
            isNew = true;

            GetProposals();
            dataChanged = false;
            btnUndo.Enabled = false;
            //btnCopy.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            DisableTabPages();
        }
        //
        string revCopy = string.Empty;
        private string oldRevision = "";
        private bool revisionStatus = false;
        bool isCopy = false;

        bool copy = false;
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {

                case "&Report":
                    bool ret = Reports.JobMasterProposalSheet(JobID, globalProposalID, globalUser, globalREV);
                    if (ret == false)
                    {
                        MessageBox.Show("Please select revision to Print!", CCEApplication.ApplicationName, MessageBoxButtons.OK);

                    }
                    break;
                case "&New":
                    if (ValidateProposals(ClickedButton.New))
                    {
                        isCopy = false;
                        globalProposalID = "0";
                        ProjectProposal.globalProposalID = "0";

                        isNew = true;
                        GetProposals();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnRev.Enabled = false;
                        cboRevision.Properties.Items.Clear();
                        DisableTabPages();
                    }
                    break;
                case "&Copy":

                    btnCopy.Enabled = false;
                    isCopy = true;
                    string proposalID = globalProposalID;
                    string userID = globalUser;
                    revCopy = globalREV;
                    #region make a blank new copy
                    globalProposalID = "0";
                    ProjectProposal.globalProposalID = "0";
                    isNew = true;
                    GetProposals();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    // btnCopy.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    btnRev.Enabled = false;
                    cboRevision.Properties.Items.Clear();
                    #endregion

                    #region Again fill the details for copy having selected proposal , selected user and selected revision.
                    globalProposalID = ProjectProposal.globalProposalID = proposalID;
                    globalUser = userID;
                    globalREV = revCopy;
                    UserDetails();
                    //  EnableTabPages();

                    globalProposalID = "0";
                    ProjectProposal.globalProposalID = "0";
                    cboRevision.Properties.Items.Clear();
                    cboRevision.EditValue = null;
                    cboRevision.Text = string.Empty;

                    comboToPerson.Enabled = true;
                    comboToPerson.EditValue = string.Empty;
                    comboToPerson.Text = string.Empty;
                    comboToCompany.EditValue = string.Empty;
                    comboToCompany.Enabled = true;
                    copy = true;
                    btnCopy.Enabled = false;
                    revCopy = string.Empty;
                    #endregion

                    break;
                case "&Save":
                    ValidateProposals(ClickedButton.Save);
                    break;
                case "&Undo":
                    GetProposals();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    if (!isNew)
                    {
                        string str = cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1);
                        if (str == "0".ToString())
                        { btnDelete.Enabled = false; }
                        else
                        {
                            btnDelete.Enabled = true;
                        }

                        btnRev.Enabled = true;
                        btnCopy.Enabled = true;
                    }



                    break;
                case "&Delete":
                    if (!string.IsNullOrEmpty(cboRevision.Text) && cboRevision.Text.ToString() == "000")
                    {
                        MessageBox.Show("User cannot delete the original proposal.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to delete the proposal for " + cboRevision.Text.ToString() + " revision?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DeleteProposal();
                        }
                    }
                    break;

                case "&Rev":
                    try
                    {
                        //  btnRev.Enabled = false;
                        if (MessageBox.Show("You are about to create a Revision for the current Proposal. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                string rev = "";
                                oldRevision = cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1);
                                string NewRevision = ProjectProposal.GetNewRevison(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser));
                                CreateRevision(Convert.ToInt32(globalProposalID), Convert.ToInt32(oldRevision), Convert.ToInt32(NewRevision));


                                //GetChangeOrderRevision(recordID);
                            }
                            else
                            { }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    finally
                    {
                        //if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                        //{
                        //    btnRev.Enabled = false;
                        //    btnCopy.Enabled = false;
                        //}
                        //else
                        //{
                        //    btnRev.Enabled = true;
                        //    btnCopy.Enabled = true;
                        //}
                    }
                    break;

            }
        }


        #region pricing
        private void grdClassificationView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        }
        bool value = false;
        private void grdClassificationView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DataRow r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);

            if (r != null && r.ItemArray[0].ToString() != "" && r.ItemArray[1].ToString() != "" && r.ItemArray[2].ToString() != "")
            {
                // Validate Fields
                if (r["BaseBid"].ToString().Trim() == "")
                {
                    message = "Base bid is Required ..\n";
                    valid = false;
                }
                if (r["Price"].ToString().Trim() == "")
                {
                    message = message + "Price is Required ..\n";
                    valid = false;
                }

                if (string.IsNullOrEmpty(r["BaseBid"].ToString().Trim()) && string.IsNullOrEmpty(r["Price"].ToString().Trim()))
                {
                    valid = true;
                    message = string.Empty;
                    e.Valid = false;

                }
            }
            if (valid)
            {
                btnSave.Enabled = true;
                dataChanged = true;

                // UpdatePricing();
            }
            else
            {
                MessageBox.Show(message, CCEApplication.ApplicationName);
                e.Valid = false;
            }

        }

        private void grdClassificationView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdClassificationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);
                if (r == null)
                {
                    pricingID = "0";
                }
                else
                {
                    pricingID = r["pricingID"].ToString();
                }
            }

        }

        private void grdClassificationView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete selected pricing?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            ProjectProposalPricing.Delete(r[2].ToString(), Convert.ToInt32(globalProposalID), Convert.ToInt32(globalREV), Convert.ToInt32(globalUser));
                            grdClassificationView.DeleteRow(grdClassificationView.GetSelectedRows()[0]);

                            if (globalProposalID == "0")
                            { txtPricingTotal.Text = "$0"; }
                            else
                            {
                                DataTable dtPriceTotal = ProjectProposal.GetPricing(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV)).Tables[1];
                                txtPricingTotal.Text = dtPriceTotal.Rows[0]["Total"].ToString();
                                MessageBox.Show("Deleted successfully.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                //grdClassificationView.MoveNext();
                //decimal price = 0;
                //DataRow r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);
                //if (r != null  )
                //{

                //    if (!String.IsNullOrEmpty(r[2].ToString()))
                //    {
                //        if (r[2].ToString().Trim().Contains("$"))
                //        { price = Convert.ToDecimal(r[2].ToString().Replace("$", String.Empty)); }
                //        else
                //        {
                //            decimal value = 0;
                //            bool isNumerical = decimal.TryParse(r[2].ToString(), out value);
                //            if (isNumerical == false)
                //            {
                //                MessageBox.Show("Please enter the correct price");
                //                return;
                //            }
                //        }
                //    }
                //}
            }
            else if (e.KeyCode == Keys.Escape)
            {
                grdClassificationView.HideEditor();
                grdClassificationView.CancelUpdateCurrentRow();
                e.Handled = false;
            }
        }
        #endregion

        #region Alternate Pricing
        private void grdAlternatePricingView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdAlternatePricingView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DataRow r = grdAlternatePricingView.GetDataRow(grdAlternatePricingView.GetSelectedRows()[0]);

            //if (MessageBox.Show("Save Alternate Pricing Changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            // Validate Fields
            if (r != null && r.ItemArray[0].ToString() != "" && r.ItemArray[1].ToString() != "" && r.ItemArray[2].ToString() != "")
            {

                if (r["Alternate"].ToString().Trim() == "")
                {
                    message = "Alternate is Required ..\n";
                    valid = false;
                }
                if (r["AlternatePrice"].ToString().Trim() == "")
                {
                    message = message + "Alternate Price is Required ..\n";
                    valid = false;
                }
                if (string.IsNullOrEmpty(r["Alternate"].ToString().Trim()) && string.IsNullOrEmpty(r["AlternatePrice"].ToString().Trim()))
                {
                    valid = true;
                    message = string.Empty;
                    e.Valid = false;
                }
            }
            if (valid)
            {
                btnSave.Enabled = true;
                dataChanged = true;
                //UpdatePricingAlternate();
            }
            else
            {
                MessageBox.Show(message, CCEApplication.ApplicationName);
                e.Valid = false;
            }
            //}
            //else
            //{
            //    if (r["AlternateID"] == DBNull.Value)
            //    {
            //        grdAlternatePricingView.DeleteRow(e.RowHandle);
            //    }

            //    r.CancelEdit();
            //}
        }

        private void grdAlternatePricingView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdAlternatePricingView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdAlternatePricingView.GetDataRow(grdAlternatePricingView.GetSelectedRows()[0]);
                if (r == null)
                {
                    alternatePricingID = "0";
                }
                else
                {
                    alternatePricingID = r["AlternateID"].ToString();
                }
            }

        }

        private void grdAlternatePricingView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdAlternatePricingView.GetDataRow(grdAlternatePricingView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete selected alternate?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            ProjectProposalAlternatePricing.Delete(r[2].ToString(), Convert.ToInt32(globalProposalID), Convert.ToInt32(globalREV), Convert.ToInt32(globalUser));
                            grdAlternatePricingView.DeleteRow(grdAlternatePricingView.GetSelectedRows()[0]);

                            if (globalProposalID == "0")
                            { txtAlternateTotal.Text = "$0"; }
                            else
                            {
                                DataTable dtPriceAlternateTotal = ProjectProposal.GetPricingAlternate(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV)).Tables[1];
                                txtAlternateTotal.Text = dtPriceAlternateTotal.Rows[0]["Total"].ToString();
                                MessageBox.Show("Deleted successfully.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                grdClassificationView.HideEditor();
                grdClassificationView.CancelUpdateCurrentRow();
                e.Handled = false;
            }
        }
        #endregion

        void riPopup_QueryPopUp(object sender, CancelEventArgs e)
        {
            BaseEdit editor = (BaseEdit)sender;
            richEditControl.Document.RtfText = editor.EditValue.ToString();
        }

        void riPopup_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            e.DisplayText = richEditControl.Document.Text;
        }

        void riPopup_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = richEditControl.Document.RtfText;
        }

        private void riPopup_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (!e.AcceptValue)
            {
                PopupContainerEdit pSender = (PopupContainerEdit)sender;
                RichEditControl rEdit = (RichEditControl)pSender.Properties.PopupControl.Controls[0];
                rEdit.Document.RtfText = e.Value.ToString();
            }
        }

        public void CreateRevision(int proposalID, int oldRev, int newRevision)
        {
            ProjectProposal emp = new ProjectProposal(globalProposalID, JobID, textEditSubject.Text,
                           txt1Date.Text,
                           comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString(),
                           textDynaEstimateNumber.Text, newRevision.ToString(), richBoxEditorDescription.Text,
                           richBoxEditorLeadTimes.Text, richBoxEditorScopeGenInfo.Text, richBoxEditorScopeAlternate.Text,
                           richBoxEditorClarification.Text, richBoxEditorExclusion.Text, null, null);

            DataTable dtPrice = ProjectProposal.GetPricing(proposalID, Convert.ToInt32(comboToPerson.EditValue), oldRev).Tables[0];
            DataTable dtAlternatePrice = ProjectProposal.GetPricingAlternate(proposalID, Convert.ToInt32(comboToPerson.EditValue), oldRev).Tables[0];
            #region Pricing
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("ProposalID", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("BaseBid", typeof(string)));
            tbl.Columns.Add(new DataColumn("Price", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("REV", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("User", typeof(Int32)));

            foreach (DataRow drPrice in dtPrice.Rows)
            {
                DataRow dr = tbl.NewRow();
                dr["ProposalID"] = proposalID;
                dr["BaseBid"] = drPrice["BaseBid"];
                dr["Price"] = drPrice["Price"];
                dr["REV"] = newRevision;
                dr["User"] = Convert.ToInt32(comboToPerson.EditValue);
                tbl.Rows.Add(dr);
            }
            #endregion

            #region Alternate Pricing
            DataTable tblA = new DataTable();
            tblA.Columns.Add(new DataColumn("ProposalID", typeof(Int32)));
            tblA.Columns.Add(new DataColumn("Alternate", typeof(string)));
            tblA.Columns.Add(new DataColumn("AlternatePrice", typeof(decimal)));
            tblA.Columns.Add(new DataColumn("REV", typeof(Int32)));
            tblA.Columns.Add(new DataColumn("User", typeof(Int32)));

            foreach (DataRow drAlternate in dtAlternatePrice.Rows)
            {
                DataRow dr = tblA.NewRow();
                dr["ProposalID"] = proposalID;
                dr["Alternate"] = drAlternate["Alternate"];
                dr["AlternatePrice"] = drAlternate["AlternatePrice"];
                dr["REV"] = newRevision;
                dr["User"] = Convert.ToInt32(comboToPerson.EditValue);
                tblA.Rows.Add(dr);
            }
            #endregion

            bool status = emp.CreateRevision(tbl, tblA);
            if (status == true)
            {
                MessageBox.Show("Revision No: " + newRevision + " " + "was created for current proposal for " + comboToPerson.Text, CCEApplication.ApplicationName);
                dataChanged = false;
                GetProposalDetail(globalProposalID);
                //Close();
            }


        }
        private void DeleteProposal()
        {
            try
            {
                bool status = ProjectProposal.Delete(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                if (status)
                {
                    MessageBox.Show("Proposal is deleted successfully.");
                    dataChanged = false;
                    Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private bool ValidateProposals(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // grdClassificationView.MoveNext();
                    // bindingSource.MoveNext();
                    if (ValidateAllControls())
                    {
                        SaveProposals();
                        bindingSource.EndEdit();
                        //dataChanged = false;
                        //btnUndo.Enabled = false;
                        //btnDelete.Enabled = true;
                        //btnRev.Enabled = true;
                        //btnCopy.Enabled = true;
                        return true;
                    }
                    else
                    {
                        if (!ssnValidation)
                        {
                            MessageBox.Show("Please make sure to enter all required fields.", CCEApplication.ApplicationName);
                        }
                        else
                        {
                            ssnValidation = false;
                        }
                        return false;
                    }
                }
                else
                {
                    //bindingSource.CancelEdit();
                    if (SelectedButton == ClickedButton.Save)
                    {
                        return false;
                    }
                    else
                    {
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //if (Security.Security.UserJCCFieldOperationLevel == Security.Security.AccessLevel.ReadOnly)
                        //{
                        //    btnCopy.Enabled = false;
                        //}
                        //else
                        //{
                        //    btnCopy.Enabled = true;
                        //}

                        dxErrorProvider.ClearErrors();
                        return true;
                    }
                }
            }
            else
            {
                //bindingSource.CancelEdit();
                ClearResourceValue();
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void grdClassificationView_CellValueChanged(Object sender, EventArgs e)
        {

            //btnSave.Enabled = true;
            //grdClassificationView.MoveNext();
            //dataChanged = true;
        }
        private DataTable Mapgridtodatatable(DevExpress.XtraGrid.Views.Grid.GridView GV)
        {



            DataTable dt = new DataTable();
            foreach (GridColumn column in GV.VisibleColumns)
            {
                dt.Columns.Add(column.FieldName, column.ColumnType);
            }
            dt.Columns.Add(new DataColumn("ProposalID", typeof(int)));
            dt.Columns.Add(new DataColumn("User", typeof(int)));
            dt.Columns.Add(new DataColumn("REV", typeof(int)));

            for (int i = 0; i < GV.DataRowCount; i++)
            {
                DataRow row = dt.NewRow();
                foreach (GridColumn column in GV.VisibleColumns)
                {
                    row[column.FieldName] = GV.GetRowCellValue(i, column);
                    row["ProposalID"] = globalProposalID;

                    if (string.IsNullOrEmpty(cboRevision.Text))
                    {
                        row["REV"] = "0";
                    }
                    else
                    { row["REV"] = cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1); }
                    row["User"] = comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString();

                }

                if (string.IsNullOrEmpty(Convert.ToString(row.ItemArray[0])) || string.IsNullOrEmpty(Convert.ToString(row.ItemArray[1])))
                { }
                else { dt.Rows.Add(row); }

            }

            return dt;

        }

        private DataTable Mapgridtodatatable1(DevExpress.XtraGrid.Views.Grid.GridView GV)
        {
            DataTable dt = new DataTable();
            //foreach (GridColumn column in GV.VisibleColumns)
            //{
            //    dt.Columns.Add(column.FieldName, column.ColumnType);
            //}
            dt.Columns.Add(new DataColumn("ProposalID", typeof(int)));
            dt.Columns.Add(new DataColumn("User", typeof(int)));
            dt.Columns.Add(new DataColumn("REV", typeof(int)));
            dt.Columns.Add(new DataColumn("Base Bid", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));

            for (int i = 0; i < GV.DataRowCount; i++)
            {
                DataRow row = dt.NewRow();
                foreach (GridColumn column in GV.VisibleColumns)
                {
                    if (column.ToString().Trim() == "Base Bid".ToString().Trim())
                    {
                        row[column.FieldName] = GV.GetRowCellValue(i, column);
                    }
                    else if (column.ToString().Trim() == "Price".ToString().Trim())
                    { row["Price"] = Convert.ToDecimal(GV.GetRowCellValue(i, column)); }

                    //row["BaseBid"] =GV.GetRowCellValue(i, column);
                    //row["Price"] = Convert.ToDecimal(GV.GetRowCellValue(i, column)); 
                    row["ProposalID"] = globalProposalID;

                    if (string.IsNullOrEmpty(cboRevision.Text))
                    {
                        row["REV"] = "0";
                    }
                    else
                    { row["REV"] = cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1); }
                    row["User"] = comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString();

                }
                dt.Rows.Add(row);
            }

            return dt;

        }

        private void ClearResourceValue()
        {
            if (!string.IsNullOrEmpty(JobID))
            {
                DataTable dt = ProjectProposal.GetJobAndEstimateNumber(JobID);
                textEditSubject.EditValue = dt.Rows[0]["JobName"].ToString();
                textDynaEstimateNumber.Text = dt.Rows[0]["EstimateNumber"].ToString();
                textDynaEstimateNumber.Enabled = false;
            }

            dataChanged = false;
            txt1Date.Text = "";
            btnUndo.Enabled = false;
            btnDelete.Enabled = false;
            btnRev.Enabled = false;
            btnCopy.Enabled = false;
            btnSave.Enabled = false;

            txt1Date.Text = string.Empty;
            comboToPerson.EditValue = null;
            comboToCompany.EditValue = null;

        }
        private void SaveProposals()
        {
            try
            {

                string path = "";
                string objexist = string.Empty;
                DataTable pricing = new DataTable(); //Mapgridtodatatable(grdClassificationView);                 
                DataTable alternatePricing = new DataTable(); //Mapgridtodatatable(grdAlternatePricingView);
                if (globalProposalID == "0" && isCopy == false)
                {
                    ProjectProposal emp = new ProjectProposal(globalProposalID, JobID, textEditSubject.Text,
                                txt1Date.Text,
                                comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString(),
                                textDynaEstimateNumber.Text, "0", richBoxEditorDescription.Text,
                                richBoxEditorLeadTimes.Text, richBoxEditorScopeGenInfo.Text, richBoxEditorScopeAlternate.Text,
                                richBoxEditorClarification.Text, richBoxEditorExclusion.Text, pricing, alternatePricing);
                    objexist = emp.Save();

                    if ((!string.IsNullOrEmpty(objexist) && Convert.ToString(objexist).Trim() == "Proposal Already Exist".Trim()))
                    {
                        MessageBox.Show("Proposal is already added for selected user! Please create a revision for existing proposal of " + comboToPerson.Text + ".");
                        btnUndo.Enabled = false;
                        btnDelete.Enabled = false;
                        btnRev.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        return;
                    }
                    else if ((!string.IsNullOrEmpty(objexist) && (Convert.ToInt32(objexist)) > 0))
                    {
                        objexist = globalProposalID;

                        pricing = Mapgridtodatatable(grdClassificationView);
                        alternatePricing = Mapgridtodatatable(grdAlternatePricingView);

                        if (pricing.Rows.Count > 0)
                        {
                            ProjectProposal.deletePricing(objexist, "0", comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                            ProjectProposal.BulkUpdatePricing(pricing);

                        }
                        if (alternatePricing.Rows.Count > 0)
                        {
                            ProjectProposal.deletePricingAlternate(objexist, "0", comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                            ProjectProposal.BulkUpdatePricingAlternate(alternatePricing);
                        }

                        if (objexist == "0" || objexist == "")
                        {
                            globalProposalID = ProjectProposal.globalProposalID;
                            globalREV = "0";
                            globalUser = comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString();
                            EnableTabPages();
                            MessageBox.Show("New Proposal is added successfully.");
                            GetEmployeeDetail(globalProposalID);
                            GetPricing(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                            GetPricingAlternate(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                            // btnDelete.Enabled = false;
                            btnUndo.Enabled = false;
                            btnDelete.Enabled = true;
                            btnRev.Enabled = true;
                            btnCopy.Enabled = true;
                        }
                    }
                }
                else if (globalProposalID == "0" && isCopy == true)
                {
                    pricing = new DataTable();
                    alternatePricing = new DataTable();
                    //pricing = Mapgridtodatatable(grdClassificationView);
                    //alternatePricing = Mapgridtodatatable(grdAlternatePricingView);
                    ProjectProposal emp = new ProjectProposal(globalProposalID, JobID, textEditSubject.Text,
                                txt1Date.Text,
                                comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString(),
                                textDynaEstimateNumber.Text, "0", richBoxEditorDescription.Text,
                                richBoxEditorLeadTimes.Text, richBoxEditorScopeGenInfo.Text, richBoxEditorScopeAlternate.Text,
                                richBoxEditorClarification.Text, richBoxEditorExclusion.Text, pricing, alternatePricing);
                    objexist = emp.Save();

                    if ((!string.IsNullOrEmpty(objexist) && Convert.ToString(objexist).Trim() == "Proposal Already Exist".ToString().Trim()))
                    {
                        MessageBox.Show("Proposal is already added for selected user! Please create a revision for existing proposal of " + comboToPerson.Text + ".");
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnDelete.Enabled = false;
                        btnRev.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        return;
                    }
                    else if ((!string.IsNullOrEmpty(objexist) && (Convert.ToInt32(objexist)) > 0))
                    {
                        globalProposalID = ProjectProposal.globalProposalID = objexist;

                        pricing = Mapgridtodatatable(grdClassificationView);
                        alternatePricing = Mapgridtodatatable(grdAlternatePricingView);

                        if (pricing.Rows.Count > 0)
                        {
                            ProjectProposal.deletePricing(objexist, "0", comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                            ProjectProposal.BulkUpdatePricing(pricing);

                        }
                        if (alternatePricing.Rows.Count > 0)
                        {
                            ProjectProposal.deletePricingAlternate(objexist, "0", comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                            ProjectProposal.BulkUpdatePricingAlternate(alternatePricing);
                        }

                        if (objexist != "0" || objexist != "")
                        {
                            globalProposalID = ProjectProposal.globalProposalID = objexist;
                            globalREV = "0";
                            globalUser = comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString();
                            EnableTabPages();
                            MessageBox.Show("New Proposal is added successfully.");
                            btnUndo.Enabled = false;
                            btnDelete.Enabled = true;
                            btnRev.Enabled = true;
                            btnCopy.Enabled = true;
                        }
                    }


                }
                else
                {
                    // grdClassificationView.MoveNext();
                    pricing = Mapgridtodatatable(grdClassificationView);
                    alternatePricing = Mapgridtodatatable(grdAlternatePricingView);
                    ProjectProposal emp = new ProjectProposal(globalProposalID, JobID, textEditSubject.Text,
                              txt1Date.Text,
                              comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString(),
                              textDynaEstimateNumber.Text, globalREV, richBoxEditorDescription.Text,
                              richBoxEditorLeadTimes.Text, richBoxEditorScopeGenInfo.Text, richBoxEditorScopeAlternate.Text,
                              richBoxEditorClarification.Text, richBoxEditorExclusion.Text, pricing, alternatePricing);
                    objexist = emp.Save();
                    ProjectProposal.UpdateDescription(globalProposalID, richBoxEditorDescription.Text, cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1), comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                    ProjectProposal.UpdateLeadTimes(globalProposalID, richBoxEditorLeadTimes.Text, cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1), comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                    ProjectProposal.UpdateClarification(globalProposalID, richBoxEditorClarification.Text, cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1), comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                    ProjectProposal.UpdateExclusion(globalProposalID, richBoxEditorExclusion.Text, cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1), comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                    ProjectProposal.UpdategenInfoAndAlternate(globalProposalID, richBoxEditorScopeGenInfo.Text, richBoxEditorScopeAlternate.Text, cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1), comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());

                    ProjectProposal.deletePricing(globalProposalID, cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1), comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                    ProjectProposal.deletePricingAlternate(globalProposalID, cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1), comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                    ProjectProposal.BulkUpdatePricing(pricing);
                    ProjectProposal.BulkUpdatePricingAlternate(alternatePricing);
                    if ((!string.IsNullOrEmpty(objexist)) && (Convert.ToString(objexist) == "True"))
                    {
                        MessageBox.Show("Proposal is updated successfully.");
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnDelete.Enabled = true;
                        btnRev.Enabled = true;
                        btnCopy.Enabled = true;
                        //Close();
                        // return;
                    }
                    else
                    {
                        MessageBox.Show("There is some error while updating the record.");
                        dataChanged = false;

                        Close();
                        return;
                    }
                }
                btnSave.Enabled = false;
                GetEmployeeDetail(globalProposalID);
                GetPricing(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                GetPricingAlternate(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                dataChanged = false;
                if (objexist == "Proposal Already Exist")
                {
                    MessageBox.Show("Proposal is already added for selected user! Please create a revision for existing proposal of " + comboToPerson.Text + ".");
                    btnSave.Enabled = false;
                    return;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
        }

        private void GetProposals()
        {
            GetEmployeeDetail(globalProposalID);
        }

        private bool ValidateAllControls()
        {
            UpdateErrorMessages("SAVE");
            return !errorMessages;
        }
        //
        private void AllControls_EditValue(Object sender, EventArgs e)
        {
            EnableControl();
        }



        private void EnableControl()
        {
            if (dataChanged)
            {
                // dataChanged = true;
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
                // btnCopy.Enabled = false;
            }
        }
        //
        private void frmServiceTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (bColumnWidthChanged)
            //{
            //    bColumnWidthChanged = false;
            //    try
            //    {
            //        // Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdDocumentView, "frmRFIDocument");
            //    }
            //    catch (Exception ex)
            //    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            //}
            //// ValidateProposals(ClickedButton.Close);
            //if (changesStatus)
            //{
            //    changesStatus = false;
            //}

            //if (dataChanged)
            //{
            //    if (MessageBox.Show("It looks like you have been editing something. If you leave before saving, your changes will be lost. Do you want to close this window? ", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        Close();
            //    }
            //    else
            //    { /*e.Cancel = true;*/ }

            //}



        }
        private void GetProposalDetail(string proposalID)
        {
            try
            {
                DataRow r;
                cboRevision.Properties.Items.Clear();
                if (!string.IsNullOrEmpty(proposalID) && (proposalID.Length > 0))
                {
                    DataSet ds = ProjectProposal.Getproposals(Convert.ToInt32(proposalID));
                    proposalRevision(ds);
                    proposalDetail(ds);
                }
                else
                {
                    GetDefaultDescription();
                    GetDefaultLeadTimes();
                    GetDefaultClarification();
                    GetDefaultGenInfoAndAlternates();
                    GetDefaultExclusion();
                    GetProposals();
                    GetPricing(0, 0, 0);
                    GetPricingAlternate(0, 0, 0);
                    MessageBox.Show("Proposal does not exists.");
                    Close();
                    dataChanged = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        public void proposalDetail(DataSet ds)
        {
            DataRow r;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataView view = new DataView(ds.Tables[0]);
                DataTable results;
                if (!string.IsNullOrEmpty(revCopy))
                {
                    view.RowFilter = "REV = " + revCopy;
                    results = view.ToTable(true);
                }
                else
                {
                    string str = cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1);
                    view.RowFilter = "REV = " + str;
                    results = view.ToTable(true);
                }


                r = results.Rows[0];
                if (r != null)
                {
                    textEditSubject.EditValue = r["Subject"];
                    txt1Date.EditValue = r["Date"];
                    comboToPerson.EditValue = r["User"];
                    textDynaEstimateNumber.Text = r["DynaEstimate"].ToString();
                    richBoxEditorDescription.Text = r["Desription"].ToString();
                    richBoxEditorLeadTimes.Text = r["LeadTime"].ToString();
                    richBoxEditorScopeGenInfo.Text = r["GenInfo"].ToString();
                    richBoxEditorScopeAlternate.Text = r["Alternate"].ToString();
                    richBoxEditorClarification.Text = r["Clarification"].ToString();
                    richBoxEditorExclusion.Text = r["Exclusion"].ToString();
                    comboToPerson.Enabled = false;
                    comboToCompany.Enabled = false;
                }
            }
        }

        public void getProposalForRevision(string proposalID, string revision)
        {
            if (!string.IsNullOrEmpty(proposalID) && (proposalID.Length > 0))
            {
                DataSet ds = ProjectProposal.Getproposals(Convert.ToInt32(proposalID));
                DataRow r;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView view = new DataView(ds.Tables[0]);
                    view.RowFilter = "REV = " + revision;
                    DataTable results = view.ToTable(true);

                    r = results.Rows[0];
                    if (r != null)
                    {
                        textEditSubject.EditValue = r["Subject"];
                        txt1Date.EditValue = r["Date"];
                        comboToPerson.EditValue = r["User"];
                        comboToPerson.Enabled = false;
                        comboToCompany.Enabled = false;
                        textDynaEstimateNumber.Text = r["DynaEstimate"].ToString();
                        richBoxEditorDescription.Text = r["Desription"].ToString();
                        richBoxEditorLeadTimes.Text = r["LeadTime"].ToString();
                        richBoxEditorScopeGenInfo.Text = r["GenInfo"].ToString();
                        richBoxEditorScopeAlternate.Text = r["Alternate"].ToString();
                        richBoxEditorClarification.Text = r["Clarification"].ToString();
                        richBoxEditorExclusion.Text = r["Exclusion"].ToString();
                        btnCopy.Enabled = true;
                    }
                }
            }
        }
        public void proposalRevision(DataSet ds)
        {
            try
            {
                cboRevision.Properties.Items.Clear();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        int counter = 0;
                        foreach (DataRow r1 in ds.Tables[1].Rows)
                        {
                            counter++;
                            if (r1[0].ToString().Length == 1)
                            {
                                cboRevision.Properties.Items.Add("00" + r1[0].ToString());
                            }
                            else
                            { cboRevision.Properties.Items.Add("0" + r1[0].ToString()); }
                            if (counter == ds.Tables[1].Rows.Count)
                            {
                                if (r1[0].ToString().Length == 1)
                                {
                                    cboRevision.SelectedItem = "00" + r1[0];
                                }
                                else
                                { cboRevision.SelectedItem = "0" + r1[0]; }
                                this.globalREV = r1[0].ToString().Trim();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { //MessageBox.Show(ex.Message, CCEApplication.ApplicationName); 
            }
            //this.globalREV = cboRevision.Text.Trim().Remove(0, 2);
        }
        private void UpdateErrorMessages(string from = "")
        {
            errorMessages = false;


            if (textEditSubject.Text.Trim().Length == 0)
            {
                textEditSubject.ErrorText = "Subject is required";
                errorMessages = true;
            }

            if (txt1Date.Text.Trim().Length == 0)
            {
                txt1Date.ErrorText = "Date is required";
                errorMessages = true;
            }

            if (comboToPerson.Text.Trim().Length == 0)
            {
                comboToPerson.ErrorText = "Person is required";
                errorMessages = true;
            }

            if (textDynaEstimateNumber.Text.Trim().Length == 0)
            {
                textDynaEstimateNumber.ErrorText = "Dyna Estimate is required";
                errorMessages = true;
            }


        }

        private void UpdateDataChange()
        {
            dataChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }



        private void GetPricing(int proposalID, int user, int rev)
        {

            DataTable dtPrice = new DataTable();
            if (proposalID == 0)
            {
                dtPrice = ProjectProposal.GetPricing(0, 0, 0).Tables[0];
                grdClassification.DataSource = dtPrice;

            }
            else
            {
                dtPrice = ProjectProposal.GetPricing(proposalID, user, rev).Tables[0];
                grdClassification.DataSource = dtPrice;
            }
            grdClassificationView.Columns["BaseBid"].ColumnEdit = repClassification;
            grdClassificationView.Columns["BaseBid"].Width = 650;
            grdClassificationView.Columns["Price"].ColumnEdit = repAddedBy;
            grdClassificationView.Columns["Price"].DisplayFormat.FormatString = " $ {0}";
            //   grdClassificationView.Columns["Price"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grdClassificationView.Columns["Price"].Width = 165;
            grdClassificationView.Columns["PricingID"].Visible = false;
            grdClassificationView.Columns["SerialNumber"].Visible = false;



            if (proposalID == 0)
            { txtPricingTotal.Text = "$0"; }
            else
            {
                DataTable dtPriceTotal = ProjectProposal.GetPricing(proposalID, user, rev).Tables[1];
                txtPricingTotal.Text = dtPriceTotal.Rows[0]["Total"].ToString();
            }
        }

        private void GetPricingAlternate(int proposalID, int user, int rev)
        {
            DataTable dtAlternatePrice = new DataTable();
            if (proposalID == 0)
            {
                dtAlternatePrice = ProjectProposal.GetPricingAlternate(0, 0, 0).Tables[0];
                gridPricingAlternate.DataSource = dtAlternatePrice;
            }
            else
            {
                dtAlternatePrice = ProjectProposal.GetPricingAlternate(proposalID, user, rev).Tables[0];
                gridPricingAlternate.DataSource = dtAlternatePrice;
            }


            grdAlternatePricingView.Columns["Alternate"].ColumnEdit = repAlternatePricing;
            //grdClassificationView.Columns["Assigned By"].ColumnEdit = repAddedBy;
            grdAlternatePricingView.Columns["Alternate"].Width = 650;
            grdAlternatePricingView.Columns["AlternatePrice"].ColumnEdit = repAddedByAlternatePricing;
            grdAlternatePricingView.Columns["AlternatePrice"].DisplayFormat.FormatString = " $ {0}";
            //  grdAlternatePricingView.Columns["AlternatePrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdAlternatePricingView.Columns["AlternatePrice"].Width = 165;
            grdAlternatePricingView.Columns["AlternateID"].Visible = false;
            grdAlternatePricingView.Columns["SerialNumber"].Visible = false;

            if (proposalID == 0)
            { txtAlternateTotal.Text = "$0"; }
            else
            {
                DataTable dtAlternatePriceTotal = ProjectProposal.GetPricingAlternate(proposalID, user, rev).Tables[1];
                txtAlternateTotal.Text = dtAlternatePriceTotal.Rows[0]["Total"].ToString();
            }

        }



        private void UpdatePricing()
        {
            if (grdClassificationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdClassificationView.GetDataRow(grdClassificationView.GetSelectedRows()[0]);
                Cursor = Cursors.AppStarting;
                if (r == null)
                {
                    return;
                }

                try
                {
                    ProjectProposalPricing objPricing = new ProjectProposalPricing(r["BaseBid"].ToString(),
                                        r["Price"].ToString(),
                                        r["PricingID"].ToString(),
                                       globalProposalID, this.globalREV, this.globalUser);
                    objPricing.Save();

                    GetPricing(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                    //GetPricingAlternate(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));

                    if (string.IsNullOrEmpty(r["PricingID"].ToString()))
                    {
                        MessageBox.Show("Pricing detail saved successfully.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Pricing detail updated successfully.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                        btnDelete.Enabled = true;
                    }
                    Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }

        private void UpdatePricingAlternate()
        {
            if (grdClassificationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdAlternatePricingView.GetDataRow(grdAlternatePricingView.GetSelectedRows()[0]);
                Cursor = Cursors.AppStarting;
                if (r == null)
                {
                    return;
                }

                try
                {
                    ProjectProposalAlternatePricing objPricing = new ProjectProposalAlternatePricing(r["Alternate"].ToString(),
                                        r["AlternatePrice"].ToString(),
                                        r["AlternateID"].ToString(),
                                       globalProposalID, this.globalUser, this.globalREV);
                    objPricing.Save();
                    //GetPricing(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                    GetPricingAlternate(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(globalREV));
                    if (string.IsNullOrEmpty(r["AlternateID"].ToString()))
                    {
                        MessageBox.Show("Alternate detail saved successfully.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    }
                    else
                    { MessageBox.Show("Alternate detail updated successfully.", CCEApplication.ApplicationName, MessageBoxButtons.OK); }

                    //pricingID = objPricing.PricingID;
                    Cursor = Cursors.Default;
                    //r["ClassificationID"] = classificationID;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }

        private void UpdateTermination()
        {
            if (grdTerminationView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdTerminationView.GetDataRow(grdTerminationView.GetSelectedRows()[0]);
                Cursor = Cursors.AppStarting;
                if (r == null)
                {
                    return;
                }

                try
                {
                    Termination term = new Termination(r["Reason"].ToString(),
                                        r["TerminationDate"].ToString(),
                                        r["TerminationID"].ToString(),
                                       globalProposalID);
                    term.Save();
                    terminationID = term.TerminationID;
                    Cursor = Cursors.Default;
                    r["TerminationID"] = terminationID;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }

        private void DisableTabPages()
        {
            xtraTabPage9.PageEnabled = false;
            xtraTabPage10.PageEnabled = false;
            xtraTabPage11.PageEnabled = false;
            xtraTabPage12.PageEnabled = false;
            xtraTabPage13.PageEnabled = false;
            xtraTabPage15.PageEnabled = false;
            xtraTabPage16.PageEnabled = false;

        }

        private void EnableTabPages()
        {
            xtraTabPage9.PageEnabled = true;
            xtraTabPage10.PageEnabled = true;
            xtraTabPage11.PageEnabled = true;
            xtraTabPage12.PageEnabled = true;
            xtraTabPage13.PageEnabled = true;
            // xtraTabPage14.PageEnabled = true;
            xtraTabPage15.PageEnabled = true;
            xtraTabPage16.PageEnabled = true;
        }

        private void DisableControl()
        {
            try
            {
                btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSave.Enabled = false;
                btnUndo.Enabled = false;
                btnCopy.Enabled = false;
                txt1Date.Enabled = false;
                cboJobStatus.Enabled = false;
                cboBiddingDepartment.Enabled = false;
                txtTerminationReason.Enabled = false;
                txtGeneralNotes.Enabled = false;
                grdClassification.Enabled = false;
                gridPricingAlternate.Enabled = false;
                grdTermination.Enabled = false;
                btnEvalSave.Enabled = false;
                btnSaveTraining.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    queryWhere = " WHERE A.EmployeeID= " + globalProposalID;
        //    if (txtFrom.Text.Length > 0 && txtTo.Text.Length > 0)
        //    {
        //        queryWhere += " AND (A.TrainingDate BETWEEN '" + txtFrom.Text + "' AND '" + txtTo.Text + "')";
        //    }
        //    else
        //    {
        //        if (txtFrom.Text.Length > 0)
        //        {
        //            queryWhere += " AND A.TrainingDate = '" + txtFrom.Text + "' ";
        //        }

        //        if (txtTo.Text.Length > 0)
        //        {
        //            queryWhere += " AND A.TrainingDate = '" + txtTo.Text + "' ";
        //        }
        //    }

        //    // GetEmployeeTrainings(queryWhere);
        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTo.Text = null;
            txtFrom.Text = null;
            // queryWhere = "WHERE A.EmployeeID = " + globalProposalID;
            // GetEmployeeTrainings(queryWhere);
        }


        private void txtSSn_TextChanged(object sender, EventArgs e)
        {
            EnableControl();
        }



        private void labelControl4_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = txtGeneralNotes.Text
            };
            f.ShowDialog();
            txtGeneralNotes.Text = f.MyText;
            EnableControl();
        }
        private void labelControl27_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = txtTerminationReason.Text
            };
            f.ShowDialog();
            txtTerminationReason.Text = f.MyText;
            EnableControl();
        }

        private void txt1JobName_TextChanged(object sender, EventArgs e)
        {
            dataChanged = true;
        }

        private void txt1JobName_EditValueChanged(object sender, EventArgs e)
        {
            AllControls_EditValue(sender, e);
        }

        private void richBoxEditorScopeGenInfo_Click(object sender, EventArgs e)
        {

            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = richBoxEditorScopeGenInfo.Text
            };
            f.ShowDialog();
            richBoxEditorScopeGenInfo.Text = f.MyText;
            EnableControl();
        }

        private void richBoxEditorScopeAlternate_Click(object sender, EventArgs e)
        {

            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = richBoxEditorScopeAlternate.Text
            };
            f.ShowDialog();
            richBoxEditorScopeAlternate.Text = f.MyText;
            EnableControl();
        }

        //private void hyperlinkLabelDescription_Click(object sender, EventArgs e)
        //{
        //    ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
        //    {
        //        MyText = richBoxEditorDescription.Text
        //    };
        //    f.ShowDialog();
        //    richBoxEditorDescription.Text = f.MyText;
        //    EnableControl();
        //    btnSaveDescription.Enabled = true;
        //    btnCancelDescription.Enabled = true;
        //}

        private void textEditSubject_TextChanged(object sender, EventArgs e)
        {
            dataChanged = true;
            EnableControl();
        }

        private void textDynaEstimateNumber_TextChanged(object sender, EventArgs e)
        {
            //dataChanged = true;
            //EnableControl();
        }

        private void comboToPerson_EditValueChanged(object sender, EventArgs e)
        {

            if (comboToPerson.EditValue == null || comboToPerson.EditValue.ToString().Trim() == "")
            {
                comboToCompany.Text = "";
            }
            else
            {
                int i = 0;
                contact.DefaultView.Sort = "ContactID";
                i = contact.DefaultView.Find(comboToPerson.EditValue.ToString());
                if (i != -1)
                {
                    comboToCompany.Text = contact.DefaultView[i][2].ToString();
                    comboToCompany.Enabled = false;
                }
                else
                {
                    comboToCompany.Text = "";
                    comboToCompany.Enabled = false;
                }
                dataChanged = true;

            }
            EnableControl();
        }

        private void comboToCompany_EditValueChanged(object sender, EventArgs e)
        {
            EnableControl();
        }

        private void btnSaveLeadTimes_Click(object sender, EventArgs e)
        {
            try
            {
                //if (globalProposalID.Length > 0 && globalProposalID != "0")
                //{
                //    if (globalProposalID.Length > 0 && globalProposalID != "0")
                //    {
                //        bool status = ProjectProposal.UpdateLeadTimes(globalProposalID, richBoxEditorLeadTimes.Text, globalREV, comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                //        if (status)
                //        {
                //            MessageBox.Show("Lead time is updated successfully.");
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
        }

        private void btnCancelLeadTimes_Click(object sender, EventArgs e)
        {
            if (globalProposalID.Length > 0 && globalProposalID != "0")
            {
                DataSet dsLeadTime = ProjectProposal.GetProposalleadTime(globalProposalID, this.globalUser, this.globalREV);
                if (dsLeadTime.Tables[0].Rows.Count > 0)
                {
                    DataRow r = dsLeadTime.Tables[0].Rows[0];
                    richBoxEditorDescription.Text = r["Value"].ToString();
                }
            }
            else
            {
                GetDefaultLeadTimes();
            }
        }

        private void btnSavePricing_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelPricing_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePricingAlternate_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelPricingAlternate_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveScopeInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //if (globalProposalID.Length > 0 && globalProposalID != "0")
                //{
                //    if (globalProposalID.Length > 0 && globalProposalID != "0")
                //    {
                //        bool status = ProjectProposal.UpdategenInfoAndAlternate(globalProposalID, richBoxEditorScopeGenInfo.Text, richBoxEditorScopeAlternate.Text, globalREV, comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                //        if (status)
                //        {
                //            MessageBox.Show("Scope Info. is updated successfully.");
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
        }

        private void btnCancelScopeInfo_Click(object sender, EventArgs e)
        {
            if (globalProposalID.Length > 0 && globalProposalID != "0")
            {
                DataSet dsGenInfoandAlternaten = ProjectProposal.GetProposalGenInfoAndAlternate(globalProposalID, this.globalUser, this.globalREV);
                if (dsGenInfoandAlternaten.Tables[0].Rows.Count > 0)
                {
                    DataRow r = dsGenInfoandAlternaten.Tables[0].Rows[0];

                    richBoxEditorScopeGenInfo.Text = r["Value"].ToString();
                    richBoxEditorScopeAlternate.Text = r["Value2"].ToString();
                }
            }
            else
            {
                GetDefaultGenInfoAndAlternates();
            }
        }

        private void btnCancelClarification_Click(object sender, EventArgs e)
        {
            if (globalProposalID.Length > 0 && globalProposalID != "0")
            {
                DataSet dsClarification = ProjectProposal.GetProposalClarification(globalProposalID, this.globalUser, this.globalREV);
                if (dsClarification.Tables[0].Rows.Count > 0)
                {
                    DataRow r = dsClarification.Tables[0].Rows[0];
                    richBoxEditorDescription.Text = r["Value"].ToString();
                }
            }
            else
            {
                GetDefaultClarification();
            }
        }

        private void btnClarificationSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (globalProposalID.Length > 0 && globalProposalID != "0")
                //{
                //    if (globalProposalID.Length > 0 && globalProposalID != "0")
                //    {
                //        bool status = ProjectProposal.UpdateClarification(globalProposalID, richBoxEditorClarification.Text, globalREV, comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                //        if (status)
                //        {
                //            MessageBox.Show("Clarification is updated successfully.");
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

        }

        private void btnExclusionCancel_Click(object sender, EventArgs e)
        {
            if (globalProposalID.Length > 0 && globalProposalID != "0")
            {
                DataSet dsExclusion = ProjectProposal.GetProposalExclusion(globalProposalID, this.globalUser, this.globalREV);
                if (dsExclusion.Tables[0].Rows.Count > 0)
                {
                    DataRow r = dsExclusion.Tables[0].Rows[0];
                    richBoxEditorDescription.Text = r["Value"].ToString();
                }
            }
            else
            {
                GetDefaultExclusion();
            }
        }

        private void btnSaveExclusion_Click(object sender, EventArgs e)
        {
            try
            {
                //if (globalProposalID.Length > 0 && globalProposalID != "0")
                //{
                //    bool status = ProjectProposal.UpdateExclusion(globalProposalID, richBoxEditorExclusion.Text, globalREV, comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                //    if (status)
                //    {
                //        MessageBox.Show("Exclusion is updated successfully.");
                //    }
                //}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
        }

        private void btnCancelDescription_Click(object sender, EventArgs e)
        {
            if (globalProposalID.Length > 0 && globalProposalID != "0")
            {
                DataSet dsDescription = ProjectProposal.GetProposalDescription(globalProposalID, this.globalUser, this.globalREV);
                if (dsDescription.Tables[0].Rows.Count > 0)
                {
                    DataRow r = dsDescription.Tables[0].Rows[0];
                    richBoxEditorDescription.Text = r["Value"].ToString();
                }
            }
            else
            {
                GetDefaultDescription();
            }
        }

        private void btnSaveDescription_Click(object sender, EventArgs e)
        {
            try
            {
                //if (globalProposalID.Length > 0 && globalProposalID != "0")
                //{
                //    bool status = ProjectProposal.UpdateDescription(globalProposalID, richBoxEditorDescription.Text, globalREV, comboToPerson.EditValue == null ? "" : comboToPerson.EditValue.ToString());
                //    if (status)
                //    {
                //        MessageBox.Show("Description is updated successfully.");
                //    }
                //}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
        }

        private void hyperlinkDescription_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = richBoxEditorDescription.Text
            };
            f.ShowDialog();
            richBoxEditorDescription.Text = f.MyText;
            EnableControl();
            //btnSaveDescription.Enabled = true;
            btnCancelDescription.Enabled = false;
            btnSave.Enabled = true;
            btnUndo.Enabled = true;
            dataChanged = true;
            // btnSaveDescription.Visible = true;
            btnCancelDescription.Visible = false;

        }

        private void hyperlinkGenInfo_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = richBoxEditorScopeGenInfo.Text
            };
            f.ShowDialog();
            richBoxEditorScopeGenInfo.Text = f.MyText;
            EnableControl();
            btnSave.Enabled = true;
            btnUndo.Enabled = true;

            btnCancelScopeInfo.Enabled = false;

            btnCancelScopeInfo.Visible = false;
            dataChanged = true;
        }

        private void hyperlinkLabelAlternate_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = richBoxEditorScopeAlternate.Text
            };
            f.ShowDialog();
            richBoxEditorScopeAlternate.Text = f.MyText;
            EnableControl();
            btnSave.Enabled = true;
            btnUndo.Enabled = true;
            btnCancelScopeInfo.Visible = false;
            // btnSaveScopeInfo.Visible = true;
            btnCancelScopeInfo.Enabled = false;
            //btnSaveScopeInfo.Enabled = true;
            dataChanged = true;
        }

        private void hyperlinkLabelExclusion_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = richBoxEditorExclusion.Text
            };
            f.ShowDialog();
            richBoxEditorExclusion.Text = f.MyText;
            EnableControl();
            btnSave.Enabled = true;
            btnUndo.Enabled = true;
            //btnSaveExclusion.Enabled = true;
            btnExclusionCancel.Enabled = false;
            // btnSaveExclusion.Visible = true;
            btnExclusionCancel.Visible = false;
            dataChanged = true;
        }

        private void hyperlinkLabelLeadtimes_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = richBoxEditorLeadTimes.Text
            };
            f.ShowDialog();
            richBoxEditorLeadTimes.Text = f.MyText;
            EnableControl();
            btnSave.Enabled = true;
            btnUndo.Enabled = true;
            btnCancelLeadTimes.Enabled = false;
            btnCancelLeadTimes.Visible = false;
            dataChanged = true;
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord
            {
                MyText = richBoxEditorClarification.Text.ToString()
            };
            f.ShowDialog();
            richBoxEditorClarification.Text = f.MyText.ToString();
            EnableControl();
            btnSave.Enabled = true;
            btnUndo.Enabled = true;
            btnCancelClarification.Enabled = false;
            btnCancelClarification.Visible = false;
            dataChanged = true;
        }
        string subString = "00";
        private void cboRevision_SelectedValueChanged(object sender, EventArgs e)
        {



            this.globalREV = cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1);
            getProposalForRevision(globalProposalID, cboRevision.Text.Trim().Remove(0, 2));
            GetPricing(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1)));
            GetPricingAlternate(Convert.ToInt32(globalProposalID), Convert.ToInt32(globalUser), Convert.ToInt32(cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1)));
            btnSave.Enabled = false;
            btnRev.Enabled = true;
            dataChanged = false;
            dataChanged = false;

            string str = cboRevision.Text.Trim().StartsWith(subString) == true ? cboRevision.Text.Trim().Remove(0, 2) : cboRevision.Text.Trim().Remove(0, 1);

            if (str == "0".ToString())
            { btnDelete.Enabled = false; }
            else
            {
                btnDelete.Enabled = true;
            }

        }

        private void frmProjectProposal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("It looks like you have been editing something. If you leave before saving, your changes will be lost. Do you want to close this window? ", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Close();
                    e.Cancel = false;
                    dataChanged = false;
                }
                else
                { e.Cancel = true; }

            }
        }

        private void grdClassificationView_c(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.ToString() == "Price".ToString())
            //{
            //    if (e.Value.ToString() == "$")
            //        { e.Value.ToString().Replace("$", ""); }
            //}
        }

        private void grdClassificationView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //string s = "$";
            //if (view.FocusedColumn.FieldName == "Price" && s.IndexOf(e.KeyChar) >= 0)
            //    e.Handled = true;
        }

        private void grdClassificationView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            // if (column.FieldName != "Price") return;

            if (column.FieldName == "Price")
            {
                if (e.Value.ToString().Contains("$"))
                {
                    MessageBox.Show("Please enter only numeric/decimal value in price column.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Valid = false;
                    return;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(e.Value)))
                {
                    decimal myDec;
                    bool Result = decimal.TryParse(Convert.ToString(e.Value), out myDec);
                    if (Result == false)
                    {
                        MessageBox.Show("Please enter only numeric/decimal value in price column.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                        e.Valid = false;
                        return;
                    }

                    if (Result == true)
                    {
                        if ((Convert.ToDecimal(e.Value) < -1000000000) || (Convert.ToDecimal(e.Value) > 1000000000))
                        {
                            MessageBox.Show("Price value should not exceed 9 digits.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                            e.Valid = false;
                            return;
                        }
                    }
                }
            }
            else if (column.FieldName == "BaseBid")
            {
                if ((Convert.ToDecimal(e.Value.ToString().Length) > 500))
                {
                    MessageBox.Show("Base Bid value should not exceed 500 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Valid = false;
                    return;
                }
            }
        }

        private void grdAlternatePricingView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            //if (column.FieldName != "AlternatePrice") return;
            if (column.FieldName == "AlternatePrice")
            {
                if (e.Value.ToString().Contains("$"))
                {
                    MessageBox.Show("Please enter only numeric/decimal value in price column.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Valid = false;
                    return;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(e.Value)))
                {
                    decimal myDec;
                    bool Result = decimal.TryParse(Convert.ToString(e.Value), out myDec);
                    if (Result == false)
                    {
                        MessageBox.Show("Please enter only numeric/decimal value in price column.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                        e.Valid = false;
                        return;
                    }

                    if (Result == true)
                    {
                        if ((Convert.ToDecimal(e.Value) < -1000000000) || (Convert.ToDecimal(e.Value) > 1000000000))
                        {
                            MessageBox.Show("Price value should not exceed 9 digits.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                            e.Valid = false;
                            return;
                        }
                    }
                }
            }
            else if (column.FieldName == "Alternate")
            {
                if ((Convert.ToDecimal(e.Value.ToString().Length) > 500))
                {
                    MessageBox.Show("Alternate value should not exceed 500 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Valid = false;
                    return;
                }
            }
        }

        private void txt1Date_EditValueChanging(object sender, ChangingEventArgs e)
        {
            dataChanged = true;
        }
    }
}
