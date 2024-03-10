using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace JCCBusinessLayer
{
    public class MeetingMinutesSubject
    {
        private string meetingMinutesSubjectID;
        private string jobID;
        private string meetingMinutesSubject;
        //
        public MeetingMinutesSubject()
        {
        }
        //
        public MeetingMinutesSubject(string meetingMinutesSubjectID,
                            string jobID,
                            string meetingMinutesSubject)
        {

            this.meetingMinutesSubjectID = meetingMinutesSubjectID;
            this.jobID = jobID;
            this.meetingMinutesSubject = "'" + meetingMinutesSubject.Trim().Replace("'","''") + "'";
        }
        //
        public string MeetingMinutesSubjectID
        {
            get { return meetingMinutesSubjectID; }
        }
        //
        public static DataSet GetJobMeetingMinutesSubject(string jobID)
        {
            if (jobID == "")
                jobID = "0";

            string query = "SELECT " +
                            " MeetingMinutesSubjectID, " +
                            " JobID, " +
                            " MeetingMinutesSubjectCode + '-' + MeetingMinutesSubject AS [MeetingMinutesSubject] " +
                    " FROM tblMeetingMinutesSubject WHERE JobID = " + jobID + " ";

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
        public static DataSet GetMeetingMinutesSubject(string meetingMinutesSubjectID)
        {
            if (meetingMinutesSubjectID == "")
                meetingMinutesSubjectID = "0";

            string query = "SELECT * FROM tblMeetingMinutesSubject WHERE MeetingMinutesSubjectID = " + meetingMinutesSubjectID + " ";

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
        public static bool Remove(string meetingMinutesSubjectID)
        {
            string query = "";

            query = "DELETE FROM tblMeetingMinutesSubject WHERE MeetingMinutesSubjectID = " + meetingMinutesSubjectID;
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
            if (meetingMinutesSubjectID == "" || meetingMinutesSubjectID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblMeetingMinutesSubject(JobID, MeetingMinutesSubject) Values(" +
                    jobID + ", " + meetingMinutesSubject + ") " +
                    "Select @@IDENTITY ";
            try
            {
                meetingMinutesSubjectID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblMeetingMinutesSubject SET " +
                    " JobID                         = " + jobID + ", " +
                    " MeetingMinutesSubject         = " + meetingMinutesSubject + " " +
                    " WHERE MeetingMinutesSubjectID = " + meetingMinutesSubjectID;
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
