using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using ContraCostaElectric.DatabaseUtil;
using BakirAndAssociates.DatabaseUtil;

using System.Reflection;
using System.Threading.Tasks;

//
//

namespace JCCBusinessLayer
{

    public class StaticTables
    {
        public static DataTable Customers;
        public static DataTable WorkType;
        public static DataTable ContractType;
        public static DataTable ProjectManager;
        public static DataTable Estimator;
        public static DataTable Superintendent;
        public static DataTable Foreman;
        public static DataTable OwnerClass;
        public static DataTable Retainage;
        public static DataTable InsuranceProgram;
        public static DataTable Department;
        public static DataTable Office;
        public static DataTable JobStatus;
        public static DataTable Lender;
        public static DataTable WIPEntry;
        public static DataTable Bond;
        public static DataTable Jobs;
        public static DataTable Estimates;
        public static DataTable JobsList;
        public static DataTable Revision;
        public static DataTable BidBond;
        public static DataTable CostCode;
        public static DataTable ArchivePeriod;
        public static DataTable SalesRep;
        public static DataTable JobTech;
        public static DataTable Account;
        public static DataTable Vendors;
        public static DataTable Employees;
        public static DataTable Users;
        public static DataTable EstimateList;
        public static DataTable CostCodes;
        public static DataTable PrequalKeywords;
        public static DataTable UnitType;
        public static DataTable PhaseList;
        public static DataTable Subcontract;
        public static DataTable POAddress;
        public static DataTable EmployeeStatus;
        public static DataTable Apprenticeship;
        public static DataTable InjuryType;
        public static string[] DoctorNote;
        public static DataTable Type_Injury;
        public static DataTable Category;
        //
        // Dashboard flags
        //
        public static float jobPerformanceFactor = 0;
        public static float projectedProfitPercentage = 0;
        public static float profitGainFade = 0;
        public static float laborPercentage = 0;
        public static float materialPercentage = 0;
        public static float costPerformanceFactor = 0;
        public static bool isLoaded = false;
        public static string DefaultValuelistForVersion = string.Empty;
        public static bool PopulateStaticTables ()
        {
            try

            {
                DefaultValuelistForVersion = DataBaseUtil.ExecuteScalar("Select Value from DefaultValuelist where ValueName='VersionNumber'", CCEApplication.Connection, CommandType.Text);
                POAddress = DataBaseUtil.ExecuteDataset("SELECT  Type FROM tblJobPOAddress ORDER BY Type", CCEApplication.Connection, CommandType.Text).Tables[0];
                Users = DataBaseUtil.ExecuteDataset("SELECT UserID, UserName FROM tblUser Order BY UserName", CCEApplication.Connection, CommandType.Text).Tables[0];
                Employees = DataBaseUtil.ExecuteDataset("SELECT Distinct EmpName as [EmpName] FROM tblJobHour Order BY EmpName", CCEApplication.Connection, CommandType.Text).Tables[0];
                Customers = DataBaseUtil.ExecuteDataset("SELECT CustomerID, Name FROM tblCustomer ORDER BY Name", CCEApplication.Connection, CommandType.Text).Tables[0];
                WorkType = DataBaseUtil.ExecuteDataset("SELECT WorkTypeID, Description FROM tblWorkType ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                ContractType = DataBaseUtil.ExecuteDataset("SELECT ContractTypeID, Description FROM tblContractType ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                ProjectManager = DataBaseUtil.ExecuteDataset("SELECT ProjectManagerID, Description FROM tblProjectManager ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                Estimator = DataBaseUtil.ExecuteDataset("SELECT EstimatorID, Description FROM tblEstimator ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                //** Superintendent
                Superintendent = DataBaseUtil.ExecuteDataset("SELECT SuperintendentID, Description FROM tblSuperintendent ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                Foreman = DataBaseUtil.ExecuteDataset("SELECT ForemanID, Description FROM tblForeman ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];



                // ** Foremen
                //
                PrequalKeywords = DataBaseUtil.ExecuteDataset("SELECT PrequalKeywordID, PrequalKeyword FROM tblPrequalKeyword ORDER BY PrequalKeyword", CCEApplication.Connection, CommandType.Text).Tables[0];
                OwnerClass = DataBaseUtil.ExecuteDataset("SELECT OwnerClassID, Description FROM tblOwnerClass ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                Retainage = DataBaseUtil.ExecuteDataset("SELECT RetainageID, Description FROM tblRetainage ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                InsuranceProgram = DataBaseUtil.ExecuteDataset("SELECT InsuranceProgramID, Description FROM tblInsuranceProgram ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                Department = DataBaseUtil.ExecuteDataset("SELECT DepartmentID, DepartmentName FROM tblDepartment ORDER BY DepartmentName", CCEApplication.Connection, CommandType.Text).Tables[0];
                Office = DataBaseUtil.ExecuteDataset("SELECT OfficeID, OfficeName FROM tblOffice ORDER BY OfficeName", CCEApplication.Connection, CommandType.Text).Tables[0];
                JobStatus = DataBaseUtil.ExecuteDataset("SELECT JobStatusID, JobStatus FROM tblJobStatus ORDER BY JobStatus", CCEApplication.Connection, CommandType.Text).Tables[0];
                Lender = DataBaseUtil.ExecuteDataset("SELECT LenderID, Description FROM tblLender ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                WIPEntry = DataBaseUtil.ExecuteDataset("SELECT WIPEntryID, Description FROM tblWIPEntry ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                Bond = DataBaseUtil.ExecuteDataset("SELECT BondID, Description FROM tblBond", CCEApplication.Connection, CommandType.Text).Tables[0];
                Estimates = DataBaseUtil.ExecuteDataset("SELECT JobID, EstimateNumber As [Estimate Number], JobName AS [Job Name] FROM tblJob WHERE JobName > '' AND VOID = 0 ORDER BY JobDescription", CCEApplication.Connection, CommandType.Text).Tables[0];
                Jobs = DataBaseUtil.ExecuteDataset("SELECT JobID, JobNumber AS [Job Number], JobName AS [Job Name] FROM tblJob WHERE JobNumber > '' and void = 0 ORDER BY JobName", CCEApplication.Connection, CommandType.Text).Tables[0];

                Revision = DataBaseUtil.ExecuteDataset("SELECT RevisionID, RevisionDescription FROM tblRevision ORDER BY RevisionDescription ", CCEApplication.Connection, CommandType.Text).Tables[0];
                BidBond = DataBaseUtil.ExecuteDataset("SELECT BidBondID, Description FROM tblBidBond", CCEApplication.Connection, CommandType.Text).Tables[0];
                CostCode = DataBaseUtil.ExecuteDataset("SELECT * FROM tblCostCode ORDER BY CostCodePhase, CostCode", CCEApplication.Connection, CommandType.Text).Tables[0];
                ArchivePeriod = DataBaseUtil.ExecuteDataset("SELECT DISTINCT Period AS [Period] FROM tblJobBalanceHistory ORDER by Period DESC", CCEApplication.Connection, CommandType.Text).Tables[0];
                SalesRep = DataBaseUtil.ExecuteDataset("SELECT SalesRepID, Description FROM tblSalesRep ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                JobTech = DataBaseUtil.ExecuteDataset("SELECT JobTechID, Description FROM tblJobTech ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                Account = DataBaseUtil.ExecuteDataset("SELECT AccountID, ValidationCode As [Validation Code], AccountNumber AS [Account #], Department, WorkType As [Work Type] FROM tblAccount ORDER BY AccountNumber", CCEApplication.Connection, CommandType.Text).Tables[0];
                Vendors = DataBaseUtil.ExecuteDataset("SELECT VendorID, Name FROM tblVendor ORDER BY Name", CCEApplication.Connection, CommandType.Text).Tables[0];
                Subcontract = DataBaseUtil.ExecuteDataset("SELECT * FROM tblJobVendorSubcontract ORDER BY JobVendorSubcontract", CCEApplication.Connection, CommandType.Text).Tables[0];

                CostCodes = DataBaseUtil.ExecuteDataset("SELECT CAST(0 AS BIT) AS Selected, CostCodeType AS [Type], CostCodePhase AS Phase, CostCode AS Code, CostCodeTitle AS Title FROM tblCostCode " +
                                        " ORDER BY  CostCodePhase, CostCode ", CCEApplication.Connection, CommandType.Text).Tables[0];
                PhaseList = DataBaseUtil.ExecuteDataset("SELECT  PhaseID, Phase + ' - ' + PhaseDescription AS PhaseDesc FROM tblPhase  " +
                                        " ORDER BY  Phase ", CCEApplication.Connection, CommandType.Text).Tables[0];
                //
                // Job List for Modification *********
                //
                JobsList = DataBaseUtil.ExecuteDataset("SELECT JobNumber AS [Job Number], JobName AS [Job Name] FROM tblJob WHERE JobNumber > '' AND void = 0 ORDER BY JobName", CCEApplication.Connection, CommandType.Text).Tables[0];
                EstimateList = DataBaseUtil.ExecuteDataset("SELECT EstimateNumber AS [Estimate Number], JobName AS [Job Name] FROM tblJob WHERE EstimateNumber > '' AND void = 0 ORDER BY JobName", CCEApplication.Connection, CommandType.Text).Tables[0];
                EmployeeStatus = DataBaseUtil.ExecuteDataset("SELECT EmployeeStatusID, EmployeeStatus FROM tblEmployeeStatus", CCEApplication.Connection, CommandType.Text).Tables[0];
                Apprenticeship = DataBaseUtil.ExecuteDataset("SELECT ID, Status FROM tblApprenticeshipCompleted", CCEApplication.Connection, CommandType.Text).Tables[0];
                Type_Injury = DataBaseUtil.ExecuteDataset("SELECT ID, [Type] FROM tblInjuryType WHERE [Type]<> 'None'", CCEApplication.Connection, CommandType.Text).Tables[0];
                InjuryType = DataBaseUtil.ExecuteDataset("SELECT ID, [Type] FROM tblInjuryType", CCEApplication.Connection, CommandType.Text).Tables[0];
                DoctorNote = new string[] { "Yes", "No" };
                Category = DataBaseUtil.ExecuteDataset("SELECT ID, Category FROM tblCategory", CCEApplication.Connection, CommandType.Text).Tables[0];
                DataTable table = DataBaseUtil.ExecuteDataset("SELECT * FROM tblDashboardFlags", CCEApplication.Connection, CommandType.Text).Tables[0];
                if (table.Rows.Count > 0)
                {
                    jobPerformanceFactor = float.Parse(table.Rows[0]["JobPerformanceFactor"].ToString());
                    profitGainFade = float.Parse(table.Rows[0]["ProfitGainFade"].ToString());
                    projectedProfitPercentage = float.Parse(table.Rows[0]["projectedProfitPercentage"].ToString());
                    laborPercentage = float.Parse(table.Rows[0]["LaborPercentage"].ToString());
                    materialPercentage = float.Parse(table.Rows[0]["materialPercentage"].ToString());
                    costPerformanceFactor = float.Parse(table.Rows[0]["CostPerformanceFactor"].ToString());
                }
                UnitType = DataBaseUtil.ExecuteDataset(" SELECT UnitType AS UnitTypeCode, UnitType FROM tblOTUnitType ORDER BY UnitType ", CCEApplication.Connection, CommandType.Text).Tables[0];
                isLoaded = true;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


    }
}
