using System;
using ContraCostaElectric.DatabaseUtil;
using System.Data;

namespace JCCBusinessLayer
{
    public class EmployeeSafetyNotes
    {
        private readonly string injuryType;
        private readonly string injuryDate;
        private readonly string doctorNotes;
        private readonly string comments;
        public string employeeID { get; }

        private string safetyId;
        public string SafetyNoteID { get { return safetyId; } }

        public EmployeeSafetyNotes ( string injuryType, string injuryDate, string doctorNotes, string comments, string employeeID, string safetyId )
        {
            this.injuryType = "'" + injuryType.Trim().Replace("'", "''") + "'";
            this.doctorNotes = "'" + doctorNotes.Trim().Replace("'", "''") + "'";
            this.injuryDate = String.IsNullOrEmpty(injuryDate) ? "Null" : "'" + injuryDate + "'";
            this.comments = "'" + comments.Trim().Replace("'", "''") + "'";
            this.employeeID = employeeID;
            this.safetyId = safetyId;
        }

        public bool Save ()
        {
            if (safetyId == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert ()
        {
            string query = "";
            query = "INSERT INTO tblEmployeeSafetyNotes(InjuryType, InjuryDate,DoctorNotes, Comments,EmployeeID) Values(" +
                    injuryType + ", " + injuryDate + ", " + doctorNotes + "," + comments + "," + employeeID + ")" +
                    "Select @@IDENTITY ";
            try
            {
                safetyId = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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
                query = " DELETE FROM tblEmployeeSafetyNotesAttachments WHERE SafetyNoteID = " + Convert.ToInt32(Id) + " ";
                query += " DELETE FROM tblEmployeeSafetyNotes WHERE SafetyNoteID = " + Convert.ToInt32(Id) + " ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteAttachments ( string Id )
        {
            try
            {
                string query = "";

                query = " DELETE FROM tblEmployeeSafetyNotesAttachments WHERE SafetyNoteID = " + Convert.ToInt32(Id) + " ";
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
            query = " Update tblEmployeeSafetyNotes     SET " +
                    " InjuryType                 = " + injuryType + ", " +
                    " InjuryDate                 = " + injuryDate + ", " +
                    " DoctorNotes            = " + doctorNotes + ", " +
                    " Comments                 = " + comments + " " +
                    " WHERE SafetyNoteID  = " + safetyId;
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
