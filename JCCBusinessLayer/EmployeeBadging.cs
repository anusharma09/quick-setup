using System;
using ContraCostaElectric.DatabaseUtil;
using System.Data;

namespace JCCBusinessLayer
{
   public class EmployeeBadging
    {
        private readonly string notes;
        private readonly string attachmentName;
        private readonly string issueDate;
        private readonly string attachmentPath;
        private readonly string expdate;
        private readonly string badgeType;
        public string employeeID { get; }

        private string badgeId;
        public string BadgeID { get { return badgeId; } }

        public EmployeeBadging ( string notes, string attachmentName, string issueDate, string attachmentPath, string employeeID, string badgeID, string expdate, string badgeType )
        {
            this.notes = "'" + notes.Trim().Replace("'", "''") + "'";
            this.attachmentName = "'" + attachmentName.Trim().Replace("'", "''") + "'";
            this.issueDate = String.IsNullOrEmpty(issueDate) ? "Null" : "'" + issueDate + "'";
            this.expdate = String.IsNullOrEmpty(expdate) ? "Null" : "'" + expdate + "'";
            this.attachmentPath = "'" + attachmentPath.Trim().Replace("'", "''") + "'";
            this.badgeType = "'" + badgeType.Trim().Replace("'", "''") + "'";
            this.employeeID = employeeID;
            this.badgeId = badgeID;
        }

        public bool Save ()
        {
            if (badgeId == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert ()
        {
            string query = "";
            query = "INSERT INTO tblEmployeeBadging(BadgeType, IssueDate,ExpirationDate, AttachmentName,AttachmentPath,Notes,EmployeeID) Values(" +
                    badgeType + ", " + issueDate + ", " + expdate + "," + attachmentName + "," + attachmentPath + "," + notes + "," + employeeID + ")" +
                    "Select @@IDENTITY ";
            try
            {
                badgeId = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

                query = " DELETE FROM tblEmployeeBadging WHERE BadgeID = " + Convert.ToInt32(Id) + " ";
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
            query = " Update tblEmployeeBadging     SET " +
                    " BadgeType                 = " + badgeType + ", " +
                    " IssueDate                 = " + issueDate + ", " +
                    " ExpirationDate            = " + expdate + ", " +        
                    " AttachmentName                 = " + attachmentName + ", " +
                    " AttachmentPath                  = " + attachmentPath + ", " +
                    " Notes                  = " + notes + " " +
                    " WHERE BadgeID  = " + BadgeID;
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
