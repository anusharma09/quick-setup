using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;

namespace JCCEquipmentRental.BusinessLayer
{
    class EquipmentRental
    {
        private string jobEquipmentRentalID;
        private string jobID;
        private string createdBy;
        private string creationDate;
        private string equipmentNumber;
        private string equipmentDescription;
        private string equipmentAccessories;
        private string deliveryDate;
        private string duration;
        private string startRentalDate;
        private string endRentalDate;
        private string offRentalDate;
        private string pickedUpdDate;
        private string goodCondition;
        private string returnedAsReceived;
        private string poNumber;
        private string vendor;
        private string status;
        private string termNumber;
        private string dtNumber;
        private string comment;
        private string updatedBy;
        private string updatedDate;
        private string fromID;
        private string phone;

        //
        public EquipmentRental()
        {
        }
        //
        public EquipmentRental(string jobEquipmentRentalID,
                               string jobID,
                               string equipmentNumber,
                               string equipmentDescription,
                               string equipmentAccessories,
                               string deliveryDate,
                               string duration,
                               string startRentalDate,
                               string endRentalDate,
                               string offRentalDate,
                               string pickedUpdDate,
                               string goodCondition,
                               string returnedAsReceived,
                               string poNumber,
                               string vendor,
                               string status,
                               string termNumber,
                               string dtNumber,
                               string comment,
                               string fromID,
                               string phone)
        {
            this.jobEquipmentRentalID                   = jobEquipmentRentalID;
            this.jobID                                  = jobID;
            this.equipmentNumber                        = "'" +equipmentNumber.Trim().Replace("'", "''") + "'";
            this.equipmentDescription                   = "'" + equipmentDescription.Trim().Replace("'","''") + "'";
            this.equipmentAccessories                   = "'" + equipmentAccessories.Trim().Replace("'","''") + "'";
            this.deliveryDate                           = String.IsNullOrEmpty(deliveryDate) ? "null" : "'" + deliveryDate + "'";
            this.duration                               = "'" + duration.Trim().Replace("'","''") + "'";
            this.startRentalDate                        = String.IsNullOrEmpty(startRentalDate) ? "null" : "'" + startRentalDate + "'";
            this.endRentalDate                          = String.IsNullOrEmpty(endRentalDate) ? "null" : "'" + endRentalDate + "'";
            this.offRentalDate                          = "'" + offRentalDate.Trim().Replace("'", "''") + "'";
            this.pickedUpdDate                          = String.IsNullOrEmpty(pickedUpdDate) ? "null" : "'" + pickedUpdDate + "'";
            this.goodCondition                          = goodCondition == "True" ? "1" : "0";
            this.returnedAsReceived                     = returnedAsReceived == "True" ? "1" : "0";
            this.poNumber                               = "'" + poNumber.Trim().Replace("'","''") + "'";
            this.vendor                                 = "'" + vendor.Trim().Replace("'", "''") + "'";
            this.status                                 = "'" + status.Trim().Replace("'", "''") + "'";
            this.termNumber                             = "'" + termNumber.Trim().Replace("'","''") + "'";
            this.dtNumber                               = "'" + dtNumber.Trim().Replace("'","''") + "'";
            this.comment                                = "'" + comment.Trim().Replace("'", "''") + "'";
            this.phone                                  = "'" + phone.Trim().Replace("'", "''") + "'";
            this.fromID                                 = String.IsNullOrEmpty(fromID) ? "Null" : fromID;				


        }
        //
        public string JobEquipmentRentalID
        {
            get { return jobEquipmentRentalID; }
        }
        //
        //
        public static DataSet GetEmailTo()
        {

            string query = " SELECT DISTINCT  EMail " +
                           " FROM tblSECUserAccess a  " +
                           " INNER JOIN tblUser u ON a.UserID = u.UserID " +
                           " WHERE AccessID IN(43) ";
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
        public static DataSet GetEquipmentRentalList(string where)
        {

            string query = " SELECT " +
                           " JobEquipmentRentalID, " +
                           " RequestNumber AS [Req No], " +
                           " JobNumber AS [Job], " +
                           " r.PONumber AS [PO], " +
                           " EquipmentNumber AS [Equip No], " +
                           " EquipmentDescription AS [Equipment], " +
                           " r.CreationDate AS [Ordered date], " +
                           " UserName  AS [Ordered By], " +
                           " StartRentalDate AS [Start Date], " +
                           " EndRentalDate AS [End Date], " +
                           " [OffRentalDate] AS [Off Date], " +
                           " [Name] AS Vendor, " +
                           " [Status], " +
                           " [Description] AS [Project Manager], " +
                           " [TermNumber] AS [Term No], " +
                           " [DTNumber] AS [DT No] " +
                           " FROM tblJobEquipmentRental r " +
                           " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           " LEFT JOIN tblProjectManager m ON m.ProjectManagerID = j.ProjectManagerID " +
                           " LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID " +
                           " LEFT JOIN tblVendor v ON r.Vendor = v.VendorID	 " +
                           where;
	

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
        //
        public static string GetJobID(string jobNumber)
        {
            string query = "";
            bool ret = false;
            string jobID = "0";
            DataTable t;
            if (jobNumber == "")
                jobNumber = "0";
            


            if (Security.Security.UserJCCEquipmentRentalAccess == Security.Security.Access.JCCEquipmentRentalAdmin ||
                Security.Security.UserJCCEquipmentRentalAccess == Security.Security.Access.JCCEquipmentRentalAdminMail)
            {
                query = "SELECT JobID FROM tblJob WHERE JobNumber = '" + jobNumber + "'";
            }
            else
            {
                query = " SELECT JobID " + 
                        " FROM tblJob " + 
                        " WHERE JobNumber = '" + jobNumber + "'" + 
                        " AND [dbo].[GetUserJobAccess](JobID,'" + Security.Security.LoginID  + "')  = 1 "; 
            }

            try
            {
                t =  DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    jobID = t.Rows[0]["JobID"].ToString();
                return jobID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobEquipmentRentalList(string jobID)
        {
            if (jobID == "")
                jobID = "0";

            string query = " SELECT " +
                           " JobEquipmentRentalID, " +
                           " JobID, " +
                           " RequestNumber AS [Req No], " +
                           " UserName AS [Ordered By], " +
                           " CreationDate AS [Ordered Date], " +
                           " EquipmentNumber AS [Equipment Number], " +
                           " EquipmentDescription AS [Equipment Description], " +
                           " EquipmentAccessories AS [Equipment Accessories], " +
                           " DeliveryDate AS [Delivery Date], " +
                           " StartRentalDate AS [Start Date], " +
                           " EndRentalDate AS [End Date], " +
                           " OffRentalDate AS [Off Date], " +
                           " GoodCondition AS [Good Condition], " +
                           " ReturnedAsReceived [Returned As Received] " +
                           " FROM tblJobEquipmentRental r " +
                           " LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID " +
                           " WHERE JobID = " + jobID + " ";

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
        public static DataSet GetEquipmentRentalForm(string jobEquipmentRentalID)
        {
            if (jobEquipmentRentalID == "")
                jobEquipmentRentalID = "0";

            
                string query = " SELECT " +
                " JobNumber, " +
                " RequestNumber, " +
                " JobName, " +
                " CASE l.LotusNotes  WHEN 1 THEN  mm.FirstName + ' '  + mm.LastName  ELSE nn.FirstName  + ' ' + nn.LastName  End AS [ProjectManager], " +
                " r.CreationDate, " +
                " u.UserName  AS [CreatedBy], " +
                " r.UpdatedDate, " +
                " uu.UserName  AS [UpdatedBy], " +
                " EquipmentNumber, " +
                " EquipmentDescription, " +
                " EquipmentAccessories, " +
                " DeliveryDate, " +
                " r.Duration, " +
                " StartRentalDate, " +
                " EndRentalDate, " +
                " OffRentalDate, " +
                " GoodCondition, " +
                " ReturnedAsReceived, " +
                " PickedupdDate, " +
                " r.PONumber, " +
                " Name AS Vendor, " +
                " Status, " +
                " TermNumber, " +
                " DTNumber, " +
                " r.Comment, " +
               " EmailFrom = " +
               " CASE l.LotusNotes " +
               " WHEN 1 THEN  ISNULL(mm.Email, '')" +
               " ELSE ISNULL(nn.Email, '') " +
               " End " +
                " FROM tblJobEquipmentRental r " +
                " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                //" LEFT JOIN tblProjectManager m ON m.ProjectManagerID = j.ProjectManagerID " +
                " LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID " +
                " LEFT JOIN tblUser uu ON r.UpdatedBy = uu.UserLanID " +
                " LEFT JOIN tblVendor v ON r.Vendor = v.VendorID " +
               " LEFT JOIN tblJobContact l ON r.FromID = l.ContactID " +
               " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
               " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +


                " WHERE JobEquipmentRentalID = " + jobEquipmentRentalID + " ";
            
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetEquipmentRentalFormForNewjob(string jobEquipmentRentalID)
        {
            if (jobEquipmentRentalID == "")
                jobEquipmentRentalID = "0";

            
                string query = " SELECT " +
                " JobNumber, " +
                " RequestNumber, " +
                " JobName, " +                
                " CASE l.LotusNotes  WHEN 1 THEN  gc.FirstName + ' '  + gc.LastName  ELSE nn.FirstName  + ' ' + nn.LastName  End AS [ProjectManager], " +
                " r.CreationDate, " +
                " u.UserName  AS [CreatedBy], " +
                " r.UpdatedDate, " +
                " uu.UserName  AS [UpdatedBy], " +
                " EquipmentNumber, " +
                " EquipmentDescription, " +
                " EquipmentAccessories, " +
                " DeliveryDate, " +
                " r.Duration, " +
                " StartRentalDate, " +
                " EndRentalDate, " +
                " OffRentalDate, " +
                " GoodCondition, " +
                " ReturnedAsReceived, " +
                " PickedupdDate, " +
                " r.PONumber, " +
                " Name AS Vendor, " +
                " Status, " +
                " TermNumber, " +
                " DTNumber, " +
                " r.Comment, " +
               " EmailFrom = " +
               " CASE l.LotusNotes " +
               " WHEN 1 THEN  ISNULL(gc.Email, '')" +
               " ELSE ISNULL(nn.Email, '') " +
               " End " +
                " FROM tblJobEquipmentRental r " +
                " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
               
                " LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID " +
                " LEFT JOIN tblUser uu ON r.UpdatedBy = uu.UserLanID " +
                " LEFT JOIN tblVendor v ON r.Vendor = v.VendorID " +
               " LEFT JOIN tblJobContact l ON r.FromID = l.ContactID " +
               " LEFT JOIN tblGlobalContact gc ON l.CompanyContactID = gc.GlobalContactID  " +
               " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +


                " WHERE JobEquipmentRentalID = " + jobEquipmentRentalID + " ";
            
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
        public static DataSet GetEquipmentRental(string jobEquipmentRentalID)
        {
            if (jobEquipmentRentalID == "")
                jobEquipmentRentalID = "0";

            string query = "SELECT r.*, " +
                    " JobNumber, " +
                    " u.UserName AS CreatedByName, " +
                    " uu.UserName AS UpdatedByName " +
                " FROM tblJobEquipmentRental r" +
                " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                " LEFT JOIN tblUser u ON r.CreatedBy = u.UserLanID " +
                " LEFT JOIN tblUser uu ON r.UpdatedBy = uu.UserLanID " +
                " WHERE JobEquipmentRentalID = " + jobEquipmentRentalID + " ";

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
        public static DataSet GetCreatUpdate(string jobEquipmentRentalID)
        {
            if (jobEquipmentRentalID == "")
                jobEquipmentRentalID = "0";

            string query = "SELECT RequestNumber, r.CreationDate, " +
                    " r.UpdatedDate, " +
                    " u.UserName AS CreatedByName, " +
                    " uu.UserName AS UpdatedByName " +
                " FROM tblJobEquipmentRental r" +
                " LEFT JOIN tblUser u ON r.CreatedBy = u.UserLanID " +
                " LEFT JOIN tblUser uu ON r.UpdatedBy = uu.UserLanID " +
                " WHERE JobEquipmentRentalID = " + jobEquipmentRentalID + " ";

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
        public static bool Remove(string jobEquipmentRentalID)
        {
            string query = "";

            query = "DELETE FROM tblJobEquipmentRental WHERE JobEquipmentRentalID = " + jobEquipmentRentalID;
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
        public bool Save()
        {
            if (jobEquipmentRentalID == "" || jobEquipmentRentalID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobEquipmentRental(" +
                    " JobID, " +                    
                    " CreatedBy, " +                
                    " CreationDate, " +             
                    " EquipmentNumber, " +          
                    " EquipmentDescription, " +     
                    " EquipmentAccessories, " +     
                    " DeliveryDate, " +             
                    " Duration, " +                 
                    " StartRentalDate, " +         
                    " EndRentalDate, " +            
                    " OffRentalDate, " +
                    " PickedUpdDate, " +             
                    " GoodCondition, " +            
                    " ReturnedAsReceived, " +       
                    " PONumber, " +                 
                    " Vendor, " +                   
                    " Status, " +                   
                    " TermNumber, " +               
                    " DTNumber, " + 
                    " FromID, " +
                    " Phone, " +
                    " Comment " +                  
                    " ) VALUES ( " +
                    jobID + ", " +                     
                    "'" + Security.Security.LoginID + "', " +                
                    "'" + DateTime.Now.ToShortDateString() + "', " +             
                    equipmentNumber + ", " +          
                    equipmentDescription + ", " +     
                    equipmentAccessories + ", " +     
                    deliveryDate + ", " +             
                    duration + ", " +                 
                    startRentalDate + ", " +         
                    endRentalDate + ", " +            
                    offRentalDate + ", " +
                    pickedUpdDate + ", " +             
                    goodCondition + ", " +            
                    returnedAsReceived + ", " +       
                    poNumber + ", " +                 
                    vendor + ", " +                   
                    status + ", " +                  
                    termNumber + ", " +               
                    dtNumber + ", " +  
                    fromID + ", " +
                    phone + ", " +
                    comment + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobEquipmentRentalID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobEquipmentRental SET " +
                   // " JobID                           = " + jobID  + ", " +                    
                    " EquipmentNumber                 = " + equipmentNumber + ", " +                               
                    " EquipmentDescription            = " + equipmentDescription + ", " +                          
                    " EquipmentAccessories            = " + equipmentAccessories + ", " +                          
                    " DeliveryDate                    = " + deliveryDate + ", " +                                  
                    " Duration                        = " + duration + ", " +                                      
                    " StartRentalDate                 = " + startRentalDate + ", " +                              
                    " EndRentalDate                   = " + endRentalDate + ", " +                                 
                    " OffRentalDate                   = " + offRentalDate + ", " +
                    " PickedUpdDate                   = " + pickedUpdDate + ", " +                                  
                    " GoodCondition                   = " + goodCondition + ", " +                                 
                    " ReturnedAsReceived              = " + returnedAsReceived + ", " +                            
                    " PONumber                        = " + poNumber + ", " +                                      
                    " Vendor                          = " + vendor + ", " +                                        
                    " Status                          = " + status + ", " +                                        
                    " TermNumber                      = " + termNumber + ", " +                                    
                    " DTNumber                        = " + dtNumber + ", " +
                    " FromID                          = " + fromID + ", " +
                    " Phone                           = " + phone + ", " +         
                    " Comment                         = " + comment + ", " +
                    " UpdatedBy                       = '" + Security.Security.LoginID + "', " +
                    " UpdatedDate                     = '" + DateTime.Now.ToShortDateString() + "' " +
                    " WHERE JobEquipmentRentalID      = " + jobEquipmentRentalID;
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
