using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCSwitchgear.BusinessLayer
{
    class SwitchgearRevision
    {
        private string jobSwitchgearRevisionID;
        private string jobID;
        private string revisionNumber;
        private string revisionDate;
        //
        public SwitchgearRevision()
        {
        }
        //
        public SwitchgearRevision(string jobSwitchgearRevisionID,
                                      string jobID,
                                      string revisionDate)
        {
            this.jobSwitchgearRevisionID = jobSwitchgearRevisionID;
            this.jobID = jobID;
            this.revisionDate = String.IsNullOrEmpty(revisionDate) ? "null" : "'" + revisionDate + "'";
        }
        //
        public string JobSwitchgearRevisionID
        {
            get { return jobSwitchgearRevisionID; }
        }
        //
        public string RevisionNumber
        {
            get { return revisionNumber; }
        }
        //
        //
        public static DataSet GetJobSwitchgearRevision(string jobID)
        {

            string query = "";
            string query1 = "";
            query = " SELECT " +
                    " JobSwitchgearRevisionID, " +
                    " RevisionNumber AS [Rev No], " +
                    " RevisionDate AS [Rev Date] " +
                    " FROM tblJobSwitchGearRevision " +
                    " WHERE JobID = " + jobID + " ";

            query1 = " SELECT " +
                     " d.JobSwitchgearRevisionID, " +
                     " ItemNo AS [Item No], " +
                     " Designation, " +
                     " Description, " +
                     " d.Quantity, " +
                     " EstimatedShipDate AS [Est Ship Date] " +
                     " FROM tblJobSwitchgearRevisionDetail d " +
                     " INNER JOIN tblJobSwitchgearRevision r ON d.JobSwitchgearRevisionID = r.JobSwitchgearRevisionID " +
                     " INNER JOIN tblJobSwitchgear f ON d.JobSwitchgearID = f.JobSwitchgearID " +
                     " WHERE r.JobID = " + jobID + " ";

            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query, query1, "", "JobSwitchgearRevisionID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetSwitchgearRevisionForm(string jobSwitchgearRevisionID)
        {

            string query = " SELECT  " +
                           " JobNumber, " +
                           "     JobName, " +
                           "     r.RevisionNumber, " +
                           "     r.RevisionDate, " +
                           "     ItemNo, " +
                           "     Designation, " +
                           "     Description, " +
                           "     d.Quantity, " +
                           "     d.Notes, " +
                           "     EstimatedShipDate " +
                           " FROM tblJobSwitchgearRevision r " +
                           " LEFT JOIN tblJobSwitchgearRevisionDetail d ON r.JobSwitchgearRevisionID = d.JobSwitchgearRevisionID " +
                           " LEFT JOIN tblJobSwitchgear f ON d.JobSwitchgearID = f.JobSwitchgearID " +
                           " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           " WHERE r.JobSwitchgearRevisionID = " + jobSwitchgearRevisionID + " ";
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
        public static DataSet GetSwitchgearRevisionItems(string jobSwitchgearRevisionID)
        {

            string query = " SELECT * " +
                           " FROM tblJobSwitchgearRevisionDetail " +
                           " WHERE JobSwitchgearRevisionID = " + jobSwitchgearRevisionID + " ";
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
        public static DataSet GetSwitchgearRevision(string jobSwitchgearRevisionID)
        {

            string query = " SELECT * " +
                           " FROM tblJobSwitchgearRevision " +
                           " WHERE JobSwitchgearRevisionID = " + jobSwitchgearRevisionID + " ";
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
        public static bool Remove(string jobSwitchgearRevisionID)
        {
            string query = "";

            query = "DELETE FROM tblJobSwitchgearRevisionDetail WHERE JobSwitchgearRevisionID = " + jobSwitchgearRevisionID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblJobSwitchgearRevision WHERE JobSwitchgearRevisionID = " + jobSwitchgearRevisionID;
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
            if (jobSwitchgearRevisionID == "" || jobSwitchgearRevisionID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSwitchgearRevision(" +
                    " JobID, " +
                    " RevisionDate " +
                    " ) VALUES ( " +
                    jobID + ", " +
                    revisionDate + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobSwitchgearRevisionID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                query = "SELECT RevisionNumber FROM tblJobSwitchgearRevision WHERE JobSwitchgearRevisionID = " + jobSwitchgearRevisionID + " ";

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

            query = "Update tblJobSwitchgearRevision SET " +
                    " JobID             = " + jobID + ", " +
                    " RevisionDate       = " + revisionDate + " " +
                    " WHERE JobSwitchgearRevisionID   = " + jobSwitchgearRevisionID;
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
