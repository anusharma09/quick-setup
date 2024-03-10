using ContraCostaElectric.DatabaseUtil;
using System;
using System.Data;
using System.Data.SqlClient;


namespace JCCBusinessLayer
{
    public class JobChangeOrderContract
    {
        private string jobChangeOrderID;
        private readonly string jobID;
        private string jobChangeOrderNumber;
        private readonly string jobChangeOrderRequestDate;
        private readonly string jobChangeOrderRequestedAmount;
        private readonly string jobChangeOrderApprovedDate;
        private readonly string jobChangeOrderApprovedAmount;
        private readonly string jobChangeOrderStatus;
        private readonly string jobChangeOrderDescription;
        private readonly string jobChangeOrderUpdateFlag;
        private readonly string jobChangeOrderLastUpdateDate;
        private readonly string jobChangeOrderOwnerNumber;
        private readonly string jobChangeOrderCCENumber;
        private readonly string jobChangeOrderUserDescription;

        private readonly string changeOrderAmount;
        private readonly string priceAdjustment;
        private readonly string directMaterials;

        private readonly string estimatedBIMHours;
        private readonly string estimatedApprenticeHours;
        private readonly string estimatedElectricianHours;
        private readonly string foremanDefaultHours;
        private readonly string generalForemanDefaultHours;
        private readonly string superintendentDefaultHours;
        private readonly string projectManagerDefaultHours;
        private readonly string projectEngineerDefaultHours;
        private readonly string foremanActualHours;
        private readonly string generalForemanActualHours;
        private readonly string superintendentActualHours;
        private readonly string projectManagerActualHours;
        private readonly string projectEngineerActualHours;
        private readonly string premiumHoursActualHours;
        private readonly string otherExpenses1;
        private readonly string otherExpenses2;
        private readonly string otherExpenses3;
        private readonly string otherExpenses1Description;
        private readonly string otherExpenses2Description;
        private readonly string otherExpenses3Description;
        private readonly string subcontractsAmount;
        private readonly string laborHoursEstimateDefaults;
        private readonly string laborDollarEstimateDefaults;
        private readonly string laborRateEstimateDefaults;
        private readonly string materialsEstimateDefaults;
        private readonly string otherEstimateDefaults;
        private readonly string subcontractsEstimateDefaults;
        private readonly string totalCostEstimateDefaults;
        private readonly string contractDollarEstimateDefaults;
        private readonly string profitDollarEstimateDefaults;
        private readonly string profitPercentEstimateDefaults;
        private readonly string laborHoursBudgetTotals;
        private readonly string laborDollarBudgetTotals;
        private readonly string laborRateBudgetTotals;
        private readonly string materialsBudgetTotals;
        private readonly string otherBudgetTotals;
        private readonly string subcontractsBudgetTotals;
        private readonly string totalCostBudgetTotals;
        private readonly string contractDollarBudgetTotals;
        private readonly string profitDollarBudgetTotals;
        private readonly string profitPercentBudgetTotals;
        private readonly string sundriesPercentOfMaterial;
        private readonly string salesTaxPercent;
        private readonly string asBuiltsEngineeringPercent;
        private readonly string storagePercent;
        private readonly string smallToolsPercent;
        private readonly string cartigeHandlingPercent;
        private readonly string foremanPercentOfLabor;
        private readonly string generalForemanPercentOfLabor;
        private readonly string superintendentPercentOfLabor;
        private readonly string projectManagerPercentOfLabor;
        private readonly string projectEngineerPercentOfLabor;
        private readonly string safetyMeetingPercent;
        private readonly string fringeBenefitsPercent;
        private readonly string overheadPercent;
        private readonly string profitPercent;
        private readonly string subcontractAdministrationPercent;
        private readonly string warrantyPercent;
        private readonly string bondPercent;

        private readonly string BIMRate;
        private readonly string apprenticeLaborRate;
        private readonly string electricianLaborRate;
        private readonly string foremanLaborRate;
        private readonly string generalForemanLaborRate;
        private readonly string superintendentLaborRate;
        private readonly string projectManagerLaborRate;
        private readonly string projectEngineerLaborRate;
        private readonly string safetyMeetingsLaborRate;
        private readonly string premiumTimeLaborRate;

        private readonly string sundriesCost;
        private readonly string salesTaxCost;
        private readonly string BIMCost;
        private readonly string apprenticeCost;
        private readonly string electricianCost;
        private readonly string foremanCost;
        private readonly string generalForemanCost;
        private readonly string superintendentCost;
        private readonly string premiumCost;
        private readonly string fringeBenefitsCost;
        private readonly string safetyMeetingsCost;
        private readonly string projectManagerCost;
        private readonly string projectEngineerCost;
        private readonly string totalLaborCost;
        private readonly string asBuiltsEngineeringCost;
        private readonly string storageCost;
        private readonly string smallToolsCost;
        private readonly string cartigeHandlingCost;
        private readonly string totalExpensesCost;
        private readonly string materialsLaborExpensesCost;
        private readonly string overheadCost;
        private readonly string materialsLaborExpensesOverheadCost;
        private readonly string profitCost;
        private readonly string overheadProfitCost;
        private readonly string subcontractAdministrationCost;
        private readonly string overheadProfitSubcontractsAmountSubcontractAdministrationCost;
        private readonly string warrantyCost;
        private readonly string bondCost;
        private readonly string letterWorkDescription;
        private readonly string letterExclusion;
        private readonly string letterTimeExtension;
        private readonly string contactID;
        private readonly string from;

        private readonly string BIMRateOT;
        private readonly string apprenticeLaborRateOT;
        private readonly string electricianLaborRateOT;
        private readonly string foremanLaborRateOT;
        private readonly string generalForemanLaborRateOT;
        private readonly string superintendentLaborRateOT;
        private readonly string projectManagerLaborRateOT;
        private readonly string projectEngineerLaborRateOT;
        private readonly string safetyMeetingsLaborRateOT;
        private readonly string premiumTimeLaborRateOT;

        private readonly string BIMRateDT;
        private readonly string apprenticeLaborRateDT;
        private readonly string electricianLaborRateDT;
        private readonly string foremanLaborRateDT;
        private readonly string generalForemanLaborRateDT;
        private readonly string superintendentLaborRateDT;
        private readonly string projectManagerLaborRateDT;
        private readonly string projectEngineerLaborRateDT;
        private readonly string safetyMeetingsLaborRateDT;
        private readonly string premiumTimeLaborRateDT;

        private readonly string estimatedBIMHoursOT;
        private readonly string estimatedApprenticeHoursOT;
        private readonly string estimatedElectricianHoursOT;

        private readonly string estimatedBIMHoursDT;
        private readonly string estimatedApprenticeHoursDT;
        private readonly string estimatedElectricianHoursDT;

        private readonly string foremanDefaultHoursOT;
        private readonly string generalForemanDefaultHoursOT;
        private readonly string superintendentDefaultHoursOT;
        private readonly string projectManagerDefaultHoursOT;
        private readonly string projectEngineerDefaultHoursOT;
        private readonly string foremanDefaultHoursDT;
        private readonly string generalForemanDefaultHoursDT;
        private readonly string superintendentDefaultHoursDT;
        private readonly string projectManagerDefaultHoursDT;
        private readonly string projectEngineerDefaultHoursDT;
        private readonly string foremanActualHoursOT;
        private readonly string generalForemanActualHoursOT;
        private readonly string superintendentActualHoursOT;
        private readonly string projectManagerActualHoursOT;
        private readonly string projectEngineerActualHoursOT;
        private readonly string premiumHoursActualHoursOT;
        private readonly string foremanActualHoursDT;
        private readonly string generalForemanActualHoursDT;
        private readonly string superintendentActualHoursDT;
        private readonly string projectManagerActualHoursDT;
        private readonly string projectEngineerActualHoursDT;
        private readonly string premiumHoursActualHoursDT;

        private readonly string asBuiltsEngineeringPercentText;
        private readonly string storagePercentText;
        private readonly string smallToolsPercentText;
        private readonly string cartigeHandlingPercentText;
        private readonly string overheadPercentText;
        private readonly string profitPercentText;
        private readonly string subcontractAdministrationPercentText;
        private readonly string warrantyPercentText;
        private readonly string bondPercentText;

        private readonly string BIMRate_Label;
        private readonly string apprenticeLaborRate_Label;
        private readonly string electricianLaborRate_Label;
        private readonly string foremanLaborRate_Label;
        private readonly string generalForemanLaborRate_Label;
        private readonly string superintendentLaborRate_Label;
        private readonly string projectManagerLaborRate_Label;
        private readonly string projectEngineerLaborRate_Label;
        private readonly string safetyMeetingsLaborRate_Label;
        private readonly string premiumTimeLaborRate_Label;
        private readonly string FringeBenefitsPercent_Label;
        private readonly string SafetyMeetingPercent_Label;


        public string JobChangeOrderID => jobChangeOrderID;

        public string JobChangeOrderNumber => jobChangeOrderNumber;

