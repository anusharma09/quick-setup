using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace JCCBusinessLayer
{
    public class MeetingMinutesSchedule
    {
        private string meetingMinutesScheduleID;
        private string meetingMinutesSubjectID;
        private string scheduledDate;
        private string startTime;
        private string endTime;
        private string location;
        //
        public MeetingMinutesSchedule()
        {
        }
        //
        public MeetingMinutesSchedule(string meetingMinutesScheduleID,
                            string meetingMinutesSubjectID,
                            string scheduledDate,
                            string startTime,
                            string endTime,
                            string location)
        {
            this.meetingMinutesScheduleID = meetingMinutesScheduleID;
            this.meetingMinutesSubjectID = meetingMinutesSubjectID;
            this.scheduledDate = String.IsNullOrEmpty(scheduledDate) ? "Null" : "'" + scheduledDate + "'";
            this.startTime = "'" + startTime.Trim().Replace("'","''") + "'";
            this.endTime = "'" + endTime.Trim().Replace("'", "''") + "'";
            this.location = "'" + location.Trim().Replace("'", "''") + "'";
        }
        //
        public string MeetingMinutesScheduleID
        {
            get { return meetingMinutesScheduleID; }
        }
        //

        public static DataSet CopyMeetingMinutesSchedule(string meetingMinutesScheduleID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@MeetingMinutesScheduleID", meetingMinutesScheduleID);
            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.up_MeetingMinutesCopy", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //
        public static DataSet GetMeetingMinutesScheduleReport(string meetingMinutesScheduleID, string meetingMinutesSubjectID)
        {
            if (meetingMinutesScheduleID == "")
                meetingMinutesScheduleID = "0";

            string query = " SELECT Distinct " +
                        " MeetingMinutesSubjectCode + '-' + MeetingMinutesScheduleCode + '-' + MeetingMinutesItemCode AS No, " +

                           " JobNumber, JobName, " +
                          " ss.MeetingMinutesSubject, " +
                           " s.*, " +
                           " t.Topic, " +
                           " i.* " +
                        " FROM tblMeetingMinutesSchedule s " +
                        " LEFT JOIN tblMeetingMinutesSubject ss ON s.MeetingMinutesSubjectID = ss.MeetingMinutesSubjectID " +
                        " LEFT JOIN tblMeetingMinutesItem i ON s.MeetingMinutesScheduleID = i.MeetingMinutesScheduleID " +
                        " LEFT JOIN tblMeetingMinutesTopic t ON i.MeetingMinutesTopicID = t.MeetingMinutesTopicID " +
                        " LEFT JOIN tblJob j ON ss.JobID = j.JobID " +
                        " WHERE s.MeetingMinutesScheduleID  = " + meetingMinutesScheduleID + " " +
                        " UNION ALL " +
                         " SELECT Distinct " +
                        " MeetingMinutesSubjectCode + '-' + MeetingMinutesScheduleCode + '-' + MeetingMinutesItemCode AS No, " +

                           " JobNumber, JobName, " +
                          " ss.MeetingMinutesSubject, " +
                           " s.*, " +
                           " t.Topic, " +
                           " i.* " +
                        " FROM tblMeetingMinutesSchedule s " +
                        " LEFT JOIN tblMeetingMinutesSubject ss ON s.MeetingMinutesSubjectID = ss.MeetingMinutesSubjectID " +
                        " LEFT JOIN tblMeetingMinutesItem i ON s.MeetingMinutesScheduleID = i.MeetingMinutesScheduleID " +
                        " LEFT JOIN tblMeetingMinutesTopic t ON i.MeetingMinutesTopicID = t.MeetingMinutesTopicID " +
                        " LEFT JOIN tblJob j ON ss.JobID = j.JobID " +
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
        public static DataSet GetMeetingMinutesSchedule(string meetingMinutesScheduleID)
        {
            if (meetingMinutesScheduleID == "")
                meetingMinutesScheduleID = "0";

            string query = " SELECT " +
                           " s.* " +
                           " FROM tblMeetingMinutesSchedule s " +
                           " WHERE s.MeetingMinutesScheduleID = " + meetingMinutesScheduleID + " ";

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
        public static DataSet GetJobMeetingMinutesSchedule(string jobID)
        {
            if (jobID == "")
                jobID = "0";

            string query = " SELECT " +
                           " MeetingMinutesSubjectCode + '-' + MeetingMinutesSubject AS [Subject], " +
                           " m.MeetingMinutesScheduleID, " +
                           " m.MeetingMinutesSubjectID, " +
                           " m.MeetingMinutesScheduleCode AS Code, " +
                           " m.ScheduledDate As [Scheduled Date], " +
                           " m.StartTime AS [Start Time], " +
                           " m.EndTime AS [End Time], " +
                           " m.Location AS [Location] " +
                           " FROM tblMeetingMinutesSchedule m  " +
                           " LEFT JOIN tblMeetingMinutesSubject s ON m.MeetingMinutesSubjectID = s.MeetingMinutesSubjectID " +
                           " WHERE s.JobID = " + jobID + " ";

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
        public static bool Remove(string meetingMinutesScheduleID)
        {
            string query = "";

            query = "DELETE FROM tblMeetingMinutesSchedule WHERE MeetingMinutesScheduleID = " + meetingMinutesScheduleID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblMeetingMinutesAttendee WHERE MeetingMinutesScheduleID = " + meetingMinutesScheduleID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblMeetingMinutesItem WHERE MeetingMinutesScheduleID = " + meetingMinutesScheduleID;
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
            if (meetingMinutesScheduleID == "" || meetingMinutesScheduleID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblMeetingMinutesSchedule(MeetingMinutesSubjectID, ScheduledDate, StartTime, EndTime, Location) Values(" +
                    meetingMinutesSubjectID + ", " + scheduledDate + ", " + startTime + ", " + endTime + ", " + location + ") " +
                    "Select @@IDENTITY ";
            try
            {
                meetingMinutesScheduleID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblMeetingMinutesSchedule SET " +
                    " MeetingMinutesSubjectID       = " + meetingMinutesSubjectID + ", " +
                    " ScheduledDate                 = " + scheduledDate + ", " +
                    " StartTime                     = " + startTime + ", " +
                    " EndTime                       = " + endTime + ", " +
                    " Location                      = " + location + " " +
                    " WHERE MeetingMinutesScheduleID = " + meetingMinutesScheduleID;
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
