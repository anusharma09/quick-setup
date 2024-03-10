using System;
using ContraCostaElectric.DatabaseUtil;
using System.Data;
using System.Data.SqlClient;


namespace JCCBusinessLayer
{
   public class EmployeeEvaluation
    {
        private readonly string notes;
        private readonly string attachmentName;
        private readonly string date;
        private readonly string attachmentPath;
        private readonly string comments;
        public string employeeID { get; }

        private string evaluationID;
        public string EvaluationID { get { return evaluationID; } }

        public EmployeeEvaluation ( string notes , string attachmentName , string Date,  string attachmentPath, string employeeID, string evaluationID, string comments)
        {
            this.notes = "'" + notes.Trim().Replace("'", "''") + "'"; 
            this.attachmentName = "'" + attachmentName.Trim().Replace("'", "''") + "'"; 
            this.date = String.IsNullOrEmpty(Date) ? "Null" : "'" + Date + "'"; 
            this.attachmentPath = "'" + attachmentPath.Trim().Replace("'", "''") + "'";
            this.comments = "'" + comments.Trim().Replace("'", "''") + "'";
            this.employeeID = employeeID;
            this.evaluationID = evaluationID;
        }

        public bool Save ()
        {
            if (evaluationID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert ()
        {
            string query = "";
            query = "INSERT INTO tblEmployeeEvaluation(Classification, EvaluationDate, AttachmentName,AttachmentPath,Comments,EmployeeID) Values(" +
                    notes + ", " + date + "," + attachmentName + "," + attachmentPath + ","+ comments+"," + employeeID + ")" +
                    "Select @@IDENTITY ";
            try
            {
                evaluationID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

                query = " DELETE FROM tblEmployeeEvaluation WHERE EvaluationID = " + Convert.ToInt32(Id) + " ";
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
            query = " Update tblEmployeeEvaluation     SET " +
                    " Classification                 = " + notes + ", " +
                    " EvaluationDate                 = " + date + ", " +
                    " AttachmentName                 = " + attachmentName + ", " +
                    " AttachmentPath                  = " + attachmentPath + ", " +
                    " Comments                  = " + comments + " " +
                    " WHERE EvaluationID  = " + EvaluationID;
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
