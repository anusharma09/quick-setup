using System;
using System.Collections.Generic;
using System.Text;
using ContraCostaElectric.DatabaseUtil;
using System.Data;

namespace JCCTimeMaterial.BusinessLayer
{
    class TimeMaterialWorkOrderHour
    {
        private string jobTimeMaterialWorkOrderHourID;
        private string jobTimeMaterialWorkOrderID;
        private string employee;
        private string hours;
        private string craftID;
        private string rate;
        private string date;
        //
        public TimeMaterialWorkOrderHour()
        {
        }
        //
        public TimeMaterialWorkOrderHour(string jobTimeMaterialWorkOrderHourID,
                                     string jobTimeMaterialWorkOrderID,
                                     string employee,
                                     string hours,
                                     string craftID,
                                     string rate,
                                     string date)
        {
            this.jobTimeMaterialWorkOrderHourID     = jobTimeMaterialWorkOrderHourID;
            this.jobTimeMaterialWorkOrderID         = jobTimeMaterialWorkOrderID;
            this.employee                           = "'" + employee.Trim().Replace("'", "''") + "'";
            this.hours                              = String.IsNullOrEmpty(hours) ? "Null" : hours.Replace("(", "-").Replace(")", "").Replace(",", "");
            this.craftID                            = String.IsNullOrEmpty(craftID) ? "Null" : craftID;
            this.rate                               = "'" + rate.Trim().Replace("'", "''") + "'";
            this.date                               = String.IsNullOrEmpty(date) ? "null" : "'" + date + "'";
        }
        //
        public string JobTimeMaterialWorkOrderHourID
        {
            get { return jobTimeMaterialWorkOrderHourID; }
        }
        //
        //
        public static DataSet GetJobTimeMaterialWorkOrderCraft()
        {
            string query = " SELECT * " +
                          " FROM tblJobTimeMaterialWorkOrderCraft ORDER BY CraftDescription  ";

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
        public static DataSet GetJobTimeMaterialWorkOrderHour(string jobTimeMaterialWorkOrderID)
        {
            if (jobTimeMaterialWorkOrderID == "")
                jobTimeMaterialWorkOrderID = "0";

            string query = " SELECT * " +
                          " FROM tblJobTimeMaterialWorkOrderHour  " +
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
        //
        public static DataSet GetJobTimeMaterialWorkOrderHourForm(string jobTimeMaterialWorkOrderID)
        {
            if (jobTimeMaterialWorkOrderID == "")
                jobTimeMaterialWorkOrderID = "0";

            string query = "SELECT  " +
                           "  [Date], Employee, " +
                           " HoursS = " +
                           "     Case [Rate] " +
                           "     WHEN 'S' THEN Hours " +
                           "     ELSE null " +
                           " END, " +
                           " HoursO = " +
                           "     Case [Rate] " +
                           "     WHEN 'O' THEN Hours " +
                           "     ELSE null " +
                           " END, " +
                           " HoursD = " +
                           "     Case [Rate] " +
                           "     WHEN 'D' THEN Hours " +
                           "     ELSE null " +
                           " END, " +
                           " HoursP = " +
                           "     Case [Rate] " +
                           "     WHEN 'P' THEN Hours " +
                           "     ELSE null " +
                           " END, " +
                           " Hours " +
                          " FROM tblJobTimeMaterialWorkOrderHour  " +
                          " WHERE JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID + " " +
                          " ORDER BY Date, Employee ";

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
        public static bool Remove(string jobTimeMaterialWorkOrderHourID)
        {
            string query = "";

            try
            {
                query = "DELETE FROM tblJobTimeMaterialWorkOrderHour WHERE JobTimeMaterialWorkOrderHourID = " + jobTimeMaterialWorkOrderHourID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            if (jobTimeMaterialWorkOrderHourID == "" || jobTimeMaterialWorkOrderHourID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobTimeMaterialWorkOrderHour(" +
                    " JobTimeMaterialWorkOrderID, " +
                    " Employee, " +
                    " Hours, " +
                    " CraftID, " +
                    " Rate, " +
                    " Date " +
                    " ) VALUES ( " +
                    jobTimeMaterialWorkOrderID + ", " +
                    employee + ", " +
                    hours + ", " +
                    craftID + ", " +
                    rate + ", " +
                    date + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobTimeMaterialWorkOrderHourID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobTimeMaterialWorkOrderHour SET " +
                    " JobTimeMaterialWorkOrderID            = " + jobTimeMaterialWorkOrderID + ", " +
                    " Employee                              = " + employee + ", " +
                    " Hours                                 = " + hours + ", " +
                    " CraftID                               = " + craftID + ", " +
                    " Rate                                  = " + rate + ", " +
                    " Date                                  = " + date + " " +
                    " WHERE JobTimeMaterialWorkOrderHourID = " + jobTimeMaterialWorkOrderHourID;
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
