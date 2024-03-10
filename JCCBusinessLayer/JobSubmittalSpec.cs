using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobSubmittalSpec
    {
        private string jobSubmittalSpecID;
        private string jobID;
        private string jobSubmittalSpecSection;
        private string jobSubmittalSpecDescription;

        public string JobSubmittalSpecID
        {
            get { return jobSubmittalSpecID; }
        }

        public JobSubmittalSpec()
        {
        }
        public JobSubmittalSpec(string jobSubmittalSpecID,
                       string jobID,
                       string jobSubmittalSpecSection,
                       string jobSubmittalSpecDescription)
        {
            this.jobSubmittalSpecID = jobSubmittalSpecID;
            this.jobID = String.IsNullOrEmpty(jobID) ? "Null" : jobID;
            this.jobSubmittalSpecSection = "'" + jobSubmittalSpecSection.Trim().Replace("'", "''") + "'";
            this.jobSubmittalSpecDescription = "'" + jobSubmittalSpecDescription.Trim().Replace("'", "''") + "'";
        }
        //
        public static DataSet GetJobSubmittalSpec(string jobID)
        {
            string query = "";

            query = " SELECT JobSubmittalSpecID, JobSubmittalSpecSection, JobSubmittalSpecDescription FROM tblJobSubmittalSpec " +
                    " WHERE JobID = " + jobID + " ";
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
            if (jobSubmittalSpecID == "" || jobSubmittalSpecID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSubmittalSpec(" +
                    " JobID, " +
                    " JobSubmittalSpecSection, " +
                    " JobSubmittalSpecDescription) VALUES (" +
                    jobID + ", " +
                    jobSubmittalSpecSection + ", " +
                    jobSubmittalSpecDescription + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobSubmittalSpecID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobSubmittalSpec SET " +
                    " JobID                         = " + jobID + ", " +
                    " JobSubmittalSpecSection       = " + jobSubmittalSpecSection + ", " +
                    " JobSubmittalSpecDescription   = " + jobSubmittalSpecDescription + " " +
                    " WHERE JobSubmittalSpecID      = " + jobSubmittalSpecID;
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
        public static void Delete(string jobSubmittalSpecID)
        {
            string query = "";

            query = "DELETE FROM tblJobSubmittalSpec WHERE JobSubmittalSpecID = " + jobSubmittalSpecID + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