        public JobChangeOrderContract()
        {
        }
        public JobChangeOrderContract(string jobChangeOrderID,
                                string jobID,
                                string jobChangeOrderNumber,
                                string jobChangeOrderRequestDate,
                                string jobChangeOrderRequestedAmount,
                                string jobChangeOrderApprovedDate,
                                string jobChangeOrderApprovedAmount,
                                string jobChangeOrderStatus,
                                string jobChangeOrderDescription,
                                string jobChangeOrderOwnerNumber,
                                string jobChangeOrderCCENumber,
                                string jobChangeOrderUserDescription,
                                string changeOrderAmount,
                                string priceAdjustment,
                                string directMaterials,

                                string estimatedBIMHours,
                                string estimatedApprenticeHours,
                                string estimatedElectricianHours,
                                string foremanDefaultHours,
                                string generalForemanDefaultHours,
                                string superintendentDefaultHours,
                                string projectManagerDefaultHours,
                                string projectEngineerDefaultHours,
                                string foremanActualHours,
                                string generalForemanActualHours,
                                string superintendentActualHours,
                                string projectManagerActualHours,
                                string projectEngineerActualHours,
                                string premiumHoursActualHours,
                                string otherExpenses1,
                                string otherExpenses2,
                                string otherExpenses3,
                                string otherExpenses1Description,
                                string otherExpenses2Description,
                                string otherExpenses3Description,
                                string subcontractsAmount,
                                string laborHoursEstimateDefaults,
                                string laborDollarEstimateDefaults,
                                string laborRateEstimateDefaults,
                                string materialsEstimateDefaults,
                                string otherEstimateDefaults,
                                string subcontractsEstimateDefaults,
                                string totalCostEstimateDefaults,
                                string contractDollarEstimateDefaults,
                                string profitDollarEstimateDefaults,
                                string profitPercentEstimateDefaults,
                                string laborHoursBudgetTotals,
                                string laborDollarBudgetTotals,
                                string laborRateBudgetTotals,
                                string materialsBudgetTotals,
                                string otherBudgetTotals,
                                string subcontractsBudgetTotals,
                                string totalCostBudgetTotals,
                                string contractDollarBudgetTotals,
                                string profitDollarBudgetTotals,
                                string profitPercentBudgetTotals,
                                string sundriesPercentOfMaterial,
                                string salesTaxPercent,
                                string asBuiltsEngineeringPercent,
                                string storagePercent,
                                string smallToolsPercent,
                                string cartigeHandlingPercent,
                                string foremanPercentOfLabor,
                                string generalForemanPercentOfLabor,
                                string superintendentPercentOfLabor,
                                string projectManagerPercentOfLabor,
                                string projectEngineerPercentOfLabor,
                                string safetyMeetingPercent,
                                string fringeBenefitsPercent,
                                string overheadPercent,
                                string profitPercent,
                                string subcontractAdministrationPercent,
                                string warrantyPercent,
                                string bondPercent,
                                string BIMRate,
                                string apprenticeLaborRate,
                                string electricianLaborRate,
                                string foremanLaborRate,
                                string generalForemanLaborRate,
                                string superintendentLaborRate,
                                string projectManagerLaborRate,
                                string projectEngineerLaborRate,
                                string safetyMeetingsLaborRate,
                                string premiumTimeLaborRate,
                                string sundriesCost,
                                string salesTaxCost,
                                string BIMCost,
                                string apprenticeCost,
                                string electricianCost,
                                string foremanCost,
                                string generalForemanCost,
                                string superintendentCost,
                                string premiumCost,
                                string fringeBenefitsCost,
                                string safetyMeetingsCost,
                                string projectManagerCost,
                                string projectEngineerCost,
                                string totalLaborCost,
                                string asBuiltsEngineeringCost,
                                string storageCost,
                                string smallToolsCost,
                                string cartigeHandlingCost,
                                string totalExpensesCost,
                                string materialsLaborExpensesCost,
                                string overheadCost,
                                string materialsLaborExpensesOverheadCost,
                                string profitCost,
                                string overheadProfitCost,
                                string subcontractAdministrationCost,
                                string overheadProfitSubcontractsAmountSubcontractAdministrationCost,
                                string warrantyCost,
                                string bondCost,
                                string letterWorkDescription,
                                string letterExclusion,
                                string letterTimeExtension,
                                string contactID,
                                string from,

                                string BIMRateOT,
                                string apprenticeLaborRateOT,
                                string electricianLaborRateOT,
                                string foremanLaborRateOT,
                                string generalForemanLaborRateOT,
                                string superintendentLaborRateOT,
                                string projectManagerLaborRateOT,
                                string projectEngineerLaborRateOT,
                                string safetyMeetingsLaborRateOT,
                                string premiumTimeLaborRateOT,

                                string BIMRateDT,
                                string apprenticeLaborRateDT,
                                string electricianLaborRateDT,
                                string foremanLaborRateDT,
                                string generalForemanLaborRateDT,
                                string superintendentLaborRateDT,
                                string projectManagerLaborRateDT,
                                string projectEngineerLaborRateDT,
                                string safetyMeetingsLaborRateDT,
                                string premiumTimeLaborRateDT,

                                string estimatedBIMHoursOT,
                                string estimatedApprenticeHoursOT,
                                string estimatedElectricianHoursOT,

                                string estimatedBIMHoursDT,
                                string estimatedApprenticeHoursDT,
                                string estimatedElectricianHoursDT,
                                string foremanDefaultHoursOT,
                                string generalForemanDefaultHoursOT,
                                string superintendentDefaultHoursOT,
                                string projectManagerDefaultHoursOT,
                                string projectEngineerDefaultHoursOT,
                                string foremanDefaultHoursDT,
                                string generalForemanDefaultHoursDT,
                                string superintendentDefaultHoursDT,
                                string projectManagerDefaultHoursDT,
                                string projectEngineerDefaultHoursDT,
                                string foremanActualHoursOT,
                                string generalForemanActualHoursOT,
                                string superintendentActualHoursOT,
                                string projectManagerActualHoursOT,
                                string projectEngineerActualHoursOT,
                                string premiumHoursActualHoursOT,
                                string foremanActualHoursDT,
                                string generalForemanActualHoursDT,
                                string superintendentActualHoursDT,
                                string projectManagerActualHoursDT,
                                string projectEngineerActualHoursDT,
                                string premiumHoursActualHoursDT,
                                string asBuiltsEngineeringPercentText,
                                string storagePercentText,
                                string smallToolsPercentText,
                                string cartigeHandlingPercentText,
                                string overheadPercentText,
                                string profitPercentText,
                                string subcontractAdministrationPercentText,
                                string warrantyPercentText,
                                string bondPercentText,

                              string BIMRate_Label,
                              string apprenticeLaborRate_Label,
                              string electricianLaborRate_Label,
                              string foremanLaborRate_Label,
                              string generalForemanLaborRate_Label,
                              string superintendentLaborRate_Label,
                              string projectManagerLaborRate_Label,
                              string projectEngineerLaborRate_Label,
                              string safetyMeetingsLaborRate_Label,
                               string premiumTimeLaborRate_Label,
                               string FringeBenefitsPercent_Label,
           string SafetyMeetingPercent_Label

                                )
        {
            this.jobChangeOrderID = jobChangeOrderID;
            this.jobID = jobID;
            this.jobChangeOrderNumber = jobChangeOrderNumber;
            this.jobChangeOrderRequestDate = String.IsNullOrEmpty(jobChangeOrderRequestDate) ? "null" : "'" + jobChangeOrderRequestDate + "'";
            this.jobChangeOrderRequestedAmount = String.IsNullOrEmpty(jobChangeOrderRequestedAmount) ? "Null" : jobChangeOrderRequestedAmount;
            this.jobChangeOrderApprovedDate = String.IsNullOrEmpty(jobChangeOrderApprovedDate) ? "null" : "'" + jobChangeOrderApprovedDate + "'";
            this.jobChangeOrderApprovedAmount = String.IsNullOrEmpty(jobChangeOrderApprovedAmount) ? "Null" : jobChangeOrderApprovedAmount;
            this.jobChangeOrderStatus = jobChangeOrderStatus.Trim().ToUpper().Replace("'", "''");
            this.jobChangeOrderDescription = jobChangeOrderDescription.Trim().ToUpper().Replace("'", "''");
            this.jobChangeOrderOwnerNumber = jobChangeOrderOwnerNumber.Trim().ToUpper().Replace("'", "''");
            this.jobChangeOrderCCENumber = jobChangeOrderCCENumber.Trim().ToUpper().Replace("'", "''");
            this.jobChangeOrderUserDescription = jobChangeOrderUserDescription.Trim().ToUpper().Replace("'", "''");
            jobChangeOrderLastUpdateDate = DateTime.Today.ToString();
            if (this.jobChangeOrderID == "")
            {
                jobChangeOrderUpdateFlag = "0";
            }
            else
            {
                jobChangeOrderUpdateFlag = "1";
            }

            this.changeOrderAmount = String.IsNullOrEmpty(changeOrderAmount) ? "Null" : changeOrderAmount;
            this.priceAdjustment = String.IsNullOrEmpty(priceAdjustment) ? "Null" : priceAdjustment;
            this.directMaterials = String.IsNullOrEmpty(directMaterials) ? "Null" : directMaterials;

            this.estimatedBIMHours = String.IsNullOrEmpty(estimatedBIMHours) ? "Null" : estimatedBIMHours;

            this.estimatedApprenticeHours = String.IsNullOrEmpty(estimatedApprenticeHours) ? "Null" : estimatedApprenticeHours;
            this.estimatedElectricianHours = String.IsNullOrEmpty(estimatedElectricianHours) ? "Null" : estimatedElectricianHours;
            this.foremanDefaultHours = String.IsNullOrEmpty(foremanDefaultHours) ? "Null" : foremanDefaultHours;
            this.generalForemanDefaultHours = String.IsNullOrEmpty(generalForemanDefaultHours) ? "Null" : generalForemanDefaultHours;
            this.superintendentDefaultHours = String.IsNullOrEmpty(superintendentDefaultHours) ? "Null" : superintendentDefaultHours;
            this.projectManagerDefaultHours = String.IsNullOrEmpty(projectManagerDefaultHours) ? "Null" : projectManagerDefaultHours;
            this.projectEngineerDefaultHours = String.IsNullOrEmpty(projectEngineerDefaultHours) ? "Null" : projectEngineerDefaultHours;
            this.foremanActualHours = String.IsNullOrEmpty(foremanActualHours) ? "Null" : foremanActualHours;
            this.generalForemanActualHours = String.IsNullOrEmpty(generalForemanActualHours) ? "Null" : generalForemanActualHours;
            this.superintendentActualHours = String.IsNullOrEmpty(superintendentActualHours) ? "Null" : superintendentActualHours;
            this.projectManagerActualHours = String.IsNullOrEmpty(projectManagerActualHours) ? "Null" : projectManagerActualHours;
            this.projectEngineerActualHours = String.IsNullOrEmpty(projectEngineerActualHours) ? "Null" : projectEngineerActualHours;
            this.premiumHoursActualHours = String.IsNullOrEmpty(premiumHoursActualHours) ? "Null" : premiumHoursActualHours;
            this.otherExpenses1 = String.IsNullOrEmpty(otherExpenses1) ? "Null" : otherExpenses1;
            this.otherExpenses2 = String.IsNullOrEmpty(otherExpenses2) ? "Null" : otherExpenses2;
            this.otherExpenses3 = String.IsNullOrEmpty(otherExpenses3) ? "Null" : otherExpenses3;
            this.otherExpenses1Description = otherExpenses1Description.Trim().Replace("'", "''");
            this.otherExpenses2Description = otherExpenses2Description.Trim().Replace("'", "''");
            this.otherExpenses3Description = otherExpenses3Description.Trim().Replace("'", "''");
            this.subcontractsAmount = String.IsNullOrEmpty(subcontractsAmount) ? "Null" : subcontractsAmount;
            this.laborHoursEstimateDefaults = String.IsNullOrEmpty(laborHoursEstimateDefaults) ? "Null" : laborHoursEstimateDefaults;
            this.laborDollarEstimateDefaults = String.IsNullOrEmpty(laborDollarEstimateDefaults) ? "Null" : laborDollarEstimateDefaults;
            this.laborRateEstimateDefaults = String.IsNullOrEmpty(laborRateEstimateDefaults) ? "Null" : laborRateEstimateDefaults;
            this.materialsEstimateDefaults = String.IsNullOrEmpty(materialsEstimateDefaults) ? "Null" : materialsEstimateDefaults;
            this.otherEstimateDefaults = String.IsNullOrEmpty(otherEstimateDefaults) ? "Null" : otherEstimateDefaults;
            this.subcontractsEstimateDefaults = String.IsNullOrEmpty(subcontractsEstimateDefaults) ? "Null" : subcontractsEstimateDefaults;
            this.totalCostEstimateDefaults = String.IsNullOrEmpty(totalCostEstimateDefaults) ? "Null" : totalCostEstimateDefaults;
            this.contractDollarEstimateDefaults = String.IsNullOrEmpty(contractDollarEstimateDefaults) ? "Null" : contractDollarEstimateDefaults;
            this.profitDollarEstimateDefaults = String.IsNullOrEmpty(profitDollarEstimateDefaults) ? "Null" : profitDollarEstimateDefaults;
            this.profitPercentEstimateDefaults = String.IsNullOrEmpty(profitPercentEstimateDefaults) ? "Null" : profitPercentEstimateDefaults;
            this.laborHoursBudgetTotals = String.IsNullOrEmpty(laborHoursBudgetTotals) ? "Null" : laborHoursBudgetTotals;
            this.laborDollarBudgetTotals = String.IsNullOrEmpty(laborDollarBudgetTotals) ? "Null" : laborDollarBudgetTotals;
            this.laborRateBudgetTotals = String.IsNullOrEmpty(laborRateBudgetTotals) ? "Null" : laborRateBudgetTotals;
            this.materialsBudgetTotals = String.IsNullOrEmpty(materialsBudgetTotals) ? "Null" : materialsBudgetTotals;
            this.otherBudgetTotals = String.IsNullOrEmpty(otherBudgetTotals) ? "Null" : otherBudgetTotals;
            this.subcontractsBudgetTotals = String.IsNullOrEmpty(subcontractsBudgetTotals) ? "Null" : subcontractsBudgetTotals;
            this.totalCostBudgetTotals = String.IsNullOrEmpty(totalCostBudgetTotals) ? "Null" : totalCostBudgetTotals;
            this.contractDollarBudgetTotals = String.IsNullOrEmpty(contractDollarBudgetTotals) ? "Null" : contractDollarBudgetTotals;
            this.profitDollarBudgetTotals = String.IsNullOrEmpty(profitDollarBudgetTotals) ? "Null" : profitDollarBudgetTotals;
            this.profitPercentBudgetTotals = String.IsNullOrEmpty(profitPercentBudgetTotals) ? "Null" : profitPercentBudgetTotals;
            this.sundriesPercentOfMaterial = String.IsNullOrEmpty(sundriesPercentOfMaterial) ? "Null" : sundriesPercentOfMaterial;
            this.salesTaxPercent = String.IsNullOrEmpty(salesTaxPercent) ? "Null" : salesTaxPercent;
            this.asBuiltsEngineeringPercent = String.IsNullOrEmpty(asBuiltsEngineeringPercent) ? "Null" : asBuiltsEngineeringPercent;
            this.storagePercent = String.IsNullOrEmpty(storagePercent) ? "Null" : storagePercent;
            this.smallToolsPercent = String.IsNullOrEmpty(smallToolsPercent) ? "Null" : smallToolsPercent;
            this.cartigeHandlingPercent = String.IsNullOrEmpty(cartigeHandlingPercent) ? "Null" : cartigeHandlingPercent;
            this.foremanPercentOfLabor = String.IsNullOrEmpty(foremanPercentOfLabor) ? "Null" : foremanPercentOfLabor;
            this.generalForemanPercentOfLabor = String.IsNullOrEmpty(generalForemanPercentOfLabor) ? "Null" : generalForemanPercentOfLabor;
            this.superintendentPercentOfLabor = String.IsNullOrEmpty(superintendentPercentOfLabor) ? "Null" : superintendentPercentOfLabor;
            this.projectManagerPercentOfLabor = String.IsNullOrEmpty(projectManagerPercentOfLabor) ? "Null" : projectManagerPercentOfLabor;
            this.projectEngineerPercentOfLabor = String.IsNullOrEmpty(projectEngineerPercentOfLabor) ? "Null" : projectEngineerPercentOfLabor;
            this.safetyMeetingPercent = String.IsNullOrEmpty(safetyMeetingPercent) ? "Null" : safetyMeetingPercent;
            this.fringeBenefitsPercent = String.IsNullOrEmpty(fringeBenefitsPercent) ? "Null" : fringeBenefitsPercent;
            this.overheadPercent = String.IsNullOrEmpty(overheadPercent) ? "Null" : overheadPercent;
            this.profitPercent = String.IsNullOrEmpty(profitPercent) ? "Null" : profitPercent;
            this.subcontractAdministrationPercent = String.IsNullOrEmpty(subcontractAdministrationPercent) ? "Null" : subcontractAdministrationPercent;
            this.warrantyPercent = String.IsNullOrEmpty(warrantyPercent) ? "Null" : warrantyPercent;
            this.bondPercent = String.IsNullOrEmpty(bondPercent) ? "Null" : bondPercent;


            this.BIMRate = String.IsNullOrEmpty(BIMRate) ? "Null" : BIMRate;

            this.apprenticeLaborRate = String.IsNullOrEmpty(apprenticeLaborRate) ? "Null" : apprenticeLaborRate;
            this.electricianLaborRate = String.IsNullOrEmpty(electricianLaborRate) ? "Null" : electricianLaborRate;
            this.foremanLaborRate = String.IsNullOrEmpty(foremanLaborRate) ? "Null" : foremanLaborRate;
            this.generalForemanLaborRate = String.IsNullOrEmpty(generalForemanLaborRate) ? "Null" : generalForemanLaborRate;
            this.superintendentLaborRate = String.IsNullOrEmpty(superintendentLaborRate) ? "Null" : superintendentLaborRate;
            this.projectManagerLaborRate = String.IsNullOrEmpty(projectManagerLaborRate) ? "Null" : projectManagerLaborRate;
            this.projectEngineerLaborRate = String.IsNullOrEmpty(projectEngineerLaborRate) ? "Null" : projectEngineerLaborRate;
            this.safetyMeetingsLaborRate = String.IsNullOrEmpty(safetyMeetingsLaborRate) ? "Null" : safetyMeetingsLaborRate;
            this.premiumTimeLaborRate = String.IsNullOrEmpty(premiumTimeLaborRate) ? "Null" : premiumTimeLaborRate;

            this.sundriesCost = String.IsNullOrEmpty(sundriesCost) ? "Null" : sundriesCost;
            this.salesTaxCost = String.IsNullOrEmpty(salesTaxCost) ? "Null" : salesTaxCost;
            this.BIMCost = String.IsNullOrEmpty(BIMCost) ? "Null" : BIMCost;

            this.apprenticeCost = String.IsNullOrEmpty(apprenticeCost) ? "Null" : apprenticeCost;
            this.electricianCost = String.IsNullOrEmpty(electricianCost) ? "Null" : electricianCost;
            this.foremanCost = String.IsNullOrEmpty(foremanCost) ? "Null" : foremanCost;
            this.generalForemanCost = String.IsNullOrEmpty(generalForemanCost) ? "Null" : generalForemanCost;
            this.superintendentCost = String.IsNullOrEmpty(superintendentCost) ? "Null" : superintendentCost;
            this.premiumCost = String.IsNullOrEmpty(premiumCost) ? "Null" : premiumCost;
            this.fringeBenefitsCost = String.IsNullOrEmpty(fringeBenefitsCost) ? "Null" : fringeBenefitsCost;
            this.safetyMeetingsCost = String.IsNullOrEmpty(safetyMeetingsCost) ? "Null" : safetyMeetingsCost;
            this.projectManagerCost = String.IsNullOrEmpty(projectManagerCost) ? "Null" : projectManagerCost;
            this.projectEngineerCost = String.IsNullOrEmpty(projectEngineerCost) ? "Null" : projectEngineerCost;
            this.totalLaborCost = String.IsNullOrEmpty(totalLaborCost) ? "Null" : totalLaborCost;
            this.asBuiltsEngineeringCost = String.IsNullOrEmpty(asBuiltsEngineeringCost) ? "Null" : asBuiltsEngineeringCost;
            this.storageCost = String.IsNullOrEmpty(storageCost) ? "Null" : storageCost;
            this.smallToolsCost = String.IsNullOrEmpty(smallToolsCost) ? "Null" : smallToolsCost;
            this.cartigeHandlingCost = String.IsNullOrEmpty(cartigeHandlingCost) ? "Null" : cartigeHandlingCost;
            this.totalExpensesCost = String.IsNullOrEmpty(totalExpensesCost) ? "Null" : totalExpensesCost;
            this.materialsLaborExpensesCost = String.IsNullOrEmpty(materialsLaborExpensesCost) ? "Null" : materialsLaborExpensesCost;
            this.overheadCost = String.IsNullOrEmpty(overheadCost) ? "Null" : overheadCost;
            this.materialsLaborExpensesOverheadCost = String.IsNullOrEmpty(materialsLaborExpensesOverheadCost) ? "Null" : materialsLaborExpensesOverheadCost;
            this.profitCost = String.IsNullOrEmpty(profitCost) ? "Null" : profitCost;
            this.overheadProfitCost = String.IsNullOrEmpty(overheadProfitCost) ? "Null" : overheadProfitCost;
            this.subcontractAdministrationCost = String.IsNullOrEmpty(subcontractAdministrationCost) ? "Null" : subcontractAdministrationCost;
            this.overheadProfitSubcontractsAmountSubcontractAdministrationCost
                = String.IsNullOrEmpty(overheadProfitSubcontractsAmountSubcontractAdministrationCost) ? "Null"
                : overheadProfitSubcontractsAmountSubcontractAdministrationCost;
            this.warrantyCost = String.IsNullOrEmpty(warrantyCost) ? "Null" : warrantyCost;
            this.bondCost = String.IsNullOrEmpty(bondCost) ? "Null" : bondCost;
            this.letterWorkDescription = letterWorkDescription.Trim().Replace("'", "''");
            this.letterExclusion = letterExclusion.Trim().Replace("'", "''");
            this.letterTimeExtension = String.IsNullOrEmpty(letterTimeExtension) ? "Null" : letterTimeExtension;
            this.contactID = String.IsNullOrEmpty(contactID) ? "Null" : contactID;
            this.from = from.Trim().Replace("'", "''");

            this.BIMRateOT = String.IsNullOrEmpty(BIMRateOT) ? "Null" : BIMRateOT;

            this.apprenticeLaborRateOT = String.IsNullOrEmpty(apprenticeLaborRateOT) ? "Null" : apprenticeLaborRateOT;
            this.electricianLaborRateOT = String.IsNullOrEmpty(electricianLaborRateOT) ? "Null" : electricianLaborRateOT;
            this.foremanLaborRateOT = String.IsNullOrEmpty(foremanLaborRateOT) ? "Null" : foremanLaborRateOT;
            this.generalForemanLaborRateOT = String.IsNullOrEmpty(generalForemanLaborRateOT) ? "Null" : generalForemanLaborRateOT;
            this.superintendentLaborRateOT = String.IsNullOrEmpty(superintendentLaborRateOT) ? "Null" : superintendentLaborRateOT;
            this.projectManagerLaborRateOT = String.IsNullOrEmpty(projectManagerLaborRateOT) ? "Null" : projectManagerLaborRateOT;
            this.projectEngineerLaborRateOT = String.IsNullOrEmpty(projectEngineerLaborRateOT) ? "Null" : projectEngineerLaborRateOT;
            this.safetyMeetingsLaborRateOT = String.IsNullOrEmpty(safetyMeetingsLaborRateOT) ? "Null" : safetyMeetingsLaborRateOT;
            this.premiumTimeLaborRateOT = String.IsNullOrEmpty(premiumTimeLaborRateOT) ? "Null" : premiumTimeLaborRateOT;

            this.BIMRateDT = String.IsNullOrEmpty(BIMRateDT) ? "Null" : BIMRateDT;

            this.apprenticeLaborRateDT = String.IsNullOrEmpty(apprenticeLaborRateDT) ? "Null" : apprenticeLaborRateDT;
            this.electricianLaborRateDT = String.IsNullOrEmpty(electricianLaborRateDT) ? "Null" : electricianLaborRateDT;
            this.foremanLaborRateDT = String.IsNullOrEmpty(foremanLaborRateDT) ? "Null" : foremanLaborRateDT;
            this.generalForemanLaborRateDT = String.IsNullOrEmpty(generalForemanLaborRateDT) ? "Null" : generalForemanLaborRateDT;
            this.superintendentLaborRateDT = String.IsNullOrEmpty(superintendentLaborRateDT) ? "Null" : superintendentLaborRateDT;
            this.projectManagerLaborRateDT = String.IsNullOrEmpty(projectManagerLaborRateDT) ? "Null" : projectManagerLaborRateDT;
            this.projectEngineerLaborRateDT = String.IsNullOrEmpty(projectEngineerLaborRateDT) ? "Null" : projectEngineerLaborRateDT;
            this.safetyMeetingsLaborRateDT = String.IsNullOrEmpty(safetyMeetingsLaborRateDT) ? "Null" : safetyMeetingsLaborRateDT;
            this.premiumTimeLaborRateDT = String.IsNullOrEmpty(premiumTimeLaborRateDT) ? "Null" : premiumTimeLaborRateDT;


            this.estimatedBIMHoursOT = String.IsNullOrEmpty(estimatedBIMHoursOT) ? "Null" : estimatedBIMHoursOT;

            this.estimatedApprenticeHoursOT = String.IsNullOrEmpty(estimatedApprenticeHoursOT) ? "Null" : estimatedApprenticeHoursOT;
            this.estimatedElectricianHoursOT = String.IsNullOrEmpty(estimatedElectricianHoursOT) ? "Null" : estimatedElectricianHoursOT;

            this.estimatedBIMHoursDT = String.IsNullOrEmpty(estimatedBIMHoursDT) ? "Null" : estimatedBIMHoursDT;

            this.estimatedApprenticeHoursDT = String.IsNullOrEmpty(estimatedApprenticeHoursDT) ? "Null" : estimatedApprenticeHoursDT;
            this.estimatedElectricianHoursDT = String.IsNullOrEmpty(estimatedElectricianHoursDT) ? "Null" : estimatedElectricianHoursDT;


            this.foremanDefaultHoursOT = String.IsNullOrEmpty(foremanDefaultHoursOT) ? "Null" : foremanDefaultHoursOT;
            this.generalForemanDefaultHoursOT = String.IsNullOrEmpty(generalForemanDefaultHoursOT) ? "Null" : generalForemanDefaultHoursOT;
            this.superintendentDefaultHoursOT = String.IsNullOrEmpty(superintendentDefaultHoursOT) ? "Null" : superintendentDefaultHoursOT;
            this.projectManagerDefaultHoursOT = String.IsNullOrEmpty(projectManagerDefaultHoursOT) ? "Null" : projectManagerDefaultHoursOT;
            this.projectEngineerDefaultHoursOT = String.IsNullOrEmpty(projectEngineerDefaultHoursOT) ? "Null" : projectEngineerDefaultHoursOT;
            this.foremanDefaultHoursDT = String.IsNullOrEmpty(foremanDefaultHoursDT) ? "Null" : foremanDefaultHoursDT;
            this.generalForemanDefaultHoursDT = String.IsNullOrEmpty(generalForemanDefaultHoursDT) ? "Null" : generalForemanDefaultHoursDT;
            this.superintendentDefaultHoursDT = String.IsNullOrEmpty(superintendentDefaultHoursDT) ? "Null" : superintendentDefaultHoursDT;
            this.projectManagerDefaultHoursDT = String.IsNullOrEmpty(projectManagerDefaultHoursDT) ? "Null" : projectManagerDefaultHoursDT;
            this.projectEngineerDefaultHoursDT = String.IsNullOrEmpty(projectEngineerDefaultHoursDT) ? "Null" : projectEngineerDefaultHoursDT;
            this.foremanActualHoursOT = String.IsNullOrEmpty(foremanActualHoursOT) ? "Null" : foremanActualHoursOT;
            this.generalForemanActualHoursOT = String.IsNullOrEmpty(generalForemanActualHoursOT) ? "Null" : generalForemanActualHoursOT;
            this.superintendentActualHoursOT = String.IsNullOrEmpty(superintendentActualHoursOT) ? "Null" : superintendentActualHoursOT;
            this.projectManagerActualHoursOT = String.IsNullOrEmpty(projectManagerActualHoursOT) ? "Null" : projectManagerActualHoursOT;
            this.projectEngineerActualHoursOT = String.IsNullOrEmpty(projectEngineerActualHoursOT) ? "Null" : projectEngineerActualHoursOT;
            this.premiumHoursActualHoursOT = String.IsNullOrEmpty(premiumHoursActualHoursOT) ? "Null" : premiumHoursActualHoursOT;
            this.foremanActualHoursDT = String.IsNullOrEmpty(foremanActualHoursDT) ? "Null" : foremanActualHoursDT;
            this.generalForemanActualHoursDT = String.IsNullOrEmpty(generalForemanActualHoursDT) ? "Null" : generalForemanActualHoursDT;
            this.superintendentActualHoursDT = String.IsNullOrEmpty(superintendentActualHoursDT) ? "Null" : superintendentActualHoursDT;
            this.projectManagerActualHoursDT = String.IsNullOrEmpty(projectManagerActualHoursDT) ? "Null" : projectManagerActualHoursDT;
            this.projectEngineerActualHoursDT = String.IsNullOrEmpty(projectEngineerActualHoursDT) ? "Null" : projectEngineerActualHoursDT;
            this.premiumHoursActualHoursDT = String.IsNullOrEmpty(premiumHoursActualHoursDT) ? "Null" : premiumHoursActualHoursDT;

            this.asBuiltsEngineeringPercentText = asBuiltsEngineeringPercentText.Trim().Replace("'", "''");
            this.storagePercentText = storagePercentText.Trim().Replace("'", "''");
            this.smallToolsPercentText = smallToolsPercentText.Trim().Replace("'", "''");
            this.cartigeHandlingPercentText = cartigeHandlingPercentText.Trim().Replace("'", "''");

            this.overheadPercentText = overheadPercentText.Trim().Replace("'", "''");
            this.profitPercentText = profitPercentText.Trim().Replace("'", "''");
            this.subcontractAdministrationPercentText = subcontractAdministrationPercentText.Trim().Replace("'", "''");
            this.warrantyPercentText = warrantyPercentText.Trim().Replace("'", "''");
            this.bondPercentText = bondPercentText.Trim().Replace("'", "''");


            this.BIMRate_Label = String.IsNullOrEmpty(BIMRate_Label) ? string.Empty : BIMRate_Label.Trim();
            this.apprenticeLaborRate_Label = String.IsNullOrEmpty(apprenticeLaborRate_Label) ? string.Empty : apprenticeLaborRate_Label.Trim();
            this.electricianLaborRate_Label = String.IsNullOrEmpty(electricianLaborRate_Label) ? string.Empty : electricianLaborRate_Label.Trim();
            this.foremanLaborRate_Label = String.IsNullOrEmpty(foremanLaborRate_Label) ? string.Empty : foremanLaborRate_Label.Trim();
            this.generalForemanLaborRate_Label = String.IsNullOrEmpty(generalForemanLaborRate_Label) ? string.Empty : generalForemanLaborRate_Label.Trim();
            this.superintendentLaborRate_Label = String.IsNullOrEmpty(superintendentLaborRate_Label) ? string.Empty : superintendentLaborRate_Label.Trim();
            this.projectManagerLaborRate_Label = String.IsNullOrEmpty(projectManagerLaborRate_Label) ? string.Empty : projectManagerLaborRate_Label.Trim();
            this.projectEngineerLaborRate_Label = String.IsNullOrEmpty(projectEngineerLaborRate_Label) ? string.Empty : projectEngineerLaborRate_Label.Trim();
            this.safetyMeetingsLaborRate_Label = String.IsNullOrEmpty(safetyMeetingsLaborRate_Label) ? string.Empty : safetyMeetingsLaborRate_Label.Trim();
            this.premiumTimeLaborRate_Label = String.IsNullOrEmpty(premiumTimeLaborRate_Label) ? string.Empty : premiumTimeLaborRate_Label.Trim();
            this.FringeBenefitsPercent_Label = String.IsNullOrEmpty(FringeBenefitsPercent_Label) ? string.Empty : FringeBenefitsPercent_Label.Trim();
            this.SafetyMeetingPercent_Label = String.IsNullOrEmpty(SafetyMeetingPercent_Label) ? string.Empty : SafetyMeetingPercent_Label.Trim();

        }
        //
        // Create a Change Order Revision
        //
        public static string CreateChangeOrderRevision(string jobChangeOrderID)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);

