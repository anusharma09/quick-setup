using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;


namespace JCCBusinessLayer
{
    public class JobChangeOrder
    {
        private string jobChangeOrderID;
        private string jobID;
        private string jobChangeOrderNumber;
        private string jobChangeOrderRequestDate;
        private string jobChangeOrderRequestedAmount;
        private string jobChangeOrderApprovedDate;
        private string jobChangeOrderApprovedAmount;
        private string jobChangeOrderStatus;
        private string jobChangeOrderDescription;
        private string jobChangeOrderUpdateFlag;
        private string jobChangeOrderLastUpdateDate;
        private string jobChangeOrderOwnerNumber;
        private string jobChangeOrderCCENumber;
        private string jobChangeOrderUserDescription;

        public string JobChangeOrderID
        {
            get { return jobChangeOrderID; }
        }

        public string JobChangeOrderNumber
        {
            get { return jobChangeOrderNumber; }
        }

        public JobChangeOrder()
        {
        }
        public JobChangeOrder(string jobChangeOrderID,
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
                                string jobChangeOrderUserDescription)
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
            this.jobChangeOrderLastUpdateDate = DateTime.Today.ToString();
            if (this.jobChangeOrderID == "")
                jobChangeOrderUpdateFlag = "0";
            else
                jobChangeOrderUpdateFlag = "1";
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
        public static DataSet GetJobChangeOrders(string jobID)
        {

            string query1 = "";
            string query2 = "";
            string query3 = "";

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
                     " JobChangeOrderUserDescription " +
                     " FROM tblJobChangeOrder " +
                     " WHERE JobID = '" + jobID + "' ";


            query2 = " SELECT JobChangeOrderCommentID, f.JobChangeOrderID, Comment, LastUpdateDate, UserID " +
                    " FROM tblJobChangeORder f " +
                    " INNER JOIN tblJobChangeOrderComment c ON f.JobChangeOrderID = c.JobChangeOrderID " +
                    " WHERE JobID = " + jobID + "  ORDER by c.LastUpdateDate DESC ";


            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query1, query2, query3, "JobChangeOrderID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }













            /*
                        string query = "";

                        query = "SELECT   " +
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
                                " JobChangeOrderUserDescription " +
                                " FROM tblJobChangeOrder " +
                                " WHERE JobID = '" + jobID + "' ";

                        //query = "SELECT * FROM tblJobChangeOrder" +
                        //        " WHERE JobID = '" + jobID + "' ";


                        try
                        {
                            return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        } */
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
                jobChangeOrderID = "0";

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


        public static DataSet GetJobChangeOrder(string jobChangeOrderID)
        {


            string query = "";
            if (jobChangeOrderID == "")
                jobChangeOrderID = "0";

            query = "SELECT * FROM tblJobChangeOrder" +
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

        public bool Save()
        {
            if (jobChangeOrderID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobChangeOrder(JobID, JobChangeOrderNumber, " +
                    " JobChangeOrderRequestDate, JobChangeOrderRequestedAmount, " +
                    " JobChangeOrderApprovedDate, JobChangeOrderApprovedAmount, " +
                    " JobChangeOrderStatus, JobChangeOrderDescription, " +
                    " JobChangeOrderUpdateFlag, JobChangeOrderLastUpdate, JobChangeOrderOwnerNumber, JobChangeOrderCCENumber, JobChangeOrderUserDescription, AuditUserID) Values(" +
                    jobID + ", dbo.GetNewJobChangeOrderNumber ( " + jobID + "), " +
                    " " + jobChangeOrderRequestDate + ", " + jobChangeOrderRequestedAmount + ", " +
                    " " + jobChangeOrderApprovedDate + ", " + jobChangeOrderApprovedAmount + ", " +
                    " '" + jobChangeOrderStatus + "', '" + jobChangeOrderDescription + "', " +
                    " " + jobChangeOrderUpdateFlag + ", '" + jobChangeOrderLastUpdateDate + "', '" + jobChangeOrderOwnerNumber + "', '" + jobChangeOrderCCENumber + "', '" + jobChangeOrderUserDescription + "', '" + Security.Security.LoginID + "')" +
                    "Select @@IDENTITY ";
            try
            {
                jobChangeOrderID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                // Get JobChange Order Number //
                query = "SELECT JobChangeOrderNumber FROM tblJobChangeOrder WHERE JobChangeOrderID =  " + jobChangeOrderID + " ";
                jobChangeOrderNumber = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0].Rows[0][0].ToString();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool Update()
        {
            string query = "";

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
                    " AuditUserID                     = '" + Security.Security.LoginID + "' " +
                    " WHERE JobChangeOrderID = " + jobChangeOrderID;
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
