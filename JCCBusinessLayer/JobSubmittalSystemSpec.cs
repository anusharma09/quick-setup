using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobSubmittalSystemSpec
    {
        private string jobSubmittalSystemSpecID;
        private string jobSubmittalSystemSpecSection;
        private string jobSubmittalSystemSpecDescription;

        public string JobSubmittalSystemSpecID
        {
            get { return jobSubmittalSystemSpecID; }
        }

        public JobSubmittalSystemSpec()
        {
        }
        public JobSubmittalSystemSpec(string jobSubmittalSystemSpecID,
                       string jobSubmittalSystemSpecSection,
                       string jobSubmittalSystemSpecDescription)
        {
            this.jobSubmittalSystemSpecID = jobSubmittalSystemSpecID;
            this.jobSubmittalSystemSpecSection = "'" + jobSubmittalSystemSpecSection.Trim().Replace("'", "''") + "'";
            this.jobSubmittalSystemSpecDescription = "'" + jobSubmittalSystemSpecDescription.Trim().Replace("'", "''") + "'";
        }
        //
        public static DataSet GetJobSubmittalSystemSpec()
        {
            string query = "";

            query = " SELECT * FROM tblJobSubmittalSystemSpec ";
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
            if (jobSubmittalSystemSpecID == "" || jobSubmittalSystemSpecID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSubmittalSystemSpec(" +
                    " JobSubmittalSystemSpecSection, " +
                    " JobSubmittalSystemSpecDescription) VALUES (" +
                    jobSubmittalSystemSpecSection + ", " +
                    jobSubmittalSystemSpecDescription + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobSubmittalSystemSpecID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobSubmittalSystemSpec SET " +
                    " JobSubmittalSystemSpecSection       = " + jobSubmittalSystemSpecSection + ", " +
                    " JobSubmittalSystemSpecDescription   = " + jobSubmittalSystemSpecDescription + " " +
                    " WHERE JobSubmittalSystemSpecID      = " + jobSubmittalSystemSpecID;
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
        public static void Delete(string jobSubmittalSystemSpecID)
        {
            string query = "";

            query = "DELETE FROM tblJobSubmittalSystemSpec WHERE JobSubmittalSystemSpecID = " + jobSubmittalSystemSpecID + " ";
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
