using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMDocument
    {
        private string cmDocumentID;
        private string cmContactID;
        private string cmDocumentPath;
        private string cmDocumentCreateDate;
        private string cmDocumentCreateBy;
        private string cmDocumentEditDate;
        private string cmDocumentEditBy;
        //
        public string CMDocumentID
        {
            get { return cmDocumentID; }
        }
        //
        public CMDocument()
        {
        }
        //
        public CMDocument(string cmDocumentID,
                            string cmContactID,
                            string cmDocumentPath,
                            string cmDocumentCreateDate,
                            string cmDocumentCreateBy,
                            string cmDocumentEditDate,
                            string cmDocumentEditBy)
        {
            this.cmDocumentID           = String.IsNullOrEmpty(cmDocumentID) ? "" : cmDocumentID;
            this.cmContactID            = String.IsNullOrEmpty(cmContactID) ? "null" : cmContactID;
            this.cmDocumentPath         = cmDocumentPath.Trim().Replace("'", "''");
            this.cmDocumentCreateDate   = String.IsNullOrEmpty(cmDocumentCreateDate) ? "null" : "'" + cmDocumentCreateDate + "' ";
            this.cmDocumentCreateBy     = cmDocumentCreateBy.Replace("'", "''");
            this.cmDocumentEditDate     = String.IsNullOrEmpty(cmDocumentEditDate) ? "null" : "'" + cmDocumentEditDate + "' ";
            this.cmDocumentEditBy       = cmDocumentEditBy.Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmDocumentID == "" || cmDocumentID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMDocument( " +
                   " CMContactID, " +
                   " CMDocumentPath, " +
                   " CMDocumentCreateDate, " +
                   " CMDocumentCreateBy, " +
                   " CMDocumentEditDate, " +
                   " CMDocumentEditBy) Values(" +
                   cmContactID + ", " +
                   "'" + cmDocumentPath + "', " +
                   cmDocumentCreateDate + ", " +
                   "'" + cmDocumentCreateBy + "', " +
                   cmDocumentEditDate + ", " +
                   "'" + cmDocumentEditBy + "') " +
                    "Select @@IDENTITY ";
            try
            {
                cmDocumentID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMDocument SET " +
                    " CMContactID           =  " + cmContactID + ", " +
                    " CMDocumentPath        = '" + cmDocumentPath + "', " +
                    " CMDocumentCreateDate  =  " + cmDocumentCreateDate + ", " +
                    " CMDocumentCreateBy    = '" + cmDocumentCreateBy + "', " +
                    " CMDocumentEditDate    =  " + cmDocumentEditDate + ", " +
                    " CMDocumentEditBy      = '" + cmDocumentEditBy + "'  " +          
                    " WHERE CMDocumentID    =  " + cmDocumentID;

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
        public static void Delete(string cmDocumentID)
        {
            string query = "Delete FROM tblCMDocument WHERE CMDocumentID = " + cmDocumentID;
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
        public static DataSet GetCMDocumentList()
        {
            string query = "";

            query = " SELECT CMDocumentID, " +
                    " CMContactID, " +
                    " CMDocumentPath        AS [Path], " +
                    " CMDocumentCreateDate  AS [Create Date], " +
                    " CMDocumentCreateBy    AS [Create By], " +
                    " CMDocumentEditDate    AS [Edit Date], " +
                    " CMDocumentEditBy      AS [Edit By], " +   
                    " FROM  tblCMDocument  " +
                    " ORDER BY CMDocumentPath ";
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
