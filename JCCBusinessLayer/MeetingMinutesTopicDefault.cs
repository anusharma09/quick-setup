using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class MeetingMinutesTopicDefault
    {

        public MeetingMinutesTopicDefault()
        {
        }
        //
        public static DataSet GetMeetingMinutesTopicDefault()
        {
            string query = "";

            query = " SELECT '' AS MeetingMinutesTopicID, " +
                    " '' AS MeetingMinutesSubjectID,  " +
                    " MeetingMinutesTopicDefault AS Topic FROM tblMeetingMinutesTopicDefault ";

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
