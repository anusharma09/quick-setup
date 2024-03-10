using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMActivity
    {
        private string cmActivityID;
        private string cmContactID;
        private string cmActivityType;
        private string cmActivityStartDate;
        private string cmActivityStartTime;
        private string cmActivityDuration;
        private string cmActivityEndDate;
        private string cmActivityEndTime;
        private string cmActivityRegarding;
        private string cmActivityResource;
        private string cmActivityLocation;
        private string cmActivityPriority;
        private string cmActivityAlarm;
        private string cmActivityScheduledFor;
        private string cmActivityDetail;
        private string cmActivityRecurrence;
        private string cmActivityEvery;
        private string cmActivityRangeStartDate;
        private string cmActivityNoEndDate;
        private string cmActivityRangeEndDate;
        private string cmActivityAvailability;
        private string cmActivityCreateDate;
        private string cmActivityCreateBy;
        private string cmActivityEditDate;
        private string cmActivityEditBy;
        //
        public string CMActivityID
        {
            get { return cmActivityID; }
        }
        //
        public CMActivity()
        {
        }
        //
        public CMActivity(string cmActivityID,
                          string cmContactID,
                          string cmActivityType,
                          string cmActivityStartDate,
                          string cmActivityStartTime,
                          string cmActivityDuration,
                          string cmActivityEndDate,
                          string cmActivityEndTime,
                          string cmActivityRegarding,
                          string cmActivityResource,
                          string cmActivityLocation,
                          string cmActivityPriority,
                          string cmActivityAlarm,
                          string cmActivityScheduledFor,
                          string cmActivityDetail,
                          string cmActivityRecurrence,
                          string cmActivityEvery,
                          string cmActivityRangeStartDate,
                          string cmActivityNoEndDate,
                          string cmActivityRangeEndDate,
                          string cmActivityAvailability,
                          string cmActivityCreateDate,
                          string cmActivityCreateBy,
                          string cmActivityEditDate,
                          string cmActivityEditBy)
        {
            this.cmActivityID               = String.IsNullOrEmpty(cmActivityID) ? "" : cmActivityID;
            this.cmContactID                = String.IsNullOrEmpty(cmContactID) ? "null" : cmContactID;
            this.cmActivityType             = String.IsNullOrEmpty(cmActivityType) ? "null" : cmActivityType;
            this.cmActivityStartDate        = String.IsNullOrEmpty(cmActivityStartDate) ? "null" : "'" + cmActivityStartDate + "'";
            this.cmActivityStartTime        = cmActivityStartTime.Trim().Replace("'", "''");
            this.cmActivityDuration         = cmActivityDuration.Trim().Replace("'", "''");
            this.cmActivityEndDate          = String.IsNullOrEmpty(cmActivityEndDate) ? "null" : "'" + cmActivityEndDate + "'";
            this.cmActivityEndTime          = cmActivityEndTime.Trim().Replace("'","''");
            this.cmActivityRegarding        = cmActivityRegarding.Trim().Replace("'","''");
            this.cmActivityResource         = cmActivityResource.Trim().Replace("'","''");
            this.cmActivityLocation         = cmActivityLocation.Trim().Replace("'","''");
            this.cmActivityPriority         = cmActivityPriority.Trim().Replace("'","''");
            this.cmActivityAlarm            = cmActivityAlarm.Trim().Replace("'","''");
            this.cmActivityScheduledFor     = String.IsNullOrEmpty(cmActivityScheduledFor) ? "null" : cmActivityScheduledFor;
            this.cmActivityDetail           = cmActivityDetail.Trim().Replace("'","''");
            this.cmActivityRecurrence       = cmActivityRecurrence.Trim().Replace("'","''");
            this.cmActivityEvery            = cmActivityEvery.Trim().Replace("'","''");
            this.cmActivityRangeStartDate   = String.IsNullOrEmpty(cmActivityRangeStartDate) ? "null" : "'" + cmActivityRangeStartDate + "'";
            this.cmActivityNoEndDate        = cmActivityNoEndDate == "True" ? "1" : "0";
            this.cmActivityRangeEndDate     = String.IsNullOrEmpty(cmActivityRangeEndDate) ? "null" : "'" + cmActivityRangeEndDate + "'"; 
            this.cmActivityAvailability     = cmActivityAvailability == "True" ? "1" : "0";
            this.cmActivityCreateDate       = String.IsNullOrEmpty(cmActivityCreateDate) ? "null" : "'" + cmActivityCreateDate + "'";
            this.cmActivityCreateBy         = cmActivityCreateBy.Trim().Replace("'","''");
            this.cmActivityEditDate         = String.IsNullOrEmpty(cmActivityEditDate) ? "null" : "'" + cmActivityEditDate + "'";
            this.cmActivityEditBy           = cmActivityEditBy.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmActivityID == "" || cmActivityID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMTitle(" + 
                    " CMContactID, " +             
                    " CMActivityType, " +          
                    " CMActivityStartDate, " +     
                    " CMActivityStartTime, " +     
                    " CMActivityDuration, " +      
                    " CMActivityEndDate, " +       
                    " CMActivityEndTime, " +       
                    " CMActivityRegarding, " +     
                    " CMActivityResource, " +      
                    " CMActivityLocation, " +      
                    " CMActivityPriority, " +      
                    " CMActivityAlarm, " +         
                    " CMActivityScheduledFor, " +   
                    " CMActivityDetail, " +        
                    " CMActivityRecurrence, " +    
                    " CMActivityEvery, " +         
                    " CMActivityRangeStartDate, " +
                    " CMActivityNoEndDate, "  +   
                    " CMActivityRangeEndDate, " +  
                    " CMActivityAvailability, " +          
                    " CMActivityCreateDate, " +    
                    " CMActivityCreateBy, " +      
                    " CMActivityEditDate, " +      
                    " CMActivityEditBy) VALUES (" +        
                    cmContactID + ", " +             
                    cmActivityType + ", " +          
                    cmActivityStartDate + ", " +     
                    "'" + cmActivityStartTime + "', " +     
                    "'" + cmActivityDuration + "', " +     
                    cmActivityEndDate + ", " +       
                    "'" + cmActivityEndTime + "', " +      
                    "'" + cmActivityRegarding + "', " +     
                    "'" + cmActivityResource + "', " +      
                    "'" + cmActivityLocation + "', " +     
                    "'" + cmActivityPriority + "', " +      
                    "'" + cmActivityAlarm + "', " +        
                    cmActivityScheduledFor + ", " +   
                    "'" + cmActivityDetail + "', " +        
                    "'" + cmActivityRecurrence + "', " +    
                    "'" + cmActivityEvery + "', " +         
                    cmActivityRangeStartDate + ", " +
                    cmActivityNoEndDate + ", " +     
                    cmActivityRangeEndDate + ", " +  
                    cmActivityAvailability + ", " +          
                    cmActivityCreateDate + ", " +    
                    "'" + cmActivityCreateBy + "', " +      
                    cmActivityEditDate + ", " +      
                    "'" + cmActivityEditBy + "') " +        
                    "Select @@IDENTITY ";
            try
            {
                cmActivityID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMActivity SET " +
                    " CMContactID               =  " + cmContactID + ", " +
                    " CMActivityType            =  " + cmActivityType + ", " +
                    " CMActivityStartDate       =  " + cmActivityStartDate + ", " +
                    " CMActivityStartTime       = '" + cmActivityStartTime + "', " +
                    " CMActivityDuration        = '" + cmActivityDuration + "', " +
                    " CMActivityEndDate         =  " + cmActivityEndDate + ", " +
                    " CMActivityEndTime         = '" + cmActivityEndTime + "', " +
                    " CMActivityRegarding       = '" + cmActivityRegarding + "', " +
                    " CMActivityResource        = '" + cmActivityResource + "', " +
                    " CMActivityLocation        = '" + cmActivityLocation + "', " +
                    " CMActivityPriority        = '" + cmActivityPriority + "', " +
                    " CMActivityAlarm           = '" + cmActivityAlarm + "', " +
                    " CMActivityScheduledFor    =  " + cmActivityScheduledFor + ", " +
                    " CMActivityDetail          = '" + cmActivityDetail + "', " +
                    " CMActivityRecurrence      = '" + cmActivityRecurrence + "', " +
                    " CMActivityEvery           = '" + cmActivityEvery + "', " +
                    " CMActivityRangeStartDate  =  " + cmActivityRangeStartDate + ", " +
                    " CMActivityNoEndDate       =  " + cmActivityNoEndDate + ", " +
                    " CMActivityRangeEndDate    =  " + cmActivityRangeEndDate + ", " +
                    " CMActivityAvailability    =  " + cmActivityAvailability + ", " +
                    " CMActivityCreateDate      =  " + cmActivityCreateDate + ", " +
                    " CMActivityCreateBy        = '" + cmActivityCreateBy + "', " +
                    " CMActivityEditDate        =  " + cmActivityEditDate + ", " +
                    " CMActivityEditBy          = '" + cmActivityEditBy + "' " +        
                    " WHERE CMActivityID        = " + cmActivityID;

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
        public static void Delete(string cmActivityID)
        {
            string query = "Delete FROM tblCMActivity WHERE CMActivityID = " + cmActivityID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetCMActivityList()
        {
            string query = "";

            query = " SELECT CMTitleID, " +
                    " CMContactID               AS [Contact], " +
                    " CMActivityType            AS [Activity Type], " +
                    " CMActivityStartDate       AS [Start Date], " +
                    " CMActivityStartTime       AS [Start Time], " +
                    " CMActivityDuration        AS [Duration], " +
                    " CMActivityEndDate         AS [End Date], " +
                    " CMActivityEndTime         AS [End Time], " +
                    " CMActivityRegarding       AS [Regarding], " +
                    " CMActivityResource        AS [Resource], " +
                    " CMActivityLocation        AS [Location], " +
                    " CMActivityPriority        AS [Priority], " +
                    " CMActivityAlarm           AS [Alarm], " +
                    " CMActivityScheduledFor    As [Scheduled For], " +
                    " CMActivityDetail          AS [Detail], " +
                    " CMActivityRecurrence      AS [Recurrence], " +
                    " CMActivityEvery           AS [Every], " +
                    " CMActivityRangeStartDate  AS [Range Start Date], " +
                    " CMActivityNoEndDate       AS [No End Date], " +
                    " CMActivityRangeEndDate    AS [Range End Date], " +
                    " CMActivityAvailability    AS [Availability], " +
                    " CMActivityCreateDate      AS [Create Date], " +
                    " CMActivityCreateBy        AS [Create By], " +
                    " CMActivityEditDate        AS [Edit Date], " +
                    " CMActivityEditBy          AS [Edit By] " +
                    " FROM  tblCMActivity  ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
