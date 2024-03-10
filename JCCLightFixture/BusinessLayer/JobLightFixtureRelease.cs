using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCLightFixture.BusinessLayer
{
    class JobLightFixtureRelease
    {
        private string jobLightFixtureReleaseID;
        private string jobID;
        private string poNumber;
        private string releaseNumber;
        private string releaseDate;
        //
        public JobLightFixtureRelease()
        {
        }
        //
        public JobLightFixtureRelease(string jobLightFixtureReleaseID,
                                      string jobID,
                                      string poNumber,
                                      string releaseDate)
        {
            this.jobLightFixtureReleaseID   = jobLightFixtureReleaseID;
            this.jobID                      = jobID;
            this.poNumber                   = "'" + poNumber.Trim().Replace("'", "''") + "'";
            this.releaseDate                = String.IsNullOrEmpty(releaseDate) ? "null" : "'" + releaseDate + "'";
        }
        //
        public string JobLightFixtureReleaseID
        {
            get { return jobLightFixtureReleaseID; }
        }
        //
        public string ReleaseNumber
        {
            get { return releaseNumber; }
        }
        //
        //
        public static DataSet GetJobLightFixtureRelease(string jobID)
        {

            string query = "";
            string query1 = "";
            query = " SELECT " + 
	                " JobLightFixtureReleaseID, " +
	                " PONumber AS [PO Number], " +
	                " ReleaseNumber AS [Rel No], " +
	                " ReleaseDate AS [Rel Date] " +
                    " FROM tblJobLightFixtureRelease " +
                    " WHERE JobID = " + jobID + " ";

            query1 = " SELECT " +
	                 " d.JobLightFixtureReleaseID, " +
                     " f.Type, " +
	                 " MFGR, " +
	                 " Description, " +
	                 " d.QtyRun AS [Qty Run], " +
	                 " d.Length, " +
	                 " EstimatedShipDate AS [Est Ship Date], " +
                     " d.Notes " +
                     " FROM tblJobLightFixtureReleaseDetail d " +
                     " INNER JOIN tblJobLightFixtureRelease r ON d.JobLightFixtureReleaseID = r.JobLightFixtureReleaseID " +
                     " INNER JOIN tblJobLightFixture f ON d.JobLightFixtureID = f.JobLightFixtureID " +
                     " WHERE r.JobID = " + jobID + " ";

            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query, query1, "", "JobLightFixtureReleaseID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetLightFixtureReleaseForm(string jobLightFixtureReleaseID)
        {

            string query = " SELECT  " +
                           " JobNumber, " +
	                       "     JobName, " +
	                       "     r.PONumber, " +
	                       "     r.ReleaseNumber, " +
	                       "     r.ReleaseDate, " +
	                       "     Type, " +
	                       "     MFGR, " +
	                       "     Description, " +
	                       "     d.QtyRun, " +
                           "     d.Notes, " +
	                       "     d.Length, " +
	                       "     EstimatedShipDate " +
                           " FROM tblJobLightFixtureRelease r " +
                           " LEFT JOIN tblJobLightFixtureReleaseDetail d ON r.JobLightFixtureReleaseID = d.JobLightFixtureReleaseID " +
                           " LEFT JOIN tblJobLightFixture f ON d.JobLightFixtureID = f.JobLightFixtureID " +
                           " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           " WHERE r.JobLightFixtureReleaseID = " + jobLightFixtureReleaseID + " ";
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
        public static DataSet GetLightFixtureReleaseItems(string jobLightFixtureReleaseID)
        {

            string query = " SELECT * " +
                           " FROM tblJobLightFixtureReleaseDetail " +
                           " WHERE JobLightFixtureReleaseID = " + jobLightFixtureReleaseID + " ";
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
        public static DataSet GetLightFixtureRelease(string jobLightFixtureReleaseID)
        {

            string query = " SELECT * " +
                           " FROM tblJobLightFixtureRelease " +
                           " WHERE JobLightFixtureReleaseID = " + jobLightFixtureReleaseID + " ";
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
        public static bool Remove(string jobLightFixtureReleaseID)
        {
            string query = "";

            query = "DELETE FROM tblJobLightFixtureReleaseDetail WHERE JobLightFixtureReleaseID = " + jobLightFixtureReleaseID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblJobLightFixtureRelease WHERE JobLightFixtureReleaseID = " + jobLightFixtureReleaseID;
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
            if (jobLightFixtureReleaseID == "" || jobLightFixtureReleaseID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobLightFixtureRelease(" +
                    " JobID, " +
                    " PONumber, " +
                    " ReleaseDate " +
                    " ) VALUES ( " +
                    jobID + ", " +
                    poNumber + ", " +
                    releaseDate + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobLightFixtureReleaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                query = "SELECT ReleaseNumber FROM tblJobLightFixtureRelease WHERE JobLightFixtureReleaseID = " + jobLightFixtureReleaseID + " ";

                DataTable t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    releaseNumber = t.Rows[0]["ReleaseNumber"].ToString();
                else
                    releaseNumber = "";
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

            query = "Update tblJobLightFixtureRelease SET " +
                    " JobID             = " + jobID + ", " +
                    " PONumber          = " + poNumber + ", " +
                    " ReleaseDate       = " + releaseDate + " " +
                    " WHERE JobLightFixtureReleaseID   = " + jobLightFixtureReleaseID;
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
