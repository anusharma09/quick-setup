using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;

namespace CCEJobs.PresentationLayer
{
    public partial class frmJobSystemDefaultValues : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected bool dataChanged;
        private bool errorMessages = false;
        protected string currentButtonName = "";
        protected string jobID = "";
        protected DataTable contact;
        private bool changesStatus = false;
        DataTable submittalSpec;
        //
        enum ClickedButton
        {
            Save,
            Undo,
            Close
        };
        //
        public frmJobSystemDefaultValues()
        {
            InitializeComponent();
        }
        //
        public frmJobSystemDefaultValues(string jobID)
        {
            this.jobID = jobID;
            InitializeComponent();
            this.Text = "Job Default Values";
        }
        //
        private void frmJobSystemDefaultValues_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                if (jobID.Trim().Length > 0)
                {
                    this.xtraTabControl1.TabPages[3].PageVisible = true;
                    contact = Contact.GetJobContactForPullDown(jobID).Tables[0];
                    cboRFIDefaultContact.Properties.DataSource = contact;
                    cboRFIDefaultContact.Properties.PopulateColumns();
                    cboRFIDefaultContact.Properties.DisplayMember = "Name";
                    cboRFIDefaultContact.Properties.ValueMember = "ContactID";
                    cboRFIDefaultContact.Properties.ShowHeader = false;
                    //cboRFIDefaultContact.Properties.Columns[0].Visible = false;

                    cboChangeOrderDefaultContact.Properties.DataSource = contact;
                    cboChangeOrderDefaultContact.Properties.PopulateColumns();
                    cboChangeOrderDefaultContact.Properties.DisplayMember = "Name";
                    cboChangeOrderDefaultContact.Properties.ValueMember = "ContactID";
                    cboChangeOrderDefaultContact.Properties.ShowHeader = false;
                    //cboChangeOrderDefaultContact.Properties.Columns[0].Visible = false;
                    cboDefaultFrom.Properties.DataSource = contact;
                    cboDefaultFrom.Properties.PopulateColumns();
                    cboDefaultFrom.Properties.DisplayMember = "Name";
                    cboDefaultFrom.Properties.ValueMember = "ContactID";
                    cboDefaultFrom.Properties.ShowHeader = false;

                    cboForeman.Properties.DataSource = contact;
                    cboForeman.Properties.PopulateColumns();
                    cboForeman.Properties.DisplayMember = "Name";
                    cboForeman.Properties.ValueMember = "ContactID";
                    cboForeman.Properties.ShowHeader = false;

                    //cboChangeOrderDefaultContact.Properties.Columns[0].Visible = false;

                }
                else
                    this.xtraTabControl1.TabPages[3].PageVisible = false;
                GetJobSystemDefaultValues();
                GetSubmittalSpec();
                this.Opacity = 1;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetJobSystemDefaultValues()
        {
            changesStatus = false;

            try
            {
                DataRow r;
                if (jobID.Trim().Length > 0)
                    r = JobDefaultValues.GetJobDefaultValues(jobID).Tables[0].Rows[0];
                else
                    r = JobSystemDefaultValues.GetJobSystemDefaultValues().Tables[0].Rows[0];

                txtChangeOrderStipulationsParagraph1.Text = r["ChangeOrderStipulationsParagraph1"].ToString();
                txtChangeOrderStipulationsParagraph2.Text = r["ChangeOrderStipulationsParagraph2"].ToString();
                txtMajorPONote.Text = r["MajorPONote"].ToString();
                txtSmallPONote.Text = r["SmallPONote"].ToString();
                txtSundriesPercentOfMaterial.Text = r["SundriesPercentOfMaterial"].ToString();
                txtSalesTaxPercent.Text = r["SalesTaxPercent"].ToString();
                txtAsBuiltsEngineeringPercent.Text = r["AsBuiltsEngineeringPercent"].ToString();
                txtStoragePercent.Text = r["StoragePercent"].ToString();
                txtSmallToolsPercent.Text = r["SmallToolsPercent"].ToString();
                txtCartigeHandlingPercent.Text = r["CartigeHandlingPercent"].ToString();
                txtForemanPercentOfLabor.Text = r["ForemanPercentOfLabor"].ToString();
                txtGeneralForemanPercentOfLabor.Text = r["GeneralForemanPercentOfLabor"].ToString();
                txtSuperintendentPercentOfLabor.Text = r["SuperintendentPercentOfLabor"].ToString();
                txtProjectManagerPercentOfLabor.Text = r["ProjectManagerPercentOfLabor"].ToString();
                txtProjectEngineerPercentOfLabor.Text = r["ProjectEngineerPercentOfLabor"].ToString();
                txtSafetyMeetingPercent.Text = r["SafetyMeetingPercent"].ToString();
                txtFringeBenefitsPercent.Text = r["FringeBenefitsPercent"].ToString();
                txtOverheadPercent.Text = r["OverheadPercent"].ToString();
                txtProfitPercent.Text = r["ProfitPercent"].ToString();
                txtSubcontractAdministrationPercent.Text = r["SubcontractAdministrationPercent"].ToString();
                txtWarrantyPercent.Text = r["WarrantyPercent"].ToString();
                txtBondPercent.Text = r["BondPercent"].ToString();

                txtBIMRate.Text = r["BIMRate"].ToString();
                txtApprenticeLaborRate.Text = r["ApprenticeLaborRate"].ToString();
                txtElectricianLaborRate.Text = r["ElectricianLaborRate"].ToString();
                txtForemanLaborRate.Text = r["ForemanLaborRate"].ToString();
                txtGeneralForemanLaborRate.Text = r["GeneralForemanLaborRate"].ToString();
                txtSuperintendentLaborRate.Text = r["SuperintendentLaborRate"].ToString();
                txtProjectManagerLaborRate.Text = r["ProjectManagerLaborRate"].ToString();
                txtProjectEngineerLaborRate.Text = r["ProjectEngineerLaborRate"].ToString();
                txtSafetyMeetingsLaborRate.Text = r["SafetyMeetingsLaborRate"].ToString();
                txtPremiumTimeLaborRate.Text = r["PremiumTimeLaborRate"].ToString();

                txtBIMRateOT.Text = r["BIMRateOT"].ToString();
                txtApprenticeLaborRateOT.Text = r["ApprenticeLaborRateOT"].ToString();
                txtElectricianLaborRateOT.Text = r["ElectricianLaborRateOT"].ToString();
                txtForemanLaborRateOT.Text = r["ForemanLaborRateOT"].ToString();
                txtGeneralForemanLaborRateOT.Text = r["GeneralForemanLaborRateOT"].ToString();
                txtSuperintendentLaborRateOT.Text = r["SuperintendentLaborRateOT"].ToString();
                txtProjectManagerLaborRateOT.Text = r["ProjectManagerLaborRateOT"].ToString();
                txtProjectEngineerLaborRateOT.Text = r["ProjectEngineerLaborRateOT"].ToString();
                txtSafetyMeetingsLaborRateOT.Text = r["SafetyMeetingsLaborRateOT"].ToString();
                txtPremiumTimeLaborRateOT.Text = r["PremiumTimeLaborRateOT"].ToString();

                txtBIMRateDT.Text = r["BIMRateDT"].ToString();
                txtApprenticeLaborRateDT.Text = r["ApprenticeLaborRateDT"].ToString();
                txtElectricianLaborRateDT.Text = r["ElectricianLaborRateDT"].ToString();
                txtForemanLaborRateDT.Text = r["ForemanLaborRateDT"].ToString();
                txtGeneralForemanLaborRateDT.Text = r["GeneralForemanLaborRateDT"].ToString();
                txtSuperintendentLaborRateDT.Text = r["SuperintendentLaborRateDT"].ToString();
                txtProjectManagerLaborRateDT.Text = r["ProjectManagerLaborRateDT"].ToString();
                txtProjectEngineerLaborRateDT.Text = r["ProjectEngineerLaborRateDT"].ToString();
                txtSafetyMeetingsLaborRateDT.Text = r["SafetyMeetingsLaborRateDT"].ToString();
                txtPremiumTimeLaborRateDT.Text = r["PremiumTimeLaborRateDT"].ToString();

                //labelControl134.Text = BIMRate = r["BIMRate_Label"].ToString().Trim();
                if (r["BIMRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl134.Text = BIMRate = string.Empty; }
                else
                {
                    labelControl134.Text = BIMRate = Convert.ToString(r["BIMRate_Label"]).Trim();
                }
                //labelControl130.Text = strlabelControl130 = r["ApprenticeLaborRate_Label"].ToString().Trim();
                if (r["ApprenticeLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl130.Text = strlabelControl130 = string.Empty; }
                else
                { labelControl130.Text = strlabelControl130 = Convert.ToString(r["ApprenticeLaborRate_Label"]).Trim(); }


                //labelControl119.Text = strlabelControl119 = r["ElectricianLaborRate_Label"].ToString().Trim();
                if (r["ElectricianLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl119.Text = strlabelControl119 = string.Empty; }
                else
                { labelControl119.Text = strlabelControl119 = Convert.ToString(r["ElectricianLaborRate_Label"]).Trim(); }

                //labelControl118.Text = strlabelControl118 = r["ForemanLaborRate_Label"].ToString().Trim();
                if (r["ForemanLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl118.Text = strlabelControl118 = string.Empty; }
                else
                { labelControl118.Text = strlabelControl118 = Convert.ToString(r["ForemanLaborRate_Label"]).Trim(); }

                //labelControl117.Text = strlabelControl117 = r["GeneralForemanLaborRate_Label"].ToString().Trim();
                if (r["GeneralForemanLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl117.Text = strlabelControl117 = string.Empty; }
                else
                { labelControl117.Text = strlabelControl117 = Convert.ToString(r["GeneralForemanLaborRate_Label"]).Trim(); }

                //labelControl116.Text = strlabelControl116 = r["SuperintendentLaborRate_Label"].ToString().Trim();
                if (r["SuperintendentLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl116.Text = strlabelControl116 = string.Empty; }
                else
                { labelControl116.Text = strlabelControl116 = Convert.ToString(r["SuperintendentLaborRate_Label"]).Trim(); }


                // labelControl115.Text = strlabelControl115 = r["ProjectManagerLaborRate_Label"].ToString().Trim();
                if (r["ProjectManagerLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl115.Text = strlabelControl115 = string.Empty; }
                else
                { labelControl115.Text = strlabelControl115 = Convert.ToString(r["ProjectManagerLaborRate_Label"]).Trim(); }


                // labelControl120.Text = strlabelControl120 = r["ProjectEngineerLaborRate_Label"].ToString().Trim();
                if (r["ProjectEngineerLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl120.Text = strlabelControl120 = string.Empty; }
                else
                { labelControl120.Text = strlabelControl120 = Convert.ToString(r["ProjectEngineerLaborRate_Label"]).Trim(); }


                if (r["SafetyMeetingsLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl114.Text = strlabelControl114 = string.Empty; }
                else
                {
                    labelControl114.Text = strlabelControl114 = Convert.ToString(r["SafetyMeetingsLaborRate_Label"]).Trim();
                }

                //labelControl113.Text = strlabelControl113 = r["PremiumTimeLaborRate_Label"].ToString().Trim();
                if (r["PremiumTimeLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl113.Text = strlabelControl113 = string.Empty; }
                else
                { labelControl113.Text = strlabelControl113 = Convert.ToString(r["PremiumTimeLaborRate_Label"]).Trim(); }

                //labelControl15.Text = strlabelControl15 = r["FringeBenefitsPercent_Label"].ToString().Trim();
                if (r["FringeBenefitsPercent_Label"].ToString().Trim() == "Null".ToString())
                { labelControl15.Text = strlabelControl15 = string.Empty; }
                else
                { labelControl15.Text = strlabelControl15 = Convert.ToString(r["FringeBenefitsPercent_Label"]).Trim(); }

                //labelControl16.Text = strlabelControl16 = r["SafetyMeetingPercent_Label"].ToString().Trim();
                if (r["SafetyMeetingPercent_Label"].ToString().Trim() == "Null".ToString())
                { labelControl16.Text = strlabelControl16 = string.Empty; }
                else
                { labelControl16.Text = strlabelControl16 = Convert.ToString(r["SafetyMeetingPercent_Label"]).Trim(); }


                if (jobID.Trim().Length > 0)
                {
                    cboChangeOrderDefaultContact.EditValue = r["JobDefaultChangeOrderContactID"];
                    cboRFIDefaultContact.EditValue = r["JobDefaultRFIContactID"];
                    cboDefaultFrom.EditValue = r["JobDefaultFromID"];
                    cboForeman.EditValue = r["JobForemanID"];
                }

                // Get the Values Here

                btnSave.Enabled = false;
                btnUndo.Enabled = false;
                dataChanged = false;
                UpdateErrorMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "&Save":
                    if (CheckStatus(ClickedButton.Save))
                    {
                    }
                    break;
                case "&Undo":
                    GetJobSystemDefaultValues();
                    GetSubmittalSpec();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    break;
            }
        }
        //
        private bool CheckStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {

                        Save();
                        dataChanged = false;
                        btnUndo.Enabled = false;
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
                    if (SelectedButton == ClickedButton.Save)
                        return false;
                    else
                    {
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        return true;
                    }
                }
            }
            else
            {
                dataChanged = false;
                btnUndo.Enabled = false;
                return true;
            }
        }
        //
        private void Save()
        {
            try
            {
                if (labelControl130.EditValue.ToString().Length > 27 || labelControl119.EditValue.ToString().Length > 27 || labelControl118.EditValue.ToString().Length > 27 ||
                 labelControl117.EditValue.ToString().Length > 27 ||
                 labelControl116.EditValue.ToString().Length > 27 ||
                 labelControl115.EditValue.ToString().Length > 27 ||
                 labelControl120.EditValue.ToString().Length > 27 ||
                 labelControl114.EditValue.ToString().Length > 27 ||
                 labelControl113.EditValue.ToString().Length > 27 ||
                 labelControl15.EditValue.ToString().Length > 27 ||
                 labelControl16.EditValue.ToString().Length > 27

                 )
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    return;
                }
                if (jobID.Trim().Length > 0)
                {
                    JobDefaultValues systemValue = new JobDefaultValues(
                        jobID,
                        //txtChangeOrderStipulationsParagraph1.Text,
                        txtChangeOrderStipulationsParagraph1.Text,
                        txtChangeOrderStipulationsParagraph2.Text,
                        txtMajorPONote.Text,
                        txtSmallPONote.Text,
                        txtSundriesPercentOfMaterial.EditValue.ToString(),
                        txtSalesTaxPercent.EditValue.ToString(),
                        txtAsBuiltsEngineeringPercent.EditValue.ToString(),
                        txtStoragePercent.EditValue.ToString(),
                        txtSmallToolsPercent.EditValue.ToString(),
                        txtCartigeHandlingPercent.EditValue.ToString(),
                        txtForemanPercentOfLabor.EditValue.ToString(),
                        txtGeneralForemanPercentOfLabor.EditValue.ToString(),
                        txtSuperintendentPercentOfLabor.EditValue.ToString(),
                        txtProjectManagerPercentOfLabor.EditValue.ToString(),
                        txtProjectEngineerPercentOfLabor.EditValue.ToString(),
                        txtSafetyMeetingPercent.EditValue.ToString(),
                        txtFringeBenefitsPercent.EditValue.ToString(),
                        txtOverheadPercent.EditValue.ToString(),
                        txtProfitPercent.EditValue.ToString(),
                        txtSubcontractAdministrationPercent.EditValue.ToString(),
                        txtWarrantyPercent.EditValue.ToString(),
                        txtBondPercent.EditValue.ToString(),

                        txtBIMRate.EditValue.ToString(),
                        txtApprenticeLaborRate.EditValue.ToString(),
                        txtElectricianLaborRate.EditValue.ToString(),
                        txtForemanLaborRate.EditValue.ToString(),
                        txtGeneralForemanLaborRate.EditValue.ToString(),
                        txtSuperintendentLaborRate.EditValue.ToString(),
                        txtProjectManagerLaborRate.EditValue.ToString(),
                        txtProjectEngineerLaborRate.EditValue.ToString(),
                        txtSafetyMeetingsLaborRate.EditValue.ToString(),
                        txtPremiumTimeLaborRate.EditValue.ToString(),
                        cboRFIDefaultContact.EditValue.ToString(),
                        cboChangeOrderDefaultContact.EditValue.ToString(),
                        cboDefaultFrom.EditValue.ToString(),
                        cboForeman.EditValue.ToString(),

                        txtBIMRateOT.EditValue.ToString(),
                        txtApprenticeLaborRateOT.EditValue.ToString(),
                        txtElectricianLaborRateOT.EditValue.ToString(),
                        txtForemanLaborRateOT.EditValue.ToString(),
                        txtGeneralForemanLaborRateOT.EditValue.ToString(),
                        txtSuperintendentLaborRateOT.EditValue.ToString(),
                        txtProjectManagerLaborRateOT.EditValue.ToString(),
                        txtProjectEngineerLaborRateOT.EditValue.ToString(),
                        txtSafetyMeetingsLaborRateOT.EditValue.ToString(),
                        txtPremiumTimeLaborRateOT.EditValue.ToString(),

                        txtBIMRateDT.EditValue.ToString(),
                        txtApprenticeLaborRateDT.EditValue.ToString(),
                        txtElectricianLaborRateDT.EditValue.ToString(),
                        txtForemanLaborRateDT.EditValue.ToString(),
                        txtGeneralForemanLaborRateDT.EditValue.ToString(),
                        txtSuperintendentLaborRateDT.EditValue.ToString(),
                        txtProjectManagerLaborRateDT.EditValue.ToString(),
                        txtProjectEngineerLaborRateDT.EditValue.ToString(),
                        txtSafetyMeetingsLaborRateDT.EditValue.ToString(),
                        txtPremiumTimeLaborRateDT.EditValue.ToString(),
                        labelControl134.EditValue.ToString(),

                                    labelControl130.EditValue.ToString(),
                                    labelControl119.EditValue.ToString(),
                                    labelControl118.EditValue.ToString(),
                                    labelControl117.EditValue.ToString(),
                                    labelControl116.EditValue.ToString(),
                                    labelControl115.EditValue.ToString(),
                                    labelControl120.EditValue.ToString(),
                                    labelControl114.EditValue.ToString(),
                                    labelControl113.EditValue.ToString(),
                                    labelControl15.EditValue.ToString(),
                                    labelControl16.EditValue.ToString());

                    systemValue.Save();
                }
                else
                {

                    JobSystemDefaultValues systemValue = new JobSystemDefaultValues(
                       txtChangeOrderStipulationsParagraph1.Text,
                                    //txtChangeOrderStipulationsParagraph1.Text.ToStrin,
                                    txtChangeOrderStipulationsParagraph2.Text,
                                    txtMajorPONote.Text,
                                    txtSmallPONote.Text,
                                    txtSundriesPercentOfMaterial.EditValue.ToString(),
                                    txtSalesTaxPercent.EditValue.ToString(),
                                    txtAsBuiltsEngineeringPercent.EditValue.ToString(),
                                    txtStoragePercent.EditValue.ToString(),
                                    txtSmallToolsPercent.EditValue.ToString(),
                                    txtCartigeHandlingPercent.EditValue.ToString(),
                                    txtForemanPercentOfLabor.EditValue.ToString(),
                                    txtGeneralForemanPercentOfLabor.EditValue.ToString(),
                                    txtSuperintendentPercentOfLabor.EditValue.ToString(),
                                    txtProjectManagerPercentOfLabor.EditValue.ToString(),
                                    txtProjectEngineerPercentOfLabor.EditValue.ToString(),
                                    txtSafetyMeetingPercent.EditValue.ToString(),
                                    txtFringeBenefitsPercent.EditValue.ToString(),
                                    txtOverheadPercent.EditValue.ToString(),
                                    txtProfitPercent.EditValue.ToString(),
                                    txtSubcontractAdministrationPercent.EditValue.ToString(),
                                    txtWarrantyPercent.EditValue.ToString(),
                                    txtBondPercent.EditValue.ToString(),

                                    txtBIMRate.EditValue.ToString(),
                                    txtApprenticeLaborRate.EditValue.ToString(),
                                    txtElectricianLaborRate.EditValue.ToString(),
                                    txtForemanLaborRate.EditValue.ToString(),
                                    txtGeneralForemanLaborRate.EditValue.ToString(),
                                    txtSuperintendentLaborRate.EditValue.ToString(),
                                    txtProjectManagerLaborRate.EditValue.ToString(),
                                    txtProjectEngineerLaborRate.EditValue.ToString(),
                                    txtSafetyMeetingsLaborRate.EditValue.ToString(),
                                    txtPremiumTimeLaborRate.EditValue.ToString(),

                                    txtBIMRateOT.EditValue.ToString(),
                                    txtApprenticeLaborRateOT.EditValue.ToString(),
                                    txtElectricianLaborRateOT.EditValue.ToString(),
                                    txtForemanLaborRateOT.EditValue.ToString(),
                                    txtGeneralForemanLaborRateOT.EditValue.ToString(),
                                    txtSuperintendentLaborRateOT.EditValue.ToString(),
                                    txtProjectManagerLaborRateOT.EditValue.ToString(),
                                    txtProjectEngineerLaborRateOT.EditValue.ToString(),
                                    txtSafetyMeetingsLaborRateOT.EditValue.ToString(),
                                    txtPremiumTimeLaborRateOT.EditValue.ToString(),

                                    txtBIMRateDT.EditValue.ToString(),
                                    txtApprenticeLaborRateDT.EditValue.ToString(),
                                    txtElectricianLaborRateDT.EditValue.ToString(),
                                    txtForemanLaborRateDT.EditValue.ToString(),
                                    txtGeneralForemanLaborRateDT.EditValue.ToString(),
                                    txtSuperintendentLaborRateDT.EditValue.ToString(),
                                    txtProjectManagerLaborRateDT.EditValue.ToString(),
                                    txtProjectEngineerLaborRateDT.EditValue.ToString(),
                                    txtSafetyMeetingsLaborRateDT.EditValue.ToString(),
                                    txtPremiumTimeLaborRateDT.EditValue.ToString(),

                                    labelControl134.EditValue.ToString(),
                                    labelControl130.EditValue.ToString(),
                                    labelControl119.EditValue.ToString(),
                                    labelControl118.EditValue.ToString(),
                                    labelControl117.EditValue.ToString(),
                                    labelControl116.EditValue.ToString(),
                                    labelControl115.EditValue.ToString(),
                                    labelControl120.EditValue.ToString(),
                                    labelControl114.EditValue.ToString(),
                                    labelControl113.EditValue.ToString(),
                                    labelControl15.EditValue.ToString(),
                                    labelControl16.EditValue.ToString());

                    systemValue.Save();
                }
                SaveSubmittal();
                changesStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
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
                //string myString = myControl.Text.Trim().ToUpper();

                //  if (myString != myControl.Text.Trim())
                //      myControl.Text = myControl.Text.ToString().ToUpper();
            }
            UpdateDataChange();
        }
        //
        private void frmJobSystemDefaultValues_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }

        //
        private void UpdateErrorMessages()
        {
            errorMessages = false;
        }
        //
        private void cboRFIDefaultContact_EditValueChanged(object sender, EventArgs e)
        {
            if (cboRFIDefaultContact.EditValue == null || cboRFIDefaultContact.EditValue.ToString().Trim() == "")
            {
                txtRFIDefaultContactCompany.Text = "";
            }
            else
            {
                int i = 0;
                contact.DefaultView.Sort = "ContactID";
                i = contact.DefaultView.Find(cboRFIDefaultContact.EditValue.ToString());
                if (i != -1)
                    txtRFIDefaultContactCompany.Text = contact.DefaultView[i][2].ToString();
                else
                    txtRFIDefaultContactCompany.Text = "";

            }

            AllControls_EditValue(sender, e);
        }

        private void cboChangeOrderDefaultContact_EditValueChanged(object sender, EventArgs e)
        {
            if (cboChangeOrderDefaultContact.EditValue == null || cboChangeOrderDefaultContact.EditValue.ToString().Trim() == "")
            {
                txtChangeOrderDefaultContactCompany.Text = "";
            }
            else
            {
                int i = 0;
                contact.DefaultView.Sort = "ContactID";
                i = contact.DefaultView.Find(cboChangeOrderDefaultContact.EditValue.ToString());
                if (i != -1)
                    txtChangeOrderDefaultContactCompany.Text = contact.DefaultView[i][2].ToString();
                else
                    txtChangeOrderDefaultContactCompany.Text = "";

            }

            AllControls_EditValue(sender, e);

        }
        //
        private void gridSubmittal_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }
        //
        private void GetSubmittalSpec()
        {
            try
            {
                if (jobID.Trim().Length > 0)
                {
                    submittalSpec = JobSubmittalSpec.GetJobSubmittalSpec(jobID).Tables[0];
                    this.grdSubmittal.DataSource = submittalSpec.DefaultView;
                    gridSubmittal.Columns["JobSubmittalSpecID"].Visible = false;
                    gridSubmittal.Columns["JobSubmittalSpecSection"].Caption = "Section";
                    gridSubmittal.Columns["JobSubmittalSpecDescription"].Caption = "Description";
                    gridSubmittal.Columns["JobSubmittalSpecDescription"].ColumnEdit = repDescription;
                    gridSubmittal.Columns["JobSubmittalSpecSection"].ColumnEdit = repSection;
                    gridSubmittal.Columns["JobSubmittalSpecDescription"].Width = 400;
                    gridSubmittal.Columns["JobSubmittalSpecSection"].Width = 100;
                }
                else
                {
                    submittalSpec = JobSubmittalSystemSpec.GetJobSubmittalSystemSpec().Tables[0];
                    this.grdSubmittal.DataSource = submittalSpec.DefaultView;
                    gridSubmittal.Columns["JobSubmittalSystemSpecID"].Visible = false;
                    gridSubmittal.Columns["JobSubmittalSystemSpecSection"].Caption = "Section";
                    gridSubmittal.Columns["JobSubmittalSystemSpecDescription"].Caption = "Description";
                    gridSubmittal.Columns["JobSubmittalSystemSpecDescription"].ColumnEdit = repDescription;
                    gridSubmittal.Columns["JobSubmittalSystemSpecSection"].ColumnEdit = repSection;
                    gridSubmittal.Columns["JobSubmittalSystemSpecDescription"].Width = 400;
                    gridSubmittal.Columns["JobSubmittalSystemSpecSection"].Width = 50;
                }
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    gridSubmittal.OptionsBehavior.Editable = true;
                    gridSubmittal.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                }
                else
                {
                    Paragraph1.Enabled = false;
                    Paragraph2.Enabled = false;
                    MajorPONote.Enabled = false;
                    SmallPONote.Enabled = false;
                    gridSubmittal.OptionsBehavior.Editable = false;
                    gridSubmittal.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void SaveSubmittal()
        {
            if (jobID.Trim().Length > 0)
            {
                try
                {
                    this.Cursor = Cursors.AppStarting;
                    JobSubmittalSpec spec;
                    if (submittalSpec != null)
                    {
                        foreach (DataRow r in submittalSpec.Rows)
                        {
                            // Update Record
                            switch (r.RowState)
                            {
                                case DataRowState.Added:
                                case DataRowState.Modified:
                                    spec = new JobSubmittalSpec(
                                                        r["JobSubmittalSpecID"].ToString(),
                                                        jobID,
                                                        r["JobSubmittalSpecSection"].ToString(),
                                                        r["JobSubmittalSpecDescription"].ToString());
                                    spec.Save();
                                    r["JobSubmittalSpecID"] = spec.JobSubmittalSpecID;

                                    break;
                                case DataRowState.Deleted:
                                    JobSubmittalSpec.Delete(r["JobSubmittalSpecID"].ToString());
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
            else
            {
                try
                {
                    this.Cursor = Cursors.AppStarting;
                    JobSubmittalSystemSpec spec;
                    if (submittalSpec != null)
                    {
                        foreach (DataRow r in submittalSpec.Rows)
                        {
                            // Update Record
                            switch (r.RowState)
                            {
                                case DataRowState.Added:
                                case DataRowState.Modified:
                                    spec = new JobSubmittalSystemSpec(
                                                        r["JobSubmittalSystemSpecID"].ToString(),
                                                        r["JobSubmittalSystemSpecSection"].ToString(),
                                                        r["JobSubmittalSystemSpecDescription"].ToString());
                                    spec.Save();
                                    r["JobSubmittalSystemSpecID"] = spec.JobSubmittalSystemSpecID;

                                    break;
                                case DataRowState.Deleted:
                                    JobSubmittalSystemSpec.Delete(r["JobSubmittalSystemSpecID"].ToString());
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

        }

        private void cboChangeOrderDefaultContact_EditValueChanged_1(object sender, EventArgs e)
        {
            if (cboChangeOrderDefaultContact.EditValue == null || cboChangeOrderDefaultContact.EditValue.ToString().Trim() == "")
            {
                txtChangeOrderDefaultContactCompany.Text = "";
            }
            else
            {
                int i = 0;
                contact.DefaultView.Sort = "ContactID";
                i = contact.DefaultView.Find(cboChangeOrderDefaultContact.EditValue.ToString());
                if (i != -1)
                    txtChangeOrderDefaultContactCompany.Text = contact.DefaultView[i][2].ToString();
                else
                    txtChangeOrderDefaultContactCompany.Text = "";

            }

            AllControls_EditValue(sender, e);
        }

        private void txtChangeOrderStipulationsParagraph1_OnTextChanged(object source, EventArgs e)
        {
            UpdateDataChange();
        }

        private void txtChangeOrderStipulationsParagraph2_OnTextChanged(object source, EventArgs e)
        {
            UpdateDataChange();
        }

        private void txtMajorPONote_OnTextChanged(object source, EventArgs e)
        {
            UpdateDataChange();
        }

        private void txtSmallPONote_OnTextChanged(object source, EventArgs e)
        {
            UpdateDataChange();
        }

        private void Paragraph1_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtChangeOrderStipulationsParagraph1.Text;
            f.ShowDialog();
            txtChangeOrderStipulationsParagraph1.Text = f.MyText;
            UpdateDataChange();
        }

        private void Paragraph2_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtChangeOrderStipulationsParagraph2.Text;
            f.ShowDialog();
            txtChangeOrderStipulationsParagraph2.Text = f.MyText;
            UpdateDataChange();
        }

        private void UpdateDataChange()
        {
            if (!dataChanged)
            {
                dataChanged = true;
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void SmallPONote_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtSmallPONote.Text;
            f.ShowDialog();
            txtSmallPONote.Text = f.MyText;
            UpdateDataChange();

        }

        private void MajorPONote_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtMajorPONote.Text;
            f.ShowDialog();
            txtMajorPONote.Text = f.MyText;
            UpdateDataChange();
        }

        string BIMRate = string.Empty;
        string strlabelControl119 = string.Empty;
        string strlabelControl118 = string.Empty;
        string strlabelControl117 = string.Empty;
        string strlabelControl116 = string.Empty;
        string strlabelControl115 = string.Empty;
        string strlabelControl120 = string.Empty;
        string strlabelControl114 = string.Empty;
        string strlabelControl113 = string.Empty;
        string strlabelControl130 = string.Empty;
        string strlabelControl16 = string.Empty;
        string strlabelControl15 = string.Empty;

        private void labelControl16_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl16.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl16.Text = strlabelControl16;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl16_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl16 = labelControl16.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl16.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl15_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl15.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl15.Text = strlabelControl15;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl15_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl15 = labelControl15.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl15.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl134_KeyPress(object sender, KeyPressEventArgs e)
        {
            BIMRate = labelControl134.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl134.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl134_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl134.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl134.Text = BIMRate;
                    e.Handled = true;
                    return;
                }
            }
        }


        private void labelControl119_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl119 = labelControl119.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl119.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl119_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl119.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl119.Text = strlabelControl119;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl118_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl118 = labelControl118.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl118.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl118_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl118.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl118.Text = strlabelControl118;
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl117_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl117 = labelControl117.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl117.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl117_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl117.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl117.Text = strlabelControl117;
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl116_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl116 = labelControl116.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl116.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl116_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl116.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl116.Text = strlabelControl116;
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl115_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl115 = labelControl115.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl115.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl115_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl115.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl115.Text = strlabelControl115;
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl120_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl120 = labelControl120.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl120.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl120_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl120.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl120.Text = strlabelControl120;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl114_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl114 = labelControl114.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl114.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl114_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl114.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl114.Text = strlabelControl114;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl113_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl113 = labelControl113.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl113.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl113_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl113.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl113.Text = strlabelControl113;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl130_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl130 = labelControl130.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl130.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl130_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl130.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl130.Text = strlabelControl130;
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}