using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobSubmittal
    {
        private string jobSubmittalID;
        private string jobID;
        private string jobSubmittalSpecID;
        private string title;

        public string JobSubmittalID
        {
            get { return jobSubmittalID; }
        }

        public JobSubmittal()
        {
        }
        public JobSubmittal(string jobSubmittalID,
                       string jobID,
                       string jobSubmittalSpecID,
                       string title)
        {
            this.jobSubmittalID = jobSubmittalID;
            this.jobID = String.IsNullOrEmpty(jobID) ? "Null" : jobID;
            this.jobSubmittalSpecID = String.IsNullOrEmpty(jobSubmittalSpecID) ? "Null" : jobSubmittalSpecID;
            this.title = "'" + title.Trim().Replace("'", "''") + "'";
        }
        //
        public static DataSet GetJobSubmittalList(string jobID)
        {
            string query = "";
            string query1 = ""; 
            query = " SELECT " +
	                " s.JobSubmittalID, " +
	                " JobSubmittalSpecSection AS [Spec],  " +
	                " JobSubmittalSpecDescription   AS [Description], " +
	                " Title, " +
	                " RevisionNumber AS [Rev No], " +
	                " JobSubmittalStatusDescription AS [Status], " +
	                " SubmittedDate AS [Submitted Date], " +
	                " ReceivedDate  AS [Received Date], " +
	                " Note " +
                    " FROM tblJobSubmittal s " +
                    " LEFT Join tblJob j ON s.JobID = j.JobID " +
                    " LEFT JOIN tblJobSubmittalDetail d ON s.JobSubmittalID = d.JobSubmittalID " + 
	                " AND d.RevisionNumber = (Select MAX(RevisionNumber) FROM tblJobSubmittalDetail aa WHERE jobSubmittalID = s.JobSubmittalID) " +
                    " LEFT JOIN tblJobSubmittalSpec sp ON s.JobSubmittalSpecID = sp.JobSubmittalSpecID AND s.JobID = sp.JobID " +
                    " LEFT JOIN tblJobSubmittalStatus st ON d.JobSubmittalStatusID = st.JobSubmittalStatusID " +
                    " WHERE s.JobID = " + jobID + " ORDER BY  RevisionNumber";

            query1 = " SELECT d.JobSubmittalID, " +
                     " RevisionNumber AS [Rev No], " +
                     " JobSubmittalStatusDescription AS [Status], " +
                     " SubmittedDate AS [Submitted Date], " +
                     " ReceivedDate AS [Received Date], " +
                     " Note " +
                     " FROM tblJobSubmittalDetail d " +
                     " LEFT JOIN tblJobSubmittal s ON d.JobSubmittalID = s.JobSubmittalID " +
                     " LEFT JOIN tblJobSubmittalStatus ss ON d.JobSubmittalStatusID = ss.JobSubmittalStatusID " +
                     " WHERE s.JobID = " + jobID + " ORDER BY  RevisionNumber";

            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query, query1, "", "JobSubmittalID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetJobSubmittalForm(string jobSubmittalID)
        {
            string query = "";

            query = " SELECT  " +
                    " j.JobNumber, " +
                    " jobName, " +
                    " JobSubmittalSpecSection, " +
                    " JobSubmittalSpecDescription, " +
                    " Title, " +
                    " RevisionNumber, " +
                    " JobSubmittalStatusDescription, " +
                    " SubmittedDate, " +
                    " ReceivedDate, " +
                    " Note " +
                    " FROM tblJobSubmittal s " +
                    " LEFT Join tblJob j ON s.JobID = j.JobID " +
                    " LEFT JOIN tblJobSubmittalDetail d ON s.JobSubmittalID = d.JobSubmittalID " +
                    " LEFT JOIN tblJobSubmittalSpec sp ON s.JobSubmittalSpecID = sp.JobSubmittalSpecID AND s.JobID = sp.JobID " +
                    " LEFT JOIN tblJobSubmittalStatus st ON d.JobSubmittalStatusID = st.JobSubmittalStatusID " +
                    " WHERE s.JobSubmittalID = " + jobSubmittalID + " ";
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
        public static DataSet GetJobSubmittalDetail(string jobSubmittalID)
        {
            string query = "";

            query = " SELECT * " +
                    " FROM tblJobSubmittal " +
                    " WHERE JobSubmittalID = " + jobSubmittalID + " ";
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
        public bool Save()
        {
            if (jobSubmittalID == "" || jobSubmittalID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSubmittal(" +
                    " JobID, " +
                    " JobSubmittalSpecID, " +
                    " Title) VALUES (" +
                    jobID + ", " +
                    jobSubmittalSpecID + ", " +
                    title + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobSubmittalID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobSubmittal SET " +
                    " JobID                 = " + jobID + ", " +
                    " JobSubmittalSpecID    = " + jobSubmittalSpecID + ", " +
                    " Title                 = " + title + " " +
                    " WHERE JobSubmittalID  = " + jobSubmittalID;
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
        public static void Delete(string jobSubmittalID)
        {
            string query = "";
            try
            {
                query = "DELETE FROM tblJobSubmittalDetail WHERE JobSubmittalID = " + jobSubmittalID + " ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);

                query = "DELETE FROM tblJobSubmittal WHERE JobSubmittalID = " + jobSubmittalID + " ";

                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
