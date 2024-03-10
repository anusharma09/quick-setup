using ContraCostaElectric.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class Classification
    {
        private readonly string classification;
        private readonly string classificationDate;
        private string classificationID;
        public string ClassificationID { get { return classificationID; } }
        public string employeeID { get; }

        public Classification ( string classification, string classificationDate,string classificationID, string employeeID )
        {
            this.classificationID = classificationID;
            this.employeeID = employeeID;
            this.classification = "'" + classification.Trim().Replace("'", "''") + "'";
            this.classificationDate = String.IsNullOrEmpty(classificationDate) ? "Null" : "'" + classificationDate + "'";
        }

        public bool Save ()
        {
            if (classificationID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert ()
        {
            string query = "";

            query = "INSERT INTO tblEmployeeClassification(Classification, ClassificationDate, EmployeeID, IsCurrentClassification) Values(" +
                    classification + ", " + classificationDate + ", " + employeeID + ", 0)" +
                    "Select @@IDENTITY ";
            try
            {
                classificationID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

                query = " DELETE FROM tblEmployeeClassification WHERE ClassificationID = " + Convert.ToInt32(Id) + " ";
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

            query = "Update tblEmployeeClassification     SET " +
                    " Classification                 = " + classification + ", " +
                    " ClassificationDate                  = " + classificationDate + " " +
                    " WHERE ClassificationID  = " + ClassificationID;
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
