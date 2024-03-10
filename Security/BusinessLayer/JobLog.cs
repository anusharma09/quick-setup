using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace Security.BusinessLayer
{
    public class JobLog
    {
        private string jobLogID;
        private string jobID;
        private string userID;
        private string module;
        private string date;

        public string JobLogID
        {
            get { return jobLogID; }
        }

        public JobLog()
        {
        }
        public JobLog(string jobLogID,
                    string jobID,
                    string userID,
                    string module)
        {
            this.jobLogID = jobLogID;
            this.jobID = jobID;
            this.userID = userID;
            this.module = module;
            this.date = DateTime.Now.ToShortDateString(); 

        }

        
        public static DataSet GetJobLog(string jobID)
        {
            string query = "";

            query = " SELECT JobLogID, " +
                    " UserName as [User], " +
                    " Module = " +
                    " CASE Module " +
                    " WHEN 'B' THEN 'Job Info' " +
                    " WHEN 'W' THEN 'Weekly Quantity' " +
                    " WHEN 'P' THEN 'Job Progress' " +
                    " WHEN 'S' THEN 'Job Progress Summary' " +
                    " WHEN 'L' THEN 'Labor Feedback' " +
                    " ELSE '' " +
                    " END, " +
                    " [Date] " +
                    " FROM tblJobLog j " +
                    " LEFT JOIN tblUser u ON j.UserID = u.UserID " +
                    " WHERE JobID  = " + jobID + "";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public bool Save()
        {
            return Insert();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobLog(JobID, UserID, Module, Date) Values(" +
                    jobID + ", " + userID + ", '" + module + "', '" + date + "') " +
                    "Select @@IDENTITY ";
            try
            {
                jobLogID = DataBaseUtil.ExecuteScalar(query, Security.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
