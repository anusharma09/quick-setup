using DevExpress.XtraGrid.Views.Base;
using JCCBusinessLayer;
using JCCReports;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace CCEJobs.PresentationLayer
{
    public partial class frmChangeOrder : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected bool bColumnWidthChanged = false;
        protected string recordID;
        protected string jobID;
        protected BindingSource bindingSource;
        protected bool dataChanged;
        private bool errorMessages = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        protected int defaultRFIContactID;
        protected int defaultFromID;
        private bool changesStatus = false;
        private DataSet jobCodeDataSet;
        private bool isUpdated = false;
        private bool isRev = false;
        private string revision = "";
        private DataTable contact;
        //
        private float sundriesCost = 0;
        private float salesTaxCost = 0;
        private float BIMCost = 0;
        private float apprenticeCost = 0;
        private float electricianCost = 0;
        private float foremanCost = 0;
        private float generalForemanCost = 0;
        private float superintendentCost = 0;
        private float premiumCost = 0;
        private float fringeBenefitsCost = 0;
        private float safetyMeetingsCost = 0;
        private float projectManagerCost = 0;
        private float projectEngineerCost = 0;
        private float totalLaborCost = 0;
        private float asBuiltsEngineeringCost = 0;
        private float storageCost = 0;
        private float smallToolsCost = 0;
        private float cartigeHandlingCost = 0;
        private float totalExpensesCost = 0;
        private float materialsLaborExpensesCost = 0;
        private float overheadCost = 0;
        private float materialsLaborExpensesOverheadCost = 0;
        private float profitCost = 0;
        private float overheadProfitCost = 0;
        private float subcontractAdministrationCost = 0;
        private float overheadProfitSubcontractsAmountSubcontractAdministrationCost = 0;
        private float warrantyCost = 0;
        private float bondCost = 0;
        private int defaultChangeOrderContactID = 0;
        private bool bCopy = false;
        private bool changeOrderStatus = false;
        private bool isFormClosed = true;

        private enum ClickedButton
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
        public frmChangeOrder()
        {
            InitializeComponent();
        }
        //
        public frmChangeOrder(string recordID, string jobID, BindingSource bindingSource, bool changeOrderStatus)
        {
            this.recordID = recordID;
            this.jobID = jobID;
            this.bindingSource = bindingSource;
            this.changeOrderStatus = changeOrderStatus;
            InitializeComponent();
        }
        //
        private void frmChangeOrder_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.AppStarting;

                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    btnRev.Enabled = false;
                    btnCopy.Enabled = false;
                }

                txtRecordID.DataBindings.Add("text", bindingSource, "JobChangeOrderID");
                //
                contact = Contact.GetJobContactForPullDown(jobID).Tables[0];
                cboContact.Properties.DataSource = contact;
                cboContact.Properties.DisplayMember = "Name";
                cboContact.Properties.ValueMember = "ContactID";
                cboContact.Properties.PopulateColumns();
                defaultChangeOrderContactID = JobDefaultValues.GetJobDefaultChangeOrderContact(jobID);

                //cboContact.Properties.ShowHeader = false;
                //cboContact.Properties.Columns[0].Visible = false;
                cboJobChangeOrderDescription.Properties.Items.AddRange(RepositoryItems.changeOrderDescription.Items);
                //Get whether changeOrder is newly created or historic
                if (recordID != "0")
                {
                    changeOrderStatus = JobChangeOrderContract.ChangeOrderStatus(recordID);
                }
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetChangeOrder(false);
                }
                else
                {
                    GetChangeOrder(false);
                    ribbonReport.Visible = true;
                }
                GetPhaseList();
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    btnRev.Enabled = false;
                    btnCopy.Enabled = false;
                }
                else
                {
                    GetOriginalPhaseList();
                }

                Opacity = 1;
                Cursor = Cursors.Default;


            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetChangeOrderDetail(string recordID)
        {
            changesStatus = false;
            if (isUpdated)
            {
                SaveJobCostCodes();
                isUpdated = false;
            }

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateChangeOrder(recordID);
                ProtectForm();
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                {
                    if (!changeOrderStatus)
                    {
                        btnRev.Enabled = false;
                        btnCopy.Enabled = false;
                    }
                    else
                    {
                        btnRev.Enabled = true;
                        btnCopy.Enabled = true;
                    }
                }
                else
                {
                    btnRev.Enabled = true;
                    btnCopy.Enabled = true;
                }
                Focus();
            }
            else
            {
                txtJobChangeOrderNumber.Text = "";
                txtJobChangeOrderRequestDate.Text = "";
                txtJobChangeOrderRequestedAmount.Text = "";
                txtJobChangeOrderApprovedDate.Text = "";
                txtJobChangeOrderApprovedAmount.Text = "";
                cboJobChangeOrderStatus.Text = "";
                cboJobChangeOrderDescription.Text = "";
                txtJobChangeOrderOwnerNumber.Text = "";
                txtJobChangeOrderCCENumber.Text = "";
                txtJobChangeOrderUserDescription.Text = "";
                txtChangeOrderAmount.Text = "";
                txtPriceAdjustment.Text = "";
                txtDirectMaterials.Text = "";
                txtEstimatedBIMHours.Text = "";
                txtEstimatedApprenticeHours.Text = "";
                txtEstimatedElectricianHours.Text = "";
                txtForemanDefaultHours.Text = "";
                txtGeneralForemanDefaultHours.Text = "";
                txtSuperintendentDefaultHours.Text = "";
                txtProjectManagerDefaultHours.Text = "";
                txtProjectEngineerDefaultHours.Text = "";
                txtForemanActualHours.Text = "";
                txtGeneralForemanActualHours.Text = "";
                txtSuperintendentActualHours.Text = "";
                txtProjectManagerActualHours.Text = "";
                txtProjectEngineerActualHours.Text = "";
                txtPremiumHoursActualHours.Text = "";
                txtOtherExpenses1.Text = "";
                txtOtherExpenses2.Text = "";
                txtOtherExpenses3.Text = "";
                txtOtherExpenses1Description.Text = "";
                txtOtherExpenses2Description.Text = "";
                txtOtherExpenses3Description.Text = "";
                txtSubcontractsAmount.Text = "";
                txtLaborHoursEstimateDefaults.Text = "";
                txtLaborDollarEstimateDefaults.Text = "";
                txtLaborRateEstimateDefaults.Text = "";
                txtMaterialsEstimateDefaults.Text = "";
                txtOtherEstimateDefaults.Text = "";
                txtSubcontractsEstimateDefaults.Text = "";
                txtTotalCostEstimateDefaults.Text = "";
                txtContractDollarEstimateDefaults.Text = "";
                txtProfitDollarEstimateDefaults.Text = "";
                txtProfitPercentEstimateDefaults.Text = "";
                txtLaborHoursBudgetTotals.Text = "";
                txtLaborDollarBudgetTotals.Text = "";
                txtLaborRateBudgetTotals.Text = "";
                txtMaterialsBudgetTotals.Text = "";
                txtOtherBudgetTotals.Text = "";
                txtSubcontractsBudgetTotals.Text = "";
                txtTotalCostBudgetTotals.Text = "";
                txtContractDollarBudgetTotals.Text = "";
                txtProfitDollarBudgetTotals.Text = "";
                txtProfitPercentBudgetTotals.Text = "";
                txtSundriesPercentOfMaterial.Text = "";
                txtSalesTaxPercent.Text = "";
                txtAsBuiltsEngineeringPercent.Text = "";
                txtStoragePercent.Text = "";
                txtSmallToolsPercent.Text = "";
                txtCartigeHandlingPercent.Text = "";
                txtForemanPercentOfLabor.Text = "";
                txtGeneralForemanPercentOfLabor.Text = "";
                txtSuperintendentPercentOfLabor.Text = "";
                txtProjectManagerPercentOfLabor.Text = "";
                txtProjectEngineerPercentOfLabor.Text = "";
                txtSafetyMeetingPercent.Text = "";
                txtFringeBenefitsPercent.Text = "";
                txtOverheadPercent.Text = "";
                txtProfitPercent.Text = "";
                txtSubcontractAdministrationPercent.Text = "";
                txtWarrantyPercent.Text = "";
                txtBondPercent.Text = "";

                txtBIMRate.Text = "";
                txtApprenticeLaborRate.Text = "";
                txtElectricianLaborRate.Text = "";
                txtForemanLaborRate.Text = "";
                txtGeneralForemanLaborRate.Text = "";
                txtSuperintendentLaborRate.Text = "";
                txtProjectManagerLaborRate.Text = "";
                txtProjectEngineerLaborRate.Text = "";
                txtSafetyMeetingsLaborRate.Text = "";
                txtPremiumTimeLaborRate.Text = "";

                txtBIMRateOT.Text = "";
                txtApprenticeLaborRateOT.Text = "";
                txtElectricianLaborRateOT.Text = "";
                txtForemanLaborRateOT.Text = "";
                txtGeneralForemanLaborRateOT.Text = "";
                txtSuperintendentLaborRateOT.Text = "";
                txtProjectManagerLaborRateOT.Text = "";
                txtProjectEngineerLaborRateOT.Text = "";
                txtSafetyMeetingsLaborRateOT.Text = "";
                txtPremiumTimeLaborRateOT.Text = "";

                txtBIMRateDT.Text = "";
                txtApprenticeLaborRateDT.Text = "";
                txtElectricianLaborRateDT.Text = "";
                txtForemanLaborRateDT.Text = "";
                txtGeneralForemanLaborRateDT.Text = "";
                txtSuperintendentLaborRateDT.Text = "";
                txtProjectManagerLaborRateDT.Text = "";
                txtProjectEngineerLaborRateDT.Text = "";
                txtSafetyMeetingsLaborRateDT.Text = "";
                txtPremiumTimeLaborRateDT.Text = "";

                txtEstimatedBIMHoursOT.Text = "";
                txtEstimatedApprenticeHoursOT.Text = "";
                txtEstimatedElectricianHoursOT.Text = "";
                txtEstimatedBIMHoursDT.Text = "";
                txtEstimatedApprenticeHoursDT.Text = "";
                txtEstimatedElectricianHoursDT.Text = "";

                txtForemanDefaultHoursOT.Text = "";
                txtGeneralForemanDefaultHoursOT.Text = "";
                txtSuperintendentDefaultHoursOT.Text = "";
                txtProjectManagerDefaultHoursOT.Text = "";
                txtProjectEngineerDefaultHoursOT.Text = "";
                txtForemanDefaultHoursDT.Text = "";
                txtGeneralForemanDefaultHoursDT.Text = "";
                txtSuperintendentDefaultHoursDT.Text = "";
                txtProjectManagerDefaultHoursDT.Text = "";
                txtProjectEngineerDefaultHoursDT.Text = "";
                txtForemanActualHoursOT.Text = "";
                txtGeneralForemanActualHoursOT.Text = "";
                txtSuperintendentActualHoursOT.Text = "";
                txtProjectManagerActualHoursOT.Text = "";
                txtProjectEngineerActualHoursOT.Text = "";
                txtPremiumHoursActualHoursOT.Text = "";
                txtForemanActualHoursDT.Text = "".Trim();
                txtGeneralForemanActualHoursDT.Text = "";
                txtSuperintendentActualHoursDT.Text = "";
                txtProjectManagerActualHoursDT.Text = "";
                txtProjectEngineerActualHoursDT.Text = "";
                txtPremiumHoursActualHoursDT.Text = "";






                txtLetterWorkDescription.Text = "";
                txtLetterExclusion.Text = "";
                txtLetterTimeExtension.Text = "";
                cboContact.EditValue = null;
                txtFrom.Text = "";
                sundriesCost = 0;
                salesTaxCost = 0;
                BIMCost = 0;
                apprenticeCost = 0;
                electricianCost = 0;
                foremanCost = 0;
                generalForemanCost = 0;
                superintendentCost = 0;
                premiumCost = 0;
                fringeBenefitsCost = 0;
                safetyMeetingsCost = 0;
                projectManagerCost = 0;
                projectEngineerCost = 0;
                totalLaborCost = 0;
                asBuiltsEngineeringCost = 0;
                storageCost = 0;
                smallToolsCost = 0;
                cartigeHandlingCost = 0;
                totalExpensesCost = 0;
                materialsLaborExpensesCost = 0;
                overheadCost = 0;
                materialsLaborExpensesOverheadCost = 0;
                profitCost = 0;
                overheadProfitCost = 0;
                subcontractAdministrationCost = 0;
                overheadProfitSubcontractsAmountSubcontractAdministrationCost = 0;
                warrantyCost = 0;
                bondCost = 0;
                try
                {
                    DataTable t = JobTransmittal.GetJobDefaultFrom(jobID).Tables[0];
                    if (t.Rows.Count > 0)
                    {
                        txtFrom.Text = t.Rows[0][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
                if (defaultChangeOrderContactID > 0)
                {
                    cboContact.EditValue = defaultChangeOrderContactID;
                }

                GetJobDefaultValues();
                UnProtectForm();
            }
            GetJobCostCodes(recordID, jobID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            btnSaveCostCodes.Visible = false;

        }
        //
        private void ProtectForm()
        {
            if (txtJobChangeOrderNumber.Text.Trim() == "0")
            {
                cboJobChangeOrderDescription.Properties.ReadOnly = true;
            }
            else
            {
                cboJobChangeOrderDescription.Properties.ReadOnly = false;
            }
        }
        //
        private void UnProtectForm()
        {
            cboJobChangeOrderDescription.Properties.ReadOnly = false;
        }
        //
        private void GetJobDefaultValues()
        {
            try
            {
                DataSet j = JobSystemDefaultValues.GetJobSystemDefaultValues();
                DataRow r1;

                DataRow r;

                if (JobDefaultValues.GetJobDefaultValues(jobID).Tables[0].Rows.Count > 0)
                {
                    r = JobDefaultValues.GetJobDefaultValues(jobID).Tables[0].Rows[0];
                    r1 = j.Tables[0].Rows[0];
                    txtSundriesPercentOfMaterial.EditValue = r["SundriesPercentOfMaterial"];
                    txtSalesTaxPercent.EditValue = r["SalesTaxPercent"];
                    txtAsBuiltsEngineeringPercent.EditValue = r["AsBuiltsEngineeringPercent"];
                    txtStoragePercent.EditValue = r["StoragePercent"];
                    txtSmallToolsPercent.EditValue = r["SmallToolsPercent"];
                    txtCartigeHandlingPercent.EditValue = r["CartigeHandlingPercent"];
                    txtForemanPercentOfLabor.EditValue = r["ForemanPercentOfLabor"];
                    txtGeneralForemanPercentOfLabor.EditValue = r["GeneralForemanPercentOfLabor"];
                    txtSuperintendentPercentOfLabor.EditValue = r["SuperintendentPercentOfLabor"];
                    txtProjectManagerPercentOfLabor.EditValue = r["ProjectManagerPercentOfLabor"];
                    txtProjectEngineerPercentOfLabor.EditValue = r["ProjectEngineerPercentOfLabor"];
                    txtSafetyMeetingPercent.EditValue = r["SafetyMeetingPercent"];
                    txtFringeBenefitsPercent.EditValue = r["FringeBenefitsPercent"];
                    txtOverheadPercent.EditValue = r["OverheadPercent"];
                    txtProfitPercent.EditValue = r["ProfitPercent"];
                    txtSubcontractAdministrationPercent.EditValue = r["SubcontractAdministrationPercent"];
                    txtWarrantyPercent.EditValue = r["WarrantyPercent"];
                    txtBondPercent.EditValue = r["BondPercent"];

                    txtBIMRate.EditValue = r["BIMRate"];
                    txtApprenticeLaborRate.EditValue = r["ApprenticeLaborRate"];
                    txtElectricianLaborRate.EditValue = r["ElectricianLaborRate"];
                    txtForemanLaborRate.EditValue = r["ForemanLaborRate"];
                    txtGeneralForemanLaborRate.EditValue = r["GeneralForemanLaborRate"];
                    txtSuperintendentLaborRate.EditValue = r["SuperintendentLaborRate"];
                    txtProjectManagerLaborRate.EditValue = r["ProjectManagerLaborRate"];
                    txtProjectEngineerLaborRate.EditValue = r["ProjectEngineerLaborRate"];
                    txtSafetyMeetingsLaborRate.EditValue = r["SafetyMeetingsLaborRate"];
                    txtPremiumTimeLaborRate.EditValue = r["PremiumTimeLaborRate"];

                    txtBIMRateOT.EditValue = r["BIMRateOT"];
                    txtApprenticeLaborRateOT.EditValue = r["ApprenticeLaborRateOT"];
                    txtElectricianLaborRateOT.EditValue = r["ElectricianLaborRateOT"];
                    txtForemanLaborRateOT.EditValue = r["ForemanLaborRateOT"];
                    txtGeneralForemanLaborRateOT.EditValue = r["GeneralForemanLaborRateOT"];
                    txtSuperintendentLaborRateOT.EditValue = r["SuperintendentLaborRateOT"];
                    txtProjectManagerLaborRateOT.EditValue = r["ProjectManagerLaborRateOT"];
                    txtProjectEngineerLaborRateOT.EditValue = r["ProjectEngineerLaborRateOT"];
                    txtSafetyMeetingsLaborRateOT.EditValue = r["SafetyMeetingsLaborRateOT"];
                    txtPremiumTimeLaborRateOT.EditValue = r["PremiumTimeLaborRateOT"];

                    txtBIMRateDT.EditValue = r["BIMRateDT"];
                    txtApprenticeLaborRateDT.EditValue = r["ApprenticeLaborRateDT"];
                    txtElectricianLaborRateDT.EditValue = r["ElectricianLaborRateDT"];
                    txtForemanLaborRateDT.EditValue = r["ForemanLaborRateDT"];
                    txtGeneralForemanLaborRateDT.EditValue = r["GeneralForemanLaborRateDT"];
                    txtSuperintendentLaborRateDT.EditValue = r["SuperintendentLaborRateDT"];
                    txtProjectManagerLaborRateDT.EditValue = r["ProjectManagerLaborRateDT"];
                    txtProjectEngineerLaborRateDT.EditValue = r["ProjectEngineerLaborRateDT"];
                    txtSafetyMeetingsLaborRateDT.EditValue = r["SafetyMeetingsLaborRateDT"];
                    txtPremiumTimeLaborRateDT.EditValue = r["PremiumTimeLaborRateDT"];

                    
                    if (r["BIMRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl167.Text = string.Empty; }
                    else
                    { labelControl167.Text = Convert.ToString(r["BIMRate_Label"]).Trim(); }

                    if (r["ApprenticeLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl152.Text = string.Empty; }
                    else
                    { labelControl152.Text = Convert.ToString(r["ApprenticeLaborRate_Label"]).Trim(); }
                                      
                    
                    if (r["ElectricianLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl119.Text = string.Empty; }
                    else
                    { labelControl119.Text = Convert.ToString(r["ElectricianLaborRate_Label"]).Trim(); }

                    
                    if (r["ForemanLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl118.Text = string.Empty; }
                    else
                    { labelControl118.Text = Convert.ToString(r["ForemanLaborRate_Label"]).Trim(); }

                  
                    if (r["GeneralForemanLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl117.Text = string.Empty; }
                    else
                    { labelControl117.Text = Convert.ToString(r["GeneralForemanLaborRate_Label"]).Trim(); }
                    
                    if (r["SuperintendentLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl116.Text = string.Empty; }
                    else
                    { labelControl116.Text = Convert.ToString(r["SuperintendentLaborRate_Label"]).Trim(); }

                    
                    if (r["ProjectManagerLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl115.Text = string.Empty; }
                    else
                    { labelControl115.Text = Convert.ToString(r["ProjectManagerLaborRate_Label"]).Trim(); }

                   
                    if (r["ProjectEngineerLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl120.Text = string.Empty; }
                    else
                    { labelControl120.Text = Convert.ToString(r["ProjectEngineerLaborRate_Label"]).Trim(); }

                    if (r["SafetyMeetingsLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl114.Text = string.Empty; }
                    else
                    {
                        labelControl114.Text = Convert.ToString(r["SafetyMeetingsLaborRate_Label"]).Trim();
                    }

                    if (r["PremiumTimeLaborRate_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl113.Text = string.Empty; }
                    else
                    {
                        labelControl113.Text = Convert.ToString(r["PremiumTimeLaborRate_Label"]).Trim();
                    }

                    if (r["FringeBenefitsPercent_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl15.Text = string.Empty; }
                    else
                    {
                        labelControl15.Text = Convert.ToString(r["FringeBenefitsPercent_Label"]).Trim();
                    }

                    if (r["SafetyMeetingPercent_Label"].ToString().Trim() == "Null".ToString())
                    { labelControl16.Text = string.Empty; }
                    else
                    {
                        labelControl16.Text = Convert.ToString(r["SafetyMeetingPercent_Label"]).Trim();
                    }                   
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void SaveChangeOrderCostCodesFromRev(string revision)
        {
            try
            {
                JobCost jobCost;
                foreach (DataRow r in jobCodeDataSet.Tables[0].Rows)
                {
                    if (r["Selected"].ToString() == "True")
                    {
                        jobCost = new JobCost(r["JobCostCodeID"].ToString(),
                                                                recordID,
                                                                txtJobChangeOrderNumber.Text.Trim(),
                                                                r["JobCostCodePhaseID"].ToString(),
                                                                r["User Description"].ToString(),
                                                                r["Unit"].ToString().Trim(),
                                                                r["Quantity"].ToString(),
                                                                r["Hours"].ToString(),
                                                                r["Cost $"].ToString(),
                                                                jobID,
                                                                r["Type"].ToString(),
                                                                r["Phase"].ToString(),
                                                                r["Code"].ToString(),
                                                                r["Title"].ToString(),
                                                                r["Description"].ToString());
                        jobCost.SaveCostCodeAfterRevision();
                        if (changeOrderStatus)
                        {
                            jobCost.SaveRevisionCostCode(revision);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                throw;
            }
        }
        //
        bool isUndo = false;
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridView1, "frmChangeOrder");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            cboRevision.Enabled = true;
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "Next Change Order":
                    if (isUpdated)
                    {
                        SaveJobCostCodes();
                    }

                    if (CheckChangeOrderStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetChangeOrder(false);
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                        {
                            btnRev.Enabled = false;
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnRev.Enabled = true;
                            btnCopy.Enabled = true;
                        }
                    }
                    break;
                case "Previous Change Order":
                    if (isUpdated)
                    {
                        SaveJobCostCodes();
                    }

                    if (CheckChangeOrderStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetChangeOrder(false);
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                        {
                            btnRev.Enabled = false;
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnRev.Enabled = true;
                            btnCopy.Enabled = true;
                        }
                    }
                    break;
                case "&New":
                    if (isUpdated)
                    {
                        SaveJobCostCodes();
                    }

                    if (CheckChangeOrderStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetChangeOrder(false);
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnRev.Enabled = false;
                        btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        cboRevision.Enabled = false;
                    }
                    break;
                case "&Save":
                    CheckChangeOrderStatus(ClickedButton.Save);
                    if (isUpdated)
                    {
                        SaveJobCostCodes();
                        CheckChangeOrderStatus(ClickedButton.Save);
                        isUpdated = false;
                    }

                    ribbonReport.Visible = true;
                    dataChanged = false;

                    break;
                case "&Undo":
                    isUndo = true;
                    revision = cboRevision.Text.Trim();

                    GetChangeOrder(false);
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                    {
                        btnRev.Enabled = false;
                        btnCopy.Enabled = false;
                    }
                    else
                    {
                        btnRev.Enabled = true;
                        btnCopy.Enabled = true;
                    }
                    isUndo = false;
                    break;
                case "&Rev":
                    try
                    {
                        btnRev.Enabled = false;
                        btnCopy.Enabled = false;
                        if (MessageBox.Show("You are about to create a Revision for the current change order. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                string rev = "";
                                revision = cboRevision.Text.Trim();
                                if (!changeOrderStatus)
                                {
                                    rev = JobChangeOrderContract.CreateChangeOrderRevision(recordID);
                                }
                                else
                                {
                                    rev = JobChangeOrderContract.CreateChangeOrderFromRevision(recordID, revision);
                                    JobChangeOrderContract.UpdateChangeOrderFromRevision(recordID, rev);
                                    SaveChangeOrderCostCodesFromRev(rev);
                                }
                                MessageBox.Show("Revision No: " + rev + " " + "was created for the current change Order", CCEApplication.ApplicationName);
                                GetChangeOrderRevision(recordID);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    finally
                    {
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                        {
                            btnRev.Enabled = false;
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnRev.Enabled = true;
                            btnCopy.Enabled = true;
                        }
                    }
                    break;


                case "&Copy":
                    try
                    {
                        btnRev.Enabled = false;
                        btnCopy.Enabled = false;
                        if (MessageBox.Show("You are about to create a new change order from the current change order. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                string msg = "Please make sure to:\n" +
                                            " 1. Save the change order to generate the new Change Order Number \n" +
                                            " 2. Make the adjustment ot the Cost Codes and save \n" +
                                            " 3. Save the Change Order to finalize \n";

                                MessageBox.Show(msg, CCEApplication.ApplicationName);
                                recordID = "0";
                                txtRecordID.Text = "0";
                                txtJobChangeOrderNumber.Text = "";
                                ribbonReport.Visible = false;
                                dataChanged = true;
                                btnUndo.Enabled = true;
                                btnSave.Enabled = true;
                                btnRev.Enabled = false;
                                btnCopy.Enabled = false;
                                isUpdated = true;

                                foreach (DataRow r in jobCodeDataSet.Tables[0].Rows)
                                {

                                    r["JobCostCodeID"] = DBNull.Value;
                                    //

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    //finally
                    //{
                    //    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                    //    {
                    //        btnRev.Enabled = false;
                    //        btnCopy.Enabled = false;
                    //    }
                    //    else
                    //    {
                    //        btnRev.Enabled = true;
                    //        btnCopy.Enabled = true;
                    //    }
                    //}
                    break;



                case "Budget Sheet":
                    try
                    {
                        revision = cboRevision.Text.Trim();
                        if (!changeOrderStatus)
                        {
                            if (isRev)
                            {
                                Reports.JobChangeOrderDetailRev(recordID, jobID, revision);
                            }
                            else
                            {
                                Reports.JobChangeOrderDetail(recordID, jobID);
                                Reports.JobChangeOrderDetail(recordID, jobID);
                            }
                        }
                        else
                        {
                            Reports.JobChangeOrderDetailRev(recordID, jobID, revision);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
                case "&Change Order Contract":
                    try
                    {
                        revision = cboRevision.Text.Trim();
                        if (!changeOrderStatus)
                        {
                            if (isRev)
                            {
                                Reports.ChangeOrderContractRev(jobID, recordID, revision);
                            }
                            else
                            {
                                Reports.ChangeOrderContract(jobID, recordID);
                            }
                        }
                        else
                        {
                            Reports.ChangeOrderContractRev(jobID, recordID, revision);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
                case "&Change Order Letter":
                    try
                    {
                        revision = cboRevision.Text.Trim();
                        if (changeOrderStatus)
                        {
                            Reports.ChangeOrderLetterRev(jobID, recordID, revision);
                        }
                        else
                        {
                            if (isRev)
                            {
                                Reports.ChangeOrderLetterRev(jobID, recordID, revision);
                            }
                            else
                            {
                                Reports.ChangeOrderLetter(jobID, recordID);
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
                case "Change Order Contract && Letter":
                    try
                    {
                        revision = cboRevision.Text.Trim();
                        if (!changeOrderStatus)
                        {
                            if (isRev)
                            {
                                Reports.ChangeOrderContractLetterRev(jobID, recordID, revision);
                            }
                            else
                            {
                                Reports.ChangeOrderContractLetter(jobID, recordID);
                            }
                        }
                        else
                        {
                            Reports.ChangeOrderContractLetterRev(jobID, recordID, revision);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
                    break;
            }
        }
        //
        private bool CheckChangeOrderStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveChangeOrder();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                        {
                            btnRev.Enabled = false;
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnRev.Enabled = true;
                            btnCopy.Enabled = true;
                        }
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
                    {
                        return false;
                    }
                    else
                    {
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                        {
                            btnRev.Enabled = false;
                            btnCopy.Enabled = false;
                        }
                        else
                        {
                            btnRev.Enabled = true;
                            btnCopy.Enabled = true;
                        }
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
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                {
                    btnRev.Enabled = false;
                    btnCopy.Enabled = false;
                }
                else
                {
                    btnRev.Enabled = true;
                    btnCopy.Enabled = true;
                }
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveChangeOrder()
        {
            try
            {

                if (labelControl167.EditValue.ToString().Length > 27 ||
                labelControl152.EditValue.ToString().Length > 27 ||
                labelControl119.EditValue.ToString().Length > 27 ||
                labelControl118.EditValue.ToString().Length > 27 ||
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

                #region JobChangeOrderContract
                JobChangeOrderContract changeOrder = new JobChangeOrderContract(recordID,
                                jobID,
                                txtJobChangeOrderNumber.EditValue.ToString(),
                                txtJobChangeOrderRequestDate.EditValue.ToString(),
                                txtJobChangeOrderRequestedAmount.EditValue.ToString(),
                                txtJobChangeOrderApprovedDate.EditValue.ToString(),
                                txtJobChangeOrderApprovedAmount.EditValue.ToString(),
                                cboJobChangeOrderStatus.EditValue.ToString(),
                                cboJobChangeOrderDescription.EditValue.ToString(),
                                txtJobChangeOrderOwnerNumber.EditValue.ToString(),
                                txtJobChangeOrderCCENumber.EditValue.ToString(),
                                txtJobChangeOrderUserDescription.Text,
                                txtChangeOrderAmount.EditValue.ToString(),
                                txtPriceAdjustment.EditValue.ToString(),
                                txtDirectMaterials.EditValue.ToString(),
                                txtEstimatedBIMHours.EditValue.ToString(),
                                txtEstimatedApprenticeHours.EditValue.ToString(),
                                // txtEstimatedElectricianHours.EditValue.ToString(),
                                txtEstimatedElectricianHours.EditValue.ToString(),
                                txtForemanDefaultHours.EditValue.ToString(),
                                txtGeneralForemanDefaultHours.EditValue.ToString(),
                                txtSuperintendentDefaultHours.EditValue.ToString(),
                                txtProjectManagerDefaultHours.EditValue.ToString(),
                                txtProjectEngineerDefaultHours.EditValue.ToString(),
                                txtForemanActualHours.EditValue.ToString(),
                                txtGeneralForemanActualHours.EditValue.ToString(),
                                txtSuperintendentActualHours.EditValue.ToString(),
                                txtProjectManagerActualHours.EditValue.ToString(),
                                txtProjectEngineerActualHours.EditValue.ToString(),
                                txtPremiumHoursActualHours.EditValue.ToString(),
                                txtOtherExpenses1.EditValue.ToString(),
                                txtOtherExpenses2.EditValue.ToString(),
                                txtOtherExpenses3.EditValue.ToString(),
                                txtOtherExpenses1Description.Text,
                                txtOtherExpenses2Description.Text,
                                txtOtherExpenses3Description.Text,
                                txtSubcontractsAmount.EditValue.ToString(),
                                txtLaborHoursEstimateDefaults.EditValue.ToString(),
                                txtLaborDollarEstimateDefaults.EditValue.ToString(),
                                txtLaborRateEstimateDefaults.EditValue.ToString(),
                                txtMaterialsEstimateDefaults.EditValue.ToString(),
                                txtOtherEstimateDefaults.EditValue.ToString(),
                                txtSubcontractsEstimateDefaults.EditValue.ToString(),
                                txtTotalCostEstimateDefaults.EditValue.ToString(),
                                txtContractDollarEstimateDefaults.EditValue.ToString(),
                                txtProfitDollarEstimateDefaults.EditValue.ToString(),
                                txtProfitPercentEstimateDefaults.EditValue.ToString(),
                                txtLaborHoursBudgetTotals.EditValue.ToString(),
                                txtLaborDollarBudgetTotals.EditValue.ToString(),
                                txtLaborRateBudgetTotals.EditValue.ToString(),
                                txtMaterialsBudgetTotals.EditValue.ToString(),
                                txtOtherBudgetTotals.EditValue.ToString(),
                                txtSubcontractsBudgetTotals.EditValue.ToString(),
                                txtTotalCostBudgetTotals.EditValue.ToString(),
                                txtContractDollarBudgetTotals.EditValue.ToString(),
                                txtProfitDollarBudgetTotals.EditValue.ToString(),
                                txtProfitPercentBudgetTotals.EditValue.ToString(),
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

                                sundriesCost.ToString(),
                                salesTaxCost.ToString(),
                                BIMCost.ToString(),
                                apprenticeCost.ToString(),
                                electricianCost.ToString(),
                                foremanCost.ToString(),
                                generalForemanCost.ToString(),
                                superintendentCost.ToString(),
                                premiumCost.ToString(),
                                fringeBenefitsCost.ToString(),
                                safetyMeetingsCost.ToString(),
                                projectManagerCost.ToString(),
                                projectEngineerCost.ToString(),
                                totalLaborCost.ToString(),
                                asBuiltsEngineeringCost.ToString(),
                                storageCost.ToString(),
                                smallToolsCost.ToString(),
                                cartigeHandlingCost.ToString(),
                                totalExpensesCost.ToString(),
                                materialsLaborExpensesCost.ToString(),
                                overheadCost.ToString(),
                                materialsLaborExpensesOverheadCost.ToString(),
                                profitCost.ToString(),
                                overheadProfitCost.ToString(),
                                subcontractAdministrationCost.ToString(),
                                overheadProfitSubcontractsAmountSubcontractAdministrationCost.ToString(),
                                warrantyCost.ToString(),
                                bondCost.ToString(),
                                txtLetterWorkDescription.Text,
                                txtLetterExclusion.Text,
                                txtLetterTimeExtension.EditValue == null ? "" : txtLetterTimeExtension.EditValue.ToString(),
                                cboContact.EditValue == null ? "" : cboContact.EditValue.ToString(),
                                txtFrom.Text,
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
                                txtEstimatedBIMHoursOT.EditValue.ToString(),
                                txtEstimatedApprenticeHoursOT.EditValue.ToString(),
                                txtEstimatedElectricianHoursOT.EditValue.ToString(),
                                txtEstimatedBIMHoursDT.EditValue.ToString(),
                                txtEstimatedApprenticeHoursDT.EditValue.ToString(),
                                txtEstimatedElectricianHoursDT.EditValue.ToString(),

                                txtForemanDefaultHoursOT.EditValue.ToString(),
                                txtGeneralForemanDefaultHoursOT.EditValue.ToString(),
                                txtSuperintendentDefaultHoursOT.EditValue.ToString(),
                                txtProjectManagerDefaultHoursOT.EditValue.ToString(),
                                txtProjectEngineerDefaultHoursOT.EditValue.ToString(),
                                txtForemanDefaultHoursDT.EditValue.ToString(),
                                txtGeneralForemanDefaultHoursDT.EditValue.ToString(),
                                txtSuperintendentDefaultHoursDT.EditValue.ToString(),
                                txtProjectManagerDefaultHoursDT.EditValue.ToString(),
                                txtProjectEngineerDefaultHoursDT.EditValue.ToString(),
                                txtForemanActualHoursOT.EditValue.ToString(),
                                txtGeneralForemanActualHoursOT.EditValue.ToString(),
                                txtSuperintendentActualHoursOT.EditValue.ToString(),
                                txtProjectManagerActualHoursOT.EditValue.ToString(),
                                txtProjectEngineerActualHoursOT.EditValue.ToString(),
                                txtPremiumHoursActualHoursOT.EditValue.ToString(),
                                txtForemanActualHoursDT.EditValue.ToString(),
                                txtGeneralForemanActualHoursDT.EditValue.ToString(),
                                txtSuperintendentActualHoursDT.EditValue.ToString(),
                                txtProjectManagerActualHoursDT.EditValue.ToString(),
                                txtProjectEngineerActualHoursDT.EditValue.ToString(),
                                txtPremiumHoursActualHoursDT.EditValue.ToString(),
                                txtAsBuiltsEngineeringPercentText.Text,
                                txtStoragePercentText.Text,
                                txtSmallToolsPercentText.Text,
                                txtCartigeHandlingPercentText.Text,
                                txtOverheadPercentText.Text,
                                txtProfitPercentText.Text,
                                txtSubcontractAdministrationPercentText.Text,
                                txtWarrantyPercentText.Text,
                                txtBondPercentText.Text,
                                labelControl167.Text.Trim(),
                                labelControl152.Text.Trim(),
                                labelControl119.Text.Trim(),
                                labelControl118.Text.Trim(),
                                labelControl117.Text.Trim(),
                                labelControl116.Text.Trim(),
                                labelControl115.Text.Trim(),
                                labelControl120.Text.Trim(),
                                labelControl114.Text.Trim(),
                                labelControl113.Text.Trim(),
                                labelControl15.Text.Trim(),
                                labelControl16.Text.Trim()

                                );

                #endregion JobChangeOrderContract
                revision = cboRevision.Text.Trim();
                changeOrder.Save(revision, changeOrderStatus, isFormClosed);
                recordID = changeOrder.JobChangeOrderID;
                txtRecordID.Text = recordID;
                string latestRevision = changeOrder.GetLatestChangeOrderRevision(recordID);
                if (latestRevision != cboRevision.Text.Trim())
                    SaveChangeOrderCostCodesFromRev(latestRevision);
                GetChangeOrderRevision(recordID);
                if (txtJobChangeOrderNumber.Text.Trim() == "")
                {
                    txtJobChangeOrderNumber.Text = changeOrder.JobChangeOrderNumber;
                    SetControlAccess();
                }

                // Starbuilder
                if (Convert.ToInt32(txtJobChangeOrderNumber.Text.Trim()) == 0)
                {
                    JobChangeOrder.UpdatePrimaryContract(jobID);
                }
                else
                {
                    JobChangeOrder.UpdateChangeOrder(jobID, recordID);
                }
                ProtectForm();
                changesStatus = true;

                // by anu for labour rate default value
                //try
                //{
                //    bool value = JobChangeOrder.UpdateChangeOrderDefaultLabelValues(jobID, labelControl167.Text, labelControl152.Text, labelControl119.Text, labelControl118.Text, labelControl117.Text, labelControl116.Text, labelControl115.Text, labelControl120.Text, labelControl114.Text, labelControl113.Text);
                //}
                //catch (Exception ex)
                //{ }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
            {
                btnRev.Enabled = false;
                btnCopy.Enabled = false;
            }
            else
            {
                btnRev.Enabled = true;
                btnCopy.Enabled = true;
            }
        }
        //
        private void GetChangeOrder(bool isRevision)
        {
            if (!isRevision)
            {
                GetChangeOrderRevision(recordID);
            }
            GetChangeOrderDetail(recordID);
            SetControlAccess();

            //this.Text = txtRFISubject.Text;
        }
        private void GetChangeOrderRevision(string recordID)
        {
            try
            {
                revision = "";
                //cboRevision.Text = "";
                DataTable t = JobChangeOrderContract.GetJobChangeOrderRevList(recordID).Tables[0];
                cboRevision.Properties.Items.Clear();
                if (!changeOrderStatus)
                {
                    cboRevision.Properties.Items.Add("");
                    if (t.Rows.Count > 0)
                    {
                        foreach (DataRow r in t.Rows)
                        {
                            cboRevision.Properties.Items.Add(r[0].ToString());
                        }
                    }
                }
                else
                {
                    if (t.Rows.Count > 0)
                    {
                        int counter = 0;
                        foreach (DataRow r in t.Rows)
                        {
                            counter++;
                            cboRevision.Properties.Items.Add(r[0].ToString());
                            if (counter == t.Rows.Count)
                            {
                                cboRevision.SelectedItem = r[0];
                            }
                        }
                    }
                }

                if (isUndo == true)
                { revision = cboRevision.Text.Trim(); }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            finally
            {
                isRev = false;
            }
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
            /* DevExpress.XtraEditors.BaseControl myControl = (DevExpress.XtraEditors.BaseControl)sender;
             if (myControl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
             {
               //  string myString = myControl.Text.Trim().ToUpper();

                // if (myString != myControl.Text.Trim())
                //     myControl.Text = myControl.Text.ToString().ToUpper();
             }*/
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly & !Security.Security.currentJobReadOnly && !isRev)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnRev.Enabled = false;
                    btnCopy.Enabled = false;
                }
            }
            if (!dataChanged)
            {
                //if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly & !Security.Security.currentJobReadOnly && !isRev)
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly & !Security.Security.currentJobReadOnly)
                {
                    if (!changeOrderStatus)
                    {
                        if (!isRev)
                        {
                            dataChanged = true;
                            btnUndo.Enabled = true;
                            btnSave.Enabled = true;
                            btnRev.Enabled = false;
                            btnCopy.Enabled = false;
                        }
                    }
                    else
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
                        btnRev.Enabled = false;
                        btnCopy.Enabled = false;
                    }
                }
            }
            CalculateValues();
        }
        //
        private void CalculateValues()
        {
            float directMaterial = 0;
            float sundriesPercentOfMaterial = 0;
            float salesTaxPercent = 0;
            float materialsEstimateDefaults = 0;

            float estimateBIMHours = 0;
            float estimateApprenticeHours = 0;
            float estimateElectricianHours = 0;
            /* New */
            float estimateBIMHoursOT = 0;
            float estimateApprenticeHoursOT = 0;
            float estimateElectricianHoursOT = 0;
            float estimateBIMHoursDT = 0;
            float estimateApprenticeHoursDT = 0;
            float estimateElectricianHoursDT = 0;



            float foremanActualHours = 0;
            float generalForemanActualHours = 0;
            float superintendentAcualHours = 0;
            float premiumHoursActualHours = 0;
            float foremanDefaultHours = 0;
            /* New */
            float foremanActualHoursOT = 0;
            float generalForemanActualHoursOT = 0;
            float superintendentAcualHoursOT = 0;
            float premiumHoursActualHoursOT = 0;
            float foremanDefaultHoursOT = 0;
            float foremanActualHoursDT = 0;
            float generalForemanActualHoursDT = 0;
            float superintendentAcualHoursDT = 0;
            float premiumHoursActualHoursDT = 0;
            float foremanDefaultHoursDT = 0;



            float generalForemanDefaultHours = 0;
            float superintendentDefaultHours = 0;
            /* New */
            float generalForemanDefaultHoursOT = 0;
            float superintendentDefaultHoursOT = 0;
            float generalForemanDefaultHoursDT = 0;
            float superintendentDefaultHoursDT = 0;



            float foremanPercentOfLabor = 0;
            float generalForemantPercentOfLabor = 0;
            float superintendentPercentOfLabor = 0;
            float laborHoursEstimateDefaults = 0;

            float BIMRate = 0;
            float apprenticeLaborRate = 0;
            float electricianLaborRate = 0;
            float foremanLaborRate = 0;
            float generalForemanLaborRate = 0;
            float superintendentLaborRate = 0;
            float premiumTimeLaborRate = 0;
            /* New */
            float BIMRateOT = 0;
            float apprenticeLaborRateOT = 0;
            float electricianLaborRateOT = 0;
            float foremanLaborRateOT = 0;
            float generalForemanLaborRateOT = 0;
            float superintendentLaborRateOT = 0;
            float premiumTimeLaborRateOT = 0;

            float BIMRateDT = 0;
            float apprenticeLaborRateDT = 0;
            float electricianLaborRateDT = 0;
            float foremanLaborRateDT = 0;
            float generalForemanLaborRateDT = 0;
            float superintendentLaborRateDT = 0;
            float premiumTimeLaborRateDT = 0;


            float fringeBenefitsPercent = 0;
            float safetyMeetingPercent = 0;
            float laborDollarEstimateDefaults = 0;

            float projectManagerLaborRate = 0;
            float projectEngineerLaborRate = 0;
            float projectManagerActualHours = 0;
            float projectEngineerActualHours = 0;
            float projectManagerDefaultHours = 0;
            float projectEngineerDefaultHours = 0;
            /* New */
            float projectManagerLaborRateOT = 0;
            float projectEngineerLaborRateOT = 0;
            float projectManagerActualHoursOT = 0;
            float projectEngineerActualHoursOT = 0;
            float projectManagerDefaultHoursOT = 0;
            float projectEngineerDefaultHoursOT = 0;
            float projectManagerLaborRateDT = 0;
            float projectEngineerLaborRateDT = 0;
            float projectManagerActualHoursDT = 0;
            float projectEngineerActualHoursDT = 0;
            float projectManagerDefaultHoursDT = 0;
            float projectEngineerDefaultHoursDT = 0;



            float projectManagerPercentOfLabor = 0;
            float projectEngineerPercentOfLabor = 0;
            float asBuiltsEngineeringPercent = 0;
            float storagePercent = 0;
            float smallToolsPercent = 0;
            float cartigeHandlingPercent = 0;
            float otherExpenses1 = 0;
            float otherExpenses2 = 0;
            float otherExpenses3 = 0;
            float subcontractsAmount = 0;
            float subcontractAdministrationPercent = 0;
            float warrantyPercent = 0;
            float bondPercent = 0;
            float overheadPercent = 0;
            float profitPercent = 0;
            float otherEstimateDefaults = 0;
            float totalCostEstimateDefaults = 0;
            float contractDollarEstimateDefaults = 0;
            float profitDollarEstimateDefaults = 0;
            float profitPercentEstimateDefaults = 0;
            float totalCostBudgetTotals = 0;

            /* Calculate Material */
            if (txtDirectMaterials.EditValue != null)
            {
                float.TryParse(txtDirectMaterials.EditValue.ToString(), out directMaterial);
            }

            if (txtSundriesPercentOfMaterial.EditValue != null)
            {
                float.TryParse(txtSundriesPercentOfMaterial.EditValue.ToString(), out sundriesPercentOfMaterial);
            }

            if (txtSalesTaxPercent.EditValue != null)
            {
                float.TryParse(txtSalesTaxPercent.EditValue.ToString(), out salesTaxPercent);
            }

            sundriesCost = (sundriesPercentOfMaterial * directMaterial);
            salesTaxCost = (salesTaxPercent * (directMaterial + (sundriesPercentOfMaterial * directMaterial)));
            materialsEstimateDefaults =
                directMaterial +
                sundriesCost +
                salesTaxCost;
            txtMaterialsEstimateDefaults.EditValue = materialsEstimateDefaults;

            /* Calculate Labor Hours */
            if (txtEstimatedBIMHours.EditValue != null)
            {
                float.TryParse(txtEstimatedBIMHours.EditValue.ToString(), out estimateBIMHours);
            }

            if (txtEstimatedApprenticeHours.EditValue != null)
            {
                float.TryParse(txtEstimatedApprenticeHours.EditValue.ToString(), out estimateApprenticeHours);
            }

            if (txtEstimatedElectricianHours.EditValue != null)
            {
                float.TryParse(txtEstimatedElectricianHours.EditValue.ToString(), out estimateElectricianHours);
            }

            if (txtForemanActualHours.EditValue != null)
            {
                float.TryParse(txtForemanActualHours.EditValue.ToString(), out foremanActualHours);
            }

            if (txtGeneralForemanActualHours.EditValue != null)
            {
                float.TryParse(txtGeneralForemanActualHours.EditValue.ToString(), out generalForemanActualHours);
            }

            if (txtSuperintendentActualHours.EditValue != null)
            {
                float.TryParse(txtSuperintendentActualHours.EditValue.ToString(), out superintendentAcualHours);
            }

            if (txtPremiumHoursActualHours.EditValue != null)
            {
                float.TryParse(txtPremiumHoursActualHours.EditValue.ToString(), out premiumHoursActualHours);
            }

            if (txtForemanPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtForemanPercentOfLabor.EditValue.ToString(), out foremanPercentOfLabor);
            }

            if (txtGeneralForemanPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtGeneralForemanPercentOfLabor.EditValue.ToString(), out generalForemantPercentOfLabor);
            }

            if (txtSuperintendentPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtSuperintendentPercentOfLabor.EditValue.ToString(), out superintendentPercentOfLabor);
            }

            foremanDefaultHours = estimateElectricianHours * foremanPercentOfLabor;
            generalForemanDefaultHours = estimateElectricianHours * generalForemantPercentOfLabor;
            superintendentDefaultHours = estimateElectricianHours * superintendentPercentOfLabor;
            laborHoursEstimateDefaults =
                estimateBIMHours +
                estimateApprenticeHours +
                estimateElectricianHours +
                foremanActualHours +
                generalForemanActualHours +
                superintendentAcualHours +
                premiumHoursActualHours;
            txtForemanDefaultHours.EditValue = foremanDefaultHours;
            txtGeneralForemanDefaultHours.EditValue = generalForemanDefaultHours;
            txtSuperintendentDefaultHours.EditValue = superintendentDefaultHours;
            txtLaborHoursEstimateDefaults.EditValue = laborHoursEstimateDefaults;

            /* New for Overtime */
            if (txtEstimatedApprenticeHoursOT.EditValue != null)
            {
                float.TryParse(txtEstimatedApprenticeHoursOT.EditValue.ToString(), out estimateApprenticeHoursOT);
            }

            if (txtEstimatedBIMHoursOT.EditValue != null)
            {
                float.TryParse(txtEstimatedBIMHoursOT.EditValue.ToString(), out estimateBIMHoursOT);
            }

            if (txtEstimatedElectricianHoursOT.EditValue != null)
            {
                float.TryParse(txtEstimatedElectricianHoursOT.EditValue.ToString(), out estimateElectricianHoursOT);
            }

            if (txtForemanActualHoursOT.EditValue != null)
            {
                float.TryParse(txtForemanActualHoursOT.EditValue.ToString(), out foremanActualHoursOT);
            }

            if (txtGeneralForemanActualHoursOT.EditValue != null)
            {
                float.TryParse(txtGeneralForemanActualHoursOT.EditValue.ToString(), out generalForemanActualHoursOT);
            }

            if (txtSuperintendentActualHoursOT.EditValue != null)
            {
                float.TryParse(txtSuperintendentActualHoursOT.EditValue.ToString(), out superintendentAcualHoursOT);
            }

            if (txtPremiumHoursActualHoursOT.EditValue != null)
            {
                float.TryParse(txtPremiumHoursActualHoursOT.EditValue.ToString(), out premiumHoursActualHoursOT);
            }

            if (txtForemanPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtForemanPercentOfLabor.EditValue.ToString(), out foremanPercentOfLabor);
            }

            if (txtGeneralForemanPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtGeneralForemanPercentOfLabor.EditValue.ToString(), out generalForemantPercentOfLabor);
            }

            if (txtSuperintendentPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtSuperintendentPercentOfLabor.EditValue.ToString(), out superintendentPercentOfLabor);
            }

            foremanDefaultHoursOT = estimateElectricianHoursOT * foremanPercentOfLabor;
            generalForemanDefaultHoursOT = estimateElectricianHoursOT * generalForemantPercentOfLabor;
            superintendentDefaultHoursOT = estimateElectricianHoursOT * superintendentPercentOfLabor;
            laborHoursEstimateDefaults +=
                estimateBIMHoursOT +
                estimateApprenticeHoursOT +
                estimateElectricianHoursOT +
                foremanActualHoursOT +
                generalForemanActualHoursOT +
                superintendentAcualHoursOT +
                premiumHoursActualHoursOT;
            txtForemanDefaultHoursOT.EditValue = foremanDefaultHoursOT;
            txtGeneralForemanDefaultHoursOT.EditValue = generalForemanDefaultHoursOT;
            txtSuperintendentDefaultHoursOT.EditValue = superintendentDefaultHoursOT;
            txtLaborHoursEstimateDefaults.EditValue = laborHoursEstimateDefaults;


            /* New for DoubleTime */
            if (txtEstimatedApprenticeHoursDT.EditValue != null)
            {
                float.TryParse(txtEstimatedApprenticeHoursDT.EditValue.ToString(), out estimateApprenticeHoursDT);
            }

            if (txtEstimatedBIMHoursDT.EditValue != null)
            {
                float.TryParse(txtEstimatedBIMHoursDT.EditValue.ToString(), out estimateBIMHoursDT);
            }

            if (txtEstimatedElectricianHoursDT.EditValue != null)
            {
                float.TryParse(txtEstimatedElectricianHoursDT.EditValue.ToString(), out estimateElectricianHoursDT);
            }

            if (txtForemanActualHoursDT.EditValue != null)
            {
                float.TryParse(txtForemanActualHoursDT.EditValue.ToString(), out foremanActualHoursDT);
            }

            if (txtGeneralForemanActualHoursDT.EditValue != null)
            {
                float.TryParse(txtGeneralForemanActualHoursDT.EditValue.ToString(), out generalForemanActualHoursDT);
            }

            if (txtSuperintendentActualHoursDT.EditValue != null)
            {
                float.TryParse(txtSuperintendentActualHoursDT.EditValue.ToString(), out superintendentAcualHoursDT);
            }

            if (txtPremiumHoursActualHoursDT.EditValue != null)
            {
                float.TryParse(txtPremiumHoursActualHoursDT.EditValue.ToString(), out premiumHoursActualHoursDT);
            }

            if (txtForemanPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtForemanPercentOfLabor.EditValue.ToString(), out foremanPercentOfLabor);
            }

            if (txtGeneralForemanPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtGeneralForemanPercentOfLabor.EditValue.ToString(), out generalForemantPercentOfLabor);
            }

            if (txtSuperintendentPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtSuperintendentPercentOfLabor.EditValue.ToString(), out superintendentPercentOfLabor);
            }

            foremanDefaultHoursDT = estimateElectricianHoursDT * foremanPercentOfLabor;
            generalForemanDefaultHoursDT = estimateElectricianHoursDT * generalForemantPercentOfLabor;
            superintendentDefaultHoursDT = estimateElectricianHoursDT * superintendentPercentOfLabor;
            laborHoursEstimateDefaults +=
                estimateBIMHoursDT +
                estimateApprenticeHoursDT +
                estimateElectricianHoursDT +
                foremanActualHoursDT +
                generalForemanActualHoursDT +
                superintendentAcualHoursDT +
                premiumHoursActualHoursDT;
            txtForemanDefaultHoursDT.EditValue = foremanDefaultHoursDT;
            txtGeneralForemanDefaultHoursDT.EditValue = generalForemanDefaultHoursDT;
            txtSuperintendentDefaultHoursDT.EditValue = superintendentDefaultHoursDT;
            txtLaborHoursEstimateDefaults.EditValue = laborHoursEstimateDefaults;







            /* Calculate Labor Dollar */
            if (txtApprenticeLaborRate.EditValue != null)
            {
                float.TryParse(txtApprenticeLaborRate.EditValue.ToString(), out apprenticeLaborRate);
            }

            if (txtBIMRate.EditValue != null)
            {
                float.TryParse(txtBIMRate.EditValue.ToString(), out BIMRate);
            }

            if (txtElectricianLaborRate.EditValue != null)
            {
                float.TryParse(txtElectricianLaborRate.EditValue.ToString(), out electricianLaborRate);
            }

            if (txtForemanLaborRate.EditValue != null)
            {
                float.TryParse(txtForemanLaborRate.EditValue.ToString(), out foremanLaborRate);
            }

            if (txtGeneralForemanLaborRate.EditValue != null)
            {
                float.TryParse(txtGeneralForemanLaborRate.EditValue.ToString(), out generalForemanLaborRate);
            }

            if (txtSuperintendentLaborRate.EditValue != null)
            {
                float.TryParse(txtSuperintendentLaborRate.EditValue.ToString(), out superintendentLaborRate);
            }

            if (txtPremiumTimeLaborRate.EditValue != null)
            {
                float.TryParse(txtPremiumTimeLaborRate.EditValue.ToString(), out premiumTimeLaborRate);
            }

            if (txtFringeBenefitsPercent.EditValue != null)
            {
                float.TryParse(txtFringeBenefitsPercent.EditValue.ToString(), out fringeBenefitsPercent);
            }

            if (txtSafetyMeetingPercent.EditValue != null)
            {
                float.TryParse(txtSafetyMeetingPercent.EditValue.ToString(), out safetyMeetingPercent);
            }
            /* Over Time */
            if (txtApprenticeLaborRateOT.EditValue != null)
            {
                float.TryParse(txtApprenticeLaborRateOT.EditValue.ToString(), out apprenticeLaborRateOT);
            }

            if (txtBIMRateOT.EditValue != null)
            {
                float.TryParse(txtBIMRateOT.EditValue.ToString(), out BIMRateOT);
            }

            if (txtElectricianLaborRateOT.EditValue != null)
            {
                float.TryParse(txtElectricianLaborRateOT.EditValue.ToString(), out electricianLaborRateOT);
            }

            if (txtForemanLaborRateOT.EditValue != null)
            {
                float.TryParse(txtForemanLaborRateOT.EditValue.ToString(), out foremanLaborRateOT);
            }

            if (txtGeneralForemanLaborRateOT.EditValue != null)
            {
                float.TryParse(txtGeneralForemanLaborRateOT.EditValue.ToString(), out generalForemanLaborRateOT);
            }

            if (txtSuperintendentLaborRateOT.EditValue != null)
            {
                float.TryParse(txtSuperintendentLaborRateOT.EditValue.ToString(), out superintendentLaborRateOT);
            }

            if (txtPremiumTimeLaborRateOT.EditValue != null)
            {
                float.TryParse(txtPremiumTimeLaborRateOT.EditValue.ToString(), out premiumTimeLaborRateOT);
            }

            if (txtFringeBenefitsPercent.EditValue != null)
            {
                float.TryParse(txtFringeBenefitsPercent.EditValue.ToString(), out fringeBenefitsPercent);
            }

            if (txtSafetyMeetingPercent.EditValue != null)
            {
                float.TryParse(txtSafetyMeetingPercent.EditValue.ToString(), out safetyMeetingPercent);
            }

            /* Double Time */
            if (txtApprenticeLaborRateDT.EditValue != null)
            {
                float.TryParse(txtApprenticeLaborRateDT.EditValue.ToString(), out apprenticeLaborRateDT);
            }

            if (txtBIMRateDT.EditValue != null)
            {
                float.TryParse(txtBIMRateDT.EditValue.ToString(), out BIMRateDT);
            }

            if (txtElectricianLaborRateDT.EditValue != null)
            {
                float.TryParse(txtElectricianLaborRateDT.EditValue.ToString(), out electricianLaborRateDT);
            }

            if (txtForemanLaborRateDT.EditValue != null)
            {
                float.TryParse(txtForemanLaborRateDT.EditValue.ToString(), out foremanLaborRateDT);
            }

            if (txtGeneralForemanLaborRateDT.EditValue != null)
            {
                float.TryParse(txtGeneralForemanLaborRateDT.EditValue.ToString(), out generalForemanLaborRateDT);
            }

            if (txtSuperintendentLaborRateDT.EditValue != null)
            {
                float.TryParse(txtSuperintendentLaborRateDT.EditValue.ToString(), out superintendentLaborRateDT);
            }

            if (txtPremiumTimeLaborRateDT.EditValue != null)
            {
                float.TryParse(txtPremiumTimeLaborRateDT.EditValue.ToString(), out premiumTimeLaborRateDT);
            }

            if (txtFringeBenefitsPercent.EditValue != null)
            {
                float.TryParse(txtFringeBenefitsPercent.EditValue.ToString(), out fringeBenefitsPercent);
            }

            if (txtSafetyMeetingPercent.EditValue != null)
            {
                float.TryParse(txtSafetyMeetingPercent.EditValue.ToString(), out safetyMeetingPercent);
            }

            BIMCost = (BIMRate * estimateBIMHours) + (BIMRateOT * estimateBIMHoursOT) + (BIMRateDT * estimateBIMHoursDT);

            apprenticeCost = (apprenticeLaborRate * estimateApprenticeHours) + (apprenticeLaborRateOT * estimateApprenticeHoursOT) + (apprenticeLaborRateDT * estimateApprenticeHoursDT);
            electricianCost = (electricianLaborRate * estimateElectricianHours) + (electricianLaborRateOT * estimateElectricianHoursOT) + (electricianLaborRateDT * estimateElectricianHoursDT);
            foremanCost = (foremanLaborRate * foremanActualHours) + (foremanLaborRateOT * foremanActualHoursOT) + (foremanLaborRateDT * foremanActualHoursDT);
            generalForemanCost = (generalForemanLaborRate * generalForemanActualHours) + (generalForemanLaborRateOT * generalForemanActualHoursOT) + (generalForemanLaborRateDT * generalForemanActualHoursDT);
            superintendentCost = (superintendentLaborRate * superintendentAcualHours) + (superintendentLaborRateOT * superintendentAcualHoursOT) + (superintendentLaborRateDT * superintendentAcualHoursDT);
            fringeBenefitsCost = (electricianCost +
                foremanCost +
                generalForemanCost +
                superintendentCost) * fringeBenefitsPercent;
            premiumCost = (premiumTimeLaborRate * premiumHoursActualHours) + (premiumTimeLaborRateOT * premiumHoursActualHoursOT) + (premiumTimeLaborRateDT * premiumHoursActualHoursDT);
            safetyMeetingsCost = (electricianCost + foremanCost + generalForemanCost) * safetyMeetingPercent;
            laborDollarEstimateDefaults = BIMCost + apprenticeCost +
                                    electricianCost +
                                    foremanCost +
                                    generalForemanCost +
                                    superintendentCost + fringeBenefitsCost + premiumCost + safetyMeetingsCost;

            txtLaborDollarEstimateDefaults.EditValue = laborDollarEstimateDefaults;
            if (laborHoursEstimateDefaults > 0)
            {
                txtLaborRateEstimateDefaults.EditValue = laborDollarEstimateDefaults / laborHoursEstimateDefaults;
            }
            else
            {
                txtLaborRateEstimateDefaults.EditValue = 0;
            }










            /* Calculate Other Expenses */

            if (txtProjectManagerLaborRate.EditValue != null)
            {
                float.TryParse(txtProjectManagerLaborRate.EditValue.ToString(), out projectManagerLaborRate);
            }

            if (txtProjectEngineerLaborRate.EditValue != null)
            {
                float.TryParse(txtProjectEngineerLaborRate.EditValue.ToString(), out projectEngineerLaborRate);
            }

            if (txtProjectManagerActualHours.EditValue != null)
            {
                float.TryParse(txtProjectManagerActualHours.EditValue.ToString(), out projectManagerActualHours);
            }

            if (txtProjectEngineerActualHours.EditValue != null)
            {
                float.TryParse(txtProjectEngineerActualHours.EditValue.ToString(), out projectEngineerActualHours);
            }
            /* Over Time */
            if (txtProjectManagerLaborRateOT.EditValue != null)
            {
                float.TryParse(txtProjectManagerLaborRateOT.EditValue.ToString(), out projectManagerLaborRateOT);
            }

            if (txtProjectEngineerLaborRateOT.EditValue != null)
            {
                float.TryParse(txtProjectEngineerLaborRateOT.EditValue.ToString(), out projectEngineerLaborRateOT);
            }

            if (txtProjectManagerActualHoursOT.EditValue != null)
            {
                float.TryParse(txtProjectManagerActualHoursOT.EditValue.ToString(), out projectManagerActualHoursOT);
            }

            if (txtProjectEngineerActualHoursOT.EditValue != null)
            {
                float.TryParse(txtProjectEngineerActualHoursOT.EditValue.ToString(), out projectEngineerActualHoursOT);
            }
            /* Double Time */
            if (txtProjectManagerLaborRateDT.EditValue != null)
            {
                float.TryParse(txtProjectManagerLaborRateDT.EditValue.ToString(), out projectManagerLaborRateDT);
            }

            if (txtProjectEngineerLaborRateDT.EditValue != null)
            {
                float.TryParse(txtProjectEngineerLaborRateDT.EditValue.ToString(), out projectEngineerLaborRateDT);
            }

            if (txtProjectManagerActualHoursDT.EditValue != null)
            {
                float.TryParse(txtProjectManagerActualHoursDT.EditValue.ToString(), out projectManagerActualHoursDT);
            }

            if (txtProjectEngineerActualHoursDT.EditValue != null)
            {
                float.TryParse(txtProjectEngineerActualHoursDT.EditValue.ToString(), out projectEngineerActualHoursDT);
            }

            if (txtProjectManagerPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtProjectManagerPercentOfLabor.EditValue.ToString(), out projectManagerPercentOfLabor);
            }

            if (txtProjectEngineerPercentOfLabor.EditValue != null)
            {
                float.TryParse(txtProjectEngineerPercentOfLabor.EditValue.ToString(), out projectEngineerPercentOfLabor);
            }

            if (txtAsBuiltsEngineeringPercent.EditValue != null)
            {
                float.TryParse(txtAsBuiltsEngineeringPercent.EditValue.ToString(), out asBuiltsEngineeringPercent);
            }

            if (txtStoragePercent.EditValue != null)
            {
                float.TryParse(txtStoragePercent.EditValue.ToString(), out storagePercent);
            }

            if (txtSmallToolsPercent.EditValue != null)
            {
                float.TryParse(txtSmallToolsPercent.EditValue.ToString(), out smallToolsPercent);
            }

            if (txtCartigeHandlingPercent.EditValue != null)
            {
                float.TryParse(txtCartigeHandlingPercent.EditValue.ToString(), out cartigeHandlingPercent);
            }

            if (txtOtherExpenses1.EditValue != null)
            {
                float.TryParse(txtOtherExpenses1.EditValue.ToString(), out otherExpenses1);
            }

            if (txtOtherExpenses2.EditValue != null)
            {
                float.TryParse(txtOtherExpenses2.EditValue.ToString(), out otherExpenses2);
            }

            if (txtOtherExpenses3.EditValue != null)
            {
                float.TryParse(txtOtherExpenses3.EditValue.ToString(), out otherExpenses3);
            }

            if (txtSubcontractsAmount.EditValue != null)
            {
                float.TryParse(txtSubcontractsAmount.EditValue.ToString(), out subcontractsAmount);
            }

            if (txtSubcontractAdministrationPercent.EditValue != null)
            {
                float.TryParse(txtSubcontractAdministrationPercent.EditValue.ToString(), out subcontractAdministrationPercent);
            }

            if (txtWarrantyPercent.EditValue != null)
            {
                float.TryParse(txtWarrantyPercent.EditValue.ToString(), out warrantyPercent);
            }

            if (txtBondPercent.EditValue != null)
            {
                float.TryParse(txtBondPercent.EditValue.ToString(), out bondPercent);
            }

            if (txtOverheadPercent.EditValue != null)
            {
                float.TryParse(txtOverheadPercent.EditValue.ToString(), out overheadPercent);
            }

            if (txtProfitPercent.EditValue != null)
            {
                float.TryParse(txtProfitPercent.EditValue.ToString(), out profitPercent);
            }

            projectManagerDefaultHours = estimateElectricianHours * projectManagerPercentOfLabor;
            projectEngineerDefaultHours = estimateElectricianHours * projectEngineerPercentOfLabor;
            projectManagerDefaultHoursOT = estimateElectricianHoursOT * projectManagerPercentOfLabor;
            projectEngineerDefaultHoursOT = estimateElectricianHoursOT * projectEngineerPercentOfLabor;
            projectManagerDefaultHoursDT = estimateElectricianHoursDT * projectManagerPercentOfLabor;
            projectEngineerDefaultHoursDT = estimateElectricianHoursDT * projectEngineerPercentOfLabor;

            projectManagerCost = (projectManagerLaborRate * projectManagerActualHours) + (projectManagerLaborRateOT * projectManagerActualHoursOT) + (projectManagerLaborRateDT * projectManagerActualHoursDT);
            projectEngineerCost = (projectEngineerLaborRate * projectEngineerActualHours) + (projectEngineerLaborRateOT * projectEngineerActualHoursOT) + (projectEngineerLaborRateDT * projectEngineerActualHoursDT);


            totalLaborCost = laborDollarEstimateDefaults + projectManagerCost + projectEngineerCost;







            /* The new Additions ends Here *****************************/



            asBuiltsEngineeringCost = totalLaborCost * asBuiltsEngineeringPercent;
            storageCost = totalLaborCost * storagePercent;
            smallToolsCost = totalLaborCost * smallToolsPercent;
            cartigeHandlingCost = materialsEstimateDefaults * cartigeHandlingPercent;
            totalExpensesCost =
                asBuiltsEngineeringCost +
                storageCost +
                smallToolsCost +
                cartigeHandlingCost +
                otherExpenses1 +
                otherExpenses2 +
                otherExpenses3;









            materialsLaborExpensesCost = materialsEstimateDefaults + totalLaborCost + totalExpensesCost;
            overheadCost = materialsLaborExpensesCost * overheadPercent;
            materialsLaborExpensesOverheadCost = overheadCost + materialsLaborExpensesCost;
            profitCost = materialsLaborExpensesOverheadCost * profitPercent;
            overheadProfitCost = materialsLaborExpensesOverheadCost + profitCost;









            subcontractAdministrationCost = subcontractsAmount * subcontractAdministrationPercent;
            overheadProfitSubcontractsAmountSubcontractAdministrationCost = overheadProfitCost + subcontractsAmount + subcontractAdministrationCost;
            warrantyCost = overheadProfitSubcontractsAmountSubcontractAdministrationCost * warrantyPercent;
            bondCost = overheadProfitSubcontractsAmountSubcontractAdministrationCost * bondPercent;

            otherEstimateDefaults =
                projectManagerCost +
                projectEngineerCost +
                asBuiltsEngineeringCost +
                storageCost +
                smallToolsCost +
                cartigeHandlingCost +
                otherExpenses1 +
                otherExpenses2 +
                otherExpenses3 +
                subcontractAdministrationCost +
                warrantyCost +
                bondCost;
            totalCostEstimateDefaults = materialsEstimateDefaults + subcontractsAmount + otherEstimateDefaults + laborDollarEstimateDefaults;

            txtOtherEstimateDefaults.EditValue = otherEstimateDefaults;
            txtProjectManagerDefaultHours.EditValue = projectManagerDefaultHours;
            txtProjectEngineerDefaultHours.EditValue = projectEngineerDefaultHours;
            txtProjectManagerDefaultHoursOT.EditValue = projectManagerDefaultHoursOT;
            txtProjectEngineerDefaultHoursOT.EditValue = projectEngineerDefaultHoursOT;
            txtProjectManagerDefaultHoursDT.EditValue = projectManagerDefaultHoursDT;
            txtProjectEngineerDefaultHoursDT.EditValue = projectEngineerDefaultHoursDT;


            txtSubcontractsEstimateDefaults.EditValue = subcontractsAmount;
            txtTotalCostEstimateDefaults.EditValue = totalCostEstimateDefaults;



            contractDollarEstimateDefaults =
                overheadProfitSubcontractsAmountSubcontractAdministrationCost +
                warrantyCost +
                bondCost;
            profitDollarEstimateDefaults = overheadCost + profitCost;
            if (contractDollarEstimateDefaults != 0)
            {
                profitPercentEstimateDefaults = (profitDollarEstimateDefaults / contractDollarEstimateDefaults);
            }

            txtContractDollarEstimateDefaults.EditValue = contractDollarEstimateDefaults;
            txtProfitDollarEstimateDefaults.EditValue = profitDollarEstimateDefaults;
            txtProfitPercentEstimateDefaults.EditValue = profitPercentEstimateDefaults;
            txtContractDollarBudgetTotals.EditValue = contractDollarEstimateDefaults;
            txtJobChangeOrderRequestedAmount.EditValue = contractDollarEstimateDefaults;
            if (txtTotalCostBudgetTotals.EditValue != null)
            {
                float.TryParse(txtTotalCostBudgetTotals.EditValue.ToString(), out totalCostBudgetTotals);
            }

            txtProfitDollarBudgetTotals.EditValue = (contractDollarEstimateDefaults - totalCostBudgetTotals);
            if (contractDollarEstimateDefaults != 0)
            {
                txtProfitPercentBudgetTotals.EditValue = ((contractDollarEstimateDefaults - totalCostBudgetTotals) / contractDollarEstimateDefaults);
            }
            else
            {
                txtProfitPercentBudgetTotals.EditValue = 0;
            }
        }
        //
        private void frmChangeOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridView1, "frmChangeOrder");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckChangeOrderStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
            if (isUpdated)
            {
                SaveJobCostCodes();
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateChangeOrder(string recordID)
        {
            try
            {
                DataRow r;
                if (!changeOrderStatus)
                {
                    if (isRev)
                    {
                        r = JobChangeOrderContract.GetJobChangeOrderRev(recordID, revision).Tables[0].Rows[0];
                    }
                    else
                    {
                        r = JobChangeOrderContract.GetJobChangeOrder(recordID).Tables[0].Rows[0];
                    }
                }
                else
                {
                    r = JobChangeOrderContract.GetJobChangeOrderRev(recordID, revision).Tables[0].Rows[0];
                }
                string jobID = string.Empty;
                jobID = r["JobID"].ToString();
                txtJobChangeOrderNumber.Text = r["JobChangeOrderNumber"].ToString();
                txtJobChangeOrderRequestDate.EditValue = r["JobChangeOrderRequestDate"];
                txtJobChangeOrderRequestedAmount.EditValue = r["JobChangeOrderRequestedAmount"];
                txtJobChangeOrderApprovedDate.EditValue = r["JobChangeOrderApprovedDate"];
                txtJobChangeOrderApprovedAmount.EditValue = r["JobChangeOrderApprovedAmount"];
                cboJobChangeOrderStatus.Text = r["JobChangeOrderStatus"].ToString();
                cboJobChangeOrderDescription.Text = r["JobChangeOrderDescription"].ToString();
                txtJobChangeOrderOwnerNumber.EditValue = r["JobChangeOrderOwnerNumber"];
                txtJobChangeOrderCCENumber.EditValue = r["JobChangeOrderCCENumber"];
                txtJobChangeOrderUserDescription.Text = r["JobChangeOrderUserDescription"].ToString();
                txtChangeOrderAmount.EditValue = r["ChangeOrderAmount"];
                txtPriceAdjustment.EditValue = r["PriceAdjustment"];
                txtDirectMaterials.EditValue = r["DirectMaterials"];
                txtEstimatedBIMHours.EditValue = r["EstimatedBIMHours"];
                txtEstimatedApprenticeHours.EditValue = r["EstimatedApprenticeHours"];
                txtEstimatedElectricianHours.EditValue = r["EstimatedElectricianHours"];
                txtForemanDefaultHours.EditValue = r["ForemanDefaultHours"];
                txtGeneralForemanDefaultHours.EditValue = r["GeneralForemanDefaultHours"];
                txtSuperintendentDefaultHours.EditValue = r["SuperintendentDefaultHours"];
                txtProjectManagerDefaultHours.EditValue = r["ProjectManagerDefaultHours"];
                txtProjectEngineerDefaultHours.EditValue = r["ProjectEngineerDefaultHours"];
                txtForemanActualHours.EditValue = r["ForemanActualHours"];
                txtGeneralForemanActualHours.EditValue = r["GeneralForemanActualHours"];
                txtSuperintendentActualHours.EditValue = r["SuperintendentActualHours"];
                txtProjectManagerActualHours.EditValue = r["ProjectManagerActualHours"];
                txtProjectEngineerActualHours.EditValue = r["ProjectEngineerActualHours"];
                txtPremiumHoursActualHours.EditValue = r["PremiumHoursActualHours"];
                txtOtherExpenses1.EditValue = r["OtherExpenses1"];
                txtOtherExpenses2.EditValue = r["OtherExpenses2"];
                txtOtherExpenses3.EditValue = r["OtherExpenses3"];
                txtOtherExpenses1Description.Text = r["OtherExpenses1Description"].ToString();
                txtOtherExpenses2Description.Text = r["OtherExpenses2Description"].ToString();
                txtOtherExpenses3Description.Text = r["OtherExpenses3Description"].ToString();
                txtSubcontractsAmount.EditValue = r["SubcontractsAmount"];
                txtLaborHoursEstimateDefaults.EditValue = r["LaborHoursEstimateDefaults"];
                txtLaborDollarEstimateDefaults.EditValue = r["LaborDollarEstimateDefaults"];
                txtLaborRateEstimateDefaults.EditValue = r["LaborRateEstimateDefaults"];
                txtMaterialsEstimateDefaults.EditValue = r["MaterialsEstimateDefaults"];
                txtOtherEstimateDefaults.EditValue = r["OtherEstimateDefaults"];
                txtSubcontractsEstimateDefaults.EditValue = r["SubcontractsEstimateDefaults"];
                txtTotalCostEstimateDefaults.EditValue = r["TotalCostEstimateDefaults"];
                txtContractDollarEstimateDefaults.EditValue = r["ContractDollarEstimateDefaults"];
                txtProfitDollarEstimateDefaults.EditValue = r["ProfitDollarEstimateDefaults"];
                txtProfitPercentEstimateDefaults.EditValue = r["ProfitPercentEstimateDefaults"];
                txtLaborHoursBudgetTotals.EditValue = r["LaborHoursBudgetTotals"];
                txtLaborDollarBudgetTotals.EditValue = r["LaborDollarBudgetTotals"];
                txtLaborRateBudgetTotals.EditValue = r["LaborRateBudgetTotals"];
                txtMaterialsBudgetTotals.EditValue = r["MaterialsBudgetTotals"];
                txtOtherBudgetTotals.EditValue = r["OtherBudgetTotals"];
                txtSubcontractsBudgetTotals.EditValue = r["SubcontractsBudgetTotals"];
                txtTotalCostBudgetTotals.EditValue = r["TotalCostBudgetTotals"];
                txtContractDollarBudgetTotals.EditValue = r["ContractDollarBudgetTotals"];
                txtProfitDollarBudgetTotals.EditValue = r["ProfitDollarBudgetTotals"];
                txtProfitPercentBudgetTotals.EditValue = r["ProfitPercentBudgetTotals"];
                txtSundriesPercentOfMaterial.EditValue = r["SundriesPercentOfMaterial"];
                txtSalesTaxPercent.EditValue = r["SalesTaxPercent"];
                txtAsBuiltsEngineeringPercent.EditValue = r["AsBuiltsEngineeringPercent"];
                txtAsBuiltsEngineeringPercentText.Text = r["AsBuiltsEngineeringPercentText"].ToString();
                txtStoragePercent.EditValue = r["StoragePercent"];
                txtStoragePercentText.Text = r["storagePercentText"].ToString();
                txtSmallToolsPercent.EditValue = r["SmallToolsPercent"];
                txtSmallToolsPercentText.Text = r["smallToolsPercentText"].ToString();
                txtCartigeHandlingPercent.EditValue = r["CartigeHandlingPercent"];
                txtCartigeHandlingPercentText.Text = r["cartigeHandlingPercentText"].ToString();
                txtForemanPercentOfLabor.EditValue = r["ForemanPercentOfLabor"];
                txtGeneralForemanPercentOfLabor.EditValue = r["GeneralForemanPercentOfLabor"];
                txtSuperintendentPercentOfLabor.EditValue = r["SuperintendentPercentOfLabor"];
                txtProjectManagerPercentOfLabor.EditValue = r["ProjectManagerPercentOfLabor"];
                txtProjectEngineerPercentOfLabor.EditValue = r["ProjectEngineerPercentOfLabor"];
                txtSafetyMeetingPercent.EditValue = r["SafetyMeetingPercent"];
                txtFringeBenefitsPercent.EditValue = r["FringeBenefitsPercent"];
                txtOverheadPercent.EditValue = r["OverheadPercent"];
                txtOverheadPercentText.Text = r["overheadPercentText"].ToString();
                txtProfitPercent.EditValue = r["ProfitPercent"];
                txtProfitPercentText.Text = r["profitPercentText"].ToString();
                txtSubcontractAdministrationPercent.EditValue = r["SubcontractAdministrationPercent"];
                txtSubcontractAdministrationPercentText.Text = r["subcontractAdministrationPercentText"].ToString();
                txtWarrantyPercent.EditValue = r["WarrantyPercent"];
                txtWarrantyPercentText.Text = r["warrantyPercentText"].ToString();
                txtBondPercent.EditValue = r["BondPercent"];
                txtBondPercentText.Text = r["bondPercentText"].ToString();

                txtBIMRate.EditValue = r["BIMRate"];
                txtApprenticeLaborRate.EditValue = r["ApprenticeLaborRate"];
                txtElectricianLaborRate.EditValue = r["ElectricianLaborRate"];
                txtForemanLaborRate.EditValue = r["ForemanLaborRate"];
                txtGeneralForemanLaborRate.EditValue = r["GeneralForemanLaborRate"];
                txtSuperintendentLaborRate.EditValue = r["SuperintendentLaborRate"];
                txtProjectManagerLaborRate.EditValue = r["ProjectManagerLaborRate"];
                txtProjectEngineerLaborRate.EditValue = r["ProjectEngineerLaborRate"];
                txtSafetyMeetingsLaborRate.EditValue = r["SafetyMeetingsLaborRate"];
                txtPremiumTimeLaborRate.EditValue = r["PremiumTimeLaborRate"];

                txtLetterWorkDescription.Text = r["LetterWorkDescription"].ToString();
                txtLetterExclusion.Text = r["LetterExclusion"].ToString();
                txtLetterTimeExtension.EditValue = r["LetterTimeExtension"];
                cboContact.EditValue = r["ContactID"];
                txtFrom.Text = r["From"].ToString();

                txtBIMRateOT.EditValue = r["BIMRateOT"];
                txtApprenticeLaborRateOT.EditValue = r["ApprenticeLaborRateOT"];
                txtElectricianLaborRateOT.EditValue = r["ElectricianLaborRateOT"];
                txtForemanLaborRateOT.EditValue = r["ForemanLaborRateOT"];
                txtGeneralForemanLaborRateOT.EditValue = r["GeneralForemanLaborRateOT"];
                txtSuperintendentLaborRateOT.EditValue = r["SuperintendentLaborRateOT"];
                txtProjectManagerLaborRateOT.EditValue = r["ProjectManagerLaborRateOT"];
                txtProjectEngineerLaborRateOT.EditValue = r["ProjectEngineerLaborRateOT"];
                txtSafetyMeetingsLaborRateOT.EditValue = r["SafetyMeetingsLaborRateOT"];
                txtPremiumTimeLaborRateOT.EditValue = r["PremiumTimeLaborRateOT"];

                txtBIMRateDT.EditValue = r["BIMRateDT"];
                txtApprenticeLaborRateDT.EditValue = r["ApprenticeLaborRateDT"];
                txtElectricianLaborRateDT.EditValue = r["ElectricianLaborRateDT"];
                txtForemanLaborRateDT.EditValue = r["ForemanLaborRateDT"];
                txtGeneralForemanLaborRateDT.EditValue = r["GeneralForemanLaborRateDT"];
                txtSuperintendentLaborRateDT.EditValue = r["SuperintendentLaborRateDT"];
                txtProjectManagerLaborRateDT.EditValue = r["ProjectManagerLaborRateDT"];
                txtProjectEngineerLaborRateDT.EditValue = r["ProjectEngineerLaborRateDT"];
                txtSafetyMeetingsLaborRateDT.EditValue = r["SafetyMeetingsLaborRateDT"];
                txtPremiumTimeLaborRateDT.EditValue = r["PremiumTimeLaborRateDT"];

                txtEstimatedBIMHoursOT.EditValue = r["EstimatedBIMHoursOT"];

                txtEstimatedApprenticeHoursOT.EditValue = r["EstimatedApprenticeHoursOT"];
                txtEstimatedElectricianHoursOT.EditValue = r["EstimatedElectricianHoursOT"];

                txtEstimatedBIMHoursDT.EditValue = r["EstimatedBIMHoursDT"];
                txtEstimatedApprenticeHoursDT.EditValue = r["EstimatedApprenticeHoursDT"];
                txtEstimatedElectricianHoursDT.EditValue = r["EstimatedElectricianHoursDT"];

                txtForemanDefaultHoursOT.EditValue = r["ForemanDefaultHoursOT"];
                txtGeneralForemanDefaultHoursOT.EditValue = r["GeneralForemanDefaultHoursOT"];
                txtSuperintendentDefaultHoursOT.EditValue = r["SuperintendentDefaultHoursOT"];
                txtProjectManagerDefaultHoursOT.EditValue = r["ProjectManagerDefaultHoursOT"];
                txtProjectEngineerDefaultHoursOT.EditValue = r["ProjectEngineerDefaultHoursOT"];
                txtForemanDefaultHoursDT.EditValue = r["ForemanDefaultHoursDT"];
                txtGeneralForemanDefaultHoursDT.EditValue = r["GeneralForemanDefaultHoursDT"];
                txtSuperintendentDefaultHoursDT.EditValue = r["SuperintendentDefaultHoursDT"];
                txtProjectManagerDefaultHoursDT.EditValue = r["ProjectManagerDefaultHoursDT"];
                txtProjectEngineerDefaultHoursDT.EditValue = r["ProjectEngineerDefaultHoursDT"];
                txtForemanActualHoursOT.EditValue = r["ForemanActualHoursOT"];
                txtGeneralForemanActualHoursOT.EditValue = r["GeneralForemanActualHoursOT"];
                txtSuperintendentActualHoursOT.EditValue = r["SuperintendentActualHoursOT"];
                txtProjectManagerActualHoursOT.EditValue = r["ProjectManagerActualHoursOT"];
                txtProjectEngineerActualHoursOT.EditValue = r["ProjectEngineerActualHoursOT"];
                txtPremiumHoursActualHoursOT.EditValue = r["PremiumHoursActualHoursOT"];
                txtForemanActualHoursDT.EditValue = r["ForemanActualHoursDT"];
                txtGeneralForemanActualHoursDT.EditValue = r["GeneralForemanActualHoursDT"];
                txtSuperintendentActualHoursDT.EditValue = r["SuperintendentActualHoursDT"];
                txtProjectManagerActualHoursDT.EditValue = r["ProjectManagerActualHoursDT"];
                txtProjectEngineerActualHoursDT.EditValue = r["ProjectEngineerActualHoursDT"];
                txtPremiumHoursActualHoursDT.EditValue = r["PremiumHoursActualHoursDT"];

                float.TryParse(r["SundriesCost"].ToString(), out sundriesCost);
                float.TryParse(r["SalesTaxCost"].ToString(), out salesTaxCost);
                float.TryParse(r["ElectricianCost"].ToString(), out electricianCost);
                float.TryParse(r["ForemanCost"].ToString(), out foremanCost);
                float.TryParse(r["GeneralForemanCost"].ToString(), out generalForemanCost);
                float.TryParse(r["SuperintendentCost"].ToString(), out superintendentCost);
                float.TryParse(r["PremiumCost"].ToString(), out premiumCost);
                float.TryParse(r["FringeBenefitsCost"].ToString(), out fringeBenefitsCost);
                float.TryParse(r["SafetyMeetingsCost"].ToString(), out safetyMeetingsCost);
                float.TryParse(r["ProjectManagerCost"].ToString(), out projectManagerCost);
                float.TryParse(r["ProjectEngineerCost"].ToString(), out projectEngineerCost);
                float.TryParse(r["TotalLaborCost"].ToString(), out totalLaborCost);
                float.TryParse(r["AsBuiltsEngineeringCost"].ToString(), out asBuiltsEngineeringCost);
                float.TryParse(r["StorageCost"].ToString(), out storageCost);
                float.TryParse(r["SmallToolsCost"].ToString(), out smallToolsCost);
                float.TryParse(r["CartigeHandlingCost"].ToString(), out cartigeHandlingCost);
                float.TryParse(r["TotalExpensesCost"].ToString(), out totalExpensesCost);
                float.TryParse(r["MaterialsLaborExpensesCost"].ToString(), out materialsLaborExpensesCost);
                float.TryParse(r["OverheadCost"].ToString(), out overheadCost);
                float.TryParse(r["MaterialsLaborExpensesOverheadCost"].ToString(), out materialsLaborExpensesOverheadCost);
                float.TryParse(r["ProfitCost"].ToString(), out profitCost);
                float.TryParse(r["OverheadProfitCost"].ToString(), out overheadProfitCost);
                float.TryParse(r["SubcontractAdministrationCost"].ToString(), out subcontractAdministrationCost);
                float.TryParse(r["OverheadProfitSubcontractsAmountSubcontractAdministrationCost"].ToString(), out overheadProfitSubcontractsAmountSubcontractAdministrationCost);
                float.TryParse(r["WarrantyCost"].ToString(), out warrantyCost);
                float.TryParse(r["BondCost"].ToString(), out bondCost);

                // CRETAED BY ANU FOR DEFAULT LABOR RATE VALUES 

                //DataRow r1;
                //if (jobID.Trim().Length > 0)
                //    r1 = JobDefaultValues.GetJobDefaultValues(jobID).Tables[0].Rows[0];
                //else
                //    r1 = JobSystemDefaultValues.GetJobSystemDefaultValues().Tables[0].Rows[0];
                DataSet j = JobSystemDefaultValues.GetJobSystemDefaultValues();
                DataRow r1;
                r1 = j.Tables[0].Rows[0];
                //labelControl167.EditValue = string.IsNullOrEmpty(Convert.ToString(r[""])) ? r1["BIMRate_Label"].ToString().Trim() : r["BIMRate_Label"].ToString().Trim();
                if (r["BIMRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl167.Text = string.Empty; }
                else
                {
                    labelControl167.Text = Convert.ToString(r["BIMRate_Label"]).Trim();
                }
                //labelControl152.EditValue = string.IsNullOrEmpty(Convert.ToString(r[""])) ? r1["ApprenticeLaborRate_Label"].ToString().Trim() : r["ApprenticeLaborRate_Label"].ToString().Trim();
                if (r["ApprenticeLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl152.Text = string.Empty; }
                else
                {
                    labelControl152.Text = Convert.ToString(r["ApprenticeLaborRate_Label"]).Trim();
                }

                //labelControl119.EditValue = string.IsNullOrEmpty(Convert.ToString(r["ElectricianLaborRate_Label"])) ? r1["ElectricianLaborRate_Label"].ToString().Trim() : r["ElectricianLaborRate_Label"].ToString().Trim();
                if (r["ElectricianLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl119.Text = string.Empty; }
                else
                {
                    labelControl119.Text = Convert.ToString(r["ElectricianLaborRate_Label"]).Trim();
                }

               // labelControl118.EditValue = string.IsNullOrEmpty(Convert.ToString(r[""])) ? r1["ForemanLaborRate_Label"].ToString().Trim() : r["ForemanLaborRate_Label"].ToString().Trim();
                if (r["ForemanLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl118.Text = string.Empty; }
                else
                {
                    labelControl118.Text = Convert.ToString(r["ForemanLaborRate_Label"]).Trim();
                }

              //  labelControl117.EditValue = string.IsNullOrEmpty(Convert.ToString(r[""])) ? r1["GeneralForemanLaborRate_Label"].ToString().Trim() : r["GeneralForemanLaborRate_Label"].ToString().Trim();
                if (r["GeneralForemanLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl117.Text = string.Empty; }
                else
                {
                    labelControl117.Text = Convert.ToString(r["GeneralForemanLaborRate_Label"]).Trim();
                }

               // labelControl116.EditValue = string.IsNullOrEmpty(Convert.ToString(r[""])) ? r1["SuperintendentLaborRate_Label"].ToString().Trim() : r["SuperintendentLaborRate_Label"].ToString().Trim();
                if (r["SuperintendentLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl116.Text = string.Empty; }
                else
                {
                    labelControl116.Text = Convert.ToString(r["SuperintendentLaborRate_Label"]).Trim();
                }

                //labelControl115.EditValue = string.IsNullOrEmpty(Convert.ToString(r[""])) ? r1["ProjectManagerLaborRate_Label"].ToString().Trim() : r["ProjectManagerLaborRate_Label"].ToString().Trim();
                if (r["ProjectManagerLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl115.Text = string.Empty; }
                else
                {
                    labelControl115.Text = Convert.ToString(r["ProjectManagerLaborRate_Label"]).Trim();
                }

               // labelControl120.EditValue = string.IsNullOrEmpty(Convert.ToString(r["ProjectEngineerLaborRate_Label"])) ? r1["ProjectEngineerLaborRate_Label"].ToString().Trim() : r["ProjectEngineerLaborRate_Label"].ToString().Trim();
                if (r["ProjectEngineerLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl120.Text = string.Empty; }
                else
                {
                    labelControl120.Text = Convert.ToString(r["ProjectEngineerLaborRate_Label"]).Trim();
                }
                //labelControl114.EditValue = string.IsNullOrEmpty(Convert.ToString(r["SafetyMeetingsLaborRate_Label"])) ? string.Empty : r["SafetyMeetingsLaborRate_Label"].ToString().Trim();
                if (r["SafetyMeetingsLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl114.Text = string.Empty; }
                else
                {
                    labelControl114.Text = Convert.ToString(r["SafetyMeetingsLaborRate_Label"]).Trim();
                }
                //labelControl113.EditValue = string.IsNullOrEmpty(Convert.ToString(r[""])) ? r1["PremiumTimeLaborRate_Label"].ToString().Trim() : r["PremiumTimeLaborRate_Label"].ToString().Trim();
                if (r["PremiumTimeLaborRate_Label"].ToString().Trim() == "Null".ToString())
                { labelControl113.Text = string.Empty; }
                else
                {
                    labelControl113.Text = Convert.ToString(r["PremiumTimeLaborRate_Label"]).Trim();
                }

                //labelControl15.EditValue = string.IsNullOrEmpty(Convert.ToString(r[""])) ? r1["FringeBenefitsPercent_Label"].ToString().Trim() : r["FringeBenefitsPercent_Label"].ToString().Trim();
                if (r["FringeBenefitsPercent_Label"].ToString().Trim() == "Null".ToString())
                { labelControl15.Text = string.Empty; }
                else
                {
                    labelControl15.Text = Convert.ToString(r["FringeBenefitsPercent_Label"]).Trim();
                }

                // labelControl16.EditValue = string.IsNullOrEmpty(Convert.ToString(r["SafetyMeetingPercent_Label"])) ? r1["SafetyMeetingPercent_Label"].ToString().Trim() : r["SafetyMeetingPercent_Label"].ToString().Trim();
                if (r["SafetyMeetingPercent_Label"].ToString().Trim() == "Null".ToString())
                { labelControl16.Text = string.Empty; }
                else
                {labelControl16.Text = Convert.ToString(r["SafetyMeetingPercent_Label"]).Trim(); }

                // END
                if (r["JobChangeOrderNumber"].ToString().Trim() == "0" && r["JobChangeOrderRequestDate"].ToString().Trim() == "" && r["JobChangeOrderApprovedDate"].ToString().Trim() == "")
                {
                    GetJobDefaultValues();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //


        private void UpdateErrorMessages()
        {
            float requestedAmount = 0;
            float approvedAmount = 0;
            errorMessages = false;
            cboJobChangeOrderDescription.ErrorText = "";
            cboJobChangeOrderStatus.ErrorText = "";
            txtJobChangeOrderUserDescription.ErrorText = "";
            txtJobChangeOrderRequestDate.ErrorText = "";
            txtJobChangeOrderRequestedAmount.ErrorText = "";
            txtJobChangeOrderApprovedDate.ErrorText = "";
            txtJobChangeOrderApprovedAmount.ErrorText = "";
            cboContact.ErrorText = "";
            txtFrom.ErrorText = "";
            /* if (cboContact.EditValue == null)
             {
                 cboContact.ErrorText = "Contact is Required";
                 errorMessages = true;
             }
             */
            try
            {
                float.TryParse(txtJobChangeOrderApprovedAmount.EditValue.ToString(), out approvedAmount);
                float.TryParse(txtJobChangeOrderRequestedAmount.EditValue.ToString(), out requestedAmount);
            }
            catch { }
            if (requestedAmount == 0 && approvedAmount == 0)
            {
                txtJobChangeOrderRequestedAmount.ErrorText = "Requested Amount or Approved Amount is Required";
                txtJobChangeOrderApprovedAmount.ErrorText = "Requested Amount or Approved Amount is Required";
                errorMessages = true;
            }
            else
            {
                if (requestedAmount == 0)
                {
                    txtJobChangeOrderRequestDate.Text = "";
                }
                else
                {
                    if (txtJobChangeOrderRequestDate.Text.Trim() == "")
                    {
                        txtJobChangeOrderRequestDate.ErrorText = "Requested Date is Required";
                        errorMessages = true;
                    }
                }
                if (approvedAmount == 0)
                {
                    txtJobChangeOrderApprovedDate.Text = "";
                }
                else
                {
                    if (txtJobChangeOrderApprovedDate.Text.Trim() == "")
                    {
                        txtJobChangeOrderApprovedDate.ErrorText = "Approved Date is Required";
                        errorMessages = true;
                    }
                }
            }
            if (cboJobChangeOrderDescription.Text.Trim() == "")
            {
                cboJobChangeOrderDescription.ErrorText = "Status is Requried";
                errorMessages = true;
            }
            if (cboJobChangeOrderStatus.Text.Trim() == "")
            {
                cboJobChangeOrderStatus.ErrorText = "Pending/Approved is Required";
                errorMessages = true;
            }
            if (txtJobChangeOrderUserDescription.Text.Trim() == "")
            {
                txtJobChangeOrderUserDescription.ErrorText = "Description is Required";
                errorMessages = true;
            }


            //
            /*  if (txtFrom.Text.Trim() == "")
              {
                  txtFrom.ErrorText = "From is Required";
                  errorMessages = true;
              } */
        }
        //
        private void GetPhaseList()
        {
            if (jobID != "0" && jobID != "")
            {
                cboPhase.Properties.DataSource = JobCost.GetPhases(jobID);
                JobCost.GetPhases(jobID);
                cboPhase.Properties.DisplayMember = "PhaseDesc";
                cboPhase.Properties.ValueMember = "PhaseID";
                cboPhase.Properties.PopulateColumns();
                cboPhase.Properties.ShowHeader = false;
                cboPhase.Properties.Columns[0].Visible = false;
                cboPhase.Properties.Columns[2].Visible = false;
                cboPhase.Properties.Columns[3].Visible = false;
                cboPhase.Properties.Columns[0].Width = 0;
            }
        }
        //
        private void GetJobCostCodes(string jobChangeOrderID, string jobID)
        {
            try
            {
                if (!changeOrderStatus)
                {
                    if (isRev)
                    {
                        jobCodeDataSet = JobCost.GetCostCodeRev(jobChangeOrderID, jobID, revision);
                    }
                    else
                    {
                        jobCodeDataSet = JobCost.GetCostCode(jobChangeOrderID, jobID);
                    }
                }
                else
                {
                    jobCodeDataSet = JobCost.GetCostCodeRev(jobChangeOrderID, jobID, revision);
                }

                grdCostCode.DataSource = jobCodeDataSet.Tables[0].DefaultView;
                if (chkSelected.CheckState == CheckState.Checked)
                {
                    jobCodeDataSet.Tables[0].DefaultView.RowFilter = "Selected = True";
                }

                gridView1.Columns["Type"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Phase"].OptionsColumn.AllowEdit = false;


                gridView1.Columns["Phase"].Width = 150;
                gridView1.Columns["Code"].Width = 150;


                gridView1.Columns["Code"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Title"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Description"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["User Description"].ColumnEdit = txtUserDescription1;
                gridView1.Columns["Unit"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Unit"].ColumnEdit = RepositoryItems.unitOfMeasurements;
                gridView1.Columns["Unit"].Caption = "UOM";
                gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["JobCostCodeID"].Visible = false;
                gridView1.Columns["JobChangeOrderID"].Visible = false;
                gridView1.Columns["JobCostCodePhaseID"].Visible = false;
                gridView1.Columns["Cost $"].ColumnEdit = txtMaterialCost;
                gridView1.Columns["Cost $"].Width = 200;
                gridView1.Columns["Quantity"].ColumnEdit = txtQuantity;
                gridView1.Columns["Hours"].ColumnEdit = txtHours;
                // DevExpress.XtraGrid.GridColumnSummaryItem totalHours = new DevExpress.XtraGrid.GridColumnSummaryItem(gridView1.Columns["Hours"]);
                // totalHours.DisplayFormat = "n0";
                gridView1.Columns["Hours"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Hours"].SummaryItem.DisplayFormat = "{0:n0}";
                gridView1.Columns["Cost $"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Cost $"].SummaryItem.DisplayFormat = "{0:c2}";
                gridView1.Columns["Type"].Group();
                gridView1.ExpandAllGroups();
                gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded;
                gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Hours", gridView1.Columns["Hours"], "{0:n2}");
                gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Cost $", gridView1.Columns["Cost $"], "{0:c2}");

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            gridView1.BestFitColumns();
            gridView1.Columns["Title"].Width = 150;
            gridView1.Columns["Description"].Width = 150;
            gridView1.Columns["User Description"].Width = 150;
            gridView1.Columns["Cost $"].Width = 100;
            //try
            //{
            //    Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridView1, "frmChangeOrder");
            //}
            //catch (Exception ex)
            //{
            //    ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
            //    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            //}


        }
        private void SetControlAccess()
        {
            if (recordID == "" || recordID == "0")
            {
                gridView1.OptionsBehavior.Editable = false;
                chkSelected.Visible = false;
                panCostCodes.Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Unit"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Selected"].Visible = false;
            }
            else
            {
                //if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly || isRev)
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    gridView1.OptionsBehavior.Editable = false;
                    chkSelected.Visible = false;
                    panCostCodes.Visible = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Unit"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Selected"].Visible = false;
                }
                else
                {
                    gridView1.OptionsBehavior.Editable = true;
                    chkSelected.Visible = true;
                    panCostCodes.Visible = true;
                    gridView1.OptionsBehavior.Editable = true;
                    gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Hours"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Unit"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Selected"].Visible = true;
                }
            }
        }
        //
        private void GetOriginalPhaseList()
        {
            return;
            if (jobID != "0" && jobID != "")
            {
                try
                {
                    DataTable t = JobCost.GetOriginalPhaseCodes(jobID).Tables[0];

                    foreach (DataRow r in t.Rows)
                    {

                        string query = "Type = '" + r["Type"].ToString() + "' AND " +
                              " Phase = '" + r["Phase"].ToString() + "' AND " +
                              " Code = '" + r["Code"].ToString() + "' ";
                        DataRow[] m = jobCodeDataSet.Tables[0].Select(query);
                        if (m.Length == 0)
                        {
                            jobCodeDataSet.Tables[0].ImportRow(r);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }

        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPhase.EditValue != null)
                {
                    //var jobid = cboPhase.GetColumnValue("Job");
                    string phase = cboPhase.GetColumnValue("Phase").ToString();
                    DataTable t = JobCost.GetPhaseCodes(cboPhase.EditValue.ToString(), jobID, phase).Tables[0];

                    foreach (DataRow r in t.Rows)
                    {
                        {

                            string query = "Type = '" + r["Type"].ToString() + "' AND " +
                                  " Phase = '" + r["Phase"].ToString() + "' AND " +
                                  " Code = '" + r["Code"].ToString() + "' ";
                            DataRow[] m = jobCodeDataSet.Tables[0].Select(query);
                            if (m.Length == 0)
                            {
                                jobCodeDataSet.Tables[0].ImportRow(r);
                            }
                        }

                        cboPhase.EditValue = null;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private bool SaveJobCostCodes()
        {
            float laborHours = 0;
            float laborCost = 0;
            float materialCost = 0;
            float subcontractCost = 0;
            float otherCost = 0;
            bool update = false;
            if (!isUpdated)
            {
                return true;
            }

            DialogResult result;
            bool ret = true;
            result = MessageBox.Show("Save Cost Code Changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Cancel:
                    ret = false;
                    break;
                case DialogResult.No:
                    isUpdated = false;
                    GetJobCostCodes(recordID, jobID);
                    ret = true;
                    break;
                case DialogResult.Yes:
                    try
                    {
                        revision = cboRevision.Text.Trim();
                        string latestRevision = JobCost.GetLatestChangeOrderRevision(recordID);
                        if (latestRevision != revision)
                        {
                            JobCost.RemoveAllCostCodeFromChangeOrder(recordID);
                            //JobCost.RemoveAllCostCodeFromChangeOrderRev(recordID, revision);
                        }
                        Cursor = Cursors.AppStarting;
                        JobCost jobCost;
                        foreach (DataRow r in jobCodeDataSet.Tables[0].Rows)
                        {
                            // Update Record
                            update = false;
                            if (r["Selected"].ToString() == "True" && r["JobCostCodeID"].ToString() != "")
                            {
                                jobCost = new JobCost(r["JobCostCodeID"].ToString(),
                                                                        recordID,
                                                                        txtJobChangeOrderNumber.Text.Trim(),
                                                                        r["JobCostCodePhaseID"].ToString(),
                                                                        r["User Description"].ToString(),
                                                                        r["Unit"].ToString().Trim(),
                                                                        r["Quantity"].ToString(),
                                                                        r["Hours"].ToString(),
                                                                        r["Cost $"].ToString(),
                                                                        jobID,
                                                                        r["Type"].ToString(),
                                                                        r["Phase"].ToString(),
                                                                        r["Code"].ToString(),
                                                                        r["Title"].ToString(),
                                                                        r["Description"].ToString());
                                jobCost.Save(revision, changeOrderStatus);
                                if (changeOrderStatus)
                                {
                                    if (latestRevision == revision)
                                        jobCost.SaveRevisionCostCode(revision);
                                }

                                update = true;
                            }
                            // Delete Record
                            if (r["Selected"].ToString() != "True" && r["JobCostCodeID"].ToString() != "")
                            {
                                JobCost.Remove(r["JobCostCodeID"].ToString());
                                if (changeOrderStatus)
                                {
                                    if (latestRevision == revision)
                                        JobCost.RemoveRevisionCostCode(r["JobCostCodeID"].ToString(), revision);
                                }
                            }
                            // Insert Record
                            if (r["Selected"].ToString() == "True" && r["JobCostCodeID"].ToString() == "")
                            {
                                jobCost = new JobCost(r["JobCostCodeID"].ToString(),
                                                                         recordID,
                                                                         txtJobChangeOrderNumber.Text.Trim(),
                                                                         r["JobCostCodePhaseID"].ToString(),
                                                                          r["User Description"].ToString(),
                                                                          r["Unit"].ToString().Trim(),
                                                                         r["Quantity"].ToString(),
                                                                         r["Hours"].ToString(),
                                                                         r["Cost $"].ToString(),
                                                                         jobID,
                                                                         r["Type"].ToString(),
                                                                         r["Phase"].ToString(),
                                                                         r["Code"].ToString(),
                                                                         r["Title"].ToString(),
                                                                         r["Description"].ToString());
                                jobCost.Save(revision, changeOrderStatus);
                                if (changeOrderStatus)
                                {
                                    if (latestRevision == revision)
                                        jobCost.SaveRevisionCostCode(revision);
                                }

                                update = true;
                                r["JobCostCodeID"] = jobCost.JobCostCodeID;
                            }
                            if (update)
                            {
                                switch (r["Type"].ToString())
                                {
                                    case "L":
                                        laborHours += r["Hours"].ToString() == "" ? 0 : float.Parse(r["Hours"].ToString());
                                        laborCost += r["Cost $"].ToString() == "" ? 0 : float.Parse(r["Cost $"].ToString());
                                        break;
                                    case "M":
                                        materialCost += r["Cost $"].ToString() == "" ? 0 : float.Parse(r["Cost $"].ToString());
                                        break;
                                    case "S":
                                        subcontractCost += r["Cost $"].ToString() == "" ? 0 : float.Parse(r["Cost $"].ToString());
                                        break;
                                    case "O":
                                        otherCost += r["Cost $"].ToString() == "" ? 0 : float.Parse(r["Cost $"].ToString());
                                        break;
                                }
                            }
                        }
                        // Starbuilder
                        if (Convert.ToInt32(txtJobChangeOrderNumber.Text.Trim()) == 0)
                        {
                            JobChangeOrder.UpdatePrimaryContractCostCodes(jobID);
                        }
                        else
                        {
                            JobChangeOrder.UpdateChangeOrderCostCodes(jobID, txtJobChangeOrderNumber.Text.Trim());
                        }
                        txtLaborHoursBudgetTotals.EditValue = laborHours;
                        txtLaborDollarBudgetTotals.EditValue = laborCost;
                        txtMaterialsBudgetTotals.EditValue = materialCost;
                        txtSubcontractsBudgetTotals.EditValue = subcontractCost;
                        txtOtherBudgetTotals.EditValue = otherCost;
                        if (laborHours != 0)
                        {
                            txtLaborRateBudgetTotals.EditValue = (laborCost / laborHours);
                        }
                        else
                        {
                            txtLaborRateBudgetTotals.EditValue = 0;
                        }

                        txtTotalCostBudgetTotals.EditValue = laborCost + materialCost + subcontractCost + otherCost;
                        Cursor = Cursors.Default;
                        ret = true;
                    }
                    catch (Exception ex)
                    {
                        Cursor = Cursors.Default;
                        ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }

                    isUpdated = false;
                    break;
            }
            return ret;

        }
        //
        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            btnSaveCostCodes.Visible = true;
        }
        //
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            isUpdated = true;
            btnSaveCostCodes.Visible = true;
            if (e.Column.Caption == "Selected")
            {
                try
                {
                    DataRow dataRow = null;
                    dataRow = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);

                    if (dataRow["Selected"].ToString() == "True")
                    {
                        gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Hours"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                        gridView1.Columns["Unit"].OptionsColumn.AllowEdit = true;
                        if (dataRow["User Description"].ToString() == "")
                        {
                            dataRow["User Description"] = dataRow["Description"];
                        }
                    }
                    else
                    {
                        gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                        gridView1.Columns["Unit"].OptionsColumn.AllowEdit = false;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        //
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

            if (gridView1.SelectedRowsCount <= 0)
            {
                return;
            }

            try
            {
                DataRow dataRow = null;
                dataRow = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]);

                if (dataRow["Selected"].ToString() == "True")
                {
                    gridView1.Columns["User Description"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Hours"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = true;
                    if (dataRow["User Description"].ToString() == "")
                    {
                        dataRow["User Description"] = dataRow["Description"];
                    }
                }
                else
                {
                    gridView1.Columns["User Description"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Hours"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Quantity"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Cost $"].OptionsColumn.AllowEdit = false;
                }

            }
            catch (Exception)
            {
            }
        }
        //
        private void btnSaveCostCodes_Click(object sender, EventArgs e)
        {
            if (recordID == "0")
            {
                SaveChangeOrder();
            }
            SaveJobCostCodes();
            SaveChangeOrder();
            btnSaveCostCodes.Visible = false;
            isUpdated = false;
            dataChanged = false;
        }

        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (jobCodeDataSet != null)
            {
                if (chkSelected.Checked.ToString() == "True")
                {
                    jobCodeDataSet.Tables[0].DefaultView.RowFilter = "Selected = True ";
                }
                else
                {
                    jobCodeDataSet.Tables[0].DefaultView.RowFilter = "";
                }
            }
        }

        private void cboContact_EditValueChanged(object sender, EventArgs e)
        {
            if (cboContact.EditValue == null || cboContact.EditValue.ToString().Trim() == "")
            {
                txtCompany.Text = "";
            }
            else
            {
                int i = 0;
                contact.DefaultView.Sort = "ContactID";
                i = contact.DefaultView.Find(cboContact.EditValue.ToString());
                if (i != -1)
                {
                    txtCompany.Text = contact.DefaultView[i][2].ToString();
                }
                else
                {
                    txtCompany.Text = "";
                }
            }

            AllControls_EditValue(sender, e);
        }

        private void gridView1_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void cboRevision_SelectedIndexChanged(object sender, EventArgs e)
        {
            revision = "";

            if (!changeOrderStatus)
            {
                if (cboRevision.Text.Trim().Length > 0)
                {
                    isRev = true;
                    revision = cboRevision.Text.Trim();
                }
                else
                {
                    isRev = false;
                }
            }
            else
            {
                revision = cboRevision.Text.Trim();
            }

            GetChangeOrder(true);
        }

        private void labelControl146_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtLetterWorkDescription.Text;
            f.ShowDialog();
            txtLetterWorkDescription.Text = f.MyText;
            UpdateDataChange();
        }

        private void labelControl147_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtLetterExclusion.Text;
            f.ShowDialog();
            txtLetterExclusion.Text = f.MyText;
            UpdateDataChange();
        }
        private void UpdateDataChange()
        {
            dataChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void labelControl167_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl152_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl119_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl118_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl117_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl116_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl115_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl120_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl114_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

        private void labelControl113_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }
        // starts from here 

        string strlabelControl16 = string.Empty;
        string strlabelControl15 = string.Empty;
        string strlabelControl167 = string.Empty;
        string strlabelControl152 = string.Empty;
        string strlabelControl119 = string.Empty;
        string strlabelControl118 = string.Empty;
        string strlabelControl117 = string.Empty;
        string strlabelControl116 = string.Empty;
        string strlabelControl115 = string.Empty;
        string strlabelControl120 = string.Empty;
        string strlabelControl114 = string.Empty;
        string strlabelControl113 = string.Empty;

        private void labelControl167_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl167 = labelControl167.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl167.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl167_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl167.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl167.Text = strlabelControl167;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void labelControl152_KeyPress(object sender, KeyPressEventArgs e)
        {
            strlabelControl152 = labelControl152.Text;
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl152.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void labelControl152_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                if ((Convert.ToDecimal(labelControl152.Text.Length) > 27))
                {
                    MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    labelControl152.Text = strlabelControl152;
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

        private void labelControl119_KeyUp(object sender, KeyEventArgs e)
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

        private void labelControl118_KeyUp(object sender, KeyEventArgs e)
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
        private void labelControl117_KeyUp(object sender, KeyEventArgs e)
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

        private void labelControl116_KeyUp(object sender, KeyEventArgs e)
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
            if ((Convert.ToDecimal(labelControl115.Text.Length) > 27))
            {
                MessageBox.Show("Value should not exceed 27 characters.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                e.Handled = true;
                return;
            }
        }

        private void labelControl115_KeyUp(object sender, KeyEventArgs e)
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

        private void labelControl120_KeyUp(object sender, KeyEventArgs e)
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

        private void labelControl114_KeyUp(object sender, KeyEventArgs e)
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

        private void labelControl113_KeyUp(object sender, KeyEventArgs e)
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
        private void labelControl16_KeyUp(object sender, KeyEventArgs e)
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

        private void labelControl16_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
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
        private void labelControl15_KeyUp(object sender, KeyEventArgs e)
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

        private void labelControl15_TextChanged(object sender, EventArgs e)
        {
            UpdateDataChange();
        }

    }
}