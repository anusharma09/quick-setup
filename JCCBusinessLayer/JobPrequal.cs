using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace JCCBusinessLayer
{
    public class JobPrequal
    {
        private string jobPrequalKeywordID;
        private string jobID;
        private string prequalKeywordID;
        //
        public JobPrequal()
        {
        }
        //
        public JobPrequal(string jobPrequalKeywordID,
                            string jobID,
                            string prequalKeywordID)
        {

            this.jobPrequalKeywordID        = jobPrequalKeywordID;
            this.jobID                      = jobID;
            this.prequalKeywordID           = prequalKeywordID;
        }
        //
        public string JobPrequalKeywordID
        {
            get { return jobPrequalKeywordID; }
        }
        //
        public static DataSet GetJobPrequalKeyword(string jobID)
        {
            if (jobID == "")
                jobID = "0";

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobID", jobID);

            try
            {
                return DataBaseUtil.ExecuteParDataset("up_JCGetJobPrequalKeyward", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        //
        public static bool Remove(string jobPrequalKeywordID)
        {
            string query = "";

            query = "DELETE FROM tblJobPrequalKeyword WHERE JobPrequalKeywordID = " + jobPrequalKeywordID;
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
        //
        public bool Save()
        {
            if (jobPrequalKeywordID == "")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobPrequalKeyword(JobID, PrequalKeywordID) Values(" +
                    jobID + ", " + prequalKeywordID + ") " +
                    "Select @@IDENTITY ";
            try
            {
                jobPrequalKeywordID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobPrequalKeyword SET " +
                    " JobID             = " + jobID + ", " +
                    " PrequalKeywordID  = " + prequalKeywordID + " " +
                    " WHERE JobPrequalKeywordID = " + jobPrequalKeywordID;
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
        //
        public static void UpdatePrequalComment(string jobID, string scopeOfWork)
        {
            string query = "";

            query = "UPDATE tblJob SET ScopeOfWork = '" + scopeOfWork.Replace("'", "''") + "' WHERE JobID = " + jobID;
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
    }
}
