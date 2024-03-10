using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMActivityType
    {
        private string cmActivityTypeID;
        private string cmActivityTypeDescription;
        //
        public string CMActivityTypeID
        {
            get { return cmActivityTypeID; }
        }
        //
        public CMActivityType()
        {
        }
        //
        public CMActivityType(string cmActivityTypeID,
                            string cmActivityTypeDescription)
        {
            this.cmActivityTypeID           = String.IsNullOrEmpty(cmActivityTypeID) ? "" : cmActivityTypeID;
            this.cmActivityTypeDescription  = cmActivityTypeDescription.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmActivityTypeID == "" || cmActivityTypeID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMActivityType(CMActivityTypeDescription) Values(" +
                    "  '" + cmActivityTypeDescription + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmActivityTypeID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMActivityType SET " +
                    " CMActivityTypeDescription         = '" + cmActivityTypeDescription + "' " +
                    " WHERE CMActivityTypeID            = " + cmActivityTypeID;

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
        public static void Delete(string cmActivityTypeID)
        {
            string query = "Delete FROM tblCMActivityType WHERE CMActivityTypeID = " + cmActivityTypeID;
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
        public static DataSet GetCMActivityTypeList()
        {
            string query = "";

            query = " SELECT CMActivityTypeID, " +
                    " CMActivityTypeDescription AS [Activity Type] " +
                    " FROM  tblCMActivityType  " +
                    " ORDER BY CMActivityTypeDescription ";
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
        public static DataSet GetCMActivityTypeDetail(string cmActivityTypeID)
        {
            string query = "";

            query = " SELECT CMActivityTypeID, " +
                    " CMActivityTypeDescription AS [Activity Type] " +
                    " FROM  tblCMActivityType  " +
                    " WHERE CMActivityTypeID = " + cmActivityTypeID + " ";
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
