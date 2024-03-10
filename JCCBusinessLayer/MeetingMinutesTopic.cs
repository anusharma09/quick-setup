using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace JCCBusinessLayer
{
    public class MeetingMinutesTopic
    {
        private string meetingMinutesTopicID;
        private string meetingMinutesSubjectID;
        private string topic;
        //
        public MeetingMinutesTopic()
        {
        }
        //
        public MeetingMinutesTopic(string meetingMinutesTopicID,
                            string meetingMinutesSubjectID,
                            string topic)
        {

            this.meetingMinutesTopicID = meetingMinutesTopicID;
            this.meetingMinutesSubjectID = meetingMinutesSubjectID;
            this.topic = "'" + topic.Trim().Replace("'", "''") + "'";
        }
        //
        public string MeetingMinutesTopicID
        {
            get { return meetingMinutesTopicID; }
        }
        //
        public static DataSet GetSubjectMeetingMinutesTopic(string meetingMinutesSubjectID)
        {
            if (meetingMinutesSubjectID == "")
                meetingMinutesSubjectID = "0";

            string query = "SELECT * FROM tblMeetingMinutesTopic WHERE MeetingMinutesSubjectID = " + meetingMinutesSubjectID + " ";

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
        public static bool Remove(string meetingMinutesTopicID)
        {
            string query = "";

            query = "DELETE FROM tblMeetingMinutesTopic WHERE MeetingMinutesTopicID = " + meetingMinutesTopicID;
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
            if (meetingMinutesTopicID == "" || meetingMinutesTopicID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblMeetingMinutesTopic(MeetingMinutesSubjectID, Topic) Values(" +
                    meetingMinutesSubjectID + ", " + topic + ") " +
                    "Select @@IDENTITY ";
            try
            {
                meetingMinutesTopicID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblMeetingMinutesTopic SET " +
                    " MeetingMinutesSubjectID       = " + meetingMinutesSubjectID + ", " +
                    " Topic                         = " + topic + " " +
                    " WHERE MeetingMinutesTopicID   = " + meetingMinutesTopicID;
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
