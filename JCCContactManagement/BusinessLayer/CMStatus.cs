using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMStatus
    {
        private string cmStatusID;
        private string cmStatusDescription;
        //
        public string CMStatusID
        {
            get { return cmStatusID; }
        }
        //
        public CMStatus()
        {
        }
        //
        public CMStatus(string cmStatusID,
                            string cmStatusDescription)
        {
            this.cmStatusID = String.IsNullOrEmpty(cmStatusID) ? "" : cmStatusID;
            this.cmStatusDescription = cmStatusDescription.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmStatusID == "" || cmStatusID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMStatus(CMStatusDescription) Values(" +
                    "  '" + cmStatusDescription + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmStatusID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMStatus SET " +
                    " CMStatusDescription         = '" + cmStatusDescription + "' " +
                    " WHERE CMStatusID            = " + cmStatusID;

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
        public static void Delete(string cmStatusID)
        {
            string query = "Delete FROM tblCMStatus WHERE CMStatusID = " + cmStatusID;
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
        public static DataSet GetCMStatusList()
        {
            string query = "";

            query = " SELECT CMStatusID, " +
                    " CMStatusDescription AS [Status] " +
                    " FROM  tblCMStatus  " +
                    " ORDER BY CMStatusDescription ";
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
        public static DataSet GetCMStatusDetail(string cmStatusID)
        {
            string query = "";

            query = " SELECT CMStatusID, " +
                    " CMStatusDescription AS [Status] " +
                    " FROM  tblCMStatus  " +
                    " WHERE CMStatusID =  " + cmStatusID + " ";
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
