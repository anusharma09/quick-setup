using ContraCostaElectric.DatabaseUtil;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace JCCBusinessLayer
{
    public class Contact
    {
        private string companyContactID;
        private string jobContactDetailID;
        private string contactID;
        private readonly string jobID;
        private readonly string firstName;
        private readonly string lastName;
        private readonly string title;
        private readonly string email;
        private readonly string webSite;
        private readonly string companyName;
        private readonly string categories;
        private readonly string phoneNumber;
        private readonly string cellPhoneNumber;
        private readonly string officeStreetAddress;
        private readonly string officeCity;
        private readonly string officeState;
        private readonly string officeZip;
        private readonly string officeCountry;
        private readonly string officePhoneNumber;
        private readonly string officeFAXPhoneNumber;
        private string lotusNotes;
        public Contact ()
        {
        }
        //
        public Contact (
            string companyContactID,
            string jobID,
            string lotusNotes )
        {
            this.companyContactID = companyContactID;
            this.jobID = jobID;
            this.lotusNotes = lotusNotes == "True" ? "1" : "0";
        }
        //
        public Contact (
            string jobContactDetailID,
            string jobID,
            string firstName,
            string lastName,
            string title,
            string email,
            string webSite,
            string companyName,
            string categories,
            string phoneNumber,
            string cellPhoneNumber,
            string officeStreetAddress,
            string officeCity,
            string officeState,
            string officeZip,
            string officeCountry,
            string officePhoneNumber,
            string officeFAXPhoneNumber )
        {
            this.jobContactDetailID = jobContactDetailID;
            this.jobID = jobID;
            this.firstName = firstName.Trim().Replace("'", "''");
            this.lastName = lastName.Trim().Replace("'", "''");
            this.title = title.Trim().Replace("'", "''");
            this.email = email.Trim().Replace("'", "''");
            this.webSite = webSite.Trim().Replace("'", "''");
            this.companyName = companyName.Trim().Replace("'", "''");
            this.categories = categories.Trim().Replace("'", "''");
            this.phoneNumber = phoneNumber.Trim().Replace("'", "''");
            this.cellPhoneNumber = cellPhoneNumber.Trim().Replace("'", "''");
            this.officeStreetAddress = officeStreetAddress.Trim().Replace("'", "''");
            this.officeCity = officeCity.Trim().Replace("'", "''");
            this.officeState = officeState.Trim().Replace("'", "''");
            this.officeZip = officeZip.Trim().Replace("'", "''");
            this.officeCountry = officeCountry.Trim().Replace("'", "''");
            this.officePhoneNumber = officePhoneNumber.Trim().Replace("'", "''");
            this.officeFAXPhoneNumber = officeFAXPhoneNumber.Trim().Replace("'", "''");

        }
        //
        public string JobContactDetailID => jobContactDetailID;
        //
        public string ContactID => contactID;
        //
        public static DataSet GetContactList ( string where , int jobId)
        {
            string query = "";
            if (CheckIsJobNew(jobId))
            {
                query = " DECLARE @Selected     BIT " +
                        " DECLARE @ContactID	INT " +
                        " DECLARE @LotusNotes   BIT " +
                        " SET @Selected = 0 " +
                        " SET @LotusNotes = 1 " +
                        " SELECT " +
                        " GlobalContactID AS CompanyContactID, " +
                        " @ContactID AS ContactID, " +
                        " @Selected AS Selected, " +
                        " FirstName AS [First Name], " +
                        " LastName AS [Last Name], " +
                        " CompanyName AS [Company], " +
                        " @LotusNotes AS [Lotus Notes] " +
                        " FROM tblGlobalContact " + where + " " +
                        " ORDER BY LastName ";
            }
            else
            {
                query = " DECLARE @Selected     BIT " +
                        " DECLARE @ContactID	INT " +
                        " DECLARE @LotusNotes   BIT " +
                        " SET @Selected = 0 " +
                        " SET @LotusNotes = 1 " +
                        " SELECT " +
                        " CompanyContactID, " +
                        " @ContactID AS ContactID, " +
                        " @Selected AS Selected, " +
                        " FirstName AS [First Name], " +
                        " LastName AS [Last Name], " +
                        " CompanyName AS [Company], " +
                        " @LotusNotes AS [Lotus Notes] " +
                        " FROM tblCompanyContact " + where + " " +
                        " ORDER BY LastName ";
            }
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
        public static DataSet GetJobContactForPullDown ( string jobID )
        {
            string query = "";
            if (CheckIsJobNew(Convert.ToInt32(jobID)))
            {
                query = " SELECT " +
                    " ContactID, " +
                    " [Name] = " +
                    " CASE LotusNotes " +
                    "    WHEN 1 THEN  c.FirstName + ' '  + c.LastName " +
                    "    ELSE d.FirstName  + ' ' + d.LastName " +
                    " END, " +
                    " [Company] = " +
                    " CASE LotusNotes " +
                    "   WHEN 1 THEN c.CompanyName " +
                    "   ELSE d.CompanyName " +
                    " END  " +
                    " FROM tblJobContact j " +
                    " LEFT JOIN tblGlobalContact c ON j.CompanyContactID = c.GlobalContactID " +
                    " LEFT JOIN tblJobContactDetail d ON j.CompanyContactID = d.JobContactDetailID " +
                    " WHERE j.JobID = " + jobID + " " +
                    " ORDER BY [Name] ";
            }
            else
            { 
            query = " SELECT " +
                    " ContactID, " +
                    " [Name] = " +
                    " CASE LotusNotes " +
                    "    WHEN 1 THEN  c.FirstName + ' '  + c.LastName " +
                    "    ELSE d.FirstName  + ' ' + d.LastName " +
                    " END, " +
                    " [Company] = " +
                    " CASE LotusNotes " +
                    "   WHEN 1 THEN c.CompanyName " +
                    "   ELSE d.CompanyName " +
                    " END  " +
                    " FROM tblJobContact j " +
                    " LEFT JOIN tblCompanyContact c ON j.CompanyContactID = c.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail d ON j.CompanyContactID = d.JobContactDetailID " +
                    " WHERE j.JobID = " + jobID + " " +
                    " ORDER BY [Name] ";
                }
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
        public static DataSet GetJobContactCompanyForPullDown ( string jobID )
        {
            string query = "";
            if (CheckIsJobNew(Convert.ToInt32(jobID)))
            {
                query = " SELECT " +
                   " ContactID, " +
                   " [Company] = " +
                   " CASE LotusNotes " +
                   "   WHEN 1 THEN c.CompanyName " +
                   "   ELSE d.CompanyName " +
                   " END  " +
                   " FROM tblJobContact j " +
                   " LEFT JOIN tblGlobalContact c ON j.CompanyContactID = c.GlobalContactID " +
                   " LEFT JOIN tblJobContactDetail d ON j.CompanyContactID = d.JobContactDetailID " +
                   " WHERE j.JobID = " + jobID + " " +
                   " ORDER BY [Company] ";

                
            }
            else
            {
                query = " SELECT " +
                    " ContactID, " +
                    " [Company] = " +
                    " CASE LotusNotes " +
                    "   WHEN 1 THEN c.CompanyName " +
                    "   ELSE d.CompanyName " +
                    " END  " +
                    " FROM tblJobContact j " +
                    " LEFT JOIN tblCompanyContact c ON j.CompanyContactID = c.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail d ON j.CompanyContactID = d.JobContactDetailID " +
                    " WHERE j.JobID = " + jobID + " " +
                    " ORDER BY [Company] ";
            }
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
        public static DataSet GetJobContact ( string jobID )
        {
            string query = "";
            if (CheckIsJobNew(Convert.ToInt32(jobID)))
            {
                query = " DECLARE @Selected  BIT " +
                        " SET @Selected = 1 " +
                        " ;WITH CTE (GlobalContactID,ContactID,Selected,[First Name], [Last Name],[Company], [Lotus Notes]) AS " +
                        "(" +
                        " SELECT " +
                        " CompanyContactID = CASE LotusNotes     WHEN 1 THEN  c.GlobalContactID      ELSE j.CompanyContactID  END, " +
                        " ContactID, " +
                        " @Selected AS Selected, " +
                        " [First Name] = " +
                        " CASE LotusNotes " +
                        "    WHEN 1 THEN  c.FirstName  " +
                        "    ELSE d.FirstName " +
                        " END, " +
                        " [Last Name] = " +
                        " CASE LotusNotes " +
                        "    WHEN 1 THEN c.LastName " +
                        "    ELSE d.LastName " +
                        " END, " +
                        " [Company] = " +
                        " CASE LotusNotes " +
                        "   WHEN 1 THEN c.CompanyName " +
                        "   ELSE d.CompanyName " +
                        " END,  " +
                        " LotusNotes AS [Lotus Notes] " +
                        " FROM tblJobContact j " +
                        " LEFT JOIN tblGlobalContact c ON j.CompanyContactID = c.GlobalContactID " +
                        " LEFT JOIN tblJobContactDetail d ON j.CompanyContactID = d.JobContactDetailID " +
                        " WHERE j.JobID = " + jobID + " " +
                        ")" +
                        " SELECT GlobalContactID AS CompanyContactID,ContactID,Selected,[First Name], [Last Name],[Company],[Lotus Notes] from CTE where [First Name] IS NOT NULL AND [Last Name] IS NOT NULL AND Company IS NOT NULL " +
                        " ORDER BY CompanyContactID ";
            }
            else
            {
                query = " DECLARE @Selected  BIT " +
                        " SET @Selected = 1 " +
                        " ;WITH CTE (CompanyContactID,ContactID,Selected,[First Name], [Last Name],[Company], [Lotus Notes]) AS " +
                        "(" +
                        " SELECT " +
                        " c.CompanyContactID, " +
                        " ContactID, " +
                        " @Selected AS Selected, " +
                        " [First Name] = " +
                        " CASE LotusNotes " +
                        "    WHEN 1 THEN  c.FirstName  " +
                        "    ELSE d.FirstName " +
                        " END, " +
                        " [Last Name] = " +
                        " CASE LotusNotes " +
                        "    WHEN 1 THEN c.LastName " +
                        "    ELSE d.LastName " +
                        " END, " +
                        " [Company] = " +
                        " CASE LotusNotes " +
                        "   WHEN 1 THEN c.CompanyName " +
                        "   ELSE d.CompanyName " +
                        " END,  " +
                        " LotusNotes AS [Lotus Notes] " +
                        " FROM tblJobContact j " +
                        " LEFT JOIN tblCompanyContact c ON j.CompanyContactID = c.CompanyContactID " +
                        " LEFT JOIN tblJobContactDetail d ON j.CompanyContactID = d.JobContactDetailID " +
                        " WHERE j.JobID = " + jobID + " " +
                        ")" +
                        " SELECT CompanyContactID,ContactID,Selected,[First Name], [Last Name],[Company], [Lotus Notes] from CTE where [First Name] IS NOT NULL AND [Last Name] IS NOT NULL AND Company IS NOT NULL " +
                        " ORDER BY CompanyContactID ";
            }
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
        public static DataSet GetContact ( string companyContactID, string lotusNotes , int jobID)
        {
            string query = "";
            if (lotusNotes == "True")
            {
                if (CheckIsJobNew(jobID))
                    query = "SELECT * FROM tblGlobalContact WHERE GlobalContactID = '" + companyContactID + "' ";
                else
                    query = "SELECT * FROM tblCompanyContact WHERE CompanyContactID = '" + companyContactID + "' ";
            }
            else
            {
                query = "SELECT * FROM tblJobContactDetail WHERE JobContactDetailID = '" + companyContactID + "' ";
            }

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
        public static DataSet GetCompany (int jobID)
        {
            string query = "";
            if (CheckIsJobNew(jobID))
                query = "SELECT DISTINCT CompanyName FROM tblGlobalContact Order By CompanyName ";
            else
                query = "SELECT DISTINCT CompanyName FROM tblCompanyContact Order By CompanyName ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckIsJobNew (int jobId)
        {
            string query = "";
            bool isNew = false;
            query = "SELECT IsNewJob FROM tblJob WHERE JobID = " + jobId;
            try
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count>0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IsNewJob"].ToString()))
                        isNew = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsNewJob"]);
                    else
                        isNew = false;
                }
                return isNew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String CheckIfContactIsUpdated ( int jobId )
        {
            string query = "";
            StringBuilder contact = new StringBuilder();
            query = "SELECT CompanyContactID FROM tblJobContact WHERE IsContactUpdated = 1 AND JobID = " + jobId;
            try
            {
                DataSet ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count>0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataSet dsContact = getUpdatedContactInfo(Convert.ToInt32(ds.Tables[0].Rows[i]["CompanyContactID"]));
                        if (string.IsNullOrEmpty(contact.ToString()))
                        {
                            contact.Append(dsContact.Tables[0].Rows[0]["Name"]);
                            contact.Append(" ");
                            contact.Append(dsContact.Tables[0].Rows[0]["UpdatedColumns"]);
                            contact.Append(" has been updated.");
                        }
                        else
                        {
                            contact.Append(System.Environment.NewLine);
                            contact.Append(dsContact.Tables[0].Rows[0]["Name"]);
                            contact.Append(" ");
                            contact.Append(dsContact.Tables[0].Rows[0]["UpdatedColumns"]);
                            contact.Append(" has been updated.");
                        }
                    }
                }
                return contact.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet getUpdatedContactInfo ( int contactID )
        {
            string query = "";
            query = "SELECT  FirstName+' '+LastName AS Name, UpdatedColumns FROM tblGlobalContact WHERE GlobalContactID=" + contactID;
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
        public static DataSet GetLastName (int jobID)
        {
            string query = "";
            if (CheckIsJobNew(jobID))
                query = "SELECT DISTINCT LastName FROM tblGlobalContact ORder By LastName ";
            else
                query = "SELECT DISTINCT LastName FROM tblCompanyContact ORder By LastName ";
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
        public bool Save ()
        {
            return Insert();
        }
        //
        private bool Insert ()
        {
            string query = "";

            query = "INSERT INTO tblJobContact(CompanyContactID, JobID, LotusNotes) Values(" +
                    companyContactID + ", " + jobID + ", " + lotusNotes + ")" +
                    "Select @@IDENTITY ";
            try
            {
                contactID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool SaveDetail ()
        {
            if (jobContactDetailID == "" || jobContactDetailID == "0")
            {
                return InsertDetail();
            }
            else
            {
                return UpdateDetail();
            }
        }
        //
        private bool InsertDetail ()
        {
            string query = "";

            query = "INSERT INTO tblJobContactDetail(" +
                    " JobID, " +
                    " FirstName, " +
                    " LastName, " +
                    " Title, " +
                    " Email, " +
                    " WebSite, " +
                    " CompanyName, " +
                    " Categories, " +
                    " PhoneNumber, " +
                    " CellPhoneNumber, " +
                    " OfficeStreetAddress, " +
                    " OfficeCity, " +
                    " OfficeState, " +
                    " OfficeZip, " +
                    " OfficeCountry, " +
                    " OfficePhoneNumber, " +
                    " OfficeFAXPhoneNumber) Values(" +
                    jobID + ", " +
                    "'" + firstName + "', " +
                    "'" + lastName + "', " +
                    "'" + title + "', " +
                    "'" + email + "', " +
                    "'" + webSite + "', " +
                    "'" + companyName + "', " +
                    "'" + categories + "', " +
                    "'" + phoneNumber + "', " +
                    "'" + cellPhoneNumber + "', " +
                    "'" + officeStreetAddress + "', " +
                    "'" + officeCity + "', " +
                    "'" + officeState + "', " +
                    "'" + officeZip + "', " +
                    "'" + officeCountry + "', " +
                    "'" + officePhoneNumber + "', " +
                    "'" + officeFAXPhoneNumber + "') " +
                    "Select @@IDENTITY ";
            try
            {
                jobContactDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                companyContactID = jobContactDetailID;
                lotusNotes = "0";
                Insert();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private bool UpdateDetail ()
        {
            string query = "";

            query = "UPDATE tblJobContactDetail SET " +
                    " JobID             =  " + jobID + ", " +
                    " FirstName         = '" + firstName + "', " +
                    " LastName          = '" + lastName + "', " +
                    " Title             = '" + title + "', " +
                    " Email             = '" + email + "', " +
                    " WebSite           = '" + webSite + "', " +
                    " CompanyName       = '" + companyName + "', " +
                    " Categories        = '" + categories + "', " +
                    " PhoneNumber       = '" + phoneNumber + "', " +
                    " CellPhoneNumber   = '" + cellPhoneNumber + "', " +
                    " OfficeStreetAddress = '" + officeStreetAddress + "', " +
                    " OfficeCity        = '" + officeCity + "', " +
                    " OfficeState       = '" + officeState + "', " +
                    " OfficeZip         = '" + officeZip + "', " +
                    " OfficeCountry     = '" + officeCountry + "', " +
                    " OfficePhoneNumber = '" + officePhoneNumber + "', " +
                    " OfficeFAXPhoneNumber = '" + officeFAXPhoneNumber + "' " +
                    " WHERE JobContactDetailID = " + jobContactDetailID + " ";

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

        public static void UpdateJobContact (int jobId)
        {
            string query = "";

            query = "UPDATE tblJobContact SET IsContactUpdated = 0 WHERE IsContactUpdated =1 AND JobID = " + jobId;

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
        public static void Delete ( string contactID )
        {
            int countUser = 0;
            string queryForMasterProposalContact = string.Empty;
             queryForMasterProposalContact = " select count(*) as count from tblMasterProposalDetails where [User] = " + contactID + " ";
             countUser = Convert.ToInt32(DataBaseUtil.ExecuteScalar(queryForMasterProposalContact, CCEApplication.Connection, CommandType.Text));

            if (countUser > 0)
            { throw new Exception("Contact is used and can't be deleted"); }
            else
            { }
           


            string query = "";

            query = "Delete FROM tblJobContact WHERE ContactID = " + contactID + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception)
            {
                Exception e = new Exception("Contact is used and can't be deleted");
                throw e;
            }
        }
        //
        public static void DeleteDetail ( string jobContactDetailID )
        {
            string query = "";

            query = "Delete FROM tblJobContactDetail WHERE JobContactDetailID = " + jobContactDetailID + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetAssignedUsers ( string jobID )
        {
            string query = "";

            query = " DECLARE @Selected  BIT " +
                    " DECLARE @UnSelected  BIT " +
                    " SET @Selected = 1 " +
                    " SET @UnSelected = 0 " +
                    " SELECT @Selected AS Selected, U.UserID,UserLANID,UserName,Email,UJ.ReadOnly FROM tblUser U INNER JOIN tblUserJob UJ ON U.UserID = UJ.UserID  INNER JOIN tblJob J ON UJ.JobNumber = J.JobNumber WHERE J.JobID = " + jobID +
                    " UNION " +
                    " SELECT @UnSelected AS Selected, U.UserID,UserLANID,UserName,Email,UJ.ReadOnly FROM tblUser U INNER JOIN tblUserJobHistory UJ ON U.UserID = UJ.UserID  INNER JOIN tblJob J ON UJ.JobNumber = J.JobNumber WHERE J.JobID = " + jobID;
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetUsers ()
        {
            string query = "";

            query = " SELECT UserLANID FROM tblUser";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetUserList ( string userName )
        {
            string query = "";

            query = " SELECT 0 AS Selected, UserID, UserLANID,UserName,Email, 0 AS ReadOnly FROM tblUser  WHERE UserLANID= '" + userName + "'";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AssignUserToJob ( string jobID, int userID, bool readOnly )
        {
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@UserID", userID);
            par[1] = new SqlParameter("@JobID", jobID);
            par[2] = new SqlParameter("@ReadOnly", readOnly);

            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.up_AssignUserJob", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteAssignedUserToJob ( string jobID, int userID , bool readOnly )
        {
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@UserID", userID);
            par[1] = new SqlParameter("@JobID", jobID);
            par[2] = new SqlParameter("@ReadOnly", readOnly);
            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.up_DeleteAssignedUserJob", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
