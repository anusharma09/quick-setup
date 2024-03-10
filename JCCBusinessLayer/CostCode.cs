using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class CostCode
    {
        private string jobCostCodePhaseID;
        private string jobCostCodeType;
        private string jobCostCodePhase;
        private string costCode;
        private string costCodeTitle;
        private string costCodeDescription;
        private string jobID;
        private string valueAdjustment;
        private string quantityAdjustment;
        private string monthendValueAdjustment;
        private string openCommit;
        private string period;
        private bool updateHistory = false;

        public string JobCostCodePhaseID
        {
            get { return jobCostCodePhaseID; }
        }

        public CostCode()
        {
        }
        public CostCode(string jobCostCodePhaseID,
                        string jobCostCodeType,
                        string jobCostCodePhase,
                        string costCode,
                        string costCodeTitle,
                        string costCodeDescription,
                        string jobID,
                        string valueAdjustment,
                        string quantityAdjustment,
                        string monthendValueAdjustment)
        {


            this.jobCostCodePhaseID = jobCostCodePhaseID;
            this.jobCostCodeType = jobCostCodeType;
            this.jobCostCodePhase = jobCostCodePhase;
            this.costCode = costCode;
            this.costCodeTitle = costCodeTitle.Trim().ToUpper().Replace("'", "''");
            this.costCodeDescription = costCodeDescription.Trim().ToUpper().Replace("'", "''");
            this.jobID = jobID;
            this.valueAdjustment = String.IsNullOrEmpty(valueAdjustment)? "Null" : valueAdjustment;
            this.quantityAdjustment = String.IsNullOrEmpty(quantityAdjustment) ? "Null" : quantityAdjustment;
            this.monthendValueAdjustment = String.IsNullOrEmpty(monthendValueAdjustment) ? "Null" : monthendValueAdjustment;
            updateHistory = false;
        }

        public CostCode(string jobCostCodePhaseID,
                        string jobCostCodeType,
                        string jobCostCodePhase,
                        string costCode,
                        string costCodeTitle,
                        string costCodeDescription,
                        string jobID,
                        string valueAdjustment,
                        string quantityAdjustment,
                        string monthendValueAdjustment,
                        string openCommit,
                        string period,
                        bool updateHistory)
        {


            this.jobCostCodePhaseID = jobCostCodePhaseID;
            this.jobCostCodeType = jobCostCodeType;
            this.jobCostCodePhase = jobCostCodePhase;
            this.costCode = costCode;
            this.costCodeTitle = costCodeTitle.Trim().ToUpper().Replace("'", "''");
            this.costCodeDescription = costCodeDescription.Trim().ToUpper().Replace("'", "''");
            this.jobID = jobID;
            this.valueAdjustment = String.IsNullOrEmpty(valueAdjustment) ? "Null" : valueAdjustment;
            this.quantityAdjustment = String.IsNullOrEmpty(quantityAdjustment) ? "Null" : quantityAdjustment;
            this.monthendValueAdjustment = String.IsNullOrEmpty(monthendValueAdjustment) ? "Null" : monthendValueAdjustment;
            this.openCommit = String.IsNullOrEmpty(openCommit) ? "Null" : openCommit;
            this.period = period;
            this.updateHistory = updateHistory;
        }
        public static bool IsCostCodeInDatabase(string jobCostCodeID)
        {
            string query = "Select JobCostCodeID FROM tblJobCostCode WHERE JobCostCodeID = " + jobCostCodeID + " ";

            try
            {
                if (DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0].Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        //
        public static DataSet GetJobCostCodesToResearch(string jobID)
        {
            string query = "";

            query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                " UserDescription AS [Description]," +
                " TotalBudgetHours AS [Total Budget Hrs], " +
                " TotalBudgetQuantity AS [Total Budget Qty], " +
                " TotalBudgetCost AS [Total Budget Cost], " +
                " CommittedHours AS [Committed Hrs], " +
                " CommittedQuantity AS [Committed Qty], " +
                " Cost AS [Committed Cost], " +
                " UsedHoursPercentage AS [% Used Hrs], " +
                " UsedQuantityPercentage AS [% Used Qty], " +
                " EstimatedPerformanceFactor AS [Estimated Perf Factor], " +
                " CurrentPerformanceHours AS [Current Perf Hrs], " +
                " DifferentialHours AS [Differential Hrs], " +
                " EstimatedCrewRate AS [Estimated Crew Rate], " +
                " RevisedPerformanceFactor As [Revised Perf Factor], " +
                " ProjectedOverUnder AS [Projected Over/Under], " +
                " ValueAdjustment As [Value Adjustment] " +
                " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' " + 
                " AND JobCostCodePhase like '1%' " +
				" AND ( " +
				"	 ValueAdjustment <> 0 " +
				"   OR (EstimatedPerformanceFactor > 1.001 OR  RevisedPerformanceFactor > 1.001) " +
				"	OR (CommittedHours > 0 AND CommittedQuantity = 0) ) " +
                " Order BY  JobCostCodePhase, CostCode ";

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
        public static DataSet GetJobProgressWithPhase(string jobID)
        {
            string query1 = "";
            string query2 = "";
            string query3 = "";

           // if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                query1 = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +                    
                                " Type = CASE JobCostCodeType   " +
                                " WHEN 'L' THEN '100 - LABOR' " +
                                " WHEN 'M' THEN '300 - MATERIAL' " +
                                " WHEN 'E' THEN '300 - RENTAL' " +
                                " WHEN 'S' THEN '600 - SUBCONTRACT' " +
                                " WHEN 'O' THEN '900 - DJC' " +
                                " ELSE 'OTHERS' " +
                                " END, " +
                                " UserDescription AS [Description]," +
                                " OriginalContractHours as [Original Contract Hrs], " +
                                " OriginalContractQuantity AS [Original Contract Qty], " +
                                " OriginalContractCost AS [Original Contract Cost], " +
                                " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                                " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                                " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +
                                " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                                " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                                " PendingWithProceedCost AS [Pending W. Proceed Cost], " +
                                " QuantityAdjustment AS [Qty Adjustment], " +
                                " TotalBudgetHours AS [Total Budget Hrs], " +
                                " TotalBudgetQuantity AS [Total Budget Qty], " +
                                " TotalBudgetCost AS [Total Budget Cost], " +
                                " CommittedHours AS [Committed Hrs], " +
                                " CommittedQuantity AS [Committed Qty], " +
                                " Cost AS [Committed Cost], " +
                                " BudgetLaborUnit AS [Budget Labor Unit], " +
                                " ActualLaborUnit AS [Actual Labor Unit], " +
                                " OpenCommitment as [Open Commitment], " +
                                " UsedHoursPercentage AS [% Used Hrs], " +
                                " UsedQuantityPercentage AS [% Used Qty], " +
                                " EarnedHours, " +
                                " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                                " DifferentialHours AS [Differential Hrs], " +
                                " EstimatedCrewRate AS [Estimated Crew Rate], " +
                                " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                                " ProjectedTotalHours AS [Projected Total Hrs], " +
                                " ProjectedCAC AS [Projected CAC], " +
                                " ProjectedOverUnder AS [Projected Over/Under], " +
                                " ValueAdjustment As [Value Adjustment], " +
                                " ValueAdjustmentPercentage AS [% Adjustment], " +
                                " RevisedCAC AS [Revised CAC], " +
                                " RevisedOverUnder AS [Revised Over/Under], " +
                                " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                                " ActualCostPlusCommitment, " +
                                " MonthendCAC AS [Monthend CAC], " +
                                " UpdateMonthendValueAdjustment, " +
                                " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                                " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                                " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' Order BY  JobCostCodePhase, CostCode ";
                query2 = " SELECT f.JobCostCodePhaseID, w.QuantityToDate, w.HoursToDate, Earned, LaborPerformanceFactor, Quantity, Hours, c.Weekend " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodesWeekly c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        "INNER JOIN tblJobCostCodesWeeklyFeedback w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                        " AND c.Weekend = w.weekend " +
                        " WHERE JobID = " + jobID + "  ORDER by c.Weekend DESC ";

                query3 = " SELECT JobCostCodePhaseCommentID, f.JobCostCodePhaseID, Comment, LastUpdateDate, UserID " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodePhaseComment c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";




            }
           /* else
            {



                query1 = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +

                    //
                    // Contra Costa Electric
                    //
                    " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1)  " +
                    " WHEN 'L1' THEN '100 - LABOR' " +
                    " WHEN 'L5' THEN '500 - PREFAB' " +
                    " WHEN 'M2' THEN '200 - MATERIAL' " +
                    " WHEN 'E3' THEN '300 - RENTAL' " +
                    " WHEN 'S4' THEN '400 - SUBCONTRACT' " +
                    " WHEN 'O8' THEN '800 - DJC' " +
                    " ELSE 'OTHERS' " +
                    " END, " +


                    //
                    // Dynalectric
                    //
                    // " Type = CASE JobCostCodeType   " +
                    // " WHEN 'L' THEN 'LABOR' " +
                    // " WHEN 'M' THEN 'MATERIAL' " +
                    // " WHEN 'E' THEN 'RENTAL' " +
                    // " WHEN 'S' THEN 'SUBCONTRACT' " +
                    // " WHEN 'O' THEN 'DJC' " +
                    // " ELSE 'OTHERS' " +
                    // " END, " +
                    //
                    //

                    " UserDescription AS [Description]," +
                    " OriginalContractHours as [Original Contract Hrs], " +
                    " OriginalContractQuantity AS [Original Contract Qty], " +
                    " OriginalContractCost AS [Original Contract Cost], " +
                    " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                    " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                    " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +
                    " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                    " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                    " PendingWithProceedCost AS [Pending W. Proceed Cost], " +
                    " QuantityAdjustment AS [Qty Adjustment], " +
                    " TotalBudgetHours AS [Total Budget Hrs], " +
                    " TotalBudgetQuantity AS [Total Budget Qty], " +
                    " TotalBudgetCost AS [Total Budget Cost], " +
                    " CommittedHours AS [Committed Hrs], " +
                    " CommittedQuantity AS [Committed Qty], " +
                    " Cost AS [Committed Cost], " +
                    " BudgetLaborUnit AS [Budget Labor Unit], " +
                    " ActualLaborUnit AS [Actual Labor Unit], " +
                    " OpenCommitment as [Open Commitment], " +
                    " UsedHoursPercentage AS [% Used Hrs], " +
                    " UsedQuantityPercentage AS [% Used Qty], " +
                    " EarnedHours, " +
                    " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                    " DifferentialHours AS [Differential Hrs], " +
                    " EstimatedCrewRate AS [Estimated Crew Rate], " +
                    " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                    " ProjectedTotalHours AS [Projected Total Hrs], " +
                    " ProjectedCAC AS [Projected CAC], " +
                    " ProjectedOverUnder AS [Projected Over/Under], " +
                    " ValueAdjustment As [Value Adjustment], " +
                    " ValueAdjustmentPercentage AS [% Adjustment], " +
                    " RevisedCAC AS [Revised CAC], " +
                    " RevisedOverUnder AS [Revised Over/Under], " +
                    " RevisedPerformanceFactor As [Revised Perf. Factor] " +
                    " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' Order BY  JobCostCodePhase, CostCode ";
                query2 = " SELECT f.JobCostCodePhaseID, w.QuantityToDate, w.HoursToDate, Earned, LaborPerformanceFactor, Quantity, Hours, c.Weekend " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodesWeekly c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        "INNER JOIN tblJobCostCodesWeeklyFeedback w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                        " AND c.Weekend = w.weekend " +
                        " WHERE JobID = " + jobID + "  ORDER by c.Weekend DESC ";

                query3 = " SELECT JobCostCodePhaseCommentID, f.JobCostCodePhaseID, Comment, LastUpdateDate, UserID " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodePhaseComment c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";

            }*/
            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query1, query2,query3, "JobCostCodePhaseID", CCEApplication.Connection, CommandType.Text); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //
        public static DataSet GetJobProgressWithPhaseAdmin(string jobID)
        {
            string query1 = "";
            string query2 = "";
            string query3 = "";


            //if (CCEApplication.Company.ToUpper() == "DYNA")
            {

                query1 = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +

                   
                     " Type = CASE JobCostCodeType   " +
                     " WHEN 'L' THEN '100 - LABOR' " +
                     " WHEN 'M' THEN '300 - MATERIAL' " +
                     " WHEN 'E' THEN '300 - RENTAL' " +
                     " WHEN 'S' THEN '600 - SUBCONTRACT' " +
                     " WHEN 'O' THEN '900 - DJC' " +
                     " ELSE 'OTHERS' " +
                     " END, " +
                    " UserDescription AS [Description]," +
                    " OriginalContractHours as [Original Contract Hrs], " +
                    " OriginalContractQuantity AS [Original Contract Qty], " +
                    " OriginalContractCost AS [Original Contract Cost], " +
                    " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                    " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                    " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +
                    " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                    " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                    " PendingWithProceedCost AS [Pending W. Proceed Cost], " +
                    " QuantityAdjustment AS [Qty Adjustment], " +
                    " TotalBudgetHours AS [Total Budget Hrs], " +
                    " TotalBudgetQuantity AS [Total Budget Qty], " +
                    " TotalBudgetCost AS [Total Budget Cost], " +
                    " CommittedHours AS [Committed Hrs], " +
                    " CommittedQuantity AS [Committed Qty], " +
                    " Cost AS [Committed Cost], " +
                    " BudgetLaborUnit AS [Budget Labor Unit], " +
                    " ActualLaborUnit AS [Actual Labor Unit], " +
                    " OpenCommitment as [Open Commitment], " +
                    " UsedHoursPercentage AS [% Used Hrs], " +
                    " UsedQuantityPercentage AS [% Used Qty], " +
                    " EarnedHours, " +
                    " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                    " DifferentialHours AS [Differential Hrs], " +
                    " EstimatedCrewRate AS [Estimated Crew Rate], " +
                    " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                    " ProjectedTotalHours AS [Projected Total Hrs], " +
                    " ProjectedCAC AS [Projected CAC], " +
                    " ProjectedOverUnder AS [Projected Over/Under], " +
                    " ValueAdjustment As [Value Adjustment], " +
                    " ValueAdjustmentPercentage AS [% Adjustment], " +
                    " RevisedCAC AS [Revised CAC], " +
                    " RevisedOverUnder AS [Revised Over/Under], " +
                    " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                    " ActualCostPlusCommitment, " +
                    " MonthendCAC AS [Monthend CAC], " +
                    " UpdateMonthendValueAdjustment, " +
                    " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                    " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                    " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' Order BY  JobCostCodePhase, CostCode ";
                query2 = " SELECT f.JobCostCodePhaseID, w.QuantityToDate, w.HoursToDate, Earned, LaborPerformanceFactor, Quantity, Hours, c.Weekend " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodesWeekly c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        "INNER JOIN tblJobCostCodesWeeklyFeedback w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                        " AND c.Weekend = w.weekend " +
                        " WHERE JobID = " + jobID + "  ORDER by c.Weekend DESC ";

                query3 = " SELECT JobCostCodePhaseCommentID, f.JobCostCodePhaseID, Comment, LastUpdateDate, UserID " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodePhaseComment c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";

            }
           /* else
            {
                query1 = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +

                   //
                    // Contra Costa Electric
                    //
                   " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1)  " +
                   " WHEN 'L1' THEN '100 - LABOR' " +
                   " WHEN 'L5' THEN '500 - PREFAB' " +
                   " WHEN 'M2' THEN '300 - MATERIAL' " +
                   " WHEN 'E3' THEN '300 - RENTAL' " +
                   " WHEN 'S4' THEN '600 - SUBCONTRACT' " +
                   " WHEN 'O8' THEN '900 - DJC' " +
                   " ELSE 'OTHERS' " +
                   " END, " +


                   //
                    // Dynalectric
                    //
                    // " Type = CASE JobCostCodeType   " +
                    // " WHEN 'L' THEN 'LABOR' " +
                    // " WHEN 'M' THEN 'MATERIAL' " +
                    // " WHEN 'E' THEN 'RENTAL' " +
                    // " WHEN 'S' THEN 'SUBCONTRACT' " +
                    // " WHEN 'O' THEN 'DJC' " +
                    // " ELSE 'OTHERS' " +
                    // " END, " +
                    //
                    //

                   " UserDescription AS [Description]," +
                   " OriginalContractHours as [Original Contract Hrs], " +
                   " OriginalContractQuantity AS [Original Contract Qty], " +
                   " OriginalContractCost AS [Original Contract Cost], " +
                   " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                   " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                   " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +
                   " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                   " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                   " PendingWithProceedCost AS [Pending W. Proceed Cost], " +
                   " QuantityAdjustment AS [Qty Adjustment], " +
                   " TotalBudgetHours AS [Total Budget Hrs], " +
                   " TotalBudgetQuantity AS [Total Budget Qty], " +
                   " TotalBudgetCost AS [Total Budget Cost], " +
                   " CommittedHours AS [Committed Hrs], " +
                   " CommittedQuantity AS [Committed Qty], " +
                   " Cost AS [Committed Cost], " +
                   " BudgetLaborUnit AS [Budget Labor Unit], " +
                   " ActualLaborUnit AS [Actual Labor Unit], " +
                   " OpenCommitment as [Open Commitment], " +
                   " UsedHoursPercentage AS [% Used Hrs], " +
                   " UsedQuantityPercentage AS [% Used Qty], " +
                   " EarnedHours, " +
                   " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                   " DifferentialHours AS [Differential Hrs], " +
                   " EstimatedCrewRate AS [Estimated Crew Rate], " +
                   " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                   " ProjectedTotalHours AS [Projected Total Hrs], " +
                   " ProjectedCAC AS [Projected CAC], " +
                   " ProjectedOverUnder AS [Projected Over/Under], " +
                   " ValueAdjustment As [Value Adjustment], " +
                   " ValueAdjustmentPercentage AS [% Adjustment], " +
                   " RevisedCAC AS [Revised CAC], " +
                   " RevisedOverUnder AS [Revised Over/Under], " +
                   " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                   " ActualCostPlusCommitment, " +
                   " MonthendCAC AS [Monthend CAC], " +
                   " UpdateMonthendValueAdjustment, " +
                   " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                   " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                   " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' Order BY  JobCostCodePhase, CostCode ";
                query2 = " SELECT f.JobCostCodePhaseID, w.QuantityToDate, w.HoursToDate, Earned, LaborPerformanceFactor, Quantity, Hours, c.Weekend " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodesWeekly c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        "INNER JOIN tblJobCostCodesWeeklyFeedback w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                        " AND c.Weekend = w.weekend " +
                        " WHERE JobID = " + jobID + "  ORDER by c.Weekend DESC ";

                query3 = " SELECT JobCostCodePhaseCommentID, f.JobCostCodePhaseID, Comment, LastUpdateDate, UserID " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodePhaseComment c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";
            }*/
            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query1, query2, query3, "JobCostCodePhaseID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataSet GetJobProgressHistoryWithPhase(string jobID, string period)
        {
            string query1 = "";
            string query2 = "";
            string query3 = "";

            //if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                query1 = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                    " Type = CASE JobCostCodeType " +
                    " WHEN 'L' THEN '100 - LABOR' " +
                    " WHEN 'M' THEN '300 - MATERIAL' " +
                    " WHEN 'E' THEN '300 - RENTAL' " +
                    " WHEN 'S' THEN '600 - SUBCONTRACT' " +
                    " WHEN 'O' THEN '900 - DJC' " + " ELSE 'OTHERS' " +
                    " END, " +
                    " UserDescription AS [Description]," +
                    " OriginalContractHours as [Original Contract Hrs], " +
                    " OriginalContractQuantity AS [Original Contract Qty], " +
                    " OriginalContractCost AS [Original Contract Cost], " +
                    " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                    " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                    " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +
                    " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                    " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                    " PendingWithProceedCost AS [Pending W. Proceed Cost], " +
                    " QuantityAdjustment AS [Qty Adjustment], " +
                    " TotalBudgetHours AS [Total Budget Hrs], " +
                    " TotalBudgetQuantity AS [Total Budget Qty], " +
                    " TotalBudgetCost AS [Total Budget Cost], " +
                    " CommittedHours AS [Committed Hrs], " +
                    " CommittedQuantity AS [Committed Qty], " +
                    " Cost AS [Committed Cost], " +
                    " BudgetLaborUnit AS [Budget Labor Unit], " +
                    " ActualLaborUnit AS [Actual Labor Unit], " +
                    " OpenCommitment as [Open Commitment], " +
                    " UsedHoursPercentage AS [% Used Hrs], " +
                    " UsedQuantityPercentage AS [% Used Qty], " +
                    " EarnedHours, " +
                    " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                    " DifferentialHours AS [Differential Hrs], " +
                    " EstimatedCrewRate AS [Estimated Crew Rate], " +
                    " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                    " ProjectedTotalHours AS [Projected Total Hrs], " +
                    " ProjectedCAC AS [Projected CAC], " +
                    " ProjectedOverUnder AS [Projected Over/Under], " +
                    " ValueAdjustment As [Value Adjustment], " +
                    " ValueAdjustmentPercentage AS [% Adjustment], " +
                    " RevisedCAC AS [Revised CAC], " +
                    " RevisedOverUnder AS [Revised Over/Under], " +
                    " RevisedPerformanceFactor As [Revised Perf. Factor] " +
                    " FROM tblJobCostCodePhaseHistory p  WHERE JobID = '" + jobID + "' AND Period = '" + period + "'  Order BY JobCostCodePhase, CostCode ";
                query2 = " SELECT f.JobCostCodePhaseID, w.QuantityToDate, w.HoursToDate, Earned, LaborPerformanceFactor, Quantity, Hours, c.Weekend " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodesWeekly c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        "INNER JOIN tblJobCostCodesWeeklyFeedback w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                        " AND c.Weekend = w.weekend " +
                        " WHERE JobID = " + jobID + "  ORDER by c.Weekend DESC ";

                query3 = " SELECT JobCostCodePhaseCommentID, f.JobCostCodePhaseID AS [JobCostCodePhaseID], Comment, LastUpdateDate, UserID " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodePhaseComment c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";
            }
           /* else
            {
                query1 = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                    " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1)  " +
                    " WHEN 'L1' THEN '100 - LABOR' " +
                    " WHEN 'L5' THEN '500 - PREFAB' " +
                    " WHEN 'M2' THEN '200 - MATERIAL' " +
                    " WHEN 'E3' THEN '300 - RENTAL' " +
                    " WHEN 'S4' THEN '400 - SUBCONTRACT' " +
                    " WHEN 'O8' THEN '800 - DJC' " + " ELSE 'OTHERS' " +
                    " END, " +
                    " UserDescription AS [Description]," +
                    " OriginalContractHours as [Original Contract Hrs], " +
                    " OriginalContractQuantity AS [Original Contract Qty], " +
                    " OriginalContractCost AS [Original Contract Cost], " +
                    " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                    " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                    " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +
                    " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                    " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                    " PendingWithProceedCost AS [Pending W. Proceed Cost], " +
                    " QuantityAdjustment AS [Qty Adjustment], " +
                    " TotalBudgetHours AS [Total Budget Hrs], " +
                    " TotalBudgetQuantity AS [Total Budget Qty], " +
                    " TotalBudgetCost AS [Total Budget Cost], " +
                    " CommittedHours AS [Committed Hrs], " +
                    " CommittedQuantity AS [Committed Qty], " +
                    " Cost AS [Committed Cost], " +
                    " BudgetLaborUnit AS [Budget Labor Unit], " +
                    " ActualLaborUnit AS [Actual Labor Unit], " +
                    " OpenCommitment as [Open Commitment], " +
                    " UsedHoursPercentage AS [% Used Hrs], " +
                    " UsedQuantityPercentage AS [% Used Qty], " +
                    " EarnedHours, " +
                    " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                    " DifferentialHours AS [Differential Hrs], " +
                    " EstimatedCrewRate AS [Estimated Crew Rate], " +
                    " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                    " ProjectedTotalHours AS [Projected Total Hrs], " +
                    " ProjectedCAC AS [Projected CAC], " +
                    " ProjectedOverUnder AS [Projected Over/Under], " +
                    " ValueAdjustment As [Value Adjustment], " +
                    " ValueAdjustmentPercentage AS [% Adjustment], " +
                    " RevisedCAC AS [Revised CAC], " +
                    " RevisedOverUnder AS [Revised Over/Under], " +
                    " RevisedPerformanceFactor As [Revised Perf. Factor] " +
                    " FROM tblJobCostCodePhaseHistory p  WHERE JobID = '" + jobID + "' AND Period = '" + period + "'  Order BY JobCostCodePhase, CostCode ";
                query2 = " SELECT f.JobCostCodePhaseID, w.QuantityToDate, w.HoursToDate, Earned, LaborPerformanceFactor, Quantity, Hours, c.Weekend " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodesWeekly c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        "INNER JOIN tblJobCostCodesWeeklyFeedback w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                        " AND c.Weekend = w.weekend " +
                        " WHERE JobID = " + jobID + "  ORDER by c.Weekend DESC ";

                query3 = " SELECT JobCostCodePhaseCommentID, f.JobCostCodePhaseID AS [JobCostCodePhaseID], Comment, LastUpdateDate, UserID " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodePhaseComment c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";

            }*/
            try
            {
                return DataBaseUtil.ExecuteDataset(query1,  CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataSet GetJobProgressHistoryWithPhaseAdmin(string jobID, string period)
        {
            string query1 = "";
            string query2 = "";
            string query3 = "";

           // if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                query1 = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                " Type = CASE JobCostCodeType " +
                " WHEN 'L' THEN '100 - LABOR' " +
                " WHEN 'M' THEN '300 - MATERIAL' " +
                " WHEN 'E' THEN '300 - RENTAL' " +
                " WHEN 'S' THEN '600 - SUBCONTRACT' " +
                " WHEN 'O' THEN '900 - DJC' " + " ELSE 'OTHERS' " +
                " END, " +
                " UserDescription AS [Description]," +
                " OriginalContractHours as [Original Contract Hrs], " +
                " OriginalContractQuantity AS [Original Contract Qty], " +
                " OriginalContractCost AS [Original Contract Cost], " +
                " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +
                " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                " PendingWithProceedCost AS [Pending W. Proceed Cost], " +
                " QuantityAdjustment AS [Qty Adjustment], " +
                " TotalBudgetHours AS [Total Budget Hrs], " +
                " TotalBudgetQuantity AS [Total Budget Qty], " +
                " TotalBudgetCost AS [Total Budget Cost], " +
                " CommittedHours AS [Committed Hrs], " +
                " CommittedQuantity AS [Committed Qty], " +
                " Cost AS [Committed Cost], " +
                " BudgetLaborUnit AS [Budget Labor Unit], " +
                " ActualLaborUnit AS [Actual Labor Unit], " +
                " OpenCommitment as [Open Commitment], " +
                " UsedHoursPercentage AS [% Used Hrs], " +
                " UsedQuantityPercentage AS [% Used Qty], " +
                " EarnedHours, " +
                " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                " DifferentialHours AS [Differential Hrs], " +
                " EstimatedCrewRate AS [Estimated Crew Rate], " +
                " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                " ProjectedTotalHours AS [Projected Total Hrs], " +
                " ProjectedCAC AS [Projected CAC], " +
                " ProjectedOverUnder AS [Projected Over/Under], " +
                " ValueAdjustment As [Value Adjustment], " +
                " ValueAdjustmentPercentage AS [% Adjustment], " +
                " RevisedCAC AS [Revised CAC], " +
                " RevisedOverUnder AS [Revised Over/Under], " +
                " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                " ActualCostPlusCommitment, " +
                " MonthendCAC AS [Monthend CAC], " +
                " UpdateMonthendValueAdjustment, " +
                " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                " FROM tblJobCostCodePhaseHistory p  WHERE JobID = '" + jobID + "' AND Period = '" + period + "'  Order BY JobCostCodePhase, CostCode ";
                query2 = " SELECT f.JobCostCodePhaseID, w.QuantityToDate, w.HoursToDate, Earned, LaborPerformanceFactor, Quantity, Hours, c.Weekend " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodesWeekly c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        "INNER JOIN tblJobCostCodesWeeklyFeedback w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                        " AND c.Weekend = w.weekend " +
                        " WHERE JobID = " + jobID + "  ORDER by c.Weekend DESC ";

                query3 = " SELECT JobCostCodePhaseCommentID, f.JobCostCodePhaseID AS [JobCostCodePhaseID], Comment, LastUpdateDate, UserID " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodePhaseComment c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";

            }
           /* else
            {
                query1 = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                    " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1)  " +
                    " WHEN 'L1' THEN '100 - LABOR' " +
                    " WHEN 'L5' THEN '500 - PREFAB' " +
                    " WHEN 'M2' THEN '200 - MATERIAL' " +
                    " WHEN 'E3' THEN '300 - RENTAL' " +
                    " WHEN 'S4' THEN '400 - SUBCONTRACT' " +
                    " WHEN 'O8' THEN '800 - DJC' " + " ELSE 'OTHERS' " +
                    " END, " +
                    " UserDescription AS [Description]," +
                    " OriginalContractHours as [Original Contract Hrs], " +
                    " OriginalContractQuantity AS [Original Contract Qty], " +
                    " OriginalContractCost AS [Original Contract Cost], " +
                    " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                    " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                    " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +
                    " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                    " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                    " PendingWithProceedCost AS [Pending W. Proceed Cost], " +
                    " QuantityAdjustment AS [Qty Adjustment], " +
                    " TotalBudgetHours AS [Total Budget Hrs], " +
                    " TotalBudgetQuantity AS [Total Budget Qty], " +
                    " TotalBudgetCost AS [Total Budget Cost], " +
                    " CommittedHours AS [Committed Hrs], " +
                    " CommittedQuantity AS [Committed Qty], " +
                    " Cost AS [Committed Cost], " +
                    " BudgetLaborUnit AS [Budget Labor Unit], " +
                    " ActualLaborUnit AS [Actual Labor Unit], " +
                    " OpenCommitment as [Open Commitment], " +
                    " UsedHoursPercentage AS [% Used Hrs], " +
                    " UsedQuantityPercentage AS [% Used Qty], " +
                    " EarnedHours, " +
                    " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                    " DifferentialHours AS [Differential Hrs], " +
                    " EstimatedCrewRate AS [Estimated Crew Rate], " +
                    " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                    " ProjectedTotalHours AS [Projected Total Hrs], " +
                    " ProjectedCAC AS [Projected CAC], " +
                    " ProjectedOverUnder AS [Projected Over/Under], " +
                    " ValueAdjustment As [Value Adjustment], " +
                    " ValueAdjustmentPercentage AS [% Adjustment], " +
                    " RevisedCAC AS [Revised CAC], " +
                    " RevisedOverUnder AS [Revised Over/Under], " +
                    " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                    " ActualCostPlusCommitment, " +
                    " MonthendCAC AS [Monthend CAC], " +
                    " UpdateMonthendValueAdjustment, " +
                    " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                    " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                    " FROM tblJobCostCodePhaseHistory p  WHERE JobID = '" + jobID + "' AND Period = '" + period + "'  Order BY JobCostCodePhase, CostCode ";
                query2 = " SELECT f.JobCostCodePhaseID, w.QuantityToDate, w.HoursToDate, Earned, LaborPerformanceFactor, Quantity, Hours, c.Weekend " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodesWeekly c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        "INNER JOIN tblJobCostCodesWeeklyFeedback w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                        " AND c.Weekend = w.weekend " +
                        " WHERE JobID = " + jobID + "  ORDER by c.Weekend DESC ";

                query3 = " SELECT JobCostCodePhaseCommentID, f.JobCostCodePhaseID AS [JobCostCodePhaseID], Comment, LastUpdateDate, UserID " +
                        " FROM tblJobCostCodePhase f " +
                        " INNER JOIN tblJobCostCodePhaseComment c ON f.JobCostCodePhaseID = c.JobCostCodePhaseID " +
                        " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";

            } */
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
        public static DataSet GetJobProgress(string jobID)
        {
            string query = "";

            //if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                " Type = CASE JobCostCodeType   " +
                " WHEN 'L' THEN '100 - LABOR' " +
                " WHEN 'M' THEN '300 - MATERIAL' " +
                " WHEN 'E' THEN '300 - RENTAL' " +
                " WHEN 'S' THEN '600 - SUBCONTRACT' " +
                " WHEN 'O' THEN '900 - DJC' " +
                " ELSE 'OTHERS' " +
                " END, " +
                " UserDescription AS [Description]," +
                " OriginalContractHours as [Original Contract Hrs], " +
                " OriginalContractQuantity AS [Original Contract Qty], " +
                " OriginalContractCost AS [Original Contract Cost], " +
                " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +

                " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                " PendingWithProceedCost AS [Pending W. Proceed Cost], " +

                " QuantityAdjustment AS [Qty Adjustment], " +
                " TotalBudgetHours AS [Total Budget Hrs], " +
                " TotalBudgetQuantity AS [Total Budget Qty], " +
                " TotalBudgetCost AS [Total Budget Cost], " +
                " CommittedHours AS [Committed Hrs], " +
                " CommittedQuantity AS [Committed Qty], " +
                " Cost AS [Committed Cost], " +
                " BudgetLaborUnit AS [Budget Labor Unit], " +
                " ActualLaborUnit AS [Actual Labor Unit], " +
                " OpenCommitment as [Open Commitment], " +
                " UsedHoursPercentage AS [% Used Hrs], " +
                " UsedQuantityPercentage AS [% Used Qty], " +
                " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                " DifferentialHours AS [Differential Hrs], " +
                " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                " ProjectedTotalHours AS [Projected Total Hrs], " +
                " ProjectedCAC AS [Projected CAC], " +
                " ProjectedOverUnder AS [Projected Over/Under], " +
                " ValueAdjustment As [Value Adjustment], " +
                " ValueAdjustmentPercentage AS [% Adjustment], " +
                " RevisedCAC AS [Revised CAC], " +
                " RevisedOverUnder AS [Revised Over/Under], " +
                " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                " ActualCostPlusCommitment, " +
                " MonthendCAC AS [Monthend CAC], " +
                " UpdateMonthendValueAdjustment, " +
                " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                " RevisedCACMonthEnd AS [Revised Monthend CAC], Unit " +
                " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' Order BY  JobCostCodePhase, CostCode ";
            }
           /* else
            {

                query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                        " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1)  " +
                        " WHEN 'L1' THEN '100 - LABOR' " +
                        " WHEN 'L5' THEN '500 - PREFAB' " +
                        " WHEN 'M2' THEN '200 - MATERIAL' " +
                        " WHEN 'E3' THEN '300 - RENTAL' " +
                        " WHEN 'S4' THEN '400 - SUBCONTRACT' " +
                        " WHEN 'O8' THEN '800 - DJC' " +
                        " WHEN 'O' THEN '800 - DJC' " +
                        " ELSE 'OTHERS' " +
                        " END, " +
                        " UserDescription AS [Description]," +
                        " OriginalContractHours as [Original Contract Hrs], " +
                        " OriginalContractQuantity AS [Original Contract Qty], " +
                        " OriginalContractCost AS [Original Contract Cost], " +
                        " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                        " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                        " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +

                        " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                        " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                        " PendingWithProceedCost AS [Pending W. Proceed Cost], " +

                        " QuantityAdjustment AS [Qty Adjustment], " +
                        " TotalBudgetHours AS [Total Budget Hrs], " +
                        " TotalBudgetQuantity AS [Total Budget Qty], " +
                        " TotalBudgetCost AS [Total Budget Cost], " +
                        " CommittedHours AS [Committed Hrs], " +
                        " CommittedQuantity AS [Committed Qty], " +
                        " Cost AS [Committed Cost], " +
                        " BudgetLaborUnit AS [Budget Labor Unit], " +
                        " ActualLaborUnit AS [Actual Labor Unit], " +
                        " OpenCommitment as [Open Commitment], " +
                        " UsedHoursPercentage AS [% Used Hrs], " +
                        " UsedQuantityPercentage AS [% Used Qty], " +
                        " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                        " DifferentialHours AS [Differential Hrs], " +
                        " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                        " ProjectedTotalHours AS [Projected Total Hrs], " +
                        " ProjectedCAC AS [Projected CAC], " +
                        " ProjectedOverUnder AS [Projected Over/Under], " +
                        " ValueAdjustment As [Value Adjustment], " +
                        " ValueAdjustmentPercentage AS [% Adjustment], " +
                        " RevisedCAC AS [Revised CAC], " +
                        " RevisedOverUnder AS [Revised Over/Under], " +
                        " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                        " ActualCostPlusCommitment, " +
                        " MonthendCAC AS [Monthend CAC], " +
                        " UpdateMonthendValueAdjustment, " +
                        " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                        " RevisedCACMonthEnd AS [Revised Monthend CAC], Unit " +
                        " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' Order BY  JobCostCodePhase, CostCode ";
            } */
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
        public static DataSet GetJobProgressHistory(string jobID, string period)
        {
            string query = "";

            //if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                        " Type = CASE JobCostCodeType   " +
                        " WHEN 'L' THEN '100 - LABOR' " +
                        " WHEN 'M' THEN '300 - MATERIAL' " +
                        " WHEN 'E' THEN '300 - RENTAL' " +
                        " WHEN 'S' THEN '600 - SUBCONTRACT' " +
                        " WHEN 'O' THEN '900 - DJC' " +
                        " ELSE 'OTHERS' " +
                        " END, " +
                        " UserDescription AS [Description]," +
                        " OriginalContractHours as [Original Contract Hrs], " +
                        " OriginalContractQuantity AS [Original Contract Qty], " +
                        " OriginalContractCost AS [Original Contract Cost], " +
                        " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                        " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                        " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +

                        " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                        " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                        " PendingWithProceedCost AS [Pending W. Proceed Cost], " +

                        " QuantityAdjustment AS [Qty Adjustment], " +
                        " TotalBudgetHours AS [Total Budget Hrs], " +
                        " TotalBudgetQuantity AS [Total Budget Qty], " +
                        " TotalBudgetCost AS [Total Budget Cost], " +
                        " CommittedHours AS [Committed Hrs], " +
                        " CommittedQuantity AS [Committed Qty], " +
                        " Cost AS [Committed Cost], " +
                        " BudgetLaborUnit AS [Budget Labor Unit], " +
                        " ActualLaborUnit AS [Actual Labor Unit], " +
                        " OpenCommitment as [Open Commitment], " +
                        " UsedHoursPercentage AS [% Used Hrs], " +
                        " UsedQuantityPercentage AS [% Used Qty], " +
                        " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                        " DifferentialHours AS [Differential Hrs], " +
                        " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                        " ProjectedTotalHours AS [Projected Total Hrs], " +
                        " ProjectedCAC AS [Projected CAC], " +
                        " ProjectedOverUnder AS [Projected Over/Under], " +
                        " ValueAdjustment As [Value Adjustment], " +
                        " ValueAdjustmentPercentage AS [% Adjustment], " +
                        " RevisedCAC AS [Revised CAC], " +
                        " RevisedOverUnder AS [Revised Over/Under], " +
                        " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                        " ActualCostPlusCommitment, " +
                        " MonthendCAC AS [Monthend CAC], " +
                        " UpdateMonthendValueAdjustment, " +
                        " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                        " RevisedCACMonthEnd AS [Revised Monthend CAC], Unit " +
                        " FROM tblJobCostCodePhaseHistory p  WHERE JobID = '" + jobID + "' AND Period = '" + period + "'  Order BY JobCostCodePhase, CostCode ";
            }
           /* else
            {
                query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                        " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1)  " +
                        " WHEN 'L1' THEN '100 - LABOR' " +
                        " WHEN 'L5' THEN '500 - PREFAB' " +
                        " WHEN 'M2' THEN '200 - MATERIAL' " +
                        " WHEN 'E3' THEN '300 - RENTAL' " +
                        " WHEN 'S4' THEN '400 - SUBCONTRACT' " +
                        " WHEN 'O8' THEN '800 - DJC' " +
                        " ELSE 'OTHERS' " +
                        " END, " +
                        " UserDescription AS [Description]," +
                        " OriginalContractHours as [Original Contract Hrs], " +
                        " OriginalContractQuantity AS [Original Contract Qty], " +
                        " OriginalContractCost AS [Original Contract Cost], " +
                        " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                        " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                        " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +

                        " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                        " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                        " PendingWithProceedCost AS [Pending W. Proceed Cost], " +

                        " QuantityAdjustment AS [Qty Adjustment], " +
                        " TotalBudgetHours AS [Total Budget Hrs], " +
                        " TotalBudgetQuantity AS [Total Budget Qty], " +
                        " TotalBudgetCost AS [Total Budget Cost], " +
                        " CommittedHours AS [Committed Hrs], " +
                        " CommittedQuantity AS [Committed Qty], " +
                        " Cost AS [Committed Cost], " +
                        " BudgetLaborUnit AS [Budget Labor Unit], " +
                        " ActualLaborUnit AS [Actual Labor Unit], " +
                        " OpenCommitment as [Open Commitment], " +
                        " UsedHoursPercentage AS [% Used Hrs], " +
                        " UsedQuantityPercentage AS [% Used Qty], " +
                        " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                        " DifferentialHours AS [Differential Hrs], " +
                        " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                        " ProjectedTotalHours AS [Projected Total Hrs], " +
                        " ProjectedCAC AS [Projected CAC], " +
                        " ProjectedOverUnder AS [Projected Over/Under], " +
                        " ValueAdjustment As [Value Adjustment], " +
                        " ValueAdjustmentPercentage AS [% Adjustment], " +
                        " RevisedCAC AS [Revised CAC], " +
                        " RevisedOverUnder AS [Revised Over/Under], " +
                        " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                        " ActualCostPlusCommitment, " +
                        " MonthendCAC AS [Monthend CAC], " +
                        " UpdateMonthendValueAdjustment, " +
                        " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                        " RevisedCACMonthEnd AS [Revised Monthend CAC], Unit " +
                        " FROM tblJobCostCodePhaseHistory p  WHERE JobID = '" + jobID + "' AND Period = '" + period + "'  Order BY JobCostCodePhase, CostCode ";
            } */
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetJobProgressForExcel(string jobID)
        {
            string query = "";

           // if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                " Type = CASE JobCostCodeType " +
                " WHEN 'L' THEN '100 - LABOR' " +
                " WHEN 'M' THEN '300 - MATERIAL' " +
                " WHEN 'S' THEN '600 - SUBCONTRACT' " +
                " WHEN 'O' THEN '900 - DJC' " +
                " ELSE 'OTHERS' " +
                " END, " +
                " JobCostCodePhase + CostCode as [Code], " +
                " UserDescription AS [Description]," +
                " OriginalContractHours as [Original Contract Hrs], " +
                " OriginalContractQuantity AS [Original Contract Qty], " +
                " OriginalContractCost AS [Original Contract Cost], " +
                " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +

                " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                " PendingWithProceedCost AS [Pending W. Proceed Cost], " +

                " QuantityAdjustment AS [Qty Adjustment], " +
                " TotalBudgetHours AS [Total Budget Hrs], " +
                " TotalBudgetQuantity AS [Total Budget Qty], " +
                " TotalBudgetCost AS [Total Budget Cost], " +
                " CommittedHours AS [Committed Hrs], " +
                " CommittedQuantity AS [Committed Qty], " +
                " Cost AS [Committed Cost], " +
                " BudgetLaborUnit AS [Budget Labor Unit], " +
                " ActualLaborUnit AS [Actual Labor Unit], " +

                " OpenCommitment as [Open Commitment], " +
                " UsedHoursPercentage AS [% Used Hrs], " +
                " UsedQuantityPercentage AS [% Used Qty], " +
                " EarnedHours, " +
                " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                " DifferentialHours AS [Differential Hrs], " +
                " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                " ProjectedTotalHours AS [Projected Total Hrs], " +
                " ProjectedCAC AS [Projected CAC], " +
                " ProjectedOverUnder AS [Projected Over/Under], " +
                " ValueAdjustment As [Value Adjustment], " +
                " ValueAdjustmentPercentage AS [% Adjustment], " +
                " RevisedCAC AS [Revised CAC], " +
                " RevisedOverUnder AS [Revised Over/Under], " +
                " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                " EstimatedCrewRate, " +
                " ActualCostPlusCommitment, " +
                " MonthendCAC AS [Monthend CAC], " +
                " UpdateMonthendValueAdjustment, " +
                " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' Order BY JobCostCodePhase + CostCode DESC ";

            }
           /* else
            {

                query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                        " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1)  " +
                        " WHEN 'L1' THEN '100 - LABOR' " +
                        " WHEN 'L5' THEN '500 - PREFAB' " +
                        " WHEN 'M2' THEN '200 - MATERIAL' " +
                        " WHEN 'E3' THEN '300 - RENTAL' " +
                        " WHEN 'S4' THEN '400 - SUBCONTRACT' " +
                        " WHEN 'O8' THEN '800 - DJC' " +
                        " ELSE 'OTHERS' " +
                        " END, " +
                        " JobCostCodePhase + CostCode as [Code], " +
                        " UserDescription AS [Description]," +
                        " OriginalContractHours as [Original Contract Hrs], " +
                        " OriginalContractQuantity AS [Original Contract Qty], " +
                        " OriginalContractCost AS [Original Contract Cost], " +
                        " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                        " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                        " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +

                        " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                        " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                        " PendingWithProceedCost AS [Pending W. Proceed Cost], " +

                        " QuantityAdjustment AS [Qty Adjustment], " +
                        " TotalBudgetHours AS [Total Budget Hrs], " +
                        " TotalBudgetQuantity AS [Total Budget Qty], " +
                        " TotalBudgetCost AS [Total Budget Cost], " +
                        " CommittedHours AS [Committed Hrs], " +
                        " CommittedQuantity AS [Committed Qty], " +
                        " Cost AS [Committed Cost], " +
                        " BudgetLaborUnit AS [Budget Labor Unit], " +
                        " ActualLaborUnit AS [Actual Labor Unit], " +

                        " OpenCommitment as [Open Commitment], " +
                        " UsedHoursPercentage AS [% Used Hrs], " +
                        " UsedQuantityPercentage AS [% Used Qty], " +
                        " EarnedHours, " +
                        " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                        " DifferentialHours AS [Differential Hrs], " +
                        " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                        " ProjectedTotalHours AS [Projected Total Hrs], " +
                        " ProjectedCAC AS [Projected CAC], " +
                        " ProjectedOverUnder AS [Projected Over/Under], " +
                        " ValueAdjustment As [Value Adjustment], " +
                        " ValueAdjustmentPercentage AS [% Adjustment], " +
                        " RevisedCAC AS [Revised CAC], " +
                        " RevisedOverUnder AS [Revised Over/Under], " +
                        " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                        " EstimatedCrewRate, " +
                        " ActualCostPlusCommitment, " +
                        " MonthendCAC AS [Monthend CAC], " +
                        " UpdateMonthendValueAdjustment, " +
                        " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                        " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                        " FROM tblJobCostCodePhase p  WHERE JobID = '" + jobID + "' Order BY JobCostCodePhase + CostCode DESC ";
            } */
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataSet GetJobProgressForExcelHistory(string jobID, string period)
        {
            string query = "";

            // if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                    " Type = CASE JobCostCodeType " +
                    " WHEN 'L' THEN '100 - LABOR' " +
                    " WHEN 'M' THEN '300 - MATERIAL' " +
                    " WHEN 'E' THEN '300 - RENTAL' " +
                    " WHEN 'S' THEN '600 - SUBCONTRACT' " +
                    " WHEN 'O' THEN '900 - DJC' " +
                    " ELSE 'OTHERS' " +
                    " END, " +
                    " JobCostCodePhase + CostCode as [Code], " +
                    " UserDescription AS [Description]," +
                    " OriginalContractHours as [Original Contract Hrs], " +
                    " OriginalContractQuantity AS [Original Contract Qty], " +
                    " OriginalContractCost AS [Original Contract Cost], " +
                    " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                    " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                    " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +

                    " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                    " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                    " PendingWithProceedCost AS [Pending W. Proceed Cost], " +

                    " QuantityAdjustment AS [Qty Adjustment], " +
                    " TotalBudgetHours AS [Total Budget Hrs], " +
                    " TotalBudgetQuantity AS [Total Budget Qty], " +
                    " TotalBudgetCost AS [Total Budget Cost], " +
                    " CommittedHours AS [Committed Hrs], " +
                    " CommittedQuantity AS [Committed Qty], " +
                    " Cost AS [Committed Cost], " +
                    " BudgetLaborUnit AS [Budget Labor Unit], " +
                    " ActualLaborUnit AS [Actual Labor Unit], " +


                    " OpenCommitment as [Open Commitment], " +
                    " UsedHoursPercentage AS [% Used Hrs], " +
                    " UsedQuantityPercentage AS [% Used Qty], " +
                    " EarnedHours, " +
                    " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                    " DifferentialHours AS [Differential Hrs], " +
                    " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                    " ProjectedTotalHours AS [Projected Total Hrs], " +
                    " ProjectedCAC AS [Projected CAC], " +
                    " ProjectedOverUnder AS [Projected Over/Under], " +
                    " ValueAdjustment As [Value Adjustment], " +
                    " ValueAdjustmentPercentage AS [% Adjustment], " +
                    " RevisedCAC AS [Revised CAC], " +
                    " RevisedOverUnder AS [Revised Over/Under], " +
                    " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                    " EstimatedCrewRate, " +
                    " ActualCostPlusCommitment, " +
                    " MonthendCAC AS [Monthend CAC], " +
                    " UpdateMonthendValueAdjustment, " +
                    " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                    " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                    " FROM tblJobCostCodePhaseHistory p  WHERE JobID = '" + jobID + "' AND Period = '" + period + "' Order BY JobCostCodePhase + CostCode DESC ";

            }
           /* else
            {
                query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " +
                        " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1)  " +
                        " WHEN 'L1' THEN '100 - LABOR' " +
                        " WHEN 'L5' THEN '500 - PREFAB' " +
                        " WHEN 'M2' THEN '200 - MATERIAL' " +
                        " WHEN 'E3' THEN '300 - RENTAL' " +
                        " WHEN 'S4' THEN '400 - SUBCONTRACT' " +
                        " WHEN 'O8' THEN '800 - DJC' " +
                        " ELSE 'OTHERS' " +
                        " END, " +
                        " JobCostCodePhase + CostCode as [Code], " +
                        " UserDescription AS [Description]," +
                        " OriginalContractHours as [Original Contract Hrs], " +
                        " OriginalContractQuantity AS [Original Contract Qty], " +
                        " OriginalContractCost AS [Original Contract Cost], " +
                        " ApprovedChangeOrderHours as [Approved Change Order Hrs], " +
                        " ApprovedChangeOrderQuantity AS [Approved Change Order Qty], " +
                        " ApprovedChangeOrderCost AS [Approved Change Order Cost], " +

                        " PendingWithProceedHours as [Pending W. Proceed Hrs], " +
                        " PendingWithProceedQuantity AS [Pending W. Proceed Qty], " +
                        " PendingWithProceedCost AS [Pending W. Proceed Cost], " +

                        " QuantityAdjustment AS [Qty Adjustment], " +
                        " TotalBudgetHours AS [Total Budget Hrs], " +
                        " TotalBudgetQuantity AS [Total Budget Qty], " +
                        " TotalBudgetCost AS [Total Budget Cost], " +
                        " CommittedHours AS [Committed Hrs], " +
                        " CommittedQuantity AS [Committed Qty], " +
                        " Cost AS [Committed Cost], " +
                        " BudgetLaborUnit AS [Budget Labor Unit], " +
                        " ActualLaborUnit AS [Actual Labor Unit], " +


                        " OpenCommitment as [Open Commitment], " +
                        " UsedHoursPercentage AS [% Used Hrs], " +
                        " UsedQuantityPercentage AS [% Used Qty], " +
                        " EarnedHours, " +
                        " EstimatedPerformanceFactor AS [Estimated Perf. Factor], " +
                        " DifferentialHours AS [Differential Hrs], " +
                        " CurrentPerformanceHours AS [Current Perf. Hrs], " +
                        " ProjectedTotalHours AS [Projected Total Hrs], " +
                        " ProjectedCAC AS [Projected CAC], " +
                        " ProjectedOverUnder AS [Projected Over/Under], " +
                        " ValueAdjustment As [Value Adjustment], " +
                        " ValueAdjustmentPercentage AS [% Adjustment], " +
                        " RevisedCAC AS [Revised CAC], " +
                        " RevisedOverUnder AS [Revised Over/Under], " +
                        " RevisedPerformanceFactor As [Revised Perf. Factor], " +
                        " EstimatedCrewRate, " +
                        " ActualCostPlusCommitment, " +
                        " MonthendCAC AS [Monthend CAC], " +
                        " UpdateMonthendValueAdjustment, " +
                        " MonthendValueAdjustment As [Monthend Value Adjustment], " +
                        " RevisedCACMonthEnd AS [Revised Monthend CAC] " +
                        " FROM tblJobCostCodePhaseHistory p  WHERE JobID = '" + jobID + "' AND Period = '" + period + "' Order BY JobCostCodePhase + CostCode DESC ";
            } */
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
        public static DataSet GetCostCodePhases(string type, string code, string jobID)
        {
            string query = "";

            query = "SELECT jobCostCodePhaseID AS ID, 'N' AS [New?], CAST(JobCostCodePhase AS INT) AS [Phase], CostCodeDescription AS [Description] FROM tblJobCostCodePhase " +
                    " WHERE JobCostCodeType = '" + type + "' AND CostCode = '" + code + "' AND JobID = " + jobID + " " + 
                    " Order by [Phase] ";
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
        public static DataSet GetCostCodePhasesProc(string type, string code, string jobID, string phase)
        {
            
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@Type", type);
            par[1] = new SqlParameter("@Code", code);
            par[2] = new SqlParameter("@JobID", jobID);
            par[3] = new SqlParameter("@Phase", phase);


            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_JCGetJobCostCodeByPhase", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            if (jobCostCodePhaseID == "")
                return Insert();
            else
                if (updateHistory)
                    return UpdateHistory();
                else
                    return Update();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobCostCodePhase(JobCostCodeType, JobCostCodePhase, CostCode, CostCodeTitle, CostCodeDescription, JobID) Values('" +
                    jobCostCodeType + "', '" + jobCostCodePhase + "', '" + costCode + "', '" + costCodeTitle + "', '" + costCodeDescription + "', " + jobID + ")" +
                    "Select @@IDENTITY ";
            try
            {
                jobCostCodePhaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        // Update Current Phase
        //
        private bool Update()
        {
            string query = "";

            query = "Update tblJobCostCodePhase SET " +
                    " CostCodeDescription       = '" + costCodeDescription + "', " +
                    " ValueAdjustment           = " + valueAdjustment + ", " +
                    " QuantityAdjustment        = " + quantityAdjustment + " ";
                    if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator ||
                                       Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator)
                  {
                      query += ", MonthendValueAdjustment    = " + monthendValueAdjustment + " ";
                   }
                    query += " WHERE JobCostCodePhaseID  = " + JobCostCodePhaseID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool UpdateHistory()
        {
            string query = "";

            query = "Update tblJobCostCodePhaseHistory SET " +
                    " CostCodeDescription       = '" + costCodeDescription + "', " +
                    " ValueAdjustment           = " + valueAdjustment + ", " +
                    " QuantityAdjustment        = " + quantityAdjustment + ", " +
                    " Opencommitment            = " + openCommit + " ";

            if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator ||
                               Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator)
            {
                query += ", MonthendValueAdjustment    = " + monthendValueAdjustment + " ";
            } 
            query += " WHERE JobCostCodePhaseID  = " + JobCostCodePhaseID + " AND period = '" + period + "' ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
