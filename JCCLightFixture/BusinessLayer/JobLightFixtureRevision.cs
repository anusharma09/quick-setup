using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCLightFixture.BusinessLayer
{
    class JobLightFixtureRevision
    {
        private string jobLightFixtureRevisionID;
        private string jobID;
        private string revisionNumber;
        private string revisionDate;
        //
        public JobLightFixtureRevision()
        {
        }
        //
        public JobLightFixtureRevision(string jobLightFixtureRevisionID,
                                      string jobID,
                                      string revisionDate)
        {
            this.jobLightFixtureRevisionID   = jobLightFixtureRevisionID;
            this.jobID                      = jobID;
            this.revisionDate                = String.IsNullOrEmpty(revisionDate) ? "null" : "'" + revisionDate + "'";
        }
        //
        public string JobLightFixtureRevisionID
        {
            get { return jobLightFixtureRevisionID; }
        }
        //
        public string RevisionNumber
        {
            get { return revisionNumber; }
        }
        //
        //
        public static DataSet GetJobLightFixtureRevision(string jobID)
        {

            string query = "";
            string query1 = "";
            query = " SELECT " + 
	                " JobLightFixtureRevisionID, " +
	                " RevisionNumber AS [Rev No], " +
	                " RevisionDate AS [Rev Date] " +
                    " FROM tblJobLightFixtureRevision " +
                    " WHERE JobID = " + jobID + " ";

            query1 = " SELECT " +
	                 " d.JobLightFixtureRevisionID, " +
                     " f.Type, " +
	                 " MFGR, " +
	                 " Description, " +
	                 " d.QtyRun AS [Qty Run], " +
	                 " d.Length, " +
	                 " EstimatedShipDate AS [Est Ship Date], " +
                     " d.Notes " +
                     " FROM tblJobLightFixtureRevisionDetail d " +
                     " INNER JOIN tblJobLightFixtureRevision r ON d.JobLightFixtureRevisionID = r.JobLightFixtureRevisionID " +
                     " INNER JOIN tblJobLightFixture f ON d.JobLightFixtureID = f.JobLightFixtureID " +
                     " WHERE r.JobID = " + jobID + " ";

            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query, query1, "", "JobLightFixtureRevisionID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetLightFixtureRevisionForm(string jobLightFixtureRevisionID)
        {

            string query = " SELECT  " +
                           " JobNumber, " +
	                       "     JobName, " +
	                       "     r.RevisionNumber, " +
	                       "     r.RevisionDate, " +
	                       "     Type, " +
	                       "     MFGR, " +
	                       "     Description, " +
	                       "     d.QtyRun, " +
                           "     d.Notes, " +
	                       "     d.Length, " +
	                       "     EstimatedShipDate " +
                           " FROM tblJobLightFixtureRevision r " +
                           " LEFT JOIN tblJobLightFixtureRevisionDetail d ON r.JobLightFixtureRevisionID = d.JobLightFixtureRevisionID " +
                           " LEFT JOIN tblJobLightFixture f ON d.JobLightFixtureID = f.JobLightFixtureID " +
                           " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           " WHERE r.JobLightFixtureRevisionID = " + jobLightFixtureRevisionID + " ";
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
        public static DataSet GetLightFixtureRevisionItems(string jobLightFixtureRevisionID)
        {

            string query = " SELECT * " +
                           " FROM tblJobLightFixtureRevisionDetail " +
                           " WHERE JobLightFixtureRevisionID = " + jobLightFixtureRevisionID + " ";
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
        public static DataSet GetLightFixtureRevision(string jobLightFixtureRevisionID)
        {

            string query = " SELECT * " +
                           " FROM tblJobLightFixtureRevision " +
                           " WHERE JobLightFixtureRevisionID = " + jobLightFixtureRevisionID + " ";
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
        public static bool Remove(string jobLightFixtureRevisionID)
        {
            string query = "";

            query = "DELETE FROM tblJobLightFixtureRevisionDetail WHERE JobLightFixtureRevisionID = " + jobLightFixtureRevisionID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblJobLightFixtureRevision WHERE JobLightFixtureRevisionID = " + jobLightFixtureRevisionID;
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
            if (jobLightFixtureRevisionID == "" || jobLightFixtureRevisionID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobLightFixtureRevision(" +
                    " JobID, " +
                    " RevisionDate " +
                    " ) VALUES ( " +
                    jobID + ", " +
                    revisionDate + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobLightFixtureRevisionID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                query = "SELECT RevisionNumber FROM tblJobLightFixtureRevision WHERE JobLightFixtureRevisionID = " + jobLightFixtureRevisionID + " ";

                DataTable t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    revisionNumber = t.Rows[0]["RevisionNumber"].ToString();
                else
                    revisionNumber = "";
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

            query = "Update tblJobLightFixtureRevision SET " +
                    " JobID             = " + jobID + ", " +
                    " RevisionDate      = " + revisionDate + " " +
                    " WHERE JobLightFixtureRevisionID   = " + jobLightFixtureRevisionID;
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
