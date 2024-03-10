using ContraCostaElectric.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;

namespace JCCBusinessLayer
{
   public class SafetyNoteAttachment
    {
        private readonly string attachmentName;
        private readonly string attachmentPath;
        public string safetyId { get; }
        private string attachmentId;
        public string AttachmentID { get { return attachmentId; } }

        public SafetyNoteAttachment(string attachmentName, string attachmentPath, string safetyNoteID, string attachmentId)
        {
            this.attachmentName = "'" + attachmentName.Trim().Replace("'", "''") + "'";
            this.attachmentPath = "'" + attachmentPath.Trim().Replace("'", "''") + "'";
            this.safetyId = safetyNoteID;
            this.attachmentId = attachmentId;
        }

        public bool Save ()
        {
            if (attachmentId == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert ()
        {
            string query = "";
            query = "INSERT INTO tblEmployeeSafetyNotesAttachments(AttachmentName, AttachmentPath,SafetyNoteID) Values(" +
                    attachmentName + ", " + attachmentPath + ", " + safetyId + ")" +
                    "Select @@IDENTITY ";
            try
            {
                attachmentId = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Delete ( string Id )
        {
            try
            {
                string query = "";

                query = " DELETE FROM tblEmployeeSafetyNotesAttachments WHERE AttchmentID = " + Convert.ToInt32(Id) + " ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Update ()
        {
            string query = "";
            query = " Update tblEmployeeSafetyNotesAttachments     SET " +
                    " AttachmentName                 = " + attachmentName + ", " +
                    " AttachmentPath                 = " + attachmentPath + " " +
                    " WHERE AttchmentID  = " + AttachmentID;
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
