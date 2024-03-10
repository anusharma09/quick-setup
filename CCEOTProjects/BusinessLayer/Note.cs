using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace CCEOTProjects.BusinessLayer
{
    class Note
    {
        private string otNoteID;
        private string otProjectID;
        private string note;
        private string userLANID;
        private string noteDate;

        public string NoteID
        {
            get { return otNoteID; }
        }
        //
        public Note()
        {
        }
        //
        public Note(string otNoteID,
                    string otProjectID,
                    string note,
                    string userLANID,
                    string noteDate)
        {
            this.otNoteID           = otNoteID;
            this.otProjectID        = otProjectID;
            this.note               = note.Trim().ToUpper().Replace("'", "''");
            this.userLANID          = userLANID;
            this.noteDate           = noteDate;
        }
        //
        public static DataSet GetNotes(string otProjectID)
        {
            string query = "";

            query = " SELECT OTNoteID, OTProjectID, Note, UserName AS [Created By], NoteDate AS [Date] " +
                    " FROM tblOTNote n " +
                    " LEFT JOIN tblUser u ON n.UserLANID = u.UserLANID " +
                    " WHERE OTProjectID = " + otProjectID + " ";
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
            if (otNoteID == "")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblOTNote(OTProjectID, Note, UserLANID, NoteDate) Values(" +
                    otProjectID + ", '" + note + "', '" + userLANID + "', '" + noteDate + "')" +
                    "Select @@IDENTITY ";
            try
            {
                otNoteID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static bool Delete(string otNoteID)
        {
            try
            {
                string query = "";

                query = " DELETE FROM tblOTNote WHERE OTNoteID = " + otNoteID + " ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
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

            query = "Update tblOTNote       SET " +
                    " OTProjectID               = " + otProjectID + ", " +
                    " Note                      = '" + note + "', " +
                    " UserLANID                 = '" + userLANID + "', " +
                    " NoteDate                  = '" + noteDate + "' " +
                    " WHERE OTNoteID  = " + otNoteID;
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
