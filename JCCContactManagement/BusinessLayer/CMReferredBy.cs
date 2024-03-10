using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMReferredBy
    {
        private string cmReferredByID;
        private string cmReferredByDescription;
        //
        public string CMReferredByID
        {
            get { return cmReferredByID; }
        }
        //
        public CMReferredBy()
        {
        }
        //
        public CMReferredBy(string cmReferredByID,
                            string cmReferredByDescription)
        {
            this.cmReferredByID = String.IsNullOrEmpty(cmReferredByID) ? "" : cmReferredByID;
            this.cmReferredByDescription = cmReferredByDescription.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmReferredByID == "" || cmReferredByID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMReferredBy(CMReferredByDescription) Values(" +
                    "  '" + cmReferredByDescription + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmReferredByID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMReferredBy SET " +
                    " CMReferredByDescription         = '" + cmReferredByDescription + "' " +
                    " WHERE CMReferredByID            = " + cmReferredByID;

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
        public static void Delete(string cmReferredByID)
        {
            string query = "Delete FROM tblCMReferredBy WHERE CMReferredByID = " + cmReferredByID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetCMReferredByList()
        {
            string query = "";

            query = " SELECT CMReferredByID, " +
                    " CMReferredByDescription AS [Referred By] " +
                    " FROM  tblCMReferredBy  " +
                    " ORDER BY CMReferredByDescription ";
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
        public static DataSet GetCMReferredByDetail(string cmReferredByID)
        {
            string query = "";

            query = " SELECT CMReferredByID, " +
                    " CMReferredByDescription AS [Referred By] " +
                    " FROM  tblCMReferredBy  " +
                    " WHERE CMReferredByID = " + cmReferredByID + " ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
