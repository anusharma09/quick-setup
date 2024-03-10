using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCSwitchgear.BusinessLayer
{
    class SwitchgearRelease
    {
        private string jobSwitchgearReleaseID;
        private string jobID;
        private string poNumber;
        private string releaseNumber;
        private string releaseDate;
        //
        public SwitchgearRelease()
        {
        }
        //
        public SwitchgearRelease(string jobSwitchgearReleaseID,
                                      string jobID,
                                      string poNumber,
                                      string releaseDate)
        {
            this.jobSwitchgearReleaseID = jobSwitchgearReleaseID;
            this.jobID = jobID;
            this.poNumber = "'" + poNumber.Trim().Replace("'", "''") + "'";
            this.releaseDate = String.IsNullOrEmpty(releaseDate) ? "null" : "'" + releaseDate + "'";
        }
        //
        public string JobSwitchgearReleaseID
        {
            get { return jobSwitchgearReleaseID; }
        }
        //
        public string ReleaseNumber
        {
            get { return releaseNumber; }
        }
        //
        //
        public static DataSet GetJobSwitchgearRelease(string jobID)
        {

            string query = "";
            string query1 = "";
            query = " SELECT " +
                    " JobSwitchgearReleaseID, " +
                    " PONumber AS [PO Number], " +
                    " ReleaseNumber AS [Rel No], " +
                    " ReleaseDate AS [Rel Date] " +
                    " FROM tblJobSwitchGearRelease " +
                    " WHERE JobID = " + jobID + " ";

            query1 = " SELECT " +
                     " d.JobSwitchgearReleaseID, " +
                     " ItemNo AS [Item No], " +
                     " Designation, " +
                     " Description, " +
                     " d.Quantity, " +
                     " EstimatedShipDate AS [Est Ship Date] " +
                     " FROM tblJobSwitchgearReleaseDetail d " +
                     " INNER JOIN tblJobSwitchgearRelease r ON d.JobSwitchgearReleaseID = r.JobSwitchgearReleaseID " +
                     " INNER JOIN tblJobSwitchgear f ON d.JobSwitchgearID = f.JobSwitchgearID " +
                     " WHERE r.JobID = " + jobID + " ";

            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query, query1, "", "JobSwitchgearReleaseID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetSwitchgearReleaseForm(string jobSwitchgearReleaseID)
        {

            string query = " SELECT  " +
                           " JobNumber, " +
                           "     JobName, " +
                           "     r.PONumber, " +
                           "     r.ReleaseNumber, " +
                           "     r.ReleaseDate, " +
                           "     ItemNo, " +
                           "     Designation, " +
                           "     Description, " +
                           "     d.Quantity, " +
                           "     d.Notes, " +
                           "     EstimatedShipDate " +
                           " FROM tblJobSwitchgearRelease r " +
                           " LEFT JOIN tblJobSwitchgearReleaseDetail d ON r.JobSwitchgearReleaseID = d.JobSwitchgearReleaseID " +
                           " LEFT JOIN tblJobSwitchgear f ON d.JobSwitchgearID = f.JobSwitchgearID " +
                           " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           " WHERE r.JobSwitchgearReleaseID = " + jobSwitchgearReleaseID + " ";
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
        public static DataSet GetSwitchgearReleaseItems(string jobSwitchgearReleaseID)
        {

            string query = " SELECT * " +
                           " FROM tblJobSwitchgearReleaseDetail " +
                           " WHERE JobSwitchgearReleaseID = " + jobSwitchgearReleaseID + " ";
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
        public static DataSet GetSwitchgearRelease(string jobSwitchgearReleaseID)
        {

            string query = " SELECT * " +
                           " FROM tblJobSwitchgearRelease " +
                           " WHERE JobSwitchgearReleaseID = " + jobSwitchgearReleaseID + " ";
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
        public static bool Remove(string jobSwitchgearReleaseID)
        {
            string query = "";

            query = "DELETE FROM tblJobSwitchgearRelease WHERE JobSwitchgearReleaseID = " + jobSwitchgearReleaseID;
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
            if (jobSwitchgearReleaseID == "" || jobSwitchgearReleaseID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSwitchgearRelease(" +
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
                jobSwitchgearReleaseID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                query = "SELECT ReleaseNumber FROM tblJobSwitchgearRelease WHERE JobSwitchgearReleaseID = " + jobSwitchgearReleaseID + " ";

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

            query = "Update tblJobSwitchgearRelease SET " +
                    " JobID             = " + jobID + ", " +
                    " PONumber          = " + poNumber + ", " +
                    " ReleaseDate       = " + releaseDate + " " +
                    " WHERE JobSwitchgearReleaseID   = " + jobSwitchgearReleaseID;
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
