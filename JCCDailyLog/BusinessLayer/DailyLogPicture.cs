using ContraCostaElectric.DatabaseUtil;
using System;
using System.Data;
using System.Data.SqlClient;
namespace JCCDailyLog.BusinessLayer
{
    internal class DailyLogPicture
    {
        private string jobDailyLogPictureID;
        private readonly string jobDailyLogID;
        private readonly string pictureTitle;
        private readonly string picture;
        private readonly string include;
        //
        public DailyLogPicture ()
        {
        }
        //
        public DailyLogPicture ( string jobDailyLogPictureID,
                                            string jobDailyLogID,
                                            string pictureTitle,
                                            string picture,
                                            string include )
        {
            this.jobDailyLogPictureID = jobDailyLogPictureID;
            this.jobDailyLogID = jobDailyLogID;
            this.pictureTitle = "'" + pictureTitle.Trim().Replace("'", "''") + "'";
            this.picture = "'" + picture.Trim().Replace("'", "''") + "'";
            this.include = include == "True" ? "1" : "0";

        }
        //
        public string JobDailyLogPictureID => jobDailyLogPictureID;
        //
        public static DataSet GetPictures ( string jobDailyLogID )
        {

            string query = " SELECT *, ' ' AS Pic, CASE WHEN dbo.GetExtension(Picture) ='pdf' THEN 'PDF'"+
                            " WHEN LOWER ( dbo.GetExtension(Picture)) = 'jpg' THEN 'IMAGE' "+
                            " WHEN LOWER ( dbo.GetExtension(Picture)) = 'png' THEN 'IMAGE' "+
                            " WHEN LOWER ( dbo.GetExtension(Picture)) = 'jpeg' THEN 'IMAGE' "+
                            " WHEN LOWER ( dbo.GetExtension(Picture)) = 'gif' THEN 'IMAGE' "+
                            " WHEN LOWER ( dbo.GetExtension(Picture)) = 'raw' THEN 'IMAGE' "+
                            " WHEN LOWER ( dbo.GetExtension(Picture)) = 'bmp' THEN 'IMAGE' " +
                            " END AS FileExtension" +
                            " FROM tblJobDailyLogPictures " +
                            " WHERE JobDailyLogID = " + jobDailyLogID + " ";
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
        public static DataSet GetPicturesForReport ( string jobDailyLogID )
        {

            string query = " SELECT * " +
                           " FROM tblJobDailyLogPictures " +
                           " WHERE JobDailyLogID = " + jobDailyLogID + "  AND Include = 1 AND LOWER(Picture) NOT LIKE '%.pdf' ";
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
        public static bool Remove ( string jobDailyLogPictureID )
        {
            string query = "";

            query = "DELETE FROM tblJobDailyLogPictures WHERE JobDailyLogPictureID = " + jobDailyLogPictureID;
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
        public bool Save ()
        {
            if (jobDailyLogPictureID == "" || jobDailyLogPictureID == "0")
            {
                return Insert();
            }
            else
            {
                return Update();
            }
        }
        //
        private bool Insert ()
        {
            string query = "";

            query = "INSERT INTO tblJobDailyLogPictures(" +
                    " JobDailyLogID, " +
                    " PictureTitle, " +
                    " Picture, " +
                    " Include," +
                    " IsDeleted" +

                    " ) VALUES ( " +
                    jobDailyLogID + ", " +
                    pictureTitle + ", " +
                    picture + ", " +
                    include + ", " +
                    "0" + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobDailyLogPictureID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private bool Update ()
        {
            string query = "";

            query = "Update tblJobDailyLogPictures SET " +
                    " PictureTitle                  = " + pictureTitle + ", " +
                    " Picture                       = " + picture + ", " +
                    " include                         = " + include + " " +
                    " WHERE JobDailyLogPictureID   = " + jobDailyLogPictureID;
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
