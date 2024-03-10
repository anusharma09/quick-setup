using System;
using System.Collections.Generic;
using System.Text;
using ContraCostaElectric.DatabaseUtil;
using System.Data;

namespace JCCTimeMaterial.BusinessLayer
{
    class TimeMaterialWorkOrder
    {
        private string jobTimeMaterialWorkOrderID;
        private string jobID;
        private string addressedToID;
        private string workRequestedBy;
        private string referenceNumber;
        private string workOrderTitle;
        private string workOrderDescription;
        private string customerTrackingNumber;
        private string technician;
        private string workComplete;
        //
        public TimeMaterialWorkOrder()
        {
        }
        //
        public TimeMaterialWorkOrder(string jobTimeMaterialWorkOrderID,
                                     string jobID,
                                     string addressedToID,
                                     string workRequestedBy,
                                     string referenceNumber,
                                     string workOrderTitle,
                                     string workOrderDescription,
                                     string customerTrackingNumber,
                                     string technician,
                                     bool workComplte) 
        {
            this.jobTimeMaterialWorkOrderID             = jobTimeMaterialWorkOrderID;
            this.jobID                                  = jobID;
            this.addressedToID                          = String.IsNullOrEmpty(addressedToID) ? "null" : addressedToID;
            this.workRequestedBy                        = "'" + workRequestedBy.Trim().Replace("'","''") + "'";
            this.referenceNumber                        = "'" + referenceNumber.Trim().Replace("'", "''") + "'";
            this.workOrderTitle                         = "'" + workOrderTitle.Trim().Replace("'", "''") + "'";
            this.workOrderDescription                   = "'" + workOrderDescription.Trim().Replace("'", "''") + "'";
            this.customerTrackingNumber                 = "'" + customerTrackingNumber.Trim().Replace("'", "''") + "'";
            this.technician                             = "'" + technician.Trim().Replace("'", "''") + "'";
            this.workComplete                           = workComplte ? "1":"0";
        }
        //
        public string JobTimeMaterialWorkOrderID
        {
            get { return jobTimeMaterialWorkOrderID; }
        }
        //
         public static DataSet GetTimeMaterialForm(string jobTimeMaterialWorkOrderID)
         {
             if (jobTimeMaterialWorkOrderID == "")
                 jobTimeMaterialWorkOrderID = "0";

             string query = "";

            
                query = "  SELECT " +
                     "  WorkOrderNumber = JobNumber + '-' + WorkOrderNumber, " +
                     "  ReferenceNumber, " +
                     "  JobName, " +
                     "  JobAddress1, " +
                     "  JobCityStateZip = ISNULL(JobCity, '') + ', ' + ISNULL(JobState, '') + ' ' + ISNULL(JobZip, ''), " +
                     "  WorkRequestedBy, " +
                     "  JobNumber, " +
                     "  Organization = " +
                     "      CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(c.CompanyName, '') " +
                     "      ELSE ISNULL(d.CompanyName, '') " +
                     "      END, " +
                     "   OfficeStreetAddress = " +
                     "      CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(c.OfficeStreetAddress, '') " +
                     "      ELSE ISNULL(d.OfficeStreetAddress, '') " +
                     "      END, " +
                     "  OfficeCityStateZip = " +
                     "  CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(c.OfficeCity, '') + ', ' + ISNULL(c.OfficeState, '') + ' ' + ISNULL(c.OfficeZip, '') " +
                     "      ELSE ISNULL(d.OfficeCity, '') + ', ' + ISNULL(d.OfficeState, '') + ' ' + ISNULL(d.OfficeZip, '') " +
                     "      END, " +
                     "   WorkOrderTitle, " +
                     "   WorkOrderDescription, " +
                     "   CustomerTrackingNumber, " +
                     "   Technician, " +
                     "   CASE WorkComplete WHEN 1 then 'YES' WHEN 0 then 'NO' ELSE 'NO' END As WorkComplete " +
                     " FROM tblJobTimeMaterialWorkOrder o " +
                     " LEFT JOIN tblJob j ON o.JobID = j.JobID " +
                     " LEFT JOIN  tblJobContact jc ON o.AddressedToID = jc.ContactID " +
                     " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                     " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                     " WHERE o.JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID + " ";
            
           
             try
             {
                 return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
        public static DataSet GetTimeMaterialForm(string jobTimeMaterialWorkOrderID,string jobID)
        {
            if (jobTimeMaterialWorkOrderID == "")
                jobTimeMaterialWorkOrderID = "0";

            string query = "";

            if (CheckIsJobNew(Convert.ToInt32(jobID)))
            {
                query = "  SELECT " +
                     "  WorkOrderNumber = JobNumber + '-' + WorkOrderNumber, " +
                     "  ReferenceNumber, " +
                     "  JobName, " +
                     "  JobAddress1, " +
                     "  JobCityStateZip = ISNULL(JobCity, '') + ', ' + ISNULL(JobState, '') + ' ' + ISNULL(JobZip, ''), " +
                     "  WorkRequestedBy, " +
                     "  JobNumber, " +
                     "  Organization = " +
                     "      CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(gc.CompanyName, '') " +
                     "      ELSE ISNULL(d.CompanyName, '') " +
                     "      END, " +
                     "   OfficeStreetAddress = " +
                     "      CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(gc.OfficeStreetAddress, '') " +
                     "      ELSE ISNULL(d.OfficeStreetAddress, '') " +
                     "      END, " +
                     "  OfficeCityStateZip = " +
                     "  CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(gc.OfficeCity, '') + ', ' + ISNULL(gc.OfficeState, '') + ' ' + ISNULL(gc.OfficeZip, '') " +
                     "      ELSE ISNULL(d.OfficeCity, '') + ', ' + ISNULL(d.OfficeState, '') + ' ' + ISNULL(d.OfficeZip, '') " +
                     "      END, " +
                     "   WorkOrderTitle, " +
                     "   WorkOrderDescription, " +
                     "   CustomerTrackingNumber, " +
                     "   Technician, " +
                     "   CASE WorkComplete WHEN 1 then 'YES' WHEN 0 then 'NO' ELSE 'NO' END As WorkComplete " +
                     " FROM tblJobTimeMaterialWorkOrder o " +
                     " LEFT JOIN tblJob j ON o.JobID = j.JobID " +
                     " LEFT JOIN  tblJobContact jc ON o.AddressedToID = jc.ContactID " +
                     "   LEFT JOIN tblGlobalContact gc ON jc.CompanyContactID = gc.GlobalContactID " +
                     " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                     " WHERE o.JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID + " ";
            }
            else
            {
                query = "  SELECT " +
                     "  WorkOrderNumber = JobNumber + '-' + WorkOrderNumber, " +
                     "  ReferenceNumber, " +
                     "  JobName, " +
                     "  JobAddress1, " +
                     "  JobCityStateZip = ISNULL(JobCity, '') + ', ' + ISNULL(JobState, '') + ' ' + ISNULL(JobZip, ''), " +
                     "  WorkRequestedBy, " +
                     "  JobNumber, " +
                     "  Organization = " +
                     "      CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(c.CompanyName, '') " +
                     "      ELSE ISNULL(d.CompanyName, '') " +
                     "      END, " +
                     "   OfficeStreetAddress = " +
                     "      CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(c.OfficeStreetAddress, '') " +
                     "      ELSE ISNULL(d.OfficeStreetAddress, '') " +
                     "      END, " +
                     "  OfficeCityStateZip = " +
                     "  CASE LotusNotes " +
                     "      WHEN 1 THEN ISNULL(c.OfficeCity, '') + ', ' + ISNULL(c.OfficeState, '') + ' ' + ISNULL(c.OfficeZip, '') " +
                     "      ELSE ISNULL(d.OfficeCity, '') + ', ' + ISNULL(d.OfficeState, '') + ' ' + ISNULL(d.OfficeZip, '') " +
                     "      END, " +
                     "   WorkOrderTitle, " +
                     "   WorkOrderDescription, " +
                     "   CustomerTrackingNumber, " +
                     "   Technician, " +
                     "   CASE WorkComplete WHEN 1 then 'YES' WHEN 0 then 'NO' ELSE 'NO' END As WorkComplete " +
                     " FROM tblJobTimeMaterialWorkOrder o " +
                     " LEFT JOIN tblJob j ON o.JobID = j.JobID " +
                     " LEFT JOIN  tblJobContact jc ON o.AddressedToID = jc.ContactID " +
                     " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                     " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                     " WHERE o.JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID + " ";
            }

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
        public static DataSet GetTimeMaterialWorkOrder(string jobTimeMaterialWorkOrderID)
          {
              if (jobTimeMaterialWorkOrderID == "")
                  jobTimeMaterialWorkOrderID = "0";

              string query = "SELECT * FROM tblJobTimeMaterialWorkOrder WHERE " +
                            " JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID + " ";
               
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
        public static string GetWorkOrderNumber(string jobTimeMaterialWorkOrderID)
        {
            if (jobTimeMaterialWorkOrderID == "")
                jobTimeMaterialWorkOrderID = "0";
            string workOrderNumber = "";
            string query = "SELECT WorkOrderNumber " +
                " FROM tblJobTimeMaterialWorkOrder " +
                " WHERE JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID + " ";

            try
            {
                DataTable t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    workOrderNumber = t.Rows[0]["WorkOrderNumber"].ToString();
                return workOrderNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //

        public static bool CheckIsJobNew(int jobId)
        {
            string query = "";
            bool isNew = false;
            query = "SELECT IsNewJob FROM tblJob WHERE JobID = " + jobId;
            try
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IsNewJob"].ToString()))
                        isNew = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsNewJob"]);
                    else
                        isNew = false;
                }
                return isNew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetJobTimeMaterialWorkOrderLog(string jobID)
        {
            if (jobID == "")
                jobID = "0";


            string query = string.Empty;

            if (CheckIsJobNew(Convert.ToInt32(jobID)))
            {
                query = " SELECT " +
                             "   JobTimeMaterialWorkOrderID, " +
                             "   o.JobID, " +
                             "   WorkOrderNumber AS [Order No], " +
                             "   WorkOrderTitle [Work Order Title], " +
                             "   WorkRequestedBy AS [Requested By], " +
                             "   Organization =  " +
                             "       CASE LotusNotes " +
                             "       WHEN 1 THEN ISNULL(gc.CompanyName, '') " +
                             "       ELSE ISNULL(d.CompanyName, '') " +
                             "       END, " +
                             "   ReferenceNumber AS [Reference Number], " +
                             "     [dbo].[GetJobTimeMaterialWorkHours] (JobTimeMaterialWorkOrderID, 'S') AS [Hours S], " +
                            " [dbo].[GetJobTimeMaterialWorkHours] (JobTimeMaterialWorkOrderID, 'D') AS [Hours D], " +
                            " [dbo].[GetJobTimeMaterialWorkHours] (JobTimeMaterialWorkOrderID, 'P') AS [Hours P], " +
                            " [dbo].[GetJobTimeMaterialWorkHours] (JobTimeMaterialWorkOrderID, 'O') AS [Hours O]  " +
                            " FROM tblJobTimeMaterialWorkOrder o " +
                            " LEFT JOIN  tblJobContact jc ON o.AddressedToID = jc.ContactID " +
                            " LEFT JOIN tblGlobalContact gc ON jc.CompanyContactID = gc.GlobalContactID " +
                            " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                            " WHERE o.JobID = " + jobID + " ";
            }

            else
            {
                 query = " SELECT " +
                             "   JobTimeMaterialWorkOrderID, " +
                             "   o.JobID, " +
                             "   WorkOrderNumber AS [Order No], " +
                             "   WorkOrderTitle [Work Order Title], " +
                             "   WorkRequestedBy AS [Requested By], " +
                             "   Organization =  " +
                             "       CASE LotusNotes " +
                             "       WHEN 1 THEN ISNULL(c.CompanyName, '') " +
                             "       ELSE ISNULL(d.CompanyName, '') " +
                             "       END, " +
                             "   ReferenceNumber AS [Reference Number], " +
                             "     [dbo].[GetJobTimeMaterialWorkHours] (JobTimeMaterialWorkOrderID, 'S') AS [Hours S], " +
                            " [dbo].[GetJobTimeMaterialWorkHours] (JobTimeMaterialWorkOrderID, 'D') AS [Hours D], " +
                            " [dbo].[GetJobTimeMaterialWorkHours] (JobTimeMaterialWorkOrderID, 'P') AS [Hours P], " +
                            " [dbo].[GetJobTimeMaterialWorkHours] (JobTimeMaterialWorkOrderID, 'O') AS [Hours O]  " +
                            " FROM tblJobTimeMaterialWorkOrder o " +
                            " LEFT JOIN  tblJobContact jc ON o.AddressedToID = jc.ContactID " +
                            " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                            " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                            " WHERE o.JobID = " + jobID + " ";
            }

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
        public static bool Remove(string jobTimeMaterialWorkOrderID)
        {
            string query = "";

            try
            {
                query = "DELETE FROM tblJobTimeMaterialWorkOrderMaterial WHERE JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblJobTimeMaterialWorkOrderHour WHERE JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblJobTimeMaterialWorkOrder WHERE JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID;
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
            if (jobTimeMaterialWorkOrderID == "" || jobTimeMaterialWorkOrderID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobTimeMaterialWorkOrder(" +
                    " JobID, " +
                    " AddressedToID, " +
                    " WorkRequestedBy, " +
                    " ReferenceNumber, " +
                    " WorkOrderTitle, " +
                    " WorkOrderDescription, " +
                    " CustomerTrackingNumber, " +
                    " Technician, " +
                    " WorkComplete " +
                    " ) VALUES ( " +
                    jobID + ", " +
                    addressedToID + ", " +
                    workRequestedBy + ", " +
                    referenceNumber + ", " +
                    workOrderTitle + ", " +
                    workOrderDescription + ", " +
                    customerTrackingNumber+ ", " +
                    technician + ", " +
                    workComplete  + ") " +                  
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobTimeMaterialWorkOrderID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobTimeMaterialWorkOrder SET " +
                    " JobID                         = " + jobID + ", " +             
                    " AddressedToID                 = " + addressedToID + ", " +       
                    " WorkRequestedBy               = " + workRequestedBy + ", " +      
                    " ReferenceNumber               = " + referenceNumber + ", " +     
                    " WorkOrderTitle                = " + workOrderTitle + ", " +
                    " WorkOrderDescription          = " + workOrderDescription + ", " +
                    " CustomerTrackingNumber        = " + customerTrackingNumber + ", " +
                    " Technician                    = " + technician + ", " +
                    " WorkComplete                  = " + workComplete + " " +   
                    " WHERE JobTimeMaterialWorkOrderID = " + jobTimeMaterialWorkOrderID;
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
