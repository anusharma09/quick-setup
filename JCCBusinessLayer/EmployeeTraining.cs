using System;
using ContraCostaElectric.DatabaseUtil;
using System.Data;
using System.Data.SqlClient;


namespace JCCBusinessLayer
{
   public class EmployeeTraining
    {
        private readonly string trainingDesc;
        private readonly string attachmentName;
        private readonly string trainingDate;
        private readonly string expirationdate;
        private readonly string attachmentPath;
        private readonly string hours;
        public string employeeID { get; }

        private string trainingID;
        public string TrainingID { get { return trainingID; } }

        public EmployeeTraining( string trainingDesc , string attachmentName , string trainingDate, string expirationdate, string attachmentPath, string employeeID, string trainingID, string hours)
        {
            this.trainingDesc = "'" + trainingDesc.Trim().Replace("'", "''") + "'"; 
            this.attachmentName = "'" + attachmentName.Trim().Replace("'", "''") + "'"; 
            this.trainingDate = String.IsNullOrEmpty(trainingDate) ? "Null" : "'" + trainingDate + "'"; 
            this.expirationdate = String.IsNullOrEmpty(expirationdate) ? "Null" : "'" + expirationdate + "'"; 
            this.attachmentPath = "'" + attachmentPath.Trim().Replace("'", "''") + "'";
            this.hours = hours;
            this.employeeID = employeeID;
            this.trainingID = trainingID;
        }

        public bool Save ()
        {
            if (trainingID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert ()
        {
            string query = "";
            int hoursT = String.IsNullOrEmpty(hours.ToString()) ? 0 : Convert.ToInt32(hours);
            query = "INSERT INTO tblEmployeeTraining(TrainingDescription, TrainingDate, ExpirationDate, AttachmentName,AttachmentPath,EmployeeID,HoursOfTraining) Values(" +
                    trainingDesc + ", " + trainingDate + ", " + expirationdate + ", " + attachmentName + "," + attachmentPath + "," + employeeID + ","+ hoursT + ")" +
                    "Select @@IDENTITY ";
            try
            {
                trainingID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

                query = " DELETE FROM tblEmployeeTraining WHERE TrainingID = " + Convert.ToInt32(Id) + " ";
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
            int hoursT = String.IsNullOrEmpty(hours.ToString()) ? 0 : Convert.ToInt32(hours);
            query = " Update tblEmployeeTraining     SET " +
                    " TrainingDescription                 = " + trainingDesc + ", " +
                    " TrainingDate                 = " + trainingDate + ", " +
                    " ExpirationDate                 = " + expirationdate + ", " +
                    " AttachmentName                 = " + attachmentName + ", " +
                    " AttachmentPath                  = " + attachmentPath + ", " +
                    " HoursOfTraining                 = " + hoursT +
                    " WHERE TrainingID  = " + TrainingID;
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
