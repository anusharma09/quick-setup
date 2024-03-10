using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobBiddingContractor
    {
        private string jobBiddingContractorID;
        private string jobID;
        private string contractorID;
        private string estimatorID;
        private string status;
        private string amount;
        //
        public string JobBiddingContractorID
        {
            get { return jobBiddingContractorID; }
        }
        //
        public JobBiddingContractor()
        {
        }
        public JobBiddingContractor(string jobBiddingContractorID,
                       string jobID,
                       string contractorID,
                       string estimatorID,
                       string status,
                       string amount)
        {
            this.jobBiddingContractorID = jobBiddingContractorID;
            this.jobID = String.IsNullOrEmpty(jobID) ? "Null" : jobID;
            this.contractorID = String.IsNullOrEmpty(contractorID) ? "Null" : contractorID;
            this.estimatorID = String.IsNullOrEmpty(estimatorID) ? "Null" : estimatorID;
            this.status = "'" + status.Trim().Replace("'", "''") + "'";
            this.amount = String.IsNullOrEmpty(amount) ? "null" : amount;
        }
        //
        public static DataSet GetJobBiddingContractorList(string jobID)
        {
            string query = "";
            query = " SELECT " +
                    " JobBiddingContractorID, " +
                    " r.JobID, " +
                    " ContractorID AS Contractor," + 
                    " EstimatorID AS Estimator, " +
                    " Status, " +
                    " Amount " +
                    " FROM tblJobBiddingContractor r " +
                    " WHERE r.JobID = " + jobID + " ";
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
        public static void Delete(string jobBiddingContractorID)
        {
            string query = " DELETE FROM tblJobBiddingContractor WHERE JobBiddingContractorID = " + jobBiddingContractorID + " ";

            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            if (jobBiddingContractorID == "" || jobBiddingContractorID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";
            
            query = "INSERT INTO tblJobBiddingContractor(" +
                    " JobID, " +
                    " ContractorID, " +
                    " EstimatorID, " +
                    " Status, " +
                    " Amount) VALUES (" +
                    jobID + ", " +
                    contractorID + ", " +
                    estimatorID + ", " +
                    status + ", " +
                    amount + ") " +
                   " SELECT SCOPE_IDENTITY()  ";
            try
            {
                jobBiddingContractorID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        private bool Update()
        {
            string query = "";

            query = "Update tblJobBiddingContractor SET " +
                    " JobID                         = " + jobID + ", " +
                    " ContractorID                  = " + contractorID + ", " +
                    " EstimatorID                   = " + estimatorID + ", " +
                    " Status                        = " + status + ", " +
                    " Amount                        = " + amount + " " +
                    " WHERE jobBiddingContractorID  = " + jobBiddingContractorID;
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
