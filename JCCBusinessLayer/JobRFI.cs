using ContraCostaElectric.DatabaseUtil;
using System;
using System.Data;

namespace JCCBusinessLayer
{
    public class JobRFI
    {
        private string jobRFIID;
        private readonly string jobID;
        private readonly string jobChangeOrderID;
        private string jobRFINumber;
        private string jobRFINumberRev;
        private readonly string RFIToContactID;
        private readonly string RFISubject;
        private readonly string RFIFromID;
        private readonly string RFIDate;
        private readonly string RFIText;
        private readonly string RFIGeneralNumber;
        private readonly string designDetailRequired;
        private readonly string delayJob;
        private readonly string discussedOnPhoneWith;
        private readonly string phoneDiscussionDate;
        private readonly string answeredNeededBy;
        private readonly string statusOpenClosed;
        private readonly string costImpactYesNo;
        private readonly string RFIResponse;
        private readonly string responseDate;
        private readonly string responseBy;
        private readonly string emailBody;
        private readonly string rfivoid;

        public string JobRFIID => jobRFIID;
        public string JobRFINumber => jobRFINumber;
        public string JobRFINumberRev => jobRFINumberRev;

        public JobRFI()
        {
        }
        public JobRFI(string jobRFIID,
                      string jobID,
                      string jobRFINumber,
                      string jobRFINumberRev,
                      string jobChangeOrderID,
                      string RFIToContactID,
                      string RFISubject,
                      string RFIFromID,
                      string RFIDate,
                      string RFIText,
                      string RFIGeneralNumber,
                      string designDetailRequired,
                      string delayJob,
                      string discussedOnPhoneWith,
                      string phoneDiscussionDate,
                      string answeredNeededBy,
                      string statusOpenClosed,
                      string costImpactYesNo,
                      string RFIResponse,
                      string responseDate,
                      string responseBy,
                      string emailBody,
                      string rfivoid)
        {
            this.jobRFIID = jobRFIID;
            this.jobID = String.IsNullOrEmpty(jobID) ? "Null" : jobID;
            this.jobRFINumber = "'" + jobRFINumber.Trim().Replace("'", "''") + "'";
            this.jobRFINumberRev = "'" + jobRFINumberRev.Trim().Replace("'", "''") + "'";
            this.jobChangeOrderID = String.IsNullOrEmpty(jobChangeOrderID) ? "Null" : jobChangeOrderID;
            this.RFIToContactID = String.IsNullOrEmpty(RFIToContactID) ? "Null" : RFIToContactID;
            this.RFISubject = "'" + RFISubject.Trim().Replace("'", "''") + "'";
            this.RFIFromID = String.IsNullOrEmpty(RFIFromID) ? "Null" : RFIFromID;
            this.RFIDate = String.IsNullOrEmpty(RFIDate) ? "Null" : "'" + RFIDate + "'";
            this.RFIText = "'" + RFIText.Trim().Replace("'", "''") + "'";
            this.RFIGeneralNumber = "'" + RFIGeneralNumber.Trim().Replace("'", "''") + "'";
            this.designDetailRequired = designDetailRequired == "True" ? "1" : "0";
            this.delayJob = delayJob == "True" ? "1" : "0";
            this.discussedOnPhoneWith = "'" + discussedOnPhoneWith.Trim().Replace("'", "''") + "'";
            this.phoneDiscussionDate = String.IsNullOrEmpty(phoneDiscussionDate) ? "Null" : "'" + phoneDiscussionDate + "'";
            this.answeredNeededBy = String.IsNullOrEmpty(answeredNeededBy) ? "Null" : "'" + answeredNeededBy + "'";
            this.statusOpenClosed = statusOpenClosed;
            this.costImpactYesNo = costImpactYesNo;
            this.RFIResponse = "'" + RFIResponse.Trim().Replace("'", "''") + "'";
            this.responseDate = String.IsNullOrEmpty(responseDate) ? "Null" : "'" + responseDate + "'";
            this.responseBy = "'" + responseBy.Trim().Replace("'", "''") + "'";
            this.emailBody = "'" + emailBody.Trim().Replace("'", "''") + "'";
            this.rfivoid = rfivoid == "True" ? "1" : "0";

        }
        //
        public static DataSet GetRFISheet(string jobRFIID)
        {
            string query = "";

            query = " SELECT " +
                    " Company = " +
                    " CASE c.LotusNotes " +
                    " WHEN 1 THEN cc.CompanyName " +
                    " ELSE dd.CompanyName " +
                    " End, " +
                    " CompanyTo = " +
                    " CASE c.LotusNotes " +
                    " WHEN 1 THEN  cc.FirstName + ' '  + cc.LastName " +
                    " ELSE dd.FirstName  + ' ' + dd.LastName " +
                    " End, " +
                    " RFISubject, " +
                    " JobRFINumber, " +
                    " JobRFINumberRev, " +
                    " RFIDate, " +
                    " JobNumber, " +
                    " JobName, " +
                    " CompanyFrom = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN  mm.FirstName + ' '  + mm.LastName " +
                    " ELSE nn.FirstName  + ' ' + nn.LastName " +
                    " End, " +
                    " RFIText, " +
                    " DesignDetailRequired, " +
                    " DelayJob, " +
                    " DiscussedOnPhoneWith, " +
                    " PhoneDiscussionDate, " +
                    " AnsweredNeededBy, " +
                    " RFIResponse, " +
                    " ISNULL(EmailBody, '') AS EmailBody, " +
                    " EmailTo = " +
                    " CASE c.LotusNotes " +
                    " WHEN 1 THEN  ISNULL(cc.Email, '') " +
                    " ELSE ISNULL(dd.Email, '') " +
                    " End, " +
                    " EmailFrom = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN  ISNULL(mm.Email, '')" +
                    " ELSE ISNULL(nn.Email, '') " +
                    " End, " +
                    " CostImpactYesNo " +
                    " FROM tblJobRFI r " +
                    " LEFT Join tblJob j ON r.JobID = j.JobID " +
                    " LEFT JOIN tblJobContact c ON r.RFIToContactID = c.ContactID " +
                    " LEFT JOIN tblCompanyContact cc ON c.CompanyContactID = cc.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail dd ON c.CompanyContactID = dd.JobContactDetailID " +
                    " LEFT JOIN tblJobContact l ON r.RFIFromID = l.ContactID " +
                    " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                    " WHERE r.JobRFIID =  " + jobRFIID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetRFISheetForNewJobs(string jobRFIID)
        {
            string query = "";

            query = " SELECT " +
                    " Company = " +
                    " CASE c.LotusNotes " +
                    " WHEN 1 THEN gc.CompanyName " +
                    " ELSE dd.CompanyName " +
                    " End, " +
                    " CompanyTo = " +
                    " CASE c.LotusNotes " +
                    " WHEN 1 THEN  gc.FirstName + ' '  + gc.LastName " +
                    " ELSE dd.FirstName  + ' ' + dd.LastName " +
                    " End, " +
                    " RFISubject, " +
                    " JobRFINumber, " +
                    " JobRFINumberRev, " +
                    " RFIDate, " +
                    " JobNumber, " +
                    " JobName, " +
                    " CompanyFrom = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN  gcc.FirstName + ' '  + gcc.LastName " +
                    " ELSE nn.FirstName  + ' ' + nn.LastName " +
                    " End, " +
                    " RFIText, " +
                    " DesignDetailRequired, " +
                    " DelayJob, " +
                    " DiscussedOnPhoneWith, " +
                    " PhoneDiscussionDate, " +
                    " AnsweredNeededBy, " +
                    " RFIResponse, " +
                    " ISNULL(EmailBody, '') AS EmailBody, " +
                    " EmailTo = " +
                    " CASE c.LotusNotes " +
                    " WHEN 1 THEN  ISNULL(gc.Email, '') " +
                    " ELSE ISNULL(dd.Email, '') " +
                    " End, " +
                    " EmailFrom = " +
                    " CASE l.LotusNotes " +
                    " WHEN 1 THEN  ISNULL(gcc.Email, '')" +
                    " ELSE ISNULL(nn.Email, '') " +
                    " End, " +
                    " CostImpactYesNo " +
                    " FROM tblJobRFI r " +
                    " LEFT Join tblJob j ON r.JobID = j.JobID " +
                    " LEFT JOIN tblJobContact c ON r.RFIToContactID = c.ContactID " +
                    //" LEFT JOIN tblCompanyContact cc ON c.CompanyContactID = cc.CompanyContactID " + 
                    " LEFT JOIN tblGlobalContact gc ON c.CompanyContactID = gc.GlobalContactID  " +
                    " LEFT JOIN tblJobContactDetail dd ON c.CompanyContactID = dd.JobContactDetailID " +
                    " LEFT JOIN tblJobContact l ON r.RFIFromID = l.ContactID " +
                   // " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                   "LEFT JOIN tblGlobalContact gcc ON l.CompanyContactID = gcc.GlobalContactID" +
                    " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                    " WHERE r.JobRFIID =  " + jobRFIID + " ";

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
        public static DataSet GetRFI(string jobRFIID)
        {
            string query = "";

            query = " SELECT * FROM tblJobRFI WHERE JobRFIID = " + jobRFIID + " ";

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
        public static DataSet GetJobRFI(string jobID)
        {
            string query = "";

            query = " SELECT " +
                    " JobRFIID, " +
                    " LTRIM(RTRIM(JobRFINumber)) + '.' + JobRFINumberRev AS [RFI No], " +
                    //" JobRFINumberRev AS [Rev No], " +
                    " RFIGeneralNumber AS [GC RFI No], " +
                    " RFISubject AS [Subject], " +
                    " RFIDate AS [RFI Date], " +
                    " ResponseDate AS [Response Date], " +
                    " [Status] =  " +
                    " CASE StatusOpenClosed " +
                    " WHEN 1 THEN 'Closed' " +
                    " ELSE 'Open' " +
                    " END , " +
                    " [Days Out] = " +
                    " CASE StatusOpenClosed " +
                    " WHEN 0 THEN " +
                    " DATEDIFF(Day, RFIDate, GetDATE()) " +
                    " END, " +
                    " JobChangeOrderNumber AS [Change Order #], " +
                    " Void, " +
                    " [Cost Impact] = " +
                    " CASE CostImpactYesNo " +
                    " WHEN 1 THEN 'No'" +
                    " ELSE 'Yes' " +
                    " END " +
                    " FROM tblJobRFI r  " +
                    " LEFT JOIN tblJobChangeOrder o ON r.JobChangeOrderID = o.JobChangeOrderID " +
                    " WHERE r.JobID = " + jobID + " " +
                    " ORDER BY JobRFINumber, JobRFINumberRev ";
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
        public bool Save()
        {
            if (jobRFIID == "" || jobRFIID == "0")
            {
                return Insert();
            }
            else
            {
                return Update();
            }
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobRFI(" +
                    " JobID, " +
                    " JobRFINumber, " +
                    " JobRFINumberRev, " +
                    " JobChangeOrderID, " +
                    " RFIToContactID, " +
                    " RFISubject, " +
                    " RFIFromID, " +
                    " RFIDate, " +
                    " RFIText, " +
                    " RFIGeneralNumber, " +
                    " DesignDetailRequired, " +
                    " DelayJob, " +
                    " DiscussedOnPhoneWith, " +
                    " PhoneDiscussionDate, " +
                    " AnsweredNeededBy, " +
                    " StatusOpenClosed, " +
                    " CostImpactYesNo, " +
                    " RFIResponse, " +
                    " ResponseDate, " +
                    " EmailBody, " +
                    " Void, " +
                    " ResponseBy) VALUES (" +
                    jobID + ", " +
                    jobRFINumber + ", " +
                    jobRFINumberRev + ", " +
                    jobChangeOrderID + ", " +
                    RFIToContactID + ", " +
                    RFISubject + ", " +
                    RFIFromID + ", " +
                    RFIDate + ", " +
                    RFIText + ", " +
                    RFIGeneralNumber + ", " +
                    designDetailRequired + ", " +
                    delayJob + ", " +
                    discussedOnPhoneWith + ", " +
                    phoneDiscussionDate + ", " +
                    answeredNeededBy + ", " +
                    statusOpenClosed + ", " +
                    costImpactYesNo + ", " +
                    RFIResponse + ", " +
                    responseDate + ", " +
                    emailBody + ", " +
                    rfivoid + ", " +
                    responseBy + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobRFIID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                query = "SELECT JobRFINumber, JobRFINumberRev FROM tblJobRFI WHERE JobRFIID = " + jobRFIID + " ";

                DataTable t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                {
                    jobRFINumber = t.Rows[0]["JobRFINumber"].ToString();
                    jobRFINumberRev = t.Rows[0]["JobRFINumberRev"].ToString();
                }
                else
                {
                    jobRFINumber = "";
                    jobRFINumberRev = "";
                }
                return true;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool Update()
        {
            string query = "";

            query = "Update tblJobRFI SET " +
                    " JobID                 = " + jobID + ", " +
                    " JobRFINumber          = " + jobRFINumber + ", " +
                    " JobRFINumberRev       = " + jobRFINumberRev + ", " +
                    " JobChangeOrderID      = " + jobChangeOrderID + ", " +
                    " RFIToContactID        = " + RFIToContactID + ", " +
                    " RFISubject            = " + RFISubject + ", " +
                    " RFIFromID             = " + RFIFromID + ", " +
                    " RFIDate               = " + RFIDate + ", " +
                    " RFIText               = " + RFIText + ", " +
                    " RFIGeneralNumber      = " + RFIGeneralNumber + ", " +
                    " DesignDetailRequired  = " + designDetailRequired + ", " +
                    " DelayJob              = " + delayJob + ", " +
                    " DiscussedOnPhoneWith  = " + discussedOnPhoneWith + ", " +
                    " PhoneDiscussionDate   = " + phoneDiscussionDate + ", " +
                    " AnsweredNeededBy      = " + answeredNeededBy + ", " +
                    " StatusOpenClosed      = " + statusOpenClosed + ", " +
                    " CostImpactYesNo       = " + costImpactYesNo + ", " +
                    " RFIResponse           = " + RFIResponse + ", " +
                    " ResponseDate          = " + responseDate + ", " +
                    " EmailBody             = " + emailBody + ", " +
                    " Void                  = " + rfivoid + ", " +
                    " ResponseBy            = " + responseBy + " " +
                    " WHERE JobRFIID  = " + jobRFIID;
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
