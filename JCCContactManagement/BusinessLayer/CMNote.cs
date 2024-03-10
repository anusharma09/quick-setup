using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMNote
    {
        private string cmNoteID;
        private string cmContactID;
        private string cmNoteDate;
        private string cmNoteTime;
        private string cmNoteDetail;
        private string cmNoteAttachmentPath;
        private string cmNoteCreateDate;
        private string cmNoteCreateBy;
        private string cmNoteEditDate;
        private string cmNoteEditBy;
        //
        public string CMNoteID
        {
            get { return cmNoteID; }
        }
        //
        public CMNote()
        {
        }
        //
        public CMNote(string cmNoteID,
                            string cmContactID,
                            string cmNotedate,
                            string cmNoteTime,
                            string cmNoteDetail,
                            string cmNoteAttachmentPath,
                            string cmNoteCreateDate,
                            string cmNoteCreateBy,
                            string cmNoteEditDate,
                            string cmNoteEditBy)
        {
            this.cmNoteID               = String.IsNullOrEmpty(cmNoteID) ? "" : cmNoteID;
            this.cmContactID            = String.IsNullOrEmpty(cmContactID) ? "null" : cmContactID;
            this.cmNoteDate             = String.IsNullOrEmpty(cmNoteDate) ? "null" : cmNoteDate;
            this.cmNoteTime             = cmNoteTime.Trim().Replace("'", "''");
            this.cmNoteDetail           = cmNoteDetail.Trim().Replace("'", "''");
            this.cmNoteAttachmentPath   = cmNoteAttachmentPath.Trim().Replace("'", "''");
            this.cmNoteCreateDate       = String.IsNullOrEmpty(cmNoteCreateDate) ? "null" : "'" + cmNoteCreateDate + "' ";
            this.cmNoteCreateBy         = cmNoteCreateBy.Replace("'", "''");
            this.cmNoteEditDate         = String.IsNullOrEmpty(cmNoteEditDate) ? "null" : "'" + cmNoteEditDate + "' ";
            this.cmNoteEditBy           = cmNoteEditBy.Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmNoteID == "" || cmNoteID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMNote( " +
                   " CMContactID, " +
                   " CMNoteDate, " +
                   " CMNoteTime, " +
                   " CMNoteDetail, " +
                   " CMNoteAttachmentPath, " +
                   " CMNoteCreateDate, " +
                   " CMNoteCreateBy, " +
                   " CMNoteEditDate, " +
                   " CMNoteEditBy) Values(" +
                   cmContactID + ", " +
                   cmNoteDate + ", " +
                   "'" + cmNoteTime + "', " +
                   "'" + cmNoteDetail + "', " +
                   "'" + cmNoteAttachmentPath + "', " +
                   cmNoteCreateDate + ", " +
                  "'" + cmNoteCreateBy + "', " +
                   cmNoteEditDate + ", " +
                   "'" + cmNoteEditBy + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmNoteID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMNote SET " +
                    " CMContactID           =  " + cmContactID + ", " +
                    " CMNoteDate            =  " + cmNoteDate + ", " +
                    " CMNoteTime            = '" + cmNoteTime + "', " +
                    " CMNoteDetail          = '" + cmNoteDetail + "', " +
                    " CMNoteAttachmentPath  = '" + cmNoteAttachmentPath + "', " +
                    " CMNoteCreateDate      =  " + cmNoteCreateDate + ", " +
                    " CMNoteCreateBy        = '" + cmNoteCreateBy + "', " +
                    " CMNoteEditDate        =  " + cmNoteEditDate + ", " +
                    " CMNoteEditBy          = '" + cmNoteEditBy + "'  " +
                    " WHERE CMNoteID        =  " + cmNoteID;

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
        public static void Delete(string cmNoteID)
        {
            string query = "Delete FROM tblCMNote WHERE CMNoteID = " + cmNoteID;
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
        public static DataSet GetCMNoteList()
        {
            string query = "";

            query = " SELECT CMNoteID, " +
                    " CMContactID, " +
                    " CMNoteDate            AS [Note Date], " +
                    " CMNoteTime            AS [Note Time], " +
                    " CMNoteDetail          AS [Note Detail], " +
                    " CMNoteAttachmentPath  AS [Attachment Path], " +
                    " CMNoteCreateDate      AS [Create Date], " +
                    " CMNoteCreateBy        AS [Create By], " +
                    " CMNoteEditDate        AS [Edit Date], " +
                    " CMNoteEditBy          AS [Edit By], " +
                    " FROM  tblCMNote  " +
                    " ORDER BY CMNoteAttachmentPath ";
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
