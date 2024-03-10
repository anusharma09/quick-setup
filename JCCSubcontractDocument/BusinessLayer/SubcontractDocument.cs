using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCSubcontractDocument.BusinessLayer
{
    public class SubcontractDocument
    {
        private string jobVendorSubcontractID;
        private string jobVendorSubcontract;

        public string JobVendorSubcontractID
        {
            get { return jobVendorSubcontractID; }
        }

        public SubcontractDocument()
        {
        }
        public SubcontractDocument(string jobVendorSubcontractID,
                    string jobVendorSubcontract)
        {
            this.jobVendorSubcontractID         = jobVendorSubcontractID;
            this.jobVendorSubcontract           = jobVendorSubcontract.Trim().ToUpper().Replace("'","''");
        }
        public static DataSet GetVendorSubcontracts()
        {
            string query = "";

            query = " SELECT JobVendorSubcontractID, JobVendorSubcontract AS [Subcontract] " +      
                    " FROM tblJobVendorSubcontract "; 

            try
            {
                return DataBaseUtil.ExecuteDataset(query, JCCSubcontractDocument.CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Save()
        {
            if (jobVendorSubcontractID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobVendorSubcontract(JobVendorSubcontract) Values('" +
                    jobVendorSubcontract + "') " +
                    "Select @@IDENTITY ";
            try
            {
                jobVendorSubcontractID = DataBaseUtil.ExecuteScalar(query, JCCSubcontractDocument.CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Delete(string jobVendorSubcontractID)
        {
            try
            {
                string query = "";
                
                query = " DELETE FROM tblJobVendorSubcontract WHERE JobVendorSubcontractID = " + jobVendorSubcontractID + " ";
                DataBaseUtil.ExecuteNonQuery(query, JCCSubcontractDocument.CCEApplication.Connection, CommandType.Text);
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

            query = "Update tblJobVendorSubcontract     SET " +
                    " JobVendorSubcontract      = '" + jobVendorSubcontract + "' " +
                    " WHERE JobVendorSubcontractID  = " + jobVendorSubcontractID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, JCCSubcontractDocument.CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
