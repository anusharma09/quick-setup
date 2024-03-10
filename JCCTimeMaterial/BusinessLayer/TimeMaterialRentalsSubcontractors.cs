using ContraCostaElectric.DatabaseUtil;
using System;
using System.Data;

namespace JCCTimeMaterial.BusinessLayer
{
    class TimeMaterialRentalsSubcontractors
    {

        private string jobTimeMaterialRentalsSubcontratorsId;
        private string jobTimeMaterialWorkOrderID;
 
        private string description;
        private string date;
        public TimeMaterialRentalsSubcontractors(string jobTimeMaterialrentalsSubconractorsID,
                                     string jobTimeMaterialWorkOrderID, string description ,                            
                                    string date)
        {
            this.jobTimeMaterialRentalsSubcontratorsId = jobTimeMaterialrentalsSubconractorsID;
            this.jobTimeMaterialWorkOrderID = jobTimeMaterialWorkOrderID;
            this.description = "'" + description.Trim().Replace("'", "''") + "'";        
            this.date = String.IsNullOrEmpty(date) ? "null" : "'" + date + "'";
        }
        //
        public string JobTimeMaterialRentalsSubcontratorsId
        {
            get { return jobTimeMaterialRentalsSubcontratorsId; }
        }

        public static DataSet GetJobTimeMaterialRentalsSubcontractors(string jobTimeMaterialWorkOrderID)
        {
            if (jobTimeMaterialWorkOrderID == "")
                jobTimeMaterialWorkOrderID = "0";

            string query = " SELECT * " +
                          " FROM tblJobTimeMaterialRentalsSubcontrators  " +
                          " WHERE JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save()
        {
            if (jobTimeMaterialRentalsSubcontratorsId == "" || jobTimeMaterialRentalsSubcontratorsId == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobTimeMaterialRentalsSubcontrators (" +
                    " JobTimeMaterialWorkOrderID, " +
                    " Description, " +
                    " Date " +
                    " ) VALUES ( " +
                    jobTimeMaterialWorkOrderID + ", " +
                    description + ", " +
                    date + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobTimeMaterialRentalsSubcontratorsId = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobTimeMaterialRentalsSubcontrators SET " +
                    " JobTimeMaterialWorkOrderID            = " + jobTimeMaterialWorkOrderID + ", " +
                    " Description                      = " + description + ", " +
                    " Date                   = " + date + " " +
                    " WHERE JobTimeMaterialRentalsSubcontratorsID = " + jobTimeMaterialRentalsSubcontratorsId;
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
        public static bool Remove(string jobTimeMaterialRentalsSubcontratorsId)
        {
            string query = "";

            try
            {
                query = "DELETE FROM tblJobTimeMaterialRentalsSubcontrators WHERE JobTimeMaterialRentalsSubcontratorsID = " + jobTimeMaterialRentalsSubcontratorsId;
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