            string rev = "";
            try
            {
                DataRow r = DataBaseUtil.ExecuteParDataset("dbo.[up_JCCCreateChangeOrderRevision]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0].Rows[0];
                if (r != null)
                {
                    rev = r[0].ToString();
                }

                return rev;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Inactive revision 
        /// </summary>
        /// <param name="jobChangerOrderID"></param>
        /// <returns></returns>
        public static string UpdateInActiveRevision(string jobChangeOrderID, string revision)
        {

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);
            par[1] = new SqlParameter("@Revision", revision);

            string rev = "";
            try
            {
                DataRow r = DataBaseUtil.ExecuteParDataset("dbo.[up_JCCUpdatePreviousRevision]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0].Rows[0];
                if (r != null)
                {
                    rev = r[0].ToString();
                }

                return rev;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Create revision from existing Revisions
        /// </summary>
        /// <param name="jobChangerOrderID"></param>
        /// <returns></returns>
        public static string CreateChangeOrderFromRevision(string jobChangeOrderID, string revision)
        {

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);
            par[1] = new SqlParameter("@Revision", revision);

            string rev = "";
            try
            {
                DataRow r = DataBaseUtil.ExecuteParDataset("dbo.[up_JCCCreateChangeOrderFromRevision]", CCEApplication.Connection, CommandType.StoredProcedure, par).Tables[0].Rows[0];
                if (r != null)
                {
                    rev = r[0].ToString();
                }

                return rev;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Change Order Details with current revision created
        /// </summary>
        /// <param name="jobChangeOrderID"></param>
        /// <param name="revision"></param>
        /// <returns></returns>
        public static bool UpdateChangeOrderFromRevision(string jobChangeOrderID, string revision)
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);
            par[1] = new SqlParameter("@Revision", revision);

            try
            {
                DataBaseUtil.ExecuteParDataset("up_JCCUpdateJobChangeOrder", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static DataSet GetJobChangeOrderRevList(string jobChangerOrderID)
        {
            string query = " SELECT Rev, Rev AS R FROM [tblJobChangeOrderRev] " +
                           " WHERE JobChangeOrderID = " + jobChangerOrderID + " " +
                            " ORDER BY Rev ";


            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public static DataSet GetJobChangeOrdersPullDown(string jobID)
        {
            string query = " SELECT JobChangeOrderID, " +
                           " JobChangeOrderNumber, " +
                           " JobChangeOrderUserDescription " +
                           " FROM tblJobChangeOrder WHERE JobID = " + jobID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetContractLog(string jobID)
        {
            string query = "SELECT " +
                            " JobChangeOrderLogID, " +
                            " l.JobID, " +
                            " JobChangeOrderNumber, " +
                            " JobChangeOrderRequestDate," +
                            " JobChangeOrderApprovedDate, " +
                            " JobChangeOrderContractAmount, " +
                            " JobChangeOrderStatus, " +
                            " JobChangeOrderDescription, " +
                            " JobChangeOrderOwnerNumber, " +
                            " JobChangeOrderCCENumber, " +
                            " JobCostCodeType, " +
                            " JobChangeOrderUserDescription, " +
                            " Hours, " +
                            " Labor, " +
                            " Subcontract, " +
                            " Material, " +
                            " Expense, " +
                            " Labor + Subcontract + Material + Expense AS TotalCost, " +
                            " (JobChangeOrderContractAmount -   (Labor + Subcontract + Material + Expense) ) AS EstProfit, " +
                            " ProfitPercent = " +
                            " CASE ISNULL(JobChangeOrderContractAmount,0) " +
                            " WHEN  0 THEN 0 " +
                            " ELSE CAST(  ( JobChangeOrderContractAmount -  (Labor + Subcontract + Material + Expense)) / JobChangeOrderContractAmount AS FLOAT) " +
                            " END, " +
                            " JobNumber, " +
                            " JobName, " +
                            " j.CustomerID, " +
                            " [Name] AS CustomerName, " +
                            " m.Description AS ProjectManager, " +
                            " t.Description AS ContractType, " +
                            " ContractEstComplDate, " +
                            " JobChangeOrderDescriptionGroup " +
                            " FROM tblJobChangeOrderLog l " +
                            " INNER JOIN tblJob j ON l.JobID = j.JobID " +
                            " LEFT JOIN tblCustomer c ON j.CustomerID = c.CustomerID " +
                            " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " +
                            " LEFT JOIN tblContractType t ON j.ContractTypeID = t.ContractTypeID " +
                            " WHERE j.JobID =  " + jobID + "";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobChangeOrderLetterRev(string jobChangeOrderID, string revision)
        {

            string query1 = "";

            query1 = " SELECT DISTINCT" +
                " o.BIMRate_Label,o.ApprenticeLaborRate_Label,o.ElectricianLaborRate_Label,o.ForemanLaborRate_Label,o.GeneralForemanLaborRate_Label,o.SuperintendentLaborRate_Label,o.ProjectManagerLaborRate_Label,o.ProjectEngineerLaborRate_Label,o.SafetyMeetingsLaborRate_Label,o.PremiumTimeLaborRate_Label ,o.FringeBenefitsPercent_Label, o.SafetyMeetingPercent_Label," +
                     " Rev, " +
                     " JobChangeOrderNumber, " +
                     " JobName, " +
                     " JobNumber, " +
                     " JobChangeOrderRequestDate, " +
                     " JobChangeOrderRequestedAmount, " +
                     " JobChangeOrderCCENumber, " +
                     " JobChangeOrderOwnerNumber, " +
                     " JobChangeOrderUserDescription, " +
                     " LetterWorkDescription, " +
                     " ChangeOrderStipulationsParagraph1, " +
                     " ChangeOrderStipulationsParagraph2, " +
                     " LetterExclusion, " +
                     " LetterTimeExtension, " +
                     " ChangeOrderDefaultContact = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN  mm.FirstName + ' ' +  mm.LastName " +
                    " ELSE nn.FirstName  + ' ' + nn.LastName " +
                    " END, " +
                    " CompanyName = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN mm.CompanyName " +
                    " ELSE nn.CompanyName " +
                    " End, " +
                    " OfficeStreetAddress = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN mm.OfficeStreetAddress " +
                    " ELSE nn.OfficeStreetAddress " +
                    " End, " +
                    " CityStateZip = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN ISNULL(mm.OfficeCity, '') + ' ' + ISNULL(mm.OfficeState, '') + ', ' + ISNULL(mm.OfficeZip, '') " +
                    " ELSE " +
                    " ISNULL(nn.OfficeCity, '') + ' ' + ISNULL(nn.OfficeState, '') + ', ' + ISNULL(nn.OfficeZip, '')  " +
                    " END " +
                    " FROM tblJobChangeOrderRev o " +
                    " LEFT JOIN tblJob j ON o.JobID = j.JobID " +
                    " LEFT JOIN tblJobDefaultValues v on o.JobID = v.JobID " +
                    " LEFT JOIN tblJobContact l ON o.ContactID = l.ContactID " +
                    " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                     " WHERE o.JobChangeOrderID = '" + jobChangeOrderID + "' AND o.Rev = '" + revision + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetJobChangeOrderLetterRevFornewjob(string jobChangeOrderID, string revision)
        {

            string query1 = "";

            query1 = " SELECT DISTINCT" +
                     " Rev, " +
                     " JobChangeOrderNumber, " +
                     " JobName, " +
                     " JobNumber, " +
                     " JobChangeOrderRequestDate, " +
                     " JobChangeOrderRequestedAmount, " +
                     " JobChangeOrderCCENumber, " +
                     " JobChangeOrderOwnerNumber, " +
                     " JobChangeOrderUserDescription, " +
                     " LetterWorkDescription, " +
                     " ChangeOrderStipulationsParagraph1, " +
                     " ChangeOrderStipulationsParagraph2, " +
                     " LetterExclusion, " +
                     " LetterTimeExtension, " +
                     " ChangeOrderDefaultContact = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN  gc.FirstName + ' ' +  gc.LastName " +
                    " ELSE nn.FirstName  + ' ' + nn.LastName " +
                    " END, " +
                    " CompanyName = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN gc.CompanyName " +
                    " ELSE nn.CompanyName " +
                    " End, " +
                    " OfficeStreetAddress = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN gc.OfficeStreetAddress " +
                    " ELSE nn.OfficeStreetAddress " +
                    " End, " +
                    " CityStateZip = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN ISNULL(gc.OfficeCity, '') + ' ' + ISNULL(gc.OfficeState, '') + ', ' + ISNULL(gc.OfficeZip, '') " +
                    " ELSE " +
                    " ISNULL(nn.OfficeCity, '') + ' ' + ISNULL(nn.OfficeState, '') + ', ' + ISNULL(nn.OfficeZip, '')  " +
                    " END " +
                    " FROM tblJobChangeOrderRev o " +
                    " LEFT JOIN tblJob j ON o.JobID = j.JobID " +
                    " LEFT JOIN tblJobDefaultValues v on o.JobID = v.JobID " +
                    " LEFT JOIN tblJobContact l ON o.ContactID = l.ContactID " +
                    //" LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                    "  LEFT JOIN tblGlobalContact gc ON l.CompanyContactID = gc.GlobalContactID  " +
                    " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                     " WHERE o.JobChangeOrderID = '" + jobChangeOrderID + "' AND o.Rev = '" + revision + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //
        public static DataSet GetJobChangeOrderLetter(string jobChangeOrderID)
        {

            string query1 = "";

            query1 = " SELECT DISTINCT" +
                     " JobChangeOrderNumber, " +
                     " JobName, " +
                     " JobNumber, " +
                     " JobChangeOrderRequestDate, " +
                     " JobChangeOrderRequestedAmount, " +
                     " JobChangeOrderCCENumber, " +
                     " JobChangeOrderOwnerNumber, " +
                     " JobChangeOrderUserDescription, " +
                     " LetterWorkDescription, " +
                     " ChangeOrderStipulationsParagraph1, " +
                     " ChangeOrderStipulationsParagraph2, " +
                     " LetterExclusion, " +
                     " LetterTimeExtension, " +
                     " ChangeOrderDefaultContact = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN  mm.FirstName + ' ' +  mm.LastName " +
                    " ELSE nn.FirstName  + ' ' + nn.LastName " +
                    " END, " +
                    " CompanyName = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN mm.CompanyName " +
                    " ELSE nn.CompanyName " +
                    " End, " +
                    " OfficeStreetAddress = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN mm.OfficeStreetAddress " +
                    " ELSE nn.OfficeStreetAddress " +
                    " End, " +
                    " CityStateZip = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN ISNULL(mm.OfficeCity, '') + ' ' + ISNULL(mm.OfficeState, '') + ', ' + ISNULL(mm.OfficeZip, '') " +
                    " ELSE " +
                    " ISNULL(nn.OfficeCity, '') + ' ' + ISNULL(nn.OfficeState, '') + ', ' + ISNULL(nn.OfficeZip, '')  " +
                    " END " +
                    " FROM tblJobChangeOrder o " +
                    " LEFT JOIN tblJob j ON o.JobID = j.JobID " +
                    " LEFT JOIN tblJobDefaultValues v on o.JobID = v.JobID " +
                    " LEFT JOIN tblJobContact l ON o.ContactID = l.ContactID " +
                    " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                     " WHERE o.JobChangeOrderID = '" + jobChangeOrderID + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet GetJobChangeOrderLetterForNewJob(string jobChangeOrderID)
        {

            string query1 = "";

            query1 = " SELECT DISTINCT" +
                     " JobChangeOrderNumber, " +
                     " JobName, " +
                     " JobNumber, " +
                     " JobChangeOrderRequestDate, " +
                     " JobChangeOrderRequestedAmount, " +
                     " JobChangeOrderCCENumber, " +
                     " JobChangeOrderOwnerNumber, " +
                     " JobChangeOrderUserDescription, " +
                     " LetterWorkDescription, " +
                     " ChangeOrderStipulationsParagraph1, " +
                     " ChangeOrderStipulationsParagraph2, " +
                     " LetterExclusion, " +
                     " LetterTimeExtension, " +
                     " ChangeOrderDefaultContact = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN  gc.FirstName + ' ' +  gc.LastName " +
                    " ELSE nn.FirstName  + ' ' + nn.LastName " +
                    " END, " +
                    " CompanyName = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN gc.CompanyName " +
                    " ELSE nn.CompanyName " +
                    " End, " +
                    " OfficeStreetAddress = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN gc.OfficeStreetAddress " +
                    " ELSE nn.OfficeStreetAddress " +
                    " End, " +
                    " CityStateZip = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN ISNULL(gc.OfficeCity, '') + ' ' + ISNULL(gc.OfficeState, '') + ', ' + ISNULL(gc.OfficeZip, '') " +
                    " ELSE " +
                    " ISNULL(nn.OfficeCity, '') + ' ' + ISNULL(nn.OfficeState, '') + ', ' + ISNULL(nn.OfficeZip, '')  " +
                    " END " +
                    " FROM tblJobChangeOrder o " +
                    " LEFT JOIN tblJob j ON o.JobID = j.JobID " +
                    " LEFT JOIN tblJobDefaultValues v on o.JobID = v.JobID " +
                    " LEFT JOIN tblJobContact l ON o.ContactID = l.ContactID " +
                    //" LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                    " LEFT JOIN tblGlobalContact gc ON l.CompanyContactID = gc.GlobalContactID  " +
                    " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                     " WHERE o.JobChangeOrderID = '" + jobChangeOrderID + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobChangeOrders(string jobID)
        {

            string query1 = "";

            query1 = "SELECT   " +
                     " JobChangeOrderID, " +
                     " JobID, " +
                     " JobChangeOrderNumber, " +
                     " JobChangeOrderRequestDate, " +
                     " JobChangeOrderRequestedAmount, " +
                     " JobChangeOrderApprovedDate, " +
                     " JobChangeOrderApprovedAmount, " +
                     " JobChangeOrderStatus, " +
                     " JobChangeOrderDescription, " +
                     " JobChangeOrderUpdateFlag, " +
                     " JobChangeOrderLastUpdate, " +
                     " JobChangeOrderOwnerNumber, " +
                     " JobChangeOrderCCENumber, " +
                     " JobChangeOrderUserDescription, " +
                     " [dbo].[GetChangeOrderCost] (JobChangeOrderID) AS Cost " +
                     " FROM tblJobChangeOrder " +
                     " WHERE JobID = '" + jobID + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetJobOutstandingChangeOrders(string jobID)
        {

            string query1 = "";

            query1 = "SELECT   " +
                     " JobChangeOrderID, " +
                     " JobID, " +
                     " JobChangeOrderNumber, " +
                     " JobChangeOrderRequestDate, " +
                     " JobChangeOrderRequestedAmount, " +
                     " JobChangeOrderApprovedDate, " +
                     " JobChangeOrderApprovedAmount, " +
                     " JobChangeOrderStatus, " +
                     " JobChangeOrderDescription, " +
                     " JobChangeOrderUpdateFlag, " +
                     " JobChangeOrderLastUpdate, " +
                     " JobChangeOrderOwnerNumber, " +
                     " JobChangeOrderCCENumber, " +
                     " JobChangeOrderUserDescription, " +
                     " [dbo].[GetChangeOrderCost] (JobChangeOrderID) AS Cost " +
                     " FROM tblJobChangeOrder " +
                     " WHERE JobID = '" + jobID + "' AND   JobChangeOrderStatus = 'Pending'     ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query1, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // 

        public static bool UpdateTMContractAmount(string jobID, string contractAmount)
        {
            string query = " UPDATE tblJobBalance SET OriginalContract = " + contractAmount + " " +
                " WHERE jobID = " + jobID + " ";

            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                UpdatePrimaryContract(jobID);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool UpdatePrimaryContract(string jobID)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobID", jobID);

            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.[up_DMJobUpdateStarbuilderPrimaryContract]", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdateChangeOrder(string jobID, string jobChangeOrderID)
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@JobID", jobID);
            par[1] = new SqlParameter("@JobChangeOrderID", jobChangeOrderID);

            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.[up_DMJobUpdateStarbuilderChangeOrder]", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdatePrimaryContractCostCodes(string jobID)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobID", jobID);

            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.[up_DMJobUpdateStarbuilderPrimaryContractCostCodes]", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static bool UpdateChangeOrderCostCodes(string jobID, string jobChangeOrderNumber)
        {

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@JobID", jobID);
            par[1] = new SqlParameter("@JobChangeOrderNumber", jobChangeOrderNumber);

            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.[up_DMJobUpdateStarbuilderChangeOrderCostCodes]", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobOriginalContractStatus(string jobID)
        {
            string query = "";

            query = "SELECT JobChangeOrderID FROM tblJobChangeOrder" +
                    " WHERE JobID = '" + jobID + "' AND JobChangeOrderDescription = 'ORIGINAL CONTRACT' AND JobChangeOrderStatus = 'APPROVED' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobChangeOrderDetail(string jobChangeOrderID)
        {
            string query = "";
            if (jobChangeOrderID == "")
            {
                jobChangeOrderID = "0";
            }

            query = "SELECT " +
                    " JobChangeOrderNumber, " +
                    " JobChangeOrderUserDescription, " +
                    " EstimateNumber, " +
                    " JobNumber, " +
                    " JobName, " +
                    " JobChangeOrderCCENumber, " +
                    " JobChangeOrderOwnerNumber, " +
                    " m.Description As [ProjectManager], " +
                    " e.Description As [Estimator], " +
                    " s.Description AS [Superintendent], " +
                    " BillingRep," +
                    " Name AS [CustomerName], " +
                    " ApprovedAmount = " +
                    " CASE JobChangeOrderApprovedAmount " +
                    " WHEN 0 THEN JobChangeOrderRequestedAmount " +
                    " ELSE JobChangeOrderApprovedAmount " +
                    " END, " +
                    " d.UNIT, " +
                    " JobCostCodeType, " +
                    " JobCostCodePhase, " +
                    " CostCode, " +
                    " d.Description AS [CostCodeDescription], " +
                    " ISNULL(Quantity, 0) AS Quantity, " +
                    " ISNULL(Hours,0) AS Hours, " +
                    " ISNULL(d.Cost, 0) AS Cost " +
                    " FROM tblJob j " +
                    " LEFT JOIN tblProjectManager m " +
                    " ON j.ProjectManagerID = m.ProjectManagerID " +
                    " LEFT JOIN tblEstimator e " +
                    " ON j.EstimatorID = e.EstimatorID " +
                    " LEFT JOIN tblSuperintendent s " +
                    " ON j.SuperintendentID = s.SuperintendentID " +
                    " LEFT JOIN tblJobChangeOrder C " +
                    " ON j.JobID = c.JobID " +
                    " LEFT JOIN tblCustomer u " +
                    " ON j.CustomerID = u.CustomerID " +
                    " LEFT JOIN tblJobCostCode d " +
                    " ON c.JobChangeOrderID = d.JobChangeOrderID " +
                    " LEFT JOIN tblJobCostCodePhase p " +
                    " ON d.JobCostCodePhaseID = p.JobCostCodePhaseID " +
                    " WHERE c.JobChangeOrderID = '" + jobChangeOrderID + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobChangeOrder(string jobChangeOrderID)
        {


            string query = "";
            if (jobChangeOrderID == "")
            {
                jobChangeOrderID = "0";
            }

            query = "SELECT  TRIM(CO.BIMRate_Label) AS BIMRate_Label, LTRIM(CO.ApprenticeLaborRate_Label) AS ApprenticeLaborRate_Label,LTRIM(CO.ElectricianLaborRate_Label) AS ElectricianLaborRate_Label,LTRIM(CO.ForemanLaborRate_Label) AS ForemanLaborRate_Label,TRIM(CO.GeneralForemanLaborRate_Label) AS GeneralForemanLaborRate_Label,TRIM(CO.SuperintendentLaborRate_Label) AS SuperintendentLaborRate_Label,TRIM(CO.ProjectManagerLaborRate_Label) AS ProjectManagerLaborRate_Label,TRIM(CO.ProjectEngineerLaborRate_Label) AS ProjectEngineerLaborRate_Label,TRIM(CO.SafetyMeetingsLaborRate_Label) AS SafetyMeetingsLaborRate_Label,TRIM(CO.PremiumTimeLaborRate_Label) AS PremiumTimeLaborRate_Label , TRIM(CO.SafetyMeetingPercent_Label) as  SafetyMeetingPercent_Label, TRIM(CO.FringeBenefitsPercent_Label) as  FringeBenefitsPercent_Label,CO.*, JobName, JobNumber FROM tblJobChangeOrder CO" +
                    " LEFT JOIN tblJob j ON CO.JobID = j.JobID " +
                    //" LEFT JOIN tblJobDefaultValues dv on o.jobID=dv.jobID " +
                    " WHERE JobChangeOrderID = '" + jobChangeOrderID + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetJobChangeOrderRev(string jobChangeOrderID, string revision)
        {


            string query = "";
            if (jobChangeOrderID == "")
            {
                jobChangeOrderID = "0";
            }

         query = "SELECT TRIM(o.BIMRate_Label) AS BIMRate_Label, LTRIM(o.ApprenticeLaborRate_Label) AS ApprenticeLaborRate_Label,LTRIM(o.ElectricianLaborRate_Label) AS ElectricianLaborRate_Label,LTRIM(o.ForemanLaborRate_Label) AS ForemanLaborRate_Label,TRIM(o.GeneralForemanLaborRate_Label) AS GeneralForemanLaborRate_Label,TRIM(o.SuperintendentLaborRate_Label) AS SuperintendentLaborRate_Label,TRIM(o.ProjectManagerLaborRate_Label) AS ProjectManagerLaborRate_Label,TRIM(o.ProjectEngineerLaborRate_Label) AS ProjectEngineerLaborRate_Label,TRIM(o.SafetyMeetingsLaborRate_Label) AS SafetyMeetingsLaborRate_Label,TRIM(o.PremiumTimeLaborRate_Label) AS PremiumTimeLaborRate_Label , TRIM(o.SafetyMeetingPercent_Label) as  SafetyMeetingPercent_Label, TRIM(o.FringeBenefitsPercent_Label) as  FringeBenefitsPercent_Label,o.*, JobName, JobNumber  FROM tblJobChangeOrderRev o" +
            //query = "SELECT o.*, JobName, JobNumber  FROM tblJobChangeOrderRev o" +
                    " LEFT JOIN tblJob j ON o.JobID = j.JobID " +
                    "LEFT JOIN tblJobChangeOrder CO on o.JobChangeOrderID=CO.JobChangeOrderID " +
                    " WHERE o.JobChangeOrderID = '" + jobChangeOrderID + "' AND Rev =  '" + revision + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save(string rev, bool changeOrderStatus, bool isCostCodeUpdate)
        {
            if (jobChangeOrderID == "" || jobChangeOrderID == "0")
            {
                return Insert(rev);
            }
            else
            {
                return Update(rev, changeOrderStatus, isCostCodeUpdate);
            }
        }
        private bool Insert(string rev)
        {
            string query = "";

            query = "INSERT INTO tblJobChangeOrder(JobID, JobChangeOrderNumber, " +
                    " JobChangeOrderRequestDate, JobChangeOrderRequestedAmount, " +
                    " JobChangeOrderApprovedDate, JobChangeOrderApprovedAmount, " +
                    " JobChangeOrderStatus, JobChangeOrderDescription, " +
                    " JobChangeOrderUpdateFlag, JobChangeOrderLastUpdate, JobChangeOrderOwnerNumber, JobChangeOrderCCENumber, JobChangeOrderUserDescription, AuditUserID, " +
                    " ChangeOrderAmount, " +
                    " PriceAdjustment, " +
                    " DirectMaterials, " +

                    " EstimatedBIMHours, " +
                    " EstimatedApprenticeHours, " +
                    " EstimatedElectricianHours, " +
                    " ForemanDefaultHours, " +
                    " GeneralForemanDefaultHours, " +
                    " SuperintendentDefaultHours, " +
                    " ProjectManagerDefaultHours, " +
                    " ProjectEngineerDefaultHours, " +
                    " ForemanActualHours, " +
                    " GeneralForemanActualHours, " +
                    " SuperintendentActualHours, " +
                    " ProjectManagerActualHours, " +
                    " ProjectEngineerActualHours, " +
                    " PremiumHoursActualHours, " +
                    " OtherExpenses1, " +
                    " OtherExpenses2, " +
                    " OtherExpenses3, " +
                    " OtherExpenses1Description, " +
                    " OtherExpenses2Description, " +
                    " OtherExpenses3Description, " +
                    " SubcontractsAmount, " +
                    " LaborHoursEstimateDefaults, " +
                    " LaborDollarEstimateDefaults, " +
                    " LaborRateEstimateDefaults, " +
                    " MaterialsEstimateDefaults, " +
                    " OtherEstimateDefaults, " +
                    " SubcontractsEstimateDefaults, " +
                    " TotalCostEstimateDefaults, " +
                    " ContractDollarEstimateDefaults, " +
                    " ProfitDollarEstimateDefaults, " +
                    " ProfitPercentEstimateDefaults, " +
                    " LaborHoursBudgetTotals, " +
                    " LaborDollarBudgetTotals, " +
                    " LaborRateBudgetTotals, " +
                    " MaterialsBudgetTotals, " +
                    " OtherBudgetTotals, " +
                    " SubcontractsBudgetTotals, " +
                    " TotalCostBudgetTotals, " +
                    " ContractDollarBudgetTotals, " +
                    " ProfitDollarBudgetTotals, " +
                    " ProfitPercentBudgetTotals, " +
                    " SundriesPercentOfMaterial, " +
                    " SalesTaxPercent, " +
                    " AsBuiltsEngineeringPercent, " +
                    " StoragePercent, " +
                    " SmallToolsPercent, " +
                    " CartigeHandlingPercent, " +
                    " ForemanPercentOfLabor, " +
                    " GeneralForemanPercentOfLabor, " +
                    " SuperintendentPercentOfLabor, " +
                    " ProjectManagerPercentOfLabor, " +
                    " ProjectEngineerPercentOfLabor, " +
                    " SafetyMeetingPercent, " +
                    " FringeBenefitsPercent, " +
                    " OverheadPercent, " +
                    " ProfitPercent, " +
                    " SubcontractAdministrationPercent, " +
                    " WarrantyPercent, " +
                    " BondPercent, " +


                    " BIMRate, " +
                    " ApprenticeLaborRate, " +
                    " ElectricianLaborRate, " +
                    " ForemanLaborRate, " +
                    " GeneralForemanLaborRate, " +
                    " SuperintendentLaborRate, " +
                    " ProjectManagerLaborRate, " +
                    " ProjectEngineerLaborRate, " +
                    " SafetyMeetingsLaborRate, " +
                    " PremiumTimeLaborRate, " +
                    " SundriesCost, " +
                    " SalesTaxCost, " +
                    " BIMCost, " +
                    " ApprenticeCost, " +
                    " ElectricianCost, " +
                    " ForemanCost, " +
                    " GeneralForemanCost, " +
                    " SuperintendentCost, " +
                    " PremiumCost, " +
                    " FringeBenefitsCost, " +
                    " SafetyMeetingsCost, " +
                    " ProjectManagerCost, " +
                    " ProjectEngineerCost, " +
                    " TotalLaborCost, " +
                    " AsBuiltsEngineeringCost, " +
                    " StorageCost, " +
                    " SmallToolsCost, " +
                    " CartigeHandlingCost, " +
                    " TotalExpensesCost, " +
                    " MaterialsLaborExpensesCost, " +
                    " OverheadCost, " +
                    " MaterialsLaborExpensesOverheadCost, " +
                    " ProfitCost, " +
                    " OverheadProfitCost, " +
                    " SubcontractAdministrationCost, " +
                    " OverheadProfitSubcontractsAmountSubcontractAdministrationCost, " +
                    " WarrantyCost, " +
                    " BondCost, " +
                    " LetterWorkDescription, " +
                    " LetterExclusion, " +
                    " LetterTimeExtension, " +
                    " ContactID, " +

                    " BIMRateOT, " +
                    " ApprenticeLaborRateOT, " +
                    " ElectricianLaborRateOT, " +
                    " ForemanLaborRateOT, " +
                    " GeneralForemanLaborRateOT, " +
                    " SuperintendentLaborRateOT, " +
                    " ProjectManagerLaborRateOT, " +
                    " ProjectEngineerLaborRateOT, " +
                    " SafetyMeetingsLaborRateOT, " +
                    " PremiumTimeLaborRateOT, " +

                    " BIMRateDT, " +
                    " ApprenticeLaborRateDT, " +
                    " ElectricianLaborRateDT, " +
                    " ForemanLaborRateDT, " +
                    " GeneralForemanLaborRateDT, " +
                    " SuperintendentLaborRateDT, " +
                    " ProjectManagerLaborRateDT, " +
                    " ProjectEngineerLaborRateDT, " +
                    " SafetyMeetingsLaborRateDT, " +
                    " PremiumTimeLaborRateDT, " +

                    " EstimatedBIMHoursOT, " +
                    " EstimatedApprenticeHoursOT, " +
                    " EstimatedElectricianHoursOT, " +
                    " EstimatedBIMHoursDT, " +
                    " EstimatedApprenticeHoursDT, " +
                    " EstimatedElectricianHoursDT, " +

                    " ForemanDefaultHoursOT, " +
                    " GeneralForemanDefaultHoursOT, " +
                    " SuperintendentDefaultHoursOT, " +
                    " ProjectManagerDefaultHoursOT, " +
                    " ProjectEngineerDefaultHoursOT, " +
                    " ForemanDefaultHoursDT, " +
                    " GeneralForemanDefaultHoursDT, " +
                    " SuperintendentDefaultHoursDT, " +
                    " ProjectManagerDefaultHoursDT, " +
                    " ProjectEngineerDefaultHoursDT, " +
                    " ForemanActualHoursOT, " +
                    " GeneralForemanActualHoursOT, " +
                    " SuperintendentActualHoursOT, " +
                    " ProjectManagerActualHoursOT, " +
                    " ProjectEngineerActualHoursOT, " +
                    " PremiumHoursActualHoursOT, " +
                    " ForemanActualHoursDT, " +
                    " GeneralForemanActualHoursDT, " +
                    " SuperintendentActualHoursDT, " +
                    " ProjectManagerActualHoursDT, " +
                    " ProjectEngineerActualHoursDT, " +
                    " PremiumHoursActualHoursDT, " +
                    "AsBuiltsEngineeringPercentText, " +
                    "storagePercentText, " +
                    "smallToolsPercentText, " +
                    "cartigeHandlingPercentText, " +

                    " overheadPercentText, " +
                    " profitPercentText, " +
                    " subcontractAdministrationPercentText, " +
                    " warrantyPercentText, " +
                    " bondPercentText, " +
                    " IsNew, " +
                    " [From], " +

                   " BIMRate_Label, " +
                   " ApprenticeLaborRate_Label, " +
                   " ElectricianLaborRate_Label, " +
                   " ForemanLaborRate_Label, " +
                   " GeneralForemanLaborRate_Label, " +
                   " SuperintendentLaborRate_Label, " +
                   " ProjectManagerLaborRate_Label, " +
                   " ProjectEngineerLaborRate_Label, " +
                   " SafetyMeetingsLaborRate_Label, " +
                   " PremiumTimeLaborRate_Label ," +
                   " FringeBenefitsPercent_Label, " +
                   " SafetyMeetingPercent_Label " +




                    ") Values(" +
                    jobID + ", dbo.GetNewJobChangeOrderNumber ( " + jobID + "), " +
                    " " + jobChangeOrderRequestDate + ", " + jobChangeOrderRequestedAmount + ", " +
                    " " + jobChangeOrderApprovedDate + ", " + jobChangeOrderApprovedAmount + ", " +
                    " '" + jobChangeOrderStatus + "', '" + jobChangeOrderDescription + "', " +
                    " " + jobChangeOrderUpdateFlag + ", '" + jobChangeOrderLastUpdateDate + "', '" + jobChangeOrderOwnerNumber + "', '" + jobChangeOrderCCENumber + "', '" + jobChangeOrderUserDescription + "', '" + Security.Security.LoginID + "', " +
                    changeOrderAmount + ", " +
                    priceAdjustment + ", " +
                    directMaterials + ", " +
                    estimatedBIMHours + ", " +
                    estimatedApprenticeHours + ", " +
                    estimatedElectricianHours + ", " +
                    foremanDefaultHours + ", " +
                    generalForemanDefaultHours + ", " +
                    superintendentDefaultHours + ", " +
                    projectManagerDefaultHours + ", " +
                    projectEngineerDefaultHours + ", " +
                    foremanActualHours + ", " +
                    generalForemanActualHours + ", " +
                    superintendentActualHours + ", " +
                    projectManagerActualHours + ", " +
                    projectEngineerActualHours + ", " +
                    premiumHoursActualHours + ", " +
                    otherExpenses1 + ", " +
                    otherExpenses2 + ", " +
                    otherExpenses3 + ", " +
                    "'" + otherExpenses1Description + "', " +
                    "'" + otherExpenses2Description + "', " +
                    "'" + otherExpenses3Description + "', " +
                    subcontractsAmount + ", " +
                    laborHoursEstimateDefaults + ", " +
                    laborDollarEstimateDefaults + ", " +
                    laborRateEstimateDefaults + ", " +
                    materialsEstimateDefaults + ", " +
                    otherEstimateDefaults + ", " +
                    subcontractsEstimateDefaults + ", " +
                    totalCostEstimateDefaults + ", " +
                    contractDollarEstimateDefaults + ", " +
                    profitDollarEstimateDefaults + ", " +
                    profitPercentEstimateDefaults + ", " +
                    laborHoursBudgetTotals + ", " +
                    laborDollarBudgetTotals + ", " +
                    laborRateBudgetTotals + ", " +
                    materialsBudgetTotals + ", " +
                    otherBudgetTotals + ", " +
                    subcontractsBudgetTotals + ", " +
                    totalCostBudgetTotals + ", " +
                    contractDollarBudgetTotals + ", " +
                    profitDollarBudgetTotals + ", " +
                    profitPercentBudgetTotals + ", " +
                    sundriesPercentOfMaterial + ", " +
                    salesTaxPercent + ", " +
                    asBuiltsEngineeringPercent + ", " +
                    storagePercent + ", " +
                    smallToolsPercent + ", " +
                    cartigeHandlingPercent + ", " +
                    foremanPercentOfLabor + ", " +
                    generalForemanPercentOfLabor + ", " +
                    superintendentPercentOfLabor + ", " +
                    projectManagerPercentOfLabor + ", " +
                    projectEngineerPercentOfLabor + ", " +
                    safetyMeetingPercent + ", " +
                    fringeBenefitsPercent + ", " +
                    overheadPercent + ", " +
                    profitPercent + ", " +
                    subcontractAdministrationPercent + ", " +
                    warrantyPercent + ", " +
                    bondPercent + ", " +


                    BIMRate + ", " +
                    apprenticeLaborRate + ", " +
                    electricianLaborRate + ", " +
                    foremanLaborRate + ", " +
                    generalForemanLaborRate + ", " +
                    superintendentLaborRate + ", " +
                    projectManagerLaborRate + ", " +
                    projectEngineerLaborRate + ", " +
                    safetyMeetingsLaborRate + ", " +
                    premiumTimeLaborRate + ", " +
                    sundriesCost + ", " +
                    salesTaxCost + ", " +
                    BIMCost + ", " +
                    apprenticeCost + ", " +
                    electricianCost + ", " +
                    foremanCost + ", " +
                    generalForemanCost + ", " +
                    superintendentCost + ", " +
                    premiumCost + ", " +
                    fringeBenefitsCost + ", " +
                    safetyMeetingsCost + ", " +
                    projectManagerCost + ", " +
                    projectEngineerCost + ", " +
                    totalLaborCost + ", " +
                    asBuiltsEngineeringCost + ", " +
                    storageCost + ", " +
                    smallToolsCost + ", " +
                    cartigeHandlingCost + ", " +
                    totalExpensesCost + ", " +
                    materialsLaborExpensesCost + ", " +
                    overheadCost + ", " +
                    materialsLaborExpensesOverheadCost + ", " +
                    profitCost + ", " +
                    overheadProfitCost + ", " +
                    subcontractAdministrationCost + ", " +
                    overheadProfitSubcontractsAmountSubcontractAdministrationCost + ", " +
                    warrantyCost + ", " +
                    bondCost + ", " +
                    "'" + letterWorkDescription + "', " +
                    "'" + letterExclusion + "', " +
                    letterTimeExtension + ", " +
                    contactID + ", " +

                    BIMRateOT + ", " +
                    apprenticeLaborRateOT + ", " +
                    electricianLaborRateOT + ", " +
                    foremanLaborRateOT + ", " +
                    generalForemanLaborRateOT + ", " +
                    superintendentLaborRateOT + ", " +
                    projectManagerLaborRateOT + ", " +
                    projectEngineerLaborRateOT + ", " +
                    safetyMeetingsLaborRateOT + ", " +
                    premiumTimeLaborRateOT + ", " +

                    BIMRateDT + ", " +
                    apprenticeLaborRateDT + ", " +
                    electricianLaborRateDT + ", " +
                    foremanLaborRateDT + ", " +
                    generalForemanLaborRateDT + ", " +
                    superintendentLaborRateDT + ", " +
                    projectManagerLaborRateDT + ", " +
                    projectEngineerLaborRateDT + ", " +
                    safetyMeetingsLaborRateDT + ", " +
                    premiumTimeLaborRateDT + ", " +

                    estimatedBIMHoursOT + ", " +
                    estimatedApprenticeHoursOT + ", " +
                    estimatedElectricianHoursOT + ", " +
                    estimatedBIMHoursDT + ", " +
                    estimatedApprenticeHoursDT + ", " +
                    estimatedElectricianHoursDT + ", " +

                    foremanDefaultHoursOT + ", " +
                    generalForemanDefaultHoursOT + ", " +
                    superintendentDefaultHoursOT + ", " +
                    projectManagerDefaultHoursOT + ", " +
                    projectEngineerDefaultHoursOT + ", " +
                    foremanDefaultHoursDT + ", " +
                    generalForemanDefaultHoursDT + ", " +
                    superintendentDefaultHoursDT + ", " +
                    projectManagerDefaultHoursDT + ", " +
                    projectEngineerDefaultHoursDT + ", " +
                    foremanActualHoursOT + ", " +
                    generalForemanActualHoursOT + ", " +
                    superintendentActualHoursOT + ", " +
                    projectManagerActualHoursOT + ", " +
                    projectEngineerActualHoursOT + ", " +
                    premiumHoursActualHoursOT + ", " +
                    foremanActualHoursDT + ", " +
                    generalForemanActualHoursDT + ", " +
                    superintendentActualHoursDT + ", " +
                    projectManagerActualHoursDT + ", " +
                    projectEngineerActualHoursDT + ", " +
                    premiumHoursActualHoursDT + ", " +

                    "'" + asBuiltsEngineeringPercentText + "', " +
                    "'" + storagePercentText + "', " +
                    "'" + smallToolsPercentText + "', " +
                    "'" + cartigeHandlingPercentText + "', " +

                    "'" + overheadPercentText + "', " +
                    "'" + profitPercentText + "', " +
                    "'" + subcontractAdministrationPercentText + "', " +
                    "'" + warrantyPercentText + "', " +
                    "'" + bondPercentText + "', " +
                    "1," +
                    "'" + from + "', " +

                    "'" + BIMRate_Label.Trim() + "'," +
                    "'" + apprenticeLaborRate_Label.Trim() + "'," +
                    "'" + electricianLaborRate_Label.Trim() + "'," +
                    "'" + foremanLaborRate_Label.Trim() + "'," +
                    "'" + generalForemanLaborRate_Label.Trim() + "'," +
                    "'" + superintendentLaborRate_Label.Trim() + "'," +
                    "'" + projectManagerLaborRate_Label.Trim() + "'," +
                    "'" + projectEngineerLaborRate_Label.Trim() + "'," +
                    "'" + safetyMeetingsLaborRate_Label.Trim() + "'," +
                    "'" + premiumTimeLaborRate_Label.Trim() + "'," +
                                         "'" + FringeBenefitsPercent_Label.Trim() + "'," +
                    "'" + SafetyMeetingPercent_Label.Trim() + "' " +



                    " ) " +
                    "Select @@IDENTITY ";
            try
            {
                jobChangeOrderID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                // Get JobChange Order Number //
                query = "SELECT JobChangeOrderNumber FROM tblJobChangeOrder WHERE JobChangeOrderID =  " + jobChangeOrderID + " ";
                jobChangeOrderNumber = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0].Rows[0][0].ToString();
                // Whenever a change Order is created create a revision (000) for that change order
                CreateChangeOrderRevision(jobChangeOrderID);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool Update(string rev, bool changeOrderStatus, bool isCostCodeUpdate)
        {
            string query = "";
            #region Query
            query = "Update tblJobChangeOrder SET " +
                    " jobChangeOrderRequestDate       = " + jobChangeOrderRequestDate + ", " +
                    " JobChangeOrderRequestedAmount   = " + jobChangeOrderRequestedAmount + ", " +
                    " jobChangeOrderApprovedDate      = " + jobChangeOrderApprovedDate + ", " +
                    " JobChangeOrderApprovedAmount    = " + jobChangeOrderApprovedAmount + ", " +
                    " JobChangeOrderStatus            = '" + jobChangeOrderStatus + "', " +
                    " JobChangeOrderDescription       = '" + jobChangeOrderDescription + "', " +
                    " JobChangeOrderUpdateFlag        = " + jobChangeOrderUpdateFlag + ", " +
                    " JobChangeOrderLastUpdate        = '" + jobChangeOrderLastUpdateDate + "', " +
                    " JobChangeOrderOwnerNumber       = '" + jobChangeOrderOwnerNumber + "', " +
                    " JobChangeOrderCCENumber         = '" + jobChangeOrderCCENumber + "', " +
                    " JobChangeOrderUserDescription   = '" + jobChangeOrderUserDescription + "', " +
                    " AuditUserID                     = '" + Security.Security.LoginID + "', " +
                    " ChangeOrderAmount               = " + changeOrderAmount + ", " +
                    " PriceAdjustment                 = " + priceAdjustment + ", " +
                    " DirectMaterials                 = " + directMaterials + ", " +
                    " EstimatedBIMHours               = " + estimatedBIMHours + ", " +
                    " EstimatedApprenticeHours       = " + estimatedApprenticeHours + ", " +
                    " EstimatedElectricianHours       = " + estimatedElectricianHours + ", " +
                    " ForemanDefaultHours             = " + foremanDefaultHours + ", " +
                    " GeneralForemanDefaultHours      = " + generalForemanDefaultHours + ", " +
                    " SuperintendentDefaultHours      = " + superintendentDefaultHours + ", " +
                    " ProjectManagerDefaultHours      = " + projectManagerDefaultHours + ", " +
                    " ProjectEngineerDefaultHours     = " + projectEngineerDefaultHours + ", " +
                    " ForemanActualHours              = " + foremanActualHours + ", " +
                    " GeneralForemanActualHours       = " + generalForemanActualHours + ", " +
                    " SuperintendentActualHours       = " + superintendentActualHours + ", " +
                    " ProjectManagerActualHours       = " + projectManagerActualHours + ", " +
                    " ProjectEngineerActualHours      = " + projectEngineerActualHours + ", " +
                    " PremiumHoursActualHours         = " + premiumHoursActualHours + ", " +
                    " OtherExpenses1                  = " + otherExpenses1 + ", " +
                    " OtherExpenses2                  = " + otherExpenses2 + ", " +
                    " OtherExpenses3                  = " + otherExpenses3 + ", " +
                    " OtherExpenses1Description       = '" + otherExpenses1Description + "', " +
                    " OtherExpenses2Description       = '" + otherExpenses2Description + "', " +
                    " OtherExpenses3Description       = '" + otherExpenses3Description + "', " +
                    " SubcontractsAmount              = " + subcontractsAmount + ", " +
                    " LaborHoursEstimateDefaults      = " + laborHoursEstimateDefaults + ", " +
                    " LaborDollarEstimateDefaults     = " + laborDollarEstimateDefaults + ", " +
                    " LaborRateEstimateDefaults       = " + laborRateEstimateDefaults + ", " +
                    " MaterialsEstimateDefaults       = " + materialsEstimateDefaults + ", " +
                    " OtherEstimateDefaults           = " + otherEstimateDefaults + ", " +
                    " SubcontractsEstimateDefaults    = " + subcontractsEstimateDefaults + ", " +
                    " TotalCostEstimateDefaults       = " + totalCostEstimateDefaults + ", " +
                    " ContractDollarEstimateDefaults  = " + contractDollarEstimateDefaults + ", " +
                    " ProfitDollarEstimateDefaults    = " + profitDollarEstimateDefaults + ", " +
                    " ProfitPercentEstimateDefaults   = " + profitPercentEstimateDefaults + ", " +
                    " LaborHoursBudgetTotals          = " + laborHoursBudgetTotals + ", " +
                    " LaborDollarBudgetTotals         = " + laborDollarBudgetTotals + ", " +
                    " LaborRateBudgetTotals           = " + laborRateBudgetTotals + ", " +
                    " MaterialsBudgetTotals           = " + materialsBudgetTotals + ", " +
                    " OtherBudgetTotals               = " + otherBudgetTotals + ", " +
                    " SubcontractsBudgetTotals        = " + subcontractsBudgetTotals + ", " +
                    " TotalCostBudgetTotals           = " + totalCostBudgetTotals + ", " +
                    " ContractDollarBudgetTotals      = " + contractDollarBudgetTotals + ", " +
                    " ProfitDollarBudgetTotals        = " + profitDollarBudgetTotals + ", " +
                    " ProfitPercentBudgetTotals       = " + profitPercentBudgetTotals + ", " +
                    " SundriesPercentOfMaterial       = " + sundriesPercentOfMaterial + ", " +
                    " SalesTaxPercent                 = " + salesTaxPercent + ", " +
                    " AsBuiltsEngineeringPercent      = " + asBuiltsEngineeringPercent + ", " +
                    " StoragePercent                  = " + storagePercent + ", " +
                    " SmallToolsPercent               = " + smallToolsPercent + ", " +
                    " CartigeHandlingPercent          = " + cartigeHandlingPercent + ", " +
                    " ForemanPercentOfLabor           = " + foremanPercentOfLabor + ", " +
                    " GeneralForemanPercentOfLabor    = " + generalForemanPercentOfLabor + ", " +
                    " SuperintendentPercentOfLabor    = " + superintendentPercentOfLabor + ", " +
                    " ProjectManagerPercentOfLabor    = " + projectManagerPercentOfLabor + ", " +
                    " ProjectEngineerPercentOfLabor   = " + projectEngineerPercentOfLabor + ", " +
                    " SafetyMeetingPercent            = " + safetyMeetingPercent + ", " +
                    " FringeBenefitsPercent           = " + fringeBenefitsPercent + ", " +
                    " OverheadPercent                 = " + overheadPercent + ", " +
                    " ProfitPercent                   = " + profitPercent + ", " +
                    " SubcontractAdministrationPercent = " + subcontractAdministrationPercent + ", " +
                    " WarrantyPercent                 = " + warrantyPercent + ", " +
                    " BondPercent                     = " + bondPercent + ", " +

                    " BIMRate                        = " + BIMRate + ", " +
                    " ApprenticeLaborRate            = " + apprenticeLaborRate + ", " +
                    " ElectricianLaborRate            = " + electricianLaborRate + ", " +
                    " ForemanLaborRate                = " + foremanLaborRate + ", " +
                    " GeneralForemanLaborRate         = " + generalForemanLaborRate + ", " +
                    " SuperintendentLaborRate         = " + superintendentLaborRate + ", " +
                    " ProjectManagerLaborRate         = " + projectManagerLaborRate + ", " +
                    " ProjectEngineerLaborRate        = " + projectEngineerLaborRate + ", " +
                    " SafetyMeetingsLaborRate         = " + safetyMeetingsLaborRate + ", " +
                    " PremiumTimeLaborRate            = " + premiumTimeLaborRate + ", " +
                    " SundriesCost                    = " + sundriesCost + ", " +
                    " SalesTaxCost                    = " + salesTaxCost + ", " +
                    " BIMCost                         = " + BIMCost + ", " +
                    " ApprenticeCost                    = " + apprenticeCost + ", " +
                    " ElectricianCost                 = " + electricianCost + ", " +
                    " ForemanCost                     = " + foremanCost + ", " +
                    " GeneralForemanCost              = " + generalForemanCost + ", " +
                    " SuperintendentCost              = " + superintendentCost + ", " +
                    " PremiumCost                     = " + premiumCost + ", " +
                    " FringeBenefitsCost              = " + fringeBenefitsCost + ", " +
                    " SafetyMeetingsCost              = " + safetyMeetingsCost + ", " +
                    " ProjectManagerCost              = " + projectManagerCost + ", " +
                    " ProjectEngineerCost             = " + projectEngineerCost + ", " +
                    " TotalLaborCost                  = " + totalLaborCost + ", " +
                    " AsBuiltsEngineeringCost         = " + asBuiltsEngineeringCost + ", " +
                    " StorageCost                     = " + storageCost + ", " +
                    " SmallToolsCost                  = " + smallToolsCost + ", " +
                    " CartigeHandlingCost             = " + cartigeHandlingCost + ", " +
                    " TotalExpensesCost               = " + totalExpensesCost + ", " +
                    " MaterialsLaborExpensesCost      = " + materialsLaborExpensesCost + ", " +
                    " OverheadCost                    = " + overheadCost + ", " +
                    " MaterialsLaborExpensesOverheadCost = " + materialsLaborExpensesOverheadCost + ", " +
                    " ProfitCost                      = " + profitCost + ", " +
                    " OverheadProfitCost              = " + overheadProfitCost + ", " +
                    " SubcontractAdministrationCost  =  " + subcontractAdministrationCost + ", " +
                    " OverheadProfitSubcontractsAmountSubcontractAdministrationCost = " + overheadProfitSubcontractsAmountSubcontractAdministrationCost + ", " +
                    " WarrantyCost                     = " + warrantyCost + ", " +
                    " BondCost                         = " + bondCost + ",  " +
                    " LetterWorkDescription               = '" + letterWorkDescription + "', " +
                    " LetterExclusion                   = '" + letterExclusion + "', " +
                    " letterTimeExtension               = " + letterTimeExtension + ", " +
                    " ContactID                         = " + contactID + ", " +
                    " [From]                              = '" + from + "', " +
                    " BIMRateOT                          =  " + BIMRateOT + ", " +
                    " ApprenticeLaborRateOT                =  " + apprenticeLaborRateOT + ", " +
                    " ElectricianLaborRateOT               =  " + electricianLaborRateOT + ", " +
                    " ForemanLaborRateOT                   =  " + foremanLaborRateOT + ", " +
                    " GeneralForemanLaborRateOT            =  " + generalForemanLaborRateOT + ", " +
                    " SuperintendentLaborRateOT            =  " + superintendentLaborRateOT + ", " +
                    " ProjectManagerLaborRateOT            =  " + projectManagerLaborRateOT + ", " +
                    " ProjectEngineerLaborRateOT           =  " + projectEngineerLaborRateOT + ", " +
                    " SafetyMeetingsLaborRateOT            =  " + safetyMeetingsLaborRateOT + ", " +
                    " PremiumTimeLaborRateOT               =  " + premiumTimeLaborRateOT + ", " +

                    " BIMRateDT                            = " + BIMRateDT + ", " +
                    " ApprenticeLaborRateDT                =  " + apprenticeLaborRateDT + ", " +
                    " ElectricianLaborRateDT               =  " + electricianLaborRateDT + ", " +
                    " ForemanLaborRateDT                   =  " + foremanLaborRateDT + ", " +
                    " GeneralForemanLaborRateDT            =  " + generalForemanLaborRateDT + ", " +
                    " SuperintendentLaborRateDT            =  " + superintendentLaborRateDT + ", " +
                    " ProjectManagerLaborRateDT            =  " + projectManagerLaborRateDT + ", " +
                    " ProjectEngineerLaborRateDT           =  " + projectEngineerLaborRateDT + ", " +
                    " SafetyMeetingsLaborRateDT            =  " + safetyMeetingsLaborRateDT + ", " +
                    " PremiumTimeLaborRateDT               =  " + premiumTimeLaborRateDT + ", " +

                    " EstimatedBIMHoursOT                   = " + estimatedBIMHoursOT + ", " +
                    " EstimatedApprenticeHoursOT            = " + estimatedApprenticeHoursOT + " , " +
                    " EstimatedElectricianHoursOT           = " + estimatedElectricianHoursOT + ", " +
                    " EstimatedBIMHoursDT                   = " + estimatedBIMHoursDT + ", " +
                    " EstimatedApprenticeHoursDT            = " + estimatedApprenticeHoursDT + ", " +
                    " EstimatedElectricianHoursDT           = " + estimatedElectricianHoursDT + ", " +


                     " ForemanDefaultHoursOT                = " + foremanDefaultHoursOT + ", " +
                    " GeneralForemanDefaultHoursOT          = " + generalForemanDefaultHoursOT + ", " +
                    " SuperintendentDefaultHoursOT          = " + superintendentDefaultHoursOT + ", " +
                    " ProjectManagerDefaultHoursOT          = " + projectManagerDefaultHoursOT + ", " +
                    " ProjectEngineerDefaultHoursOT         = " + projectEngineerDefaultHoursOT + ", " +
                    " ForemanDefaultHoursDT                 = " + foremanDefaultHoursDT + ", " +
                    " GeneralForemanDefaultHoursDT          = " + generalForemanDefaultHoursDT + ", " +
                    " SuperintendentDefaultHoursDT          = " + superintendentDefaultHoursDT + ", " +
                    " ProjectManagerDefaultHoursDT          = " + projectManagerDefaultHoursDT + ", " +
                    " ProjectEngineerDefaultHoursDT         = " + projectEngineerDefaultHoursDT + ", " +
                    " ForemanActualHoursOT                  = " + foremanActualHoursOT + ", " +
                    " GeneralForemanActualHoursOT           = " + generalForemanActualHoursOT + ", " +
                    " SuperintendentActualHoursOT           = " + superintendentActualHoursOT + ", " +
                    " ProjectManagerActualHoursOT           = " + projectManagerActualHoursOT + ", " +
                    " ProjectEngineerActualHoursOT          = " + projectEngineerActualHoursOT + ", " +
                    " PremiumHoursActualHoursOT             = " + premiumHoursActualHoursOT + ", " +
                    " ForemanActualHoursDT                  = " + foremanActualHoursDT + ", " +
                    " GeneralForemanActualHoursDT           = " + generalForemanActualHoursDT + ", " +
                    " SuperintendentActualHoursDT           = " + superintendentActualHoursDT + ", " +
                    " ProjectManagerActualHoursDT           = " + projectManagerActualHoursDT + ", " +
                    " ProjectEngineerActualHoursDT          = " + projectEngineerActualHoursDT + ", " +
                    " PremiumHoursActualHoursDT             = " + premiumHoursActualHoursDT + "," +

                    " AsBuiltsEngineeringPercentText        = '" + asBuiltsEngineeringPercentText + "'," +
                    " storagePercentText                    = '" + storagePercentText + "'," +
                    " smallToolsPercentText                 = '" + smallToolsPercentText + "'," +
                    " cartigeHandlingPercentText            = '" + cartigeHandlingPercentText + "'," +

                    " overheadPercentText                   = '" + overheadPercentText + "'," +
                    " profitPercentText                     = '" + profitPercentText + "'," +
                    " subcontractAdministrationPercentText  = '" + subcontractAdministrationPercentText + "'," +
                    " warrantyPercentText                   = '" + warrantyPercentText + "'," +
                    " bondPercentText                       = '" + bondPercentText + "', " +


                    " BIMRate_Label                            =  '" + BIMRate_Label.Trim() + "'," +
                    " ApprenticeLaborRate_Label                = '" + apprenticeLaborRate_Label.Trim() + "'," +
                    " ElectricianLaborRate_Label               =  '" + electricianLaborRate_Label.Trim() + "'," +
                    " ForemanLaborRate_Label                  = '" + foremanLaborRate_Label.Trim() + "'," +
                    " GeneralForemanLaborRate_Label            = '" + generalForemanLaborRate_Label.Trim() + "'," +
                    " SuperintendentLaborRate_Label           =  '" + superintendentLaborRate_Label.Trim() + "'," +
                    " ProjectManagerLaborRate_Label            = '" + projectManagerLaborRate_Label.Trim() + "'," +
                    " ProjectEngineerLaborRate_Label           = '" + projectEngineerLaborRate_Label.Trim() + "'," +
                    " SafetyMeetingsLaborRate_Label            =  '" + safetyMeetingsLaborRate_Label.Trim() + "'," +
                    " PremiumTimeLaborRate_Label               =  '" + premiumTimeLaborRate_Label.Trim() + "'," +
                     " FringeBenefitsPercent_Label               =  '" + FringeBenefitsPercent_Label.Trim() + "'," +
                    " SafetyMeetingPercent_Label               =  '" + SafetyMeetingPercent_Label.Trim() + "' " +



                    " WHERE JobChangeOrderID = " + jobChangeOrderID;
            #endregion Query
            try
            {
                //if (rev.Trim() == "000".Trim() || string.IsNullOrEmpty(rev)) // Anu Needs to change
                //{
                    DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                //}
                // Uupdate Revision Table
                if (rev.Trim() != "000".Trim() || (!string.IsNullOrEmpty(rev)))
                //if (changeOrderStatus)
                {
                    UpdateRevision(rev, isCostCodeUpdate);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool UpdateRevision(string rev, bool isCostCodeUpdate)
        {
            string query = "";

            #region Query
            query = "Update tblJobChangeOrderRev SET " +
                    " jobChangeOrderRequestDate       = " + jobChangeOrderRequestDate + ", " +
                    " JobChangeOrderRequestedAmount   = " + jobChangeOrderRequestedAmount + ", " +
                    " jobChangeOrderApprovedDate      = " + jobChangeOrderApprovedDate + ", " +
                    " JobChangeOrderApprovedAmount    = " + jobChangeOrderApprovedAmount + ", " +
                    " JobChangeOrderStatus            = '" + jobChangeOrderStatus + "', " +
                    " JobChangeOrderDescription       = '" + jobChangeOrderDescription + "', " +
                    " JobChangeOrderUpdateFlag        = " + jobChangeOrderUpdateFlag + ", " +
                    " JobChangeOrderLastUpdate        = '" + jobChangeOrderLastUpdateDate + "', " +
                    " JobChangeOrderOwnerNumber       = '" + jobChangeOrderOwnerNumber + "', " +
                    " JobChangeOrderCCENumber         = '" + jobChangeOrderCCENumber + "', " +
                    " JobChangeOrderUserDescription   = '" + jobChangeOrderUserDescription + "', " +
                    " AuditUserID                     = '" + Security.Security.LoginID + "', " +
                    " ChangeOrderAmount               = " + changeOrderAmount + ", " +
                    " PriceAdjustment                 = " + priceAdjustment + ", " +
                    " DirectMaterials                 = " + directMaterials + ", " +
                    " EstimatedBIMHours               = " + estimatedBIMHours + ", " +
                    " EstimatedApprenticeHours       = " + estimatedApprenticeHours + ", " +
                    " EstimatedElectricianHours       = " + estimatedElectricianHours + ", " +
                    " ForemanDefaultHours             = " + foremanDefaultHours + ", " +
                    " GeneralForemanDefaultHours      = " + generalForemanDefaultHours + ", " +
                    " SuperintendentDefaultHours      = " + superintendentDefaultHours + ", " +
                    " ProjectManagerDefaultHours      = " + projectManagerDefaultHours + ", " +
                    " ProjectEngineerDefaultHours     = " + projectEngineerDefaultHours + ", " +
                    " ForemanActualHours              = " + foremanActualHours + ", " +
                    " GeneralForemanActualHours       = " + generalForemanActualHours + ", " +
                    " SuperintendentActualHours       = " + superintendentActualHours + ", " +
                    " ProjectManagerActualHours       = " + projectManagerActualHours + ", " +
                    " ProjectEngineerActualHours      = " + projectEngineerActualHours + ", " +
                    " PremiumHoursActualHours         = " + premiumHoursActualHours + ", " +
                    " OtherExpenses1                  = " + otherExpenses1 + ", " +
                    " OtherExpenses2                  = " + otherExpenses2 + ", " +
                    " OtherExpenses3                  = " + otherExpenses3 + ", " +
                    " OtherExpenses1Description       = '" + otherExpenses1Description + "', " +
                    " OtherExpenses2Description       = '" + otherExpenses2Description + "', " +
                    " OtherExpenses3Description       = '" + otherExpenses3Description + "', " +
                    " SubcontractsAmount              = " + subcontractsAmount + ", " +
                    " LaborHoursEstimateDefaults      = " + laborHoursEstimateDefaults + ", " +
                    " LaborDollarEstimateDefaults     = " + laborDollarEstimateDefaults + ", " +
                    " LaborRateEstimateDefaults       = " + laborRateEstimateDefaults + ", " +
                    " MaterialsEstimateDefaults       = " + materialsEstimateDefaults + ", " +
                    " OtherEstimateDefaults           = " + otherEstimateDefaults + ", " +
                    " SubcontractsEstimateDefaults    = " + subcontractsEstimateDefaults + ", " +
                    " TotalCostEstimateDefaults       = " + totalCostEstimateDefaults + ", " +
                    " ContractDollarEstimateDefaults  = " + contractDollarEstimateDefaults + ", " +
                    " ProfitDollarEstimateDefaults    = " + profitDollarEstimateDefaults + ", " +
                    " ProfitPercentEstimateDefaults   = " + profitPercentEstimateDefaults + ", " +
                    " LaborHoursBudgetTotals          = " + laborHoursBudgetTotals + ", " +
                    " LaborDollarBudgetTotals         = " + laborDollarBudgetTotals + ", " +
                    " LaborRateBudgetTotals           = " + laborRateBudgetTotals + ", " +
                    " MaterialsBudgetTotals           = " + materialsBudgetTotals + ", " +
                    " OtherBudgetTotals               = " + otherBudgetTotals + ", " +
                    " SubcontractsBudgetTotals        = " + subcontractsBudgetTotals + ", " +
                    " TotalCostBudgetTotals           = " + totalCostBudgetTotals + ", " +
                    " ContractDollarBudgetTotals      = " + contractDollarBudgetTotals + ", " +
                    " ProfitDollarBudgetTotals        = " + profitDollarBudgetTotals + ", " +
                    " ProfitPercentBudgetTotals       = " + profitPercentBudgetTotals + ", " +
                    " SundriesPercentOfMaterial       = " + sundriesPercentOfMaterial + ", " +
                    " SalesTaxPercent                 = " + salesTaxPercent + ", " +
                    " AsBuiltsEngineeringPercent      = " + asBuiltsEngineeringPercent + ", " +
                    " StoragePercent                  = " + storagePercent + ", " +
                    " SmallToolsPercent               = " + smallToolsPercent + ", " +
                    " CartigeHandlingPercent          = " + cartigeHandlingPercent + ", " +
                    " ForemanPercentOfLabor           = " + foremanPercentOfLabor + ", " +
                    " GeneralForemanPercentOfLabor    = " + generalForemanPercentOfLabor + ", " +
                    " SuperintendentPercentOfLabor    = " + superintendentPercentOfLabor + ", " +
                    " ProjectManagerPercentOfLabor    = " + projectManagerPercentOfLabor + ", " +
                    " ProjectEngineerPercentOfLabor   = " + projectEngineerPercentOfLabor + ", " +
                    " SafetyMeetingPercent            = " + safetyMeetingPercent + ", " +
                    " FringeBenefitsPercent           = " + fringeBenefitsPercent + ", " +
                    " OverheadPercent                 = " + overheadPercent + ", " +
                    " ProfitPercent                   = " + profitPercent + ", " +
                    " SubcontractAdministrationPercent = " + subcontractAdministrationPercent + ", " +
                    " WarrantyPercent                 = " + warrantyPercent + ", " +
                    " BondPercent                     = " + bondPercent + ", " +

                    " BIMRate                        = " + BIMRate + ", " +
                    " ApprenticeLaborRate            = " + apprenticeLaborRate + ", " +
                    " ElectricianLaborRate            = " + electricianLaborRate + ", " +
                    " ForemanLaborRate                = " + foremanLaborRate + ", " +
                    " GeneralForemanLaborRate         = " + generalForemanLaborRate + ", " +
                    " SuperintendentLaborRate         = " + superintendentLaborRate + ", " +
                    " ProjectManagerLaborRate         = " + projectManagerLaborRate + ", " +
                    " ProjectEngineerLaborRate        = " + projectEngineerLaborRate + ", " +
                    " SafetyMeetingsLaborRate         = " + safetyMeetingsLaborRate + ", " +
                    " PremiumTimeLaborRate            = " + premiumTimeLaborRate + ", " +
                    " SundriesCost                    = " + sundriesCost + ", " +
                    " SalesTaxCost                    = " + salesTaxCost + ", " +
                    " BIMCost                         = " + BIMCost + ", " +
                    " ApprenticeCost                    = " + apprenticeCost + ", " +
                    " ElectricianCost                 = " + electricianCost + ", " +
                    " ForemanCost                     = " + foremanCost + ", " +
                    " GeneralForemanCost              = " + generalForemanCost + ", " +
                    " SuperintendentCost              = " + superintendentCost + ", " +
                    " PremiumCost                     = " + premiumCost + ", " +
                    " FringeBenefitsCost              = " + fringeBenefitsCost + ", " +
                    " SafetyMeetingsCost              = " + safetyMeetingsCost + ", " +
                    " ProjectManagerCost              = " + projectManagerCost + ", " +
                    " ProjectEngineerCost             = " + projectEngineerCost + ", " +
                    " TotalLaborCost                  = " + totalLaborCost + ", " +
                    " AsBuiltsEngineeringCost         = " + asBuiltsEngineeringCost + ", " +
                    " StorageCost                     = " + storageCost + ", " +
                    " SmallToolsCost                  = " + smallToolsCost + ", " +
                    " CartigeHandlingCost             = " + cartigeHandlingCost + ", " +
                    " TotalExpensesCost               = " + totalExpensesCost + ", " +
                    " MaterialsLaborExpensesCost      = " + materialsLaborExpensesCost + ", " +
                    " OverheadCost                    = " + overheadCost + ", " +
                    " MaterialsLaborExpensesOverheadCost = " + materialsLaborExpensesOverheadCost + ", " +
                    " ProfitCost                      = " + profitCost + ", " +
                    " OverheadProfitCost              = " + overheadProfitCost + ", " +
                    " SubcontractAdministrationCost  =  " + subcontractAdministrationCost + ", " +
                    " OverheadProfitSubcontractsAmountSubcontractAdministrationCost = " + overheadProfitSubcontractsAmountSubcontractAdministrationCost + ", " +
                    " WarrantyCost                     = " + warrantyCost + ", " +
                    " BondCost                         = " + bondCost + ",  " +
                    " LetterWorkDescription               = '" + letterWorkDescription + "', " +
                    " LetterExclusion                   = '" + letterExclusion + "', " +
                    " letterTimeExtension               = " + letterTimeExtension + ", " +
                    " ContactID                         = " + contactID + ", " +
                    " [From]                              = '" + from + "', " +
                    " BIMRateOT                          =  " + BIMRateOT + ", " +
                    " ApprenticeLaborRateOT                =  " + apprenticeLaborRateOT + ", " +
                    " ElectricianLaborRateOT               =  " + electricianLaborRateOT + ", " +
                    " ForemanLaborRateOT                   =  " + foremanLaborRateOT + ", " +
                    " GeneralForemanLaborRateOT            =  " + generalForemanLaborRateOT + ", " +
                    " SuperintendentLaborRateOT            =  " + superintendentLaborRateOT + ", " +
                    " ProjectManagerLaborRateOT            =  " + projectManagerLaborRateOT + ", " +
                    " ProjectEngineerLaborRateOT           =  " + projectEngineerLaborRateOT + ", " +
                    " SafetyMeetingsLaborRateOT            =  " + safetyMeetingsLaborRateOT + ", " +
                    " PremiumTimeLaborRateOT               =  " + premiumTimeLaborRateOT + ", " +

                    " BIMRateDT                            = " + BIMRateDT + ", " +
                    " ApprenticeLaborRateDT                =  " + apprenticeLaborRateDT + ", " +
                    " ElectricianLaborRateDT               =  " + electricianLaborRateDT + ", " +
                    " ForemanLaborRateDT                   =  " + foremanLaborRateDT + ", " +
                    " GeneralForemanLaborRateDT            =  " + generalForemanLaborRateDT + ", " +
                    " SuperintendentLaborRateDT            =  " + superintendentLaborRateDT + ", " +
                    " ProjectManagerLaborRateDT            =  " + projectManagerLaborRateDT + ", " +
                    " ProjectEngineerLaborRateDT           =  " + projectEngineerLaborRateDT + ", " +
                    " SafetyMeetingsLaborRateDT            =  " + safetyMeetingsLaborRateDT + ", " +
                    " PremiumTimeLaborRateDT               =  " + premiumTimeLaborRateDT + ", " +

                    " EstimatedBIMHoursOT                   = " + estimatedBIMHoursOT + ", " +
                    " EstimatedApprenticeHoursOT            = " + estimatedApprenticeHoursOT + " , " +
                    " EstimatedElectricianHoursOT           = " + estimatedElectricianHoursOT + ", " +
                    " EstimatedBIMHoursDT                   = " + estimatedBIMHoursDT + ", " +
                    " EstimatedApprenticeHoursDT            = " + estimatedApprenticeHoursDT + ", " +
                    " EstimatedElectricianHoursDT           = " + estimatedElectricianHoursDT + ", " +


                     " ForemanDefaultHoursOT                = " + foremanDefaultHoursOT + ", " +
                    " GeneralForemanDefaultHoursOT          = " + generalForemanDefaultHoursOT + ", " +
                    " SuperintendentDefaultHoursOT          = " + superintendentDefaultHoursOT + ", " +
                    " ProjectManagerDefaultHoursOT          = " + projectManagerDefaultHoursOT + ", " +
                    " ProjectEngineerDefaultHoursOT         = " + projectEngineerDefaultHoursOT + ", " +
                    " ForemanDefaultHoursDT                 = " + foremanDefaultHoursDT + ", " +
                    " GeneralForemanDefaultHoursDT          = " + generalForemanDefaultHoursDT + ", " +
                    " SuperintendentDefaultHoursDT          = " + superintendentDefaultHoursDT + ", " +
                    " ProjectManagerDefaultHoursDT          = " + projectManagerDefaultHoursDT + ", " +
                    " ProjectEngineerDefaultHoursDT         = " + projectEngineerDefaultHoursDT + ", " +
                    " ForemanActualHoursOT                  = " + foremanActualHoursOT + ", " +
                    " GeneralForemanActualHoursOT           = " + generalForemanActualHoursOT + ", " +
                    " SuperintendentActualHoursOT           = " + superintendentActualHoursOT + ", " +
                    " ProjectManagerActualHoursOT           = " + projectManagerActualHoursOT + ", " +
                    " ProjectEngineerActualHoursOT          = " + projectEngineerActualHoursOT + ", " +
                    " PremiumHoursActualHoursOT             = " + premiumHoursActualHoursOT + ", " +
                    " ForemanActualHoursDT                  = " + foremanActualHoursDT + ", " +
                    " GeneralForemanActualHoursDT           = " + generalForemanActualHoursDT + ", " +
                    " SuperintendentActualHoursDT           = " + superintendentActualHoursDT + ", " +
                    " ProjectManagerActualHoursDT           = " + projectManagerActualHoursDT + ", " +
                    " ProjectEngineerActualHoursDT          = " + projectEngineerActualHoursDT + ", " +
                    " PremiumHoursActualHoursDT             = " + premiumHoursActualHoursDT + "," +

                    " AsBuiltsEngineeringPercentText        = '" + asBuiltsEngineeringPercentText + "'," +
                    " storagePercentText                    = '" + storagePercentText + "'," +
                    " smallToolsPercentText                 = '" + smallToolsPercentText + "'," +
                    " cartigeHandlingPercentText            = '" + cartigeHandlingPercentText + "'," +

                    " overheadPercentText                   = '" + overheadPercentText + "'," +
                    " profitPercentText                     = '" + profitPercentText + "'," +
                    " subcontractAdministrationPercentText  = '" + subcontractAdministrationPercentText + "'," +
                    " warrantyPercentText                   = '" + warrantyPercentText + "'," +


                    " bondPercentText                       = '" + bondPercentText + "', " +


                    " BIMRate_Label                            =  '" + BIMRate_Label.Trim() + "'," +
                    " ApprenticeLaborRate_Label                = '" + apprenticeLaborRate_Label.Trim() + "'," +
                    " ElectricianLaborRate_Label               =  '" + electricianLaborRate_Label.Trim() + "'," +
                    " ForemanLaborRate_Label                  = '" + foremanLaborRate_Label.Trim() + "'," +
                    " GeneralForemanLaborRate_Label            = '" + generalForemanLaborRate_Label.Trim() + "'," +
                    " SuperintendentLaborRate_Label           =  '" + superintendentLaborRate_Label.Trim() + "'," +
                    " ProjectManagerLaborRate_Label            = '" + projectManagerLaborRate_Label.Trim() + "'," +
                    " ProjectEngineerLaborRate_Label           = '" + projectEngineerLaborRate_Label.Trim() + "'," +
                    " SafetyMeetingsLaborRate_Label            =  '" + safetyMeetingsLaborRate_Label.Trim() + "'," +
                    " PremiumTimeLaborRate_Label               =  '" + premiumTimeLaborRate_Label.Trim() + "'," +
                     " FringeBenefitsPercent_Label               =  '" + FringeBenefitsPercent_Label.Trim() + "'," +
                    " SafetyMeetingPercent_Label               =  '" + SafetyMeetingPercent_Label.Trim() + "'" +



                    " WHERE  JobChangeOrderID = " + jobChangeOrderID + " AND Rev = '" + rev + "'";
            #endregion Query

            try
            {
                string activeRev = GetLatestChangeOrderRevision(jobChangeOrderID);
                if (activeRev == rev)
                {
                    DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                }
                else
                {
                    // While updating previous Revision update the revision and create new revision which will be latest active revision.
                    //CreateChangeOrderFromRevision(jobChangeOrderID, rev);
                    UpdateInActiveRevision(JobChangeOrderID, rev);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool ChangeOrderStatus(string jobChangeOrderID)
        {
            bool status = false;
            string query = " SELECT IsNew " +
                            " FROM tblJobChangeOrder WHERE JobChangeOrderID = " + jobChangeOrderID + " ";

            try
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                return status = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsNew"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetLatestChangeOrderRevision(string jobChangeOrderID)
        {
            string query = "";
            string rev = "";
            query = " select  MAX(rev) as Rev from tblJobChangeOrderRev where   JobChangeOrderID=" + jobChangeOrderID;
            try
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                return rev = Convert.ToString(ds.Tables[0].Rows[0]["Rev"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
