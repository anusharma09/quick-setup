using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace JCCBusinessLayer
{
    public class MeetingMinutesItem
    {
        private string meetingMinutesItemID;
        private string meetingMinutesScheduleID;
        private string meetingMinutesTopicID;
        private string action;
        private string assignedTo;
        private string assignmentDate;
        private string status;
        private string statusDate;
        private string completionDate;
        //
        public MeetingMinutesItem()
        {
        }
        //
        public MeetingMinutesItem(string meetingMinutesItemID,
                            string meetingMinutesScheduleID,
                            string meetingMinutesTopicID,
                            string action,
                            string assignedTo,
                            string assignmentDate,
                            string status,
                            string statusDate,
                            string completionDate)
        {
            this.meetingMinutesItemID = meetingMinutesItemID;
            this.meetingMinutesScheduleID = meetingMinutesScheduleID;
            this.meetingMinutesTopicID = String.IsNullOrEmpty(meetingMinutesTopicID) ? "Null" : meetingMinutesTopicID;
            this.action = "'" + action.Trim().Replace("'", "''") + "'";
            this.assignedTo = "'" + assignedTo.Trim().Replace("'", "''") + "'";
            this.assignmentDate = String.IsNullOrEmpty(assignmentDate) ? "Null" : "'" + assignmentDate + "'";
            this.status = "'" + status.Trim().Replace("'", "''") + "'";
            this.statusDate = String.IsNullOrEmpty(statusDate) ? "null" : "'" + statusDate + "'";
            this.completionDate = String.IsNullOrEmpty(completionDate) ? "null" : "'" + completionDate + "'";
        }
        //
        public string MeetingMinutesItemID
        {
            get { return meetingMinutesItemID; }
        }
        //
        public static DataSet GetScheduleMeetingMinutesItem(string meetingMinutesScheduleID, string meetingMinutesSubjectID)
        {
            if (meetingMinutesScheduleID == "")
                meetingMinutesScheduleID = "0";

            string query = "SELECT " +
                    " MeetingMinutesScheduleCode + '-' + MeetingMinutesItemCode AS No, " +
                    " i.* " +

                " FROM tblMeetingMinutesItem i " +
                " LEFT JOIN tblMeetingMinutesSchedule s ON i.MeetingMinutesScheduleID = s.MeetingMinutesScheduleID " +
                " LEFT JOIN tblMeetingMinutesSubject ss ON s.MeetingMinutesSubjectID = ss.MeetingMinutesSubjectID " +


                " WHERE i.MeetingMinutesScheduleID = " + meetingMinutesScheduleID + " " +

                 " UNION ALL " +
                 " SELECT " +
                 " MeetingMinutesScheduleCode + '-' + MeetingMinutesItemCode AS No, " +
                    "i.* " +
                " FROM tblMeetingMinutesItem i " +
                " LEFT JOIN tblMeetingMinutesSchedule s ON i.MeetingMinutesScheduleID = s.MeetingMinutesScheduleID " +
                " LEFT JOIN tblMeetingMinutesSubject ss ON s.MeetingMinutesSubjectID = ss.MeetingMinutesSubjectID " +
                " WHERE s.MeetingMinutesSubjectID  = " + meetingMinutesSubjectID + " AND i.Status = 'Open' " +
                " AND s.MeetingMinutesScheduleID < " + meetingMinutesScheduleID + " ";

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
        public static bool Remove(string meetingMinutesItemID)
        {
            string query = "";

            query = "DELETE FROM tblMeetingMinutesItem WHERE MeetingMinutesItemID = " + meetingMinutesItemID;
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
            if (meetingMinutesItemID == "" || meetingMinutesItemID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblMeetingMinutesItem(" +
                    " MeetingMinutesScheduleID, " +
                    " MeetingMinutesTopicID, " +
                    " Action, " +
                    " AssignedTo, " +
                    " AssignmentDate, " +
                    " Status, " +
                    " StatusDate, " +
                    " CompletionDate) Values(" +
                    meetingMinutesScheduleID + ", " + 
                    meetingMinutesTopicID + ", " +
                    action + ", " + 
                    assignedTo + ", " + 
                    assignmentDate + ", " +
                    status + ", " +
                    statusDate + ", " +
                    completionDate + ") " +
                    "Select @@IDENTITY ";
            try
            {
                meetingMinutesItemID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblMeetingMinutesItem SET " +
                    " MeetingMinutesScheduleID      = " + meetingMinutesScheduleID + ", " +
                    " MeetingMinutesTopicID         = " + meetingMinutesTopicID + ", " +
                    " Action                        = " + action + ", " +
                    " AssignedTo                    = " + assignedTo + ", " +
                    " AssignmentDate                = " + assignmentDate + ", " +
                    " Status                        = " + status + ", " +
                    " StatusDate                    = " + statusDate + ", " +
                    " CompletionDate                = " + completionDate + " " +
                    " WHERE MeetingMinutesItemID = " + meetingMinutesItemID;
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
    }
}
