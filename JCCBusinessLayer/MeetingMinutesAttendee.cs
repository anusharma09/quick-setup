using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace JCCBusinessLayer
{
    public class MeetingMinutesAttendee
    {
        private string meetingMinutesAttendeeID;
        private string meetingMinutesScheduleID;
        private string attendee;
        private string requiredStatus;
        private string attended;
        //
        public MeetingMinutesAttendee()
        {
        }
        //
        public MeetingMinutesAttendee(string meetingMinutesAttendeeID,
                            string meetingMinutesScheduleID,
                            string attendee,
                            string requiredStatus,
                            string attended)
        {
            this.meetingMinutesAttendeeID = meetingMinutesAttendeeID;
            this.meetingMinutesScheduleID = meetingMinutesScheduleID;
            this.attendee = "'" + attendee.Trim().Replace("'", "''") + "'";
            this.requiredStatus = "'" + requiredStatus.Trim().Replace("'", "''") + "'";
            this.attended = attended == "True" ? "1" : "0";
        }
        //
        public string MeetingMinutesAttendeeID
        {
            get { return meetingMinutesAttendeeID; }
        }
        //
        public static DataSet GetScheduleMeetingMinutesAttendee(string meetingMinutesScheduleID)
        {
            if (meetingMinutesScheduleID == "")
                meetingMinutesScheduleID = "0";

            string query = "SELECT * FROM tblMeetingMinutesAttendee WHERE MeetingMinutesScheduleID = " + meetingMinutesScheduleID + " ";

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
        public static bool Remove(string meetingMinutesAttendeeID)
        {
            string query = "";

            query = "DELETE FROM tblMeetingMinutesAttendee WHERE MeetingMinutesAttendeeID = " + meetingMinutesAttendeeID;
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
            if (meetingMinutesAttendeeID == "" || meetingMinutesAttendeeID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblMeetingMinutesAttendee(" +
                    " MeetingMinutesScheduleID, " +
                    " Attendee, " +
                    " RequiredStatus, " +
                    " Attended) Values(" +
                    meetingMinutesScheduleID + ", " +
                    attendee + ", " +
                    requiredStatus + ", " +
                    attended + ") " +
                    "Select @@IDENTITY ";
            try
            {
                meetingMinutesAttendeeID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblMeetingMinutesAttendee SET " +
                    " MeetingMinutesScheduleID      = " + meetingMinutesScheduleID + ", " +
                    " Attendee                      = " + attendee + ", " +
                    " RequiredStatus                = " + requiredStatus + ", " +
                    " Attended                      = " + attended + " " +
                    " WHERE MeetingMinutesAttendeeID = " + meetingMinutesAttendeeID;
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
