using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace JCCBusinessLayer
{
    public class JobCostTimeSheet
    {
        private string jobCostCodeWeeklyID;
        private string jobCostCodePhaseID;
        private string weekEnd;
        private string selected;
        private string quantity;
        private string hours;
        public JobCostTimeSheet()
        {
        }
        public JobCostTimeSheet(string jobCostCodeWeeklyID, 
                                string jobCostCodePhaseID,
                                string weekEnd,
                                string quantity,
                                string hours)
        {

            this.jobCostCodeWeeklyID = jobCostCodeWeeklyID;
            this.jobCostCodePhaseID = jobCostCodePhaseID;
            this.weekEnd = weekEnd;
            this.selected = "0";
            this.quantity = String.IsNullOrEmpty(quantity) ? "null" : quantity;
            this.hours = String.IsNullOrEmpty(hours) ? "null" : hours;
        }


        public static DataSet CreateTimeSheet(string jobID)
        {
            try
            {
                
                SqlParameter[] par = new SqlParameter[1];

                par[0] = new SqlParameter("@jobId", Convert.ToInt16(jobID));
                return DataBaseUtil.ExecuteParDataset("dbo.up_JCCreateTimeSheet", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetCostCodeWeeklyEmployee(string jobID, string weekend )
        {
            string query = "";
            if (jobID == "")
                jobID = "0";
            query = " DECLARE @JobNumber VARCHAR(10) " +
                  " SELECT @JobNumber = JobNumber FROM tblJob WHERE JobID = " + jobID + " " +
                  " SELECT Distinct empName FROM tblJobHour WHERE JobNumber = @JobNumber AND weekend =  '" + weekend + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetCostCodeWeeklyDates(string jobID)
        {
            string query = "";
            if (jobID == "")
                jobID = "0";
            query = "SELECT Distinct Weekend as [WeekEnd] FROM tblJobCostCodePhase p  " +
                    " INNER JOIN tblJobCostCodesWeekly w " +
                    " ON p.JobCostCodePhaseID = w.JobCostCodePhaseID " +
                    " WHERE jobID = " + jobID + " Order by WeekEnd Desc ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetCostCodeWeekly(string jobID, string weekEnd)
        {

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@JobID", jobID);
            par[1] = new SqlParameter("@WeekEnd", weekEnd);


            try
            {
                return DataBaseUtil.ExecuteParDataset("up_jCGetJobCostCodeWeekly", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetTimeCard(string jobID)
        {
            string query = "";

            if (CCEApplication.Company.ToUpper() == "DYNA")
                query = "SELECT  Selected, JobCostCodePhase as [Phase], CostCode As [Code], " +
                    " UserDescription As [Description], Unit " +
                    " FROM tblJobCostCodePhase " +
                    " WHERE (jobID = " + jobID + ")  AND (JobCostCodeType = 'L' OR JobCostCodeType = 'O')  " +
                    " Order By JobCostCodePhase, CostCode ";

            else
                query = "SELECT  Selected, JobCostCodePhase as [Phase], CostCode As [Code], " +
                        " UserDescription As [Description], Unit " +
                        " FROM tblJobCostCodePhase " +
                        " WHERE (jobID = " + jobID + ")  AND (JobCostCodePhase like '1%' OR JobCostCodePhase Like '5%' OR JobCostCodePhase Like '8%')  " + 
                        " Order By JobCostCodePhase, CostCode ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetCostCodeWeeklyTimeSheet(string jobID, string weekEnd)
        {
            string query = "";

            query = "SELECT  JobNumber, jobName,CONVERT(VARCHAR(10), WeekEnd,101) As [WeekEnd], JobCostCodePhase as [Phase], CostCode As [Cost Code]" +
                    " CostCodeTitle As [Title], CostCodeDescription As [Description], w.quantity, w.hours" + 
                    " FROM tblJobCostCodePhase c " +  
                    " LEFT JOIN tblJobCostCodesWeekly w ON c.JobCostCodePhaseID = w.JobCostCodePhaseID " + 
                    " LEFT JOIN tblJob j ON c.JobID = j.JobID " +  
                    " WHERE c.jobID = " + jobID + "AND WeekEnd = '" + weekEnd + "' AND w.Selected = 1";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Remove(string jobCostCodeWeeklyID)
        {
            string query = "";

            query = "DELETE FROM tblJobCostCodesWeekly WHERE JobCostCodeWeeklyID = " + jobCostCodeWeeklyID;
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
        
        
        public bool Save()
        {
            if (jobCostCodeWeeklyID == "")
                return Insert();
            else
                return Update();
        }

        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobCostCodesWeekly(JobCostCodePhaseID, WeekEnd, Quantity, hours, Selected, AuditUserID) Values(" +
                    jobCostCodePhaseID + ", '" + weekEnd + "', " + quantity + ", " + hours + ", 1, '" + Security.Security.LoginID + "')";
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

        private bool Update()
        {
            string query = "";

            query = "Update tblJobCostCodesWeekly SET " +
                    " Selected          =  1, " +
                    " quantity          = " + quantity + ", " +
                    " hours             = " + hours + ", " +
                    " AuditUserID       = '" + Security.Security.LoginID + "' " +
                    " WHERE JobCostCodeWeeklyID = " + jobCostCodeWeeklyID;
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
