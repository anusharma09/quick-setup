using ContraCostaElectric.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;  

namespace JCCBusinessLayer
{
   public class Termination
    {
        private readonly string     termination;
        private readonly string terminationDate;
        private string terminationID;
        public string TerminationID { get { return terminationID; } }
        public string employeeID { get; }

        public Termination ( string termination, string terminationDate, string terminationID, string employeeID )
        {
            this.terminationID = terminationID;
            this.employeeID = employeeID;
            this.termination = "'" + termination.Trim().Replace("'", "''") + "'";
            this.terminationDate = String.IsNullOrEmpty(terminationDate) ? "Null" : "'" + terminationDate + "'";
        }

        public bool Save ()
        {
            if (terminationID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert ()
        {
            string query = "";

            query = "INSERT INTO tblEmployeeTermination(Reason, TerminationDate, EmployeeID, IsCurrentTermination) Values(" +
                    termination + ", " + terminationDate + ", " + employeeID + ", 0)" +
                    "Select @@IDENTITY ";
            try
            {
                terminationID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

                query = " DELETE FROM tblEmployeeTermination WHERE TerminationID = " + Convert.ToInt32(Id) + " ";
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

            query = "Update tblEmployeeTermination     SET " +
                    " Reason                 = " + termination + ", " +
                    " TerminationDate                  = " + terminationDate + " " +
                    " WHERE TerminationID  = " + TerminationID;
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
